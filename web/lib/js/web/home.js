jQuery(function () {
    $('#__VIEWSTATE').remove();
    function getEl(el, fn) {
        var _offset = jQuery(el).offset();
        var _t = _offset.top;
        var _l = _offset.left;
        var _w = el.width();
        var _h = el.height();
        var _pt = parseInt(el.css('padding-top').toString().toLowerCase().replace('px', ''));
        var _pb = parseInt(el.css('padding-bottom').toString().toLowerCase().replace('px', ''));
        var _mt = parseInt(el.css('margin-top').toString().toLowerCase().replace('px', ''));
        var _mb = parseInt(el.css('margin-bottom').toString().toLowerCase().replace('px', ''));
        var _bb = parseInt(el.css('border-bottom-width').toString().toLowerCase().replace('px', ''));
        var _bt = parseInt(el.css('border-top-width').toString().toLowerCase().replace('px', ''));
        var _t1 = 0;
        _t1 = _t + _h + ((_pt == NaN) ? _pt : 0) + ((_pb == NaN) ? _pb : 0) + ((_mt == NaN) ? _mt : 0) + ((_mb == NaN) ? _mb : 0) + ((_bb == NaN) ? _bb : 0) + ((_bt == NaN) ? _bt : 0);
        if (typeof (fn) == 'function') { fn(_t, _l, _w, _t1); }
    }
    jQuery('form').submit(function () {
        return false;
    });
    bcy1Fn.login();
    bcy1Fn.taoBeFn();
    bcy1Fn.beCoverFn();
    bcy1Fn.avatarHomeFn();
    bcy1Fn.postBoxFn();
    bcy1Fn.AddBlogFn();
    bcy1Fn.AddHoatDongFn();
    bcy1Fn.AddVideoFn();
    bcy1Fn.AddAlbumlogFn();
    bcy1Fn.AddGiaDinhDialogFn();
    bcy1Fn.CapNhatWallFn();
    bcy1Fn.BinhLuanFn();
    bcy1Fn.ViewAnhFn();
    bcy1Fn.AddTheoDoiFn();
    bcy1Fn.EditTheoDoiFn();
    bcy1Fn.GiaDinhRemoveFn();
    bcy1Fn.SearchFn();
    bcy1Fn.AddCauHoiDialogFn();
    bcy1Fn.AddTraLoiDialogFn();
});

