<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AnswerList.ascx.cs" Inherits="lib_ui_Auto_Game_templates_AnswerList" %>
<%@ Register src="~/lib/ui/auto/game/templates/AnswerItem.ascx" tagname="AnswerItem" tagprefix="uc1" %>

<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:AnswerItem ID="AnswerItem1" runat="server" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>