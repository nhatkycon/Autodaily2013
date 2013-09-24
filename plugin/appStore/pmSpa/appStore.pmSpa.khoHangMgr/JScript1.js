var KhoHangMgrFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.khoHangMgr.Class1, appStore.pmSpa.khoHangMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        $('#KhoHangMgrMdl-List').jqGrid({
            url: KhoHangMgrFn.urlDefault().toString() + '&subAct=get',
            height: '1000',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mã', 'Tên', 'Địa chỉ', 'Khu vực'],
            colModel: [
                { name: 'ID', key: true, width: 1, sortable: true, hidden: true },
                { name: 'Ma', width: 10, sortable: true },
                { name: 'Ten', width: 40, sortable: true },
                { name: 'DiaChi', width: 40, sortable: true },
                { name: 'KhuVuc', width: 10, sortable: true }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'Ten',
            sortorder: 'asc',
            rowNum: 10000,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#KhoHangMgrMdl-List';

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
                KhoHangMgrFn.loadHtml(function () {
                    var newDlg = $('#KhoHangMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        buttons: {
                            'Lưu': function () {
                                KhoHangMgrFn.save(false, function () {
                                    KhoHangMgrFn.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                KhoHangMgrFn.save(false, function () {
                                    KhoHangMgrFn.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            KhoHangMgrFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            KhoHangMgrFn.clearform();
                            KhoHangMgrFn.popfn();
                            $.ajax({
                                url: KhoHangMgrFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);

                                    var newDlg = $('#KhoHangMgrMdl-dlgNew');
                                    var ID = $('.ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var DiaChi = $('.DiaChi', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var KV_ID = $('.KV_ID', newDlg);
                                    
                                    var admMsg = $('.admMsg', newDlg);



                                    ID.val(dt.ID);
                                    Ma.val(dt.Ma);
                                    Ten.val(dt.Ten);
                                    DiaChi.val(dt.DiaChi);
                                    KV_ID.val(dt.KV_Ten);
                                    KV_ID.attr('_value',dt.KV_ID);
                                    
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function (fn) {
        KhoHangMgrFn.loadHtml(function () {
            var newDlg = $('#KhoHangMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        KhoHangMgrFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            KhoHangMgrFn.clearform();
                        }, '#KhoHangMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        KhoHangMgrFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            $(newDlg).dialog('close');
                        }, '#KhoHangMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    KhoHangMgrFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    KhoHangMgrFn.clearform();
                    KhoHangMgrFn.popfn();
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#KhoHangMgrMdl-List';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa mẩu tin này?')) {// Xác nhận xem có xóa hay không
                    $.ajax({
                        url: KhoHangMgrFn.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: { 'ID': s },
                        success: function (dt) {
                            jQuery(grid).trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn, grid) {
        if (typeof (grid) == 'undefined') grid == '#KhoHangMgrMdl-List';
        var newDlg = $('#KhoHangMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var Ma = $('.Ma', newDlg);
        var KV_ID = $('.KV_ID', newDlg);
        var admMsg = $('.admMsg', newDlg);


        //region bien
        var _ID = ID.val();
        var _Ten = Ten.val();
        var _DiaChi = DiaChi.val();
        var _Ma = Ma.val();
        var _KV_ID = KV_ID.attr('_value');

        var err = '';
        if (_Ten == '') { err += 'Nhập tên<br/>'; };

        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: KhoHangMgrFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                ID: _ID,
                Ten: _Ten,
                DiaChi: _DiaChi,
                Ma: _Ma,
                KV_ID: _KV_ID
            },
            success: function(dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof(fn) == 'function') {
                        fn(_ID, _Ten);
                    }
                    $(grid).trigger('reloadGrid');
                } else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },    
    popfn: function () {
        var newDlg = $('#KhoHangMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var Ma = $('.Ma', newDlg);
        var KV_ID = $('.KV_ID', newDlg);
        adm.regType(typeof(danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function() {
            danhmuc.autoCompleteLangBased('', 'KHUVUC', KV_ID, function (event, ui) {
                KV_ID.attr('_value', ui.item.id);
            });
        });
        
    },
    clearform: function () {
        var newDlg = $('#KhoHangMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var Ma = $('.Ma', newDlg);
        var KV_ID = $('.KV_ID', newDlg);
        
        var admMsg = $('.admMsg', newDlg);
        KV_ID.attr('_value', '');
        admMsg.html('');
        newDlg.find('input, textarea').val('');
    },
    autoComplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'khachHangMgr-autoCompleteSearch' + request.term;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: KhoHangMgrFn.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'search', 'q': request.term },
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
                                        KhuVuc_Ten: item.KhuVuc_Ten
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
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a href=\"javascript:;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    autoCompleteByHangHoa: function (el, hh_id, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'khachHangMgr-autoCompleteByHangHoa' + hh_id;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: KhoHangMgrFn.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'searchByHangHoa', 'HH_ID': hh_id },
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
                                        ma: item.Ma,
                                        soLuong : item.SoLuong,
                                        KhuVuc_Ten: item.KhuVuc_Ten
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
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a href=\"javascript:;\">" + item.label + " -  <b>" + item.soLuong  + "<b/></a>")
				            .appendTo(ul);
        };
    },
    loadHtml: function (fn) {
        var dlg = $('#KhoHangMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.khoHangMgr.htm.htm")%>',
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
