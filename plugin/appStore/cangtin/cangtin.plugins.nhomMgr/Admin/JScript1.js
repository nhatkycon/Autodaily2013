var nhomMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cangtin.plugins.nhomMgr.Admin.Class1, cangtin.plugins.nhomMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu tin tức');
        adm.styleButton();
        var searchTxt = $('.mdl-head-search-tin');
        $('#nhomMgrMdl-List').jqGrid({
            url: nhomMgrFn.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Home','Hot', 'Loại', 'Cha', 'Tên', 'Người tạo', 'Ngày tạo'],
            colModel: [
            { name: 'NHOM_ID', key: true, sortable: true, hidden: true },
            { name: 'NHOM_Home', width: 3, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
            { name: 'NHOM_Hot', width: 3, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
            { name: 'NHOM_PID_ID', width: 10, sortable: true },
            { name: 'NHOM_DM_ID', width: 10, resizable: true, sortable: true},
            { name: 'NHOM_Ten', width: 40, resizable: true, sortable: true },
            { name: 'NHOM_NguoiTao', width: 10, resizable: true, sortable: true },
            { name: 'NHOM_NgayTao', width: 10, sortable: true }
        ],
            caption: 'Nhóm',
            autowidth: true,
            sortname: 'NHOM_NgayTao',
            sortorder: 'desc',
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#nhomMgrMdl-Pagerql'),
            onSelectRow: function (rowid) {
                nhomMgrFn.changeSubGrid(rowid);
            },
            loadComplete: function () {
                nhomMgrFn.loadSubGrid();
                adm.regType(typeof (AlbumMgrFn), 'appStore.pmSpa.desktop.controls.AlbumMgr.DanhSach, appStore.pmSpa.desktop.controls', function () {
                });
                adm.regType(typeof (blogMgrFn), 'appStore.commonStore.blogMgr.Admin.Class1, appStore.commonStore.blogMgr', function () {                    
                });
                adm.loading(null);
                if (typeof (Ajax_upload) == 'undefined') {
                    $.getScript('../js/ajaxupload.js', function () { });
                };
                adm.watermark(searchTxt, 'Tìm kiếm nhóm', function () {
                    $(searchTxt).val('');
                    nhomMgrFn.search();
                    $(searchTxt).val('Tìm kiếm nhóm');
                });
            }
        });
    },
    loadSubGrid: function () {
        $('.nhomMgrMdl-subMdl-list').tabs({
            show: function (event, ui) {
                if (ui.index == '0') {
                    $('#nhomMgrMdlChiTiet-ThanhVien-List').jqGrid({
                        url: nhomMgrFn.urlDefault + '&subAct=getThanhVien&PID_ID=',
                        height: '400',
                        datatype: 'json',
                        colNames: ['ID','Duyệt','Admin','Vip','Mod',  'Tên', 'Username', 'Mobile','Ngày tạo'],
                        colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true },
                        { name: 'Duyet', width: 3, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                        { name: 'Admin', width: 3, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                        { name: 'Vip', width: 3, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
                        { name: 'Mod', width: 3, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
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
                        pager: jQuery('#nhomMgrMdlChiTiet-ThanhVien-Pager'),
                        onSelectRow: function (rowid) { },
                        loadComplete: function () { adm.loading(null); }
                    });
                }
                else if (ui.index == '1') {
                    adm.regType(typeof (AlbumMgrFn), 'appStore.pmSpa.desktop.controls.AlbumMgr.DanhSach, appStore.pmSpa.desktop.controls', function () {
                        AlbumMgrFn.loadGrid('#nhomMgrMdlAlbum-Album-list', function () {
                        });
                    });
                }
                else if (ui.index == '2') {
                    adm.regType(typeof (blogMgrFn), 'appStore.commonStore.blogMgr.Admin.Class1, appStore.commonStore.blogMgr', function () {
                        blogMgrFn.loadgrid('#blogMgrMdlAlbum-SubMdl-list', function () {
                        });
                    });
                }
            }
        });
    },
    changeSubGrid: function (_id) {
        $('#nhomMgrMdlChiTiet-ThanhVien-List').jqGrid('setGridParam', { url: nhomMgrFn.urlDefault + '&subAct=getThanhVien&PID_ID=' + _id }).trigger('reloadGrid');
        $('#nhomMgrMdlAlbum-Album-list').jqGrid('setGridParam', { url: AlbumMgrFn.urlDefault().toString() + '&subAct=getGrid&P_RowId=' + _id }).trigger('reloadGrid');
        $('#blogMgrMdlAlbum-SubMdl-list').jqGrid('setGridParam', { url: blogMgrFn.urlDefault + '&subAct=get&PID_ID=' + _id }).trigger('reloadGrid');
    },
    add: function () {
        nhomMgrFn.loadHtml(function () {
            var newDlg = $('#nhomMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1000,
                position: [200, 0],
                //     modal: true,
                buttons: {
                    'Lưu': function () {
                        nhomMgrFn.save(false, function () {
                            nhomMgrFn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        nhomMgrFn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {

                    adm.styleButton();
                    nhomMgrFn.clearform();
                    nhomMgrFn.addpopfn();
                }
                ,
                beforeclose: function () {
                    nhomMgrFn.clearform();
                }
            });
        });
    },
    edit: function () {
        var s = '';
        if (jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                nhomMgrFn.loadHtml(function () {
                    var newDlg = $('#nhomMgrMdl-dlgNew');

                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 1000,

                        position: [200, 0],
                        //  modal: true,
                        buttons: {
                            'Lưu': function () {
                                nhomMgrFn.save(false, function () {
                                    nhomMgrFn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                nhomMgrFn.save(false, function () {
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
                            nhomMgrFn.addpopfn();
                            nhomMgrFn.clearform();
                            $.ajax({
                                url: nhomMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#nhomMgrMdl-dlgNew');
                                    
                                    var ID = $('.ID', newDlg);
                                    var PID_ID = $('.PID_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var GioiThieu = $('.GioiThieu', newDlg);
                                    var Anh = $('.Anh', newDlg);
                                    var Home = $('.Home', newDlg);
                                    var Hot = $('.Hot', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    
                                    var imgAnh = $('.adm-uploadTintuc-preview-img', newDlg);
                                    var Anh = $('.Anh', newDlg);

                                    imgAnh.attr('src', '');
                                    Anh.attr('ref', '');

                                    Anh.attr('ref', data.Anh);
                                    imgAnh.attr('src', '../up/i/' + data.Anh + '?ref=' + Math.random());
                                    
                                    ID.val(data.ID);
                                    DM_ID.val(data.DM_Ten);
                                    DM_ID.attr('_value', data.DM_ID);
                                    PID_ID.val(data.PID_Ten);
                                    PID_ID.attr('_value', data.PID_ID);
                                    
                                    Ten.val(data.Ten);
                                    MoTa.val(data.MoTa);
                                    GioiThieu.val(data.GioiThieu);
                                    if (data.Home) {
                                        Home.attr('checked', 'checked');
                                    } else {
                                        Home.removeAttr('checked');
                                    }
                                    if (data.Hot) {
                                        Hot.attr('checked', 'checked');
                                    } else {
                                        Hot.removeAttr('checked');
                                    }
                                    ThuTu.val(data.ThuTu);
                                    
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
        s = jQuery("#nhomMgrMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
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
                            var treedata = $("#nhomMgrMdl-List").jqGrid('getRowData', ss[j]);
                            ll += treedata.SK_ID + ',';
                        }                        
                    }                    
                }
            }
            $.ajax({
                url: nhomMgrFn.urlDefault + '&subAct=del',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#nhomMgrMdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    duyet: function (st) {
        var s = '';
        s = jQuery("#nhomMgrMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#nhomMgrMdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: nhomMgrFn.urlDefault + '&subAct=duyet&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#nhomMgrMdl-List").trigger('reloadGrid');
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
            $('#nhomMgrMdl-List').jqGrid('setGridParam', { url: nhomMgrFn.urlDefault + "&subAct=get&q=" + q + "&DMID=" + dm }).trigger("reloadGrid");
        }, 500);
    },
    save: function (validate, fn) {
        var newDlg = $('#nhomMgrMdl-dlgNew');
        
        var ID = $('.ID', newDlg);
        var PID_ID = $('.PID_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var GioiThieu = $('.GioiThieu', newDlg);
        var Anh = $('.Anh', newDlg);
        var Home = $('.Home', newDlg);
        var Hot = $('.Hot', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        
        var _ID = ID.val();
        var _PID_ID = PID_ID.attr('_value');
        var _Ten = Ten.val();
        var _MoTa = MoTa.val();
        var _GioiThieu = GioiThieu.val();
        var _Anh = Anh.attr('ref');
        var _Home = Home.is(':checked');
        var _Hot = Hot.is(':checked');
        var _ThuTu = ThuTu.val();
        var _DM_ID = DM_ID.attr('_value');
        
        var err = '';
        if (_ThuTu == '')
            _ThuTu = '0';
        
        if (_ThuTu == '') { _ThuTu = '0'; } else { if (!adm.isInt(_ThuTu)) { err += 'Nhập thứ tự kiểu số<br/>'; } }

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
            url: nhomMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                ID: _ID,
                PID_ID: _PID_ID,
                Ten: _Ten,
                MoTa: _MoTa,
                GioiThieu: _GioiThieu,
                Anh: _Anh,
                Home: _Home,
                Hot: _Hot,
                ThuTu: _ThuTu,
                DM_ID: _DM_ID
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#nhomMgrMdl-List').trigger('reloadGrid');
                } else {
                    adm.loading('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    clearform: function () {
        var newDlg = $('#nhomMgrMdl-dlgNew');

        var lblAnh = $('.Anh', newDlg);
        lblAnh.removeAttr('ref');
        lblAnh.attr('ref', '');
        lblAnh.prev().find('img').removeAttr('src');
        lblAnh.prev().find('img').attr('src','xx');
        lblAnh.prev().find('img').attr('src','');
        
        var ID = $('.ID', newDlg);
        var PID_ID = $('.PID_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var GioiThieu = $('.GioiThieu', newDlg);
        var Anh = $('.Anh', newDlg);
        var Home = $('.Home', newDlg);
        var Hot = $('.Hot', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        
        newDlg.find('input, textarea').val('');
        DM_ID.attr('_value', '');
        PID_ID.attr('_value', '');

    },
    loadHtml: function (fn) {
        var dlg = $('#nhomMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cangtin.plugins.nhomMgr.Admin.htm.htm")%>',
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
    autoComplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'nhomMgrFn-autoCompleteLangBased' + request.term;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: nhomMgrFn.urlDefault,
                    dataType: 'script',
                    data: { 'subAct': 'autoComplete', 'q': request.term},
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
                                        id: item.ID
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
				            .append('<a style=\"margin-left:' + (parseInt(item.level) * 10) + 'px;\">' + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    addAlbum: function () {
        var _DV_ID = '';
        if (jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
            $('#nhomMgrMdlAlbum-Album-list').trigger('reloadGrid');
            return;
        }, { P_RowId: _DV_ID });
    },
    editAlbum: function () {
        var _DV_ID = '';
        if (jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
        if (jQuery('#nhomMgrMdlAlbum-Album-list').jqGrid('getGridParam', 'selrow') != null) {
            _ab_id = jQuery('#nhomMgrMdlAlbum-Album-list').jqGrid('getGridParam', 'selrow').toString();
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
            $('#nhomMgrMdlAlbum-Album-list').trigger('reloadGrid');
            return false;
        }, { P_RowId: _DV_ID });
    },
    deleteAlbum: function (grid) {
        if (typeof (grid) == 'undefined') grid = '#nhomMgrMdlAlbum-Album-list';
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
    addBlog: function () {
        var _DV_ID = '';
        if (jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
        blogMgrFn.add(function () {
            $('#blogMgrMdlAlbum-SubMdl-list').trigger('reloadGrid');
            return false;
        }, { PID_ID: _DV_ID });
    },
    editBlog: function () {
        var _DV_ID = '';
        if (jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
        if (jQuery('#blogMgrMdlAlbum-SubMdl-list').jqGrid('getGridParam', 'selrow') != null) {
            _ab_id = jQuery('#blogMgrMdlAlbum-SubMdl-list').jqGrid('getGridParam', 'selrow').toString();
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

        blogMgrFn.edit(_ab_id, function () {
            $('#blogMgrMdlAlbum-SubMdl-list').trigger('reloadGrid');
            return false;
        }, { PID_ID: _DV_ID });
    },
    deleteBlog: function () {
        blogMgrFn.del(function () {
            $('#blogMgrMdlAlbum-SubMdl-list').trigger('reloadGrid');
            return false;
        }, '#blogMgrMdlAlbum-SubMdl-listt');
    },
    addThanhVien: function () {
        var _DV_ID = '';
        if (jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
        nhomMgrFn.loadHtmlThanhVien(function () {
            adm.styleButton();
            var newDlg = $('#nhomMgrMdl-ThanhVien-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm thành viên',
                modal: true,
                width: 500,
                buttons: {
                    'Lưu': function () {
                        nhomMgrFn.saveThanhVien(false, function () {
                            nhomMgrFn.clearformThanhVien();
                        });
                    },
                    'Lưu và đóng': function () {
                        nhomMgrFn.saveThanhVien(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    nhomMgrFn.clearformThanhVien();
                    nhomMgrFn.addpopThanhVienfn();
                }
            });
        });
    },
    editThanhVien: function () {
        var _DV_ID = '';
        if (jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
        if (jQuery('#nhomMgrMdlChiTiet-ThanhVien-List').jqGrid('getGridParam', 'selrow') != null) {
            _ab_id = jQuery('#nhomMgrMdlChiTiet-ThanhVien-List').jqGrid('getGridParam', 'selrow').toString();
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

        nhomMgrFn.loadHtmlThanhVien(function () {
            adm.styleButton();
            var newDlg = $('#nhomMgrMdl-ThanhVien-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm thành viên',
                modal: true,
                width: 500,
                buttons: {
                    'Lưu': function () {
                        nhomMgrFn.saveThanhVien(false, function () {
                            nhomMgrFn.clearformThanhVien();
                        });
                    },
                    'Lưu và đóng': function () {
                        homMgrFn.saveThanhVien(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    nhomMgrFn.clearformThanhVien();
                    adm.loading('Đang nạp dữ liệu');
                    $.ajax({
                        url: nhomMgrFn.urlDefault + '&subAct=editThanhVien',
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
                            var Mod = $('.Mod', newDlg);
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
                            if (dt.Mod) {
                                Mod.attr('checked', 'checked');
                            } else {
                                Mod.removeAttr('checked');
                            }
                            nhomMgrFn.addpopThanhVienfn();
                        }
                    });
                }
            });
        });
    },
    deleteThanhVien: function (grid) {
        if (typeof (grid) == 'undefined') grid = '#nhomMgrMdlChiTiet-ThanhVien-List';
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
                    url: nhomMgrFn.urlDefault + '&subAct=delThanhVien',
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
        var dlg = $('#nhomMgrMdl-ThanhVien-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cangtin.plugins.nhomMgr.Admin.thanhVien.htm")%>',
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
        var newDlg = $('#nhomMgrMdl-ThanhVien-dlgNew');
        var ID = $('.ID', newDlg);
        var Username = $('.Username', newDlg);
        var Admin = $('.Admin', newDlg);
        var Duyet = $('.Duyet', newDlg);
        var Vip = $('.Vip', newDlg);
        var Mod = $('.Mod', newDlg);
        newDlg.find('input, textarea').val('');
        newDlg.find('.admckb').removeAttr('checked');
        Username.attr('_value', '');

    },
    addpopThanhVienfn: function () {
        var newDlg = $('#nhomMgrMdl-ThanhVien-dlgNew');
        var ID = $('.ID', newDlg);
        var Username = $('.Username', newDlg);
        
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(Username, function (event, ui) {
                Username.val(ui.item.label);
                Username.attr('_value', ui.item.value);
            });
        });
       
    },
    saveThanhVien: function (validate, fn) {
        var newDlg = $('#nhomMgrMdl-ThanhVien-dlgNew');
        var _DV_ID = '';
        if (jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            _DV_ID = jQuery('#nhomMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
        var Mod = $('.Mod', newDlg);

        var _ID = ID.val();
        var _Username = Username.attr('_value');
        var _Admin = Admin.is(':checked');
        var _Duyet = Duyet.is(':checked');
        var _Vip = Vip.is(':checked');
        var _Mod = Mod.is(':checked');

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
            url: nhomMgrFn.urlDefault + '&subAct=saveThanhVien',
            dataType: 'script',
            type: 'POST',
            data: {
                ID: _ID,
                Username: _Username,
                Admin: _Admin,
                Duyet: _Duyet,
                Vip: _Vip,
                Mod: _Mod,
                NHOM_ID: _DV_ID,
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#nhomMgrMdlChiTiet-ThanhVien-List').trigger('reloadGrid');
                } else {
                    adm.loading('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    addpopfn: function () {
        var newDlg = $('#nhomMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var PID_ID = $('.PID_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var GioiThieu = $('.GioiThieu', newDlg);
        var Anh = $('.Anh', newDlg);
        var Home = $('.Home', newDlg);
        var Hot = $('.Hot', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var DM_ID = $('.DM_ID', newDlg);

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
        adm.createCkFull(GioiThieu);
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'NHOM-LOAI', DM_ID, function (event, ui) {
                DM_ID.attr('_value', ui.item.id);
            });
        });
        nhomMgrFn.autoComplete(PID_ID, function (event, ui) {
            PID_ID.attr('_value', ui.item.id);
        });
    }
}
