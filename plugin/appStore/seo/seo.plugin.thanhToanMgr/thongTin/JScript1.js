var ThanhToanMgrthongTinFn = {
    urlDefault: function () {
        return adm.urlDefault + '&act=loadPlug&rqPlug=seo.plugin.thanhToanMgr.thongTin.Class1, seo.plugin.thanhToanMgr';
    },
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Lấy dữ liệu');
        $('#ThanhToanMgrthongTin-List').jqGrid({
            url: ThanhToanMgrthongTinFn.urlDefault().toString() + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            colNames: ['ID', 'Số tiền', 'Ngày', 'Duyệt'],
            colModel: [
                { name: 'ID', key: true, sortable: true, hidden: true },
                { name: 'SoDu', width: 70, sortable: true, align: "center" },
                { name: 'NgayTao', width: 20, resizable: true, sortable: true },
                { name: 'Duyet', width: 10, resizable: true, sortable: true }
            ],
            caption: 'Lịch sử thanh toán',
            autowidth: true,
            sortname: 'ID',
            sortorder: 'desc',
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) {
                //var treedata = $("#ThanhToanMgrthongTin-List").jqGrid('getRowData', rowid);
                //ThanhToanMgrthongTinFn.changeGrid(treedata.ID, treedata.Ten);
            },
            rowNum: 50,
            rowList: [50, 100, 150, 500],
            pager: jQuery('#ThanhToanMgrthongTin-Pager'),
            loadComplete: function () {
                adm.loading(null);
                adm.regType(typeof (chienDichForUserFn), 'seo.plugin.ChienDichForUser.Class1, seo.plugin.ChienDichForUser', function () { });
            }
        });
    },
    add1: function () {
        ThanhToanMgrthongTinFn.loadHtml(function () {
            var newDlg = $('#ThanhToanMgrthongTin-yeuCau-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        ThanhToanMgrthongTinFn.save1(false, function () {
                            ThanhToanMgrthongTinFn.clearform1();
                        });
                    },
                    'Lưu và đóng': function () {
                        ThanhToanMgrthongTinFn.save1(false, function () {
                            ThanhToanMgrthongTinFn.clearform1();
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    ThanhToanMgrthongTinFn.clearform1();
                    adm.styleButton();
                }
            });
        });
    },
    del: function () {
        var s = '';
        if ($('#ThanhToanMgrthongTin-List').jqGrid('getGridParam', 'selrow') != null) {
            s = $('#ThanhToanMgrthongTin-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa loại danh mục này?')) {
                    $.ajax({
                        url: ThanhToanMgrthongTinFn.urlDefault().toString() + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            $("#ThanhToanMgrthongTin-List").trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save1: function (validate, fn) {
        var newDlg = $('#ThanhToanMgrthongTin-yeuCau-dlgNew');
        var ID = $('.ID', newDlg);
        var SoDu = $('.SoDu', newDlg);
        var TkTotal = $('#ThanhToanMgrthongTin-tkBtn').attr('_value');
        var spbMsg = $('.admMsg', newDlg);

        var _ID = ID.val();
        var _SoDu = SoDu.val();
        var err = '';
        if (_SoDu == '') { err += 'Nhập Số dư<br/>'; }
        else { if (!adm.isInt(_SoDu)) { err += 'Nhập Số dư kiểu số<br/>'; } };

        if (parseInt(_SoDu) < 100000) { err += 'Số dư lớn hơn 300.000 vnđ<br/>'; }

        if (parseInt(TkTotal) < 0) { err += 'Số dư của bạn bằng 0<br/>'; }
        if (parseInt(_SoDu) > parseInt(TkTotal)) { err += 'Số dư cần nhỏ hơn tổng tài khoản<br/>' + TkTotal; }
        if ($('.yctt-unchecked').length > 0 && _ID == '') { err += 'Bạn đã có yêu cầu thanh toán và chúng tôi đang tiến hành xử lý<br/>Bạn không thể tiếp tục yêu cầu cho đến khi chúng tôi xử lý xong yêu cầu đang có<br/>'; }

        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: ThanhToanMgrthongTinFn.urlDefault().toString() + '&subAct=saveSoDu',
            dataType: 'script',
            data: {
                'ID': _ID,
                'SoDu': _SoDu
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    $('#ThanhToanMgrthongTin-List').trigger('reloadGrid');
                    ThanhToanMgrthongTinFn.clearform1();
                    if (typeof (fn) == 'function') { fn(); }
                }
                else if (dt == '-1') {
                    alert('Bạn cần chứng thực tài khoản\n Để đề phòng trường hợp cộng tác viên gian lận, chúng tôi chỉ trả tiền cho những thành viên đã chứng thực tài khoản\n Bạn vui lòng liên hệ 094.670.9969, Mr Linh để tiến hành chứng thực tài khoản');
                }
                else { spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu'); }
            }
        })
    },
    save2: function (validate, fn) {
        var newDlg = $('#ThanhToanMgrthongTin-thongTin-dlgNew');
        var MoTa = $('.MoTa', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _MoTa = MoTa.val();
        var err = '';
        if (_MoTa == '') { err += 'Nhập thông tin tài khoản<br/>'; }
        if (err != '') { spbMsg.html(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: ThanhToanMgrthongTinFn.urlDefault().toString() + '&subAct=saveTaiKhoan',
            dataType: 'script',
            data: {
                'MoTa': _MoTa
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    ThanhToanMgrthongTinFn.clearform2();
                    if (typeof (fn) == 'function') { fn(); }
                }
                else { spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu'); }
            }
        })
    },
    edit1: function (s) {
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
            return false;
        }
        ThanhToanMgrthongTinFn.loadHtml(function () {
            var newDlg = $('#ThanhToanMgrthongTin-yeuCau-dlgNew');
            $(newDlg).dialog({
                title: 'Sửa',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        ThanhToanMgrthongTinFn.save1(false, function () {
                            ThanhToanMgrthongTinFn.clearform1();
                        });
                    },
                    'Lưu và đóng': function () {
                        ThanhToanMgrthongTinFn.save1(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    ThanhToanMgrthongTinFn.popfn();
                    adm.loading('Đang nạp dữ liệu');
                    $.ajax({
                        url: ThanhToanMgrthongTinFn.urlDefault().toString() + '&subAct=editSoDu',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (_dt) {
                            adm.loading(null);
                            var dt = eval(_dt);
                            var ID = $('.ID', newDlg);
                            var SoDu = $('.SoDu', newDlg);
                            var spbMsg = $('.admMsg', newDlg);
                            ID.val(dt.ID);
                            SoDu.val(dt.SoDu);
                            $(spbMsg).html('');
                        }
                    });
                }
            });
        });
    },
    edit2: function () {
        ThanhToanMgrthongTinFn.loadHtml(function () {
            var newDlg = $('#ThanhToanMgrthongTin-thongTin-dlgNew');
            $(newDlg).dialog({
                title: 'Thông tin thanh toán',
                width: 600,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        ThanhToanMgrthongTinFn.save2(false, function () {
                            ThanhToanMgrthongTinFn.clearform2();
                        });
                    },
                    'Lưu và đóng': function () {
                        ThanhToanMgrthongTinFn.save2(false, function () {
                            ThanhToanMgrthongTinFn.clearform2();
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    ThanhToanMgrthongTinFn.popfn();
                    adm.loading('Đang nạp dữ liệu');
                    $.ajax({
                        url: ThanhToanMgrthongTinFn.urlDefault().toString() + '&subAct=editTaiKhoan',
                        success: function (_dt) {
                            adm.loading(null);
                            var MoTa = $('.MoTa', newDlg);
                            var spbMsg = $('.admMsg', newDlg);
                            MoTa.val(_dt);
                            $(spbMsg).html('');
                        }
                    });
                }
            });
        });
    },
    popfn: function () {
        var newDlg = $('#ThanhToanMgrthongTin-yeuCau-dlgNew');
        var ID = $('.ID', newDlg);
        var SoDu = $('.SoDu', newDlg);
    },
    clearform1: function () {
        var newDlg = $('#ThanhToanMgrthongTin-yeuCau-dlgNew');
        var ID = $('.ID', newDlg);
        var SoDu = $('.SoDu', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        spbMsg.html('');
        $(ID).val('');
        $(SoDu).val('');
    },
    clearform2: function () {
        var newDlg = $('#ThanhToanMgrthongTin-thongTin-dlgNew');
        var MoTa = $('.MoTa', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        spbMsg.html('');
        $(MoTa).val('');
    },
    loadHtml: function (fn) {
        var dlg = $('#ThanhToanMgrthongTin-thongTin-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("seo.plugin.thanhToanMgr.thongTin.htm.htm")%>',
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
