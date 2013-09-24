var ResourcesArr = {};
var ResourcesFn = {
    urlDefault: function () {
        return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.Resources.Class1, cnn.plugin.Resources';
    },
    setup: function () {
    },
    changeResources: function () {
        $.ajax({
            url: ResourcesFn.urlDefault().toString(),
            data: { 'subAct': 'getByLang', 'Lang': Lang },
            dataType: 'script',
            success: function () {
                console.log(ResourcesArr);
                $.each($('[_resource]'), function (i, item) {
                    var k = $(item).attr('_resource');
                    if ($(item).children().length > 0) {
                        $(item).children().html(ResourcesArr[k]);
                    }
                    else {
                        $(item).html(ResourcesArr[k]);
                    }
                });
            }
        });
    },
    loadgrid: function () {
        adm.styleButton();
        adm.regType(typeof (languageFn), 'cnn.plugin.language.Class1, cnn.plugin.language', function () {
            languageFn.setup(function () {
                adm.loading('...');
                $('#ResourcesMdl-List').jqGrid({
                    url: ResourcesFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
                    height: 'auto',
                    datatype: 'json',
                    loadui: 'disable',
                    colNames: ['ID', '<span _resource=\"admin.language.grid.col.Lang\">Ngôn ngữ</span>', '<span _resource=\"admin.language.grid.col.K\">Khóa</span>', '<span _resource=\"admin.language.grid.col.V\">Giá trị</span>'],
                    colModel: [
            { name: 'ID', key: true, sortable: true, hidden: true },
            { name: 'Lang', width: 10, resizable: true, sortable: true, align: "center" },
            { name: 'K', width: 30, resizable: true, sortable: true, align: "left" },
            { name: 'V', width: 60, sortable: true, align: "center" }
        ],
                    caption: '<span _resource=\"admin.language.grid.Resources\">Cấu hình Ngôn ngữ</span>',
                    autowidth: true,
                    rowNum: 50,
                    rowList: [50, 100, 500],
                    pager: jQuery('#ResourcesMdl-Pager'),
                    loadComplete: function () {
                        adm.loading(null);
                        ResourcesFn.changeResources(Lang);
                        
                    }
                });
            });
            var searchTxt = $('.mdl-head-search-ResourcesFn');
            $('.mdl-head-search-ResourcesFn').keyup(function () {
                var txtsearch = $('.mdl-head-search-ResourcesFn').val();
                ResourcesFn.search();
            });
            adm.watermark(searchTxt, ResourcesArr['admin.language.searchTxt'], function () {
                $(searchTxt).val('');
                ResourcesFn.search();
                $(searchTxt).val(ResourcesArr['admin.language.searchTxt']);
            });

            var changeLangBtn = $('#ResourcesMdl-changeLangSlt');
            $(changeLangBtn).find('option').remove();
            $.each(LangArr, function (i, item) {
                if (item.Active) {
                    Lang = item.Ma;
                }
                $(changeLangBtn).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
            });
            $(changeLangBtn).val(Lang);
        });
    },
    changeLang: function (_obj) {
        var obj = $(_obj);
        $('#ResourcesMdl-List').jqGrid('setGridParam', { url: ResourcesFn.urlDefault().toString() + '&subAct=get&Lang=' + obj.val() }).trigger('reloadGrid');
    },
    add: function () {
        ResourcesFn.loadHtml(function () {
            var newDlg = $('#ResourcesMdl-dlgNew');
            var save = ResourcesFn.getResourcesByKey('admin.system.label.save', 'Lưu');
            var saveAndClose = ResourcesFn.getResourcesByKey('admin.system.label.saveAndClose', 'Lưu và đóng');
            var close = ResourcesFn.getResourcesByKey('admin.system.label.close', 'Đóng');
            $(newDlg).dialog({
                title: ResourcesArr['admin.system.label.addNew'],
                width: 400,
                modal: true,
                beforeClose: function () {
                    ResourcesFn.clearform();
                },
                buttons: {
                    save: function () {
                        ResourcesFn.save(false, function () { ResourcesFn.clearform(); });
                    },
                    saveAndClose: function () {
                        ResourcesFn.save(false, function () {
                            $(newDlg).dialog('close');
                            ResourcesFn.clearform();
                        });
                    },
                    close: function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    ResourcesFn.popfn();
                    ResourcesFn.clearform();
                }
            });
        });
    },
    getResourcesByKey: function (k, txt) {
        if (typeof (ResourcesArr) == 'undefined') { return txt; }
        if (ResourcesArr[k] == '') return txt;
        return ResourcesArr[k];
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-ResourcesFn');
        var q = filterDM.val();
        var ldm = $(filterDM).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#ResourcesMdl-List').jqGrid('setGridParam', { url: ResourcesFn.urlDefault + "&subAct=get&q=" + q }).trigger("reloadGrid");
        }, 500);
    },
    del: function () {
        var s = '';
        if (jQuery("#ResourcesMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#ResourcesMdl-List").jqGrid('getGridParam', 'selrow').toString();
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
                        url: ResourcesFn.urlDefault().toString(),
                        dataType: 'script',
                        data: {
                            'ID': s, 'subAct': 'del'
                        },
                        success: function (dt) {
                            jQuery("#ResourcesMdl-List").trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#ResourcesMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var LangTxt = $('.Lang', newDlg);
        var K = $('.K', newDlg);
        var V = $('.V', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _Lang = $(LangTxt).val();
        var _K = K.val();
        var _V = V.val();

        var err = '';
        if (_K == '') {
            err += 'Nhập khóa<br/>';
        }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: ResourcesFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                'ID': _ID,
                'Lang': _Lang,
                'K': _K,
                'V': _V
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    jQuery("#ResourcesMdl-List").trigger('reloadGrid');
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
        if (jQuery("#ResourcesMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#ResourcesMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                ResourcesFn.loadHtml(function () {
                    var newDlg = $('#ResourcesMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                ResourcesFn.save(false, function () { ResourcesFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                ResourcesFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                    ResourcesFn.clearform();
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            ResourcesFn.clearform();
                        },
                        open: function () {
                            ResourcesFn.popfn();
                            adm.loading('Đang nạp dữ liệu');
                            $.ajax({
                                url: ResourcesFn.urlDefault().toString(),
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    'ID': s,
                                    'subAct': 'edit'
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#ResourcesMdl-dlgNew');
                                    var ID = $('.ID', newDlg);
                                    var LangTxt = $('.Lang', newDlg);
                                    var K = $('.K', newDlg);
                                    var V = $('.V', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    $(ID).val(data.ID);
                                    $(LangTxt).val(data.Lang);
                                    $(K).val(data.K);
                                    $(V).val(data.V);
                                    $(spbMsg).html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    setAutocomplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp danh sách');
                $.ajax({
                    url: ResourcesFn.urlDefault + '&subAct=getPid',
                    dataType: 'script',
                    data: {
                        'q': request.term
                    },
                    success: function (dt) {
                        adm.loading(null);
                        var data = eval(dt);
                        response($.map(data, function (item) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                ma: item.Ma
                            }
                        }))
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    clearform: function () {
        var newDlg = $('#ResourcesMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var LangTxt = $('.Lang', newDlg);
        var K = $('.K', newDlg);
        var V = $('.V', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(ID).val('');
        $(V).val('');
        $(K).val('');
        spbMsg.html('');
    },
    popfn: function () {
        var newDlg = $('#ResourcesMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var LangTxt = $('.Lang', newDlg);
        var K = $('.K', newDlg);
        var V = $('.V', newDlg);
        if ($(LangTxt).find('option').length < 1) {
            $(LangTxt).find('option').remove();
            console.log(LangArr);
            $.each(LangArr, function (i, item) {
                $(LangTxt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
            });
        }
    },
    loadHtml: function (fn) {
        var dlg = $('#ResourcesMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.Resources.htm.htm")%>',
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
