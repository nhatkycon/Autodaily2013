<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddTheoDoi.ascx.cs" Inherits="lib_ui_TheoDoi_AddTheoDoi" %>
<div id="AddTheoDoiDialog" class="modal hide fade span12" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Theo dõi</h3>
    </div>
    <div class="modal-body">
         <div class="row-fluid">
             <div class="span12">
                <form class="form-horizontal">
                    <div class="control-group input-append NgayGhiBox">
                        <label class="control-label" for="NgayGhi">Ngày ghi:</label>
                        <input id="NgayGhi" name="NgayGhi" data-format="dd/MM/yyyy hh:mm:ss" type="text" placeholder="Ngày ghi theo dõi" class="input-xlarge NgayGhi">
                        <span class="add-on">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                        </i>
                        </span>
                    </div>
                    <br/><br/>                    
                    <div style="display: none;" class="LOAISUB_ID_BOX">
                        <div class="input-append">
                            <input data-id="" id="LOAISUB_ID" name="buttondropdown" class="input-medium LOAISUB_ID" placeholder="Mốc theo dõi, vd: Tuần 1" type="text">
                            <div class="btn-group">
                                <button class="btn LOAISUB_hint">
                                    Chọn mốc thời gian
                                    <span class="caret"></span>
                                </button>
                            </div>
                        </div>    
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                      <label class="control-label" for="CanNang">Cân nặng:</label>
                      <div class="controls">
                        <input id="CanNang" name="CanNang" type="text" placeholder="Cân nặng theo gram" class="input-xlarge CanNang">
                        <p class="help-block">ví dụ bé nặng 3,5kg -&gt; 3500</p>
                      </div>
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                      <label class="control-label" for="ChieuCao">Chiều cao:</label>
                      <div class="controls">
                        <input id="ChieuCao" name="ChieuCao" type="text" placeholder="Chiều cao tính theo cm" class="input-xlarge ChieuCao">
                        <p class="help-block">ví dụ: 78</p>
                      </div>
                    </div>
                  	<hr>
                    <p class="well well-large">
                        <b>*&nbsp; Hướng dẫn:</b><br/>
                        - Với bé đã sinh cần nhập cả chiều cao và cân nặng để theo dõi.<br/>
                        - Với biểu đồ dành cho thai chỉ cần cân nặng<br/>
                        - Với biểu đồ cho bà bầu chỉ cần cân nặng
                    </p>
                </form>
             </div>
         </div>
    </div>
    <div class="modal-footer">
        <button type="submit" data-cid="" data-pid="<%=Request["ID"] %>" class="btn btn-large btn-info Savebtn">Lưu</button>        
    </div>
</div>
<style>
    .modal-body {
        max-height: 700px;
    }
</style>
