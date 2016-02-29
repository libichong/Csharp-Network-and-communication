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
	/// updateuser 的摘要说明。
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
					Lbl_note.Text="更新失败";
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
