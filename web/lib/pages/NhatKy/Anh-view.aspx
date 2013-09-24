<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Anh-view.aspx.cs" Inherits="lib_pages_NhatKy_Anh_view" %>

<%@ Register src="../../ui/nhatKy/Album_View.ascx" tagname="Album_View" tagprefix="uc1" %>
<%@ Register src="../../ui/heThong/BinhLuan.ascx" tagname="BinhLuan" tagprefix="uc2" %>

<%@ Register src="../../ui/nhatKy/Anh_View.ascx" tagname="Anh_View" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc3:Anh_View ID="Anh_View1" runat="server" />
    <uc2:BinhLuan ID="BinhLuan1" runat="server" />
</asp:Content>

