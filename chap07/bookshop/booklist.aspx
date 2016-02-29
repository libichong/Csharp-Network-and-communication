<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="booklist.aspx.cs" AutoEventWireup="false" Inherits="bookshop.booklist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>booklist</title>
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
					<table height="100%" align="left" cellspacing="0" cellpadding="0" width="70%" border="0">
						<tr valign="top">
							<td width="20">
								&nbsp;
							</td>
							<td nowrap vAlign="middle">
								<table cellspacing="0" cellpadding="2" width="80%" border="0">
									<tr valign="top">
										<td height="500" width="508" bgcolor="gainsboro">
											<p>
											电子图书信息： &nbsp;<p>&nbsp;
												<asp:DataList id="MyList" RepeatColumns="2" runat="server">
													<ItemStyle Font-Size="Medium"></ItemStyle>
													<ItemTemplate>
														<table border="0" width="500">
															<tr>
																<td width="25">
																	&nbsp
																</td>
																<td width="100" valign="middle" align="right">
																	<a href='wareDetails.aspx?bookid=<%# DataBinder.Eval(Container.DataItem, "bookid") %>'>
																	</a>
																</td>
																<td width="200" valign="middle">
																	<span class="ProductListHead"><b>《<%# DataBinder.Eval(Container.DataItem, "bookName") %>》</b>
																	</span>
																	<br>
																	<span class="ProductListItem"><b>作者： </b>
																		<%# DataBinder.Eval(Container.DataItem, "author", "{0:c}") %>
																	</span>
																	<br>
																	<span class="ProductListItem"><b>出版社： </b>
																		<%# DataBinder.Eval(Container.DataItem, "bookprint", "{0:c}") %>
																	</span>
																	<br>
																	<span class="ProductListItem"><b>原价：</b>
																		<%# DataBinder.Eval(Container.DataItem, "startprice", "{0:c}") %>
																	</span>
																	<br>
																	<span class="ProductListItem"><b>售价：</b>
																		<%# DataBinder.Eval(Container.DataItem, "saleprice", "{0:c}") %>
																	</span>
																	<br>
																	<span class="ProductListItem"><b>库存数量：</b>
																		<%# DataBinder.Eval(Container.DataItem, "number", "{0:c}") %>
																		本 </span>
																	<br>
																	<hr size="1" width="60%">
																	<br>
																	<span class="ProductListItem"><b>内容简介：</b>
																		<%# DataBinder.Eval(Container.DataItem, "show") %>
																	</span>
																	<br>
																	<a href='AddToCart.aspx?bookID=<%# DataBinder.Eval(Container.DataItem, "bookid") %>'>
																		<span class="ProductListItem"><font color="#9D0000"><b>放入购物车<b></font></span> </a>
																</td>
															</tr>
														</table>
													</ItemTemplate>
													<HeaderStyle Font-Size="Medium"></HeaderStyle>
												</asp:DataList>
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
