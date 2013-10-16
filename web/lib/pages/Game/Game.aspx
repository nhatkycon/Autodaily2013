<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Normal.master" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="lib_pages_Game_Game" %>

<%@ Register src="../../ui/Auto/Game/GameBoard.ascx" tagname="GameBoard" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:GameBoard ID="GameBoard1" runat="server" />
</asp:Content>

