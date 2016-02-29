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
	/// AccountProp 的摘要说明。
	/// </summary>
	public class AccountProp : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageIn;
		private System.Windows.Forms.TabPage tabPageOut;
		private System.Windows.Forms.TabPage tabPageMail;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbbMailType;
		private System.Windows.Forms.TextBox tbMailBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbInServer;
		private System.Windows.Forms.TextBox tbInPort;
		private System.Windows.Forms.CheckBox cbKeepMails;
		private System.Windows.Forms.TextBox tbInPwd;
		private System.Windows.Forms.TextBox tbInID;
		private System.Windows.Forms.TextBox tbOutPwd;
		private System.Windows.Forms.TextBox tbOutID;
		private System.Windows.Forms.TextBox tbOutPort;
		private System.Windows.Forms.CheckBox cbNeedVerify;
		private System.Windows.Forms.TextBox tbOutServer;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private frmMain mf;
		private System.Windows.Forms.RadioButton rbtnOwn;
		private System.Windows.Forms.RadioButton rbtnSame;
		private System.Windows.Forms.GroupBox gbOutSettings;
		private ListView lv;

		//标记是否添加新记录
		private bool newFlag = false;
		
		private DataSet ds;
		private System.Data.OleDb.OleDbDataAdapter da;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private DataTable dt;

		public AccountProp(frmMain mf, ListView lv)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.mf = mf;
			this.lv = lv;

			
			oleDbConnection1.Open();
			ds = new DataSet();
			da.Fill(ds, "MailAccounts");
			dt = ds.Tables[0];
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageMail = new System.Windows.Forms.TabPage();
			this.cbbMailType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbMailBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPageIn = new System.Windows.Forms.TabPage();
			this.tbInPort = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbKeepMails = new System.Windows.Forms.CheckBox();
			this.tbInPwd = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbInID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbInServer = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPageOut = new System.Windows.Forms.TabPage();
			this.gbOutSettings = new System.Windows.Forms.GroupBox();
			this.rbtnOwn = new System.Windows.Forms.RadioButton();
			this.rbtnSame = new System.Windows.Forms.RadioButton();
			this.tbOutPwd = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbOutID = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbOutPort = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cbNeedVerify = new System.Windows.Forms.CheckBox();
			this.tbOutServer = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.da = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.tabControl1.SuspendLayout();
			this.tabPageMail.SuspendLayout();
			this.tabPageIn.SuspendLayout();
			this.tabPageOut.SuspendLayout();
			this.gbOutSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageMail);
			this.tabControl1.Controls.Add(this.tabPageIn);
			this.tabControl1.Controls.Add(this.tabPageOut);
			this.tabControl1.Location = new System.Drawing.Point(10, 17);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(585, 362);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageMail
			// 
			this.tabPageMail.Controls.Add(this.cbbMailType);
			this.tabPageMail.Controls.Add(this.label2);
			this.tabPageMail.Controls.Add(this.tbMailBox);
			this.tabPageMail.Controls.Add(this.label1);
			this.tabPageMail.Location = new System.Drawing.Point(4, 21);
			this.tabPageMail.Name = "tabPageMail";
			this.tabPageMail.Size = new System.Drawing.Size(577, 337);
			this.tabPageMail.TabIndex = 2;
			this.tabPageMail.Text = "邮箱设置";
			// 
			// cbbMailType
			// 
			this.cbbMailType.Enabled = false;
			this.cbbMailType.Items.AddRange(new object[] {
															 "POP3"});
			this.cbbMailType.Location = new System.Drawing.Point(106, 52);
			this.cbbMailType.Name = "cbbMailType";
			this.cbbMailType.Size = new System.Drawing.Size(145, 20);
			this.cbbMailType.TabIndex = 3;
			this.cbbMailType.Text = "POP3";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(19, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "邮箱类型：";
			// 
			// tbMailBox
			// 
			this.tbMailBox.Location = new System.Drawing.Point(106, 17);
			this.tbMailBox.Name = "tbMailBox";
			this.tbMailBox.Size = new System.Drawing.Size(432, 21);
			this.tbMailBox.TabIndex = 1;
			this.tbMailBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "电子邮箱：";
			// 
			// tabPageIn
			// 
			this.tabPageIn.Controls.Add(this.tbInPort);
			this.tabPageIn.Controls.Add(this.label6);
			this.tabPageIn.Controls.Add(this.cbKeepMails);
			this.tabPageIn.Controls.Add(this.tbInPwd);
			this.tabPageIn.Controls.Add(this.label5);
			this.tabPageIn.Controls.Add(this.tbInID);
			this.tabPageIn.Controls.Add(this.label4);
			this.tabPageIn.Controls.Add(this.tbInServer);
			this.tabPageIn.Controls.Add(this.label3);
			this.tabPageIn.Location = new System.Drawing.Point(4, 21);
			this.tabPageIn.Name = "tabPageIn";
			this.tabPageIn.Size = new System.Drawing.Size(577, 337);
			this.tabPageIn.TabIndex = 0;
			this.tabPageIn.Text = "收件服务器设置";
			// 
			// tbInPort
			// 
			this.tbInPort.Location = new System.Drawing.Point(182, 146);
			this.tbInPort.Name = "tbInPort";
			this.tbInPort.Size = new System.Drawing.Size(375, 21);
			this.tbInPort.TabIndex = 8;
			this.tbInPort.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(29, 148);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(163, 24);
			this.label6.TabIndex = 7;
			this.label6.Text = "收件服务器登录端口：";
			// 
			// cbKeepMails
			// 
			this.cbKeepMails.Location = new System.Drawing.Point(278, 198);
			this.cbKeepMails.Name = "cbKeepMails";
			this.cbKeepMails.Size = new System.Drawing.Size(269, 26);
			this.cbKeepMails.TabIndex = 6;
			this.cbKeepMails.Text = "接收邮件后保留服务器中的邮件";
			// 
			// tbInPwd
			// 
			this.tbInPwd.Location = new System.Drawing.Point(182, 103);
			this.tbInPwd.Name = "tbInPwd";
			this.tbInPwd.PasswordChar = '*';
			this.tbInPwd.Size = new System.Drawing.Size(375, 21);
			this.tbInPwd.TabIndex = 5;
			this.tbInPwd.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(29, 106);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(163, 24);
			this.label5.TabIndex = 4;
			this.label5.Text = "收件服务器登录密码：";
			// 
			// tbInID
			// 
			this.tbInID.Location = new System.Drawing.Point(182, 60);
			this.tbInID.Name = "tbInID";
			this.tbInID.Size = new System.Drawing.Size(375, 21);
			this.tbInID.TabIndex = 3;
			this.tbInID.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(29, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(163, 24);
			this.label4.TabIndex = 2;
			this.label4.Text = "收件服务器登录账户：";
			// 
			// tbInServer
			// 
			this.tbInServer.Location = new System.Drawing.Point(134, 17);
			this.tbInServer.Name = "tbInServer";
			this.tbInServer.Size = new System.Drawing.Size(423, 21);
			this.tbInServer.TabIndex = 1;
			this.tbInServer.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(29, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 25);
			this.label3.TabIndex = 0;
			this.label3.Text = "收件服务器：";
			// 
			// tabPageOut
			// 
			this.tabPageOut.Controls.Add(this.gbOutSettings);
			this.tabPageOut.Controls.Add(this.tbOutPort);
			this.tabPageOut.Controls.Add(this.label7);
			this.tabPageOut.Controls.Add(this.cbNeedVerify);
			this.tabPageOut.Controls.Add(this.tbOutServer);
			this.tabPageOut.Controls.Add(this.label10);
			this.tabPageOut.Location = new System.Drawing.Point(4, 21);
			this.tabPageOut.Name = "tabPageOut";
			this.tabPageOut.Size = new System.Drawing.Size(577, 337);
			this.tabPageOut.TabIndex = 1;
			this.tabPageOut.Text = "发件服务器设置";
			// 
			// gbOutSettings
			// 
			this.gbOutSettings.Controls.Add(this.rbtnOwn);
			this.gbOutSettings.Controls.Add(this.rbtnSame);
			this.gbOutSettings.Controls.Add(this.tbOutPwd);
			this.gbOutSettings.Controls.Add(this.label8);
			this.gbOutSettings.Controls.Add(this.tbOutID);
			this.gbOutSettings.Controls.Add(this.label9);
			this.gbOutSettings.Location = new System.Drawing.Point(19, 95);
			this.gbOutSettings.Name = "gbOutSettings";
			this.gbOutSettings.Size = new System.Drawing.Size(528, 181);
			this.gbOutSettings.TabIndex = 18;
			this.gbOutSettings.TabStop = false;
			this.gbOutSettings.Text = "发件服务器登录设置";
			// 
			// rbtnOwn
			// 
			this.rbtnOwn.Checked = true;
			this.rbtnOwn.Location = new System.Drawing.Point(29, 69);
			this.rbtnOwn.Name = "rbtnOwn";
			this.rbtnOwn.Size = new System.Drawing.Size(403, 26);
			this.rbtnOwn.TabIndex = 20;
			this.rbtnOwn.TabStop = true;
			this.rbtnOwn.Text = "使用自己的设置";
			this.rbtnOwn.CheckedChanged += new System.EventHandler(this.rbtnOwn_CheckedChanged);
			// 
			// rbtnSame
			// 
			this.rbtnSame.Location = new System.Drawing.Point(29, 34);
			this.rbtnSame.Name = "rbtnSame";
			this.rbtnSame.Size = new System.Drawing.Size(413, 26);
			this.rbtnSame.TabIndex = 19;
			this.rbtnSame.Text = "使用和收件服务器相同的设置";
			this.rbtnSame.CheckedChanged += new System.EventHandler(this.rbtnSame_CheckedChanged);
			// 
			// tbOutPwd
			// 
			this.tbOutPwd.Location = new System.Drawing.Point(182, 146);
			this.tbOutPwd.Name = "tbOutPwd";
			this.tbOutPwd.Size = new System.Drawing.Size(327, 21);
			this.tbOutPwd.TabIndex = 18;
			this.tbOutPwd.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(19, 146);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(163, 25);
			this.label8.TabIndex = 17;
			this.label8.Text = "发件服务器登录密码：";
			// 
			// tbOutID
			// 
			this.tbOutID.Location = new System.Drawing.Point(182, 112);
			this.tbOutID.Name = "tbOutID";
			this.tbOutID.Size = new System.Drawing.Size(327, 21);
			this.tbOutID.TabIndex = 16;
			this.tbOutID.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(19, 112);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(163, 25);
			this.label9.TabIndex = 15;
			this.label9.Text = "发件服务器登录账户：";
			// 
			// tbOutPort
			// 
			this.tbOutPort.Location = new System.Drawing.Point(173, 293);
			this.tbOutPort.Name = "tbOutPort";
			this.tbOutPort.Size = new System.Drawing.Size(374, 21);
			this.tbOutPort.TabIndex = 17;
			this.tbOutPort.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(19, 293);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(163, 25);
			this.label7.TabIndex = 16;
			this.label7.Text = "发件服务器登录端口：";
			// 
			// cbNeedVerify
			// 
			this.cbNeedVerify.Checked = true;
			this.cbNeedVerify.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbNeedVerify.Location = new System.Drawing.Point(19, 60);
			this.cbNeedVerify.Name = "cbNeedVerify";
			this.cbNeedVerify.Size = new System.Drawing.Size(269, 26);
			this.cbNeedVerify.TabIndex = 15;
			this.cbNeedVerify.Text = "发件服务器需要验证";
			this.cbNeedVerify.CheckedChanged += new System.EventHandler(this.cbNeedVerify_CheckedChanged);
			// 
			// tbOutServer
			// 
			this.tbOutServer.Location = new System.Drawing.Point(125, 17);
			this.tbOutServer.Name = "tbOutServer";
			this.tbOutServer.Size = new System.Drawing.Size(422, 21);
			this.tbOutServer.TabIndex = 10;
			this.tbOutServer.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(19, 17);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 25);
			this.label10.TabIndex = 9;
			this.label10.Text = "收件服务器：";
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(499, 388);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(90, 24);
			this.btnApply.TabIndex = 1;
			this.btnApply.Text = "应用(&A)";
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(384, 388);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(90, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "取消(&C)";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(250, 388);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(90, 24);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "确定(&O)";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// da
			// 
			this.da.DeleteCommand = this.oleDbDeleteCommand1;
			this.da.InsertCommand = this.oleDbInsertCommand1;
			this.da.SelectCommand = this.oleDbSelectCommand1;
			this.da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																						 new System.Data.Common.DataTableMapping("Table", "MailAccounts", new System.Data.Common.DataColumnMapping[] {
																																																		 new System.Data.Common.DataColumnMapping("Account", "Account"),
																																																		 new System.Data.Common.DataColumnMapping("IncomingMailServer", "IncomingMailServer"),
																																																		 new System.Data.Common.DataColumnMapping("InPassword", "InPassword"),
																																																		 new System.Data.Common.DataColumnMapping("InPort", "InPort"),
																																																		 new System.Data.Common.DataColumnMapping("InUserID", "InUserID"),
																																																		 new System.Data.Common.DataColumnMapping("IsLeaveMessage", "IsLeaveMessage"),
																																																		 new System.Data.Common.DataColumnMapping("IsOutgoingAuthorized", "IsOutgoingAuthorized"),
																																																		 new System.Data.Common.DataColumnMapping("IsTheSameWithIncoming", "IsTheSameWithIncoming"),
																																																		 new System.Data.Common.DataColumnMapping("MailAccountID", "MailAccountID"),
																																																		 new System.Data.Common.DataColumnMapping("OutgoingMailServer", "OutgoingMailServer"),
																																																		 new System.Data.Common.DataColumnMapping("OutPassword", "OutPassword"),
																																																		 new System.Data.Common.DataColumnMapping("OutPort", "OutPort"),
																																																		 new System.Data.Common.DataColumnMapping("OutUserID", "OutUserID"),
																																																		 new System.Data.Common.DataColumnMapping("ServerType", "ServerType"),
																																																		 new System.Data.Common.DataColumnMapping("Type", "Type")})});
			this.da.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM MailAccounts WHERE (MailAccountID = ?) AND (Account = ? OR ? IS NULL AND Account IS NULL) AND (InPassword = ? OR ? IS NULL AND InPassword IS NULL) AND (InPort = ? OR ? IS NULL AND InPort IS NULL) AND (InUserID = ? OR ? IS NULL AND InUserID IS NULL) AND (IncomingMailServer = ? OR ? IS NULL AND IncomingMailServer IS NULL) AND (IsLeaveMessage = ?) AND (IsOutgoingAuthorized = ?) AND (IsTheSameWithIncoming = ?) AND (OutPassword = ? OR ? IS NULL AND OutPassword IS NULL) AND (OutPort = ? OR ? IS NULL AND OutPort IS NULL) AND (OutUserID = ? OR ? IS NULL AND OutUserID IS NULL) AND (OutgoingMailServer = ? OR ? IS NULL AND OutgoingMailServer IS NULL) AND (ServerType = ? OR ? IS NULL AND ServerType IS NULL) AND (Type = ? OR ? IS NULL AND Type IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MailAccountID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MailAccountID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Account", System.Data.OleDb.OleDbType.VarWChar, 125, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Account", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Account1", System.Data.OleDb.OleDbType.VarWChar, 125, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Account", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InPassword", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InPassword1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InPort", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InPort", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InPort1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InPort", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InUserID", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InUserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InUserID1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InUserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncomingMailServer", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncomingMailServer", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncomingMailServer1", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncomingMailServer", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsLeaveMessage", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsLeaveMessage", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsOutgoingAuthorized", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsOutgoingAuthorized", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsTheSameWithIncoming", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsTheSameWithIncoming", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutPassword", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutPassword1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutPort", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutPort", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutPort1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutPort", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutUserID", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutUserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutUserID1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutUserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutgoingMailServer", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutgoingMailServer", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutgoingMailServer1", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutgoingMailServer", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ServerType", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ServerType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ServerType1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ServerType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Type", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Type", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Type1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Type", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""MyOutlookDB.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO MailAccounts(Account, IncomingMailServer, InPassword, InPort, InUserID, IsLeaveMessage, IsOutgoingAuthorized, IsTheSameWithIncoming, OutgoingMailServer, OutPassword, OutPort, OutUserID, ServerType, Type) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Account", System.Data.OleDb.OleDbType.VarWChar, 125, "Account"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncomingMailServer", System.Data.OleDb.OleDbType.VarWChar, 25, "IncomingMailServer"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("InPassword", System.Data.OleDb.OleDbType.VarWChar, 20, "InPassword"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("InPort", System.Data.OleDb.OleDbType.VarWChar, 6, "InPort"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("InUserID", System.Data.OleDb.OleDbType.VarWChar, 20, "InUserID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsLeaveMessage", System.Data.OleDb.OleDbType.Boolean, 2, "IsLeaveMessage"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsOutgoingAuthorized", System.Data.OleDb.OleDbType.Boolean, 2, "IsOutgoingAuthorized"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsTheSameWithIncoming", System.Data.OleDb.OleDbType.Boolean, 2, "IsTheSameWithIncoming"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutgoingMailServer", System.Data.OleDb.OleDbType.VarWChar, 25, "OutgoingMailServer"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutPassword", System.Data.OleDb.OleDbType.VarWChar, 20, "OutPassword"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutPort", System.Data.OleDb.OleDbType.VarWChar, 6, "OutPort"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutUserID", System.Data.OleDb.OleDbType.VarWChar, 20, "OutUserID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ServerType", System.Data.OleDb.OleDbType.VarWChar, 4, "ServerType"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Type", System.Data.OleDb.OleDbType.VarWChar, 4, "Type"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT Account, IncomingMailServer, InPassword, InPort, InUserID, IsLeaveMessage," +
				" IsOutgoingAuthorized, IsTheSameWithIncoming, MailAccountID, OutgoingMailServer," +
				" OutPassword, OutPort, OutUserID, ServerType, Type FROM MailAccounts";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE MailAccounts SET Account = ?, IncomingMailServer = ?, InPassword = ?, InPort = ?, InUserID = ?, IsLeaveMessage = ?, IsOutgoingAuthorized = ?, IsTheSameWithIncoming = ?, OutgoingMailServer = ?, OutPassword = ?, OutPort = ?, OutUserID = ?, ServerType = ?, Type = ? WHERE (MailAccountID = ?) AND (Account = ? OR ? IS NULL AND Account IS NULL) AND (InPassword = ? OR ? IS NULL AND InPassword IS NULL) AND (InPort = ? OR ? IS NULL AND InPort IS NULL) AND (InUserID = ? OR ? IS NULL AND InUserID IS NULL) AND (IncomingMailServer = ? OR ? IS NULL AND IncomingMailServer IS NULL) AND (IsLeaveMessage = ?) AND (IsOutgoingAuthorized = ?) AND (IsTheSameWithIncoming = ?) AND (OutPassword = ? OR ? IS NULL AND OutPassword IS NULL) AND (OutPort = ? OR ? IS NULL AND OutPort IS NULL) AND (OutUserID = ? OR ? IS NULL AND OutUserID IS NULL) AND (OutgoingMailServer = ? OR ? IS NULL AND OutgoingMailServer IS NULL) AND (ServerType = ? OR ? IS NULL AND ServerType IS NULL) AND (Type = ? OR ? IS NULL AND Type IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Account", System.Data.OleDb.OleDbType.VarWChar, 125, "Account"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IncomingMailServer", System.Data.OleDb.OleDbType.VarWChar, 25, "IncomingMailServer"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("InPassword", System.Data.OleDb.OleDbType.VarWChar, 20, "InPassword"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("InPort", System.Data.OleDb.OleDbType.VarWChar, 6, "InPort"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("InUserID", System.Data.OleDb.OleDbType.VarWChar, 20, "InUserID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsLeaveMessage", System.Data.OleDb.OleDbType.Boolean, 2, "IsLeaveMessage"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsOutgoingAuthorized", System.Data.OleDb.OleDbType.Boolean, 2, "IsOutgoingAuthorized"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsTheSameWithIncoming", System.Data.OleDb.OleDbType.Boolean, 2, "IsTheSameWithIncoming"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutgoingMailServer", System.Data.OleDb.OleDbType.VarWChar, 25, "OutgoingMailServer"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutPassword", System.Data.OleDb.OleDbType.VarWChar, 20, "OutPassword"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutPort", System.Data.OleDb.OleDbType.VarWChar, 6, "OutPort"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OutUserID", System.Data.OleDb.OleDbType.VarWChar, 20, "OutUserID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ServerType", System.Data.OleDb.OleDbType.VarWChar, 4, "ServerType"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Type", System.Data.OleDb.OleDbType.VarWChar, 4, "Type"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MailAccountID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MailAccountID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Account", System.Data.OleDb.OleDbType.VarWChar, 125, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Account", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Account1", System.Data.OleDb.OleDbType.VarWChar, 125, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Account", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InPassword", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InPassword1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InPort", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InPort", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InPort1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InPort", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InUserID", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InUserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InUserID1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InUserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncomingMailServer", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncomingMailServer", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IncomingMailServer1", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IncomingMailServer", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsLeaveMessage", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsLeaveMessage", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsOutgoingAuthorized", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsOutgoingAuthorized", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IsTheSameWithIncoming", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsTheSameWithIncoming", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutPassword", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutPassword1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutPassword", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutPort", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutPort", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutPort1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutPort", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutUserID", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutUserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutUserID1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutUserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutgoingMailServer", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutgoingMailServer", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OutgoingMailServer1", System.Data.OleDb.OleDbType.VarWChar, 25, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OutgoingMailServer", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ServerType", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ServerType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ServerType1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ServerType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Type", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Type", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Type1", System.Data.OleDb.OleDbType.VarWChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Type", System.Data.DataRowVersion.Original, null));
			// 
			// AccountProp
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(607, 429);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "AccountProp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.tabControl1.ResumeLayout(false);
			this.tabPageMail.ResumeLayout(false);
			this.tabPageIn.ResumeLayout(false);
			this.tabPageOut.ResumeLayout(false);
			this.gbOutSettings.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		//创建或者修改属性
		public void setProp(bool newAccount) 
		{
			if (!newAccount) 
			{
				updateData();
			}
			else 
			{
				newFlag = true;
			}
		}

		//更新窗口中的数据
		private void updateData() 
		{
			if (lv.SelectedIndices.Count>0)
			{
				int index = lv.SelectedIndices[0];
				string account = lv.Items[index].Text;

				//从数据库中读取邮箱帐户

				DataRow dr = dt.Rows[index];
				
				this.tbMailBox.Text = (string)dr["Account"];
				this.tbInServer.Text = (string)dr["IncomingMailServer"].ToString();
				this.tbInID.Text = (string)dr["InUserID"].ToString();
				this.tbInPwd.Text = (string)dr["InUserID"].ToString();
				this.tbInPort.Text = (string)dr["InPort"].ToString();
				this.tbOutServer.Text = (string)dr["OutgoingMailServer"].ToString();
				this.tbOutPwd.Text = (string)dr["OutPassword"].ToString();
				this.tbOutID.Text = (string)dr["OutUserID"].ToString();
				this.tbOutPort.Text = (string)dr["OutPort"].ToString();

				this.cbKeepMails.Checked = (bool)dr["IsLeaveMessage"];
				this.cbNeedVerify.Checked = (bool)dr["IsOutgoingAuthorized"];
				this.rbtnSame.Checked = (bool)dr["IsTheSameWithIncoming"];

				this.cbNeedVerify_CheckedChanged(null, null);
			}
		}

		//根据Checkbox的状态更新下面的控件
		private void cbNeedVerify_CheckedChanged(object sender, System.EventArgs e)
		{
			gbOutSettings.Enabled = cbNeedVerify.Checked;
			tbOutID.Enabled = rbtnOwn.Checked;
			tbOutPwd.Enabled = rbtnOwn.Checked;
		}

		private void rbtnSame_CheckedChanged(object sender, System.EventArgs e)
		{
			this.cbNeedVerify_CheckedChanged(null, null);
		}

		private void rbtnOwn_CheckedChanged(object sender, System.EventArgs e)
		{
			this.cbNeedVerify_CheckedChanged(null, null);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			if (this.tbMailBox.Text == "") 
			{
				MessageBox.Show("必须输入邮件帐户名字", "邮箱帐户错误",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			DataRow dr;
			if (!newFlag) 
			{
				int index = lv.SelectedIndices[0];
				dr = dt.Rows[index];
			}
			else 
			{
				dr = dt.NewRow();
				dt.Rows.Add(dr);
			}
			dr.BeginEdit();

			dr["Account"] = this.tbMailBox.Text;
			dr["IncomingMailServer"] = this.tbInServer.Text;
			dr["InUserID"] = this.tbInID.Text;
			dr["InPassword"] = this.tbInPwd.Text;
			dr["InPort"] = this.tbInPort.Text;

			dr["OutgoingMailServer"] = this.tbOutServer.Text;
			dr["OutPassword"] = this.tbOutPwd.Text;
			dr["OutUserID"] = this.tbOutID.Text;
			dr["OutPort"] = this.tbOutPort.Text;
			dr["IsLeaveMessage"] = this.cbKeepMails.Checked;
			dr["IsOutgoingAuthorized"] = this.cbNeedVerify.Checked;
			dr["IsTheSameWithIncoming"] =this.rbtnSame.Checked;
				
			dr.EndEdit();

			da.Update(ds, "MailAccounts");
			ds.AcceptChanges();

				

			//更新ListView
			if (newFlag) 
			{
				ListViewItem item1 = lv.Items.Add(this.tbMailBox.Text);
				item1.SubItems.Add(FormAccount.MAIL_TYPE_GENERAL);
			}
			else 
			{
				int index = lv.SelectedIndices[0];
				lv.Items[index].Text = this.tbMailBox.Text;
			}

			newFlag = false;
			
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			btnApply_Click(null, null);
			this.Close();
		}
	}
}
