var congNoDauKyFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.commonStore.thuChiMgr.congNoDauKy.Class1, appStore.commonStore.thuChiMgr'; },
    urlDefault1: function () { return adm.urlDefault1 + '&act=loadPlug&rqPlug=appStore.commonStore.thuChiMgr.congNoDauKy.Class1, appStore.commonStore.thuChiMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        var KH_ID = $('.mdl-head-CongNoDauKy-KhachHang');
        $('#congNoDauKyMdl-List').jqGrid({
            url: congNoDauKyFn.urlDefault().toString() + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Kh/ Ncc', 'Số Tiền', 'Nợ', 'Ngày tạo', 'Người tạo'],
            colModel: [
                        { name: 'CNKH_ID', key: true, sortable: true, hidden: true },
                        { name: 'CNKH_KH_ID', width: 50, sortable: true },
                        { name: 'CNKH_Tien', width: 20, resizable: true, sortable: true, align: 'right' },
                        { name: 'CNKH_No', width: 5, resizable: true, sortable: true, formatter: 'checkbox' },
                        { name: 'CNKH_NgayTao', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'CNKH_NguoiTao', width: 10, resizable: true, sortable: true, align: 'right' }
                    ],
            caption: 'Công nợ đầu kỳ',
            autowidth: true,
            sortname: 'CNKH_NgayTao',
            sortorder: 'desc',
            pager: jQuery('#congNoDauKyMdl-Pager'),
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                adm.regJPlugin(jQuery().formatCurrency, '../js/jquery.formatCurrency-1.4.0.min.js', function () {
                });
                adm.loading(null);
                
                adm.regType(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
                    DanhSachKhachHangFn.autoCompleteSearch(KH_ID, function (event, ui) {
                        KH_ID.attr('_value', ui.item.id);
                        congNoDauKyFn.search();
                    });
                    KH_ID.unbind('click').click(function () {
                        KH_ID.autocomplete('search', '');
                    });
                });
            }
        });
    },
    popfn: function (newDlg) {
        var ID = $('.ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var Tien = $('.Tien', newDlg);
        var btnThemNhanhKH = $('.btnThemNhanhKH', newDlg);
        adm.regType(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
            DanhSachKhachHangFn.autoCompleteSearch(KH_ID, function (event, ui) {
                KH_ID.attr('_value', ui.item.id);
            });
            btnThemNhanhKH.unbind('click').click(function () {
                DanhSachKhachHangFn.add(function (_ID, _Ten) {
                    KH_ID.attr('_value', _ID);
                    KH_ID.val(_Ten);
                });
            });
        });
        adm.formatTien(Tien);
    },
    refresh: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#congNoDauKyMdl-List';
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: congNoDauKyFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        }, 500);
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#congNoDauKyMdl-List';

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
                var owner = treedata.CNKH_NguoiTao;
                var CNKH_XN_ID = treedata.CNKH_XN_ID;
                var CNKH_DV_ID = treedata.CNKH_DV_ID;
                if (owner == 'No') {
                    alert('Bạn không đủ quyền sửa phiếu này');
                    return false;
                }
                if (CNKH_XN_ID == 'Yes' || CNKH_DV_ID == 'Yes') {
                    alert('Phiếu này liên quan đến hóa đơn xuất nhập, phiếu dịch vụ. Bạn không sửa được!');
                    return false;
                }
                congNoDauKyFn.loadHtml(function () {
                    var newDlg = $('#congNoDauKyMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        buttons: {
                            'Lưu': function () {
                                congNoDauKyFn.save(false, function () {
                                    congNoDauKyFn.clearform();
                                    congNoDauKyFn.draff(function (dt) {
                                        newDlg.find('.ID').val(dt);
                                        newDlg.find('.ID').attr('draff', '1');
                                    });
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                congNoDauKyFn.save(false, function () {
                                    congNoDauKyFn.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'In': function () {
                                congNoDauKyFn.createReport(s);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            congNoDauKyFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            congNoDauKyFn.clearform();
                            congNoDauKyFn.popfn(newDlg);
                            $.ajax({
                                url: congNoDauKyFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var KH_ID = $('.KH_ID', newDlg);
                                    var Tien = $('.Tien', newDlg);
                                    var No = $('.No', newDlg);
                                    var spbMsg = $('.spbMsg', newDlg);
                                    
                                    ID.val(dt.ID);
                                    Tien.val(dt.Tien);
                                    KH_ID.val(dt._KhachHang.Ten);
                                    KH_ID.attr('_value', dt.KH_ID);
                                    if (dt.No) {
                                        No.attr('checked', 'checked');
                                    } else {
                                        No.removeAttr('checked');
                                    }
                                    adm.formatTien(Tien);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function (_newDlg, fn) {
        congNoDauKyFn.loadHtml(function () {
            var newDlg = $('#congNoDauKyMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        congNoDauKyFn.save(false, function (_ID) {
                            if (typeof (fn) == 'function') {
                                fn(_ID);
                            }
                            congNoDauKyFn.clearform();                           
                        }, '#congNoDauKyMdl-List');
                    },
                    'Lưu và đóng': function () {
                        congNoDauKyFn.save(false, function (_ID) {
                            if (typeof (fn) == 'function') {
                                fn(_ID);
                            }
                            $(newDlg).dialog('close');
                        }, '#congNoDauKyMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    congNoDauKyFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    congNoDauKyFn.clearform();
                    congNoDauKyFn.popfn(newDlg);                    
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#congNoDauKyMdl-List';
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
                    url: congNoDauKyFn.urlDefault().toString() + '&subAct=del',
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
        if (typeof (grid) == 'undefined') grid == '#congNoDauKyMdl-List';
        var newDlg = $('#congNoDauKyMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var Tien = $('.Tien', newDlg);
        var No = $('.No', newDlg);
        var spbMsg = $('.spbMsg', newDlg);

        var _ID = ID.val();
        var _Tien = adm.VndToInt(Tien);
        var _KH_ID = KH_ID.attr('_value');
        var _No = No.is(':checked');

        var err = '';
        if (_KH_ID == '') { err += 'Chọn khách hàng/ nhà cung cấp<br/>'; };
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }

        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: congNoDauKyFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'save',
                ID: _ID,
                KH_ID: _KH_ID,
                Tien: _Tien,
                No: _No
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn(_ID);
                    }
                    $(grid).trigger('reloadGrid');
                } else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    search: function () {
        var KH_ID = $('.mdl-head-CongNoDauKy-KhachHang');
        var _KH_ID = KH_ID.attr('_value');
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#congNoDauKyMdl-List').jqGrid('setGridParam', { url: congNoDauKyFn.urlDefault().toString() + '&subAct=get&KH_ID=' + _KH_ID }).trigger('reloadGrid');
        }, 500);
    },
    draff: function (fn) {
        $.ajax({
            url: congNoDauKyFn.urlDefault().toString(),
            type: 'POST',
            data: {
                'subAct': 'draff'
            },
            success: function (dt) {
                fn(dt);
            }
        });
    },
    clearform: function () {
        var newDlg = $('#congNoDauKyMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var Tien = $('.Tien', newDlg);
        var spbMsg = $('.spbMsg', newDlg);
        
        $(spbMsg).html('');
        KH_ID.attr('_value', '');
        newDlg.find('input').val('');
    },
    createReportByGrid: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#congNoDauKyMdl-List';

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
                congNoDauKyFn.createReport(s);
            }
        }
    },
    createReport: function (id) {
        var request = document.location.href + congNoDauKyFn.urlDefault().toString() + '&subAct=reports&ID=' + id;
        var win = window.open(request, 'popup', 'width=700, height=700');
        win.focus();
    },
    autoCompleteByQ: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'hangHoa-autoCompleteByQ' + el.val();
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: congNoDauKyFn.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'autoCompleteByQ', 'q': el.val() },
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
                                        gia: item.GNY
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
				            .append("<a><b>" + item.ma + '</b> ' + item.label + ' [' + item.gia + '] </a>')
				            .appendTo(ul);
        };
    },
    loadHtml: function (fn) {
        var dlg = $('#congNoDauKyMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.commonStore.thuChiMgr.congNoDauKy.htm.htm")%>',
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
