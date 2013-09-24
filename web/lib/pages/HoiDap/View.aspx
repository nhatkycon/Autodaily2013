<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="lib_pages_HoiDap_View" %>
<%@ Register src="~/lib/ui/HoiDap/TrangThaiBe.ascx" tagname="TrangThaiBe" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/HoiDap/Menu.ascx" tagname="Menu" tagprefix="uc2" %>
<%@ Register src="~/lib/ui/HoiDap/Header.ascx" tagname="Header" tagprefix="uc3" %>
<%@ Register src="~/lib/ui/HoiDap/View.ascx" tagname="View" tagprefix="uc5" %>
<%@ Register src="~/lib/ui/HoiDap/DanhSachTraLoi.ascx" tagname="DanhSachTraLoi" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div style="width: 354px; float: left;">
        <uc1:TrangThaiBe ID="TrangThaiBe1" runat="server" />
        <uc2:Menu ID="Menu1" runat="server" />
    </div>
    <div style="float: right; width: 560px;">
        <uc3:Header ID="Header1" runat="server" />        
        <uc5:View ID="View1" runat="server" />
        <uc4:DanhSachTraLoi ID="DanhSachTraLoi1" runat="server" />
    </div>
</asp:Content>