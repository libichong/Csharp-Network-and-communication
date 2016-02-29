using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;

namespace game
{
	/// <summary>
	/// fivechess 的摘要说明。
	/// </summary>
	public class fivechess : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private const int None = -1;//没有棋子
		private const int White = 0;//代表白棋
		private const int Black = 1;//代表黑棋
		private int [,]checkerBoard = new int [15, 15];//棋盘(用来保存每一个棋子)
		private int nextPlayer;//下一个选手
		private int Player
		{
			get
			{
				return nextPlayer;
			}
			set
			{
				nextPlayer = value;
				ReDrawNextPlayerMark();
			}
		}
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label1;//下一次该黑棋还是白棋下
		private Stack History;//下棋的历史记录
		
		private IPEndPoint client;
		private Socket     server;
		private Thread     thdSvr;
		NetworkStream      stream;
		TextWriter          write;
		TextReader         reader;
		private System.Windows.Forms.Label label2;
		string na;
		
		private void ThreadServer()
		{
			client=new IPEndPoint(IPAddress.Any,34567);
			server=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
			server.Blocking=true;
			server.Bind(client);
			server.Listen(0);
			while(true)
			{
				Socket t=server.Accept();
				if(t!=null)
				{
					stream=new NetworkStream(t);
					write=new StreamWriter(stream);
					reader=new StreamReader(stream);
					richTextBox1.Text+="其他用户正在连接服务器……\n";
					write.WriteLine("连接到服务器！");
					write.Flush();
					write.WriteLine("可以玩游戏了！");
                    write.Flush();
					richTextBox1.Text+=reader.ReadLine();
					richTextBox1.Text+="\n";
                    reader.Close();
					write.Close();
					t.Close();

				}
			}
		}
		public void nich(string name)
		{
			na=name;
		}

