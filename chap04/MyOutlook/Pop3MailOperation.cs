using System;
using System.Net;
using System.Net.Sockets;

namespace MyOutlook
{
	/// <summary>
	/// Pop3MailOperation ��ժҪ˵����
	/// </summary>

	public class Pop3MailOperation:Operation
	{
		public static int CLOSED = 0;
		public static int CONNECTED = 1;
		public static int TRANSACTION = 2;
		//public static int LIST_MAILS = 3;
		public static int FINISHED = 9;

		private TcpClient client;
		private NetworkStream stream;
		private int state = CLOSED;
		private MailAccount mailAccount;

		private System.Windows.Forms.RichTextBox ResInfo=new System.Windows.Forms.RichTextBox();

		public Pop3MailOperation()
		{
		}


		//���ӷ�����, ���isReceiveΪtrue�����ӽ��շ�����
		//�������ӷ��ͷ�����
		public bool Connect(MailAccount ma, bool isReceive,
			 ref string repMsg)
		{
			this.mailAccount = ma;
            bool connected = false;
			string server, port, user, psw;
			if (isReceive)
			{
				server = ma.InServer;
				port = ma.InServerPort;
				
				user = ma.InServerUser;
				psw = ma.InServerPassword;
			}
			else {
				server = ma.OutServer;
				port = ma.OutServerPort;

				if (ma.OutServerRequireAuth) 
				{
					if (ma.IsTheSameWithIncoming)
					{
						user = ma.InServerUser;
						psw = ma.InServerPassword;
					}
					else 
					{
						user = ma.OutServerUser;
						psw = ma.OutServerPassword;
					}
				}
			}

			if (server == "") 
			{
				repMsg += "��������ַ��Ч���˳�";
				return false;
			}

			if (port=="") 
			{
				//ʹ��ȱʡ�Ķ˿�
				if (isReceive) 
				{
					port = "110";
				}
				else 
				{
					port = "25";
				}
			}


			repMsg = "�������䣺" + ma.Account + " ... \n";
			client=new TcpClient(server,System.Convert.ToInt32(port));
			stream=client.GetStream();

			string response=ReceiveResponse();
			repMsg += "\n��������Ӧ��" + response+"\n";

			if ((repMsg.IndexOf("OK")>=0) || (repMsg.IndexOf("220")>=0))
			{
				//���ӳɹ�
				connected = true;

				state = CONNECTED;
				if ((!isReceive) && (!ma.OutServerRequireAuth))
				{
					state = TRANSACTION;
				}
			}

			return connected;
		}

		//��ȡ��Ӧ
		private string ReceiveResponse()
		{
			byte[] bb=new byte[512];
			try
			{
				int len = stream.Read(bb,0,bb.Length);
				string read=System.Text.Encoding.UTF8.GetString(bb);
				return read.Substring(0, len);
			}
			catch (Exception e)
			{
				return e.ToString();
			}
		}

		//�����������ִ������
		private void SendCommand(string command)
		{
			try 
			{
				string stringToSend=command+"\r\n";
				byte[] arrayToSend=System.Text.Encoding.Default.GetBytes(
					stringToSend.ToCharArray());
				stream.Write(arrayToSend,0,arrayToSend.Length);
			} 
			catch (Exception e)
			{
				Console.WriteLine("���������쳣: " + e.ToString());
			}

		}

		//��¼������
		public bool Pop3Login(ref string repMsg)
		{
			string response;

			if (state != CONNECTED) 
			{
				repMsg = "����ִ��Login����";
				return false;
			}

			repMsg = "��¼������...\n";
			 
			//�����û���
			SendCommand("user "+this.mailAccount.InServerUser);
			response=ReceiveResponse();
			repMsg += "��֤�û�..." + response + "\n";

			if (response.IndexOf("OK") < 0)
			{
				repMsg += "��¼����";
				return false;
			}

			//��������
			SendCommand("pass "+ this.mailAccount.InServerPassword);
			response=ReceiveResponse();
			repMsg += "��֤����..." + response + "\n";
			if (response.IndexOf("OK")<0) 
			{
				repMsg += "��¼����";
				return false;
			}

			repMsg += "�ɹ���¼������\n";
			state = TRANSACTION;
			return true;
		}


