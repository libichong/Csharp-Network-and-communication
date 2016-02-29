using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace TeleCommServices
{
	/// <summary>
	///  CustomerInquiryServices 的摘要说明。
	/// </summary>
	[WebService(Namespace="http://www.telecomm.com")]
	public class CustomerInquiryServices : System.Web.Services.WebService
	{
		public CustomerInquiryServices()
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

		
		//查询每月的短信话费
		[WebMethod]
		public decimal QuerySMBill(string CardNo,int year,int month)
		{
			decimal result=0;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			SqlCommand comm=new SqlCommand();
			conn.ConnectionString=ConnectionString;
			conn.Open();

			comm.Connection=conn;
			comm.CommandText="usp_QuerySMBill";
			comm.CommandType=CommandType.StoredProcedure;
			SqlParameter param1=new SqlParameter("@Year",SqlDbType.Int);
			param1.Direction=ParameterDirection.Input;
			param1.Value=year;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@Month",SqlDbType.Int);
			param2.Direction=ParameterDirection.Input;
			param2.Value=month;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@Total",SqlDbType.Decimal,10);
			param3.Scale=2;
			param3.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param3);
			SqlParameter param4=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param4.Direction=ParameterDirection.Input;
			param4.Value=CardNo;
			comm.Parameters.Add(param4);
			comm.ExecuteNonQuery();
			result=(decimal)param3.Value;
			return result;
		}
		//查询每月的通话话费
		[WebMethod]
		public decimal QueryCallBill(string CardNo,int year,int month)
		{
			decimal result=0;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			SqlCommand comm=new SqlCommand();
			conn.ConnectionString=ConnectionString;
			conn.Open();

			comm.Connection=conn;
			comm.CommandText="usp_QueryCallBill";
			comm.CommandType=CommandType.StoredProcedure;
			SqlParameter param1=new SqlParameter("@Year",SqlDbType.Int);
			param1.Direction=ParameterDirection.Input;
			param1.Value=year;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@Month",SqlDbType.Int);
			param2.Direction=ParameterDirection.Input;
			param2.Value=month;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@Total",SqlDbType.Decimal,10);
			param3.Scale=2;
			param3.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param3);
			SqlParameter param4=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param4.Direction=ParameterDirection.Input;
			param4.Value=CardNo;
			comm.Parameters.Add(param4);
			comm.ExecuteNonQuery();
			result=(decimal)param3.Value;
			return result;
		}
		//查询每月的总话费
		[WebMethod]
		public decimal QueryBill(string CardNo,int year,int month)
		{
			decimal result=0;
			result=QueryCallBill(CardNo,year,month)+
				QuerySMBill(CardNo,year,month);
			return result;
		}
		//查询SIM卡余额
		[WebMethod]
		public decimal QueryBalance(string CardNo)
		{
			decimal result;
			string ConnectionString=
				ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			conn.ConnectionString=ConnectionString;
			conn.Open();
			SqlCommand comm=new SqlCommand("usp_QueryBalance",conn);
			comm.CommandType=CommandType.StoredProcedure;
			
			SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=CardNo;
			comm.Parameters.Add(param1);

			SqlDataReader reader=comm.ExecuteReader();
			if(reader.Read())
			{
				result=reader.GetDecimal(0);
			}
			else
			{
				result=0;
			}
			reader.Close();
			conn.Close();
			return result;
		}
	
		/*修改PIN码*/
		[WebMethod]
		public bool UpdatePIN(string CardNo,string pwd)
		{
			bool result=false;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			SqlCommand comm=new SqlCommand();
			conn.ConnectionString=ConnectionString;
			conn.Open();

			comm.Connection=conn;
			comm.CommandText="usp_UpdatePIN";
			comm.CommandType=CommandType.StoredProcedure;
			SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=CardNo;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@Pwd",SqlDbType.VarChar,8);
			param2.Direction=ParameterDirection.Input;
			param2.Value=pwd;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@RC",SqlDbType.Int);
			param3.Direction=ParameterDirection.ReturnValue;
			comm.Parameters.Add(param3);
			comm.ExecuteNonQuery();
			if((int)param3.Value==0)
				result=true;
			return result;
		}

		//验证冲值卡是否正确
		private string VerifyRechargeCardNo(string RechargeCardNo,string Pwd,
			out decimal FaceValue,out Int16 Duration)
		{
			string CardNo=null;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			SqlCommand comm=new SqlCommand();
			conn.ConnectionString=ConnectionString;
			conn.Open();

			comm.CommandText="usp_VerifyRechargeCardNo";
			comm.CommandType=CommandType.StoredProcedure;
			comm.Connection=conn;
			SqlParameter param1=new SqlParameter("@RechargeCardNo",SqlDbType.VarChar,10);
			param1.Direction=ParameterDirection.InputOutput;
			param1.Value=RechargeCardNo;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@Pwd",SqlDbType.VarChar,10);
			param2.Direction=ParameterDirection.Input;
			param2.Value=Pwd;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@FaceValue",SqlDbType.Decimal,3);
			param3.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param3);
			SqlParameter param4=new SqlParameter("@Duration",SqlDbType.SmallInt);
			param4.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param4);
			SqlParameter param5=new SqlParameter("@Result",SqlDbType.Int);
			param5.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param5);
			comm.ExecuteNonQuery();
			if((int)param5.Value>0)
			{
				CardNo=param1.Value.ToString();
				FaceValue=(decimal)param3.Value;
				Duration=(Int16)param4.Value;
			}
			else
			{
				CardNo=null;
				FaceValue=0;
				Duration=0;
			}
			return CardNo;
		}
		//冲值
		[WebMethod]
		public bool Recharge(string CardNo,string RechargeCardNo,string Pwd)
		{
			bool result=false;
			decimal FaceValue;
			Int16 Duration;
			string RecharCardNo=null;
			RecharCardNo=VerifyRechargeCardNo(RechargeCardNo,Pwd,out FaceValue,out Duration);
			if(RecharCardNo!=null)
			{
				string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
				SqlConnection conn=new SqlConnection();
				SqlCommand comm=new SqlCommand();
				conn.ConnectionString=ConnectionString;
				conn.Open();

				comm.CommandText="usp_Recharge";
				comm.CommandType=CommandType.StoredProcedure;
				comm.Connection=conn;
				SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
				param1.Direction=ParameterDirection.Input;
				param1.Value=CardNo;
				comm.Parameters.Add(param1);
				SqlParameter param2=new SqlParameter("@RechargeCardNo",SqlDbType.VarChar,10);
				param2.Direction=ParameterDirection.Input;
				param2.Value=RecharCardNo;
				comm.Parameters.Add(param2);
				SqlParameter param3=new SqlParameter("@FaceValue",SqlDbType.Decimal,3);
				param3.Direction=ParameterDirection.Input;
				param3.Value=FaceValue;
				comm.Parameters.Add(param3);
				SqlParameter param4=new SqlParameter("@Duration",SqlDbType.SmallInt);
				param4.Direction=ParameterDirection.Input;
				param4.Value=Duration;
				comm.Parameters.Add(param4);
				SqlParameter param5=new SqlParameter("@Result",SqlDbType.Int);
				param5.Direction=ParameterDirection.Output;
				comm.Parameters.Add(param5);
				comm.ExecuteNonQuery();
				if((int)param5.Value>0)
					result=true;
			}
			return result;
		}

		//解除暂时锁定
		[WebMethod]
		public bool Unlock(string CardNo,string PUK)
		{
			bool result=false;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			SqlCommand comm=new SqlCommand();
			conn.ConnectionString=ConnectionString;
			conn.Open();

			comm.CommandText="usp_Unlock";
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
			comm.ExecuteNonQuery();
			if((int)param3.Value>0)
				result=true;
			return result;
		}
		//挂失
		[WebMethod]
		public bool ReportOfLost(string CardNo)
		{
			bool result=false;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			SqlCommand comm=new SqlCommand();
			conn.ConnectionString=ConnectionString;
			conn.Open();

			comm.CommandText="usp_ReportOfLost";
			comm.CommandType=CommandType.StoredProcedure;
			comm.Connection=conn;
			SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=CardNo;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@Result",SqlDbType.Int);
			param2.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param2);
			comm.ExecuteNonQuery();
			if((int)param2.Value>0)
				result=true;
			return result;
		}
		//验证卡号是否正确
		[WebMethod]
		public bool VerifyCard(string CardNo,string PIN)
		{
			bool result=false;
			string ConnectionString=ConfigurationSettings.AppSettings["ConnectionString"];
			SqlConnection conn=new SqlConnection();
			SqlCommand comm=new SqlCommand();
			conn.ConnectionString=ConnectionString;
			conn.Open();

			comm.CommandText="usp_VerifyCard";
			comm.CommandType=CommandType.StoredProcedure;
			comm.Connection=conn;
			SqlParameter param1=new SqlParameter("@CardNo",SqlDbType.Char,11);
			param1.Direction=ParameterDirection.Input;
			param1.Value=CardNo;
			comm.Parameters.Add(param1);
			SqlParameter param2=new SqlParameter("@PIN",SqlDbType.VarChar,8);
			param2.Direction=ParameterDirection.Input;
			param2.Value=PIN;
			comm.Parameters.Add(param2);
			SqlParameter param3=new SqlParameter("@Result",SqlDbType.Int);
			param3.Direction=ParameterDirection.Output;
			comm.Parameters.Add(param3);
			comm.ExecuteNonQuery();
			if((int)param3.Value>0)
				result=true;
			return result;
		}
	}
}
