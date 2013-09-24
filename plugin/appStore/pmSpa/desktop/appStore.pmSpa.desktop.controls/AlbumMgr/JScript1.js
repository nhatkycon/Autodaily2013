var AlbumMgrFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=appStore.pmSpa.desktop.controls.AlbumMgr.DanhSach, appStore.pmSpa.desktop.controls'; },
    EditForm: '#AlbumMgrFnMdl-dlgNew',
    getAlbum: function (fn) {
        AlbumMgrFn.Setup();
        $.ajax({
            url: AlbumMgrFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: {
                'subAct': 'get'
            },
            success: function (dt) {
                if (typeof (fn) == 'function') {
                    fn(dt);
                }
                var list = $('.album-list');
                list.html($('#album-item').tmpl(eval(dt)));
            }
        });
    },
    loadGrid: function (grid, fn) {
        if (typeof (grid) == 'undefined') grid == '#danhMucDichVuMgrAlbum-list';

        $(grid).jqGrid({
            url: AlbumMgrFn.urlDefault().toString() + '&subAct=getGrid',
            height: '400',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Mã', 'Tên'],
            colModel: [
                        { name: 'AB_ID', key: true, sortable: true, hidden: true },
                        { name: 'AB_Ma', width: 5, sortable: true },
                        { name: 'AB_Ten', width: 20, sortable: true }
                    ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'AB_NgayTao',
            sortorder: 'asc',
            rowNum: 10000,
            onSelectRow: function (rowid) {
            },
            pager: $('#danhMucDichVuMgr-Pager'),
            loadComplete: function () {
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    Setup: function () {
        $('<a href="javascript:;" onclick="AlbumMgrFn.Add();" class="topBar-navigation-item icon-add"><span class="icon"></span><span class="icon-ten">Thêm</span></a>').appendTo('#topBar-left');
        $('<a href="' + ((typeof (domain) != 'undefined') ? domain : '..') + '/Album-Danh-SoSanh/" class="topBar-navigation-item icon-sosanh"><span class="icon"></span><span class="icon-ten">So sánh</span></a>').appendTo('#topBar-left');
    },
    ViewAllbum: function (ten, mota) {
        
    },
    AddProxy: function () {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        AlbumMgrFn.Add(function (dt) {
            var myUi = eval(dt);
            var skList = $('.album-list');
            $('#album-item').tmpl(myUi).prependTo(skList);
            return false;
        }, { });
    },
    Add: function (fn, options) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        AlbumMgrFn.loadHtml(function () {
            var newDlg = $(AlbumMgrFn.EditForm);
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 1000,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        AlbumMgrFn.save(function (ds) {
                            if (typeof (fn) == 'function') {
                                fn(ds);
                            }
                            AlbumMgrFn.clearform();
                            AlbumMgrFn.popfn();
                            AlbumMgrFn.draff(function (dt) {
                                var ID = newDlg.find('.ID');
                                var UploadImg = $('.UploadImg', newDlg);
                                var listImg = $('.listImg', newDlg);
                                ID.val(dt);
                                ID.attr('_RowID', dt);
                                ID.attr('draff', '1');
                                AlbumMgrFn.addEventUpload(UploadImg, listImg, ID);
                            });
                        }, options);
                    },
                    'Lưu và đóng': function () {
                        AlbumMgrFn.save(false, function (dt) {
                            if (typeof (fn) == 'function') {
                                fn(dt);
                            }
                            $(newDlg).dialog('close');
                        }, options);
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        AlbumMgrFn.clearform();
                    }
                },
                beforeClose: function () {
                    AlbumMgrFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    AlbumMgrFn.clearform();
                    AlbumMgrFn.popfn();
                    AlbumMgrFn.draff(function (dt) {
                        var ID = newDlg.find('.ID');
                        var UploadImg = $('.UploadImg', newDlg);
                        var listImg = $('.listImg', newDlg);
                        ID.val(dt);
                        ID.attr('_RowID', dt);
                        ID.attr('draff', '1');
                        AlbumMgrFn.addEventUpload(UploadImg, listImg, ID);
                    });
                }
            });
        });
    },
    Edit: function (s, fn, options, fn1) {
        AlbumMgrFn.loadHtml(function () {
            var newDlg = $(AlbumMgrFn.EditForm);
            $(newDlg).dialog({
                title: 'Sửa',
                width: 1000,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        AlbumMgrFn.save(function (ds) {
                            adm.styleButton();
                            AlbumMgrFn.clearform();
                            AlbumMgrFn.popfn();
                            if (typeof (fn) == 'function') {
                                fn(ds);
                            }
                            AlbumMgrFn.draff(function (dt) {
                                var ID = newDlg.find('.ID');
                                var UploadImg = $('.UploadImg', newDlg);
                                var listImg = $('.listImg', newDlg);
                                ID.val(dt);
                                ID.attr('_RowID', dt);
                                ID.attr('draff', '1');
                                AlbumMgrFn.addEventUpload(UploadImg, listImg, ID);
                            });
                        }, options);
                    },
                    'Lưu và đóng': function () {
                        AlbumMgrFn.save(false, function (dt) {
                            if (typeof (fn) == 'function') {
                                fn(dt);
                            }
                            $(newDlg).dialog('close');
                        }, options);
                    },
                    'Xóa': function () {
                        $.ajax({
                            url: AlbumMgrFn.urlDefault().toString() + '&subAct=del',
                            dataType:'script',
                            data:{'ID': s},
                            success: function(_dt) {
                                $(newDlg).dialog('close');
                                AlbumMgrFn.clearform();
                                if (typeof (fn1) == "function") {
                                    fn1();
                                }
                            }
                        });
                        
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        AlbumMgrFn.clearform();
                    }
                },
                beforeClose: function () {
                    AlbumMgrFn.clearform();
                },
                open: function () {
                    adm.styleButton();
                    AlbumMgrFn.clearform();
                    AlbumMgrFn.popfn();
                    $.ajax({
                        url: AlbumMgrFn.urlDefault().toString() + '&subAct=edit',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (_dt) {
                            adm.loading(null);
                            var dt = eval(_dt);
                            var ID = $('.ID', newDlg);
                            var Ma = $('.Ma', newDlg);
                            var Ten = $('.Ten', newDlg);
                            var MoTa = $('.MoTa', newDlg);
                            var ThuTu = $('.ThuTu', newDlg);
                            var Anh = $('.Anh', newDlg);
                            var UploadImg = $('.UploadImg', newDlg);
                            var listImg = $('.listImg', newDlg);

                            var spbMsg = $('.admMsg', newDlg);
                            var imgAnh = $('.previewImg', newDlg);
                            var Anh = $('.Anh', newDlg);

                            imgAnh.attr('src', '');
                            Anh.attr('ref', '');

                            Anh.attr('ref', dt.AnhDaiDien);
                            imgAnh.attr('src', '../up/i/' + dt.AnhDaiDien + '?ref=' + Math.random());

                            ID.val(dt.ID);
                            ID.attr('draff', '0');
                            Ten.val(dt.Ten);
                            Ma.val(dt.Ma);
                            MoTa.val(dt.MoTa);
                            ThuTu.val(dt.ThuTu);

                            var ListFiles = eval(dt.ListFiles);
                            $.each(ListFiles, function (i, item) {
                                $('<span class=\"adm-token-item\"><div class=\"adm-div-preview-img-size-75\"><img class=\"adm-preview-img-size-75\" src=\"' + ((typeof (domain) != 'undefined') ? domain + '/lib' : '..') + '/up/sanpham/' + item.ThuMuc + '/' + item.Ten + item.MimeType + '?ref=' + Math.random() + '\" /></div><a _value=\"' + item.ID + '\" href="javascript:;" class="adm-upload-btn">Xóa</a></span>').appendTo(listImg).find('a').click(function () {
                                    if (confirm('Bạn có chắc chắn xóa ảnh này?')) {
                                        var _item = $(this);
                                        $(_item).hide();
                                        $.ajax({
                                            url: AlbumMgrFn.urlDefault().toString(),
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

                            ID.attr('_RowID', dt);
                            AlbumMgrFn.addEventUpload(UploadImg, listImg, ID);
                        }
                    });
                }
            });
        });
    },
    EditInView: function (s) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        AlbumMgrFn.Edit(s, function() {
            document.location.reload();
        },null,function () {
            var url = $('.tablet-content-tabs-header-item-back').attr('href');
            document.location.href = url;
        });
    },
    save: function (fn, options) {
        if (!loggedIn) {
            alert('Bạn cần đăng nhập'); return false;
        }
        var newDlg = $(AlbumMgrFn.EditForm);
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var ThuTu = $('.ThuTu', newDlg);
        var Anh = $('.Anh', newDlg);

        var _Anh = $(Anh).attr('ref');
        var _ID = ID.val();
        var _draff = ID.attr('draff');
        var _Ma = Ma.val();
        var _Ten = Ten.val();
        var _ThuTu = ThuTu.val();
        var _MoTa = MoTa.val();

        var err = '';
        if (_Ten == null) { err = 'Nhập tên<br/>'; }
        if (_ThuTu == null) { err = 'Nhập thứ tự<br/>'; }
        if (err != '') {
            if (typeof (common) != 'undefined') {
                common.fbMsg('Lỗi', 'Bạn cần hoàn thành các lỗi sau <hr/>' + err, 200, 'msg-dangKy-pop', function () {
                    setTimeout(function () {
                        $(document).trigger('close.facebox', 'msg-dangKy-pop');
                    }, 1000);
                });
            }
            else {
                adm.loading('Lỗi<br/>Bạn cần hoàn thành các lỗi sau <hr/>' + err);
            }
            return false;
        }

        var coptions = {
            'subAct': 'save',
            ID: _ID,
            Ma: _Ma,
            Ten: _Ten,
            MoTa: _MoTa,
            Anh: _Anh,
            draff: _draff,
            ThuTu: _ThuTu
        };

        coptions = $.extend(options, coptions);

        $.ajax({
            url: AlbumMgrFn.urlDefault().toString(),
            type: 'POST',
            dataType: 'script',
            data: coptions,
            success: function (dt) {
                if (typeof (fn) == 'function') {
                    fn(dt);
                }
                AlbumMgrFn.getAlbum();                
            }
        });

    },
    popfn: function () {
        var newDlg = $(AlbumMgrFn.EditForm);
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var ThuTu = $('.ThuTu', newDlg);

        var ulpFn = function () {
            var imgAnh = $('.previewImg', newDlg);
            var Anh = $('.Anh', newDlg);
            var _params = { 'oldFile': $(Anh).attr('ref') };
            adm.upload(Anh, 'anh', _params, function (rs) {
                $(Anh).attr('ref', rs)
                imgAnh.attr('src', ((typeof(domain) != 'undefined') ? domain + '/lib' : '..')  + '/up/i/' + rs + '?ref=' + Math.random());
            }, function (f) {
            });
        };
        ulpFn();
    },
    clearform: function () {
        var newDlg = $(AlbumMgrFn.EditForm);
        var ID = $('.ID', newDlg);
        var Ma = $('.Ma', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var ThuTu = $('.ThuTu', newDlg);

        var Anh = $('.Anh', newDlg);
        var imgAnh = $('.previewImg', newDlg);
        var UploadImg = $('.UploadImg', newDlg);
        var listImg = $('.listImg', newDlg);

        listImg.html('');
        imgAnh.attr('src', '');
        Anh.attr('ref', '');

        newDlg.attr('_id', '');
        newDlg.attr('_RowId', '');
        newDlg.attr('draff', '0');
        newDlg.find('input, textarea').val('');

    },
    draff: function (fn) {
        var newDlg = $(AlbumMgrFn.EditForm);
        $.ajax({
            url: AlbumMgrFn.urlDefault().toString(),
            type: 'POST',
            data: {
                'subAct': 'draff'
            },
            success: function (dt) {
                fn(dt);
            }
        });
    },
    addEventUpload: function (oBrowseButton, oFileList, oInputData) {
        var browseButton = $(oBrowseButton);
        var fileList = $(oFileList);
        var inputData = $(oInputData);
        var PRowIdSP = inputData.attr('_RowID');
        var _params = { 'act': 'MultiuploadImg', 'PRowIdSP': PRowIdSP }
        adm.uploadSanPham(browseButton, 'anh', _params, function (rs) {
        }, function (_rs) {
        }, function (_r, _f) {

            var datars = eval(_r);
            var Imgname = datars.Ten + datars.MimeType;
            var foldername = datars.ThuMuc;
            var l = '';
            l += '<span class=\"adm-token-item\"><div class=\"adm-div-preview-img-size-75\"><img class=\"adm-preview-img-size-75\" src=\"' + ((typeof (domain) != 'undefined') ? domain + '/lib' : '..') + '/up/sanpham/' + foldername + '/' + Imgname + '?ref=' + Math.random() + '\" /></div><a _value=\"' + datars.ID + '\" href="javascript:;" class="adm-upload-btn">Xóa</a></span>';
            $(l).appendTo(fileList).find('a').click(function () {
                if (confirm('Bạn có chắc chắn xóa ảnh này?')) {
                    var _item = $(this);
                    $(_item).hide();
                    $.ajax({
                        url: AlbumMgrFn.urlDefault().toString(),
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
    loadHtml: function (fn) {
        var dlg = $(AlbumMgrFn.EditForm);
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.desktop.controls.AlbumMgr.htm.htm")%>',
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