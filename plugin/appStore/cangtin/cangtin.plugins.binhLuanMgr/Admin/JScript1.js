var binhLuanMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cangtin.plugins.binhLuanMgr.Admin.Class1, cangtin.plugins.binhLuanMgr',
    setup: function () {
    },
    loadgrid: function () {

        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        var searchTxt = $('.mdl-head-search-tin');
        $('#binhLuanMgrMdl-List').jqGrid({
            url: binhLuanMgrFn.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Người tạo', 'Nội dung', 'Ngày', 'Duyệt','Link'],
            colModel: [
            { name: 'BL_ID', key: true, sortable: true, hidden: true },
            { name: 'BL_NguoiTao', width: 10, sortable: true},
            { name: 'BL_Ten', width: 70, resizable: true, sortable: true},
            { name: 'BL_NgayTao', width: 10, resizable: true, sortable: true },
            { name: 'BL_Duyet', width: 5, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
            { name: 'BL_Link', width: 5, resizable: true, sortable: true, align: "center" }
        ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'BL_NgayTao',
            sortorder: 'desc',
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#binhLuanMgrMdl-Pagerql'),
            onSelectRow: function (rowid) {

            },
            loadComplete: function () {
                adm.loading(null);
                adm.watermark(searchTxt, 'Tìm kiếm', function () {
                    $(searchTxt).val('');
                    binhLuanMgrFn.search();
                    $(searchTxt).val('Tìm kiếm');
                });
            }
        });
    },
    add: function () {
        binhLuanMgrFn.loadHtml(function () {
            var newDlg = $('#binhLuanMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                position: [200, 0],
                //     modal: true,
                buttons: {
                    'Lưu': function () {
                        binhLuanMgrFn.save(false, function () {
                            binhLuanMgrFn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        binhLuanMgrFn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {

                    adm.styleButton();
                    binhLuanMgrFn.clearform();
                    binhLuanMgrFn.addpopfn();
                }
                ,
                beforeclose: function () {
                    binhLuanMgrFn.clearform();
                }
            });
        });
    },
    edit: function () {
        var s = '';
        if (jQuery('#binhLuanMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#binhLuanMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                binhLuanMgrFn.loadHtml(function () {
                    var newDlg = $('#binhLuanMgrMdl-dlgNew');

                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,

                        position: [200, 0],
                        //  modal: true,
                        buttons: {
                            'Lưu': function () {
                                binhLuanMgrFn.save(false, function () {
                                    binhLuanMgrFn.clearform();
                                });
                            },
                            'Lưu và đóng': function () {
                                binhLuanMgrFn.save(false, function () {
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
                            binhLuanMgrFn.clearform();
                            $.ajax({
                                url: binhLuanMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#binhLuanMgrMdl-dlgNew');
                            
                                    
                                    var ID = $('.ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var Url = $('.Url', newDlg);
                                    var Duyet = $('.Duyet', newDlg);
                                    
                                    ID.val(data.ID);
                                    Url.attr('Url', data.Url);
                                    Ten.val(data.Ten);
                                    NoiDung.val(data.NoiDung);
                                    if (data.Duyet) {
                                        Duyet.attr('checked', 'checked');
                                    } else {
                                        Duyet.removeAttr('checked');
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
        s = jQuery("#binhLuanMgrMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa những mẩu tin này?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    if (ss[j] != '') {
                        if (ss[j] != '') {
                            var treedata = $("#binhLuanMgrMdl-List").jqGrid('getRowData', ss[j]);
                            ll += treedata.BL_ID + ',';
                        }                        
                    }                    
                }
            }
            $.ajax({
                url: binhLuanMgrFn.urlDefault + '&subAct=del',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#binhLuanMgrMdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    duyet: function (st) {
        var s = '';
        s = jQuery("#binhLuanMgrMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để duyệt');
        }
        else {
            if (confirm('Bạn có chắc chắn duyệt những này?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    if (ss[j] != '') {
                        if (ss[j] != '') {
                            var treedata = $("#binhLuanMgrMdl-List").jqGrid('getRowData', ss[j]);
                            ll += treedata.BL_ID + ',';
                        }
                    }
                }
            }
            $.ajax({
                url: binhLuanMgrFn.urlDefault + '&subAct=duyet&Duyet=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#binhLuanMgrMdl-List").trigger('reloadGrid');
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
            $('#binhLuanMgrMdl-List').jqGrid('setGridParam', { url: binhLuanMgrFn.urlDefault + "&subAct=get&q=" + q + "&DMID=" + dm }).trigger("reloadGrid");
        }, 500);
    },
    save: function (validate, fn) {
        var newDlg = $('#binhLuanMgrMdl-dlgNew');
        
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Url = $('.Url', newDlg);
        var Duyet = $('.Duyet', newDlg);

        var _ID = ID.val();
        var _Ten = Ten.val();
        var _NoiDung = NoiDung.val();
        var _Duyet = MienPhi.is(':checked');
        
        var err = '';

        if (_Ten == '') {
            err += 'Nhập tên<br/>';
        }

        if (_NoiDung == '') {
            err += 'Nhập nội dung<br/>';
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
            url: binhLuanMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                ID: _ID,
                Ten: _Ten,
                NoiDung: _NoiDung,
                Duyet: _Duyet
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#binhLuanMgrMdl-List').trigger('reloadGrid');
                } else {
                    adm.loading('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    clearform: function () {
        var newDlg = $('#binhLuanMgrMdl-dlgNew');
        
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Url = $('.Url', newDlg);
        var Duyet = $('.Duyet', newDlg);

        Duyet.removeAttr('checked');
        Url.attr('src', '');
        newDlg.find('input, textarea').val('');

    },
    loadHtml: function (fn) {
        var dlg = $('#binhLuanMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cangtin.plugins.binhLuanMgr.Admin.htm.htm")%>',
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
    addpopfn: function () {
        var newDlg = $('#binhLuanMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Url = $('.Url', newDlg);
        var Duyet = $('.Duyet', newDlg);
        adm.createCkFull(NoiDung);
    }
}
