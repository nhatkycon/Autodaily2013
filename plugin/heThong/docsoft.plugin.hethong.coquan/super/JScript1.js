var coquanSuper = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.coquanSuper.Class1, docsoft.plugin.hethong.coquan',
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton('.mdl-head-btn');
        adm.loading('Đang lấy dữ liệu cơ quan');
        $('.sub-mdl').tabs();
        var searchTxt = $('.mdl-head-search-coQuanSuper');
        $('#coquanSupermdl-List').jqGrid({
            url: coquanSuper.urlDefault + '&subAct=get',
            datatype: 'json',
            height: 300,
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
                var treedata = $("#coquanSupermdl-List").jqGrid('getRowData', rowid);
                coquanSuper.loadsubfunction(treedata.ID);
            },
            loadComplete: function () {
                adm.regQS(searchTxt, 'coquanSupermdl-List');
                adm.loading(null);
            }
        });
        var newDlg = $('#coquanSupermdl-dlgNew');
        if ($(newDlg).length < 1) {
            $('body').append('<div class=\"adm-dialogS\" id=\"coquanSupermdl-dlgNew\"></div>');
            newDlg = $('#coquanSupermdl-dlgNew');
            $(newDlg).load('<%=WebResource("docsoft.plugin.hethong.coquan.super.add.htm")%>');
        }
    },
    add: function () {
        var newDlg = $('#coquanSupermdl-dlgNew');
        $(newDlg).dialog({
            title: 'Thêm mới',
            modal: true,
            buttons: {
                'Lưu': function () {
                    coquanSuper.save();
                },
                'Lưu và đóng': function () {
                    coquanSuper.save();
                    $(newDlg).dialog('close');
                },
                'Đóng': function () {
                    $(newDlg).dialog('close');
                }
            },
            open: function () {
                coquanSuper.clearform();
                coquanSuper.setAutocomplete($('.PID', newDlg), function (event, ui) {
                    $('.PID', newDlg).val(ui.item.label);
                    $('.PID', newDlg).attr('_value', ui.item.id);
                });
            }
        });
    },
    edit: function () {
        var s = '';
        if (jQuery("#coquanSupermdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#coquanSupermdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                var newDlg = $('#coquanSupermdl-dlgNew');
                $(newDlg).dialog({
                    title: 'Sửa',
                    modal: true,
                    buttons: {
                        'Lưu': function () {
                            coquanSuper.save();
                        },
                        'Lưu và đóng': function () {
                            coquanSuper.save();
                            $(newDlg).dialog('close');
                        },
                        'Đóng': function () {
                            $(newDlg).dialog('close');
                        }
                    },
                    open: function () {
                        $.ajax({
                            url: coquanSuper.urlDefault + '&subAct=edit',
                            dataType: 'script',
                            data: {
                                'ID': s
                            },
                            success: function (dt) {
                                var data = eval('(' + dt + ')');
                                var newDlg = $('#coquanSupermdl-dlgNew');
                                var txtID = $('.ID', newDlg);
                                var txtPID = $('.PID', newDlg);
                                var txtTen = $('.Ten', newDlg);
                                var txtThuTu = $('.ThuTu', newDlg);
                                var txtMoTa = $('.MoTa', newDlg);
                                var txtNguoiTao = $('.NguoiTao', newDlg);
                                var spInfo = $('.admInfo', newDlg);
                                var spbMsg = $('.admMsg', newDlg);
                                $(txtID).val(data.ID);
                                $(txtPID).val(data.PID);
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
            }
        }
    },
    del: function () {
        var s = '';
        if (jQuery("#coquanSupermdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#coquanSupermdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                $.ajax({
                    url: coquanSuper.urlDefault + '&subAct=del',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery("#coquanSupermdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    save: function () {
        var newDlg = $('#coquanSupermdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtPID = $('.PID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtMoTa = $('.MoTa', newDlg);
        var txtThuTu = $('.ThuTu', newDlg);
        var txtNguoiTao = $('.NguoiTao', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var id = $(txtID).val();
        var pid = $(txtPID).attr('_value');
        var ten = $(txtTen).val();
        var thutu = $(txtThuTu).val();
        var mota = $(txtMoTa).val();
        var nguoitao = $(txtNguoiTao).val();
        var err = '';
        if (ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (err != '') {
            spbMsg.html(err);
            return false;
        }
        $.ajax({
            url: coquanSuper.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': id,
                'Ten': ten,
                'Mota': mota,
                'PID': pid,
                'ThuTu': thutu
            },
            success: function (dt) {
                if (dt == '1') {
                    spbMsg.html('');
                    jQuery("#coquanSupermdl-List").trigger('reloadGrid');
                    coquanSuper.clearform();
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
                    url: coquanSuper.urlDefault + '&subAct=getPid',
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
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + parseInt(item.level) * 10 + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    timer: null,
    loadsubfunction: function (cqid) {
        adm.loading('Nạp tính năng');
        var treeDiv = $('#coquanSuperMdl-functionmdl-coQuanFnMdl');
        $.ajax({
            url: coquanSuper.urlDefault + '&subAct=getFunction',
            data: {
                CQ_ID: cqid
            }, success: function (data) {
                adm.loading(null);
                $(treeDiv).jstree({ 'html_data': { 'data': data }, 'plugins': ['themes', 'html_data', 'ui', 'checkbox', 'crrm', 'hotkeys'] });
                $.each($('a', treeDiv), function (i, item) {
                    $(item).unbind('click').click(function () {
                        coquanSuper.timer = setTimeout(function () {
                            var l = '';
                            $.each($('a', treeDiv), function (i, item) {
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
                                url: coquanSuper.urlDefault + "&subAct=upadteFunction",
                                data: {
                                    UpdateList: l, CQ_ID: cqid
                                }, success: function (data) {
                                    adm.loading(null);
                                }, error: function () {
                                    adm.loading('Lỗi. Vui lòng thử lại');
                                }
                            });
                            if (coquanSuper.timer) clearInterval(coquanSuper.timer);
                        }, 1);
                    });
                });
            }
        });
    },
    clearform: function () {
        var newDlg = $('#coquanSupermdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtPID = $('.PID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtMoTa = $('.MoTa', newDlg);
        var txtThuTu = $('.ThuTu', newDlg);
        var txtNguoiTao = $('.NguoiTao', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        $(txtID).val('');
        $(txtPID).val('');
        $(txtPID).attr('_value', '');
        $(txtTen).val('');
        $(txtMoTa).val('');
        $(txtThuTu).val('');
        $(txtNguoiTao).val('');
        $(spInfo).html('');
        $(spbMsg).html('');
    }
}
coquanSuper.loadgrid();