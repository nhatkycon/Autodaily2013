var topicFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.rss.topic.topic, plugin.rss.topic',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('.sub-mdl').tabs();
        $('#topicMdl-List').jqGrid({
            url: topicFn.urlDefault + '&subAct=get',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Ảnh', 'Tên', 'Thứ tự', 'Mô tả', 'Từ khóa', 'Active', 'Hot', 'Hot1', 'Hot2', 'Home'],
            colModel: [
            { name: 'TP_ID', key: true, sortable: true, hidden: true },
            { name: 'TP_Anh', width: 20, sortable: false, editable: true },
            { name: 'TP_Ten', width: 30, resizable: true, sortable: false, editable: true },
            { name: 'TP_ThuTu', width: 50, resizable: true, sortable: false, editable: true },
            { name: 'TP_MoTa', width: 50, resizable: true, sortable: false, editable: true },
            { name: 'TP_Keywords', width: 50, resizable: true, sortable: false, editable: true },
            { name: 'TP_Active', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'TP_Hot', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'TP_Hot1', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'TP_Hot2', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'TP_Home', width: 5, resizable: true, sortable: false, formatter: 'checkbox' }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'DM_ID',
            sortorder: 'desc',
            height: 200,
            rowNum: 1000,
            rowList: [5, 100, 200, 500, 1000],
//            pager: jQuery('#topicMdl-Pager'),
            editurl: topicFn.urlDefault + '&subAct=save',
            onSelectRow: function (rowid) {
                var treedata = $("#topicMdl-List").jqGrid('getRowData', rowid);
                topicFn.changeSubTin(treedata.TP_ID);
            },
            loadComplete: function () {
                adm.loading(null);
                topicFn.loadTinList('0');
                var searchTxt = $('.mdl-head-search-topicMdl'); adm.regQS(searchTxt, 'topicMdl-List');
                topicFn.SubTinFn();
            }
        });
    },
    loadTinList: function (_id) {
        $('#topicMdl-subTinMdl-List').jqGrid({
            url: topicFn.urlDefault + '&subAct=getSubTin&ID=' + _id,
            datatype: 'json',
            loadui: 'disable',
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
//            pager: jQuery('#topicMdl-subTinMdl-Pager'),
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-subTinMdl-topicMdl'); adm.regQS(searchTxt, 'topicMdl-subTinMdl-List');
            }
        });
    },
    SubTinFn: function () {
        var T_ID = $('.mdl-head-topicSearchTin');
        var Btn = $('#topicMdl-subTinMdl-addBtn');
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
            var _tpId = $(item).attr('_id');
            if (_tpId == '') { alert('Chọn chủ đề'); return false; }
            T_ID = $('.mdl-head-topicSearchTin');
            var _v = $(T_ID).attr('_value');
            if (_v != '') {
                if (adm.isInt(_v)) {
                    $.ajax({
                        url: topicFn.urlDefault + '&subAct=addSubTin&ID=' + _tpId,
                        data: { 'T_ID': _v },
                        success: function () {
                            $(T_ID).val('');
                            $(T_ID).attr('_value', '');
                            jQuery('#topicMdl-subTinMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        });
    },
    delSubTin: function () {
        var Btn = $('#topicMdl-subTinMdl-addBtn');
        var _tpId = $(Btn).attr('_id');
        if (_tpId == '') { alert('Chọn chủ đề'); return false; }
        var s = '';
        s = jQuery("#topicMdl-subTinMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            var con = confirm('Bạn có muốn xóa');
            if (con) {
                $.ajax({
                    url: topicFn.urlDefault + '&subAct=delSubTin',
                    dataType: 'script',
                    data: {
                        'ID': _tpId,
                        'IDs': s
                    },
                    success: function (dt) {
                        jQuery('#topicMdl-subTinMdl-List').trigger('reloadGrid');
                    }
                });
            }
        }
    },
    changeSubTin: function (_id) {
        var Btn = $('#topicMdl-subTinMdl-addBtn');
        $(Btn).attr('_id', _id);
        $('#topicMdl-subTinMdl-List').jqGrid('setGridParam', { url: topicFn.urlDefault + '&subAct=getSubTin&ID=' + _id }).trigger('reloadGrid');
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
            $('#topicMdl-List').jqGrid('setGridParam', { url: topicFn.urlDefault + '&subAct=get' + "&B_ID=" + _B_ID + "&DM_ID=" + _DM_ID }).trigger("reloadGrid");
        }, 500);
    },
    edit: function () {
        var s = '';
        if (jQuery('#topicMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#topicMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                topicFn.loadHtml(function () {
                    var newDlg = $('#topicMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                topicFn.save(false, function () { topicFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                topicFn.save(false, function () { topicFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            topicFn.clearform();
                            topicFn.popfn();
                            $.ajax({
                                url: topicFn.urlDefault + '&subAct=edit',
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
                                    var MoTa = $('.MoTa', newDlg);
                                    var Keywords = $('.Keywords', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var Home = $('.Home', newDlg);
                                    var Hot = $('.Hot', newDlg);
                                    var Hot1 = $('.Hot1', newDlg);
                                    var Hot2 = $('.Hot2', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');

                                    $(ID).val(dt.ID);
                                    $(DM_ID).val(dt._DanhMuc.Ten);
                                    $(DM_ID).attr('_value', dt.DM_ID);
                                    $(Ten).val(dt.Ten);
                                    $(ThuTu).val(dt.ThuTu);
                                    $(MoTa).val(dt.MoTa);
                                    $(Keywords).val(dt.Keywords);
                                    if (dt.Active) { $(Active).attr('checked', 'checked'); } else { $(Active).removeAttr('checked'); }
                                    if (dt.Hot) { $(Hot).attr('checked', 'checked'); } else { $(Hot).removeAttr('checked'); }
                                    if (dt.Hot1) { $(Hot1).attr('checked', 'checked'); } else { $(Hot1).removeAttr('checked'); }
                                    if (dt.Hot2) { $(Hot2).attr('checked', 'checked'); } else { $(Hot2).removeAttr('checked'); }
                                    if (dt.Home) { $(Home).attr('checked', 'checked'); } else { $(Home).removeAttr('checked'); }
                                    if (dt.Anh != '') {
                                        $(lblAnh).attr('ref', dt.Anh);
                                        $(lblAnhPrvImg).attr('src', '../lib/up/' + dt.Anh + '?ref=' + Math.random());
                                    }
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
        if (jQuery('#topicMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#topicMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: topicFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery('#topicMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#topicMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Keywords = $('.Keywords', newDlg);
        var Active = $('.Active', newDlg);
        var Home = $('.Home', newDlg);
        var Hot = $('.Hot', newDlg);
        var Hot1 = $('.Hot1', newDlg);
        var Hot2 = $('.Hot2', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var lblAnh = $('.Anh', newDlg);

        var _ID = $(ID).val();
        var _DM_ID = $(DM_ID).attr('_value');
        var _Ten = $(Ten).val();
        var _ThuTu = $(ThuTu).val();
        var _MoTa = $(MoTa).val();
        var _Keywords = $(Keywords).val();
        var _Active = $(Active).is(':checked');
        var _Home = $(Home).is(':checked');
        var _Hot = $(Hot).is(':checked');
        var _Hot1 = $(Hot1).is(':checked');
        var _Hot2 = $(Hot2).is(':checked');
        var _anh = $(lblAnh).attr('ref');


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
            url: topicFn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': _ID,
                'DM_ID': _DM_ID,
                'Ten': _Ten,
                'ThuTu': _ThuTu,
                'MoTa': _MoTa,
                'Keywords': _Keywords,
                'Active': _Active,
                'Home': _Home,
                'Hot': _Hot,
                'Hot1': _Hot1,
                'Hot2': _Hot2,
                'Anh': _anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#topicMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        topicFn.loadHtml(function () {
            var newDlg = $('#topicMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        topicFn.save(false, function () {
                            topicFn.clearform();
                        }, '#topicMdl-List');
                    },
                    'Lưu và đóng': function () {
                        topicFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#topicMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    topicFn.clearform();
                    topicFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#topicMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        adm.regType(typeof (phanLoaiFn), 'plugin.rss.phanLoai.Class1, plugin.rss.phanLoai', function () {
            phanLoaiFn.autoComplete(DM_ID, function (event, ui) { $(DM_ID).val(ui.item.label); $(DM_ID).attr('_value', ui.item.id); });
            $(DM_ID).unbind('click').click(function () { $(DM_ID).autocomplete('search', ''); }); ;
        });
        var ulpFn = function () {
            var uploadBtn = $('.adm-upload-btn', newDlg);
            var uploadView = $('.adm-upload-preview-img', newDlg);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.upload(uploadBtn, 'anh', _params, function (rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '../lib/up/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();
    },
    clearform: function () {
        var newDlg = $('#topicMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var Keywords = $('.Keywords', newDlg);
        var Active = $('.Active', newDlg);
        var Home = $('.Home', newDlg);
        var Hot = $('.Hot', newDlg);
        var Hot1 = $('.Hot1', newDlg);
        var Hot2 = $('.Hot2', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(ID).val('');
        $(DM_ID).val('');
        $(DM_ID).attr('_value', '');
        $(Ten).val('');
        $(ThuTu).val('');
        $(MoTa).val('');
        $(Keywords).val('');
        $(Active).val('');
        $(Home).val('');
        $(Hot).val('');
        $(Hot1).val('');
        $(Hot2).val('');
        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');
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
                var term = 'topicFn-autoComplete-';
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
                    url: topicFn.urlDefault + '&subAct=getautoComplete',
                    dataType: 'script',
                    data: {
                        'q': ''
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
        var dlg = $('#topicMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.rss.topic.htm.htm")%>',
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
