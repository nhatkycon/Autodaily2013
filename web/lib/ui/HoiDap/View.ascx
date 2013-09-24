<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="lib_ui_HoiDap_View" %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header block-header-liner">
            <div class="block-title">
                <div class="block-title-lbl">
                    <a href="/lib/pages/HoiDap/Default.aspx" class="btn btn-default btn-large">
                        <i class="icon icon-chevron-sign-left"></i> Quay lại
                    </a>
               </div>
            </div>
        </div>
        <div class="block-body thang-list-box">
            <div class="p-title">
                <%=Item.Ten %>
            </div>
            <hr/>   
            <i class="icon icon-calendar"></i> &nbsp;<span class="muted"><%=Item.NgayTao.ToString("dd/MM/yyyy") %> </span>
            &nbsp;
            <i class="icon icon-bookmark"></i> &nbsp;<span class="muted"><%=Item.DoTuoi_Ten %> </span> -&nbsp;<span class="muted"><%=Item._DanhMuc.Ten %> </span>
            <hr/>            
            <%=Item.NoiDung %>
        </div>
    </div>
</div>
