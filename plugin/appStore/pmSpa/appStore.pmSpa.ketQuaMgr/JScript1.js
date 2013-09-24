var ketQuaMgr = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.ketQuaMgr.Class1, appStore.pmSpa.ketQuaMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        var DMID = $('.mdl-head-filterByLoaiDichVu');
        $('#ketQuaMgr-List').jqGrid({
            url: ketQuaMgr.urlDefault().toString() + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'T/Trạng', 'K/Hàng', 'Tên', 'Mô tả', 'Active'],
            colModel: [
                        { name: 'KQ_ID', key: true, sortable: true, hidden: true },
                        { name: 'KQ_TT_ID', width: 10, sortable: true, align: "center" },
                        { name: 'KQ_KH_ID', width: 20, sortable: true, align: "center" },
                        { name: 'KQ_Ten', width: 20, resizable: true, sortable: true },
                        { name: 'KQ_MoTa', width: 50, resizable: true, sortable: true, align: "center" },
                        { name: 'KQ_Active', width: 10, resizable: true, sortable: true, align: "center" }
                    ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'KQ_ThuTu',
            sortorder: 'desc',
            rowNum: 10000,
            onSelectRow: function (rowid) {
            },
            pager: $('#ketQuaMgr-Pager'),
            loadComplete: function () {
                if (typeof (Ajax_upload) == 'undefined') {
                    $.getScript('../js/ajaxupload.js', function () { });
                };
                adm.loading(null);
            }
        });
        adm.watermark(DMID, 'Gõ tên loại danh mục để lọc', function () {
        });
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid = '#ketQuaMgr-List';

        if (jQuery(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                ketQuaMgr.loadHtml(function () {
                    var newDlg = $('#ketQuaMgr-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                ketQuaMgr.save(false, function () {
                                    ketQuaMgr.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                ketQuaMgr.save(false, function () {
                                    ketQuaMgr.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            ketQuaMgr.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            ketQuaMgr.clearform();
                            ketQuaMgr.popfn();
                            $.ajax({
                                url: ketQuaMgr.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);

                                    var ID = $('.ID', newDlg);
                                    var TT_ID = $('.TT_ID', newDlg);
                                    var KH_ID = $('.KH_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var Anh = $('.Anh', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var Active = $('.Active', newDlg);

                                    var spbMsg = $('.admMsg', newDlg);
                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var Anh = $('.Anh', newDlg);

                                    imgAnh.attr('src', '');
                                    Anh.attr('ref', '');

                                    Anh.attr('ref', dt.Anh);
                                    imgAnh.attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());

                                    ID.val(dt.ID);



                                    TT_ID.val(dt.TT_Ten);
                                    TT_ID.attr('_value', dt.TT_ID);
                                    KH_ID.val(dt.KH_Ten);
                                    KH_ID.attr('_value', dt.KH_ID);

                                    Ten.val(dt.Ten);
                                    ThuTu.val(dt.ThuTu);
                                    MoTa.val(dt.MoTa);
                                    NoiDung.val(dt.NoiDung);

                                    if (dt.Active) {
                                        Active.attr('checked', 'checked');
                                    }
                                    else {
                                        Active.removeAttr('checked');
                                    }
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function () {
        ketQuaMgr.loadHtml(function () {
            var newDlg = $('#ketQuaMgr-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        ketQuaMgr.save(false, function () {
                            ketQuaMgr.clearform();
                        }, '#ketQuaMgr-List');
                    },
                    'Lưu và đóng': function () {
                        ketQuaMgr.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#ketQuaMgr-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    ketQuaMgr.clearform();
                },
                open: function () {
                    adm.styleButton();
                    ketQuaMgr.clearform();
                    ketQuaMgr.popfn();
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid = '#ketQuaMgr-List';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa danh mục này?')) {// Xác nhận xem có xóa hay không
                var treedata = $(grid).jqGrid('getRowData', s); // Lấy row hiện tại đang select
                var __DV_ID = treedata.DV_ID; // Lấy DV_ID thật của danh mục
                $.ajax({
                    url: ketQuaMgr.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': __DV_ID },
                    success: function (dt) {
                        jQuery(grid).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    save: function (validate, fn, grid) {
        if (typeof (grid) == 'undefined') grid = '#ketQuaMgr-List';
        var newDlg = $('#ketQuaMgr-dlgNew');

        var ID = $('.ID', newDlg);
        var TT_ID = $('.TT_ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Anh = $('.Anh', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);

        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var Anh = $('.Anh', newDlg);

        var _Anh = $(Anh).attr('ref');

        var _ID = ID.val();
        var _TT_ID = TT_ID.attr('_value');
        var _KH_ID = KH_ID.attr('_value');
        var _Ten = Ten.val();
        var _ThuTu = ThuTu.val();
        var _MoTa = MoTa.val();
        var _NoiDung = NoiDung.val();
        var _Anh = Anh.attr('ref');
        var _Active = Active.is(':checked');

        ////console.log(_Anh);
        var err = '';
        if (_TT_ID == '') { err += 'Chọn tình trạng<br/>'; };
        if (_KH_ID == '') { err += 'Chọn khách hàng<br/>'; };
        if (_Ten == '') { err += 'Nhập tên<br/>'; };
        if (_ThuTu == '') { _ThoiGian = '0'; } else { if (!adm.isInt(_ThuTu)) { err += 'Nhập thời gian kiểu số<br/>'; } }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: ketQuaMgr.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                ID: _ID,
                TT_ID: _TT_ID,
                KH_ID: _KH_ID,
                Ten: _Ten,
                MoTa: _MoTa,
                Anh: _Anh,
                NoiDung: _NoiDung,
                ThuTu: _ThuTu,
                Active: _Active
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    $(grid).trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    search: function () {
        var timerSearch;
        var LDMID = $('.mdl-head-filterByLoaiDichVu');
        var q = $('.mdl-head-search-dichVuMgr').val();
        var _LDMID = $(LDMID).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#ketQuaMgr-List').jqGrid('setGridParam', { url: ketQuaMgr.urlDefault().toString() + '&subAct=get&DM_ID=' + _LDMID + '&q=' + q.val() }).trigger('reloadGrid');
        }, 500);
    },
    popfn: function () {
        var newDlg = $('#ketQuaMgr-dlgNew');

        var ID = $('.ID', newDlg);
        var TT_ID = $('.TT_ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Anh = $('.Anh', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);

        var btnThemNhanhKH = $('.btnThemNhanhKH', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);


        adm.regType(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
            DanhSachKhachHangFn.autoCompleteSearch(KH_ID, function (event, ui) {
                KH_ID.attr('_value', ui.item.id);
            });
            btnThemNhanhKH.unbind('click').click(function () {
                DanhSachKhachHangFn.add(function (_ID, _Ten) {
                    KH_ID.attr('_value', _ID);
                    KH_ID.val(_Ten);
                });
            });
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TINH-TRANG', TT_ID, function (event, ui) {
                TT_ID.attr('_value', ui.item.id);
                TT_ID.val(ui.item.ten);
            });
        });

        adm.createTinyMce(NoiDung);

        var ulpFn = function () {
            var imgAnh = $('.adm-upload-preview-img', newDlg);
            var Anh = $('.Anh', newDlg);
            var _params = { 'oldFile': $(Anh).attr('ref') };
            adm.upload(Anh, 'anh', _params, function (rs) {
                $(Anh).attr('ref', rs)
                $(imgAnh).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
            }, function (f) {
            });
        };
        ulpFn();
    },       
    clearform: function () {
        var newDlg = $('#ketQuaMgr-dlgNew');

        var ID = $('.ID', newDlg);
        var TT_ID = $('.TT_ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Anh = $('.Anh', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);


        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);


        ID.val('');
        TT_ID.val('');
        TT_ID.attr('_value', '');
        KH_ID.val('');
        KH_ID.attr('_value', '');
        Ten.val('');
        MoTa.val('');
        NoiDung.val('');
        ThuTu.val('');
        Active.removeAttr('checked');

        imgAnh.attr('src', '');
        Anh.attr('ref', '');
        $(spbMsg).html('');
    },
    autoCompleteByQ: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'dichVu-autoCompleteByQ' + el.val();
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: ketQuaMgr.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteByQ', 'q': el.val() },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        ma: item.Ma,
                                        gia: item.Gia
                                    }
                                }
                            }))
                        }
                    }
                });
            },
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
				            .append("<a><b>" + item.ma + '</b> ' + item.label + ' [' + item.gia + '] </a>')
				            .appendTo(ul);
        };
    },
    loadHtml: function (fn) {
        var dlg = $('#ketQuaMgr-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.ketQuaMgr.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
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
