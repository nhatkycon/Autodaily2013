var hangHoaMgrFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.commonStore.hangHoaMgr.Class1, appStore.commonStore.hangHoaMgr'; },
    urlDefault1: function () { return adm.urlDefault1 + '&act=loadPlug&rqPlug=appStore.commonStore.hangHoaMgr.Class1, appStore.commonStore.hangHoaMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        var DMID = $('.mdl-head-HangHoaFilterDanhMuc');
        var q = $('.mdl-head-search-hangHoaMgr');
        $('#hangHoaMgrMdl-List').jqGrid({
            url: hangHoaMgrFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mục', 'Mã', 'Tên', 'Giá N', 'GNY', 'SL','Đơn vị', 'Cập nhật'],
            colModel: [
                        { name: 'HH_ID', key: true, sortable: true, hidden: true, summaryTpl: '({0}) hàng hóa' },
                        { name: 'HH_DM_ID', width: 10, sortable: true },
                        { name: 'HH_Ma', width: 10, resizable: true, sortable: true },
                        { name: 'HH_Ten', width: 55, resizable: true, sortable: true },
                        { name: 'HH_GiaNhap', width: 5, resizable: true, sortable: true, align: 'right' },
                        { name: 'HH_GiaNhap', width: 5, resizable: true, sortable: true, align: 'right' },
                        { name: 'HH_SoLuong', width: 3, resizable: true, sortable: true, align: 'right', summaryType: 'sum', summaryTpl: '<b>{0}</b>' },
                        { name: 'HH_DONVI_ID', width: 2, resizable: true, sortable: true, align: 'right' },
                        { name: 'HH_NgayCapNhat', width: 10, resizable: true, align: 'right' }
                    ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'HH_NgayTao',
            sortorder: 'asc',
            rowNum: 10000,
            multiselect: true,
            multiboxonly: true,
            grouping: true,
            groupingView: {
                groupField: ['HH_DM_ID'],
                groupSummary: [true],
                groupColumnShow: [true],                
                groupText: ['<b>{0} - {1} sản phẩm</b>'],
                groupCollapse: false,
                groupOrder: ['asc']
            },
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                if (typeof (Ajax_upload) == 'undefined') {
                    $.getScript('../js/ajaxupload.js', function () { });
                };

                adm.regJPlugin(jQuery().formatCurrency, '../js/jquery.formatCurrency-1.4.0.min.js', function () {

                });

                adm.loading(null);
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteLangBased('', 'NHOM-HH', DMID, function (event, ui) {
                        DMID.attr('_value', ui.item.id);
                        hangHoaMgrFn.search();
                    });
                    DMID.unbind('click').click(function () {
                        DMID.autocomplete('search', '');
                    });
                });
            }
        });
        adm.watermark(DMID, 'Gõ tên loại danh mục để lọc', function () {
            DMID.attr('_value', '');
            DMID.val('');
            q.val('');
            hangHoaMgrFn.search();
        });
        adm.watermark(q, 'Tìm kiếm', function () {
            q.val('');
            hangHoaMgrFn.search();
        });

    },
    refresh: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#hangHoaMgrMdl-List';
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: hangHoaMgrFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        }, 500);
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#hangHoaMgrMdl-List';

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
                hangHoaMgrFn.loadHtml(function () {
                    var newDlg = $('#hangHoaMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                hangHoaMgrFn.save(false, function () {
                                    hangHoaMgrFn.clearform();
                                    hangHoaMgrFn.draff(function (dt) {
                                        newDlg.find('.ID').val(dt);
                                        newDlg.find('.ID').attr('draff', '1');
                                    });
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                hangHoaMgrFn.save(false, function () {
                                    hangHoaMgrFn.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            hangHoaMgrFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            hangHoaMgrFn.clearform();
                            $.ajax({
                                url: hangHoaMgrFn.urlDefault().toString() + '&subAct=edit',
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
                                    var Ma = $('.Ma', newDlg);
                                    var Keywords = $('.Keywords', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var GNY = $('.GNY', newDlg);
                                    var GiaNhap = $('.GiaNhap', newDlg);
                                    var DonVi_ID = $('.DonVi_ID', newDlg);
                                    var SoLuong = $('.SoLuong', newDlg);
                                    var Anh = $('.Anh', newDlg);
                                    var HetHang = $('.HetHang', newDlg);
                                    var TonDinhMuc = $('.TonDinhMuc', newDlg);
                                    var UploadImg = $('.UploadImg', newDlg);
                                    var listImg = $('.listImg', newDlg);

                                    var spbMsg = $('.admMsg', newDlg);
                                    var imgAnh = $('.previewImg', newDlg);
                                    var Anh = $('.Anh', newDlg);

                                    imgAnh.attr('src', '');
                                    Anh.attr('ref', '');

                                    Anh.attr('ref', dt.Anh);
                                    imgAnh.attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());

                                    ID.val(dt.ID);
                                    ID.attr('draff', '0');
                                    DM_ID.val(dt.DM_Ten);
                                    DM_ID.attr('_value', dt.DM_ID);
                                    Ten.val(dt.Ten);
                                    Ma.val(dt.Ma);
                                    Keywords.val(dt.Keywords);
                                    MoTa.val(dt.MoTa);
                                    NoiDung.val(dt.NoiDung);
                                    GNY.val(dt.GNY);
                                    GiaNhap.val(dt.GiaNhap);
                                    SoLuong.val(dt.SoLuong);
                                    HetHang.val(dt.HetHang);
                                    TonDinhMuc.val(dt.TonDinhMuc);
                                    if (dt.HetHang) {
                                        HetHang.attr('checked', 'checked');
                                    } else {
                                        HetHang.removeAttr('checked');
                                    }
                                    DonVi_ID.val(dt.DonVi_Ten);
                                    DonVi_ID.attr('_value', dt.DonVi_ID);

                                    var ListFiles = eval(dt.ListFiles);
                                    $.each(ListFiles, function (i, item) {
                                        $('<span class=\"adm-token-item\"><div class=\"adm-div-preview-img-size-75\"><img class=\"adm-preview-img-size-75\" src=\"../up/sanpham/' + item.ThuMuc + '/' + item.Ten + item.MimeType + '?ref=' + Math.random() + '\" /></div><a _value=\"' + item.ID + '\" href="javascript:;" class="adm-upload-btn">Xóa</a></span>').appendTo(listImg).find('a').click(function () {
                                            if (confirm('Bạn có chắc chắn xóa ảnh này?')) {
                                                var _item = $(this);
                                                $(_item).hide();
                                                $.ajax({
                                                    url: hangHoaMgrFn.urlDefault().toString(),
                                                    dataType: 'script',
                                                    type: 'POST',
                                                    data: {
                                                        'subAct': 'DeleteDoc',
                                                        'F_ID': $(_item).attr('_value')
                                                    },
                                                    success: function (dt) {
                                                        $(_item).remove();
                                                    }
                                                });
                                                $(this).parent().remove();
                                            }
                                        });
                                    });


                                    ID.attr('_RowID', dt.ID);
                                    hangHoaMgrFn.addEventUpload(UploadImg, listImg, ID);
                                    hangHoaMgrFn.popfn();

                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function () {
        hangHoaMgrFn.loadHtml(function () {
            var newDlg = $('#hangHoaMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        hangHoaMgrFn.save(false, function () {
                            hangHoaMgrFn.clearform();
                            hangHoaMgrFn.draff(function (dt) {
                                var ID = newDlg.find('.ID');
                                var UploadImg = $('.UploadImg', newDlg);
                                var listImg = $('.listImg', newDlg);
                                ID.val(dt);
                                ID.attr('_RowID', dt);
                                ID.attr('draff', '1');
                                hangHoaMgrFn.addEventUpload(UploadImg, listImg, ID);
                            });
                        }, '#hangHoaMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        hangHoaMgrFn.save(false, function () {
                            $(newDlg).dialog('close');
                        }, '#hangHoaMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    hangHoaMgrFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    hangHoaMgrFn.clearform();
                    hangHoaMgrFn.popfn();
                    hangHoaMgrFn.draff(function (dt) {
                        var ID = newDlg.find('.ID');
                        var UploadImg = $('.UploadImg', newDlg);
                        var listImg = $('.listImg', newDlg);
                        ID.val(dt);
                        ID.attr('_RowID', dt);
                        ID.attr('draff', '1');
                        hangHoaMgrFn.addEventUpload(UploadImg, listImg, ID);
                    });
                }
            });
        });
    },
    addQuick: function (fn) {
        hangHoaMgrFn.loadHtml(function () {
            var newDlg = $('#hangHoaMgrMdl-dlgNewQuick');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 610,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        hangHoaMgrFn.saveQuick(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            hangHoaMgrFn.clearformQuick();
                            hangHoaMgrFn.draff(function (dt) {
                                var ID = newDlg.find('.ID');
                                ID.val(dt);
                                ID.attr('_RowID', dt);
                                ID.attr('draff', '1');
                            });
                        }, '#hangHoaMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        hangHoaMgrFn.saveQuick(false, function () {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            $(newDlg).dialog('close');
                        }, '#hangHoaMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    hangHoaMgrFn.clearformQuick();
                },
                open: function () {
                    adm.styleButton();
                    hangHoaMgrFn.clearformQuick();
                    hangHoaMgrFn.popfnQuick();
                    hangHoaMgrFn.draff(function (dt) {
                        var ID = newDlg.find('.ID');
                        ID.val(dt);
                        ID.attr('_RowID', dt);
                        ID.attr('draff', '1');
                    });
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#hangHoaMgrMdl-List';
        var s = '';
        if ($(grid).jqGrid('getGridParam', 'selarrrow') != null) {
            s = $(grid).jqGrid('getGridParam', 'selarrrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (confirm('Bạn có chắc chắn xóa?')) {// Xác nhận xem có xóa hay không
                $.ajax({
                    url: hangHoaMgrFn.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(grid).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    save: function (validate, fn, grid) {
        if (typeof (grid) == 'undefined') grid == '#hangHoaMgrMdl-List';
        var newDlg = $('#hangHoaMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var Keywords = $('.Keywords', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var GNY = $('.GNY', newDlg);
        var GiaNhap = $('.GiaNhap', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var Anh = $('.Anh', newDlg);
        var HetHang = $('.HetHang', newDlg);
        var TonDinhMuc = $('.TonDinhMuc', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _Anh = $(Anh).attr('ref');
        var _ID = ID.val();
        var _DM_ID = DM_ID.attr('_value');
        var _Ten = Ten.val();
        var _Ma = Ma.val();
        var _Keywords = Keywords.val();
        var _MoTa = MoTa.val();
        var _NoiDung = NoiDung.val();
        var _GNY = adm.VndToInt(GNY);
        var _GiaNhap = adm.VndToInt(GiaNhap);
        var _DonVi_ID = DonVi_ID.attr('_value');
        var _SoLuong = adm.VndToInt(SoLuong);
        var _TonDinhMuc = adm.VndToInt(TonDinhMuc);
        var _HetHang = HetHang.is(':checked');

        var _draff = ID.attr('draff');

        ////console.log(_Anh);
        var err = '';
        if (_DM_ID == '') { err += 'Chọn loại danh mục<br/>'; }; if (_Ten == '') { err += 'Nhập danh mục<br/>'; };
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: hangHoaMgrFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                draff: _draff,
                ID: _ID,
                DM_ID: _DM_ID,
                Ten: _Ten,
                Ma: _Ma,
                Keywords: _Keywords,
                MoTa: _MoTa,
                NoiDung: _NoiDung,
                GNY: _GNY,
                GiaNhap: _GiaNhap,
                DonVi_ID: _DonVi_ID,
                SoLuong: _SoLuong,
                Anh: _Anh,
                HetHang: _HetHang,
                TonDinhMuc: _TonDinhMuc
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    $(grid).trigger('reloadGrid');
                } else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    saveQuick: function (validate, fn, grid) {
        if (typeof (grid) == 'undefined') grid == '#hangHoaMgrMdl-List';
        var newDlg = $('#hangHoaMgrMdl-dlgNewQuick');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var GNY = $('.GNY', newDlg);
        var GiaNhap = $('.GiaNhap', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var HetHang = $('.HetHang', newDlg);
        var TonDinhMuc = $('.TonDinhMuc', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _DM_ID = DM_ID.attr('_value');
        var _Ten = Ten.val();
        var _Ma = Ma.val();
        var _GNY = GNY.val().replace(',', '');
        var _GiaNhap = GiaNhap.val().replace(',', '');
        var _DonVi_ID = DonVi_ID.attr('_value');
        var _SoLuong = SoLuong.val();
        var _TonDinhMuc = TonDinhMuc.val();
        var _HetHang = HetHang.is(':checked');

        var _draff = ID.attr('draff');

        ////console.log(_Anh);
        var err = '';
        if (_DM_ID == '') { err += 'Chọn loại danh mục<br/>'; }; if (_Ten == '') { err += 'Nhập danh mục<br/>'; };
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: hangHoaMgrFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                draff: _draff,
                ID: _ID,
                DM_ID: _DM_ID,
                Ten: _Ten,
                Ma: _Ma,
                GNY: _GNY,
                GiaNhap: _GiaNhap,
                DonVi_ID: _DonVi_ID,
                SoLuong: _SoLuong,
                HetHang: _HetHang,
                TonDinhMuc: _TonDinhMuc
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn(_ID,_Ten);
                    }
                    $(grid).trigger('reloadGrid');
                } else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    search: function () {
        var DMID = $('.mdl-head-HangHoaFilterDanhMuc');
        var q = $('.mdl-head-search-hangHoaMgr');
        var _DMID = DMID.attr('_value');
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#hangHoaMgrMdl-List').jqGrid('setGridParam', { url: hangHoaMgrFn.urlDefault().toString() + '&subAct=get&DM_ID=' + _DMID + '&q=' + q.val() }).trigger('reloadGrid');
        }, 500);
    },
    draff: function (fn) {
        $.ajax({
            url: hangHoaMgrFn.urlDefault().toString(),
            type: 'POST',
            data: {
                'subAct': 'draff'
            },
            success: function (dt) {
                fn(dt);
            }
        });
    },
    popfn: function () {
        var newDlg = $('#hangHoaMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var Keywords = $('.Keywords', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var GNY = $('.GNY', newDlg);
        var GiaNhap = $('.GiaNhap', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var HetHang = $('.HetHang', newDlg);

        adm.formatTien(GiaNhap);
        adm.formatTien(GNY);

        danhmuc.autoCompleteLangBased('', 'NHOM-HH', DM_ID, function (event, ui) {
            DM_ID.attr('_ma', ui.item.label);
            DM_ID.attr('_value', ui.item.id);
            if (Ma.val() == '') {
                Ma.val(ui.item.ma);
            }
        });

        danhmuc.autoCompleteLangBased('', 'DONVI', DonVi_ID, function (event, ui) {
            DonVi_ID.attr('_ma', ui.item.ma);
            DonVi_ID.attr('_value', ui.item.id);
        });

        adm.createTinyMce(NoiDung);
        var ulpFn = function () {
            var imgAnh = $('.previewImg', newDlg);
            var Anh = $('.Anh', newDlg);
            var _params = { 'oldFile': $(Anh).attr('ref') };
            adm.upload(Anh, 'anh', _params, function (rs) {
                $(Anh).attr('ref', rs)
                imgAnh.attr('src', '../up/i/' + rs + '?ref=' + Math.random());
            }, function (f) {
            });
        };
        ulpFn();
    },
    popfnQuick: function () {
        var newDlg = $('#hangHoaMgrMdl-dlgNewQuick');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var GNY = $('.GNY', newDlg);
        var GiaNhap = $('.GiaNhap', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var HetHang = $('.HetHang', newDlg);

        adm.formatTien(GiaNhap);
        adm.formatTien(GNY);

        danhmuc.autoCompleteLangBased('', 'NHOM-HH', DM_ID, function (event, ui) {
            DM_ID.attr('_ma', ui.item.label);
            DM_ID.attr('_value', ui.item.id);
            if (Ma.val() == '') {
                Ma.val(ui.item.ma);
            }
        });

        danhmuc.autoCompleteLangBased('', 'DONVI', DonVi_ID, function (event, ui) {
            DonVi_ID.attr('_ma', ui.item.ma);
            DonVi_ID.attr('_value', ui.item.id);
        });
    },
    clearform: function () {
        var newDlg = $('#hangHoaMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var Keywords = $('.Keywords', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var GNY = $('.GNY', newDlg);
        var GiaNhap = $('.GiaNhap', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var Anh = $('.Anh', newDlg);
        var HetHang = $('.HetHang', newDlg);
        var TonDinhMuc = $('.TonDinhMuc', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.previewImg', newDlg);
        var UploadImg = $('.UploadImg', newDlg);
        var listImg = $('.listImg', newDlg);

        listImg.html('');
        imgAnh.attr('src', '');
        Anh.attr('ref', '');
        $(spbMsg).html('');
        ID.val('');
        ID.attr('_RowId', '');
        DM_ID.val('');
        DM_ID.attr('_value', '');
        Ten.val('');
        Ma.val('');
        Keywords.val('');
        MoTa.val('');
        NoiDung.val('');
        GNY.val('');
        GiaNhap.val('');
        DonVi_ID.val('');
        DonVi_ID.attr('_value', '');
        SoLuong.val('');
        HetHang.val('');
        TonDinhMuc.val('');
    },
    clearformQuick: function () {
        var newDlg = $('#hangHoaMgrMdl-dlgNewQuick');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var Ma = $('.Ma', newDlg);
        var GNY = $('.GNY', newDlg);
        var GiaNhap = $('.GiaNhap', newDlg);
        var DonVi_ID = $('.DonVi_ID', newDlg);
        var SoLuong = $('.SoLuong', newDlg);
        var Anh = $('.Anh', newDlg);
        var HetHang = $('.HetHang', newDlg);
        var TonDinhMuc = $('.TonDinhMuc', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(spbMsg).html('');
        ID.val('');
        DM_ID.val('');
        DM_ID.attr('_value', '');
        Ten.val('');
        Ma.val('');
        GNY.val('');
        GiaNhap.val('');
        DonVi_ID.val('');
        DonVi_ID.attr('_value', '');
        SoLuong.val('0');
        HetHang.val('');
        TonDinhMuc.val('0');
    },
    createReport: function (v) {
        hangHoaMgrFn.loadHtml(function () {
            var newDlg = $('#hangHoaMgrMdl-DlgReport');
            $(newDlg).dialog({
                title: 'Tạo báo cáo',
                width: 510,
                height: 175,
                modal: true,
                buttons: {
                    'Download báo cáo': function () {
                        var txtTungay = $('.tungay', newDlg);
                        var txtDenngay = $('.denngay', newDlg);
                        var txtTen = $('.Ten', newDlg);
                        var _tungay = $(txtTungay).val();
                        var _denNgay = $(txtDenngay).val();
                        var _ten = $(txtTen).val();
                        var lblMsg = $('.admMsg', newDlg);
                        var err = '';
                        if (_tungay != '') {
                            if (!adm.isDate(txtTungay, _tungay)) {
                                err += 'Định dạng ô \"Từ ngày\" kiểu ngày/tháng/năm (30/01/2010)<br/>';
                            }
                        }
                        if (_denNgay != '') {
                            if (!adm.isDate(txtDenngay, _denNgay)) {
                                err += 'Định dạng ô \"Đến ngày\" kiểu ngày/tháng/năm (30/01/2010)<br/>';
                            }
                        }
                        if (err != '') {
                            spbMsg.html(err);
                            return false;
                        }
                        var _ngay = '';
                        if (_tungay == _denNgay) {
                            _ngay = '(Ngày ' + _tungay + ')';
                        }
                        else {
                            _ngay = '(Từ ngày: ' + _tungay + ' đến: ' + _denNgay + ')';
                        }
                        var request = $('#hangHoaMgrMdl-List').jqGrid('getGridParam', 'url');
                        request.replace('.plugin', '');
                        request = adm.urlDefault().toString() + request;
                        request = request.replace('loadPlug', 'loadPlugDirect');
                        request = request.replace('get', 'reports');
                        request = request + '&Loai=' + v + '&Rep_Ten=' + _ten + '&Rep_Ngay=' + _ngay + '&rows=' + $('#hangHoaMgrMdl-List').jqGrid('getGridParam', 'rowNum');
                        var win = window.open(request, 'popup', 'width=1024, height=700');
                        win.focus();
                        
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    var txtTungay = $('.tungay', newDlg);
                    var txtDenngay = $('.denngay', newDlg);
                    var txtTen = $('.Ten', newDlg);
                    var lblMsg = $('.admMsg', newDlg);
                    $(lblMsg).html('');
                    var _today = new Date();
                    var _todayDate = _today.getDate() + '/' + (_today.getMonth() + 1) + '/' + _today.getFullYear();
                    $(txtTungay).val(_todayDate);
                    $(txtDenngay).val(_todayDate);
                    $(txtTungay).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
                    $(txtDenngay).datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
                    $(txtTen).val($('#vanbandimdl-List').jqGrid('getGridParam', 'caption'));
                }
            });
        });
    },
    addEventUpload: function (oBrowseButton, oFileList, oInputData) {

        var browseButton = $(oBrowseButton);
        var fileList = $(oFileList);
        var inputData = $(oInputData);

        var PRowIdSP = inputData.attr('_RowID');
        var _params = { 'act': 'MultiuploadImg', 'PRowIdSP': PRowIdSP };
        adm.uploadSanPham(browseButton, 'anh', _params, function (rs) {
        }, function (_rs) {
        }, function (_r, _f) {

            var datars = eval(_r);
            var Imgname = datars.Ten + datars.MimeType;
            var foldername = datars.ThuMuc;
            var l = '';
            l += '<span class=\"adm-token-item\"><div class=\"adm-div-preview-img-size-75\"><img class=\"adm-preview-img-size-75\" src=\"../up/sanpham/' + foldername + '/' + Imgname + '?ref=' + Math.random() + '\" /></div><a _value=\"' + datars.ID + '\" href="javascript:;" class="adm-upload-btn">Xóa</a></span>';
            $(l).appendTo(fileList).find('a').click(function () {
                if (confirm('Bạn có chắc chắn xóa ảnh này?')) {
                    var _item = $(this);
                    $(_item).hide();
                    $.ajax({
                        url: hangHoaMgrFn.urlDefault,
                        dataType: 'script',
                        type: 'POST',
                        data: {
                            'subAct': 'DeleteDoc',
                            'F_ID': $(_item).attr('_value')
                        },
                        success: function (dt) {
                            $(_item).remove();
                        }
                    });
                    $(this).parent().remove();
                }
            });
        });
    },
    autoCompleteByQ: function (el, fn, fn1, fn2) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'hangHoa-autoCompleteByQ' + el.val();
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: hangHoaMgrFn.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteByQ', 'q': el.val()},
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function(item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    if(typeof (fn2) == "function") {
                                        return fn2(item);
                                    }else {
                                        return {
                                            label: item.Ten,
                                            value: item.Ten,
                                            id: item.ID,
                                            rowid: item.RowId,
                                            ma: item.Ma,
                                            DonVi: item.DonVi_Ten,
                                            gia: item.GNY,
                                            giaNhap: item.GiaNhap
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
                return false;
            },
            change: function (event, ui) {
                //if (!ui.item) {
                //    if ($(this).val() == '') {
                //        $(this).attr('_value', '');
                //    }
                //}
            },
            delay: 0
        }).data("autocomplete")._renderItem = function (ul, item) {
            if(typeof (fn1) == "function") {
                return fn1(ul,item);
            }else {
                return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a><b>" + item.ma + '</b> ' + item.label + ' [' + adm.formatTienStr(item.gia) + '] </a>')
				            .appendTo(ul);
            }            
        };
    },
    loadHtml: function (fn) {
        var dlg = $('#hangHoaMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.commonStore.hangHoaMgr.htm.htm")%>',
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
