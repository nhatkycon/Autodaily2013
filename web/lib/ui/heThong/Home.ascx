<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home.ascx.cs" Inherits="lib_ui_heThong_Home" %>
<meta property="og:title" content="Web viết nhật ký cho con" />
<meta property="og:description" content="Viết nhật ký cho con bằng ảnh, album ảnh, video. Sau này con lớn sẽ có khối chuyện để kể" />

<div class="home-full">    
    <div class="home-full-top">
        <div class="pull-right">
            Bạn đã có tài khoản <a href="#loginDialog" data-toggle="modal" class="btn btn-success btn-large">Đăng nhập</a>
        </div>
        <div class="logo logo-home">
            
        </div>
        
    </div>
    <div class="home-full-body">
            <div class="row-fluid">
                <div class="span3">
                    <div class="popover top">
                        <div class="arrow"></div>
                        <h3 class="popover-title">07/12/2013: Nụ cười đầu tiên bố thấy</h3>
                        <div class="popover-content">
                            <img src="/lib/css/web/1/be/thai.jpg" class="img-polaroid"/>
                        </div>
                    </div>
                </div>
               
                <div class="span3">
                    <div class="popover top">
                        <div class="arrow"></div>
                        <h3 class="popover-title">22/5/2013: Mụ đang dạy nhím</h3>
                        <div class="popover-content">
                            <iframe width="300" height="300" src="http://www.youtube.com/embed/e1j3YitTp5s" frameborder="0" allowfullscreen></iframe>
                        </div>
                    </div>
                </div>

                <div class="span3">
                    <div class="popover top">
                        <div class="arrow"></div>
                        <h3 class="popover-title">4/6/2013: Nhím tiêm phòng</h3>
                        <div class="popover-content">
                            Hic, <b>Nhím</b> đi tiêm về rên hừ hừ, cả nhà lo sốt vó lên được í.
                        </div>
                    </div>
                </div>
                 <div class="span3">
                    <div class="popover top">
                        <div class="arrow"></div>
                        <h3 class="popover-title">26/12/2013: Sóc tạo "dáng"</h3>
                        <div class="popover-content">
                            <img src="/lib/css/web/1/be/Soc.jpg" class="img-rounded"/>
                        </div>
                  </div>
                </div>
            </div>
    </div>
    <div class="home-full-foot">
        <div class="row-fluid">
            <div class="span10">
                <div class="home-full-instruction">
                    Lưu khoảnh khắc tuyệt diệu cho thiên thần của bạn &nbsp;<a href="/lib/pages/NhatKy/Default.aspx?ID=aa1c69e5-3cc1-4ef0-a7e8-00ca320ccc15" class="btn btn-warning">Xem demo nhật ký của Nhím</a>
                </div>                      
                 <div class="row-fluid">
                    <div class="span4">
                        <h3>Viết nhật ký</h3>
                        <p>
                            Giao diện giản lược vô cùng dễ dùng giúp <code>Ghi blog</code> lại tình cảm của bạn dành cho bé, lưu <code>album ảnh</code> về những khoảnh khắc của bé hoặc cả <code>video</code> của bé.
                        </p>
                    </div>
                    <div class="span4">
                        <h3>Lập bảng theo dõi</h3>
                        <p>
                            Bảng theo dõi cân nặng, chiều cao cho bé từ khi sinh đến 5 tuổi.<br/>
                            Hoặc lập bảng theo dõi cân nặng cho em bé khi mang thai và cân nặng của bà bầu mỗi tuần
                        </p>
                    </div>
                    <div class="span4">
                        <h3>Gửi cho ông bà ngoại</h3>
                        <p>
                            Ông bà ngoại mình ở tận Vinh nhưng luôn muốn nhìn thấy cháu ngoại mỗi ngày<br/>
                            Chỉ với vài phút là có một nhật ký online để ông bà, cô chú nhìn thấy cháu mỗi ngày
                        </p>
                    </div>
                </div>
            </div>
            <div class="span2">
                <a href="/lib/pages/HeThong/Register.aspx" class="btn btn-primary btn-large">Viết nhật ký!</a><br/><br/>
                <a href="/lib/pages/HeThong/GioiThieu.aspx" class="btn btn-primary btn-danger">Tìm hiểu thêm về web</a>
            </div>
        </div>
    </div>
</div>
<style>
   body {
        background-color: #999;
    }
</style>
