var danhMucDichVuMgr = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.danhMucDichVuMgr.Class1, appStore.pmSpa.danhMucDichVuMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        var DMID = $('.mdl-head-filterByLoaiDichVu');
        $('#danhMucDichVuMgr-List').jqGrid({
            url: danhMucDichVuMgr.urlDefault().toString() + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Nhóm', 'Mã', 'Tên', 'Mô tả', 'Giá', 'Khóa'],
            colModel: [
                        { name: 'DV_ID', key: true, sortable: true, hidden: true },
                        { name: 'DV_DM_Ten', width: 10, resizable: true, sortable: true },
                        { name: 'DV_Ma', width: 5, sortable: true },
                        { name: 'DV_Ten', width: 20, sortable: true },
                        { name: 'DV_MoTa', width: 30, resizable: true, sortable: true },
                        { name: 'DV_Gia', width: 10, resizable: true, sortable: true, align: "right" },
                        { name: 'DV_Active', width: 5, resizable: true, sortable: true, formatter: 'checkbox' }
                    ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'DV_NgayTao',
            sortorder: 'asc',
            rowNum: 10000,
            onSelectRow: function (rowid) {
                var treedata = $("#danhMucDichVuMgr-List").jqGrid('getRowData', rowid);
                danhMucDichVuMgr.changeSubGrid(treedata.DV_ID);
            },
            pager: $('#danhMucDichVuMgr-Pager'),
            loadComplete: function () {
                danhMucDichVuMgr.loadSubGrid();
                if (typeof (Ajax_upload) == 'undefined') {
                    $.getScript('../js/ajaxupload.js', function () { });
                };
                adm.regJPlugin(jQuery().formatCurrency, '../js/jquery.formatCurrency-1.4.0.min.js', function () {
                });
                adm.loading(null);

                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteLangBased('', 'NHOM-DV', DMID, function (event, ui) {
                        DMID.attr('_value', ui.item.id);
                        danhMucDichVuMgr.search();
                    });
                    DMID.unbind('click').click(function () {
                        DMID.autocomplete('search', '');
                    });
                });
                adm.regType(typeof (AlbumMgrFn), 'appStore.pmSpa.desktop.controls.AlbumMgr.DanhSach, appStore.pmSpa.desktop.controls', function () {
                });
            }
        });
        adm.watermark(DMID, 'Gõ tên loại danh mục để lọc', function () {
        });
    },
    loadSubGrid: function () {
        $('.danhMucDichVuMgr-subMdl').tabs({
            show: function (event, ui) {
                if (ui.index == '0') {
                    $('#danhMucDichVuMgrChiTiet-List').jqGrid({
                        url: danhMucDichVuMgr.urlDefault().toString() + '&subAct=getSub&DV_ID=',
                        height: '400',
                        datatype: 'json',
                        colNames: ['ID', 'Thứ tự', 'Tên', 'Giá', 'Số lượng', 'Tổng', 'Ngày tạo'],
                        colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true },
                        { name: 'ThuTu', width: 5, sortable: true },
                        { name: 'HH_Ten', width: 55, sortable: true },
                        { name: 'Gia', width: 10, sortable: true, align: "right" },
                        { name: 'SoLuong', width: 5, resizable: true, sortable: true, align: "right" },
                        { name: 'Tong', width: 15, resizable: true, sortable: true, align: "right" },
                        { name: 'NgayTao', width: 10, resizable: true, sortable: true }

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
                }
                else if (ui.index == '1') {
                    adm.regType(typeof (AlbumMgrFn), 'appStore.pmSpa.desktop.controls.AlbumMgr.DanhSach, appStore.pmSpa.desktop.controls', function () {
                        AlbumMgrFn.loadGrid('#danhMucDichVuMgrAlbum-list', function () {
                        });
                    });
                }
            }
        });
    },
    changeSubGrid: function (_id) {
        $('#danhMucDichVuMgrChiTiet-List').jqGrid('setGridParam', { url: danhMucDichVuMgr.urlDefault().toString() + '&subAct=getSub&DV_ID=' + _id }).trigger('reloadGrid');
        $('#danhMucDichVuMgrAlbum-list').jqGrid('setGridParam', { url: AlbumMgrFn.urlDefault().toString() + '&subAct=getGrid&P_RowId=' + _id }).trigger('reloadGrid');
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid = '#danhMucDichVuMgr-List';

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
                var __DV_ID = treedata.DV_ID;
                danhMucDichVuMgr.loadHtml(function () {
                    var newDlg = $('#danhMucDichVuMgr-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                danhMucDichVuMgr.save(false, function () {
                                    danhMucDichVuMgr.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                danhMucDichVuMgr.save(false, function () {
                                    danhMucDichVuMgr.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            danhMucDichVuMgr.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            danhMucDichVuMgr.clearform();
                            $.ajax({
                                url: danhMucDichVuMgr.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': __DV_ID
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var GhiChu = $('.GhiChu', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var ThaoTac = $('.ThaoTac', newDlg);
                                    var Gia = $('.Gia', newDlg);
                                    var ThoiGian = $('.ThoiGian', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var KhuyenMai = $('.KhuyenMai', newDlg);
                                    var SoLan = $('.SoLan', newDlg);

                                    var spbMsg = $('.admMsg', newDlg);
                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var Anh = $('.Anh', newDlg);

                                    imgAnh.attr('src', '');
                                    Anh.attr('ref', '');

                                    Anh.attr('ref', dt.Anh);
                                    imgAnh.attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());

                                    ID.val(dt.ID);



                                    DM_ID.val(dt.DM_Ten);
                                    DM_ID.attr('_value', dt.DM_ID);
                                    Ten.val(dt.Ten);
                                    Ma.val(dt.Ma);
                                    MoTa.val(dt.MoTa);
                                    GhiChu.val(dt.GhiChu);
                                    SoLan.val(dt.SoLan);
                                    NoiDung.val(dt.NoiDung);
                                    ThaoTac.val(dt.ThaoTac);
                                    Gia.val(dt.Gia);
                                    ThoiGian.val(dt.ThoiGian);

                                    if (dt.Active) {
                                        Active.attr('checked', 'checked');
                                    }
                                    else {
                                        Active.removeAttr('checked');
                                    }
                                    if (dt.KhuyenMai) {
                                        KhuyenMai.attr('checked', 'checked');
                                    }
                                    else {
                                        KhuyenMai.removeAttr('checked');
                                    }
                                    danhMucDichVuMgr.popfn();

                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function () {
        danhMucDichVuMgr.loadHtml(function () {
            var newDlg = $('#danhMucDichVuMgr-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        danhMucDichVuMgr.save(false, function () {
                            danhMucDichVuMgr.clearform();
                        }, '#danhMucDichVuMgr-List');
                    },
                    'Lưu và đóng': function () {
                        danhMucDichVuMgr.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#danhMucDichVuMgr-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    danhMucDichVuMgr.clearform();
                },
                open: function () {
                    adm.styleButton();
                    danhMucDichVuMgr.clearform();
                    danhMucDichVuMgr.popfn();
                }
            });
        });

    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid = '#danhMucDichVuMgr-List';
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
                    url: danhMucDichVuMgr.urlDefault().toString() + '&subAct=del',
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
        if (typeof (grid) == 'undefined') grid = '#danhMucDichVuMgr-List';
        var newDlg = $('#danhMucDichVuMgr-dlgNew');

        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var ThaoTac = $('.ThaoTac', newDlg);
        var Gia = $('.Gia', newDlg);
        var ThoiGian = $('.ThoiGian', newDlg);
        var SoLan = $('.SoLan', newDlg);
        var Active = $('.Active', newDlg);
        var KhuyenMai = $('.KhuyenMai', newDlg);

        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var Anh = $('.Anh', newDlg);

        var _Anh = $(Anh).attr('ref');

        var _ID = ID.val();
        var _DM_ID = DM_ID.attr('_value');
        var _Ten = Ten.val();
        var _Ma = Ma.val();
        var _MoTa = MoTa.val();
        var _GhiChu = GhiChu.val();
        var _NoiDung = NoiDung.val();
        var _ThaoTac = ThaoTac.val();
        var _Anh = Anh.attr('ref');
        var _Gia = adm.VndToNumber(Gia);
        var _SoLan = adm.VndToNumber(SoLan);
        var _ThoiGian = adm.VndToNumber(ThoiGian);
        var _Active = Active.is(':checked');
        var _KhuyenMai = KhuyenMai.is(':checked');

        ////console.log(_Anh);
        var err = '';
        if (_DM_ID == '') { err += 'Chọn loại danh mục<br/>'; };
        if (_Ten == '') { err += 'Nhập tên<br/>'; };
        
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: danhMucDichVuMgr.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                ID: _ID,
                DM_ID: _DM_ID,
                Ten: _Ten,
                Ma: _Ma,
                MoTa: _MoTa,
                GhiChu: _GhiChu,
                NoiDung: _NoiDung,
                ThaoTac: _ThaoTac,
                Anh: _Anh,
                Gia: _Gia,
                ThoiGian: _ThoiGian,
                Active: _Active,
                KhuyenMai: _KhuyenMai,
                SoLan: _SoLan
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
            $('#danhMucDichVuMgr-List').jqGrid('setGridParam', { url: danhMucDichVuMgr.urlDefault().toString() + '&subAct=get&DM_ID=' + _LDMID + '&q=' + q.val() }).trigger('reloadGrid');
        }, 500);
    },
    popfn: function () {
        var newDlg = $('#danhMucDichVuMgr-dlgNew');
        var DMID = $('.DM_ID', newDlg);
        var ID = $('.ID', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var ThaoTac = $('.ThaoTac', newDlg);
        var Gia = $('.Gia', newDlg);
        var ThoiGian = $('.ThoiGian', newDlg);
        var SoLan = $('.SoLan', newDlg);
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'NHOM-DV', DMID, function (event, ui) {
                DMID.attr('_value', ui.item.id);
            });
            DMID.unbind('click').click(function () {
                DMID.autocomplete('search', '');
            });
        });

        adm.createTinyMce(GhiChu);
        adm.createTinyMce(NoiDung);
        adm.createTinyMce(ThaoTac);

        adm.formatNumber(ThoiGian);
        adm.formatNumber(SoLan);
        adm.formatNumber(Gia);
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
    saveSub: function (validate, fn, grid) {
        var _DV_ID = '';

        if (jQuery('#danhMucDichVuMgr-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#danhMucDichVuMgr-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (_DV_ID == '') {
            _DV_ID = '';
        }
        else {
            if (_DV_ID.indexOf(',') != -1) {
                _DV_ID = '';
            }
        }

        if (typeof (grid) == 'undefined') grid = '#danhMucDichVuMgrChiTiet-List';
        if (typeof (grid) == 'undefined') grid = '#danhMucDichVuMgrChiTiet-List';
        var newDlg = $('#danhMucDichVuMgrChiTiet-dlgNew');


        var ID = $('.ID', newDlg);
        var HH_ID = $('.HH_ID', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Gia = $('.Gia', newDlg);
        var SoLuong = $('.SoLuong', newDlg);

        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _HH_ID = HH_ID.attr('_value');
        var _ThuTu = adm.VndToNumber(ThuTu);
        var _Gia = adm.VndToInt(Gia);
        var _SoLuong = adm.VndToNumber(SoLuong);


        console.log(_ThuTu);
        console.log(_Gia);
        console.log(_SoLuong);
        var err = '';
        if (_HH_ID == '') { err += 'Chọn hàng hoá<br/>'; };
        if (_DV_ID == '') { err += 'Chọn dịch vụ ở lưới trên<br/>'; };
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: danhMucDichVuMgr.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'saveSub',
                ID: _ID,
                HH_ID: _HH_ID,
                DV_ID: _DV_ID,
                ThuTu: _ThuTu,
                SoLuong: _SoLuong,
                Gia: _Gia
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
        if (typeof (grid) == 'undefined') grid = '#danhMucDichVuMgrChiTiet-List';

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
                danhMucDichVuMgr.loadHtml(function () {
                    var newDlg = $('#danhMucDichVuMgrChiTiet-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        buttons: {
                            'Lưu': function () {
                                danhMucDichVuMgr.saveSub(false, function () {
                                    danhMucDichVuMgr.clearformSub();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                danhMucDichVuMgr.saveSub(false, function () {
                                    danhMucDichVuMgr.clearformSub();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            danhMucDichVuMgr.clearformSub();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            danhMucDichVuMgr.clearformSub();
                            $.ajax({
                                url: danhMucDichVuMgr.urlDefault().toString() + '&subAct=editSub',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var HH_ID = $('.HH_ID', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var Gia = $('.Gia', newDlg);
                                    var SoLuong = $('.SoLuong', newDlg);

                                    ID.val(dt.ID);



                                    HH_ID.val(dt.HH_Ten);
                                    HH_ID.attr('_value', dt.HH_ID);
                                    ThuTu.val(dt.ThuTu);
                                    Gia.val(dt.Gia);
                                    SoLuong.val(dt.SoLuong);
                                    danhMucDichVuMgr.popfnSub();
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    delSub: function (grid) {
        if (typeof (grid) == 'undefined') grid = '#danhMucDichVuMgrChiTiet-List';
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
                    url: danhMucDichVuMgr.urlDefault().toString() + '&subAct=delSub',
                    dataType: 'script',
                    data: { 'ID': __DV_ID },
                    success: function (dt) {
                        jQuery(grid).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    addSub: function () {
        var _DV_ID = '';
        if (jQuery('#danhMucDichVuMgr-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#danhMucDichVuMgr-List').jqGrid('getGridParam', 'selrow').toString();
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

        danhMucDichVuMgr.loadHtml(function () {
            var newDlg = $('#danhMucDichVuMgrChiTiet-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        danhMucDichVuMgr.saveSub(false, function () {
                            danhMucDichVuMgr.clearformSub();
                        }, '#danhMucDichVuMgrChiTiet-List');
                    },
                    'Lưu và đóng': function () {
                        danhMucDichVuMgr.saveSub(false, function () {
                            $(newDlg).dialog('close');
                        }, '#danhMucDichVuMgrChiTiet-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    danhMucDichVuMgr.clearformSub();
                },
                open: function () {
                    adm.styleButton();
                    danhMucDichVuMgr.clearformSub();
                    danhMucDichVuMgr.popfnSub();
                }
            });
        });
    },
    popfnSub: function () {
        var newDlg = $('#danhMucDichVuMgrChiTiet-dlgNew');
        var HH_ID = $('.HH_ID', newDlg);
        var ID = $('.ID', newDlg);
        var desc = newDlg.find('.desc');
        var Gia = $('.Gia', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var SoLuong = $('.SoLuong', newDlg);

        adm.formatTien(Gia);
        adm.formatNumber(ThuTu);
        adm.formatNumber(SoLuong);
        adm.regType(typeof (hangHoaMgrFn), 'appStore.commonStore.hangHoaMgr.Class1, appStore.commonStore.hangHoaMgr', function () {
            hangHoaMgrFn.autoCompleteByQ(HH_ID, function (event, ui) {
                HH_ID.val(ui.item.value);
                HH_ID.attr('_value', ui.item.id);
                desc.html('<br/>' + ui.item.label + ' ' + adm.formatTienStr(ui.item.giaNhap));
                if (Gia.val() == '') {
                    Gia.val(ui.item.giaNhap);
                    adm.formatTien(Gia);
                }
            });
        }, function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a><b>" + item.ma + '</b> ' + item.label + ' [' + adm.formatTienStr(item.giaNhap) + '] - ' + item.DonVi + ' </a>')
				            .appendTo(ul);
        });
    },
    clearformSub: function () {
        var newDlg = $('#danhMucDichVuMgrChiTiet-dlgNew');
        var ID = $('.ID', newDlg);
        var HH_ID = $('.HH_ID', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Gia = $('.Gia', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var desc = newDlg.find('.desc');

        ID.val('');
        HH_ID.val('');
        HH_ID.attr('_value', '');
        ThuTu.val('');
        Gia.val('');
        SoLuong.val('');
        desc.html('');
        $(spbMsg).html('');
    },
    clearform: function () {
        var newDlg = $('#danhMucDichVuMgr-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var ThaoTac = $('.ThaoTac', newDlg);
        var Anh = $('.Anh', newDlg);
        var Gia = $('.Gia', newDlg);
        var Active = $('.Active', newDlg);
        var KhuyenMai = $('.KhuyenMai', newDlg);
        var SoLan = $('.SoLan', newDlg);
        var ThoiGian = $('.ThoiGian', newDlg);


        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var Anh = $('.Anh', newDlg);


        ID.val('');
        DM_ID.val('');
        DM_ID.attr('_value', '');
        Ten.val('');
        Ma.val('');
        MoTa.val('');
        GhiChu.val('');
        NoiDung.val('');
        ThaoTac.val('');
        Anh.val('');
        Gia.val('');
        SoLan.val('');
        Active.val('');
        KhuyenMai.val('');
        ThoiGian.val('');

        imgAnh.attr('src', '');
        Anh.attr('ref', '');
        $(spbMsg).html('');
    },
    autoCompleteByQ: function (el, fn, fn1) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'dichVu-autoCompleteByQ' + el.val();
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhMucDichVuMgr.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteByQ', 'q': el.val() },
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
                                        ma: item.Ma,
                                        gia: item.Gia,
                                        SoLan: item.SoLan,
                                        ThoiGian: item.ThoiGian
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
            if (typeof (fn1) == "function") {
                return fn1(ul, item);
            }
            else {
                return $("<li></li>")
                                .data("item.autocomplete", item)
                                .append("<a><b>" + item.ma + '</b> ' + item.label + ' [' + item.gia + '] </a>')
                                .appendTo(ul);
            }
        };
    },
    addAlbum: function () {
        var _DV_ID = '';
        if (jQuery('#danhMucDichVuMgr-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#danhMucDichVuMgr-List').jqGrid('getGridParam', 'selrow').toString();
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
        AlbumMgrFn.Add(function () {
            $('#danhMucDichVuMgrAlbum-list').trigger('reloadGrid');
            return false;
        }, { P_RowId: _DV_ID });
    },
    editAlbum: function () {

        var _DV_ID = '';
        if (jQuery('#danhMucDichVuMgr-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#danhMucDichVuMgr-List').jqGrid('getGridParam', 'selrow').toString();
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

        var _ab_id = '';
        if (jQuery('#danhMucDichVuMgrAlbum-list').jqGrid('getGridParam', 'selrow') != null) {
            _ab_id = jQuery('#danhMucDichVuMgrAlbum-list').jqGrid('getGridParam', 'selrow').toString();
        }
        if (_ab_id == '') {
            _ab_id = '';
        }
        else {
            if (_ab_id.indexOf(',') != -1) {
                _ab_id = '';
            }
        }
        if (_ab_id == '') {
            alert('Chọn dịch vụ ở trên');
            return false;
        }

        AlbumMgrFn.Edit(_ab_id, function () {
            $('#danhMucDichVuMgrAlbum-list').trigger('reloadGrid');
            return false;
        }, { P_RowId: _DV_ID });
    },
    deleteAlbum: function (grid) {
        if (typeof (grid) == 'undefined') grid = '#danhMucDichVuMgrAlbum-list';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa ?')) {// Xác nhận xem có xóa hay không
                $.ajax({
                    url: AlbumMgrFn.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(grid).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    loadHtml: function (fn) {
        var dlg = $('#danhMucDichVuMgr-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.danhMucDichVuMgr.htm.htm")%>',
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
