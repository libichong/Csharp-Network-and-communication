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

namespace TelnetClient
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		//---------------------------------常量定义
		const char GO_NORM = (char)0;
		const char SUSP = (char)237;

		const char ABORT = (char)238; 
		const char SE = (char)240; //子选项结束Subnegotiation End
		const char NOP = (char)241;
		const char DM = (char)242; //Data Mark
		const char BREAK = (char)243; //BREAK
		const char IP = (char)244; //Interrupt Process
		const char AO = (char)245; //Abort Output
		const char AYT = (char)246; //Are you there
		const char EC = (char)247; //Erase character
		const char EL = (char)248; //Erase Line
		const char GOAHEAD = (char)249; //Go Ahead
		const char SB = (char)250; //子选项开始Subnegotiation Begin

		const char WILL = (char)251;
		const char WONT = (char)252;
		const char DO = (char)253;
		const char DONT = (char)254;
		const char IAC = (char)255;
	
		const char BINARY = (char)0;
		const char IS = (char)0;
		const char SEND = (char)1;
		const char ECHO = (char)1;
		const char RECONNECT = (char)2;
		const char SGA = (char)3;
		const char AMSN = (char)4;
		const char STATUS = (char)5;
		const char TIMING = (char)6;
		const char RCTAN = (char)7;
		const char OLW = (char)8;
		const char OPS = (char)9;
		const char OCRD = (char)10;
		const char OHTS = (char)11;
		const char OHTD = (char)12;
		const char OFFD = (char)13;
		const char OVTS = (char)14;
		const char OVTD = (char)15;
		const char OLFD = (char)16;
		const char XASCII = (char)17;
		const char LOGOUT = (char)18;
		const char BYTEM = (char)19;
		const char DET = (char)20;
		const char SUPDUP = (char)21;
		const char SUPDUPOUT = (char)22;
		const char SENDLOC = (char)23;
		const char TERMTYPE = (char)24;
		const char EOR = (char)25;
		const char TACACSUID = (char)26;
		const char OUTPUTMARK = (char)27;
		const char TERMLOCNUM = (char)28;
		const char REGIME3270 = (char)29;
		const char X3PAD = (char)30;
		const char NAWS = (char)31;
		const char TERMSPEED = (char)32;
		const char TFLOWCNTRL = (char)33;
		const char LINEMODE = (char)34;
		const char DISPLOC = (char)35;
	
		const char ENVIRON = (char)36;
		const char AUTHENTICATION = (char)37;
		const char UNKNOWN39 = (char)39;
		const char EXTENDED_OPTIONS_LIST = (char)255;
		const char RANDOM_LOSE = (char)256;


		const char CR = (char)13;	//回车
		const char LF = (char)10;	//换行
		const string BACK =  "[P";

		private short[] parsedata;
		protected bool sw_ugoahead;
		protected bool sw_igoahead;
		protected bool sw_echo;
		protected bool sw_termsent;
		
		private SettingsForm sf;
		private Socket socket;


		public System.Windows.Forms.Timer cursor_timer;
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.MainMenu MainMenu1;
		public System.Windows.Forms.MenuItem mFile;
		public System.Windows.Forms.MenuItem mConnection;
		public System.Windows.Forms.MenuItem mSettings;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItemOpen;
		private System.Windows.Forms.MenuItem menuItemClose;
		public System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.RichTextBox rtbConsole;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//

			parsedata = new short[10];




			sf = new SettingsForm();

			string ip = GetLocalAPAddress();
			if (ip != "")
			{
				this.statusBarPanel2.Text = "本地IP地址：" + ip;
			}
			else
			{
				this.statusBarPanel2.Text = "无法获得本机IP地址，请检查网络连接";
				this.mFile.Enabled = false;
			}
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.cursor_timer = new System.Windows.Forms.Timer(this.components);
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.MainMenu1 = new System.Windows.Forms.MainMenu();
			this.mFile = new System.Windows.Forms.MenuItem();
			this.menuItemOpen = new System.Windows.Forms.MenuItem();
			this.menuItemClose = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.mConnection = new System.Windows.Forms.MenuItem();
			this.mSettings = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
			this.rtbConsole = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
			this.SuspendLayout();
			// 
			// cursor_timer
			// 
			this.cursor_timer.Interval = 300;
			// 
			// MainMenu1
			// 
			this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mFile,
																					  this.mConnection});
			// 
			// mFile
			// 
			this.mFile.Index = 0;
			this.mFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				  this.menuItemOpen,
																				  this.menuItemClose,
																				  this.menuItem3,
																				  this.miExit});
			this.mFile.Text = "文件(&F)";
			// 
			// menuItemOpen
			// 
			this.menuItemOpen.Index = 0;
			this.menuItemOpen.Text = "打开连接(&O)";
			this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
			// 
			// menuItemClose
			// 
			this.menuItemClose.Index = 1;
			this.menuItemClose.Text = "关闭连接(&C)";
			this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 3;
			this.miExit.Text = "退出(&X)";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// mConnection
			// 
			this.mConnection.Index = 1;
			this.mConnection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mSettings});
			this.mConnection.Text = "设置(&S)";
			// 
			// mSettings
			// 
			this.mSettings.Index = 0;
			this.mSettings.Text = "连接设置(&S)";
			this.mSettings.Click += new System.EventHandler(this.mSettings_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 503);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2,
																						  this.statusBarPanel3,
																						  this.statusBarPanel4});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(728, 22);
			this.statusBar1.TabIndex = 0;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Text = "状态：";
			this.statusBarPanel1.Width = 120;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Text = "本地地址：";
			this.statusBarPanel2.Width = 200;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.Text = "服务器地址：";
			this.statusBarPanel3.Width = 200;
			// 
			// statusBarPanel4
			// 
			this.statusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel4.Text = "服务器状态：";
			this.statusBarPanel4.Width = 192;
			// 
			// rtbConsole
			// 
			this.rtbConsole.BackColor = System.Drawing.Color.Black;
			this.rtbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtbConsole.ForeColor = System.Drawing.Color.White;
			this.rtbConsole.Location = new System.Drawing.Point(0, 0);
			this.rtbConsole.Name = "rtbConsole";
			this.rtbConsole.ReadOnly = true;
			this.rtbConsole.Size = new System.Drawing.Size(728, 503);
			this.rtbConsole.TabIndex = 1;
			this.rtbConsole.Text = "";
			this.rtbConsole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbConsole_KeyDown);
			this.rtbConsole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbConsole_KeyPress);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(728, 525);
			this.Controls.Add(this.rtbConsole);
			this.Controls.Add(this.statusBar1);
			this.Menu = this.MainMenu1;
			this.Name = "MainForm";
			this.Text = "Telnet客户端";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			loadSettings();
		}
		
		private void mSettings_Click(object sender, System.EventArgs e)
		{
			sf.lblEffect.BackColor = this.rtbConsole.BackColor;
			sf.lblEffect.ForeColor = this.rtbConsole.ForeColor;
			sf.lblEffect.Font = this.rtbConsole.Font; 

			if (sf.ShowDialog()== DialogResult.OK)
			{
				this.rtbConsole.ForeColor = sf.lblEffect.ForeColor;
				this.rtbConsole.BackColor = sf.lblEffect.BackColor;
				this.rtbConsole.Font = sf.lblEffect.Font;
				this.rtbConsole.SelectionFont = sf.lblEffect.Font;
			}
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItemOpen_Click(object sender, System.EventArgs e)
		{
			Connect();
		}

		private void menuItemClose_Click(object sender, System.EventArgs e)
		{
			CloseConnection();
		}

		
		
		//装载程序参数设置
		private void loadSettings()
		{
			string path = System.Windows.Forms.Application.ExecutablePath 
				+ ".settings.set";
			
			if (File.Exists(path))  
			{
				using (StreamReader sr = File.OpenText(path)) 
				{
					try 
					{
						sf.txtRemoteAddress.Text = sr.ReadLine();
						sf.txtPort.Text = sr.ReadLine();
						sf.chkAutoConnect.Checked = 
							System.Convert.ToBoolean(sr.ReadLine());
						sf.lblEffect.BackColor = 
							Color.FromArgb(System.Convert.ToInt32(sr.ReadLine()));
						sf.lblEffect.ForeColor = 
							Color.FromArgb(System.Convert.ToInt32(sr.ReadLine()));
						
						string fontFamily = sr.ReadLine();
						float size = System.Convert.ToSingle(sr.ReadLine());
						string style = sr.ReadLine();
						
						FontStyle fs = 0;
						if (style.IndexOf("Bold")>-1)
						{
							fs |= FontStyle.Bold;
						}

						if (style.IndexOf("Italic")>-1)
						{
							fs |= FontStyle.Italic;
						}
						
						if (style.IndexOf("Regular")>-1)
						{
							fs |= FontStyle.Regular;
						}

						if (style.IndexOf("Strikeout")>-1)
						{
							fs |= FontStyle.Strikeout;
						}
						
						if (style.IndexOf("Underline")>-1)
						{
							fs |= FontStyle.Underline;
						}


						GraphicsUnit gu = 0;
						string s = sr.ReadLine();
						if (s.IndexOf("Display")>-1)
						{
							gu |= GraphicsUnit.Display;
						}

						if (s.IndexOf("Document")>-1)
						{
							gu |= GraphicsUnit.Document;
						}
						
						if (s.IndexOf("Inch")>-1)
						{
							gu |= GraphicsUnit.Inch;
						}

						if (s.IndexOf("Millimeter")>-1)
						{
							gu |= GraphicsUnit.Millimeter;
						}
						
						if (s.IndexOf("Pixel")>-1)
						{
							gu |= GraphicsUnit.Pixel;
						}					

						if (s.IndexOf("Point")>-1)
						{
							gu |= GraphicsUnit.Point;
						}	

						if (s.IndexOf("World")>-1)
						{
							gu |= GraphicsUnit.World;
						}	
 

						Font font = new Font(fontFamily, size, fs,gu,
							System.Convert.ToByte(sr.ReadLine()),
							System.Convert.ToBoolean(sr.ReadLine()));
						sf.lblEffect.Font = font;
						
						this.rtbConsole.ForeColor = sf.lblEffect.ForeColor;
						this.rtbConsole.BackColor = sf.lblEffect.BackColor;
						this.rtbConsole.Font = sf.lblEffect.Font;
						this.rtbConsole.SelectionFont = sf.lblEffect.Font;

						//自动连接
						if (sf.chkAutoConnect.Checked)
						{
							this.Connect();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e.ToString());
					}
				}

			}
		}
		

		private void rtbConsole_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (socket == null || !socket.Connected)
			{
				return;
			}

			bool control_on = e.Control;
			string key = "";

			switch (e.KeyCode)
			{
				case Keys.Back:	
					Send((char)e.KeyCode+"");
					break;
				case Keys.End:
					key = OUTPUTMARK + "[K";
					break;
				case Keys.Home:
					key = OUTPUTMARK + "[H";
					break;
				case Keys.Left:
					key  = OUTPUTMARK + "[D";
					break;
				case Keys.Right:
					key  = OUTPUTMARK + "[C";
					break;
				case Keys.Up:
					key =  OUTPUTMARK + "[A";
					break;
				case Keys.Down:
					key = OUTPUTMARK + "[B";
					break;
				case Keys.F1:
					key  = OUTPUTMARK + "OP";
					break;
				case Keys.F2:
					key = OUTPUTMARK + "OQ";
					break;
				case Keys.F3:
					key  = OUTPUTMARK + "OR";
					break;
				case Keys.F4:
					key = OUTPUTMARK + "OS";
					break;
				default:
					if (control_on && e.KeyValue > 63)
					{
						key = "" + (char)(e.KeyValue - 64);
					}
					break;
			}
			if (key.Length >0)
			{
				Send(key);
			}
			e.Handled = true;
		}


		private void rtbConsole_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (socket == null || !socket.Connected)
			{
				return;
			}

			if (e.KeyChar == 13)
			{
				Send(e.KeyChar.ToString() + LF);
			}
			else
			{
				//只接受有效的字符
				if (e.KeyChar >= ' ' && e.KeyChar <= 'z')
				{
					Send(e.KeyChar.ToString());
				}				
			}
			e.Handled = true;
		}


		private void Connect() 
		{
			sw_igoahead = false;
			sw_ugoahead = true;
			sw_igoahead = false;
			sw_echo = true;
			sw_termsent = false;

			Console.WriteLine("连接服务器" + sf.txtRemoteAddress.Text + "...");

			socket = new Socket(AddressFamily.InterNetwork,
				SocketType.Stream,ProtocolType.Tcp);
			socket.SetSocketOption (SocketOptionLevel.Socket, 
				SocketOptionName.SendTimeout, 5000);	
			IPAddress ipAdd=IPAddress.Parse(sf.txtRemoteAddress.Text);
			int port = System.Convert.ToInt32(sf.txtPort.Text);
			IPEndPoint hostEndPoint = new IPEndPoint(ipAdd, port);
			
			try
			{
				socket.Connect(hostEndPoint);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				this.statusBarPanel4.Text = "服务器状态：服务器未准备好";
				return;
			}

			if (socket.Connected)
			{
				//更新状态
				this.statusBarPanel1.Text = "状态：已连接";
				this.statusBarPanel3.Text = "服务器地址：" + 
					sf.txtRemoteAddress.Text;
				this.statusBarPanel4.Text = "服务器状态：服务器已经接受连接"; 

				Thread thread=new Thread(new ThreadStart(this.TelnetThread));
				thread.Start();
			}
				
		}

		private void CloseConnection()
		{
			if (socket != null && socket.Connected)
			{
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
			this.statusBarPanel1.Text = "状态：断开连接...";

		}				

		private string GetLocalAPAddress()
		{
			
			IPAddress[] AddressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
			if (AddressList.Length>0)
			{
				//首先获得拨号动态分配IP地址
				//如果没有，则获得局域网地址
				return AddressList[AddressList.Length-1].ToString();
			}
			return "";
		}

		private void TelnetThread()
		{	
			while(socket.Connected)
			{
				try
				{
					string str = Receive();
					str = str.Replace("\0", "");
					string delim = "\b";
					str = str.Trim(delim.ToCharArray());
					if (str.Length > 0)
					{	
						Console.WriteLine(str);
						
						if (str == OUTPUTMARK + BACK)
						{
							//BackupSpace键处理
							this.rtbConsole.ReadOnly = false;
							int curpos = rtbConsole.SelectionStart;
							this.rtbConsole.Select(curpos-1, 1);
							this.rtbConsole.SelectedText = "";
							this.rtbConsole.ReadOnly = true;
						}
						else 
						{
							int len;
							for (int i=0;i<str.Length;i+=80)
							{
								len = 80;
								if (i+80 > str.Length)
								{
									len = str.Length -i;
								}
								this.rtbConsole.AppendText(str.Substring(i, len));
							}
						}
					}
					Thread.Sleep(100);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			this.statusBarPanel1.Text = "状态：已断开";
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			CloseConnection();
		}

		//向Telnet服务器发送命令
		private void Send(string msg)
		{
			System.Byte[] message=System.Text.Encoding.ASCII.GetBytes(
				msg.ToCharArray());
			socket.Send(message,message.Length,0);
		}

		//向Telnet服务器发送命令
		private void Send(char[] chr)
		{
			System.Byte[] message=System.Text.Encoding.ASCII.GetBytes(chr);
			socket.Send(message,message.Length,0);
		}

		//接收数据
		private string Receive()
		{
			//用于接收数据的缓冲
			byte[] buf;
			string result="";

			int count = socket.Available;
			if (count > 0)
			{
				buf = new byte[count];
				socket.Receive(buf);
				result = ProcessOptions(buf);
			}
			return result;
		}

		//处理命令字符，buf是包含数据的缓冲
		private string ProcessOptions(byte[] buf)
		{
			string strNormal="";
			int i=0;
			while(i<buf.Length)
			{
				if (buf[i]==IAC)
				{
					switch((char)buf[++i])
					{
						case DO:
							Console.Write("--------------接收到 DO ");
							ProcessDo(buf[++i]);
							break;
						case DONT:
							Console.Write("--------------接收到 DONT ");
							ProcessDont(buf[++i]);
							break;
						case WONT:
							Console.Write("--------------接收到 WONT ");
							ProcessWont(buf[++i]);
							break;
						case WILL:
							Console.Write("--------------接收到 WILL ");
							ProcessWill(buf[++i]);
							break;
						case IAC:
							//正常字符
							strNormal += System.Text.Encoding.Default.GetString(buf,i,1);
							break;
						case SB:
							//子会话开始
							int j=0;
							while(buf[++i] != SE)
							{
								parsedata[j++] = buf[i];
							}
							//子会话结束:
							switch((char)parsedata[0])
							{
								case TERMTYPE:
									break;
								case TERMSPEED:
									if (parsedata[1] == 1)
									{
										Console.WriteLine("发送: SB TERMSPEED 57600,57600");
										Send(IAC +
											SB + TERMSPEED + 
											IS + "57600,57600" + IAC + SE);
									}
									break;
							}
							break;
						default:
							Console.WriteLine("无效的命令" + buf[1]);
							i++;
							break;
					};
				}
				else
				{
					//正常的文字
					strNormal += System.Text.Encoding.Default.GetString(buf,i,1);		
				}
				i++;
			}
			return strNormal;
		}

		private void ProcessDo(short ch)
		{
			//处理DO，以WILL或者WONT响应
			switch((char)ch)
			{
				case BINARY:
					Console.WriteLine(BINARY);
					Send(new char[] {IAC, WONT, BINARY});
					Console.WriteLine("发送: WONT BINARY");
					break;
				case ECHO:
					Console.WriteLine(ECHO);
					Send(new char[] {IAC, WONT, ECHO});
					Console.WriteLine("发送: WONT ECHO");
					break;
				case SGA:
					Console.WriteLine(SGA);
					if (!sw_igoahead)
					{
						Send(new char[] {IAC, WILL, SGA});
						Console.WriteLine("发送: WILL SGA");
						sw_igoahead = true;
					}
					else
					{
						Console.WriteLine("不发送响应");
					}
					break;
				case TERMSPEED:
					Console.WriteLine(TERMSPEED);
					Send(new char[] {IAC, WILL, TERMSPEED});
					Console.WriteLine("发送: WILL TERMSPEED");

					Send(IAC + SB + TERMSPEED + (char)0 + "57600,57600" + 
														  IAC + SE);
					Console.WriteLine("发送:SB TERMSPEED 57600");
					break;
				case TFLOWCNTRL:
					Console.WriteLine(TFLOWCNTRL);
					Send(new char[] {IAC, WONT, TFLOWCNTRL});
					Console.WriteLine("发送: WONT TFLOWCNTRL");
					break;
				case LINEMODE:
					Console.WriteLine(LINEMODE);
					Send(new char[] {IAC, WONT, LINEMODE});
					Console.WriteLine("发送: WONT LINEMODE");
					break;
				case STATUS:
					Console.WriteLine(STATUS);
					Send(new char[] {IAC, WONT, STATUS});
					Console.WriteLine("发送: WONT STATUS");
					break;
				case TIMING:
					Console.WriteLine(TIMING);
					Send(new char[] {IAC, WONT, TIMING});
					Console.WriteLine("发送: WONT TIMING");
					break;
				case DISPLOC:
					Console.WriteLine(DISPLOC);
					Send(new char[] {IAC, WONT, DISPLOC});
					Console.WriteLine("发送: WONT DISPLOC");
					break;
				case ENVIRON:
					Console.WriteLine(ENVIRON);
					Send(new char[] {IAC, WONT, ENVIRON});
					Console.WriteLine("发送: WONT ENVIRON");
					break;
				case UNKNOWN39:
					Console.WriteLine(UNKNOWN39);
					Send(new char[] {IAC, WILL, UNKNOWN39});
					Console.WriteLine("发送: WILL UNKNOWN39");
					break;
				case AUTHENTICATION:
					Console.WriteLine(AUTHENTICATION);
					Send(new char[] {IAC, WONT, AUTHENTICATION});
					Console.WriteLine("发送: WONT AUTHENTICATION");
					Console.WriteLine("发送: SB AUTHENTICATION");
					Send(IAC + SB + AUTHENTICATION + (char)0 + (char)0 +
						(char)0 + (char)0 + "" + IAC + SE);
					break;
				default:
					Console.WriteLine("未知的选项");
					break;
			}
		}

		//处理DONT
		private void ProcessDont(short ch)
		{
			switch((char)ch)
			{
				case SE:
					Console.WriteLine(SE);
					Console.WriteLine("接收到: RECEIVED SE");
					break;
				case ECHO:
					Console.WriteLine(ECHO);
					if (!sw_echo)
					{
						sw_echo = true;
						Send(new char[] {IAC, WONT, ECHO});
						Console.WriteLine("发送: WONT ECHO");
					}
					break;
				case SGA:
					Console.WriteLine(SGA);
					if (!sw_ugoahead)
					{
						Send(new char[] {IAC, WONT, SGA});
						Console.WriteLine("发送: WONT SGA");
						sw_ugoahead = true;
					}
					break;
				case TERMSPEED:
					Console.WriteLine(TERMSPEED);
					Send(new char[] {IAC, WONT, TERMSPEED});
					Console.WriteLine("发送: WONT TERMSPEED");
					break;
				case TFLOWCNTRL:
					Console.WriteLine(TFLOWCNTRL);
					Send(new char[] {IAC, WONT, TFLOWCNTRL});
					Console.WriteLine("发送: WONT TFLOWCNTRL");
					break;
				case STATUS:
					Console.WriteLine(STATUS);
					Send(new char[] {IAC, WONT, STATUS});
					Console.WriteLine("发送: WONT STATUS");
					break;
				case TIMING:
					Console.WriteLine(TIMING);
					Send(new char[] {IAC, WONT, TIMING});
					Console.WriteLine("发送: WONT TIMING");
					break;
				case DISPLOC:
					Console.WriteLine(DISPLOC);
					Send(new char[] {IAC, WONT, DISPLOC});
					Console.WriteLine("发送: WONT DISPLOC");
					break;
				case ENVIRON:
					Console.WriteLine(ENVIRON);
					Send(new char[] {IAC, WONT, ENVIRON});
					Console.WriteLine("发送: WONT ENVIRON");
					break;
				case UNKNOWN39:
					Console.WriteLine(UNKNOWN39);
					Send(new char[] {IAC, WILL, UNKNOWN39});
					Console.WriteLine("发送: WILL UNKNOWN39");
					break;
				default:
					break;
			}			
		}

		//处理WONT
		private void ProcessWont(short ch)
		{
			switch((char)ch)
			{
				case ECHO:
					Console.WriteLine(ECHO);
					if (sw_echo)
					{
						sw_echo = false;
						Send(new char[] {IAC, DONT, ECHO});
						Console.WriteLine("发送: DONT ECHO");
					}
					break;
				case SGA:
					Console.WriteLine(SGA);
					Send(new char[] {IAC, DONT, SGA});
					Console.WriteLine("发送: DONT SGA");
					sw_igoahead = false;
					break;
				case TERMSPEED:
					Console.WriteLine(TERMSPEED);
					Send(new char[] {IAC, DONT, TERMSPEED});
					Console.WriteLine("发送: DONT TERMSPEED");
					break;
				case TFLOWCNTRL:
					Console.WriteLine(TFLOWCNTRL);
					Send(new char[] {IAC, DONT, TFLOWCNTRL});
					Console.WriteLine("发送: DONT TFLOWCNTRL");
					break;
				case LINEMODE:
					Console.WriteLine(LINEMODE);
					Send(new char[] {IAC, DONT, LINEMODE});
					Console.WriteLine("发送: DONT LINEMODE");
					break;
				case STATUS:
					Console.WriteLine(STATUS);
					Send(new char[] {IAC, DONT, STATUS});
					Console.WriteLine("发送: DONT STATUS");
					break;
				case TIMING:
					Console.WriteLine(TIMING);
					Send(new char[] {IAC, WONT, TIMING});
					Console.WriteLine("发送: WONT TIMING");
					break;
				case DISPLOC:
					Console.WriteLine(DISPLOC);
					Send(new char[] {IAC, DONT, DISPLOC});
					Console.WriteLine("发送: DONT DISPLOC");
					break;
				case ENVIRON:
					Console.WriteLine(ENVIRON);
					Send(new char[] {IAC, DONT, ENVIRON});
					Console.WriteLine("发送: DONT ENVIRON");
					break;
				case UNKNOWN39:
					Console.WriteLine(UNKNOWN39);
					Send(new char[] {IAC, DONT, UNKNOWN39});
					Console.WriteLine("发送: DONT UNKNOWN39");
					break;
				default:
					Console.WriteLine("未知的选项");
					break;
			}
		}

		//处理WILL，以DO或者DONT响应
		private void ProcessWill(short ch)
		{
			switch((char)ch)
			{
				case ECHO:
					Console.WriteLine(ECHO);
					if (!sw_echo)
					{
						sw_echo = true;
						Send(new char[] {IAC, DO, ECHO});
						Console.WriteLine("发送: DO ECHO");
					}
					break;
				case SGA:
					Console.WriteLine(SGA);
					if (!sw_ugoahead)
					{
						Send(new char[] {IAC, DO, SGA});
						Console.WriteLine("发送: DO SGA");
						sw_ugoahead = true;
					}
					else
					{
						Console.WriteLine("不发送响应");
					}
					break;
				case TERMTYPE:
					Console.WriteLine("TERMTYPE");
					if (!sw_termsent)
					{
						Send(new char[] {IAC, WILL, TERMTYPE});
						Send(IAC + SB + TERMTYPE + (char)0 + "VT100" + IAC + SE);
						sw_termsent = true;
						Console.WriteLine("发送: SB TERMTYPE VT100");
					}
					break;
				case TERMSPEED:
					Console.WriteLine(TERMSPEED);
					Send(new char[] {IAC, DONT, TERMSPEED});
					Console.WriteLine("发送: DONT TERMSPEED");
					break;
				case TFLOWCNTRL:
					Console.WriteLine(TFLOWCNTRL);
					Send(new char[] {IAC, DONT, TFLOWCNTRL});
					Console.WriteLine("发送: DONT TFLOWCNTRL");
					break;
				case LINEMODE:
					Console.WriteLine(LINEMODE);
					Send(new char[] {IAC, WONT, LINEMODE});
					Console.WriteLine("发送: WONT LINEMODE");
					break;
				case STATUS:
					Console.WriteLine(STATUS);
					Send(new char[] {IAC, DONT, STATUS});
					Console.WriteLine("发送: DONT STATUS");
					break;
				case TIMING:
					Console.WriteLine(TIMING);
					Send(new char[] {IAC, DONT, TIMING});
					Console.WriteLine("发送: DONT TIMING");
					break;
				case DISPLOC:
					Console.WriteLine(DISPLOC);
					Send(new char[] {IAC, DONT, DISPLOC});
					Console.WriteLine("发送: DONT DISPLOC");
					break;
				case ENVIRON:
					Console.WriteLine(ENVIRON);
					Send(new char[] {IAC, DONT, ENVIRON});
					Console.WriteLine("发送: DONT ENVIRON");
					break;
				case UNKNOWN39:
					Console.WriteLine(UNKNOWN39);
					Send(new char[] {IAC, DONT, UNKNOWN39});
					Console.WriteLine("发送: DONT UNKNOWN39");
					break;
				default:
					Console.WriteLine("未知的选项");
					break;
			}
		}


	}
}
