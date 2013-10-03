<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminDapAnList.ascx.cs" Inherits="lib_ui_Auto_TayDua_AdminDapAnList" %>
<%@ Register src="~/lib/ui/Auto/TayDua/templates/AdminDapAnItem.ascx" tagname="AdminDapAnItem" tagprefix="uc1" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:AdminDapAnItem ID="AdminDapAnItem1" runat="server"  Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>
