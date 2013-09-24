<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DoiNick.ascx.cs" Inherits="lib_ui_CaNhan_DoiNick" %>
<div id="NickDialog" class="modal hide fade span12" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Đổi nick truy cập</h3>
    </div>
    <div class="modal-body">
         <div class="row-fluid">
             <div class="span12">
                <div class="form-horizontal">
                    <br/><br/>
                    Http://NhatKyCon.vn/<input placeholder="Nick cho bé" class="input-mini Nick" style="" type="text"/>
                    <br/>
                    <br/>
                    <p class="well well-large">
                        Địa chỉ nhật ký của bé có dạng:<br/>
                        Http://NhatKyCon.vn/<strong><span class="NickPath"></span></strong>
                    </p>
                    <hr/>
                    <p style="display: none;" class="alert alert-success">
                        <strong>Bạn đã đổi nick cho bé thành công</strong>
                    </p>
                    <p style="display: none;" class="alert alert-error">
                        <strong>Nick này đã tồn tại, vui lòng chọn nick khác cho bé</strong>
                    </p>
                </div>
             </div>
         </div>
    </div>
    <div class="modal-footer">
        <button type="submit" data-id="" class="btn btn-large btn-info Savebtn">Đổi Nick</button>        
        <a href="#" data-dismiss="modal" class="btn btn-large">Đóng</a>
    </div>
</div>
<style>
    .modal-body {
        max-height: 600px;
    }
</style>