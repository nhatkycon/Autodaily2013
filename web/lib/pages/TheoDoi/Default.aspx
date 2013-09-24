<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_TheoDoi_Default" %>
<%@ Register src="~/lib/ui/Home/CoverImage.ascx" tagname="CoverImage" tagprefix="uc1" %>

<%@ Register src="~/lib/ui/TheoDoi/Navigator.ascx" tagname="Navigator" tagprefix="uc2" %>

<%@ Register src="~/lib/ui/TheoDoi/DanhSach.ascx" tagname="DanhSach" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:CoverImage ID="CoverImage1" runat="server" />
    <uc2:Navigator ID="Navigator1" runat="server" />
    <uc3:DanhSach ID="DanhSach1" runat="server" />
</asp:Content>

