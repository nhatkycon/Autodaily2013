<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TrangThaiBe.ascx.cs" Inherits="lib_ui_HoiDap_TrangThaiBe" %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header block-header-liner">
            <div class="block-title">
                <div class="block-title-lbl">
                  Danh sách bé
               </div>
            </div>
        </div>
        <div class="block-body">
            <% foreach (var item in List)
               {%>
              <div class="">
                  <%=item.Alias %> &nbsp; <%=linh.common.Lib.ThangTuoi(item.MangThai,item.MangThai ? item.NgayDuSinh : item.NgaySinh) %> tháng
              </div>
              <hr/>
            <%   } %>
        </div>
    </div>
</div>