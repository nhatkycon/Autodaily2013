<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="lib_ui_HoiDap_Menu" %>
<% foreach (var Item in List1)
               {%>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header block-header-liner">
            <div class="block-title">
                <div class="block-title-lbl">
                  Hỏi đáp &nbsp; <%=Item.Ten%>
               </div>
            </div>
        </div>
        <div class="block-body thang-list-box">
            <% var list = from p in List
                          where p.PID == Item.ID
                orderby p.ThuTu
                select p; %>
                <% foreach (var item in list)
                   {%>
                   <a data-toggle="tooltip" title="<%=Item.Ten %> <%=item.Ten %>" class="thang-list-item" href="/lib/pages/HoiDap/DanhMuc.aspx?DM_ID=<%=item.ID %>">
                   <%=item.ThuTu %>                       
                   </a>
                 <%  } %>
        </div>
    </div>
</div>
<% } %>
<script>
    $('.thang-list-item').tooltip({ placement: 'bottom' });
</script>  