<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="DanhMuc.aspx.cs" Inherits="lib_pages_Tin_DanhMuc" %>
<%@ Register src="~/lib/ui/Tin/Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/Tin/ViewDanhMuc.ascx" tagname="ViewDanhMuc" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
        <div style="width: 354px; float: left;">
        <uc1:Menu ID="Menu1" runat="server" />
    </div>
    <div style="float: right; width: 560px;">
        <uc2:ViewDanhMuc ID="ViewDanhMuc1" runat="server" />
    </div>
</asp:Content>

