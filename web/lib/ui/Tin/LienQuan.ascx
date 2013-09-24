<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LienQuan.ascx.cs" Inherits="lib_ui_Tin_LienQuan" %>
<%if(List.Any()){ %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="block-title">
                <div class="block-title-lbl">
                    Bài viết liên quan
               </div>
            </div>
        </div>
        <div class="block-body thang-list-box">
            <% foreach (var item in List)
               {%>
               <div class="tin-dm-item">
                   <div class="tin-item-imgBox">
                       <img class="tin-item-img" src="/lib/up/tintuc/<%=item.Anh %>"/>
                   </div>
                   <a href="/lib/pages/Tin/View.aspx?ID=<%=item.ID %>" class="tin-item-ten">
                       <%=item.Ten %>
                   </a>
                   <div class="tin-item-moTa">
                       <%=item.MoTa %>
                   </div>
               </div>
            <% } %>
        </div>
    </div>
</div>
<%} %>