<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThemMoi.ascx.cs" Inherits="lib_ui_GiaDinh_ThemMoi" %>
<div id="AddGiaDinhDialog" class="modal hide fade span12" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Thêm thành viên gia đình</h3>
    </div>
    <div class="modal-body" style="height: 350px;">
         <div class="row-fluid">
             <div class="span12">
                <div class="form-horizontal">
                    <input placeholder="Tên thành viên, ví dụ: Nguyễn Xuân Linh" class="input-xlarge Ten" style="width: 500px;" size="16" type="text"/>
                    <br/><br/>
                    <input placeholder="Địa chỉ e-mail nếu có" class="input-xlarge Email" style="width: 500px;" size="16" type="email"/>
                    <div class="blog-post-img-box">
                        <img class="blog-post-img" src="" />
                        <div class="blog-post-doiAnhBtn">
                            <a href="javascript:;" class="btn btn-success">Đổi ảnh</a>                            
                        </div>
                    </div>   
                    <div>
                        <div class="input-append">
                            <input data-id="" id="LOAI_ID" name="buttondropdown" class="input-medium LOAI_ID" placeholder="Ví dụ: Bố, Ông nội" type="text"/>
                            <div class="btn-group">
                                <button class="btn HoatDong_hint">
                                    Quan hệ với bé
                                    <span class="caret"></span>
                                </button>
                            </div>
                        </div>    
                    </div>     
                    <textarea placeholder="Vài dòng giới thiệu" class="input-xlarge NoiDung" style="width: 500px;" rows="2"></textarea>
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
