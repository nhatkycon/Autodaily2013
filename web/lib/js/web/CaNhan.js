$(function () {
    bcyCaNhan.caiDatFn();
    bcyCaNhan.UnLikeFn();
    bcyCaNhan.SuaBeFn();
    bcyCaNhan.KhongChiaSeBeFn();
    bcyCaNhan.SuaNickFn();
});

var bcyCaNhan = {
    caiDatFn: function () {
        var CaiDatForm = $('.CaiDatForm');
        if ($(CaiDatForm).length < 1)
            return;
        var Ten = CaiDatForm.find('.Ten');
        var Savebtn = CaiDatForm.find('.Savebtn');
        var img = CaiDatForm.find('img');
        var hoatDongDoiAnhBtn = CaiDatForm.find('.blog-post-doiAnhBtn').find('a');

        var msgCaiDatDone = CaiDatForm.find('.msgCaiDatDone');
        var msgCaiDatMissing = CaiDatForm.find('.msgCaiDatMissing');
        Savebtn.click(function () {
            var _Ten = Ten.val();
            var _Anh = img.attr('data-src');
            msgCaiDatDone.hide();
            msgCaiDatMissing.hide();
            if (_Ten == '') {
                msgCaiDatDone.hide();
                msgCaiDatMissing.show();
                return;
            }
            $.ajax({
                url: domain + '/lib/ajax/CaNhan/Default.aspx',
                type: 'POST',
                data: {
                    subAct: 'update',
                    Ten: _Ten,
                    Anh: _Anh
                },
                success: function () {
                    msgCaiDatDone.show();
                    msgCaiDatMissing.hide();
                }
            });
        });

        if ($(hoatDongDoiAnhBtn).length > 0) {
            var param = { 'subAct': 'upload' };
            //return false;
            new Ajax_upload(jQuery(hoatDongDoiAnhBtn), {
                action: domain + '/lib/ajax/CaNhan/Default.aspx',
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
    }
    , UnLikeFn: function () {
        //UnLikeBtn
        $(document).on('click', '.UnLikeBtn', function () {
            var item = $(this);
            var id = item.attr('data-id');

            $.ajax({
                url: domain + '/lib/ajax/Thich/Default.aspx',
                data: {
                    subAct: 'like',
                    ID: id,
                    Liked: 'False'
                },
                success: function () {
                    var pitem = item.parent().parent().parent();
                    pitem.addClass('animated bounceOutRight');
                    setTimeout(function () {
                        pitem.remove();
                    }, 500);
                }
            });
        });
    }
    , SuaBeFn: function () {
        var Taobe = $('#SuaBeForm');
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

            $('#NgayDuSinhBox').datetimepicker({
                language: 'vi-Vn'
            });
            $('#NgaySinhBox').datetimepicker({
                language: 'vi-Vn'
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
                var _ID = SaveBe.attr('data-id');

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
                    'subAct': 'save'
                    , Alias: _Alias
                    , Ho: _Ho
                    , Ten: _Ten
                    , NgaySinh: _NgaySinh
                    , CanNang: _CanNang
                    , GioiTinh: _GioiTinh
                    , NgayDuSinh: _NgayDuSinh
                    , MangThai: _MangThai
                    , ID: _ID
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
    , SuaNickFn: function () {
        $('.editNick').click(function () {
            var item = $(this);
            var id = item.attr('data-id');
            var ref = item.attr('href');
            var nick = item.attr('data-nick');
            $(ref).modal().on('shown', function () {
                var Nick = $(ref).find('.Nick');
                var NickPath = $(ref).find('.NickPath');
                NickPath.html(nick);
                Nick.val(nick);
                Nick.unbind('keyup').keyup(function () {
                    NickPath.html(Nick.val());
                });
                var success = $(ref).find('.alert-success');
                var error = $(ref).find('.alert-error');
                var SaveBtn = $(ref).find('.Savebtn');
                SaveBtn.unbind('click').click(function () {
                    success.hide();
                    error.hide();
                    var _Nick = Nick.val();
                    if (_Nick == nick) {
                        return;
                    }
                    $.ajax({
                        url: domain + '/lib/ajax/Be/'
                        , data: {
                            'subAct': 'SuaNick'
                            , Nick: _Nick
                            , ID: id
                        }
                        , success: function (_dt) {
                            if (_dt == '0') {
                                success.hide();
                                error.show();
                            } else {
                                success.show();
                                error.hide();
                            }
                        }
                    });

                });
            });
        });
    }
    , KhongChiaSeBeFn: function () {
        $(document).on('click', '.btnKhongChiaSeBtn', function () {
            var item = $(this);
            var id = item.attr('data-id');
            var _KhongChiaSe = !item.find('i').hasClass('icon-lock');
            if (_KhongChiaSe) {
                item.find('i').removeClass('icon-unlock').addClass('icon-lock');
            } else {
                item.find('i').removeClass('icon-lock').addClass('icon-unlock');
            }
            $.ajax({
                url: domain + '/lib/ajax/Be/Default.aspx',
                type: 'POST',
                data: {
                    subAct: 'UpdateChiaSe',
                    KhongChiaSe: _KhongChiaSe,
                    ID: id
                },
                success: function (_id) {
                }
            });

        });
    }
}

