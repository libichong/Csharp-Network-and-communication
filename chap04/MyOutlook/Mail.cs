using System;

namespace MyOutlook
{
	/// <summary>
	/// Mail 的摘要说明。
	/// </summary>
	public class Mail
	{
		public static string IN_BOX = "收件箱";
		public static string OUT_BOX = "发件箱";
		public static string SENT_BOX = "已发送";
		public static string DRAFT_BOX = "草稿箱";
		public static string TRASH_BOX = "垃圾箱";

		public Mail()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//邮件ID
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

		//邮件的存储位置
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

		//邮件的主题
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

		//邮件的接收者
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

		//邮件的发送者
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

		//邮件的内容
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

		//邮件的时间
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
