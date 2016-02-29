<%@ Control Language="c#" AutoEventWireup="false" Codebehind="header.ascx.cs" Inherits="bookshop.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
<br>
<table align="center" border="0">
	<tr>
		<td valign="middle">
			<table id="Header_holder" runat="Server" border="0" cellspacing="0" cellpadding="0" width="600">
				<tr>
					<td align="center" style="WIDTH: 500px; HEIGHT: 65px">
						<asp:HyperLink NavigateUrl="Default.aspx" id="Header_Field3" runat="server">
							<h1>电子书店系统</h1>
						</asp:HyperLink>
					</td>
					<td align="center" style="HEIGHT: 65px">
						<table width="100" border="0" cellspacing="3" cellpadding="0" height="51" align="center"
							style="WIDTH: 100px; HEIGHT: 51px">
							<tr align="center" valign="middle">
								<td style="HEIGHT: 21px"><img src="images/title.gif" align="absMiddle"></td>
								<td align="left" style="HEIGHT: 21px">
									<asp:HyperLink NavigateUrl="login.aspx" id="Header_Field2" runat="server">
					登录
					</asp:HyperLink>
								</td>
							</tr>
							<tr align="center" valign="middle">
								<td style="HEIGHT: 21px"><img src="images/title.gif" align="absMiddle"></td>
								<td align="left" style="HEIGHT: 21px">
									<asp:HyperLink NavigateUrl="bookselect.aspx" id="Header_Field1" runat="server">
					图书查询
					</asp:HyperLink>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
