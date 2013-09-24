var danhmuc = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu danh mục');
        var LDMID = $('.mdl-head-filterloaidanhmuc');
        $('#danhmucmdl-List').jqGrid({
            url: danhmuc.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'LangBased', '_ID', 'Lang', 'Thứ tự', 'Loại Danh Mục', 'Mã', 'Ký Hiệu', 'Giá Trị', 'Ảnh', 'Tên', 'Ngày cập nhật', 'Người tạo/sửa'],
            colModel: [
                        { name: 'DM_ID', key: true, sortable: true, hidden: true },
                        { name: 'LangBased', key: true, sortable: true, hidden: true },
                        { name: '_DM_ID', key: true, sortable: true, hidden: true },
                        { name: 'DM_Lang', width: 2, sortable: true, align: "center", hidden: true },
                        { name: 'DM_ThuTu', width: 2, sortable: true },
                        { name: 'LDM_Ten', width: 10, resizable: true, sortable: true },
                        { name: 'DM_Ma', width: 10, resizable: true, sortable: true },
                        { name: 'DM_KyHieu', width: 10, resizable: true, sortable: true },
                        { name: 'DM_GiaTri', width: 10, resizable: true, sortable: true },
                        { name: 'DM_Anh', width: 5, resizable: true, sortable: true },
                        { name: 'DM_Ten', width: 40, resizable: true, sortable: true },
                        { name: 'DM_NgayCapNhat', width: 5, resizable: true, sortable: true, align: "center" },
                        { name: 'DM_NguoiTao ', width: 5, resizable: false, sortable: true, align: "center" }
                    ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'DM_ThuTu',
            sortorder: 'asc',
            rowNum: 10000,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                if (typeof (Ajax_upload) == 'undefined') {
                    $.getScript('../js/ajaxupload.js', function () { });
                };
                adm.loading(null);
                adm.regType(typeof (loaidanhmuc), 'docsoft.plugin.loaidanhmuc.Class1,docsoft.plugin.loaidanhmuc', function () {
                    loaidanhmuc.setAutocomplete(LDMID, function (event, ui) {
                        $(LDMID).attr('_value', ui.item.id);
                        danhmuc.search();
                    });
                    $(LDMID).unbind('click').click(function () {
                        $(LDMID).autocomplete('search', '');
                    });
                });
                adm.regQS($('.mdl-head-search-danhmuc'), 'danhmucmdl-List');
            },
            treeGrid: true,
            ExpandColumn: 'DM_Ten',
            treeGridModel: 'adjacency',
            ExpandColClick: false,
            treeIcons: { leaf: 'ui-icon-document-b' }
        });
        adm.watermark(LDMID, 'Gõ tên loại danh mục để lọc', function () {
        });
        var changeLangBtn = $('#danhMucMdl-changeLangSlt');
        $(changeLangBtn).find('option').remove();
        $.each(LangArr, function (i, item) {
            if (item.Active) {
                Lang = item.Ma;
            }
            $(changeLangBtn).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
        });
        $(changeLangBtn).val(Lang);
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#danhmucmdl-List';

        if (jQuery(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var treedata = $(grid).jqGrid('getRowData', s);
                var __DM_ID = treedata._DM_ID;
                var _DM_ID = treedata.DM_ID;
                var _Lang = treedata.DM_Lang;
                if (__DM_ID == '0') { alert('Danh mục này chưa tồn tại ở ngôn ngữ ' + _Lang); return false; }
                danhmuc.loadHtml(function () {
                    var newDlg = $('#danhmucmdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        modal: false,
                        buttons: {
                            'Lưu': function () {
                                danhmuc.save(false, function () {
                                    danhmuc.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                danhmuc.save(false, function () {
                                    danhmuc.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            danhmuc.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            danhmuc.clearform();
                            danhmuc.popfn();
                            $.ajax({
                                url: danhmuc.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': __DM_ID
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg); ;
                                    var LangBased = $('.LangBased', newDlg);
                                    var LangBased_ID = $('.LangBased_ID', newDlg);
                                    var LDMID = $('.LDMID', newDlg);
                                    var PID = $('.PID', newDlg);
                                    var LangTxt = $('.Lang', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var KyHieu = $('.KyHieu', newDlg);
                                    var GiaTri = $('.GiaTri', newDlg);
                                    var KeyWords = $('.KeyWords', newDlg);
                                    var Description = $('.Description', newDlg);
                                    var ThuTu = $('.ThuTu', newDlg);
                                    var NguoiTao = $('.NguoiTao', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    PID.val('');
                                    PID.attr('_value', '');

                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var Anh = $('.Anh', newDlg);

                                    imgAnh.attr('src', '');
                                    Anh.attr('ref', '');

                                    Anh.attr('ref', dt.Anh);
                                    imgAnh.attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());

                                    ID.val(dt.ID);
                                    LangBased_ID.val(dt.LangBased_ID);
                                    if (dt.LangBased) {
                                        $(LangBased).attr('checked', 'checked');
                                    }
                                    else {
                                        $(LangBased).removeAttr('checked');
                                    }
                                    LDMID.val(dt.LDM_Ten);
                                    LDMID.attr('_value', dt.LDM_ID);
                                    PID.val(dt.PID_Ten);
                                    PID.attr('_value', dt.PID);
                                    LangTxt.val(dt.Lang);
                                    Ten.val(dt.Ten);
                                    Alias.val(dt.Alias);
                                    Ma.val(dt.Ma);
                                    KyHieu.val(dt.KyHieu);
                                    GiaTri.val(dt.GiaTri);
                                    KeyWords.val(dt.KeyWords);
                                    Description.val(dt.Description);
                                    ThuTu.val(dt.ThuTu);
                                    NguoiTao.val(dt.NguoiTao);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    addLang: function () {
        var s = '';
        if (jQuery('#danhmucmdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#danhmucmdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu mẩu tin');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var treedata = $("#danhmucmdl-List").jqGrid('getRowData', s);
                var _DM_ID = treedata.DM_ID;
                danhmuc.loadHtml(function () {
                    var newDlg = $('#danhmucmdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Thêm mới',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                danhmuc.save(false, function () {
                                    danhmuc.clearform();
                                }, '#danhmucmdl-List');
                            },
                            'Lưu và đóng': function () {
                                danhmuc.save(false, function () {
                                    $(newDlg).dialog('close');
                                }, '#danhmucmdl-List');
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            danhmuc.clearform();
                        },
                        open: function () {
                            adm.styleButton();
                            danhmuc.clearform();
                            danhmuc.popfn();
                            var LangBased_ID = $('.LangBased_ID', newDlg);
                            LangBased_ID.val(s);
                            var LangBased = $('.LangBased', newDlg);
                            $(LangBased).removeAttr('checked');

                            $.ajax({
                                url: danhmuc.urlDefault().toString(),
                                dataType: 'script',
                                data: {
                                    'subAct': 'edit',
                                    'ID': _DM_ID
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var LangBased_ID = $('.LangBased_ID');
                                    var LDMID = $('.LDMID');
                                    var PID = $('.PID');
                                    var LangTxt = $('.Lang');
                                    var Ten = $('.Ten');
                                    var Alias = $('.Alias');
                                    var Ma = $('.Ma');
                                    var KyHieu = $('.KyHieu');
                                    var GiaTri = $('.GiaTri');
                                    var KeyWords = $('.KeyWords');
                                    var Description = $('.Description');
                                    var ThuTu = $('.ThuTu');
                                    var NguoiTao = $('.NguoiTao');
                                    var spbMsg = $('.admMsg', newDlg);

                                    LangBased_ID.val(dt.LangBased_ID);
                                    LDMID.val(dt.LDM_Ten);
                                    LDMID.attr('_value', dt.LDM_ID);
                                    PID.val(dt.PID_Ten);
                                    PID.attr('_value', dt.PID);
                                    LangTxt.val(dt.Lang);
                                    Ten.val(dt.Ten);
                                    Alias.val(dt.Alias);
                                    Ma.val(dt.Ma);
                                    KyHieu.val(dt.KyHieu);
                                    GiaTri.val(dt.GiaTri);
                                    KeyWords.val(dt.KeyWords);
                                    Description.val(dt.Description);
                                    ThuTu.val(dt.ThuTu);
                                    NguoiTao.val(dt.NguoiTao);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function () {
        danhmuc.loadHtml(function () {
            var newDlg = $('#danhmucmdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                buttons: {
                    'Lưu': function () {
                        danhmuc.save(false, function () {
                            danhmuc.clearform();
                        }, '#danhmucmdl-List');
                    },
                    'Lưu và đóng': function () {
                        danhmuc.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#danhmucmdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    danhmuc.clearform();
                },
                modal: false,
                open: function () {
                    adm.styleButton();
                    danhmuc.clearform();
                    danhmuc.popfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#danhmucmdl-List';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa danh mục này?')) {// Xác nhận xem có xóa hay không
                    var treedata = $(grid).jqGrid('getRowData', s); // Lấy row hiện tại đang select
                    var __DM_ID = treedata._DM_ID; // Lấy DM_ID thật của danh mục
                    $.ajax({
                        url: danhmuc.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: { 'ID': __DM_ID },
                        success: function (dt) {
                            jQuery(grid).trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn, grid) {
        if (typeof (grid) == 'undefined') grid == '#danhmucmdl-List';
        var newDlg = $('#danhmucmdl-dlgNew');
        var ID = $('.ID', newDlg);
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var LDMID = $('.LDMID', newDlg);
        var PID = $('.PID', newDlg);
        var LangTxt = $('.Lang', newDlg);
        var Ten = $('.Ten', newDlg);
        var Alias = $('.Alias', newDlg);
        var Ma = $('.Ma', newDlg);
        var KyHieu = $('.KyHieu', newDlg);
        var GiaTri = $('.GiaTri', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var Anh = $('.Anh', newDlg);

        var _Anh = $(Anh).attr('ref');
        var _ID = ID.val();
        var _LangBased_ID = LangBased_ID.val();
        var _LangBased = $(LangBased).is(':checked');
        var _LDMID = LDMID.attr('_value');
        var _PID = PID.attr('_value');
        var _Lang = LangTxt.val();
        var _Ten = Ten.val();
        var _Alias = Alias.val();
        var _Ma = Ma.val();
        var _KyHieu = KyHieu.val();
        var _GiaTri = GiaTri.val();
        var _Keywords = $(KeyWords).val();
        var _Description = Description.val();
        var _ThuTu = ThuTu.val();
        var err = '';
        if (_LDMID == '') { err += 'Chọn loại danh mục<br/>'; }; if (_Ten == '') { err += 'Nhập tên<br/>'; };
        if (_ThuTu == '') { _ThuTu = '0'; } else { if (!adm.isInt(_ThuTu)) { err += 'Nhập thứ tự kiểu số<br/>'; } }
        //if (!_LangBased) { if (_Lang == Lang) { err += 'Chọn ngôn ngữ khác'; }; }
        //else { if (_Lang != Lang) { err += 'Bạn cần chọn ngôn ngữ gốc ' + Lang; }; }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: danhmuc.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                'ID': _ID,
                'LangBased': _LangBased,
                'LangBased_ID': _LangBased_ID,
                'LDMID': _LDMID,
                'PID': _PID,
                'Lang': _Lang,
                'Ten': _Ten,
                'Alias': _Alias,
                'Ma': _Ma,
                'KyHieu': _KyHieu,
                'GiaTri': _GiaTri,
                'KeyWords': _Keywords,
                'Description': _Description,
                'ThuTu': _ThuTu,
                'Anh': _Anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    $(grid).trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    search: function () {
        var timerSearch;
        var LDMID = $('.mdl-head-filterloaidanhmuc');
        var _Lang = $('#danhMucMdl-changeLangSlt').val();
        var _LDMID = $(LDMID).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#danhmucmdl-List').jqGrid('setGridParam', { url: danhmuc.urlDefault().toString() + '&subAct=get&LDMID=' + _LDMID + '&Lang=' + _Lang }).trigger('reloadGrid');
        }, 500);
    },
    popfn: function () {
        var newDlg = $('#danhmucmdl-dlgNew');
        var LDMID = $('.LDMID', newDlg);
        var PID = $('.PID', newDlg);
        var ID = $('.ID', newDlg);
        var Description = $('.Description', newDlg);
        loaidanhmuc.setAutocomplete(LDMID, function (event, ui) {
            $(LDMID).attr('_value', ui.item.id);
            $(LDMID).attr('_ma', ui.item.ma);
            danhmuc.autoCompleteLangBased(_ID, $(LDMID).attr('_ma'), PID, function (event, _ui) {
                $(PID).attr('_ma', _ui.item.ma);
                $(PID).attr('_value', _ui.item.id);
            });
        });
        $(LDMID).unbind('click').click(function () { $(LDMID).autocomplete('search', ''); });

        var _ID = ID.val();

        danhmuc.autoCompleteLangBased(_ID, $(LDMID).attr('_ma'), PID, function (event, ui) {
            $(PID).attr('_ma', ui.item.ma);
            $(PID).attr('_value', ui.item.id);
        });

        $(PID).unbind('click').click(function () { $(PID).autocomplete('search', ''); });
        var LangSlt = $('.Lang', newDlg);
        if ($(LangSlt).children().length > 0) { return false; }
        $(LangSlt).find('option').remove();
        $.each(LangArr, function (i, item) {
            if (item.Active) {
                Lang = item.Ma;
            }
            $(LangSlt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
        });
        adm.createTinyMce(Description);
        var ulpFn = function () {
            var imgAnh = $('.adm-upload-preview-img', newDlg);
            var Anh = $('.Anh', newDlg);
            var _params = { 'oldFile': $(Anh).attr('ref') };
            adm.upload(Anh, 'anh', _params, function (rs) {
                $(Anh).attr('ref', rs)
                $(imgAnh).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
            }, function (f) { });
        }
        ulpFn();
    },
    clearform: function () {
        var newDlg = $('#danhmucmdl-dlgNew');
        var ID = $('.ID');
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var LDMID = $('.LDMID', newDlg);
        var PID = $('.PID', newDlg);
        var LangTxt = $('.Lang', newDlg);
        var Ten = $('.Ten', newDlg);
        var Alias = $('.Alias', newDlg);
        var Ma = $('.Ma', newDlg);
        var KyHieu = $('.KyHieu', newDlg);
        var GiaTri = $('.GiaTri', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var Anh = $('.Anh', newDlg);

        imgAnh.attr('src', '');
        Anh.attr('ref', '');
        ID.val('');
        LangBased_ID.val('');
        Ten.val('');
        Alias.val('');
        Ma.val('');
        KyHieu.val('');
        GiaTri.val('');
        KeyWords.val('');
        Description.val('');
        ThuTu.val('');
        NguoiTao.val('');
        $(spbMsg).html('');
    },
    autoCompleteLangBased: function (id, ldm_ma, el, fn, fn1) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'danhMuc-autoCompleteLangBased' + id + ldm_ma;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteLangBased', 'LDM_Ma': ldm_ma, 'ID': id },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri,
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
        });
    },
    autoCompleteLangBasedNoChild: function (ldm_ma, el, fn, fn1) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'danhMuc-autoCompleteLangBased' + ldm_ma;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteLangBasedNoChild', 'LDM_Ma': ldm_ma},
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri,
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
        });
    },
    autoCompleteByPid: function (el, fn, fn1) {
        var id = el.attr('data-pid');
        if (id == '')
            return;
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'danhMuc-autoCompleteByPid' + id;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteByPid', 'ID': id },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri,
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
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    //
    autoCompleteDanhMucByLang: function (id, ldm_ma, el, lang, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'danhMuc-autoCompleteLangBased' + id + ldm_ma;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteDanhMucByLang', 'LDM_Ma': ldm_ma, 'ID': id, 'Lang': lang },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri,
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
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    autoCompleteByUserLdmMa: function (id, ldm_ma, el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'danhMuc-autoCompleteByUserLdmMa-' + id + ldm_ma;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteByUserLdmMa', 'LDM_Ma': ldm_ma, 'ID': id },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri,
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
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\"><b>" + item.ma + '</b> ' + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    ///hampv
    autoCompleteLangBasedByDM: function (id, dm_ma, el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'danhMuc-autoCompleteLangBasedByDM' + id + dm_ma;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteLangBasedByDM', 'Ma': dm_ma, 'ID': id },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri,
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
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    }
    ,
    autoCompleteByLoai: function (s, el, fn, fn1, fn2) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'autoCompleteByLoai-' + s;
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                rowid: item.RowId,
                                ma: item.Ma,
                                kyhieu: item.KyHieu,
                                giatri: item.GiaTri
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString() + '&subAct=autoCompleteLdmMa',
                    dataType: 'script',
                    data: {
                        'q': '',
                        'LDM_Ma': s
                    },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                                    if (typeof (fn1) == "function") {
                                        return fn1(item);
                                    } else {
                                        return {
                                            label: item.Ten,
                                            value: item.Ten,
                                            id: item.ID,
                                            //pid: item.d,
                                            rowid: item.RowId,
                                            ma: item.Ma,
                                            kyhieu: item.KyHieu,
                                            giatri: item.GiaTri
                                        };
                                    }
                                }
                            }));
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
            if (typeof (fn2) == "function") {
                return fn2(ul, item);
            }
            else {
                return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
            }
        };
    }
    ,

    autocompleteSelectPidByMa: function (id, ldm_ma, el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'danhMuc-autocompleteSelectPidByMa' + id + ldm_ma;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autocompleteSelectPidByMa', 'LDM_Ma': ldm_ma, 'ID': id },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri,
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
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    autoCompleteByLoaiLang: function (s, el, lang, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'autoCompleteByLoai-' + s;
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                rowid: item.RowId,
                                ma: item.Ma,
                                kyhieu: item.KyHieu,
                                giatri: item.GiaTri
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString() + '&subAct=getPidByDm',
                    dataType: 'script',
                    data: {
                        'q': '',
                        'LDMID': s,
                        'Lang': lang
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
                                        //pid: item.d,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri
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
    autoCompleteCategoriesByLoai: function (s, el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'autoCompleteByLoai-' + s;
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                rowid: item.RowId,
                                ma: item.Ma,
                                kyhieu: item.KyHieu,
                                giatri: item.GiaTri
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString() + '&subAct=getPidByDm',
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
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri
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
        }).data("autocomplete")
        //        ._renderItem = function (ul, item) {
        //            return $("<li></li>")
        //				            .data("item.autocomplete", item)
        //				            .append("<a>" + item.ma + ": " + item.label + "</a>")
        //				            .appendTo(ul);
        //        }
        ._renderMenu = function (ul, items) {
            var self = this,
				currentCategory = "";
            $.each(items, function (index, item) {
                if (item.giatri != currentCategory) {
                    ul.append("<li class='ui-autocomplete-category'>" + item.label + "</li>");
                    currentCategory = item.giatri;
                }
                self._renderItem(ul, item);
            });
        };
    },
    autoCompleteByLoaiNguoiThao: function (s, el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'danhMuc-autoCompleteByLoai-CB_STVB' + s;
                term = term + request.term;
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString() + '&subAct=autoCompleteByLoaiNguoiThao',
                    dataType: 'script',
                    data: {
                        'q': request.term
                    },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten
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
                    if ($(this).val() != '') {
                        danhmuc.QuickSave(el, 'CB_STVB', function (dt) {
                        });
                    }
                }
            },
            delay: 0,
            selectFirst: true
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    autoCompleteByLoaiMultiple: function (s, el, fn) {
        function split(val) {
            return val.split(/;\s*/);
        }
        function extractLast(term) {
            return split(term).pop();
        }
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'autoCompleteByLoai-' + s;
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(extractLast(request.term)), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                rowid: item.RowId,
                                ma: item.Ma,
                                kyhieu: item.KyHieu,
                                giatri: item.GiaTri
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: danhmuc.urlDefault().toString() + '&subAct=getPidByDm',
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
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma,
                                        kyhieu: item.KyHieu,
                                        giatri: item.GiaTri
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
    autoSelectByLoai: function (s, el, fn) {
        $(el).html('Nạp danh sách');
        adm.loading('Nạp danh sách đơn vị');
        $.ajax({
            url: danhmuc.urlDefault().toString() + '&subAct=getPidByDm',
            dataType: 'script',
            data: {
                'q': '',
                'LDMID': s
            },
            success: function (dt) {
                $(el).html('');
                adm.loading(null);
                var data = eval(dt);
                if ($(el).length > 0) {
                    $.each(data, function (i, item) {
                        $(el).append('<span class=\"adm-selectList-item\"><input _role=\"cid\" chinh=\"0\"  _value=\"' + item.RowId + '\" type=\"checkbox\" /> ' + item.Ten + '</span>');
                    });
                    $(el).find('input').unbind('click').click(function () {
                        var item = this;
                        if (typeof (fn) == 'function') {
                            fn(item);
                        }
                    });
                }
            }
        });
    },
    setSelectByLoaiAndPid: function (s, pid, el, fn) {
        $(el).html('Nạp danh sách');
        adm.loading('Nạp danh sách đơn vị');
        $.ajax({
            url: danhmuc.urlDefault().toString() + '&subAct=getByLdmAndPID',
            dataType: 'script',
            data: {
                'PID': pid,
                'LDMID': s
            },
            success: function (dt) {
                $(el).html('');
                adm.loading(null);
                var data = eval(dt);
                if ($(el).length > 0) {
                    $.each(data, function (i, item) {
                        $(el).append('<span class=\"adm-selectList-item\"><input ' + (item.NguoiTao == '0' ? '' : ' checked=\"checked\" ') + ' _role=\"cid\" chinh=\"0\"  _value=\"' + item.RowId + '\" type=\"checkbox\" /> ' + item.Ten + '</span>');
                    });
                    $(el).find('input').unbind('click').click(function () {
                        var item = this;
                        if (typeof (fn) == 'function') {
                            fn(item);
                        }
                    });
                }
            }
        });
    },
    setSelectNoiNhanList: function (s, pid, el, fn, fn1) {
        $(el).html('Nạp danh sách');
        adm.loading('Nạp danh sách đơn vị');
        $.ajax({
            url: danhmuc.urlDefault().toString() + '&subAct=getNoiNhanList',
            dataType: 'script',
            data: {
                'PID': pid,
                'LDMID': s
            },
            success: function (dt) {
                $(el).html('');
                adm.loading(null);
                $(el).html(dt);
                $(el).find('input[dm=\"0\"]').unbind('click').click(function () {
                    var item = this;
                    var ckb = $(item).is(':checked');
                    var _n = $(item).parent().next();
                    if ($(_n).hasClass('adm-selectList-box')) {
                        if (ckb) {
                            $(_n).find('input').attr('checked', 'checked');
                        }
                        else {
                            $(_n).find('input').removeAttr('checked');
                        }
                    }
                });
                if (typeof (fn1) == 'function') {
                    fn1();
                }
                $(el).find('input[_role=\"cid\"]').unbind('click').click(function () {
                    var item = this;
                    if (typeof (fn) == 'function') {
                        fn(item);
                    }
                });
            }
        });
    },
    loadHtml: function (fn) {
        var dlg = $('#danhmucmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("docsoft.plugin.danhmuc.htm.htm")%>',
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
