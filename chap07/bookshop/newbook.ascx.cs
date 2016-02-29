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
	///		newbook ��ժҪ˵����
	/// </summary>
	public class newbook : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataList MyList;
		SqlConnection cn;

		public newbook() 
		{
			this.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
			SqlDataAdapter da=new SqlDataAdapter("select TOP 10 * from book order by bookid desc",cn);
			DataSet ds=new DataSet();
			da.Fill (ds);
			MyList.DataSource=ds;
			MyList.DataBind();
		}
		private void Page_Init(object sender, EventArgs e) 
		{
			
			InitializeComponent();
		}

		#region Web ������������ɵĴ���
		
		
		/// <summary>
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
