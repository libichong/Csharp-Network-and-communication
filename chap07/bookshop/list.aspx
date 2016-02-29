<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="list.aspx.cs" AutoEventWireup="false" Inherits="bookshop.list" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>list</title>
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
											电子书店图书列表： &nbsp;<p>
												<form id="Form1" method="post" runat="server">
													<asp:datagrid id="datagrid1" runat="server" DataKeyField="bookid" OnPageIndexChanged="DataGrid_page"
														AutoGenerateColumns="False" AllowPaging="True" Width="100%" BorderColor="#999999" BorderStyle="None"
														BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
														<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
														<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
														<AlternatingItemStyle HorizontalAlign="Center" BackColor="#DCDCDC"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
															BackColor="#000084"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="bookname" HeaderText="书籍名称"></asp:BoundColumn>
															<asp:BoundColumn DataField="author" HeaderText="作者"></asp:BoundColumn>
															<asp:BoundColumn DataField="bookprint" HeaderText="出版社"></asp:BoundColumn>
															<asp:HyperLinkColumn Text="&gt;&gt;&gt;&gt;" DataNavigateUrlField="bookid" DataNavigateUrlFormatString="booklist.aspx?bookid={0}"
																HeaderText="详细信息"></asp:HyperLinkColumn>
															
														</Columns>
														<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
													</asp:datagrid>
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
