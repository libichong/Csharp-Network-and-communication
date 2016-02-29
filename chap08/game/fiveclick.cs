using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;


namespace game
{
	/// <summary>
	/// fiveclick ��ժҪ˵����
	/// </summary>
	public class fiveclick : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private const int None = -1;//û������
		private const int White = 0;//�������
		private const int Black = 1;//�������
		private int [,]checkerBoard = new int [15, 15];//����(��������ÿһ������)
		private int nextPlayer;//��һ��ѡ��
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
		private System.Windows.Forms.Label label1;//��һ�θú��廹�ǰ�����
		private Stack History;//�������ʷ��¼
		
		
		private System.Windows.Forms.Label label2;
		string na;
		string ipadd;
		public void ipa(string ipad)
		{
			ipadd=ipad;
		}
		
		
		public void nich(string name)
		{
			na=name;
		}

		public fiveclick()
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
			Player = White;//Ĭ������Ϊ��������
			Reset();

		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fiveclick));
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
			this.menuItem5.Text = "��ʼ (&N)";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuItem6.Text = "�˳� (&X)";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem9,
																					  this.menuItem6});
			this.menuItem1.Text = "ϵͳ (&S)";
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
			this.groupBox1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(321, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(231, 338);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "����״̬";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(72, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 12);
			this.label2.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(26, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "�ǳƣ�";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(21, 74);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(181, 224);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// fiveclick
			// 
			this.AccessibleDescription = "";
			this.AllowDrop = true;
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(10, 25);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(546, 331);
			this.Controls.Add(this.groupBox1);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "fiveclick";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "������";
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
			TextWriter          write;
			TextReader         reader;
			IPAddress   serIP;
			IPEndPoint  server;
			Socket      client;
			NetworkStream stream;
			serIP=IPAddress.Parse(ipadd);
			server=new IPEndPoint(serIP,34567);
			client=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
			client.Connect(server);
			if(client.Connected)
			{
				stream=new NetworkStream(client);
				write=new StreamWriter(stream);
				reader=new StreamReader(stream);
				richTextBox1.Text+="���ӷ���������\n";
				richTextBox1.Text+=reader.ReadLine();
				richTextBox1.Text +=reader.ReadLine();
				richTextBox1.Text+="\n";
				write.WriteLine("���Խ�����Ϸ��");
				write.Flush();
				reader.Close();
				write.Close();
				stream.Close();
				client.Close();



			}
		}

		

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			if(History.Count > 0) this.Reset();
		}

		

		//�����ػ�����
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

		//������갴���¼�
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

		//���������ת������������
		private Point MToA(Point p)
		{
			return new Point( (p.X - 15) / 20, (p.Y - 6) / 20);
		}

		//��ʼ�µ���֣��������ݸ�λ���ػ�����
		private void Reset()
		{
			for( int i = 0; i < 15; i++ )
			{
				for( int j = 0; j < 15; j++)
				{
					checkerBoard[i,j] = None;
				}
			}
			History.Clear();//�����ʷ��¼
			DrawCheckerBoard();//�ػ�����
		}

		//�ػ�����
		private void DrawCheckerBoard()
		{
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.BackColor = System.Drawing.SystemColors.Control;
		}

		//�ػ���һ��ѡ�ֵı�־����
		private void ReDrawNextPlayerMark()
		{
			System.Drawing.Graphics g = this.CreateGraphics();
			imageList1.Draw(g, 2, 309, 20, 20, Player);
		}

		//�������ϻ�һ������
		private void DrawChess(Point pCoordinates,int iPlayer)
		{
			System.Drawing.Graphics g = this.CreateGraphics();
			imageList1.Draw(g, 15 + pCoordinates.X * 20, 6 + pCoordinates.Y * 20, 20, 20, iPlayer);
		}

		//��ָ������������λ�����һ������
		private void AddChess(Point p)
		{
			//�ж��Ƿ񳬳��߽�
			if( (p.X < 0 || p.X > 14) || (p.Y < 0 || p.Y > 14) ) return;
			//�жϸ�λ����������
			if( checkerBoard[ p.Y, p.X ] != None ) return;//����Ѿ������������˳�������岻���£�
			DrawChess( p,Player );
			if(Player == White)//�ð�����
			{
				checkerBoard[ p.Y, p.X ] = White;
				Player = Black;
			}
			else
			{
				checkerBoard[ p.Y, p.X ] = Black;
				Player = White;
			}
			History.Push( new Point(p.X, p.Y) );//�����ʷ��¼
			CheckGameResult( p );
		}

		//�����Ϸ���
		/*
		 * �㷨��
		 * ���ڸ�����Ϸ����ֻ���ȷų� 5 �����������ӵ�һ����ʣ��
		 * ����ֻҪ�Ըո��¹����Ǹ�����Ϊ���ģ������û�� 5 ��������ͬ��ɫ���Ӿͺ��ˡ�
		 */
		private void CheckGameResult(Point sourcePoint)
		{
			int x,y;
			int LastPlayer = (Player == White)? Black: White;
			int n;

			//�����
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

			//�����
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

			//�����б��
			n=1;
			for(x = sourcePoint.X + 1 , y = sourcePoint.Y - 1; x < 15 && y >= 0; x++, y--)//�����б�ߵ��ϰ��
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			for(x = sourcePoint.X - 1 , y = sourcePoint.Y + 1; x >= 0 && y < 15; x--, y++)//�����б�ߵ��°��
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			if(n >= 5)
			{
				Win(LastPlayer);
				return;
			}

			//�����б��
			n = 1;
			for(x = sourcePoint.X - 1 , y = sourcePoint.Y - 1; x >= 0 && y >= 0; x--, y--)//�����б�ߵ��ϰ��
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			for(x = sourcePoint.X + 1 , y = sourcePoint.Y + 1; x < 15 && y < 15; x++, y++)//�����б�ߵ��°��
			{
				if(checkerBoard[ y, x ] == LastPlayer) n++;
				else break;
			}
			if(n >= 5)
			{
				Win(LastPlayer);
				return;
			}

			//�������壬ƽ��
			if(History.Count >= 225)
			{
				Win(None);
				return;
			}

		}

		//��ʾָ��ѡ�ֵĻ�ʤ��Ϣ
		private void Win(int NPlayer)
		{
			switch(NPlayer)
			{
				case None:
					MessageBox.Show("����ƽ��!");
					break;
				case White:
					MessageBox.Show("���� ���� ��ʤ !");
					break;
				case Black:
					MessageBox.Show("���� ���� ��ʤ !");
					break;
			}
			Reset();
		}		

	}
}
