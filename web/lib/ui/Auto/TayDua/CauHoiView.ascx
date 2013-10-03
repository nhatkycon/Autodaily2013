<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CauHoiView.ascx.cs" Inherits="lib_ui_Auto_TayDua_CauHoiView" %>

<div class="LoginPnl">
    <div class="Login-Body form-signin">
        <div class="unLoggedInPnl">
            <button class="facebookLogin">Login bằng Facebook</button>            
        </div>
        <div class="loggedInPnl">
                <div class="row row-fluid">
                    <div class="span4">
                        <img src="" class="img-rounded img-polaroid pull-left Anh"/>                        
                    </div>
                    <div class="span8">
                        <div class="row row-fluid spacer">
                            <div class="span1">Tên:</div>
                            <div class="span11">
                                <input class="input-large Ten"/>
                            </div>
                        </div>    
                        <div class="row row-fluid spacer">
                            <div class="span1">E-mail:</div>
                            <div class="span11">
                                <input class="input-large Email" disabled="disabled"/>
                            </div>
                        </div>    
                        <div class="row row-fluid spacer">
                            <div class="span1"></div>
                            <div class="span11">
                                <button class="btn btn-success btn-large">
                                    <i class="icon icon-repeat"></i>
                                    Bắt đầu
                                </button>
                            </div>
                        </div>        
                    </div>
                </div>
        </div>
    </div>
</div>

<div class="CauHoiList">
    
</div>
<div class="KetQuaPnl">
    
</div>
<script>
    var lblFbBtnLogin = $('.facebookLogin');
    var unLoggedInPnl = $('.unLoggedInPnl');
    var loggedInPnl = $('.loggedInPnl');
    var Anh = loggedInPnl.find('.Anh');
    var Ten = loggedInPnl.find('.Ten');
    var Email = loggedInPnl.find('.Email');
    
    FB.init({
        appId: '242395835911380',                        // App ID from the app dashboard
        channelUrl: '//autov./channel.html', // Channel file for x-domain comms
        status: true,                                 // Check Facebook Login status
        xfbml: true                                  // Look for social plugins on the page
    });

    lblFbBtnLogin.unbind('click').click(function (event) {
        event.preventDefault();
        FB.login(function (response) {
            if (response.status.toString().toLowerCase() == 'unknown') {
                console.log('Facebook connect is cancel');
            } else {
                unLoggedInPnl.hide();
                loggedInPnl.show();
                FB.api('/me', function (response) {
                    Ten.val(response.name);
                    Email.val(response.email);
                    Anh.attr('src', 'https://graph.facebook.com/' + response.id + '/picture?type=large');
                });
            }
        }, { scope: 'email' });
        return false;
    });

    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            unLoggedInPnl.hide();
            loggedInPnl.show();
            FB.api('/me', function (response) {
                Ten.val(response.name);
                Email.val(response.email);
                Anh.attr('src', 'https://graph.facebook.com/' + response.id + '/picture?type=large');
            });
        } else {
            unLoggedInPnl.show();
            loggedInPnl.hide();
        }
    });
    
</script>