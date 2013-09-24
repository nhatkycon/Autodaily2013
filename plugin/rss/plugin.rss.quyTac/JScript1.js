var quyTacFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.rss.quyTac.Class1, plugin.rss.quyTac',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#quyTacMdl-List').jqGrid({
            url: quyTacFn.urlDefault + '&subAct=get',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID','Domain', 'Loại', 'xPath', 'Thứ tự', 'Xóa'],
            colModel: [
                { name: 'ID', key: true, sortable: true, hidden: true },
                { name: 'Host', width: 20, sortable: false },
                { name: 'Loai', width: 20, sortable: false},
                { name: 'xPath', width: 50, resizable: true, sortable: false},
                { name: 'ThuTu', width: 5, resizable: true, sortable: false},
                { name: 'Xoa', width: 5, resizable: true, sortable: false, formatter: 'checkbox' }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'DM_ID',
            sortorder: 'desc',
            rowNum: 1000,
            rowList: [5, 100, 200, 500, 1000],
            pager: jQuery('#quyTacMdl-Pager'),
            editurl: quyTacFn.urlDefault + '&subAct=save',
            onSelectRow: function (rowid) {
            },
            loadComplete: function () {
                adm.loading(null);
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
            $('#quyTacMdl-List').jqGrid('setGridParam', { url: quyTacFn.urlDefault + '&subAct=get' + "&B_ID=" + _B_ID + "&DM_ID=" + _DM_ID }).trigger("reloadGrid");
        }, 500);
    },
    edit: function () {
        var s = '';
        if (jQuery('#quyTacMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#quyTacMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                quyTacFn.loadHtml(function () {
                    var newDlg = $('#quyTacMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                quyTacFn.save(false, function () { quyTacFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                quyTacFn.save(false, function () { quyTacFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            quyTacFn.clearform();
                            quyTacFn.popfn();
                            $.ajax({
                                url: quyTacFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    '_ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);

                                    var ID = $('.ID', newDlg);
                                    var Loai = $('.Loai', newDlg);
                                    var Host = $('.Host', newDlg);
                                    var Xpath = $('.Xpath', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var Xoa = $('.Xoa', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);


                                    ID.val(dt.ID);
                                    Loai.val(dt.Loai);
                                    Host.val(dt.Host);
                                    Xpath.val(dt.Xpath);
                                    ThuTu.val(dt.ThuTu);
                                    if (dt.Xoa) {
                                        Xoa.attr('checked', 'checked');
                                    }
                                    else {
                                        Xoa.removeAttr('checked');
                                    }
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
        if (jQuery('#quyTacMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#quyTacMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa?')) {
                    $.ajax({
                        url: quyTacFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            '_ID': s
                        },
                        success: function (dt) {
                            jQuery('#quyTacMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#quyTacMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Loai = $('.Loai', newDlg);
        var Host = $('.Host', newDlg);
        var Xpath = $('.Xpath', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Xoa = $('.Xoa', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var _ID = ID.val();
        var _Loai = Loai.val();
        var _Host = Host.val();
        var _Xpath = Xpath.val();
        var _ThuTu = ThuTu.val();
        var _Xoa = Xoa.is(':checked');

        var err = '';
        if (_Xpath == '') {
            err += 'Nhập quy tắc<br/>';
        }
        if (_Host == '') {
            err += 'Nhập Domain<br/>';
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
            url: quyTacFn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                '_ID': _ID,
                '_Loai': _Loai,
                '_Host': _Host,
                '_ThuTu': _ThuTu,
                '_Xoa': _Xoa,
                '_Xpath': _Xpath
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#quyTacMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        quyTacFn.loadHtml(function () {
            var newDlg = $('#quyTacMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        quyTacFn.save(false, function () {
                            quyTacFn.clearform();
                        }, '#quyTacMdl-List');
                    },
                    'Lưu và đóng': function () {
                        quyTacFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#quyTacMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    quyTacFn.clearform();
                    quyTacFn.popfn();
                }
            });
        });
    },
    popfn: function () {

    },
    clearform: function () {
        var newDlg = $('#quyTacMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Loai = $('.Loai', newDlg);
        var Host = $('.Host', newDlg);
        var Xpath = $('.Xpath', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Xoa = $('.Xoa', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        Loai.val('0');
        $('input', newDlg).val('');
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
                var term = 'quyTacFn-autoComplete-' + s;
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
                    url: quyTacFn.urlDefault + '&subAct=getautoComplete',
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
        var dlg = $('#quyTacMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.rss.quyTac.htm.htm")%>',
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
