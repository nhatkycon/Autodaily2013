var noiBoXuatFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.commonStore.xuatNhapMgr.noiBoXuat.Class1, appStore.commonStore.xuatNhapMgr'; },
    urlDefault1: function () { return adm.urlDefault1 + '&act=loadPlug&rqPlug=appStore.commonStore.xuatNhapMgr.noiBoXuat.Class1, appStore.commonStore.xuatNhapMgr'; },
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        var DMID = $('.mdl-head-HangHoaFilterDanhMuc');
        var q = $('.mdl-head-search-hangHoaMgr');
        $('#noiBoXuatMdl-List').jqGrid({
            url: noiBoXuatFn.urlDefault().toString() + '&subAct=get',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mục', 'Mã', 'K/h', 'Ngày Hđ', 'Cộng', 'VAT', 'CK', 'Tổng', 'Thanh toán', 'Nợ', 'Cập nhật'],
            colModel: [
                        { name: 'XN_ID', key: true, sortable: true, hidden: true },
                        { name: 'XN_LOAI_ID', width: 5, sortable: true },
                        { name: 'XN_Ma', width: 10, resizable: true, sortable: true },
                        { name: 'XN_KH_ID', width: 10, resizable: true, sortable: true, hidden: true },
                        { name: 'XN_NgayHoaDon', width: 10, resizable: true, sortable: true },
                        { name: 'XN_CongTienHang', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XN_VAT', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XN_ChietKhau', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XN_CongTienHang', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XN_ThanhToan', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XN_ConNo', width: 10, resizable: true, sortable: true, align: 'right' },
                        { name: 'XN_NgayCapNhat', width: 10, resizable: true, align: 'right' }
                    ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'convert(int,XN_Ma)',
            sortorder: 'desc',
            pager: jQuery('#noiBoXuatMdl-Pager'),   
            rowNum: 10,
            rowList: [10, 20, 50, 100, 200, 300],
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) { },
            loadComplete: function () {
                adm.regJPlugin(jQuery().formatCurrency, '../js/jquery.formatCurrency-1.4.0.min.js', function () {
                });

                adm.regJPlugin(jQuery().tmpl, '../js/jquery.tmpl.min.js', function () {
                });

                adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
                });
                adm.loading(null);
                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteLangBased('', 'NHOM-HH', DMID, function (event, ui) {
                        DMID.attr('_value', ui.item.id);
                        noiBoXuatFn.search();
                    });
                    DMID.unbind('click').click(function () {
                        DMID.autocomplete('search', '');
                    });
                });

                adm.regType(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
                });
            }
        });
        adm.watermark(DMID, 'Gõ tên loại danh mục để lọc', function () {
            DMID.attr('_value', '');
            DMID.val('');
            q.val('');
            noiBoXuatFn.search();
        });
        adm.watermark(q, 'Tìm kiếm', function () {
            q.val('');
            noiBoXuatFn.search();
        });

    },
    XuatNhapChiTietItemFn: function (_obj) {
        var obj = $(_obj);
        adm.styleButton();
        var DV_Ten = obj.find('.DV_Ten').find('input');
        var DonGia = obj.find('.DonGia').find('input');
        var SoLuong = obj.find('.SoLuong').find('input');
        var Tong = obj.find('.Tong').find('input');
        var VAT = obj.find('.VAT').find('input');
        var VATTien = obj.find('.VATTien').find('input');
        var CKTyLe = obj.find('.CKTyLe').find('input');
        var CKTien = obj.find('.CKTien').find('input');
        var Kho = obj.find('.Kho').find('input');
        var Xoa = obj.find('.item-Xoa').find('a');

        Xoa.click(function () {
            var id = obj.attr('id');
            obj.fadeOut('200');
            $.ajax({
                url: noiBoXuatFn.urlDefault().toString(),
                dataType: 'script',
                data: {
                    subAct: 'XoaXNChiTiet',
                    'ID': id
                },
                success: function (_dt) {
                    obj.remove();
                }
            });
        });
        noiBoXuatFn.recount();

        Tong.val(adm.VndToInt(DonGia) * adm.VndToInt(SoLuong));
        CKTien.val(adm.VndToInt(CKTyLe) * adm.VndToInt(Tong) / 100);
        VATTien.val(adm.VndToInt(DonGia) * adm.VndToInt(SoLuong) * adm.VndToInt(VAT) / 100);

        

        DonGia.keyup(function () {
            Tong.val(adm.VndToInt(DonGia) * adm.VndToInt(SoLuong));
            CKTien.val(adm.VndToInt(CKTyLe) * adm.VndToInt(Tong) / 100);
            adm.formatTien(Tong);
            noiBoXuatFn.recount();
        });

        VAT.keyup(function () {
            VATTien.val(adm.VndToInt(DonGia) * adm.VndToInt(SoLuong) * adm.VndToInt(VAT) / 100);
            adm.formatTien(Tong);
            adm.formatTien(VATTien);
            noiBoXuatFn.recount();
        });

        SoLuong.keyup(function () {
            Tong.val(adm.VndToInt(DonGia) * adm.VndToInt(SoLuong));
            CKTien.val(adm.VndToInt(CKTyLe) * adm.VndToInt(Tong) / 100);
            adm.formatTien(Tong);
            noiBoXuatFn.recount();
        });

        CKTyLe.keyup(function () {
            CKTien.val(adm.VndToInt(CKTyLe) * adm.VndToInt(Tong) / 100);
            adm.formatTien(CKTien);
            noiBoXuatFn.recount();
        });
        CKTien.keyup(function () {
            adm.formatTien(CKTien);
            noiBoXuatFn.recount();
        });
        
        adm.formatTien(DonGia);
        adm.formatTien(Tong);
        adm.formatTien(CKTien);
        adm.formatTien(VATTien);
        adm.formatTien(SoLuong);
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'DONVI', DV_Ten, function (event, ui) {
                DV_Ten.attr('_value', ui.item.id);
            });
        });
    },
    updateXNCTItem: function (_obj) {
        var obj = $(_obj);

        var DV_Ten = obj.find('.DV_Ten').find('input');
        var DonGia = obj.find('.DonGia').find('input');
        var SoLuong = obj.find('.SoLuong').find('input');
        var Tong = obj.find('.Tong').find('input');
        var VAT = obj.find('.VAT').find('input');
        var VATTien = obj.find('.VATTien').find('input');
        var CKTyLe = obj.find('.CKTyLe').find('input');
        var CKTien = obj.find('.CKTien').find('input');
        var GhiChu = obj.find('.GhiChu').find('input');
        var Kho = obj.find('.Kho').find('input');
        var Xoa = obj.find('.item-Xoa').find('a');
        var ID = obj.attr('id');
        $.each(obj.find('input'), function (i, _item) {
            var item = $(_item);
            item.keyup(function () {
                var _DV_ID = DV_Ten.attr('_value');
                var _DonGia = adm.VndToInt(DonGia);
                var _SoLuong = SoLuong.val();
                var _Tong = adm.VndToInt(Tong);
                var _VAT = VAT.val();
                var _VATTien = adm.VndToInt(VATTien);
                var _CKTyLe = CKTyLe.val();
                var _CKTien = adm.VndToInt(CKTien);
                var _KH_ID = Kho.attr('_value');
                var _GhiChu = GhiChu.val();
                if (_DV_ID != '' && _DonGia != '' && _SoLuong != '' && _Tong != '' && _VAT != '' && _VATTien != '' && _CKTien != '' && _CKTyLe != '') {
                    var timerS;
                    if (timerS) clearTimeout(timerS);
                    timerS = setTimeout(function () {
                        $.ajax({
                            url: noiBoXuatFn.urlDefault().toString(),
                            type: 'POST',
                            data: {
                                subAct: 'SaveXNChiTiet',
                                ID: ID,
                                DV_ID: _DV_ID,
                                DonGia: _DonGia,
                                SoLuong: _SoLuong,
                                Tong: _Tong,
                                VAT: _VAT,
                                VATTien: _VATTien,
                                CKTyLe: _CKTyLe,
                                CKTien: _CKTien,
                                GhiChu: _GhiChu,
                                KH_ID : _KH_ID
                            },
                            success: function (_dt) {
                            }
                        });
                    }, 500);
                }
            });
        });

    },
    recount: function () {
        var newDlg = $('#noiBoXuatMdl-dlgNew');
        var CongTienHang = $('.CongTienHang', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var TongVAT = $('.TongVAT', newDlg);
        var ChietKhau = $('.ChietKhau', newDlg);
        var ConNo = $('.ConNo', newDlg);
        var ThanhToan = $('.ThanhToan', newDlg);
        var PhaiTra = $('.PhaiTra', newDlg);

        var DanhSachXuatNhapChiTiet = $('.DanhSachXuatNhapChiTiet', newDlg);
        var SoLuongAll = DanhSachXuatNhapChiTiet.find('.SoLuongAll').find('input');
        var TongAll = DanhSachXuatNhapChiTiet.find('.TongAll').find('input');
        var CKTienAll = DanhSachXuatNhapChiTiet.find('.CKTienAll').find('input');
        var VATAll = DanhSachXuatNhapChiTiet.find('.VATAll').find('input');

        var totalSoLuong = 0;
        var totalTong = 0;
        var totalCKTien = 0;
        var totalVat = 0;



        $.each(DanhSachXuatNhapChiTiet.find('.ds-item-value'), function (i, jtem) {
            var item = $(jtem);
            totalSoLuong += parseFloat(adm.VndToInt(item.find('.SoLuong').find('input')));
            totalTong += adm.VndToInt(item.find('.SoLuong').find('input')) * adm.VndToInt(item.find('.DonGia').find('input'));
            totalCKTien += parseFloat(adm.VndToInt(item.find('.CKTien').find('input')));
            totalVat += parseFloat(adm.VndToInt(item.find('.VATTien').find('input')));
        });

        ChietKhau.val(totalCKTien);
        CongTienHang.val(totalTong);

        VATAll.val(totalVat);
        SoLuongAll.val(totalSoLuong);
        TongAll.val(totalTong);
        CKTienAll.val(totalCKTien);
        TongVAT.val(totalVat);


        var phaiTra = parseFloat(totalTong) + parseFloat(totalVat) - parseFloat(totalCKTien);
        var thanhToan = ThanhToan.val();
        if (thanhToan == '') {
            thanhToan = '0';
        }
        else {
            thanhToan = adm.VndToInt(ThanhToan);
        }

        var conNo = phaiTra - thanhToan;
        PhaiTra.val(phaiTra);
        ConNo.val(conNo);

        ThanhToan.unbind('keyup').keyup(function () {
            noiBoXuatFn.recount();
        });

        ChietKhau.unbind('keyup').keyup(function () {
            noiBoXuatFn.recount();
        });

        adm.formatTien(ThanhToan);
        adm.formatTien(ConNo);
        adm.formatTien(ChietKhau);
        adm.formatTien(CongTienHang);
        adm.formatTien(TongVAT);
        adm.formatTien(PhaiTra);
        adm.formatTien(VATAll);
        adm.formatTien(SoLuongAll);
        adm.formatTien(TongAll);
        adm.formatTien(CKTienAll);

    },
    popfn: function (newDlg) {
        var ID = $('.ID', newDlg);
        var NgayHoaDon = $('.NgayHoaDon', newDlg);
        var Ma = $('.Ma', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var btnThemNhanhKH = $('.btnThemNhanhKH', newDlg);

        var HangHoa = $('.HangHoa', newDlg);
        var btnThemNhanhHH = $('.btnThemNhanhHH', newDlg);
        
        var DanhSachXuatNhapChiTiet = $('.DanhSachXuatNhapChiTiet', newDlg);
        var DanhSachXuatNhapChiTietFooter = DanhSachXuatNhapChiTiet.find('.ds-footer');
        var NhanVien = $('.NhanVien', newDlg);
        var CongTienHang = $('.CongTienHang', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var TongVAT = $('.TongVAT', newDlg);
        var ChietKhau = $('.ChietKhau', newDlg);
        var ConNo = $('.ConNo', newDlg);
        var ThanhToan = $('.ThanhToan', newDlg);
        var PhaiTra = $('.PhaiTra', newDlg);
        var KHO_ID = $('.KHO_ID', newDlg);
        

        adm.regType(typeof (KhoHangMgrFn), 'appStore.pmSpa.khoHangMgr.Class1, appStore.pmSpa.khoHangMgr', function () {
            KhoHangMgrFn.autoComplete(KHO_ID, function (event, ui) {
                KHO_ID.attr('_value', ui.item.id);
            });
        });

        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(NhanVien, function (event, ui) {
                NhanVien.val(ui.item.value);
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

        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        if (NgayHoaDon.val() == '') {
            NgayHoaDon.val(dateStr);
        }
        NgayHoaDon.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        adm.regType(typeof (hangHoaMgrFn), 'appStore.commonStore.hangHoaMgr.Class1, appStore.commonStore.hangHoaMgr', function () {
            hangHoaMgrFn.autoCompleteByQ(HangHoa, function (event, ui) {
                var cItem = DanhSachXuatNhapChiTiet.find('.ds-item-' + ui.item.id);
                HangHoa.focus();
                HangHoa.val('');
                if ($(cItem).length < 1) {
                    $.ajax({
                        url: noiBoXuatFn.urlDefault().toString(),
                        dataType: 'script',
                        data: {
                            subAct: 'ThemXNChiTiet',
                            'ID': ID.val(),
                            'HH_ID': ui.item.id
                        },
                        success: function (_dt) {
                            adm.loading(null);
                            var dt = eval(_dt);
                            var newItem = $('#xnct-hh-item').tmpl(dt).insertBefore(DanhSachXuatNhapChiTietFooter);
                            newItem.hide();
                            newItem.fadeIn('slideDown');
                            noiBoXuatFn.XuatNhapChiTietItemFn(newItem);
                            noiBoXuatFn.recount();
                            noiBoXuatFn.updateXNCTItem(newItem);
                        }
                    });
                    HangHoa.focus();
                    HangHoa.val('');
                }
                else {
                    var soLuong = cItem.find('.SoLuong').find('input');
                    soLuong.val(adm.VndToInt(soLuong) + 1);
                    HangHoa.focus();
                    HangHoa.val('');
                    noiBoXuatFn.XuatNhapChiTietItemFn(cItem);
                    noiBoXuatFn.recount();
                    noiBoXuatFn.updateXNCTItem(cItem);
                }
                return false;
            });
            HangHoa.unbind('click').click(function () {
                HangHoa.autocomplete('search', '');
            });
            btnThemNhanhHH.unbind('click').click(function () {
                hangHoaMgrFn.addQuick(function (_ID, _Ten) {
                    $.ajax({
                        url: noiBoXuatFn.urlDefault().toString(),
                        dataType: 'script',
                        data: {
                            subAct: 'ThemXNChiTiet',
                            'ID': ID.val(),
                            'HH_ID': _ID
                        },
                        success: function (_dt) {
                            adm.loading(null);
                            var dt = eval(_dt);
                            var newItem = $('#xnct-hh-item').tmpl(dt).insertBefore(DanhSachXuatNhapChiTietFooter);
                            noiBoXuatFn.XuatNhapChiTietItemFn(newItem);
                            noiBoXuatFn.recount();
                            HangHoa.val('');
                            HangHoa.focus();
                        }
                    });
                });
            });
        });

        adm.formatTien(ThanhToan);
        adm.formatTien(ConNo);
        adm.formatTien(TongVAT);
        adm.formatTien(ChietKhau);
        adm.formatTien(PhaiTra);
        adm.formatTien(CongTienHang);
    },
    refresh: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#noiBoXuatMdl-List';
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $(grid).jqGrid('setGridParam', { url: noiBoXuatFn.urlDefault().toString() + '&subAct=get' }).trigger('reloadGrid');
        }, 500);
    },
    edit: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#noiBoXuatMdl-List';

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
                noiBoXuatFn.loadHtml(function () {
                    var newDlg = $('#noiBoXuatMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 1010,
                        buttons: {
                            'Lưu': function () {
                                noiBoXuatFn.save(false, function () {
                                    noiBoXuatFn.clearform();
                                    noiBoXuatFn.draff(function (dt) {
                                        newDlg.find('.ID').val(dt);
                                        newDlg.find('.ID').attr('draff', '1');
                                    });
                                }, grid),{};
                            },
                            'Lưu và đóng': function () {
                                noiBoXuatFn.save(false, function () {
                                    noiBoXuatFn.clearform();
                                    $(newDlg).dialog('close');
                                }, grid,{});
                            },
                            'In hóa đơn': function () {
                                noiBoXuatFn.createReport(s);
                            },
                            'In phiếu thu': function () {
                                noiBoXuatFn.createReport(s);
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        beforeClose: function () {
                            noiBoXuatFn.clearform();
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            noiBoXuatFn.clearform();
                            $.ajax({
                                url: noiBoXuatFn.urlDefault().toString() + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);

                                    var ID = $('.ID', newDlg);
                                    ID.attr('draff', '0');
                                    var NgayHoaDon = $('.NgayHoaDon', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var KH_ID = $('.KH_ID', newDlg);
                                    var DanhSachXuatNhapChiTiet = $('.DanhSachXuatNhapChiTiet', newDlg);
                                    var DanhSachXuatNhapChiTietFooter = DanhSachXuatNhapChiTiet.find('.ds-footer');
                                    var NhanVien = $('.NhanVien', newDlg);
                                    var CongTienHang = $('.CongTienHang', newDlg);
                                    var GhiChu = $('.GhiChu', newDlg);
                                    var TongVAT = $('.TongVAT', newDlg);
                                    var ChietKhau = $('.ChietKhau', newDlg);
                                    var ConNo = $('.ConNo', newDlg);
                                    var ThanhToan = $('.ThanhToan', newDlg);
                                    var HangHoa = $('.HangHoa', newDlg);
                                    var PhaiTra = $('.PhaiTra', newDlg);
                                    var KHO_ID = $('.KHO_ID', newDlg);
                                    
                                    ID.val(dt.ID);
                                    var value = new Date(dt.NgayHoaDon);

                                    NgayHoaDon.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());
                                    Ma.val(dt.Ma);

                                    KHO_ID.val(dt.KHO_Ten);
                                    KHO_ID.attr('_value', dt.KHO_ID);
                                    
                                    KH_ID.val(dt.KH_Ten);
                                    KH_ID.attr('_value', dt.KH_ID);
                                    $.each(dt.XNCT, function (i, item) {
                                        var newItem = $('#xnct-hh-item').tmpl(item).insertBefore(DanhSachXuatNhapChiTietFooter);
                                        newItem.hide();
                                        newItem.fadeIn('slideDown');
                                        noiBoXuatFn.XuatNhapChiTietItemFn(newItem);
                                        noiBoXuatFn.recount();
                                        noiBoXuatFn.updateXNCTItem(newItem);
                                    });

                                    NhanVien.val(dt.NhanVien);
                                    CongTienHang.val(dt.CongTienHang);
                                    GhiChu.val(dt.GhiChu);
                                    TongVAT.val(dt.VAT);
                                    ChietKhau.val(dt.ChietKhau);
                                    ConNo.val(dt.ConNo);
                                    ThanhToan.val(dt.ThanhToan);
                                    PhaiTra.val(dt.PhaiTra);
                                    noiBoXuatFn.popfn();
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function (_newDlg, fn, obj) {
        noiBoXuatFn.loadHtml(function () {
            var newDlg = $('#noiBoXuatMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1010,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        noiBoXuatFn.save(false, function (_ID) {
                            if (typeof (fn) == 'function') {
                                fn(_ID);
                            }
                            noiBoXuatFn.clearform();
                            noiBoXuatFn.draff(function (_dt) {
                                var dt = eval(_dt);
                                var ID = newDlg.find('.ID');
                                var Ma = newDlg.find('.Ma');
                                ID.val(dt.ID);
                                Ma.val(dt.Ma);
                                ID.attr('draff', '1');
                            });
                        }, '#noiBoXuatMdl-List', obj);
                    },
                    'Lưu và đóng': function () {
                        noiBoXuatFn.save(false, function (_ID) {
                            if (typeof (fn) == 'function') {
                                fn(_ID);
                            }
                            $(newDlg).dialog('close');
                        }, '#noiBoXuatMdl-List', obj);
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    noiBoXuatFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    noiBoXuatFn.clearform();
                    noiBoXuatFn.popfn(newDlg);
                    noiBoXuatFn.draff(function (_dt) {
                        var dt = eval(_dt);
                        var ID = newDlg.find('.ID');
                        var Ma = newDlg.find('.Ma');
                        ID.val(dt.ID);
                        Ma.val(dt.Ma);
                        ID.attr('draff', '1');
                    });
                }
            });
        });
    },
    loc: function () {
        noiBoXuatFn.loadHtml(function () {
            var newDlg = $('#noiBoXuatMdl-dlgFilter');
            $(newDlg).dialog({
                title: 'Lọc',
                width: 600,
                modal: true,
                buttons: {
                    'Tìm': function () {
                        var DM_ID = $('.DM_ID', newDlg);
                        var KH_ID = $('.KH_ID', newDlg);
                        var TuNgay = $('.TuNgay', newDlg);
                        var DenNgay = $('.DenNgay', newDlg);
                        var _DM_ID = DM_ID.attr('_value');
                        var _KH_ID = KH_ID.attr('_value');
                        var _TuNgay = TuNgay.val();
                        var _DenNgay = DenNgay.val();
                        $('#noiBoXuatMdl-List').jqGrid('setGridParam', { url: noiBoXuatFn.urlDefault().toString() + '&subAct=get&DM_ID=' + _DM_ID + '&KH_ID=' + _KH_ID + '&TuNgay=' + _TuNgay + '&DenNgay=' + _DenNgay }).trigger('reloadGrid');

                    },
                    'Nhập lại': function () {
                        noiBoXuatFn.locClearform();
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                    noiBoXuatFn.locClearform();
                },
                open: function () {
                    adm.styleButton();
                    noiBoXuatFn.locClearform();
                    noiBoXuatFn.locPopfn(newDlg);
                }
            });
        });
    },
    locClearform: function (newDlg) {
        var DM_ID = $('.DM_ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var TuNgay = $('.TuNgay', newDlg);
        var DenNgay = $('.DenNgay', newDlg);

        DM_ID.val('');
        DM_ID.attr('_value', '');
        KH_ID.val('');
        KH_ID.attr('_value', '');
        TuNgay.val('');
        DenNgay.val('');
    },
    locPopfn: function (newDlg) {

        var DM_ID = $('.DM_ID', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var TuNgay = $('.TuNgay', newDlg);
        var DenNgay = $('.DenNgay', newDlg);

        adm.regType(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
            DanhSachKhachHangFn.autoCompleteSearch(KH_ID, function (event, ui) {
                KH_ID.attr('_value', ui.item.id);
            });
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'NHOM-HH', DM_ID, function (event, ui) {
                DM_ID.attr('_value', ui.item.id);
            });
            DM_ID.unbind('click').click(function () {
                DM_ID.autocomplete('search', '');
            });
        });

        TuNgay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });

        DenNgay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });

    },
    del: function (grid) {
        if (typeof (grid) == 'undefined') grid == '#noiBoXuatMdl-List';
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
                    url: noiBoXuatFn.urlDefault().toString() + '&subAct=del',
                    dataType: 'script',
                    data: { 'ID': s },
                    success: function (dt) {
                        jQuery(grid).trigger('reloadGrid');
                    }
                });
            }
        }
    },
    save: function (validate, fn, grid, obj) {
        if (typeof (grid) == 'undefined') grid == '#noiBoXuatMdl-List';
        var newDlg = $('#noiBoXuatMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var NgayHoaDon = $('.NgayHoaDon', newDlg);
        var Ma = $('.Ma', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var NhanVien = $('.NhanVien', newDlg);
        var CongTienHang = $('.CongTienHang', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var TongVAT = $('.TongVAT', newDlg);
        var ChietKhau = $('.ChietKhau', newDlg);
        var ConNo = $('.ConNo', newDlg);
        var ThanhToan = $('.ThanhToan', newDlg);
        var PhaiTra = $('.PhaiTra', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var KHO_ID = $('.KHO_ID', newDlg);
        
        var _draff = ID.attr('draff');

        var _ID = ID.val();
        var _NgayHoaDon = NgayHoaDon.val();
        var _Ma = Ma.val();
        var _KH_ID = KH_ID.attr('_value');
        var _NhanVien = NhanVien.val();
        var _CongTienHang = adm.VndToInt(CongTienHang);
        var _GhiChu = GhiChu.val();
        var _TongVAT = adm.VndToInt(TongVAT);
        var _ChietKhau = adm.VndToInt(ChietKhau);
        var _ConNo = adm.VndToInt(ConNo);
        var _ThanhToan = adm.VndToInt(ThanhToan);
        var _PhaiTra = adm.VndToInt(PhaiTra);
        var _KHO_ID = KHO_ID.attr('_value');

        var err = '';
        if (_Ma == '') { err += 'Nhập mã<br/>'; };
        if (_NhanVien == '') { err += 'Chọn nhân viên<br/>'; };
        if (_KHO_ID == '') { err += 'Chọn kho hàng<br/>'; };
        if (_NgayHoaDon == '') { err += 'Chọn ngày<br/>'; };
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        var datas = {
            'subAct': 'save',
            draff: _draff,
            ID: _ID,
            Ma: _Ma,
            KH_ID: _KH_ID,
            NhanVien: _NhanVien,
            NgayHoaDon: _NgayHoaDon,
            GhiChu: _GhiChu,
            CongTienHang: _CongTienHang,
            VAT: _TongVAT,
            ChietKhau: _ChietKhau,
            ThanhToan: _ThanhToan,
            ConNo: _ConNo,
            KHO_ID: _KHO_ID
        };
        $.extend(datas, obj);
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: noiBoXuatFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: datas,     
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
        var DMID = $('.mdl-head-HangHoaFilterDanhMuc');
        var q = $('.mdl-head-search-hangHoaMgr');
        var _DMID = DMID.attr('_value');
        var timerSearch;
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#noiBoXuatMdl-List').jqGrid('setGridParam', { url: noiBoXuatFn.urlDefault().toString() + '&subAct=get&DM_ID=' + _DMID + '&q=' + q.val() }).trigger('reloadGrid');
        }, 500);
    },
    draff: function (fn) {
        $.ajax({
            url: noiBoXuatFn.urlDefault().toString(),
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
        var newDlg = $('#noiBoXuatMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var NgayHoaDon = $('.NgayHoaDon', newDlg);
        var Ma = $('.Ma', newDlg);
        var KH_ID = $('.KH_ID', newDlg);
        var NhanVien = $('.NhanVien', newDlg);
        var CongTienHang = $('.CongTienHang', newDlg);
        var GhiChu = $('.GhiChu', newDlg);
        var TongVAT = $('.TongVAT', newDlg);
        var ChietKhau = $('.ChietKhau', newDlg);
        var ConNo = $('.ConNo', newDlg);
        var ThanhToan = $('.ThanhToan', newDlg);
        var PhaiTra = $('.PhaiTra', newDlg);
        var KHO_ID = $('.KHO_ID', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        $(spbMsg).html('');
        ID.val('');
        KH_ID.attr('_value', '');
        KHO_ID.attr('_value', '');
        var DanhSachXuatNhapChiTiet = $('.DanhSachXuatNhapChiTiet', newDlg);
        DanhSachXuatNhapChiTiet.find('.ds-item-value').remove();
        newDlg.find('input').val('');
        ThanhToan.val('0');
    },
    createReportByGrid: function (grid) {
        var s = '';
        if (typeof (grid) == 'undefined') grid == '#noiBoXuatMdl-List';

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
                noiBoXuatFn.createReport(s);
            }
        }
    },
    createReport: function (id) {
        var request = document.location.href + noiBoXuatFn.urlDefault().toString() + '&subAct=reports&ID=' + id;
        var win = window.open(request, 'popup', 'width=1024, height=700');
        win.focus();
    },
    autoCompleteByQ: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'hangHoa-autoCompleteByQ' + el.val();
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: noiBoXuatFn.urlDefault().toString(),
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
        var dlg = $('#noiBoXuatMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.commonStore.xuatNhapMgr.noiBoXuat.htm.htm")%>',
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
