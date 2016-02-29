using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Configuration;

namespace TeleCommServices
{
	/// <summary>
	/// ChargeManageServices 的摘要说明。
	/// </summary>
	[WebService(Namespace="http://www.telecomm.com")]
	public class ChargeManageServices : System.Web.Services.WebService
	{
		public ChargeManageServices()
		{
			//CODEGEN: This call is required by http://localhost/DotNet/TeleCommServices/ChargeManageServices.asmxthe ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		//发送短信的收费计算
		[WebMethod]
		public bool SendSM(string CardNo,string SMStatus,DateTime Time)
		{
			bool result=false;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];			
			SqlConnection conn=new SqlConnection();
			conn.ConnectionString=ConnectionString;
			conn.Open();
			SqlCommand comm=new SqlCommand();
			comm.Connection=conn;
			comm.CommandText="usp_SendSM";
			comm.CommandType=CommandType.StoredProcedure;
			SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=CardNo;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@SMStatus",SqlDbType.VarChar,15);
			param2.Direction=ParameterDirection.Input;
			param2.Value=SMStatus;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@Time",SqlDbType.DateTime);
			param3.Direction=ParameterDirection.Input;
			param3.Value=Time;
			comm.Parameters.Add(param3);
			SqlParameter param4=new SqlParameter("@Result",SqlDbType.Int);
			param4.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param4);
			comm.ExecuteNonQuery();
			if((int)param4.Value>0)
				result=true;
			conn.Close();
			return result;
		}
		//通话的收费计算
		[WebMethod]
		public bool Call(string FromCard,string ToCard,DateTime StartTime,int Duration,
			string CallStatus,string ReceiveStatus)
		{
			bool result=false;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];			
			SqlConnection conn=new SqlConnection();
			conn.ConnectionString=ConnectionString;
			conn.Open();
			SqlCommand comm=new SqlCommand();
			comm.Connection=conn;
			comm.CommandText="usp_Call";
			comm.CommandType=CommandType.StoredProcedure;
			//定义参数
			SqlParameter param1=new SqlParameter("@FromCard",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=FromCard;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@ToCard",SqlDbType.Char,11);
			param2.Direction=ParameterDirection.Input;
			param2.Value=ToCard;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@StartTime",SqlDbType.DateTime);
			param3.Direction=ParameterDirection.Input;
			param3.Value=StartTime;
			comm.Parameters.Add(param3);
			SqlParameter param4=new SqlParameter("@Duration",SqlDbType.Int);
			param4.Direction=ParameterDirection.Input;
			param4.Value=Duration;
			comm.Parameters.Add(param4);
			SqlParameter param5=new SqlParameter("@CallStatus",SqlDbType.VarChar,15);
			param5.Direction=ParameterDirection.Input;
			param5.Value=CallStatus;
			comm.Parameters.Add(param5);
			SqlParameter param6=new SqlParameter("@ReceiveStatus",SqlDbType.VarChar,15);
			param6.Direction=ParameterDirection.Input;
			param6.Value=ReceiveStatus;
			comm.Parameters.Add(param6);
			SqlParameter param7=new SqlParameter("@Result",SqlDbType.Int);
			param7.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param7);
			comm.ExecuteNonQuery();
			if((int)param7.Value>0)
				result=true;
			return result;
		}
	}
}
