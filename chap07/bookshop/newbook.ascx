<%@ Control Language="c#" AutoEventWireup="false" Codebehind="newbook.ascx.cs" Inherits="bookshop.newbook" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<asp:DataList id="MyList" RepeatColumns="2" runat="server">
	<ItemStyle Font-Size="Medium"></ItemStyle>
	<ItemTemplate>
		<table border="0" width="300">
			<tr>
				<td width="25">
					&nbsp
				</td>
				<td width="100" valign="middle" align="right">
					<a href='booklist.aspx?bookid=<%# DataBinder.Eval(Container.DataItem, "bookid") %>'>
					</a>
				</td>
				<td width="200" valign="middle">
					
					<span class="ProductListHead">
						<b>《<%# DataBinder.Eval(Container.DataItem, "bookName") %>》</b>
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
					<a href='booklist.aspx?bookID=<%# DataBinder.Eval(Container.DataItem, "bookID") %>'>
						<span class="ProductListItem"><font color="#9D0000"><b>详细内容<b></font></span> </a>
				</td>
			</tr>
		</table>
	</ItemTemplate>
	<HeaderStyle Font-Size="Medium"></HeaderStyle>
</asp:DataList>
