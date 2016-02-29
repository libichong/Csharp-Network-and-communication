using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.OleDb;


namespace MyOutlook
{
	/// <summary>
	/// frmMain 的摘要说明。
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.MenuItem miFile;
		private System.Windows.Forms.MenuItem miSetup;
		private System.Windows.Forms.TreeView tvBoxesList;
		private System.Windows.Forms.ColumnHeader colSentTime;
		private System.Windows.Forms.ColumnHeader colSentName;
		private System.Windows.Forms.ColumnHeader colReceiveName;
		private System.Windows.Forms.ColumnHeader colTitle;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.ListView lvMailList;
		private System.Windows.Forms.Panel pnlClient;
		private System.Windows.Forms.Splitter splListPreview;
		private System.Windows.Forms.Panel pnlPreview;
		private System.Windows.Forms.RichTextBox rtbContent;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem miAccountSetup;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbbtnNew;
		private System.Windows.Forms.ToolBarButton tbbtnReceive;
		private System.Windows.Forms.ToolBarButton tbbtnSend;
		private System.Windows.Forms.MenuItem miReceiveAll;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.ContextMenu cmAccounts;

		internal System.Data.OleDb.OleDbConnection oledbcntMyOutLookDB;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbDataAdapter oledbadpMailAccounts;
		
		
		internal ArrayList accounts;
		private System.Windows.Forms.MenuItem miLine;
		internal Hashtable  mails;
		private MailStore ms;
		private System.Windows.Forms.MenuItem miNew;
		private System.Data.OleDb.OleDbDataAdapter oledbadpMails;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Windows.Forms.MenuItem miDelete;
		private System.Windows.Forms.ToolBarButton tbbtnDelete;
		private string curMailBox="";

