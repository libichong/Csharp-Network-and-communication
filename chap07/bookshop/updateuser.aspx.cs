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
	/// updateuser ��ժҪ˵����
	/// </summary>
	public class updateuser : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox password;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.TextBox Email;
		protected System.Web.UI.WebControls.TextBox card;
		protected System.Web.UI.WebControls.Button Btn_ok;
		protected System.Web.UI.WebControls.Button Btn_cancel;
		protected System.Web.UI.WebControls.Label Lbl_note;
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
			this.Btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Btn_ok_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				SqlCommand cm=new SqlCommand("updateuser",cn);
				cm.CommandType=CommandType.StoredProcedure;
				cm.Parameters.Add(new SqlParameter("@userid",SqlDbType.Char,200));
				cm.Parameters.Add(new SqlParameter("@password",SqlDbType.Char,18));
				cm.Parameters.Add(new SqlParameter("@name",SqlDbType.Char,20));
				cm.Parameters.Add(new SqlParameter("@Email",SqlDbType.VarChar,30));
				cm.Parameters.Add(new SqlParameter("@card",SqlDbType.VarChar,50));
				
				cm.Parameters["@userid"].Value=Session["userid"];
				cm.Parameters["@password"].Value=password.Text;
				cm.Parameters["@name"].Value=name.Text;
				cm.Parameters["@Email"].Value=Email.Text;				
				cm.Parameters["@card"].Value=card.Text;
				
				cm.Connection.Open();
				try
				{
					cm.ExecuteNonQuery();
					Response.Redirect("login.aspx");
				
				}
				catch(SqlException)
				{
					Lbl_note.Text="����ʧ��";
					Lbl_note.Style["color"]="red";
				}
				cm.Connection.Close();
			}
		}

		private void Btn_cancel_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("updateuser.aspx");
		}
	}
}
