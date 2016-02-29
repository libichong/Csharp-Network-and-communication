<%@ OutputCache Duration="3000" VaryByParam="selection" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="type.ascx.cs" Inherits="bookshop.type" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="0" cellPadding="0" width="145" bgColor="gainsboro" border="0">
	<tr vAlign="top">
		<td vAlign="top" colSpan="2"><FONT face="ËÎÌו"></FONT><A href="default.aspx"></A></td>
	</tr>
	<tr vAlign="top">
		<td><asp:datalist id="MyList" Font-Underline="True" ShowFooter="False" ShowHeader="False" BorderWidth="1px"
				GridLines="Vertical" BackColor="White" BorderStyle="None" BorderColor="#999999" runat="server"
				cellpadding="3" width="145px" SelectedItemStyle-BackColor="dimgray" EnableViewState="False"
				Font-Size="Larger">
				<SelectedItemStyle Font-Size="Medium" Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<SelectedItemTemplate>
					<asp:HyperLink id="HyperLink2" Text='<%# DataBinder.Eval(Container.DataItem, "typeName") %>' NavigateUrl='<%# "List.aspx?typeID=" + DataBinder.Eval(Container.DataItem, "typeID") + "&selection=" + Container.ItemIndex %>' runat="server" />
				</SelectedItemTemplate>
				<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<ItemStyle Font-Underline="True" ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<ItemTemplate>
					<asp:HyperLink id="HyperLink1" Text='<%# DataBinder.Eval(Container.DataItem, "typeName") %>' NavigateUrl='<%# "List.aspx?typeID=" + DataBinder.Eval(Container.DataItem, "typeID") + "&selection=" + Container.ItemIndex %>' runat="server" />
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
			</asp:datalist></td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
	</tr>
</table>
