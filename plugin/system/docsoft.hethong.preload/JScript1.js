var preload = {
    login: function () {
        preload.showLogin(function (dt) {
            preload.setup(dt);
        });
    },
    loginDesktop: function (fn) {
        preload.showLogin(function () {
            document.location.reload();
        });
    },
    loginSmall: function (fn) {
        preload.showLogin(function (dt) {
            if (typeof (fn) == 'function') {
                fn(dt);
            }
        });
    },
    showLoginCreateUser: function (cq, fn, fn1) {
        preload.loadHtml(function () {
            var loginPnl = jQuery('#login-pnl');
            jQuery(loginPnl).dialog({
                title: 'Đăng nhập',
                modal: true,
                closeOnEscape: false,
                buttons: {
                    'Đăng nhập': function () {
                        preload.dologin(fn);
                    },
                    'Đăng ký': function () {
                        preload.creatUser(cq, fn1);
                    },
                    'Quên mật khẩu': function () {
                        preload.showRecover();
                    }
                },
                open: function () {
                    jQuery('.ui-dialog-titlebar-close').remove();
                    preload.poploginfn();
                }
            });
        });
    },
    creatUser: function (_cq, fn, fn1) {
        preload.loadHtml(function () {
            var newDlg = jQuery('#login-creatUser');
            jQuery(newDlg).dialog({
                title: 'Đăng ký',
                modal: true,
                closeOnEscape: false,
                buttons: {
                    'Đăng ký': function () {
                        //var cq = jQuery('#login-creatUser-cqId', newDlg);
                        var user = jQuery('#login-creatUser-user', newDlg);
                        var pwd = jQuery('#login-creatUser-pwd', newDlg);
                        var email = jQuery('#login-creatUser-email', newDlg);
                        var ten = jQuery('#login-creatUser-ten', newDlg);
                        //var _cq = cq.val();
                        var _user = user.val();
                        var _pwd = pwd.val();
                        var _email = email.val();
                        var _ten = ten.val();
                        var err = '';
                        if (_cq == '') { err += 'Cơ quan\n'; }
                        if (_user == '') { err += 'Tên đăng nhập\n'; }
                        if (_ten == '') { err += 'Tên\n'; }
                        if (_pwd == '') { err += 'Mật khẩu\n'; }
                        if (_email == '') { err += 'Tài khoản email\n'; }
                        if (err != '') {
                            alert('Lỗi\n' + err);
                            return false;
                        }
                        adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'subAct': 'register', 'u': _user, 'p': _pwd, 'email': _email, 'cq': _cq }, function (_dt) {
                            if (_dt == '1') {
                                alert('Bạn đã tạo tài khoản thành công');
                                jQuery(newDlg).dialog('close');
                                if (typeof (fn) == 'function') {
                                    fn();
                                }
                            }
                            else {
                                alert('Email hoặc tài khoản không hợp lệ');
                            }
                        });
                    },
                    'đóng lại': function () {
                        jQuery(newDlg).dialog('close');
                    }
                },
                open: function () {
                }
            });
        });
    },
    showLogin: function (fn) {
        preload.loadHtml(function () {
            var loginPnl = jQuery('#login-pnl');
            jQuery(loginPnl).dialog({
                title: 'Đăng nhập',
                width: 400,
                modal: true,
                closeOnEscape: false,
                buttons: {
                    'Đăng nhập': function () {
                        preload.dologin(fn);
                    },
                    'Quên mật khẩu': function () {
                        preload.showRecover();
                    }
                },
                open: function () {
                    //jQuery('.ui-dialog-titlebar-close').remove();
                    preload.poploginfn();
                }
            });
        });

    },
    showRecover: function () {
        var recoverPnl = jQuery('#login-recovery');
        jQuery(recoverPnl).dialog({
            title: 'Quên mật khẩu',
            modal: true,
            closeOnEscape: false,
            buttons: {
                'Gửi': function () {
                    var user = jQuery('#login-recovery-usr', recoverPnl);
                    var _user = user.val();
                    if (_user == '') { alert('Nhập username(tài khoản)'); return false; }
                    adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'subAct': 'recovery', 'u': _user }, function (_dt) {
                        if (_dt == '1') {
                            preload.showChangePass();
                        }
                        else {
                            alert('Email của bạn chưa có, vui lòng liên hệ quản trị hệ thống (Mr Linh: 094.670.9969)');
                        }
                    });
                },
                'Đóng lại': function () {
                    jQuery(recoverPnl).dialog('close');
                }
            },
            open: function () {
            }
        });
    },
    showChangePass: function () {
        var newDlg = jQuery('#login-changePass');
        jQuery(newDlg).dialog({
            title: 'Thay đổi mật khẩu',
            modal: true,
            closeOnEscape: false,
            buttons: {
                'Gửi': function () {
                    var code = jQuery('#login-changePass-code', newDlg);
                    var pwd = jQuery('#login-changePass-pwd', newDlg);
                    var user = jQuery('#login-recovery-usr', '#login-recovery');

                    var _code = code.val();
                    var _pwd = pwd.val();
                    var _user = user.val();
                    if (_code == '') { alert('Nhập mã xác nhận'); return false; }
                    if (_pwd == '') { alert('Nhập mật khẩu mới'); return false; }
                    if (_user == '') { alert('Nhập mật username (tài khoản)'); return false; }
                    adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'subAct': 'changePass', 'code': _code, 'p': _pwd, 'u': _user }, function (_dt) {
                        if (_dt == '1') {
                            alert('Bạn đã đổi mật khẩu thành công\nMật khẩu mới là: ' + _pwd);
                            jQuery(newDlg).dialog('close');
                            jQuery('#login-recovery').dialog('close');
                            setTimeout(function() {
                                document.location.reload();
                            }, 1000);
                        }
                        else {
                            alert('Mã xác nhận chưa hợp lệ, bạn có thể kiểm tra lại email \nVui lòng liên hệ quản trị hệ thống (Mr Linh: 094.670.9969');
                        }
                    });
                },
                'Quay lại': function () {
                    jQuery(newDlg).dialog('close');
                }
            },
            open: function () {
            }
        });
    },
    dologin: function (fn) {
        var loginPnl = jQuery('#login-pnl');
        var utxt = jQuery('#authentication-txtLogin', loginPnl);
        var ptxt = jQuery('#authentication-txtLogout', loginPnl);
        var rem = jQuery('#authentication-remember', loginPnl);
        var u = utxt.val();
        var p = ptxt.val();
        var r = jQuery(rem).is(':checked');
        if (u == '') {
            alert('Tên đăng nhập');
            utxt.focus();
            return false;
        }
        if (p == '') {
            alert('Mật khẩu');
            ptxt.focus();
            return false;
        }

        adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'u': u, 'p': p, 'r': r }, function (data) {
            if (data == '0') {
                alert('Tên và mật khẩu không hợp lệ');
            }
            else {
                jQuery(loginPnl).dialog('close');
                if (typeof (fn) == 'function') {
                    fn(data);
                }
            }
        });
    },
    poploginfn: function () {
        var loginPnl = jQuery('#login-pnl');
        var utxt = jQuery('#authentication-txtLogin', loginPnl);
        var ptxt = jQuery('#authentication-txtLogout', loginPnl);
        jQuery(utxt).focus(function () {
            jQuery(utxt).unbind('keypress').bind('keypress', function (evt) {
                if (evt.keyCode == 13) {
                    preload.dologin();
                }
            });
        });
        jQuery(ptxt).focus(function () {
            jQuery(ptxt).unbind('keypress').bind('keypress', function (evt) {
                if (evt.keyCode == 13) {
                    preload.dologin();
                }
            });
        });
    },
    logout: function () {
        adm.loadPlug('docsoft.plugin.authentication.Class1, docsoft.plugin.authentication', { 'subact': 'logout' }, function (data) {
            var l = document.location.href;
            if (l.indexOf('#').length != -1) {
                l = l.substr(0, l.indexOf('#'));
            }
            //document.location.href = l;
            document.location.href = '../../';
        });
    },
    openPop: function (url) {
        var win = window.open('lite.htm#conference.phongHopView.Class1, conference.phongHopView', 'newpopup', 'width=' + screen.width + ', height=' + screen.height + ', top=0, left=0,');
        win.focus();
    },
    setup: function (s) {
        var l = '<div id=\"adm-banner\" class=\"ui-layout-north ui-widget ui-widget-content\">';
        l += '<div id=\"adm-banner-left\">';
        l += '<a class=\"adm-usr-label\" href=\"javascript:;\">' + s + '</a><a href=\"javascript:preload.logout();\">Thoát</a></div>';
        l += '</div>';
        l += '<div id=\"LeftPane\" class=\"ui-layout-west ui-widget ui-widget-content\">';
        l += '<div id=\"LeftPanel-top\"></div>';
        l += '</div>';
        l += '<div id=\"RightPane\" class=\"ui-layout-center ui-helper-reset ui-widget-content\" ><div id=\"tabs\" class=\"jqgtabs\"><ul><li><a href=\"#desktopMdl\">Bàn làm việc</a></li></ul><div id=\"desktopMdl\" style=\"font-size:12px;\">';
        //l += '<a id=\"desk-openPop-btn\" href=\"javascript:;\" onclick=\"preload.openPop(\'lite.htm#conference.phongHopView.Class1, conference.phongHopView\')\" style=\"font-size:18pt; text-decoration:none;color:#000;\">Phòng hội thảo</a>';
        l += '</div></div></div><div id=\"global-dialog-alert\"></div>';
        jQuery('body').append(l);
        //                jQuery.getScript('http://phanmemthuyloi.vn/livezilla/server.php?request=track&output=jcrpt&nse=linhnx',function(){
        //                    jQuery('#LeftPane').prepend('<div style=\"text-align:center;width:160px;\"><a href=\"javascript:void(window.open(\'http://phanmemthuyloi.vn/livezilla/livezilla.php\',\'\',\'width=590,height=550,left=0,top=0,resizable=yes,menubar=no,location=no,status=yes,scrollbars=yes\'))\"><img src=\"http://phanmemthuyloi.vn/livezilla/image.php?id=03\" width=\"160\" border=\"0\" alt=\"LiveZilla Live Help\"></a></div><div id=\"livezilla_tracking\" style=\"display:none\"></div>');
        //                });

        var usr = $('.adm-usr-label');
        adm.loadPlug('docsoft.hethong.preload.Class1, docsoft.hethong.preload', { 'subAct': 'getGhLink' }, function (data) {
            var dt = eval(data);
            $('<a href=\"../../Gian-hang/vi-VN/a/' + dt.ID + '/\" target=\"_blank\">Gian hàng</a>').insertBefore(usr);
        });


        jQuery('body').layout({
            west__spacing_open: 2
            , north__spacing_open: 0
            , north__size: 100
            , west__size: 190
            , resizerClass: 'ui-state-default'
            , west__onresize: function (pane, jQueryPane) {
                //                jQuery("#LeftPanel-top").css('width', jQueryPane.innerWidth() - 2);
            }
            , center__onresize: function (pane, jQueryPane) {
                //alert('center h:' + jQueryPane.innerHeight() + ' w:' + jQueryPane.innerWidth());
                jQuery('.mdl-list').jqGrid('setGridWidth', jQueryPane.innerWidth() - 40);
                jQuery('.sub-mdl-list').css('width', jQueryPane.innerWidth() - 60);
                //                jQuery('.mdl-list, .sub-mdl-list').jqGrid('setGridHeight', (jQueryPane.innerHeight() / 2) - 90);
            }
            , north__onresize: function (pane, jQueryPane) {
                //alert('north h:' + jQueryPane.innerHeight() + ' w:' + jQueryPane.innerWidth());
            }
        });
        jQuery('#desk-openPop-btn').click();
        jQuery.jgrid.defaults = jQuery.extend(jQuery.jgrid.defaults, { loadui: "enable" });
        preload.loadMenu(function () {
            preload.loadDesk(function () {
                adm.live();
            });
            //adm.live();
        });
        //jQuery('#adm-banner-left').append('<select id=\"cssSwichter\"><option value=\"blitzer\">blitzer</option><option value=\"vader\">vader</option><option value=\"redmond\">redmond</option></select>');
        //        jQuery('#cssSwichter').change(function () {
        //            var _v = jQuery('#cssSwichter').children('option:selected').val();
        //            var _l = jQuery('link');
        //            jQuery(_l).attr('href', '../css/' + _v + '/admin.css');
        //        });
    },

    loadDesk: function (fn) {
        adm.loading('Nạp bàn làm việc');
        jQuery.ajax({
            url: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.plugManager.Class1, docsoft.plugin.plugManager&subAct=desk',
            success: function (dt) {
                adm.loading(null);
                var desk = jQuery('#desktopMdl');
                jQuery(desk).html('<div id=\"desktopMdl-Content\">' + dt + '</div>');
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    loadMenu: function (fn) {
        var maintab = jQuery('#tabs', '#RightPane').tabs({
            add: function (e, ui) {
                // append close thingy
                jQuery(ui.tab).parents('li:first')
                .append('<span class="ui-tabs-close ui-icon ui-icon-close" title="Close Tab"></span>')
                .find('span.ui-tabs-close')
                .show()
                .click(function () {
                    maintab.tabs('remove', jQuery('li', maintab).index(jQuery(this).parents('li:first')[0]));
                });
                maintab.tabs('select', '#' + ui.panel.id);
            }
        });
        adm.loading('Nạp danh mục');
        jQuery.ajax({
            url: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.plugManager.Class1, docsoft.plugin.plugManager&subAct=menu',
            success: function (dt) {
                adm.loading(null);
                var mnu = jQuery('#LeftPanel-top');
                jQuery(mnu).html(dt);
                jQuery(mnu).accordion({});
                if (typeof (fn) == 'function') {
                    fn();
                }
                jQuery('.mnu-item', mnu).unbind('click').click(function () {
                    var item = jQuery(this);
                    var _id = jQuery(item).attr('_fn_id');
                    var _ten = jQuery(item).attr('title');
                    var _url = jQuery(item).attr('_url');
                    var st = "#t" + _id;
                    jQuery('.mnu-item-selected').removeClass('mnu-item-selected');
                    jQuery(item).addClass('mnu-item-selected');
                    if (jQuery(st).html() != null) {
                        maintab.tabs('select', st);
                    } else {
                        maintab.tabs('add', st, _ten);
                        adm.loadPlug(_url, { 'fn_id': _id }, function (data) { jQuery(st, "#tabs").append(data); });
                    }
                });
            }
        });
    },
    loadmdl: function (_url, fn) {
        var mnu = jQuery('#LeftPanel-top');
        var st = "#t" + _id;
        var maintab = jQuery('#tabs', '#RightPane').tabs({
            add: function (e, ui) {
                jQuery(ui.tab).parents('li:first').append('<span class="ui-tabs-close ui-icon ui-icon-close" title="Close Tab"></span>').find('span.ui-tabs-close').click(function () {
                    maintab.tabs('remove', jQuery('li', maintab).index(jQuery(this).parents('li:first')[0]));
                });
                maintab.tabs('select', '#' + ui.panel.id);
            }
        });
        jQuery('.mnu-item-selected').removeClass('mnu-item-selected');
        var item = jQuery(mnu).find('[_url=\"' + _url + '\"]');
        var _id = jQuery(item).attr('_fn_id');
        var _ten = jQuery(item).attr('title');
        jQuery(item).addClass('mnu-item-selected');
        if (jQuery(st).html() != null) {
            maintab.tabs('select', st);
        } else {
            maintab.tabs('add', st, _ten);
            adm.loadPlug(_url, { 'fn_id': _id }, function (data) {
                jQuery(st, "#tabs").append(data);
                if (typeof (fn) == 'function') {
                    fn();
                }
            });
        }
    },
    loadHtml: function (fn) {
        var dlg = jQuery('#login-pnl');
        if (jQuery(dlg).length < 1) {
            adm.loading('Dựng form');
            jQuery.ajax({
                url: '<%=WebResource("docsoft.hethong.preload.login.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    jQuery('body').append(dt);
                    if (typeof (fn) == 'function') { fn(); }
                }
            });
        }
        else { if (typeof (fn) == 'function') { fn(); } }
    }
}