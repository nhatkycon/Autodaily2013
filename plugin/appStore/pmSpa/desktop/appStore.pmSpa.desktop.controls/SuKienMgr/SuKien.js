var suKienFn = {
    urlDefault: function () { return domain + '/lib/admin/Default.aspx?&act=loadPlug&rqPlug=appStore.pmSpa.desktop.controls.SuKienMgr.DanhSach, appStore.pmSpa.desktop.controls'; },
    EditForm: '#DeskTopSuKienMdl-newDlg',
    Add: function (obj, fn) {
        suKienFn.loadHtml(function () {
            var newDlg = $(suKienFn.EditForm);
            $(newDlg).dialog({
                title: 'Thêm lịch',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        suKienFn.save(obj, function (dt) {
                            if(typeof (fn) =="function") {
                                fn(dt);
                            }
                            suKienFn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        suKienFn.save(obj, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        suKienFn.clearform();
                    }
                },
                beforeClose: function () {
                    suKienFn.clearform();
                },
                open: function () {
                    common.styleButton();
                    suKienFn.clearform();
                    suKienFn.popfn();
                }
            });
        });
    },
    init: function () {
        $('<a href="javascript:;" onclick="suKienFn.Add();" class="topBar-navigation-item icon-add"><span class="icon"></span><span class="icon-ten">Thêm</span></a>').appendTo('#topBar-left');
        suKienFn.get();
    },
    get: function () {
        var list = $('.suKien-list');
        $.ajax({
            url: suKienFn.urlDefault().toString(),
            data: { 'subAct': 'get' },
            type: 'POST',
            dataType: 'script',
            success: function (dt) {
                list.html($('#suKienDesktop-item').tmpl(eval(dt)));
            }
        });
    },
    xoa: function (_obj) {
        var obj = $(_obj);
        var id = obj.attr('id');
        $.ajax({
            url: suKienFn.urlDefault().toString(),
            data: { 'subAct': 'del', 'ID': id },
            type: 'POST',
            dataType: 'script',
            success: function (dt) {
                $('.suKien-item[id="' + id + '"]').fadeOut('1000');
            }
        });
    },
    view: function (_obj, obj1, fn) {
        var obj = $(_obj);
        var id = obj.attr('id');
        suKienFn.loadHtml(function () {
            var newDlg = $(suKienFn.EditForm);
            $(newDlg).dialog({
                title: 'Sửa lịch',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        suKienFn.save(obj1, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            suKienFn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        suKienFn.save(obj1, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            $(newDlg).dialog('close');
                        });
                    },
                    'Xóa': function () {
                        $.ajax({
                            url: suKienFn.urlDefault().toString(),
                            data: { 'subAct': 'del', 'ID': id },
                            type: 'POST',
                            dataType: 'script',
                            success: function (dt) {
                                $('.sk-small-item[id="' + id + '"]').fadeOut('1000');
                            }
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        suKienFn.clearform();
                    }
                },
                beforeClose: function () {
                    suKienFn.clearform();
                },
                open: function () {
                    common.styleButton();
                    suKienFn.clearform();
                    suKienFn.popfn();
                    $.ajax({
                        url: suKienFn.urlDefault().toString(),
                        data: { 'subAct': 'edit', 'ID': id },
                        type: 'POST',
                        dataType: 'script',
                        success: function (_dt) {
                            var dt = eval(_dt);
                            var ID = $('.ID', newDlg);
                            var Ten = $('.Ten', newDlg);
                            var MoTa = $('.MoTa', newDlg);
                            var NhanVien = $('.NhanVien', newDlg);
                            var Ngay = $('.Ngay', newDlg);
                            var DM_ID = $('.DM_ID', newDlg);
                            var Gio = $('.Gio', newDlg);
                            var msg = $('.msg', newDlg);

                            ID.val(dt.ID);
                            Ten.val(dt.Ten);
                            MoTa.val(dt.MoTa);
                            NhanVien.val(dt.NhanVien);
                            DM_ID.val(dt.DM_Ten);
                            DM_ID.attr('_value', dt.DM_ID);
                            var value = new Date(dt.NgayBatDau);

                            Ngay.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());
                            Gio.val(value.getHours() + ':' + value.getMinutes());
                        }
                    });
                }
            });
        });
    },    
    save: function (obj, fn) {
        var newDlg = $(suKienFn.EditForm);
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NhanVien = $('.NhanVien', newDlg);
        var Ngay = $('.Ngay', newDlg);
        var Gio = $('.Gio', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var msg = $('.msg', newDlg);


        var _ID = ID.val();
        var _Ten = Ten.val();
        var _MoTa = MoTa.val();
        var _Ngay = Ngay.val();
        var _Gio = Gio.val();
        var _NhanVien = NhanVien.attr('_value');
        var _DM_ID = DM_ID.attr('_value');

        var err = '';
        if (_Ten == null) { err = 'Nhập Tên<br/>'; }
        if (_Gio == null) { err = 'Nhập giờ<br/>'; }
        if (_NhanVien == null) { err = 'Chọn nhân viên<br/>'; }
        if (err != '') {
            common.fbMsg('Lỗi', 'Bạn cần hoàn thành các lỗi sau <hr/>' + err, 200, 'msg-dangKy-pop', function () {
                setTimeout(function () {
                    $(document).trigger('close.facebox', 'msg-dangKy-pop');
                }, 1000);
            });
            return false;
        }

        var datas = {
            'subAct': 'save',
            ID: _ID,
            Ten: _Ten,
            MoTa: _MoTa,
            Ngay: _Ngay,
            Gio: _Gio,
            DM_ID : _DM_ID,
            NhanVien: _NhanVien
        };
        $.extend(datas, obj);
        $.ajax({
            url: suKienFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: datas,
            success: function (dt) {
                fn(dt);
            }
        });

    },
    popfn: function () {
        var newDlg = $(suKienFn.EditForm);

        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NhanVien = $('.NhanVien', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ngay = $('.Ngay', newDlg);
        var Gio = $('.Gio', newDlg);
        var msg = $('.msg', newDlg);

        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        var dateNgaySinhStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear() - 20);

        Ngay.val(dateStr);
        Ngay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });

        suKienFn.getGio(Gio, function (e, ui) {
        });

        common.regPlug(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(NhanVien, function (event, ui) {
                NhanVien.val(ui.item.value);
                NhanVien.attr('_value', ui.item.value);
            });
        });
        common.regPlug(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'NHOM-SK', DM_ID, function (event, ui) {
                DM_ID.attr('_value', ui.item.id);
            });
            DM_ID.unbind('click').click(function () {
                DM_ID.autocomplete('search', '');
            });
        });
    },
    getGio: function (el, fn) {
        $.ajax({
            url: suKienFn.urlDefault().toString(),
            dataType: 'script',
            data: { 'subAct': 'getGio' },
            success: function (dt, status, xhr) {
                console.log(dt);
                adm.loading(null);
                var data = eval(dt);
                $(el).autocomplete({
                    source: data,
                    minLength: 0,
                    select: function (event, ui) {
                        fn(event, ui);
                    },
                    change: function (event, ui) {
                        if (!ui.item) {
                            if ($(this).val() == '') {
                                $(this).attr('_value', '');
                            }
                        }
                    },
                    delay: 0,
                    selectFirst: true
                }).data("autocomplete")._renderItem = function (ul, item) {
                    return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append('<a>' + item.label + '</a>')
				            .appendTo(ul);
                };
            }
        });

    },
    clearform: function () {
        var newDlg = $(suKienFn.EditForm);
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NhanVien = $('.NhanVien', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ngay = $('.Ngay', newDlg);
        var Gio = $('.Gio', newDlg);
        var msg = $('.msg', newDlg);

        newDlg.attr('_id', '');
        newDlg.find('input, textarea').val('');
        newDlg.find('input, textarea').attr('_value', '');

    },
    draff: function (fn) {
        var newDlg = $(suKienFn.EditForm);
        $.ajax({
            url: suKienFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: {
                'subAct': 'draff'
            },
            success: function (dt) {
                var item = eval(dt);
                newDlg.attr('_id', item.ID);
                newDlg.find('.So').val(item.So);
                fn(dt);
            }
        });
    },
    timKhachHangPopup: function () {
        suKienFn.loadHtml(function () {
            var newDlg = $(suKienFn.TimKiemForm);
            $(newDlg).dialog({
                title: 'Tìm kiếm',
                width: 400,
                modal: true,
                buttons: {
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                },
                open: function () {
                    common.styleButton();
                    suKienFn.timKhachHangPopupFn();
                }
            });
        });
    },
    loadHtml: function (fn) {
        var dlg = $(suKienFn.EditForm);
        if ($(dlg).length < 1) {
            common.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.desktop.controls.SuKienMgr.htm.htm")%>',
                success: function (dt) {
                    common.loading(null);
                    $('body').append(dt);
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
            });
        }
        else {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
    }
}