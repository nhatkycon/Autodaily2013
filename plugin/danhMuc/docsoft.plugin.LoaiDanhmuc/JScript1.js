var loaidanhmuc = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.loaidanhmuc.Class1, docsoft.plugin.loaidanhmuc',
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu loại danh mục');
        $('#loaidanhmucmdl-List').jqGrid({
            url: loaidanhmuc.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Thứ Tự', 'Mã', 'Ký hiệu', 'Tên', 'Ngày sửa', 'Người tạo/sửa'],
            colModel: [
            { name: 'ID', key: true, sortable: true, hidden: true },
            { name: 'ThuTu', width: 80, sortable: true, align: "center" },
            { name: 'Ma', width: 80, resizable: true, sortable: true, align: "center" },
            { name: 'KyHieu', width: 60, resizable: true, sortable: true, align: "center" },
            { name: 'Ten', width: 300, resizable: true, sortable: true, align: "left" },
            { name: 'NgaySua', width: 100, resizable: true, sortable: true, align: "center" },
            { name: 'NguoiTao', width: 100, resizable: true, sortable: true, align: "center" }
            ],
            caption: 'Loại danh mục',
            autowidth: true,
            sortname: 'ThuTu',
            sortorder: 'asc',
            onSelectRow: function (rowid) {
                var treedata = $("#loaidanhmucmdl-List").jqGrid('getRowData', rowid);
                loaidanhmuc.changeGrid(treedata.ID, treedata.Ten);
            },
            rowNum: 5000,
            rowList: [5000, 10, 15, 20, 25, 30],
            pager: jQuery('#loaidanhmucmdl-Pager'),
            loadComplete: function () {
                adm.loading(null);
            }
        });
        var searchTxt = $('.mdl-head-search-loaidanhmuc');
        $('.mdl-head-search-loaidanhmuc').keyup(function () {
            var txtsearch = $('.mdl-head-search-loaidanhmuc').val();
            loaidanhmuc.search();
        });
        adm.watermark(searchTxt, 'Tìm kiếm loại danh mục', function () {
            $(searchTxt).val('');
            loaidanhmuc.search();
            $(searchTxt).val('Tìm kiếm loại danh mục');
        });
    },
    changeGrid: function (DM_ID, DM_Ten) {
        var _Lang = $('#loaidanhmucmdl-danhMucMdl-changeLangSlt').val();
        $('#subdanhmucmdl-List').jqGrid('setGridParam', { url: danhmuc.urlDefault().toString() + '&subAct=get&LDMID=' + DM_ID + '&Ten=' + DM_Ten + '&Lang=' + _Lang }).trigger('reloadGrid');
    },
    add: function () {
        loaidanhmuc.loadHtml(function () {
            var newDlg = $('#loaidanhmucmdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        loaidanhmuc.save();
                    },
                    'Lưu và đóng': function () {
                        loaidanhmuc.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    loaidanhmuc.clearform();
                }
            });
        });
    },
    search: function () {
        var timerSearch;
        var filterDM = $('.mdl-head-search-loaidanhmuc');
        var q = filterDM.val();
        var ldm = $(filterDM).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#loaidanhmucmdl-List').jqGrid('setGridParam', { url: loaidanhmuc.urlDefault + "&subAct=get&q=" + q }).trigger("reloadGrid");
        }, 500);
    },
    searchDanhMuc: function () {
        var timerSearch;
        var LDMID = '';
        if (jQuery("#loaidanhmucmdl-List").jqGrid('getGridParam', 'selrow') != null) {
            LDMID = jQuery("#loaidanhmucmdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        var _Lang = $('#loaidanhmucmdl-danhMucMdl-changeLangSlt').val();
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#subdanhmucmdl-List').jqGrid('setGridParam', { url: danhmuc.urlDefault().toString() + '&subAct=get&LDMID=' + LDMID + '&Lang=' + _Lang }).trigger('reloadGrid');
        }, 500);
    },
    del: function () {
        var s = '';
        if (jQuery("#loaidanhmucmdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#loaidanhmucmdl-List").jqGrid('getGridParam', 'selrow').toString();
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
                        url: loaidanhmuc.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery("#loaidanhmucmdl-List").trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#loaidanhmucmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        var txtTen = $('.Ten', newDlg);
        var ten = $(txtTen).val();
        var txtKyHieu = $('.KyHieu', newDlg);
        var txtMa = $('.Ma', newDlg);
        var ma = $(txtMa).val();

        var KyHieu = $(txtKyHieu).val(); ;

        var txtThuTu = $('.STT', newDlg);
        var ThuTu = $(txtThuTu).val();

        var txtNguoiTao = $('NguoiTao', newDlg);

        var spbMsg = $('.admMsg', newDlg);
        var err = '';
        if (ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (ma == '') {
            err += 'Nhập mã<br/>';
        }
        if (KyHieu == '') {
            err += 'Nhập ký hiệu<br/>';
        }
        if (ThuTu == '') {
            err += 'Nhập thứ tự<br/>';
        }
        else {

            if (!adm.isInt(ThuTu)) {
                err += 'Nhập thứ tự kiểu số<br/>';
            }
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
            url: loaidanhmuc.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': id,
                'STT': ThuTu,
                'Ten': ten,
                'Ma': ma,
                'kyhieu': KyHieu
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    jQuery("#loaidanhmucmdl-List").trigger('reloadGrid');
                    loaidanhmuc.clearform();
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
        if (jQuery("#loaidanhmucmdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#loaidanhmucmdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                loaidanhmuc.loadHtml(function () {
                    var newDlg = $('#loaidanhmucmdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                loaidanhmuc.save();
                            },
                            'Lưu và đóng': function () {
                                loaidanhmuc.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            $.ajax({
                                url: loaidanhmuc.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var txtID = $('.ID', newDlg);
                                    $(txtID).val(data.ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);
                                    var txtMa = $('.Ma', newDlg);
                                    $(txtMa).val(data.Ma);
                                    var txtKyHieu = $('.KyHieu', newDlg);
                                    $(txtKyHieu).val(data.KyHieu);
                                    var txtNguoiTao = $('.NguoiTao', newDlg);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                    var txtSTT = $('.STT', newDlg);
                                    $(txtSTT).val(data.ThuTu);
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
    setAutocomplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp danh sách');
                $.ajax({
                    url: loaidanhmuc.urlDefault + '&subAct=getAll',
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
        var newDlg = $('#loaidanhmucmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtMa = $('.Ma', newDlg);
        var txtKyHieu = $('.KyHieu', newDlg);
        var txtNguoiTao = $('.NguoiTao', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var txtSTT = $('.STT', newDlg);
        spbMsg.html('');
        $(txtID).val('');
        $(txtTen).val('');
        $(txtMa).val('');
        $(txtKyHieu).val('');
        $(txtNguoiTao).val('');
        $(txtSTT).val('');
    },
    loadHtml: function (fn) {
        var dlg = $('#loaidanhmucmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("docsoft.plugin.loaidanhmuc.htm.htm")%>',
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
