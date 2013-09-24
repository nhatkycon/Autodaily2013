var quanLyTheFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.theKhuyenMaiMgr.quanLyThe.Class1, appStore.pmSpa.theKhuyenMaiMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');

        var filterKhachHangByNguonGoc = $('.filterKhachHangByNguonGoc');
        var filterKhachHangByKhuVuc = $('.filterKhachHangByKhuVuc');
        var q = $('.mdl-head-search-quanLyTheMdl');
        adm.watermark(filterKhachHangByKhuVuc, 'Gõ khu vực', function () {
            quanLyTheFn.search();
        });

        adm.watermark(filterKhachHangByNguonGoc, 'Gõ nguồn gốc', function () {
            quanLyTheFn.search();
        });

        adm.watermark(q, 'Tìm kiếm', function () {
            quanLyTheFn.search();
        });

        $('#quanLyTheMdl-List').jqGrid({
            url: quanLyTheFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
            height: '1000',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Nhà tổ chức', 'C/Trình KM', 'Mã', 'Trị giá', 'Giá NY', 'K/Hàng', 'D/Vụ', 'P/hành', 'Hsd', 'H/Đổi thẻ','T/Trạng','S/Dụng','Cập nhật'],
            colModel: [
                { name: 'ID', key: true, width: 1, sortable: true, hidden: true },
                { name: 'DVTC_ID', width: 10, sortable: true },
                { name: 'KM_ID', width: 10, sortable: true },
                { name: 'Ma', width: 10, sortable: true },
                { name: 'Gia', width: 5, sortable: true, align: 'right' },
                { name: 'GiaNY', width: 5, sortable: true, align: 'right' },
                { name: 'KH_ID', width: 10, sortable: true },
                { name: 'DV_ID', width: 10, sortable: true },
                { name: 'NgayPhatHanh', width: 5, sortable: true, align: 'right' },
                { name: 'HanSuDung', width: 5, resizable: true, sortable: true, align: 'right' },
                { name: 'HanDoiThe', width: 5, resizable: true, sortable: true, align: 'right' },
                { name: 'TinhTrang', width: 2, resizable: true, sortable: true, formatter: 'checkbox' },
                { name: 'DaDung', width: 2, resizable: true, sortable: true, formatter: 'checkbox' },
                { name: 'NgayCapNhat', width: 10, resizable: true, sortable: true, align: 'right' }
            ],
            caption: 'Danh sách thẻ khuyến mãi',
            autowidth: true,
            sortname: 'NgayTao',
            sortorder: 'asc',
            pager: jQuery('#quanLyTheMdl-Pager'),
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                adm.loading(null);

                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteLangBased('', 'KHUVUC', filterKhachHangByKhuVuc, function (event, ui) {
                        filterKhachHangByKhuVuc.attr('_value', ui.item.id);
                        quanLyTheFn.search();
                    });
                    danhmuc.autoCompleteLangBased('', 'NGUON-KH', filterKhachHangByNguonGoc, function (event, ui) {
                        filterKhachHangByNguonGoc.attr('_value', ui.item.id);
                        quanLyTheFn.search();
                    });
                    filterKhachHangByKhuVuc.unbind('click').click(function () {
                        filterKhachHangByKhuVuc.autocomplete('search', '');
                    });
                    filterKhachHangByNguonGoc.unbind('click').click(function () {
                        filterKhachHangByNguonGoc.autocomplete('search', '');
                    });
                });
                q.keyup(function () {
                    quanLyTheFn.search();
                });

            }
        });
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#quanLyTheMdl-List';

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
                quanLyTheFn.loadHtml(function () {
                    var newDlg = $('#quanLyTheMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 1000,
                        buttons: {
                            'Lưu': function () {
                                quanLyTheFn.save(false, function () {
                                    quanLyTheFn.clearform();
                                }, grid);
                            },
                            'Lưu và đóng': function () {
                                quanLyTheFn.save(false, function () {
                                    quanLyTheFn.clearform();
                                    $(newDlg).dialog('close');
                                }, grid);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            quanLyTheFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            quanLyTheFn.clearform();
                            quanLyTheFn.popfn();
                            $.ajax({
                                url: quanLyTheFn.urlDefault().toString() + '&subAct=edit',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);


                                    var ID = $('.ID', newDlg);
                                    var KM_ID = $('.KM_ID', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var KH_ID = $('.KH_ID', newDlg);
                                    var DVTC_ID = $('.DVTC_ID', newDlg);
                                    var GiaNY = $('.GiaNY', newDlg);
                                    var Gia = $('.Gia', newDlg);
                                    var HanSuDung = $('.HanSuDung', newDlg);
                                    var HanDoiThe = $('.HanDoiThe', newDlg);
                                    var TinhTrang = $('.TinhTrang', newDlg);
                                    var DaDung = $('.DaDung', newDlg);
                                    var DV_ID = $('.DV_ID', newDlg);
                                    var NgayPhatHanh = $('.NgayPhatHanh', newDlg);
                                    var NgayNhan = $('.NgayNhan', newDlg);
                                    var NguoiNhan = $('.NguoiNhan', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    KM_ID.val(dt.KM_Ten);
                                    KM_ID.attr('_value', dt.KM_ID);
                                    Ma.val(dt.Ma);
                                    
                                    KH_ID.val(dt.KH_Ten);
                                    KH_ID.attr('_value', dt.KH_ID);
                                    DVTC_ID.val(dt.DVTC_Ten);
                                    DVTC_ID.attr('_value', dt.DVTC_ID);
                                    
                                    GiaNY.val(dt.GiaNY);
                                    Gia.val(dt.Gia);
                                    adm.formatTien(GiaNY);
                                    adm.formatTien(Gia);

                                    var valueHanSuDung = new Date(dt.HanSuDung);
                                    if (valueHanSuDung.getFullYear() != 100) {
                                        HanSuDung.val(valueHanSuDung.getDate() + "/" + (valueHanSuDung.getMonth() + 1) + "/" + valueHanSuDung.getFullYear());
                                    }
                                        
                                    var valueHanDoiThe = new Date(dt.HanDoiThe);
                                    if (valueHanDoiThe.getFullYear() != 100) {
                                        HanDoiThe.val(valueHanDoiThe.getDate() + "/" + (valueHanDoiThe.getMonth() + 1) + "/" + valueHanDoiThe.getFullYear());
                                    }
                                    
                                    if (dt.TinhTrang) {
                                        TinhTrang.attr('checked', 'checked');
                                    }
                                    else {
                                        TinhTrang.removeAttr('checked');
                                    }
                                    if (dt.DaDung) {
                                        DaDung.attr('checked', 'checked');
                                    }
                                    else {
                                        DaDung.removeAttr('checked');
                                    }
                                    
                                    DV_ID.val(dt.DV_Ten);
                                    DV_ID.attr('_value', dt.DV_ID);

                                    var valueNgayPhatHanh = new Date(dt.NgayPhatHanh);
                                    if (valueNgayPhatHanh.getFullYear() != 100) {
                                        NgayPhatHanh.val(valueNgayPhatHanh.getDate() + "/" + (valueNgayPhatHanh.getMonth() + 1) + "/" + valueNgayPhatHanh.getFullYear());
                                    }
                                    var valueNgayNhan = new Date(dt.NgayNhan);
                                    if (valueNgayNhan.getFullYear() != 100) {
                                        NgayNhan.val(valueNgayNhan.getDate() + "/" + (valueNgayNhan.getMonth() + 1) + "/" + valueNgayNhan.getFullYear());
                                    }
                                    NguoiNhan.val(dt.NguoiNhan_Ten);
                                    NguoiNhan.attr('_value', dt.NguoiNhan);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function (fn) {
        quanLyTheFn.loadHtml(function () {
            var newDlg = $('#quanLyTheMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1000,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        quanLyTheFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            quanLyTheFn.clearform();
                        }, '#quanLyTheMdl-List');
                    },
                    'Lưu và đóng': function () {
                        quanLyTheFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            $(newDlg).dialog('close');
                        }, '#quanLyTheMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    quanLyTheFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    quanLyTheFn.clearform();
                    quanLyTheFn.popfn();
                }
            });
        });
    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#quanLyTheMdl-List';
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
                if (confirm('Bạn có chắc chắn xóa khách hàng này?')) {// Xác nhận xem có xóa hay không
                    $.ajax({
                        url: quanLyTheFn.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: { 'ID': s },
                        success: function (dt) {
                            jQuery(grid).trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn, grid) {
        if (typeof (grid) == 'undefined') grid == '#quanLyTheMdl-List';
        var newDlg = $('#quanLyTheMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var KM_ID = $('.KM_ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var DVTC_ID = $('.DVTC_ID', newDlg);
        var GiaNY = $('.GiaNY', newDlg);
        var Gia = $('.Gia', newDlg);
        var HanSuDung = $('.HanSuDung', newDlg);
        var HanDoiThe = $('.HanDoiThe', newDlg);
        var TinhTrang = $('.TinhTrang', newDlg);
        var DaDung = $('.DaDung', newDlg);
        var DV_ID = $('.DV_ID', newDlg);
        var NgayPhatHanh = $('.NgayPhatHanh', newDlg);
        var NgayNhan = $('.NgayNhan', newDlg);
        var NguoiNhan = $('.NguoiNhan', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        
        //region bien
        var _ID = ID.val();
        var _KM_ID = KM_ID.attr('_value');
        var _Ma = Ma.val();
        var _KH_ID = KH_ID.attr('_value');
        var _DVTC_ID = DVTC_ID.attr('_value');
        var _GiaNY = adm.VndToInt(GiaNY);
        var _Gia = adm.VndToInt(Gia);
        
        var _HanSuDung = HanSuDung.val();
        var _HanDoiThe = HanDoiThe.val();
        
        var _TinhTrang = TinhTrang.is(':checked');
        var _DaDung = DaDung.is(':checked');
        
        var _DV_ID = DV_ID.attr('_value');
        
        var _NgayPhatHanh = NgayPhatHanh.val();
        var _NgayNhan = NgayNhan.val();
        
        var _NguoiNhan = NguoiNhan.attr('_value');
        //endregion

        var err = '';
        if (_KM_ID == '') { err += 'Chọn chương trình<br/>'; };
        if (_Ma == '') { err += 'Nhập mã<br/>'; };

        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: quanLyTheFn.urlDefault().toString(),
            type: 'POST',
            data: {
                'subAct': 'save',
                ID: _ID,
                KM_ID: _KM_ID,
                Ma: _Ma,
                KH_ID: _KH_ID,
                DVTC_ID: _DVTC_ID,
                GiaNY: _GiaNY,
                Gia: _Gia,
                HanSuDung: _HanSuDung,
                HanDoiThe: _HanDoiThe,
                TinhTrang: _TinhTrang,
                DV_ID: _DV_ID,
                NgayPhatHanh: _NgayPhatHanh,
                NgayNhan: _NgayNhan,
                NguoiNhan: _NguoiNhan,
                DaDung: _DaDung
            },
            success: function (dt) {
                adm.loading(null);
                if (typeof (fn) == 'function') {
                    fn(dt);
                }
                $(grid).trigger('reloadGrid');
            }
        });
    },
    sendmail: function () {
        var s = '';
        s = jQuery("#quanLyTheMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        quanLyTheFn.loadHtml(function () {
            var emailDlg = $('#quanLyTheMdl-dlgEmail');
            $(emailDlg).dialog({
                title: 'Email cho thành viên',
                modal: true,
                width: 800,
                buttons: {
                    'Gửi': function () {
                        var EmailTo = $('.EmailToTxt', emailDlg);
                        var EmailToDiv = $(EmailTo).parent();
                        var l = '';
                        $.each($(EmailToDiv).find('span'), function (i, item) {
                            l += $(item).attr('_value') + ',';
                        });
                        var EmailBody = emailDlg.find('.EmailBody');
                        var EmailTitle = emailDlg.find('.EmailTitle');
                        $.ajax({
                            url: quanLyTheFn.urlDefault().toString(),
                            dataType: 'script',
                            type: 'POST',
                            data: {
                                'subAct': 'sendmail',
                                ID: l,
                                EmailBody: EmailBody.val(),
                                EmailTitle: EmailTitle.val()
                            },
                            success: function (dt) {
                                adm.loading(null);
                                adm.loading('Gửi thành công');
                                $(emailDlg).dialog('close');
                            },
                            error: function (xhr) {
                                adm.loading('Lỗi:<br/>' + xhr.responseText);
                            }
                        })
                    },
                    'Đóng': function () {
                        $(emailDlg).dialog('close');
                    }
                },
                open: function () {
                    var EmailTo = $('.EmailToTxt', emailDlg);
                    var EmailBody = emailDlg.find('.EmailBody');
                    var EmailTitle = emailDlg.find('.EmailTitle');
                    $(EmailTo).focus();
                    var EmailToDiv = $(EmailTo).parent();
                    $(EmailToDiv).find('span').remove();
                    if (s != '') {
                        var ll = '';
                        var ss = s.split(',');
                        for (j = 0; j < ss.length; j++) {
                            if (ss[j] != '') {
                                var treedata = $("#quanLyTheMdl-List").jqGrid('getRowData', ss[j]);
                                ll += '<span class=\"adm-token-item\" _value=\"' + treedata.ID + '\">' + treedata.Ten + '<a href=\"javascript:;\">x</a></span>';
                            }                            
                        }
                        $(EmailToDiv).prepend(ll);
                        $(EmailToDiv).find('a').click(function () {
                            $(this).parent().remove();
                        });
                    }

                    adm.createTinyMce(EmailBody);
                    quanLyTheFn.autoCompleteSearch(EmailTo, function (e, ui) {
                        var CurrentItem = $(EmailToDiv).find('span[_value=\"' + ui.item.id + '\"]');
                        setTimeout(function () {
                            $(EmailTo).val('');
                        }, 100);
                        if ($(CurrentItem).length < 1) {
                            var l = '';
                            l += '<span class=\"adm-token-item\" _value=\"' + ui.item.id + '\">' + ui.item.label + '<a href=\"javascript:;\">x</a></span>';
                            $(l).insertBefore(EmailTo);
                            CurrentItem = $(EmailToDiv).find('span[_value=\"' + ui.item.id + '\"]');
                            var removeBtn = $(CurrentItem).find('a');
                            $(removeBtn).click(function () {
                                $(CurrentItem).remove();
                            });
                        }
                        else {
                            $(CurrentItem).animate({ backgroundColor: 'orange' }, 500, function () {
                                $(CurrentItem).animate({ backgroundColor: 'white' }, 500);
                            });
                        }
                    });
                }
            });
        });
    },
    search: function () {
        var timerSearch;

        var filterKhachHangByNguonGoc = $('.filterKhachHangByNguonGoc');
        var filterKhachHangByKhuVuc = $('.filterKhachHangByKhuVuc');
        var q = $('.mdl-head-search-quanLyTheMdl');

        var NguonGoc_ID = filterKhachHangByNguonGoc.attr('_value');
        var KhuVuc_ID = filterKhachHangByKhuVuc.attr('_value');
        var _q = q.val();
        if (_q == 'Tìm kiếm') _q = '';
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#quanLyTheMdl-List').jqGrid('setGridParam', {
                url: quanLyTheFn.urlDefault().toString() + '&subAct=get&NguonGoc_ID=' + NguonGoc_ID + '&KhuVuc_ID=' + KhuVuc_ID + '&q=' + _q
            }).trigger('reloadGrid');
        }, 1000);
    },
    popfn: function () {
        var newDlg = $('#quanLyTheMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var KM_ID = $('.KM_ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var DVTC_ID = $('.DVTC_ID', newDlg);
        var GiaNY = $('.GiaNY', newDlg);
        var Gia = $('.Gia', newDlg);
        var HanSuDung = $('.HanSuDung', newDlg);
        var HanDoiThe = $('.HanDoiThe', newDlg);
        var TinhTrang = $('.TinhTrang', newDlg);
        var DV_ID = $('.DV_ID', newDlg);
        var NgayPhatHanh = $('.NgayPhatHanh', newDlg);
        var NgayNhan = $('.NgayNhan', newDlg);
        var NguoiNhan = $('.NguoiNhan', newDlg);
        var DaDung = $('.DaDung', newDlg);
        var btnThemNhanhKH = $('.btnThemNhanhKH', newDlg);

        adm.formatTien(GiaNY);
        adm.formatTien(Gia);

        HanSuDung.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        HanDoiThe.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayPhatHanh.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayNhan.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });

        adm.regType(typeof (danhMucDichVuMgr), 'appStore.pmSpa.danhMucDichVuMgr.Class1, appStore.pmSpa.danhMucDichVuMgr', function () {
            danhMucDichVuMgr.autoCompleteByQ(DV_ID, function (event, ui) {
                DV_ID.attr('_value', ui.item.id);
            });
        });

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

        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(NguoiNhan, function (event, ui) {
                NguoiNhan.val(ui.item.value);
            });
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'DVTC', DVTC_ID, function (event, ui) {
                DVTC_ID.attr('_value', ui.item.id);
            });
        });
        
        adm.regType(typeof (KhuyenMaiMgrFn), 'appStore.pmSpa.khuyenMaiMgr.Class1, appStore.pmSpa.khuyenMaiMgr', function () {
            KhuyenMaiMgrFn.autoCompleteSearch(KM_ID, function (event, ui) {
                KM_ID.attr('_value', ui.item.id);
            });
        });
    },
    clearform: function () {
        var newDlg = $('#quanLyTheMdl-dlgNew');
        var spbMsg = $('.admMsg', newDlg);
        spbMsg.html('');
        newDlg.find('input').attr('_value', '');
        newDlg.find('input, textarea').val('');
    },
    autoCompleteSearch: function (el, fn, fn1) {
        if (typeof (fn1) != "function") {
            fn1 = function(ul, item) {
                return $("<li></li>")
                    .data("item.autocomplete", item)
                    .append("<a href=\"javascript:;\">" + item.label + "</a>")
                    .appendTo(ul);
            };
        }
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'theKhuyenMaiMgr-autoCompleteSearch' + request.term;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: quanLyTheFn.urlDefault().toString(),
                    dataType: 'script',
                    data: { 'subAct': 'search', 'q': request.term },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function(item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase())) || matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Email.toLowerCase())) || matcher.test(item.Mobile.toLowerCase()) || matcher.test(adm.normalizeStr(item.Phone.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        ma: item.Ma,
                                        KhuVuc_Ten: item.KhuVuc_Ten,
                                        Mobile: item.Mobile,
                                        Email: item.Email,
                                        Phone: item.Phone,
                                        CMND: item.CMND,
                                        Ym: item.YM,
                                        DiaChi: item.DiaChi,
                                        NguonGoc_Ten: item.NguonGoc_Ten
                                    };
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
        }).data("autocomplete")._renderItem = fn1;
    },
    loadHtml: function (fn) {
        var dlg = $('#quanLyTheMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.theKhuyenMaiMgr.quanLyThe.htm.htm")%>',
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
