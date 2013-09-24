var functions = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.functions.Class1, docsoft.plugin.hethong.functions',
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu tính năng');
        $('#functionsmdl-List').jqGrid({
            url: functions.urlDefault + '&subAct=get',
            datatype: 'json',
            height: 'auto',
            pager: false,
            colNames: ['ID', 'Tên', 'Ảnh', 'Mã', 'Kiểu', 'Thứ tự', 'Loại', 'Khóa', 'Mặc định'],
            colModel: [
            { name: 'Id', width: 1, key: true, hidden: true, sortable: false },
            { name: 'Ten', width: 50,  sortable: false },
            { name: 'Anh', width: 5, resizable: false, sortable: false },
            { name: 'Ma', width: 5, sortable: false },
            { name: 'Url', width: 20, sortable: false },
            { name: 'ThuTu', width: 5, resizable: false, sortable: false },
            { name: 'Loai', width: 5, resizable: false, sortable: false },
            { name: 'Publish', width: 5, resizable: false, sortable: false, formatter: 'checkbox' },
            { name: 'GiaTriMacDinh', width: 5, resizable: false, sortable: false, formatter: 'checkbox' }
        ],
            treeGrid: true,
            caption: 'Danh sách',
            ExpandColumn: 'Ten',
            treeGridModel: 'adjacency',
            autowidth: true,
            multiselect: true,
            rowNum: 200,
            ExpandColClick: true,
            treeIcons: { leaf: 'ui-icon-document-b' },
            onSelectRow: function (rowid) {

            },
            height: 400,
            loadComplete: function () {
                adm.loading(null);
                var searchTxt = $('.mdl-head-search-functions');
                adm.regQS(searchTxt, 'functionsmdl-List');
                adm.watermark(searchTxt, 'Tìm kiếm', function () {
                    $(searchTxt).val('');
                    $(searchTxt).val('Tìm kiếm');
                });
            }
        });
    },
    add: function () {
        functions.loadHtml(function () {
            var newDlg = $('#functionsmdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                modal: true,
                width: 380,
                buttons: {
                    'Lưu': function () {
                        functions.save();
                    },
                    'Lưu và đóng': function () {
                        functions.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    functions.clearform();
                    adm.styleButton();
                    var txtPID = $('.PID', newDlg);
                    functions.setAutocomplete($(txtPID), function (event, ui) {
                        $(txtPID).val(ui.item.label);
                        $(txtPID).attr('_value', ui.item.id);
                    });
                    $(txtPID).unbind('click').click(function () {
                        $(txtPID).autocomplete('search', '');
                    });
                    var ulpFn = function () {
                        var uploadBtn = $('.adm-upload-btn', newDlg);
                        var uploadView = $('.adm-upload-preview-img', newDlg);
                        var _params = { 'oldFile': $(uploadBtn).attr('ref') };
                        adm.upload(uploadBtn, 'anh', _params, function (rs) {
                            $(uploadBtn).attr('ref', rs)
                            $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                            ulpFn();
                        }, function (f) {
                        });
                    }
                    ulpFn();
                }
            });
        });
    },
    edit: function () {
        var s = '';
        if (jQuery("#functionsmdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#functionsmdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                functions.loadHtml(function () {
                    var newDlg = $('#functionsmdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        modal: true,
                        width: 380,
                        buttons: {
                            'Lưu': function () {
                                functions.save();
                            },
                            'Lưu và đóng': function () {
                                functions.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            var ulpFn = function () {
                                var uploadBtn = $('.adm-upload-btn', newDlg);
                                var uploadView = $('.adm-upload-preview-img', newDlg);
                                var _params = { 'oldFile': $(uploadBtn).attr('ref') };
                                adm.upload(uploadBtn, 'anh', _params, function (rs) {
                                    $(uploadBtn).attr('ref', rs)
                                    $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                                    ulpFn();
                                }, function (f) {
                                });
                            }
                            ulpFn();
                            var txtPID = $('.PID', newDlg);
                            $(txtPID).unbind('click').click(function () {
                                $(txtPID).autocomplete('search', '');
                            });
                            functions.setAutocomplete($(txtPID), function (event, ui) {
                                $(txtPID).val(ui.item.label);
                                $(txtPID).attr('_value', ui.item.id);
                            });
                            $.ajax({
                                url: functions.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    functions.clearform();
                                    var data = eval(dt);
                                    console.log(data);
                                    var newDlg = $('#functionsmdl-dlgNew');
                                    



                                    var txtID = $('.ID', newDlg);
                                    var txtPID = $('.PID', newDlg);
                                    var txtTen = $('.Ten', newDlg);
                                    var txtMoTa = $('.MoTa', newDlg);
                                    var txtThuTu = $('.ThuTu', newDlg);
                                    var txtNguoiTao = $('.NguoiTao', newDlg);
                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    var ckbGiaTriMacDinh = $('.GiaTriMacDinh', newDlg);
                                    var ckbPublish = $('.Publish', newDlg);
                                    var ckbDesk = $('.Desk', newDlg);
                                    var ckbDeskMacDinh = $('.DeskMacDinh', newDlg);
                                    var txtMa = $('.Ma', newDlg);
                                    var txtUrl = $('.Url', newDlg);
                                    var sltLoai = $('.Loai', newDlg);
                                    var lblAnh = $('.Anh', newDlg);
                                    var lblAnhPrv = $('.adm-upload-preview', newDlg);
                                    var lblAnhPrvImg = $(lblAnhPrv).find('img');

                                    $(lblAnh).attr('ref', data.Anh);
                                    if (data.Anh != '') {
                                        $(lblAnhPrvImg).attr('src', '../up/i/' + data.Anh + '?ref=' + Math.random());
                                    }
                                    
                                    if (data.Desk) {
                                        ckbDesk.attr('checked', 'checked');
                                    }
                                    else {
                                        ckbDesk.removeAttr('checked');
                                    }

                                    if (data.DeskMacDinh) {
                                        ckbDeskMacDinh.attr('checked', 'checked');
                                    }
                                    else {
                                        ckbDeskMacDinh.removeAttr('checked');
                                    }

                                    if (data.Publish) {
                                        ckbPublish.attr('checked', 'checked');
                                    }
                                    else {
                                        ckbPublish.removeAttr('checked');
                                    }

                                    if (data.GiaTriMacDinh) {
                                        ckbGiaTriMacDinh.attr('checked', 'checked');
                                    }
                                    else {
                                        ckbGiaTriMacDinh.removeAttr('checked');
                                    }
                                    
                                    $(txtID).val(data.ID);
                                    $(txtPID).val(data.PID);
                                    $(txtPID).val(data._Parent.Ten);
                                    $(txtPID).attr('_value', data.PID);
                                    $(txtTen).val(data.Ten);
                                    $(txtMoTa).val(data.MoTa);
                                    $(txtMa).val(data.Ma);
                                    $(txtThuTu).val(data.ThuTu);
                                    $(txtUrl).val(data.Url);
                                    $(sltLoai).val(data.Loai);
                                    $(txtNguoiTao).val(data.NguoiTao);
                                }
                            });
                        }
                    });
                });                
            }
        }
    },
    del: function () {
        var s = '';
        if (jQuery("#functionsmdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#functionsmdl-List").jqGrid('getGridParam', 'selrow').toString();
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
                    url: functions.urlDefault + '&subAct=del',
                    dataType: 'script',
                    data: {
                        'ID': s
                    },
                    success: function (dt) {
                        jQuery("#functionsmdl-List").trigger('reloadGrid');
                    }
                });
            }
        }
    },
    save: function (validate, fn) {
        var newDlg = $('#functionsmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtPID = $('.PID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtMoTa = $('.MoTa', newDlg);
        var txtMa = $('.Ma', newDlg);
        var txtUrl = $('.Url', newDlg);
        var ckbGiaTriMacDinh = $('.GiaTriMacDinh', newDlg);
        var ckbPublish = $('.Publish', newDlg);
        var ckbDesk = $('.Desk', newDlg);
        var ckbDeskMacDinh = $('.DeskMacDinh', newDlg);
        var txtNguoiTao = $('.NguoiTao', newDlg);
        var sltLoai = $('.Loai', newDlg);
        var txtThuTu = $('.ThuTu', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var lblAnh = $('.Anh', newDlg);

        var anh = $(lblAnh).attr('ref');
        var id = $(txtID).val();
        var pid = $(txtPID).attr('_value');
        var ma = $(txtMa).val();
        var url = $(txtUrl).val();
        var giatrimacdinh = $(ckbGiaTriMacDinh).is(':checked');
        var publish = $(ckbPublish).is(':checked');
        var desk = $(ckbDesk).is(':checked');
        var deskmacdinh = $(ckbDesk).is(':checked');
        var thutu = $(txtThuTu).val();
        var ten = $(txtTen).val();
        var mota = $(txtMoTa).val();
        var nguoitao = $(txtNguoiTao).val();
        var loai = $(sltLoai).children('option:selected').val();
        var err = '';
        if (ten == '') {
            err += 'Nhập tên<br/>';
        }
        if (ma == '') {
            err += 'Nhập mã<br/>';
        }
        if (err != '') {
            spbMsg.html(err);
            return false;
        }
        if (thutu == '') {
            thutu = '1';
        }
        else {
            if (!adm.isInt(thutu)) {
                err += 'Thứ tự là kiểu số<br/>';
            }
        }
        if (validate) {
            if (typeof (fn) == 'function') {
                fn();
            }
            return false;
        }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: functions.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {
                'ID': id,
                'Ten': ten,
                'GiaTriMacDinh': giatrimacdinh,
                'Ma': ma,
                'Url': url,
                'Mota': mota,
                'PID': pid,
                'Loai': loai,
                'Publish': publish,
                'Desk': desk,
                'DeskMacDinh': deskmacdinh,
                'ThuTu': thutu,
                'Anh': anh
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    spbMsg.html('');
                    jQuery("#functionsmdl-List").trigger('reloadGrid');
                    functions.clearform();
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
                    url: functions.urlDefault + '&subAct=getPid',
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
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + parseInt(item.level) * 10 + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    clearform: function () {
        var newDlg = $('#functionsmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtPID = $('.PID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtMoTa = $('.MoTa', newDlg);
        var txtMa = $('.Ma', newDlg);
        var txtUrl = $('.Url', newDlg);
        var ckbGiaTriMacDinh = $('.GiaTriMacDinh', newDlg);
        var ckbPublish = $('.Publish', newDlg);
        var ckbDesk = $('.Desk', newDlg);
        var ckbDeskMacDinh = $('.DeskMacDinh', newDlg);
        var txtThuTu = $('.ThuTu', newDlg);
        var txtNguoiTao = $('.NguoiTao', newDlg);
        var sltLoai = $('.Loai', newDlg);
        var spInfo = $('.admInfo', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var imgAnh = $('.adm-upload-preview-img', newDlg);
        var lblAnh = $('.Anh', newDlg);
        $(imgAnh).attr('src', '');
        $(lblAnh).attr('ref', '');

        $(txtID).val('');
        $(txtTen).val('');
        $(txtMoTa).val('');
        $(txtMa).val('');
        $(txtThuTu).val('');
        $(txtUrl).val('');
        $(ckbGiaTriMacDinh).removeAttr('checked');
        $(ckbPublish).removeAttr('checked');
        $(ckbDesk).removeAttr('checked');
        $(ckbDeskMacDinh).removeAttr('checked');
        $(txtNguoiTao).val('');
        $(spbMsg).html('');
        $(spInfo).html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#functionsmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("docsoft.plugin.hethong.functions.htm.htm")%>',
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