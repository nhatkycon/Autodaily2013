<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigator.ascx.cs" Inherits="lib_ui_TheoDoi_Navigator" %>
<%@ Import Namespace="docsoft" %>
<%@ Register src="~/lib/ui/heThong/NavigatorBased.ascx" tagname="navi" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/TheoDoi/AddBaoCao.ascx" tagname="AddBaoCao" tagprefix="uc3" %>
<div class="post-box effect2">
    <div class="navigation">
        <div class="pull-right">
            <%if(BeItem != null && BeItem.Username==Security.Username){ %>
            <a href="#AddBaoCaoTheoDoiDialog" class="btn btn-primary btn-large" data-toggle="modal">Thêm báo cáo theo dõi</a>
            <%} %>
            <%if (List.Any()){ %>
            <a href="#" class="btn btn-default btn-large dropdown-toggle" data-toggle="dropdown">
                <span class="navigation-lbl">Theo dõi</span>                        
                <span class="caret"></span>
            </a>
            <ul class="dropdown-menu">
                <% foreach (var item in List)
                   {%>
                   <li><a href="/lib/pages/TheoDoi/View.aspx?BCTD_ID=<%=item.ID %>&ID=<%=item.PID_ID %>">
                           <%=item.Ten %>
                       </a></li> 
                <%   } %>                
            </ul>
            <%} %>
        </div>
        <uc3:AddBaoCao ID="AddBaoCao1" runat="server" />
        <uc1:navi ID="navi1" runat="server"/>
    </div>
</div>
