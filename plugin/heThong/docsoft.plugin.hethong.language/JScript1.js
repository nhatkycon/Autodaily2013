var Lang;
var LangArr;
var languageFn = {
    urlDefault: function () {
        return adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.language.Class1, docsoft.plugin.hethong.language';
    },
    setup: function (fn) {
        var langSw = $('#langSw');
        if ($(langSw).length == 1) { if (typeof (fn) == 'function') { fn(); }; return false; }
        $.ajax({
            url: languageFn.urlDefault().toString(),
            data: { 'subAct': 'getActive' },
            dataType: 'script',
            success: function (_dt) {
                var dt = eval(_dt);
                LangArr = dt;
                if ($(langSw).length < 1) {
                    $('#adm-banner-left').prepend('<select onchange=\"languageFn.changeLang(this);\" id=\"langSw\"></select>');
                    langSw = $('#langSw');
                }
                $(langSw).find('option').remove();
                $.each(dt, function (i, item) {
                    if (item.Active) {
                        Lang = item.Ma;
                    }
                    $(langSw).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                });
                langSw.val(Lang);
                if (typeof (fn) == 'function') { fn(); }
            }
        });
    },
    changeLang: function (_obj) {
        var obj = $(_obj);
        Lang = obj.val();
        adm.regType(typeof (ResourcesFn), 'cnn.plugin.Resources.Class1, cnn.plugin.Resources', function () { ResourcesFn.changeResources(); });
    },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu loại danh mục');
        $('#languageMdl-List').jqGrid({
            url: languageFn.urlDefault().toString() + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mã', 'Tên', 'Thứ Tự', 'Active'],
            colModel: [
            { name: 'ID', key: true, sortable: true, hidden: true },
            { name: 'Ma', width: 80, resizable: true, sortable: true, align: "center" },
            { name: 'Ten', width: 300, resizable: true, sortable: true, align: "left" },
            { name: 'ThuTu', width: 80, sortable: true, align: "center" },
            { name: 'Active', width: 100, resizable: true, sortable: true, align: "center", formatter: 'checkbox' }
        ],
            caption: 'Ngôn ngữ',
            autowidth: true,
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25, 30],
            pager: jQuery('#languageMdl-Pager'),
            loadComplete: function () {
                adm.loading(null);
            }
        });
        var searchTxt = $('.mdl-head-search-languageFn');
        $('.mdl-head-search-languageFn').keyup(function () {
            var txtsearch = $('.mdl-head-search-languageFn').val();
            languageFn.search();
        });
        adm.watermark(searchTxt, 'Tìm kiếm loại danh mục', function () {
            $(searchTxt).val('');
            languageFn.search();
            $(searchTxt).val('Tìm kiếm loại danh mục');
        });
    },
    add: function () {
        languageFn.loadHtml(function () {
            var newDlg = $('#languageMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                beforeClose: function () {
                    languageFn.clearform();
                },
                buttons: {
                    'Lưu': function () {
                        languageFn.save();
                    },
                    'Lưu và đóng': function () {
                        languageFn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    languageFn.clearform();
                }
            });
        });
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-languageFn');
        var q = filterDM.val();
        var ldm = $(filterDM).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#languageMdl-List').jqGrid('setGridParam', { url: languageFn.urlDefault + "&subAct=get&q=" + q }).trigger("reloadGrid");
        }, 500);
    },
    del: function () {
        var s = '';
        if (jQuery("#languageMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#languageMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa loại danh mục này?')) {
                    $.ajax({
                        url: languageFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery("#languageMdl-List").trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#languageMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _Ten = $(Ten).val();
        var _Ma = $(Ma).val();
        var _ThuTu = ThuTu.val();
        var _Active = Active.is(':checked');

        var err = '';
        if (_Ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (_Ma == '') {
            err += 'Nhập mã<br/>';
        }
        if (_ThuTu == '') {
            err += 'Nhập thứ tự<br/>';
        }
        else {

            if (!adm.isInt(_ThuTu)) {
                err += 'Nhập thứ tự kiểu số<br/>';
            }
        }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: languageFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                'ID': _ID,
                'ThuTu': _ThuTu,
                'Ten': _Ten,
                'Ma': _Ma,
                'Active': _Active
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    jQuery("#languageMdl-List").trigger('reloadGrid');
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    edit: function () {
        var s = '';
        if (jQuery("#languageMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#languageMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                languageFn.loadHtml(function () {
                    var newDlg = $('#languageMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                languageFn.save();
                            },
                            'Lưu và đóng': function () {
                                languageFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            languageFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            $.ajax({
                                url: languageFn.urlDefault().toString(),
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    'ID': s,
                                    'subAct': 'edit'
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#languageMdl-dlgNew');
                                    var ID = $('.ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    $(ID).val(data.ID);
                                    $(Ten).val(data.Ten);
                                    $(Ma).val(data.Ma);
                                    $(ThuTu).val(data.ThuTu);
                                    if (data.Active) {
                                        Active.removeAttr('checked');
                                    }
                                    else {
                                        Active.attr('checked', 'checked');
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
    AutoComplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'languageFn-AutoComplete-' + s;
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                ma: item.Ma,
                                thutu: item.ThuTu
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: languageFn.urlDefault().toString(),
                    dataType: 'script',
                    data: {
                        'subAct': 'AutoComplete'
                    },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        ma: item.Ma,
                                        thutu: item.ThuTu
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
    clearform: function () {
        var newDlg = $('#languageMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Active = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(ID).val('');
        $(Ten).val('');
        $(Ma).val('');
        $(ThuTu).val('');
        $(Active).removeAttr('checked');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#languageMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("docsoft.plugin.hethong.language.htm.htm")%>',
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
