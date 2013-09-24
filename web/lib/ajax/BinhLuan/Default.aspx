<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_ajax_BinhLuan_Default" %>
<%@ Register src="../../ui/nhatKy/templates/BinhLuan_PureTemplates.ascx" tagname="BinhLuan_PureTemplates" tagprefix="uc1" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:BinhLuan_PureTemplates ID="BinhLuan_PureTemplates1" Item='<%# Container.DataItem %>' runat="server" />        
    </ItemTemplate>
</asp:Repeater>
<uc1:BinhLuan_PureTemplates Visible="False" ID="BinhLuan_PureTemplates2" runat="server" />        
