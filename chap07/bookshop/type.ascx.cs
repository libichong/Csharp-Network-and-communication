namespace bookshop
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Data.SqlClient;
	using System.Configuration;

	/// <summary>
	///		type 的摘要说明。
	/// </summary>
	public class type : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataList MyList;
		SqlConnection cn;

		public type() 
		{
			this.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);

			String selectedId = Request.Params["selection"];

			if (selectedId != null)
			{
				MyList.SelectedIndex = Int32.Parse(selectedId);
			}

			SqlDataAdapter da=new SqlDataAdapter("select * from booktype",cn);
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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
