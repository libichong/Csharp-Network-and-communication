using System;

namespace MyOutlook
{
	/// <summary>
	/// Mail ��ժҪ˵����
	/// </summary>
	public class Mail
	{
		public static string IN_BOX = "�ռ���";
		public static string OUT_BOX = "������";
		public static string SENT_BOX = "�ѷ���";
		public static string DRAFT_BOX = "�ݸ���";
		public static string TRASH_BOX = "������";

		public Mail()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		//�ʼ�ID
		private string mailID;
		public string MailID
		{
			get
			{
				return mailID;
			}
			set
			{
				mailID=value;
			}
		}

		//�ʼ��Ĵ洢λ��
		private string mailStorePosition;
		public string MailStorePosition
		{
			get
			{
				return mailStorePosition;
			}
			set
			{
				mailStorePosition=value;
			}
		}

		//�ʼ�������
		private string subject;
		public string Subject
		{
			get
			{
				return subject;
			}
			set
			{
				subject=value;
			}
		}

		//�ʼ��Ľ�����
		private string recipient;
		public string Recipient
		{
			get
			{
				return recipient;
			}
			set
			{
				recipient=value;
			}
		}

		//�ʼ��ķ�����
		private string sender;
		public string Sender
		{
			get
			{
				return sender;
			}
			set
			{
				sender=value;
			}
		}

		//�ʼ�������
		private string mailContent;
		public string MailContent
		{
			get
			{
				return mailContent;
			}
			set
			{
				mailContent=value;
			}
		}

		//�ʼ���ʱ��
		private string time;
		public string Time
		{
			get
			{
				return time;
			}
			set
			{
				time=value;
			}
		}

		//CC
		private string cc;
		public string Cc
		{
			get
			{
				return cc;
			}
			set
			{
				cc=value;
			}
		}

		//BCC
		private string bcc;
		public string Bcc
		{
			get
			{
				return bcc;
			}
			set
			{
				bcc=value;
			}
		}
	}
}
