using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ChargeManageForm
{
	/// <summary>
	/// Form1的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private TeleCommServices.ChargeManageServices service=null;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private DateTime StartTime;
		private int Duration;

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
			init();
			service=new TeleCommServices.ChargeManageServices();
		}

		/// <summary>
		///清理所有正在使用的资源。
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new System.Drawing.Point(24, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 88);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "短信";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(312, 24);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "发送短信";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(128, 56);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(152, 20);
			this.comboBox1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "短信状态：";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "发送卡号：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(128, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(152, 21);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Location = new System.Drawing.Point(24, 88);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(424, 208);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "通话";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(312, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "开始通话";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.comboBox3);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.textBox3);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Location = new System.Drawing.Point(8, 112);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(288, 88);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "接听者";
			// 
			// comboBox3
			// 
			this.comboBox3.BackColor = System.Drawing.SystemColors.Window;
			this.comboBox3.Location = new System.Drawing.Point(120, 56);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(152, 20);
			this.comboBox3.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 2;
			this.label6.Text = "接听状态：";
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.SystemColors.Window;
			this.textBox3.Location = new System.Drawing.Point(120, 24);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(152, 21);
			this.textBox3.TabIndex = 1;
			this.textBox3.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "接听卡号：";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.comboBox2);
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(8, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(288, 88);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "拨出者";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "拨出状态：";
			// 
			// comboBox2
			// 
			this.comboBox2.BackColor = System.Drawing.SystemColors.Window;
			this.comboBox2.Location = new System.Drawing.Point(120, 56);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(152, 20);
			this.comboBox2.TabIndex = 2;
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.SystemColors.Window;
			this.textBox2.Location = new System.Drawing.Point(120, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(152, 21);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "拨出卡号：";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.richTextBox1);
			this.groupBox5.Location = new System.Drawing.Point(459, 1);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(236, 296);
			this.groupBox5.TabIndex = 2;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "操作结果信息";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(3, 17);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(230, 276);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(698, 322);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "收费管理";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
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
		private void init()
		{
			//初始化短信状态
			comboBox1.Items.Add("InCell");
			comboBox1.Items.Add("InterCell");
			comboBox1.SelectedIndex=0;
			//初始化呼出状态
			comboBox2.Items.Add("InCell");
			comboBox2.Items.Add("InterCell");
			comboBox2.Items.Add("Roaming");
			comboBox2.SelectedIndex=0;
			//初始化接听状态
			comboBox3.Items.Add("InCell");
			comboBox3.Items.Add("InterCell");
			comboBox3.Items.Add("Roaming");
			comboBox3.SelectedIndex=0;
		}
		//发送短信
		private void button2_Click(object sender, System.EventArgs e)
		{
			string CardNo=textBox1.Text;
			string SMStatus=comboBox1.SelectedItem.ToString();
			DateTime Time=DateTime.Now;
			bool result;
			result=service.SendSM(CardNo,SMStatus,Time);
			if(result)
			{
				richTextBox1.AppendText("短信发送成功！\r\n");				
			}
			else
			{
				richTextBox1.AppendText("短信发送失败！\r\n");
			}
		}
		//通话
		private void button1_Click(object sender, System.EventArgs e)
		{
			Button source;
			source=(Button)sender;
			if(source.Text=="开始通话")
			{
				StartTime=DateTime.Now;
				source.Text="结束通话";
				richTextBox1.AppendText("通话正在进行中...\r\n");
				richTextBox1.AppendText("想结束通话，请按“结束通话”按钮！\r\n");
				textBox2.Enabled=false;
				comboBox2.Enabled=false;
				textBox3.Enabled=false;
				comboBox3.Enabled=false;
			}
			else if(source.Text=="结束通话")
			{
				bool result;
				string FromCard=textBox2.Text;
				string ToCard=textBox3.Text;
				string CallStatus=comboBox2.SelectedItem.ToString();
				string ReceiveStatus=comboBox2.SelectedItem.ToString();
				Duration=(int)(DateTime.Now.Ticks-StartTime.Ticks)/10000000;
				result=service.Call(FromCard,ToCard,StartTime,Duration,CallStatus,ReceiveStatus);
				if(result)
				{
					richTextBox1.AppendText("通话成功！\r\n");
					richTextBox1.AppendText("通话开始时间是："+StartTime+",通话时长："+Duration+"秒\r\n");
				}
				else
				{
					richTextBox1.AppendText("通话失败！\r\n");
				}
				source.Text="开始通话";
				textBox2.Enabled=true;
				comboBox2.Enabled=true;
				textBox3.Enabled=true;
				comboBox3.Enabled=true;
			}			
		}

		private void richTextBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
