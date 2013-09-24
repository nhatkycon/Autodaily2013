var dangKyFn = {
    urlDefault: function () { return domain + '/lib/admin/Default.aspx?&act=loadPlug&rqPlug=appStore.pmSpa.desktop.controls.KHang.DangKy, appStore.pmSpa.desktop.controls'; },
    EditForm: '#DeskTopTuVanMdl-newDlg',
    KhachHangForm: '#DeskTopKhachHangMdl-newDlg',
    TimKiemForm: '#DeskTopTimKiemKhachHangMdl-newDlg',
    Show: function () {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        dangKyFn.loadHtml(function () {
            var newDlg = $(dangKyFn.KhachHangForm);
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1010,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        dangKyFn.save(function () {
                            dangKyFn.clearform();
                            dangKyFn.draff(function (_item) { });
                        });
                    },
                    'Lưu và đóng': function () {
                        dangKyFn.save(false, function () {
                            $(newDlg).dialog('close');
                            dangKyFn.draff(function (_item) { });
                        });
                    },
                    'In': function () {
                        $(newDlg).dialog('close');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        dangKyFn.clearform();
                    }
                },
                beforeClose: function () {
                    dangKyFn.clearform();
                },
                open: function () {
                    common.styleButton();
                    dangKyFn.clearform();
                    dangKyFn.popfn();
                    dangKyFn.draff(function (_item) { });
                }
            });
        });
    },
    ShowTuVan:function (_id) {
        var obj = { KH_ID: _id };
        dangKyFn.AddTuVan(obj, function (dt) {
            var myUi = eval(dt);
            var skList = $('.kh-tuVan-list');
            $('#kh-tv-item').tmpl(myUi).prependTo(skList);
        });
    },
    AlbumViewFs: function(_id) {
        $.ajax({
            url: dangKyFn.urlDefault().toString(),
            type: 'POST',            
            data: {
                'subAct': 'getAlbum',
                ID: _id,
            },
            success: function (dt) {
                var fsBody = $('.dv-fs-body').find('ul');
                fsBody.html(dt);
                $('.dv-fs-box').show();
                $('.dv-fs-closeBtn').unbind('click').click(function () {
                    $('.dv-fs-box').hide();
                    fsBody.html('');
                });
                dichVuFsSlide = new Swipe(document.getElementById('dv-fs-body'));
            }
        });
    },
    AddTuVan: function (obj, fn) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        dangKyFn.loadHtml(function () {
            var newDlg = $(dangKyFn.EditForm);
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1010,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        dangKyFn.saveTuVan(obj, function (dt) {
                            if(typeof (fn) =="function") {
                                fn(dt);
                            }
                            dangKyFn.clearformTuVan();
                            dangKyFn.draffTuVan(function (_item) { });
                        });
                    },
                    'Lưu và đóng': function () {
                        dangKyFn.saveTuVan(obj, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            $(newDlg).dialog('close');
                            dangKyFn.clearformTuVan();
                            dangKyFn.draffTuVan(function (_item) { });
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        dangKyFn.clearformTuVan();
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
                    dangKyFn.clearformTuVan();
                },
                open: function () {
                    common.styleButton();
                    dangKyFn.clearformTuVan();
                    dangKyFn.popTuVanfn();
                    dangKyFn.draffTuVan(function (_item) { });
                }
            });
        });
    },
    ViewTuVanProxy: function (id) {
        dangKyFn.ViewTuVan(id, function(dt) {

        });
    },
    ViewTuVan: function (id, fn) {
        dangKyFn.loadHtml(function () {
            var newDlg = $(dangKyFn.EditForm);
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1010,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        dangKyFn.saveTuVan({}, function (dt) {
                            if (typeof (fn) == "function") {
                                fn(dt);
                            }
                            $(newDlg).dialog('close');
                            dangKyFn.clearformTuVan();
                            dangKyFn.draffTuVan(function (_item) { });
                        });
                    },
                    'Xóa': function () {
                        $.ajax({
                            url: dangKyFn.urlDefault().toString(),
                            data: { 'subAct': 'delTuVan', 'ID': id },
                            type: 'POST',
                            dataType: 'script',
                            success: function (dt) {
                                $('#' + id).fadeOut('1000');
                            }
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        dangKyFn.clearformTuVan();
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
                    dangKyFn.clearformTuVan();
                },
                open: function () {
                    common.styleButton();
                    dangKyFn.clearformTuVan();
                    dangKyFn.popTuVanfn();
                    
                    $.ajax({
                        url: dangKyFn.urlDefault().toString(),
                        data: { 'subAct': 'editTuVan', 'ID': id },
                        type: 'POST',
                        dataType: 'script',
                        success: function (_dt) {
                            var dt = eval(_dt);
                            var So = newDlg.find('.So');
                            var Ngay = newDlg.find('.Ngay');
                            var TuVanVien = newDlg.find('.TuVanVien');
                            var TinhTrangSucKhoe = newDlg.find('.TinhTrangSucKhoe');
                            var TinhTrangLanDa = newDlg.find('.TinhTrangLanDa');
                            var YKienKhachHang = newDlg.find('.YKienKhachHang');
                            var DichVuDieuTriKhac = newDlg.find('.DichVuDieuTriKhac');
                            var DV_Chon = newDlg.find('.DV_Chon');
                            var DV_DanhSach = newDlg.find('.DV_DanhSach');

                            So.val(dt.So);
                            var value = new Date(dt.Ngay);
                            Ngay.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());
                            TuVanVien.val(dt.TuVanVien_Ten);
                            TuVanVien.attr('_value',dt.TuVanVien);
                            TinhTrangSucKhoe.val(dt.TinhTrangSucKhoe);
                            TinhTrangLanDa.val(dt.TinhTrangLanDa);
                            YKienKhachHang.val(dt.YKienKhachHang);
                            DichVuDieuTriKhac.val(dt.DichVuDieuTriKhac);
                            DV_DanhSach.html($('#tt-item-view').tmpl(dt._TuVanTinhTrang));
                            
                            DV_DanhSach.find('.tt-item-xoaBtn').unbind('click').click(function () {
                                var _item = $(this);
                                var _pitem = _item.parent().parent().parent();
                                $.ajax({
                                    url: dangKyFn.urlDefault().toString(),
                                    type: 'POST',
                                    dataType: 'script',
                                    data: {
                                        'subAct': 'delTinhTrang',
                                        'ID': newDlg.attr('_id'),
                                        'TT_ID': _item.attr('id')
                                    },
                                    success: function (dt) {
                                        _pitem.fadeOut(1000);
                                        setTimeout(function () {
                                            _pitem.remove();
                                        }, 1000);
                                    }
                                });
                            });
                        }
                    });
                }
            });
        });
    },
    AddAlbum: function (_id) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        common.regPlug(typeof (AlbumMgrFn), 'appStore.pmSpa.desktop.controls.AlbumMgr.DanhSach, appStore.pmSpa.desktop.controls', function () {
            AlbumMgrFn.Add(function (dt) {
                var myUi = eval(dt);
                var skList = $('.kh-album-list');
                $('#kh-album-item').tmpl(myUi).prependTo(skList);
                return false;
            }, { P_RowId: _id });
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
    createReport: function (id) {
        //var request = dangKyFn.urlDefault().toString() + '&subAct=reports&ID=' + id;
        //request = request.replace('loadPlug', 'loadPlugDirect');
        //adm.loadIfr(request
        //, function () {
        //    adm.loading('Đang tạo báo cáo');
        //}
        //, function () {
        //    adm.loading(null);
        //});
        common.fbMsg('In', 'Bạn click <hr/>' + err, 200, 'msg-dangKy-pop', function () {
            setTimeout(function () {
                $(document).trigger('close.facebox', 'msg-dangKy-pop');
            }, 10000);
        });
    },
    save: function (fn) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        var newDlg = $(dangKyFn.KhachHangForm);
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
        var KH_NguoiGioiThieu = newDlg.find('.KH_NguoiGioiThieu');
        var LinhVuc_ID = newDlg.find('.LinhVuc_ID');
        var TuVanVien = newDlg.find('.TuVanVien');
        
        var _KH_Ma = KH_Ma.val();
        var _So = So.val();
        var _KH_Ten = KH_Ten.val();
        var _KH_GioiTinh = KH_GioiTinh.attr('cValue');
        var _KH_NgaySinh = KH_NgaySinh.val();
        var _KH_DiaChi = KH_DiaChi.val();
        var _KH_KhuVuc_ID = KH_KhuVuc_ID.attr('_value');
        var _LinhVuc_ID = LinhVuc_ID.attr('_value');
        var _TuVanVien = TuVanVien.attr('_value');
        var _KH_Phone = KH_Phone.val();
        var _KH_Mobile = KH_Mobile.val();
        var _KH_Ym = KH_Ym.val();
        var _KH_CMND = KH_CMND.val();
        var _KH_Email = KH_Email.val();
        var _KH_NguonGoc_ID = KH_NguonGoc_ID.attr('_value');
        var _KH_NguoiGioiThieu = KH_NguoiGioiThieu.attr('_value');
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
            url: dangKyFn.urlDefault().toString(),
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
                Anh: _Anh,
                KH_NguoiGioiThieu: _KH_NguoiGioiThieu,
                TuVanVien: _TuVanVien,
                LinhVuc_ID: _LinhVuc_ID
            },
            success: function (dt) {
                fn(dt);
                var data = eval(dt);
                document.location.href = domain + '/Khach-hang/' + data.ID + '.html';
            }
        });

    },
    popfn: function () {
        var newDlg = $(dangKyFn.KhachHangForm);
        var Ngay = newDlg.find('.Ngay');
        var KH_NgaySinh = newDlg.find('.KH_NgaySinh');
        var KH_KhuVuc_ID = newDlg.find('.KH_KhuVuc_ID');
        var KH_NguonGoc_ID = newDlg.find('.KH_NguonGoc_ID');
        var KH_NguoiGioiThieu = newDlg.find('.KH_NguoiGioiThieu');
        var LinhVuc_ID = newDlg.find('.LinhVuc_ID');
        var TuVanVien = newDlg.find('.TuVanVien');
        
        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        var dateNgaySinhStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear() - 20);

        common.regPlug(typeof (DanhSachKhachHangFn), 'appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr', function () {
            DanhSachKhachHangFn.autoCompleteSearch(KH_NguoiGioiThieu, function (event, ui) {
                KH_NguoiGioiThieu.attr('_value', ui.item.id);
            });
        });
       
        common.regPlug(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(TuVanVien, function (event, ui) {
                TuVanVien.val(ui.item.label);
                TuVanVien.attr('_value', ui.item.value);
            });
        });


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
            danhmuc.autoCompleteLangBased('', 'LINHVUC-KH', LinhVuc_ID, function (event, ui) {
                LinhVuc_ID.attr('_value', ui.item.id);
            });
            KH_KhuVuc_ID.unbind('click').click(function () {
                KH_KhuVuc_ID.autocomplete('search', '');
            });
            KH_NguonGoc_ID.unbind('click').click(function () {
                KH_NguonGoc_ID.autocomplete('search', '');
            });
            LinhVuc_ID.unbind('click').click(function () {
                LinhVuc_ID.autocomplete('search', '');
            });
        });
    },
    popTuVanfn: function () {
        var newDlg = $(dangKyFn.EditForm);
        var So = newDlg.find('.So');
        var Ngay = newDlg.find('.Ngay');
        var TuVanVien = newDlg.find('.TuVanVien');
        var TinhTrangSucKhoe = newDlg.find('.TinhTrangSucKhoe');
        var TinhTrangLanDa = newDlg.find('.TinhTrangLanDa');
        var YKienKhachHang = newDlg.find('.YKienKhachHang');
        var HH_DanhSach = newDlg.find('.HH_DanhSach');
        var DichVuDieuTriKhac = newDlg.find('.DichVuDieuTriKhac');
        var DV_Chon = newDlg.find('.DV_Chon');
        var DV_DanhSach = newDlg.find('.DV_DanhSach');
        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        Ngay.val(dateStr);
        Ngay.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });
        common.regPlug(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(TuVanVien, function (event, ui) {
                TuVanVien.attr('_value', ui.item.value);
            });
        });
        common.regPlug(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TINH-TRANG', DV_Chon, function (event, ui) {
                $.ajax({
                    url: dangKyFn.urlDefault().toString(),
                    type: 'POST',
                    dataType: 'script',
                    data: {
                        'subAct': 'addTinhTrang',
                        'ID': newDlg.attr('_id'),
                        'TT_ID': ui.item.id
                    },
                    success: function (dt) {
                        var myUi = eval(dt);
                        var currentTt = DV_DanhSach.find('.' + myUi.id);
                        if ($(currentTt).length > 0) {
                        }
                        else {
                            $('#tt-item-view').tmpl(myUi).appendTo(DV_DanhSach);
                            currentTt = DV_DanhSach.find('.' + myUi.id);
                        }
                        currentTt.find('.tt-item-xoaBtn').unbind('click').click(function () {
                            $.ajax({
                                url: dangKyFn.urlDefault().toString(),
                                type: 'POST',
                                dataType: 'script',
                                data: {
                                    'subAct': 'delTinhTrang',
                                    'ID': newDlg.attr('_id'),
                                    'TT_ID': currentTt.attr('id')
                                },
                                success: function (dt) {
                                    currentTt.fadeOut(1000);
                                    setTimeout(function () {
                                        currentTt.remove();
                                    }, 1000);
                                }
                            });
                        });
                    }
                });                
            });
        });
    },
    saveTuVan: function (obj, fn) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        var newDlg = $(dangKyFn.EditForm);
        var So = newDlg.find('.So');
        var Ngay = newDlg.find('.Ngay');
        var TuVanVien = newDlg.find('.TuVanVien');
        var TinhTrangSucKhoe = newDlg.find('.TinhTrangSucKhoe');
        var TinhTrangLanDa = newDlg.find('.TinhTrangLanDa');
        var YKienKhachHang = newDlg.find('.YKienKhachHang');
        var DichVuDieuTriKhac = newDlg.find('.DichVuDieuTriKhac');


        var _So = So.val();
        var _Ngay = Ngay.val();
        var _TuVanVien = TuVanVien.attr('_value');
        var _TinhTrangSucKhoe = TinhTrangSucKhoe.val();
        var _TinhTrangLanDa = TinhTrangLanDa.val();
        var _YKienKhachHang = YKienKhachHang.val();
        var _DichVuDieuTriKhac = DichVuDieuTriKhac.val();
        var _ID = newDlg.attr('_id');

        var err = '';
        if (_So == '') { err = 'Nhập số<br/>'; }
        if (_TuVanVien == '') { err = 'Chọn tư vấn viên<br/>'; }
        if (err != '') {
            common.fbMsg('Lỗi', 'Bạn cần hoàn thành các lỗi sau <hr/>' + err, 200, 'msg-dangKy-pop', function () {
                setTimeout(function () {
                    $(document).trigger('close.facebox', 'msg-dangKy-pop');
                }, 10000);
            });
            return false;
        }
        var datas = {
            'subAct': 'saveTuVan',
            ID: _ID,
            So: _So,
            Ngay: _Ngay,
            TuVanVien: _TuVanVien,
            TinhTrangSucKhoe: _TinhTrangSucKhoe,
            TinhTrangLanDa: _TinhTrangLanDa,
            YKienKhachHang: _YKienKhachHang,
            DichVuDieuTriKhac: _DichVuDieuTriKhac
        };
        $.extend(datas, obj);
        $.ajax({
            url: dangKyFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: datas,
            success: function (dt) {
                fn(dt);
            }
        });

    },
    clearform: function () {
        var newDlg = $(dangKyFn.EditForm);
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
    clearformTuVan: function () {
        var newDlg = $(dangKyFn.EditForm);
        var So = newDlg.find('.So');
        var Ngay = newDlg.find('.Ngay');
        var TuVanVien = newDlg.find('.TuVanVien');
        var TinhTrangSucKhoe = newDlg.find('.TinhTrangSucKhoe');
        var TinhTrangLanDa = newDlg.find('.TinhTrangLanDa');
        var YKienKhachHang = newDlg.find('.YKienKhachHang');
        var DV_Chon = newDlg.find('.DV_Chon');
        var DichVuDieuTriKhac = newDlg.find('.DichVuDieuTriKhac');
        var DV_Chon = newDlg.find('.DV_Chon');
        var DV_DanhSach = newDlg.find('.DV_DanhSach');
        
        newDlg.attr('_id', '');
        newDlg.find('input, textarea').val('');
        newDlg.find('input, textarea').attr('_value', '');
        DV_DanhSach.html('');
    },
    draff: function (fn) {
        var newDlg = $(dangKyFn.KhachHangForm);
        $.ajax({
            url: dangKyFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: {
                'subAct': 'draff'
            },
            success: function (dt) {
                var item = eval(dt);
                newDlg.attr('_id', item.ID);
                newDlg.find('.KH_Ma').val(item.Ma);
                fn(dt);
            }
        });
    },
    draffTuVan: function (fn) {
        var newDlg = $(dangKyFn.EditForm);
        $.ajax({
            url: dangKyFn.urlDefault().toString(),
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
        dangKyFn.loadHtml(function () {
            var newDlg = $(dangKyFn.TimKiemForm);
            $(newDlg).dialog({
                title: 'Tìm kiếm',
                width: 700,
                modal: true,
                create: function (/*e, ui*/) {
                    var $dlgELem = $(this);
                    $dlgELem.dialog('widget').find('.ui-dialog-titlebar').remove();
                },
                buttons: {
                    'Thêm mới': function () {
                        dangKyFn.Show();
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                position: {
                    my: "center top", at: "center top"
                },
                beforeClose: function () {
                },
                open: function () {
                    common.styleButton();
                    dangKyFn.timKhachHangPopupFn();
                }
            });
        });
    },
    timKhachHangPopupFn: function () {
        var newDlg = $(dangKyFn.TimKiemForm);
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
                Ten.blur();                
            }, function (ul, item) {
                return $("<li></li>")
                    .data("item.autocomplete", item)
                    .append("<a href=\"javascript:;\"><b>" + item.ma + ":" + item.label + "</b> " + item.Phone + " " + item.Mobile + "<br/> " + item.Email + ", " + item.KhuVuc_Ten + "</a>")
                    .appendTo(ul);
            });
        });
    },
    loadHtml: function (fn) {
        var dlg = $(dangKyFn.EditForm);
        if ($(dlg).length < 1) {
            common.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.desktop.controls.KHang.TuVan.htm")%>',
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

function formatAnh(anh) {
    return common.imgSize(anh, '240x180');
}