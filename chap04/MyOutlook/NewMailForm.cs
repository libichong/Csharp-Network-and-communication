using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyOutlook
{
	/// <summary>
	/// NewMailForm 的摘要说明。
	/// </summary>
	public class NewMailForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem miMail;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbtnSave;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbbtnSend;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.RichTextBox rtbMailContent;
		private System.Windows.Forms.ComboBox cbbSend;
		private System.Windows.Forms.TextBox tbReceive;
		private System.Windows.Forms.TextBox tbCC;
		private System.Windows.Forms.TextBox tbTitle;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miSend;
		private System.ComponentModel.IContainer components;

		private Mail mail;
		private frmMain mf;

		public NewMailForm(Mail mail, frmMain mf)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.mail = mail;
			this.mf = mf;

			this.cbbSend.Items.Clear();
			if ((mf.accounts != null) && (mf.accounts.Count>0))
			{
				System.Collections.IEnumerator myEnumerator = mf.accounts.GetEnumerator();
				while (myEnumerator.MoveNext())
				{
					MailAccount ma = (MailAccount)myEnumerator.Current;
					this.cbbSend.Items.Add(ma.Account);
				}
			}
			

			if (mail != null)
			{
				this.cbbSend.SelectedIndex = this.cbbSend.Items.IndexOf(mail.Sender);
				this.tbCC.Text = mail.Cc;
				this.tbReceive.Text = mail.Recipient;
				this.tbTitle.Text = mail.Subject;
				this.rtbMailContent.Text = mail.MailContent;
			}

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
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NewMailForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.miMail = new System.Windows.Forms.MenuItem();
			this.miSave = new System.Windows.Forms.MenuItem();
			this.miSend = new System.Windows.Forms.MenuItem();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbtnSave = new System.Windows.Forms.ToolBarButton();
			this.tbbtnSend = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbTitle = new System.Windows.Forms.TextBox();
			this.tbCC = new System.Windows.Forms.TextBox();
			this.tbReceive = new System.Windows.Forms.TextBox();
			this.cbbSend = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.rtbMailContent = new System.Windows.Forms.RichTextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miMail});
			// 
			// miMail
			// 
			this.miMail.Index = 0;
			this.miMail.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miSave,
																				   this.miSend});
			this.miMail.Text = "邮件(&M)";
			// 
			// miSave
			// 
			this.miSave.Index = 0;
			this.miSave.Text = "保存(&S)";
			this.miSave.Click += new System.EventHandler(this.miSave_Click);
			// 
			// miSend
			// 
			this.miSend.Index = 1;
			this.miSend.Text = "发送(&E)";
			this.miSend.Click += new System.EventHandler(this.miSend_Click);
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbtnSave,
																						this.tbbtnSend});
			this.toolBar1.ButtonSize = new System.Drawing.Size(64, 40);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(1072, 46);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbtnSave
			// 
			this.tbbtnSave.ImageIndex = 0;
			this.tbbtnSave.Text = "保存";
			// 
			// tbbtnSend
			// 
			this.tbbtnSend.ImageIndex = 2;
			this.tbbtnSend.Text = "发送";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tbTitle);
			this.panel1.Controls.Add(this.tbCC);
			this.panel1.Controls.Add(this.tbReceive);
			this.panel1.Controls.Add(this.cbbSend);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1072, 130);
			this.panel1.TabIndex = 2;
			// 
			// tbTitle
			// 
			this.tbTitle.Location = new System.Drawing.Point(96, 104);
			this.tbTitle.Name = "tbTitle";
			this.tbTitle.Size = new System.Drawing.Size(960, 20);
			this.tbTitle.TabIndex = 5;
			this.tbTitle.Text = "";
			// 
			// tbCC
			// 
			this.tbCC.Location = new System.Drawing.Point(96, 72);
			this.tbCC.Name = "tbCC";
			this.tbCC.Size = new System.Drawing.Size(960, 20);
			this.tbCC.TabIndex = 4;
			this.tbCC.Text = "";
			// 
			// tbReceive
			// 
			this.tbReceive.Location = new System.Drawing.Point(96, 40);
			this.tbReceive.Name = "tbReceive";
			this.tbReceive.Size = new System.Drawing.Size(960, 20);
			this.tbReceive.TabIndex = 3;
			this.tbReceive.Text = "";
			// 
			// cbbSend
			// 
			this.cbbSend.Location = new System.Drawing.Point(96, 8);
			this.cbbSend.Name = "cbbSend";
			this.cbbSend.Size = new System.Drawing.Size(960, 21);
			this.cbbSend.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(96, 130);
			this.panel2.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "主题：";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "抄送：";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "接收邮箱：";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "发送邮箱：";
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 176);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1072, 64);
			this.panel3.TabIndex = 3;
			this.panel3.Visible = false;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.rtbMailContent);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 240);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(1072, 393);
			this.panel4.TabIndex = 4;
			// 
			// rtbMailContent
			// 
			this.rtbMailContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbMailContent.Location = new System.Drawing.Point(0, 0);
			this.rtbMailContent.Name = "rtbMailContent";
			this.rtbMailContent.Size = new System.Drawing.Size(1072, 393);
			this.rtbMailContent.TabIndex = 0;
			this.rtbMailContent.Text = "";
			// 
			// NewMailForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1072, 633);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "NewMailForm";
			this.Text = "新建邮件";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void miSave_Click(object sender, System.EventArgs e)
		{
			NewMail(false);
		}

		private void miSend_Click(object sender, System.EventArgs e)
		{
			NewMail(true);	
			this.Close();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tbbtnSave) 
			{
				NewMail(false);
			}
			else if (e.Button == this.tbbtnSend)
			{
				NewMail(true);
				this.Close();
			}		
		}

		private void NewMail(bool isSend)
		{
			Mail m;
			if (mail == null)
			{
				m = new Mail();
			}
			else 
			{
				m = this.mail;
			}
			m.Sender = this.cbbSend.Text;
			m.Recipient = this.tbReceive.Text;
			m.Subject = this.tbTitle.Text;
			m.Cc = this.tbCC.Text;
			m.MailContent = this.rtbMailContent.Text;
			
			if (isSend)
			{
				m.MailStorePosition = Mail.OUT_BOX;
			}
			else 
			{
				m.MailStorePosition = Mail.DRAFT_BOX;
			}

			if (this.mail == null)
			{
				this.mail = m;
			}
			mf.AddNewMail(mail);
		}
	}
}
