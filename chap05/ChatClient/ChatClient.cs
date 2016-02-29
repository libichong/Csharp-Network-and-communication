using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ChatClient
{
	public class ChatClientForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.ListBox lstUsers;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbSendContent;
		private System.Windows.Forms.RichTextBox rtbMsg;
		private System.Windows.Forms.Button btnColor;
		
		
		//�������������
		TcpClient tcpClient;
	
		//����������ݽ�������ͨ��
		private NetworkStream Stream;


		//�ͻ��˵�״̬
		private static string CLOSED = "closed";
		private static string CONNECTED = "connected";
		private System.Windows.Forms.TextBox tbUserName;
		private System.Windows.Forms.CheckBox cbPrivate;
		private string state = CLOSED;

		private bool stopFlag;

		private Color color;

		public ChatClientForm()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbSendContent = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.lstUsers = new System.Windows.Forms.ListBox();
			this.cbPrivate = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnLogin = new System.Windows.Forms.Button();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.rtbMsg = new System.Windows.Forms.RichTextBox();
			this.btnColor = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbSendContent
			// 
			this.tbSendContent.Location = new System.Drawing.Point(280, 448);
			this.tbSendContent.Multiline = true;
			this.tbSendContent.Name = "tbSendContent";
			this.tbSendContent.Size = new System.Drawing.Size(472, 112);
			this.tbSendContent.TabIndex = 0;
			this.tbSendContent.Text = "";
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(760, 448);
			this.btnSend.Name = "btnSend";
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "����(&A)";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// lstUsers
			// 
			this.lstUsers.Location = new System.Drawing.Point(16, 112);
			this.lstUsers.Name = "lstUsers";
			this.lstUsers.ScrollAlwaysVisible = true;
			this.lstUsers.Size = new System.Drawing.Size(248, 459);
			this.lstUsers.TabIndex = 2;
			// 
			// cbPrivate
			// 
			this.cbPrivate.Location = new System.Drawing.Point(280, 408);
			this.cbPrivate.Name = "cbPrivate";
			this.cbPrivate.Size = new System.Drawing.Size(87, 22);
			this.cbPrivate.TabIndex = 7;
			this.cbPrivate.Text = "���Ļ�";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 21);
			this.label2.TabIndex = 9;
			this.label2.Text = "��ǰ�����û��б�";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnExit);
			this.groupBox1.Controls.Add(this.btnLogin);
			this.groupBox1.Controls.Add(this.tbUserName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtPort);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtHost);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(816, 72);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "�������������";
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(712, 32);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(62, 22);
			this.btnExit.TabIndex = 25;
			this.btnExit.Text = "�뿪";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
			// 
			// btnLogin
			// 
			this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnLogin.Location = new System.Drawing.Point(640, 32);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(62, 21);
			this.btnLogin.TabIndex = 24;
			this.btnLogin.Text = "����";
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(448, 32);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(84, 20);
			this.tbUserName.TabIndex = 22;
			this.tbUserName.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(368, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 21);
			this.label3.TabIndex = 23;
			this.label3.Text = "�û�����";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(296, 32);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(46, 20);
			this.txtPort.TabIndex = 21;
			this.txtPort.Text = "1234";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(216, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 22);
			this.label4.TabIndex = 20;
			this.label4.Text = "�˿ںţ�";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtHost
			// 
			this.txtHost.Location = new System.Drawing.Point(96, 32);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(104, 20);
			this.txtHost.TabIndex = 19;
			this.txtHost.Text = "127.0.0.1";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 22);
			this.label5.TabIndex = 18;
			this.label5.Text = "��������ַ��";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(280, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 21);
			this.label1.TabIndex = 22;
			this.label1.Text = "ϵͳ��Ϣ��";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rtbMsg
			// 
			this.rtbMsg.Location = new System.Drawing.Point(280, 112);
			this.rtbMsg.Name = "rtbMsg";
			this.rtbMsg.Size = new System.Drawing.Size(552, 288);
			this.rtbMsg.TabIndex = 25;
			this.rtbMsg.Text = "";
			// 
			// btnColor
			// 
			this.btnColor.Location = new System.Drawing.Point(760, 488);
			this.btnColor.Name = "btnColor";
			this.btnColor.TabIndex = 28;
			this.btnColor.Text = "��ɫ";
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// ChatClientForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(848, 589);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.rtbMsg);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbPrivate);
			this.Controls.Add(this.lstUsers);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.tbSendContent);
			this.Name = "ChatClientForm";
			this.Text = "ChatClient";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ChatClientForm_Closing);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ChatClientForm());
		}


		//ServerResponse()�������ڽ��մӷ��������ص���Ϣ��
		//���ݲ�ͬ�����ִ����Ӧ�Ĳ���
		private void ServerResponse()
		{
			//����һ��byte���飬���ڽ��մӷ������˷����������ݣ�
			//ÿ�����ܽ��յ����ݰ�����󳤶�Ϊ1024���ֽ�
			byte[] buff=new byte[1024];
			string msg;
			int len;
			try
			{
				if(!Stream.CanRead)
				{
					return;
				}

				stopFlag = false;
				while(!stopFlag)
				{
					//�����еõ����ݣ������뵽buff�ַ�������
					len=Stream.Read(buff,0,buff.Length);

					if (len < 1)
					{
						Thread.Sleep(200);
						continue;
					}
					
					//���ַ�����ת��Ϊ�ַ���
					msg=System.Text.Encoding.Default.GetString(buff,0,len);
					msg.Trim();

					string[] tokens=msg.Split(new Char[]{'|'});
					//tokens[0]�б����������־����LIST��JOIN��QUIT��
					
					if (tokens[0].ToUpper()== "OK")
					{
						//������Ӧ
						add("����ִ�гɹ�");
					}
					else if (tokens[0].ToUpper()== "ERR")
					{
						//����ִ�д���
						add("����ִ�д���" + tokens[1]);
					}
					else if(tokens[0]== "LIST")
					{
						//��ʱ�ӷ��������ص���Ϣ��ʽ��
						//�����־����LIST��|�û���1|�û���|2...�����������û�����|
						add("����û��б�");
						//���������û��б�
						lstUsers.Items.Clear();
						for(int i=1;i<tokens.Length-1;i++)
						{
							lstUsers.Items.Add(tokens[i].Trim());
						}
					}
					else if(tokens[0]== "JOIN")
					{
						//��ʱ�ӷ��������ص���Ϣ��ʽ��
						//�����־����JOIN��|�ոյ�����û���|
						add(tokens[1]+" "+"�Ѿ�������������");
						this.lstUsers.Items.Add(tokens[1]);
						if (this.tbUserName.Text ==tokens[1]) 
						{
							this.state = CONNECTED;
						}
					}
					else if(tokens[0]== "QUIT")
					{
						if (this.lstUsers.Items.IndexOf(tokens[1])>-1)
						{
							this.lstUsers.Items.Remove(tokens[1]);
						}
						add("�û���" + tokens[1] + " �Ѿ��뿪");
					}
					else
					{
						//����ӷ��������ص�������Ϣ��ʽ��
						//����ListBox�ؼ���ֱ����ʾ
						add(msg);
					}	
				}
				//�ر�����
				tcpClient.Close();
			}
			catch
			{
				add("���緢������");
			}
		}

		private void add(string msg)
		{
			if (!color.IsEmpty)
			{
				this.rtbMsg.SelectionColor = color;
			}
			this.rtbMsg.SelectedText = msg + "\n";
		}

		//����������͡���ťʱ��������btnSend_Click�������
		//��btnSend_Click��������У��������˽�ģ�
		//����CHAT������͸���������
		//����Ϊ˽�ģ�������PRIV������͸���������
		//ע�������ʽһ��Ҫ��������˵������ʽһ��
		private void btnSend_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!this.cbPrivate.Checked)
				{
					//��ʱ����ĸ�ʽ�ǣ�
					//�����־����CHAT��|�����ߵ��û�������������|
					string message="CHAT|"+ this.tbUserName.Text +":"+
						tbSendContent.Text+"|";
					tbSendContent.Text="";
					tbSendContent.Focus();
					//���ַ���ת��Ϊ�ַ�����
					Byte[]outbytes=System.Text.Encoding.Default.GetBytes(
						message.ToCharArray());
					Stream.Write(outbytes,0,outbytes.Length);
					
				}
				else
				{
					if(lstUsers.SelectedIndex==-1)
					{
						MessageBox.Show("�����б���ѡ��һ���û�","��ʾ��Ϣ",
							MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						return;
					}
					string receiver=lstUsers.SelectedItem.ToString();
					//��Ϣ�ĸ�ʽ�ǣ�
					//�����־����PRIV��|�����ߵ��û���|�����ߵ��û���|��������|
					string message="PRIV|"+this.tbUserName.Text+"|"+receiver+"|"+
						tbSendContent.Text+"|";
					tbSendContent.Text="";
					tbSendContent.Focus();
					//���ַ���ת��Ϊ�ַ�����
					byte[] outbytes=System.Text.Encoding.ASCII.GetBytes(
						message.ToCharArray());
					Stream.Write(outbytes,0,outbytes.Length);
					
				}
			}
			catch
			{
				this.rtbMsg.AppendText("���緢������");
			}

		}


		//�������������
		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			if (state == CONNECTED)
			{
				return;
			}

			if(this.tbUserName.Text.Length==0)
			{
				MessageBox.Show("�����������س�!","��ʾ��Ϣ",
					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.tbUserName.Focus();
				return;
			}
			try
			{
				//����һ���ͻ����׽��֣�����Login��һ���������ԣ�
				//�������ݸ�ChatClient����
				tcpClient=new TcpClient();
				//��ָ����IP��ַ�ķ�����������������
				tcpClient.Connect(IPAddress.Parse(txtHost.Text),
					Int32.Parse(txtPort.Text));
				//�������������ݽ�������ͨ����NetworkStream)
				Stream=tcpClient.GetStream();

				//����һ���µ��̣߳�ִ�з���this.ServerResponse()��
				//�Ա�����Ӧ�ӷ��������ص���Ϣ
				Thread thread=new Thread(new ThreadStart(this.ServerResponse));
				thread.Start();

				//����������͡�CONN���������
				//������ĸ�ʽ��������˵Ķ���ĸ�ʽһ�£�
				//�����ʽΪ�������־����CONN��|�����ߵ��û���|
				string cmd="CONN|"+this.tbUserName.Text+"|";
				//���ַ���ת��Ϊ�ַ�����
				Byte[] outbytes=System.Text.Encoding.Default.GetBytes(
					cmd.ToCharArray());
				Stream.Write(outbytes,0,outbytes.Length);

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		//����������ɫ
		private void btnColor_Click(object sender, System.EventArgs e)
		{
			ColorDialog colorDialog1 = new ColorDialog();
			colorDialog1.Color = this.rtbMsg.SelectionColor;

			if(colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && 
				colorDialog1.Color !=this.rtbMsg.SelectionColor)
			{
				this.rtbMsg.SelectionColor = colorDialog1.Color;
				color = colorDialog1.Color;
			}
		}

		//���������뿪����ťʱ���������btnExit_Click �������
		//��btnExit_Click ��������У�
		//����EXIT������͸����������������ʽҪ��������˵������ʽһ��
		private void btnExit_Click_1(object sender, System.EventArgs e)
		{
			if (state == CONNECTED) 
			{
				string message="EXIT|"+this.tbUserName.Text+"|";
				//���ַ���ת��Ϊ�ַ�����
				Byte[]outbytes=System.Text.Encoding.Default.GetBytes(
					message.ToCharArray());
				Stream.Write(outbytes,0,outbytes.Length);

				this.state = CLOSED;
				this.stopFlag = true;
				this.lstUsers.Items.Clear();
			}
		}

		private void ChatClientForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			btnExit_Click_1(sender, e);
		}


	}
}
