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
	///		type ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
