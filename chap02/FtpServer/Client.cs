using System;
using System.Net.Sockets;
using System.Threading;
using System.Data;
using System.Collections;
using System.Net;


namespace FtpServer
{
	/// <summary>
	/// Client 的摘要说明。
	/// </summary>
	public class Client
	{	
		int dataPort = 5380; //21, 21
		internal FtpServerForm server;
		private Request request;
		
		
		//当前连接的状态：
		internal bool isLogin = false;
		
		//工作目录
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

		//ServiceClient方法用于和客户端进行数据通信，包括接收客户端的请求，
		//根据不同的请求命令，执行相应的操作，并将处理结果返回到客户端
		public void ServiceClient()
		{
			stopFlag = false;
			isLogin = false;

			//发送欢迎消息
			sendMsg("220 欢迎使用FTP服务器，您已经连接上了服务器...");
			
			try
			{
				//用户名
				if (request.parseCmd(receiveCmd()) != Request.LOGIN_USER)
				{
					sendMsg("221 命令错误.");
					this.CurrentSocket.Close();
					server.removeClient(this);
					return;
				}
				
				sendMsg("331 请输入用户" + User + "的登录密码");
				//密码
				if (request.parseCmd(receiveCmd()) != Request.LOGIN_PASS)
				{
					sendMsg("221 命令错误.");
					this.CurrentSocket.Close();
					server.removeClient(this);
					return;
				}
				
				//判断用户名和密码是否正确
				if (((user == "test") && (password == "123")) ||
				    (user == "guest"))
				{
					this.isLogin = true;
					sendMsg("230 User " + User + " 已经登录.");
				}
				else
				{
					sendMsg("530 用户名或者密码错误.");
					currentSocket.Close();
					server.removeClient(this);
					return;
				}	
			}
			catch(Exception e)
			{
				Console.WriteLine("登录时发生异常："+ e.ToString());
				this.CurrentSocket.Close();
				server.removeClient(this);
				return;
			}


			//用循环来不断地与客户端进行交互，直到客户端发出“QUIT”命令，
			//将stopFlag置为false，退出循环，关闭连接，并中止当前线程
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
					Console.WriteLine("发生异常："+ e.ToString());
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

			//接收数据并存入buff数组中
			byte[] buff = new byte[1024];
			currentSocket.Receive(buff);
			
			//将字符数组转化为字符串
			string clientCommand=System.Text.Encoding.ASCII.GetString(buff);
			clientCommand = clientCommand.Trim("\0".ToCharArray());
			clientCommand = clientCommand.Trim("\r\n".ToCharArray());

			if (clientCommand.Length > 0) 
			{
				//tokens[0]中保存了命令标志符（LIST、DIR、RETR或QUIT等）
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

		//SendToClient()方法实现了向客户端发送命令请求的功能
		internal void sendMsg(string msg)
		{
			string resmsg = msg + "\r\n";
			System.Byte[] message=System.Text.Encoding.Default.GetBytes(
				resmsg.ToCharArray());
			currentSocket.Send(message,message.Length,0);
		}

		//通过一个临时Socket发送数据
		internal void sendMsgByTempSocket(string msg)
		{
			System.Byte[] message=System.Text.Encoding.Default.GetBytes(
				msg.ToCharArray());
			sendMsgByTempSocket(message);
		}
		
		//通过一个临时Socket发送数据
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
				//创建服务器套接字
				TcpListener listener=new TcpListener(ipAdd, dataPort);
				//开始监听服务器端口
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
