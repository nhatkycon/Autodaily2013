var userFn = {
    url: function () {
        return domain + 'lib/admin/Default.aspx?ref=' + Math.random() + '&act=loadPlug&rqPlug=appStore.authorityStore.userMgr.authentication, appStore.authorityStore.userMgr';
    },
    setup: function () {

    },
    register: function () {
        var dlg = $('#register-form');
        common.loadHtml(dlg, '<%=WebResource("appStore.authorityStore.userMgr.htm.htm")%>', function () {
            dlg = $('#register-form');
            common.fbJquery('Đăng ký tài khoản', dlg, 540, 'register-form-fb', function (b) {
                common.loading(null);
                var foot = $(b).find('.facebox-footer');
                var box = $(b).find('.facebox-box');
                var Ten = $('.reg-Ten', b);
                var Usr = $('.reg-Username', b);
                var GioiTinh = $('.reg-gioiTinh', b);
                var Email = $('.reg-Email', b);
                var Pwd = $('.reg-Pwd', b);
                var Btn = $('.reg-save', b);
                $(Btn).click(function () {
                    if ($(b).find('.reg-msg-false').length != -1 && $(b).find('.reg-msg-ok').length < 4) {
                        common.fbMsg('Lỗi', 'Bạn cần hoàn thiện mẫu đăng ký', 300, 'fb-pop-msg-register-error', function () { });
                        return false;
                    }
                    var _Ten = $(Ten).val();
                    var _Pwd = $(Pwd).val();
                    var _Usr = $(Usr).val();
                    var _Email = $(Email).val();
                    var _GioiTinh = $(GioiTinh).is(':checked');
                    common.loading('Xác nhận');
                    common.fbAjax('Xác nhận', domain + '/lib/html/sys/registercaptcha.htm', {}, 540, 'fb-pop-register-captcha', function (b1) {
                        common.loading(null);
                        var img = $('.reg-captcha', b1);
                        var code = $('.code', b1);
                        var btn1 = $('.reg-validate', b1);
                        $(img).attr('src', registerFn.urlCaptcha().toString());
                        $(btn1).click(function () {
                            var _code = $(code).val();
                            if (_code == '') {
                                common.fbMsg('Lỗi', 'Bạn cần nhập ký tự', 300, 'fb-pop-register-error', function () { });
                                return false;
                            }
                            $.ajax({
                                url: registerFn.urlCaptcha().toString(),
                                data: { 'act': 'validate', 'Code': _code },
                                success: function (data) {
                                    if (data == "1") {
                                        $(document).trigger('close.facebox', 'fb-pop-register-captcha');
                                        $.ajax({
                                            url: registerFn.url().toString(),
                                            data: { 'act': 'Reg', 'Email': _Email, 'Usr': _Usr, 'Ten': _Ten, 'GioiTinh': _GioiTinh, 'Pwd': _Pwd },
                                            success: function (data) {
                                                if (data != "0") {
                                                    $(document).trigger('close.facebox', 'fb-pop-register');
                                                    registerFn.login();
                                                }
                                            }
                                        });
                                    }
                                    else {
                                        common.fbMsg('Lỗi', 'Không chính xác', 300, 'fb-pop-register-error', function () { });
                                    }
                                }
                            });
                        });
                    });

                });

                $(Ten).keyup(function () {
                    var msg = $(Ten).next();
                    var _val = $(Ten).val();
                    if (_val.indexOf(' ') == -1 || _val.length < 8 || _val.length > 50) {
                        $(msg).html('Họ và Tên đầy đủ');
                        if (!$(msg).hasClass('reg-msg-false')) $(msg).addClass('reg-msg-false');
                        if ($(msg).hasClass('reg-msg-ok')) $(msg).removeClass('reg-msg-ok');
                    }
                    else {
                        $(msg).html('');
                        if (!$(msg).hasClass('reg-msg-ok')) $(msg).addClass('reg-msg-ok');
                        if ($(msg).hasClass('reg-msg-false')) $(msg).removeClass('reg-msg-false');
                    }
                });
                $(Pwd).keyup(function () {
                    var msg = $(Pwd).next();
                    var _val = $(Pwd).val();
                    if (_val.length < 3 || _val.length > 14) {
                        $(msg).html('Mật khẩu từ 3 đến 14 ký tự');
                        if (!$(msg).hasClass('reg-msg-false')) $(msg).addClass('reg-msg-false');
                        if ($(msg).hasClass('reg-msg-ok')) $(msg).removeClass('reg-msg-ok');
                    }
                    else {
                        $(msg).html('');
                        if (!$(msg).hasClass('reg-msg-ok')) $(msg).addClass('reg-msg-ok');
                        if ($(msg).hasClass('reg-msg-false')) $(msg).removeClass('reg-msg-false');
                    }
                });

                common.validInputValueAjax(Email, function (_v, _t) {
                    var msg = $(Email).next();
                    if (common.isEmail(_v) && _v.length < 30) {
                        $(msg).addClass('reg-msg-wait');
                        $.ajax({
                            url: userFn.url().toString(),
                            data: {
                                'subAct': 'ValidateEmail',
                                'Email': $(Email).val()
                            }, success: function (data) {
                                $(msg).removeClass('reg-msg-wait');
                                if (data == 'False') {
                                    $(msg).html('');
                                    if (!$(msg).hasClass('reg-msg-ok')) $(msg).addClass('reg-msg-ok');
                                    if ($(msg).hasClass('reg-msg-false')) $(msg).removeClass('reg-msg-false');
                                }
                                else {
                                    $(msg).html('email đã tồn tại');
                                    if (!$(msg).hasClass('reg-msg-false')) $(msg).addClass('reg-msg-false');
                                    if ($(msg).hasClass('reg-msg-ok')) $(msg).removeClass('reg-msg-ok');
                                }
                            }
                        });
                    }
                    else {
                        $(msg).html('Định dạng email');
                        if (!$(msg).hasClass('reg-msg-false')) $(msg).addClass('reg-msg-false');
                        if ($(msg).hasClass('reg-msg-ok')) $(msg).removeClass('reg-msg-ok');
                    }
                });
                $(Usr).keyup(function () {
                    $(Usr).val(common.normalizeStrUrl($(Usr).val()));
                });
                common.validInputValueAjax(Usr, function (_v, _t) {
                    var msg = $(Usr).next();
                    if (_v.length < 14 && _v.length > 3) {
                        $(msg).addClass('reg-msg-wait');
                        $.ajax({
                            url: userFn.url().toString(),
                            data: {
                                'subAct': 'ValidateUsername',
                                'Usr': $(Usr).val()
                            }, success: function (data) {
                                $(msg).removeClass('reg-msg-wait');
                                if (data == 'True') {
                                    $(msg).html('');
                                    if (!$(msg).hasClass('reg-msg-ok')) $(msg).addClass('reg-msg-ok');
                                    if ($(msg).hasClass('reg-msg-false')) $(msg).removeClass('reg-msg-false');
                                }
                                else {
                                    $(msg).html('tên này đã tồn tại');
                                    if (!$(msg).hasClass('reg-msg-false')) $(msg).addClass('reg-msg-false');
                                    if ($(msg).hasClass('reg-msg-ok')) $(msg).removeClass('reg-msg-ok');
                                }
                            }
                        });
                    }
                    else {
                        $(msg).html('Tên đăng nhập 4 - 14 ký tự');
                        if (!$(msg).hasClass('reg-msg-false')) $(msg).addClass('reg-msg-false');
                        if ($(msg).hasClass('reg-msg-ok')) $(msg).removeClass('reg-msg-ok');
                    }

                });
                common.watermarks('.reg-input', function (item) { if (!$(item).hasClass('reg-input-focus')) $(item).addClass('reg-input-focus'); }, function (item) { if ($(item).hasClass('reg-input-focus')) $(item).removeClass('reg-input-focus'); });
            });
        });
//        common.fbAjax('Đăng ký tài khoản', '<%=WebResource("appStore.authorityStore.userMgr.htm.htm")%>', {}, 400, 'register-form', function () {
//            var dlg = $('#register-form');
//        });
    }
}