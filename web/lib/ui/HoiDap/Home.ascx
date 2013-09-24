<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home.ascx.cs" Inherits="lib_ui_HoiDap_Home" %>
<% int i = 0; %>
<% foreach (var Item in List) {%>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="block-title">
                <div class="pull-right">
                    <a class="btn" href="/lib/pages/HoiDap/PhanLoai.aspx?PHANLOAI_ID=<%=Item.ID %>">
                        <i class="icon icon-arrow-right"></i>
                    </a>
                </div>
               <div class="block-title-lbl">
                   <%=Item.Ten%>
               </div>
            </div>
        </div>
        <div class="block-body thang-list-box">
            <% i = 1; %>
            <% foreach (var item in Item.SpaHoiDaps)
               {%>
               <div class="hoiDap-my-item">
                 <a href="/lib/pages/HoiDap/View.aspx?ID=<%=item.ID %>">
                    <%=i %>. &nbsp; <%=item.Ten %>
                 </a>
                 <div class="pull-right">
                     <%if (item.DaTraLoi)
                       { %>
                       <span class="label label-success">Đã trả lời</span>
                     <% }
                       else
                       {%>
                       <span class="label">Chưa có trả lời</span>  
                      <% } %>
                 </div>
             </div>  
               <% i++; %>  
            <% } %>
        </div>
    </div>
</div>
<% } %>