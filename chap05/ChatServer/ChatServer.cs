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
		/// 必需的设计器变量。
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

		//clients数组保存当前在线用户的Client对象
		internal static Hashtable clients=new Hashtable();
		
		//该服务器默认的监听的端口号
		private TcpListener listener;
		
		//服务器可以支持的最多的客户端的连接数
		static int MAX_NUM=100;
		
		//开始服务的标志
		internal static bool SocketServiceFlag = false;

		public ClientSeverForm()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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
			this.grpSocket.Text = "Socket连接监听";
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
			this.btnSocketStop.Text = "Socket停止";
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
			this.btnSocketStart.Text = "Socket启动";
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
			this.label1.Text = "Socket端口号：";
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
			this.label3.Text = "当前在线用户：";
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
			this.Text = "聊天室服务器";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ClientSeverForm_Closing);
			this.grpSocket.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ClientSeverForm());
		}

		private string getIPAddress()
		{
			// 获得本机局域网IP地址
			IPAddress[] AddressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
			if (AddressList.Length<1)
			{
				return "";
			}
			
			return AddressList[0].ToString();
		} 

		private static string getDynamicIPAddress( )
		{
			// 获得拨号动态分配IP地址
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

			//测试端口号是否有效
			try
			{
				//是否为空
				if (port=="") 
				{
					throw new ArgumentException(
						"端口号为空，不能启动服务器");
				}
				lport = System.Convert.ToInt32(port);
			}
			catch (Exception e)
			{
				//ArgumentException, 
				//FormatException, 
				//OverflowException
				Console.WriteLine("无效的端口号：" + e.ToString());
				this.rtbSocketMsg.AppendText("无效的端口号：" + e.ToString()+"\n");
				return -1;
			}
			return lport;
		}

		//当单击“Socket启动”按钮时，便开始监听指定的Socket端口
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
				//创建服务器套接字
				listener=new TcpListener(ipAdd, port);
				//开始监听服务器端口
				listener.Start();
				this.rtbSocketMsg.AppendText("Socket服务器已经启动，正在监听" + 
					ip + " 端口号：" + this.tbSocketPort.Text + "\n");

				//启动一个新的线程，执行方法this.StartSocketListen，
				//以便在一个独立的进程中执行确认与客户端Socket连接的操作
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

		//在新的线程中的操作，它主要用于当接收到一个客户端请求时，确认与客户端的连接，
		//并且立刻启动一个新的线程来处理和该客户端的信息交互。
		private void StartSocketListen()
		{
			while(ClientSeverForm.SocketServiceFlag)
			{
				try
				{
					//当接收到一个客户端请求时，确认与客户端的连接
					if (listener.Pending())
					{
						Socket socket=listener.AcceptSocket();
						if(clients.Count>=MAX_NUM)
						{
							this.rtbSocketMsg.AppendText("已经达到了最大连接数：" + 
								MAX_NUM + "，拒绝新的连接\n");
							socket.Close();
						}
						else
						{
							//启动一个新的线程，
							//执行方法this.ServiceClient，处理用户相应的请求
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
			this.rtbSocketMsg.AppendText(username + " 已经加入\n");
		    //将刚连接的用户名加入到当前在线用户列表中
			this.lbSocketClients.Items.Add(username);
			this.tbSocketClientsNum.Text = System.Convert.ToString(clients.Count);
		}

		public void removeUser(string username)
		{
			this.rtbSocketMsg.AppendText(username + " 已经离开\n");
			//将刚连接的用户名加入到当前在线用户列表中
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
		
		//保留当前连接的状态：
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

		//ServiceClient方法用于和客户端进行数据通信，包括接收客户端的请求，
		//根据不同的请求命令，执行相应的操作，并将处理结果返回到客户端
		public void ServiceClient()
		{
			string[] tokens=null;
			byte[] buff=new byte[1024];
			bool keepConnect=true;
			
			//用循环来不断地与客户端进行交互，直到客户端发出“EXIT”命令，
			//将keepConnect置为false，退出循环，关闭连接，并中止当前线程
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

					//接收数据并存入buff数组中
					int len = currentSocket.Receive(buff);
					//将字符数组转化为字符串
					string clientCommand=System.Text.Encoding.Default.GetString(
						                                 buff, 0, len);
				
					//tokens[0]中保存了命令标志符（CONN、CHAT、PRIV、LIST或EXIT）
					tokens=clientCommand.Split(new Char[]{'|'});

					if (tokens == null) 
					{
						Thread.Sleep(200);
						continue;
					}
				} 
				catch(Exception e)
				{
					server.updateUI("发生异常："+ e.ToString());
				}
			

				if(tokens[0]=="CONN")
				{
					//此时接收到的命令格式为：
					//命令标志符（CONN）|发送者的用户名|，
					//tokens[1]中保存了发送者的用户名
					this.name = tokens[1];
					if (ClientSeverForm.clients.Contains(this.name))
					{
						SendToClient(this, "ERR|User " + this.name + " 已经存在");

					}
					else
					{
						Hashtable syncClients = Hashtable.Synchronized(
							ClientSeverForm.clients);
						syncClients.Add(this.name,this);

						//更新界面
						server.addUser(this.name);

					
						//对每一个当前在线的用户发送JOIN消息命令和LIST消息命令，
						//以此来更新客户端的当前在线用户列表
						System.Collections.IEnumerator myEnumerator = 
							ClientSeverForm.clients.Values.GetEnumerator();
						while (myEnumerator.MoveNext())
						{
							Client client = (Client)myEnumerator.Current;
							SendToClient(client, "JOIN|"+tokens[1]+"|");
							Thread.Sleep(100);
						}
						//更新状态
						state = "connected";	
						SendToClient(this, "ok");	

						//向客户端发送LIST命令，以此更新客户端的当前在线用户列表
						string msgUsers="LIST|"+server.GetUserList();
						SendToClient(this, msgUsers);
					}

				}
				else if(tokens[0]=="LIST")
				{
					if (state == "connnected")
					{
						//向客户端发送LIST命令，以此更新客户端的当前在线用户列表
						string msgUsers="LIST|"+server.GetUserList();
						SendToClient(this, msgUsers);
					}
					else
					{
						//send err to server
						SendToClient(this, "ERR|state error，Please login first");
					}
				}
				else if(tokens[0]=="CHAT")
				{
					if (state == "connected")
					{
						//此时接收到的命令的格式为：
						//命令标志符（CHAT）|发送者的用户名：发送内容|
						//向所有当前在线的用户转发此信息
						System.Collections.IEnumerator myEnumerator = 
							ClientSeverForm.clients.Values.GetEnumerator();
						while (myEnumerator.MoveNext())
						{
							Client client = (Client)myEnumerator.Current;
							//将“发送者的用户名：发送内容”转发给用户
							SendToClient(client, tokens[1]);
						}
						server.updateUI(tokens[1]);
					}
					else
					{
						//send err to server
						SendToClient(this, "ERR|state error，Please login first");
					}
				}
				else if(tokens[0]=="PRIV")
				{
					if (state == "connected")
					{
						//此时接收到的命令格式为：
						//命令标志符（PRIV）|发送者用户名|接收者用户名|发送内容|
						//tokens[1]中保存了发送者的用户名
						string sender=tokens[1];
						//tokens[2]中保存了接收者的用户名
						string receiver=tokens[2];
						//tokens[3]中保存了发送的内容
						string content=tokens[3];
						string message=sender+" ---> "+receiver+":  " + content;
						
						//仅将信息转发给发送者和接收者
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
						SendToClient(this, "ERR|state error，Please login first");
					}
				}
				else if(tokens[0]=="EXIT")
				{
					//此时接收到的命令的格式为：命令标志符（EXIT）|发送者的用户名
					//向所有当前在线的用户发送该用户已离开的信息
					if (ClientSeverForm.clients.Contains(tokens[1]))
					{
						Client client = (Client)ClientSeverForm.clients[tokens[1]];

						//将该用户对应的Client对象从clients中删除
						Hashtable syncClients = Hashtable.Synchronized(
							ClientSeverForm.clients);
						syncClients.Remove(client.name);
						server.removeUser(client.name);

						//向客户端发送QUIT命令
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

					//退出当前线程
					break;
				}
				Thread.Sleep(200);
			}
		}
		
		//SendToClient()方法实现了向客户端发送命令请求的功能
		private void SendToClient(Client client, string msg)
		{
			System.Byte[] message=System.Text.Encoding.Default.GetBytes(
					msg.ToCharArray());
			client.CurrentSocket.Send(message,message.Length,0);
		}			
				
	}
		
}
