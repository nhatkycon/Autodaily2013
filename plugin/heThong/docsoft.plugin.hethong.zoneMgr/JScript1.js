var zoneMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.zoneMgr.Class1, docsoft.plugin.hethong.zoneMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu danh mục');
        $('.sub-mdl').tabs();
        adm.styleButton();
        $('#zoneMgrFnMdl-List').jqGrid({
            url: zoneMgrFn.urlDefault + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Trang', 'Mã', 'ID khách', 'Thứ tự', 'Dài', 'Css'],
            colModel: [
            { name: 'Z_ID', key: true, sortable: true, hidden: true },
            { name: 'Z_PG_ID', width: 40, resizable: true, sortable: true },
            { name: 'Z_Ma', width: 10, sortable: true },
            { name: 'Z_SID', width: 10, sortable: true },
            { name: 'Z_ThuTu', width: 10, resizable: true, sortable: true },
            { name: 'Z_Width', width: 10, resizable: true, sortable: true },
            { name: 'Z_CssClass', width: 10, resizable: true, sortable: true }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'Z_ID',
            sortorder: 'asc',
            rowNum: 10000,
            //            rowNum: 20,
            //            rowList: [5, 10, 20, 30],
            //            pager: jQuery('#zoneMgrFnMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#zoneMgrFnMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                adm.regQS(searchTxt, 'zoneMgrFnMdl-List');
            }
        });
        var filterLoaiDanhMucID = $('.mdl-head-filterloaizoneMgrFn');
        var searchTxt = $('.mdl-head-search-zoneMgrFn');
    },
    edit: function (grid) {
        var s = '';
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
                zoneMgrFn.loadHtml(function () {
                    var newDlg = $('#zoneMgrFnMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 800,
                        buttons: {
                            'Lưu': function () {
                                zoneMgrFn.save(false, function () {
                                    zoneMgrFn.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                zoneMgrFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            zoneMgrFn.clearform();
                            zoneMgrFn.popfn();
                            $.ajax({
                                url: zoneMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    '_ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var PG_ID = $('.PG_ID', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var Width = $('.Width', newDlg);
                                    var SID = $('.SID', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var CssClass = $('.CssClass', newDlg);
                                    var HtmlAfter = $('.HtmlAfter', newDlg);
                                    var HtmlBefore = $('.HtmlBefore', newDlg);

                                    var spbMsg = $('.admMsg', newDlg);
                                    ID.val(dt.ID);
                                    PG_ID.val(dt.PG_Ten);
                                    PG_ID.attr('_value', dt.PG_ID);
                                    Ma.val(dt.Ma);
                                    SID.val(dt.SID);
                                    ThuTu.val(dt.ThuTu);
                                    Width.val(dt.Width);
                                    CssClass.val(dt.CssClass);
                                    HtmlAfter.val(dt.HtmlAfter);
                                    HtmlBefore.val(dt.HtmlBefore);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function (grid) {
        var s = '';
        if (jQuery(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa danh mục này?')) {
                    $.ajax({
                        url: zoneMgrFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            '_ID': s
                        },
                        success: function (dt) {
                            jQuery(grid).trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn, grid) {
        var newDlg = $('#zoneMgrFnMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var PG_ID = $('.PG_ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Width = $('.Width', newDlg);
        var SID = $('.SID', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var CssClass = $('.CssClass', newDlg);
        var HtmlAfter = $('.HtmlAfter', newDlg);
        var HtmlBefore = $('.HtmlBefore', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _PG_ID = PG_ID.attr('_value');
        var _Ma = Ma.val();
        var _SID = SID.val();
        var _ThuTu = ThuTu.val();
        var _CssClass = CssClass.val();
        var _Width = Width.val();
        var _HtmlAfter = HtmlAfter.val();
        var _HtmlBefore = HtmlBefore.val();

        var err = '';
        if (_Ma == '') {
            err += 'Nhập Mã<br/>';
        }
        if (err != '') {
            spbMsg.html(err);
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
            url: zoneMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                '_ID': _ID, '_PG_ID': _PG_ID, '_Ma': _Ma,
                '_SID': _SID, '_ThuTu': _ThuTu, '_CssClass': _CssClass, '_Width': _Width,
                '_HtmlBefore': _HtmlBefore, '_HtmlAfter': _HtmlAfter
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery(grid).trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    search: function () {
    },
    add: function () {
        zoneMgrFn.loadHtml(function () {
            var newDlg = $('#zoneMgrFnMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 800,
                buttons: {
                    'Lưu': function () {
                        zoneMgrFn.save(false, function () {
                            zoneMgrFn.clearform();
                        }, '#zoneMgrFnMdl-List');
                    },
                    'Lưu và đóng': function () {
                        zoneMgrFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#zoneMgrFnMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    zoneMgrFn.clearform();
                    zoneMgrFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#zoneMgrFnMdl-dlgNew');
        var PG_ID = $('.PG_ID', newDlg);
        adm.regType(typeof (pagesMgrFn), 'docsoft.plugin.hethong.pagesMgr.Class1, docsoft.plugin.hethong.pagesMgr', function () {
            pagesMgrFn.autoComplete(PG_ID, function (event, ui) {
                PG_ID.val(ui.item.label);
                PG_ID.attr('_value', ui.item.id);
            });
            $(PG_ID).unbind('click').click(function () {
                $(PG_ID).autocomplete('search', '');
            });
        });

        var HtmlAfter = $('.HtmlAfter', newDlg);
        var HtmlBefore = $('.HtmlBefore', newDlg);
        adm.createFck(HtmlAfter);
        adm.createFck(HtmlBefore);
    },
    clearform: function (news) {
        var newDlg = $('#zoneMgrFnMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var PG_ID = $('.PG_ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var SID = $('.SID', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var CssClass = $('.CssClass', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var Width = $('.Width', newDlg);
        var HtmlAfter = $('.HtmlAfter', newDlg);
        var HtmlBefore = $('.HtmlBefore', newDlg);
        spbMsg.html('');
        $('input, textarea', newDlg).val('');
        PG_ID.attr('_value', '');
    },
    timer: null,
    autoComplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'zoneMgrFn-autoComplete';
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                ma: item.Ma
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: zoneMgrFn.urlDefault + '&subAct=autoComplete',
                    dataType: 'script',
                    data: {
                },
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
                                    ma: item.Ma
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
				            .append("<a>" + item.ma + ": " + item.label + "</a>")
				            .appendTo(ul);
    };
},
autoCompleteMultiple: function (s, el, fn) {
    function split(val) {
        return val.split(/;\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }
    $(el).autocomplete({
        source: function (request, response) {
            var term = 'zoneMgrFn-autoCompleteMultiple';
            if (term in _cache) {
                var matcher = new RegExp($.ui.autocomplete.escapeRegex(extractLast(request.term)), "i");
                response($.map(_cache[term], function (item) {
                    if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                        return {
                            label: item.Ten,
                            value: item.Ten,
                            id: item.ID,
                            ma: item.Ma
                        }
                    }
                }))
                return;
            }

            adm.loading('Nạp danh sách');
            _lastXhr = $.ajax({
                url: zoneMgrFn.urlDefault + '&subAct=getPidByDm',
                dataType: 'script',
                data: {
            },
            success: function (dt, status, xhr) {
                adm.loading(null);
                var data = eval(dt);
                _cache[term] = data;
                if (xhr === _lastXhr) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(extractLast(request.term)), "i");
                    response($.map(data, function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                ma: item.Ma
                            }
                        }
                    }))
                }
            }
        });
    },
    minLength: 0,
    select: function (event, ui) {
        var terms = split(this.value);
        // remove the current input
        terms.pop();
        // add the selected item
        terms.push(ui.item.value);
        // add placeholder to get the comma-and-space at the end
        terms.push('');
        this.value = terms.join('; ');
        fn(event, ui);
        return false;
    },
    focus: function () {
        return false;
    },
    change: function (event, ui) {
    },
    delay: 0
}).data("autocomplete")._renderItem = function (ul, item) {
    return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
};
},
loadHtml: function (fn) {
    var dlg = $('#zoneMgrFnMdl-dlgNew');
    if ($(dlg).length < 1) {
        adm.loading('Dựng from');
        $.ajax({
            url: '<%=WebResource("docsoft.plugin.hethong.zoneMgr.htm.htm")%>',
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
