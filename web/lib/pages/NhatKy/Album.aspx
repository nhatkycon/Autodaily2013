<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Album.aspx.cs" Inherits="lib_pages_NhatKy_Album" %>

<%@ Register src="../../ui/nhatKy/Album_View.ascx" tagname="Album_View" tagprefix="uc1" %>

<%@ Register src="../../ui/heThong/BinhLuan.ascx" tagname="BinhLuan" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:Album_View ID="Album_View1" runat="server" />
    <uc2:BinhLuan ID="BinhLuan1" runat="server" />
</asp:Content>

