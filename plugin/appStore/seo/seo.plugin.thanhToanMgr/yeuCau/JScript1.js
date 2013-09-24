var ThanhToanMgryeuCauFn = {
    urlDefault: function () {
        return adm.urlDefault + '&act=loadPlug&rqPlug=seo.plugin.thanhToanMgr.yeuCau.Class1, seo.plugin.thanhToanMgr';
    },
    setup: function () {
    },
    loadgrid: function () {
        adm.styleButton();
        adm.loading('Lấy dữ liệu');
        $('#ThanhToanMgryeuCau-List').jqGrid({
            url: ThanhToanMgryeuCauFn.urlDefault().toString() + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            colNames: ['ID','Tài khoản' ,'Số tiền', 'Ngày'],
            colModel: [
                { name: 'ID', key: true, sortable: true, hidden: true },
                { name: 'NguoiYeuCau', width: 40, resizable: true, sortable: true },
                { name: 'SoDu', width: 40, sortable: true, align: "center" },
                { name: 'NgayTao', width: 20, resizable: true, sortable: true }
            ],
            caption: 'Yêu cầu thanh toán',
            autowidth: true,
            sortname: 'ID',
            sortorder: 'desc',
            multiselect: true,
            multiboxonly: true,
            onSelectRow: function (rowid) {
                //var treedata = $("#ThanhToanMgryeuCau-List").jqGrid('getRowData', rowid);
                //ThanhToanMgryeuCauFn.changeGrid(treedata.ID, treedata.Ten);
            },
            rowNum: 50,
            rowList: [50, 100, 150, 500],
            pager: jQuery('#ThanhToanMgryeuCau-Pager'),
            loadComplete: function () {
                adm.loading(null);
            }
        });
    },
    duyet: function (ok) {
        var s = '';
        s = $('#ThanhToanMgryeuCau-List').jqGrid('getGridParam', 'selarrrow').toString();
        if (s == '') {
            alert('Chọn yêu cầu');
            return false;
        }
        $.ajax({
            url: ThanhToanMgryeuCauFn.urlDefault().toString() + '&subAct=duyet',
            dataType: 'script',
            data: {
                'ID': s,
                'Khoa': ok
            },
            success: function (dt) {
                $("#ThanhToanMgryeuCau-List").trigger('reloadGrid');
            }
        });
    },
    loadHtml: function (fn) {
        var dlg = $('#ThanhToanMgryeuCau-yeuCau-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("seo.plugin.thanhToanMgr.yeuCau.htm.htm")%>',
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
