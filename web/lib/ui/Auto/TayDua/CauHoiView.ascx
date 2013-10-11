<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CauHoiView.ascx.cs" Inherits="lib_ui_Auto_TayDua_CauHoiView" %>
    <%@ Register src="~/lib/ui/Auto/TayDua/templates/CauHoiViewItem.ascx" tagname="CauHoiViewItem" tagprefix="uc1" %>
<script>
    var cauHoiSwipe;
</script>
<div class="unLoggedInPnl">
    <div class="Login-Body form-signin">
        <div class="unLoggedInPnl">
            <button class="facebookLogin">Login bằng Facebook</button>            
        </div>
    </div>
</div>
<div class="TayDua-Header loggedInPnl">
    <div class="ClockPnl">
        <div class="Clock">            
        </div>
    </div>
    <div class="pull-right UserInfo-Pnl">
        <img src="" class="img-rounded img-polaroid Anh"/>
        Tay đua <span class="Ten"></span>
    </div>
</div>
<div class="TayDua-Start">
    <a href="javascript:;" class="TayDua-StartBtn">
        <i class="icon icon-play-circle"></i>
        Bắt đầu
    </a>
</div>
<div  id="cauhoi-view-slider" class="TayDua-CauHoiList swipe">
    <div class="swipe-wrap">
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:CauHoiViewItem ID="CauHoiViewItem" runat="server"  Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
    </div>
</div>
<div class="TayDua-KetQuaPnl">
    <div class="TayDua-KetQuaPnl-Body">
        Kết quả : 
        <span class="TayDua-KetQuaPnl-Rs"></span>
        <a href="/lib/pages/TayDua/Default.aspx" class="pull-right btn btn-large">
            <i class="icon icon-check"></i>Chơi tiếp
        </a>
    </div>
    
</div>
<script src="/lib/js/swipe.js" type="text/javascript"></script>
<script src="/lib/js/jquery.timeTo.min.js" type="text/javascript"></script>
<script>
    var lblFbBtnLogin = $('.facebookLogin');
    var unLoggedInPnl = $('.unLoggedInPnl');
    var loggedInPnl = $('.loggedInPnl');

    var TayDuaStart = $('.TayDua-Start');
    var TayDuaStartBtn = $('.TayDua-StartBtn');

    var Clock = $('.Clock');
    
    var TayDuaCauHoiList = $('.TayDua-CauHoiList');
    var TayDuaKetQuaPnl = $('.TayDua-KetQuaPnl');



    var Anh = loggedInPnl.find('.Anh');
    var Ten = loggedInPnl.find('.Ten');
    var Email = loggedInPnl.find('.Email');
    
    FB.init({
        appId: '242395835911380',                        // App ID from the app dashboard
        channelUrl: '//auto.vn/channel.html', // Channel file for x-domain comms
        status: true,                                 // Check Facebook Login status
        xfbml: true                                  // Look for social plugins on the page
    });

    lblFbBtnLogin.unbind('click').click(function (event) {
        event.preventDefault();
        FB.login(function (response) {
            handleFBResponse(response);
        }, { scope: 'email' });
        return false;
    });
    FB.getLoginStatus(function (response) {
        handleFBResponse(response);
    });
    function handleFBResponse(response) {
        if (response.status === 'connected') {
            unLoggedInPnl.hide();
            loggedInPnl.show();
            FB.api('/me', function (responses) {
                Ten.html(responses.name);
                Anh.attr('src', 'https://graph.facebook.com/' + responses.id + '/picture?type=square');
                $.ajax({
                    url: domain + '/lib/ajax/TayDua/Default.aspx?ref=' + Math.random(),
                    data: {
                        subAct: 'newCauHoi'
                        , Email: responses.email
                        , Ten: responses.name
                    },
                    success: function (dt) {
                        TayDuaCauHoiList.attr('data-id', dt);
                    }
                });
            });
        }
        else if (response.status.toString().toLowerCase() == 'unknown') {
            console.log('Facebook connect is cancel');
        } else {
            unLoggedInPnl.show();
            loggedInPnl.hide();
        }
    }

    $('.TayDua-CauHoiItem-NextBtn').last().unbind('click').click(function () {
        var con = confirm('Bạn có muốn kết thúc cuộc đua');
        if(con) {
            endCauHoi();            
        }
    });
    $('.TayDua-CauHoiItem-PrevBtn').first().hide();

    TayDuaStartBtn.click(function () {
        TayDuaCauHoiList.show();
        TayDuaStart.hide();
        cauHoiSwipe = new Swipe(document.getElementById('cauhoi-view-slider'), {
            continuous: false
            , callback: function (index, elem) {
                console.log(index);
                console.log(elem);
            }
        });
        Clock.timeTo(100, function () {
            endCauHoi();
        });
    });


    $('.TayDua-CauHoiList').on('click', '.radio', function () {
        var item = $(this);
        var id = item.attr('id');
        $.ajax({
            url: domain + '/lib/ajax/TayDua/Default.aspx?ref=' + Math.random(),
            data: {
                subAct: 'saveDapAnCauHoi'
                , ID: id
                , LUOT_ID: TayDuaCauHoiList.attr('data-id')
            },
            success: function (dt) {
            }
        });
    });

    function endCauHoi() {
        TayDuaKetQuaPnl.show();
        TayDuaCauHoiList.hide();
        $.ajax({
            url: domain + '/lib/ajax/TayDua/Default.aspx?ref=' + Math.random(),
            data: {
                subAct: 'ketQuaCauHoi'
                        , ID: TayDuaCauHoiList.attr('data-id')
            },
            success: function (dt) {
                $('.TayDua-KetQuaPnl-Rs').html(dt);
            }
        });
    }
    
</script>