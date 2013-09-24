var KhuyenMaiMgrFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.khuyenMaiMgr.Class1, appStore.pmSpa.khuyenMaiMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        $('#KhuyenMaiMgrMdl-List').jqGrid({
            url: KhuyenMaiMgrFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
            height: '1000',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mã', 'Tên', 'S/L', 'Thời hạn', 'C/k tiền', 'C/k %', 'Active', 'Thứ tự', 'Ngày cập nhật'],
            colModel: [
                { name: 'ID', key: true, width: 1, sortable: true, hidden: true },
                { name: 'Ma', width: 10, sortable: true },
                { name: 'Ten', width: 50, sortable: true },
                { name: 'SoLuong', width: 5, sortable: true },
                { name: 'TuNgay', width: 10, sortable: true },
                { name: 'TienChietKhau', width: 5, sortable: true },
                { name: 'ChietKhau', width: 5, sortable: true },
                { name: 'Active', width: 10, sortable: true, formatter: 'checkbox' },
                { name: 'ThuTu', width: 10, sortable: true },
                { name: 'NgayCapNhat', width: 10, resizable: true, sortable: true }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'NgayTao',
            sortorder: 'asc',
            rowNum: 10000,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#KhuyenMaiMgrMdl-List';

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
                KhuyenMaiMgrFn.loadHtml(function () {
                    var newDlg = $('#KhuyenMaiMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                KhuyenMaiMgrFn.save(false, function () {
                                    KhuyenMaiMgrFn.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                KhuyenMaiMgrFn.save(false, function () {
                                    KhuyenMaiMgrFn.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            KhuyenMaiMgrFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            KhuyenMaiMgrFn.clearform();
                            KhuyenMaiMgrFn.popfn();
                            $.ajax({
                                url: KhuyenMaiMgrFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);

                                    var newDlg = $('#KhuyenMaiMgrMdl-dlgNew');
                                    var ID = $('.ID', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var TuNgay = $('.TuNgay', newDlg);
                                    var DenNgay = $('.DenNgay', newDlg);
                                    var SoLuong = $('.SoLuong', newDlg);
                                    var ChietKhau = $('.ChietKhau', newDlg);
                                    var TienChietKhau = $('.TienChietKhau', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var admMsg = $('.admMsg', newDlg);



                                    ID.val(dt.ID);
                                    Ma.val(dt.Ma);
                                    Ten.val(dt.Ten);

                                    var value = new Date(dt.TuNgay);
                                    TuNgay.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());


                                    value = new Date(dt.DenNgay);
                                    DenNgay.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());

                                    if (dt.Active) {
                                        Active.attr('checked', 'checked');
                                    }
                                    else {
                                        Active.removeAttr('checked');
                                    }

                                    MoTa.val(dt.MoTa);
                                    NoiDung.val(dt.NoiDung);
                                    SoLuong.val(dt.SoLuong);
                                    ChietKhau.val(dt.ChietKhau);
                                    TienChietKhau.val(dt.TienChietKhau);
                                    ThuTu.val(dt.ThuTu);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function (fn) {
        KhuyenMaiMgrFn.loadHtml(function () {
            var newDlg = $('#KhuyenMaiMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        KhuyenMaiMgrFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            KhuyenMaiMgrFn.clearform();
                        }, '#KhuyenMaiMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        KhuyenMaiMgrFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            $(newDlg).dialog('close');
                        }, '#KhuyenMaiMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    KhuyenMaiMgrFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    KhuyenMaiMgrFn.clearform();
                    KhuyenMaiMgrFn.popfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#KhuyenMaiMgrMdl-List';
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
                        url: KhuyenMaiMgrFn.urlDefault().toString() + '&subAct=del',
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
        if (typeof (grid) == 'undefined') grid == '#KhuyenMaiMgrMdl-List';
        var newDlg = $('#KhuyenMaiMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var TuNgay = $('.TuNgay', newDlg);
        var DenNgay = $('.DenNgay', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var ChietKhau = $('.ChietKhau', newDlg);
        var TienChietKhau = $('.TienChietKhau', newDlg);
        var Active = $('.Active', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var admMsg = $('.admMsg', newDlg);


        //region bien
        var _ID = ID.val();
        var _Ten = Ten.val();
        var _MoTa = MoTa.val();
        var _Ma = Ma.val();
        var _NoiDung = NoiDung.val();
        var _TuNgay = TuNgay.val();
        var _DenNgay = DenNgay.val();
        var _SoLuong = SoLuong.val();
        var _ChietKhau = ChietKhau.val() ;
        var _TienChietKhau = adm.VndToInt(TienChietKhau);
        var _Active = Active.is(':checked');
        var _ThuTu = ThuTu.val();

        var err = '';
        if (_Ten == '') { err += 'Nhập tên<br/>'; };

        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: KhuyenMaiMgrFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                ID: _ID,
                Ten: _Ten,
                MoTa: _MoTa,
                Ma: _Ma,
                NoiDung: _NoiDung,
                TuNgay: _TuNgay,
                DenNgay: _DenNgay,
                SoLuong: _SoLuong,
                ChietKhau: _ChietKhau,
                TienChietKhau: _TienChietKhau,
                Active: _Active,
                ThuTu: _ThuTu
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn(_ID, _Ten);
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
        var LDMID = $('.mdl-head-filterloaidanhmuc');
        var _Lang = $('#danhMucMdl-changeLangSlt').val();
        var _LDMID = $(LDMID).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#KhuyenMaiMgrMdl-List').jqGrid('setGridParam', { url: KhuyenMaiMgrFn.urlDefault().toString() + '&subAct=get&LDMID=' + _LDMID + '&Lang=' + _Lang }).trigger('reloadGrid');
        }, 500);
    },
    popfn: function () {
        var newDlg = $('#KhuyenMaiMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var TuNgay = $('.TuNgay', newDlg);
        var DenNgay = $('.DenNgay', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var ChietKhau = $('.ChietKhau', newDlg);
        var TienChietKhau = $('.TienChietKhau', newDlg);
        var Active = $('.Active', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var admMsg = $('.admMsg', newDlg);

        adm.createTinyMce(NoiDung);

        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        TuNgay.val(dateStr);
        TuNgay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });

        DenNgay.val(dateStr);
        DenNgay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });

        ChietKhau.val('0');
        TienChietKhau.val('0');
        ThuTu.val('0');
        SoLuong.val('0');

        adm.regJPlugin(jQuery().formatCurrency, '../js/jquery.formatCurrency-1.4.0.min.js', function () {
            adm.formatTien(TienChietKhau);
        });        
    },
    clearform: function () {
        var newDlg = $('#KhuyenMaiMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var TuNgay = $('.TuNgay', newDlg);
        var DenNgay = $('.DenNgay', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var ChietKhau = $('.ChietKhau', newDlg);
        var TienChietKhau = $('.TienChietKhau', newDlg);
        var Active = $('.Active', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var admMsg = $('.admMsg', newDlg);

        admMsg.html('');
        newDlg.find('input, textarea').val('');
    },
    autoCompleteSearch: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'khuyenMaiMgr-autoCompleteSearch' + request.term;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: KhuyenMaiMgrFn.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'search', 'q': request.term },
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
                                        ma: item.Ma
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
				            .append("<a href=\"javascript:;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },

    loadHtml: function (fn) {
        var dlg = $('#KhuyenMaiMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.khuyenMaiMgr.htm.htm")%>',
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
