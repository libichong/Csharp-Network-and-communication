using System;
using System.IO;
using System.Net.Sockets;

namespace FtpServer
{
	/// <summary>
	/// Request ��ժҪ˵����
	/// </summary>
	public class Request
	{
		public const int LOGIN_USER = 0;				//USER
		public const int LOGIN_PASS = 1;				//PASS
		public const int SYSTEM  = 2;					//SYST
		public const int RESTART = 3;					//REST
		public const int RETRIEVE = 4;					//RETR
		public const int STORE = 5;						//STOR
		public const int RENAME_FROM = 6;				//RNFR
		public const int RENAME_TO = 7;					//RNTO
		public const int ABORT = 8;						//ABOR
		public const int DELETE = 9;					//DELE
		public const int XMKD = 10;					//XMKD
		public const int PWD = 11;						//PWD
		public const int LIST = 12;						//LIST
		public const int NOOP = 13;						//NOOP 
		public const int REPRESENTATION_TYPE = 14;		//TYPE
		public const int LOGOUT = 15;					//QUIT
		public const int DATA_PORT = 16;				//PORT
		public const int PASSIVE = 17; 					//PASV
		public const int CWD = 18;						//CWD
		public const int CHANGE_DIR_UP = 19;			//CDUP
		public const int UNKNOWN_CMD = 99;				//unknow cmd

		public const int PORT = 0;
		public const int PASV = 1;
		public const int ERROR = -1;

		private string representationType;
		internal int transferType;
		
		private Client client;

		//FTP�ͻ��˵���������
		public int requestType;


		public Request(Client client)
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			requestType = ERROR;
			transferType = PORT;
			this.client = client;
		}

		public int RequestType
		{
			get
			{
				return requestType;
			}
			set
			{
				requestType=value;
			}
		}

		public int parseCmd(string[] tokens) 
		{

			if (tokens == null || tokens.Length < 1) 
			{
				return ERROR;
			}
			
			for (int i=0;i<tokens.Length;i++) 
			{
				tokens[i] = tokens[i].Trim("\0".ToCharArray());
				tokens[i] = tokens[i].Trim("\r\n".ToCharArray());
			}
			
			Console.WriteLine("�������" + tokens[0]);

			if (tokens[0].ToUpper() == "USER") 
			{
				requestType = LOGIN_USER;
				client.User = tokens[1];
			}
			
			else if (tokens[0].ToUpper() == "PASS") 
			{
				requestType = LOGIN_PASS;
				client.Password = tokens[1];
			}
			else if (tokens[0].ToUpper() == "SYST") 
			{
				requestType = SYSTEM ;
				client.sendMsg("215 UNIX Type: L8");
			}
			else if (tokens[0].ToUpper() == "RETR") 
			{
				requestType = RETRIEVE;
				client.FileName = tokens[1];
				sendFile(tokens[1]);
			}
			else if (tokens[0].ToUpper() == "STOR") 
			{
				requestType = STORE;
				client.FileName = tokens[1];
				receiveFile(tokens[1]);
			}
			else if (tokens[0].ToUpper() == "RNFR") 
			{
				requestType = RENAME_FROM;
				client.FileName = tokens[1];
				client.sendMsg("350");
			}
			else if (tokens[0].ToUpper() == "RNTO") 
			{
				requestType = RENAME_TO;
				rename(client.FileName, tokens[1]);
				client.FileName = tokens[1];
			}
			else if (tokens[0].ToUpper() == "XMKD") 
			{
				requestType = XMKD;
				client.FileName = tokens[1];
				createDir(tokens[1]);
			}
			else if (tokens[0].ToUpper() == "DELE") 
			{
				requestType = DELETE;
				client.FileName = tokens[1];
				delete(tokens[1]);
			}
			else if ((tokens[0].ToUpper() == "PWD") ||
				(tokens[0].ToUpper().IndexOf("XPWD")>-1))
			{
				requestType = PWD;
				client.sendMsg("257 ��ǰĿ¼\"" + getDir() + "\"");
			}
			else if (tokens[0].ToUpper() == "LIST" ||
				 tokens[0].ToUpper() == "NLST" ) 
			{
				requestType = LIST;
				client.sendMsg("150 ��ʾĿ¼��Ϣ");
				sendDirMsg();
				client.sendMsg("226 ��ʾ���");
			}
			else if (tokens[0].ToUpper() == "CWD") 
			{
				requestType = CWD;
				client.FileName = tokens[1];
				gotoDir(tokens);
			}
			else if (tokens[0].ToUpper() == "NOOP") 
			{
				requestType = NOOP;
				client.sendMsg("200 NOOP����ɹ�");
			}
			else if (tokens[0].ToUpper() == "TYPE") 
			{
				requestType = REPRESENTATION_TYPE;
				representationType = tokens[1];
				client.sendMsg("200");
			}
			else if (tokens[0].ToUpper() == "QUIT") 
			{
				requestType = LOGOUT;
				client.isLogin = false;
				client.sendMsg("221 �˳���¼");
			}
			else if (tokens[0].ToUpper() == "PORT") 
			{
				requestType = DATA_PORT;
				updatePort(tokens);
				client.sendMsg("200");
			}
			else if (tokens[0].ToUpper() == "PASV") 
			{
				requestType = PASSIVE;
				transferType = PASV;
				string ip = client.server.ip.Replace(".", ",");
				ip += ",21,21";
				client.sendMsg("227 ����PASVģʽ. " + ip);
			}
			else 
			{
				requestType = UNKNOWN_CMD;
				client.sendMsg("221 δ֪������");
			}


			return requestType;
		}

