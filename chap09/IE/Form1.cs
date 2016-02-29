using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;

namespace IE
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private AxSHDocVw.AxWebBrowser axWebBrowser1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.Panel panel1;
		private System.ComponentModel.IContainer components;

		public Form1()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// axWebBrowser1
			// 
			this.axWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axWebBrowser1.Enabled = true;
			this.axWebBrowser1.Location = new System.Drawing.Point(0, 0);
			this.axWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser1.OcxState")));
			this.axWebBrowser1.Size = new System.Drawing.Size(792, 573);
			this.axWebBrowser1.TabIndex = 0;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4});
			this.menuItem1.Text = "设置";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "设为空白页";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "设为首页";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "动感效果";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 551);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(792, 22);
			this.statusBar1.TabIndex = 1;
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2,
																						this.toolBarButton3,
																						this.toolBarButton4,
																						this.toolBarButton5,
																						this.toolBarButton6});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(792, 41);
			this.toolBar1.TabIndex = 2;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 0;
			this.toolBarButton1.Text = "后退";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 1;
			this.toolBarButton2.Text = "前进";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.ImageIndex = 2;
			this.toolBarButton3.Text = "暂停";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 3;
			this.toolBarButton4.Text = "刷新";
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.ImageIndex = 4;
			this.toolBarButton5.Text = "首页";
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.ImageIndex = 5;
			this.toolBarButton6.Text = "搜索";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "地址";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(48, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(696, 20);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(752, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(40, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "转到";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(792, 39);
			this.panel1.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.axWebBrowser1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Web IE";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).EndInit();
			this.panel1.ResumeLayout(false);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			System.Object nullObject = 0 ;
			string str = "" ;
			System.Object nullObjStr = str ;
			Cursor.Current = Cursors.WaitCursor ;
			axWebBrowser1.Navigate (comboBox1.Text , ref nullObject , ref nullObjStr , ref nullObjStr , ref nullObjStr ) ;
			Cursor.Current = Cursors.Default ;
			AddAdress();
			statusBar1.Text=axWebBrowser1.LocationName;
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			RegistryKey pregkey ; 
			pregkey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main",true); 
			if (pregkey==null) 
			{ 
				Console.WriteLine("键值不存在"); 
			} 
			else 
			{ 
				pregkey.SetValue("Start Page",comboBox1.Text); 
						
				Console.WriteLine("修改成功"); 

			} 
			pregkey.Close(); 
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0:
					axWebBrowser1.GoBack();
					break;
				case 1:
					axWebBrowser1.GoForward();
					break;
				case 2:
					axWebBrowser1.Stop();
					break;
				case 3:
					axWebBrowser1.Refresh();
					break;
				case 4:
					axWebBrowser1.GoHome();
					break;
				case 5:
					axWebBrowser1.GoSearch();
					break;
			}
		}

		private void comboBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==(char)13)//回车键
			{
				Navigate();
			}
		}
		private void Navigate()
		{
			object aObject = new object();
			try
			{
				this.axWebBrowser1.Navigate(comboBox1.Text,ref aObject,ref aObject,ref aObject,ref aObject);
			}
			catch{}
			AddAdress();
			statusBar1.Text=axWebBrowser1.LocationName;

		}
		private void AddAdress()//地址不在ComboxBox控件中，则添加地址
		{
			int AdressIndex = comboBox1.FindStringExact(comboBox1.Text);
			if(AdressIndex<0)
			{
				comboBox1.Items.Add(comboBox1.Text);
			}
		}
		//设置为空白页
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			RegistryKey pregkey ; 
			pregkey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main",true); 
			if (pregkey==null) 
			{ 
				Console.WriteLine("键值不存在"); 
			} 
			else 
			{ 
				pregkey.SetValue("Start Page","about:blank"); 
						
				Console.WriteLine("修改成功"); 
			} 
			pregkey.Close(); 
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			RegistryKey pregkey ; 
			pregkey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop\\WindowMetrics",true); 
			if (pregkey==null) 
			{ 
				Console.WriteLine("键值不存在"); 
			} 
			else 
			{ 
				pregkey.SetValue("MinAnimate","1"); 
				pregkey.SetValue("MaxAnimate","1"); 						
				Console.WriteLine("修改成功"); 
			} 
			pregkey.Close(); 
		}
		//打开窗口时,将注册表中历史记录,添加到Combox1下拉列表中.
		private void Form1_Load(object sender, System.EventArgs e)
		{
			RegistryKey pregkey ; 
			pregkey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\TypedURLs",true); 
			if (pregkey==null) 
			{ 
				Console.WriteLine("键值不存在"); 
			} 
			else 
			{ 
				String [] names =pregkey.GetValueNames(); 
				foreach (String s in names) 
				{
					comboBox1.Items.Add(pregkey.GetValue(s).ToString());
				}						
				Console.WriteLine("读取成功"); 
			} 
			pregkey.Close();
		
		}
	}
}
