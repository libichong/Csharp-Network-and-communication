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
	/// bookselect ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string strconn=ConfigurationSettings.AppSettings["ConnectionString"];
			cn=new SqlConnection(strconn);
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