		private void updatePort(string[] tokens) 
		{
			string[] data;
			if (tokens.Length==2) 
			{
				data = tokens[1].Split(new Char[]{','});
			} 
			else if (tokens.Length==3)
			{
				data = tokens[2].Split(new Char[]{','});
			}
			else
			{
				return;
			}


			//�ͻ���IP��ַ��n1.n2 .n3 .n4���Ͷ˿ڣ�n5��256+n6��
			int n6 =  System.Convert.ToInt32(data[5]);
			int n5 =  System.Convert.ToInt32(data[4]);
			client.Port = n5*256+n6;

			string ip = data[0] + "." +
				data[1] + "." +
				data[2] + "." +
				data[3];

			client.IpAddress = ip;
		}
				
		// ��õ�ǰĿ¼
		private string getDir() 
		{
			string dir = client.workingDir;
			dir = dir.Remove(0, FtpServerForm.ROOT_DIR.Length);
			dir = dir.Replace("\\", "/");
			if (dir == "")
			{
				dir = "/";
			}
			return dir;	

		}

		//��ת������Ŀ¼
		private void gotoDir(String[] tokens)
		{
			
			if (tokens.Length>1)
			{
				string dir = trimEnd(tokens[1]);
				
				if (dir == "..") 
				{
					//ת����һ��Ŀ¼
					if (client.workingDir != FtpServerForm.ROOT_DIR)
					{
						//�����ǰĿ¼���Ǹ�Ŀ¼����ת����һ��Ŀ¼
						try 
						{
							DirectoryInfo directoryInfo =
								Directory.GetParent(client.workingDir);

							client.workingDir = directoryInfo.FullName;
							client.sendMsg("257 ��ǰĿ¼\"" + getDir() + "\"");
						}
						catch (ArgumentNullException) 
						{
							System.Console.WriteLine("·��Ϊ��");
						}
						catch (ArgumentException) 
						{
							System.Console.WriteLine("��ǰ����·����һ�����ַ�����" +
								"·����ֻ�ܰ����ո���������κ���Ч���ַ���");
						}
					}
					else
					{
						client.sendMsg("�Ѿ��Ǹ�Ŀ¼�ˣ�����ִ�иò���");
					}
				}
				else if (dir[0] == '/')
				{
					//�Ƿ�Ӹ�Ŀ¼��ʼ
					dir = dir.TrimStart("/".ToCharArray());
					dir = FtpServerForm.ROOT_DIR + dir;
					if (Directory.Exists(dir))
					{
						client.workingDir = dir;
						client.sendMsg("257 ��ǰĿ¼\"" + getDir() + "\"");
					} 
					else
					{
						client.sendMsg("Ŀ¼������");
					}
				}
				else if (dir == ".")
				{
					client.sendMsg("257 ��ǰĿ¼\"" + getDir() + "\"");
				}
				else 
				{
					//����Ŀ¼
					if (client.workingDir[client.workingDir.Length-1] != '\\')
					{
						client.workingDir += "\\";
					}
					dir = client.workingDir + dir;
					if (Directory.Exists(dir))
					{
						client.workingDir = dir;
						client.sendMsg("257 ��ǰĿ¼\"" + getDir() + "\"");
					}
					else 
					{
						client.sendMsg("Ŀ¼������");
					}
				}
			}
			else
			{
				client.sendMsg("257 ��ǰĿ¼\"" + getDir() + "\"");
			}
		}

