<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="lib_pages_TheoDoi_View" %>
<%@ Register src="~/lib/ui/Home/CoverImage.ascx" tagname="CoverImage" tagprefix="uc1" %>

<%@ Register src="~/lib/ui/TheoDoi/Navigator.ascx" tagname="Navigator" tagprefix="uc2" %>

<%@ Register src="~/lib/ui/TheoDoi/TheoDoi_View.ascx" tagname="TheoDoi_View" tagprefix="uc3" %>

<%@ Register src="~/lib/ui/heThong/BinhLuan.ascx" tagname="BinhLuan" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:CoverImage ID="CoverImage1" runat="server" />
    <uc2:Navigator ID="Navigator1" runat="server" />
    <uc3:TheoDoi_View ID="TheoDoi_View1" runat="server" />    
    <uc4:BinhLuan ID="BinhLuan1" runat="server" />
</asp:Content>

