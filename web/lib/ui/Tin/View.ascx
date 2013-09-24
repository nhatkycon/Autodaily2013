<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="lib_ui_Tin_View" %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="block-title">
                <div class="block-title-lbl">
               </div>
            </div>
        </div>
        <div class="block-body thang-list-box">
            <h1 class="p-title">
                <%=Item.Ten %>
            </h1>
            <hr/>
            <p class="p-subTitle muted">
                <%=Item.MoTa %>
            </p>
            <%=Item.NoiDung %>
        </div>
    </div>
</div>
