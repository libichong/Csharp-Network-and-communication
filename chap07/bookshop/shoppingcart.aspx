<%@ Page language="c#" Codebehind="shoppingcart.aspx.cs" AutoEventWireup="false" Inherits="bookshop.shoppingcart" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>shoppingcart</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="bookshop.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td colSpan="2"><H:HEADER id="Header1" runat="server"></H:HEADER></td>
			</tr>
			<tr>
				<td vAlign="top">&nbsp;
				</td>
				<td vAlign="top" noWrap align="left" width="100%">
					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
						<tr vAlign="top">
							<td noWrap><br>
								<form id="Form1" runat="server">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td>&nbsp;&nbsp;<STRONG><FONT size="4">我的购物车</FONT></STRONG>
												<br>
											</td>
										</tr>
									</table>
									 <font color="red">
										<asp:label class="ErrorText" id="MyError" runat="Server" Font-Bold="True" Font-Size="Large"
											EnableViewState="false"></asp:label></font><br>
									<img height="15" src="images/1x1.gif" width="24" align="left" border="0">
									<asp:panel id="DetailsPanel" runat="server">
										<TABLE height="100%" cellSpacing="0" cellPadding="0" width="550" border="0">
											<TR vAlign="top">
												<TD width="550">
													<asp:DataGrid id="MyList" runat="server" Font-Size="8pt" AutoGenerateColumns="False" DataKeyField="bookQuantity"
														AlternatingItemStyle-CssClass="CartListItemAlt" ItemStyle-CssClass="CartListItem" FooterStyle-CssClass="CartListFooter"
														HeaderStyle-CssClass="CartListHead" ShowFooter="True" Font-Name="Verdana" cellpadding="4"
														GridLines="Vertical" BorderColor="Black" Font-Names="Verdana">
														<AlternatingItemStyle CssClass="CartListItemAlt"></AlternatingItemStyle>
														<ItemStyle CssClass="CartListItem"></ItemStyle>
														<HeaderStyle Font-Size="Medium" CssClass="CartListHead"></HeaderStyle>
														<FooterStyle CssClass="CartListFooter"></FooterStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="书籍编号">
																<ItemTemplate>
																	<asp:Label id="bookid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "bookid") %>' />
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="bookName" HeaderText="书籍名称"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="数量">
																<ItemTemplate>
																	<asp:TextBox id="wareQuantity" runat="server" Columns="4" MaxLength="3" Text='<%# DataBinder.Eval(Container.DataItem, "bookQuantity") %>' width="40px" />
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="SalePrice" HeaderText="价格" DataFormatString="{0:c}"></asp:BoundColumn>
															<asp:BoundColumn DataField="ExtendedAmount" HeaderText="小计" DataFormatString="{0:c}"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="删除">
																<ItemTemplate>
																	<center>
																		<asp:CheckBox id="Remove" runat="server" />
																	</center>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid><IMG height="1" src="Images/1x1.gif" width="350"> <SPAN class="NormalBold">
														<FONT face="宋体" size="3">总额:</FONT> </SPAN>
													<asp:Label class="NormalBold" id="lblTotal" runat="server" Font-Size="Small" EnableViewState="false"></asp:Label><BR>
													<BR>
													<asp:button id="UpdateBtn" runat="server" Text="更新购物车"></asp:button>
													<asp:button id="CheckoutBtn" runat="server" Text="最终结算"></asp:button><BR>
												</TD>
											</TR>
										</TABLE>
									</asp:panel></form>
							</td>
						</tr>
						<TR>
							<TD noWrap><F:FOOTER id="footer1" runat="server"></F:FOOTER></TD>
						</TR>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
