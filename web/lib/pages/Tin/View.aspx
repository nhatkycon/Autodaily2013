<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="lib_pages_Tin_View" %>
<%@ Register src="~/lib/ui/Tin/Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/Tin/View.ascx" tagname="View" tagprefix="uc2" %>
<%@ Register src="~/lib/ui/heThong/BinhLuan.ascx" tagname="BinhLuan" tagprefix="uc3" %>
<%@ Register src="~/lib/ui/Tin/LienQuan.ascx" tagname="LienQuan" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
      <div style="width: 354px; float: left;">
        <uc1:Menu ID="Menu1" runat="server" />
          <uc4:LienQuan ID="LienQuan1" runat="server" />
    </div>
    <div style="float: right; width: 560px;">
        <uc2:View ID="View1" runat="server" />
        <uc3:BinhLuan ID="BinhLuan1" runat="server" />
    </div>
</asp:Content>

