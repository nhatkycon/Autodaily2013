<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HoatDong_Add.ascx.cs" Inherits="lib_ui_nhatKy_HoatDong_Add" %>
<div id="AddHoatDongDialog" class="modal hide fade span12" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Ghi lại mốc sự kiện</h3>
    </div>
    <div class="modal-body" style="height: 400px;">
         <div class="row-fluid">
             <div class="span12">
                <div class="form-horizontal">
                    <div class="input-append NgayVietBox">
                        <input name="NgayViet" data-format="dd/MM/yyyy hh:mm:ss" type="text" placeholder="Ngày nhật ký" class="input-xlarge NgayViet"/>
                        <span class="add-on">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                        </i>
                        </span>
                    </div>
                    <br/><br/>
                    <input placeholder="Tên sự kiện đầy đủ, ví dụ: Nhím mọc răng hôm nay làm mẹ lo quá..." class="input-xlarge Ten" style="width: 500px;" size="16" type="text"/>
                    <div class="blog-post-img-box">
                        <img class="blog-post-img" src="" />
                        <div class="blog-post-doiAnhBtn">
                            <a href="javascript:;" class="btn btn-success">Đổi ảnh</a>                            
                        </div>
                    </div>   
                    <div>
                        <div class="input-append">
                            <input data-id="" id="HoatDong_ID" name="buttondropdown" class="input-medium HoatDong_ID" placeholder="Chọn loại sự kiện" type="text"/>
                            <div class="btn-group">
                                <button class="btn HoatDong_hint">
                                    Loại sự kiện
                                    <span class="caret"></span>
                                </button>
                            </div>
                        </div>    
                    </div>     
                    <textarea placeholder="Nội dung bài viết của bạn" class="input-xlarge NoiDung" style="width: 500px;" rows="4"></textarea>
                    <hr/>
                </div>
             </div>
         </div>
    </div>
    <div class="modal-footer">
        <button type="submit" data-pid="<%=Request["ID"] %>" class="btn btn-large btn-info Savebtn">Gửi</button>        
    </div>
</div>
<style>
    .modal-body {
        max-height: 700px;
    }
</style>
