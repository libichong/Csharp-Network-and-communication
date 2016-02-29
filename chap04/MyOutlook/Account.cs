using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data;

namespace MyOutlook
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FormAccount : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnProp;
		private System.Windows.Forms.Button btnDefault;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ListView lvAccounts;
		private System.Windows.Forms.ColumnHeader colAccount;
		private System.Windows.Forms.ColumnHeader colType;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public static string MAIL_TYPE_DEFAULT = "缺省邮箱";
		public static string MAIL_TYPE_GENERAL = "普通邮箱";
		private frmMain mf;

		public FormAccount(frmMain mainform)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			mf = mainform;

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
			this.lvAccounts = new System.Windows.Forms.ListView();
			this.colAccount = new System.Windows.Forms.ColumnHeader();
			this.colType = new System.Windows.Forms.ColumnHeader();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnProp = new System.Windows.Forms.Button();
			this.btnDefault = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lvAccounts
			// 
			this.lvAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.colAccount,
																						 this.colType});
			this.lvAccounts.FullRowSelect = true;
			this.lvAccounts.Location = new System.Drawing.Point(19, 26);
			this.lvAccounts.Name = "lvAccounts";
			this.lvAccounts.Size = new System.Drawing.Size(490, 422);
			this.lvAccounts.TabIndex = 0;
			this.lvAccounts.View = System.Windows.Forms.View.Details;
			// 
			// colAccount
			// 
			this.colAccount.Text = "邮箱帐号";
			this.colAccount.Width = 308;
			// 
			// colType
			// 
			this.colType.Text = "类型";
			this.colType.Width = 81;
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(538, 26);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(90, 25);
			this.btnNew.TabIndex = 1;
			this.btnNew.Text = "新建";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(538, 78);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(90, 24);
			this.btnDel.TabIndex = 2;
			this.btnDel.Text = "删除";
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnProp
			// 
			this.btnProp.Location = new System.Drawing.Point(538, 129);
			this.btnProp.Name = "btnProp";
			this.btnProp.Size = new System.Drawing.Size(90, 25);
			this.btnProp.TabIndex = 3;
			this.btnProp.Text = "属性";
			this.btnProp.Click += new System.EventHandler(this.btnProp_Click);
			// 
			// btnDefault
			// 
			this.btnDefault.Location = new System.Drawing.Point(538, 181);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(90, 25);
			this.btnDefault.TabIndex = 4;
			this.btnDefault.Text = "设为默认";
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(538, 422);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 25);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "关闭";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// FormAccount
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(652, 470);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnDefault);
			this.Controls.Add(this.btnProp);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.lvAccounts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "FormAccount";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "设置邮箱";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormAccount_Closing);
			this.Load += new System.EventHandler(this.FormAccount_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void FormAccount_Load(object sender, System.EventArgs e)
		{
			
			//从数据库中读取所有的邮箱帐户，然后填充在列表中
			string mySelectQuery = "SELECT * FROM MailAccounts ORDER BY MailAccountID";
			OleDbCommand oledbcmdMailAccount = new OleDbCommand(mySelectQuery, mf.oledbcntMyOutLookDB);
			oledbcmdMailAccount.CommandTimeout = 20;


			string account, type;
			lvAccounts.Items.Clear();
			
			//打开连接
			if ( mf.oledbcntMyOutLookDB.State==System.Data.ConnectionState.Closed)
			{
				 mf.oledbcntMyOutLookDB.Open();
			}
			System.Data.OleDb.OleDbDataReader oledrMailAccounts = oledbcmdMailAccount.ExecuteReader();
			if (oledrMailAccounts.HasRows)
			{
				while (oledrMailAccounts.Read())
				{
					account = oledrMailAccounts.GetString(1);
					ListViewItem lvi = lvAccounts.Items.Add(account);

					if (!oledrMailAccounts.IsDBNull(2)) 
					{
						type = oledrMailAccounts.GetString(2);
						lvi.SubItems.Add(type);
					} 
					else 
					{
						lvi.SubItems.Add(MAIL_TYPE_GENERAL);
					}
				}
			}


			//关闭连接
			oledrMailAccounts.Close();
		}

		//把当前选中的邮箱设置为缺省的邮箱
		private void btnDefault_Click(object sender, System.EventArgs e)
		{
			if (lvAccounts.SelectedIndices.Count>0)
			{
				int index = lvAccounts.SelectedIndices[0];
				string account = lvAccounts.Items[index].Text;
				
				this.lvAccounts.Items[index].SubItems[1].Text = MAIL_TYPE_DEFAULT;
				this.lvAccounts.Update();
				
				//更新数据库
				string updateSQL = "UPDATE MailAccounts set Type='"  + MAIL_TYPE_DEFAULT + 
																	  "' WHERE Account='" + account + "'";
				OleDbCommand oledbcmdMailAccount = new OleDbCommand(updateSQL, mf.oledbcntMyOutLookDB);
				oledbcmdMailAccount.ExecuteNonQuery();
			}
		}

		//设置当前邮箱的属性
		private void btnProp_Click(object sender, System.EventArgs e)
		{
			if (lvAccounts.SelectedIndices.Count>0)
			{
				int index = lvAccounts.SelectedIndices[0];
				string account = lvAccounts.Items[index].Text;
				AccountProp ap = new AccountProp(mf, lvAccounts);
				ap.Text = "设置属性 - " + account;
				ap.setProp(false);
				ap.ShowDialog();
			}
		}

		//删除当前邮箱
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if (lvAccounts.SelectedIndices.Count>0)
			{
				int index = lvAccounts.SelectedIndices[0];		
				string account = lvAccounts.Items[index].Text;

				//从数据库中删除邮箱设置
				string sqlStr = "DELETE FROM MailAccounts WHERE Account='" + account + "'";
				OleDbCommand oledbcmdMailAccount = new OleDbCommand(sqlStr, mf.oledbcntMyOutLookDB);
				oledbcmdMailAccount.ExecuteNonQuery();

				//删除列表中邮箱
				lvAccounts.Items.Remove(lvAccounts.Items[index]);
			}
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			AccountProp ap = new AccountProp(mf, lvAccounts);
			ap.Text = "添加新邮箱";
			ap.setProp(true);
			ap.ShowDialog();
		}

		private void FormAccount_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			mf.loadAccounts();
		}
	}
}
