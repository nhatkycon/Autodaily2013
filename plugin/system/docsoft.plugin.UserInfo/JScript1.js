var userInfoFn = {
    url: function () {
        return '';
    },
    setup:function() {

    },
    save: function () {
        var pwd1 = $('.oldPwd', '#userInfoDlg');
        var pwd2 = $('.newPwd', '#userInfoDlg');
        var _pwd1 = pwd1.val();
        var _pwd2 = pwd2.val();
        var err = '';
        if (_pwd1 == '') {
            err += '\nNhập mật khẩu cũ';
        }
        if (_pwd2 == '') {
            err += '\nNhập mật khẩu mới';
        }
        if (err != '') {
            alert('Lỗi\n' + err);
            return false;
        }
        adm.loadPlug('docsoft.plugin.UserInfo.Class1, docsoft.plugin.UserInfo'
        , { 'subAct': 'changePass', 'pwd1': _pwd1, 'pwd2': _pwd2 }, function (_dt) {
            if (_dt == '1') {
                alert('Bạn đã đổi mật khẩu thành công');
            }
            else {
                alert('Mật khẩu cũ chưa hợp lệ, vui lòng thử lại');
            }
        });
    }
}