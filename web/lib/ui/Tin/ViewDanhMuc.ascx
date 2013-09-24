<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewDanhMuc.ascx.cs" Inherits="lib_ui_Tin_ViewDanhMuc" %>
<%if(pager.List.Any()){ %>
<% int i = 0; %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="block-title">
                <div class="block-title-lbl">
                    <%if (PhanLoai != null)
                      { %>
                    <%=PhanLoai.Ten%>
                    <%} %>
                    <%if(Item != null){ %>
                    &nbsp;
                    <%=Item.Ten %>
                    <%} %>
               </div>
            </div>
        </div>
        <div class="block-body thang-list-box">
            <% foreach (var item in pager.List)
               {%>
               <div class="tin-dm-item<% =(i==0 ? " tin-dm-itemBig" : "") %>">
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
               <% i++; %>  
            <% } %>
        </div>
    </div>
</div>
<%} %>