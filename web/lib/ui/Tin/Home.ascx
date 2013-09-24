<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home.ascx.cs" Inherits="lib_ui_Tin_Home" %>
<% int i = 0; %>
<% foreach (var Item in List) {%>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="block-title">
                <div class="pull-right">
                    <a class="btn" href="/lib/pages/Tin/DanhMuc.aspx?PHANLOAI_ID=<%=Item.ID %>">
                        <i class="icon icon-arrow-right"></i>
                    </a>
                </div>
               <div class="block-title-lbl">
                   <%=Item.Ten%>
               </div>
            </div>
        </div>
        <div class="block-body thang-list-box">
            <% i = 0; %>
            <% foreach (var item in Item.Tins)
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
<% } %>