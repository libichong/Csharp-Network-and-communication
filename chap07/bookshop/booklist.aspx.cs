using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

namespace bookshop
{
	/// <summary>
	/// booklist 的摘要说明。
	/// </summary>
	public class booklist : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList MyList;		
		SqlConnection cn;
	
		public booklist() 
		{
			this.Init += new System.EventHandler(Page_Init);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string  bookid =  Request.QueryString.Get("bookid");
			
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			string sql="select * from book where bookid='"+bookid+"'";
			SqlDataAdapter da=new SqlDataAdapter(sql,cn);
			DataSet ds=new DataSet();
			da.Fill (ds);
			MyList.DataSource=ds;
			MyList.DataBind();
		}
		private void Page_Init(object sender, EventArgs e) 
		{
			
			InitializeComponent();
		}

		#region Web 窗体设计器生成的代码
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
