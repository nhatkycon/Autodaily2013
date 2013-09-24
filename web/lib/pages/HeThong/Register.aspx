<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="lib_pages_HeThong_Register" %>

<%@ Register src="../../ui/heThong/Register.ascx" tagname="Register" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="row">
        <uc1:Register ID="Register1" runat="server" />        
    </div>
</asp:Content>

