using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace FtpServer
{
	public class FtpServerForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		
		public const string ROOT_DIR = "c:\\";
		//服务器可以支持的最多的客户端的连接数
		public const int MAX_NUM=100;

		
		//clients数组保存当前在线用户的Client对象
		internal static Hashtable clients=new Hashtable();
		
		//该服务器默认的监听的端口号
		private TcpListener listener;
		
		
		//开始服务的标志
		internal static bool SocketServiceFlag = false;
		//服务器的IP地址
		internal string ip;
		internal int port;

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox tbSocketPort;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox grpSocket;
		private System.Windows.Forms.ListBox lbClients;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.TextBox tbClientsNum;
		


		public FtpServerForm()
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
			this.lbClients = new System.Windows.Forms.ListBox();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.tbSocketPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbClientsNum = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.grpSocket = new System.Windows.Forms.GroupBox();
			this.grpSocket.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbClients
			// 
			this.lbClients.Location = new System.Drawing.Point(8, 24);
			this.lbClients.Name = "lbClients";
			this.lbClients.ScrollAlwaysVisible = true;
			this.lbClients.Size = new System.Drawing.Size(328, 563);
			this.lbClients.TabIndex = 21;
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(352, 160);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(224, 24);
			this.btnStop.TabIndex = 2;
			this.btnStop.Text = "停止FTP服务器(&S)";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(352, 120);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(224, 24);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "启动FTP服务器(&R)";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// tbSocketPort
			// 
			this.tbSocketPort.Location = new System.Drawing.Point(456, 24);
			this.tbSocketPort.Name = "tbSocketPort";
			this.tbSocketPort.Size = new System.Drawing.Size(112, 20);
			this.tbSocketPort.TabIndex = 3;
			this.tbSocketPort.Text = "21";
			this.tbSocketPort.TextChanged += new System.EventHandler(this.tbSocketPort_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(352, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 21);
			this.label1.TabIndex = 16;
			this.label1.Text = "Socket端口号：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbClientsNum
			// 
			this.tbClientsNum.Location = new System.Drawing.Point(456, 64);
			this.tbClientsNum.Name = "tbClientsNum";
			this.tbClientsNum.ReadOnly = true;
			this.tbClientsNum.Size = new System.Drawing.Size(112, 20);
			this.tbClientsNum.TabIndex = 4;
			this.tbClientsNum.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(360, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 16);
			this.label3.TabIndex = 13;
			this.label3.Text = "当前在线用户：";
			// 
			// grpSocket
			// 
			this.grpSocket.Controls.Add(this.lbClients);
			this.grpSocket.Controls.Add(this.btnStop);
			this.grpSocket.Controls.Add(this.btnStart);
			this.grpSocket.Controls.Add(this.tbSocketPort);
			this.grpSocket.Controls.Add(this.label1);
			this.grpSocket.Controls.Add(this.tbClientsNum);
			this.grpSocket.Controls.Add(this.label3);
			this.grpSocket.Location = new System.Drawing.Point(16, 16);
			this.grpSocket.Name = "grpSocket";
			this.grpSocket.Size = new System.Drawing.Size(592, 608);
			this.grpSocket.TabIndex = 13;
			this.grpSocket.TabStop = false;
			this.grpSocket.Text = "FTP服务器设置";
			// 
			// FtpServerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(626, 639);
			this.Controls.Add(this.grpSocket);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MinimizeBox = false;
			this.Name = "FtpServerForm";
			this.Text = "FTP服务器";
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
			Application.Run(new FtpServerForm());
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
				Console.WriteLine("无效的端口号：" + e.ToString());
				return -1;
			}
			return lport;
		}

		//当单击“Socket启动”按钮时，便开始监听指定的Socket端口
		private void btnStart_Click(object sender, System.EventArgs e)
		{
			Console.WriteLine("FTP服务器启动...");
			port = getValidPort(tbSocketPort.Text);
			if (port<0)
			{
				return;
			}

			// 获得本机局域网IP地址
			IPAddress[] AddressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
			if (AddressList.Length>0)
			{

				ip = AddressList[0].ToString();
				try
				{
					IPAddress ipAdd=IPAddress.Parse(ip);
					//创建服务器套接字
					listener=new TcpListener(ipAdd, port);
					//开始监听服务器端口
					listener.Start();


					//启动一个新的线程，执行方法this.StartSocketListen，
					//以便在一个独立的进程中执行确认与客户端Socket连接的操作
					FtpServerForm.SocketServiceFlag = true;
					Thread thread=new Thread(new ThreadStart(this.StartSocketListen));
					thread.Start();
					this.btnStart.Enabled = false;
					this.btnStop.Enabled = true;
					this.tbSocketPort.Enabled = false;
				}
				catch(Exception ex)
				{
					Console.WriteLine("不能启动服务器：" + ex.ToString());
				}		
			}

		}

		//在新的线程中的操作，它主要用于当接收到一个客户端请求时，确认与客户端的连接，
		//并且立刻启动一个新的线程来处理和该客户端的信息交互。
		private void StartSocketListen()
		{
			while(FtpServerForm.SocketServiceFlag)
			{
				try
				{
					//当接收到一个客户端请求时，确认与客户端的连接
					if (listener.Pending())
					{
						Socket socket=listener.AcceptSocket();
						if(clients.Count>=MAX_NUM)
						{
							Console.WriteLine("已经达到了最大连接数：" + 
								MAX_NUM + "，拒绝新的连接\n");
							socket.Close();
						}
						else
						{
							//启动一个新的线程，
							//执行方法this.ServiceClient，处理用户相应的请求
							Client client = new Client(this, socket);
							addClient(client);

							Thread clientService=new Thread(
								new ThreadStart(client.ServiceClient));
							clientService.Start();
						}
					}

					Thread.Sleep(500);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message.ToString()+ "\n");
				}
			}
		}

		private void tbSocketPort_TextChanged(object sender, System.EventArgs e)
		{
			this.btnStart.Enabled = (this.tbSocketPort.Text != "");
		}


		private void btnStop_Click(object sender, System.EventArgs e)
		{
			FtpServerForm.SocketServiceFlag = false;
			this.btnStart.Enabled = true;
			this.btnStop.Enabled = false;
			this.tbSocketPort.Enabled = true;
			if (listener != null)
			{
				listener.Stop();
			}

			System.Collections.IDictionaryEnumerator myEnumerator = clients.GetEnumerator();
			while (myEnumerator.MoveNext())
			{
				Client client = (Client)myEnumerator.Value;
					;
				client.StopFlag = true;
				client.CurrentSocket.Close();
			}
			clients.Clear();
			lbClients.Items.Clear();
			this.tbClientsNum.Text = "";
		}
		
		private void ClientSeverForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			btnStop_Click(sender, e);
		}

		public void removeClient(Client client) 
		{
			if (clients.Contains(client.IpAddress))
			{
				clients.Remove(client.IpAddress);
				lbClients.Items.Remove(client.IpAddress);
			}
			this.tbClientsNum.Text = System.Convert.ToString(clients.Count);
		}

		private void addClient(Client client)
		{
			if (clients.Contains(client.IpAddress))
			{
				clients.Remove(client.IpAddress);
			}
			if (lbClients.Items.IndexOf(client.IpAddress)>-1)
			{
				lbClients.Items.Remove(client.IpAddress);
			}

			clients.Add(client.IpAddress, client);
			lbClients.Items.Add(client.IpAddress);

			this.tbClientsNum.Text = System.Convert.ToString(clients.Count);
		}
	}
		
}
