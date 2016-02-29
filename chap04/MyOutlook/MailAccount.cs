using System;

namespace MyOutlook
{
	/// <summary>
	/// MailAccount 的摘要说明。
	/// </summary>
	public class MailAccount
	{
		public MailAccount()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		//邮箱ID
		private int mailAccountID;
		public int MailAccountID
		{
			get
			{
				return mailAccountID;
			}
			set
			{
				mailAccountID=value;
			}
		}
		
		//邮箱帐号
		private string account;
		public string Account
		{
			get
			{
				return account;
			}
			set
			{
				account=value;
			}
		}

		//发件服务器地址
		private string outServer;
		public string OutServer
		{
			get
			{
				return outServer;
			}
			set
			{
				outServer=value;
			}
		}
		
		//发件服务器端口
		private string outServerPort;
		public string OutServerPort
		{
			get
			{
				return outServerPort;
			}
			set
			{
				outServerPort=value;
			}
		}
		
		//发件服务器登录用户名
		private string outServerUser;
		public string OutServerUser
		{
			get
			{
				return outServerUser;
			}
			set
			{
				outServerUser=value;
			}
		}

		//发件服务器登录口令
		private string outServerPassword;
		public string OutServerPassword
		{
			get
			{
				return outServerPassword;
			}
			set
			{
				outServerPassword=value;
			}
		}

		//收件服务器地址
		private string inServer;
		public string InServer
		{
			get
			{
				return inServer;
			}
			set
			{
				inServer=value;
			}
		}
		
		//收件服务器端口
		private string inServerPort;
		public string InServerPort
		{
			get
			{
				return inServerPort;
			}
			set
			{
				inServerPort=value;
			}
		}
		
		//收件服务器登录用户名
		private string inServerUser;
		public string InServerUser
		{
			get
			{
				return inServerUser;
			}
			set
			{
				inServerUser=value;
			}
		}

		//收件服务器登录口令
		private string intServerPassword;
		public string InServerPassword
		{
			get
			{
				return intServerPassword;
			}
			set
			{
				intServerPassword=value;
			}
		}

		//发件服务器是否需要认证
		private bool outServerRequireAuth;
		public bool OutServerRequireAuth
		{
			get
			{
				return outServerRequireAuth;
			}
			set
			{
				outServerRequireAuth=value;
			}
		}

		//发件服务器是否使用和接收服务器相同的设置
		private bool isTheSameWithIncoming;
		public bool IsTheSameWithIncoming
		{
			get
			{
				return isTheSameWithIncoming;
			}
			set
			{
				isTheSameWithIncoming=value;
			}
		}

		//接收邮件后是否删除服务器上的邮件
		private bool isLeaveMessage;
		public bool IsLeaveMessage
		{
			get
			{
				return isLeaveMessage;
			}
			set
			{
				isLeaveMessage=value;
			}
		}

	}
}
