<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddBaoCao.ascx.cs" Inherits="lib_ui_TheoDoi_AddBaoCao" %>
<div id="AddBaoCaoTheoDoiDialog" class="modal hide fade span12" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Thêm báo cáo theo dõi</h3>
    </div>
    <div class="modal-body">
         <div class="row-fluid">
             <div class="span12">
                <form class="form-horizontal">
                    <p>
                        <div class="input-append">
                            <input data-id="" id="LOAI_ID" name="buttondropdown" class="input-large LOAI_ID" placeholder="Chọn loại theo dõi" type="text">
                            <div class="btn-group">
                                <button class="btn LOAI_hint">
                                    Loại theo dõi
                                    <span class="caret"></span>
                                </button>
                            </div>
                        </div>    
                    </p>   
                    <!-- Text input-->
                    <div class="control-group">
                      <label class="control-label" for="Ten">Tên báo cáo:</label>
                      <div class="controls">
                        <input id="Ten" name="Ten" type="text" placeholder="Tên bảng theo dõi, ví dụ: Cân nặng của nhím" class="input-xlarge Ten">
                      </div>
                    </div>
                  	<hr>                    
                </form>
             </div>
         </div>
    </div>
    <div class="modal-footer">
        <a href="#" data-dismiss="modal" class="btn btn-large">Đóng</a>
        <button type="submit" data-cid="" data-pid="<%=Request["ID"] %>" class="btn btn-large btn-info Savebtn">Lưu</button>        
    </div>
</div>
<style>
    .modal-body {
        max-height: 700px;
    }
</style>
