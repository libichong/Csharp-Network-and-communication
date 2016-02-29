using System;
using System.Net;
using System.Net.Sockets;

namespace MyOutlook
{
	/// <summary>
	/// Pop3MailOperation 的摘要说明。
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


		//连接服务器, 如果isReceive为true就连接接收服务器
		//否则连接发送服务器
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
				repMsg += "服务器地址无效，退出";
				return false;
			}

			if (port=="") 
			{
				//使用缺省的端口
				if (isReceive) 
				{
					port = "110";
				}
				else 
				{
					port = "25";
				}
			}


			repMsg = "连接邮箱：" + ma.Account + " ... \n";
			client=new TcpClient(server,System.Convert.ToInt32(port));
			stream=client.GetStream();

			string response=ReceiveResponse();
			repMsg += "\n服务器响应：" + response+"\n";

			if ((repMsg.IndexOf("OK")>=0) || (repMsg.IndexOf("220")>=0))
			{
				//连接成功
				connected = true;

				state = CONNECTED;
				if ((!isReceive) && (!ma.OutServerRequireAuth))
				{
					state = TRANSACTION;
				}
			}

			return connected;
		}

		//获取响应
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

		//向服务器发送执行命令
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
				Console.WriteLine("发送命令异常: " + e.ToString());
			}

		}

		//登录服务器
		public bool Pop3Login(ref string repMsg)
		{
			string response;

			if (state != CONNECTED) 
			{
				repMsg = "请先执行Login操作";
				return false;
			}

			repMsg = "登录服务器...\n";
			 
			//输入用户名
			SendCommand("user "+this.mailAccount.InServerUser);
			response=ReceiveResponse();
			repMsg += "验证用户..." + response + "\n";

			if (response.IndexOf("OK") < 0)
			{
				repMsg += "登录错误！";
				return false;
			}

			//输入密码
			SendCommand("pass "+ this.mailAccount.InServerPassword);
			response=ReceiveResponse();
			repMsg += "验证密码..." + response + "\n";
			if (response.IndexOf("OK")<0) 
			{
				repMsg += "登录错误！";
				return false;
			}

			repMsg += "成功登录服务器\n";
			state = TRANSACTION;
			return true;
		}


		//获得邮件数目
		public int GetMailNumber(ref string repMsg)
		{
			if (state != TRANSACTION) 
			{
				repMsg = "请先执行Login操作";
				return 0;
			}

			repMsg = "读取邮件数目...\n";
			SendCommand("stat");
			string response = ReceiveResponse();
			repMsg += "服务器响应： " + response + "\n";

			if (response.IndexOf("OK")<0)
			{
				repMsg += "列邮件错误！";
				return 0;
			}

			char[] a = new char[]{' '};
			string[] mess = response.Split(a);
			int mailNumber = Int32.Parse(mess[1]);

			repMsg += "共有" + mailNumber + " 封邮件\n" ;
			return mailNumber;
		}


		//List邮件
		public bool ListMails(ref string repMsg)
		{
			if (state != TRANSACTION) 
			{
				repMsg = "请先执行Login操作";
				return false;
			}
			
			repMsg = "列邮件...\n";
			SendCommand("list");
			string response = ReceiveResponse();
			repMsg += "服务器响应： " + response + "\n";
			if (response.IndexOf("OK")<0)
			{
				repMsg += "读取邮件数目错误！";
				return false;
			}

			return true;
		}

		//接收邮件，返回接收到的新邮件
		public Mail Receive(ref string repMsg, int mailid)
		{
			Mail mail = new Mail();
			string response;

			if (state != TRANSACTION) 
			{
				repMsg = "请先执行Login操作";
				return null;
			}

			repMsg = "接收邮件...\n";
			 

			SendCommand("retr " + System.Convert.ToString(mailid));
			response=ReceiveResponse();
			repMsg += "读取邮件服务器响应： " + response + "\n";
			if (response.IndexOf("OK")<0)
			{
				repMsg += "读取邮件错误！";
				return null;
			}

			int len = 0;
			byte[] bb=new byte[6400];
				len = stream.Read(bb,0,bb.Length);
			string read=System.Text.Encoding.UTF8.GetString(bb,0,len);
			
			//解析内容
			Console.WriteLine(read);
			ParserMail(read, ref mail);
			mail.MailStorePosition = Mail.IN_BOX;

			if (!this.mailAccount.IsLeaveMessage)
			{
				//删除邮件
				repMsg += "删除邮件...\n";
				SendCommand("dele 1");
				response = ReceiveResponse();
				repMsg += "服务器响应： " + response + "\n";
				if (response.IndexOf("OK")<0)
				{
					repMsg += "删除邮件数目错误！";
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
							break;	//读取完毕
						}
						//读取邮件内容
						mail.MailContent += lstr + "\r\n";
					}
					if (lstr.IndexOf("Content-Transfer-Encoding:")>=0)
					{
						readContent = true;
					}
				}
			}
		}

		//解析纯文本邮件
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
						continue;	//忽略头部内容
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
						//读取邮件内容
						mail.MailContent += lstr + "\r\n";
					}
				}
			}
		}

		//退出服务器的连接
		public bool Close(ref string repMsg)
		{
			repMsg = "退出服务器...\n";
			SendCommand("QUIT\r\n");
			string response=ReceiveResponse();
			repMsg += "服务器响应： " + response + "\n";
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


		//发送邮件
		public bool Send(Mail mail, ref string repMsg)
		{
			string response;

			if (state != TRANSACTION) 
			{
				repMsg = "请先执行Login操作";
				return false;
			}

			repMsg = "发送邮件...\r\n";

			string user;
				//正在验证身份
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
			repMsg += "邮件服务器响应： " + response + "\r\n";
			if (response.IndexOf("250")<0)
			{
				repMsg += "错误！";
				return false;
			}


			repMsg += "RCPT TO...";
			SendCommand("RCPT TO:<"+mail.Recipient+">");
			response=ReceiveResponse();
			repMsg += "邮件服务器响应： " + response + "\r\n";
			if (response.IndexOf("250")<0)
			{
				repMsg += "错误！";
				return false;
			}

			repMsg += "DATA...";
			SendCommand("DATA");
			response=ReceiveResponse();
			repMsg += "邮件服务器响应： " + response + "\r\n";
			if (response.IndexOf("354")<0)
			{
				repMsg += "错误！";
				return false;
			}


			repMsg += "SendMail...";
			string content = "Subject: " + mail.Subject + "\r\n";
			content += "To: " + mail.Recipient + "\r\n";
			content += "Cc: " + mail.Cc + "\r\n";
			content += "\r\n" + mail.MailContent + "\r\n.\r\n";
			SendMail(content);
			response=ReceiveResponse();
			repMsg += "邮件服务器响应： " + response + "\r\n";
			if (response.IndexOf("250")<0)
			{
				repMsg += "错误！";
				return false;
			}

			repMsg += "发送完成\n";
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
				repMsg = "请先执行Connect操作";
				return false;
			}

			repMsg = "登录系统...\n";

			string hostName = Dns.GetHostName();
			SendCommand("HELO "+hostName);
			response=ReceiveResponse();
			repMsg += ("邮件服务器响应： " + response + "\n");
			if (response.IndexOf("250")<0)
			{
				repMsg += "错误！";
				return false;
			}

			string Pwd, UserName;
			if (this.mailAccount.OutServerRequireAuth)
			{
				//正在验证身份
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
					repMsg += "错误！";
					return false;
				}

						
				SendCommand(UserName);
				response=ReceiveResponse();
				if (response.IndexOf("334")<0)
				{
					repMsg += "登录错误！";
					return false;
				}
				repMsg += "身份验证...OK\n";
						
				SendCommand(Pwd);
				response=ReceiveResponse();
				repMsg += "验证密码...邮件服务器响应： " + response + "\n";
				if (response.IndexOf("235")<0)
				{
					repMsg += "登录错误！";
					return false;
				}
			}

			state = TRANSACTION;
			return true;
		}
	}
}
