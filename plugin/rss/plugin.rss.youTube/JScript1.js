var youTuBeFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.rss.youTube.Class1, plugin.rss.youTube',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('.sub-mdl').tabs();
        $('#youTuBeMdl-List').jqGrid({
            url: youTuBeFn.urlDefault + '&subAct=get',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Ảnh', 'Tên', 'Url', 'Mô tả', 'Điểm/ Xem', 'Active', 'Hot', 'Hot1', 'Hot2', 'Hot3', 'Home'],
            colModel: [
            { name: 'V_ID', key: true, sortable: true, hidden: true },
            { name: 'V_Anh', width: 50, sortable: false, editable: true },
            { name: 'V_Ten', width: 30, resizable: true, sortable: false, editable: true },
            { name: 'V_Url', width: 50, resizable: true, sortable: false, editable: true },
            { name: 'V_MoTa', width: 50, resizable: true, sortable: false, editable: true },
            { name: 'V_Views', width: 50, resizable: true, sortable: false, editable: true },
            { name: 'V_Active', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'V_Hot', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'V_Hot1', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'V_Hot2', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'V_Hot3', width: 5, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'V_Home', width: 5, resizable: true, sortable: false, formatter: 'checkbox' }
            ],
            caption: 'Video',
            autowidth: true,
            sortname: 'V_ID',
            sortorder: 'desc',
            height: 200,
            rowNum: 1000,
            rowList: [5, 100, 200, 500, 1000],
            editurl: youTuBeFn.urlDefault + '&subAct=save',
            onSelectRow: function (rowid) {
            },
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-youTuBeMdl'); adm.regQS(searchTxt, 'youTuBeMdl-List');
            }
        });
    },
    edit: function () {
        var s = '';
        if (jQuery('#youTuBeMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#youTuBeMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                youTuBeFn.loadHtml(function () {
                    var newDlg = $('#youTuBeMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                youTuBeFn.save(false, function () { youTuBeFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                youTuBeFn.save(false, function () { youTuBeFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            youTuBeFn.clearform();
                            youTuBeFn.popfn();
                            $.ajax({
                                url: youTuBeFn.urlDefault + '&subAct=edit',
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
                                    var YID = $('.YID', newDlg);
                                    var Views = $('.Views', newDlg);
                                    var Diem = $('.Diem', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var Home = $('.Home', newDlg);
                                    var Hot = $('.Hot', newDlg);
                                    var Hot1 = $('.Hot1', newDlg);
                                    var Hot2 = $('.Hot2', newDlg);
                                    var Hot3 = $('.Hot3', newDlg);

                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    var spbMsg = $('.admMsg', newDlg);


                                    $(ID).val(dt.ID);
                                    if (dt.DanhMuc != null) {
                                        $(DM_ID).val(dt._DanhMuc.Ten);
                                        $(DM_ID).attr('_value', dt.DM_ID);
                                    }
                                    $(Ten).val(dt.Ten);
                                    $(Url).val(dt.Url);
                                    $(MoTa).val(dt.MoTa);
                                    $(Views).val(dt.Views);
                                    $(Diem).val(dt.Diem);
                                    $(YID).val(dt.YID);
                                    if (dt.Active) { $(Active).attr('checked', 'checked'); } else { $(Active).removeAttr('checked'); }
                                    if (dt.Hot) { $(Hot).attr('checked', 'checked'); } else { $(Hot).removeAttr('checked'); }
                                    if (dt.Hot1) { $(Hot1).attr('checked', 'checked'); } else { $(Hot1).removeAttr('checked'); }
                                    if (dt.Hot2) { $(Hot2).attr('checked', 'checked'); } else { $(Hot2).removeAttr('checked'); }
                                    if (dt.Home) { $(Home).attr('checked', 'checked'); } else { $(Home).removeAttr('checked'); }
                                    if (dt.Hot3) { $(Hot3).attr('checked', 'checked'); } else { $(Hot3).removeAttr('checked'); }
                                    if (dt.Anh != '') {
                                        $(lblAnh).attr('ref', dt.Anh);
                                        $(lblAnhPrvImg).attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
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
        if (jQuery('#youTuBeMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = $('#youTuBeMdl-List').jqGrid('getGridParam', 'selrow').toString();
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
                        url: youTuBeFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            $('#youTuBeMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#youTuBeMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Url = $('.Url', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var YID = $('.YID', newDlg);
        var Views = $('.Views', newDlg);
        var Diem = $('.Diem', newDlg);
        var Active = $('.Active', newDlg);
        var Home = $('.Home', newDlg);
        var Hot = $('.Hot', newDlg);
        var Hot1 = $('.Hot1', newDlg);
        var Hot2 = $('.Hot2', newDlg);
        var Hot3 = $('.Hot3', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _DM_ID = $(DM_ID).attr('_value');
        var _Ten = $(Ten).val();
        var _Url = $(Url).val();
        var _MoTa = $(MoTa).val();
        var _YID = $(YID).val();
        var _Views = $(Views).val();
        var _Diem = $(Diem).val();
        var _Active = $(Active).is(':checked');
        var _Home = $(Home).is(':checked');
        var _Hot = $(Hot).is(':checked');
        var _Hot1 = $(Hot1).is(':checked');
        var _Hot2 = $(Hot2).is(':checked');
        var _Hot3 = $(Hot3).is(':checked');
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
            url: youTuBeFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type:'POST',
            data: {
                'ID': _ID,
                'DM_ID': _DM_ID,
                'Ten': _Ten,
                'Url': _Url,
                'MoTa': _MoTa,
                'YID': _YID,
                'Views': _Views,
                'Diem': _Diem,
                'Active': _Active,
                'Home': _Home,
                'Hot': _Hot,
                'Hot1': _Hot1,
                'Hot2': _Hot2,
                'Hot3': _Hot3,
                'Anh': _anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#youTuBeMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        youTuBeFn.loadHtml(function () {
            var newDlg = $('#youTuBeMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        youTuBeFn.save(false, function () {
                            youTuBeFn.clearform();
                        }, '#youTuBeMdl-List');
                    },
                    'Lưu và đóng': function () {
                        youTuBeFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#youTuBeMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    youTuBeFn.clearform();
                    youTuBeFn.popfn();
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#youTuBeMdl-dlgNew');
        var DM_ID = $('.DM_ID', newDlg);
        var Url = $('.Url', newDlg);
        var Ten = $('.Ten', newDlg);
        var Url = $('.Url', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var YID = $('.YID', newDlg);

        var lblAnh = $('.Anh', newDlg);
        var lblAnhPrv = $('.adm-upload-preview', newDlg);
        var lblAnhPrvImg = $(lblAnhPrv).find('img');

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
                $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();
        adm.validElValAjax(Url, function (_v, _t) {
            $.ajax({
                url: youTuBeFn.urlDefault + '&subAct=wrappUrl',
                dataType: 'script',
                data: {
                    'Url': _v
                },
                success: function (_dt) {
                    var dt = eval(_dt);
                    $(Ten).val(dt.Ten);
                    $(MoTa).val(dt.MoTa);
                    $(YID).val(dt.YId);
                    $(lblAnh).attr('ref', dt.Anh);
                    $(lblAnhPrvImg).attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
                }
            })
        });
    },

    clearform: function () {
        var newDlg = $('#youTuBeMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Url = $('.Url', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var YID = $('.YID', newDlg);
        var Views = $('.Views', newDlg);
        var Diem = $('.Diem', newDlg);
        var Active = $('.Active', newDlg);
        var Home = $('.Home', newDlg);
        var Hot = $('.Hot', newDlg);
        var Hot1 = $('.Hot1', newDlg);
        var Hot2 = $('.Hot2', newDlg);
        var Hot3 = $('.Hot3', newDlg);
        var lblAnh = $('.Anh', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(ID).val('');
        $(DM_ID).val('');
        $(DM_ID).attr('_value', '');
        $(Ten).val('');
        $(Url).val('');
        $(MoTa).val('');
        $(YID).val('');
        $(Views).val('');
        $(Diem).val('');
        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#youTuBeMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.rss.youTube.htm.htm")%>',
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
