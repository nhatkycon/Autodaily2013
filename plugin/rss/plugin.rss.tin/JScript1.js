var tinFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.rss.tin.Class1, plugin.rss.tin',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#tinMdl-List').jqGrid({
            url: tinFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Ảnh', 'Nội dung', 'Phân loại', 'Ngày', 'Hot', 'Hot1', 'Hot2', 'Hot3', 'Dm', 'Home', 'Đọc nhiều', 'Views', 'Bình luận', 'Điểm'],
            colModel: [
            { name: 'T_ID', key: true, sortable: true, hidden: true },
            { name: 'T_Anh', width: 5, sortable: false, editable: true },
            { name: 'T_Ten', width: 50, resizable: true, sortable: false, editable: true },
            { name: 'T_CM_ID', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'T_Ngay', width: 5, resizable: true, sortable: false, editable: true },
            { name: 'T_Hot', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Hot1', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Hot2', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Hot3', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Dm', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Home', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_DocNhieu', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'T_Views', width: 5, resizable: true, sortable: false },
            { name: 'T_BinhChon', width: 5, resizable: true, sortable: false },
            { name: 'T_Diem', width: 5, resizable: true, sortable: false }
            ],
            caption: 'Danh sách',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'T_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#tinMdl-Pager'),
            editurl: tinFn.urlDefault + '&subAct=save',
            onSelectRow: function (rowid) {
                var treedata = $("#tinMdl-List").jqGrid('getRowData', rowid);
                tinFn.reLoadTinList(treedata.T_ID);
            },
            loadComplete: function () {
                adm.loading(null);
                //var searchTxt = $('.mdl-head-search-tinMdl'); adm.regQS(searchTxt, 'tinMdl-List');
                tinFn.headFn();
                tinFn.loadTinList('0');
            }
        });
    },
    headFn: function () {
        var filterByBao = $('.mdl-head-tinFilterByBao');
        var filterByDanhMuc = $('.mdl-head-tinFilterByDanhMuc');
        var filterByNhom = $('.mdl-head-tinFilterByNhom');
        var filterByTopic = $('.mdl-head-tinFilterByTopic');
        var filterByNgay = $('.mdl-head-tinFilterByNgay');
        var searchTxt = $('.mdl-head-search-tinMdl');

        $(filterByBao).blur(function () { tinFn.search(); });
        $(filterByDanhMuc).blur(function () { tinFn.search(); });

        $(searchTxt).unbind('keyup').keyup(function () {
            tinFn.search();
        });

        $(filterByNgay).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true,
            onSelect: function (dateText, inst) {
                tinFn.search();
            }
        });

        adm.regType(typeof (phanLoaiFn), 'plugin.rss.phanLoai.Class1, plugin.rss.phanLoai', function () {
            phanLoaiFn.autoComplete(filterByDanhMuc, function (event, ui) {
                $(filterByDanhMuc).val(ui.item.label); $(filterByDanhMuc).attr('_value', ui.item.id);
                tinFn.search();
            });
            $(filterByDanhMuc).unbind('click').click(function () { $(filterByDanhMuc).autocomplete('search', ''); }); ;
        });

        adm.regType(typeof (baoFn), 'plugin.rss.bao.Class1, plugin.rss.bao', function () {
            baoFn.autoComplete(filterByBao, function (event, ui) {
                $(filterByBao).val(ui.item.label); $(filterByBao).attr('_value', ui.item.id);
                tinFn.search();
            });
            $(filterByBao).unbind('click').click(function () { $(filterByBao).autocomplete('search', ''); });
        });

        adm.regType(typeof (nhomFn), 'plugin.rss.nhom.Class1, plugin.rss.nhom', function () {
            nhomFn.autoComplete(filterByNhom, function (event, ui) {
                $(filterByNhom).val(ui.item.label); $(filterByNhom).attr('_value', ui.item.id);
                tinFn.search();
            });
            $(filterByNhom).unbind('click').click(function () { $(filterByNhom).autocomplete('search', ''); }); ;
        });

        adm.regType(typeof (topicFn), 'plugin.rss.topic.topic, plugin.rss.topic', function () {
            topicFn.autoComplete(filterByTopic, function (event, ui) {
                $(filterByTopic).val(ui.item.label); $(filterByTopic).attr('_value', ui.item.id);
                tinFn.search();
            });
            $(filterByTopic).unbind('click').click(function () { $(filterByTopic).autocomplete('search', ''); }); ;
        });
    },
    search: function () {
        var timerSearch;
        var filterByBao = $('.mdl-head-tinFilterByBao');
        var filterByDanhMuc = $('.mdl-head-tinFilterByDanhMuc');
        var filterByNhom = $('.mdl-head-tinFilterByNhom');
        var filterByTopic = $('.mdl-head-tinFilterByTopic');
        var filterByNgay = $('.mdl-head-tinFilterByNgay');
        var searchTxt = $('.mdl-head-search-tinMdl');

        var _B_ID = $(filterByBao).attr('_value');
        var _DM_ID = $(filterByDanhMuc).attr('_value');
        var _N_ID = $(filterByNhom).attr('_value');
        var _T_ID = $(filterByTopic).attr('_value');
        var _Ngay = $(filterByNgay).val();

        var __B_ID = $(filterByBao).val();
        var __DM_ID = $(filterByDanhMuc).val();
        var __N_ID = $(filterByNhom).val();
        var __T_ID = $(filterByTopic).val();
        var __q = $(searchTxt).val();
        if (__DM_ID == '') {
            $(filterByDanhMuc).attr('_value', ''); _DM_ID = '';
        }
        if (__B_ID == '') {
            $(filterByBao).attr('_value', ''); _B_ID = '';
        }
        if (__N_ID == '') {
            $(filterByNhom).attr('_value', ''); _N_ID = '';
        }
        if (__T_ID == '') {
            $(filterByTopic).attr('_value', ''); _T_ID = '';
        }
        if (timerSearch) clearTimeout(timerSearch);

        timerSearch = setTimeout(function () {
            $('#tinMdl-List').jqGrid('setGridParam', { url: tinFn.urlDefault
            + '&subAct=get'
            + '&Bao=' + _B_ID
            + '&DM_ID=' + _DM_ID
            + '&TpId=' + _T_ID
             + '&Nid=' + _N_ID
             + '&Ngay=' + _Ngay
             + '&q=' + __q
            }).trigger("reloadGrid");
        }, 1000);
    },
    loadTinList: function (_id) {

        // Lưới của nhóm
        $('#tinMdl-subTinNhomMdl-List').jqGrid({
            url: tinFn.urlDefault + '&subAct=getNhomByTinId&ID=' + _id,
            height: '400',
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Thứ tự', 'Active'],
            colModel: [
            { name: 'N_ID', key: true, sortable: true, hidden: true },
            { name: 'N_Ten', width: 20, sortable: false },
            { name: 'N_ThuTu', width: 5, resizable: true, sortable: false },
            { name: 'N_Active', width: 5, resizable: true, sortable: false }
        ],
            caption: 'Nhóm',
            autowidth: true,
            sortname: 'B_ID',
            height: 200,
            sortorder: 'desc',
            rowNum: 10000,
            rowNum: 20,
            rowList: [5, 10, 20, 30],
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-tinMdl-subTinNhomMdl');
                adm.regQS(searchTxt, 'tinMdl-subTinNhomMdl-List');
            }
        });
        // Lưới của Topic
        $('#tinMdl-subTinTopicMdl-List').jqGrid({
            url: tinFn.urlDefault + '&subAct=getTopicByTinId&ID=' + _id,
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Thứ tự', 'Mô tả', 'Active'],
            colModel: [
            { name: 'TP_ID', key: true, sortable: true, hidden: true },
            { name: 'TP_Ten', width: 30, resizable: true, sortable: false, editable: true },
            { name: 'TP_ThuTu', width: 5, resizable: true, sortable: false, editable: true },
            { name: 'TP_MoTa', width: 20, resizable: true, sortable: false, editable: true },
            { name: 'TP_Active', width: 5, resizable: true, sortable: false }
            ],
            caption: 'Chủ đề',
            autowidth: true,
            sortname: 'DM_ID',
            sortorder: 'desc',
            height: 200,
            rowNum: 1000,
            rowList: [5, 100, 200, 500, 1000],
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-tinMdl-subTinTopicMdl');
                adm.regQS(searchTxt, 'tinMdl-subTinTopicMdl-List');
            }
        });
        // Lưới của Bình luận
        $('#tinMdl-subTinBinhLuanMdl-List').jqGrid({
            url: tinFn.urlDefault + '&subAct=getBinhLuanByTinId&ID=' + _id,
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Nội dung', 'Ngày tạo', 'Email', 'Active', 'Xóa'],
            colModel: [
            { name: 'ID', key: true, sortable: true, hidden: true },
            { name: 'Ten', width: 5, sortable: false },
            { name: 'NoiDung', width: 20, resizable: true, sortable: false },
            { name: 'NgayTao', width: 5, resizable: true, sortable: false },
            { name: 'Email', width: 5, resizable: true, sortable: false },
            { name: 'Active', width: 5, resizable: true, sortable: false },
            { name: 'Xoa', width: 5, resizable: true, sortable: false }
        ],
            caption: 'Bình luận',
            autowidth: true,
            sortname: 'B_ID',
            height: 200,
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 10, 20, 30],
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-tinMdl-subTinBinhLuanMdl');
                adm.regQS(searchTxt, 'tinMdl-subTinBinhLuanMdl-List');
            }
        });

    },
    reLoadTinList: function (_id) {
        $('#tinMdl-subTinNhomMdl-List').jqGrid('setGridParam', { url: tinFn.urlDefault + '&subAct=getNhomByTinId&ID=' + _id }).trigger('reloadGrid');
        $('#tinMdl-subTinTopicMdl-List').jqGrid('setGridParam', { url: tinFn.urlDefault + '&subAct=getTopicByTinId&ID=' + _id }).trigger('reloadGrid');
        $('#tinMdl-subTinBinhLuanMdl-List').jqGrid('setGridParam', { url: tinFn.urlDefault + '&subAct=getBinhLuanByTinId&ID=' + _id }).trigger('reloadGrid');
    },
    saveTopic: function (_obj, _id) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: tinFn.urlDefault + '&subAct=saveTopic&ID=' + _id,
            data: { 'TpId': _objId, 'Active': _ck },
            success: function (_dt) { }
        });
    },
    saveTinAttr: function (_obj, _id, _params) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: tinFn.urlDefault + '&subAct=saveTinAttr&' + _params + '=' + _ck +  '&ID=' + _id,
            success: function (_dt) { }
        });
    },
    saveNhom: function (_obj, _id) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: tinFn.urlDefault + '&subAct=saveNhom&ID=' + _id,
            data: { 'Nid': _objId, 'Active': _ck },
            success: function (_dt) { }
        });
    },
    saveBinhLuan: function (_obj, _id) {
        var obj = $(_obj);
        var _ck = $(obj).is(':checked');
        var _objId = $(obj).attr('_id');
        $.ajax({
            url: tinFn.urlDefault + '&subAct=saveBinhLuan&ID=' + _id,
            data: { 'BlId': _objId, 'Active': _ck },
            success: function (_dt) { }
        });
    },
    xoaBinhLuan: function (_obj, _id) {
        var con = confirm('Bạn có muốn xóa bình luận');
        if (con) {
            var obj = $(_obj);
            $.ajax({
                url: tinFn.urlDefault + '&subAct=xoaBinhLuan&ID=' + _id,
                data: { 'BlId': _id },
                success: function (_dt) {
                    $(obj).parent().parent().remove();
                }
            });
        }
    },
    edit: function () {
        var s = '';
        if (jQuery('#tinMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#tinMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                tinFn.loadHtml(function () {
                    var newDlg = $('#tinMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        height: 700,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                tinFn.save(false, function () { tinFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                tinFn.save(false, function () { tinFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            tinFn.clearform();
                            tinFn.popfn();
                            $.ajax({
                                url: tinFn.urlDefault + '&subAct=edit',
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
                                    var Url = $('.Url', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    var spbMsg = $('.admMsg', newDlg);
                                    $(ID).val(dt.ID);
                                    $(DM_ID).val(dt.CM_Ten);
                                    $(DM_ID).attr('_value', dt.CM_ID);
                                    $(Ten).val(dt.Ten);
                                    $(Url).html(dt.Url).attr('href', dt.Url);
                                    $(MoTa).val(dt.MoTa);
                                    $(NoiDung).val(dt.NoiDung);

                                    if (dt.Anh != '') {
                                        $(lblAnh).attr('ref', dt.Anh);
                                        $(lblAnhPrvImg).attr('src', '../up/' + dt.Anh + '?ref=' + Math.random());
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
        if (jQuery('#tinMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#tinMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: tinFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery('#tinMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#tinMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Url = $('.Url', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _DM_ID = $(DM_ID).attr('_value');
        var _Ten = $(Ten).val();
        var _MoTa = $(MoTa).val();
        var _NoiDung = $(NoiDung).val();
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
            url: tinFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type:'POST',
            data: {
                'ID': _ID,
                'DM_ID': _DM_ID,
                'Ten': _Ten,
                'MoTa': _MoTa,
                'NoiDung': _NoiDung,
                'Anh': _anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#tinMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        tinFn.loadHtml(function () {
            var newDlg = $('#tinMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        tinFn.save(false, function () {
                            tinFn.clearform();
                        }, '#tinMdl-List');
                    },
                    'Lưu và đóng': function () {
                        tinFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#tinMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    tinFn.clearform();
                    tinFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#tinMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        adm.createFck(NoiDung);

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
                $(uploadView).attr('src', '../up/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();

    },
    clearform: function () {
        var newDlg = $('#tinMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Url = $('.Url', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var lblAnhPrv = $('.adm-upload-preview', newDlg);
        var lblAnhPrvImg = $(lblAnhPrv).find('img');
        var spbMsg = $('.admMsg', newDlg);

        $(ID).val('');
        $(DM_ID).val('');
        $(DM_ID).attr('_value', '');
        $(Ten).val('');
        $(Url).html('');
        $(MoTa).val('');
        $(NoiDung).val('');
        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');
        spbMsg.html('');
    },
    autoCompleteSearch: function (el, fn) {
        function split(val) {
            return val.split(/;\s*/);
        }
        function extractLast(term) {
            return split(term).pop();
        }
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'tinFn-autoComplete-' + request.term;
                if (term in _cache) {
                    response($.map(_cache[term], function (item) {
                        return {
                            label: item.Ten,
                            value: item.Ten,
                            id: item.ID
                        }
                    }))
                    return;
                }
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: tinFn.urlDefault + '&subAct=autoCompleteSearch',
                    dataType: 'script',
                    data: { 'q': request.term },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            response($.map(_cache[term], function (item) {
                                return {
                                    label: item.Ten,
                                    value: item.Ten,
                                    id: item.ID
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
            delay: 500
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    loadHtml: function (fn) {
        var dlg = $('#tinMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.rss.tin.htm.htm")%>',
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
