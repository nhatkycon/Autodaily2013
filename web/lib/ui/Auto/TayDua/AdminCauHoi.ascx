<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminCauHoi.ascx.cs" Inherits="lib_ui_Auto_TayDua_AdminCauHoi" %>


<%@ Register src="~/lib/ui/Auto/TayDua/templates/AdminCauHoiItem.ascx" tagname="AdminCauHoiItem" tagprefix="uc2" %>

<%@ Register src="~/lib/ui/Auto/TayDua/templates/LoaiCauHoi.ascx" tagname="LoaiCauHoi" tagprefix="uc1" %>
<div class="TayDuaCauHoiAdmin">
    <div class="post-box effect2  CauHoiThem">
        <div class="navigation">
            <button class="btn btn-primary addBtn">Thêm</button> &nbsp; 
            <div class="row-fluid spacer addPnl">
            </div>
        </div>
    </div>
    <div class="CauHoiList">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc2:AdminCauHoiItem ID="AdminCauHoiItem1" runat="server" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<script src="/lib/js/jquery.tmpl.min.js" type="text/javascript"></script>
<script id="CauHoiItem" type="text/x-jquery-tmpl">
    <div  data-id="${ID}" class="well well-large addForm" style="margin-top: 10px;">
        <div class="row row-fluid">
            <div class="span1">Tên: </div>
            <div class="span8">
                <input value="${Ten}" class="input-xxlarge Ten" type="text"/>
            </div>
            <div class="span1" style="display: none;">Thứ tự: </div>
            <div class="span1" style="display: none;">
                <input value="${ThuTu}" class="input-mini ThuTu" type="text"/>
            </div>
        </div>
        <div class="row row-fluid">
            <div class="span1">Loại: </div>
            <div class="span8">
                <select class="LOAI_ID">
                    <uc1:LoaiCauHoi ID="LoaiCauHoi1" runat="server" />                
                </select>
            </div>
            <div class="span1">Độ khó: </div>
            <div class="span1">
                <select class="Diem">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>
            </div>
        </div>
        <div class="row row-fluid">
            <div class="span1">Mô tả: </div>
            <div class="span11">
                <textarea class="input-xxlarge MoTa">${MoTa}</textarea>
            </div>
        </div>
        
       <div class="row row-fluid spacer">
           <div class="span2">
            </div>
            <div class="span10">
                <button data-id="${ID}" class="btn btn-info cancelBtn">Hủy</button> &nbsp; <button data-id="${ID}" class="btn btn-primary saveBtn">Lưu</button>
            </div>
        </div>
    </div>
</script>
    <style>
    .spacer {
        margin-top: 20px; /* define margin as you see fit */
    }
    .AnhDaiDien {
        display: inline-block;
        width: 120px;
        height: 80px;
    }
    .Anh {
        display: inline-block;
        width: 200px;
        height: 150px;
    }
     .DapAnPnl {
        display: none;
    }
</style>
