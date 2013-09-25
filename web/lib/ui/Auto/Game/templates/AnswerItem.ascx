<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AnswerItem.ascx.cs" Inherits="lib_ui_Auto_Game_templates_AnswerItem" %>
<div class="row-fluid item-anh-uploadPreview" data-id="<%=Item.ID %>">
    <div class="span3">
        <div class="anh-img-box">
            <img src="/lib/up/i/<%=Item.Anh %>" class="anh-img"/>
        </div>
    </div>    
    <div class="span9">
        <input data-id="<%=Item.ID %>" class="input-mini ThuTu ThuTuAnh" value="<%=Item.ThuTu %>" type="text"/>
        <button class="btn btn-warning XoaAnhBtn" data-id="<%=Item.ID %>" style="margin-bottom: 10px;">Xóa</button>
    </div>
</div>