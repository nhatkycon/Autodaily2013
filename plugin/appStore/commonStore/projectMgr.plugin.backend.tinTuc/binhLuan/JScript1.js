var dbBlfn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=projectMgr.plugin.backend.tinTuc.binhLuan.Class1, projectMgr.plugin.backend.tinTuc',
    setup: function () {
    },
    loadgrid: function () {

        adm.loading('Đang lấy dữ liệu tin tức');
        adm.styleButton();
        $('#dbBlMdl-List').jqGrid({
            url: dbBlfn.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Tên', 'Email', 'Mobile', 'NoiDung', 'Tin', 'Ngày tạo'],
            colModel: [
                        { name: 'TIN_ID', key: true, sortable: true, hidden: true },
                        { name: 'Tên', width: 10, sortable: true },
                        { name: 'Email', width: 10, resizable: true, sortable: true },
                        { name: 'Mobile', width: 10, resizable: true, sortable: true },
                        { name: 'NoiDung', width: 30, resizable: true, sortable: true },
                        { name: 'Tin', width: 5, resizable: true, sortable: true },
                        { name: 'Active', width: 5, resizable: true, sortable: true }
                    ],
            caption: 'Danh sách Bình luận',
            autowidth: true,
            sortname: 'TIN_NgayCapNhat',
            sortorder: 'desc',
            rowNum: 100,
            rowList: [100, 50, 20, 300, 500, 1000],
            pager: jQuery('#dbBlMdl-Pagerql'),
            onSelectRow: function (rowid) {
                dbBlfn.doc(rowid);
            },
            loadComplete: function () {
                adm.loading(null);
            }
        });

        var searchTxt = $('.mdl-head-dbBlMdl-search-tin');
        $(searchTxt).unbind('keyup').keyup(function () {
            dbBlfn.search();
        });
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-dbBlMdl-search-tin');
        var __q = $(searchTxt).val();
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#dbBlMdl-List').jqGrid('setGridParam', { url: dbBlfn.urlDefault
            + '&subAct=get'
             + '&q=' + __q
            }).trigger("reloadGrid");
        }, 1000);
    },
    del: function (fn) {
        var s = '';
        if (jQuery("#dbBlMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#dbBlMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa?')) {
                    $.ajax({
                        url: dbBlfn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery("#dbBlMdl-List").trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    doc: function (id) {
        $.ajax({
            url: dbBlfn.urlDefault + '&subAct=readed',
            dataType: 'script',
            data: {
                'ID': id
            },
            success: function (dt) {
                $('tr[id="' + id + '"]', '#dbBlMdl-List').find('.comment-bold').removeClass('comment-bold');
            }
        });
    },
    duyet: function (st) {
        var s = '';
        if (jQuery("#dbBlMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#dbBlMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                $.ajax({
                    url: dbBlfn.urlDefault + '&subAct=duyet',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery("#dbBlMdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    send: function (act, fn) {
        var newDlg = $('#dbBlMdl-dlgNew');
        var NoiDung = $('.NoiDung', newDlg);
        var TIN_ID = $('.TIN_ID', newDlg);
        var ID = $('.ID', newDlg);
        var _NoiDung = NoiDung.val();
        var _PID = TIN_ID.val();
        var _ID = ID.val();
        var C_ID = $('.C_ID', newDlg);
        var _C_ID = C_ID.val();
        $.ajax({
            url: dbBlfn.urlDefault + '&subAct=' + act,
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'NoiDung': _NoiDung,
                'PID': _PID,
                'C_ID': _C_ID
            },
            success: function (_dt) {
                if (typeof (fn) == 'function') { fn(); };
            }
        });

    },
    edit: function () {
        var s = '';
        if (jQuery('#dbBlMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#dbBlMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một bình luận');
            }
            else {
                dbBlfn.loadHtml(function () {
                    var newDlg = $('#dbBlMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,

                        position: [200, 0],
                        //     modal: true,
                        buttons: {
                            'Lưu': function () {
                                dbBlfn.save(false, function () {
                                    dbBlfn.clearform();
                                    $(newDlg).dialog('close');
                                    jQuery("#dbBlMdl-List").trigger('reloadGrid');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            dbBlfn.clearform();
                            adm.styleButton();
                            dbBlfn.clearform();
                            dbBlfn.popfn();
                            $.ajax({
                                url: dbBlfn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                type: 'POST',
                                success: function (_dt) {
                                    var dt = eval(_dt);

                                    var NoiDung = $('.NoiDung', newDlg);
                                    var TIN_ID = $('.TIN_ID', newDlg);
                                    var ID = $('.ID', newDlg);
                                    var C_ID = $('.C_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var MoTa = $('.MoTa', newDlg);
                                    var KH_Email = $('.KH_Email', newDlg);
                                    var KH_Mobile = $('.KH_Mobile', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var KH_Ten = $('.KH_Ten', newDlg);
                                    var Anh = $('.Anh', newDlg);
                                    var imgAnh = $('.previewImg', newDlg);


                                    C_ID.val(dt.C_ID);
                                    Ten.val(dt.Ten);
                                    MoTa.val(dt.MoTa);
                                    KH_Email.val(dt.KH_Email);
                                    KH_Mobile.val(dt.KH_Mobile);
                                    KH_Ten.val(dt.KH_Ten);
                                    if (dt.Anh != '') {
                                        Anh.attr('ref', dt.Anh);
                                        imgAnh.attr('src', '../up/i/' + dt.Anh + '?ref=' + Math.random());
                                    }
                                    if (dt.Active) {
                                        Active.attr('checked', 'checked');
                                    }
                                    else {
                                        Active.removeAttr('checked');
                                    }
                                    NoiDung.val(dt.NoiDung);
                                    TIN_ID.val(dt.PID);
                                    ID.val(dt.ID);
                                }
                            });
                        },
                        beforeclose: function () {
                            dbBlfn.clearform();
                        }
                    });
                });
            }
        }

    },
    popfn: function () {
        var newDlg = $('#dbBlMdl-dlgNew');
        var NoiDung = $('.NoiDung', newDlg);
        var TIN_ID = $('.TIN_ID', newDlg);
        var ID = $('.ID', newDlg);
        var C_ID = $('.C_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var KH_Email = $('.KH_Email', newDlg);
        var KH_Mobile = $('.KH_Mobile', newDlg);
        var Active = $('.Active', newDlg);
        var KH_Ten = $('.KH_Ten', newDlg);
        var Anh = $('.Anh', newDlg);

        var ulpFn = function () {
            var imgAnh = $('.previewImg', newDlg);
            var _params = { 'oldFile': $(Anh).attr('ref') };
            adm.upload(Anh, 'anh', _params, function (rs) {
                $(Anh).attr('ref', rs)
                imgAnh.attr('src', '../up/i/' + rs + '?ref=' + Math.random());
            }, function (f) {
            });
        };
        ulpFn();

        adm.createTinyMce(NoiDung);
    },
    add: function () {

        dbBlfn.loadHtml(function () {
            var newDlg = $('#dbBlMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                buttons: {
                    'Lưu': function () {
                        dbBlfn.save(false, function () {
                            dbBlfn.clearform();
                        });
                    },
                    'Lưu và đóng': function () {
                        dbBlfn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {

                    adm.styleButton();
                    dbBlfn.clearform();
                    dbBlfn.popfn();
                }
                ,
                beforeclose: function () {

                }
            });
        });
    },
    rep: function () {
        var s = '';
        if (jQuery('#dbBlMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#dbBlMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một bình luận');
            }
            else {
                dbBlfn.loadHtml(function () {
                    var newDlg = $('#dbBlMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Trả lời',
                        width: 900,

                        position: [200, 0],
                        //     modal: true,
                        buttons: {
                            'Gửi': function () {
                                dbBlfn.send('send', function () {
                                    dbBlfn.clearform();
                                    $(newDlg).dialog('close');
                                    jQuery("#dbBlMdl-List").trigger('reloadGrid');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            dbBlfn.clearform();
                            dbBlfn.popfn();
                            $.ajax({
                                url: dbBlfn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (_dt) {
                                    var dt = eval(_dt);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var TIN_ID = $('.TIN_ID', newDlg);
                                    var ID = $('.ID', newDlg);
                                    var C_ID = $('.C_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var Email = $('.Email', newDlg);
                                    var Mobile = $('.Mobile', newDlg);


                                    C_ID.val(dt.C_ID);
                                    Ten.val(dt.Ten);
                                    Email.val(dt.Email);
                                    Mobile.val(dt.Mobile);
                                    NoiDung.val(dt.NoiDung);
                                    TIN_ID.val(dt.PID);
                                    ID.val(dt.ID);
                                }
                            });
                        },
                        beforeclose: function () {
                            dbBlfn.clearform();
                        }
                    });
                });
            }
        }

    },
    clearform: function () {
        var newDlg = $('#dbBlMdl-dlgNew');
        var NoiDung = $('.NoiDung', newDlg);
        var TIN_ID = $('.TIN_ID', newDlg);
        var ID = $('.ID', newDlg);
        var C_ID = $('.C_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var KH_Email = $('.KH_Email', newDlg);
        var KH_Mobile = $('.KH_Mobile', newDlg);
        var Active = $('.Active', newDlg);
        var KH_Ten = $('.KH_Ten', newDlg);
        var Anh = $('.Anh', newDlg);
        var imgAnh = $('.previewImg', newDlg);

        Anh.attr('ref', '');
        imgAnh.removeAttr('src');
        $('input, textarea', newDlg).val('');
    },
    save: function (validate, fn) {
        var newDlg = $('#dbBlMdl-dlgNew');

        var NoiDung = $('.NoiDung', newDlg);
        var TIN_ID = $('.TIN_ID', newDlg);
        var ID = $('.ID', newDlg);
        var C_ID = $('.C_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var MoTa = $('.MoTa', newDlg);
        var KH_Email = $('.KH_Email', newDlg);
        var KH_Mobile = $('.KH_Mobile', newDlg);
        var Active = $('.Active', newDlg);
        var KH_Ten = $('.KH_Ten', newDlg);
        var Anh = $('.Anh', newDlg);

        var _NoiDung = NoiDung.val();
        var _TIN_ID = TIN_ID.val();
        var _ID = ID.val();
        var _C_ID = C_ID.val();
        var _Ten = Ten.val();
        var _MoTa = MoTa.val();
        var _KH_Email = KH_Email.val();
        var _KH_Mobile = KH_Mobile.val();
        var _KH_Ten = KH_Ten.val();
        var _Anh = Anh.attr('ref');
        var _Active = Active.is(':checked');
        var err = '';
        if (_Ten == '') {
            err += 'Nhập tên<br/>';
        }

        if (_NoiDung == '') {
            err += 'Nhập nội dung<br/>';
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
            url: dbBlfn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                ID: _ID,
                KH_Ten: _KH_Ten,
                KH_Email: _KH_Email,
                KH_Mobile: _KH_Mobile,
                Ten: _Ten,
                MoTa: _MoTa,
                Anh: _Anh,
                NoiDung: _NoiDung,
                Active : _Active
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#dbBlMdl-List').trigger('reloadGrid');
                } else {
                }
            }
        });
    },
    loadHtml: function (fn) {
        var dlg = $('#dbBlMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("projectMgr.plugin.backend.tinTuc.binhLuan.htm.htm")%>',
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
