using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyOutlook
{
	/// <summary>
	/// Progress 的摘要说明。
	/// </summary>
	public class frmProgress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ProgressBar pbProgress;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblProgress;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.RichTextBox rtbMsg;
		public bool stopFlag = false;

		public frmProgress()
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
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.btnStop = new System.Windows.Forms.Button();
			this.lblProgress = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.rtbMsg = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// pbProgress
			// 
			this.pbProgress.Location = new System.Drawing.Point(16, 40);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(544, 23);
			this.pbProgress.TabIndex = 0;
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(592, 40);
			this.btnStop.Name = "btnStop";
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "停止(&S)";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// lblProgress
			// 
			this.lblProgress.Location = new System.Drawing.Point(16, 8);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(544, 24);
			this.lblProgress.TabIndex = 3;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(592, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "关闭(&C)";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// rtbMsg
			// 
			this.rtbMsg.Location = new System.Drawing.Point(16, 80);
			this.rtbMsg.Name = "rtbMsg";
			this.rtbMsg.ReadOnly = true;
			this.rtbMsg.Size = new System.Drawing.Size(648, 288);
			this.rtbMsg.TabIndex = 5;
			this.rtbMsg.Text = "";
			// 
			// frmProgress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(682, 383);
			this.Controls.Add(this.rtbMsg);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.pbProgress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "frmProgress";
			this.Text = "接收/发送邮件";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnStop_Click(object sender, System.EventArgs e)
		{
			stopFlag = true;
		}

		//更新界面
		public void UpdateUI(string title, int pos, string msg)
		{
			this.lblProgress.Text = title;
			this.pbProgress.Value = pos;
			this.rtbMsg.AppendText(msg);
			Console.WriteLine(msg);
			this.Update();
		}
	}
}
