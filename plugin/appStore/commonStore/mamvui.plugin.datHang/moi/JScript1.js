var Lang;
var LangArr;
var datHangMoiFn = {
    urlDefault: function () {
        return adm.urlDefault + '&act=loadPlug&rqPlug=mamvui.plugin.datHang.moi.Class1, mamvui.plugin.datHang';
    },
    setup: function (fn) {
        var langSw = $('#langSw');
        if ($(langSw).length == 1) { if (typeof (fn) == 'function') { fn(); }; return false; }
        $.ajax({
            url: datHangMoiFn.urlDefault().toString(),
            data: { 'subAct': 'getActive' },
            dataType: 'script',
            success: function (_dt) {
                var dt = eval(_dt);
                LangArr = dt;
                if ($(langSw).length < 1) {
                    $('#adm-banner-left').prepend('<select onchange=\"datHangMoiFn.changeLang(this);\" id=\"langSw\"></select>');
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
    baocao: function () {
        var request = $('#datHangMoiMdl-List').jqGrid('getGridParam', 'url');
        request = request.replace('.plugin', 'Default.aspx');
        request = request.replace('loadPlug', 'loadPlugDirect');
        request = request.replace('get', 'reports');
        request = request + '&rows=' + $('#datHangMoiMdl-List').jqGrid('getGridParam', 'rowNum');

        adm.loadIfr(request
                        , function () {
                            adm.loading('Đang tạo báo cáo');
                        }
                        , function () {
                            adm.loading(null);
                        });
    },
    daGiao: function (_id) {
        $.ajax({
            url: datHangMoiFn.urlDefault().toString() + '&subAct=giao&ID=' + _id,
            dataType: 'script',
            success: function (dt) {
                jQuery("#datHangMoiMdl-List").trigger('reloadGrid');
            }
        });
    },
    changeLang: function (_obj) {
        var obj = $(_obj);
        Lang = obj.val();
        adm.regType(typeof (ResourcesFn), 'cnn.plugin.Resources.Class1, cnn.plugin.Resources', function () { ResourcesFn.changeResources(); });
    },
    loadSubGrid: function () {
        $('#datHangChiTietMdl-List').jqGrid({
            url: datHangMoiFn.urlDefault().toString() + '&subAct=getSubGrid&ID=0',
            height: '400',
            datatype: 'json',
            colNames: ['ID', 'Món', 'Giá', 'Số lượng', 'Tổng'],
            colModel: [
                        { name: 'ID', key: true, sortable: true, hidden: true },
                        { name: 'Ten', width: 40, sortable: true },
                        { name: 'Gia', width: 10, sortable: true, align: "center" },
                        { name: 'SoLuong', width: 5, resizable: true, sortable: true },
                        { name: 'Tong', width: 10, resizable: true, sortable: true }

                    ],
            caption: 'Chi tiết',
            autowidth: true,
            sortorder: 'asc',
            rowNum: 20000,
            pager: false,
            rowList: [20000, 2000, 3000],
            onSelectRow: function (rowid) { },
            loadComplete: function () { adm.loading(null); }
        });
    },
    nap: function () {
        $('#datHangMoiMdl-List').jqGrid('setGridParam', { url: datHangMoiFn.urlDefault().toString() + "&subAct=get&" }).trigger("reloadGrid");
    },
    changeSubGrid: function (_id) {
        $('#datHangChiTietMdl-List').jqGrid('setGridParam', { url: datHangMoiFn.urlDefault().toString() + '&subAct=getSubGrid&ID=' + _id }).trigger('reloadGrid');
    },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu đặt hàng');
        $('#datHangMoiMdl-List').jqGrid({
            url: datHangMoiFn.urlDefault().toString() + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Khách', 'Mobile', 'Địa chỉ', 'Tổng', 'Ngày tạo', 'Giao'],
            colModel: [
            { name: 'ID', key: true, width: 5, sortable: true, hidden: true },
            { name: 'KH_Ten', width: 30, resizable: true, sortable: true, align: "left" },
            { name: 'KH_Mobile', width: 10, resizable: true, sortable: true, align: "left" },
            { name: 'KH_DiaChi', width: 35, sortable: true, align: "left" },
            { name: 'Tong', width: 5, sortable: true, align: "center" },
            { name: 'NgayTao', width: 10, sortable: true, align: "center" },
            { name: 'GiaoHang', width: 5, sortable: true, align: "center" }
        ],
            caption: 'Đặt hàng',
            autowidth: true,
            rowNum: 50,
            rowList: [50, 100, 150, 200],
            pager: jQuery('#datHangMoiMdl-Pager'),
            loadComplete: function () {
                adm.loading(null);
            },
            onSelectRow: function (rowid) {
                var treedata = $("#datHangMoiMdl-List").jqGrid('getRowData', rowid);
                datHangMoiFn.changeSubGrid(treedata.ID);
            }
        });
        var searchTxt = $('.mdl-head-search-languageFn');
        $('.mdl-head-search-languageFn').keyup(function () {
            var txtsearch = $('.mdl-head-search-languageFn').val();
            datHangMoiFn.search();
        });
        adm.watermark(searchTxt, 'Tìm kiếm loại danh mục', function () {
            $(searchTxt).val('');
            datHangMoiFn.search();
            $(searchTxt).val('Tìm kiếm loại danh mục');
        });
        datHangMoiFn.loadSubGrid();
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-languageFn');
        var q = filterDM.val();
        var ldm = $(filterDM).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#datHangMoiMdl-List').jqGrid('setGridParam', { url: datHangMoiFn.urlDefault + "&subAct=get&q=" + q }).trigger("reloadGrid");
        }, 500);
    },
    del: function () {
        var s = '';
        if (jQuery("#datHangMoiMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#datHangMoiMdl-List").jqGrid('getGridParam', 'selrow').toString();
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
                        url: datHangMoiFn.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery("#datHangMoiMdl-List").trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    edit: function () {
        var s = '';
        if (jQuery("#datHangMoiMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#datHangMoiMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                datHangMoiFn.loadHtml(function () {
                    var newDlg = $('#datHangMoiMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                datHangMoiFn.save();
                            },
                            'Lưu và đóng': function () {
                                datHangMoiFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            datHangMoiFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            $.ajax({
                                url: datHangMoiFn.urlDefault().toString(),
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    'ID': s,
                                    'subAct': 'edit'
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#datHangMoiMdl-dlgNew');
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
                    url: datHangMoiFn.urlDefault().toString(),
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
        var newDlg = $('#datHangMoiMdl-dlgNew');
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
        var dlg = $('#datHangMoiMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("mamvui.plugin.datHang.moi.htm.htm")%>',
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
