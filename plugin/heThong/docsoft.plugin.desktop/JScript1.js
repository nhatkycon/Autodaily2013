var dvanBanDen = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.desktop.dVanBanDen, docsoft.plugin.desktop',
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Đang lấy dữ liệu văn bản');
        $('.sub-mdl').tabs();
        $('.dvanBanDenMdl-List').jqGrid({
            url: dvanBanDen.urlDefault + '&subAct=get&VB_Draff=0',
            datatype: 'json',
            height: 120,
            pager: false,
            colNames: ['ID', 'Số Đến', 'Ký hiệu'
            , 'Ngày VB', 'Trích yếu', 'Trích yếu giá trị'
            , 'Lãnh đạo'],
            colModel: [
            { name: 'Id', width: 1, key: true, hidden: true, sortable: false },
            { name: 'SoDen', width: 40, align: 'center' },
            { name: 'SoKyHieu', width: 40, align: 'center' },
            { name: 'NgayTrenVanBan', align: 'center', width: 65 },
            { name: 'TrichYeuShow', width: 240, sortable: false },
            { name: 'TrichYeu', width: 1, hidden: true },
            { name: 'LanhDao', width: 80, sortable: false },
        ],
            caption: 'Danh sách',
            autowidth: true,
            //multiselect: true,
            rowNum: 200,
            onSelectRow: function (rowid) {
                //var treedata = $("#dvanBanDenMdl-List").jqGrid('getRowData', rowid);
                //vanBanDen.getVanBan(treedata.Id);
            },
            loadComplete: function () {
                $('.ui-jqgrid-titlebar').hide();
                $('.sub-mdl').hide();
                adm.loading(null);

            }
        });
    },
    getVanBanNode: function (s) {
//        var treedata = $("#dvanBanDenMdl-List").jqGrid('getRowData', s);
        adm.regType(typeof (vanBanDen), 'docsoft.plugin.vb.vanBanDen.Class1, docsoft.plugin.vb.vanBanDen', function () {
            vanBanDen.getVanBanNode(s);
        });
    },
    xulySave: function (vb, validate, fn) {
        var newXuLyDlg = $('#dvanBanDenMdl-dlgXuly');
        var txtNoiDung = $('.NoiDung', newXuLyDlg);
        var addPnlDonVi = $('.vanbanXuLy-AddPanel-DonVi', newXuLyDlg);
        var addPnlMember = $('.vanbanXuLy-AddPanel-Member', newXuLyDlg);
        var addDonVi = true;
        var addMem = true;
        var addAll = false;
        var addNone = true;
        if ($(addPnlDonVi).is(':hidden')) {
            addDonVi = false;
        }
        if ($(addPnlMember).is(':hidden')) {
            addMem = false;
        }
        if (addDonVi && addMem) {
            addAll = true;
        }
        if (!addDonVi && !addMem) {
            addNone = true;
        }
        var noiDung = $(txtNoiDung).val();
        if (noiDung == '') {
            alert('Nhập nội dung');
            $(txtNoiDung).focus();
            return false;
        }
        var cidlist = '';
        if (addAll) {
            var txtDonVi = $('.DonViChuTri', addPnlDonVi);
            cidlist += $(txtDonVi).attr('_value') + ',1;';
            $.each($(addPnlDonVi).find('.adm-token-item'), function (i, item) {
                cidlist += $(item).attr('_value') + ',0;';
            });
        }
        if (addMem) {
            // pending...
        }
        else if (addDonVi) {
            var txtDonVi = $('.DonViChuTri', addPnlDonVi);
            cidlist += $(txtDonVi).attr('_value') + ',1;';
            $.each($(addPnlDonVi).find('.adm-token-item'), function (i, item) {
                cidlist += $(item).attr('_value') + ',0;';
            });
        }
        if (cidlist == '') {
            if (!addNone) {
                alert('Chọn Đơn vị/Cán bộ');
                return false;
            }
        }
        if (validate) {
            if (typeof (fn) == 'function') {
                fn();
            }
            return false;
        }
        workflowsfn.saveNode(vb, cidlist, noiDung, function (rs) {
            adm.tbao('Chuyển thành công', function () {
                $('#dvanBanDenMdl-dlgXuly').dialog('close');
            });
        }, false);
    }
}
dvanBanDen.loadgrid();