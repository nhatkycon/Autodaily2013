<%@ Control Language="C#" AutoEventWireup="true" CodeFile="traLoi.ascx.cs" Inherits="lib_ui_HoiDap_templates_traLoi" %>
<hr/>
<div class="traLoi-item row-fluid">
    <%if (!string.IsNullOrEmpty(Item._Member.Anh))
        { %>
    <div class="span3">
        <a href="/lib/pages/CaNhan/Profile.aspx?U=<%=Item.NguoiTao %>">
            <img class="img-rounded media-object" src="/lib/up/i/<%=Item._Member.Anh %>">
        </a>   
    </div>
    <%} %>
    <div class="span9">
        <div class="pull-right">
            <%if(Item.DaTraLoi){ %>    
            <a data-id="<%=Item.ID %>" href="javascript:;" class="btn btn-large daTraLoi">
                <i class="icon icon-thumbs-up"></i>
            </a>
            <%}else { %>
            <a data-id="<%=Item.ID %>" href="javascript:;" class="btn btn-large">
                <i class="icon icon-thumbs-up"></i>
            </a>
            <%} %>
        </div>
        <%=Item.NoiDung%>
        <p>
            <span class="muted">
                <%=Item.NgayTao.ToString("dd/MM/yyyy")%>
            </span>
        </p>
    </div>
                       
</div>