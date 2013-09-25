var autofn = {
    Setup: function() {
        autofn.GameAdminDanhSachThem();
        autofn.GameAdminDanhSachFn();
    }
    , GameAdminDanhSachThem: function () {
        var pnl = $('.GameThemPnl');
        var GameList = $('.GameList');
        var TenEl = pnl.find('.Ten');
        var ThuTuEl = pnl.find('.ThuTu');
        var btn = pnl.find('button');
        
        btn.click(function () {
            var Ten = TenEl.val();
            var ThuTu = ThuTuEl.val();
            if (Ten == '') {
                alert('Nhập Tên! Guy');
                return;
            }
            if (ThuTu == '')
                ThuTu = '0';
            $.ajax({
                url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                data: {
                    subAct: 'addGame',
                    Ten: Ten,
                    ThuTu: ThuTu
                },
                success: function (dt) {
                    TenEl.val('');
                    ThuTuEl.val('');
                    var item = $(dt).prependTo(GameList);
                    item.addClass('animated bounceInDown');
                    setTimeout(function () {
                        item.removeClass('animated bounceInDown');
                    }, 1000);
                }
            });
        });
    }
    , GameAdminDanhSachFn: function () {
        var GameList = $('.GameList');
        GameList.on('click', '.edit', function () {
            var item = $(this);
            var id = item.attr('data-id');
            var pitem = item.parent().parent();
            var editPnl = pitem.find('.editPnl');
            editPnl.html('Loading...');
            $.ajax({
                url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                data: {
                    subAct: 'editGame',
                    ID: id
                },
                success: function (_dt) {
                    var dt = eval(_dt);
                    editPnl.html('');
                    var GameItem = $('#GameItem').tmpl(dt).prependTo(editPnl);
                }
            });
        });
        
        GameList.on('click', '.cancelBtn', function () {
            var item = $(this);
            item.parent().parent().html('').hide();
        });

        GameList.on('click', '.saveBtn', function () {
            var item = $(this);
            var pitem = item.parent().parent();
            var TenEl = pitem.find('.Ten');
            var ThuTuEl = pitem.find('.ThuTu');
            var id = item.attr('data-id');
            var Ten = TenEl.val();
            var ThuTu = ThuTuEl.val();
            if (Ten == '') {
                alert('Nhập Tên! Guy');
                return;
            }
            if (ThuTu == '')
                ThuTu = '0';
            var TenLbl =  pitem.parent().find('.view').find('.Ten');
            TenLbl.html(Ten);
            $.ajax({
                url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                data: {
                    subAct: 'saveGame',
                    ID: id,
                    Ten: Ten,
                    ThuTu: ThuTu
                },
                success: function (dt) {
                    alert('Lưu thành công');
                    pitem.html('');
                }
            });
        });

        GameList.on('click', '.remove', function () {
            var item = $(this);
            var con = confirm('Bạn có muốn xóa bỏ không? Nghiêm túc đó!!!');
            if(con) {
                $.ajax({
                    url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
                    data: {
                        subAct: 'removeGame',
                        ID: item.attr('data-id')
                    },
                    success: function (dt) {
                        var pitem = item.parent().parent();
                        pitem.addClass('animated bounceOutRight');
                        setTimeout(function () {
                            pitem.remove();
                        }, 500);
                    }
                });
            }
        });
    }
};

$(function() {
    autofn.Setup();
});