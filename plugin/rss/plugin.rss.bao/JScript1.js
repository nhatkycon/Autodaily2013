var baoFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.rss.bao.Class1, plugin.rss.bao',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#baoMdl-List').jqGrid({
            url: baoFn.urlDefault + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Tên', 'Url', 'RssUrl'],
            colModel: [
            { name: 'B_ID', key: true, sortable: true, hidden: true },
            { name: 'B_Ten', width: 50, sortable: false },
            { name: 'B_Url', width: 20, resizable: true, sortable: false },
            { name: 'B_RssUrl', width: 30, resizable: true, sortable: false }
        ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'B_ID',
            sortorder: 'desc',
            rowNum: 10000,
            rowNum: 20,
            rowList: [5, 10, 20, 30],
            pager: jQuery('#baoMdl-Pager'),
            onSelectRow: function (rowid) {

            },
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-baoMdl');
                adm.regQS(searchTxt, 'baoMdl-List');
            }
        });
    },
    edit: function () {
        var s = '';
        if (jQuery('#baoMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#baoMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                baoFn.loadHtml(function () {
                    var newDlg = $('#baoMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                baoFn.save(false, function () {
                                    baoFn.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                baoFn.save(false, function () {
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
                            baoFn.clearform();
                            $.ajax({
                                url: baoFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#baoMdl-dlgNew');
                                    var ID = $('.ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Url = $('.Url', newDlg);
                                    var RssUrl = $('.RssUrl', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    $(ID).val(data.ID);
                                    $(Ten).val(data.Ten);
                                    $(Url).val(data.Url);
                                    $(RssUrl).val(data.RssUrl);
                                    $(spbMsg).html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function () {
        var s = '';
        if (jQuery('#baoMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#baoMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: baoFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery("#baoMdl-List").trigger('reloadGrid');
                          //  jQuery(grid).trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn, grid) {
        var newDlg = $('#baoMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Url = $('.Url', newDlg);
        var RssUrl = $('.RssUrl', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _Ten = $(Ten).val();
        var _Url = $(Url).val();
        var _RssUrl = $(RssUrl).val();
        var err = '';
        if (_Ten == '') {
            err += 'Nhập Tên<br/>';
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
            url: baoFn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': _ID,
                'Ten': _Ten,
                'RssUrl': _RssUrl,
                'Url': _Url
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
    add: function () {
        baoFn.loadHtml(function () {
            var newDlg = $('#baoMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        baoFn.save(false, function () {
                            baoFn.clearform();
                        }, '#baoMdl-List');
                    },
                    'Lưu và đóng': function () {
                        baoFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#baoMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    baoFn.clearform();
                }
            });
        });
    },
    clearform: function () {
        var newDlg = $('#baoMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Url = $('.Url', newDlg);
        var RssUrl = $('.RssUrl', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        $(ID).val('');
        $(Ten).val('');
        $(Url).val('');
        spbMsg.html('');
    },
    autoComplete: function (el, fn) {
        function split(val) {
            return val.split(/;\s*/);
        }
        function extractLast(term) {
            return split(term).pop();
        }
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'baoFn-autoComplete';
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(extractLast(request.term)), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                url: item.Url,
                                rssurl: item.RssUrl
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: baoFn.urlDefault + '&subAct=getautoComplete',
                    dataType: 'script',
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
                                        url: item.Url,
                                        rssurl: item.RssUrl
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
                // prevent value inserted on focus
                return false;
            },
            change: function (event, ui) {
                //                if (!ui.item) {
                //                    if ($(this).val() == '') {
                //                        $(this).attr('_value', '');
                //                    }
                //                }
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
        var dlg = $('#baoMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.rss.bao.htm.htm")%>',
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
