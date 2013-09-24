var ThanhToanMgrdaThanhToanFn = {
    urlDefault: function () {
        return adm.urlDefault + '&act=loadPlug&rqPlug=seo.plugin.thanhToanMgr.daThanhToan.Class1, seo.plugin.thanhToanMgr';
    },
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Lấy dữ liệu');
        $('#ThanhToanMgrdaThanhToan-List').jqGrid({
            url: ThanhToanMgrdaThanhToanFn.urlDefault().toString() + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            colNames: ['ID','Tài khoản' ,'Số tiền', 'Ngày yêu cầu','Ngày duyệt'],
            colModel: [
                { name: 'ID', key: true, sortable: true, hidden: true },
                { name: 'NguoiYeuCau', width: 40, resizable: true, sortable: true },
                { name: 'SoDu', width: 40, sortable: true, align: "center" },
                { name: 'NgayTao', width: 20, resizable: true, sortable: true },
                { name: 'NgayChuyenTien', width: 20, resizable: true, sortable: true }
            ],
            caption: 'Thanh toán đã duyệt',
            autowidth: true,
            sortname: 'ID',
            sortorder: 'desc',
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) {
                //var treedata = $("#ThanhToanMgrdaThanhToan-List").jqGrid('getRowData', rowid);
                //ThanhToanMgrdaThanhToanFn.changeGrid(treedata.ID, treedata.Ten);
            },
            rowNum: 50,
            rowList: [50, 100, 150, 500],
            pager: jQuery('#ThanhToanMgrdaThanhToan-Pager'),
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    duyet: function (ok) {
        var s = '';
        s = $('#ThanhToanMgrdaThanhToan-List').jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn yêu cầu');
            return false;
        }
        $.ajax({
            url: ThanhToanMgrdaThanhToanFn.urlDefault().toString() + '&subAct=duyet',
            dataType: 'script',
            data: {
                'ID': s,
                'Khoa': ok
            },
            success: function (dt) {
                $("#ThanhToanMgrdaThanhToan-List").trigger('reloadGrid');
            }
        });
    },
    loadHtml: function (fn) {
        var dlg = $('#ThanhToanMgrdaThanhToan-daThanhToan-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("seo.plugin.thanhToanMgr.daThanhToan.htm.htm")%>',
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
