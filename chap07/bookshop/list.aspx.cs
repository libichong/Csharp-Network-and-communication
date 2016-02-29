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
	/// list 的摘要说明。
	/// </summary>
	public class list : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid datagrid1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		SqlConnection cn;				
		SqlDataReader dr;
		SqlCommand cmd;
		
		string bookid;
		string strSQL;
		char[] de={'&'};
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string typeid=Request.QueryString.Get("typeid");
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			strSQL="Select bookid from book where typeid="+typeid;
			cn=new SqlConnection(strconn);
			cmd=new SqlCommand(strSQL,cn);
			cn.Open();
			dr=cmd.ExecuteReader();
			
			while(dr.Read())
			{
				bookid=dr["bookid"].ToString();
							
			}
			dr.Close();
			if(!IsPostBack)		BindGrid();
		}
		public void DataGrid_page(object sender,DataGridPageChangedEventArgs e)
		{
			datagrid1.CurrentPageIndex=e.NewPageIndex;
			BindGrid();
		}
		public void BindGrid()
		{
			string typeid=Request.QueryString.Get("typeid");
			string sql="select * from book where typeid='"+typeid+"' order by bookprint";
			SqlDataAdapter da=new SqlDataAdapter(sql,cn);
			DataSet ds=new DataSet();
			da.Fill(ds);
			datagrid1.DataSource=ds;
			datagrid1.DataBind();
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
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
