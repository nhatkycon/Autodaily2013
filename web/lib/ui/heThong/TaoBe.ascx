<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaoBe.ascx.cs" Inherits="lib_ui_heThong_TaoBe" %>
<form class="form-horizontal">
<fieldset>

<!-- Form Name -->
<legend>Tạo nhật ký cho bé</legend>

<!-- Text input-->
<div class="control-group">
  <label class="control-label" for="Alias">Tên cúng cơm:</label>
  <div class="controls">
    <input title="Tên cúng cơm hay tên gọi ở nhà của bé" id="Alias" name="Alias" type="text" placeholder="Tên gọi yêu của bé, vd: Nhím, bông" class="tooltips input-xlarge" required="">
  </div>
</div>

<!-- Multiple Radios (inline) -->
<div class="control-group">
  <label class="control-label" for="MangThai">Bé đã sinh chưa</label>
  <div class="controls">
    <label class="radio inline" for="MangThai-0">
      <input type="radio" checked="checked" name="MangThai" id="MangThai-0" value="1" checked="checked">
      Đang mang thai
    </label>
    <label class="radio inline" for="MangThai-1">
      <input type="radio" name="MangThai" id="MangThai-1" value="0">
      Đã sinh
    </label>
  </div>
</div>

<div class="DaSinh">
    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="Ho">Họ và tên đệm:</label>
      <div class="controls">
        <input id="Ho" name="Ho" type="text" placeholder="Nguyễn Hữu" class="input-xlarge" required="">
    
      </div>
    </div>

    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="Ten">Tên:</label>
      <div class="controls">
        <input id="Ten" name="Ten" type="text" placeholder="Đức" class="input-xlarge">
    
      </div>
    </div>

    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="NgaySinh">Ngày sinh:</label>
      <div class="controls">
           <div id="NgaySinhBox" title="Bạn hãy chọn ngày sinh và giờ sinh chuẩn cho bé nhé" class="tooltips input-append">
            <input id="NgaySinh" data-format="dd/MM/yyyy hh:mm:ss" name="NgayDuSinh" type="text" placeholder="10/05/2013" class="input-xlarge">
            <span class="add-on">
                <i class="icon-calendar" data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
            </span>      
          </div>
      </div>
    </div>

    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="CanNang">Cân nặng khi sinh:</label>
      <div class="controls">
        <input id="CanNang" name="CanNang" type="number" placeholder="3200" class="input-xlarge">
        <p class="help-block">Cân của bé tính theo gram bạn nhé</p>
      </div>
    </div>

    <!-- Multiple Checkboxes (inline) -->
    <div class="control-group">
      <label class="control-label" for="GioiTinh">Giới tính của bé</label>
      <div class="controls">
        <label class="checkbox inline" for="GioiTinh">
          <input type="checkbox" name="GioiTinh" id="GioiTinh" value="Nam">
          Nam
          <p class="help-block">
              Nếu bé là bé gái thì không tíc vào ô này bạn thân yêu nhé
          </p>
        </label>
      </div>
    </div>
    
</div>
<div class="ChuaSinh">
    <!-- Text input-->
    <div class="control-group">
      <label class="control-label" for="NgayDuSinh">Ngày dự sinh</label>
      <div class="controls">
          <div id="NgayDuSinhBox" title="Bạn hãy nhập ngày dự sinh chuẩn xác cho bé nhé" class="tooltips input-append NgayDuSinhBox">
            <input id="NgayDuSinh" data-format="dd/MM/yyyy hh:mm:ss" name="NgayDuSinh" type="text" placeholder="10/05/2013" class="input-xlarge">
            <span class="add-on">
                <i class="icon-calendar" data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
            </span>      
          </div>
        
        <p class="help-block">Ngày sinh dự tính của bé theo bác sĩ nhé</p>
      </div>
    </div>    
</div>
<hr/>
<!-- Button (Double) -->
<div class="control-group">
  <label class="control-label" for="SaveBe"></label>
  <div class="controls">
    <a href="/lib/pages/CaNhan/" id="BoQua" name="BoQua" class="btn btn-large">Tôi sẽ tạo bé sau</a> &nbsp;
    <button id="SaveBe" name="SaveBe" class="btn btn-primary btn-large">Lưu</button>
  </div>
</div>
    <div id="msgRegisterDone" style="display: none;" class="alert alert-success"></div>
    <div id="msgRegisterMissing" style="display: none;" class="alert alert-error"></div>
</fieldset>
</form>
<script>
    $('.tooltips').tooltip({ 'placement': 'bottom' });
</script>