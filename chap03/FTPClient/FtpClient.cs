using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace FTPClient
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FTPClient : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox cbxPasv;
		private System.Windows.Forms.CheckBox cbxAnonymous;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbUser;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TextBox tbLocalPath;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox rtbCommand;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.RichTextBox rtbMsg;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.ComponentModel.IContainer components;

		private const string port1 = "22";
		private const string port2 = "22";
		private int dataPort;
		private string dataIp;

		private TcpListener listener;
		private Socket socket = null;
		private Socket dataSocket = null;
		private bool stopFlag;
		private string cmd = "";

		public FTPClient()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			listFolders();
			this.treeView1.Select();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				this.treeView1.Nodes.Clear();
				this.listView1.Items.Clear();

				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FTPClient));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.cbxPasv = new System.Windows.Forms.CheckBox();
			this.cbxAnonymous = new System.Windows.Forms.CheckBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbUser = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.tbLocalPath = new System.Windows.Forms.TextBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.rtbMsg = new System.Windows.Forms.RichTextBox();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.rtbCommand = new System.Windows.Forms.RichTextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btnDisconnect);
			this.panel1.Controls.Add(this.btnConnect);
			this.panel1.Controls.Add(this.cbxPasv);
			this.panel1.Controls.Add(this.cbxAnonymous);
			this.panel1.Controls.Add(this.tbPassword);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.tbUser);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.tbPort);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.tbAddress);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1010, 88);
			this.panel1.TabIndex = 11;
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Location = new System.Drawing.Point(672, 56);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(152, 23);
			this.btnDisconnect.TabIndex = 21;
			this.btnDisconnect.Text = "断开FTP服务器(&D)";
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(672, 16);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(152, 23);
			this.btnConnect.TabIndex = 20;
			this.btnConnect.Text = "连接FTP服务器(&C)";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// cbxPasv
			// 
			this.cbxPasv.Location = new System.Drawing.Point(504, 56);
			this.cbxPasv.Name = "cbxPasv";
			this.cbxPasv.Size = new System.Drawing.Size(120, 16);
			this.cbxPasv.TabIndex = 19;
			this.cbxPasv.Text = "PASV";
			// 
			// cbxAnonymous
			// 
			this.cbxAnonymous.Location = new System.Drawing.Point(504, 16);
			this.cbxAnonymous.Name = "cbxAnonymous";
			this.cbxAnonymous.Size = new System.Drawing.Size(120, 16);
			this.cbxAnonymous.TabIndex = 18;
			this.cbxAnonymous.Text = "匿名登录";
			this.cbxAnonymous.CheckedChanged += new System.EventHandler(this.cbxAnonymous_CheckedChanged);
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(312, 48);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new System.Drawing.Size(152, 20);
			this.tbPassword.TabIndex = 17;
			this.tbPassword.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(256, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 16;
			this.label3.Text = "密码：";
			// 
			// tbUser
			// 
			this.tbUser.Location = new System.Drawing.Point(72, 48);
			this.tbUser.Name = "tbUser";
			this.tbUser.Size = new System.Drawing.Size(152, 20);
			this.tbUser.TabIndex = 15;
			this.tbUser.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 14;
			this.label4.Text = "用户名：";
			// 
			// tbPort
			// 
			this.tbPort.Location = new System.Drawing.Point(312, 8);
			this.tbPort.Name = "tbPort";
			this.tbPort.Size = new System.Drawing.Size(152, 20);
			this.tbPort.TabIndex = 13;
			this.tbPort.Text = "21";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(256, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "端口号：";
			// 
			// tbAddress
			// 
			this.tbAddress.Location = new System.Drawing.Point(72, 8);
			this.tbAddress.Name = "tbAddress";
			this.tbAddress.Size = new System.Drawing.Size(152, 20);
			this.tbAddress.TabIndex = 11;
			this.tbAddress.Text = "localhost";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "FTP地址：";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.tbLocalPath);
			this.panel2.Controls.Add(this.treeView1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 88);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(296, 631);
			this.panel2.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "本地路径：";
			// 
			// tbLocalPath
			// 
			this.tbLocalPath.Location = new System.Drawing.Point(88, 24);
			this.tbLocalPath.Name = "tbLocalPath";
			this.tbLocalPath.Size = new System.Drawing.Size(200, 20);
			this.tbLocalPath.TabIndex = 12;
			this.tbLocalPath.Text = "c:\\";
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.treeView1.ImageIndex = 1;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(0, 67);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(292, 560);
			this.treeView1.TabIndex = 11;
			this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(296, 88);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 631);
			this.splitter1.TabIndex = 13;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.listView1);
			this.panel3.Controls.Add(this.rtbMsg);
			this.panel3.Controls.Add(this.splitter2);
			this.panel3.Controls.Add(this.rtbCommand);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(299, 88);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(711, 631);
			this.panel3.TabIndex = 14;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.listView1.LargeImageList = this.imageList2;
			this.listView1.Location = new System.Drawing.Point(8, 304);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(688, 312);
			this.listView1.SmallImageList = this.imageList2;
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 3;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 120;
			// 
			// imageList2
			// 
			this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// rtbMsg
			// 
			this.rtbMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtbMsg.Location = new System.Drawing.Point(8, 40);
			this.rtbMsg.Name = "rtbMsg";
			this.rtbMsg.Size = new System.Drawing.Size(688, 256);
			this.rtbMsg.TabIndex = 2;
			this.rtbMsg.Text = "";
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(0, 32);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(707, 3);
			this.splitter2.TabIndex = 1;
			this.splitter2.TabStop = false;
			// 
			// rtbCommand
			// 
			this.rtbCommand.Dock = System.Windows.Forms.DockStyle.Top;
			this.rtbCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtbCommand.Location = new System.Drawing.Point(0, 0);
			this.rtbCommand.Multiline = false;
			this.rtbCommand.Name = "rtbCommand";
			this.rtbCommand.Size = new System.Drawing.Size(707, 32);
			this.rtbCommand.TabIndex = 0;
			this.rtbCommand.Text = "";
			this.rtbCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbCommand_KeyPress);
			// 
			// FTPClient
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1010, 719);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "FTPClient";
			this.Text = "FTP客户端";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FTPClient_Closing);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FTPClient());
		}

		private void listFolders() 
		{
			//获取逻辑驱动器
			string[] LogicDrives=System.IO .Directory .GetLogicalDrives();

			TreeNode[] cRoot =new TreeNode[LogicDrives.Length];
			for (int i=0;i< LogicDrives.Length ;i++)
			{
　				TreeNode drivesNode=new TreeNode(LogicDrives[i]);
				treeView1.Nodes .Add (drivesNode);
				if (LogicDrives[i]!="A:\\" && LogicDrives[i]!="B:\\" )
				{
				　　getSubNode(drivesNode,true);
				}
			}

		}

		//用于获取子目录，以创建目录树节点，
		//参数：PathName为获取的子目录在此节点下创建子节点，
		//参数notEnd：结束标志,true则结束。
		private void getSubNode(TreeNode PathName,bool notEnd)
		{
			if(!notEnd)
			{
				return; 
			}
		　　TreeNode curNode;
		　　DirectoryInfo[] subDir=null;
		　　DirectoryInfo curDir=new DirectoryInfo (PathName.FullPath);
			try
		　　{
				subDir=curDir.GetDirectories();
			}
		　　catch
			{
				return;
			}
		　　
			foreach(DirectoryInfo d in subDir)
			{
		　　　　curNode=new TreeNode(d.Name);
		　　　　PathName.Nodes .Add (curNode);
		　　　　getSubNode(curNode,false);
			}
		}

		//当鼠标单击目录节点左边的+号时，节点将展开，
		//此时在AfterExpand事件中获取此目录下的子目录节点：
		private void treeView1_AfterExpand(object sender, 
			System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				foreach(TreeNode tn in e.Node.Nodes)
				{
　　　				if (!tn.IsExpanded) 
				{
　　　　				getSubNode(tn,true);
				}
				}
			}
		　	catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		//当鼠标单击选中目录节点时，右边的listView控件应显示此目录下的文件和目录
		private void treeView1_AfterSelect(object sender, 
			System.Windows.Forms.TreeViewEventArgs e)
		{
			listView1.Items.Clear();
　			DirectoryInfo selDir=new DirectoryInfo(e.Node.FullPath);
			this.tbLocalPath.Text = e.Node.FullPath;
　			DirectoryInfo[] listDir=null;
　			FileInfo[] listFile=null;

　			try
　			{
　　			listDir=selDir.GetDirectories();
　　			listFile=selDir.GetFiles(); 
				
　				foreach (DirectoryInfo d in listDir)
				{
　　				listView1.Items .Add(d.Name,1);
				}

　				foreach (FileInfo d in listFile)
				{
　　				listView1.Items .Add(d.Name, 2);
				}
　			}
　			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

		}

			//SendToClient()方法实现了发送命令请求的功能
			internal void sendMsg(string msg)
			{
				string resmsg = msg + "\r\n";
				System.Byte[] message=System.Text.Encoding.Default.GetBytes(
					resmsg.ToCharArray());
				socket.Send(message,message.Length,0);
			}
 
		private string receiveCmd() 
		{
			string clientCommand = "";

			if (socket.Connected)
			{
				//接收数据并存入buff数组中
				byte[] buff  = new byte[1024];
				socket.Receive(buff);
				//将字符数组转化为字符串
				clientCommand=System.Text.Encoding.Default.GetString(buff);
				clientCommand = clientCommand.Trim("\0".ToCharArray());
				int index = clientCommand.IndexOf("\r\n");
				if (index>-1)
				{
					clientCommand = clientCommand.Substring(0, index);
				}
			}
			else
			{
				this.socket.Close();
			}
			return clientCommand;
		}

		//连接到FTP服务器，并创建一个线程
		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			this.btnConnect.Enabled = false;
			this.btnDisconnect.Enabled = true;
			this.cbxAnonymous.Enabled = false;
			this.cbxPasv.Enabled = false;


			string ip = this.tbAddress.Text;
			if (ip.ToLower() == "localhost" || ip == "127.0.0.1")
			{
				//获得本机地址
				IPAddress[] AddressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
				if (AddressList.Length>0)
				{
					ip = AddressList[0].ToString();
				}
			}

			int port = System.Convert.ToInt32(this.tbPort.Text);
			
			socket = new Socket(AddressFamily.InterNetwork,
				SocketType.Stream,ProtocolType.Tcp);
			socket.SetSocketOption (SocketOptionLevel.Socket, 
				SocketOptionName.SendTimeout, 5000);

			showMsg("正在连接FTP服务器...", true);
	
			try
			{
				IPAddress ipAdd=IPAddress.Parse(ip);
				IPEndPoint hostEndPoint = new IPEndPoint(ipAdd, port);

				//连接服务器
				socket.Connect(hostEndPoint);
				string msg = this.receiveCmd();
				if (msg.IndexOf("220")==-1)
				{
					//连接不成功
					this.showMsg("连接不成功，退出连接", true);
					socket.Close();
					return;
				}
				showMsg(msg,false);

				this.showMsg("正在验证用户信息...", true);
				//输入用户
				string un;
				string pass;
				if (this.cbxAnonymous.Checked)		//检查是否匿名登录
				{
					un = "guest";
					pass = "";
				}
				else
				{
					un = this.tbUser.Text;
					pass = this.tbPassword.Text;
				}

				this.sendMsg("USER " + un);
				msg = this.receiveCmd();
				if (msg.IndexOf("331")==-1)
				{
					//错误响应
					this.showMsg("错误响应，退出连接", true);
					socket.Close();
					return;
				}
				showMsg(msg,false);
 
				//输入密码
				this.sendMsg("PASS " + pass);
				msg = this.receiveCmd();
				if (msg.IndexOf("230")==-1)
				{
					//登录错误
					this.showMsg("登录错误，退出连接", true);
					socket.Close();
					return;
				}
				showMsg(msg,false);

				this.stopFlag = false;
				Thread thread=new Thread(new ThreadStart(this.handleCmd));
				thread.Start();

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private void btnDisconnect_Click(object sender, System.EventArgs e)
		{
			this.btnConnect.Enabled = true;
			this.btnDisconnect.Enabled = false;
			this.cbxAnonymous.Enabled = true;
			this.cbxPasv.Enabled = true;

			this.stopFlag = true;
			if (socket != null)
			{
				if (socket.Connected)
				{
					this.sendMsg("QUIT");
				}
				socket.Close();
			}
			if (dataSocket != null)
			{
				dataSocket.Close();
			}
			this.rtbMsg.Clear();
			cmd = "";
		}

		private void showMsg(string msg, bool isColor)
		{
			if (isColor)
			{
				this.rtbMsg.SelectionColor = Color.Blue;
			}
			else
			{
				this.rtbMsg.SelectionColor = Color.Black;
			}
			this.rtbMsg.SelectedText = msg + "\n";

		}

		private void FTPClient_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			btnDisconnect_Click(sender, e);
		}

		private void handleCmd()
		{
			while(!stopFlag)
			{
				if (cmd != "")
				{
					try
					{
						string[] tokens = cmd.Split(new Char[]{' '});

						if (tokens[0].ToLower() == "cd")
						{
							tokens[0] = "cwd";
							string c = "";
							for (int i=0;i<tokens.Length;i++)
							{
								c += tokens[i] + " ";
							}
							this.sendMsg(c);
							this.showMsg(cmd, true);

							string msg = this.receiveCmd();
							showMsg(msg,false);
							if (msg.IndexOf("257")==-1)
							{
								this.showMsg("命令错误", true);
							}
						}

						if (tokens[0].ToLower() == "quit")
						{
							this.sendMsg(cmd);
							this.showMsg(cmd, true);
							string msg = this.receiveCmd();
							showMsg(msg,false);
							if (msg.IndexOf("221")==-1)
							{
								this.showMsg("命令错误", true);
							}
							stopFlag = true;
							socket.Close();
							return;
						}

						
						if (tokens[0].ToLower() == "pwd")
						{
							this.sendMsg(cmd);
							this.showMsg(cmd, true);
							string msg = this.receiveCmd();
							showMsg(msg,false);
							if (msg.IndexOf("257")==-1)
							{
								this.showMsg("命令错误", true);
							}
						}

						if (tokens[0].ToLower() == "type" ||
							tokens[0].ToLower() == "noop")
						{
							this.sendMsg(cmd);
							this.showMsg(cmd, true);
							string msg = this.receiveCmd();
							showMsg(msg,false);
							if (msg.IndexOf("200")==-1)
							{
								this.showMsg("命令错误", true);
							}
						}

						if (tokens[0].ToLower() == "delete")
						{
							tokens[0] = "dele";
							string c = "";
							for (int i=0;i<tokens.Length;i++)
							{
								c += tokens[i] + " ";
							}
							this.sendMsg(c);
							this.showMsg(cmd, true);
							string msg = this.receiveCmd();
							showMsg(msg,false);
							if (msg.IndexOf("250")==-1)
							{
								this.showMsg("命令错误", true);
							}
						}

						if (tokens[0].ToLower() == "mkdir")
						{
							tokens[0] = "xmkd";
							string c = "";
							for (int i=0;i<tokens.Length;i++)
							{
								c += tokens[i] + " ";
							}
							this.sendMsg(c);
							this.showMsg(cmd, true);
							string msg = this.receiveCmd();
							showMsg(msg,false);
							if (msg.IndexOf("250")==-1)
							{
								this.showMsg("命令错误", true);
							}
						}

						if (tokens[0].ToLower() == "rename")
						{
							if (tokens.Length<3) 
							{
								this.showMsg("命令错误", true);
								cmd = "";
								continue;
							}

							string c = "RNFR " + tokens[1];
							this.sendMsg(c);
							this.showMsg(cmd, true);
							string msg = this.receiveCmd();
							showMsg(msg,false);
							if (msg.IndexOf("350")==-1)
							{
								this.showMsg("命令错误", true);
								cmd = "";
								continue;
							}
							
							c = "RNTO " + tokens[2];
							this.sendMsg(c);
							this.showMsg(cmd, true);
							msg = this.receiveCmd();
							showMsg(msg,false);
							if (msg.IndexOf("250")==-1)
							{
								this.showMsg("命令错误", true);
								cmd = "";
								continue;
							}
						}

						if (tokens[0].ToLower() == "ls" ||
							tokens[0].ToLower() == "dir")
						{							
							tokens[0] = "NLST";
							string c = "";
							for (int i=0;i<tokens.Length;i++)
							{
								c += tokens[i] + " ";
							}

							if (this.sendPortMsg())
							{
								this.sendMsg(c);
								this.showMsg(cmd, true);

								string msg = this.receiveCmd();
								showMsg(msg,false);
								if (msg.IndexOf("150")==-1)
								{
									this.showMsg("命令错误", true);
									cmd = "";
									continue;
								}

								string m = receiveData();
								if (m != "")
								{
									this.showMsg(m, false);
									msg = this.receiveCmd();
									showMsg(msg,false);
									if (msg.IndexOf("226")==-1)
									{
										this.showMsg("命令错误", true);
										cmd = "";
										continue;
									}
								}	
							}
						}
						
						if (tokens[0].ToLower() == "get")
						{							
							//错误检查
							if (tokens.Length<2) 
							{
								this.showMsg("命令错误", true);
								cmd = "";
								continue;
							}

							tokens[0] = "RETR";
							string c = "";
							for (int i=0;i<tokens.Length;i++)
							{
								c += tokens[i] + " ";
							}

							if (this.sendPortMsg())
							{
								this.sendMsg(c);
								this.showMsg(cmd, true);

								string msg = this.receiveCmd();
								showMsg(msg,false);
								if (msg.IndexOf("150")==-1)
								{
									this.showMsg("命令错误", true);
									cmd = "";
									continue;
								}

								string m = receiveData();
								if (m != "")
								{
									saveFileData(tokens[1], m);
									this.showMsg("文件保存完毕", true);

									msg = this.receiveCmd();
									showMsg(msg,false);
									if (msg.IndexOf("226")==-1)
									{
										this.showMsg("命令错误", true);
										cmd = "";
										continue;
									}
								}	
							}
						}

						if (tokens[0].ToLower() == "put")
						{							
							//错误检查
							if (tokens.Length<2) 
							{
								this.showMsg("命令错误", true);
								cmd = "";
								continue;
							}

							tokens[0] = "STOR";
							string c = "";
							for (int i=0;i<tokens.Length;i++)
							{
								c += tokens[i] + " ";
							}

							if (this.sendPortMsg())
							{
								this.sendMsg(c);
								this.showMsg(cmd, true);

								string msg = this.receiveCmd();
								showMsg(msg,false);
								if (msg.IndexOf("150")==-1)
								{
									this.showMsg("命令错误", true);
									cmd = "";
									continue;
								}

								sendData(this.readFileData(tokens[1]));
								this.showMsg("文件发送完毕", true);

								msg = this.receiveCmd();
								showMsg(msg,false);
								if (msg.IndexOf("226")==-1)
								{
									this.showMsg("命令错误", true);
									cmd = "";
									continue;
								}
							}
						}
					}
					catch (Exception e)
					{
						if (stopFlag)
						{
							return;
						}
						else
						{
							Console.WriteLine(e.ToString());
						}
					}


					//执行完毕，清除命令
					cmd = "";
				}
				Thread.Sleep(500);
			}
		}

		private bool sendPortMsg() 
		{
			if (this.cbxPasv.Checked) 
			{
				//PASV模式
				string c = "PASV";
				this.showMsg(c, true);
				this.sendMsg(c); 
				string msg = this.receiveCmd();
				showMsg(msg,false);
				if (msg.IndexOf("227")==-1)
				{
					this.showMsg("命令错误", true);
					return false;
				}
				string[] tokens = msg.Split(new Char[]{' '});
				int len = tokens.Length;
				if (len>2) 
				{
					tokens = tokens[2].Split(new Char[]{','});
					len = tokens.Length;
					if (len>5)
					{
						dataPort = System.Convert.ToInt32(tokens[len-1])*256 +
							System.Convert.ToInt32(len-2);

						dataIp = tokens[len-6] + "." +
							tokens[len-5] + "." +
							tokens[len-4] + "." +
							tokens[len-3];
					}
				}
			}
			else
			{	//PORT模式	
				
				//获得本机局域网IP地址
				IPAddress[] AddressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
				if (AddressList.Length>0)
				{

					string ip = AddressList[0].ToString();
					try
					{
						IPAddress ipAdd=IPAddress.Parse(ip);
						//创建服务器套接字
						dataPort = System.Convert.ToInt32(port1)*256 +
							System.Convert.ToInt32(port2);

						listener=new TcpListener(ipAdd, dataPort);
						//开始监听服务器端口
						listener.Start();

						//发送Port命令
						string strip = ip.Replace(".", ",");
						string c = "PORT " + strip + "," + port1 + "," + port2;
						this.showMsg(c, true);
						this.sendMsg(c); 
						string msg = this.receiveCmd();
						showMsg(msg,false);
						if (msg.IndexOf("200")==-1)
						{
							this.showMsg("命令错误", true);
							return false;
						}

						this.stopFlag = false;
						Thread thread=new Thread(new ThreadStart(this.getDataSocket));
						thread.Start();
					}
					catch (Exception e)
					{
						Console.WriteLine("数据接收Socket：" + e.ToString());
					}
				}
			}
			return true;
		}

		//启动一个新的线程来接收客户端的连接
		private void getDataSocket()
		{
			while(!stopFlag)
			{
				try
				{
					//当接收到一个客户端请求时，确认与客户端的连接
					if (listener.Pending())
					{
						dataSocket = listener.AcceptSocket();
						break;
					}

					Thread.Sleep(100);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
		}

		private string receiveData() 
		{
			string clientCommand = "";

			if (this.cbxPasv.Checked) 
			{
				//PASV模式
				dataSocket = new Socket(AddressFamily.InterNetwork,
					SocketType.Stream,ProtocolType.Tcp);
				dataSocket.SetSocketOption (SocketOptionLevel.Socket, 
					SocketOptionName.SendTimeout, 5000);	
				IPAddress ipAdd=IPAddress.Parse(this.dataIp);
				IPEndPoint hostEndPoint = new IPEndPoint(ipAdd, dataPort);
				dataSocket.Connect(hostEndPoint);
			}

			//接收数据
			int timeout = 100;
			while(timeout-->0)
			{
				if (dataSocket != null &&
					dataSocket.Connected)
				{
					byte[] buff = new byte[4096];
					//接收数据并存入buff数组中
					while(dataSocket.Receive(buff)>0)
					{
						//将字符数组转化为字符串
						string msg = System.Text.Encoding.Default.GetString(buff);
						msg = msg.Trim("\0".ToCharArray());
						clientCommand += msg;
					}

					if (clientCommand.Length>0)
					{
						break;
					}
				}

				try
				{
					Thread.Sleep(200);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}			
			return clientCommand;
		}

		private void sendData(byte[] data) 
		{
			if (this.cbxPasv.Checked) 
			{
				//PASV模式
				dataSocket = new Socket(AddressFamily.InterNetwork,
					SocketType.Stream,ProtocolType.Tcp);
				dataSocket.SetSocketOption (SocketOptionLevel.Socket, 
					SocketOptionName.SendTimeout, 5000);	
				IPAddress ipAdd=IPAddress.Parse(this.dataIp);
				IPEndPoint hostEndPoint = new IPEndPoint(ipAdd, dataPort);
				dataSocket.Connect(hostEndPoint);
			}

			//发送数据
			int timeout = 100;
			while(timeout-->0)
			{
				if (dataSocket != null &&
					dataSocket.Connected)
				{
					dataSocket.Send(data, data.Length, 0);
					dataSocket.Close();
					break;
				}

				try
				{
					Thread.Sleep(200);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}			
		}

		private byte[] readFileData(string filename)
		{
			string path = this.tbLocalPath.Text;
			if (path[path.Length-1] != '\\')
			{
				path += "\\";
			}
			path += filename;
			FileInfo fi = new FileInfo(path);
			if (fi.Exists)
			{
				FileStream fs = fi.OpenRead();	
				byte[] b = new byte[fs.Length];

				fs.Read(b,0,b.Length);
				return b;
			}
			return null;
		}

		private void saveFileData(string filename, string data)
		{
			string path = this.tbLocalPath.Text;
			if (path[path.Length-1] != '\\')
			{
				path += "\\";
			}
			path += filename;
			FileInfo fi = new FileInfo(path);
			byte[] buf = new byte[1];
			if (!fi.Exists) 
			{
				File.Create(path);
			}
			
			byte[] b = System.Text.Encoding.Default.GetBytes(data);
			using (FileStream fs = File.OpenWrite(path))
			{
				fs.Write(b, 0 ,b.Length);
				fs.Close();
			}
		}
			


		private void rtbCommand_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) 
			{
				string c = this.rtbCommand.Text;
				if (c!="") 
				{
					cmd = c;
					this.rtbCommand.Text = "";
				}
			}
		}

		private void cbxAnonymous_CheckedChanged(object sender, System.EventArgs e)
		{
			this.tbPassword.Enabled = !this.cbxAnonymous.Checked;
			this.tbUser.Enabled = !this.cbxAnonymous.Checked;
		}

	}
}
