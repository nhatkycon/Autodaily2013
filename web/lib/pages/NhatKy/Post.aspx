<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="lib_pages_NhatKy_Post" %>
<%@ Register src="/lib/ui/Home/CoverImage.ascx" tagname="CoverImage" tagprefix="uc1" %>
<%@ Register src="/lib/ui/Home/Navigator.ascx" tagname="Navigator" tagprefix="uc2" %>
<%@ Register src="/lib/ui/Home/Avatar.ascx" tagname="Avatar" tagprefix="uc4" %>
<%@ Register src="/lib/ui/Home/GiaDinh.ascx" tagname="GiaDinh" tagprefix="uc5" %>
<%@ Register src="/lib/ui/Home/LoiChuc.ascx" tagname="LoiChuc" tagprefix="uc6" %>
<%@ Register src="/lib/ui/nhatKy/Post_View.ascx" tagname="Post_View" tagprefix="uc1" %>

<%@ Register src="../../ui/heThong/BinhLuan.ascx" tagname="BinhLuan" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:CoverImage ID="CoverImage1" runat="server" />
    <div style="float: left; width: 560px;">
        <uc2:Navigator ID="Navigator1" runat="server" />
        <uc1:Post_View ID="Post_View1" runat="server" />
        <uc3:BinhLuan ID="BinhLuan1" runat="server" />
    </div>
    <div style="width: 354px; float: right;">
        <uc4:Avatar ID="Avatar1" runat="server" />
        <uc5:GiaDinh ID="GiaDinh1" runat="server" />
        <uc6:LoiChuc Visible="False" ID="LoiChuc1" runat="server" />
    </div>
</asp:Content>

