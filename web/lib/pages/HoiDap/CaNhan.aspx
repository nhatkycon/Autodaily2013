<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="CaNhan.aspx.cs" Inherits="lib_pages_HoiDap_CaNhan" %>
<%@ Register src="~/lib/ui/HoiDap/TrangThaiBe.ascx" tagname="TrangThaiBe" tagprefix="uc1" %>

<%@ Register src="~/lib/ui/HoiDap/Menu.ascx" tagname="Menu" tagprefix="uc2" %>
<%@ Register src="~/lib/ui/HoiDap/Header.ascx" tagname="Header" tagprefix="uc3" %>

<%@ Register src="~/lib/ui/HoiDap/CauHoiCuaToi.ascx" tagname="CauHoiCuaToi" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div style="width: 354px; float: left;">
        <uc1:TrangThaiBe ID="TrangThaiBe1" runat="server" />
        <uc2:Menu ID="Menu1" runat="server" />
    </div>
    <div style="float: right; width: 560px;">
        <uc3:Header ID="Header1" runat="server" />
        <uc4:CauHoiCuaToi ID="CauHoiCuaToi1" runat="server" />
    </div>
</asp:Content>


