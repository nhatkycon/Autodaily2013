<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CaiDat.ascx.cs" Inherits="lib_ui_CaNhan_CaiDat" %>
<div class="full-content effect6 CaiDatForm">
    <div class="row-fluid">
            <h2>
                Thông tin cá nhân
            </h2>
            <hr/>
            <div class="control-group">
                <label class="control-label" for="Ten">Họ và Tên:</label>
                <div class="controls">
                    <input value="<%=Item.Ten %>" id="Ten" name="Ten" type="text" placeholder="vd: Nguyễn Xuân Linh" class="input-xlarge Ten" required=""/>
                </div>
            </div>
            <div class="blog-post-img-box">
                <img class="blog-post-img" src="/lib/up/i/<%=Item.Anh %>" />
                <div class="blog-post-doiAnhBtn">
                    <a href="javascript:;" class="btn btn-success">Đổi ảnh</a>                            
                </div>
            </div>   
            <hr>
            <button type="submit" data-pid="<%=Item.ID %>" class="btn btn-large btn-info Savebtn">Lưu thông tin</button>
            <a href="/lib/pages/CaNhan/" class="btn btn-default btn-large">Bỏ qua</a>
            <br/><br/>
            <p>
                <div style="display: none;" class="alert alert-success msgCaiDatDone">
                    Bạn đã lưu thành công nhé!
                </div>
                <div style="display: none;" class="alert alert-error msgCaiDatMissing">
                    Nhập tên bạn ơi!
                </div>
            </p>
    </div>
</div>

<script src="/lib/js/web/CaNhan.js" type="text/javascript"></script>
