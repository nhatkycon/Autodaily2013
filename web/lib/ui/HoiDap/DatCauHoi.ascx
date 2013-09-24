<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatCauHoi.ascx.cs" Inherits="lib_ui_HoiDap_DatCauHoi" %>
<div id="AddCauHoiDialog" class="modal hide fade span12" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Đặt câu hỏi</h3>
    </div>
    <div class="modal-body" style="height: 350px;">
         <div class="row-fluid">
             <div class="span12">
                <div class="form-horizontal">
                    <input placeholder="Tên câu hỏi" class="input-xlarge Ten" style="width: 500px;" size="16" type="text"/>
                    <br/><br/>
                    <div>
                        <div class="input-append">
                            <input data-id="" id="DoTuoi_ID" name="buttondropdown" class="input-xlarge DoTuoi_ID" placeholder="Độ tuổi của bé (hoặc tuổi thai)" type="text"/>
                            <div class="btn-group">
                                <button class="btn DoTuoi_Hint">
                                    Lứa tuổi
                                    <span class="caret"></span>
                                </button>
                            </div>
                        </div>    
                    </div>     
                    <br/>
                    <div>
                        <div class="input-append">
                            <input data-id="" id="DM_ID" name="buttondropdown" class="input-xlarge DM_ID" placeholder="Chọn phân loại cho câu hỏi" type="text"/>
                            <div class="btn-group">
                                <button class="btn DM_Hint">
                                    Phân loại
                                    <span class="caret"></span>
                                </button>
                            </div>
                        </div>    
                    </div>     
                    <br/>
                    <textarea placeholder="Nhập nội dung câu hỏi" class="input-xlarge NoiDung" style="width: 500px;" rows="4"></textarea>
                  	<hr>
                </div>
             </div>
         </div>
    </div>
    <div class="modal-footer">
        <a href="#" data-dismiss="modal" class="btn btn-large">Đóng</a>
        <button type="submit" data-pid="<%=Request["ID"] %>" class="btn btn-large btn-info Savebtn">Lưu</button>        
    </div>
</div>
<style>
    .modal-body {
        max-height: 500px;
    }
</style>
