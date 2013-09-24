<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation_Anh.ascx.cs" Inherits="lib_ui_Home_Navigation_Anh" %>
<%@ Import Namespace="docsoft" %>
<%@ Register src="~/lib/ui/heThong/NavigatorBased.ascx" tagname="navi" tagprefix="uc1" %>
<div class="post-box effect2">
    <div class="navigation">
        <%if(BeItem != null && BeItem.Username==Security.Username){ %>
        <div class="pull-right" >
            <a href="/lib/pages/NhatKy/Album_Add.aspx?ID=<%=Request["ID"] %>" class="btn btn-primary btn-large">Thêm album ảnh</a>
        </div>
        <%} %>
        <uc1:navi ID="navi1" runat="server"/>
    </div>
</div>