<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation.ascx.cs" Inherits="lib_ui_GiaDinh_Navigation" %>
<%@ Import Namespace="docsoft" %>
<%@ Register src="~/lib/ui/heThong/NavigatorBased.ascx" tagname="navi" tagprefix="uc1" %>
<%@ Register src="ThemMoi.ascx" tagname="ThemMoi" tagprefix="uc2" %>
<div class="post-box effect2">
    <div class="navigation">
        <%if(BeItem != null && BeItem.Username==Security.Username){ %>
        <div class="pull-right" >
            <a href="#AddGiaDinhDialog" data-toggle="modal" class="btn btn-primary btn-large">Thêm thành viên</a>
        </div>
        <uc2:ThemMoi ID="ThemMoi1" runat="server" />
        <%} %>
        <uc1:navi ID="navi1" runat="server"/>
    </div>
</div>
