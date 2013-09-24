<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Register.ascx.cs" Inherits="lib_ui_heThong_Register" %>
<div class="span5 form-register">
    <form class="form-horizontal">
        <fieldset>
        <legend>Đăng ký tài khoản</legend>
        <div class="RegisterPnl">
            
        <!-- Form Name -->

        <!-- Text input-->
        <div class="control-group">
          <label class="control-label" for="Ten">Họ và Tên:</label>
          <div class="controls">
            <input id="Ten" name="Ten" type="text" placeholder="Ví dụ: Nguyễn Xuân Linh" class="input-xlarge" required="">
    
          </div>
        </div>

        <!-- Text input-->
        <div class="control-group">
          <label class="control-label" for="Email">E-mail:</label>
          <div class="controls">
            <input id="Email" name="Email" type="text" placeholder="Ví dụ: linhnx@me.com" class="input-xlarge" required="">
    
          </div>
        </div>

        <!-- Password input-->
        <div class="control-group">
          <label class="control-label" for="Password">Mật khẩu:</label>
          <div class="controls">
            <input id="Password" name="Password" type="password" placeholder="Càng khó càng tốt" class="input-xlarge" required="">
    
          </div>
        </div>

        <!-- Button -->
        <div class="control-group">
          <label class="control-label" for="Register"></label>
          <div class="controls">
            <button id="Register" name="Register" class="btn btn-primary">Đăng ký</button>
          </div>
        </div>
        </div>
        <div id="msgRegisterDone" style="display: none;" class="alert alert-success"></div>
        <div id="msgRegisterMissing" style="display: none;" class="alert alert-error"></div>
         <!-- Text input-->
        <div class="ConfirmPnl">
            <div class="control-group">
              <label class="control-label" for="ConfirmCode">Mã mà bạn nhận được:</label>
              <div class="controls">
                <input id="ConfirmCode" name="ConfirmCode" type="text" placeholder="Có 6 số thôi bạn nhé" class="input-xlarge" required="">
                <br/><br/>
                <a href="/lib/pages/HeThong/TaoBe.aspx" name="XacNhanBtn" class="btn">Sẽ xác nhận sau</a>
                &nbsp;
                <button id="XacNhanBtn" name="XacNhanBtn" class="btn btn-success">Xác nhận E-mail</button>
              </div>
            </div>
        </div>
        </fieldset>
    </form>
</div>
<div class="span6">
    <h2>Ghi nhật ký con yêu mỗi ngày!</h2>
    <div class="well well-large">
        <h3>Lưu lại khoảnh khắc</h3>
        <p>
            Lần đầu thấy con trong ảnh siêu âm, đón bé trong lòng bàn tay khi bé chào đời, nụ cười kỳ diệu của bé khi mụ dạy...
            Mỗi lần xem lại mọi thứ đều như mới và cảm xúc lại ùa về
        </p>
        <h3>
            Chia sẻ với Ông bà Nội, ngoại
        </h3>
        <p>
            Chỉ cần đưa cho ông bà, cô gì, chú bác địa chỉ nhật ký là mọi người luôn được thấy bé mỗi ngày
        </p>
        <h3>
            Bảng theo dõi cân nặng, chiều cao
        </h3>
        <p>Bạn có thể theo dõi sự lớn lên của bé hàng ngày, và việc ghi lại giúp bạn hiểu bé có đang phát triển bình thường hay không<br/>
        Chúng tôi có 05 bảng theo dõi về đầy đủ chiều cao cân nặng cho bé từ mang thai đến 5 tuổi</p>
    </div>
    <%--<iframe width="400" height="225" src="http://www.youtube.com/embed/stJcsZ42UCs" frameborder="0" allowfullscreen></iframe>--%>
</div> 
