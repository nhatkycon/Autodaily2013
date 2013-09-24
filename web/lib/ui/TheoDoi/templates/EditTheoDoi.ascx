<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditTheoDoi.ascx.cs" Inherits="lib_ui_TheoDoi_templates_EditTheoDoi" %>
<div id="AddTheoDoiDialog-<%=Item.ID %>" class="modal hide fade span12 EditTheoDoiDialog" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Sửa theo dõi</h3>
    </div>
    <div class="modal-body">
         <div class="row-fluid">
             <div class="span12">
                <form class="form-horizontal">
                    <div class="control-group input-append NgayGhiBox">
                        <input value="<%=Item.NgayGhi == DateTime.MinValue ? "" : Item.NgayGhi.ToString("dd/MM/yyyy hh:mm:ss") %>" id="NgayGhi" name="NgayGhi" data-format="dd/MM/yyyy hh:mm:ss" type="text" placeholder="Ngày ghi theo dõi" class="input-xlarge NgayGhi">
                        <span class="add-on">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                        </i>
                        </span>
                    </div>
                    <div style="display: none;" class="control-group LOAISUB_ID_BOX">
                        <div class="input-append">
                            <input data-pid="<%=Item.LOAI_ID %>" value="<%=Item._DanhMuc.Ten %>" data-id="<%=Item.LOAISUB_ID %>" id="LOAISUB_ID" name="buttondropdown" class="input-medium LOAISUB_ID" placeholder="Mốc theo dõi, vd: Tuần 1" type="text">
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
                        <input value="<%=Item.CanNang %>" id="CanNang" name="CanNang" type="text" placeholder="Cân nặng theo gram" class="input-xlarge CanNang">
                        <p class="help-block">ví dụ bé nặng 3,5kg -&gt; 3500</p>
                      </div>
                    </div>
                    <!-- Text input-->
                    <div class="control-group">
                      <label class="control-label" for="ChieuCao">Chiều cao:</label>
                      <div class="controls">
                        <input value="<%=Item.ChieuCao %>" id="ChieuCao" name="ChieuCao" type="text" placeholder="Chiều cao tính theo cm" class="input-xlarge ChieuCao">
                        <p class="help-block">ví dụ: 78</p>
                      </div>
                    </div>
                  	<hr>
                    <p class="well well-large">
                        <b>*&nbsp; Hướng dẫn:</b><br/>
                        - Với biểu đồ cho bà bầu chỉ cần cân nặng
                    </p>
                </form>
             </div>
         </div>
    </div>
    <div class="modal-footer">
        <a href="#" data-dismiss="modal" class="btn btn-large">Đóng</a>
        <button type="submit" data-id="<%=Item.ID %>" class="btn btn-large btn-info Savebtn">Lưu</button>
    </div>
</div>