	  	// �б�ǰĿ¼�ļ�
		private void sendDirMsg()
		{
			try 
			{
				string[] dirs = Directory.GetDirectories(client.workingDir);
				string[] files = Directory.GetFiles(client.workingDir);

				string msg="";
				for(int i=0;i<files.Length;i++)
				{
					FileInfo fi = new FileInfo(files[i]);
					string name = fi.Name;
					
					if (fi.Name.Length <20)
					{
						for (int j=0;j<20-fi.Name.Length;j++)
						{
							name += " ";
						}
					}
					msg += name + "\t-rw-r--r-- \t�ļ���С " + 
						fi.Length + "	����ʱ�� " + 
						fi.CreationTime.ToString() + "\n";
				}

				for(int i=0;i<dirs.Length;i++)
				{
					DirectoryInfo di = new DirectoryInfo(dirs[i]);
					string name = di.Name;
					if (di.Name.Length <20)
					{
						for (int j=0;j<20-di.Name.Length;j++)
						{
							name += " ";
						}
					}
					msg += name + "\tdrwxr-xr-x \t����ʱ�� " + 
						di.CreationTime.ToString() + "\n";
				}

				client.sendMsgByTempSocket(msg);
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
				return;
			}
		}
		
		//����Ŀ¼
		private void createDir(string dirName)
		{
			string dir = getFileName(dirName);
			Console.WriteLine("����Ŀ¼" + dir);
					
			if (Directory.Exists(dir))
			{
				client.sendMsg("221 Ŀ¼�Ѿ�����");
			}
			else 
			{
				Directory.CreateDirectory(dir);
				client.sendMsg("250 Ŀ¼�����ɹ�");
			} 
		}

		//ɾ���ļ�����Ŀ¼
		private void delete(string dirName)
		{
			string dir = getFileName(dirName);
			Console.WriteLine("ɾ��Ŀ¼/�ļ�" + dir);
			
			FileInfo fi = new FileInfo(dir);
		
			if (Directory.Exists(dir))
			{
				Directory.Delete(dir, true);
				client.sendMsg("250 Ŀ¼ɾ���ɹ�");				
			}
			else if (fi.Exists)
			{
				fi.Delete();
				client.sendMsg("250 �ļ�ɾ���ɹ�");
			}
			else
			{
				client.sendMsg("221 Ŀ¼�����ļ�������");
			} 
		}
		
		//����ļ���
		private string getFileName(string name)
		{
			if (client.workingDir[client.workingDir.Length-1] != '\\')
			{
				client.workingDir += "\\";
			}
			
			string dir=trimEnd(name);
			return client.workingDir + dir;
		}
		
		private string trimEnd(string org_str)
		{
			string dir="";
			int pos = org_str.IndexOf("\r\n");
			if (pos>-1)
			{
				dir = org_str.Substring(0, pos);
			}
			else
			{
				dir = org_str;
			}
			return dir;
		}
			
		
		//ΪĿ¼�����ļ�����
		private void rename(string from, string to)
		{
			string name = getFileName(from);
			string new_name = trimEnd(to);
			Console.WriteLine("������" + name + "��" + 
				client.workingDir + new_name);
			
			FileInfo fi = new FileInfo(name);
			if (fi.Exists)
			{
				fi.MoveTo(client.workingDir + new_name);
				client.sendMsg("250 �ļ������ɹ�");
			}
			else if (Directory.Exists(name))
			{
				Directory.Move(name, client.workingDir + new_name);
				client.sendMsg("250 Ŀ¼�����ɹ�");
			}
			else
			{
				client.sendMsg("550 Ŀ¼�����ļ�������");
			}
		}

		//��ͻ��˷����ļ�
		private void sendFile(string filename)
		{
			client.sendMsg("150 ��ʼ��������"); 
			string name = getFileName(filename);
			FileInfo fi = new FileInfo(name);
			if (fi.Exists)
			{
				FileStream fs = fi.OpenRead();	
				byte[] b = new byte[fs.Length];

				fs.Read(b,0,b.Length);
				fs.Close();
				client.sendMsgByTempSocket(b);
	
				client.sendMsg("226 �ļ��������");
			}
			else
			{
				client.sendMsg("550  �ļ�������");
			}
			
		}
		
		//��ȡ���������ļ�
		private void receiveFile(string filename)
		{
			client.sendMsg("150 ��ʼ��������"); 
	  		
			string name = getFileName(filename);
			FileInfo fi = new FileInfo(name);
	  		
			Socket tempSocket=client.getTempSocket();
	  		
			if (tempSocket.Connected)
			{
				byte[] buf = new byte[1];
				if (!fi.Exists) 
				{
					File.Create(name);
				}
				FileStream fs = File.OpenWrite(name);		
				while(tempSocket.Receive(buf)>0)
				{
					fs.Write(buf, 0 ,buf.Length);
				}
				fs.Close();
				client.sendMsg("226 �ļ��������");
			} 
			else
			{
				client.sendMsg("550 �����ϴ��ļ�");
			}	
		}
	}
}
