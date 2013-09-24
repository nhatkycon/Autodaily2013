var pagesMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.pagesMgr.Class1, docsoft.plugin.hethong.pagesMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu danh mục');
        $('.sub-mdl').tabs();
        adm.styleButton();
        $('#pagesMgrMdl-List').jqGrid({
            url: pagesMgrFn.urlDefault + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Tên', 'Alias', 'KeyWords', 'Descriptions','Active'],
            colModel: [
            { name: 'PG_ID', key: true, sortable: true, hidden: true },
            { name: 'PG_Ten', width: 50, resizable: true, sortable: true },
            { name: 'PG_Alias', width: 5, sortable: true, align: "center" },
            { name: 'PG_KeyWords', width: 10, resizable: true, sortable: true },
            { name: 'PG_Descriptions', width: 10, resizable: true, sortable: true },
            { name: 'PG_Active', width: 15, resizable: true, sortable: true, formatter: 'checkbox' }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'PG_ID',
            sortorder: 'asc',
            rowNum: 10000,
            //            rowNum: 20,
            //            rowList: [5, 10, 20, 30],
            //            pager: jQuery('#pagesMgrMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#pagesMgrMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                adm.regQS(searchTxt, 'pagesMgrMdl-List');
            }
        });
        var filterLoaiDanhMucID = $('.mdl-head-filterloaipagesMgrFn');
        var searchTxt = $('.mdl-head-search-pagesMgrFn');
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
                pagesMgrFn.loadHtml(function () {
                    var newDlg = $('#pagesMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                pagesMgrFn.save(false, function () {
                                    pagesMgrFn.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                pagesMgrFn.save(false, function () {
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
                            pagesMgrFn.clearform();
                            $.ajax({
                                url: pagesMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    '_ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var KeyWords = $('.KeyWords', newDlg);
                                    var Descriptions = $('.Descriptions', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    Ten.val(dt.Ten);
                                    Alias.val(dt.Alias);
                                    KeyWords.val(dt.KeyWords);
                                    Descriptions.val(dt.Descriptions);
                                    if (dt.Active) { Active.attr('checked', 'checked'); }
                                    else { Active.removeAttr('checked'); }
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
                        url: pagesMgrFn.urlDefault + '&subAct=del',
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
        var newDlg = $('#pagesMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Alias = $('.Alias', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Descriptions = $('.Descriptions', newDlg);
        var Active = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _Ten = Ten.val();
        var _Alias = Alias.val();
        var _KeyWords = KeyWords.val();
        var _Descriptions = Descriptions.val();
        var _Active = Active.is(':checked');

        var err = '';
        if (_Ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (_Alias == '') {
            err += 'Nhập Alias<br/>';
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
            url: pagesMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                '_ID': _ID, '_Ten': _Ten, '_Alias': _Alias,
                '_KeyWords': _KeyWords, '_Active': _Active, '_Descriptions': _Descriptions
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
        pagesMgrFn.loadHtml(function () {
            var newDlg = $('#pagesMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        pagesMgrFn.save(false, function () {
                            pagesMgrFn.clearform();
                        }, '#pagesMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        pagesMgrFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#pagesMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    pagesMgrFn.clearform();
                }
            });
        });
    },
    clearform: function (news) {
        var newDlg = $('#pagesMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Alias = $('.Alias', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Descriptions = $('.Descriptions', newDlg);
        var Active = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        spbMsg.html('');
        $('input, textarea', newDlg).val('');
    },
    timer: null,
    autoComplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'pagesMgrFn-autoComplete';
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                ma: item.Alias
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: pagesMgrFn.urlDefault + '&subAct=autoComplete',
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
                                    ma: item.Alias
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
            var term = 'pagesMgrFn-autoCompleteMultiple';
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
                url: pagesMgrFn.urlDefault + '&subAct=getPidByDm',
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
    var dlg = $('#pagesMgrMdl-dlgNew');
    if ($(dlg).length < 1) {
        adm.loading('Dựng from');
        $.ajax({
            url: '<%=WebResource("docsoft.plugin.hethong.pagesMgr.htm.htm")%>',
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
