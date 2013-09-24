<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="lib_pages_TheoDoi_Edit" %>

<%@ Register src="~/lib/ui/Home/CoverImage.ascx" tagname="CoverImage" tagprefix="uc1" %>

<%@ Register src="~/lib/ui/TheoDoi/Navigator.ascx" tagname="Navigator" tagprefix="uc2" %>


<%@ Register src="~/lib/ui/TheoDoi/TheoDoi_Edit.ascx" tagname="TheoDoi_Edit" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:CoverImage ID="CoverImage1" runat="server" />
    <uc2:Navigator ID="Navigator1" runat="server" />
    <uc4:TheoDoi_Edit ID="TheoDoi_Edit1" runat="server" />
</asp:Content>

