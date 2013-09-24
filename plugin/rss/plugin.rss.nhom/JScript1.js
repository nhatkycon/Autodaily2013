var nhomFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.rss.nhom.Class1, plugin.rss.nhom',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('.sub-mdl').tabs();
        $('#nhomMdl-List').jqGrid({
            url: nhomFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID','Danh mục', 'Tên', 'Thứ tự', 'Active', 'Hot', 'Hot1', 'Hot2', 'Hot3'],
            colModel: [
            { name: 'N_ID', key: true, sortable: true, hidden: true },
            { name: 'N_DM_ID', width: 20, sortable: false },
            { name: 'N_Ten', width: 20, sortable: false },
            { name: 'N_ThuTu', width: 20, resizable: true, sortable: false },
            { name: 'N_Active', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'N_Hot', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'N_Hot1', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'N_Hot2', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'N_Hot3', width: 5, resizable: true, sortable: false, formatter: 'checkbox' }
        ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'B_ID',
            height: 200,
            sortorder: 'desc',
            rowNum: 10000,
            rowNum: 20,
            rowList: [5, 10, 20, 30],
            //            pager: jQuery('#nhomMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#nhomMdl-List").jqGrid('getRowData', rowid);
                nhomFn.changeSubTin(treedata.N_ID);
            },
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-nhomMdl');
                adm.regQS(searchTxt, 'nhomMdl-List');
                nhomFn.loadTinList('0');
                nhomFn.SubTinFn();
            }
        });
    },
    loadTinList: function (_id) {
        $('#nhomMdl-subTinMdl-List').jqGrid({
            url: nhomFn.urlDefault + '&subAct=getSubTin&ID=' + _id,
            datatype: 'json',
            colNames: ['ID', 'Ảnh', 'Tên', 'Mô tả', 'Url', 'Ngày tạo'],
            colModel: [
            { name: 'TPT_ID', key: true, sortable: true, hidden: true },
            { name: 'TPT_Anh', width: 20, sortable: false, editable: true },
            { name: 'TPT_Ten', width: 30, resizable: true, sortable: false, editable: true },
            { name: 'TPT_MoTa', width: 30, resizable: true, sortable: false, editable: true },
            { name: 'TPT_Url', width: 30, resizable: true, sortable: false, editable: true },
            { name: 'TPT_NgayTao', width: 10, resizable: true, sortable: false, editable: true }
            ],
            caption: 'Tin',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            rowNum: 1000,
            rowList: [5, 100, 200, 500, 1000],
            //            pager: jQuery('#nhomMdl-subTinMdl-Pager'),
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-subTinMdl-nhomMdl'); adm.regQS(searchTxt, 'nhomMdl-subTinMdl-List');
            }
        });
    },
    SubTinFn: function () {
        var T_ID = $('.mdl-head-nhomMdlSearchTin');
        var Btn = $('#nhomMdl-subTinMdl-addBtn');
        adm.regType(typeof (tinFn), 'plugin.rss.tin.Class1, plugin.rss.tin', function () {
            tinFn.autoCompleteSearch(T_ID,
                        function (event, ui) {
                            $(T_ID).val(ui.item.label);
                            $(T_ID).attr('_value', ui.item.id);
                        });
            $(T_ID).unbind('click').click(function () { if ($(T_ID).val() != '') { $(T_ID).autocomplete('search', $(T_ID).val()); } }); ;
        });
        $(Btn).unbind('click').click(function () {
            var item = this;
            var _nId = $(item).attr('_id');
            if (_nId == '') { alert('Chọn chủ đề'); return false; }
            T_ID = $('.mdl-head-nhomMdlSearchTin');
            var _v = $(T_ID).attr('_value');
            if (_v != '') {
                if (adm.isInt(_v)) {
                    $.ajax({
                        url: nhomFn.urlDefault + '&subAct=addSubTin&ID=' + _nId,
                        data: { 'N_ID': _v },
                        success: function () {
                            $(T_ID).val('');
                            $(T_ID).attr('_value', '');
                            jQuery('#nhomMdl-subTinMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        });
    },
    delSubTin: function () {
        var Btn = $('#nhomMdl-subTinMdl-addBtn');
        var _tpId = $(Btn).attr('_id');
        if (_tpId == '') { alert('Chọn chủ đề'); return false; }
        var s = '';
        s = jQuery("#nhomMdl-subTinMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            var con = confirm('Bạn có muốn xóa');
            if (con) {
                $.ajax({
                    url: nhomFn.urlDefault + '&subAct=delSubTin',
                    dataType: 'script',
                    data: {
                        'ID': _tpId,
                        'IDs': s
                    },
                    success: function (dt) {
                        jQuery('#nhomMdl-subTinMdl-List').trigger('reloadGrid');
                    }
                });
            }
        }
    },
    changeSubTin: function (_id) {
        var Btn = $('#nhomMdl-subTinMdl-addBtn');
        $(Btn).attr('_id', _id);
        $('#nhomMdl-subTinMdl-List').jqGrid('setGridParam', { url: nhomFn.urlDefault + '&subAct=getSubTin&ID=' + _id }).trigger('reloadGrid');
    },
    edit: function () {
        var s = '';
        if (jQuery('#nhomMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#nhomMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                nhomFn.loadHtml(function () {
                    var newDlg = $('#nhomMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                nhomFn.save(false, function () {
                                    nhomFn.clearform();
                                }, '#nhomMdl-List');
                            },
                            'Lưu và đóng': function () {
                                nhomFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                }, '#nhomMdl-List');
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            nhomFn.clearform();
                            nhomFn.popfn();

                            $.ajax({
                                url: nhomFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);

                                    var ID = $('.ID', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var Hot = $('.Hot', newDlg);
                                    var Hot1 = $('.Hot1', newDlg);
                                    var Hot2 = $('.Hot2', newDlg);
                                    var Hot3 = $('.Hot3', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    $(ID).val(dt.ID);
                                    $(Ten).val(dt.Ten);
                                    $(ThuTu).val(dt.ThuTu);
                                    $(DM_ID).val(dt._DanhMuc.Ten);
                                    $(DM_ID).attr('_value', dt.DM_ID);

                                    if (dt.Active) { $(Active).attr('checked', 'checked'); } else { $(Active).removeAttr('checked'); }
                                    if (dt.Hot) { $(Hot).attr('checked', 'checked'); } else { $(Hot).removeAttr('checked'); }
                                    if (dt.Hot1) { $(Hot1).attr('checked', 'checked'); } else { $(Hot1).removeAttr('checked'); }
                                    if (dt.Hot2) { $(Hot2).attr('checked', 'checked'); } else { $(Hot2).removeAttr('checked'); }
                                    if (dt.Hot3) { $(Hot3).attr('checked', 'checked'); } else { $(Hot3).removeAttr('checked'); }
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
        if (jQuery('#nhomMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#nhomMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: nhomFn.urlDefault + '&subAct=del',
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
    save: function (validate, fn, grid) {
        var newDlg = $('#nhomMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);
        var Hot = $('.Hot', newDlg);
        var Hot1 = $('.Hot1', newDlg);
        var Hot2 = $('.Hot2', newDlg);
        var Hot3 = $('.Hot3', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _DM_ID = $(DM_ID).attr('_value');
        var _Ten = $(Ten).val();
        var _ThuTu = $(ThuTu).val();
        var _Active = $(Active).is(':checked');
        var _Hot = $(Hot).is(':checked');
        var _Hot1 = $(Hot1).is(':checked');
        var _Hot2 = $(Hot2).is(':checked');
        var _Hot3 = $(Hot3).is(':checked');

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
            url: nhomFn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': _ID,
                'DM_ID': _DM_ID,
                'Ten': _Ten,
                'ThuTu': _ThuTu,
                'Active': _Active,
                'Hot': _Hot,
                'Hot1': _Hot1,
                'Hot2': _Hot2,
                'Hot3': _Hot3
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
        nhomFn.loadHtml(function () {
            var newDlg = $('#nhomMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        nhomFn.save(false, function () {
                            nhomFn.clearform();
                        }, '#nhomMdl-List');
                    },
                    'Lưu và đóng': function () {
                        nhomFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#nhomMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    nhomFn.clearform();
                    nhomFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#nhomMdl-dlgNew');
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            var DM_ID = $('.DM_ID', newDlg);
            danhmuc.autoCompleteByLoai('TIN-LNHOM', DM_ID, function (event, ui) {
                $(DM_ID).attr('_value', ui.item.id);
            });
            $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); }); ;

        });
    },
    clearform: function () {
        var newDlg = $('#nhomMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Active = $('.Active', newDlg);
        var Hot = $('.Hot', newDlg);
        var Hot1 = $('.Hot1', newDlg);
        var Hot2 = $('.Hot2', newDlg);
        var Hot3 = $('.Hot3', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(DM_ID).val('');
        $(DM_ID).attr('_value', '');
        $(ID).val('');
        $(Ten).val('');
        $(ThuTu).val('');
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
                var term = 'nhomFn-autoComplete';
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
                    url: nhomFn.urlDefault + '&subAct=getautoComplete',
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
        var dlg = $('#nhomMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.rss.nhom.htm.htm")%>',
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
