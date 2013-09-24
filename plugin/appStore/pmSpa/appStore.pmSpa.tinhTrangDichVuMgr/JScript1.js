var tinhTrangDichVuMgr = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.tinhTrangDichVuMgr.Class1, appStore.pmSpa.tinhTrangDichVuMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            $('#tinhTrangDichVuMgr-List').jqGrid({
                url: danhmuc.urlDefault().toString() + '&subAct=getByMa&LDM_Ma=TINH-TRANG',
                height: '400',
                datatype: 'json',
                loadui: 'disable',
                colNames: ['ID', 'LangBased', '_ID', 'Lang', 'Thứ tự', 'Loại Danh Mục', 'Mã', 'Ký Hiệu', 'Giá Trị', 'Ảnh', 'Tên', 'Ngày cập nhật', 'Người tạo/sửa'],
                colModel: [
                        { name: 'DM_ID', key: true, sortable: true, hidden: true },
                        { name: 'LangBased', key: true, sortable: true, hidden: true },
                        { name: '_DM_ID', key: true, sortable: true, hidden: true },
                        { name: 'DM_Lang', width: 2, sortable: true, align: "center", hidden: true },
                        { name: 'DM_ThuTu', width: 2, sortable: true },
                        { name: 'LDM_Ten', width: 10, resizable: true, sortable: true },
                        { name: 'DM_Ma', width: 10, resizable: true, sortable: true },
                        { name: 'DM_KyHieu', width: 10, resizable: true, sortable: true },
                        { name: 'DM_GiaTri', width: 10, resizable: true, sortable: true },
                        { name: 'DM_Anh', width: 5, resizable: true, sortable: true },
                        { name: 'DM_Ten', width: 40, resizable: true, sortable: true },
                        { name: 'DM_NgayCapNhat', width: 5, resizable: true, sortable: true, align: "center" },
                        { name: 'DM_NguoiTao ', width: 5, resizable: false, sortable: true, align: "center" }
                    ],
                caption: 'Danh sách',
                autowidth: true,
                sortname: 'DM_ThuTu',
                sortorder: 'asc',
                rowNum: 10000,
                onSelectRow: function (rowid) {
                    var treedata = $("#tinhTrangDichVuMgr-List").jqGrid('getRowData', rowid);
                    tinhTrangDichVuMgr.changeSubGrid(treedata.DM_ID);
                },
                loadComplete: function () {
                    tinhTrangDichVuMgr.loadSubGrid();
                    adm.loading(null);
                },
                treeGrid: true,
                ExpandColumn: 'DM_Ten',
                treeGridModel: 'adjacency',
                ExpandColClick: false,
                treeIcons: { leaf: 'ui-icon-document-b' }
            });
        });
    },
    loadSubGrid: function () {
        $('#tinhTrangDichVuMgrChiTiet-List').jqGrid({
            url: tinhTrangDichVuMgr.urlDefault().toString() + '&subAct=getSub&DM_ID=',
            height: '400',
            datatype: 'json',
            colNames: ['ID', 'Thứ tự', 'Tên', 'Số lượng'],
            colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true },
                        { name: 'ThuTu', width: 10, sortable: true },
                        { name: 'DV_Ten', width: 50, sortable: true },
                        { name: 'SoLuong', width: 10, resizable: true, sortable: true }
                    ],
            caption: 'Chi tiết',
            autowidth: true,
            sortorder: 'asc',
            rowNum: 20000,
            pager: false,
            rowList: [20000, 2000, 3000],
            onSelectRow: function (rowid) { },
            loadComplete: function () { adm.loading(null); }
        });
    },
    changeSubGrid: function (_id) {
        $('#tinhTrangDichVuMgrChiTiet-List').jqGrid('setGridParam', { url: tinhTrangDichVuMgr.urlDefault().toString() + '&subAct=getSub&DM_ID=' + _id }).trigger('reloadGrid');
    },
    saveSub: function (validate, fn, grid) {
        var _DM_ID = '';

        if (jQuery('#tinhTrangDichVuMgr-List').jqGrid('getGridParam', 'selrow') != null) {
            _DM_ID = jQuery('#tinhTrangDichVuMgr-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (_DM_ID == '') {
            _DM_ID = '';
        }
        else {
            if (_DM_ID.indexOf(',') != -1) {
                _DM_ID = '';
            }
        }


        if (typeof (grid) == 'undefined') grid = '#tinhTrangDichVuMgrChiTiet-List';
        if (typeof (grid) == 'undefined') grid = '#tinhTrangDichVuMgrChiTiet-List';
        var newDlg = $('#tinhTrangDichVuMgrChiTiet-dlgNew');


        var ID = $('.ID', newDlg);
        var DV_ID = $('.DV_ID', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var SoLuong = $('.SoLuong', newDlg);

        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _DV_ID = DV_ID.attr('_value');
        var _ThuTu = ThuTu.val();
        var _SoLuong = SoLuong.val();

        var err = '';
        if (_DV_ID == '') { err += 'Chọn dịch vụ<br/>'; };
        if (_DM_ID == '') { err += 'Chọn tình trạng ở lưới trên<br/>'; };
        if (_SoLuong == '') { _SoLuong = '0'; } else { if (!adm.isInt(_SoLuong)) { err += 'Nhập số lượng kiểu số<br/>'; } }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: tinhTrangDichVuMgr.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'saveSub',
                ID: _ID,
                DM_ID: _DM_ID,
                DV_ID: _DV_ID,
                ThuTu: _ThuTu,
                SoLuong: _SoLuong
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
    editSub: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid = '#tinhTrangDichVuMgrChiTiet-List';

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
                tinhTrangDichVuMgr.loadHtml(function () {
                    var newDlg = $('#tinhTrangDichVuMgrChiTiet-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 450,
                        buttons: {
                            'Lưu': function () {
                                tinhTrangDichVuMgr.saveSub(false, function () {
                                    tinhTrangDichVuMgr.clearformSub();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                tinhTrangDichVuMgr.saveSub(false, function () {
                                    tinhTrangDichVuMgr.clearformSub();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            tinhTrangDichVuMgr.clearformSub();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            tinhTrangDichVuMgr.clearformSub();
                            tinhTrangDichVuMgr.popfnSub();
                            $.ajax({
                                url: tinhTrangDichVuMgr.urlDefault().toString() + '&subAct=editSub',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var DV_ID = $('.DV_ID', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var SoLuong = $('.SoLuong', newDlg);

                                    ID.val(dt.ID);
                                    DV_ID.val(dt.DV_Ten);
                                    DV_ID.attr('_value', dt.DV_ID);
                                    ThuTu.val(dt.ThuTu);
                                    SoLuong.val(dt.SoLuong);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    delSub: function (grid) {
        if (typeof (grid) == 'undefined') grid = '#tinhTrangDichVuMgrChiTiet-List';
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
                var __DV_ID = treedata.ID; // Lấy DV_ID thật của danh mục
                $.ajax({
                    url: tinhTrangDichVuMgr.urlDefault().toString() + '&subAct=delSub',
                    dataType: 'script',
                    data: { 'ID': __DV_ID },
                    success: function (dt) {
                        jQuery(grid).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    getByDmId: function (dmId, fn) {
        $.ajax({
            url: tinhTrangDichVuMgr.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: {
                'subAct': 'getByDmId',
                'DM_ID' : dmId
            },
            success: function (dt) {
                fn(dt);
            }
        });
    },
    addSub: function () {
        var _DV_ID = '';
        if (jQuery('#tinhTrangDichVuMgr-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#tinhTrangDichVuMgr-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (_DV_ID == '') {
            _DV_ID = '';
        }
        else {
            if (_DV_ID.indexOf(',') != -1) {
                _DV_ID = '';
            }
        }
        if (_DV_ID == '') {
            alert('Chọn dịch vụ ở trên');
            return false;
        }

        tinhTrangDichVuMgr.loadHtml(function () {
            var newDlg = $('#tinhTrangDichVuMgrChiTiet-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 450,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        tinhTrangDichVuMgr.saveSub(false, function () {
                            tinhTrangDichVuMgr.clearformSub();
                        }, '#tinhTrangDichVuMgrChiTiet-List');
                    },
                    'Lưu và đóng': function () {
                        tinhTrangDichVuMgr.saveSub(false, function () {
                            $(newDlg).dialog('close');
                        }, '#tinhTrangDichVuMgrChiTiet-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    tinhTrangDichVuMgr.clearformSub();
                },
                open: function () {
                    adm.styleButton();
                    tinhTrangDichVuMgr.clearformSub();
                    tinhTrangDichVuMgr.popfnSub();
                }
            });
        });
    },
    popfnSub: function () {
        var newDlg = $('#tinhTrangDichVuMgrChiTiet-dlgNew');
        var DV_ID = $('.DV_ID', newDlg);
        var ID = $('.ID', newDlg);

        adm.regType(typeof (danhMucDichVuMgr), 'appStore.pmSpa.danhMucDichVuMgr.Class1, appStore.pmSpa.danhMucDichVuMgr', function () {
            danhMucDichVuMgr.autoCompleteByQ(DV_ID, function (event, ui) {
                DV_ID.attr('_value', ui.item.id);
            });
            DV_ID.unbind('click').click(function () {
                DV_ID.autocomplete('search', '');
            });
        });
    },
    clearformSub: function () {
        var newDlg = $('#tinhTrangDichVuMgrChiTiet-dlgNew');
        var ID = $('.ID', newDlg);
        var DV_ID = $('.DV_ID', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        ID.val('');
        DV_ID.val('');
        DV_ID.attr('_value', '');
        ThuTu.val('');
        SoLuong.val('');
        $(spbMsg).html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#tinhTrangDichVuMgrChiTiet-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.tinhTrangDichVuMgr.htm.htm")%>',
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
