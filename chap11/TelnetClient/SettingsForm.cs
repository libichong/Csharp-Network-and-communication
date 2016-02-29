using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;


namespace TelnetClient
{
	/// <summary>
	/// Form2 的摘要说明。
	/// </summary>
	public class SettingsForm : System.Windows.Forms.Form
	{
		public System.Windows.Forms.ToolTip ToolTip1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnFont;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnFGColor;
		private System.Windows.Forms.Button btnBGColor;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components;

		public System.Windows.Forms.TextBox txtPort;
		public System.Windows.Forms.TextBox txtRemoteAddress;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label Label1_0;
		public System.Windows.Forms.CheckBox chkAutoConnect;
		public System.Windows.Forms.Label lblEffect;
		public System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Button btnOk;
		
		public SettingsForm()
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.txtRemoteAddress = new System.Windows.Forms.TextBox();
			this._Label1_1 = new System.Windows.Forms.Label();
			this.Label1_0 = new System.Windows.Forms.Label();
			this.chkAutoConnect = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnFont = new System.Windows.Forms.Button();
			this.lblEffect = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnFGColor = new System.Windows.Forms.Button();
			this.btnBGColor = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCancel.Location = new System.Drawing.Point(432, 64);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnCancel.Size = new System.Drawing.Size(88, 25);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "取消(&A)";
			// 
			// btnOk
			// 
			this.btnOk.BackColor = System.Drawing.SystemColors.Control;
			this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnOk.Location = new System.Drawing.Point(432, 24);
			this.btnOk.Name = "btnOk";
			this.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnOk.Size = new System.Drawing.Size(88, 25);
			this.btnOk.TabIndex = 9;
			this.btnOk.Text = "确定(&O)";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtPort);
			this.groupBox1.Controls.Add(this.txtRemoteAddress);
			this.groupBox1.Controls.Add(this._Label1_1);
			this.groupBox1.Controls.Add(this.Label1_0);
			this.groupBox1.Controls.Add(this.chkAutoConnect);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 136);
			this.groupBox1.TabIndex = 23;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "连接参数设置";
			// 
			// txtPort
			// 
			this.txtPort.AcceptsReturn = true;
			this.txtPort.AutoSize = false;
			this.txtPort.BackColor = System.Drawing.SystemColors.Window;
			this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPort.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPort.Location = new System.Drawing.Point(120, 64);
			this.txtPort.MaxLength = 0;
			this.txtPort.Name = "txtPort";
			this.txtPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPort.Size = new System.Drawing.Size(153, 25);
			this.txtPort.TabIndex = 15;
			this.txtPort.Text = "23";
			// 
			// txtRemoteAddress
			// 
			this.txtRemoteAddress.AcceptsReturn = true;
			this.txtRemoteAddress.AutoSize = false;
			this.txtRemoteAddress.BackColor = System.Drawing.SystemColors.Window;
			this.txtRemoteAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRemoteAddress.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRemoteAddress.Location = new System.Drawing.Point(120, 24);
			this.txtRemoteAddress.MaxLength = 0;
			this.txtRemoteAddress.Name = "txtRemoteAddress";
			this.txtRemoteAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemoteAddress.Size = new System.Drawing.Size(153, 25);
			this.txtRemoteAddress.TabIndex = 14;
			this.txtRemoteAddress.Text = "127.0.0.1";
			// 
			// _Label1_1
			// 
			this._Label1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Location = new System.Drawing.Point(8, 72);
			this._Label1_1.Name = "_Label1_1";
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.Size = new System.Drawing.Size(137, 17);
			this._Label1_1.TabIndex = 17;
			this._Label1_1.Text = "Telnet服务器端口：";
			// 
			// Label1_0
			// 
			this.Label1_0.BackColor = System.Drawing.SystemColors.Control;
			this.Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1_0.Location = new System.Drawing.Point(8, 32);
			this.Label1_0.Name = "Label1_0";
			this.Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1_0.Size = new System.Drawing.Size(137, 17);
			this.Label1_0.TabIndex = 16;
			this.Label1_0.Text = "Telnet服务器地址：";
			// 
			// chkAutoConnect
			// 
			this.chkAutoConnect.BackColor = System.Drawing.SystemColors.Control;
			this.chkAutoConnect.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkAutoConnect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAutoConnect.Location = new System.Drawing.Point(16, 104);
			this.chkAutoConnect.Name = "chkAutoConnect";
			this.chkAutoConnect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAutoConnect.Size = new System.Drawing.Size(264, 17);
			this.chkAutoConnect.TabIndex = 18;
			this.chkAutoConnect.Text = "自动连接";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnFont);
			this.groupBox2.Controls.Add(this.lblEffect);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.btnFGColor);
			this.groupBox2.Controls.Add(this.btnBGColor);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(16, 168);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(392, 168);
			this.groupBox2.TabIndex = 24;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "显示参数设置";
			// 
			// btnFont
			// 
			this.btnFont.Location = new System.Drawing.Point(232, 104);
			this.btnFont.Name = "btnFont";
			this.btnFont.Size = new System.Drawing.Size(136, 23);
			this.btnFont.TabIndex = 31;
			this.btnFont.Text = "设置显示字体(&F)";
			this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
			// 
			// lblEffect
			// 
			this.lblEffect.BackColor = System.Drawing.Color.Black;
			this.lblEffect.ForeColor = System.Drawing.Color.Blue;
			this.lblEffect.Location = new System.Drawing.Point(112, 24);
			this.lblEffect.Name = "lblEffect";
			this.lblEffect.Size = new System.Drawing.Size(104, 120);
			this.lblEffect.TabIndex = 30;
			this.lblEffect.Text = "效果";
			this.lblEffect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 29;
			this.label2.Text = "设置显示字体：";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 27;
			this.label3.Text = "设置前景颜色：";
			// 
			// btnFGColor
			// 
			this.btnFGColor.Location = new System.Drawing.Point(232, 64);
			this.btnFGColor.Name = "btnFGColor";
			this.btnFGColor.Size = new System.Drawing.Size(136, 23);
			this.btnFGColor.TabIndex = 26;
			this.btnFGColor.Text = "设置前景颜色(&C)";
			this.btnFGColor.Click += new System.EventHandler(this.btnFGColor_Click);
			// 
			// btnBGColor
			// 
			this.btnBGColor.Location = new System.Drawing.Point(232, 24);
			this.btnBGColor.Name = "btnBGColor";
			this.btnBGColor.Size = new System.Drawing.Size(136, 23);
			this.btnBGColor.TabIndex = 25;
			this.btnBGColor.Text = "设置背景颜色(&B)";
			this.btnBGColor.Click += new System.EventHandler(this.btnBGColor_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 23;
			this.label1.Text = "设置背景颜色：";
			// 
			// SettingsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(538, 351);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SettingsForm";
			this.Text = "设置Telnet客户端参数";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		//保存程序参数设置
		private void saveSettings()
		{
			string path = System.Windows.Forms.Application.ExecutablePath
				+ ".settings.set";
			
			if (File.Exists(path))  
			{
				File.Delete(path);
			}

			using (StreamWriter sw = File.AppendText(path)) 
			{
				sw.WriteLine(this.txtRemoteAddress.Text);
				sw.WriteLine(this.txtPort.Text);
				sw.WriteLine(this.chkAutoConnect.Checked);
				sw.WriteLine(this.lblEffect.BackColor.ToArgb());
				sw.WriteLine(this.lblEffect.ForeColor.ToArgb());
				sw.WriteLine(this.lblEffect.Font.FontFamily.Name);
				sw.WriteLine(this.lblEffect.Font.Size);
				sw.WriteLine(this.lblEffect.Font.Style);
				sw.WriteLine(this.lblEffect.Font.Unit);
				sw.WriteLine(this.lblEffect.Font.GdiCharSet);
				sw.WriteLine(this.lblEffect.Font.GdiVerticalFont);
			}

			
		}

		private void btnBGColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog1.Color = this.lblEffect.BackColor;
			if (this.colorDialog1.ShowDialog(this) == DialogResult.OK)
			{
				this.lblEffect.BackColor = this.colorDialog1.Color;
			}
		}

		private void btnFGColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog1.Color = this.lblEffect.ForeColor;
			if (this.colorDialog1.ShowDialog(this) == DialogResult.OK)
			{
				this.lblEffect.ForeColor = this.colorDialog1.Color;
			}
		}

		private void btnFont_Click(object sender, System.EventArgs e)
		{
			this.fontDialog1.Font = this.lblEffect.Font;
			if (this.fontDialog1.ShowDialog(this) == DialogResult.OK)
			{
				this.lblEffect.Font = this.fontDialog1.Font;
			}
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			saveSettings();
		}
	}
}
