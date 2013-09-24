<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Anh.aspx.cs" Inherits="lib_pages_NhatKy_Anh" %>
<%@ Register src="/lib/ui/Home/CoverImage.ascx" tagname="CoverImage" tagprefix="uc1" %>
<%@ Register src="/lib/ui/Home/Avatar.ascx" tagname="Avatar" tagprefix="uc4" %>
<%@ Register src="/lib/ui/Home/GiaDinh.ascx" tagname="GiaDinh" tagprefix="uc5" %>
<%@ Register src="/lib/ui/Home/LoiChuc.ascx" tagname="LoiChuc" tagprefix="uc6" %>
<%@ Register src="~/lib/ui/GiaDinh/DanhSach.ascx" tagname="DanhSach" tagprefix="uc2" %>

<%@ Register src="~/lib/ui/Home/Navigation_Anh.ascx" tagname="Navigation_Anh" tagprefix="uc3" %>

<%@ Register src="~/lib/ui/nhatKy/Album_DanhSach.ascx" tagname="Album_DanhSach" tagprefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:CoverImage ID="CoverImage1" runat="server" />            
    <uc3:Navigation_Anh ID="Navigation_Anh1" runat="server" />
    <uc7:Album_DanhSach ID="Album_DanhSach1" runat="server" />
</asp:Content>
