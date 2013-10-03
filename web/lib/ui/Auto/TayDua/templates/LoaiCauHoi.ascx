<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoaiCauHoi.ascx.cs" Inherits="lib_ui_Auto_TayDua_templates_LoaiCauHoi" %>
<%@ Register src="~/lib/ui/Auto/TayDua/templates/LoaiCauHoiItem.ascx" tagname="LoaiCauHoiItem" tagprefix="uc1" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:LoaiCauHoiItem ID="LoaiCauHoiItem1" runat="server" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>

