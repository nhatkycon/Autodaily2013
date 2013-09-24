qllienhefn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.QuanLyLienHe.Class1, cnn.plugin.QuanLyLienHe',
    setup: function () {

    },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang tải dữ liệu danh sách liên hệ');
        $('#lienhemdl-List').jqGrid({
            url: qllienhefn.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Tên', 'Địa chỉ', 'Công ty', 'Email', 'Điện thoại', 'Skype', 'Yahoo messenger', 'Website', 'Active'],
            colModel: [
            { name: 'ID', key: true, sortable: true, hidden: true },
            { name: 'Ten', width: 400, resizable: true, sortable: true, align: "left" },
            { name: 'DiaChi', width: 350, resizable: true, sortable: true, align: "center" },
            { name: 'CongTy', width: 300, resizable: true, sortable: true, align: "center" },
            { name: 'Email', width: 300, resizable: true, sortable: true, align: "left" },
            { name: 'DienThoai', width: 200, resizable: true, sortable: true, align: "left" },
            { name: 'Skype', width: 300, resizable: true, sortable: true, align: "center" },
            { name: 'Yahoo messenger', width: 300, resizable: true, sortable: true, align: "left" },
            { name: 'Website', width: 300, resizable: true, sortable: true, align: "left" },
            { name: 'Active', width: 100, resizable: true, sortable: true, align: "center", formatter: 'checkbox' },
            ],
            caption: 'Danh sách liên hệ',
            autowidth: true,
            sortname: 'ID',            
            sortorder: 'asc',
            onSelectRow: function (rowid) {
                var treedata = $('#lienhemdl-List').jqGrid('getRowData', rowid);
            },
            rowNum: 5,
            rowList: [5, 10, 15, 20, 25, 30],
            pager: jQuery('#lienhePager'),
            loadComplete: function () {
                adm.loading(null);
            }
        });

        var searchTxt = $('.mdl-head-search-lienhe');
        $('.mdl-head-search-lienhe').keyup(function () {
            var txtsearch = $('.mdl-head-search-lienhe').val();
            qllienhefn.search();
        });
        adm.watermark(searchTxt, 'Tìm kiếm liên hệ', function () {
            $(searchTxt).val('');
            qllienhefn.search();

        });


    },


    search: function () {
        var timerSearch;
        var filterPS = $('.mdl-head-search-lienhe');
        var q = filterPS.val();
        var ldm = $(filterPS).attr('_value');
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#lienhemdl-List').jqGrid('setGridParam', { url: qllienhefn.urlDefault + "&subAct=get&q=" + q }).trigger("reloadGrid");
        }, 500);
    },
    add: function () {
        qllienhefn.loadHtml(function () {
            var newDlg = $('#LHmdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 400,
                modal: true,
                buttons: {
                    'Lưu': function () {
                        qllienhefn.save();

                    },
                    'Lưu và đóng': function () {
                        qllienhefn.save(false, function () {
                            $(newDlg).dialog('close');
                        });
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    qllienhefn.clearform();

                }
            });
        });
    },

    save: function (validate, fn) {
        var newDlg = $('#LHmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var id = $(txtID).val();
        var txtTen = $('.Ten', newDlg);
        var ten = $(txtTen).val();
        var txtDiaChi = $('.DiaChi', newDlg);
        var diachi = $(txtDiaChi).val();
        var txtCongTy = $('.CongTy', newDlg);
        var congty = $(txtCongTy).val();

        var txtEmail = $('.Email', newDlg);
        var email = $(txtEmail).val();
        var txtDienThoai = $('.DienThoai', newDlg);
        var dienthoai = $(txtDienThoai).val();
        var txtSkype = $('.Skype', newDlg);
        var sky = $(txtSkype).val();
        var txtYm = $('.Ym', newDlg);
        var ym = $(txtYm).val();
        var txtWeb = $('.Website', newDlg);
        var web = $(txtWeb).val();
        var ckbActive = $('.Active', newDlg);
        var active = $(ckbActive).is(':checked');
        var spbMsg = $('.admMsg', newDlg);
        var err = '';
        if (ten == '')
            err += 'Nhập Tên <br/>';
        if (diachi == '')
            err += 'Nhập địa chỉ <br/>';
        if (qllienhefn.valiNumberPhone(dienthoai) == false || dienthoai == '')
            err += 'Nhập số điện thoại, chỉ cho phép nhập số <br/>';
        if (qllienhefn.valiEmail(email) == false)
            err += 'Nhập không đúng định dạng Email<br/>';
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

        adm.loading('Đang lưu dữ liệu')
        qllienhefn.clearform();
        $.ajax({
            url: qllienhefn.urlDefault + '&subAct=save',
            dataType: 'script',
            data: {

                'ID': id,
                'Ten': ten,
                'DiaChi': diachi,
                'CongTy': congty,
                'Email': email,
                'DienThoai': dienthoai,
                'Skype': sky,
                'Ym': ym,
                'Website': web,
                'Active': active
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    jQuery('#lienhemdl-List').trigger('reloadGrid');
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
                else {

                    adm.loading('Lỗi nhập dữ liệu')
                }
            }
        })
    },

    clearform: function () {
        var newDlg = $('#LHmdl-dlgNew');
        var txtID = $('.ID', newDlg);
        var txtTen = $('.Ten', newDlg);
        var txtDiaChi = $('.DiaChi', newDlg);
        var txtDienThoai = $('.DienThoai', newDlg);
        var txtCongTy = $('.CongTy', newDlg);
        var txtEmail = $('.Email', newDlg);
        var txtSkype = $('.Skype', newDlg);
        var txtYm = $('.Ym', newDlg);
        var txtWebsite = $('.Website', newDlg);
        var ckbActive = $('.Active', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        spbMsg.html('');
        $(txtID).val('');
        $(txtTen).val('');
        $(txtDiaChi).val('');
        $(txtDienThoai).val('');
        $(txtEmail).val('');
        $(txtCongTy).val('');
        $(txtSkype).val('');
        $(txtWebsite).val('');
        $(txtYm).val('');
        $(ckbActive).removeAttr('checked');
    },
    del: function () {
        var s = '';
        if (jQuery("#lienhemdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#lienhemdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        //s = jQuery("#lienhemdl-List").jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') alert('Hãy chọn mẩu tin để xóa!');
        else {
            if (s.indexOf(',') != -1) alert('Chọn một mẩu tin');
            else {
                if (confirm('Bạn có muốn chắc chắn muốn xóa không?')) {
                    $.ajax({
                        url: qllienhefn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            'ID': s
                        },
                        success: function (dt) {
                            jQuery("#lienhemdl-List").trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },

    edit: function () {
        var s = '';
        if (jQuery("#lienhemdl-List").jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery("#lienhemdl-List").jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Hãy chọn mẩu tin để sửa.')
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                qllienhefn.loadHtml(function () {
                    var newDlg = $('#LHmdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 400,
                        modal: true,
                        buttons: {
                            'Lưu': function () {
                                qllienhefn.save();
                            },
                            'Lưu và đóng': function () {
                                qllienhefn.save(false, function () {
                                    $(newDlg).dialog('close');
                                });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            $.ajax({
                                url: qllienhefn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                data: {
                                    'ID': s
                                },
                                success: function (dt) {
                                    adm.loading(null);
                                    var data = eval(dt);
                                    var txtID = $('.ID', newDlg);
                                    $(txtID).val(data.ID);
                                    var txtTen = $('.Ten', newDlg);
                                    $(txtTen).val(data.Ten);
                                    var txtDiaChi = $('.DiaChi', newDlg);
                                    $(txtDiaChi).val(data.DiaChi);
                                    var txtCongTy = $('.CongTy', newDlg);
                                    $(txtCongTy).val(data.CongTy);
                                    var txtEmail = $('.Email', newDlg);
                                    $(txtEmail).val(data.Email);
                                    var txtDienThoai = $('.DienThoai', newDlg);
                                    $(txtDienThoai).val(data.Mobile)
                                    var txtSkype = $('.Skype', newDlg);
                                    $(txtSkype).val(data.Skype);
                                    var txtYm = $('.Ym', newDlg);
                                    $(txtYm).val(data.Ym);
                                    var txtWebsite = $('.Website', newDlg);
                                    $(txtWebsite).val(data.Website);
                                    var ckbActive = $('.Active', newDlg);
                                    if (data.Active) {

                                        $(ckbActive).attr('checked', 'checked');
                                    }
                                    else {
                                        $(ckbActive).removeAttr('checked');
                                    }

                                    var spInfo = $('.admInfo', newDlg);
                                    var spbMsg = $('.admMsg', newDlg);
                                    $(spbMsg).html('');

                                }
                            });
                        }
                    });
                });
            }

        }
    },

    valiNumberPhone: function (number) {
        var status = false;
        var numberPRegEx = /(^[\d]*[-]*$)|(^[-]*[0-9]*$)|(^[0-9]*[-]*[0-9]*$)/;
        if (number.search(numberPRegEx) == -1) {
            status = false;
        }
        else {
            status = true;
        }
        return status;
    },
    valiEmail: function (email) {
        var status = false;
        var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
        if (emailRegEx.test(email))
            status = true;
        return status;
    },
    loadHtml: function (fn) {
        var dlg = $('#LHmdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng form');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.QuanLyLienHe.htm.htm")%>',
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

