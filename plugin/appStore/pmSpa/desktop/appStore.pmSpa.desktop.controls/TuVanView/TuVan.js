var tuVanFn = {
    urlDefault: function () { return domain + '/lib/admin/Default.aspx?&act=loadPlug&rqPlug=appStore.pmSpa.desktop.controls.TuVanView.DanhSach, appStore.pmSpa.desktop.controls'; },
    EditForm: '#TuVanDichVu-newDlg',
    KhachHangForm: '#DeskTopKhachHangMdl-newDlg',
    TimKiemForm: '#DeskTopTimKiemKhachHangMdl-newDlg',
    LamDichVuForm: '#TuVanLamDichVu-newDlg',
    Show: function () {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        tuVanFn.loadHtml(function () {
            var newDlg = $(tuVanFn.KhachHangForm);
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1010,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        tuVanFn.save(function () {
                            tuVanFn.clearform();
                            tuVanFn.draff(function (_item) { });
                        });
                    },
                    'Lưu và đóng': function () {
                        tuVanFn.save(false, function () {
                            $(newDlg).dialog('close');
                            tuVanFn.draff(function (_item) { });
                        });
                    },
                    'In': function () {
                        $(newDlg).dialog('close');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        tuVanFn.clearform();
                    }
                },
                beforeClose: function () {
                    tuVanFn.clearform();
                },
                open: function () {
                    common.styleButton();
                    tuVanFn.clearform();
                    tuVanFn.popfn();
                    tuVanFn.draff(function (_item) { });
                }
            });
        });
    },
    AddDichVuProxy: function (_id) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        tuVanFn.AddDichVu(_id, function (dt) {
            var myUi = eval(dt);
            var skList = $('.kh-DichVu-list');
            $('#tv-dv-item').tmpl(myUi).prependTo(skList);
        });
    },
    AddMuaKem: function (_id) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        common.regPlug(typeof (quanLyXuatNhapFn), 'appStore.commonStore.xuatNhapMgr.quanLyXuatNhap.Class1, appStore.commonStore.xuatNhapMgr', function () {
            quanLyXuatNhapFn.add(null, function (dt) {
                document.location.reload();
            }, { TV_ID: _id });
        });
    },
    AddDichVu: function (_id, fn) {
        var obj = { TV_ID: _id };
        tuVanFn.loadHtml(function () {
            var newDlg = $(tuVanFn.EditForm);
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 700,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        tuVanFn.saveDichVu(obj, function (dt) {
                            if(typeof (fn) =="function") {
                                fn(dt);
                            }
                            tuVanFn.clearformDichVu();
                        });
                    },
                    'Lưu và đóng': function () {
                        tuVanFn.saveDichVu(obj, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            $(newDlg).dialog('close');
                            tuVanFn.clearformDichVu();
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        tuVanFn.clearformDichVu();
                    }
                },
                position: {
                    my: "center top", at: "center top"
                },
                create: function (/*e, ui*/) {
                    var $dlgELem = $(this);
                    $dlgELem.dialog('widget').find('.ui-dialog-titlebar').remove();
                },
                beforeClose: function () {
                    tuVanFn.clearformDichVu();
                },
                open: function () {
                    common.styleButton();
                    tuVanFn.clearformDichVu();
                    tuVanFn.popDichVufn();
                }
            });
        });
    },
    viewDichVuProxy:function (_id) {
        tuVanFn.viewDichVu(_id, function(dt) {
            var myUi = eval(dt);            
            var cItem = $('#' + _id);
            var newItem = $('#tv-dv-item-edit').tmpl(myUi).html();
            $(cItem).html(newItem);
        });
    },
    addLamDichVuProxy: function (_id) {
        console.log(_id);
        tuVanFn.addLamDichVu(_id, function (dt) {
            var myUi = eval(dt);
            var skList = $('#ldv-list-' + _id);
            $('#tv-ldv-item').tmpl(myUi).appendTo(skList);
        });
    },
    addLamDichVu: function (_id, fn) {
        var obj = { TVDV_ID: _id };
        tuVanFn.loadHtml(function () {
            var newDlg = $(tuVanFn.LamDichVuForm);
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1010,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        tuVanFn.saveLamDichVu(obj, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            tuVanFn.clearLamDichVu();
                            //tuVanFn.draff(function (_dt) {
                            //}, _id);
                        });
                    },
                    'Lưu và đóng': function () {
                        tuVanFn.saveLamDichVu(obj, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            $(newDlg).dialog('close');
                            tuVanFn.clearLamDichVu();
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        tuVanFn.clearLamDichVu();
                    }
                },
                position: {
                    my: "center top", at: "center top"
                },
                create: function (/*e, ui*/) {
                    var $dlgELem = $(this);
                    $dlgELem.dialog('widget').find('.ui-dialog-titlebar').remove();
                },
                beforeClose: function () {
                    tuVanFn.clearLamDichVu();
                },
                open: function () {
                    common.styleButton();
                    tuVanFn.clearLamDichVu();
                    tuVanFn.popLamDichVuFn(_id);
                    tuVanFn.draff(function (_dt) {
                    }, _id);
                }
            });
        });
    },
    viewLamDichVuProxy: function (_id, id) {
        tuVanFn.viewLamDichVu(id, _id, function (dt) {
            var myUi = eval(dt);
            var cItem = $('#' + _id + '');
            console.log(cItem);
            var newItem = $('#tv-ldv-item').tmpl(myUi).html();
            $(cItem).html(newItem);
        });
    },
    viewLamDichVu: function (_id, id, fn) {
        tuVanFn.loadHtml(function () {
            var newDlg = $(tuVanFn.LamDichVuForm);
            $(newDlg).dialog({
                title: 'Sửa dịch vụ',
                width: 1010,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        tuVanFn.saveLamDichVu({}, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            tuVanFn.clearLamDichVu();
                            $(newDlg).dialog('close');
                            tuVanFn.draff(function (_dt) {
                            }, _id);
                        });
                    },
                    'Xóa': function () {
                        $.ajax({
                            url: tuVanFn.urlDefault().toString(),
                            data: { 'subAct': 'delLamDichVu', 'ID': id },
                            type: 'POST',
                            dataType: 'script',
                            success: function () {
                                $('#' + id).remove();
                            }
                        });
                        $(newDlg).dialog('close');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        tuVanFn.clearLamDichVu();
                        
                    }
                },
                beforeClose: function () {
                    tuVanFn.clearLamDichVu();
                },
                open: function () {
                    common.styleButton();
                    tuVanFn.clearLamDichVu();
                    tuVanFn.popLamDichVuFn(_id);
                    $.ajax({
                        url: tuVanFn.urlDefault().toString(),
                        data: { 'subAct': 'editLamDichVu', 'ID': id },
                        type: 'POST',
                        dataType: 'script',
                        success: function (_dt) {
                            var dt = eval(_dt);

                            var ID = newDlg.find('.ID');
                            var NhanVien = newDlg.find('.NhanVien');
                            var ThuTu = newDlg.find('.ThuTu');
                            var NgayLam = newDlg.find('.NgayLam');
                            var XN_ID = newDlg.find('.XN_ID');

                            ID.val(dt.ID);
                            NhanVien.val(dt.NhanVien_Ten);
                            NhanVien.attr('_value', dt.NhanVien);
                            ThuTu.val(dt.ThuTu);
                            XN_ID.val(dt.XN_ID);
                            var value = new Date(dt.NgayLam);
                            NgayLam.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());
                            
                            var DanhSachXuatNhapChiTiet = $('.DanhSachTieuHaoChiTiet', newDlg);
                            var DanhSachXuatNhapChiTietFooter = DanhSachXuatNhapChiTiet.find('.ds-footer');
                            $.each(dt._XuatNhap.XNCT, function (i, item) {
                                var newItem = $('#xnct-hh-item-1').tmpl(item).insertBefore(DanhSachXuatNhapChiTietFooter);
                                newItem.hide();
                                newItem.fadeIn('slideDown');
                                tuVanFn.XuatNhapChiTietItemFn(newItem);
                                tuVanFn.updateXNCTItem(newItem);
                            });
                        }
                    });
                }
            });
        });
    },
    saveLamDichVu: function (obj, fn) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        var newDlg = $(tuVanFn.LamDichVuForm);
        var ID = newDlg.find('.ID');
        var NhanVien = newDlg.find('.NhanVien');
        var ThuTu = newDlg.find('.ThuTu');
        var NgayLam = newDlg.find('.NgayLam');
        var XN_ID = newDlg.find('.XN_ID');
        var _ID = ID.val();
        var _ThuTu = ThuTu.val();
        var _NhanVien = NhanVien.attr('_value');
        var _XN_ID = XN_ID.val();
        var _NgayLam = NgayLam.val();

        var err = '';
        if (_NhanVien == '') { err = 'Chọn nhân viên<br/>'; }
        if (_ThuTu == '') { err = 'Nhập thứ tự<br/>'; }
        if (_XN_ID == '') { err = 'Thiếu mã xuất<br/>'; }
        if (err != '') {
            common.fbMsg('Lỗi', 'Bạn cần hoàn thành các lỗi sau <hr/>' + err, 200, 'msg-dangKy-pop', function () {
                setTimeout(function () {
                    $(document).trigger('close.facebox', 'msg-dangKy-pop');
                }, 10000);
            });
            return false;
        }
        var datas = {
            'subAct': 'saveLamDichVu',
            ID: _ID,
            NgayLam: _NgayLam,
            NhanVien: _NhanVien,
            ThuTu: _ThuTu,
            XN_ID: _XN_ID
        };
        $.extend(datas, obj);
        $.ajax({
            url: tuVanFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: datas,
            success: function (dt) {
                if(typeof (fn) == "function") {
                    fn(dt);
                }
            }
        });
    },
    clearLamDichVu: function () {
        var newDlg = $(tuVanFn.LamDichVuForm);
        newDlg.attr('_id', '');
        newDlg.find('input, textarea').val('');
        newDlg.find('input, textarea').attr('_value', '');
        var DanhSachXuatNhapChiTiet = $('.DanhSachTieuHaoChiTiet', newDlg);
        DanhSachXuatNhapChiTiet.find('.ds-item-value').remove();
    },
    XuatNhapChiTietItemFn: function (_obj) {
        var obj = $(_obj);
        common.styleButton();
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
                url: tuVanFn.urlDefault().toString(),
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

        Tong.val(adm.VndToNumber(DonGia) * adm.VndToNumber(SoLuong));
        CKTien.val(adm.VndToNumber(CKTyLe) * adm.VndToNumber(Tong) / 100);
        VATTien.val(adm.VndToNumber(DonGia) * adm.VndToNumber(SoLuong) * adm.VndToNumber(VAT) / 100);



        DonGia.keyup(function () {
            Tong.val(adm.VndToNumber(DonGia) * adm.VndToNumber(SoLuong));
            CKTien.val(adm.VndToNumber(CKTyLe) * adm.VndToNumber(Tong) / 100);
            adm.formatTien(Tong);
        });

        VAT.keyup(function () {
            VATTien.val(adm.VndToNumber(DonGia) * adm.VndToNumber(SoLuong) * adm.VndToNumber(VAT) / 100);
            adm.formatTien(Tong);
            adm.formatTien(VATTien);
        });

        SoLuong.keyup(function () {
            Tong.val(adm.VndToNumber(DonGia) * adm.VndToNumber(SoLuong));
            CKTien.val(adm.VndToNumber(CKTyLe) * adm.VndToNumber(Tong) / 100);
            adm.formatTien(Tong);
        });

        CKTyLe.keyup(function () {
            CKTien.val(adm.VndToNumber(CKTyLe) * adm.VndToNumber(Tong) / 100);
            adm.formatTien(CKTien);
        });
        CKTien.keyup(function () {
            adm.formatTien(CKTien);
        });

        adm.formatTien(DonGia);
        adm.formatTien(Tong);
        adm.formatTien(CKTien);
        adm.formatTien(VATTien);

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
        var XN_ID = obj.attr('XN_ID');
        $.each(obj.find('input'), function (i, _item) {
            var item = $(_item);
            item.keyup(function () {
                var _DV_ID = DV_Ten.attr('_value');
                var _DonGia = DonGia.val();
                var _SoLuong = SoLuong.val();
                var _Tong = Tong.val();
                var _VAT = VAT.val();
                var _VATTien = VATTien.val();
                var _CKTyLe = CKTyLe.val();
                var _CKTien = CKTien.val();
                var _KH_ID = Kho.attr('_value');
                var _GhiChu = GhiChu.val();
                if (_DV_ID != '' && _DonGia != '' && _SoLuong != '' && _Tong != '' && _VAT != '' && _VATTien != '' && _CKTien != '' && _CKTyLe != '') {
                    var timerS;
                    if (timerS) clearTimeout(timerS);
                    timerS = setTimeout(function () {
                        $.ajax({
                            url: tuVanFn.urlDefault().toString(),
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
                                KH_ID: _KH_ID,
                                XN_ID: XN_ID
                            },
                            success: function (_dt) {
                            }
                        });
                    }, 500);
                }
            });
        });

    },
    popLamDichVuFn: function (_id) {
        var newDlg = $(tuVanFn.LamDichVuForm);
        var XN_ID = newDlg.find('.XN_ID');
        var NhanVien = newDlg.find('.NhanVien');
        var ThuTu = newDlg.find('.ThuTu');
        var NgayLam = newDlg.find('.NgayLam');
        var HangHoa = $('.HangHoa', newDlg);
        var btnThemNhanhHH = $('.btnThemNhanhHH', newDlg);
        var DanhSachXuatNhapChiTiet = $('.DanhSachTieuHaoChiTiet', newDlg);
        var DanhSachXuatNhapChiTietFooter = DanhSachXuatNhapChiTiet.find('.ds-footer');
        
        common.regPlug(typeof (hangHoaMgrFn), 'appStore.commonStore.hangHoaMgr.Class1, appStore.commonStore.hangHoaMgr', function () {
            hangHoaMgrFn.autoCompleteByQ(HangHoa, function (event, ui) {
                var cItem = DanhSachXuatNhapChiTiet.find('.ds-item-' + ui.item.id);
                HangHoa.focus();
                HangHoa.val('');
                if ($(cItem).length < 1) {
                    $.ajax({
                        url: tuVanFn.urlDefault().toString(),
                        dataType: 'script',
                        data: {
                            subAct: 'ThemXNChiTiet',
                            'XN_ID': XN_ID.val(),
                            'HH_ID': ui.item.id,
                            'TV_ID' : _id
                        },
                        success: function (_dt) {
                            adm.loading(null);
                            var dt = eval(_dt);
                            var newItem = $('#xnct-hh-item-1').tmpl(dt).insertBefore(DanhSachXuatNhapChiTietFooter);
                            newItem.hide();
                            newItem.fadeIn('slideDown');
                            tuVanFn.XuatNhapChiTietItemFn(newItem);
                            tuVanFn.updateXNCTItem(newItem);
                        }
                    });
                    HangHoa.focus();
                    HangHoa.val('');
                }
                else {
                    var soLuong = cItem.find('.SoLuong').find('input');
                    soLuong.val(adm.VndToNumber(soLuong) + 1);
                    HangHoa.focus();
                    HangHoa.val('');
                    tuVanFn.XuatNhapChiTietItemFn(cItem);
                    tuVanFn.updateXNCTItem(cItem);
                }
                return false;
            });
            HangHoa.unbind('click').click(function () {
                HangHoa.autocomplete('search', '');
            });
            btnThemNhanhHH.unbind('click').click(function () {
                hangHoaMgrFn.addQuick(function (_ID, _Ten) {
                    $.ajax({
                        url: tuVanFn.urlDefault().toString(),
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
                            tuVanFn.XuatNhapChiTietItemFn(newItem);
                            HangHoa.val('');
                            HangHoa.focus();
                        }
                    });
                });
            });
        });

        common.regPlug(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocompleteLamDichVu(NhanVien, function (event, ui) {
                NhanVien.attr('_value', ui.item.user);
            }, function (ul,item) {
                return $("<li></li>")
                               .data("item.autocomplete", item)
                               .append("<a><b>" + item.level + "</b>&nbsp; " + item.label + "</a>")
                               .appendTo(ul);
            }, _id, function (item) {
                return {
                    label: item.Ten,
                    value: item.Ten,
                    user: item.Username,
                    level: item.Loai,
                    id: item.ID,
                    Email: item.Email
                };
            });
        });
        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        NgayLam.val(dateStr);
        NgayLam.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        
        

    },
    viewDichVu: function (id, fn) {
        tuVanFn.loadHtml(function () {
            var newDlg = $(tuVanFn.EditForm);
            $(newDlg).dialog({
                title: 'Sửa dịch vụ',
                width: 700,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        tuVanFn.saveDichVu({}, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            tuVanFn.clearformDichVu();
                        });
                    },
                    'Lưu và đóng': function () {
                        tuVanFn.saveDichVu({}, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            $(newDlg).dialog('close');
                            tuVanFn.clearformDichVu();
                        });
                    },
                    'Xóa': function () {
                        $(newDlg).dialog('close');
                        tuVanFn.clearformDichVu();
                        $.ajax({
                            url: tuVanFn.urlDefault().toString(),
                            data: { 'subAct': 'delDichVu', 'ID': id },
                            type: 'POST',
                            dataType: 'script',
                            success: function (dt) {
                                $('#' + id).fadeOut('1000');
                                $('#ldv-list-' + id).fadeOut('1000');
                            }
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        tuVanFn.clearformDichVu();
                    }
                },
                beforeClose: function () {
                    tuVanFn.clearformDichVu();
                },
                open: function () {
                    common.styleButton();
                    tuVanFn.clearformDichVu();
                    tuVanFn.popDichVufn();
                    $.ajax({
                        url: tuVanFn.urlDefault().toString(),
                        data: { 'subAct': 'editDichVu', 'ID': id },
                        type: 'POST',
                        dataType: 'script',
                        success: function (_dt) {
                            var dt = eval(_dt);
                            
                            var ID = newDlg.find('.ID');
                            var DV_ID = newDlg.find('.DV_ID');
                            var Gia = newDlg.find('.Gia');
                            var BaoHanh_ID = newDlg.find('.BaoHanh_ID');
                            var SoLan = newDlg.find('.SoLan');
                            var ThanhToan = newDlg.find('.ThanhToan');
                            var ConNo = newDlg.find('.ConNo');
                            var GhiChu = newDlg.find('.GhiChu');
                            var NgayLap = newDlg.find('.NgayLap');
                            var KHO_ID = newDlg.find('.KHO_ID');
                            var CK = newDlg.find('.CK');
                            var NhanVien = newDlg.find('.NhanVien');
                            var LoaiQuy = newDlg.find('.LoaiQuy');

                            ID.val(dt.ID);
                            DV_ID.val(dt._DichVu.Ten);
                            DV_ID.attr('_value', dt.DV_ID);
                            BaoHanh_ID.val(dt.BaoHanh_Ten);
                            BaoHanh_ID.attr('_value', dt.BaoHanh_ID);
                            KHO_ID.val(dt.KHO_Ten);
                            KHO_ID.attr('_value', dt.KHO_ID);
                            SoLan.val(dt.SoLan);
                            Gia.val(dt.Gia);
                            ThanhToan.val(dt.ThanhToan);
                            ConNo.val(dt.ConNo);
                            CK.val(dt.CK);
                            NhanVien.val(dt.NhanVien);
                            LoaiQuy.val(dt.LoaiQuy);
                            GhiChu.val(dt.GhiChu);
                            var value = new Date(dt.NgayLap);
                            NgayLap.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());
                            common.formatTien(Gia);
                            common.formatTien(ThanhToan);
                            common.formatTien(ConNo);
                            common.formatTien(CK);
                        }
                    });
                }
            });
        });
    },
    AddLich: function (_id) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        common.regPlug(typeof (suKienFn), 'appStore.pmSpa.desktop.controls.SuKienMgr.DanhSach, appStore.pmSpa.desktop.controls', function () {
            suKienFn.Add({ KH_ID : _id}, function (dt) {
                var myUi = eval(dt);
                var skList = $('.kh-suKien-list');
                $('#kh-sk-item').tmpl(myUi).prependTo(skList);
            });
        });
    },
    ViewLich: function (obj, _id) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        common.regPlug(typeof (suKienFn), 'appStore.pmSpa.desktop.controls.SuKienMgr.DanhSach, appStore.pmSpa.desktop.controls', function () {
            suKienFn.view(obj, { KH_ID: _id }, function (dt) {
                var myUi = eval(dt);
                var id = $(obj).attr('id');
                var cItem = $('.sk-small-item[id="' + id + '"]');
                var skList = $('.kh-suKien-list');
                var newItem = $('#kh-sk-item').tmpl(myUi).html();
                $(cItem).html(newItem);
            });
        });
    },
    save: function (fn) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        var newDlg = $(tuVanFn.KhachHangForm);
        var KH_Ma = newDlg.find('.KH_Ma');
        var So = newDlg.find('.So');
        var KH_Ten = newDlg.find('.KH_Ten');
        var KH_GioiTinh = newDlg.find('[name=KH_GioiTinh]:checked');
        var KH_NgaySinh = newDlg.find('.KH_NgaySinh');
        var KH_DiaChi = newDlg.find('.KH_DiaChi');
        var KH_KhuVuc_ID = newDlg.find('.KH_KhuVuc_ID');
        var KH_Phone = newDlg.find('.KH_Phone');
        var KH_Mobile = newDlg.find('.KH_Mobile');
        var KH_Ym = newDlg.find('.KH_Ym');
        var KH_CMND = newDlg.find('.KH_CMND');
        var KH_Email = newDlg.find('.KH_Email');
        var KH_NguonGoc_ID = newDlg.find('.KH_NguonGoc_ID');
        var Anh = newDlg.find('.Anh');
        
        var _KH_Ma = KH_Ma.val();
        var _So = So.val();
        var _KH_Ten = KH_Ten.val();
        var _KH_GioiTinh = KH_GioiTinh.attr('cValue');
        var _KH_NgaySinh = KH_NgaySinh.val();
        var _KH_DiaChi = KH_DiaChi.val();
        var _KH_KhuVuc_ID = KH_KhuVuc_ID.attr('_value');
        var _KH_Phone = KH_Phone.val();
        var _KH_Mobile = KH_Mobile.val();
        var _KH_Ym = KH_Ym.val();
        var _KH_CMND = KH_CMND.val();
        var _KH_Email = KH_Email.val();
        var _KH_NguonGoc_ID = KH_NguonGoc_ID.attr('_value');
        var _Anh = $(Anh).attr('ref');
        
        var _ID = newDlg.attr('_id');

        var err = '';
        if (_KH_Ma == '') { err = 'Nhập mã<br/>'; }
        if (err != '') {
            common.fbMsg('Lỗi', 'Bạn cần hoàn thành các lỗi sau <hr/>' + err, 200, 'msg-dangKy-pop', function () {
                setTimeout(function () {
                    $(document).trigger('close.facebox', 'msg-dangKy-pop');
                }, 10000);
            });
            return false;
        }
        $.ajax({
            url: tuVanFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: {
                'subAct': 'save',
                ID: _ID,
                So: _So,
                KH_Ma: _KH_Ma,
                KH_Ten: _KH_Ten,
                KH_GioiTinh: _KH_GioiTinh,
                KH_NgaySinh: _KH_NgaySinh,
                KH_DiaChi: _KH_DiaChi,
                KH_KhuVuc_ID: _KH_KhuVuc_ID,
                KH_Phone: _KH_Phone,
                KH_Mobile: _KH_Mobile,
                KH_Ym: _KH_Ym,
                KH_CMND: _KH_CMND,
                KH_Email: _KH_Email,
                KH_NguonGoc_ID: _KH_NguonGoc_ID,
                Anh: _Anh
            },
            success: function (dt) {
                fn(dt);
                var data = eval(dt);
                document.location.href = domain + '/Khach-hang/' + data.ID + '.html';
            }
        });

    },
    popfn: function () {
        var newDlg = $(tuVanFn.KhachHangForm);
        var Ngay = newDlg.find('.Ngay');
        var KH_NgaySinh = newDlg.find('.KH_NgaySinh');
        var KH_KhuVuc_ID = newDlg.find('.KH_KhuVuc_ID');
        var KH_NguonGoc_ID = newDlg.find('.KH_NguonGoc_ID');
        
        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        var dateNgaySinhStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear() - 20);

        Ngay.val(dateStr);
        KH_NgaySinh.val(dateNgaySinhStr);
        Ngay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        KH_NgaySinh.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        
        common.styleButton();
        var ulpFn = function () {
            var imgAnh = $('.previewImg', newDlg);
            var Anh = $('.Anh', newDlg);
            var _params = { 'oldFile': $(Anh).attr('ref') };
            common.upload(Anh, 'anh', _params, function (rs) {
                $(Anh).attr('ref', rs)
                imgAnh.attr('src', domain + '/lib/up/i/' + common.imgSize(rs,'full') + '?ref=' + Math.random());
            }, function (f) {
            });
        };
        ulpFn();
        common.regPlug(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'KHUVUC', KH_KhuVuc_ID, function (event, ui) {
                KH_KhuVuc_ID.attr('_value', ui.item.id);
            });
            danhmuc.autoCompleteLangBased('', 'NGUON-KH', KH_NguonGoc_ID, function (event, ui) {
                KH_NguonGoc_ID.attr('_value', ui.item.id);
            });
           
            KH_KhuVuc_ID.unbind('click').click(function () {
                KH_KhuVuc_ID.autocomplete('search', '');
            });
            KH_NguonGoc_ID.unbind('click').click(function () {
                KH_NguonGoc_ID.autocomplete('search', '');
            });


        });
    },
    popDichVufn: function () {
        var newDlg = $(tuVanFn.EditForm);
        var ID = newDlg.find('.ID');
        var DV_ID = newDlg.find('.DV_ID');
        var Gia = newDlg.find('.Gia');
        var BaoHanh_ID = newDlg.find('.BaoHanh_ID');
        var SoLan = newDlg.find('.SoLan');
        var ThanhToan = newDlg.find('.ThanhToan');
        var ConNo = newDlg.find('.ConNo');
        var GhiChu = newDlg.find('.GhiChu');
        var NgayLap = newDlg.find('.NgayLap');
        var KHO_ID = newDlg.find('.KHO_ID');
        var CK = newDlg.find('.CK');
        var NhanVien = newDlg.find('.NhanVien');
        var LoaiQuy = newDlg.find('.LoaiQuy');
        
        ThanhToan.keyup(function() {
            var gia = parseInt(adm.VndToNumber(Gia)) - parseInt(adm.VndToNumber(CK));
            var thanhToan = parseInt(adm.VndToNumber(ThanhToan));
            var conNo = parseInt(gia) - parseInt(thanhToan);
            ConNo.val(conNo);
            common.formatTien(ConNo);
        });

        Gia.keyup(function () {
            var gia = parseInt(adm.VndToNumber(Gia)) - parseInt(adm.VndToNumber(CK));
            var thanhToan = parseInt(adm.VndToNumber(ThanhToan));
            var conNo = parseInt(gia) - parseInt(thanhToan);
            ConNo.val(conNo);
            common.formatTien(ConNo);
        });


        CK.keyup(function () {
            var gia = parseInt(adm.VndToNumber(Gia)) - parseInt(adm.VndToNumber(CK));
            var thanhToan = parseInt(adm.VndToNumber(ThanhToan));
            var conNo = parseInt(gia) - parseInt(thanhToan);
            ConNo.val(conNo);
            common.formatTien(ConNo);
        });

        common.regPlug(typeof (KhoHangMgrFn), 'appStore.pmSpa.khoHangMgr.Class1, appStore.pmSpa.khoHangMgr', function () {
            KhoHangMgrFn.autoComplete(KHO_ID, function (event, ui) {
                KHO_ID.attr('_value', ui.item.id);
            });
        });

        common.regPlug(typeof (danhMucDichVuMgr), 'appStore.pmSpa.danhMucDichVuMgr.Class1, appStore.pmSpa.danhMucDichVuMgr', function () {
            danhMucDichVuMgr.autoCompleteByQ(DV_ID, function (event, ui) {
                DV_ID.attr('_value', ui.item.id);
                var gia = Gia.val();
                if(gia=='') {
                    Gia.val(ui.item.gia);
                    var gia = parseInt(adm.VndToNumber(Gia));
                    var thanhToan = parseInt(adm.VndToNumber(ThanhToan));
                    var conNo = gia - thanhToan;
                    ConNo.val(conNo);
                    common.formatTien(ConNo);
                    common.formatTien(Gia);
                }
            },function (ul, item) {
                return $("<li></li>")
                                .data("item.autocomplete", item)
                                .append("<a><b>" + item.ma + '</b> ' + item.label + ' [' + item.gia + ']<br/>' + item.SoLan + ' lần, ' + item.ThoiGian + ' phút/ lần</a>')
                                .appendTo(ul);
            });
            DV_ID.unbind('click').click(function () {
                DV_ID.autocomplete('search', '');
            });
        });
        
        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        NgayLap.val(dateStr);
        NgayLap.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });

        common.regPlug(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(NhanVien, function (event, ui) {
                NhanVien.val(ui.item.value);
            });
        });

        common.regPlug(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'NHOM-BH', BaoHanh_ID, function (event, ui) {
                BaoHanh_ID.attr('_value', ui.item.id);
            }, function (ul,item) {
                return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
            });
            BaoHanh_ID.unbind('click').click(function () {
                BaoHanh_ID.autocomplete('search', '');
            });
        });
        
        common.formatTien(Gia);
        common.formatTien(ThanhToan);
        common.formatTien(ConNo);
        common.formatTien(CK);
    },
    saveDichVu: function (obj, fn) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        var newDlg = $(tuVanFn.EditForm);
        var ID = newDlg.find('.ID');
        var DV_ID = newDlg.find('.DV_ID');
        var Gia = newDlg.find('.Gia');
        var BaoHanh_ID = newDlg.find('.BaoHanh_ID');
        var SoLan = newDlg.find('.SoLan');
        var ThanhToan = newDlg.find('.ThanhToan');
        var ConNo = newDlg.find('.ConNo');
        var GhiChu = newDlg.find('.GhiChu');
        var NgayLap = newDlg.find('.NgayLap');
        var KHO_ID = newDlg.find('.KHO_ID');
        var CK = newDlg.find('.CK');
        var NhanVien = newDlg.find('.NhanVien');
        var LoaiQuy = newDlg.find('.LoaiQuy');
        
        var _ID = ID.val();
        var _Gia = adm.VndToNumber(Gia);
        var _ThanhToan = adm.VndToNumber(ThanhToan);
        var _ConNo = adm.VndToNumber(ConNo);
        var _CK = adm.VndToNumber(CK);
        var _DV_ID = DV_ID.attr('_value');
        var _SoLan = SoLan.val();
        var _GhiChu = GhiChu.val();
        var _NgayLap = NgayLap.val();
        var _NhanVien = NhanVien.val();
        var _LoaiQuy = LoaiQuy.val();
        var _BaoHanh_ID = BaoHanh_ID.attr('_value');
        var _KHO_ID = KHO_ID.attr('_value');
        
        var err = '';
        if (_DV_ID == '') { err = 'Chọn dịch vụ<br/>'; }
        if (_Gia == '') { err = 'Nhập giá<br/>'; }
        if (_KHO_ID == '') { err = 'Chọn cơ sở<br/>'; }
        if (err != '') {
            common.fbMsg('Lỗi', 'Bạn cần hoàn thành các lỗi sau <hr/>' + err, 200, 'msg-dangKy-pop', function () {
                setTimeout(function () {
                    $(document).trigger('close.facebox', 'msg-dangKy-pop');
                }, 10000);
            });
            return false;
        }
        var datas = {
            'subAct': 'saveTuVanDichVu',
            ID: _ID,
            Gia: _Gia,
            DV_ID: _DV_ID,
            ThanhToan: _ThanhToan,
            ConNo: _ConNo,
            SoLan: _SoLan,
            GhiChu: _GhiChu,
            NgayLap: _NgayLap,
            BaoHanh_ID: _BaoHanh_ID,
            KHO_ID: _KHO_ID,
            NhanVien: _NhanVien,
            LoaiQuy: _LoaiQuy,
            CK : _CK
        };
        $.extend(datas, obj);
        $.ajax({
            url: tuVanFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: datas,
            success: function (dt) {
                fn(dt);
            }
        });

    },
    clearform: function () {
        var newDlg = $(tuVanFn.EditForm);
        var KH_Ma = newDlg.find('.KH_Ma');
        var MaDv = newDlg.find('.MaDv');
        var So = newDlg.find('.So');
        var NgayT = newDlg.find('.Ngay');
        var KH_Ten = newDlg.find('.KH_Ten');
        var KH_GioiTinh = newDlg.find('.KH_GioiTinh');
        var KH_NgaySinh = newDlg.find('.KH_NgaySinh');
        var KH_DiaChi = newDlg.find('.KH_DiaChi');
        var KH_KhuVuc_ID = newDlg.find('.KH_KhuVuc_ID');
        var KH_Phone = newDlg.find('.KH_Phone');
        var KH_Mobile = newDlg.find('.KH_Mobile');
        var KH_Ym = newDlg.find('.KH_Ym');
        var KH_CMND = newDlg.find('.KH_CMND');
        var KH_Email = newDlg.find('.KH_Email');
        var KH_NguonGoc_ID = newDlg.find('.KH_NguonGoc_ID');
        newDlg.attr('_id', '');
        newDlg.find('input, textarea').val('');
        newDlg.find('input, textarea').attr('_value', '');

    },
    clearformDichVu: function () {
        var newDlg = $(tuVanFn.EditForm);
        newDlg.attr('_id', '');
        newDlg.find('input, textarea').val('');
        newDlg.find('input, textarea').attr('_value', '');

    },
    draff: function (fn, _id) {
        var newDlg = $(tuVanFn.LamDichVuForm);
        $.ajax({
            url: tuVanFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: {
                'subAct': 'draff',
                'TVDV_ID' : _id
            },
            success: function (_dt) {
                var dt1 = eval(_dt);
                var XN_ID = newDlg.find('.XN_ID');
                XN_ID.val(dt1.ID);
                XN_ID.attr('draff', '1');
                var DanhSachXuatNhapChiTiet = $('.DanhSachTieuHaoChiTiet', newDlg);
                var DanhSachXuatNhapChiTietFooter = DanhSachXuatNhapChiTiet.find('.ds-footer');
                $.each(dt1.XNCT, function (i, item) {
                    var newItem = $('#xnct-hh-item-1').tmpl(item).insertBefore(DanhSachXuatNhapChiTietFooter);
                    newItem.hide();
                    newItem.fadeIn('slideDown');
                    tuVanFn.XuatNhapChiTietItemFn(newItem);
                    tuVanFn.updateXNCTItem(newItem);
                });
                fn(dt1);
            }
        });
    },
    draffTuVan: function (fn) {
        var newDlg = $(tuVanFn.EditForm);
        $.ajax({
            url: tuVanFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: {
                'subAct': 'draffTuVan'
            },
            success: function (dt) {
                var item = eval(dt);
                newDlg.attr('_id', item.ID);
                newDlg.find('.So').val(item.So);
                fn(dt);
            }
        });
    },
    timKhachHangPopup: function () {
        tuVanFn.loadHtml(function () {
            var newDlg = $(tuVanFn.TimKiemForm);
            $(newDlg).dialog({
                title: 'Tìm kiếm',
                width: 500,
                modal: true,
                create: function (/*e, ui*/) {
                    var $dlgELem = $(this);
                    $dlgELem.dialog('widget').find('.ui-dialog-titlebar').remove();
                },
                buttons: {
                    'Thêm mới': function () {
                        tuVanFn.Show();
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                beforeClose: function () {
                },
                open: function () {
                    common.styleButton();
                    tuVanFn.timKhachHangPopupFn();
                }
            });
        });
    },
    timKhachHangPopupFn: function () {
        var newDlg = $(tuVanFn.TimKiemForm);
        var Ten = newDlg.find('.Ten');
        var msg = newDlg.find('.khachhang-view-pnl');
        common.regPlug(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
            DanhSachKhachHangFn.autoCompleteSearch(Ten, function (event, ui) {
                //msg.html(ui.item.label + '<br/>' + ui.item.Mobile);
                msg.html('');
                var myUi = ui.item;
                $('#khachHangChiTiet').tmpl(myUi).appendTo(msg);
                common.styleButton();
                newDlg.find('.reSearchBtn').click(function () {
                    msg.html('');
                    Ten.val('');
                });
            }, function (ul, item) {
                return $("<li></li>")
                    .data("item.autocomplete", item)
                    .append("<a href=\"javascript:;\"><b>" + item.label + "</b> " + item.Phone + " " + item.Mobile + "<br/> " + item.Email + ", " + item.KhuVuc_Ten + "</a>")
                    .appendTo(ul);
            });
        });
    },
    loadHtml: function (fn) {
        var dlg = $(tuVanFn.EditForm);
        if ($(dlg).length < 1) {
            common.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.desktop.controls.TuVanView.html.htm")%>',
                success: function (dt) {
                    common.loading(null);
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
$(function () {
    adm.regJPlugin(jQuery().formatCurrency, domain + '/lib/js/jquery.formatCurrency-1.4.0.min.js', function () {
    });
    adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
        
    });
})