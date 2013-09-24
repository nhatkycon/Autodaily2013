<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Email.aspx.cs" Inherits="lib_pages_Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <h3>
        Gửi mail
        </h3>
        <asp:Button runat="server" ID="btnEmail" Text="Gửi e-mail" 
        CssClass="btn btn-large" onclick="btnEmail_Click"/>
</asp:Content>

