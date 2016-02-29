<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="bookshop.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>login</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="bookshop.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<TBODY>
				<tr>
					<td style="HEIGHT: 162px" vAlign="top" noWrap align="center" width="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr vAlign="top">
								<td noWrap><FONT face="宋体"></FONT><FONT face="宋体"></FONT><br>
									<form id="Form1" runat="server">
										<table height="100%" cellSpacing="0" cellPadding="0" align="center" border="0">
											<tr vAlign="top" align="center">
												<td><asp:label class="ErrorText" id="Message" runat="server"></asp:label></td>
												<td></td>
											</tr>
											<tr vAlign="top" align="center">
												<td>用户名&nbsp;</td>
												<td align="left"><asp:textbox id="userid" runat="server" size="25"></asp:textbox><asp:requiredfieldvalidator id="UserNameRequired" runat="server" ErrorMessage="请填写，不能为空" Font-Size="9pt" Font-Name="verdana"
														Display="dynamic" ControlToValidate="userid"></asp:requiredfieldvalidator></td>
											</tr>
											<tr vAlign="top" align="center">
												<td style="HEIGHT: 17px">密&nbsp;&nbsp;&nbsp;&nbsp;码&nbsp;</td>
												<td style="HEIGHT: 17px"><asp:textbox id="password" runat="server" size="25" textmode="password"></asp:textbox><asp:requiredfieldvalidator id="passwordRequired" runat="server" ErrorMessage="请填写，不能为空" Font-Size="9pt" Font-Name="verdana"
														Display="Static" ControlToValidate="password"></asp:requiredfieldvalidator></td>
											</tr>
											<tr vAlign="top" align="center">
												<td align="right"><asp:imagebutton id="LoginBtn" runat="server" ImageURL="images/sign_in_now.gif"></asp:imagebutton></td>
												<td><A href="regedit.aspx"><IMG src="images/register.gif" border="0"></A></td>
											</tr>
										</table>
									</form>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<TD style="HEIGHT: 71px" vAlign="top" noWrap align="center" width="100%">
						<P>&nbsp;</P>
						<P><asp:hyperlink id="BackHyperLink" runat="server" NavigateUrl="Default.aspx">返回</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;
						&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="updateuser.aspx">修改信息</asp:hyperlink></P>
					</TD>
				</TR>
			</TBODY>
		</table>
		</TR></TBODY></TABLE>
	</body>
</HTML>
