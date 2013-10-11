<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Normal.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_TayDua_Default" %>

<%@ Register src="~/lib/ui/Auto/TayDua/CauHoiView.ascx" tagname="CauHoiView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:CauHoiView ID="CauHoiView" runat="server" />
</asp:Content>

