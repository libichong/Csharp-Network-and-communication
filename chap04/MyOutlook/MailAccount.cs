using System;

namespace MyOutlook
{
	/// <summary>
	/// MailAccount ��ժҪ˵����
	/// </summary>
	public class MailAccount
	{
		public MailAccount()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}


		//����ID
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
		
		//�����ʺ�
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

		//������������ַ
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
		
		//�����������˿�
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
		
		//������������¼�û���
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

		//������������¼����
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

		//�ռ���������ַ
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
		
		//�ռ��������˿�
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
		
		//�ռ���������¼�û���
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

		//�ռ���������¼����
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

		//�����������Ƿ���Ҫ��֤
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

		//�����������Ƿ�ʹ�úͽ��շ�������ͬ������
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

		//�����ʼ����Ƿ�ɾ���������ϵ��ʼ�
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
