var suKienMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cangtin.plugins.suKienMgr.Admin.Class1, cangtin.plugins.suKienMgr',
    setup: function () {
    },
    loadgrid: function () {

        adm.loading('Đang lấy dữ liệu tin tức');
        adm.styleButton();
        var searchTxt = $('.mdl-head-search-tin');
        $('#suKienMgrMdl-List').jqGrid({
            url: suKienMgrFn.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Loại', 'Tên', 'Ngày', 'Lệ phí', 'Xem', 'Đăng ký', 'Tham gia', 'Khóa','Ngày C/n'],
            colModel: [
            { name: 'SK_ID', key: true, sortable: true, hidden: true },
            { name: 'SK_DM_ID', width: 10, sortable: true},
            { name: 'SK_Ten', width: 40, resizable: true, sortable: true},
            { name: 'SK_Ngay', width: 5, resizable: true, sortable: true},
            { name: 'SK_LePhi', width: 5, resizable: true, sortable: true },
            { name: 'SK_Xem', width: 5, resizable: true, sortable: true },
            { name: 'SK_DangKy', width: 5, sortable: true },
            { name: 'SK_ThamGia', width: 5, resizable: true, sortable: true, hidden: true },
            { name: 'SK_Khoa', width: 5, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
            { name: 'SK_NgayCapNhat', width: 50, resizable: true, sortable: true, align: "center" }
        ],
            caption: 'Danh sách sự kiện',
            autowidth: true,
            sortname: 'SK_NgayTao',
            sortorder: 'desc',
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            pager: jQuery('#suKienMgrMdl-Pagerql'),
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) {
                suKienMgrFn.changeSubGrid(rowid);
            },
            loadComplete: function () {
                suKienMgrFn.loadSubGrid();
                adm.loading(null);
                if (typeof (Ajax_upload) == 'undefined') {
                    $.getScript('../js/ajaxupload.js', function () { });
                };
                adm.watermark(searchTxt, 'Tìm kiếm tin tức', function () {
                    $(searchTxt).val('');
                    suKienMgrFn.search();
                    $(searchTxt).val('Tìm kiếm tin tức');
                });
            }
        });
    },
    loadSubGrid: function () {
        $('.suKienMgrMdl-subMdl-list').tabs({
            show: function (event, ui) {
                if (ui.index == '0') {
                    $('#suKienMgrMdlChiTiet-ThanhVien-List').jqGrid({
                        url: suKienMgrFn.urlDefault + '&subAct=getThanhVien&PID_ID=',
                        height: '400',
                        datatype: 'json',
                        colNames: ['ID', 'Duyệt', 'Admin', 'Vip', 'Tên', 'Username', 'Mobile', 'Ngày tạo'],
                        colModel: [
                            { name: 'ID', key: true, sortable: true, hidden: true },
                            { name: 'Duyet', width: 3, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                            { name: 'Admin', width: 3, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                            { name: 'Vip', width: 3, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                            { name: 'Ten', width: 20 },
                            { name: 'Username', width: 20, sortable: true, align: "right" },
                            { name: 'Mobile', width: 5, resizable: true, align: "right" },
                            { name: 'NgayTao', width: 10, resizable: true, sortable: true }
                        ],
                        caption: 'Thành viên',
                        autowidth: true,
                        sortorder: 'asc',
                        rowNum: 10,
                        rowList: [10, 20, 50, 100, 200, 300],
                        pager: jQuery('#suKienMgrMdlChiTiet-ThanhVien-Pager'),
                        onSelectRow: function (rowid) { },
                        loadComplete: function () { adm.loading(null); }
                    });
                }
                else if (ui.index == '1') {
                    adm.regType(typeof (AlbumMgrFn), 'appStore.pmSpa.desktop.controls.AlbumMgr.DanhSach, appStore.pmSpa.desktop.controls', function () {
                        AlbumMgrFn.loadGrid('#suKienMgrMdlAlbum-Album-list', function () {
                        });
                    });
                }
            }
        });
    },
    changeSubGrid: function (_id) {
        $('#suKienMgrMdlChiTiet-ThanhVien-List').jqGrid('setGridParam', { url: suKienMgrFn.urlDefault + '&subAct=getThanhVien&PID_ID=' + _id }).trigger('reloadGrid');
    },
    add: function () {
        suKienMgrFn.loadHtml(function () {
            var newDlg = $('#suKienMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1000,
                position: [200, 0],
                //     modal: true,
                buttons: {
                    'Lưu': function () {
                        suKienMgrFn.save(false, function () {
                            suKienMgrFn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        suKienMgrFn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {

                    adm.styleButton();
                    suKienMgrFn.clearform();
                    suKienMgrFn.addpopfn();
                }
                ,
                beforeclose: function () {
                    suKienMgrFn.clearform();
                }
            });
        });
    },
    edit: function () {
        var s = '';
        if (jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                suKienMgrFn.loadHtml(function () {
                    var newDlg = $('#suKienMgrMdl-dlgNew');

                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 1000,

                        position: [200, 0],
                        //  modal: true,
                        buttons: {
                            'Lưu': function () {
                                suKienMgrFn.save(false, function () {
                                    suKienMgrFn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                suKienMgrFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeclose: function () {

                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            suKienMgrFn.addpopfn();
                            suKienMgrFn.clearform();
                            $.ajax({
                                url: suKienMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#suKienMgrMdl-dlgNew');
                            
                                    
                                    var ID = $('.ID', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var NgayBatDau = $('.NgayBatDau', newDlg);
                                    var GhiChu = $('.GhiChu', newDlg);
                                    var MienPhi = $('.MienPhi', newDlg);
                                    var LePhi = $('.LePhi', newDlg);
                                    var LuotXem = $('.LuotXem', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var DiaChi = $('.DiaChi', newDlg);
                                    var ToaDo = $('.ToaDo', newDlg);
                                    var HauTruong = $('.HauTruong', newDlg);
                                    var Anh = $('.Anh', newDlg);
                                    var imgAnh = $('.adm-uploadTintuc-preview-img', newDlg);
                                    var Anh = $('.Anh', newDlg);

                                    imgAnh.attr('src', '');
                                    Anh.attr('ref', '');

                                    Anh.attr('ref', data.Anh);
                                    imgAnh.attr('src', '../up/i/' + data.Anh + '?ref=' + Math.random());
                                    
                                    ID.val(data.ID);
                                    DM_ID.val(data.DM_Ten);
                                    DM_ID.attr('_value',data.DM_ID);
                                    Ten.val(data.Ten);
                                    MoTa.val(data.MoTa);
                                    NoiDung.val(data.NoiDung);
                                    GhiChu.val(data.GhiChu);
                                    DiaChi.val(data.DiaChi);
                                    ToaDo.val(data.ToaDo);
                                    HauTruong.val(data.HauTruong);
                                    if(data.MienPhi) {
                                        MienPhi.attr('checked', 'checked');
                                    } else {
                                        MienPhi.removeAttr('checked');
                                    }
                                    LePhi.val(data.LePhi);
                                    LuotXem.val(data.LuotXem);
                                    
                                    if (data.Active) {
                                        Active.attr('checked', 'checked');
                                    } else {
                                        Active.removeAttr('checked');
                                    }
                                    
                                    var NgayBatDauData = new Date(data.NgayBatDau);

                                    var NgayBatDauStr = '';
                                    NgayBatDauStr = NgayBatDauData.getDate() + '/' + (NgayBatDauData.getMonth() + 1) + '/' + (NgayBatDauData.getFullYear());
                                    if (NgayBatDauData.getFullYear() != 100) {
                                        NgayBatDau.val(NgayBatDauStr);
                                    }
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function (fn) {
        var s = '';
        s = jQuery("#suKienMgrMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa tin này?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    if (ss[j] != '') {
                        if (ss[j] != '') {
                            var treedata = $("#suKienMgrMdl-List").jqGrid('getRowData', ss[j]);
                            ll += treedata.SK_ID + ',';
                        }                        
                    }                    
                }
            }
            $.ajax({
                url: suKienMgrFn.urlDefault + '&subAct=del',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#suKienMgrMdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    duyet: function (st) {
        var s = '';
        s = jQuery("#suKienMgrMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#suKienMgrMdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: suKienMgrFn.urlDefault + '&subAct=duyet&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#suKienMgrMdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    search: function () {
        var timerSearch;
        var DMID = $('.mdl-head-filterTinBydanhmuc');
        var searchTxt = $('.mdl-head-search-tin');
        var q = searchTxt.val();
        if (q == 'Tìm kiếm tin tức') {
            q = '';
        }
        var dm = DMID.attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#suKienMgrMdl-List').jqGrid('setGridParam', { url: suKienMgrFn.urlDefault + "&subAct=get&q=" + q + "&DMID=" + dm }).trigger("reloadGrid");
        }, 500);
    },
    save: function (validate, fn) {
        var newDlg = $('#suKienMgrMdl-dlgNew');
        
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var NgayBatDau = $('.NgayBatDau', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var MienPhi = $('.MienPhi', newDlg);
        var LePhi = $('.LePhi', newDlg);
        var LuotXem = $('.LuotXem', newDlg);
        var DangKy = $('.DangKy', newDlg);
        var Active = $('.Active', newDlg);
        var Anh = $('.Anh', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var ToaDo = $('.ToaDo', newDlg);
        var HauTruong = $('.HauTruong', newDlg);
        
        var _Anh = Anh.attr('ref');
        var _ID = ID.val();
        var _DM_ID = DM_ID.attr('_value');
        var _Ten = Ten.val();
        var _MoTa = MoTa.val();
        var _NoiDung = NoiDung.val();
        var _NgayBatDau = NgayBatDau.val();
        var _GhiChu = GhiChu.val();
        var _MienPhi = MienPhi.is(':checked');
        var _LePhi = LePhi.val();
        var _LuotXem = LuotXem.val();
        var _DiaChi = DiaChi.val();
        var _ToaDo = ToaDo.val();
        var _HauTruong = HauTruong.val();
        var _Active = Active.is(':checked');
        
        var err = '';
        if (_LePhi == '') { _LePhi = '0'; } else { if (!adm.isInt(_LePhi)) { err += 'Nhập lệ phí kiểu số<br/>'; } }
        if (_LuotXem == '') { _LuotXem = '0'; } else { if (!adm.isInt(_LuotXem)) { err += 'Nhập view kiểu số<br/>'; } }

        if (_Ten == '') {
            err += 'Nhập tên<br/>';
        }

        if (_DM_ID == '') {
            err += 'Chọn danh mục<br/>';
        }

        if (err != '') {
            adm.loading(err);
            return false;
        }
        if (validate) {
            if (typeof (fn) == 'function') {
                fn();
            }
            return false;
        }
        
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: suKienMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                ID: _ID,
                DM_ID: _DM_ID,
                Ten: _Ten,
                MoTa: _MoTa,
                NoiDung: _NoiDung,
                NgayBatDau: _NgayBatDau,
                GhiChu: _GhiChu,
                MienPhi: _MienPhi,
                LePhi: _LePhi,
                LuotXem: _LuotXem,
                Active: _Active,
                Anh: _Anh,
                ToaDo: _ToaDo,
                DiaChi: _DiaChi,
                HauTruong: _HauTruong
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#suKienMgrMdl-List').trigger('reloadGrid');
                } else {
                    adm.loading('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    clearform: function () {
        var newDlg = $('#suKienMgrMdl-dlgNew');

        var lblAnh = $('.Anh', newDlg);
        $(lblAnh).removeAttr('ref');
        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');
        
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var NgayBatDau = $('.NgayBatDau', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var MienPhi = $('.MienPhi', newDlg);
        var LePhi = $('.LePhi', newDlg);
        var LuotXem = $('.LuotXem', newDlg);
        var DangKy = $('.DangKy', newDlg);
        var Active = $('.Active', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var ToaDo = $('.ToaDo', newDlg);
        var HauTruong = $('.HauTruong', newDlg);
        newDlg.find('input, textarea').val('');
        DM_ID.attr('_value', '');

    },
    loadHtml: function (fn) {
        var dlg = $('#suKienMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cangtin.plugins.suKienMgr.Admin.htm.htm")%>',
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
    },
    addThanhVien: function () {
        var _DV_ID = '';
        if (jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
            alert('Chọn nhóm ở trên');
            return false;
        }
        suKienMgrFn.loadHtmlThanhVien(function () {
            adm.styleButton();
            var newDlg = $('#suKienMgrMdl-ThanhVien-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm thành viên',
                modal: true,
                width: 500,
                buttons: {
                    'Lưu': function () {
                        suKienMgrFn.saveThanhVien(false, function () {
                            suKienMgrFn.clearformThanhVien();
                        });
                    },
                    'Lưu và đóng': function () {
                        suKienMgrFn.saveThanhVien(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    suKienMgrFn.clearformThanhVien();
                    suKienMgrFn.addpopThanhVienfn();
                }
            });
        });
    },
    editThanhVien: function () {
        var _DV_ID = '';
        if (jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
            alert('Chọn nhóm ở trên');
            return false;
        }

        var _ab_id = '';
        if (jQuery('#suKienMgrMdlChiTiet-ThanhVien-List').jqGrid('getGridParam', 'selrow') != null) {
            _ab_id = jQuery('#suKienMgrMdlChiTiet-ThanhVien-List').jqGrid('getGridParam', 'selrow').toString();
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
            alert('Chọn thành viên');
            return false;
        }

        suKienMgrFn.loadHtmlThanhVien(function () {
            adm.styleButton();
            var newDlg = $('#suKienMgrMdl-ThanhVien-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm thành viên',
                modal: true,
                width: 500,
                buttons: {
                    'Lưu': function () {
                        suKienMgrFn.saveThanhVien(false, function () {
                            suKienMgrFn.clearformThanhVien();
                        });
                    },
                    'Lưu và đóng': function () {
                        suKienMgrFn.saveThanhVien(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    suKienMgrFn.clearformThanhVien();
                    adm.loading('Đang nạp dữ liệu');
                    $.ajax({
                        url: suKienMgrFn.urlDefault + '&subAct=editThanhVien',
                        dataType: 'script',
                        data: {
                            'ID': _ab_id
                        },
                        success: function (data) {
                            adm.loading(null);
                            var ID = $('.ID', newDlg);
                            var Username = $('.Username', newDlg);
                            var Admin = $('.Admin', newDlg);
                            var Duyet = $('.Duyet', newDlg);
                            var Vip = $('.Vip', newDlg);
                            var dt = eval(data);
                            ID.val(dt.ID);
                            Username.val(dt.Ten);
                            Username.attr('_value', dt.Username);
                            if (dt.Admin) {
                                Admin.attr('checked', 'checked');
                            } else {
                                Admin.removeAttr('checked');
                            }
                            if (dt.Duyet) {
                                Duyet.attr('checked', 'checked');
                            } else {
                                Duyet.removeAttr('checked');
                            }
                            if (dt.Vip) {
                                Vip.attr('checked', 'checked');
                            } else {
                                Vip.removeAttr('checked');
                            }
                            suKienMgrFn.addpopThanhVienfn();
                        }
                    });
                }
            });
        });
    },
    deleteThanhVien: function (grid) {
        if (typeof (grid) == 'undefined') grid = '#suKienMgrMdlChiTiet-ThanhVien-List';
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
                    url: suKienMgrFn.urlDefault + '&subAct=delThanhVien',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(grid).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    loadHtmlThanhVien: function (fn) {
        var dlg = $('#suKienMgrMdl-ThanhVien-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cangtin.plugins.suKienMgr.Admin.thanhVien.htm")%>',
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
    },
    clearformThanhVien: function () {
        var newDlg = $('#suKienMgrMdl-ThanhVien-dlgNew');
        var ID = $('.ID', newDlg);
        var Username = $('.Username', newDlg);
        var Admin = $('.Admin', newDlg);
        var Duyet = $('.Duyet', newDlg);
        var Vip = $('.Vip', newDlg);
        newDlg.find('input, textarea').val('');
        newDlg.find('.admckb').removeAttr('checked');
        Username.attr('_value', '');

    },
    addpopThanhVienfn: function () {
        var newDlg = $('#suKienMgrMdl-ThanhVien-dlgNew');
        var Username = $('.Username', newDlg);

        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(Username, function (event, ui) {
                Username.val(ui.item.label);
                Username.attr('_value', ui.item.value);
            });
        });

    },
    saveThanhVien: function (validate, fn) {
        var newDlg = $('#suKienMgrMdl-ThanhVien-dlgNew');
        var _DV_ID = '';
        if (jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
            alert('Chọn nhóm ở trên');
            return false;
        }

        var ID = $('.ID', newDlg);
        var Username = $('.Username', newDlg);
        var Admin = $('.Admin', newDlg);
        var Duyet = $('.Duyet', newDlg);
        var Vip = $('.Vip', newDlg);

        var _ID = ID.val();
        var _Username = Username.attr('_value');
        var _Admin = Admin.is(':checked');
        var _Duyet = Duyet.is(':checked');
        var _Vip = Vip.is(':checked');

        var err = '';
        if (_Username == '') {
            err += 'Chọn thành viên<br/>';
        }

        if (err != '') {
            adm.loading(err);
            return false;
        }
        if (validate) {
            if (typeof (fn) == 'function') {
                fn();
            }
            return false;
        }

        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: suKienMgrFn.urlDefault + '&subAct=saveThanhVien',
            dataType: 'script',
            type: 'POST',
            data: {
                ID: _ID,
                Username: _Username,
                Admin: _Admin,
                Duyet: _Duyet,
                Vip: _Vip,
                SK_ID: _DV_ID,
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#suKienMgrMdlChiTiet-ThanhVien-List').trigger('reloadGrid');
                } else {
                    adm.loading('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    addAlbum: function () {
        var _DV_ID = '';
        if (jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
            alert('Chọn nhómở trên');
            return false;
        }
        AlbumMgrFn.Add(function () {
            $('#suKienMgrMdlAlbum-Album-list').trigger('reloadGrid');
            return;
        }, { P_RowId: _DV_ID });
    },
    editAlbum: function () {
        var _DV_ID = '';
        if (jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#suKienMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
            alert('Chọn nhómở trên');
            return false;
        }

        var _ab_id = '';
        if (jQuery('#suKienMgrMdlAlbum-Album-list').jqGrid('getGridParam', 'selrow') != null) {
            _ab_id = jQuery('#suKienMgrMdlAlbum-Album-list').jqGrid('getGridParam', 'selrow').toString();
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
            alert('Chọn nhómở trên');
            return false;
        }

        AlbumMgrFn.Edit(_ab_id, function () {
            $('#suKienMgrMdlAlbum-Album-list').trigger('reloadGrid');
            return false;
        }, { P_RowId: _DV_ID });
    },
    deleteAlbum: function (grid) {
        if (typeof (grid) == 'undefined') grid = '#suKienMgrMdlAlbum-Album-list';
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
    addpopfn: function () {

        var newDlg = $('#suKienMgrMdl-dlgNew');
        

        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var NgayBatDau = $('.NgayBatDau', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var MienPhi = $('.MienPhi', newDlg);
        var LePhi = $('.LePhi', newDlg);
        var LuotXem = $('.LuotXem', newDlg);
        var DangKy = $('.DangKy', newDlg);
        var Active = $('.Active', newDlg);
        var HauTruong = $('.HauTruong', newDlg);

        var lblAnh = $('.Anh', newDlg);
        
        var ulpFn = function() {
            var uploadTintucBtn = $('.Anh', newDlg);
            var uploadTintucView = $('.adm-uploadTintuc-preview-img', newDlg);
            var _params = { 'oldFile': $(uploadTintucBtn).attr('ref') };
            adm.upload(uploadTintucBtn, 'anh', _params, function(rs) {
                $(uploadTintucBtn).attr('ref', rs);
                $(uploadTintucView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function(f) {
            });
        };
        ulpFn();
        adm.createCkFull(NoiDung);
        adm.createCkFull(HauTruong);
        adm.createCkFull(GhiChu);
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'SU-KIEN-LOAI', DM_ID, function (event, ui) {
                DM_ID.attr('_value', ui.item.id);
            });
        });

        
        NgayBatDau.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });

        
    }
}
