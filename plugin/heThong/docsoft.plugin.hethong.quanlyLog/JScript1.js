var quanlylog = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.hethong.quanlyLog.Class1, docsoft.plugin.hethong.quanlyLog',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#quanlylogmdl-List').jqGrid({
            url: quanlylog.urlDefault + '&subAct=get',
            height: 'auto',
            datatype: 'json',
            loadui: 'disable',
            colNames: ['ID', 'Loại Log', 'Thời gian', 'User', 'Nội dung', 'IP Truy cập'],
            colModel: [
            { name: 'ID', key: true, width: 30, sortable: true },
            { name: 'LOG_LLOG_ID', width: 30, resizable: true, sortable: true },
            { name: 'NgayTao', width: 80, sortable: true, align: "center" },
            { name: 'Username', width: 50, resizable: true, sortable: true },
            { name: 'RawUrl', width: 300, resizable: true, sortable: true },
            { name: 'RequestIp', width: 50, resizable: true, sortable: true },
        ],
            caption: 'Danh sách',
            autowidth: true,
            sortname: 'ID',
            sortorder: 'desc',
            rowNum: 50,
            rowList: [50, 100, 150, 200, 250, 300],
            pager: jQuery('#quanlylogmdl-List'),
            onSelectRow: function (rowid) {

            },
            loadComplete: function () {
                adm.loading(null);

            }
        });
        var head = $('#mdl-head');
        var txtthanhvien = $('.UserName', head);
        adm.watermarks(txtthanhvien, 'Lọc theo thành viên', function () {
        });
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.setAutocompleteCungDonVi(txtthanhvien, function (event, ui) {
                $(txtthanhvien).val(ui.item.label);
                $(txtthanhvien).attr('_value', ui.item.username);
                quanlylog.search();
            });
            $(txtthanhvien).unbind('click').click(function () {
                $(txtthanhvien).autocomplete('search', '');
            });
        });
    },
    search: function () {
        var timerSearch;
        var head = $('#mdl-head');
        var filterDM = $('.UserName', head);
        var searchTxt = $('.IPTruyCap', head);
        var q = filterDM.attr('_value');
        if (q == 'Tìm log') {
            q = '';
        }
        var dm = $(searchTxt).val();
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#quanlylogmdl-List').jqGrid('setGridParam', { url: quanlylog.urlDefault + "&subAct=get&UserName=" + q + "&IPTruyCap=" + dm }).trigger("reloadGrid");
        }, 500);
    }


}