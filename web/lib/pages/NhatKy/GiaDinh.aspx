<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="GiaDinh.aspx.cs" Inherits="lib_pages_NhatKy_GiaDinh" %>
<%@ Register src="/lib/ui/Home/CoverImage.ascx" tagname="CoverImage" tagprefix="uc1" %>
<%@ Register src="/lib/ui/Home/Avatar.ascx" tagname="Avatar" tagprefix="uc4" %>
<%@ Register src="/lib/ui/Home/GiaDinh.ascx" tagname="GiaDinh" tagprefix="uc5" %>
<%@ Register src="/lib/ui/Home/LoiChuc.ascx" tagname="LoiChuc" tagprefix="uc6" %>

<%@ Register src="/lib/ui/GiaDinh/Navigation.ascx" tagname="Navigation" tagprefix="uc7" %>

<%@ Register src="/lib/ui/GiaDinh/DanhSach.ascx" tagname="DanhSach" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:CoverImage ID="CoverImage1" runat="server" />            
    <uc7:Navigation ID="Navigation1" runat="server" />
    <div style="float: left; width: 560px;">
        <uc2:DanhSach ID="DanhSach1" runat="server" />
    </div>
    <div style="width: 354px; float: right;">
        <uc4:Avatar ID="Avatar1" runat="server" />
        <uc5:GiaDinh Visible="False" ID="GiaDinh1" runat="server" />
        <uc6:LoiChuc ID="LoiChuc1" runat="server" />
    </div>
</asp:Content>