		public fivechess()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//			checkerBoard = new int [15,15];
			History = new Stack();
			Player = White;//默认设置为白棋先下
			Reset();

		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(server!=null)
				server.Close();
			if(thdSvr!=null)
				thdSvr.Abort();
			if( disposing )
			{
				if(components != null)
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fivechess));
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.menuItem5.Text = "开始 (&N)";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuItem6.Text = "退出 (&X)";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem9,
																					  this.menuItem6});
			this.menuItem1.Text = "系统 (&S)";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(20, 20);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.richTextBox1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(321, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(231, 338);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "连接状态";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(79, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 12);
			this.label2.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(26, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "昵称：";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.richTextBox1.Location = new System.Drawing.Point(21, 74);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(181, 224);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "等待其他用户连接服务器……";
			// 
			// fivechess
			// 
			this.AccessibleDescription = "";
			this.AllowDrop = true;
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(10, 25);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(549, 331);
			this.Controls.Add(this.groupBox1);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "fivechess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "五子棋";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		

		

		private void Form1_Load(object sender, System.EventArgs e)
		{
			label2.Text+=na;
			thdSvr=new Thread(new ThreadStart(this.ThreadServer));
			thdSvr.Start();
		}

		

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			if(History.Count > 0) this.Reset();
		}

		

		//重载重画函数
		protected override void OnPaint(PaintEventArgs e)
		{
			System.Drawing.Graphics g = this.CreateGraphics();
			for(int x = 0; x < 15; x++)
			{
				for(int y= 0; y < 15; y++)
				{
					if(checkerBoard[ y, x ] != None)	DrawChess(new Point(x, y), checkerBoard[ y, x ]);
				}
			}
			ReDrawNextPlayerMark();
			base.OnPaint(e);
		}

		//重载鼠标按下事件
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e) 
		{
			base.OnMouseDown(e);
			switch( e.Button )
			{
					//take left button down
				case MouseButtons.Left:
					if( (History.Count == 0) && (2 < e.X) && (e.X < 22) && (309 < e.Y) && (e.Y < 329) ) Player = (Player == White)? Black: White;
					else	AddChess( MToA( new Point(e.X, e.Y) ) );
					break;
					//take right button down
				case MouseButtons.Right:
					//					OnRButtonDown(new Point(e.X,e.Y));
					break;
			}
		}

		//把鼠标坐标转换成棋盘坐标
		private Point MToA(Point p)
		{
			return new Point( (p.X - 15) / 20, (p.Y - 6) / 20);
		}

		//开始新的棋局，所有数据复位并重画棋盘
		private void Reset()
		{
			for( int i = 0; i < 15; i++ )
			{
				for( int j = 0; j < 15; j++)
				{
					checkerBoard[i,j] = None;
				}
			}
			History.Clear();//清空历史记录
			DrawCheckerBoard();//重画棋盘
		}

		//重画棋盘
		private void DrawCheckerBoard()
		{
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.BackColor = System.Drawing.SystemColors.Control;
		}

		//重画下一个选手的标志棋子
		private void ReDrawNextPlayerMark()
		{
			System.Drawing.Graphics g = this.CreateGraphics();
			imageList1.Draw(g, 2, 309, 20, 20, Player);
		}

		//在棋盘上画一个棋子
		private void DrawChess(Point pCoordinates,int iPlayer)
		{
			System.Drawing.Graphics g = this.CreateGraphics();
			imageList1.Draw(g, 15 + pCoordinates.X * 20, 6 + pCoordinates.Y * 20, 20, 20, iPlayer);
		}

		//在指定的棋盘坐标位置添加一个棋子
		private void AddChess(Point p)
		{
			//判断是否超出边界
			if( (p.X < 0 || p.X > 14) || (p.Y < 0 || p.Y > 14) ) return;
			//判断该位置有无棋子
			if( checkerBoard[ p.Y, p.X ] != None ) return;//如果已经有了棋子则退出（这颗棋不能下）
			DrawChess( p,Player );
			if(Player == White)//该白棋下
			{
				checkerBoard[ p.Y, p.X ] = White;
				Player = Black;
			}
			else
			{
				checkerBoard[ p.Y, p.X ] = Black;
				Player = White;
			}
			History.Push( new Point(p.X, p.Y) );//添加历史记录
			CheckGameResult( p );
		}

		//检查游戏结果
		/*
		 * 算法：
		 * 由于根据游戏规则，只有先放成 5 个相连的棋子的一方或剩，
		 * 所以只要以刚刚下过的那个棋子为中心，检查有没有 5 个相连的同颜色棋子就好了。
		 */
		private void CheckGameResult(Point sourcePoint)
		{
			int x,y;
			int LastPlayer = (Player == White)? Black: White;
			int n;

			//检查行
			n = 1;
			y = sourcePoint.Y;
			for(x = sourcePoint.X - 1; x >= 0; x--)
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			for(x = sourcePoint.X + 1; x < 15; x++)
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			if(n >= 5)
			{
				Win(LastPlayer);
				return;
			}

			//检查列
			n = 1;
			x = sourcePoint.X;
			for(y = sourcePoint.Y - 1; y >= 0; y--)
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			for(y = sourcePoint.Y + 1; y < 15; y++)
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			if(n >= 5)
			{
				Win(LastPlayer);
				return;
			}

			//检查左斜线
			n=1;
			for(x = sourcePoint.X + 1 , y = sourcePoint.Y - 1; x < 15 && y >= 0; x++, y--)//检查左斜线的上半截
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			for(x = sourcePoint.X - 1 , y = sourcePoint.Y + 1; x >= 0 && y < 15; x--, y++)//检查左斜线的下半截
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			if(n >= 5)
			{
				Win(LastPlayer);
				return;
			}

			//检查右斜线
			n = 1;
			for(x = sourcePoint.X - 1 , y = sourcePoint.Y - 1; x >= 0 && y >= 0; x--, y--)//检查右斜线的上半截
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			for(x = sourcePoint.X + 1 , y = sourcePoint.Y + 1; x < 15 && y < 15; x++, y++)//检查右斜线的下半截
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			if(n >= 5)
			{
				Win(LastPlayer);
				return;
			}

			//棋盘满棋，平手
			if(History.Count >= 225)
			{
				Win(None);
				return;
			}

		}

		//显示指定选手的获胜信息
		private void Win(int NPlayer)
		{
			switch(NPlayer)
			{
				case None:
					MessageBox.Show("本局平手!");
					break;
				case White:
					MessageBox.Show("本局 白棋 获胜 !");
					break;
				case Black:
					MessageBox.Show("本局 黑棋 获胜 !");
					break;
			}
			Reset();
		}		

	}
}

