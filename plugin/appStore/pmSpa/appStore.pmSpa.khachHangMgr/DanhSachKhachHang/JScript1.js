var DanhSachKhachHangFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.khachHangMgr.DanhSachKhachHang.Class1, appStore.pmSpa.khachHangMgr'; },
    EditForm: '#DanhSachKhachHangMdl-dlgNew',
    setup: function () { },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu');

        var filterKhachHangByNguonGoc = $('.filterKhachHangByNguonGoc');
        var filterKhachHangByKhuVuc = $('.filterKhachHangByKhuVuc');
        var q = $('.mdl-head-search-DanhSachKhachHangMdl');
        adm.watermark(filterKhachHangByKhuVuc, 'Gõ khu vực', function () {
            DanhSachKhachHangFn.search();
        });

        adm.watermark(filterKhachHangByNguonGoc, 'Gõ nguồn gốc', function () {
            DanhSachKhachHangFn.search();
        });

        adm.watermark(q, 'Tìm kiếm', function () {
            DanhSachKhachHangFn.search();
        });

        $('#DanhSachKhachHangMdl-List').jqGrid({
            url: DanhSachKhachHangFn.urlDefault().toString() + '&subAct=get&Lang=' + Lang,
            height: '1000',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mã', 'Tên', 'Mobile', 'Email', 'Giới tính', 'Ym', 'Ngày sinh', 'Khu vực', 'Nguồn gốc', 'Lịch sử'],
            colModel: [
                { name: 'ID', key: true, width: 1, sortable: true, hidden: true },
                { name: 'Ma', width: 10, sortable: true },
                { name: 'Ten', width: 20, sortable: true },
                { name: 'Mobile', width: 10, sortable: true },
                { name: 'Email', width: 10, sortable: true },
                { name: 'GioiTinh', width: 5, sortable: true },
                { name: 'Ym', width: 5, sortable: true },
                { name: 'NgaySinh', width: 10, sortable: true },
                { name: 'KhuVuc_ID', width: 10, sortable: true },
                { name: 'NguonGoc_ID', width: 10, resizable: true, sortable: true },
                { name: 'NgayCapNhat', width: 10, resizable: true, sortable: true }
            ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'NgayTao',
            sortorder: 'asc',
            pager: jQuery('#DanhSachKhachHangMdl-Pager'),
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
                        DanhSachKhachHangFn.search();
                    });
                    danhmuc.autoCompleteLangBased('', 'NGUON-KH', filterKhachHangByNguonGoc, function (event, ui) {
                        filterKhachHangByNguonGoc.attr('_value', ui.item.id);
                        DanhSachKhachHangFn.search();
                    });
                    filterKhachHangByKhuVuc.unbind('click').click(function () {
                        filterKhachHangByKhuVuc.autocomplete('search', '');
                    });
                    filterKhachHangByNguonGoc.unbind('click').click(function () {
                        filterKhachHangByNguonGoc.autocomplete('search', '');
                    });
                });
                q.keyup(function () {
                    DanhSachKhachHangFn.search();
                });

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
                DanhSachKhachHangFn.loadHtml(function () {
                    var newDlg = $('#DanhSachKhachHangMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                DanhSachKhachHangFn.save(false, function () {
                                    DanhSachKhachHangFn.clearform();
                                    DanhSachKhachHangFn.draff(function () {

                                    });
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
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);


                                    var ID = $('.ID', newDlg);
                                    var Ma = $('.Ma', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var NgaySinh = $('.NgaySinh', newDlg);
                                    var GioiTinh = $('.GioiTinh', newDlg);
                                    var Email = $('.Email', newDlg);
                                    var Mobile = $('.Mobile', newDlg);
                                    var Anh = $('.Anh', newDlg);
                                    var Phone = $('.Phone', newDlg);
                                    var CMND = $('.CMND', newDlg);
                                    var Ym = $('.Ym', newDlg);
                                    var NguonGoc_ID = $('.NguonGoc_ID', newDlg);
                                    var DiaChi = $('.DiaChi', newDlg);
                                    var KhuVuc_ID = $('.KhuVuc_ID', newDlg);
                                    var NgungTheoDoi = $('.NgungTheoDoi', newDlg);
                                    var NguoiGioiThieu = $('.NguoiGioiThieu', newDlg);
                                    var LinhVuc_ID = $('.LinhVuc_ID', newDlg);
                                    var TuVanVien = $('.TuVanVien', newDlg);
                                    
                                    var spbMsg = $('.admMsg', newDlg);

                                    var imgAnh = $('.adm-upload-preview-img', newDlg);
                                    var Anh = $('.Anh', newDlg);

                                    imgAnh.attr('src', '');
                                    Anh.attr('ref', '');

                                    Anh.attr('ref', dt.Anh);
                                    imgAnh.attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());

                                    ID.val(dt.ID);
                                    Ma.val(dt.Ma);
                                    Ten.val(dt.Ten);
                                    var value = new Date(dt.NgaySinh);
                                    if (NgaySinh.getFullYear() != 100) {
                                        NgaySinh.val(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());
                                    }
                                    
                                    if (dt.GioiTinh) {
                                        GioiTinh.attr('checked', 'checked');
                                    }
                                    else {
                                        GioiTinh.removeAttr('checked');
                                    }
                                    Email.val(dt.Email);
                                    Mobile.val(dt.Mobile);
                                    Phone.val(dt.Phone);
                                    CMND.val(dt.CMND);
                                    Ym.val(dt.Ym);
                                    NguonGoc_ID.val(dt.NguonGoc_Ten);
                                    NguonGoc_ID.attr('_value', dt.NguonGoc_ID);
                                    
                                    LinhVuc_ID.val(dt.LinhVuc_Ten);
                                    LinhVuc_ID.attr('_value', dt.LinhVuc_ID);
                                    TuVanVien.val(dt.TuVanVien_Ten);
                                    TuVanVien.attr('_value', dt.TuVanVien);
                                    
                                    DiaChi.val(dt.DiaChi);
                                    KhuVuc_ID.val(dt.KhuVuc_Ten);
                                    KhuVuc_ID.attr('_value', dt.KhuVuc_ID);
                                    NguoiGioiThieu.val(dt.NguoiGioiThieu_Ten);
                                    NguoiGioiThieu.attr('_value', dt.NguoiGioiThieu);
                                    if (dt.NgungTheoDoi) {
                                        NgungTheoDoi.attr('checked', 'checked');
                                    }
                                    else {
                                        NgungTheoDoi.removeAttr('checked');
                                    }


                                }
                            });
                        }
                    });
                });
            }
        }
    },
    add: function (fn) {
        DanhSachKhachHangFn.loadHtml(function () {
            var newDlg = $('#DanhSachKhachHangMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        DanhSachKhachHangFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
                            DanhSachKhachHangFn.clearform();
                            DanhSachKhachHangFn.draff(function () {

                            });
                        }, '#DanhSachKhachHangMdl-List');
                    },
                    'Lưu và đóng': function () {
                        DanhSachKhachHangFn.save(false, function (_ID, _Ten) {
                            if (typeof (fn) == 'function') {
                                fn(_ID, _Ten);
                            }
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
                    DanhSachKhachHangFn.draff(function() {

                    });
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
                if (confirm('Bạn có chắc chắn xóa khách hàng này?')) {// Xác nhận xem có xóa hay không
                    $.ajax({
                        url: DanhSachKhachHangFn.urlDefault().toString() + '&subAct=del',
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
        if (typeof (grid) == 'undefined') grid == '#DanhSachKhachHangMdl-List';
        var newDlg = $('#DanhSachKhachHangMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var NgaySinh = $('.NgaySinh', newDlg);
        var GioiTinh = $('.GioiTinh', newDlg);
        var Email = $('.Email', newDlg);
        var Mobile = $('.Mobile', newDlg);
        var Anh = $('.Anh', newDlg);
        var Phone = $('.Phone', newDlg);
        var CMND = $('.CMND', newDlg);
        var Ym = $('.Ym', newDlg);
        var NguonGoc_ID = $('.NguonGoc_ID', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var KhuVuc_ID = $('.KhuVuc_ID', newDlg);
        var NgungTheoDoi = $('.NgungTheoDoi', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var NguoiGioiThieu = $('.NguoiGioiThieu', newDlg);
        var LinhVuc_ID = $('.LinhVuc_ID', newDlg);
        var TuVanVien = $('.TuVanVien', newDlg);
        
        //region bien
        var _Anh = $(Anh).attr('ref');
        var _ID = ID.val();
        var _Ma = Ma.val();
        var _Ten = Ten.val();
        var _NgaySinh = NgaySinh.val();
        var _GioiTinh = GioiTinh.is(':checked');
        var _Email = Email.val();
        var _Mobile = Mobile.val();
        var _Phone = Phone.val();
        var _CMND = CMND.val();
        var _Ym = Ym.val();
        var _NguonGoc_ID = NguonGoc_ID.attr('_value');
        var _NguoiGioiThieu = NguoiGioiThieu.attr('_value');
        var _DiaChi = DiaChi.val();
        var _KhuVuc_ID = KhuVuc_ID.attr('_value');
        var _NgungTheoDoi = NgungTheoDoi.is(':checked');
        var _TuVanVien = TuVanVien.attr('_value');
        var _LinhVuc_ID = LinhVuc_ID.attr('_value');
        
        var _ID = ID.val();
        //endregion

        var err = '';
        if (_NguonGoc_ID == '') { err += 'Chọn nguồn gốc<br/>'; };
        if (_KhuVuc_ID == '') { err += 'Chọn khu vực khách hàng<br/>'; };
        if (_Ten == '') { err += 'Nhập tên<br/>'; };
        if (_Ma == '') { err += 'Nhập mã<br/>'; };

        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: DanhSachKhachHangFn.urlDefault().toString(),
            type: 'POST',
            data: {
                'subAct': 'save',
                ID: _ID,
                Ma: _Ma,
                Ten: _Ten,
                NgaySinh: _NgaySinh,
                GioiTinh: _GioiTinh,
                Email: _Email,
                Mobile: _Mobile,
                Phone: _Phone,
                CMND: _CMND,
                Ym: _Ym,
                NguonGoc_ID: _NguonGoc_ID,
                DiaChi: _DiaChi,
                KhuVuc_ID: _KhuVuc_ID,
                NgungTheoDoi: _NgungTheoDoi,
                Anh: _Anh,
                NguoiGioiThieu: _NguoiGioiThieu,
                LinhVuc_ID: _LinhVuc_ID,
                TuVanVien: _TuVanVien
            },
            success: function (dt) {
                adm.loading(null);
                if (typeof(fn) == 'function') {
                    fn(dt, _Ten);
                }
                $(grid).trigger('reloadGrid');
            }
        });
    },
    sendmail: function () {
        var s = '';
        s = jQuery("#DanhSachKhachHangMdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        DanhSachKhachHangFn.loadHtml(function () {
            var emailDlg = $('#DanhSachKhachHangMdl-dlgEmail');
            $(emailDlg).dialog({
                title: 'Email cho thành viên',
                modal: true,
                width: 800,
                buttons: {
                    'Gửi': function () {
                        var EmailTo = $('.EmailToTxt', emailDlg);
                        var EmailToDiv = $(EmailTo).parent();
                        var l = '';
                        $.each($(EmailToDiv).find('span.adm-token-item'), function (i, item) {
                            l += $(item).attr('_value') + ',';
                        });
                        var EmailBody = emailDlg.find('.EmailBody');
                        var EmailTitle = emailDlg.find('.EmailTitle');
                        $.ajax({
                            url: DanhSachKhachHangFn.urlDefault().toString(),
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
                                EmailToDiv.find('span.adm-token-item').remove();
                                EmailTitle.val('');
                                EmailBody.val('');
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
                                var treedata = $("#DanhSachKhachHangMdl-List").jqGrid('getRowData', ss[j]);
                                ll += '<span class=\"adm-token-item\" _value=\"' + treedata.ID + '\">' + treedata.Ten + '<a href=\"javascript:;\">x</a></span>';
                            }                            
                        }
                        $(EmailToDiv).prepend(ll);
                        $(EmailToDiv).find('a').click(function () {
                            $(this).parent().remove();
                        });
                    }

                    adm.createTinyMce(EmailBody);
                    DanhSachKhachHangFn.autoCompleteSearch(EmailTo, function (e, ui) {
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
        var q = $('.mdl-head-search-DanhSachKhachHangMdl');

        var NguonGoc_ID = filterKhachHangByNguonGoc.attr('_value');
        var KhuVuc_ID = filterKhachHangByKhuVuc.attr('_value');
        var _q = q.val();
        if (_q == 'Tìm kiếm') _q = '';
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#DanhSachKhachHangMdl-List').jqGrid('setGridParam', {
                url: DanhSachKhachHangFn.urlDefault().toString() + '&subAct=get&NguonGoc_ID=' + NguonGoc_ID + '&KhuVuc_ID=' + KhuVuc_ID + '&q=' + _q
            }).trigger('reloadGrid');
        }, 1000);
    },
    popfn: function () {
        var newDlg = $('#DanhSachKhachHangMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var NgaySinh = $('.NgaySinh', newDlg);
        var GioiTinh = $('.GioiTinh', newDlg);
        var Email = $('.Email', newDlg);
        var Mobile = $('.Mobile', newDlg);
        var Anh = $('.Anh', newDlg);
        var Phone = $('.Phone', newDlg);
        var CMND = $('.CMND', newDlg);
        var Ym = $('.Ym', newDlg);
        var NguonGoc_ID = $('.NguonGoc_ID', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var KhuVuc_ID = $('.KhuVuc_ID', newDlg);
        var LinhVuc_ID = $('.LinhVuc_ID', newDlg);
        var TuVanVien = $('.TuVanVien', newDlg);
        
        var NgungTheoDoi = $('.NgungTheoDoi', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var imgPreview = $('.adm-upload-preview-img', newDlg);
        var NguoiGioiThieu = $('.NguoiGioiThieu', newDlg);


        DanhSachKhachHangFn.autoCompleteSearch(NguoiGioiThieu, function (event, ui) {
            NguoiGioiThieu.attr('_value', ui.item.id);
        });

        var date = new Date();
        var dateStr = date.getDate() + '/' + (date.getMonth() + 1) + '/' + (date.getFullYear());
        NgaySinh.val(dateStr);
        NgaySinh.datepicker({ dateFormat: 'dd/mm/yy', showButtonPanel: true });

        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocomplete(TuVanVien, function (event, ui) {
                TuVanVien.val(ui.item.label);
                TuVanVien.attr('_value', ui.item.value);
            });
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'KHUVUC', KhuVuc_ID, function (event, ui) {
                KhuVuc_ID.attr('_value', ui.item.id);
            });
            danhmuc.autoCompleteLangBased('', 'NGUON-KH', NguonGoc_ID, function (event, ui) {
                NguonGoc_ID.attr('_value', ui.item.id);
            });
            danhmuc.autoCompleteLangBased('', 'LINHVUC-KH', LinhVuc_ID, function (event, ui) {
                LinhVuc_ID.attr('_value', ui.item.id);
            });
            KhuVuc_ID.unbind('click').click(function () {
                KhuVuc_ID.autocomplete('search', '');
            });
            LinhVuc_ID.unbind('click').click(function () {
                LinhVuc_ID.autocomplete('search', '');
            });
            NguonGoc_ID.unbind('click').click(function () {
                NguonGoc_ID.autocomplete('search', '');
            });
        });

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
    clearform: function () {
        var newDlg = $('#DanhSachKhachHangMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var NgaySinh = $('.NgaySinh', newDlg);
        var GioiTinh = $('.GioiTinh', newDlg);
        var Email = $('.Email', newDlg);
        var Mobile = $('.Mobile', newDlg);
        var Anh = $('.Anh', newDlg);
        var Phone = $('.Phone', newDlg);
        var CMND = $('.CMND', newDlg);
        var Ym = $('.Ym', newDlg);
        var NguonGoc_ID = $('.NguonGoc_ID', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var KhuVuc_ID = $('.KhuVuc_ID', newDlg);
        var NgungTheoDoi = $('.NgungTheoDoi', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var NguoiGioiThieu = $('.NguoiGioiThieu', newDlg);

        spbMsg.html('');
        imgAnh.attr('src', '');
        NguonGoc_ID.attr('_value', '');
        KhuVuc_ID.attr('_value', '');
        newDlg.find('input, textarea').val('');
    },
    draff: function (fn) {
        var newDlg = $(DanhSachKhachHangFn.EditForm);
        $.ajax({
            url: DanhSachKhachHangFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: {
                'subAct': 'draff'
            },
            success: function (dt) {
                var item = eval(dt);
                newDlg.find('.Ma').val(item.Ma);
                fn(dt);
            }
        });
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
                var term = 'khachHangMgr-autoCompleteSearch' + request.term;
                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: DanhSachKhachHangFn.urlDefault().toString(),
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
