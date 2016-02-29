using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CustomerInquiryForm
{
	/// <summary>
	///  Form1��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private TeleCommServices.CustomerInquiryServices service=null;
		private bool IsVerified;	
		private bool IsQueryBill;
		private bool IsRecharge;
		private bool IsUnlock;
		private bool IsUpdatePIN;

		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			service=new TeleCommServices.CustomerInquiryServices();
			IsVerified=false;
		}

		/// <summary>
		///������������ʹ�õ���Դ��
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
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new System.Drawing.Point(56, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(512, 80);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "����";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(392, 48);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "��֤����";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "PIN�룺";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(136, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new System.Drawing.Size(248, 21);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "���ţ�";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(136, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(248, 21);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton7);
			this.groupBox2.Controls.Add(this.radioButton6);
			this.groupBox2.Controls.Add(this.radioButton5);
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Location = new System.Drawing.Point(56, 88);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(512, 83);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "����ѡ��";
			// 
			// radioButton7
			// 
			this.radioButton7.Location = new System.Drawing.Point(95, 46);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.TabIndex = 6;
			this.radioButton7.Text = "��������";
			this.radioButton7.Click += new System.EventHandler(this.radioButton7_Click);
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(7, 52);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.TabIndex = 5;
			this.radioButton6.Text = "�޸�PIN��";
			this.radioButton6.Click += new System.EventHandler(this.radioButton6_Click);
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(353, 17);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.TabIndex = 4;
			this.radioButton5.Text = "����";
			this.radioButton5.Click += new System.EventHandler(this.radioButton5_Click);
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(274, 18);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "��ʧ";
			this.radioButton4.Click += new System.EventHandler(this.radioButton4_Click);
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(201, 17);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "��ֵ";
			this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(96, 16);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "��ѯÿ�»���";
			this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "��ѯ���";
			this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button3);
			this.groupBox3.Controls.Add(this.button2);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.textBox4);
			this.groupBox3.Controls.Add(this.textBox3);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.richTextBox1);
			this.groupBox3.Location = new System.Drawing.Point(59, 182);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(513, 288);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "���";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(264, 64);
			this.button3.Name = "button3";
			this.button3.TabIndex = 6;
			this.button3.Text = "��������";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(264, 24);
			this.button2.Name = "button2";
			this.button2.TabIndex = 5;
			this.button2.Text = "ȷ��";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 64);
			this.label4.Name = "label4";
			this.label4.TabIndex = 4;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(120, 64);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(136, 21);
			this.textBox4.TabIndex = 3;
			this.textBox4.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(120, 24);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(136, 21);
			this.textBox3.TabIndex = 2;
			this.textBox3.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 32);
			this.label3.Name = "label3";
			this.label3.TabIndex = 1;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(8, 112);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(368, 168);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(598, 481);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "�ͻ���ѯ";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		//��ѯ���
		private void radioButton1_Click(object sender, System.EventArgs e)
		{
			decimal Balance;
			if(IsVerified)
			{
				Balance=service.QueryBalance(textBox1.Text);
				richTextBox1.AppendText("����:"+textBox1.Text+"�������:"+Balance+"\r\n");
			}
			else
			{
				richTextBox1.AppendText("��������֤���ţ�\r\n");
			}
		}
		//��֤�����Ƿ���ȷ
		private void button1_Click(object sender, System.EventArgs e)
		{
			if(service.VerifyCard(textBox1.Text,textBox2.Text))
			{
				IsVerified=true;
				textBox1.ReadOnly=true;
				textBox2.ReadOnly=true;
				button1.Enabled=false;
				richTextBox1.AppendText("������֤ͨ��������ִ�����������ˣ�\r\n");
			}
			else
				richTextBox1.AppendText("������֤ʧ�ܣ�\r\n");
		}
		//��������
		private void radioButton7_Click(object sender, System.EventArgs e)
		{
			IsVerified=false;
			textBox1.ReadOnly=false;
			textBox2.ReadOnly=false;
			button1.Enabled=true;
			richTextBox1.AppendText("���������������½��в�����"+
				"�������������뿨�ź�PIN�벢��֤��\r\n");
		}
		//ÿ�»��Ѳ�ѯ
		private void radioButton2_Click(object sender, System.EventArgs e)
		{
			if(IsVerified)
			{
				IsQueryBill=true;
				IsRecharge=false;
				IsUnlock=false;
				IsUpdatePIN=false;
				label3.Text="�꣨4λ���֣�";
				label4.Text="�£�2λ���֣�";
			}
			else
				richTextBox1.AppendText("�����Ƚ�����֤��\r\n");
		}
		//��ʧ
		private void radioButton4_Click(object sender, System.EventArgs e)
		{
			if(IsVerified)
			{
				if(service.ReportOfLost(textBox1.Text))
				{
					richTextBox1.AppendText("��ʧ�ɹ�������������\r\n");
					IsVerified=false;
					textBox1.ReadOnly=false;
					textBox2.ReadOnly=false;
					button1.Enabled=true;
				}
				else
					richTextBox1.AppendText("��ʧʧ�ܣ�\r\n");
			}
			else
			{
				richTextBox1.AppendText("��������֤���ţ�\r\n");
			}

		}
		//��ֵ
		private void radioButton3_Click(object sender, System.EventArgs e)
		{
			if(IsVerified)
			{
				IsQueryBill=false;
				IsRecharge=true;
				IsUnlock=false;
				IsUpdatePIN=false;
				label3.Text="��ֵ���ţ�";
				label4.Text="��ֵ�����";
				textBox4.PasswordChar='*';
			}
			else
				richTextBox1.AppendText("�����Ƚ�����֤��\r\n");
		}
		//����
		private void radioButton5_Click(object sender, System.EventArgs e)
		{
				IsQueryBill=false;
				IsRecharge=false;
				IsUnlock=true;
				IsUpdatePIN=false;
				label3.Text="PUK�룺";
				textBox3.PasswordChar='*';
				label4.Enabled=false;
				textBox4.Enabled=false;
		}
		//�޸�PIN��
		private void radioButton6_Click(object sender, System.EventArgs e)
		{
			if(IsVerified)
			{
				IsQueryBill=false;
				IsRecharge=false;
				IsUnlock=false;
				IsUpdatePIN=true;
				label3.Text="����PIN�룺";
				label4.Text="ȷ��PIN�룺";
				textBox3.PasswordChar='*';
				textBox4.PasswordChar='*';
			}
			else
				richTextBox1.AppendText("�����Ƚ�����֤��\r\n");
		}
		//ȷ���������Ϣ����������Ӧ�Ĳ���
		private void button2_Click(object sender, System.EventArgs e)
		{
			//��ѯÿ�»���
			if(IsQueryBill)
			{
				decimal Amount,SMAmount,CallAmount;
				string CardNo=textBox1.Text;
				int year=int.Parse(textBox3.Text);
				int month=int.Parse(textBox4.Text);
				Amount=service.QueryBill(CardNo,year,month);
				SMAmount=service.QuerySMBill(CardNo,year,month);
				CallAmount=service.QueryCallBill(CardNo,year,month);
				richTextBox1.AppendText("����:"+CardNo+"��"+year+"��"+month+"�µ��ܻ����ǣ�"
					+Amount+"\r\n");
				richTextBox1.AppendText("ͨ�������ǣ�"+CallAmount+",���Ż����ǣ�"+SMAmount+"\r\n");
				IsQueryBill=false;
			}
			//��ֵ
			if(IsRecharge)
			{
				bool result;
				string CardNo=textBox1.Text;
				string RechargeCard=textBox3.Text;
				string Password=textBox4.Text;
				result=service.Recharge(CardNo,RechargeCard,Password);
				if(result)
				{
					richTextBox1.AppendText("��ֵ�ɹ���\r\n");
				}
				else
					richTextBox1.AppendText("��ֵʧ�ܣ�\r\n");
				IsRecharge=false;
				textBox4.Text="";
				textBox4.PasswordChar=char.Parse("\0");
			}
			//����
			if(IsUnlock)
			{
				bool result;
				string CardNo=textBox1.Text;
				string PUK=textBox3.Text;
				result=service.Unlock(CardNo,PUK);
				if(result)
				{
					richTextBox1.AppendText("�����ɹ���\r\n");
				}
				else
					richTextBox1.AppendText("����ʧ�ܻ��߿���û�б���ʱ����\r\n");
				IsUnlock=false;
				textBox3.Text="";
				textBox3.PasswordChar=char.Parse("\0");
				label4.Enabled=true;
				textBox4.Enabled=true;
			}
			//�޸�PIN��
			if(IsUpdatePIN)
			{
				bool result;
				string CardNo=textBox1.Text;
				string Pwd=textBox3.Text;
				string RePwd=textBox4.Text;
				if(Pwd==RePwd)
				{
					result=service.UpdatePIN(CardNo,Pwd);
					if(result)
					{
						richTextBox1.AppendText("�޸�PIN��ɹ���\r\n");
					}
					else
					{
						richTextBox1.AppendText("�޸�PIN�벻�ɹ���\r\n");
					}
					IsUpdatePIN=false;
				}
				else
				{
					richTextBox1.AppendText("��������PIN�벻һ�������������룡\r\n");
					this.InvokeOnClick(button3,new EventArgs());
				}
				if(!IsUpdatePIN)
				{
					textBox3.Text="";
					textBox4.Text="";
					textBox3.PasswordChar=char.Parse("\0");
					textBox4.PasswordChar=char.Parse("\0");
				}
			}
		}
		//��������
		private void button3_Click(object sender, System.EventArgs e)
		{
			textBox3.Text="";
			textBox4.Text="";
		}
	}
}
