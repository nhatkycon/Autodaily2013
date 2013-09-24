<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Video_Add.ascx.cs" Inherits="lib_ui_nhatKy_Video_Add" %>
<div id="AddVideoDialog" class="modal hide fade span12" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Thêm video từ Youtube</h3>
    </div>
    <div class="modal-body" style="height: 400px;">
         <div class="row-fluid">
                <div class="form-horizontal">
                    <input placeholder="Đường dẫn video trên Youtube, ví dụ: www.youtube.com/watch?v=8ZsFd2j35t0" class="input-xlarge Url" style="width: 500px;" size="16" type="text"/>
                    <br/><br/>
                    <div class="input-append NgayVietBox">
                        <input name="NgayViet" data-format="dd/MM/yyyy hh:mm:ss" type="text" placeholder="Ngày nhật ký" class="input-xlarge NgayViet"/>
                        <span class="add-on">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                        </i>
                        </span>
                    </div>
                    <br/><br/>
                    <input placeholder="Tiêu đề video của bạn" class="input-xlarge Ten" style="width: 500px;" size="16" type="text"/>
                    <hr/>
                    <div class="well-large video-view">
                        <iframe data-yid="" data-img="" id="youtube-view" style="display: none;" width="500" height="281" src="" frameborder="0" allowfullscreen></iframe>
                    </div>
                </div>
         </div>
    </div>
    <div class="modal-footer">
        <button type="submit" data-pid="<%=Request["ID"] %>" class="btn btn-large btn-info Savebtn">Gửi</button>        
    </div>
</div>

