using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ChatClient
{
	public class ChatClientForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.ListBox lstUsers;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbSendContent;
		private System.Windows.Forms.RichTextBox rtbMsg;
		private System.Windows.Forms.Button btnColor;
		
		
		//与服务器的连接
		TcpClient tcpClient;
	
		//与服务器数据交互的流通道
		private NetworkStream Stream;


		//客户端的状态
		private static string CLOSED = "closed";
		private static string CONNECTED = "connected";
		private System.Windows.Forms.TextBox tbUserName;
		private System.Windows.Forms.CheckBox cbPrivate;
		private string state = CLOSED;

		private bool stopFlag;

		private Color color;

		public ChatClientForm()
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
		/// Clean up any resources being used.
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
			this.tbSendContent = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.lstUsers = new System.Windows.Forms.ListBox();
			this.cbPrivate = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnLogin = new System.Windows.Forms.Button();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.rtbMsg = new System.Windows.Forms.RichTextBox();
			this.btnColor = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbSendContent
			// 
			this.tbSendContent.Location = new System.Drawing.Point(280, 448);
			this.tbSendContent.Multiline = true;
			this.tbSendContent.Name = "tbSendContent";
			this.tbSendContent.Size = new System.Drawing.Size(472, 112);
			this.tbSendContent.TabIndex = 0;
			this.tbSendContent.Text = "";
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(760, 448);
			this.btnSend.Name = "btnSend";
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "发送(&A)";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// lstUsers
			// 
			this.lstUsers.Location = new System.Drawing.Point(16, 112);
			this.lstUsers.Name = "lstUsers";
			this.lstUsers.ScrollAlwaysVisible = true;
			this.lstUsers.Size = new System.Drawing.Size(248, 459);
			this.lstUsers.TabIndex = 2;
			// 
			// cbPrivate
			// 
			this.cbPrivate.Location = new System.Drawing.Point(280, 408);
			this.cbPrivate.Name = "cbPrivate";
			this.cbPrivate.Size = new System.Drawing.Size(87, 22);
			this.cbPrivate.TabIndex = 7;
			this.cbPrivate.Text = "悄悄话";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 21);
			this.label2.TabIndex = 9;
			this.label2.Text = "当前在线用户列表：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnExit);
			this.groupBox1.Controls.Add(this.btnLogin);
			this.groupBox1.Controls.Add(this.tbUserName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtPort);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtHost);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(816, 72);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "聊天服务器设置";
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(712, 32);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(62, 22);
			this.btnExit.TabIndex = 25;
			this.btnExit.Text = "离开";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
			// 
			// btnLogin
			// 
			this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnLogin.Location = new System.Drawing.Point(640, 32);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(62, 21);
			this.btnLogin.TabIndex = 24;
			this.btnLogin.Text = "登入";
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(448, 32);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(84, 20);
			this.tbUserName.TabIndex = 22;
			this.tbUserName.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(368, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 21);
			this.label3.TabIndex = 23;
			this.label3.Text = "用户名：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(296, 32);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(46, 20);
			this.txtPort.TabIndex = 21;
			this.txtPort.Text = "1234";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(216, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 22);
			this.label4.TabIndex = 20;
			this.label4.Text = "端口号：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtHost
			// 
			this.txtHost.Location = new System.Drawing.Point(96, 32);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(104, 20);
			this.txtHost.TabIndex = 19;
			this.txtHost.Text = "127.0.0.1";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 22);
			this.label5.TabIndex = 18;
			this.label5.Text = "服务器地址：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(280, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 21);
			this.label1.TabIndex = 22;
			this.label1.Text = "系统消息：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rtbMsg
			// 
			this.rtbMsg.Location = new System.Drawing.Point(280, 112);
			this.rtbMsg.Name = "rtbMsg";
			this.rtbMsg.Size = new System.Drawing.Size(552, 288);
			this.rtbMsg.TabIndex = 25;
			this.rtbMsg.Text = "";
			// 
			// btnColor
			// 
			this.btnColor.Location = new System.Drawing.Point(760, 488);
			this.btnColor.Name = "btnColor";
			this.btnColor.TabIndex = 28;
			this.btnColor.Text = "颜色";
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// ChatClientForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(848, 589);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.rtbMsg);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbPrivate);
			this.Controls.Add(this.lstUsers);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.tbSendContent);
			this.Name = "ChatClientForm";
			this.Text = "ChatClient";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ChatClientForm_Closing);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ChatClientForm());
		}


		//ServerResponse()方法用于接收从服务器发回的信息，
		//根据不同的命令，执行相应的操作
		private void ServerResponse()
		{
			//定义一个byte数组，用于接收从服务器端发送来的数据，
			//每次所能接收的数据包的最大长度为1024个字节
			byte[] buff=new byte[1024];
			string msg;
			int len;
			try
			{
				if(!Stream.CanRead)
				{
					return;
				}

				stopFlag = false;
				while(!stopFlag)
				{
					//从流中得到数据，并存入到buff字符数组中
					len=Stream.Read(buff,0,buff.Length);

					if (len < 1)
					{
						Thread.Sleep(200);
						continue;
					}
					
					//将字符数组转化为字符串
					msg=System.Text.Encoding.Default.GetString(buff,0,len);
					msg.Trim();

					string[] tokens=msg.Split(new Char[]{'|'});
					//tokens[0]中保存了命令标志符（LIST或JOIN或QUIT）
					
					if (tokens[0].ToUpper()== "OK")
					{
						//处理响应
						add("命令执行成功");
					}
					else if (tokens[0].ToUpper()== "ERR")
					{
						//命令执行错误
						add("命令执行错误：" + tokens[1]);
					}
					else if(tokens[0]== "LIST")
					{
						//此时从服务器返回的消息格式：
						//命令标志符（LIST）|用户名1|用户名|2...（所有在线用户名）|
						add("获得用户列表");
						//更新在线用户列表
						lstUsers.Items.Clear();
						for(int i=1;i<tokens.Length-1;i++)
						{
							lstUsers.Items.Add(tokens[i].Trim());
						}
					}
					else if(tokens[0]== "JOIN")
					{
						//此时从服务器返回的消息格式：
						//命令标志符（JOIN）|刚刚登入的用户名|
						add(tokens[1]+" "+"已经进入了聊天室");
						this.lstUsers.Items.Add(tokens[1]);
						if (this.tbUserName.Text ==tokens[1]) 
						{
							this.state = CONNECTED;
						}
					}
					else if(tokens[0]== "QUIT")
					{
						if (this.lstUsers.Items.IndexOf(tokens[1])>-1)
						{
							this.lstUsers.Items.Remove(tokens[1]);
						}
						add("用户：" + tokens[1] + " 已经离开");
					}
					else
					{
						//如果从服务器返回的其他消息格式，
						//则在ListBox控件中直接显示
						add(msg);
					}	
				}
				//关闭连接
				tcpClient.Close();
			}
			catch
			{
				add("网络发生错误");
			}
		}

		private void add(string msg)
		{
			if (!color.IsEmpty)
			{
				this.rtbMsg.SelectionColor = color;
			}
			this.rtbMsg.SelectedText = msg + "\n";
		}

		//当点击“发送”按钮时，便会进入btnSend_Click处理程序。
		//在btnSend_Click处理程序中，如果不是私聊，
		//将“CHAT”命令发送给服务器，
		//否则（为私聊），将“PRIV”命令发送给服务器，
		//注意命令格式一定要与服务器端的命令格式一致
		private void btnSend_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!this.cbPrivate.Checked)
				{
					//此时命令的格式是：
					//命令标志符（CHAT）|发送者的用户名：发送内容|
					string message="CHAT|"+ this.tbUserName.Text +":"+
						tbSendContent.Text+"|";
					tbSendContent.Text="";
					tbSendContent.Focus();
					//将字符串转化为字符数组
					Byte[]outbytes=System.Text.Encoding.Default.GetBytes(
						message.ToCharArray());
					Stream.Write(outbytes,0,outbytes.Length);
					
				}
				else
				{
					if(lstUsers.SelectedIndex==-1)
					{
						MessageBox.Show("请在列表中选择一个用户","提示信息",
							MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						return;
					}
					string receiver=lstUsers.SelectedItem.ToString();
					//消息的格式是：
					//命令标志符（PRIV）|发送者的用户名|接收者的用户名|发送内容|
					string message="PRIV|"+this.tbUserName.Text+"|"+receiver+"|"+
						tbSendContent.Text+"|";
					tbSendContent.Text="";
					tbSendContent.Focus();
					//将字符串转化为字符数组
					byte[] outbytes=System.Text.Encoding.ASCII.GetBytes(
						message.ToCharArray());
					Stream.Write(outbytes,0,outbytes.Length);
					
				}
			}
			catch
			{
				this.rtbMsg.AppendText("网络发生错误");
			}

		}


		//连接聊天服务器
		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			if (state == CONNECTED)
			{
				return;
			}

			if(this.tbUserName.Text.Length==0)
			{
				MessageBox.Show("请输入您的呢称!","提示信息",
					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.tbUserName.Focus();
				return;
			}
			try
			{
				//创建一个客户端套接字，它是Login的一个公共属性，
				//将被传递给ChatClient窗体
				tcpClient=new TcpClient();
				//向指定的IP地址的服务器发出连接请求
				tcpClient.Connect(IPAddress.Parse(txtHost.Text),
					Int32.Parse(txtPort.Text));
				//获得与服务器数据交互的流通道（NetworkStream)
				Stream=tcpClient.GetStream();

				//启动一个新的线程，执行方法this.ServerResponse()，
				//以便来响应从服务器发回的信息
				Thread thread=new Thread(new ThreadStart(this.ServerResponse));
				thread.Start();

				//向服务器发送“CONN”请求命令，
				//此命令的格式与服务器端的定义的格式一致，
				//命令格式为：命令标志符（CONN）|发送者的用户名|
				string cmd="CONN|"+this.tbUserName.Text+"|";
				//将字符串转化为字符数组
				Byte[] outbytes=System.Text.Encoding.Default.GetBytes(
					cmd.ToCharArray());
				Stream.Write(outbytes,0,outbytes.Length);

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		//设置字体颜色
		private void btnColor_Click(object sender, System.EventArgs e)
		{
			ColorDialog colorDialog1 = new ColorDialog();
			colorDialog1.Color = this.rtbMsg.SelectionColor;

			if(colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && 
				colorDialog1.Color !=this.rtbMsg.SelectionColor)
			{
				this.rtbMsg.SelectionColor = colorDialog1.Color;
				color = colorDialog1.Color;
			}
		}

		//当单击“离开”按钮时，便进入了btnExit_Click 处理程序。
		//在btnExit_Click 处理程序中，
		//将“EXIT”命令发送给服务器，此命令格式要与服务器端的命令格式一致
		private void btnExit_Click_1(object sender, System.EventArgs e)
		{
			if (state == CONNECTED) 
			{
				string message="EXIT|"+this.tbUserName.Text+"|";
				//将字符串转化为字符数组
				Byte[]outbytes=System.Text.Encoding.Default.GetBytes(
					message.ToCharArray());
				Stream.Write(outbytes,0,outbytes.Length);

				this.state = CLOSED;
				this.stopFlag = true;
				this.lstUsers.Items.Clear();
			}
		}

		private void ChatClientForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			btnExit_Click_1(sender, e);
		}


	}
}
