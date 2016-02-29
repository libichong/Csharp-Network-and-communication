using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ChatServer
{
	public class ClientSeverForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private System.Windows.Forms.GroupBox grpSocket;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbSocketPort;
		private System.Windows.Forms.TextBox tbSocketClientsNum;
		private System.Windows.Forms.RichTextBox rtbSocketMsg;
		private System.Windows.Forms.Button btnSocketStart;
		private System.Windows.Forms.Button btnSocketStop;
		private System.Windows.Forms.ListBox lbSocketClients;

		//clients���鱣�浱ǰ�����û���Client����
		internal static Hashtable clients=new Hashtable();
		
		//�÷�����Ĭ�ϵļ����Ķ˿ں�
		private TcpListener listener;
		
		//����������֧�ֵ����Ŀͻ��˵�������
		static int MAX_NUM=100;
		
		//��ʼ����ı�־
		internal static bool SocketServiceFlag = false;

		public ClientSeverForm()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ClientSeverForm));
			this.grpSocket = new System.Windows.Forms.GroupBox();
			this.lbSocketClients = new System.Windows.Forms.ListBox();
			this.btnSocketStop = new System.Windows.Forms.Button();
			this.rtbSocketMsg = new System.Windows.Forms.RichTextBox();
			this.btnSocketStart = new System.Windows.Forms.Button();
			this.tbSocketPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbSocketClientsNum = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.grpSocket.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpSocket
			// 
			this.grpSocket.Controls.Add(this.lbSocketClients);
			this.grpSocket.Controls.Add(this.btnSocketStop);
			this.grpSocket.Controls.Add(this.rtbSocketMsg);
			this.grpSocket.Controls.Add(this.btnSocketStart);
			this.grpSocket.Controls.Add(this.tbSocketPort);
			this.grpSocket.Controls.Add(this.label1);
			this.grpSocket.Controls.Add(this.tbSocketClientsNum);
			this.grpSocket.Controls.Add(this.label3);
			this.grpSocket.Location = new System.Drawing.Point(16, 16);
			this.grpSocket.Name = "grpSocket";
			this.grpSocket.Size = new System.Drawing.Size(784, 368);
			this.grpSocket.TabIndex = 13;
			this.grpSocket.TabStop = false;
			this.grpSocket.Text = "Socket���Ӽ���";
			// 
			// lbSocketClients
			// 
			this.lbSocketClients.Location = new System.Drawing.Point(8, 64);
			this.lbSocketClients.Name = "lbSocketClients";
			this.lbSocketClients.ScrollAlwaysVisible = true;
			this.lbSocketClients.Size = new System.Drawing.Size(200, 290);
			this.lbSocketClients.TabIndex = 21;
			// 
			// btnSocketStop
			// 
			this.btnSocketStop.Enabled = false;
			this.btnSocketStop.Location = new System.Drawing.Point(528, 32);
			this.btnSocketStop.Name = "btnSocketStop";
			this.btnSocketStop.Size = new System.Drawing.Size(88, 24);
			this.btnSocketStop.TabIndex = 20;
			this.btnSocketStop.Text = "Socketֹͣ";
			this.btnSocketStop.Click += new System.EventHandler(this.btnSocketStop_Click);
			// 
			// rtbSocketMsg
			// 
			this.rtbSocketMsg.Location = new System.Drawing.Point(216, 64);
			this.rtbSocketMsg.Name = "rtbSocketMsg";
			this.rtbSocketMsg.Size = new System.Drawing.Size(552, 296);
			this.rtbSocketMsg.TabIndex = 19;
			this.rtbSocketMsg.Text = "";
			// 
			// btnSocketStart
			// 
			this.btnSocketStart.Location = new System.Drawing.Point(424, 32);
			this.btnSocketStart.Name = "btnSocketStart";
			this.btnSocketStart.Size = new System.Drawing.Size(88, 24);
			this.btnSocketStart.TabIndex = 18;
			this.btnSocketStart.Text = "Socket����";
			this.btnSocketStart.Click += new System.EventHandler(this.btnSocketStart_Click);
			// 
			// tbSocketPort
			// 
			this.tbSocketPort.Location = new System.Drawing.Point(328, 32);
			this.tbSocketPort.Name = "tbSocketPort";
			this.tbSocketPort.Size = new System.Drawing.Size(83, 20);
			this.tbSocketPort.TabIndex = 17;
			this.tbSocketPort.Text = "1234";
			this.tbSocketPort.TextChanged += new System.EventHandler(this.tbSocketPort_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(232, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 21);
			this.label1.TabIndex = 16;
			this.label1.Text = "Socket�˿ںţ�";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbSocketClientsNum
			// 
			this.tbSocketClientsNum.Location = new System.Drawing.Point(112, 32);
			this.tbSocketClientsNum.Name = "tbSocketClientsNum";
			this.tbSocketClientsNum.ReadOnly = true;
			this.tbSocketClientsNum.TabIndex = 15;
			this.tbSocketClientsNum.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 16);
			this.label3.TabIndex = 13;
			this.label3.Text = "��ǰ�����û���";
			// 
			// ClientSeverForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(818, 407);
			this.Controls.Add(this.grpSocket);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "ClientSeverForm";
			this.Text = "�����ҷ�����";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ClientSeverForm_Closing);
			this.grpSocket.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ClientSeverForm());
		}

		private string getIPAddress()
		{
			// ��ñ���������IP��ַ
			IPAddress[] AddressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
			if (AddressList.Length<1)
			{
				return "";
			}
			
			return AddressList[0].ToString();
		} 

		private static string getDynamicIPAddress( )
		{
			// ��ò��Ŷ�̬����IP��ַ
			IPAddress[] AddressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
			if (AddressList.Length<2)
			{
				return "";
			}
			
			return AddressList[1].ToString();
		}

		private int getValidPort(string port)
		{
			int lport;

			//���Զ˿ں��Ƿ���Ч
			try
			{
				//�Ƿ�Ϊ��
				if (port=="") 
				{
					throw new ArgumentException(
						"�˿ں�Ϊ�գ���������������");
				}
				lport = System.Convert.ToInt32(port);
			}
			catch (Exception e)
			{
				//ArgumentException, 
				//FormatException, 
				//OverflowException
				Console.WriteLine("��Ч�Ķ˿ںţ�" + e.ToString());
				this.rtbSocketMsg.AppendText("��Ч�Ķ˿ںţ�" + e.ToString()+"\n");
				return -1;
			}
			return lport;
		}

		//��������Socket��������ťʱ���㿪ʼ����ָ����Socket�˿�
		private void btnSocketStart_Click(object sender, System.EventArgs e)
		{
			int port = getValidPort(tbSocketPort.Text);
			if (port<0)
			{
				return;
			}

			string ip = this.getIPAddress();
			try
			{
				IPAddress ipAdd=IPAddress.Parse(ip);
				//�����������׽���
				listener=new TcpListener(ipAdd, port);
				//��ʼ�����������˿�
				listener.Start();
				this.rtbSocketMsg.AppendText("Socket�������Ѿ����������ڼ���" + 
					ip + " �˿ںţ�" + this.tbSocketPort.Text + "\n");

				//����һ���µ��̣߳�ִ�з���this.StartSocketListen��
				//�Ա���һ�������Ľ�����ִ��ȷ����ͻ���Socket���ӵĲ���
				ClientSeverForm.SocketServiceFlag = true;
				Thread thread=new Thread(new ThreadStart(this.StartSocketListen));
				thread.Start();
				this.btnSocketStart.Enabled = false;
				this.btnSocketStop.Enabled = true;
			}
			catch(Exception ex)
			{
				this.rtbSocketMsg.AppendText(ex.Message.ToString()+"\n");
			}		
		}

		//���µ��߳��еĲ���������Ҫ���ڵ����յ�һ���ͻ�������ʱ��ȷ����ͻ��˵����ӣ�
		//������������һ���µ��߳�������͸ÿͻ��˵���Ϣ������
		private void StartSocketListen()
		{
			while(ClientSeverForm.SocketServiceFlag)
			{
				try
				{
					//�����յ�һ���ͻ�������ʱ��ȷ����ͻ��˵�����
					if (listener.Pending())
					{
						Socket socket=listener.AcceptSocket();
						if(clients.Count>=MAX_NUM)
						{
							this.rtbSocketMsg.AppendText("�Ѿ��ﵽ�������������" + 
								MAX_NUM + "���ܾ��µ�����\n");
							socket.Close();
						}
						else
						{
							//����һ���µ��̣߳�
							//ִ�з���this.ServiceClient�������û���Ӧ������
							Client client = new Client(this, socket);
							Thread clientService=new Thread(
								new ThreadStart(client.ServiceClient));
							clientService.Start();
						}
					}
					Thread.Sleep(200);
				}
				catch(Exception ex)
				{
					this.rtbSocketMsg.AppendText(ex.Message.ToString()+ "\n");
				}
			}
		}

		private void tbSocketPort_TextChanged(object sender, System.EventArgs e)
		{
			this.btnSocketStart.Enabled = (this.tbSocketPort.Text != "");
		}


		private void btnSocketStop_Click(object sender, System.EventArgs e)
		{
			ClientSeverForm.SocketServiceFlag = false;
			this.btnSocketStart.Enabled = true;
			this.btnSocketStop.Enabled = false;
		}
		
		public void addUser(string username)
		{
			this.rtbSocketMsg.AppendText(username + " �Ѿ�����\n");
		    //�������ӵ��û������뵽��ǰ�����û��б���
			this.lbSocketClients.Items.Add(username);
			this.tbSocketClientsNum.Text = System.Convert.ToString(clients.Count);
		}

		public void removeUser(string username)
		{
			this.rtbSocketMsg.AppendText(username + " �Ѿ��뿪\n");
			//�������ӵ��û������뵽��ǰ�����û��б���
			this.lbSocketClients.Items.Remove(username);
			this.tbSocketClientsNum.Text = System.Convert.ToString(clients.Count);
		}
		
		public string GetUserList()
		{
			string Rtn="";
			for(int i=0;i<lbSocketClients.Items.Count;i++)
			{
				Rtn=Rtn+lbSocketClients.Items[i].ToString() + "|";
			}
			return Rtn;
		}

		public void updateUI(string msg)
		{
			this.rtbSocketMsg.AppendText(msg + "\n");
		}

		private void ClientSeverForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ClientSeverForm.SocketServiceFlag = false;
		}
		
	}


	public class Client
	{
		private string name;
		private Socket currentSocket = null;
		private string ipAddress;
		private ClientSeverForm server;
		
		//������ǰ���ӵ�״̬��
		//closed --> connected --> closed
		private string state = "closed";
		
		public Client(ClientSeverForm server, Socket clientSocket)
		{
			this.server = server;
			this.currentSocket = clientSocket;
			ipAddress = getRemoteIPAddress();
		}
		
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name=value;
			}
		}
		public  Socket CurrentSocket
		{
			get
			{
				return currentSocket;
			}
			set
			{
				currentSocket=value;
			}
		}
		
		public  string IpAddress
		{
			get
			{
				return ipAddress;
			}
		}
		
		private string getRemoteIPAddress()
		{
			return ((IPEndPoint)currentSocket.RemoteEndPoint).
					Address.ToString();
		}

		//ServiceClient�������ںͿͻ��˽�������ͨ�ţ��������տͻ��˵�����
		//���ݲ�ͬ���������ִ����Ӧ�Ĳ������������������ص��ͻ���
		public void ServiceClient()
		{
			string[] tokens=null;
			byte[] buff=new byte[1024];
			bool keepConnect=true;
			
			//��ѭ�������ϵ���ͻ��˽��н�����ֱ���ͻ��˷�����EXIT�����
			//��keepConnect��Ϊfalse���˳�ѭ�����ر����ӣ�����ֹ��ǰ�߳�
			while(keepConnect && ClientSeverForm.SocketServiceFlag)
			{
				tokens = null;
				try
				{
					if (currentSocket == null ||
						currentSocket.Available < 1)
					{
						Thread.Sleep(300);
						continue;
					}

					//�������ݲ�����buff������
					int len = currentSocket.Receive(buff);
					//���ַ�����ת��Ϊ�ַ���
					string clientCommand=System.Text.Encoding.Default.GetString(
						                                 buff, 0, len);
				
					//tokens[0]�б����������־����CONN��CHAT��PRIV��LIST��EXIT��
					tokens=clientCommand.Split(new Char[]{'|'});

					if (tokens == null) 
					{
						Thread.Sleep(200);
						continue;
					}
				} 
				catch(Exception e)
				{
					server.updateUI("�����쳣��"+ e.ToString());
				}
			

				if(tokens[0]=="CONN")
				{
					//��ʱ���յ��������ʽΪ��
					//�����־����CONN��|�����ߵ��û���|��
					//tokens[1]�б����˷����ߵ��û���
					this.name = tokens[1];
					if (ClientSeverForm.clients.Contains(this.name))
					{
						SendToClient(this, "ERR|User " + this.name + " �Ѿ�����");

					}
					else
					{
						Hashtable syncClients = Hashtable.Synchronized(
							ClientSeverForm.clients);
						syncClients.Add(this.name,this);

						//���½���
						server.addUser(this.name);

					
						//��ÿһ����ǰ���ߵ��û�����JOIN��Ϣ�����LIST��Ϣ���
						//�Դ������¿ͻ��˵ĵ�ǰ�����û��б�
						System.Collections.IEnumerator myEnumerator = 
							ClientSeverForm.clients.Values.GetEnumerator();
						while (myEnumerator.MoveNext())
						{
							Client client = (Client)myEnumerator.Current;
							SendToClient(client, "JOIN|"+tokens[1]+"|");
							Thread.Sleep(100);
						}
						//����״̬
						state = "connected";	
						SendToClient(this, "ok");	

						//��ͻ��˷���LIST����Դ˸��¿ͻ��˵ĵ�ǰ�����û��б�
						string msgUsers="LIST|"+server.GetUserList();
						SendToClient(this, msgUsers);
					}

				}
				else if(tokens[0]=="LIST")
				{
					if (state == "connnected")
					{
						//��ͻ��˷���LIST����Դ˸��¿ͻ��˵ĵ�ǰ�����û��б�
						string msgUsers="LIST|"+server.GetUserList();
						SendToClient(this, msgUsers);
					}
					else
					{
						//send err to server
						SendToClient(this, "ERR|state error��Please login first");
					}
				}
				else if(tokens[0]=="CHAT")
				{
					if (state == "connected")
					{
						//��ʱ���յ�������ĸ�ʽΪ��
						//�����־����CHAT��|�����ߵ��û�������������|
						//�����е�ǰ���ߵ��û�ת������Ϣ
						System.Collections.IEnumerator myEnumerator = 
							ClientSeverForm.clients.Values.GetEnumerator();
						while (myEnumerator.MoveNext())
						{
							Client client = (Client)myEnumerator.Current;
							//���������ߵ��û������������ݡ�ת�����û�
							SendToClient(client, tokens[1]);
						}
						server.updateUI(tokens[1]);
					}
					else
					{
						//send err to server
						SendToClient(this, "ERR|state error��Please login first");
					}
				}
				else if(tokens[0]=="PRIV")
				{
					if (state == "connected")
					{
						//��ʱ���յ��������ʽΪ��
						//�����־����PRIV��|�������û���|�������û���|��������|
						//tokens[1]�б����˷����ߵ��û���
						string sender=tokens[1];
						//tokens[2]�б����˽����ߵ��û���
						string receiver=tokens[2];
						//tokens[3]�б����˷��͵�����
						string content=tokens[3];
						string message=sender+" ---> "+receiver+":  " + content;
						
						//������Ϣת���������ߺͽ�����
						if (ClientSeverForm.clients.Contains(sender))
						{
							SendToClient(
								(Client)ClientSeverForm.clients[sender], message);
						}
						if (ClientSeverForm.clients.Contains(receiver))
						{
							SendToClient(
								(Client)ClientSeverForm.clients[receiver], message);
						}
						server.updateUI(message);
					}
					else
					{
						//send err to server
						SendToClient(this, "ERR|state error��Please login first");
					}
				}
				else if(tokens[0]=="EXIT")
				{
					//��ʱ���յ�������ĸ�ʽΪ�������־����EXIT��|�����ߵ��û���
					//�����е�ǰ���ߵ��û����͸��û����뿪����Ϣ
					if (ClientSeverForm.clients.Contains(tokens[1]))
					{
						Client client = (Client)ClientSeverForm.clients[tokens[1]];

						//�����û���Ӧ��Client�����clients��ɾ��
						Hashtable syncClients = Hashtable.Synchronized(
							ClientSeverForm.clients);
						syncClients.Remove(client.name);
						server.removeUser(client.name);

						//��ͻ��˷���QUIT����
						string message="QUIT|" + tokens[1];
							
						System.Collections.IEnumerator myEnumerator = 
							ClientSeverForm.clients.Values.GetEnumerator();
						while (myEnumerator.MoveNext())
						{
							Client c = (Client)myEnumerator.Current;
							SendToClient(c, message);
						}
						server.updateUI("QUIT");
					}

					//�˳���ǰ�߳�
					break;
				}
				Thread.Sleep(200);
			}
		}
		
		//SendToClient()����ʵ������ͻ��˷�����������Ĺ���
		private void SendToClient(Client client, string msg)
		{
			System.Byte[] message=System.Text.Encoding.Default.GetBytes(
					msg.ToCharArray());
			client.CurrentSocket.Send(message,message.Length,0);
		}			
				
	}
		
}
