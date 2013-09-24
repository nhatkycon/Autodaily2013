var dthoitiet = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.desktop.dThoiTiet, docsoft.plugin.desktop',
    setup: function () {
    },
    doidiadanh: function (diadanh) {
        $.ajax({
            url: dthoitiet.urlDefault + '&subAct=get',
            data: {
                    'diadanh': diadanh
            },
            success: function (_dt) {
                adm.loading(null);
                var dt = eval(_dt);
                var thoitiencontent = $('.DeskMdl-ThoiTietMdl-content');
                var img = $('.DeskMdl-ThoiTietMdl-Img', thoitiencontent).eq(0);
                var img1 = $('.DeskMdl-ThoiTietMdl-Img', thoitiencontent).eq(1);
                var img2 = $('.DeskMdl-ThoiTietMdl-Img2', thoitiencontent).eq(2);
                var img3 = $('.DeskMdl-ThoiTietMdl-Img3', thoitiencontent).eq(3);
                var img4 = $('.DeskMdl-ThoiTietMdl-Img4', thoitiencontent).eq(4);
                var img5 = $('.DeskMdl-ThoiTietMdl-Img5', thoitiencontent).eq(5);
                var detail = $('.DeskMdl-ThoiTietMdl-Item-Detail', thoitiencontent);
                alert(dt.AdImg);
                $(img).attr('src', dt.AdImg);
                $(img1).attr('src', dt.AdImg1);
                $(img2).attr('src', dt.AdImg2);
                $(img3).attr('src', dt.AdImg3);
                $(img4).attr('src', dt.AdImg4);
                $(img5).attr('src', dt.AdImg5);
                $(detail).html(dt.Weather)
            }
        });

    }
}