		//����ʼ���Ŀ
		public int GetMailNumber(ref string repMsg)
		{
			if (state != TRANSACTION) 
			{
				repMsg = "����ִ��Login����";
				return 0;
			}

			repMsg = "��ȡ�ʼ���Ŀ...\n";
			SendCommand("stat");
			string response = ReceiveResponse();
			repMsg += "��������Ӧ�� " + response + "\n";

			if (response.IndexOf("OK")<0)
			{
				repMsg += "���ʼ�����";
				return 0;
			}

			char[] a = new char[]{' '};
			string[] mess = response.Split(a);
			int mailNumber = Int32.Parse(mess[1]);

			repMsg += "����" + mailNumber + " ���ʼ�\n" ;
			return mailNumber;
		}


		//List�ʼ�
		public bool ListMails(ref string repMsg)
		{
			if (state != TRANSACTION) 
			{
				repMsg = "����ִ��Login����";
				return false;
			}
			
			repMsg = "���ʼ�...\n";
			SendCommand("list");
			string response = ReceiveResponse();
			repMsg += "��������Ӧ�� " + response + "\n";
			if (response.IndexOf("OK")<0)
			{
				repMsg += "��ȡ�ʼ���Ŀ����";
				return false;
			}

			return true;
		}

		//�����ʼ������ؽ��յ������ʼ�
		public Mail Receive(ref string repMsg, int mailid)
		{
			Mail mail = new Mail();
			string response;

			if (state != TRANSACTION) 
			{
				repMsg = "����ִ��Login����";
				return null;
			}

			repMsg = "�����ʼ�...\n";
			 

			SendCommand("retr " + System.Convert.ToString(mailid));
			response=ReceiveResponse();
			repMsg += "��ȡ�ʼ���������Ӧ�� " + response + "\n";
			if (response.IndexOf("OK")<0)
			{
				repMsg += "��ȡ�ʼ�����";
				return null;
			}

			int len = 0;
			byte[] bb=new byte[6400];
				len = stream.Read(bb,0,bb.Length);
			string read=System.Text.Encoding.UTF8.GetString(bb,0,len);
			
			//��������
			Console.WriteLine(read);
			ParserMail(read, ref mail);
			mail.MailStorePosition = Mail.IN_BOX;

			if (!this.mailAccount.IsLeaveMessage)
			{
				//ɾ���ʼ�
				repMsg += "ɾ���ʼ�...\n";
				SendCommand("dele 1");
				response = ReceiveResponse();
				repMsg += "��������Ӧ�� " + response + "\n";
				if (response.IndexOf("OK")<0)
				{
					repMsg += "ɾ���ʼ���Ŀ����";
					return null;
				}
			}
			return mail;																	   
		}

		private void ParserMail(string content, ref Mail mail)
		{			
			if (content.IndexOf("MIME-Version:")>-1)
			{
				ParserMIMETypeMail(content, ref mail);
			}
			else 
			{
				ParserTextMail(content, ref mail);
			}
		}

		private void ParserMIMETypeMail(string content, ref Mail mail)
		{
			System.IO.StringReader sr = new System.IO.StringReader(content);

			bool readContent = false;
			bool readHeader = true;
			while (sr.Peek() >= 0) 
			{
				string lstr = sr.ReadLine();
				if (lstr.IndexOf("----=")>=0)
				{
					readHeader = false;
				}
				
				if (readHeader)
				{
					if (lstr.IndexOf("From:")>=0)
					{
						int start = lstr.IndexOf("<");
						int end = lstr.IndexOf(">");
						if ((start>=0)&&(end>=0))
						{
							mail.Sender = lstr.Substring(start+1, end - start-1);
						}
						else
						{
							mail.Sender = lstr.Substring(5);
						}
					}
					else if (lstr.IndexOf("To:")>=0)
					{
						mail.Recipient = this.mailAccount.Account;
					}
					else if (lstr.IndexOf("Subject:")>=0)
					{
						int start = lstr.IndexOf(":");;
						mail.Subject = lstr.Substring(start+1);
					}
					else if (lstr.IndexOf("Date:")>=0)
					{
						int start = lstr.IndexOf(":");;
						mail.Time = lstr.Substring(start+1);
					}
				}
				else 
				{	
					if (readContent)
					{
						if (lstr.IndexOf("------=_NextPart")>=0)
						{
							readContent = false;
							break;	//��ȡ���
						}
						//��ȡ�ʼ�����
						mail.MailContent += lstr + "\r\n";
					}
					if (lstr.IndexOf("Content-Transfer-Encoding:")>=0)
					{
						readContent = true;
					}
				}
			}
		}

