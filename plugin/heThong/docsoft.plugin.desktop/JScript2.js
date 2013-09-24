var UserOnline = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.desktop.UserOnline, docsoft.plugin.desktop',
    setup: function () {
    },
    loadgrid: function () {
        var sobanghi = $('#userOnlineMdl-SoBanGhi').val();
        adm.loading('Đang lấy dữ liệu');
        $('.userOnlineMdl-List').jqGrid({
            url: UserOnline.urlDefault + '&subAct=get&sobanghi='+sobanghi,
            datatype: 'json',
            height: 120,
            pager: false,
            colNames: ['Tên Cơ Quan', 'Số người Online'],
            colModel: [
            { name: 'Username', sortable: false },
            { name: 'Loai', width: 80, align: 'right', sortable: false },
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
                adm.loading(null);
            }
        });
    }
}
UserOnline.loadgrid();