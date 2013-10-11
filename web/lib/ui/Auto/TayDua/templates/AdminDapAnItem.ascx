<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminDapAnItem.ascx.cs" Inherits="lib_ui_Auto_TayDua_templates_AdminDapAnItem" %>
<div class="DapAn-Item row-fluid" data-id="<%=Item.ID %>">
    <div class="span10">
        <%if(Item.Dung){ %>
        <input type="radio" checked="checked" class="Dung DapAnDung" data-id="<%=Item.ID %>" name="<%=Item.CH_ID %>"/>
        <%}else{ %>
        <input type="radio" class="Dung DapAnDung" data-id="<%=Item.ID %>" name="<%=Item.CH_ID %>"/>
        <%} %>
        <input type="text" class="input-xlarge Ten DapAnTen" value="<%=Item.Ten %>" data-id="<%=Item.ID %>"/>    &nbsp;
        STT: <input type="text" value="<%=Item.ThuTu %>" data-id="<%=Item.ID %>" class="input-mini ThuTu DapAnThuTu"/>     
    </div>
    <div class="pull-right">
        <a data-id="<%=Item.ID %>" href="javascript:;" class="btn removeDapAn">
            <i class="icon icon-remove"></i>
        </a>
    </div>
</div>