using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OperatorManageForm
{
	/// <summary>
	/// Form1的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private TeleCommServices.OperatorManageServices service=null;
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
			service=new TeleCommServices.OperatorManageServices();
		
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
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBox5);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(544, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "创建和删除卡号";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(440, 40);
			this.button2.Name = "button2";
			this.button2.TabIndex = 13;
			this.button2.Text = "删除旧卡";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(440, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 12;
			this.button1.Text = "创建新卡";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(64, 64);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 20);
			this.comboBox1.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 23);
			this.label6.TabIndex = 10;
			this.label6.Text = "余额：";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(280, 64);
			this.textBox5.Name = "textBox5";
			this.textBox5.PasswordChar = '*';
			this.textBox5.Size = new System.Drawing.Size(120, 21);
			this.textBox5.TabIndex = 9;
			this.textBox5.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(192, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "用户口令：";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(280, 40);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(120, 21);
			this.textBox4.TabIndex = 7;
			this.textBox4.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(192, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "客户ID：";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(64, 40);
			this.textBox3.Name = "textBox3";
			this.textBox3.PasswordChar = '*';
			this.textBox3.Size = new System.Drawing.Size(120, 21);
			this.textBox3.TabIndex = 5;
			this.textBox3.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "PUK码：";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(280, 16);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new System.Drawing.Size(120, 21);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(192, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "PIN码：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(64, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "卡号：";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.textBox10);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.textBox9);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.textBox8);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.textBox7);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.textBox6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Location = new System.Drawing.Point(8, 183);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(544, 96);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "设置收费标准";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(440, 40);
			this.button4.Name = "button4";
			this.button4.TabIndex = 11;
			this.button4.Text = "重新设置";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(440, 17);
			this.button3.Name = "button3";
			this.button3.TabIndex = 10;
			this.button3.Text = "确认";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(128, 64);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(88, 21);
			this.textBox10.TabIndex = 9;
			this.textBox10.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 64);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 23);
			this.label11.TabIndex = 8;
			this.label11.Text = "服务区间短信：";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(336, 40);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(88, 21);
			this.textBox9.TabIndex = 7;
			this.textBox9.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(224, 40);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 23);
			this.label10.TabIndex = 6;
			this.label10.Text = "服务区内短信：";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(128, 40);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(88, 21);
			this.textBox8.TabIndex = 5;
			this.textBox8.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 40);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(104, 23);
			this.label9.TabIndex = 4;
			this.label9.Text = "漫游通话：";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(336, 16);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(88, 21);
			this.textBox7.TabIndex = 3;
			this.textBox7.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(224, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 23);
			this.label8.TabIndex = 2;
			this.label8.Text = "服务区间通话：";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(128, 16);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(88, 21);
			this.textBox6.TabIndex = 1;
			this.textBox6.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 23);
			this.label7.TabIndex = 0;
			this.label7.Text = "服务区内通话：";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button6);
			this.groupBox3.Controls.Add(this.button5);
			this.groupBox3.Controls.Add(this.textBox13);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.textBox12);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.textBox11);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Location = new System.Drawing.Point(7, 110);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(544, 72);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "卡号操作";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(440, 40);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(98, 23);
			this.button6.TabIndex = 7;
			this.button6.Text = "查询详细话单";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(440, 16);
			this.button5.Name = "button5";
			this.button5.TabIndex = 6;
			this.button5.Text = "解除挂失";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(284, 13);
			this.textBox13.Name = "textBox13";
			this.textBox13.PasswordChar = '*';
			this.textBox13.Size = new System.Drawing.Size(116, 21);
			this.textBox13.TabIndex = 5;
			this.textBox13.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(194, 14);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 23);
			this.label14.TabIndex = 4;
			this.label14.Text = "用户口令：";
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(87, 45);
			this.textBox12.Name = "textBox12";
			this.textBox12.PasswordChar = '*';
			this.textBox12.Size = new System.Drawing.Size(105, 21);
			this.textBox12.TabIndex = 3;
			this.textBox12.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(10, 44);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 23);
			this.label13.TabIndex = 2;
			this.label13.Text = "PUK码：";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(88, 16);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(104, 21);
			this.textBox11.TabIndex = 1;
			this.textBox11.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 23);
			this.label12.TabIndex = 0;
			this.label12.Text = "卡号：";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.richTextBox1);
			this.groupBox4.Location = new System.Drawing.Point(559, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(181, 270);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "结果信息";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(3, 17);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(175, 250);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(744, 306);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "操作员管理界面";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
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
		//初始化
		private void init()
		{
			comboBox1.Items.Add("100");
			comboBox1.Items.Add("50");
			comboBox1.Items.Add("30");
			comboBox1.SelectedIndex=1;
		}
		//创建新卡
		private void button1_Click(object sender, System.EventArgs e)
		{
			string CardNo=textBox1.Text;
			string PIN=textBox2.Text;
			string PUK=textBox3.Text;
			int CustomerID=int.Parse(textBox4.Text);
			decimal Balance=decimal.Parse(comboBox1.SelectedItem.ToString());
			string UserPwd=textBox5.Text;
			DateTime Expiration;
			switch(comboBox1.SelectedItem.ToString())
			{
				case "100":
					Expiration=DateTime.Now.AddYears(1);
					break;
				case "50":
					Expiration=DateTime.Now.AddMonths(6);
					break;
				case "30":
					Expiration=DateTime.Now.AddMonths(3);
					break;
				default:
					Expiration=DateTime.Now;
					break;
			}
			try
			{
				service.CreateCard(CardNo,CustomerID,PUK,PIN,UserPwd,Balance,Expiration);
			}
			catch(Exception ex)
			{
				richTextBox1.AppendText("卡号创建失败！\r\n");
			}
			richTextBox1.AppendText("创建卡号成功！\r\n");
			richTextBox1.AppendText("卡号是："+CardNo+",余额是："+
				Balance+",时间期限是："+Expiration+"\r\n");
		}
		//删除旧卡
		private void button2_Click(object sender, System.EventArgs e)
		{
			string CardNo=textBox1.Text;
			service.DeleteCard(CardNo);
			richTextBox1.AppendText("卡号："+CardNo+"已被删除！\r\n");
		}
		//设置收费标准
		private void button3_Click(object sender, System.EventArgs e)
		{
			decimal CallInCell=decimal.Parse(textBox6.Text);
			decimal CallInterCell=decimal.Parse(textBox7.Text);
			decimal CallRoaming=decimal.Parse(textBox8.Text);
			decimal SMInCell=decimal.Parse(textBox9.Text);
			decimal SMInterCell=decimal.Parse(textBox10.Text);
			try
			{
				service.SetCharge(CallInCell,CallRoaming,CallInterCell,SMInCell,SMInterCell);
			}
			catch(Exception ex)
			{
				richTextBox1.AppendText(ex.Message+"\r\n");
			}
			richTextBox1.AppendText("设置收费标准成功！\r\n");
		}
		//重新输入收费标准
		private void button4_Click(object sender, System.EventArgs e)
		{
			textBox6.Text="";
			textBox7.Text="";
			textBox8.Text="";
			textBox9.Text="";
			textBox10.Text="";
		}
		//解除挂失
		private void button5_Click(object sender, System.EventArgs e)
		{
			bool result;
			string CardNo=textBox11.Text;
			string PUK=textBox12.Text;
			string UserPwd=textBox13.Text;
			result=service.DelistFromBlackList(CardNo,PUK,UserPwd);
			if(result)
			{
				richTextBox1.AppendText("解除挂失成功！\r\n");
			}
			else
			{
				richTextBox1.AppendText("解除挂失失败，可能的原因：\r\n"
					+"PUK码错，用户口令错，或卡号没有挂失！\r\n");
			}
		}
		//查询详细话单
		private void button6_Click(object sender, System.EventArgs e)
		{
			QueryDetailBillForm QueryForm=new QueryDetailBillForm();
			QueryForm.CardNo=textBox11.Text;
			QueryForm.ShowDialog();
		}
	}
}
