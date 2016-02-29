using System;
using System.Collections;

using System.Data.OleDb;
using System.Data;

namespace MyOutlook
{
	/// <summary>
	/// MailStore 的摘要说明。
	/// </summary>
	public class MailStore
	{
		public MailStore(System.Data.OleDb.OleDbConnection cnt,
			System.Data.OleDb.OleDbDataAdapter adapter)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			connection = cnt;
			this.adapter = adapter;

		}

		private System.Data.OleDb.OleDbConnection connection;
		private System.Data.OleDb.OleDbDataAdapter adapter;


		public Hashtable getMails() 
		{
			Hashtable mails = new Hashtable();

			if (mails.Count<1) 
			{
				loadMails(mails);
			}
			return mails;
		}

		private void loadMails(Hashtable  mails) 
		{
			//从数据库中读取所有的邮件
			string mySelectQuery = "SELECT * FROM Mails ORDER BY MailStorePosition";
			System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(mySelectQuery, connection);
			cmd.CommandTimeout = 20;

			mails.Clear();
			
			//打开连接
			if (connection.State==System.Data.ConnectionState.Closed)
			{
				connection.Open();
			}

			System.Data.OleDb.OleDbDataReader dr;
			try 
			{
				dr = cmd.ExecuteReader();
			}
			catch 
			{
				return;
			}

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Mail m = new Mail();
					m.MailID = System.Convert.ToString(dr["MailID"]);
					m.MailStorePosition = System.Convert.ToString(dr["MailStorePosition"]);
					m.Recipient = System.Convert.ToString(dr["ReceiveMailBox"]);
					m.Sender = System.Convert.ToString(dr["SendMailBox"]);
					m.Subject = System.Convert.ToString(dr["Title"]);
					m.Time = System.Convert.ToString(dr["Time"]);
					m.MailContent = System.Convert.ToString(dr["Content"]);
					m.Cc = System.Convert.ToString(dr["CC"]);
					m.Bcc = System.Convert.ToString(dr["BCC"]);

					mails.Add(m.MailID, m);
				}
			}


			//关闭连接
			dr.Close();
		}

		public Mail addNew(Mail mail) 
		{
			//打开连接
			if (connection.State==System.Data.ConnectionState.Closed)
			{
				connection.Open();
			}
			DataSet ds = new DataSet();
			adapter.Fill(ds, "Mails");
			DataTable dt = ds.Tables[0];
			
			DataRow dr = dt.NewRow();
			dt.Rows.Add(dr);

			dr.BeginEdit();

			dr["MailStorePosition"] = mail.MailStorePosition;
			dr["SendMailBox"] = mail.Sender;
			dr["ReceiveMailBox"] = mail.Recipient;
			dr["Title"] = mail.Subject;
			dr["Time"] = mail.Time;
			dr["Content"] = mail.MailContent;
			dr["CC"] = mail.Cc;
			dr["BCC"] = mail.Bcc;
		
			dr.EndEdit();
			this.adapter.Update(ds, "Mails");
			ds.AcceptChanges();

			//获得添加邮件的ID
			adapter.Fill(ds, "Mails");
			dt = ds.Tables[0];
			dr = dt.Rows[dt.Rows.Count-1];
			Object o = dr[0];
			int a = (int)dr["MailID"];
			mail.MailID = System.Convert.ToString(dr["MailID"]);

			
			return mail;
		}
		
		public void addAll(Hashtable mails) {
			if (mails.Count>0) 
			{
				DataSet ds = new DataSet();
				adapter.Fill(ds, "Mails");
				DataTable dt = ds.Tables[0];

				System.Collections.IEnumerator myEnumerator = mails.GetEnumerator();
				while (myEnumerator.MoveNext())
				{
					Mail mail = (Mail)myEnumerator.Current;
					
					DataRow dr = dt.NewRow();
					dt.Rows.Add(dr);

					dr.BeginEdit();

					dr["MailStorePosition"] = mail.MailStorePosition;
					dr["SendMailBox"] = mail.Sender;
					dr["ReceiveMailBox"] = mail.Recipient;
					dr["Title"] = mail.Subject;
					dr["Time"] = mail.Time;
					dr["Content"] = mail.MailContent;
					dr["CC"] = mail.Cc;
					dr["BCC"] = mail.Bcc;

					dr.EndEdit();
				}

				
				this.adapter.Update(ds, "Mails");
				ds.AcceptChanges();
			}
		
		}

		public void update(Mail mail) {

			string sqlStr = "UPDATE Mails SET MailStorePosition='" + 
				mail.MailStorePosition +
				"' WHERE MailID=" + mail.MailID;
			System.Data.OleDb.OleDbCommand cmd = new 
				System.Data.OleDb.OleDbCommand(sqlStr, connection);
			cmd.CommandTimeout = 20;

			//打开连接
			if (connection.State==System.Data.ConnectionState.Closed)
			{
				connection.Open();
			}

			cmd.ExecuteNonQuery();
		
		}

		//从数据库中删除邮件
		public void delete(Mail mail) {
			string sqlStr = "DELETE FROM Mails WHERE MailID=" + mail.MailID;
			System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sqlStr, connection);
			cmd.CommandTimeout = 20;

			//打开连接
			if (connection.State==System.Data.ConnectionState.Closed)
			{
				connection.Open();
			}

			cmd.ExecuteNonQuery();
		}

	}
}
