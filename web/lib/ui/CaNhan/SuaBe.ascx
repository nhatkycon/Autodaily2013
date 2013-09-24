<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuaBe.ascx.cs" Inherits="lib_ui_CaNhan_SuaBe" %>
<form class="form-horizontal">
<fieldset>

<!-- Form Name -->
<legend>Chỉnh sửa</legend>

<!-- Text input-->
<div class="control-group">
  <label class="control-label" for="Alias">Tên cúng cơm:</label>
  <div class="controls">
    <input id="Alias" name="Alias" value="<%=BeItem.Alias %>" type="text" placeholder="Tên gọi yêu của bé, vd: Nhím, bông" class="input-xlarge" required="">
  </div>
</div>

<!-- Multiple Radios (inline) -->
<div class="control-group">
  <label class="control-label" for="MangThai">Bé đã sinh chưa</label>
  <div class="controls">
    <label class="radio inline" for="MangThai-0">
      <input type="radio" checked="checked" name="MangThai" id="MangThai-0" value="1" checked="<%=BeItem.MangThai ? "checked" : "" %>">
      Đang mang thai
    </label>
    <label class="radio inline" for="MangThai-1">
      <input type="radio" name="MangThai" id="MangThai-1" value="0" checked="<%=!BeItem.MangThai ? "checked" : "" %>">
      Đã sinh
    </label>
  </div>
</div>

<div class="DaSinh" style="display: <%=BeItem.MangThai ? "none;" : "block;" %>">
    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="Ho">Họ và tên đệm:</label>
      <div class="controls">
        <input id="Ho" name="Ho" value="<%=BeItem.Ho %>" type="text" placeholder="Nguyễn Hữu" class="input-xlarge" required="">
    
      </div>
    </div>

    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="Ten">Tên:</label>
      <div class="controls">
        <input id="Ten" name="Ten" value="<%=BeItem.Ten %>" type="text" placeholder="Đức" class="input-xlarge">
    
      </div>
    </div>

    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="NgaySinh">Ngày sinh:</label>
      <div class="controls">
          <div id="NgaySinhBox" class="input-append NgaySinhBox">
            <input id="NgaySinh" name="NgaySinh" value="<%=BeItem.MangThai? "" : BeItem.NgaySinh.ToString("dd/MM/yyyy hh:mm:ss") %>" data-format="dd/MM/yyyy hh:mm:ss" type="text" placeholder="20/06/2013" class="input-xlarge">
            <span class="add-on">
            <i data-time-icon="icon-time" data-date-icon="icon-calendar">
            </i>
            </span>
        </div>
      </div>
    </div>

    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="CanNang">Cân nặng khi sinh:</label>
      <div class="controls">
        <input id="CanNang" value="<%=BeItem.MangThai? "" : BeItem.CanNangKhiSinh.ToString() %>" name="CanNang" type="number" placeholder="3200" class="input-xlarge">
        <p class="help-block">Cân của bé tính theo gram bạn nhé</p>
      </div>
    </div>

    <!-- Multiple Checkboxes (inline) -->
    <div class="control-group">
      <label class="control-label" for="GioiTinh">Giới tính của bé</label>
      <div class="controls">
        <label class="checkbox inline" for="GioiTinh">            
          <input type="checkbox" name="GioiTinh" checked="<%=BeItem.GioiTinh ? "checked" : "" %>" id="GioiTinh" value="Nam">
          Nam
        </label>
      </div>
    </div>
    
</div>
<div class="ChuaSinh"style="display: <%=!BeItem.MangThai ? "none;" : "block;" %>">
    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="NgayDuSinh">Ngày dự sinh</label>
      <div class="controls">
          <div id="NgayDuSinhBox" class="input-append NgayDuSinhBox">
            <input id="NgayDuSinh" value="<%=!BeItem.MangThai? "" : BeItem.NgayDuSinh.ToString("dd/MM/yyyy hh:mm:ss") %>" data-format="dd/MM/yyyy hh:mm:ss" name="NgayDuSinh" type="text" placeholder="10/05/2013" class="input-xlarge">
            <span class="add-on">
                <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
            </span>      
          </div>
        
        <p class="help-block">Ngày sinh dự tính của bé theo bác sĩ nhé</p>
      </div>
    </div>    
</div>
<!-- Button (Double) -->
<hr/>
<div class="control-group">
  <label class="control-label" for="SaveBe"></label>
  <div class="controls">
    <button id="SaveBe" name="SaveBe" data-id="<%=BeItem.ID %>" class="btn btn-primary btn-large">Lưu</button>
    <a href="/lib/pages/CaNhan/QuanLyBe.aspx" id="BoQua" name="BoQua" class="btn btn-info  btn-large">Bỏ qua</a>
  </div>
</div>
    <div id="msgRegisterDone" style="display: none;" class="alert alert-success"></div>
    <div id="msgRegisterMissing" style="display: none;" class="alert alert-error"></div>
</fieldset>
</form>
<script src="/lib/js/web/CaNhan.js" type="text/javascript"></script>