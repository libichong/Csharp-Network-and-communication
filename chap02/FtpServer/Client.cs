using System;
using System.Net.Sockets;
using System.Threading;
using System.Data;
using System.Collections;
using System.Net;


namespace FtpServer
{
	/// <summary>
	/// Client ��ժҪ˵����
	/// </summary>
	public class Client
	{	
		int dataPort = 5380; //21, 21
		internal FtpServerForm server;
		private Request request;
		
		
		//��ǰ���ӵ�״̬��
		internal bool isLogin = false;
		
		//����Ŀ¼
		internal string workingDir;
	
		private string user;
		public string User
		{
			get
			{
				return user;
			}
			set
			{
				user=value;
			}
		}

		private string password;
		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password=value;
			}
		}

		private Socket currentSocket = null;
		public  Socket CurrentSocket
		{
			get
			{
				return currentSocket;
			}
			set
			{
				currentSocket=value;
			}
		}
		
		private string ipAddress;
		public  string IpAddress
		{
			get
			{
				return ipAddress;
			}
			set
			{
				ipAddress=value;
			}
		}

		private int port;
		public  int Port
		{
			get
			{
				return port;
			}
			set
			{
				port=value;
			}
		}

		private bool stopFlag;
		public  bool StopFlag
		{
			get
			{
				return stopFlag;
			}
			set
			{
				stopFlag=value;
			}
		}

		private string fileName;
		public string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				fileName=value;
			}
		}

		private string currentCmd;
		public string CurrentCmd
		{
			get
			{
				return currentCmd;
			}
			set
			{
				currentCmd=value;
			}
		}

		public Client(FtpServerForm server, Socket clientSocket)
		{
			this.server = server;
			this.currentSocket = clientSocket;
			ipAddress = getRemoteIPAddress();
			port = server.port;
			request = new Request(this);
			workingDir = FtpServerForm.ROOT_DIR;
		}


						
		private string getRemoteIPAddress()
		{
			return ((IPEndPoint)currentSocket.RemoteEndPoint).
				Address.ToString();
		}

		//ServiceClient�������ںͿͻ��˽�������ͨ�ţ��������տͻ��˵�����
		//���ݲ�ͬ���������ִ����Ӧ�Ĳ������������������ص��ͻ���
		public void ServiceClient()
		{
			stopFlag = false;
			isLogin = false;

			//���ͻ�ӭ��Ϣ
			sendMsg("220 ��ӭʹ��FTP�����������Ѿ��������˷�����...");
			
			try
			{
				//�û���
				if (request.parseCmd(receiveCmd()) != Request.LOGIN_USER)
				{
					sendMsg("221 �������.");
					this.CurrentSocket.Close();
					server.removeClient(this);
					return;
				}
				
				sendMsg("331 �������û�" + User + "�ĵ�¼����");
				//����
				if (request.parseCmd(receiveCmd()) != Request.LOGIN_PASS)
				{
					sendMsg("221 �������.");
					this.CurrentSocket.Close();
					server.removeClient(this);
					return;
				}
				
				//�ж��û����������Ƿ���ȷ
				if (((user == "test") && (password == "123")) ||
				    (user == "guest"))
				{
					this.isLogin = true;
					sendMsg("230 User " + User + " �Ѿ���¼.");
				}
				else
				{
					sendMsg("530 �û��������������.");
					currentSocket.Close();
					server.removeClient(this);
					return;
				}	
			}
			catch(Exception e)
			{
				Console.WriteLine("��¼ʱ�����쳣��"+ e.ToString());
				this.CurrentSocket.Close();
				server.removeClient(this);
				return;
			}


			//��ѭ�������ϵ���ͻ��˽��н�����ֱ���ͻ��˷�����QUIT�����
			//��stopFlag��Ϊfalse���˳�ѭ�����ر����ӣ�����ֹ��ǰ�߳�
			while(!stopFlag && FtpServerForm.SocketServiceFlag)
			{
				if (!isLogin) 
				{
					break;
				}
				
				try
				{
					if (currentSocket.Connected &&
						currentSocket.Available>0)
					{
						request.parseCmd(receiveCmd());
					}
					Thread.Sleep(500);
				} 
				catch(Exception e)
				{
					Console.WriteLine("�����쳣��"+ e.ToString());
					this.CurrentSocket.Close();
					server.removeClient(this);
					break;
				}
			}
			this.CurrentSocket.Close();
			server.removeClient(this);
		}
		
		private string[] receiveCmd() 
		{
			string[] tokens=null;

			//�������ݲ�����buff������
			byte[] buff = new byte[1024];
			currentSocket.Receive(buff);
			
			//���ַ�����ת��Ϊ�ַ���
			string clientCommand=System.Text.Encoding.ASCII.GetString(buff);
			clientCommand = clientCommand.Trim("\0".ToCharArray());
			clientCommand = clientCommand.Trim("\r\n".ToCharArray());

			if (clientCommand.Length > 0) 
			{
				//tokens[0]�б����������־����LIST��DIR��RETR��QUIT�ȣ�
				if (clientCommand.IndexOf(" ")>-1)
				{
					tokens=clientCommand.Split(new Char[]{' '});
				}
				else
				{
					tokens=clientCommand.Split("\r\n".ToCharArray());
				}
				
				this.currentCmd = tokens[0];
			}
			return tokens;
		}

		//SendToClient()����ʵ������ͻ��˷�����������Ĺ���
		internal void sendMsg(string msg)
		{
			string resmsg = msg + "\r\n";
			System.Byte[] message=System.Text.Encoding.Default.GetBytes(
				resmsg.ToCharArray());
			currentSocket.Send(message,message.Length,0);
		}

		//ͨ��һ����ʱSocket��������
		internal void sendMsgByTempSocket(string msg)
		{
			System.Byte[] message=System.Text.Encoding.Default.GetBytes(
				msg.ToCharArray());
			sendMsgByTempSocket(message);
		}
		
		//ͨ��һ����ʱSocket��������
		internal void sendMsgByTempSocket(byte[] msg)
		{			
			Socket tempSocket=getTempSocket();

			if (tempSocket.Connected)
			{
				tempSocket.Send(msg, msg.Length,0);
			}
			tempSocket.Close();
		}	
		
		internal Socket getTempSocket()
		{
			Socket tempSocket=null;
			if (request.transferType == Request.PASV)
			{
				IPAddress ipAdd=IPAddress.Parse(server.ip);
				//�����������׽���
				TcpListener listener=new TcpListener(ipAdd, dataPort);
				//��ʼ�����������˿�
				listener.Start();
				int timeout = 5000;
				while(timeout-->0)
				{
					if (listener.Pending())
					{
						tempSocket=listener.AcceptSocket();
						break;
					}
					try
					{
						Thread.Sleep(500);
					} 
					catch (Exception e) {}
				}
			}
			else
			{
				tempSocket = new Socket(AddressFamily.InterNetwork,
					SocketType.Stream,ProtocolType.Tcp);
				tempSocket.SetSocketOption (SocketOptionLevel.Socket, 
					SocketOptionName.SendTimeout, 5000);	
				IPAddress ipAdd=IPAddress.Parse(this.ipAddress);
				IPEndPoint hostEndPoint = new IPEndPoint(ipAdd, port);
				tempSocket.Connect(hostEndPoint);
			}
			return tempSocket;
		}	
	}
}
