var tinQuanLyPhuTrachFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=projectMgr.plugin.backend.tinTuc.QuanLy.PhuTrach.Class1, projectMgr.plugin.backend.tinTuc',
    setup: function () {
    },
    loadgrid: function () {

        adm.loading('Đang lấy dữ liệu tin tức');
        adm.styleButton();
        $('.sub-mdl').tabs();
        var DMID = $('.mdl-head-filterTinBydanh' +
            'muc');
        var searchTxt = $('.mdl-head-search-tin');
        $('#tinQuanLyPhuTrachMdl-List').jqGrid({
            url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'LangBased', '_ID', 'Lang', '#', 'Ảnh', 'Tiêu đề', 'Tóm tắt', 'Mục tin', 'Lần đọc', 'Người viết', 'Ngày cập nhật', 'Kích hoạt', 'Hot', 'Hết hạn', 'Lịch'],
            colModel: [
            { name: 'TIN_ID', key: true, sortable: true, hidden: true },
             { name: 'LangBased', key: true, sortable: true, hidden: true },
            { name: '_TIN_ID', key: true, sortable: true, hidden: true },
            { name: 'TIN_Lang', width: 30, sortable: true, align: "center", hidden: true },
            { name: 'TIN_ThuTu', width: 20, resizable: true, sortable: true, align: "center", hidden: true },
            { name: 'TIN_Anh', width: 5, resizable: true, sortable: true, align: "center" },
            { name: 'TIN_Ten', width: 40, resizable: true, sortable: true },
            { name: 'TIN_MoTa', width: 30, resizable: true, sortable: true, hidden: true },
            { name: 'TIN_DM_Ten', width: 5, sortable: true, hidden: true },
            { name: 'TIN_Views', width: 3, resizable: true, sortable: true, hidden: true },
            { name: 'TIN_NguoiTao', width: 40, resizable: true, sortable: true },
            { name: 'TIN_NgayCapNhat', width: 10, resizable: true, sortable: true },
            { name: 'TIN_Active', width: 5, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true },
            { name: 'TIN_Hot', width: 5, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true },
            { name: 'TIN_HetHan', width: 30, resizable: true, sortable: true, align: "center", formatter: 'checkbox', hidden: true },
            { name: 'TIN_NgayCapNhat', width: 10, resizable: true, sortable: true }
        ],
            caption: 'Danh sách tin',
            autowidth: true,
            sortname: 'TIN_NgayTao',
            sortorder: 'desc',
            rowNum: 100,
            rowList: [10, 20, 50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            pager: jQuery('#tinQuanLyPhuTrachMdl-Pagerql'),
            onSelectRow: function (rowid) {
                tinQuanLyPhuTrachFn.changeSubTin(rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                if (typeof (Ajax_upload) == 'undefined') {
                    $.getScript('../js/ajaxupload.js', function () { });
                };
                tinQuanLyPhuTrachFn.loadTinList();
                tinQuanLyPhuTrachFn.SubtinQuanLyPhuTrachFn();
                //adm.regQS(searchTxt, 'tinQuanLyPhuTrachMdl-List');
                adm.watermarks(DMID, 'Gõ tên mục tin để lọc', function () {
                    if ($(searchTxt).val() == 'Tìm kiếm tin tức') {
                        $(searchTxt).val('');
                    }
                    tinQuanLyPhuTrachFn.search();
                    if ($(searchTxt).val() == '') {
                        $(searchTxt).val('Tìm kiếm tin tức');
                    }
                });

                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteByUserLdmMa('', 'TIN-TUC', DMID, function (event, ui) {
                        DMID.attr('_value', ui.item.id);
                        tinQuanLyPhuTrachFn.search();
                    });
                    DMID.unbind('click').click(function () {
                        DMID.autocomplete('search', '');
                    });
                    $(DMID).unbind('click').click(function () {
                        $(DMID).autocomplete('search', '');
                    });
                });
                adm.watermark(searchTxt, 'Tìm kiếm tin tức', function () {
                    $(searchTxt).val('');
                    tinQuanLyPhuTrachFn.search();
                    $(searchTxt).val('Tìm kiếm tin tức');
                });
            }
        });
    },
    viewThongTinNguoiViet:function (_id) {
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.thongTinCaNhan(_id, function(_dt) {
            });
        });
    },
    loadTinList: function (_id) {
        $('#tinQuanLyPhuTrachMdl-subtinQuanLyPhuTrachMdl-List').jqGrid({
            url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=getSubTin&ID=' + _id,
            datatype: 'json',
            colNames: ['ID', 'Ảnh', 'Tên', 'Mô tả', 'Tác giả', 'Ngày tạo'],
            colModel: [
            { name: 'ID', key: true, sortable: true, hidden: true },
            { name: 'Anh', width: 10, sortable: false, editable: true },
            { name: 'Ten', width: 40, resizable: true, sortable: false, editable: true },
            { name: 'MoTa', width: 30, resizable: true, sortable: false, editable: true },
            { name: 'NguoiTao', width: 10, resizable: true, sortable: false, editable: true },
            { name: 'NgayTao', width: 10, resizable: true, sortable: false, editable: true }
            ],
            caption: 'Tin',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            rowNum: 1000,
            rowList: [5, 100, 200, 500, 1000],
            //            pager: jQuery('#nhomMdl-subtinQuanLyPhuTrachMdl-Pager'),
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    SubtinQuanLyPhuTrachFn: function () {
        var T_ID = $('.mdl-head-subTinsearchtinQuanLyPhuTrachMdl');
        var Btn = $('#tinQuanLyPhuTrachMdl-subtinQuanLyPhuTrachMdl-addBtn');
        tinQuanLyPhuTrachFn.autoCompleteSearch(T_ID,
                        function (event, ui) {
                            $(T_ID).val(ui.item.label);
                            $(T_ID).attr('_value', ui.item.id);
                        });
        $(T_ID).unbind('click').click(function () { if ($(T_ID).val() != '') { $(T_ID).autocomplete('search', $(T_ID).val()); } });;

        $(Btn).unbind('click').click(function () {
            var item = this;
            var _nId = $(item).attr('_id');
            if (_nId == '') { alert('Chọn chủ đề'); return false; }
            T_ID = $('.mdl-head-subTinsearchtinQuanLyPhuTrachMdl');
            var _v = $(T_ID).attr('_value');
            if (_v != '') {
                $.ajax({
                    url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=addSubTin&ID=' + _nId,
                    data: { 'CID': _v },
                    success: function () {
                        $(T_ID).val('');
                        $(T_ID).attr('_value', '');
                        $('#tinQuanLyPhuTrachMdl-subtinQuanLyPhuTrachMdl-List').trigger('reloadGrid');
                    }
                });
            }
        });
    },
    delSubTin: function () {
        var Btn = $('#tinQuanLyPhuTrachMdl-subtinQuanLyPhuTrachMdl-addBtn');
        var _tpId = $(Btn).attr('_id');
        if (_tpId == '') { alert('Chọn chủ đề'); return false; }
        var s = '';
        s = jQuery("#tinQuanLyPhuTrachMdl-subtinQuanLyPhuTrachMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            var con = confirm('Bạn có muốn xóa');
            if (con) {
                $.ajax({
                    url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=delSubTin',
                    dataType: 'script',
                    data: {
                        'ID': _tpId,
                        'CID': s
                    },
                    success: function (dt) {
                        $('#tinQuanLyPhuTrachMdl-subtinQuanLyPhuTrachMdl-List').trigger('reloadGrid');
                    }
                });
            }
        }
    },
    changeSubTin: function (_id) {
        var Btn = $('#tinQuanLyPhuTrachMdl-subtinQuanLyPhuTrachMdl-addBtn');
        $(Btn).attr('_id', _id);
        $('#tinQuanLyPhuTrachMdl-subtinQuanLyPhuTrachMdl-List').jqGrid('setGridParam', { url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=getSubTin&ID=' + _id }).trigger('reloadGrid');
    },
    edit: function () {
        var s = '';
        if (jQuery('#tinQuanLyPhuTrachMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#tinQuanLyPhuTrachMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var treedata = $("#tinQuanLyPhuTrachMdl-List").jqGrid('getRowData', s);
                var __TIN_ID = treedata._TIN_ID;
                var _TIN_ID = treedata.TIN_ID;
                var _Lang = treedata.TIN_Lang;
                if (__TIN_ID == '0') { alert('Tin này chưa tồn tại ở ngôn ngữ ' + _Lang); return false; }
                tinQuanLyPhuTrachFn.loadHtml(function () {
                    var newDlg = $('#tinQuanLyPhuTrachMdl-dlgNew');

                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,

                        position: [200, 0],
                        //  modal: true,
                        buttons: {
                            'Đăng': function () {
                                var _tinList = __TIN_ID + ',';
                                var GH_ID = newDlg.find('.GH_ID');
                                var _GH_ID = GH_ID.attr('_value');
                                if (_GH_ID == '') {
                                    alert('Chọn loại');
                                    GH_ID.focus();
                                    return;
                                }
                                tinQuanLyPhuTrachFn.save(false, function () {
                                    $.ajax({
                                        url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=duyet&status=true',
                                        dataType: 'script',
                                        data: {
                                            'ID': _tinList, 'GH_ID': _GH_ID
                                        },
                                        success: function (dt) {
                                            jQuery("#tinQuanLyPhuTrachMdl-List").trigger('reloadGrid');
                                        }
                                    });
                                    tinQuanLyPhuTrachFn.clearform();
                                });
                            },
                            'Hẹn giờ': function () {
                                var _tinList = __TIN_ID + ',';
                                var HenGio_Ngay = newDlg.find('.HenGio_Ngay');
                                var HenGio_Gio = newDlg.find('.HenGio_Gio');
                                var HenGioStr = '';
                                if (HenGio_Gio.val() != '') {
                                    HenGioStr = HenGio_Ngay.val() + ' ' + HenGio_Gio.val();
                                }
                                if (HenGioStr == '') {
                                    alert('Chọn giờ đăng nào');
                                    HenGio_Gio.focus();
                                    return;
                                }
                                var GH_ID = newDlg.find('.GH_ID');
                                var _GH_ID = GH_ID.attr('_value');
                                if (_GH_ID == '') {
                                    alert('Chọn loại');
                                    GH_ID.focus();
                                    return false;
                                }
                                
                                tinQuanLyPhuTrachFn.save(false, function () {
                                    $.ajax({
                                        url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=duyetHenGio&status=true',
                                        dataType: 'script',
                                        data: {
                                            'ID': _tinList,
                                            'HG_GioDang': HenGioStr, 'GH_ID': _GH_ID
                                        },
                                        success: function (dt) {
                                            jQuery("#tinQuanLyPhuTrachMdl-List").trigger('reloadGrid');
                                        }
                                    });
                                    tinQuanLyPhuTrachFn.clearform();
                                });
                            },
                            'Y/c Xem lại':function () {
                                var _tinList = __TIN_ID + ',';
                                tinQuanLyPhuTrachFn.save(false, function () {
                                    $.ajax({
                                        url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=yeuCauDuyet&status=false',
                                        dataType: 'script',
                                        data: {
                                            'ID': _tinList
                                        },
                                        success: function (dt) {
                                            jQuery("#tinQuanLyPhuTrachMdl-List").trigger('reloadGrid');
                                        }
                                    });
                                    tinQuanLyPhuTrachFn.clearform();
                                });
                            },
                            'Lưu': function () {
                                tinQuanLyPhuTrachFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeclose: function () {

                        },
                        open: function () {

                            //alert("aaaaaaaaa");
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            tinQuanLyPhuTrachFn.clearform();
                            $.ajax({
                                url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': __TIN_ID
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var newDlg = $('#tinQuanLyPhuTrachMdl-dlgNew');
                                    //file uploadTintuc
                                    var lbladm_uploadTintuc_fileLists = $('.adm-uploadTintuc-fileLists', newDlg);
                                    var txtID = $('.ID', newDlg);
                                    $(txtID).val(data.ID);
                                    $(txtID).attr('_value', data.RowId);
                                    var LangBased = $('.LangBased', newDlg);
                                    var LangBased_ID = $('.LangBased_ID', newDlg);
                                    var Alias = $('.Alias', newDlg);
                                    var LangTxt = $('.Lang', newDlg);
                                    //  var LangSlt = $('.Lang', newDlg);
                                    var GH_ID = newDlg.find('.GH_ID');
                                    GH_ID.val(data.GH_Ten);
                                    GH_ID.attr('_value', data.GH_ID);
                                    
                                    var KeyWords = $('.KeyWords', newDlg);
                                    var Description = $('.Description', newDlg);
                                    var txtPID = $('.DMID', newDlg);
                                    $(txtPID).val(data.DM_Ten);
                                    $(txtPID).attr('_value', data.DM_ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);

                                    LangBased_ID.val(data.LangBased_ID);
                                    if (data.LangBased) {
                                        $(LangBased).attr('checked', 'checked');
                                    }
                                    else {
                                        $(LangBased).removeAttr('checked');
                                    }

                                    Alias.val(data.Alias);
                                    KeyWords.val(data.KeyWords);
                                    Description.val(data.Description);
                                    var txtNguon = $('.Nguon', newDlg);
                                    $(txtNguon).val(data.Nguon);

                                    var txtMoTa = $('.MoTa', newDlg);
                                    $(txtMoTa).val(data.MoTa);

                                    var txtNoiDung_tt = $('.NoiDung_tt', newDlg);

                                    $(txtNoiDung_tt).val(data.NoiDung);

                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-uploadTintuc-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');
                                    $(lblAnh).attr('ref', data.Anh);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/Tintuc/' + data.Anh + '?ref=' + Math.random());
                                    }
                                    var txtNguoiTao = $('.NguoiTao', newDlg);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                    var txtSTT = $('.ThuTu', newDlg);
                                    $(txtSTT).val(data.ThuTu);
                                    var ckbHot = $('.Hot', newDlg);
                                    if (data.Hot.toString() == 'true') {
                                        $(ckbHot).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHot).removeAttr('checked');
                                    }
                                    var ckbPublish = $('.Publish', newDlg);
                                    if (data.Active.toString() == 'true') {
                                        $(ckbPublish).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbPublish).removeAttr('checked');
                                    }

                                    var ckbHetHan = $('.HetHan', newDlg);
                                    if (data.HetHan.toString() == 'true') {
                                        $(ckbHetHan).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbHetHan).removeAttr('checked');
                                    }
                                    var txtNgayHetHan = $('.NgayHetHan', newDlg)
                                    var _ngayHetHan = new Date(data.NgayHetHan);

                                    checkdate = '';
                                    checkdate = _ngayHetHan.getDate() + '/' + (_ngayHetHan.getMonth() + 1) + '/' + (_ngayHetHan.getFullYear());
                                    if ('1/1/100' == checkdate) {
                                        $(txtNgayHetHan).val('');
                                    }
                                    else {
                                        $(txtNgayHetHan).val(checkdate);
                                    }
                                    var txtNgayCapNhat = $('.NgayCapNhat', newDlg)
                                    var _ngayCapNhat = new Date(data.NgayCapNhat);

                                    checkdates = '';
                                    checkdates = _ngayCapNhat.getDate() + '/' + (_ngayCapNhat.getMonth() + 1) + '/' + (_ngayCapNhat.getFullYear());
                                    if ('1/1/100' == checkdates) {
                                        $(txtNgayCapNhat).val('');
                                    }
                                    else {
                                        $(txtNgayCapNhat).val(checkdates);
                                    }
                                    // file uploadTintuc
                                    $(lbladm_uploadTintuc_fileLists).html(data.FileListStr);
                                    $(lbladm_uploadTintuc_fileLists).find('a').click(function () {
                                        var _item = $(this).parent();
                                        $(_item).hide();
                                        //  alert($(_item).attr('_value'));
                                        $.ajax({
                                            url: tinQuanLyPhuTrachFn.urlDefault,
                                            data: {
                                                'subAct': 'DeleteDoc',
                                                'F_ID': $(_item).attr('_value')
                                            },
                                            success: function (dt) {
                                                $(_item).remove();
                                            }
                                        });
                                        $(this).parent().remove();
                                    });

                                    tinQuanLyPhuTrachFn.addpopfn();
                                    LangTxt.val(data.Lang);
                                    //                                    if ($(LangTxt).children().length > 0) { return false; }
                                    //                                    $(LangTxt).find('option').remove();
                                    //                                    $.each(LangArr, function (i, item) {
                                    //                                        if (item.Active) {
                                    //                                            Lang = item.Ma;
                                    //                                        }
                                    //                                        $(LangTxt).prepend('<option value=\"' + item.Ma + '\">' + item.Ten + '</option>');
                                    //                                    });
                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    $(spbMsg).html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function (fn) {
        var s = '';
        s = jQuery("#tinQuanLyPhuTrachMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa tin này?')) {
                var ll = '';
                var ss = s.split(',');
                for (j = 0; j < ss.length; j++) {
                    if (ss[j] != '') {
                        var treedata = $("#tinQuanLyPhuTrachMdl-List").jqGrid('getRowData', ss[j]);
                        ll += treedata.TIN_ID + ',';
                    }                    
                }
            }
            $.ajax({
                url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=del',
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#tinQuanLyPhuTrachMdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    duyet: function (st) {
        var s = '';
        s = jQuery("#tinQuanLyPhuTrachMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tinQuanLyPhuTrachMdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=duyet&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#tinQuanLyPhuTrachMdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    tinhot: function (st) {
        var s = '';
        s = jQuery("#tinQuanLyPhuTrachMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tinQuanLyPhuTrachMdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=hot&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#tinQuanLyPhuTrachMdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    hethan: function (st) {
        var s = '';
        s = jQuery("#tinQuanLyPhuTrachMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chưa chọn tin nào');
        }
        else {
            var ll = '';
            var ss = s.split(',');
            for (j = 0; j < ss.length; j++) {
                var treedata = $("#tinQuanLyPhuTrachMdl-List").jqGrid('getRowData', ss[j]);
                ll += ss[j] + ',';
            }
            $.ajax({
                url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=hethan&status=' + st,
                dataType: 'script',
                data: {
                    'ID': ll
                },
                success: function (dt) {
                    jQuery("#tinQuanLyPhuTrachMdl-List").trigger('reloadGrid');
                }
            });
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    search: function () {
        var timerSearch;
        var DMID = $('.mdl-head-filterTinBydanhmuc');
        var searchTxt = $('.mdl-head-search-tin');
        var q = searchTxt.val();
        if (q == 'Tìm kiếm tin tức') {
            q = '';
        }
        var dm = DMID.attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#tinQuanLyPhuTrachMdl-List').jqGrid('setGridParam', { url: tinQuanLyPhuTrachFn.urlDefault + "&subAct=get&q=" + q + "&DMID=" + dm }).trigger("reloadGrid");
        }, 500);
    },
    save: function (validate, fn) {
        var newDlg = $('#tinQuanLyPhuTrachMdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        var GH_ID = newDlg.find('.GH_ID');
        var _GH_ID = GH_ID.attr('_value');
        var LangBased = $('.LangBased', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var Alias = $('.Alias', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        var _LangBased_ID = LangBased_ID.val();
        var _LangBased = $(LangBased).is(':checked');
        var _Alias = Alias.val();
        var _Keywords = $(KeyWords).val();
        var _Description = Description.val();
        
        var txtPID = $('.DMID', newDlg);
        var pid = $(txtPID).attr('_value');
        var pten = $(txtPID).val();

        

        var txtTen = $('.Ten', newDlg);
        var ten = $(txtTen).val();

        var txtNguon = $('.Nguon', newDlg);
        var Nguon = $(txtNguon).val();

        var txtMa = $('.Ma', newDlg);
        var ma = $(txtMa).val();

        var txtThuTu = $('.ThuTu', newDlg);
        var ThuTu = $(txtThuTu).val();

        var txtMoTa = $('.MoTa', newDlg);
        var MoTa = $(txtMoTa).val();

        var txtNoiDung_tt = $('.NoiDung_tt', newDlg);
        var NoiDung_tt = $(txtNoiDung_tt).val();

        var ckbPublish = $('.Publish', newDlg);
        var Publish = $(ckbPublish).val();

        var lblAnh = $('.Anh', newDlg);
        var anh = $(lblAnh).attr('ref');

        var ckbHot = $('.Hot', newDlg);
        var Hot = $(ckbHot).is(':checked');

        var ckbHetHan = $('.HetHan', newDlg);
        var HetHan = $(ckbHetHan).is(':checked');

        var txtNguoiTao = $('.NguoiTao', newDlg);

        var spbMsg = $('.admMsg', newDlg);
        var err = '';
        if (ThuTu == '') { ThuTu = '0'; } else { if (!adm.isInt(ThuTu)) { err += 'Nhập thứ tự kiểu số<br/>'; } }


        if (pid == '') {
            err += 'Nhập mục tin<br/>';
        }
        if (ten == '') {
            err += 'Nhập tên<br/>';
        }

        if (MoTa == '') {
            err += 'Nhập mô tả<br/>';
        }

        if (NoiDung_tt == '') {
            err += 'Nhập nội dung<br/>';
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
            url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': id,
                'LangBased': _LangBased,
                'LangBased_ID': _LangBased_ID,
                'Alias': _Alias,
                'DMID': pid,
                'DMTen': pten,
                'ThuTu': ThuTu,
                'Ten': ten,
                'Mota': MoTa,
                'NoiDung_tt': NoiDung_tt,
                'Public': Publish,
                'Hot': Hot,
                'Anh': anh,
                'HetHan': HetHan,
                'Nguon': Nguon,
                'KeyWords': _Keywords,
                'Description': _Description,
                'GH_ID': _GH_ID
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#tinQuanLyPhuTrachMdl-List').trigger('reloadGrid');
                } else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    clearform: function () {
        var newDlg = $('#tinQuanLyPhuTrachMdl-dlgNew');
        var txtID = $('.ID', newDlg);
        $(txtID).val('');
        var txtPID = $('.DMID', newDlg);
        $(txtPID).val('');
        $(txtPID).attr('_value', '');
        var GH_ID = newDlg.find('.GH_ID');
        GH_ID.val('');
        GH_ID.attr('_value', '');

        var txtTen = $('.Ten', newDlg);
        $(txtTen).val('');
        var txtNguon = $('.Nguon', newDlg);
        $(txtNguon).val('');
        var txtNguoiTao = $('.NguoiTao', newDlg);
        $(txtNguoiTao).val('');
        var txtSTT = $('.ThuTu', newDlg);
        $(txtSTT).val('');
        var txtMoTa = $('.MoTa', newDlg);
        $(txtMoTa).val('');
        var txtNoiDung_tt = $('.NoiDung_tt', newDlg);
        $(txtNoiDung_tt).val('');
        var ckbHot = $('.Hot', newDlg);
        $(ckbHot).removeAttr('checked');
        var ckbPublish = $('.Publish', newDlg);
        $(ckbPublish).removeAttr('checked');
        var ckbHetHan = $('.HetHan', newDlg);
        $(ckbHetHan).removeAttr('checked');

        var lblAnh = $('.Anh', newDlg);

        $(lblAnh).removeAttr('ref');
        $(lblAnh).attr('ref', '');
        $(lblAnh).prev().find('img').attr('src', '');

        var fileList = $('.adm-uploadTintuc-fileLists', newDlg);
        $(fileList).val('');
        var LangTxt = $('.Lang', newDlg);
        var LangBased_ID = $('.LangBased_ID', newDlg);
        var KeyWords = $('.KeyWords', newDlg);
        var Description = $('.Description', newDlg);
        LangBased_ID.val('');
        KeyWords.val('');
        var Alias = $('.Alias', newDlg);
        Alias.val('');
        Description.val('');
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        $(spbMsg).html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#tinQuanLyPhuTrachMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("projectMgr.plugin.backend.tinTuc.QuanLy.PhuTrach.htm.htm")%>',
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
    },
    loadLienQuan: function (fn) {
        var dlg = $('#tinLienQuanMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("projectMgr.plugin.backend.tinTuc.QuanLy.PhuTrach.TinLienQuan.htm")%>',
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
    },
    tinLienQuanFn: function (el) {
        var mdl = $('#tinLienQuanMdl-dlgNew');
        el.click(function() {
            tinQuanLyPhuTrachFn.loadLienQuan(function () {
                tinQuanLyPhuTrachFn.loadHtml(function () {
                    var newDlg = $('#tinQuanLyPhuTrachMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Thêm mới',
                        width: 900,

                        position: [200, 0],
                        //     modal: true,
                        buttons: {
                            'Lưu': function () {
                                tinQuanLyPhuTrachFn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            var _ID = el.attr('_value');
                            $('#tinLienQuanMdl-List').jqGrid({
                                url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=getLienQuan&ID=' + _ID,
                                height: 'auto',
                                datatype: 'json',
                                loadui: 'disable',
                                colNames: ['ID', 'Ảnh', 'Tiêu đề', 'Tóm tắt', 'Mục tin', 'Lần đọc', 'Người viết', 'Ngày tạo'],
                                colModel: [
                                { name: 'TIN_ID', key: true, sortable: true, hidden: true },
                                { name: 'TIN_Anh', width: 50, resizable: true, sortable: true, align: "center" },
                                { name: 'TIN_Ten', width: 120, resizable: true, sortable: true },
                                { name: 'TIN_MoTa', width: 180, resizable: true, sortable: true },
                                { name: 'TIN_DM_Ten', width: 50, sortable: true },
                                { name: 'TIN_Views', width: 30, resizable: true, sortable: true },
                                { name: 'TIN_NguoiTao', width: 50, resizable: true, sortable: true, align: "center" },
                                { name: 'TIN_NgayCapNhat', width: 50, resizable: true, sortable: true, align: "center" }
                                ],
                                caption: 'Danh sách tin',
                                autowidth: true,
                                sortname: 'TIN_NgayCapNhat',
                                sortorder: 'desc',
                                rowNum: 10,
                                rowList: [10, 20, 50, 100, 200, 300],
                                multiselect: true,
                                multiboxonly: true,
                                onSelectRow: function (rowid) {
                                },
                                loadComplete: function () {
                                    adm.loading(null);
                                }
                            });
                        }
                        ,
                        beforeclose: function () {

                        }
                    });
                });

            });
        });
    },
    autoCompleteSearch: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'tinQuanLyPhuTrachFn-autoCompleteSearch-' + request.term;
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
                    url: tinQuanLyPhuTrachFn.urlDefault + '&subAct=autoCompleteSearch',
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
                fn(event, ui);
                return false;
            },
            focus: function () {
                // prevent value inserted on focus
                return false;
            },
            change: function (event, ui) {
                if (!ui.item) {
                    $(this).val('');
                    $(this).attr('_value', '');
                }
            },
            delay: 500
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    addpopfn: function () {

        var newDlg = $('#tinQuanLyPhuTrachMdl-dlgNew');
        var txtNoiDung_tt = $('.NoiDung_tt', newDlg);
        var txtID = $('.ID', newDlg);
        var txtDMID = $('.DMID', newDlg);
        var GH_ID = newDlg.find('.GH_ID');
        
        var HenGio_Ngay = newDlg.find('.HenGio_Ngay');
        var HenGio_Gio = newDlg.find('.HenGio_Gio');

        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        HenGio_Ngay.val(dateStr);
        HenGio_Ngay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        
        var lblAnh = $('.Anh', newDlg);
        var fileList = $('.adm-uploadTintuc-fileLists', newDlg);
        var ulpFn = function () {
            var uploadTintucBtn = $('.Anh', newDlg);
            var uploadTintucView = $('.adm-uploadTintuc-preview-img', newDlg);
            var _params = { 'oldFile': '' };
            adm.uploadTintuc(uploadTintucBtn, 'anh', _params, function (rs) {
                $(uploadTintucBtn).attr('ref', rs)
                $(uploadTintucView).attr('src', '../up/Tintuc/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
            var XoaAnh = newDlg.find('.XoaAnh');
            XoaAnh.unbind('click').click(function () {
                uploadTintucBtn = $('.Anh', newDlg);
                uploadTintucView = $('.adm-uploadTintuc-preview-img', newDlg);
                uploadTintucBtn.removeAttr('ref');
                uploadTintucView.attr('src', '');
            });
        };
        ulpFn();
        var ID = $('.ID', newDlg);
        var _ID = ID.val();

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', "TIN-TUC", txtDMID, function (event, ui) {
                $(txtDMID).attr('_value', ui.item.id);
            });
            danhmuc.autoCompleteLangBased(_ID, "HOI-DAP", GH_ID, function (event, ui) {
                GH_ID.attr('_value', ui.item.id);
            });
            danhmuc.autoCompleteLangBased(_ID, "HEN-GIO", HenGio_Gio, function (event, ui) {
                HenGio_Gio.val(ui.item.giatri);
            });
        });


        $(txtDMID).unbind('click').click(function () { $(txtDMID).autocomplete('search', ''); });
        $('.NgayHetHan', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        $('.NgayCapNhat', newDlg).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });

        var txttextarea = $('.NoiDung_tt', newDlg);
        adm.createCkFull(txttextarea);
    }
}
