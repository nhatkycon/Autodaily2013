<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Normal.master" AutoEventWireup="true" CodeFile="Question.aspx.cs" Inherits="lib_pages_Game_Question" %>

<%@ Register src="../../ui/Auto/Game/templates/QuestionView.ascx" tagname="QuestionView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:QuestionView ID="QuestionView1" runat="server" />
</asp:Content>

