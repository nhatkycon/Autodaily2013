var lamDichVuFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.Class1, appStore.pmSpa.thongKeNhanVienMgr'; },
    urlDefault1: function () { return adm.urlDefault1 + '&act=loadPlug&rqPlug=appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.Class1, appStore.pmSpa.thongKeNhanVienMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        var NhanVien = $('.mdl-head-lamDichVuMdl-NhanVien');
        var TuNgay = $('.mdl-head-lamDichVuMdl-TuNgay');
        var DenNgay = $('.mdl-head-lamDichVuMdl-DenNgay');
        TuNgay.datepicker({
            dateFormat: 'dd/mm/yy',
            showButtonPanel: true,
            onSelect: function (date) {
                lamDichVuFn.search();
            }
        });
        DenNgay.datepicker({
            dateFormat: 'dd/mm/yy', showButtonPanel: true, onSelect: function (date) {
                lamDichVuFn.search();
            }
        });
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(NhanVien, function (event, ui) {
                NhanVien.val(ui.item.label);
                NhanVien.attr('_value', ui.item.value);
                lamDichVuFn.search();
            });
            NhanVien.unbind('click').click(function () {
                NhanVien.autocomplete('search', '');
            });
        });
        $('#lamDichVuMdl-List').jqGrid({
            url: lamDichVuFn.urlDefault().toString() + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Nhân viên', 'K/hàng', 'Dịch vụ', 'Thanh toán', 'Tổng tiền', 'Ngày làm'],
            colModel: [
                        { name: 'LDV_ID', key: true, sortable: true, hidden: true },
                        { name: 'LDV_NhanVien', width: 5, sortable: true },
                        { name: 'LDV_KH_Ten', width: 10, resizable: true, sortable: true },
                        { name: 'LDV_DV_Ten', width: 10, resizable: true, sortable: true },
                        { name: 'TVDV_ThanhToan', width: 10, resizable: true, sortable: true, formatter:'number', formatoptions: { decimalSeparator: ",", thousandsSeparator: ".", decimalPlaces: 0, defaultValue: '0' } },
                        { name: 'TVDV_Tien', width: 10, resizable: true, sortable: true, align: 'right', summaryType: 'sum', summaryTpl: '<b>{0}</b>', formatter: 'number', formatoptions: { decimalSeparator: ",", thousandsSeparator: ".", decimalPlaces: 0, defaultValue: '0' } },
                        { name: 'LDV_NgayLam', width: 10, resizable: true, sortable: true, align: 'right' }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'LDV_NgayLam',
            sortorder: 'asc',
            pager: jQuery('#lamDichVuMdl-Pager'),
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) { },
            grouping: true,
            groupingView: {
                groupField: ['LDV_NhanVien'],
                groupSummary: [true],
                groupColumnShow: [true],
                groupText: ['<b>{0} - {1} lần</b>'],
                groupCollapse: false,
                groupOrder: ['asc']
            },
            loadComplete: function () {
                
            }
        });

    },
    refresh: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#lamDichVuMdl-List';
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: lamDichVuFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        }, 500);
    },
    search: function () {
        var NhanVien = $('.mdl-head-lamDichVuMdl-NhanVien');
        var TuNgay = $('.mdl-head-lamDichVuMdl-TuNgay');
        var DenNgay = $('.mdl-head-lamDichVuMdl-DenNgay');
        
        var _NhanVien = NhanVien.attr('_value');
        var _TuNgay = TuNgay.val();
        var _DenNgay = DenNgay.val();
        
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#lamDichVuMdl-List').jqGrid('setGridParam', { url: lamDichVuFn.urlDefault().toString() + '&subAct=get&NhanVien=' + _NhanVien  + '&DenNgay=' + _DenNgay + '&TuNgay=' + _TuNgay }).trigger('reloadGrid');
        }, 500);
    },
    clearform: function () {
        var newDlg = $('#lamDichVuMdl-dlgNew');
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
        if (typeof (grid) == 'undefined') grid == '#lamDichVuMdl-List';
        var request = $(grid).jqGrid('getGridParam', 'url');
        request = request.replace('get', 'reports');
        var win = window.open(request, 'popup', 'width=1024, height=700');
        win.focus();
    },
    createReport: function (id) {
        var request = document.location.href + lamDichVuFn.urlDefault().toString() + '&subAct=reports&ID=' + id;
        var win = window.open(request, 'popup', 'width=1024, height=700');
        win.focus();
    },
    loadHtml: function (fn) {
        var dlg = $('#lamDichVuMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.htm.htm")%>',
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
