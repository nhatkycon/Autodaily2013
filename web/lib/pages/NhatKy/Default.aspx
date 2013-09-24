<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_NhatKy_Default" %>

<%@ Register src="~/lib/ui/Home/CoverImage.ascx" tagname="CoverImage" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/Home/Navigator.ascx" tagname="Navigator" tagprefix="uc2" %>
<%@ Register src="~/lib/ui/Home/Post_List.ascx" tagname="Post_List" tagprefix="uc3" %>
<%@ Register src="~/lib/ui/Home/Avatar.ascx" tagname="Avatar" tagprefix="uc4" %>
<%@ Register src="~/lib/ui/Home/GiaDinh.ascx" tagname="GiaDinh" tagprefix="uc5" %>
<%@ Register src="~/lib/ui/Home/LoiChuc.ascx" tagname="LoiChuc" tagprefix="uc6" %>
<%@ Register src="~/lib/ui/Home/CungTuoi.ascx" tagname="CungTuoi" tagprefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:CoverImage ID="CoverImage1" runat="server" /> 
        <div style="float: left; width: 560px;">
            <uc2:Navigator ID="Navigator1" runat="server" />
            <uc3:Post_List ID="Post_List1" runat="server" />
        </div>
        <div style="width: 354px; float: right;">
            <uc4:Avatar ID="Avatar1" runat="server" />
            <uc5:GiaDinh ID="GiaDinh1" runat="server" />
            <uc7:CungTuoi ID="CungTuoi1" runat="server" />
            <uc6:LoiChuc ID="LoiChuc1" runat="server" />
        </div>
</asp:Content>

