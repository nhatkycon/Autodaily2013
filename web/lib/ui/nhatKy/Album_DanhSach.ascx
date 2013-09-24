<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Album_DanhSach.ascx.cs" Inherits="lib_ui_nhatKy_Album_DanhSach" %>
<%@ Import Namespace="docsoft" %>
<div class="full-content effect6">
    <div class="row-fluid">
        <div class="span2">
            <a href="Default.aspx?ID=<%=Request["ID"] %>" class="btn btn-default btn-large">
                <i class="icon icon-chevron-sign-left"></i> Quay lại
            </a>    
        </div>
        <div class="span8">
            <div class="album-view-ten p-title">Danh sách album ảnh của <%=BeItem.Alias %></div>
        </div>
        
    </div>
    <hr class="hr"/>       
     <div class="album-view-anh">
        <% foreach (var item in List)
            {%>
            <div class="anh-album-view-item">
                <a class="anh-img-box" href="/lib/pages/NhatKy/Album.aspx?ID=<%=item.ID %>">
                    <img src="/lib/up/anh/<%=item.AnhDaiDien %>" class="anh-img"/>                    
                </a>
                <div class="anh-album-ten">
                    <%=item.Ten %>
                </div>
            </div>                                  
        <%} %>
    </div>
</div>