		//�������ı��ʼ�
		private void ParserTextMail(string content, ref Mail mail)
		{
			System.IO.StringReader sr = new System.IO.StringReader(content);
			
			bool readHeader = true;
			while (sr.Peek() >= 0) 
			{
				string lstr = sr.ReadLine();

				if (readHeader)
				{
					if (lstr.IndexOf("Subject:")<0)
					{
						continue;	//����ͷ������
					}
					else 
					{
						readHeader = false;
						int start = lstr.IndexOf(": ");
						mail.Subject = lstr.Substring(start+1).Trim();
					}
				}
				else 
				{
					if (lstr.IndexOf("To:")>=0)
					{
						int start = lstr.IndexOf(": ");
						mail.Recipient = lstr.Substring(start+1).Trim();
					}
					else if (lstr.IndexOf("Cc: ")>=0)
					{
						int start = lstr.IndexOf(": ");
						mail.Cc = lstr.Substring(start+1).Trim();
					}
					else if (lstr.IndexOf("Date:")>=0)
					{
						int start = lstr.IndexOf(": ");
						mail.Time = lstr.Substring(start+1).Trim();
					}
					else if (lstr.IndexOf("From:")>=0)
					{
						int start = lstr.IndexOf(": ");
						mail.Sender = lstr.Substring(start+1).Trim();
					}
					else if (lstr.IndexOf("Message-Id:")>=0)
					{
						continue;
					}
					else
					{
						//��ȡ�ʼ�����
						mail.MailContent += lstr + "\r\n";
					}
				}
			}
		}

		//�˳�������������
		public bool Close(ref string repMsg)
		{
			repMsg = "�˳�������...\n";
			SendCommand("QUIT\r\n");
			string response=ReceiveResponse();
			repMsg += "��������Ӧ�� " + response + "\n";
			state = CLOSED;
			return true;
		}


		private string AsciiToBase64(string AsciiMsg)
		{
			byte[] AsciiBytes=new byte[512];
			byte[] Base64Bytes=new byte[512];
			string AsciiMsg1=null;
			string Base64Msg=null;
			switch(AsciiMsg.Length%3)
			{
				case 1:
				{
					AsciiMsg1=AsciiMsg+"\0\0";
					break;
				}
				case 2:
				{
					AsciiMsg1=AsciiMsg+"\0";
					break;
				}
				default:
				{
					AsciiMsg1=AsciiMsg;
					break;
				}
			}
			for(int i=0;i<AsciiMsg1.Length/3;i++)
			{
				string AsciiMsg2=AsciiMsg1.Substring(i*3,3);
				AsciiBytes=System.Text.Encoding.ASCII.GetBytes(AsciiMsg2);
				System.Security.Cryptography.ToBase64Transform transformer=new System.Security.Cryptography.ToBase64Transform();
				transformer.TransformBlock(AsciiBytes,0,AsciiBytes.Length,Base64Bytes,0);
				string str=System.Text.Encoding.ASCII.GetString(Base64Bytes,0,Base64Bytes.Length);
				str=str.Substring(0,4);
				Base64Msg+=str;
			}
			return Base64Msg;
		}


