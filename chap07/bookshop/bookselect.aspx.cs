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
	/// bookselect 的摘要说明。
	/// </summary>
	public class bookselect : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox author;
		protected System.Web.UI.WebControls.Button Btn_ok;
		protected System.Web.UI.WebControls.DataGrid datagrid1;
		protected System.Web.UI.WebControls.TextBox bookname;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.TextBox bookprint;
		SqlConnection cn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
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
			this.Btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_ok_Click(object sender, System.EventArgs e)
		{
			SqlCommand cm=new SqlCommand("bookselect",cn);
			cm.CommandType=CommandType.StoredProcedure;
							
			cm.Parameters.Add(new SqlParameter("@author",SqlDbType.VarChar ,50));
			cm.Parameters.Add(new SqlParameter("@bookprint",SqlDbType.VarChar,50));			
			cm.Parameters.Add(new SqlParameter("@bookname",SqlDbType.VarChar,50));

			
			cm.Parameters["@author"].Value=author.Text;
			cm.Parameters["@bookprint"].Value=bookprint.Text;
			cm.Parameters["@bookname"].Value=bookname.Text;
								
			

			try
			{
				SqlDataAdapter myAdapter = new SqlDataAdapter();

				myAdapter.SelectCommand = cm;

				DataSet ds = new DataSet();

				myAdapter.Fill(ds);
				datagrid1.DataSource=ds;
				datagrid1.DataBind();
				
			}
			catch
			{}
		}
	}
}
