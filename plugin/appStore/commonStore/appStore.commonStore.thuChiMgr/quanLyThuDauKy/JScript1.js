var quanLyThuDauKyDauKyFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.commonStore.thuChiMgr.quanLyThuDauKy.Class1, appStore.commonStore.thuChiMgr'; },
    urlDefault1: function () { return adm.urlDefault1 + '&act=loadPlug&rqPlug=appStore.commonStore.thuChiMgr.quanLyThuDauKy.Class1, appStore.commonStore.thuChiMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        var DMID = $('.mdl-head-HangHoaFilterDanhMuc');
        var TuNgay = $('.mdl-head-quanLyThuDauKyDauKyMdl-TuNgay');
        var DenNgay = $('.mdl-head-quanLyThuDauKyDauKyMdl-DenNgay');
        var q = $('.mdl-head-search-hangHoaMgr');
        $('#quanLyThuDauKyDauKyMdl-List').jqGrid({
            url: quanLyThuDauKyDauKyFn.urlDefault().toString() + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Nội dung', 'Số phiếu', 'Người nộp', 'Mô tả', 'Ngày nộp', 'Số tiền', 'Người tạo', 'Người tạo mã','XN_ID','DV_ID'],
            colModel: [
                        { name: 'TC_ID', key: true, sortable: true, hidden: true },
                        { name: 'TC_NDTC_ID', width: 5, sortable: true },
                        { name: 'TC_SoPhieu', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'TC_P_ID', width: 10, resizable: true, sortable: true, hidden: true },
                        { name: 'TC_MoTa', width: 10, resizable: true, sortable: true },
                        { name: 'TC_NgayTao', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'TC_SoTien', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'TC_NguoiTao_Ten', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'TC_NguoiTao', width: 10, resizable: true, sortable: true, align: 'right', hidden: true, formatter: 'checkbox' },
                        { name: 'TC_XN_ID', width: 10, resizable: true, sortable: true, align: 'right', hidden: true, formatter: 'checkbox' },
                        { name: 'TC_DV_ID', width: 10, resizable: true, sortable: true, align: 'right', hidden: true, formatter: 'checkbox' }
                    ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'TC_NgayTao',
            sortorder: 'asc',
            pager: jQuery('#quanLyThuDauKyDauKyMdl-Pager'),
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                adm.regJPlugin(jQuery().formatCurrency, '../js/jquery.formatCurrency-1.4.0.min.js', function () {
                });

                adm.regJPlugin(jQuery().tmpl, '../js/jquery.tmpl.min.js', function () {
                });

                adm.loading(null);
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteLangBased('', 'NDTC-THU', DMID, function (event, ui) {
                        DMID.attr('_value', ui.item.id);
                        quanLyThuDauKyDauKyFn.search();
                    });
                    DMID.unbind('click').click(function () {
                        DMID.autocomplete('search', '');
                    });
                });
                TuNgay.datepicker({
                    dateFormat: 'dd/mm/yy',
                    showButtonPanel: true,
                    onSelect: function (date) {
                        quanLyThuDauKyDauKyFn.search();
                    }
                });
                DenNgay.datepicker({
                    dateFormat: 'dd/mm/yy', showButtonPanel: true, onSelect: function (date) {
                        quanLyThuDauKyDauKyFn.search();
                    }
                });
            }
        });
    },
    popfn: function (newDlg) {
        var ID = $('.ID', newDlg);
        var NDTC_ID = $('.NDTC_ID', newDlg);
        var SoPhieu = $('.SoPhieu', newDlg);
        var SoTien = $('.SoTien', newDlg);
        var Mota = $('.Mota', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var NgayTao = $('.NgayTao', newDlg);
        var LoaiQuy = $('.LoaiQuy', newDlg);
        var P_ID = $('.P_ID', newDlg);
        
        var btnThemNhanhKH = $('.btnThemNhanhKH', newDlg);

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'NDTC-THU', NDTC_ID, function (event, ui) {
                NDTC_ID.attr('_value', ui.item.id);
            });
            NDTC_ID.unbind('click').click(function () {
                NDTC_ID.autocomplete('search', '');
            });
        });

        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(NguoiTao, function (event, ui) {
                NguoiTao.val(ui.item.label);
                NguoiTao.attr('_value', ui.item.value);
            });
        });

        adm.regType(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
            DanhSachKhachHangFn.autoCompleteSearch(P_ID, function (event, ui) {
                P_ID.attr('_value', ui.item.id);
            });
            btnThemNhanhKH.unbind('click').click(function () {
                DanhSachKhachHangFn.add(function (_ID, _Ten) {
                    P_ID.attr('_value', _ID);
                    P_ID.val(_Ten);
                });
            });
        });

        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        NgayTao.val(dateStr);
        NgayTao.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        adm.formatTien(SoTien);
    },
    refresh: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#quanLyThuDauKyDauKyMdl-List';
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: quanLyThuDauKyDauKyFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        }, 500);
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#quanLyThuDauKyDauKyMdl-List';

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
                var treedata = $(grid).jqGrid('getRowData', s);
                var owner = treedata.TC_NguoiTao;
                var TC_XN_ID = treedata.TC_XN_ID;
                var TC_DV_ID = treedata.TC_DV_ID;
                if (owner == 'No') {
                    alert('Bạn không đủ quyền sửa phiếu này');
                    return false;
                }
                if (TC_XN_ID == 'Yes' || TC_DV_ID == 'Yes') {
                    alert('Phiếu này liên quan đến hóa đơn xuất nhập, phiếu dịch vụ. Bạn không sửa được!');
                    return false;
                }
                quanLyThuDauKyDauKyFn.loadHtml(function () {
                    var newDlg = $('#quanLyThuDauKyDauKyMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 700,
                        buttons: {
                            'Lưu': function () {
                                quanLyThuDauKyDauKyFn.save(false, function () {
                                    quanLyThuDauKyDauKyFn.clearform();
                                    quanLyThuDauKyDauKyFn.draff(function (dt) {
                                        newDlg.find('.ID').val(dt);
                                        newDlg.find('.ID').attr('draff', '1');
                                    });
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                quanLyThuDauKyDauKyFn.save(false, function () {
                                    quanLyThuDauKyDauKyFn.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'In': function () {
                                quanLyThuDauKyDauKyFn.createReport(s);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            quanLyThuDauKyDauKyFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            quanLyThuDauKyDauKyFn.clearform();
                            quanLyThuDauKyDauKyFn.popfn(newDlg);
                            $.ajax({
                                url: quanLyThuDauKyDauKyFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    ID.attr('draff', '0');
                                    var ID = $('.ID', newDlg);
                                    var NDTC_ID = $('.NDTC_ID', newDlg);
                                    var SoPhieu = $('.SoPhieu', newDlg);
                                    var SoTien = $('.SoTien', newDlg);
                                    var Mota = $('.Mota', newDlg);
                                    var NguoiTao = $('.NguoiTao', newDlg);
                                    var NgayTao = $('.NgayTao', newDlg);
                                    var LoaiQuy = $('.LoaiQuy', newDlg);
                                    var P_ID = $('.P_ID', newDlg);
                                    
                                    ID.val(dt.ID);
                                    var value = new Date(dt.NgayTao);
                                    NgayTao.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());
                                    SoPhieu.val(dt.SoPhieu);
                                    SoTien.val(dt.SoTien);
                                    Mota.val(dt.Mota);
                                    NguoiTao.val(dt.NguoiTao);
                                    NguoiTao.attr('_value', dt.NguoiTao_Ten);
                                    LoaiQuy.val(dt.LoaiQuy);
                                    
                                    NDTC_ID.val(dt.NDTC_Ten);
                                    NDTC_ID.attr('_value', dt.NDTC_ID);
                                    
                                    P_ID.val(dt.P_Ten);
                                    P_ID.attr('_value', dt.P_ID);
                                    adm.formatTien(SoTien);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function (_newDlg, fn) {
        quanLyThuDauKyDauKyFn.loadHtml(function () {
            var newDlg = $('#quanLyThuDauKyDauKyMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 700,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        quanLyThuDauKyDauKyFn.save(false, function (_ID) {
                            if (typeof (fn) == 'function') {
                                fn(_ID);
                            }
                            quanLyThuDauKyDauKyFn.clearform();
                            quanLyThuDauKyDauKyFn.draff(function (_dt) {
                                var dt = eval(_dt);
                                var ID = newDlg.find('.ID');
                                var SoPhieu = newDlg.find('.SoPhieu');
                                ID.val(dt.ID);
                                SoPhieu.val(dt.SoPhieu);
                                ID.attr('draff', '1');
                            });
                        }, '#quanLyThuDauKyDauKyMdl-List');
                    },
                    'Lưu và đóng': function () {
                        quanLyThuDauKyDauKyFn.save(false, function (_ID) {
                            if (typeof (fn) == 'function') {
                                fn(_ID);
                            }
                            $(newDlg).dialog('close');
                        }, '#quanLyThuDauKyDauKyMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    quanLyThuDauKyDauKyFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    quanLyThuDauKyDauKyFn.clearform();
                    quanLyThuDauKyDauKyFn.popfn(newDlg);
                    quanLyThuDauKyDauKyFn.draff(function (_dt) {
                        var dt = eval(_dt);
                        var ID = newDlg.find('.ID');
                        var SoPhieu = newDlg.find('.SoPhieu');
                        ID.val(dt.ID);
                        SoPhieu.val(dt.SoPhieu);
                        ID.attr('draff', '1');
                    });
                }
            });
        });
    },
    loc: function () {
        quanLyThuDauKyDauKyFn.loadHtml(function () {
            var newDlg = $('#quanLyThuDauKyDauKyMdl-dlgFilter');
            $(newDlg).dialog({
                title: 'Lọc',
                width: 600,
                modal: true,
                buttons: {
                    'Tìm': function () {
                        var DM_ID = $('.DM_ID', newDlg);
                        var KH_ID = $('.KH_ID', newDlg);
                        var TuNgay = $('.TuNgay', newDlg);
                        var DenNgay = $('.DenNgay', newDlg);
                        var _DM_ID = DM_ID.attr('_value');
                        var _KH_ID = KH_ID.attr('_value');
                        var _TuNgay = TuNgay.val();
                        var _DenNgay = DenNgay.val();
                        $('#quanLyThuDauKyDauKyMdl-List').jqGrid('setGridParam', { url: quanLyThuDauKyDauKyFn.urlDefault().toString() + '&subAct=get&DM_ID=' + _DM_ID + '&KH_ID=' + _KH_ID + '&TuNgay=' + _TuNgay + '&DenNgay=' + _DenNgay }).trigger('reloadGrid');

                    },
                    'Nhập lại': function () {
                        quanLyThuDauKyDauKyFn.locClearform();
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    quanLyThuDauKyDauKyFn.locClearform();
                },
                open: function () {
                    adm.styleButton();
                    quanLyThuDauKyDauKyFn.locClearform();
                    quanLyThuDauKyDauKyFn.locPopfn(newDlg);
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#quanLyThuDauKyDauKyMdl-List';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selarrrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa?')) {// Xác nhận xem có xóa hay không
                $.ajax({
                    url: quanLyThuDauKyDauKyFn.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(grid).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    save: function (validate, fn, grid) {
        if (typeof (grid) == 'undefined') grid == '#quanLyThuDauKyDauKyMdl-List';
        var newDlg = $('#quanLyThuDauKyDauKyMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var NDTC_ID = $('.NDTC_ID', newDlg);
        var SoPhieu = $('.SoPhieu', newDlg);
        var SoTien = $('.SoTien', newDlg);
        var Mota = $('.MoTa', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var NgayTao = $('.NgayTao', newDlg);
        var LoaiQuy = $('.LoaiQuy', newDlg);
        var P_ID = $('.P_ID', newDlg);
        var spbMsg = $('.spbMsg', newDlg);
        var _draff = ID.attr('draff');

        var _ID = ID.val();
        var _SoPhieu = SoPhieu.val();
        var _SoTien = adm.VndToInt(SoTien);
        var _NDTC_ID = NDTC_ID.attr('_value');
        var _Mota = Mota.val();
        var _NguoiTao = NguoiTao.attr('_value');

        var _NgayTao = NgayTao.val();
        var _LoaiQuy = LoaiQuy.val();
        var _P_ID = P_ID.attr('_value');

        var err = '';
        //if (_P_ID == '') { err += 'Chọn người nộp<br/>'; };
        if (_NDTC_ID == '') { err += 'Chọn nội dung<br/>'; };
        if (_SoPhieu == '') { err += 'Nhập phiếu<br/>'; };
        if (_NguoiTao == '') { err += 'Chọn nhân viên<br/>'; };
        if (_SoTien == '') { err += 'Nhập tiền<br/>'; };
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }

        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: quanLyThuDauKyDauKyFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                draff: _draff,
                ID: _ID,
                SoPhieu: _SoPhieu,
                SoTien: _SoTien,
                NDTC_ID: _NDTC_ID,
                Mota: _Mota,
                NguoiTao: _NguoiTao,
                NgayTao: _NgayTao,
                LoaiQuy: _LoaiQuy,
                P_ID: _P_ID
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn(_ID);
                    }
                    $(grid).trigger('reloadGrid');
                } else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    search: function () {
        var DMID = $('.mdl-head-HangHoaFilterDanhMuc');
        var q = $('.mdl-head-search-hangHoaMgr');
        var TuNgay = $('.mdl-head-quanLyThuDauKyDauKyMdl-TuNgay');
        var DenNgay = $('.mdl-head-quanLyThuDauKyDauKyMdl-DenNgay');
        var _DMID = DMID.attr('_value');
        var _TuNgay = TuNgay.val();
        var _DenNgay = DenNgay.val();
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#quanLyThuDauKyDauKyMdl-List').jqGrid('setGridParam', { url: quanLyThuDauKyDauKyFn.urlDefault().toString() + '&subAct=get&NDTC_ID=' + _DMID + '&q=' + q.val() + '&DenNgay=' + _DenNgay + '&TuNgay=' + _TuNgay }).trigger('reloadGrid');
        }, 500);
    },
    draff: function (fn) {
        $.ajax({
            url: quanLyThuDauKyDauKyFn.urlDefault().toString(),
            type: 'POST',
            data: {
                'subAct': 'draff'
            },
            success: function (dt) {
                fn(dt);
            }
        });
    },
    clearform: function () {
        var newDlg = $('#quanLyThuDauKyDauKyMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var NDTC_ID = $('.NDTC_ID', newDlg);
        var SoPhieu = $('.SoPhieu', newDlg);
        var SoTien = $('.SoTien', newDlg);
        var Mota = $('.Mota', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var LoaiQuy = $('.LoaiQuy', newDlg);
        var P_ID = $('.P_ID', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(spbMsg).html('');
        NDTC_ID.attr('_value', '');
        P_ID.attr('_value', '');
        NguoiTao.attr('_value', '');
        newDlg.find('input').val('');
    },
    createReportByGrid: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#quanLyThuDauKyDauKyMdl-List';

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
                quanLyThuDauKyDauKyFn.createReport(s);
            }
        }
    },
    createReport: function (id) {
        var request = document.location.href + quanLyThuDauKyDauKyFn.urlDefault().toString() + '&subAct=reports&ID=' + id;
        var win = window.open(request, 'popup', 'width=700, height=700');
        win.focus();
    },
    autoCompleteByQ: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'hangHoa-autoCompleteByQ' + el.val();
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: quanLyThuDauKyDauKyFn.urlDefault().toString(),
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
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        gia: item.GNY
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
        var dlg = $('#quanLyThuDauKyDauKyMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.commonStore.thuChiMgr.quanLyThuDauKy.htm.htm")%>',
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
