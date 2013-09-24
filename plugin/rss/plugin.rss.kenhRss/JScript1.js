var kenhRssFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.rss.kenhRss.Class1, plugin.rss.kenhRss',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#kenhRssMdl-List').jqGrid({
            url: kenhRssFn.urlDefault + '&subAct=get',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Báo', 'Phân loại', 'Url'],
            colModel: [
            { name: 'ID', key: true, sortable: true, hidden: true },
            { name: 'B_ID', width: 20, sortable: false, editable: true },
            { name: 'DM_ID', width: 30, resizable: true, sortable: false, editable: true },
            { name: 'RssUrl', width: 50, resizable: true, sortable: false, editable: true }
        ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'DM_ID',
            sortorder: 'desc',
            rowNum: 1000,
            rowList: [5, 100, 200, 500, 1000],
            pager: jQuery('#kenhRssMdl-Pager'),
            editurl: kenhRssFn.urlDefault + '&subAct=save',
            onSelectRow: function (rowid) {
                //                var item = $('#' + rowid, '#kenhRssMdl-List');
                //                if (!$(item).hasClass('editRow')) {
                //                    jQuery('#kenhRssMdl-List').jqGrid('editRow', rowid);
                //                    $(item).addClass('editRow');
                //                }
            },
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-kenhRssMdl');
                adm.regQS(searchTxt, 'kenhRssMdl-List');
                var filterByBao = $('.mdl-head-kenhRssFilterByBao');
                var filterByDanhMuc = $('.mdl-head-kenhRssFilterByDanhMuc');
                $(filterByBao).blur(function () { kenhRssFn.search(); });
                $(filterByDanhMuc).blur(function () { kenhRssFn.search(); });
                adm.regType(typeof (phanLoaiFn), 'plugin.rss.phanLoai.Class1, plugin.rss.phanLoai', function () {
                    phanLoaiFn.autoComplete(filterByDanhMuc, function (event, ui) {
                        $(filterByDanhMuc).val(ui.item.label); $(filterByDanhMuc).attr('_value', ui.item.id);
                        kenhRssFn.search();
                    });
                    $(filterByDanhMuc).unbind('click').click(function () { $(filterByDanhMuc).autocomplete('search', ''); }); ;
                });
                adm.regType(typeof (baoFn), 'plugin.rss.bao.Class1, plugin.rss.bao', function () {
                    baoFn.autoComplete(filterByBao, function (event, ui) {
                        $(filterByBao).val(ui.item.label); $(filterByBao).attr('_value', ui.item.id);
                        kenhRssFn.search();
                    });
                    $(filterByBao).unbind('click').click(function () { $(filterByBao).autocomplete('search', ''); });
                });
            }
        });
    },
    search: function () {
        var timerSearch;
        var filterByBao = $('.mdl-head-kenhRssFilterByBao');
        var filterByDanhMuc = $('.mdl-head-kenhRssFilterByDanhMuc');
        var _B_ID = $(filterByBao).attr('_value');
        var _DM_ID = $(filterByDanhMuc).attr('_value');
        var __B_ID = $(filterByBao).val();
        var __DM_ID = $(filterByDanhMuc).val();
        if (__DM_ID == '') {
            $(filterByDanhMuc).attr('_value', ''); _DM_ID = '';
        }
        if (__B_ID == '') {
            $(filterByBao).attr('_value', ''); _B_ID = '';
        }
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#kenhRssMdl-List').jqGrid('setGridParam', { url: kenhRssFn.urlDefault + '&subAct=get' + "&B_ID=" + _B_ID + "&DM_ID=" + _DM_ID }).trigger("reloadGrid");
        }, 500);
    },
    edit: function () {
        var s = '';
        if (jQuery('#kenhRssMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#kenhRssMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                kenhRssFn.loadHtml(function () {
                    var newDlg = $('#kenhRssMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                kenhRssFn.save(false, function () { kenhRssFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                kenhRssFn.save(false, function () { kenhRssFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            kenhRssFn.clearform();
                            kenhRssFn.popfn();
                            $.ajax({
                                url: kenhRssFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var B_ID = $('.B_ID', newDlg);
                                    var RssUrl = $('.RssUrl', newDlg);

                                    $(ID).val(dt.ID);
                                    $(DM_ID).val(dt.DM_Ten);
                                    $(DM_ID).attr('_value', dt.DM_ID);
                                    $(B_ID).val(dt.B_Ten);
                                    $(B_ID).attr('_value', dt.B_ID);
                                    $(RssUrl).val(dt.RssUrl);

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
        if (jQuery('#kenhRssMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#kenhRssMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: kenhRssFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery('#kenhRssMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#kenhRssMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var B_ID = $('.B_ID', newDlg);
        var RssUrl = $('.RssUrl', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _DM_ID = $(DM_ID).attr('_value');
        var _B_ID = $(B_ID).attr('_value');
        var _RssUrl = $(RssUrl).val();

        var err = '';
        if (_DM_ID == '') {
            err += 'Nhập Phân loại<br/>';
        }
        if (_B_ID == '') {
            err += 'Nhập Báo<br/>';
        }
        if (_RssUrl == '') {
            err += 'Nhập RssUrl<br/>';
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
            url: kenhRssFn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': _ID,
                'DM_ID': _DM_ID,
                'B_ID': _B_ID,
                'RssUrl': _RssUrl
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#kenhRssMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        kenhRssFn.loadHtml(function () {
            var newDlg = $('#kenhRssMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        kenhRssFn.save(false, function () {
                            kenhRssFn.clearform();
                        }, '#kenhRssMdl-List');
                    },
                    'Lưu và đóng': function () {
                        kenhRssFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#kenhRssMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    kenhRssFn.clearform();
                    kenhRssFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#kenhRssMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var B_ID = $('.B_ID', newDlg);
        var RssUrl = $('.RssUrl', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var _ID = ID.val();
        adm.regType(typeof (phanLoaiFn), 'plugin.rss.phanLoai.Class1, plugin.rss.phanLoai', function () {
            phanLoaiFn.autoComplete(DM_ID, function (event, ui) { $(DM_ID).val(ui.item.label); $(DM_ID).attr('_value', ui.item.id); });
            $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); }); ;
        });
        adm.regType(typeof (baoFn), 'plugin.rss.bao.Class1, plugin.rss.bao', function () {
            baoFn.autoComplete(B_ID, function (event, ui) { $(B_ID).val(ui.item.label); $(B_ID).attr('_value', ui.item.id); });
            $(B_ID).unbind('click').click(function () { $(B_ID).autocomplete('search', ''); });
        });
    },
    clearform: function () {
        var newDlg = $('#kenhRssMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var B_ID = $('.B_ID', newDlg);
        var RssUrl = $('.RssUrl', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(ID).val('');
        $(RssUrl).val('');
        spbMsg.html('');
    },
    autoComplete: function (s, el, fn) {
        function split(val) {
            return val.split(/;\s*/);
        }
        function extractLast(term) {
            return split(term).pop();
        }
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'kenhRssFn-autoComplete-' + s;
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(extractLast(request.term)), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: kenhRssFn.urlDefault + '&subAct=getautoComplete',
                    dataType: 'script',
                    data: {
                        'q': '',
                        'LDMID': s
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
        var dlg = $('#kenhRssMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.rss.kenhRss.htm.htm")%>',
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
