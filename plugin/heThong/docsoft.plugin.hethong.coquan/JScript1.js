var coquan = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.coquan.Class1, docsoft.plugin.hethong.coquan',
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton('.mdl-head-btn');
        adm.loading('Đang lấy dữ liệu cơ quan');
        $('.sub-mdl').tabs();
        var searchTxt = $('.mdl-head-search-coQuan');
        $('#coquanmdl-List').jqGrid({
            url: coquan.urlDefault + '&subAct=get',
            datatype: 'json',
            height: 240,
            pager: false,
            loadui: 'disable',
            colNames: ['ID', 'Thứ tự', 'Mã', 'Tên', 'Địa chỉ', 'Active', 'Lịch sử', 'NSD'],
            colModel: [
            { name: 'ID', width: 1, key: true, hidden: true, sortable: false },
            { name: 'ThuTu', width: 10, sortable: false, align: 'right' },
            { name: 'Ma', width: 30, sortable: false, align: 'right' },
            { name: 'Ten', width: 200, sortable: false },
            { name: 'MoTa', width: 100, sortable: false },
            { name: 'Active', width: 10, sortable: false, align: 'center', formatter: 'checkbox' },
            { name: 'NgayTao', width: 50, sortable: false },
            { name: 'NSD', width: 10, sortable: false, align: 'right' }
        ],
            treeGrid: true,
            caption: 'Danh sách',
            ExpandColumn: 'Ten',
            treeGridModel: 'adjacency',
            autowidth: true,
            rowNum: 200,
            ExpandColClick: false,
            treeIcons: { leaf: 'ui-icon-document-b' },
            onSelectRow: function (rowid) {
                var treedata = $("#coquanmdl-List").jqGrid('getRowData', rowid);
                coquan.loadsubfunction(treedata.ID);
            },
            loadComplete: function () {
                adm.regQS(searchTxt, 'coquanmdl-List');
                adm.loading(null);
            }
        });
        $(searchTxt).unbind('keyup').keyup(function () {
            //coquan.search();
        });
        adm.watermark(searchTxt, 'Tìm kiếm', function () {
            $(searchTxt).val('');
            $(searchTxt).val('Tìm kiếm');
        });
    },
    add: function () {
        coquan.loadHtml(function () {
            var newDlg = $('#coquanmdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                modal: true,
                width: 380,
                buttons: {
                    'Lưu': function () {
                        coquan.save();
                    },
                    'Lưu và đóng': function () {
                        coquan.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    coquan.clearform();
                    coquan.setAutocomplete($('.PID', newDlg), function (event, ui) {
                        $('.PID', newDlg).val(ui.item.label);
                        $('.PID', newDlg).attr('_value', ui.item.id);
                    });
                }
            });
        });
    },
    edit: function () {
        var s = '';
        if (jQuery("#coquanmdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#coquanmdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                coquan.loadHtml(function () {
                    var newDlg = $('#coquanmdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        modal: true,
                        width: 380,
                        buttons: {
                            'Lưu': function () {
                                coquan.save();
                            },
                            'Lưu và đóng': function () {
                                coquan.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.styleButton();
                            coquan.setAutocomplete($('.PID', newDlg), function (event, ui) {
                                $('.PID', newDlg).val(ui.item.label);
                                $('.PID', newDlg).attr('_value', ui.item.id);
                            });
                            $.ajax({
                                url: coquan.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    var data = eval('(' + dt + ')');
                                    var newDlg = $('#coquanmdl-dlgNew');
                                    var txtID = $('.ID', newDlg);
                                    var txtPID = $('.PID', newDlg);
                                    var txtTen = $('.Ten', newDlg);
                                    var txtThuTu = $('.ThuTu', newDlg);
                                    var txtMoTa = $('.MoTa', newDlg);
                                    var txtNguoiTao = $('.NguoiTao', newDlg);
                                    var txtMa = $('.Ma', newDlg);
                                    var ckbActive = $('.Active', newDlg);
                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    $(txtID).val(data.ID);
                                    $(txtMa).val(data.Ma);
                                    if (data.Active) {
                                        $(ckbActive).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbActive).removeAttr('checked');
                                    }
                                    $(txtPID).val(data._Parent.Ten);
                                    $(txtPID).attr('_value', data.PID);
                                    $(txtTen).val(data.Ten);
                                    $(txtMoTa).val(data.MoTa);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                    $(spInfo).html(data.NgayTao);
                                    $(txtThuTu).val(data.ThuTu);
                                }
                            })
                        }
                    });
                });
            }
        }
    },
    del: function () {
        var s = '';
        if (jQuery("#coquanmdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#coquanmdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var con = confirm('Bạn có muốn xóa cơ quan này');
                if (con) {
                    $.ajax({
                        url: coquan.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery("#coquanmdl-List").trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#coquanmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtPID = $('.PID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtMoTa = $('.MoTa', newDlg);
        var txtThuTu = $('.ThuTu', newDlg);
        var txtNguoiTao = $('.NguoiTao', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var txtMa = $('.Ma', newDlg);
        var ckbActive = $('.Active', newDlg);
        var id = $(txtID).val();
        var pid = $(txtPID).attr('_value');
        var ten = $(txtTen).val();
        var thutu = $(txtThuTu).val();
        var mota = $(txtMoTa).val();
        var nguoitao = $(txtNguoiTao).val();
        var ma = $(txtMa).val();
        var active = $(ckbActive).is(':checked');
        var err = '';
        if (ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (thutu == '') {
            thutu = '1';
        }
        else {
            if (!adm.isInt(thutu)) {
                err += 'Thứ tự là kiểu số<br/>';
            }
        }
        if (ma == '') {
            err += 'Nhập mã<br/>';
        }
        if (err != '') {
            spbMsg.html(err);
            return false;
        }
        if (validate) {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
        $.ajax({
            url: coquan.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': id,
                'Ten': ten,
                'Mota': mota,
                'PID': pid,
                'ThuTu': thutu,
                'Ma': ma,
                'Active': active
            },
            success: function (dt) {
                if (dt == '1') {
                    spbMsg.html('');
                    jQuery("#coquanmdl-List").trigger('reloadGrid');
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    coquan.clearform();
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
                adm.loading('Nạp danh sách');
                $.ajax({
                    url: coquan.urlDefault + '&subAct=getPid',
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
                                level: item.Level,
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
                    if ($(this).val() == '') {
                        $(this).attr('_value', '');
                    }
                }
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + parseInt(item.level) * 10 + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
        $(el).unbind('click').click(function () {
            $(el).autocomplete('search', '');
        });
    },
    setAutocompleteConByUsername: function (el, fn) {
        var term = 'coQuan-getCoQuanConByUsername';
        $(el).autocomplete({
            source: function (request, response) {
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID,
                                rowid: item.RowId,
                                ma: item.Ma
                            }
                        }
                    }))
                    return;
                }
                adm.loading('Nạp danh sách Đơn vị');
                _lastXhr = $.ajax({
                    url: coquan.urlDefault + '&subAct=getCoQuanConByUsername',
                    dataType: 'script',
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ma.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ma.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID,
                                        rowid: item.RowId,
                                        ma: item.Ma
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
            }, change: function (event, ui) {
                if (!ui.item) {
                    $(this).val('')
                    $(this).attr('_value', '');
                }
            },
            delay: 0,
            selectFirst: true
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
                				    .data("item.autocomplete", item)
                				    .append("<a><b>" + item.ma + "</b>: " + item.label + "</a>")
                				    .appendTo(ul);
        };
        $(el).unbind('click').click(function () {
            $(el).autocomplete('search', '');
        });        
    },
    setAutocompleteNodeWfId: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                adm.loading('Nạp danh sách');
                $.ajax({
                    url: coquan.urlDefault + '&subAct=SelectByNodeAndWfId',
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
                                level: item.Level,
                                rowid: item.RowId,
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
                    if ($(this).val() == '') {
                        $(this).attr('_value', '');
                    }
                }
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
        $(el).unbind('click').click(function () {
            $(el).autocomplete('search', '');
        });
    },
    setSelectListbyWf: function (el, fn) {
        $(el).html('Nạp danh sách');
        adm.loading('Nạp danh sách đơn vị');
        $.ajax({
            url: coquan.urlDefault + '&subAct=SelectByNodeAndWfId',
            dataType: 'script',
            data: {
                'q': ''
            },
            success: function (dt) {
                $(el).html('');
                adm.loading(null);
                var data = eval(dt);
                if ($(el).length > 0) {
                    $.each(data, function (i, item) {
                        $(el).append('<span class=\"adm-selectList-item\"><input _role=\"cid\" chinh=\"0\"  _value=\"' + item.RowId + '\" type=\"checkbox\" /> ' + item.Ten + '</span>');
                    });
                    $(el).find('input').unbind('click').click(function () {
                        var item = this;
                        if (typeof (fn) == 'function') {
                            fn(item);
                        }
                    });
                }
            }
        });
    },
    timer: null,
    loadsubfunction: function (cqid) {
        adm.loading('Nạp tính năng');
        var treeDiv = $('#coquanmdl-functionmdl-coQuanFnMdl');
        $.ajax({
            url: coquan.urlDefault + '&subAct=getFunction',
            data: {
                CQ_ID: cqid
            }, success: function (data) {
                adm.loading(null);
                $(treeDiv).jstree({ 'html_data': { 'data': data }, 'plugins': ['themes', 'html_data', 'ui', 'checkbox', 'crrm', 'hotkeys'] });
                $.each($('a', '#coquanmdl-functionmdl-coQuanFnMdl'), function (i, item) {
                    $(item).unbind('click').click(function () {
                        coquan.timer = setTimeout(function () {
                            var l = '';
                            $.each($('a', '#coquanmdl-functionmdl-coQuanFnMdl'), function (i, item) {
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
                                url: coquan.urlDefault + "&subAct=upadteFunction",
                                data: {
                                    UpdateList: l, CQ_ID: cqid
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
        });
    },
    clearform: function () {
        var newDlg = $('#coquanmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtPID = $('.PID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtMoTa = $('.MoTa', newDlg);
        var txtThuTu = $('.ThuTu', newDlg);
        var txtNguoiTao = $('.NguoiTao', newDlg);
        var txtMa = $('.Ma', newDlg);
        var ckbActive = $('.Active', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        $(txtID).val('');
        $(txtTen).val('');
        $(txtMoTa).val('');
        $(txtThuTu).val('');
        $(txtNguoiTao).val('');
        $(spInfo).html('');
        $(spbMsg).html('');
        $(txtMa).val('');
    },
    loadHtml: function (fn) {
        var dlg = $('#coquanmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("docsoft.plugin.hethong.coquan.htm.htm")%>',
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
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-coQuan');
        var q = $(searchTxt).val();
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#coquanmdl-List').jqGrid('setGridParam', { url: coquan.urlDefault + "&subAct=get&q=" + q }).trigger("reloadGrid");
        }, 500);
    }
}