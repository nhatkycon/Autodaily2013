<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="lib_ui_heThong_Login" %>
<div id="loginDialog" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3 id="myModalLabel">Đăng nhập</h3>
    </div>
    <div id="loginForm" class="form-horizontal">
        <fieldset>
        <!-- Form Name -->
        <br/>
        <!-- Text input-->
        <div class="control-group">
          <label class="control-label" for="Email">E-mail:</label>
          <div class="controls">
            <input id="Email"  name="Email" type="email" placeholder="Ví dụ: linhnx@me.com" class="input-xlarge" required="">
          </div>
        </div>

        <!-- Password input-->
        <div class="control-group">
          <label class="control-label" for="Password">Mật khẩu:</label>
          <div class="controls">
            <input id="Password" name="Password" type="password" placeholder="Nhập mật khẩu của bạn" class="input-xlarge" required="">
          </div>
        </div>

        <!-- Multiple Checkboxes -->
        <div class="control-group">
          <label class="control-label" for="Remember"></label>
          <div class="controls">
            <label class="checkbox" for="Remember-0">
              <input type="checkbox" name="Remember" id="Remember" value="Ghi nhớ mật khẩu">
              Ghi nhớ mật khẩu
            </label>
          </div>
        </div>

        <!-- Button (Double) -->
        <div class="control-group">
          <label class="control-label" for="Login"></label>
          <div class="controls">
            <button id="LoginBtn" name="Login" class="btn btn-primary" >Đăng nhập</button>
            <a href="/lib/pages/HeThong/Register.aspx" id="Forgot" name="Forgot" class="btn btn-default">Tạo mới</a>
            <a class="btn btn-link btn-QuenMatKhau" href="javascript:;">Quên mật khẩu</a>
          </div>
        </div>
        <div id="msgError" style="display: none;" class="alert alert-error">E-mail hoặc mật khẩu không hợp lệ bạn ơi!</div>
        <div id="msgMissing" style="display: none;" class="alert alert-error">Nhập E-mail và mật khẩu bạn nhé!</div>
        </fieldset>
    </div>
</div>
