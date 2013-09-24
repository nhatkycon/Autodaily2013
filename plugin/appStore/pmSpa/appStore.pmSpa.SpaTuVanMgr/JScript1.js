var SpaTuVanMgrFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.SpaTuVanMgr.Class1, appStore.pmSpa.SpaTuVanMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        var KH_ID = $('.filter-tuVan-byKhachHang');
        $('#SpaTuVanMgrMdl-List').jqGrid({
            url: SpaTuVanMgrFn.urlDefault().toString() + '&subAct=get&',
            height: '1000',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mã', 'Khách hàng', 'Tư vấn viên', 'Ngày'],
            colModel: [
                { name: 'ID', key: true, width: 1, sortable: true, hidden: true },
                { name: 'Ma', width: 20, sortable: true },
                { name: 'KH_ID', width: 20, sortable: true },
                { name: 'TuVanVien', width: 20, sortable: true },
                { name: 'NgayTao', width: 20, sortable: true }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'NgayTao',
            sortorder: 'desc',
            pager: jQuery('#SpaTuVanMgrMdl-Pager'),
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                adm.loading(null);
                adm.regJPlugin(jQuery().tmpl, '../js/jquery.tmpl.min.js', function () {
                });
                adm.regType(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
                    DanhSachKhachHangFn.autoCompleteSearch(KH_ID, function (event, ui) {
                        KH_ID.attr('_value', ui.item.id);
                        SpaTuVanMgrFn.search();
                    });
                });
            }
        });
    },
    refresh: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#SpaTuVanMgrMdl-List';
        var KH_ID = $('.filter-tuVan-byKhachHang');
        KH_ID.val('');
        KH_ID.attr('_value', '');
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: SpaTuVanMgrFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        }, 500);
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#SpaTuVanMgrMdl-List';

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
                SpaTuVanMgrFn.loadHtml(function () {
                    var newDlg = $('#SpaTuVanMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 1000,
                        buttons: {
                            'Lưu': function () {
                                SpaTuVanMgrFn.save(false, function () {
                                    SpaTuVanMgrFn.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                SpaTuVanMgrFn.save(false, function () {
                                    SpaTuVanMgrFn.clearform();
                                    $(newDlg).dialog('close');
                                    SpaTuVanMgrFn.draffTuVan(function (_item) { });
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            SpaTuVanMgrFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            SpaTuVanMgrFn.clearform();
                            SpaTuVanMgrFn.popfn();
                            $.ajax({
                                url: SpaTuVanMgrFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var newDlg = $('#SpaTuVanMgrMdl-dlgNew');

                                    var So = newDlg.find('.So');
                                    var ID = newDlg.find('.ID');
                                    var Ngay = newDlg.find('.Ngay');
                                    var TuVanVien = newDlg.find('.TuVanVien');
                                    var TinhTrangSucKhoe = newDlg.find('.TinhTrangSucKhoe');
                                    var TinhTrangLanDa = newDlg.find('.TinhTrangLanDa');
                                    var YKienKhachHang = newDlg.find('.YKienKhachHang');
                                    var DichVuDieuTriKhac = newDlg.find('.DichVuDieuTriKhac');
                                    var DV_Chon = newDlg.find('.DV_Chon');
                                    var DV_DanhSach = newDlg.find('.DV_DanhSach');
                                    var KH_ID = newDlg.find('.KH_ID');

                                    ID.val(dt.ID);
                                    newDlg.attr('_id', dt.ID);
                                    So.val(dt.So);
                                    KH_ID.val(dt.KH_Ten);
                                    KH_ID.attr('_value', dt.KH_ID);
                                    var value = new Date(dt.Ngay);
                                    Ngay.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());
                                    TuVanVien.val(dt.TuVanVien_Ten);
                                    TuVanVien.attr('_value', dt.TuVanVien);
                                    TinhTrangSucKhoe.val(dt.TinhTrangSucKhoe);
                                    TinhTrangLanDa.val(dt.TinhTrangLanDa);
                                    YKienKhachHang.val(dt.YKienKhachHang);
                                    DichVuDieuTriKhac.val(dt.DichVuDieuTriKhac);
                                    DV_DanhSach.html($('#tt-item-view').tmpl(dt._TuVanTinhTrang));

                                    DV_DanhSach.find('.tt-item-xoaBtn').unbind('click').click(function () {
                                        var _item = $(this);
                                        var _pitem = _item.parent().parent().parent();
                                        $.ajax({
                                            url: SpaTuVanMgrFn.urlDefault().toString(),
                                            type: 'POST',
                                            dataType: 'script',
                                            data: {
                                                'subAct': 'delTinhTrang',
                                                'ID': newDlg.attr('_id'),
                                                'TT_ID': _item.attr('id')
                                            },
                                            success: function (dt) {
                                                _pitem.fadeOut(1000);
                                                setTimeout(function () {
                                                    _pitem.remove();
                                                }, 1000);
                                            }
                                        });
                                    });
                                    
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function (fn) {
        SpaTuVanMgrFn.loadHtml(function () {
            var newDlg = $('#SpaTuVanMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1000,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        SpaTuVanMgrFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            SpaTuVanMgrFn.clearform();
                            SpaTuVanMgrFn.draffTuVan(function (_item) { });
                        }, '#SpaTuVanMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        SpaTuVanMgrFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            $(newDlg).dialog('close');
                        }, '#SpaTuVanMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    SpaTuVanMgrFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    SpaTuVanMgrFn.clearform();
                    SpaTuVanMgrFn.popfn();
                    SpaTuVanMgrFn.draffTuVan(function (_item) { });
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#SpaTuVanMgrMdl-List';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa khách hàng này?')) {// Xác nhận xem có xóa hay không
                    $.ajax({
                        url: SpaTuVanMgrFn.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: { 'ID': s },
                        success: function (dt) {
                            jQuery(grid).trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn, grid) {
        if (typeof (grid) == 'undefined') grid == '#SpaTuVanMgrMdl-List';
        var newDlg = $('#SpaTuVanMgrMdl-dlgNew');
        var So = newDlg.find('.So');
        var Ngay = newDlg.find('.Ngay');
        var TuVanVien = newDlg.find('.TuVanVien');
        var TinhTrangSucKhoe = newDlg.find('.TinhTrangSucKhoe');
        var TinhTrangLanDa = newDlg.find('.TinhTrangLanDa');
        var YKienKhachHang = newDlg.find('.YKienKhachHang');
        var DichVuDieuTriKhac = newDlg.find('.DichVuDieuTriKhac');
        var KH_ID = newDlg.find('.KH_ID');
        
        var _So = So.val();
        var _Ngay = Ngay.val();
        var _Ngay = Ngay.val();
        var _TuVanVien = TuVanVien.attr('_value');
        var _TinhTrangSucKhoe = TinhTrangSucKhoe.val();
        var _TinhTrangLanDa = TinhTrangLanDa.val();
        var _YKienKhachHang = YKienKhachHang.val();
        var _DichVuDieuTriKhac = DichVuDieuTriKhac.val();
        var _ID = newDlg.attr('_id');
        var _KH_ID = KH_ID.attr('_value');
        
        var err = '';
        if (_So == '') { err = 'Nhập số<br/>'; }
        if (_TuVanVien == '') { err = 'Chọn tư vấn viên<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        var datas = {
            'subAct': 'save',
            ID: _ID,
            So: _So,
            Ngay: _Ngay,
            TuVanVien: _TuVanVien,
            TinhTrangSucKhoe: _TinhTrangSucKhoe,
            TinhTrangLanDa: _TinhTrangLanDa,
            YKienKhachHang: _YKienKhachHang,
            DichVuDieuTriKhac: _DichVuDieuTriKhac,
            KH_ID: _KH_ID,
            Ngay: _Ngay
        };        
        var err = '';
        if (_So == '') { err += 'Nhập số<br/>'; };
        if (_KH_ID == '') { err += 'Nhập khách hàng<br/>'; };
        
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: SpaTuVanMgrFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: datas,
            success: function(dt) {
                adm.loading(null);
                $(grid).trigger('reloadGrid');
                if (typeof (fn) == 'function') {
                    fn(_ID, _Ten);
                }
            }
        });
    },
    search: function () {
        var timerSearch;
        var KH_ID = $('.filter-tuVan-byKhachHang');
        var _KH_ID = $(KH_ID).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#SpaTuVanMgrMdl-List').jqGrid('setGridParam', { url: SpaTuVanMgrFn.urlDefault().toString() + '&subAct=get&KH_ID=' + _KH_ID}).trigger('reloadGrid');
        }, 500);
    },
    popfn: function () {
        var newDlg = $('#SpaTuVanMgrMdl-dlgNew');
        var So = newDlg.find('.So');
        var Ngay = newDlg.find('.Ngay');
        var TuVanVien = newDlg.find('.TuVanVien');
        var TinhTrangSucKhoe = newDlg.find('.TinhTrangSucKhoe');
        var TinhTrangLanDa = newDlg.find('.TinhTrangLanDa');
        var YKienKhachHang = newDlg.find('.YKienKhachHang');
        var HH_DanhSach = newDlg.find('.HH_DanhSach');
        var DichVuDieuTriKhac = newDlg.find('.DichVuDieuTriKhac');
        var DV_Chon = newDlg.find('.DV_Chon');
        var DV_DanhSach = newDlg.find('.DV_DanhSach');
        var btnThemNhanhKH = newDlg.find('.btnThemNhanhKH');
        var KH_ID = newDlg.find('.KH_ID');
        var Ngay = $('.Ngay', newDlg);
        
        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        Ngay.val(dateStr);
        Ngay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(TuVanVien, function (event, ui) {
                TuVanVien.attr('_value', ui.item.value);
            });
        });
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TINH-TRANG', DV_Chon, function (event, ui) {
                $.ajax({
                    url: SpaTuVanMgrFn.urlDefault().toString(),
                    type: 'POST',
                    dataType: 'script',
                    data: {
                        'subAct': 'addTinhTrang',
                        'ID': newDlg.attr('_id'),
                        'TT_ID': ui.item.id
                    },
                    success: function (dt) {
                        var myUi = eval(dt);
                        var currentTt = DV_DanhSach.find('.' + myUi.id);
                        if ($(currentTt).length > 0) {
                        }
                        else {
                            $('#tt-item-view').tmpl(myUi).appendTo(DV_DanhSach);
                            currentTt = DV_DanhSach.find('.' + myUi.id);
                        }
                        currentTt.find('.tt-item-xoaBtn').unbind('click').click(function () {
                            $.ajax({
                                url: SpaTuVanMgrFn.urlDefault().toString(),
                                type: 'POST',
                                dataType: 'script',
                                data: {
                                    'subAct': 'delTinhTrang',
                                    'ID': newDlg.attr('_id'),
                                    'TT_ID': currentTt.attr('id')
                                },
                                success: function (dt) {
                                    currentTt.fadeOut(1000);
                                    setTimeout(function () {
                                        currentTt.remove();
                                    }, 1000);
                                }
                            });
                        });
                    }
                });
            });
        });
        
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
        
        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        Ngay.val(dateStr);
        Ngay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    clearform: function () {
        var newDlg = $('#SpaTuVanMgrMdl-dlgNew');
        var So = newDlg.find('.So');
        var Ngay = newDlg.find('.Ngay');
        var TuVanVien = newDlg.find('.TuVanVien');
        var TinhTrangSucKhoe = newDlg.find('.TinhTrangSucKhoe');
        var TinhTrangLanDa = newDlg.find('.TinhTrangLanDa');
        var YKienKhachHang = newDlg.find('.YKienKhachHang');
        var DV_Chon = newDlg.find('.DV_Chon');
        var DichVuDieuTriKhac = newDlg.find('.DichVuDieuTriKhac');
        var DV_Chon = newDlg.find('.DV_Chon');
        var DV_DanhSach = newDlg.find('.DV_DanhSach');

        newDlg.attr('_id', '');
        newDlg.find('input, textarea').val('');
        newDlg.find('input, textarea').attr('_value', '');
        DV_DanhSach.html('');
    },
    autoCompleteSearch: function (el, fn, fn1, fn2) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'SpaTuVanMgr-autoCompleteSearch' + request.term;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: SpaTuVanMgrFn.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'search', 'q': request.term },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function(item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        so: item.So
                                    };
                                }
                            }));
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
            if(typeof (fn1) == "function") {
                return fn1(ul, item);
            }
            else {
                return $("<li></li>")
                                .data("item.autocomplete", item)
                                .append("<a href=\"javascript:;\"><b>" + item.so + "</b>" + item.label + "</a>")
                                .appendTo(ul);
            }
        };
    },
    draffTuVan: function (fn) {
        var newDlg = $('#SpaTuVanMgrMdl-dlgNew');
        $.ajax({
            url: SpaTuVanMgrFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: {
                'subAct': 'draffTuVan'
            },
            success: function (dt) {
                var item = eval(dt);
                newDlg.attr('_id', item.ID);
                newDlg.find('.So').val(item.So);
                fn(dt);
            }
        });
    },
    loadHtml: function (fn) {
        var dlg = $('#SpaTuVanMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.SpaTuVanMgr.htm.htm")%>',
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
