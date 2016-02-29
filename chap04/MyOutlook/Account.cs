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
	/// Form1 ��ժҪ˵����
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
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		public static string MAIL_TYPE_DEFAULT = "ȱʡ����";
		public static string MAIL_TYPE_GENERAL = "��ͨ����";
		private frmMain mf;

		public FormAccount(frmMain mainform)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			mf = mainform;

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			this.colAccount.Text = "�����ʺ�";
			this.colAccount.Width = 308;
			// 
			// colType
			// 
			this.colType.Text = "����";
			this.colType.Width = 81;
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(538, 26);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(90, 25);
			this.btnNew.TabIndex = 1;
			this.btnNew.Text = "�½�";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(538, 78);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(90, 24);
			this.btnDel.TabIndex = 2;
			this.btnDel.Text = "ɾ��";
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnProp
			// 
			this.btnProp.Location = new System.Drawing.Point(538, 129);
			this.btnProp.Name = "btnProp";
			this.btnProp.Size = new System.Drawing.Size(90, 25);
			this.btnProp.TabIndex = 3;
			this.btnProp.Text = "����";
			this.btnProp.Click += new System.EventHandler(this.btnProp_Click);
			// 
			// btnDefault
			// 
			this.btnDefault.Location = new System.Drawing.Point(538, 181);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(90, 25);
			this.btnDefault.TabIndex = 4;
			this.btnDefault.Text = "��ΪĬ��";
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(538, 422);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 25);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "�ر�";
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
			this.Text = "��������";
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
			
			//�����ݿ��ж�ȡ���е������ʻ���Ȼ��������б���
			string mySelectQuery = "SELECT * FROM MailAccounts ORDER BY MailAccountID";
			OleDbCommand oledbcmdMailAccount = new OleDbCommand(mySelectQuery, mf.oledbcntMyOutLookDB);
			oledbcmdMailAccount.CommandTimeout = 20;


			string account, type;
			lvAccounts.Items.Clear();
			
			//������
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


			//�ر�����
			oledrMailAccounts.Close();
		}

		//�ѵ�ǰѡ�е���������Ϊȱʡ������
		private void btnDefault_Click(object sender, System.EventArgs e)
		{
			if (lvAccounts.SelectedIndices.Count>0)
			{
				int index = lvAccounts.SelectedIndices[0];
				string account = lvAccounts.Items[index].Text;
				
				this.lvAccounts.Items[index].SubItems[1].Text = MAIL_TYPE_DEFAULT;
				this.lvAccounts.Update();
				
				//�������ݿ�
				string updateSQL = "UPDATE MailAccounts set Type='"  + MAIL_TYPE_DEFAULT + 
																	  "' WHERE Account='" + account + "'";
				OleDbCommand oledbcmdMailAccount = new OleDbCommand(updateSQL, mf.oledbcntMyOutLookDB);
				oledbcmdMailAccount.ExecuteNonQuery();
			}
		}

		//���õ�ǰ���������
		private void btnProp_Click(object sender, System.EventArgs e)
		{
			if (lvAccounts.SelectedIndices.Count>0)
			{
				int index = lvAccounts.SelectedIndices[0];
				string account = lvAccounts.Items[index].Text;
				AccountProp ap = new AccountProp(mf, lvAccounts);
				ap.Text = "�������� - " + account;
				ap.setProp(false);
				ap.ShowDialog();
			}
		}

		//ɾ����ǰ����
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if (lvAccounts.SelectedIndices.Count>0)
			{
				int index = lvAccounts.SelectedIndices[0];		
				string account = lvAccounts.Items[index].Text;

				//�����ݿ���ɾ����������
				string sqlStr = "DELETE FROM MailAccounts WHERE Account='" + account + "'";
				OleDbCommand oledbcmdMailAccount = new OleDbCommand(sqlStr, mf.oledbcntMyOutLookDB);
				oledbcmdMailAccount.ExecuteNonQuery();

				//ɾ���б�������
				lvAccounts.Items.Remove(lvAccounts.Items[index]);
			}
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			AccountProp ap = new AccountProp(mf, lvAccounts);
			ap.Text = "���������";
			ap.setProp(true);
			ap.ShowDialog();
		}

		private void FormAccount_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			mf.loadAccounts();
		}
	}
}
