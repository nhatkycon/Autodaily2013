<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BinhLuan_PureTemplates.ascx.cs" Inherits="lib_ui_nhatKy_templates_BinhLuan_PureTemplates" %>
<%@ Import Namespace="docsoft" %>
<div data-id="<%=Item.ID %>" data-date="<%=Item.NgayTao.ToString("yyyy-MM-dd HH:mm:s.ms") %>" class="binhLuan-Item">
    <hr/>
    <a href="/lib/pages/CaNhan/Profile.aspx?U=<%=Item.Username %>" class="binhLuan-Item-Avatar">
        <img src="/lib/up/i/<%=Item._Member.Anh %>" class="binhLuan-Item-img"/>
    </a>
    <div class="binhLuan-Item-Body">
        <%if(Security.Username== Item.Username){ %>
        <a href="javascript:;" class="btn btn-default binhLuan-Item-Xoa pull-right" data-id="<%=Item.ID %>">Xóa</a>            
        <%} %>
        <a class="binhLuan-Item-Username" href="/lib/pages/CaNhan/Profile.aspx?U=<%=Item.Username %>">
            <%=Item._Member.Ten %>
        </a>
        <span class="binhLuan-Item-Date">
            lúc <%= Item.NgayTao.ToString("HH:mm dd/MM/yy")%>
        </span>
        <div class="binhLuan-Item-NoiDung">
            <%=Item.NoiDung %>
        </div>
        <div class="binhLuan-Item-Task ">
        </div>
    </div>
</div>