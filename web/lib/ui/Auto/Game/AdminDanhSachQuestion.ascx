<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminDanhSachQuestion.ascx.cs" Inherits="lib_ui_Auto_Game_AdminDanhSachQuestion" %>
<%@ Register src="~/lib/ui/auto/game/templates/QuestionItem.ascx" tagname="QuestionItem" tagprefix="uc1" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:QuestionItem ID="GameItem1" runat="server" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>