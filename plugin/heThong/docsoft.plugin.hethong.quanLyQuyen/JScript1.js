var quanLyQuyen = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.quanLyQuyen.Class1, docsoft.plugin.hethong.quanLyQuyen',
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton('.mdl-head-btn');
        adm.loading('Đang lấy dữ liệu quyền');
        $('.quanLyQuyenMdl-subMdl').tabs();
        var filterCQID = $('.mdl-head-filterQuanLyQuyenByCQID');
        var searchTxt = $('.mdl-head-search-quanLyQuyen');
        $(searchTxt).unbind('keydown').keyup(function () {
            quanLyQuyen.search();
        });

        adm.watermark(filterCQID, 'Gõ tên đơn vị để lọc', function () {
            $(searchTxt).val('');
            quanLyQuyen.search();
            $(searchTxt).val('Tìm kiếm');
        });

        adm.watermark(searchTxt, 'Tìm kiếm', function () {
            $(searchTxt).val('');
            quanLyQuyen.search();
            $(searchTxt).val('Tìm kiếm');
        });

        $('#quanLyQuyenMdl-List').jqGrid({
            url: quanLyQuyen.urlDefault + '&subAct=get',
            datatype: 'json',
            height: 200,
            pager: false,
            colNames: ['ID', 'Tên', 'Loại', 'Đơn vị'],
            colModel: [
            { name: 'Id', width: 20, key: true },
            { name: 'Ten', width: 100, resizable: false },
            { name: 'Loại', width: 100, resizable: false },
            { name: 'CQ_ID', width: 100, resizable: false }
        ],
            caption: 'Danh sách',
            autowidth: true,
            //            multiselect: true,
            rowNum: 200,
            onSelectRow: function (rowid) {
                var treedata = $("#quanLyQuyenMdl-List").jqGrid('getRowData', rowid);
                quanLyQuyen.loadsubfunction(treedata.Id);
                quanLyQuyen.loadSubUser(treedata.Id);
            },
            loadComplete: function () {
                adm.loading(null);
                adm.regType(typeof(coquan), 'docsoft.plugin.hethong.coquan.Class1, docsoft.plugin.hethong.coquan', function () {
                    coquan.setAutocomplete(filterCQID, function (event, ui) {
                        $(filterCQID).val(ui.item.label);
                        $(filterCQID).attr('_value', ui.item.id);
                        if ($(searchTxt).val() == 'Tìm kiếm') {
                            $(searchTxt).val('');
                        }
                        quanLyQuyen.search();
                        $(searchTxt).val('Tìm kiếm');
                    });
                    $(filterCQID).unbind('click').click(function () {
                        $(filterCQID).autocomplete('search', '');
                    });
                });
            }
        });
    },
    add: function () {
        quanLyQuyen.loadHtml(function () {
            var newDlg = $('#quanLyQuyenMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                modal: true,
                width: 370,
                buttons: {
                    'Lưu': function () {
                        quanLyQuyen.save();
                    },
                    'Lưu và đóng': function () {
                        quanLyQuyen.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton('.mdl-head-btn');
                    quanLyQuyen.clearform();
                    quanLyQuyen.popfn();
                }
            });
        });
    },
    edit: function () {
        var s = '';
        if (jQuery("#quanLyQuyenMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#quanLyQuyenMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                quanLyQuyen.loadHtml(function () {
                    var newDlg = $('#quanLyQuyenMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        modal: true,
                        width: 370,
                        buttons: {
                            'Lưu': function () {
                                quanLyQuyen.save();
                            },
                            'Lưu và đóng': function () {
                                quanLyQuyen.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton('.mdl-head-btn');
                            quanLyQuyen.clearform();
                            quanLyQuyen.popfn();
                            $.ajax({
                                url: quanLyQuyen.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var txtID = $('.ID', newDlg);
                                    var txtCQID = $('.CQ_ID', newDlg);
                                    var txtTen = $('.Ten', newDlg);
                                    var txtloai = $('.DM_ID', newDlg);
                                    var txtNguoiTao = $('.NguoiTao', newDlg);
                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    $(txtloai).val(data.Loai_Ten);
                                    $(txtloai).attr('_value', data.Loai_ID);
                                    $(txtID).val(data.ID);
                                    $(txtCQID).val(data._CoQuan.Ten);
                                    $(txtCQID).attr('_value', data.CQ_ID);
                                    $(txtTen).val(data.Ten);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                    $(spInfo).html(data.NgayTao);
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    popfn: function () {
        var newDlg = $('#quanLyQuyenMdl-dlgNew');
        quanLyQuyen.clearform();
        adm.regType(typeof (coquan), 'docsoft.plugin.hethong.coquan.Class1, docsoft.plugin.hethong.coquan', function () {
            var txtCQ_ID = $('.CQ_ID', newDlg);
            coquan.setAutocomplete(txtCQ_ID, function (event, ui) {
                $(txtCQ_ID).val(ui.item.label);
                $(txtCQ_ID).attr('_value', ui.item.id);
            });
            $(txtCQ_ID).unbind('click').click(function () {
                $(txtCQ_ID).autocomplete('search', '');
            });            
        });
        var txtDM_ID = $('.DM_ID', newDlg);
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('LUSR', txtDM_ID, function (event, ui) {
                $(txtDM_ID).attr('_value', ui.item.id);
            });
            $(txtDM_ID).unbind('click').click(function () {
                $(txtDM_ID).autocomplete('search', '');
            });
        });
    },
    del: function () {
        var s = '';
        if (jQuery("#quanLyQuyenMdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#quanLyQuyenMdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            var con = confirm('Bạn muốn xóa bỏ nhóm này?');
            if (con) {
                $.ajax({
                    url: quanLyQuyen.urlDefault + '&subAct=del',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery("#quanLyQuyenMdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#quanLyQuyenMdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtCQID = $('.CQ_ID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var _loai = $('.DM_ID', newDlg)
        var _id = $(txtID).val();
        var _cq_id = $(txtCQID).attr('_value');
        var _ten = $(txtTen).val();
        var _loai_id = $(_loai).attr('_value');
        var _loai_ten = $(_loai).val();
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var err = '';
        if (_ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (_cq_id == '') {
            err += 'Chọn cơ quan<br/>';
        }

//        if (_loai_id == '') {
//            err += 'Chọn loại người dùng<br/>';
//        }
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
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: quanLyQuyen.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': _id,
                'Ten': _ten,
                'CQ_ID': _cq_id,
                'Loai_ID': _loai_id,
                'Loai_Ten': _loai_ten

            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    spbMsg.html('');
                    jQuery("#quanLyQuyenMdl-List").trigger('reloadGrid');
                    quanLyQuyen.clearform();
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
    setAutocomplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp list');
                $.ajax({
                    url: quanLyQuyen.urlDefault + '&subAct=getPid',
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
                                level: item.Loai,
                                id: item.ID,
                                pid: item.PID
                            }
                        }))
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            },
            change: function (event, ui) {
                if (!ui.item) {
                    $(this).val('')
                    $(this).attr('_value', '');
                }
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    clearform: function () {
        var newDlg = $('#quanLyQuyenMdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtCQID = $('.CQ_ID', newDlg);
        var txtLoai = $('.DM_ID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        $(txtID).val('');
        $(txtTen).val('');
        $(spbMsg).html('');
        $(spInfo).html('');
    },
    search: function () {
        var timerSearch;
        var filterCQID = $('.mdl-head-filterQuanLyQuyenByCQID');
        var searchTxt = $('.mdl-head-search-quanLyQuyen');
        var q = $(searchTxt).val();
        var cq = $(filterCQID).attr('_value');
        var _cq = $(filterCQID).val();
        if (_cq == '') cq = '';
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#quanLyQuyenMdl-List').jqGrid('setGridParam', { url: quanLyQuyen.urlDefault + "&subAct=get&q=" + q + "&CQ_ID=" + cq }).trigger("reloadGrid");
        }, 500);
    },
    timer: null,
    loadsubfunction: function (role_id) {
        adm.loading('Nạp tính năng');
        var treeDiv = $('#quanLyQuyenMdl-functionmdl-roleFnMdl');
        $.ajax({
            url: quanLyQuyen.urlDefault + '&subAct=getFunction',
            data: {
                'ID': role_id
            }, success: function (data) {
                adm.loading(null);
                if (data == '0') {
                    $(treeDiv).html('Đơn vị chưa cấu hình quyền');
                }
                else {
                    $(treeDiv).jstree({ 'html_data': { 'data': data }, 'plugins': ['themes', 'html_data', 'ui', 'checkbox', 'crrm', 'hotkeys'] });
                    $.each($('a', '#quanLyQuyenMdl-functionmdl-roleFnMdl'), function (i, item) {                    
                        $(item).unbind('click').click(function () {
                            coquan.timer = setTimeout(function () {
                                var l = '';
                                $.each($('a', '#quanLyQuyenMdl-functionmdl-roleFnMdl'), function (i, item) {
                                    var _p = $(item).parent();
                                    if (!$(_p).hasClass('jstree-unchecked')) {
                                        if ($(_p).hasClass('jstree-undetermined')) {
                                            if ($(_p).find('.jstree-checked').length > 0) {
                                                l += $(_p).attr('_ID');
                                                l += ',';
                                            }
                                        }
                                        else {
                                            l += $(_p).attr('_ID');
                                            l += ',';
                                        }
                                    }
                                });
                                adm.loading('Lưu thay đổi');
                                $.ajax({
                                    url: quanLyQuyen.urlDefault + "&subAct=updateFunction",
                                    data: {
                                        UpdateList: l, ID: role_id
                                    }, success: function (data) {
                                        adm.loading(null);
                                    }, error: function () {
                                        adm.loading('Lỗi. Vui lòng thử lại');
                                    }
                                });
                                if (coquan.timer) clearInterval(coquan.timer);
                            }, 1);
                        });
                    });
                }
            }
        });
    },
    loadSubUser: function (role_id) {
        adm.loading('Nạp thành viên');
        var userList = $('#quanLyQuyenMdl-functionmdl-UserInRoleMdl');
        $.ajax({
            url: quanLyQuyen.urlDefault + '&subAct=getUserByRole',
            data: {
                'ID': role_id
            }, success: function (data) {
                adm.loading(null);
                if (data == '0') {
                    $(userList).html('Đơn vị chưa có thành viên');
                }
                else {
                    $(userList).html(data);
                    $.each($('input', userList), function (i, item) {
                        $(item).unbind('click').click(function () {
                            coquan.timer = setTimeout(function () {
                                var l = '';
                                $.each($('input', userList), function (i, item) {
                                    if ($(item).is(':checked')) {
                                        l += $(item).attr('_username');
                                        l += ',';
                                    }
                                });

                                adm.loading('Lưu thay đổi');
                                $.ajax({
                                    url: quanLyQuyen.urlDefault + "&subAct=updateUsers",
                                    data: {
                                        UpdateList: l, ID: role_id
                                    }, success: function (data) {
                                        adm.loading(null);
                                    }, error: function () {
                                        adm.loading('Lỗi. Vui lòng thử lại');
                                    }
                                });
                                if (coquan.timer) clearInterval(coquan.timer);
                            }, 1);
                        });
                    });
                }
            }
        });
    },
    loadHtml: function (fn) {
        var dlg = $('#quanLyQuyenMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("docsoft.plugin.hethong.quanLyQuyen.htm.htm")%>',
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