var bcy1Fn = {
    login: function () {
        var loginPnl = $('#loginForm');
        if ($(loginPnl).length > 0) {
            var btn = $(loginPnl).find('#LoginBtn');

            var u = $(loginPnl).find('#Email');
            var p = $(loginPnl).find('#Password');
            var r = $(loginPnl).find('#Remember');
            var msgError = $(loginPnl).find('#msgError');
            var msgMissing = $(loginPnl).find('#msgMissing');
            var btnQuenMatKhau = loginPnl.find('.btn-QuenMatKhau');

            btnQuenMatKhau.click(function () {
                $('#loginDialog').modal('hide');
                jQuery.post(adm.urlDefault, { 'act': 'loadPlug', 'rqPlug': 'docsoft.hethong.preload.Class1, docsoft.hethong.preload' }, function (data) {
                    setTimeout(function () {
                        preload.showRecover();
                    }, 1500);
                }, 'script');
            });

            btn.click(function () {
                var _u = u.val();
                var _p = p.val();
                msgMissing.hide();
                msgError.hide();
                if (_u == '' || _p == '') {
                    msgMissing.show();
                    return;
                }
                var _r = r.is(':checked');
                adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'u': _u, 'p': _p, 'r': _r }, function (data) {
                    if (data == '0') {
                        msgError.show();
                    }
                    else {
                        document.location.reload();
                    }
                });
            });

            $(p).keypress(function (e) {
                if (e.which == 13) {
                    var _u = u.val();
                    var _p = p.val();
                    msgMissing.hide();
                    msgError.hide();
                    if (_u == '' || _p == '' || !common.isEmail(_u)) {
                        msgMissing.show();
                        return;
                    }
                    var _r = r.is(':checked');
                    adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'u': _u, 'p': _p, 'r': _r }, function (data) {
                        if (data == '0') {
                            msgError.show();
                        }
                        else {
                            document.location.reload();
                        }
                    });
                }
            });

            $(u).keypress(function (e) {
                if (e.which == 13) {
                    var _u = u.val();
                    var _p = p.val();
                    msgMissing.hide();
                    msgError.hide();
                    if (_u == '' || _p == '' || !common.isEmail(_u)) {
                        msgMissing.show();
                        return;
                    }
                    var _r = r.is(':checked');
                    adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'u': _u, 'p': _p, 'r': _r }, function (data) {
                        if (data == '0') {
                            msgError.show();
                        }
                        else {
                            document.location.reload();
                        }
                    });
                }
            });

        }


        $('.log-out').click(function () {
            adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'subact': 'logout' }, function (data) {
                var l = document.location.href;
                if (l.indexOf('#').length != -1) {
                    l = l.substr(0, l.indexOf('#'));
                }
                //document.location.href = l;
                document.location.reload();
            });
        });


        var registerForm = $('.form-register');
        if ($(registerForm).length > 0) {
            adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
                var ConfirmPnl = registerForm.find('.ConfirmPnl');
                var RegisterPnl = registerForm.find('.RegisterPnl');
                ConfirmPnl.hide();
                RegisterPnl.show();
                var Ten = registerForm.find('#Ten');
                var Email = registerForm.find('#Email');
                var Password = registerForm.find('#Password');
                var msgRegisterDone = registerForm.find('#msgRegisterDone');
                var msgRegisterMissing = registerForm.find('#msgRegisterMissing');
                var btn = registerForm.find('#Register');
                var XacNhanBtn = registerForm.find('#XacNhanBtn');
                var ConfirmCode = registerForm.find('#ConfirmCode');
                btn.prop('disabled', false);

                btn.click(function () {
                    msgRegisterDone.hide();
                    msgRegisterMissing.hide();

                    var _Ten = Ten.val();
                    var _Email = Email.val();
                    var _Password = Password.val();
                    var err = '';
                    if (_Ten == '') {
                        err += 'Nhập tên <br/>';
                    }
                    if (_Email == '') {
                        err += 'Nhập Email <br/>';
                    }
                    if (_Password == '') {
                        err += 'Nhập mật khẩu <br/>';
                    }
                    if (!common.isEmail(_Email)) {
                        err += 'E-mail dạng chuẩn: abc@abc.com (Đừng gõ email có dấu bạn nhé) <br/>';
                    }
                    if (err != '') {
                        msgRegisterMissing.show();
                        msgRegisterMissing.html('Lỗi này bạn ơi<br/><b>Bạn cần chỉnh ngay nhé:</b><br/>' + err);
                        return false;
                    }
                    common.fbMsg('Đang xử lý', 'Vui lòng đợi 1 chút bạn nhé...', 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 20000);
                    });
                    btn.prop('disabled', true);
                    $.ajax({
                        url: thanhvien.urlDefault,
                        data: { Ten: _Ten, Email: _Email, Password: _Password, subAct: 'createFb' },
                        success: function (_dt) {
                            $(document).trigger('close.facebox', 'msg-portal-pop-processing');

                            if (_dt == '1') {
                                msgRegisterDone.show();
                                msgRegisterDone.html('<h3>Kiểm tra mã số trong e-mail</h3>Còn một bước nữa thôi bạn ơi!<br/>Chúng tôi gửi mã số bí mật vào hòm thư <b>' + _Email + '</b><br/>Bạn kiểm tra hòm thư và nhập số đó vào ô bên dưới để hoàn tất nhé<hr/>Đôi lúc bạn nên kiểm tra hòm thư rác (Spam) nhé!!');
                                //                                setTimeout(function () {
                                //                                    document.location.href = 'TaoBe.aspx';
                                //                                }, 1000);
                                ConfirmPnl.show();
                                RegisterPnl.hide();
                                XacNhanBtn.click(function () {
                                    var _ConfirmCode = ConfirmCode.val();
                                    if (_ConfirmCode == '') {
                                        msgRegisterMissing.show();
                                        msgRegisterMissing.html('<h3>Bạn cần nhập mã bí mật vào nhé :(( ặc ặc</h3><br/>Đôi lúc bạn nên kiểm tra hòm thư rác (Spam) nhé!!');
                                        return;
                                    }
                                    XacNhanBtn.prop('disabled', false);
                                    common.fbMsg('Đang xử lý', 'Vui lòng đợi 1 chút bạn nhé...', 200, 'msg-portal-pop-processing', function () {
                                        setTimeout(function () {
                                            $(document).trigger('close.facebox', 'msg-portal-pop');
                                        }, 20000);
                                    });
                                    $.ajax({
                                        url: thanhvien.urlDefault,
                                        data: { DiaChi: _ConfirmCode, Email: _Email, subAct: 'active', Password: _Password },
                                        success: function (_dt1) {
                                            $(document).trigger('close.facebox', 'msg-portal-pop-processing');
                                            if (_dt1 == '1') {
                                                msgRegisterMissing.hide();
                                                msgRegisterDone.show();
                                                msgRegisterDone.html('<h3>Hoàn thành</h3>Cám ơn bạn đã đăng ký thành công!<br/>Bạn chuẩn bị điền thông tin cho nhật ký của bé nhé!!');
                                                ConfirmPnl.hide();
                                                setTimeout(function () {
                                                    document.location.href = 'TaoBe.aspx';
                                                }, 1000);
                                            }
                                            else {
                                                msgRegisterMissing.show();
                                                msgRegisterMissing.html('<h3>Mã số sai :(( ặc ặc</h3><br/>kiểm tra e-mail nhé, đừng tự nghĩ số bạn nhé<hr/<b>Mẹo</b> <br/>Đôi lúc bạn nên kiểm tra hòm thư rác (Spam) nhé!!');
                                                btn.prop('disabled', false);
                                            }

                                        }
                                    });
                                });
                                btn.prop('disabled', true);
                            }
                            else if (_dt == '0') {
                                msgRegisterMissing.show();
                                msgRegisterMissing.html('<h3>Email này bị dùng rồi :(( ặc ặc</h3><br/>dùng email mới xem dư lào');
                                btn.prop('disabled', false);
                            }
                            else {
                                msgRegisterMissing.show();
                                msgRegisterMissing.html('<h3>Có lỗi, chán quá vì mình sửa mãi mà nó vẫn bị</h3><br/>Copy lỗi trên rùi gửi cho mình nhé: linh_net');
                                btn.prop('disabled', false);
                            }
                        }
                    });
                });
            });
        }
    }
    , taoBeFn: function () {
        var Taobe = $('#TaobeForm');
        if ($(Taobe).length > 0) {
            var Alias = Taobe.find('#Alias');
            var Ho = Taobe.find('#Ho');
            var Ten = Taobe.find('#Ten');
            var NgaySinh = Taobe.find('#NgaySinh');
            var CanNang = Taobe.find('#CanNang');
            var GioiTinh = Taobe.find('#GioiTinh');
            var NgayDuSinh = Taobe.find('#NgayDuSinh');
            var ChuaSinh = Taobe.find('.ChuaSinh');
            var DaSinh = Taobe.find('.DaSinh');
            var SaveBe = Taobe.find('#SaveBe');
            var msgRegisterDone = Taobe.find('#msgRegisterDone');
            var msgRegisterMissing = Taobe.find('#msgRegisterMissing');
            ChuaSinh.hide();
            DaSinh.hide();
            Taobe.find('input[name=MangThai]').click(function () {
                var _v = Taobe.find('input[name=MangThai]:checked').val();
                if (_v == '0') {
                    ChuaSinh.hide();
                    DaSinh.show();
                }
                else {
                    ChuaSinh.show();
                    DaSinh.hide();
                }
            });
            Taobe.find('#MangThai-0').click();

            

            $('#NgayDuSinhBox').datetimepicker({
                language: 'vi-Vn'
            });
            $('#NgayDuSinh').focus(function () {
                $('#NgayDuSinhBox').datetimepicker('show');
            });
            
            $('#NgaySinhBox').datetimepicker({
                language: 'vi-Vn'
            });
            
            $('#NgaySinh').focus(function () {
                $('#NgaySinhBox').datetimepicker('show');
            });

            SaveBe.click(function () {
                var _Alias = Alias.val();
                var _Ho = Ho.val();
                var _Ten = Ten.val();
                var _NgaySinh = NgaySinh.val();
                var _CanNang = CanNang.val();
                var _GioiTinh = GioiTinh.is(':checked');
                var _NgayDuSinh = NgayDuSinh.val();
                var _MangThai = Taobe.find('input[name=MangThai]:checked').val();

                var err = '';
                if (_Alias == '') {
                    err += '<br/>Đặt tên cúng cơm cho bé';
                }
                if (_MangThai == '0') {
                    if (_Ho == '' || _Ten == '' || _CanNang == '' || _NgaySinh == '') {
                        err += '<br/>Bạn cần nhập thật đầy đủ thông tin cho bé yêu của mình nhé';
                    }
                } else {
                    if (_NgayDuSinh == '') {
                        err += '<br/>Bạn hãy nhập một ngày mà bạn tin bé yêu của bạn sẽ chào đời nhé!';
                    }
                }

                msgRegisterDone.hide();
                msgRegisterMissing.hide();

                if (err != '') {
                    msgRegisterMissing.show();
                    msgRegisterMissing.html('<h3>Bạn hay gặp các lỗi này</h3>' + err);
                    return;
                }
                $.ajax({
                    url: domain + '/lib/ajax/Be/'
                , data: {
                    'subAct': 'add'
                    , Alias: _Alias
                    , Ho: _Ho
                    , Ten: _Ten
                    , NgaySinh: _NgaySinh
                    , CanNang: _CanNang
                    , GioiTinh: _GioiTinh
                    , NgayDuSinh: _NgayDuSinh
                    , MangThai: _MangThai
                }
                , success: function (_dt) {
                    msgRegisterDone.show();
                    msgRegisterDone.html('<h3>Bạn đã tạo thành công</h3>Chờ 1 giây sau đó bạn sẽ đến trang nhật ký của bé nhé</br>');
                    document.location.href = '../NhatKy/?ID=' + _dt;
                }
                });
            });
        }
    }
    , beCoverFn: function () {
        var beCover = $('.be-cover');
        if ($(beCover).length > 0) {
            var dragImg = beCover.find('.draggable');
            var beCoverBox = beCover.find('.be-cover-box');
            var keoAnhBtn = beCover.find('.be-cover-keoBtn');
            if ($(dragImg).length > 0) {
                var id = dragImg.attr('data-id');
                beCover.find('.draggable').draggable({
                    handle: '.be-cover-keoBtn'
                    , containment: beCoverBox
                    , scroll: true
                    , axis: 'y'
                    , stop: function (event, ui) {
                        $.ajax({
                            url: domain + '/lib/ajax/Be/Default.aspx',
                            type: 'POST',
                            data: {
                                subAct: 'moveCover',
                                css: dragImg.attr('style'),
                                ID: id
                            },
                            success: function (_id) {
                            }
                        });
                    }
                });
            }
            keoAnhBtn.disableSelection();
            var doiAnhBtn = beCover.find('.be-cover-doiAnhBtn');
            beCover.mouseenter(function () {
                keoAnhBtn.show();
            });
            beCover.mouseleave(function () {
                setTimeout(function () {
                    keoAnhBtn.hide();
                }, 2000);
            });
            if ($(doiAnhBtn).length > 0) {
                var id = doiAnhBtn.attr('data-id');
                var param = { 'subAct': 'doiAnh', 'id': id };
                //return false;
                new Ajax_upload(jQuery(doiAnhBtn), {
                    action: domain + '/lib/ajax/Be/Default.aspx',
                    name: 'anh',
                    data: param,
                    onSubmit: function (file, ext) {
                        if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    },
                    onComplete: function (file, response) {
                        if (response == '930') {
                            common.fbMsg('Ảnh có chiều rộng < 930px', 'trông xấu lắm bạn ạ, chọn ảnh khác đi bạn ơi...', 200, 'msg-portal-pop-processing', function () {
                                setTimeout(function () {
                                    $(document).trigger('close.facebox', 'msg-portal-pop');
                                }, 1000);
                            });
                        } else {
                            var img = beCover.find('.be-image');
                            img.attr('src', '/lib/up/avatar/' + response);
                            keoAnhBtn.show();
                        }
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            }

        }
    }
    , avatarHomeFn: function () {
        var avatarHome = $('.avatar-home');
        if ($(avatarHome).length > 0) {
            var doiAvatarBtn = avatarHome.find('.avatar-img-doiAnhBtn');
            avatarHome.mouseenter(function () {
                doiAvatarBtn.show();
            });
            avatarHome.mouseleave(function () {
                setTimeout(function () {
                    doiAvatarBtn.hide();
                }, 10000);
            });
            if ($(doiAvatarBtn).length > 0) {
                var id = doiAvatarBtn.attr('data-id');
                var param = { 'subAct': 'doiAvatar', 'id': id };
                //return false;
                new Ajax_upload(jQuery(doiAvatarBtn), {
                    action: domain + '/lib/ajax/Be/Default.aspx',
                    name: 'anh',
                    data: param,
                    onSubmit: function (file, ext) {
                        if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    },
                    onComplete: function (file, response) {
                        if (response == '400') {
                            common.fbMsg('Ảnh rộng quá 400px', 'Bạn chọn cái ảnh khác nhỏ hơn 400px bạn nhé...', 200, 'msg-portal-pop-processing', function () {
                                setTimeout(function () {
                                    $(document).trigger('close.facebox', 'msg-portal-pop');
                                }, 1000);
                            });
                        } else {
                            var img = avatarHome.find('.avatar-img');
                            img.attr('src', '/lib/up/avatar/' + response);
                        }
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            }

        }
    }
    , postBoxFn: function () {
        $(document).on('click', '.loiChucXoaBtn', function () {
            var item = $(this);
            var id = item.attr('data-id');
            var pitem = item.parent().parent().parent();
            pitem.addClass('animated bounceOutRight');
            setTimeout(function () {
                pitem.remove();
            }, 1000);

            $.ajax({
                url: domain + '/lib/ajax/LoiChuc/Default.aspx',
                data: {
                    subAct: 'remove',
                    ID: id
                },
                success: function (_rs) {
                }
            });
        });
        //.loiChucXoaBtn
        var postBox = $('.lc-post-box');
        if ($(postBox).length > 0) {
            var txt = postBox.find('textarea');
            var postBtn = postBox.find('button');
            postBtn.click(function () {
                var _txt = txt.val();
                if (_txt == '') {
                    txt.focus();
                    return;
                }
                postBtn.attr('disabled', 'disabled');

                $.ajax({
                    url: domain + '/lib/ajax/LoiChuc/Default.aspx',
                    type: 'POST',
                    data: {
                        subAct: 'add'
                    , ID: postBtn.attr('data-id')
                    , NoiDung: _txt
                    },
                    success: function (_dt) {
                        postBtn.removeAttr('disabled');
                        txt.val('');

                        $.ajax({
                            url: domain + '/lib/ajax/LoiChuc/Default.aspx',
                            data: {
                                act: 'view'
                            , ID: _dt
                            },
                            success: function (_view) {
                                var lcList = postBox.parent().find('.lc-list');
                                $(_view).prependTo(lcList);
                            }
                        });
                    }
                });
            });
        }
    }
    , AddBlogFn: function () {
        var AddBlogDialog = $('#AddBlogDialog');
        if ($(AddBlogDialog).length > 0) {
            var NoiDung = AddBlogDialog.find('.NoiDung');
            var Ten = AddBlogDialog.find('.Ten');
            var Savebtn = AddBlogDialog.find('.Savebtn');
            var imgBlog = AddBlogDialog.find('img');
            var blogDoiAnhBtn = AddBlogDialog.find('.blog-post-doiAnhBtn').find('a');
            var ID = Savebtn.attr('data-pid');
            var NgayVietBox = AddBlogDialog.find('.NgayVietBox');
            var NgayViet = AddBlogDialog.find('.NgayViet');
            NgayVietBox.datetimepicker({
                language: 'vi-Vn'
            });

            adm.ckeditor_blogPost(NoiDung);

            Savebtn.click(function () {
                var _Ten = Ten.val();
                var _NoiDung = NoiDung.val();
                var _Anh = imgBlog.attr('data-src');
                var _NgayViet = NgayViet.val();
                if (_Ten == '' || _NoiDung == '') {
                    common.fbMsg('Nhập tên, nội dung nhé bạn', 'Bạn cần nhập Tên, Nội dung của Blog nhé', 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 1000);
                    });
                    return;
                }
                $.ajax({
                    url: domain + '/lib/ajax/Post/Default.aspx',
                    type: 'POST',
                    data: {
                        subAct: 'add',
                        Ten: _Ten,
                        NoiDung: _NoiDung,
                        Anh: _Anh,
                        P_ID: ID,
                        NgayViet: _NgayViet
                    },
                    success: function (_id) {
                        $('#AddBlogDialog').modal('hide');
                        Ten.val('');
                        NoiDung.val('');
                        imgBlog.attr('data-src', '');
                        imgBlog.attr('src', '');
                        bcy1Fn.HandlePost(_id);
                    }
                });
            });

            if ($(blogDoiAnhBtn).length > 0) {
                var param = { 'subAct': 'upload' };
                //return false;
                new Ajax_upload(jQuery(blogDoiAnhBtn), {
                    action: domain + '/lib/ajax/Post/Default.aspx',
                    name: 'anh',
                    data: param,
                    onSubmit: function (file, ext) {
                        if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    },
                    onComplete: function (file, response) {
                        if (response == '300') {
                            common.fbMsg('Ảnh có chiều rộng nhỏ quá < 300', 'trông xấu lắm bạn ạ, chọn ảnh khác đi bạn ơi...', 200, 'msg-portal-pop-processing', function () {
                                setTimeout(function () {
                                    $(document).trigger('close.facebox', 'msg-portal-pop');
                                }, 1000);
                            });
                        } else {
                            imgBlog.attr('src', '/lib/up/i/' + response);
                            imgBlog.attr('data-src', response);
                        }
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            }
        }
    }
    , AddHoatDongFn: function () {
        var AddHoatDongDialog = $('#AddHoatDongDialog');
        if ($(AddHoatDongDialog).length > 0) {
            var NoiDung = AddHoatDongDialog.find('.NoiDung');
            var Ten = AddHoatDongDialog.find('.Ten');
            var Savebtn = AddHoatDongDialog.find('.Savebtn');
            var HoatDong_ID = AddHoatDongDialog.find('.HoatDong_ID');
            var HoatDong_hint = AddHoatDongDialog.find('.HoatDong_hint');
            var img = AddHoatDongDialog.find('img');
            var hoatDongDoiAnhBtn = AddHoatDongDialog.find('.blog-post-doiAnhBtn').find('a');
            var ID = Savebtn.attr('data-pid');
            var NgayVietBox = AddHoatDongDialog.find('.NgayVietBox');
            var NgayViet = AddHoatDongDialog.find('.NgayViet');
            NgayVietBox.datetimepicker({
                language: 'vi-Vn'
            });

            adm.ckeditor_blogPost(NoiDung);

            Savebtn.click(function () {
                var _Ten = Ten.val();
                var _NoiDung = NoiDung.val();
                var _HoatDong_ID = HoatDong_ID.attr('data-id');
                var _Anh = img.attr('data-src');
                var _NgayViet = NgayViet.val();
                if (_Ten == '' || _NoiDung == '' || _HoatDong_ID == '') {
                    common.fbMsg('Nhập tên, nội dung nhé bạn', 'Bạn cần nhập Tên, Nội dung của hoạt động nhé', 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 1000);
                    });
                    return;
                }
                $.ajax({
                    url: domain + '/lib/ajax/SuKien/Default.aspx',
                    type: 'POST',
                    data: {
                        subAct: 'add',
                        Ten: _Ten,
                        NoiDung: _NoiDung,
                        Anh: _Anh,
                        HoatDong_ID: _HoatDong_ID,
                        NgayViet: _NgayViet,
                        P_ID: ID
                    },
                    success: function (_id) {
                        $('#AddHoatDongDialog').modal('hide');
                        Ten.val('');
                        NoiDung.val('');
                        HoatDong_ID.attr('data-id', '');
                        img.attr('data-src', '');
                        img.attr('src', '');
                        bcy1Fn.HandlePost(_id);
                    }
                });
            });

            if ($(hoatDongDoiAnhBtn).length > 0) {
                var param = { 'subAct': 'upload' };
                //return false;
                new Ajax_upload(jQuery(hoatDongDoiAnhBtn), {
                    action: domain + '/lib/ajax/Post/Default.aspx',
                    name: 'anh',
                    data: param,
                    onSubmit: function (file, ext) {
                        if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    },
                    onComplete: function (file, response) {
                        if (response == '300') {
                            common.fbMsg('Ảnh có chiều rộng nhỏ quá < 300', 'trông xấu lắm bạn ạ, chọn ảnh khác đi bạn ơi...', 200, 'msg-portal-pop-processing', function () {
                                setTimeout(function () {
                                    $(document).trigger('close.facebox', 'msg-portal-pop');
                                }, 1000);
                            });
                        } else {
                            img.attr('src', '/lib/up/i/' + response);
                            img.attr('data-src', response);
                        }
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            }

            adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                danhmuc.autoCompleteLangBased('', 'LoaiHoatDong', HoatDong_ID, function (event, ui) {
                    HoatDong_ID.attr('data-id', ui.item.id);
                }, function (ul, item) {
                    return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\"><b>" + item.ma + '</b> ' + item.label + "</a>")
				            .appendTo(ul);
                });
                HoatDong_ID.unbind('click').click(function () {
                    HoatDong_ID.autocomplete('search', '');
                });
                HoatDong_hint.click(function () {
                    HoatDong_ID.autocomplete('search', '');
                });
            });
        }
    }
    , AddCauHoiDialogFn: function () {
        var AddGiaDinhDialog = $('#AddCauHoiDialog');
        if ($(AddGiaDinhDialog).length > 0) {
            var NoiDung = AddGiaDinhDialog.find('.NoiDung');
            var Ten = AddGiaDinhDialog.find('.Ten');
            var DoTuoi_ID = AddGiaDinhDialog.find('.DoTuoi_ID');
            var DM_ID = AddGiaDinhDialog.find('.DM_ID');
            var DoTuoi_Hint = AddGiaDinhDialog.find('.DoTuoi_Hint');
            var DM_Hint = AddGiaDinhDialog.find('.DM_Hint');
            var Savebtn = AddGiaDinhDialog.find('.Savebtn');

            var ID = Savebtn.attr('data-id');

            adm.ckeditor_blogPost(NoiDung);

            Savebtn.click(function () {
                var _Ten = Ten.val();
                var _DoTuoi_ID = DoTuoi_ID.attr('data-id');
                var _DM_ID = DM_ID.attr('data-id');
                var _NoiDung = NoiDung.val();

                if (_Ten == '' || _DoTuoi_ID == '' || _NoiDung == '' || _DM_ID == '') {
                    common.fbMsg('Nhập tên câu hỏi, độ tuổi và phân loại', 'Bạn cần nhập Tên, Nội dung và phân loại của câu hỏi nhé', 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 1000);
                    });
                    return;
                }
                $.ajax({
                    url: domain + '/lib/ajax/HoiDap/Default.aspx',
                    data: {
                        subAct: 'add',
                        Ten: _Ten,
                        NoiDung: _NoiDung,
                        DoTuoi_ID: _DoTuoi_ID,
                        DM_ID: _DM_ID
                    },
                    type: 'POST'
                    ,
                    success: function (_rs) {
                        $('#AddCauHoiDialog').modal('hide');
                        Ten.val('');
                        NoiDung.val('');
                        DM_ID.attr('data-id', '');
                        DoTuoi_ID.attr('data-id', '');
                    }
                });
            });


            adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {

                danhmuc.autoCompleteLangBasedByDM('', "TIN-TUC-ROOT", DoTuoi_ID, function (event, ui) {
                    DoTuoi_ID.attr('data-id', ui.item.id);
                });

                danhmuc.autoCompleteLangBased('', "HOI-DAP", DM_ID, function (event, ui) {
                    DM_ID.attr('data-id', ui.item.id);
                });

                DM_ID.unbind('click').click(function () {
                    DM_ID.autocomplete('search', '');
                });
                DM_Hint.click(function () {
                    DM_ID.autocomplete('search', '');
                });

                DoTuoi_ID.unbind('click').click(function () {
                    DoTuoi_ID.autocomplete('search', '');
                });
                DoTuoi_Hint.click(function () {
                    DoTuoi_ID.autocomplete('search', '');
                });
            });
        }
    }
    , AddTraLoiDialogFn: function () {
        var AddGiaDinhDialog = $('#AddTraLoiDialog');
        if ($(AddGiaDinhDialog).length > 0) {
            var NoiDung = AddGiaDinhDialog.find('.NoiDung');
            var Savebtn = AddGiaDinhDialog.find('.Savebtn');

            var ID = Savebtn.attr('data-hd-id');

            adm.ckeditor_blogPost(NoiDung);

            Savebtn.click(function () {
                var _NoiDung = NoiDung.val();

                if (ID == '' || _NoiDung == '') {
                    common.fbMsg('Nhập câu trả lời', 'Bạn cần nhập câu trả lời nhé ^^', 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 1000);
                    });
                    return;
                }
                $.ajax({
                    url: domain + '/lib/ajax/HoiDap/Default.aspx',
                    data: {
                        subAct: 'traLoi',
                        NoiDung: _NoiDung,
                        ID: ID
                    },
                    type: 'POST'
                    ,
                    success: function (rs) {
                        $('#AddTraLoiDialog').modal('hide');
                        NoiDung.val('');
                        var traLoiList = $('.traLoi-list-box');
                        var rsItem = $(rs).prependTo(traLoiList);
                        rsItem.addClass('animated bounceInDown');
                        setTimeout(function () {
                            rsItem.removeClass('animated bounceInDown');
                        }, 1000);
                    }
                });
            });

        }
    }
    , AddGiaDinhDialogFn: function () {
        var AddGiaDinhDialog = $('#AddGiaDinhDialog');
        if ($(AddGiaDinhDialog).length > 0) {
            var NoiDung = AddGiaDinhDialog.find('.NoiDung');
            var Ten = AddGiaDinhDialog.find('.Ten');
            var Email = AddGiaDinhDialog.find('.Email');
            var Savebtn = AddGiaDinhDialog.find('.Savebtn');
            var LOAI_ID = AddGiaDinhDialog.find('.LOAI_ID');
            var HoatDong_hint = AddGiaDinhDialog.find('.HoatDong_hint');
            var img = AddGiaDinhDialog.find('img');
            var hoatDongDoiAnhBtn = AddGiaDinhDialog.find('.blog-post-doiAnhBtn').find('a');
            var ID = Savebtn.attr('data-pid');

            adm.ckeditor_blogPost(NoiDung);

            Savebtn.click(function () {
                var _Ten = Ten.val();
                var _Email = Email.val();
                var _NoiDung = NoiDung.val();
                var _LOAI_ID = LOAI_ID.attr('data-id');
                var _Anh = img.attr('data-src');

                if (_Ten == '' || _LOAI_ID == '') {
                    common.fbMsg('Nhập tên thành viên, chọn quan hệ với bé nhé', 'Bạn cần nhập Tên, Nội dung của Blog nhé', 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 1000);
                    });
                    return;
                }
                $.ajax({
                    url: domain + '/lib/ajax/GiaDinh/Default.aspx',
                    data: {
                        subAct: 'add',
                        Ten: _Ten,
                        NoiDung: _NoiDung,
                        Anh: _Anh,
                        LOAI_ID: _LOAI_ID,
                        Email: _Email,
                        P_ID: ID
                    },
                    success: function (_rs) {
                        var gdList = $('.gd-view-list');
                        var rsItem = $(_rs).prependTo(gdList);
                        rsItem.addClass('animated bounceInDown');
                        setTimeout(function () {
                            rsItem.removeClass('animated bounceInDown');
                        }, 1000);

                        $('#AddGiaDinhDialog').modal('hide');
                        Ten.val('');
                        NoiDung.val('');
                        Email.val('');
                        LOAI_ID.attr('data-id', '');
                        img.attr('data-src', '');
                        img.attr('src', '');
                    }
                });
            });

            if ($(hoatDongDoiAnhBtn).length > 0) {
                var param = { 'subAct': 'upload' };
                //return false;
                new Ajax_upload(jQuery(hoatDongDoiAnhBtn), {
                    action: domain + '/lib/ajax/Post/Default.aspx',
                    name: 'anh',
                    data: param,
                    onSubmit: function (file, ext) {
                        if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    },
                    onComplete: function (file, response) {
                        if (response == '300') {
                            common.fbMsg('Ảnh có chiều rộng nhỏ quá < 300', 'trông xấu lắm bạn ạ, chọn ảnh khác đi bạn ơi...', 200, 'msg-portal-pop-processing', function () {
                                setTimeout(function () {
                                    $(document).trigger('close.facebox', 'msg-portal-pop');
                                }, 1000);
                            });
                        } else {
                            img.attr('src', '/lib/up/i/' + response);
                            img.attr('data-src', response);
                        }
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            }

            adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                danhmuc.autoCompleteLangBased('', 'LoaiThanhVien', LOAI_ID, function (event, ui) {
                    LOAI_ID.attr('data-id', ui.item.id);
                }, function (ul, item) {
                    return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\"><b>" + item.ma + '</b> ' + item.label + "</a>")
				            .appendTo(ul);
                });
                LOAI_ID.unbind('click').click(function () {
                    LOAI_ID.autocomplete('search', '');
                });
                HoatDong_hint.click(function () {
                    LOAI_ID.autocomplete('search', '');
                });
            });
        }
    }
    , AddVideoFn: function () {
        var AddVideoDialog = $('#AddVideoDialog');
        if ($(AddVideoDialog).length > 0) {
            var Url = AddVideoDialog.find('.Url');
            var Ten = AddVideoDialog.find('.Ten');
            var Savebtn = AddVideoDialog.find('.Savebtn');
            var img = AddVideoDialog.find('img');
            var ID = Savebtn.attr('data-pid');
            YouTubeView = AddVideoDialog.find('#youtube-view');

            var NgayVietBox = AddVideoDialog.find('.NgayVietBox');
            var NgayViet = AddVideoDialog.find('.NgayViet');
            NgayVietBox.datetimepicker({
                language: 'vi-Vn'
            });
            Savebtn.click(function () {
                var _Ten = Ten.val();
                var _Yid = YouTubeView.attr('data-yid');
                var _Anh = YouTubeView.attr('data-img');
                var _NgayViet = NgayViet.val();

                if (_Ten == '' || _Yid == '') {
                    common.fbMsg('Nhập tên, và video bạn nhé', 'Bạn cần hướng dẫn upload video lên youtube.com không?<br/>truy cập <a href=\"http://www.youtube.com/upload\" class=\"code\" target=\"_blank\">www.youtube.com/upload</a> nhé', 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 1000);
                    });
                    return;
                }
                $.ajax({
                    url: domain + '/lib/ajax/YouTube/Default.aspx',
                    type: 'POST',
                    data: {
                        subAct: 'add',
                        Ten: _Ten,
                        Yid: _Yid,
                        NgayViet: _NgayViet,
                        Anh: _Anh,
                        P_ID: ID
                    },
                    success: function (_id) {
                        $('#AddVideoDialog').modal('hide');
                        Ten.val('');
                        Url.val('');
                        YouTubeView.hide('');
                        YouTubeView.attr('data-yid', '');
                        YouTubeView.attr('data-img', '');
                        bcy1Fn.HandlePost(_id);
                    }
                });
            });

            Url.blur(function () {
                var _Url = Url.val();
                if (_Url != '') {
                    YouTubeView.hide();
                    $.ajax({
                        url: domain + '/lib/ajax/YouTube/Default.aspx',
                        data: {
                            subAct: 'wrappUrl',
                            Url: _Url,
                            P_ID: ID
                        },
                        success: function (_rs) {
                            var rs = eval(_rs);
                            YouTubeView.show();
                            YouTubeView.attr('src', 'http://www.youtube.com/embed/' + rs.YId);
                            YouTubeView.attr('data-yid', rs.YId);
                            YouTubeView.attr('data-img', rs.Anh);
                        }
                    });
                }
            });
        }
    }
    , AddAlbumlogFn: function () {
        var albumUploadBox = $('.album-upload-box');
        if ($(albumUploadBox).length > 0) {

            var albumUploadList = albumUploadBox.find('.album-view-list');
            var SaveAlbumBtn = albumUploadBox.find('.SaveAlbumBtn');
            var UpdateAlbumBtn = albumUploadBox.find('.UpdateAlbumBtn');
            var xoaAlbumBtn = albumUploadBox.find('.xoaAlbumBtn');
            var TenAlbum = albumUploadBox.find('.TenAlbum');

            var url = domain + '/lib/ajax/Album/Default.aspx';

            SaveAlbumBtn.click(function () {
                var _Ten = TenAlbum.val();
                if (_Ten == '') {
                    common.fbMsg('Nhập tên album', 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 1000);
                    });
                    return;
                }
                $.ajax({
                    url: url,
                    data: {
                        'subAct': 'addAlbum',
                        ID: albumUploadBox.attr('data-id'),
                        P_ID: albumUploadBox.attr('data-pid'),
                        Ten: _Ten
                    },
                    success: function () {
                        document.location.href = 'Album.aspx?ID=' + albumUploadBox.attr('data-id');
                    }
                });

            });
            UpdateAlbumBtn.click(function () {
                var _Ten = TenAlbum.val();
                if (_Ten == '') {
                    common.fbMsg('Nhập tên album', 'Bạn không nên bỏ qua tên album nhé, nguy hiểm lắm đấy!', 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 1000);
                    });
                    return;
                }
                $.ajax({
                    url: url,
                    data: {
                        'subAct': 'updateAlbum',
                        ID: albumUploadBox.attr('data-id'),
                        Ten: _Ten
                    },
                    success: function () {
                        document.location.href = 'Album.aspx?ID=' + albumUploadBox.attr('data-id');
                    }
                });

            });
            xoaAlbumBtn.click(function () {
                $.ajax({
                    url: url,
                    data: {
                        'subAct': 'xoaAlbum',
                        ID: albumUploadBox.attr('data-id')
                    },
                    success: function () {
                        document.location.href = 'Default.aspx?ID=' + albumUploadBox.attr('data-pid');
                    }
                });

            });
            $('.item-anh-uploadPreview').each(function () {
                var anhItem = $(this);
                anhItem.find('button').click(function () {
                    var anhXoa = $(this);
                    $.ajax({
                        url: url
                            , data: {
                                'subAct': 'xoaAnh'
                                , ID: anhXoa.attr('data-id')
                            }
                            , success: function () {
                                anhItem.fadeOut(500);
                            }
                    });
                });
                anhItem.find('input').click(function () {
                    var txt = $(this);
                    txt.blur(function () {
                        $.ajax({
                            url: url,
                            data: {
                                'subAct': 'editCaption',
                                ID: txt.attr('data-id'),
                                Ten: txt.val()
                            },
                            success: function () {
                            }
                        });
                    });
                });
            });

            $('#fileupload').fileupload({
                url: url,
                dataType: 'json',
                dropZone: albumUploadList,
                formData: {
                    'subAct': 'upload'
                , P_ID: albumUploadBox.attr('data-pid')
                , ID: albumUploadBox.attr('data-id')
                },
                done: function (e, data) {
                    $('#progress').hide();
                    $.each(data.result.files, function (index, file) {
                        var anhItem = $('#anh-item').tmpl(file).prependTo(albumUploadList);
                        anhItem.find('button').click(function () {
                            var anhXoa = $(this);
                            $.ajax({
                                url: url
                            , data: {
                                'subAct': 'xoaAnh'
                                , ID: anhXoa.attr('data-id')
                            }
                            , success: function () {
                                anhItem.fadeOut(500);
                            }
                            });
                        });
                        anhItem.find('input').click(function () {
                            var txt = $(this);
                            txt.blur(function () {
                                $.ajax({
                                    url: url,
                                    data: {
                                        'subAct': 'editCaption',
                                        ID: txt.attr('data-id'),
                                        Ten: txt.val()
                                    },
                                    success: function () {
                                    }
                                });
                            });
                        });
                    });
                },
                progressall: function (e, data) {
                    $('#progress').show();
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progress .bar').css(
                'width',
                progress + '%'
            );
                }
            });


        }
    }
    , GiaDinhSliderHome: function () {
        var slider = $('#gd-slider');
        if ($(slider).length > 0) {
            mySwipe = Swipe(document.getElementById('gd-slider'));
        }
    }
    , HandlePost: function (id) {
        $.ajax({
            url: domain + '/lib/ajax/Post/Default.aspx',
            data: {
                act: 'view',
                ID: id
            },
            success: function (_rs) {
                var list = $('.capNhat-list');
                if ($(list).length > 0) {
                    var item = $(_rs).prependTo(list).hide();
                    item.show(500);
                }
            }
        });
    }
    , GiaDinhRemoveFn: function () {
        //gd-remove  
        $(document).on('click', '.gd-remove', function () {
            var item = $(this);
            var id = item.attr('data-id');

            item.parent().parent().parent().parent().addClass('animated bounceOutRight');
            setTimeout(function () {
                item.parent().parent().parent().parent().remove();
            }, 1000);


            $.ajax({
                url: domain + '/lib/ajax/GiaDinh/Default.aspx',
                data: {
                    subAct: 'remove',
                    ID: id
                },
                success: function () {

                }
            });
        });
    }
    , CapNhatWallFn: function () {

        $(document).on('click', '.post-more-btn', function () {
            var item = $(this);
            var id = item.attr('data-id');
            var list = item.parent().parent().parent().parent().parent();
            var pitem = item.parent().parent().parent().parent();
            var date = item.attr('data-date');
            item.hide();
            $.ajax({
                url: domain + '/lib/ajax/Post/Default.aspx',
                data: {
                    subAct: 'more',
                    ID: id,
                    FromDate: date
                },
                success: function (_rs) {

                    $(_rs).appendTo(list);
                    pitem.remove();
                }
            });
        });

        $(document).on('click', '.post-likeBtn', function () {
            var item = $(this);
            var id = item.attr('data-id');
            var liked = item.hasClass('liked');

            if (liked) {
                item.parent().addClass('animated rotateOut');
                item.removeClass('liked');
                setTimeout(function () {
                    item.parent().removeClass('animated rotateOut');
                }, 1000);

            } else {
                item.parent().addClass('animated rotateIn');
                item.addClass('liked');
                setTimeout(function () {
                    item.parent().removeClass('animated rotateIn');
                }, 1000);
            }


            $.ajax({
                url: domain + '/lib/ajax/Thich/Default.aspx',
                data: {
                    subAct: 'like',
                    ID: id,
                    Liked: liked
                },
                success: function () {

                }
            });
        });

        $(document).on('click', '.post-remove', function () {
            var item = $(this);
            var id = item.attr('data-id');

            item.parent().parent().parent().addClass('animated bounceOutRight');
            setTimeout(function () {
                item.parent().parent().parent().remove();
            }, 1000);


            $.ajax({
                url: domain + '/lib/ajax/Post/Default.aspx',
                data: {
                    subAct: 'remove',
                    ID: id
                },
                success: function () {

                }
            });
        });
    }
    , BinhLuanFn: function () {
        var box = $('.binhLuan-box');
        var postList = box.find('.binhLuan-list');
        if ($(box).length < 1)
            return;
        var pid = box.attr('data-id');
        var postBox = box.find('.binhLuan-postBox');
        bcy1Fn.BinhLuanTotalFn();
        if ($(postBox).length > 0) {
            var txt = postBox.find('textarea');
            var btn = postBox.find('button');
            btn.click(function () {
                var _txt = txt.val();
                if (_txt == '') {
                    txt.focus();
                    return;
                }
                btn.attr("disabled", "disabled");
                $.ajax({
                    url: domain + '/lib/ajax/BinhLuan/Default.aspx',
                    data: {
                        subAct: 'add',
                        ID: pid,
                        Url: document.location.href,
                        Txt: _txt
                    },
                    success: function (_id) {
                        btn.removeAttr("disabled");
                        txt.val('');

                        $.ajax({
                            url: domain + '/lib/ajax/BinhLuan/Default.aspx',
                            data: {
                                act: 'view',
                                ID: _id
                            },
                            success: function (rs) {
                                var rsItem = $(rs).prependTo(postList);
                                rsItem.addClass('animated bounceInDown');
                                setTimeout(function () {
                                    rsItem.removeClass('animated bounceInDown');
                                }, 1000);
                            }
                        });
                    }
                });
            });
        }

        $.ajax({
            url: domain + '/lib/ajax/BinhLuan/Default.aspx',
            data: {
                act: 'list',
                ID: pid
            },
            success: function (rs) {
                $(rs).prependTo(postList);
            }
        });
    }
    , BinhLuanTotalFn: function () {
        $(document).on('click', '.binhLuan-Item-Xoa', function () {
            var item = $(this);
            var id = item.attr('data-id');

            $.ajax({
                url: domain + '/lib/ajax/BinhLuan/Default.aspx',
                data: {
                    subAct: 'xoa',
                    ID: id
                },
                success: function () {
                    var pitem = item.parent().parent();
                    pitem.addClass('animated bounceOutRight');
                    setTimeout(function () {
                        pitem.remove();
                    }, 500);
                }
            });
        });
    }
    , ViewAnhFn: function () {
        var sliderAnh = $('.view-anh-slider');
        var sliderViewer = $('.view-anh-sliderView');
        if ($(sliderAnh).length < 1)
            return;
        sliderAnh.find('.anh-album-view-item').each(function () {
            var item = $(this);
            var id = item.attr('data-id');
            var url = item.attr('data-url');
            var full = item.attr('data-full');
            item.click(function () {
                history.pushState('', 'Hello', url);
                sliderAnh.hide();
                sliderViewer.show();
                if (!albumSwipeRender) {
                    albumSwipe = Swipe(document.getElementById('album-view-slider'));
                    albumSwipeRender = true;
                }
            });
        });
        sliderViewer.find('.closeViewBtn').click(function () {
            sliderAnh.show();
            sliderViewer.hide();
        });
    }
    , AddTheoDoiFn: function () {
        var AddHoatDongDialog = $('#AddBaoCaoTheoDoiDialog');
        if ($(AddHoatDongDialog).length > 0) {
            var Ten = AddHoatDongDialog.find('.Ten');
            var LOAI_ID = AddHoatDongDialog.find('.LOAI_ID');
            var LOAI_hint = AddHoatDongDialog.find('.LOAI_hint');
            var Savebtn = AddHoatDongDialog.find('.Savebtn');
            var ID = Savebtn.attr('data-pid');

            Savebtn.click(function () {
                var _Ten = Ten.val();
                var _LOAI_ID = LOAI_ID.attr('data-id');
                if (_LOAI_ID == '' || _Ten == '') {
                    common.fbMsg('Nhập tên và chọn loại theo dõi'
                        , 'Phải chọn loại theo dõi bạn nhé!', 200, 'msg-portal-pop-processing', function () {
                            setTimeout(function () {
                                $(document).trigger('close.facebox', 'msg-portal-pop');
                            }, 1000);
                        });
                    return;
                }
                $.ajax({
                    url: domain + '/lib/ajax/BaoCaoTheoDoi/Default.aspx',
                    type: 'POST',
                    data: {
                        subAct: 'add',
                        Ten: _Ten,
                        LOAI_ID: _LOAI_ID,
                        P_ID: ID
                    },
                    success: function (_id) {
                        AddHoatDongDialog.modal('hide');
                        Ten.val('');
                        LOAI_ID.attr('data-id', '');
                        LOAI_ID.val('');
                        document.location.href = 'View.aspx?ID=' + _id;
                    }
                });
            });


            adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                danhmuc.autoCompleteLangBasedNoChild('LoaiTheoDoi', LOAI_ID, function (event, ui) {
                    LOAI_ID.attr('data-id', ui.item.id);
                }, function (ul, item) {
                    return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\"><b>" + item.ma + '</b> ' + item.label + "</a>")
				            .appendTo(ul);
                });


                LOAI_ID.unbind('click').click(function () {
                    LOAI_ID.autocomplete('search', '');
                });
                LOAI_hint.click(function () {
                    LOAI_ID.autocomplete('search', '');
                });

            });
        }
    }
    , EditTheoDoiFn: function () {
        var editRegion = $('.TheoDoi-View');
        if ($(editRegion).length > 0) {
            $(document).on('click', '.theoDoiSuaBtn', function () {
                var item = $(this);
                var id = item.attr('data-id');
                $.ajax({
                    url: domain + '/lib/ajax/TheoDoi/Default.aspx',
                    type: 'POST',
                    data: {
                        subAct: 'get',
                        ID: id
                    },
                    success: function (rs) {
                        $(rs).modal()
                            .on('shown', function () {
                                var AddTheoDoiDialog = $(this);
                                console.log(AddTheoDoiDialog);
                                AddTheoDoiDialog.attr('data-id', id);
                                var Savebtn = AddTheoDoiDialog.find('.Savebtn');
                                var CanNang = AddTheoDoiDialog.find('.CanNang');
                                var ChieuCao = AddTheoDoiDialog.find('.ChieuCao');
                                var NgayGhiBox = AddTheoDoiDialog.find('.NgayGhiBox');
                                var NgayGhi = AddTheoDoiDialog.find('.NgayGhi');
                                NgayGhiBox.datetimepicker({
                                    language: 'vi-Vn'
                                });
                                Savebtn.click(function () {

                                    var _CanNang = CanNang.val();
                                    var _ChieuCao = ChieuCao.val();
                                    var _NgayGhi = NgayGhi.val();
                                    var ID = AddTheoDoiDialog.attr('data-id');

                                    if ((_ChieuCao == '' && _CanNang == '')) {
                                        common.fbMsg('Chọn loại theo dõi, cân nặng, chiều cao bạn nhé'
                        , 'Phải chọn loại theo dõi bạn nhé!', 200, 'msg-portal-pop-processing', function () {
                            setTimeout(function () {
                                $(document).trigger('close.facebox', 'msg-portal-pop');
                            }, 1000);
                        });
                                        return;
                                    }
                                    $.ajax({
                                        url: domain + '/lib/ajax/TheoDoi/Default.aspx',
                                        type: 'POST',
                                        data: {
                                            subAct: 'update',
                                            CanNang: _CanNang,
                                            ChieuCao: _ChieuCao,
                                            NgayGhi: _NgayGhi,
                                            ID: ID
                                        },
                                        success: function (_newEl) {
                                            AddTheoDoiDialog.modal('hide');
                                            var el = $('tr[data-id="' + id + '"]');
                                            var newEl = $(_newEl).insertBefore(el).hide();
                                            el.addClass('animated bounceOutRight');
                                            newEl.show().addClass('animated bounceInLeft');
                                            setTimeout(function () {
                                                el.remove();
                                                newEl.removeClass('animated bounceInLeft');
                                                newEl.addClass('animated flash');
                                                setTimeout(function () {
                                                    newEl.removeClass('animated flash');
                                                }, 1000);
                                            }, 1000);
                                        }
                                    });
                                });
                            })
                            .on('hidden', function () { $(this).remove(); });

                    }
                });
            });
        }
    }
    , SearchFn: function () {
        var searchForm = $('#custom-search-form');
        if ($(searchForm).length < 1)
            return;
        var btn = searchForm.find('a');
        var txt = searchForm.find('input');
        var url = btn.attr('href');
        txt.keyup(function () {
            btn.attr('href', url + '?q=' + $(this).val());
        });
        txt.focus(function () {
            txt.keypress(function (event) {
                if (event.which == 13) {
                    btn.attr('href', url + '?q=' + $(this).val());
                    btn.click();
                    event.preventDefault();
                }
            });
        });
        //        btn.click(function (e) {
        //            e.preventDefault();
        //        });
    }
}

