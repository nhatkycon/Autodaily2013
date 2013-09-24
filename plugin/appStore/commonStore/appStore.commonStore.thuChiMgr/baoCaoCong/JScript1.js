var baoCaoCongFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.commonStore.thuChiMgr.baoCaoCong.Class1, appStore.commonStore.thuChiMgr'; },
    urlDefault1: function () { return adm.urlDefault1 + '&act=loadPlug&rqPlug=appStore.commonStore.thuChiMgr.baoCaoCong.Class1, appStore.commonStore.thuChiMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        var TuNgay = $('.mdl-head-baoCaoCongMdl-TuNgay');
        var DenNgay = $('.mdl-head-baoCaoCongMdl-DenNgay');
        $('#baoCaoCongMdl-List').jqGrid({
            url: baoCaoCongFn.urlDefault().toString() + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['Mã', 'Khách hàng','Nợ'],
            colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true }
                        , { name: 'KH_Ten', width: 5, sortable: true }
                        , { name: 'KH_CongNo', width: 5, resizable: true, sortable: true, align: 'right' }
                    ],
            caption: 'Báo cáo khách hàng còn nợ tiền',
            autowidth: true,
            sortname: 'ma',
            sortorder: 'asc',
            rowNum: 10000,
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
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
        if (typeof (grid) == 'undefined') grid == '#baoCaoCongMdl-List';
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: baoCaoCongFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        }, 500);
    },
    search: function () {
        var DMID = $('.mdl-head-HangHoaFilterDanhMuc');
        var q = $('.mdl-head-search-hangHoaMgr');
        var TuNgay = $('.mdl-head-baoCaoCongMdl-TuNgay');
        var DenNgay = $('.mdl-head-baoCaoCongMdl-DenNgay');
        var _DMID = DMID.attr('_value');
        var _TuNgay = TuNgay.val();
        var _DenNgay = DenNgay.val();
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#baoCaoCongMdl-List').jqGrid('setGridParam', { url: baoCaoCongFn.urlDefault().toString() + '&subAct=get&NDTC_ID=' + _DMID + '&q=' + q.val() + '&DenNgay=' + _DenNgay + '&TuNgay=' + _TuNgay }).trigger('reloadGrid');
        }, 500);
    },
    createReportByGrid: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#baoCaoCongMdl-List';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selarrrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            var request = baoCaoCongFn.urlDefault1().toString() + '&subAct=reports&ID=' + s;
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
        var request = baoCaoCongFn.urlDefault1().toString() + '&subAct=reports&ID=' + id;
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
        var dlg = $('#baoCaoCongMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.commonStore.thuChiMgr.baoCaoCong.htm.htm")%>',
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
