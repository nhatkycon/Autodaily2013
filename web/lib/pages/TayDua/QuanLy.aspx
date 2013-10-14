<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/TayDua.master" AutoEventWireup="true" CodeFile="QuanLy.aspx.cs" Inherits="lib_pages_TayDua_QuanLy" %>

<%@ Register src="~/lib/ui/Auto/TayDua/AdminCauHoi.ascx" tagname="AdminCauHoi" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AdminCauHoi ID="AdminCauHoi1" runat="server" />
</asp:Content>

