using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;



namespace game
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "昵称：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(64, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Location = new System.Drawing.Point(16, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(160, 80);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "游戏设置";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(24, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "建立主机";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(24, 48);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 3;
			this.radioButton2.Text = "连接主机";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "主机IP：";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(72, 136);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 167);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(288, 22);
			this.statusBar1.TabIndex = 5;
			this.statusBar1.Text = "连接信息";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(200, 40);
			this.button1.Name = "button1";
			this.button1.TabIndex = 6;
			this.button1.Text = "确定";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(200, 80);
			this.button2.Name = "button2";
			this.button2.TabIndex = 7;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(288, 189);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "登录";
			this.Load += new System.EventHandler(this.Form1_Load);
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
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			textBox2.Text=getIPAddress(); 
			
		}
		private static string getIPAddress ( ) 
		{ 
			System.Net.IPAddress addr; 
			// 获得本机局域网IP地址 
			addr = new System.Net.IPAddress(Dns.GetHostByName( Dns.GetHostName()).AddressList[0].Address) ; 
			return addr.ToString ( ) ; 
		}
		//进入主窗体
		private void button1_Click(object sender, System.EventArgs e)
		{
			if(textBox1.Text=="")
			{
				MessageBox.Show("请填写昵称！");
				
			}
			
			if(radioButton1.Checked==true)
			{
				statusBar1.Text="正在创建服务器！";
				fivechess five=new fivechess();
				string na=textBox1.Text;
				five.nich(na);
				five.Show();
				
			}
			else
			{
				statusBar1.Text="正在连接服务器！";
				fiveclick click= new fiveclick();
				string na=textBox1.Text;
				click.nich(na);
				string ip=textBox2.Text;
				click.ipa(ip);
				click.Show();
			}
			

		}
		//退出窗体
		private void button2_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox2.Text="0.0.0.0";
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox2.Text=getIPAddress(); 
		}

		

	}
}
