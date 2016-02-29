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
	/// list ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
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

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
