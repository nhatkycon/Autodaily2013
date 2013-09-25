var autofn = {
    Setup: function() {
        autofn.GameAdminDanhSachThem();
        autofn.GameAdminDanhSachFn();
        autofn.QuestionAdminThem();
        autofn.QuestionAdminDanhSachFn();
    }
    , GameAdminDanhSachThem: function () {
        var pnl = $('.GameThemPnl');
        var GameList = $('.GameList');
        var TenEl = pnl.find('.Ten');
        var ThuTuEl = pnl.find('.ThuTu');
        var btn = pnl.find('button');
        
        btn.click(function () {
            var Ten = TenEl.val();
            var ThuTu = ThuTuEl.val();
            if (Ten == '') {
                alert('Nhập Tên! Guy');
                return;
            }
            if (ThuTu == '')
                ThuTu = '0';
            $.ajax({
                url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                data: {
                    subAct: 'addGame',
                    Ten: Ten,
                    ThuTu: ThuTu
                },
                success: function (dt) {
                    TenEl.val('');
                    ThuTuEl.val('');
                    var item = $(dt).prependTo(GameList);
                    item.addClass('animated bounceInDown');
                    setTimeout(function () {
                        item.removeClass('animated bounceInDown');
                    }, 1000);
                }
            });
        });
    }
    , GameAdminDanhSachFn: function () {
        var GameList = $('.GameList');
        GameList.on('click', '.edit', function () {
            var item = $(this);
            var id = item.attr('data-id');
            var pitem = item.parent().parent();
            var editPnl = pitem.find('.editPnl');
            editPnl.html('Loading...');
            $.ajax({
                url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                data: {
                    subAct: 'editGame',
                    ID: id
                },
                success: function (_dt) {
                    var dt = eval(_dt);
                    editPnl.html('');
                    var GameItem = $('#GameItem').tmpl(dt).prependTo(editPnl);
                }
            });
        });
        
        GameList.on('click', '.cancelBtn', function () {
            var item = $(this);
            item.parent().parent().html('').hide();
        });

        GameList.on('click', '.saveBtn', function () {
            var item = $(this);
            var pitem = item.parent().parent();
            var TenEl = pitem.find('.Ten');
            var ThuTuEl = pitem.find('.ThuTu');
            var id = item.attr('data-id');
            var Ten = TenEl.val();
            var ThuTu = ThuTuEl.val();
            if (Ten == '') {
                alert('Nhập Tên! Guy');
                return;
            }
            if (ThuTu == '')
                ThuTu = '0';
            var TenLbl =  pitem.parent().find('.viewpnl').find('.Ten');
            TenLbl.html(Ten);
            $.ajax({
                url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                data: {
                    subAct: 'saveGame',
                    ID: id,
                    Ten: Ten,
                    ThuTu: ThuTu
                },
                success: function (dt) {
                    alert('Lưu thành công');
                    pitem.html('');
                }
            });
        });

        GameList.on('click', '.remove', function () {
            var item = $(this);
            var con = confirm('Bạn có muốn xóa bỏ không? Nghiêm túc đó!!!');
            if(con) {
                $.ajax({
                    url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                    data: {
                        subAct: 'removeGame',
                        ID: item.attr('data-id')
                    },
                    success: function (dt) {
                        var pitem = item.parent().parent();
                        pitem.addClass('animated bounceOutRight');
                        setTimeout(function () {
                            pitem.remove();
                        }, 500);
                    }
                });
            }
        });
    }
    , QuestionAdminThem:function () {
        var questionThemPnl = $('.QuestionThemPnl');
        var addPnl = questionThemPnl.find('.addPnl');
        if ($(addPnl).length < 1)
            return;
        var addBtn = questionThemPnl.find('.addBtn');
        addBtn.click(function() {
            var item = { ID: '', Active: false };
            addPnl.html('');
            var itemEl = $('#QItem').tmpl(item).prependTo(addPnl);
            autofn.QuestionAdminThemFn(itemEl);
            autofn.QuestionAdminSaveFn(itemEl, function(pnl,dt) {
                var QuestionList = $('.QuestionList');
                var itemEl = $(dt).prependTo(QuestionList);
                itemEl.addClass('animated bounceInDown');
                setTimeout(function () {
                    itemEl.removeClass('animated bounceInDown');
                }, 1000);
                pnl.parent().html('');
            },function (pnl) {
                pnl.parent().html('');
            });
        });
    }
    , QuestionAdminThemFn: function (pnl) {
        var MoTa = pnl.find('.MoTa');
        var AnhDaiDien = pnl.find('.AnhDaiDien');
        var Anh = pnl.find('.Anh');
        


        adm.ckeditor_blogPost(MoTa);
        
        if ($(Anh).length > 0) {
            var param = { 'subAct': 'uploadAnh' };
            //return false;
            new Ajax_upload(jQuery(Anh), {
                action: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
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
                        Anh.attr('src', '/lib/up/i/' + response);
                        Anh.attr('data-src', response);
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
            param = { 'subAct': 'uploadAnhDaiDien' };
            new Ajax_upload(jQuery(AnhDaiDien), {
                action: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
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
                        AnhDaiDien.attr('src', '/lib/up/i/' + response);
                        AnhDaiDien.attr('data-src', response);
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
    , QuestionAdminSaveFn: function (pnl, fn,fn1) {
        var AnhDaiDienEl = pnl.find('.AnhDaiDien');
        var AnhEl = pnl.find('.Anh');
        var TenEl = pnl.find('.Ten');
        var ThuTuEl = pnl.find('.ThuTu');
        var MoTaEl = pnl.find('.MoTa');
        var ActiveEl = pnl.find('.Active');
        var saveBtn = pnl.find('.saveBtn');
        var cancelBtn = pnl.find('.cancelBtn');
        var G_ID = pnl.attr('data-g-id');
        var ID = pnl.attr('data-id');
        saveBtn.click(function() {
            var Anh = AnhEl.attr('data-src');
            var AnhDaiDien = AnhDaiDienEl.attr('data-src');
            var Ten = TenEl.val();
            var ThuTu = ThuTuEl.val();
            var MoTa = MoTaEl.val();
            var Active = ActiveEl.is(':checked');
            if (ThuTu == '')
                ThuTu = '0';
            var data = {
                subAct: 'saveQuestion'
                , Ten: Ten
                , MoTa: MoTa
                , ThuTu: ThuTu
                , Anh: Anh
                , AnhDaiDien: AnhDaiDien
                , G_ID: G_ID
                , ID: ID
                , Active: Active
            };

            $.ajax({
                url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                data: data,
                success: function (dt) {
                    fn(pnl, dt);
                }
            });
        });
        cancelBtn.click(function () {
            fn1(pnl);
        });
    }
    , QuestionAdminDanhSachFn: function () {
        var QuestionList = $('.QuestionList');
        var url = domain + '/lib/ajax/Game/Default.aspx';

        


        QuestionList.on('click', '.questionViewCheckbox', function () {
            var item = $(this);
            var id = item.attr('data-id');
            $.ajax({
                url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                data: {
                    subAct: 'updateQuestionActive',
                    ID: id,
                    Active : item.is(':checked')
                },
                success: function (dt) {

                }
            });
        });

        QuestionList.on('click', '.edit', function () {
            var item = $(this);
            var id = item.attr('data-id');
            var pitem = item.parent().parent().parent().parent().parent();
            var editPnl = pitem.find('.editPnl');
            editPnl.html('Loading...');
            $.ajax({
                url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                data: {
                    subAct: 'editQuestion',
                    ID: id
                },
                success: function (_dt) {
                    var dt = eval(_dt);
                    editPnl.html('');
                    var QItem = $('#QItem').tmpl(dt).prependTo(editPnl);
                    if(dt.Active) {
                        QItem.find('.Active').attr('checked', 'checked');
                    }
                    autofn.QuestionAdminThemFn(QItem);
                    autofn.QuestionAdminSaveFn(QItem, function (pnl, dt) {
                        pnl.parent().html('');
                    }, function (pnl) {
                        pnl.parent().html('');
                    });
                }
            });
        });
        
        QuestionList.on('click', '.remove', function () {
            var item = $(this);
            var con = confirm('Bạn có muốn xóa bỏ không? Nghiêm túc đó!!!');
            if (con) {
                $.ajax({
                    url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                    data: {
                        subAct: 'removeQuestion',
                        ID: item.attr('data-id')
                    },
                    success: function (dt) {
                        var pitem = item.parent().parent().parent().parent().parent();
                        pitem.addClass('animated bounceOutRight');
                        setTimeout(function () {
                            pitem.remove();
                        }, 500);
                    }
                });
            }
        });

        QuestionList.on('blur', '.ThuTuAnh', function () {
            var txt = $(this);
            $.ajax({
                url: url,
                data: {
                    'subAct': 'updateThuTuAnswer',
                    ID: txt.attr('data-id'),
                    ThuTu: txt.val()
                },
                success: function () {
                }
            });
        });

        QuestionList.on('click', '.XoaAnhBtn', function () {
            var item = $(this);
            $.ajax({
                url: url
            , data: {
                'subAct': 'xoaAnhAnswer'
                , ID: item.attr('data-id')
            }
            , success: function () {
                var pitem = item.parent().parent();
                pitem.addClass('animated bounceOutRight');
                setTimeout(function () {
                    pitem.remove();
                }, 500);
            }
            });
        });

        QuestionList.on('click', '.showAnhBtn', function () {
            var item = $(this);
            var id = item.attr('data-id');
            var show = item.attr('data-show');
            var qitem = item.parent().parent().parent().parent().parent();
            var anhList = qitem.find('.anhList');
            var loaded = anhList.attr('data-loaded');
            var body = anhList.find('.showAnhForm-body');
            var btnThemAnh = anhList.find('.btnThemAnh');
            var btnCount = anhList.find('.btnCount');
            var closeAnhBtn = anhList.find('.closeAnhBtn');
            var f5Btn = anhList.find('.f5Btn');
            if (loaded == '0') {
                anhList.attr('data-loaded', '1');
                
                $.ajax({
                    url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                    data: {
                        subAct: 'getAnswerList',
                        ID: item.attr('data-id')
                    },
                    success: function (dt) {
                        $(dt).prependTo(body);
                    }
                });

                btnThemAnh.fileupload({
                    url: url,
                    dataType: 'json',
                    dropZone: body,
                    formData: {
                        'subAct': 'uploadAnswerAnh'
                        , Q_ID: id
                    },
                    done: function (e, data) {
                        btnCount.hide();
                        
                        $.each(data.result.files, function (index, file) {
                            var anhItem = $('#anh-item').tmpl(file).prependTo(body);

                            
                        });
                    },
                    progressall: function (e, data) {
                        btnCount.show();
                        var progress = parseInt(data.loaded / data.total * 100, 10);
                        btnCount.html(progress + '%');
                    }
                });
            }

           
            if (show == '0') {
                anhList.show();
                item.attr('data-show','1');
            } else if (show == '1') {
                anhList.hide();
                item.attr('data-show', '0');
            }
            else {
                anhList.show();
                item.attr('data-show', '1');
            }

            f5Btn.unbind('click').click(function () {
                var itemf5 = $(this);
                $.ajax({
                    url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                    data: {
                        subAct: 'getAnswerList',
                        ID: itemf5.attr('data-q-id')
                    },
                    success: function (dt) {
                        body.html(dt);
                    }
                });
            });

            closeAnhBtn.unbind('click').click(function () {
                anhList.hide();
                item.attr('data-show', '0');
            });
        });
    }
};

$(function() {
    autofn.Setup();
    

});