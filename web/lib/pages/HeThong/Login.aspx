<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="lib_pages_HeThong_Login" %>

<%@ Register src="../../ui/heThong/Login.ascx" tagname="Login" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="form-signin">
        <uc1:Login ID="Login1" runat="server" />        
    </div>
</asp:Content>

