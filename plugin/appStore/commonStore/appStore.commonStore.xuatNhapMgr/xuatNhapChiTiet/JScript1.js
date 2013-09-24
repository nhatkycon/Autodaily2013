var xuatNhapChiTietFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.Class1, appStore.commonStore.xuatNhapMgr'; },
    urlDefault1: function () { return adm.urlDefault1 + '&act=loadPlug&rqPlug=appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.Class1, appStore.commonStore.xuatNhapMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        var KH_ID = $('.mdl-head-xuatNhapChiTiet-KH_ID');
        var DM_ID = $('.mdl-head-xuatNhapChiTiet-DM_ID');
        var KHO_ID = $('.mdl-head-xuatNhapChiTiet-KHO_ID');
        var TuNgay = $('.mdl-head-xuatNhapChiTiet-TuNgay');
        var DenNgay = $('.mdl-head-xuatNhapChiTiet-DenNgay');
        TuNgay.datepicker({
            dateFormat: 'dd/mm/yy',
            showButtonPanel: true,
            onSelect: function (date) {
                xuatNhapChiTietFn.search();
            }
        });
        DenNgay.datepicker({
            dateFormat: 'dd/mm/yy', showButtonPanel: true, onSelect: function (date) {
                xuatNhapChiTietFn.search();
            }
        });
        
        $('#xuatNhapChiTietMdl-List').jqGrid({
            url: xuatNhapChiTietFn.urlDefault().toString() + '&subAct=get',
            height: '600',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Loại', 'Mã', 'Hàng', 'K/h', 'Đơn giá', 'S/Lượng', 'C/Khấu', 'Vat', 'Tổng', 'Ngày', 'Nhân viên'],
            colModel: [
                        { name: 'XNCT_ID', key: true, sortable: true, hidden: true },
                        { name: 'XN_Xuat', width: 5, sortable: true },
                        { name: 'XN_Ma', width: 10, resizable: true, sortable: true },
                        { name: 'HH_Ten', width: 10, resizable: true, sortable: true },
                        { name: 'KH_Ten', width: 10, resizable: true, sortable: true },
                        { name: 'XNCT_DonGia', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XNCT_SoLuong', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XNCT_CKTien', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XNCT_VAT', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XNCT_Tong', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XN_NgayHoaDon', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XN_NhanVien', width: 10, resizable: true, sortable: true, align: 'right' }
                    ],
            caption: 'Xuất nhập chi tiết',
            autowidth: true,
            sortname: 'XN_NgayHoaDon',
            sortorder: 'asc',
            pager: jQuery('#xuatNhapChiTietMdl-Pager'),
            rowNum: 50,
            rowList: [50, 100, 500, 1000, 2000, 3000],
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                
                adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
                });
                adm.loading(null);
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteLangBased('', 'NHOM-HH', DM_ID, function (event, ui) {
                        DM_ID.attr('_value', ui.item.id);
                        xuatNhapChiTietFn.search();
                    });
                    DM_ID.unbind('click').click(function () {
                        DM_ID.autocomplete('search', '');
                    });
                });

                adm.regType(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
                    DanhSachKhachHangFn.autoCompleteSearch(KH_ID, function (event, ui) {
                        KH_ID.attr('_value', ui.item.id);
                        xuatNhapChiTietFn.search();
                    });
                    KH_ID.unbind('click').click(function () {
                        KH_ID.autocomplete('search', '');
                    });
                });
                
                adm.regType(typeof (KhoHangMgrFn), 'appStore.pmSpa.khoHangMgr.Class1, appStore.pmSpa.khoHangMgr', function () {
                    KhoHangMgrFn.autoComplete(KHO_ID, function (event, ui) {
                        KHO_ID.attr('_value', ui.item.id);
                        xuatNhapChiTietFn.search();
                    });
                    KHO_ID.unbind('click').click(function () {
                        KHO_ID.autocomplete('search', '');
                    });
                });
            }
        });
    },
    refresh: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#xuatNhapChiTietMdl-List';
        var KH_ID = $('.mdl-head-xuatNhapChiTiet-KH_ID');
        var DM_ID = $('.mdl-head-xuatNhapChiTiet-DM_ID');
        var KHO_ID = $('.mdl-head-xuatNhapChiTiet-KHO_ID');
        var TuNgay = $('.mdl-head-xuatNhapChiTiet-TuNgay');
        var DenNgay = $('.mdl-head-xuatNhapChiTiet-DenNgay');
        KH_ID.val('');
        DM_ID.val('');
        KHO_ID.val('');
        TuNgay.val('');
        DenNgay.val('');
        KH_ID.attr('_value','');
        DM_ID.attr('_value', '');
        KHO_ID.attr('_value', '');

        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: xuatNhapChiTietFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        }, 500);
    },
    search: function () {
        var KH_ID = $('.mdl-head-xuatNhapChiTiet-KH_ID');
        var DM_ID = $('.mdl-head-xuatNhapChiTiet-DM_ID');
        var KHO_ID = $('.mdl-head-xuatNhapChiTiet-KHO_ID');
        var TuNgay = $('.mdl-head-xuatNhapChiTiet-TuNgay');
        var DenNgay = $('.mdl-head-xuatNhapChiTiet-DenNgay');
        
        var _DM_ID = DM_ID.attr('_value');
        var _KH_ID = KH_ID.attr('_value');
        var _KHO_ID = KHO_ID.attr('_value');
        var _TuNgay = TuNgay.val();
        var _DenNgay = DenNgay.val();
        
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#xuatNhapChiTietMdl-List').jqGrid('setGridParam', { url: xuatNhapChiTietFn.urlDefault().toString() + '&subAct=get&DM_ID=' + _DM_ID + '&KHO_ID=' + _KHO_ID + '&KH_ID=' + _KH_ID + '&TuNgay=' + _TuNgay + '&DenNgay=' + _DenNgay }).trigger('reloadGrid');
        }, 500);
    },
    clearform: function () {
        var newDlg = $('#xuatNhapChiTietMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var NgayHoaDon = $('.NgayHoaDon', newDlg);
        var Ma = $('.Ma', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var NhanVien = $('.NhanVien', newDlg);
        var CongTienHang = $('.CongTienHang', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var TongVAT = $('.TongVAT', newDlg);
        var ChietKhau = $('.ChietKhau', newDlg);
        var ConNo = $('.ConNo', newDlg);
        var ThanhToan = $('.ThanhToan', newDlg);
        var PhaiTra = $('.PhaiTra', newDlg);
        var KHO_ID = $('.KHO_ID', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(spbMsg).html('');
        ID.val('');
        KH_ID.attr('_value', '');
        KHO_ID.attr('_value', '');
        var DanhSachXuatNhapChiTiet = $('.DanhSachXuatNhapChiTiet', newDlg);
        DanhSachXuatNhapChiTiet.find('.ds-item-value').remove();
        newDlg.find('input').val('');
    },
    createReportByGrid: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#xuatNhapChiTietMdl-List';

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
                xuatNhapChiTietFn.createReport(s);
            }
        }
    },
    createReport: function (id) {
        var request = document.location.href + xuatNhapChiTietFn.urlDefault().toString() + '&subAct=reports&ID=' + id;
        var win = window.open(request, 'popup', 'width=1024, height=700');
        win.focus();
    },
    autoCompleteByQ: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'hangHoa-autoCompleteByQ' + el.val();
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: xuatNhapChiTietFn.urlDefault().toString(),
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
        var dlg = $('#xuatNhapChiTietMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.htm.htm")%>',
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
