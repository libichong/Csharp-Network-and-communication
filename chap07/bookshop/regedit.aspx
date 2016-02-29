<%@ Page language="c#" Codebehind="regedit.aspx.cs" AutoEventWireup="false" Inherits="bookshop.regedit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>regedit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="bookshop.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
				width="544" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 174px">
						<TABLE id="Table2" style="WIDTH: 340px; HEIGHT: 120px" cellSpacing="1" cellPadding="1"
							width="340" align="center" border="0" bgcolor="#f5f5f5">
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 31px"><FONT face="宋体">用户号：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 31px">
									<asp:TextBox id="userid" CssClass="textbox" runat="server" Width="116px"></asp:TextBox><FONT face="宋体"></FONT></TD>
								<TD style="HEIGHT: 31px"><FONT face="宋体">* </FONT><FONT size="2">
										<asp:RequiredFieldValidator id="Rfv_id" runat="server" ErrorMessage="不能为空" ControlToValidate="userid"></asp:RequiredFieldValidator>
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 31px"><FONT face="宋体">密&nbsp;&nbsp;码：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 31px">
									<asp:TextBox textmode="password" id="password" CssClass="textbox" runat="server" Width="116px"></asp:TextBox><FONT face="宋体"></FONT></TD>
								<TD style="HEIGHT: 31px"><FONT face="宋体">* </FONT><FONT size="2">
										<asp:RequiredFieldValidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="不能为空" ControlToValidate="password"></asp:RequiredFieldValidator>
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">姓名：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="name" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">Email：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="Email" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 18px"><FONT face="宋体">证件号：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 18px">
									<asp:TextBox id="card" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px">&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="3" align="center">
									<asp:Button id="Btn_ok" CssClass="Button" runat="server" Text="确定"></asp:Button><FONT face="宋体">&nbsp;&nbsp;&nbsp;
									</FONT>
									<asp:Button id="Btn_cancel" CssClass="Button" runat="server" Text="取消"></asp:Button>
									<asp:Label id="Lbl_note" runat="server"></asp:Label><FONT face="宋体"></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" bgcolor="#cccccc"><FONT face="宋体"><a href="default.aspx">返回</a> </FONT>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
