<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GameBoard.ascx.cs" Inherits="lib_ui_Auto_Game_GameBoard" %>
<%@ Register src="~/lib/ui/auto/game/templates/QuestionInBoardItem.ascx" tagname="QuestionInBoardItem" tagprefix="uc1" %>
<div class="fs-top">
    <center>
        <div class="logo-small"></div>        
    </center>
</div>
<div class="" style="margin-top: 80px;">
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:QuestionInBoardItem ID="QuestionInBoardItem1" runat="server" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
</div>
