using System;
using System.Net;
using System.Net.Sockets;

namespace MyOutlook
{
	/// <summary>
	/// MailOperation 的摘要说明。
	/// </summary>
	public interface Operation
	{
		
		bool Connect(MailAccount ma, bool isReceive, ref string repMsg);
		Mail Receive(ref string repMsg, int mailid);
		bool Pop3Login(ref string repMsg);
		bool SmtpLogin(ref string repMsg);
		int GetMailNumber(ref string repMsg);
		bool ListMails(ref string repMsg);
		bool Close(ref string repMsg);
		bool Send(Mail mail, ref string repMsg);
	}
}
