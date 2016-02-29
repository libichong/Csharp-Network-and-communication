<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="bookshop.WebForm1" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="N" TagName="newbook" Src="newbook.ascx" %>
<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="bookshop.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td colspan="2">
					<H:Header id="Header" runat="server" />
				</td>
			</tr>
			<tr>
				<td valign="top" width="145" height="551">
					<T:Type id="type" runat="server" />
				</td>
				<td align="left" valign=middle width="*" nowrap height="551">
					<table height="100%" align="left" cellspacing="0" cellpadding="0" width="100%" border="0">
						<tr valign="top">
							<td width="20">
								&nbsp;
							</td>
							<td nowrap vAlign=middle>
								<table cellspacing="0" cellpadding="2" width="80%" border="0">
									<tr valign="top">
										<td height="500" width="508" bgcolor="gainsboro">
											<p>
											电子书店最新登录图书： &nbsp;<p>
											<N:newbook id="newbook" runat="server" />
											</p>
										</td>
									</tr>
								</table>
								<F:Footer id="Footer" runat="server" />
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
