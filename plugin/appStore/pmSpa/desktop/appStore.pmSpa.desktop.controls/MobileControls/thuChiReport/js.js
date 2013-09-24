var thuChiViewFn = {
    urlDefault: function () { return domain + '/lib/admin/Default.aspx?&act=loadPlug&rqPlug=appStore.pmSpa.desktop.controls.MobileControls.thuChiReport.View,appStore.pmSpa.desktop.controls'; },
    EditForm: '#thuChiView-dlgNew',
    view: function (_id) {
        thuChiViewFn.loadHtml(function () {
            var newDlg = $(thuChiViewFn.EditForm);
            $(newDlg).dialog({
                title: 'Chi tiết',
                width: 300,
                modal: true,
                buttons: {
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                        thuChiViewFn.clearform();
                    }
                },
                beforeClose: function () {
                    thuChiViewFn.clearform();
                },
                open: function () {
                    common.styleButton();
                    thuChiViewFn.clearform();
                    $.ajax({
                        url: thuChiViewFn.urlDefault().toString(),
                        data: { 'subAct': 'edit', 'TC_ID': _id },
                        type: 'POST',
                        dataType: 'script',
                        success: function (_dt) {
                            var dt = eval(_dt);
                            var ID = $('.ID', newDlg);
                            ID.attr('draff', '0');
                            var ID = $('.ID', newDlg);
                            var NDTC_ID = $('.NDTC_ID', newDlg);
                            var SoPhieu = $('.SoPhieu', newDlg);
                            var SoTien = $('.SoTien', newDlg);
                            var Mota = $('.Mota', newDlg);
                            var NguoiTao = $('.NguoiTao', newDlg);
                            var NgayTao = $('.NgayTao', newDlg);
                            var LoaiQuy = $('.LoaiQuy', newDlg);
                            var P_ID = $('.P_ID', newDlg);
                            var Thu = $('.Thu', newDlg);

                            Thu.html(dt.Thu ? 'Người nộp' : 'Người nhận');
                            ID.val(dt.ID);
                            var value = new Date(dt.NgayTao);
                            NgayTao.html(value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear());
                            SoPhieu.html(dt.SoPhieu);
                            SoTien.html(adm.formatTienStr(dt.SoTien));
                            Mota.html(dt.Mota);
                            NguoiTao.html(dt.NguoiTao);
                            LoaiQuy.html(dt.LoaiQuy == 0 ? 'Tiền mặt' : 'Tài khoản');
                            NDTC_ID.html(dt.NDTC_Ten);
                            P_ID.html(dt.P_Ten);
                        }
                    });
                }
            });
        });
    },
    clearform: function () {
        var newDlg = $(thuChiViewFn.EditForm);
        var ID = $('.ID', newDlg);
        var NDTC_ID = $('.NDTC_ID', newDlg);
        var SoPhieu = $('.SoPhieu', newDlg);
        var SoTien = $('.SoTien', newDlg);
        var Mota = $('.Mota', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var LoaiQuy = $('.LoaiQuy', newDlg);
        var P_ID = $('.P_ID', newDlg);
        newDlg.find('span').html('');
    },
    loadHtml: function (fn) {
        var dlg = $(thuChiViewFn.EditForm);
        if ($(dlg).length < 1) {
            common.loading('Dựng form');
            $.ajax({
                url: '<%=WebResource("appStore.pmSpa.desktop.controls.TuVanView.html.htm")%>',
                success: function (dt) {
                    common.loading(null);
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