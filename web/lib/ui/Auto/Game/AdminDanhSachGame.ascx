<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminDanhSachGame.ascx.cs" Inherits="lib_ui_Auto_Game_AdminDanhSachGame" %>
<%@ Register src="~/lib/ui/auto/game/templates/GameItem.ascx" tagname="GameItem" tagprefix="uc1" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:GameItem ID="GameItem1" runat="server" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>
