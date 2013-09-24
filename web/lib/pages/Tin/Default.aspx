<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_Tin_Default" %>

<%@ Register src="~/lib/ui/Tin/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<%@ Register src="~/lib/ui/Tin/Home.ascx" tagname="Home" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div style="width: 354px; float: left;">
        <uc1:Menu ID="Menu1" runat="server" />
    </div>
    <div style="float: right; width: 560px;">
        <uc2:Home ID="Home1" runat="server" />
        
    </div>
</asp:Content>

