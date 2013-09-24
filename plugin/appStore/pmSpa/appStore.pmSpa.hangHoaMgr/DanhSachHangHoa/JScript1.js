var DanhSachKhachHangFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');
        $('#DanhSachKhachHangMdl-List').jqGrid({
            url: DanhSachKhachHangFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
            height: '1000',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mã', 'Tên', 'Mobile', 'Email', 'Giới tính', 'Nguồn gốc', 'Lịch sủ'],
            colModel: [
                { name: 'ID', key: true, width: 1, sortable: true, hidden: true },
                { name: 'Ma', width: 10, sortable: true },
                { name: 'Ten', width: 20, sortable: true },
                { name: 'Mobile', width: 5, sortable: true },
                { name: 'Email', width: 5, sortable: true },
                { name: 'GioiTinh', width: 2, sortable: true },
                { name: 'NguonGoc_ID', width: 10, resizable: true, sortable: true },
                { name: 'NgayCapNhat', width: 10, resizable: true, sortable: true }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'NgayTao',
            sortorder: 'asc',
            rowNum: 10000,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#DanhSachKhachHangMdl-List';

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
                DanhSachKhachHangFn.loadHtml(function () {
                    var newDlg = $('#DanhSachKhachHangMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                DanhSachKhachHangFn.save(false, function () {
                                    DanhSachKhachHangFn.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                DanhSachKhachHangFn.save(false, function () {
                                    DanhSachKhachHangFn.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            DanhSachKhachHangFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            DanhSachKhachHangFn.clearform();
                            DanhSachKhachHangFn.popfn();
                            $.ajax({
                                url: DanhSachKhachHangFn.urlDefault().toString() + '&subAct=edit',
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
    add: function () {
        DanhSachKhachHangFn.loadHtml(function () {
            var newDlg = $('#DanhSachKhachHangMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        DanhSachKhachHangFn.save(false, function () {
                            DanhSachKhachHangFn.clearform();
                        }, '#DanhSachKhachHangMdl-List');
                    },
                    'Lưu và đóng': function () {
                        DanhSachKhachHangFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#DanhSachKhachHangMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    DanhSachKhachHangFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    DanhSachKhachHangFn.clearform();
                    DanhSachKhachHangFn.popfn();
                    var LangBased_ID = $('.LangBased_ID', newDlg);
                    var LangBased = $('.LangBased', newDlg);
                    LangBased_ID.val('');
                    $(LangBased).attr('checked', 'checked');
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#DanhSachKhachHangMdl-List';
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
                        url: DanhSachKhachHangFn.urlDefault().toString() + '&subAct=del',
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
        if (typeof (grid) == 'undefined') grid == '#DanhSachKhachHangMdl-List';
        var newDlg = $('#DanhSachKhachHangMdl-dlgNew');
        var ID = $('.ID');
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
        ////console.log(_Anh);
        var err = '';
        if (_LDMID == '') { err += 'Chọn loại danh mục<br/>'; }; if (_Ten == '') { err += 'Nhập tên<br/>'; };
        if (_ThuTu == '') { _ThuTu = '0'; } else { if (!adm.isInt(_ThuTu)) { err += 'Nhập thứ tự kiểu số<br/>'; } }
        if (!_LangBased) { if (_Lang == Lang) { err += 'Chọn ngôn ngữ khác'; }; }
        else { if (_Lang != Lang) { err += 'Bạn cần chọn ngôn ngữ gốc ' + Lang; }; }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: DanhSachKhachHangFn.urlDefault().toString(),
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
            $('#DanhSachKhachHangMdl-List').jqGrid('setGridParam', { url: DanhSachKhachHangFn.urlDefault().toString() + '&subAct=get&LDMID=' + _LDMID + '&Lang=' + _Lang }).trigger('reloadGrid');
        }, 500);
    },
    popfn: function () {
    },
    clearform: function () {
        var newDlg = $('#DanhSachKhachHangMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ho = $('.Ho', newDlg);
        var XungHo = $('.XungHo', newDlg);
        var NgaySinh = $('.NgaySinh', newDlg);
        var GioiTinh = $('.GioiTinh', newDlg);
        var Email = $('.Email', newDlg);
        var Mobile = $('.Mobile', newDlg);
        var Phone = $('.Phone', newDlg);
        var CMND = $('.CMND', newDlg);
        var Ym = $('.Ym', newDlg);
        var FacebookUid = $('.FacebookUid', newDlg);
        var LinhVuc_ID = $('.LinhVuc_ID', newDlg);
        var NguonGoc_ID = $('.NguonGoc_ID', newDlg);
        var NguonGoc_ChiTiet_ID = $('.NguonGoc_ChiTiet_ID', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var KhuVuc_ID = $('.KhuVuc_ID', newDlg);
        var NgayTao = $('.NgayTao', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var NgayCapNhat = $('.NgayCapNhat', newDlg);
        var NguoiCapNhat = $('.NguoiCapNhat', newDlg);
        var NgungTheoDoi = $('.NgungTheoDoi', newDlg);
        var NoiBat = $('.NoiBat', newDlg);
        var ChiaSe = $('.ChiaSe', newDlg);
        var DanhGia = $('.DanhGia', newDlg);
        var KhongNhanEmail = $('.KhongNhanEmail', newDlg);
        var KhongDuocGoiDien = $('.KhongDuocGoiDien', newDlg);
        var ThoiGianGoiDien = $('.ThoiGianGoiDien', newDlg);

        ID.val('');
        Ma.val('');
        Ten.val('');
        Ho.val('');
        XungHo.val('');
        NgaySinh.val('');
        GioiTinh.val('');
        Email.val('');
        Mobile.val('');
        Phone.val('');
        CMND.val('');
        Ym.val('');
        FacebookUid.val('');
        LinhVuc_ID.val('');
        NguonGoc_ID.val('');
        NguonGoc_ChiTiet_ID.val('');
        DiaChi.val('');
        KhuVuc_ID.val('');
        NgayTao.val('');
        NguoiTao.val('');
        NgayCapNhat.val('');
        NguoiCapNhat.val('');
        NgungTheoDoi.val('');
        NoiBat.val('');
        ChiaSe.val('');
        DanhGia.val('');
        KhongNhanEmail.val('');
        KhongDuocGoiDien.val('');
        ThoiGianGoiDien.val('');
    },
    autoCompleteLangBased: function (id, ldm_ma, el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'danhMuc-autoCompleteLangBased' + id + ldm_ma;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: DanhSachKhachHangFn.urlDefault().toString(),
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
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    loadHtml: function (fn) {
        var dlg = $('#DanhSachKhachHangMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.khachHangMgr.DanhSachKhachHang.htm.htm")%>',
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
