using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.IO;
using System.Threading;

namespace Download
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		
		private System.Windows.Forms.StatusBar statusBar1;
		private WebClient client=new WebClient();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox6;
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(104, 296);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(152, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "d:\\down";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(296, 296);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "下载";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 351);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(512, 22);
			this.statusBar1.TabIndex = 3;
			this.statusBar1.Text = "下载状态";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 296);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "保存地址";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(104, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(360, 21);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "http://dl.163.com/html/article/20050613/article_184.html";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "下载地址1";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(104, 88);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(360, 21);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "http://www.263.net/index.html";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "下载地址2";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "下载地址3";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(104, 136);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(360, 21);
			this.textBox4.TabIndex = 10;
			this.textBox4.Text = "http://tech.163.com/special/t/00091GQE/ty005.html";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 184);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 11;
			this.label5.Text = "下载地址4";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(104, 184);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(360, 21);
			this.textBox5.TabIndex = 12;
			this.textBox5.Text = "http://tech.163.com/05/0713/16/1OI7VCMR00091G25.html";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 232);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 13;
			this.label6.Text = "下载地址5";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(104, 232);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(360, 21);
			this.textBox6.TabIndex = 14;
			this.textBox6.Text = "http://tech.163.com/05/0711/16/1OD30HMI00091G26.html";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(384, 296);
			this.button2.Name = "button2";
			this.button2.TabIndex = 15;
			this.button2.Text = "暂停";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(512, 373);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "下载";
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

		public System.Threading.Thread m_thdone;
		public System.Threading.Thread m_thdtwo;
		public System.Threading.Thread m_thdthree;
		public System.Threading.Thread m_thdfour;
		public System.Threading.Thread m_thdfive;
		
		

		public void ThreadOne()
		{
			button1.Enabled=false;			
			string Url=textBox2.Text;
			int n = Url.LastIndexOf('/');
			string UrlAddress = Url.Substring(0,n);
			string fileName=Url.Substring(n+1,Url.Length-n-1);
			string Dir = textBox1.Text;
			string Path = Dir+"\\"+fileName;
			try
			{
				WebRequest myre = WebRequest.Create(UrlAddress);
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
			}
			try
			{
				statusBar1.Text = "下载文件……";
				client.DownloadFile(UrlAddress,Path);
				statusBar1.Text = "下载完毕";
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
				statusBar1.Text="";
			}
			button1.Enabled = true;	
		}
		public void ThreadTwo()
		{
			button1.Enabled=false;			
			string Url1=textBox3.Text;
			int n1 = Url1.LastIndexOf('/');
			string UrlAddress1 = Url1.Substring(0,n1);
			string fileName1=Url1.Substring(n1+1,Url1.Length-n1-1);
			string Dir = textBox1.Text;
			string Path = Dir+"\\"+fileName1;
			try
			{
				WebRequest myre1 = WebRequest.Create(UrlAddress1);
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
			}
			try
			{
				statusBar1.Text = "下载文件……";
				client.DownloadFile(UrlAddress1,Path);
				statusBar1.Text = "下载完毕";
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
				statusBar1.Text="";
			}
			button1.Enabled = true;	
		}
		public void ThreadThree()
		{
			button1.Enabled=false;			
			string Url2=textBox4.Text;
			int n2 = Url2.LastIndexOf('/');
			string UrlAddress2 = Url2.Substring(0,n2);
			string fileName2=Url2.Substring(n2+1,Url2.Length-n2-1);
			string Dir = textBox1.Text;
			string Path = Dir+"\\"+fileName2;
			try
			{
				WebRequest myre2 = WebRequest.Create(UrlAddress2);
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
			}
			try
			{
				statusBar1.Text = "下载文件……";
				client.DownloadFile(UrlAddress2,Path);
				statusBar1.Text = "下载完毕";
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
				statusBar1.Text="";
			}
			button1.Enabled = true;	
		}
		public void ThreadFour()
		{
			button1.Enabled=false;			
			string Url3=textBox5.Text;
			int n3 = Url3.LastIndexOf('/');
			string UrlAddress3 = Url3.Substring(0,n3);
			string fileName3=Url3.Substring(n3+1,Url3.Length-n3-1);
			string Dir = textBox1.Text;
			string Path = Dir+"\\"+fileName3;
			try
			{
				WebRequest myre3 = WebRequest.Create(UrlAddress3);
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
			}
			try
			{
				statusBar1.Text = "下载文件……";
				client.DownloadFile(UrlAddress3,Path);
				statusBar1.Text = "下载完毕";
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
				statusBar1.Text="";
			}
			button1.Enabled = true;	
		}
		public void ThreadFive()
		{
			button1.Enabled=false;			
			string Url4=textBox6.Text;
			int n4 = Url4.LastIndexOf('/');
			string UrlAddress4 = Url4.Substring(0,n4);
			string fileName4=Url4.Substring(n4+1,Url4.Length-n4-1);
			string Dir = textBox1.Text;
			string Path = Dir+"\\"+fileName4;
			try
			{
				WebRequest myre4 = WebRequest.Create(UrlAddress4);
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
			}
			try
			{
				statusBar1.Text = "下载文件……";
				client.DownloadFile(UrlAddress4,Path);
				statusBar1.Text = "下载完毕";
			}
			catch(WebException exp)
			{
				MessageBox.Show(exp.Message,"Error");
				statusBar1.Text="";
			}
			button1.Enabled = true;	
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			
			button1.Enabled=false;
			button2.Enabled=true;

			m_thdone=new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadOne));
			m_thdtwo=new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadTwo));
			m_thdthree=new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadThree));
			m_thdfour=new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadFour));
			m_thdfive=new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadFive));
			
			m_thdone.Start();
			m_thdtwo.Start();
			m_thdthree.Start();
			m_thdfour.Start();
			m_thdfive.Start();						
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			button1.Enabled=true;
			button2.Enabled=false;
			 m_thdone.Abort();
			 m_thdtwo.Abort();
			 m_thdthree.Abort();
			 m_thdfour.Abort();
			 m_thdfive.Abort();

		}		
	}
}
