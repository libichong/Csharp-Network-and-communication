using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace TeleCommServices
{
	/// <summary>
	///  OperatorManageServices的摘要说明。
	/// </summary>
	[WebService(Namespace="http://www.telecom.com")]
	public class OperatorManageServices : System.Web.Services.WebService
	{
		public OperatorManageServices()
		{
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
		//创建新卡
		[WebMethod]
		public void CreateCard(string CardNo,int CustomerID,string PUK,string PIN,
			string UserPwd,decimal Balance,DateTime Expiration)
		{
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];			
			SqlConnection conn=new SqlConnection();
			conn.ConnectionString=ConnectionString;
			conn.Open();
			SqlCommand comm=new SqlCommand();
			comm.Connection=conn;
			comm.CommandText="usp_CreateCard";
			comm.CommandType=CommandType.StoredProcedure;
			SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=CardNo;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@CustomerID",SqlDbType.Int);
			param2.Direction=ParameterDirection.Input;
			param2.Value=CustomerID;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@PUK",SqlDbType.Char,6);
			param3.Direction=ParameterDirection.Input;
			param3.Value=PUK;
			comm.Parameters.Add(param3);
			SqlParameter param4=new SqlParameter("@PIN",SqlDbType.VarChar,8);
			param4.Direction=ParameterDirection.Input;
			param4.Value=PIN;
			comm.Parameters.Add(param4);
			SqlParameter param5=new SqlParameter("@UserPwd",SqlDbType.VarChar,8);
			param5.Direction=ParameterDirection.Input;
			param5.Value=UserPwd;
			comm.Parameters.Add(param5);
			SqlParameter param6=new SqlParameter("@Balance",SqlDbType.Decimal,5);
			param6.Direction=ParameterDirection.Input;
			param6.Scale=2;
			param6.Value=Balance;
			comm.Parameters.Add(param6);
			SqlParameter param7=new SqlParameter("@Expiration",SqlDbType.DateTime);
			param7.Direction=ParameterDirection.Input;
			param7.Value=Expiration;
			comm.Parameters.Add(param7);
			comm.ExecuteNonQuery();
			conn.Close();
		}
		//删除已存在的旧卡
		[WebMethod]
		public void DeleteCard(string CardNo)
		{
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];			
			SqlConnection conn=new SqlConnection();
			conn.ConnectionString=ConnectionString;
			conn.Open();
			SqlCommand comm=new SqlCommand();
			comm.Connection=conn;
			comm.CommandText="usp_DeleteCard";
			comm.CommandType=CommandType.StoredProcedure;
			SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=CardNo;
			comm.Parameters.Add(param1);
			comm.ExecuteNonQuery();
			conn.Close();
		}
		//设置收费标准
		[WebMethod]
		public void SetCharge(decimal CallInCell,decimal CallRoaming,
			decimal CallInterCell,decimal SMInCell,decimal SMInterCell)
		{
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];			
			SqlConnection conn=new SqlConnection();
			conn.ConnectionString=ConnectionString;
			conn.Open();
			SqlCommand comm=new SqlCommand();
			comm.Connection=conn;
			comm.CommandText="usp_SetCharge";
			comm.CommandType=CommandType.StoredProcedure;
			SqlParameter param1=new SqlParameter("@CallInCell",SqlDbType.Decimal,5);
			param1.Direction=ParameterDirection.Input;
			param1.Scale=2;
			param1.Value=CallInCell;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@CallRoaming",SqlDbType.Decimal,5);
			param2.Direction=ParameterDirection.Input;
			param2.Scale=2;
			param2.Value=CallRoaming;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@CallInterCell",SqlDbType.Decimal,5);
			param3.Direction=ParameterDirection.Input;
			param3.Scale=2;
			param3.Value=CallInterCell;
			comm.Parameters.Add(param3);
			SqlParameter param4=new SqlParameter("@SMInCell",SqlDbType.Decimal,5);
			param4.Direction=ParameterDirection.Input;
			param4.Scale=2;
			param4.Value=SMInCell;
			comm.Parameters.Add(param4);
			SqlParameter param5=new SqlParameter("@SMInterCell",SqlDbType.Decimal,5);
			param5.Direction=ParameterDirection.Input;
			param5.Scale=2;
			param5.Value=SMInterCell;
			comm.Parameters.Add(param5);
			comm.ExecuteNonQuery();
			conn.Close();
		}
		//解除挂失
		[WebMethod]
		public bool DelistFromBlackList(string CardNo,string PUK,string UserPwd)
		{
			bool result=false;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			SqlCommand comm=new SqlCommand();
			conn.ConnectionString=ConnectionString;
			conn.Open();

			comm.CommandText="usp_DelistFromBlackList";
			comm.CommandType=CommandType.StoredProcedure;
			comm.Connection=conn;
			SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=CardNo;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@PUK",SqlDbType.Char,6);
			param2.Direction=ParameterDirection.Input;
			param2.Value=PUK;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@Result",SqlDbType.Int);
			param3.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param3);
			SqlParameter param4=new SqlParameter("@UserPwd",SqlDbType.VarChar,8);
			param4.Direction=ParameterDirection.Input;
			param4.Value=UserPwd;
			comm.Parameters.Add(param4);
			comm.ExecuteNonQuery();
			if((int)param3.Value>0)
				result=true;
			return result;
		}
		//查询一个月的详细话费
		[WebMethod]
		public DataSet QueryDetailBill(string CardNo,int year,int month)
		{
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			DataSet ds=new DataSet("QueryDetailBill");
			SqlDataAdapter adapter=new SqlDataAdapter();
			SqlCommand comm=new SqlCommand();
			conn.ConnectionString=ConnectionString;
			conn.Open();
			comm.CommandType=CommandType.StoredProcedure;
			comm.Connection=conn;

			SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=CardNo;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@Year",SqlDbType.Int);
			param2.Direction=ParameterDirection.Input;
			param2.Value=year;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@Month",SqlDbType.Int);
			param3.Direction=ParameterDirection.Input;
			param3.Value=month;
			comm.Parameters.Add(param3);
			//查询一个月的详细通话话单
			comm.CommandText="usp_QueryDetailCallBill";
			adapter.SelectCommand=comm;
			adapter.Fill(ds,"DetailCallBill");
			//查询一个月的详细短信话单
			comm.CommandText="usp_QueryDetailSMBill";
			adapter.SelectCommand=comm;
			adapter.Fill(ds,"DetailSMBill");
			return ds;
		}
		
	}
}