		//�����ʼ�
		public bool Send(Mail mail, ref string repMsg)
		{
			string response;

			if (state != TRANSACTION) 
			{
				repMsg = "����ִ��Login����";
				return false;
			}

			repMsg = "�����ʼ�...\r\n";

			string user;
				//������֤���
			if (this.mailAccount.IsTheSameWithIncoming)
			{
				user = this.mailAccount.InServerUser;
			}
			else 
			{
			
				user = this.mailAccount.OutServerUser;
			}

			repMsg += "MAIL FROM...";
			SendCommand("MAIL FROM:<" + this.mailAccount.Account + ">");
			response=ReceiveResponse();
			repMsg += "�ʼ���������Ӧ�� " + response + "\r\n";
			if (response.IndexOf("250")<0)
			{
				repMsg += "����";
				return false;
			}


			repMsg += "RCPT TO...";
			SendCommand("RCPT TO:<"+mail.Recipient+">");
			response=ReceiveResponse();
			repMsg += "�ʼ���������Ӧ�� " + response + "\r\n";
			if (response.IndexOf("250")<0)
			{
				repMsg += "����";
				return false;
			}

			repMsg += "DATA...";
			SendCommand("DATA");
			response=ReceiveResponse();
			repMsg += "�ʼ���������Ӧ�� " + response + "\r\n";
			if (response.IndexOf("354")<0)
			{
				repMsg += "����";
				return false;
			}


			repMsg += "SendMail...";
			string content = "Subject: " + mail.Subject + "\r\n";
			content += "To: " + mail.Recipient + "\r\n";
			content += "Cc: " + mail.Cc + "\r\n";
			content += "\r\n" + mail.MailContent + "\r\n.\r\n";
			SendMail(content);
			response=ReceiveResponse();
			repMsg += "�ʼ���������Ӧ�� " + response + "\r\n";
			if (response.IndexOf("250")<0)
			{
				repMsg += "����";
				return false;
			}

			repMsg += "�������\n";
			return true;
		}

		public void SendMail(string message)
		{
			byte[] arrayToSend=System.Text.Encoding.UTF8.GetBytes(message.ToCharArray());
			stream.Write(arrayToSend,0,arrayToSend.Length);
		}
		
		public bool SmtpLogin(ref string repMsg)
		{
			string response;
			
			//System.Text.StringBuilder sb = new System.Text.StringBuilder();
			//sb.

			//String

			if (state != CONNECTED) 
			{
				repMsg = "����ִ��Connect����";
				return false;
			}

			repMsg = "��¼ϵͳ...\n";

			string hostName = Dns.GetHostName();
			SendCommand("HELO "+hostName);
			response=ReceiveResponse();
			repMsg += ("�ʼ���������Ӧ�� " + response + "\n");
			if (response.IndexOf("250")<0)
			{
				repMsg += "����";
				return false;
			}

			string Pwd, UserName;
			if (this.mailAccount.OutServerRequireAuth)
			{
				//������֤���
				if (this.mailAccount.IsTheSameWithIncoming)
				{
					UserName = AsciiToBase64(this.mailAccount.InServerUser);
					Pwd = AsciiToBase64(this.mailAccount.InServerPassword);
				}
				else 
				{
			
					UserName=AsciiToBase64(this.mailAccount.OutServerUser);
					Pwd=AsciiToBase64(this.mailAccount.OutServerPassword);
				}

				SendCommand("AUTH LOGIN");
				response=ReceiveResponse();
				if (response.IndexOf("334")<0)
				{
					repMsg += "����";
					return false;
				}

						
				SendCommand(UserName);
				response=ReceiveResponse();
				if (response.IndexOf("334")<0)
				{
					repMsg += "��¼����";
					return false;
				}
				repMsg += "�����֤...OK\n";
						
				SendCommand(Pwd);
				response=ReceiveResponse();
				repMsg += "��֤����...�ʼ���������Ӧ�� " + response + "\n";
				if (response.IndexOf("235")<0)
				{
					repMsg += "��¼����";
					return false;
				}
			}

			state = TRANSACTION;
			return true;
		}
	}
}
