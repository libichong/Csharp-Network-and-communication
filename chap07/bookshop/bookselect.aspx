<%@ Page language="c#" Codebehind="bookselect.aspx.cs" AutoEventWireup="false" Inherits="bookshop.bookselect" %>
<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>bookselect</title>
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
				<td align="left" valign="middle" width="*" nowrap height="551">
					<table height="100%" align="left" cellspacing="0" cellpadding="0" width="100%" border="0">
						<tr valign="top">
							<td width="20">
								&nbsp;
							</td>
							<td nowrap vAlign="middle">
								<table cellspacing="0" cellpadding="2" width="80%" border="0">
									<tr valign="top">
										<td height="500" width="600" bgcolor="gainsboro">
											<p>
											电子书店图书查询： &nbsp;<p>
												<form id="Form1" method="post" runat="server" action="bookselect.aspx">
													<TABLE id="Table2" style="WIDTH: 600px" width="600" align="center" border="0" bgcolor="#f5f5f5">
														<TR>
															<TD ><FONT face="宋体">作者：</FONT></TD>
															<TD>
																<asp:TextBox id="author" CssClass="textbox" runat="server"></asp:TextBox></TD>
															<TD><FONT face="宋体">出版社：</FONT></TD>
															<TD>
																<asp:TextBox id="bookprint" CssClass="textbox" runat="server"></asp:TextBox></TD>
															<TD><FONT face="宋体">书籍名：</FONT></TD>
															<TD>
																<asp:TextBox id="bookname" CssClass="textbox" runat="server"></asp:TextBox></TD>
															<TD><asp:Button id="Btn_ok" CssClass="Button" runat="server" Text="查询"></asp:Button></TD>
														</TR>
													</TABLE>
													<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
														width="600" align="center" border="0">
														<TR>
															<TD style="HEIGHT: 174px">
																<asp:datagrid id="datagrid1" runat="server" AutoGenerateColumns="False" PageSize="6" AllowPaging="True"
																	Width="100%" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" BackColor="White" CellPadding="3"
																	GridLines="None" CellSpacing="1">
																	<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
																	<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
																	<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
																	<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="bookname" HeaderText="书籍名"></asp:BoundColumn>
																		<asp:BoundColumn DataField="author" HeaderText="作者"></asp:BoundColumn>
																		<asp:BoundColumn DataField="bookprint" HeaderText="出版社"></asp:BoundColumn>																		
																		<asp:BoundColumn DataField="number" HeaderText="库存"></asp:BoundColumn>
																		<asp:BoundColumn DataField="saleprice" HeaderText="售价(元)"></asp:BoundColumn>
																	</Columns>
																	<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
																</asp:datagrid>
															</TD>
														</TR>
														<TR>
															<TD align="center" bgcolor="#cccccc"><FONT face="宋体">&nbsp; </FONT>
															</TD>
														</TR>
													</TABLE>
												</form>
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
