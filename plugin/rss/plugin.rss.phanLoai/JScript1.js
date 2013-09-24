var phanLoaiFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.rss.phanLoai.Class1, plugin.rss.phanLoai',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#phanLoaiMdl-List').jqGrid({
            url: phanLoaiFn.urlDefault + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Cha', 'Tên', 'Alias', 'Thứ tự', 'Keywords', 'Description', 'Tổng số tin'],
            colModel: [
            { name: 'DM_ID', key: true, sortable: true, hidden: true },
            { name: 'DM_PID', width: 50, sortable: false },
            { name: 'DM_Ten', width: 20, resizable: true, sortable: false },
            { name: 'DM_Alias', width: 30, resizable: true, sortable: false },
            { name: 'DM_ThuTu', width: 30, resizable: true, sortable: false },
            { name: 'DM_Keywords', width: 30, resizable: true, sortable: false },
            { name: 'DM_Description', width: 30, resizable: true, sortable: false },
            { name: 'DM_TongSoTin', width: 30, resizable: true, sortable: false }
        ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'DM_ID',
            sortorder: 'desc',
            rowNum: 10000,
            rowNum: 20,
            rowList: [5, 10, 20, 30],
            pager: jQuery('#phanLoaiMdl-Pager'),
            onSelectRow: function (rowid) {
            },
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-phanLoaiMdl');
                adm.regQS(searchTxt, 'phanLoaiMdl-List');
            }
        });
    },
    edit: function () {
        var s = '';
        if (jQuery('#phanLoaiMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#phanLoaiMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                phanLoaiFn.loadHtml(function () {
                    var newDlg = $('#phanLoaiMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                phanLoaiFn.save(false, function () { phanLoaiFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                phanLoaiFn.save(false, function () { phanLoaiFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            phanLoaiFn.clearform();
                            phanLoaiFn.popfn();
                            $.ajax({
                                url: phanLoaiFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var PID = $('.PID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var Keywords = $('.Keywords', newDlg);
                                    var Description = $('.Description', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    $(ID).val(dt.ID);
                                    $(PID).val(dt.P_Ten);
                                    $(PID).attr('_value', dt.P_ID);
                                    $(Ten).val(dt.Ten);
                                    $(Alias).val(dt.Alias);
                                    $(ThuTu).val(dt.ThuTu);
                                    $(Keywords).val(dt.Keywords);
                                    $(Description).val(dt.Description);

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
        if (jQuery('#phanLoaiMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#phanLoaiMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: phanLoaiFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery(grid).trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#phanLoaiMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var PID = $('.PID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Alias = $('.Alias', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Keywords = $('.Keywords', newDlg);
        var Description = $('.Description', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _PID = $(PID).attr('_value');
        var _Ten = $(Ten).val();
        var _Alias = $(Alias).val();
        var _ThuTu = $(ThuTu).val();
        var _Keywords = $(Keywords).val();
        var _Description = $(Description).val();

        var err = '';
        if (_Ten == '') {
            err += 'Nhập Tên<br/>';
        }
        if (_Alias == '') {
            err += 'Nhập Alias<br/>';
        }
        if (_ThuTu == '') {
            err += 'Nhập Thứ tự<br/>';
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
            url: phanLoaiFn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': _ID,
                'PID': _PID,
                'Ten': _Ten,
                'Alias': _Alias,
                'ThuTu': _ThuTu,
                'Keywords': _Keywords,
                'Description': _Description
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#phanLoaiMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        phanLoaiFn.loadHtml(function () {
            var newDlg = $('#phanLoaiMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        phanLoaiFn.save(false, function () {
                            phanLoaiFn.clearform();
                        }, '#phanLoaiMdl-List');
                    },
                    'Lưu và đóng': function () {
                        phanLoaiFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#phanLoaiMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    phanLoaiFn.clearform();
                    phanLoaiFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#phanLoaiMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var PID = $('.PID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Alias = $('.Alias', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Keywords = $('.Keywords', newDlg);
        var Description = $('.Description', newDlg);
        phanLoaiFn.autoCompletePid(PID, function (event, ui) {
            $(PID).val(ui.item.label);
            $(PID).attr('_value', ui.item.id);
        });
    },
    clearform: function () {
        var newDlg = $('#phanLoaiMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var PID = $('.PID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Alias = $('.Alias', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Keywords = $('.Keywords', newDlg);
        var Description = $('.Description', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(ID).val('');
        $(PID).val('');
        $(PID).attr('_value', '');
        $(Ten).val('');
        $(Alias).val('');
        $(ThuTu).val('');
        $(Keywords).val('');
        $(Description).val('');
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
                var term = 'phanLoaiFn-autoComplete';
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(extractLast(request.term)), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                level:item.Level
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: phanLoaiFn.urlDefault + '&subAct=getautoComplete',
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
                                        level: item.Level
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
				            .append('<a style=\"padding-left:' + (parseInt(item.level)*10) + 'px;\">' + item.label + '</a>')
				            .appendTo(ul);
        };
    },
    autoCompletePid: function (el, fn) {
        function split(val) {
            return val.split(/;\s*/);
        }
        function extractLast(term) {
            return split(term).pop();
        }
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'phanLoaiFn-getautoCompletePid';
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
                    url: phanLoaiFn.urlDefault + '&subAct=getautoCompletePid',
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
        var dlg = $('#phanLoaiMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.rss.phanLoai.htm.htm")%>',
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
