<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TraLoi.ascx.cs" Inherits="lib_ui_HoiDap_TraLoi" %>
<div id="AddTraLoiDialog" class="modal hide fade span12" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Trả lời</h3>
    </div>
    <div class="modal-body" style="height: 350px;">
         <div class="row-fluid">
             <div class="span12">
                <div class="form-horizontal">
                    <textarea placeholder="Nhập nội dung câu trả lời" class="input-xlarge NoiDung" style="width: 500px;" rows="4"></textarea>
                  	<hr>
                </div>
             </div>
         </div>
    </div>
    <div class="modal-footer">
        <a href="#" data-dismiss="modal" class="btn btn-large">Đóng</a>
        <button type="submit" data-hd-id="<%=Item.ID %>" class="btn btn-large btn-info Savebtn">Lưu</button>        
    </div>
</div>
<style>
    .modal-body 
    {
        height: 300px;
    }
</style>