		public frmMain()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			accounts = new ArrayList();
			
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.miFile = new System.Windows.Forms.MenuItem();
			this.miNew = new System.Windows.Forms.MenuItem();
			this.miDelete = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.miSetup = new System.Windows.Forms.MenuItem();
			this.miAccountSetup = new System.Windows.Forms.MenuItem();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.tbbtnNew = new System.Windows.Forms.ToolBarButton();
			this.tbbtnReceive = new System.Windows.Forms.ToolBarButton();
			this.cmAccounts = new System.Windows.Forms.ContextMenu();
			this.miReceiveAll = new System.Windows.Forms.MenuItem();
			this.miLine = new System.Windows.Forms.MenuItem();
			this.tbbtnSend = new System.Windows.Forms.ToolBarButton();
			this.tbbtnDelete = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.pnlClient = new System.Windows.Forms.Panel();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.pnlPreview = new System.Windows.Forms.Panel();
			this.rtbContent = new System.Windows.Forms.RichTextBox();
			this.splListPreview = new System.Windows.Forms.Splitter();
			this.lvMailList = new System.Windows.Forms.ListView();
			this.colSentName = new System.Windows.Forms.ColumnHeader();
			this.colReceiveName = new System.Windows.Forms.ColumnHeader();
			this.colTitle = new System.Windows.Forms.ColumnHeader();
			this.colSentTime = new System.Windows.Forms.ColumnHeader();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.tvBoxesList = new System.Windows.Forms.TreeView();
			this.oledbcntMyOutLookDB = new System.Data.OleDb.OleDbConnection();
			this.oledbadpMailAccounts = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oledbadpMails = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.pnlClient.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			this.pnlPreview.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miFile,
																					this.miSetup});
			// 
			// miFile
			// 
			this.miFile.Index = 0;
			this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miNew,
																				   this.miDelete,
																				   this.menuItem2,
																				   this.miExit});
			this.miFile.Text = "邮件(&M)";
			// 
			// miNew
			// 
			this.miNew.Index = 0;
			this.miNew.Text = "新建(&N)";
			this.miNew.Click += new System.EventHandler(this.miNew_Click);
			// 
			// miDelete
			// 
			this.miDelete.Index = 1;
			this.miDelete.Text = "删除(&D)";
			this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 3;
			this.miExit.Text = "退出(&X)";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// miSetup
			// 
			this.miSetup.Index = 1;
			this.miSetup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miAccountSetup});
			this.miSetup.Text = "设置(&S)";
			// 
			// miAccountSetup
			// 
			this.miAccountSetup.Index = 0;
			this.miAccountSetup.Text = "邮箱设置(&M)";
			this.miAccountSetup.Click += new System.EventHandler(this.miAccountSetup_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 627);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(1024, 22);
			this.statusBar.TabIndex = 5;
			// 
			// toolBar
			// 
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.tbbtnNew,
																					   this.tbbtnReceive,
																					   this.tbbtnSend,
																					   this.tbbtnDelete});
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imageList1;
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(1024, 42);
			this.toolBar.TabIndex = 4;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// tbbtnNew
			// 
			this.tbbtnNew.ImageIndex = 2;
			this.tbbtnNew.Text = "新建";
			// 
			// tbbtnReceive
			// 
			this.tbbtnReceive.DropDownMenu = this.cmAccounts;
			this.tbbtnReceive.ImageIndex = 1;
			this.tbbtnReceive.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbbtnReceive.Text = "接收邮件";
			// 
			// cmAccounts
			// 
			this.cmAccounts.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.miReceiveAll,
																					   this.miLine});
			// 
			// miReceiveAll
			// 
			this.miReceiveAll.Index = 0;
			this.miReceiveAll.Text = "接收全部邮箱";
			this.miReceiveAll.Click += new System.EventHandler(this.miReceiveAll_Click);
			// 
			// miLine
			// 
			this.miLine.Index = 1;
			this.miLine.Text = "-";
			// 
			// tbbtnSend
			// 
			this.tbbtnSend.ImageIndex = 0;
			this.tbbtnSend.Text = "发送";
			// 
			// tbbtnDelete
			// 
			this.tbbtnDelete.ImageIndex = 3;
			this.tbbtnDelete.Text = "删除";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pnlClient
			// 
			this.pnlClient.Controls.Add(this.pnlLeft);
			this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlClient.Location = new System.Drawing.Point(0, 42);
			this.pnlClient.Name = "pnlClient";
			this.pnlClient.Size = new System.Drawing.Size(1024, 585);
			this.pnlClient.TabIndex = 6;
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.pnlPreview);
			this.pnlLeft.Controls.Add(this.splListPreview);
			this.pnlLeft.Controls.Add(this.lvMailList);
			this.pnlLeft.Controls.Add(this.splitter1);
			this.pnlLeft.Controls.Add(this.tvBoxesList);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlLeft.Location = new System.Drawing.Point(0, 0);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(1024, 585);
			this.pnlLeft.TabIndex = 7;
			// 
			// pnlPreview
			// 
			this.pnlPreview.Controls.Add(this.rtbContent);
			this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPreview.Location = new System.Drawing.Point(187, 100);
			this.pnlPreview.Name = "pnlPreview";
			this.pnlPreview.Size = new System.Drawing.Size(837, 485);
			this.pnlPreview.TabIndex = 5;
			// 
			// rtbContent
			// 
			this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbContent.Location = new System.Drawing.Point(0, 0);
			this.rtbContent.Name = "rtbContent";
			this.rtbContent.ReadOnly = true;
			this.rtbContent.Size = new System.Drawing.Size(837, 485);
			this.rtbContent.TabIndex = 8;
			this.rtbContent.Text = "";
			// 
			// splListPreview
			// 
			this.splListPreview.Dock = System.Windows.Forms.DockStyle.Top;
			this.splListPreview.Location = new System.Drawing.Point(187, 97);
			this.splListPreview.Name = "splListPreview";
			this.splListPreview.Size = new System.Drawing.Size(837, 3);
			this.splListPreview.TabIndex = 4;
			this.splListPreview.TabStop = false;
			// 
			// lvMailList
			// 
			this.lvMailList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.colSentName,
																						 this.colReceiveName,
																						 this.colTitle,
																						 this.colSentTime});
			this.lvMailList.Dock = System.Windows.Forms.DockStyle.Top;
			this.lvMailList.FullRowSelect = true;
			this.lvMailList.Location = new System.Drawing.Point(187, 0);
			this.lvMailList.MultiSelect = false;
			this.lvMailList.Name = "lvMailList";
			this.lvMailList.Size = new System.Drawing.Size(837, 97);
			this.lvMailList.TabIndex = 3;
			this.lvMailList.View = System.Windows.Forms.View.Details;
			this.lvMailList.DoubleClick += new System.EventHandler(this.lvMailList_DoubleClick);
			this.lvMailList.SelectedIndexChanged += new System.EventHandler(this.lvMailList_SelectedIndexChanged);
			// 
			// colSentName
			// 
			this.colSentName.Text = "发送人";
			this.colSentName.Width = 142;
			// 
			// colReceiveName
			// 
			this.colReceiveName.Text = "收件人";
			this.colReceiveName.Width = 126;
			// 
			// colTitle
			// 
			this.colTitle.Text = "标题";
			this.colTitle.Width = 468;
			// 
			// colSentTime
			// 
			this.colSentTime.Text = "发送时间";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(184, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 585);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// tvBoxesList
			// 
			this.tvBoxesList.Dock = System.Windows.Forms.DockStyle.Left;
			this.tvBoxesList.ImageIndex = -1;
			this.tvBoxesList.Location = new System.Drawing.Point(0, 0);
			this.tvBoxesList.Name = "tvBoxesList";
			this.tvBoxesList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																					new System.Windows.Forms.TreeNode("收件箱"),
																					new System.Windows.Forms.TreeNode("发件箱"),
																					new System.Windows.Forms.TreeNode("草稿箱"),
																					new System.Windows.Forms.TreeNode("垃圾箱"),
																					new System.Windows.Forms.TreeNode("已发送")});
			this.tvBoxesList.SelectedImageIndex = -1;
			this.tvBoxesList.Size = new System.Drawing.Size(184, 585);
			this.tvBoxesList.TabIndex = 1;
			this.tvBoxesList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBoxesList_AfterSelect);
			// 
			// oledbcntMyOutLookDB
			// 
			this.oledbcntMyOutLookDB.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""MyOutlookDB.mdb"";Mode=Share Deny None;Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			// 
			// oledbadpMailAccounts
			// 
			this.oledbadpMailAccounts.DeleteCommand = this.oleDbDeleteCommand1;
			this.oledbadpMailAccounts.InsertCommand = this.oleDbInsertCommand1;
			this.oledbadpMailAccounts.SelectCommand = this.oleDbSelectCommand1;
			this.oledbadpMailAccounts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			this.oledbadpMailAccounts.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM MailAccounts WHERE (MailAccountID = ?) AND (Account = ? OR ? IS NULL AND Account IS NULL) AND (InPassword = ? OR ? IS NULL AND InPassword IS NULL) AND (InPort = ? OR ? IS NULL AND InPort IS NULL) AND (InUserID = ? OR ? IS NULL AND InUserID IS NULL) AND (IncomingMailServer = ? OR ? IS NULL AND IncomingMailServer IS NULL) AND (IsLeaveMessage = ?) AND (IsOutgoingAuthorized = ?) AND (IsTheSameWithIncoming = ?) AND (OutPassword = ? OR ? IS NULL AND OutPassword IS NULL) AND (OutPort = ? OR ? IS NULL AND OutPort IS NULL) AND (OutUserID = ? OR ? IS NULL AND OutUserID IS NULL) AND (OutgoingMailServer = ? OR ? IS NULL AND OutgoingMailServer IS NULL) AND (ServerType = ? OR ? IS NULL AND ServerType IS NULL) AND (Type = ? OR ? IS NULL AND Type IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oledbcntMyOutLookDB;
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
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO MailAccounts(Account, IncomingMailServer, InPassword, InPort, InUserID, IsLeaveMessage, IsOutgoingAuthorized, IsTheSameWithIncoming, OutgoingMailServer, OutPassword, OutPort, OutUserID, ServerType, Type) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oledbcntMyOutLookDB;
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
			this.oleDbSelectCommand1.Connection = this.oledbcntMyOutLookDB;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE MailAccounts SET Account = ?, IncomingMailServer = ?, InPassword = ?, InPort = ?, InUserID = ?, IsLeaveMessage = ?, IsOutgoingAuthorized = ?, IsTheSameWithIncoming = ?, OutgoingMailServer = ?, OutPassword = ?, OutPort = ?, OutUserID = ?, ServerType = ?, Type = ? WHERE (MailAccountID = ?) AND (Account = ? OR ? IS NULL AND Account IS NULL) AND (InPassword = ? OR ? IS NULL AND InPassword IS NULL) AND (InPort = ? OR ? IS NULL AND InPort IS NULL) AND (InUserID = ? OR ? IS NULL AND InUserID IS NULL) AND (IncomingMailServer = ? OR ? IS NULL AND IncomingMailServer IS NULL) AND (IsLeaveMessage = ?) AND (IsOutgoingAuthorized = ?) AND (IsTheSameWithIncoming = ?) AND (OutPassword = ? OR ? IS NULL AND OutPassword IS NULL) AND (OutPort = ? OR ? IS NULL AND OutPort IS NULL) AND (OutUserID = ? OR ? IS NULL AND OutUserID IS NULL) AND (OutgoingMailServer = ? OR ? IS NULL AND OutgoingMailServer IS NULL) AND (ServerType = ? OR ? IS NULL AND ServerType IS NULL) AND (Type = ? OR ? IS NULL AND Type IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oledbcntMyOutLookDB;
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
			// oledbadpMails
			// 
			this.oledbadpMails.DeleteCommand = this.oleDbDeleteCommand2;
			this.oledbadpMails.InsertCommand = this.oleDbInsertCommand2;
			this.oledbadpMails.SelectCommand = this.oleDbSelectCommand2;
			this.oledbadpMails.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "Mails", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("Attachment", "Attachment"),
																																																			 new System.Data.Common.DataColumnMapping("BCC", "BCC"),
																																																			 new System.Data.Common.DataColumnMapping("CC", "CC"),
																																																			 new System.Data.Common.DataColumnMapping("Content", "Content"),
																																																			 new System.Data.Common.DataColumnMapping("MailID", "MailID"),
																																																			 new System.Data.Common.DataColumnMapping("MailStorePosition", "MailStorePosition"),
																																																			 new System.Data.Common.DataColumnMapping("ReceiveMailBox", "ReceiveMailBox"),
																																																			 new System.Data.Common.DataColumnMapping("SendMailBox", "SendMailBox"),
																																																			 new System.Data.Common.DataColumnMapping("Time", "Time"),
																																																			 new System.Data.Common.DataColumnMapping("Title", "Title")})});
			this.oledbadpMails.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM Mails WHERE (MailID = ?) AND (BCC = ? OR ? IS NULL AND BCC IS NULL) AND (CC = ? OR ? IS NULL AND CC IS NULL) AND (MailStorePosition = ? OR ? IS NULL AND MailStorePosition IS NULL) AND (ReceiveMailBox = ? OR ? IS NULL AND ReceiveMailBox IS NULL) AND (SendMailBox = ? OR ? IS NULL AND SendMailBox IS NULL) AND ([Time] = ? OR ? IS NULL AND [Time] IS NULL) AND (Title = ? OR ? IS NULL AND Title IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oledbcntMyOutLookDB;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MailID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MailID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BCC", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BCC", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BCC1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BCC", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CC", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CC", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CC1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CC", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MailStorePosition", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MailStorePosition", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MailStorePosition1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MailStorePosition", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReceiveMailBox", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReceiveMailBox", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReceiveMailBox1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReceiveMailBox", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SendMailBox", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SendMailBox", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SendMailBox1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SendMailBox", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Time", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Time", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Time1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Time", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Title", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Title1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Title", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO Mails(Attachment, BCC, CC, Content, MailStorePosition, ReceiveMailBox" +
				", SendMailBox, [Time], Title) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oledbcntMyOutLookDB;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Attachment", System.Data.OleDb.OleDbType.VarBinary, 0, "Attachment"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("BCC", System.Data.OleDb.OleDbType.VarWChar, 50, "BCC"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CC", System.Data.OleDb.OleDbType.VarWChar, 50, "CC"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Content", System.Data.OleDb.OleDbType.VarWChar, 0, "Content"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MailStorePosition", System.Data.OleDb.OleDbType.VarWChar, 6, "MailStorePosition"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReceiveMailBox", System.Data.OleDb.OleDbType.VarWChar, 50, "ReceiveMailBox"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SendMailBox", System.Data.OleDb.OleDbType.VarWChar, 50, "SendMailBox"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Time", System.Data.OleDb.OleDbType.VarWChar, 50, "Time"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 255, "Title"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT Attachment, BCC, CC, Content, MailID, MailStorePosition, ReceiveMailBox, S" +
				"endMailBox, [Time], Title FROM Mails";
			this.oleDbSelectCommand2.Connection = this.oledbcntMyOutLookDB;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE Mails SET Attachment = ?, BCC = ?, CC = ?, Content = ?, MailStorePosition = ?, ReceiveMailBox = ?, SendMailBox = ?, [Time] = ?, Title = ? WHERE (MailID = ?) AND (BCC = ? OR ? IS NULL AND BCC IS NULL) AND (CC = ? OR ? IS NULL AND CC IS NULL) AND (MailStorePosition = ? OR ? IS NULL AND MailStorePosition IS NULL) AND (ReceiveMailBox = ? OR ? IS NULL AND ReceiveMailBox IS NULL) AND (SendMailBox = ? OR ? IS NULL AND SendMailBox IS NULL) AND ([Time] = ? OR ? IS NULL AND [Time] IS NULL) AND (Title = ? OR ? IS NULL AND Title IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oledbcntMyOutLookDB;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Attachment", System.Data.OleDb.OleDbType.VarBinary, 0, "Attachment"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("BCC", System.Data.OleDb.OleDbType.VarWChar, 50, "BCC"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CC", System.Data.OleDb.OleDbType.VarWChar, 50, "CC"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Content", System.Data.OleDb.OleDbType.VarWChar, 0, "Content"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MailStorePosition", System.Data.OleDb.OleDbType.VarWChar, 6, "MailStorePosition"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReceiveMailBox", System.Data.OleDb.OleDbType.VarWChar, 50, "ReceiveMailBox"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SendMailBox", System.Data.OleDb.OleDbType.VarWChar, 50, "SendMailBox"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Time", System.Data.OleDb.OleDbType.VarWChar, 50, "Time"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Title", System.Data.OleDb.OleDbType.VarWChar, 255, "Title"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MailID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MailID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BCC", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BCC", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_BCC1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BCC", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CC", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CC", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CC1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CC", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MailStorePosition", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MailStorePosition", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MailStorePosition1", System.Data.OleDb.OleDbType.VarWChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MailStorePosition", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReceiveMailBox", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReceiveMailBox", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReceiveMailBox1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReceiveMailBox", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SendMailBox", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SendMailBox", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SendMailBox1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SendMailBox", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Time", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Time", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Time1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Time", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Title", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Title", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Title1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Title", System.Data.DataRowVersion.Original, null));
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1024, 649);
			this.Controls.Add(this.pnlClient);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolBar);
			this.Menu = this.mnuMain;
			this.Name = "frmMain";
			this.Text = "我的Outlook";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.pnlClient.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			this.pnlPreview.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}


		private void frmMain_Load(object sender, System.EventArgs e)
		{
			//打开连接
			if (oledbcntMyOutLookDB.State==System.Data.ConnectionState.Closed)
			{
				oledbcntMyOutLookDB.Open();
			}
			ms = new MailStore(this.oledbcntMyOutLookDB, this.oledbadpMails);
			loadAccounts();
			loadMails();	
			System.Windows.Forms.TreeViewEventArgs ee = new TreeViewEventArgs(
				this.tvBoxesList.Nodes[0]);
			this.tvBoxesList_AfterSelect(this.tvBoxesList, ee);
		}

		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//关闭连接
			oledbcntMyOutLookDB.Close();
		}

		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tbbtnNew) 
			{
				this.miNew_Click(null, null);
			}
			else if (e.Button == this.tbbtnSend)
			{
				SendMails();
			}
			else if (e.Button == this.tbbtnDelete)
			{
				this.miDelete_Click(null, null);
			}
		}

		private void miAccountSetup_Click(object sender, System.EventArgs e)
		{
			FormAccount frmAccount = new FormAccount(this);
			frmAccount.ShowDialog();
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		internal void loadAccounts() 
		{
			//从数据库中读取所有的邮件
			string mySelectQuery = "SELECT * FROM MailAccounts ORDER BY MailAccountID";
			OleDbCommand cmd = new OleDbCommand(mySelectQuery, oledbcntMyOutLookDB);
			cmd.CommandTimeout = 20;

			accounts.Clear();
			
			//打开连接
			if (oledbcntMyOutLookDB.State==System.Data.ConnectionState.Closed)
			{
				oledbcntMyOutLookDB.Open();
			}

			System.Data.OleDb.OleDbDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				while (dr.Read())
				{
					MailAccount ma = new MailAccount();
					ma.MailAccountID = (int)dr["MailAccountID"];
					ma.Account = (string)dr["Account"];
					ma.OutServer = (string)dr["OutgoingMailServer"];
					ma.OutServerPassword = (string)dr["OutPassword"];
					ma.OutServerPort = (string)dr["OutPort"];
					ma.OutServerRequireAuth = (bool)dr["IsOutgoingAuthorized"];
					ma.OutServerUser = (string)dr["OutUserID"];

					ma.InServer = (string)dr["IncomingMailServer"];
					ma.InServerPort = (string)dr["InPort"];
					ma.InServerUser = (string)dr["InUserID"];
					
					ma.InServerPassword = (string)dr["InPassword"];;
					ma.IsLeaveMessage = (bool)dr["IsLeaveMessage"];
					ma.IsTheSameWithIncoming = (bool)dr["IsTheSameWithIncoming"];


					accounts.Add(ma);
				}
			}


			//关闭连接
			dr.Close();

			
			if (accounts.Count>0) 
			{
				this.cmAccounts.MenuItems.Clear();
				this.cmAccounts.MenuItems.Add(miReceiveAll);
				this.cmAccounts.MenuItems.Add(miLine);

				System.Collections.IEnumerator myEnumerator = accounts.GetEnumerator();
				while (myEnumerator.MoveNext())
				{
					MailAccount ma = (MailAccount)myEnumerator.Current;
					MenuItem mi = new MenuItem(ma.Account);
					mi.Click += new System.EventHandler(this.handleContextMenu_Click);
					this.cmAccounts.MenuItems.Add(mi);

				}
			}
		
		}

		//接收选定的邮箱
		private void handleContextMenu_Click(object sender, System.EventArgs e) 
		{
			if (sender is MenuItem) 
			{
				MenuItem mi = (MenuItem)sender;
				ReceiveMail(mi.Text);
			}
			
		}



		//接收全部的邮箱
		private void miReceiveAll_Click(object sender, System.EventArgs e)
		{
			if (this.cmAccounts.MenuItems.Count>2)
			{
				for (int i=2;i<cmAccounts.MenuItems.Count;i++)
				{
					MenuItem mi = this.cmAccounts.MenuItems[i];
					ReceiveMail(mi.Text);
				}
			}		
		}

		//接收指定邮箱的邮件
		private void ReceiveMail(string account) 
		{
			MailAccount ma = getMailAccountByName(account);
			if (ma == null) 
			{
				return;
			}

			frmProgress prg = new frmProgress();
			prg.Show();
				
			Pop3MailOperation mo = new Pop3MailOperation();
			string msg="";

			prg.UpdateUI("连接服务器...", 0, "");
			bool ok = mo.Connect(ma, true, ref msg);
			prg.UpdateUI("连接服务器...", 0, msg);
			if (!ok)
			{
				prg.UpdateUI("连接服务器...", 0,  
					msg + "\n连接错误，退出\n");
				return;
			}
			
			prg.UpdateUI("登录服务器...", 0, "");
			ok = mo.Pop3Login(ref msg);
			prg.UpdateUI("登录服务器...", 0, msg);
			if (!ok)
			{
				prg.UpdateUI("登录服务器...", 0,  
					msg + "\n登录错误，退出\n");
				mo.Close(ref msg);
				return;
			}
			
			prg.UpdateUI("获取邮件数目...", 0, "");
			int num = mo.GetMailNumber(ref msg);
			prg.UpdateUI("获取邮件数目...", 0, msg);
			if (num<1)
			{
				prg.UpdateUI("获取邮件数目...", 0,  
					msg + "\n邮件数目为0，接收完毕\n\n");
				mo.Close(ref msg);
				return;
			}

			int pos = 0;
			for (int j=1;j<=num;j++) 
			{
				//检查是否要终止接收
				if (prg.stopFlag) 
				{
					break;
				}

				prg.UpdateUI("共接收" + num + "封邮件，正在接收" + j + "封邮件", 0, "");
				Mail m;
				if (ma.IsLeaveMessage)
				{
					m = mo.Receive(ref msg, j);
				}
				else
				{
					m = mo.Receive(ref msg, 1);
				}
				pos = (int)100*j/num;	//计算进度条的位置
				prg.UpdateUI("共接收" + num + "封邮件，正在接收" + j + "封邮件", pos, msg);
				if (m == null) 
				{
					continue;
				}
				
				m = ms.addNew(m);
				mails.Add(m.MailID, m);

				if (m.MailStorePosition == this.curMailBox)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = m.Sender;
					lvi.SubItems.Add(m.Recipient);
					lvi.SubItems.Add(m.Subject);
					lvi.SubItems.Add(m.Time);
					lvi.Tag = m.MailID;
					this.lvMailList.Items.Add(lvi);
				}
			}
			
			prg.UpdateUI("邮件接收完毕，关闭邮箱", 0, "");
			ok = mo.Close(ref msg);
			prg.UpdateUI("邮件接收完毕，关闭邮箱", 0, msg);

		}

		private MailAccount getMailAccountByName(string curAccount)
		{
			MailAccount retMA = null;
			if (accounts.Count>0) 
			{
				System.Collections.IEnumerator myEnumerator = accounts.GetEnumerator();
				while (myEnumerator.MoveNext())
				{
					MailAccount ma = (MailAccount)myEnumerator.Current;
					if (ma.Account == curAccount) 
					{
						retMA = ma;
					}
				}
			}
			return retMA;
		}

		//装载全部的邮件，并在不同的邮箱中显示
		private void loadMails()
		{
			mails = ms.getMails();

			if (mails.Count>0) 
			{
				this.tvBoxesList.Select();
				this.tvBoxesList.SelectedNode = this.tvBoxesList.Nodes[0];
			}
		}

		//显示不同邮箱中的邮件
		private void tvBoxesList_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (mails.Count==0)
			{
				return;
			}
			
			//根据不同的邮箱，显示不同的内容
			string mailbox = e.Node.Text;

			if (curMailBox == mailbox)
			{
				return;
			}

			this.curMailBox = mailbox;
			this.lvMailList.Items.Clear();
			System.Collections.IEnumerator myEnumerator = mails.Values.GetEnumerator();
			while (myEnumerator.MoveNext())
			{
				Mail m = (Mail)myEnumerator.Current;
				if (m.MailStorePosition==mailbox) 
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = m.Sender;
					lvi.SubItems.Add(m.Recipient);
					lvi.SubItems.Add(m.Subject);
					lvi.SubItems.Add(m.Time);
					lvi.Tag = m.MailID;
					this.lvMailList.Items.Add(lvi);
				}
			}
		}

		//选择不同的邮件时，显示邮件的内容
		private void lvMailList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lvMailList.SelectedItems.Count>0) 
			{
				try 
				{
					System.Windows.Forms.ListViewItem lvi = this.lvMailList.SelectedItems[0];
				
					string id = System.Convert.ToString(lvi.Tag);
					if(mails.ContainsKey(id)) 
					{
						Mail m = (Mail)mails[id];
						this.rtbContent.Text = m.MailContent;
					}
				}
				catch {}
			}
		}

		//双击后编辑邮件内容
		private void lvMailList_DoubleClick(object sender, System.EventArgs e)
		{
			if (this.lvMailList.SelectedItems.Count>0) 
			{
				try 
				{
					System.Windows.Forms.ListViewItem lvi = this.lvMailList.SelectedItems[0];
				
					string id = System.Convert.ToString(lvi.Tag);
					if(mails.ContainsKey(id)) 
					{
						Mail m = (Mail)mails[id];
						NewMailForm nmf = new NewMailForm(m, this);
						nmf.ShowDialog();
					}
				}
				catch (Exception exp)
				{
					Console.WriteLine(exp.ToString());
				}
			}
		
		}

		public void AddNewMail(Mail mail) 
		{
			if (mails.ContainsValue(mail))
			{
				//更新
				ms.update(mail);				
			}
			else
			{
				//添加
				mail = ms.addNew(mail);
			}
			
			if (mail.MailStorePosition == this.curMailBox)
			{
				if (mails.ContainsValue(mail))
				{
					//更新
					for (int i=0;i<this.lvMailList.Items.Count;i++)
					{
						ListViewItem lvi = this.lvMailList.Items[i];
						if (mail.MailID == (string)lvi.Tag)
						{
							lvi.Text = mail.Sender;
							lvi.SubItems[1].Text = mail.Recipient;
							lvi.SubItems[2].Text = mail.Subject;
							lvi.SubItems[3].Text = mail.Time;
							lvi.Tag = mail.MailID;
						}
					}
					this.lvMailList.Update();
				}
				else
				{
					//添加
					ListViewItem lvi = new ListViewItem();
					lvi.Text = mail.Sender;
					lvi.SubItems.Add(mail.Recipient);
					lvi.SubItems.Add(mail.Subject);
					lvi.SubItems.Add(mail.Time);
					lvi.Tag = mail.MailID;
					this.lvMailList.Items.Add(lvi);

				}
			}

			if (!mails.ContainsValue(mail))
			{
				mails.Add(mail.MailID, mail);
			}
			this.lvMailList_SelectedIndexChanged(null, null);
		}

		//发送邮件
		private void SendMails() 
		{
			if (mails.Count<1)
			{
				return;
			}

			frmProgress prg = new frmProgress();
			prg.Show();
				
			Pop3MailOperation mo = new Pop3MailOperation();
			string msg="";

			//获取要发送的邮件
			int num=1;
			Hashtable outMails = new Hashtable();
			System.Collections.IEnumerator myEnumerator = mails.Values.GetEnumerator();
			while (myEnumerator.MoveNext())
			{
				Mail m = (Mail)myEnumerator.Current;
				if (m.MailStorePosition == Mail.OUT_BOX)
				{
					outMails.Add(m.MailID, m);
				}
			}

			myEnumerator = outMails.Values.GetEnumerator();
			while (myEnumerator.MoveNext())
			{
				//检查是否要终止发送
				if (prg.stopFlag) 
				{
					break;
				}

				Mail m = (Mail)myEnumerator.Current;

				//发送待发邮件
				MailAccount ma = this.getMailAccountByName(m.Sender);
				if (ma == null)
				{
					return;
				}
					
				string title = "共" + outMails.Count + "封邮件需要发送，正在发送" + num + "封邮件...";

				prg.UpdateUI(title, 0, "");
				bool ok = mo.Connect(ma, false, ref msg);
				prg.UpdateUI(title, 0, msg);
				if (!ok)
				{
					prg.UpdateUI(title, 0,  msg + "\n服务器连接失败，退出");
					return;
				}
			
				if (ma.OutServerRequireAuth)
				{
					prg.UpdateUI(title, 0, "");
					ok = mo.SmtpLogin(ref msg);
					prg.UpdateUI(title, 0, msg);
					if (!ok)
					{
						prg.UpdateUI(title, 0, msg + "\n服务器登录失败，退出");
						mo.Close(ref msg);
						return;
					}
				}

				prg.UpdateUI(title, 0, "");
				ok = mo.Send(m, ref msg);
				prg.UpdateUI(title, 0, msg);
				if (!ok)
				{
					prg.UpdateUI(title, 0,  msg + "\n服发送邮件失败，退出");
					mo.Close(ref msg);
					return;
				}
					
				prg.UpdateUI(title, 0, "");
				ok = mo.Close(ref msg);
				prg.UpdateUI(title, 0, msg);
				if (!ok)
				{
					mo.Close(ref msg);
					return;
				}

				int pos = (int)100*num++/(outMails.Count);	//计算进度条的位置
				prg.UpdateUI(title, pos, "");

				//把邮件移动到发件箱中
				m.MailStorePosition = Mail.SENT_BOX;
				ms.update(m);
				
			}
		}

		private void miNew_Click(object sender, System.EventArgs e)
		{
			NewMailForm frmNewMail = new NewMailForm(null, this);
			frmNewMail.ShowDialog();
		}

		private void miDelete_Click(object sender, System.EventArgs e)
		{
			
			if (this.lvMailList.SelectedItems.Count>0) 
			{
				try 
				{
					System.Windows.Forms.ListViewItem lvi = this.lvMailList.SelectedItems[0];
				
					string id = System.Convert.ToString(lvi.Tag);
					if(mails.ContainsKey(id)) 
					{
						Mail m = (Mail)mails[id];
						if (m.MailStorePosition != Mail.TRASH_BOX)
						{
							MessageBoxButtons buttons = MessageBoxButtons.YesNo;
							DialogResult result = MessageBox.Show(this, 
								"要删除邮件，是否继续？", "删除确认", buttons,
								MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
								MessageBoxOptions.RightAlign);

							if(result == DialogResult.Yes)
							{
								m.MailStorePosition = Mail.TRASH_BOX;
								ms.update(m);
								this.lvMailList.Items.Remove(lvi);
							}
						}
						else 
						{
							MessageBoxButtons buttons = MessageBoxButtons.YesNo;
							DialogResult result = MessageBox.Show(this, 
								"邮件将被彻底删除，是否继续？", "删除确认", buttons,
								MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
								MessageBoxOptions.RightAlign);

							if(result == DialogResult.Yes)
							{
								ms.delete(m);
								this.lvMailList.Items.Remove(lvi);
								mails.Remove(m.MailID);
							}
						}
						this.rtbContent.Text = "";
					}
				}
				catch (Exception exp)
				{
					Console.WriteLine(exp.ToString());
				}
			}
		}
	}
}
