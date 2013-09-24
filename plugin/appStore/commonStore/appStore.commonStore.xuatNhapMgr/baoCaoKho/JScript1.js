var baoCaoKhoFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.commonStore.xuatNhapMgr.baoCaoKho.Class1, appStore.commonStore.xuatNhapMgr'; },
    urlDefault1: function () { return adm.urlDefault1 + '&act=loadPlug&rqPlug=appStore.commonStore.xuatNhapMgr.baoCaoKho.Class1, appStore.commonStore.xuatNhapMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        var DM_ID = $('.mdl-head-baoCaoKhoMdl-danhMuc');
        var KHO_ID = $('.mdl-head-baoCaoKhoMdl-kho');
        var TuNgay = $('.mdl-head-baoCaoKhoMdl-TuNgay');
        var DenNgay = $('.mdl-head-baoCaoKhoMdl-DenNgay');
        $('#baoCaoKhoMdl-List').jqGrid({
            url: baoCaoKhoFn.urlDefault().toString() + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mã', 'Tên', 'Đơn vị', 'Đơn giá', 'Lượng', 'Tiền', 'Lượng', 'Tiền', 'Lượng', 'Tiền', 'Lượng', 'Tiền'],
            colModel: [
                        { name: 'HH_ID', key: true, hidden: true },
                        { name: 'HH_Ma', width: 5 },
                        { name: 'HH_Ten', width: 20, resizable: true },
                        { name: 'HH_DonVi', width: 3, resizable: true },
                        { name: 'HH_GiaNhap', width: 10, resizable: true, align: 'right' },
                        { name: 'DauKy_SoLuong', width: 10, resizable: true, align: 'right' },
                        { name: 'DauKy_Tien', width: 10, resizable: true, align: 'right' },
                        { name: 'Nhap_SoLuong', width: 10, resizable: true, align: 'right' },
                        { name: 'Nhap_Tien', width: 10, resizable: true, align: 'right' },
                        { name: 'Xuat_SoLuong', width: 10, resizable: true, align: 'right' },
                        { name: 'Xuat_Tien', width: 10, resizable: true, align: 'right' },
                        { name: 'CuoiKy_SoLuong', width: 10, resizable: true, align: 'right' },
                         { name: 'CuoiKy_Tien', width: 10, resizable: true, align: 'right' }
                    ],
            caption: 'Báo cáo xuất nhập',
            autowidth: true,
            sortname: 'HH_ID',
            sortorder: 'asc',
            rowNum: 10000,
            multiselect: true,
            multiboxonly: true,
            footerrow : true,
            userDataOnFooter : true,
            altRows : true,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                
                
                adm.loading(null);
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteLangBased('', 'NHOM-HH', DM_ID, function (event, ui) {
                        DM_ID.attr('_value', ui.item.id);
                        baoCaoKhoFn.search();
                    });
                });

                TuNgay.datepicker({
                    dateFormat: 'dd/mm/yy',
                    showButtonPanel: true,
                    onSelect: function (date) {
                        baoCaoKhoFn.search();
                    }
                });
                DenNgay.datepicker({
                    dateFormat: 'dd/mm/yy', showButtonPanel: true, onSelect: function (date) {
                        baoCaoKhoFn.search();
                    }
                });
                
                adm.regType(typeof (KhoHangMgrFn), 'appStore.pmSpa.khoHangMgr.Class1, appStore.pmSpa.khoHangMgr', function () {
                    KhoHangMgrFn.autoComplete(KHO_ID, function (event, ui) {
                        KHO_ID.attr('_value', ui.item.id);
                        baoCaoKhoFn.search();
                    });
                });
                
                $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); });
                $(KHO_ID).unbind('click').click(function () { $(KHO_ID).autocomplete('search', ''); });
            }
        });
        jQuery("#baoCaoKhoMdl-List").jqGrid('setGroupHeaders', {
            useColSpanStyle: false,
            groupHeaders: [
              { startColumnName: 'DauKy_SoLuong', numberOfColumns: 2, titleText: 'Tồn đầu kỳ' }
              , { startColumnName: 'Nhap_SoLuong', numberOfColumns: 2, titleText: 'Nhập trong kỳ' }
              , { startColumnName: 'Xuat_SoLuong', numberOfColumns: 2, titleText: 'Xuất trong kỳ' }
                , { startColumnName: 'CuoiKy_SoLuong', numberOfColumns: 2, titleText: 'Tồn cuối kỳ' }
            ]
        });

    },
    refresh: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#baoCaoKhoMdl-List';
        var DM_ID = $('.mdl-head-baoCaoKhoMdl-danhMuc');
        var KHO_ID = $('.mdl-head-baoCaoKhoMdl-kho');
        var TuNgay = $('.mdl-head-baoCaoKhoMdl-TuNgay');
        var DenNgay = $('.mdl-head-baoCaoKhoMdl-DenNgay');
        DM_ID.val('');
        DM_ID.attr('_value', '');
        KHO_ID.val('');
        KHO_ID.attr('_value', '');
        TuNgay.val('');
        DenNgay.val('');
        $(grid).jqGrid('setGridParam', { url: baoCaoKhoFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
    },
    search: function () {
        var DM_ID = $('.mdl-head-baoCaoKhoMdl-danhMuc');
        var KHO_ID = $('.mdl-head-baoCaoKhoMdl-kho');
        var TuNgay = $('.mdl-head-baoCaoKhoMdl-TuNgay');
        var DenNgay = $('.mdl-head-baoCaoKhoMdl-DenNgay');
        
        var _DM_ID = DM_ID.attr('_value');
        var _KHO_ID = KHO_ID.attr('_value');
        var _TuNgay = TuNgay.val();
        var _DenNgay = DenNgay.val();
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#baoCaoKhoMdl-List').jqGrid('setGridParam', { url: baoCaoKhoFn.urlDefault().toString() + '&subAct=get&DM_ID=' + _DM_ID + '&KHO_ID=' + _KHO_ID + '&TuNgay=' + _TuNgay + '&DenNgay=' + _DenNgay }).trigger('reloadGrid');
        }, 500);
    },
    createReportByGrid: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#baoCaoKhoMdl-List';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selarrrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            var request = baoCaoKhoFn.urlDefault1().toString() + '&subAct=reports&ID=' + s;
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
        var request = baoCaoKhoFn.urlDefault1().toString() + '&subAct=reports&ID=' + id;
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
        var dlg = $('#baoCaoKhoMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.commonStore.xuatNhapMgr.baoCaoKho.htm.htm")%>',
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
