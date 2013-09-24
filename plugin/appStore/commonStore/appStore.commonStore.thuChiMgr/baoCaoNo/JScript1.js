var baoCaoNoFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.commonStore.thuChiMgr.baoCaoNo.Class1, appStore.commonStore.thuChiMgr'; },
    urlDefault1: function () { return adm.urlDefault1 + '&act=loadPlug&rqPlug=appStore.commonStore.thuChiMgr.baoCaoNo.Class1, appStore.commonStore.thuChiMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        baoCaoNoFn.loadSubGrid();
        $('#baoCaoNoMdl-List').jqGrid({
            url: baoCaoNoFn.urlDefault().toString() + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['Mã', 'K/h-Ncc','Công nợ đầu kỳ','Nhập','Xuất','Thu','Chi','Dịch vụ','Nợ'],
            colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true }
                        , { name: 'KH_Ten', width: 5, sortable: true }
                        , { name: 'KH_CongNoDauKy', width: 5, resizable: true, sortable: true, align: 'right' }
                        , { name: 'KH_TongNhap', width: 5, resizable: true, sortable: true, align: 'right' }
                        , { name: 'KH_TongXuat', width: 5, resizable: true, sortable: true, align: 'right' }
                        , { name: 'KH_TongThu', width: 5, resizable: true, sortable: true, align: 'right' }
                        , { name: 'KH_TongChi', width: 5, resizable: true, sortable: true, align: 'right' }
                        , { name: 'KH_TongDichVu', width: 5, resizable: true, sortable: true, align: 'right' }
                        , { name: 'KH_CongNo', width: 5, resizable: true, sortable: true, align: 'right' }
                    ],
            caption: 'Báo cáo nợ',
            autowidth: true,
            sortname: 'KH_Ten',
            sortorder: 'asc',
            rowNum: 10000,
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) {
                var treedata = $("#baoCaoNoMdl-List").jqGrid('getRowData', rowid);
                baoCaoNoFn.changeSubGrid(treedata.ID);
            },
            loadComplete: function () {
            }
        });
        jQuery("#baoCaoNoMdl-List").jqGrid('setGroupHeaders', {
            useColSpanStyle: false,
            groupHeaders: [
              { startColumnName: 'KH_TongNhap', numberOfColumns: 2, titleText: 'Xuất Nhập' }
              , { startColumnName: 'KH_TongThu', numberOfColumns: 2, titleText: 'Thu Chi' }
            ]
        });
    },
    loadSubGrid: function () {
        $('.baoCaoNoMdl-subMdl').tabs({
            show: function (event, ui) {
                if (ui.index == '0') {
                    $('#baoCaoNoMdl-subMdl-mdl1-List').jqGrid({
                        url: baoCaoNoFn.urlDefault().toString() + '&subAct=getSubXuat',
                        height: '400',
                        datatype: 'json',
                        loadui: 'disable',
                        colNames: ['ID', 'Mục', 'Mã', 'K/h', 'Ngày Hđ', 'Cộng', 'VAT', 'CK', 'Tổng', 'Thanh toán', 'Nợ', 'Cập nhật'],
                        colModel: [
                                    { name: 'XN_ID', key: true, sortable: true, hidden: true },
                                    { name: 'XN_LOAI_ID', width: 5, sortable: true },
                                    { name: 'XN_Ma', width: 10, resizable: true, sortable: true },
                                    { name: 'XN_KH_ID', width: 10, resizable: true, sortable: true },
                                    { name: 'XN_NgayHoaDon', width: 10, resizable: true, sortable: true },
                                    { name: 'XN_CongTienHang', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_VAT', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_ChietKhau', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_CongTienHang', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_ThanhToan', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_ConNo', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_NgayCapNhat', width: 10, resizable: true, align: 'right' }
                        ],
                        caption: 'Xuất',
                        autowidth: true,
                        sortname: 'XN_NgayHoaDon',
                        sortorder: 'asc',
                        pager: jQuery('#baoCaoNoMdl-subMdl-mdl1-Page'),
                        rowNum: 10,
                        rowList: [10, 20, 50, 100, 200, 300],
                        multiselect: true,
                        multiboxonly: true,
                        onSelectRow: function (rowid) { },
                        loadComplete: function () {
                        }
                    });
                }
                else if (ui.index == '1') {
                    $('#baoCaoNoMdl-subMdl-mdl2-list').jqGrid({
                        url: baoCaoNoFn.urlDefault().toString() + '&subAct=getSubNhap',
                        height: '400',
                        datatype: 'json',
                        loadui: 'disable',
                        colNames: ['ID', 'Mục', 'Mã', 'Ncc', 'Ngày Hđ', 'Cộng', 'VAT', 'CK', 'Tổng', 'Thanh toán', 'Nợ', 'Cập nhật'],
                        colModel: [
                                    { name: 'XN_ID', key: true, sortable: true, hidden: true },
                                    { name: 'XN_LOAI_ID', width: 5, sortable: true },
                                    { name: 'XN_Ma', width: 10, resizable: true, sortable: true },
                                    { name: 'XN_KH_ID', width: 10, resizable: true, sortable: true },
                                    { name: 'XN_NgayHoaDon', width: 10, resizable: true, sortable: true },
                                    { name: 'XN_CongTienHang', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_VAT', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_ChietKhau', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_CongTienHang', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_ThanhToan', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_ConNo', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'XN_NgayCapNhat', width: 10, resizable: true, align: 'right' }
                        ],
                        caption: 'Nhập',
                        autowidth: true,
                        sortname: 'XN_NgayHoaDon',
                        sortorder: 'asc',
                        pager: jQuery('#baoCaoNoMdl-subMdl-mdl2-Page'),
                        rowNum: 10,
                        rowList: [10, 20, 50, 100, 200, 300],
                        multiselect: true,
                        multiboxonly: true,
                        onSelectRow: function (rowid) { },
                        loadComplete: function () {
                        }
                    });
                }
                else if (ui.index == '2') {
                    $('#baoCaoNoMdl-subMdl-mdl3-list').jqGrid({
                        url: baoCaoNoFn.urlDefault().toString() + '&subAct=getSubThu',
                        height: '400',
                        datatype: 'json',
                        loadui: 'disable',
                        colNames: ['ID', 'Nội dung', 'Số phiếu', 'Người nộp', 'Mô tả', 'Ngày nộp', 'Số tiền', 'Người tạo', 'Người tạo mã', 'XN_ID', 'DV_ID'],
                        colModel: [
                                    { name: 'TC_ID', key: true, sortable: true, hidden: true },
                                    { name: 'TC_NDTC_ID', width: 5, sortable: true },
                                    { name: 'TC_SoPhieu', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'TC_P_ID', width: 10, resizable: true, sortable: true },
                                    { name: 'TC_MoTa', width: 10, resizable: true, sortable: true },
                                    { name: 'TC_NgayTao', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'TC_SoTien', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'TC_NguoiTao_Ten', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'TC_NguoiTao', width: 10, resizable: true, sortable: true, align: 'right', hidden: true, formatter: 'checkbox' },
                                    { name: 'TC_XN_ID', width: 10, resizable: true, sortable: true, align: 'right', hidden: true, formatter: 'checkbox' },
                                    { name: 'TC_DV_ID', width: 10, resizable: true, sortable: true, align: 'right', hidden: true, formatter: 'checkbox' }
                        ],
                        caption: 'Thu',
                        autowidth: true,
                        sortname: 'TC_NgayTao',
                        sortorder: 'asc',
                        pager: jQuery('#baoCaoNoMdl-subMdl-mdl3-Page'),
                        rowNum: 10,
                        rowList: [10, 20, 50, 100, 200, 300],
                        multiselect: true,
                        multiboxonly: true,
                        onSelectRow: function (rowid) { },
                        loadComplete: function () {
                        }
                    });
                }
                else if (ui.index == '3') {
                    $('#baoCaoNoMdl-subMdl-mdl4-list').jqGrid({
                        url: baoCaoNoFn.urlDefault().toString() + '&subAct=getSubChi',
                        height: '400',
                        datatype: 'json',
                        loadui: 'disable',
                        colNames: ['ID', 'Nội dung', 'Số phiếu', 'Người nhận', 'Mô tả', 'Ngày nộp', 'Số tiền', 'Người tạo', 'Người tạo mã', 'XN_ID', 'DV_ID'],
                        colModel: [
                                    { name: 'TC_ID', key: true, sortable: true, hidden: true },
                                    { name: 'TC_NDTC_ID', width: 5, sortable: true },
                                    { name: 'TC_SoPhieu', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'TC_P_ID', width: 10, resizable: true, sortable: true },
                                    { name: 'TC_MoTa', width: 10, resizable: true, sortable: true },
                                    { name: 'TC_NgayTao', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'TC_SoTien', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'TC_NguoiTao_Ten', width: 10, resizable: true, sortable: true, align: 'right' },
                                    { name: 'TC_NguoiTao', width: 10, resizable: true, sortable: true, align: 'right', hidden: true, formatter: 'checkbox' },
                                    { name: 'TC_XN_ID', width: 10, resizable: true, sortable: true, align: 'right', hidden: true, formatter: 'checkbox' },
                                    { name: 'TC_DV_ID', width: 10, resizable: true, sortable: true, align: 'right', hidden: true, formatter: 'checkbox' }
                        ],
                        caption: 'Chi',
                        autowidth: true,
                        sortname: 'TC_NgayTao',
                        sortorder: 'asc',
                        pager: jQuery('#baoCaoNoMdl-subMdl-mdl4-Page'),
                        rowNum: 10,
                        rowList: [10, 20, 50, 100, 200, 300],
                        multiselect: true,
                        multiboxonly: true,
                        onSelectRow: function (rowid) { },
                        loadComplete: function () {
                        }
                    });
                }
            }
        });
    },
    changeSubGrid: function (_id) {
        $('#baoCaoNoMdl-subMdl-mdl1-List').jqGrid('setGridParam', { url: baoCaoNoFn.urlDefault().toString() + '&subAct=getSubXuat&ID=' + _id }).trigger('reloadGrid');
        $('#baoCaoNoMdl-subMdl-mdl2-list').jqGrid('setGridParam', { url: baoCaoNoFn.urlDefault().toString() + '&subAct=getSubNhap&ID=' + _id }).trigger('reloadGrid');
        $('#baoCaoNoMdl-subMdl-mdl3-list').jqGrid('setGridParam', { url: baoCaoNoFn.urlDefault().toString() + '&subAct=getSubThu&ID=' + _id }).trigger('reloadGrid');
        $('#baoCaoNoMdl-subMdl-mdl4-list').jqGrid('setGridParam', { url: baoCaoNoFn.urlDefault().toString() + '&subAct=getSubChi&ID=' + _id }).trigger('reloadGrid');
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
            danhmuc.autoCompleteLangBased('', 'NDTC-CHI', NDTC_ID, function (event, ui) {
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
        if (typeof (grid) == 'undefined') grid == '#baoCaoNoMdl-List';
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: baoCaoNoFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        }, 500);
    },
    search: function () {
        var DMID = $('.mdl-head-HangHoaFilterDanhMuc');
        var q = $('.mdl-head-search-hangHoaMgr');
        var TuNgay = $('.mdl-head-baoCaoNoMdl-TuNgay');
        var DenNgay = $('.mdl-head-baoCaoNoMdl-DenNgay');
        var _DMID = DMID.attr('_value');
        var _TuNgay = TuNgay.val();
        var _DenNgay = DenNgay.val();
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#baoCaoNoMdl-List').jqGrid('setGridParam', { url: baoCaoNoFn.urlDefault().toString() + '&subAct=get&NDTC_ID=' + _DMID + '&q=' + q.val() + '&DenNgay=' + _DenNgay + '&TuNgay=' + _TuNgay }).trigger('reloadGrid');
        }, 500);
    },
    createReportByGrid: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#baoCaoNoMdl-List';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selarrrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            var request = baoCaoNoFn.urlDefault1().toString() + '&subAct=reports&ID=' + s;
            request = request.replace('loadPlug', 'loadPlugDirect');
            adm.loadIfr(request
            , function () {
                adm.loading('Đang tạo báo cáo');
            }
            , function () {
                adm.loading(null);
            });
        }

       
    },
    createReport: function (id) {
        var request = baoCaoNoFn.urlDefault1().toString() + '&subAct=reports&ID=' + id;
        request = request.replace('loadPlug', 'loadPlugDirect');
        adm.loadIfr(request
        , function () {
            adm.loading('Đang tạo báo cáo');
        }
        , function () {
            adm.loading(null);
        });
    },
    loadHtml: function (fn) {
        var dlg = $('#baoCaoNoMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.commonStore.thuChiMgr.baoCaoNo.htm.htm")%>',
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
