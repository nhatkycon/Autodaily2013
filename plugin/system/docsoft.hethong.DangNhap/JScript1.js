var DangNhap = {

    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.hethong.DangNhap.Class1, docsoft.hethong.DangNhap'; },
    login_fe: function (Ma) {
        var login_fePnl = jQuery('#login_fe_pnl');

        if (jQuery(login_fePnl).length < 1) {
            adm.loading('Chứng thực');
            jQuery.ajax({
                url: '<%=WebResource("docsoft.hethong.DangNhap.login.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    jQuery('body').append(dt);
                    DangNhap.HoTro();
                    DangNhap.Gettitle(Ma, function () {

                        DangNhap.showlogin_fe();

                    });
                }
            });
        }
        else {
            DangNhap.HoTro();
            DangNhap.Gettitle(Ma, function () {

                DangNhap.showlogin_fe();

            });

        }


    },
    Gettitle: function (Ma_DM, fn) {

        var newDlg = jQuery('#login_fe_pnl');

        var txtTieuDeHD = jQuery('.title-huong-dan-dang-ky', newDlg);
        var titleDialog = jQuery('.titleDialog', newDlg);
        adm.loading('Đang gửi liên hệ');
        jQuery.ajax({
            url: DangNhap.urlDefault().toString() + '&subAct=dangky_home',
            dataType: 'script',
            data: {
                'Ma': Ma_DM
            },
            success: function (_dt) {
                var dt = eval(_dt);
                adm.loading(null);
                titleDialog.val(dt.Ten);
                //newDlg.attr('name',dt.Ten);
                txtTieuDeHD.html(dt.Description);
                //title = dt.Ten;
                // alert('Bạn đã gửi liên hệ thành công');
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
        });
    },
    HoTro: function () {

        var newDlg = jQuery('#login_fe_pnl');
        var HoTroDanhMuc = jQuery('.LienHe-DanhMuc-dk', newDlg);
        // alert("fsdfs");
        adm.loading('Đang gửi liên hệ');
        jQuery.ajax({
            url: DangNhap.urlDefault().toString() + '&subAct=Ho_tro_khach_hang',
            dataType: 'script',

            success: function (_dt) {
                var dt = eval(_dt);
                //console.log(dt);
                adm.loading(null);
                HoTroDanhMuc.html('');
                jQuery.each(dt, function (i, item) {
                    //alert(item.Ten);
                    var src = 'http://opi.yahoo.com/online?u=' + item.GiaTri + '&amp;m=g&amp;t=1';
                    HoTroDanhMuc.append('<div class="item-dk-trangchu"><br/><b>' + item.Ten + '</b>' + '<br/>' + '<a href="ymsgr:sendIM?' + item.GiaTri + '"><img border="0" src="' + src + '" alt="Hỗ trợ trực tuyến"></a><br />' + 'Mobile:<span style="color:red;"> ' + item.KyHieu + '</span><br/></div>');
                    //console.log(item.Ten);
                }
                               );
                //console.log(dt.Ten);
                //                jQuery.each(dt, function (i, item) {
                //                    item.Ten;
                //                });
                //title = dt.Ten;
                // alert('Bạn đã gửi liên hệ thành công');

            }
        });
    },
    showlogin_fe: function () {
        var login_fePnl = jQuery('#login_fe_pnl');
        var titleDialog = jQuery('.titleDialog', login_fePnl)
        //alert(titleDialog.val());
        jQuery(login_fePnl).dialog({
            title: titleDialog.val(),
            width: 730,
            height: 500,
            modal: true,
            buttons: {
                'Đóng': function () {
                    jQuery(login_fePnl).dialog('close');
                }
            },
            open: function () {
                jQuery('.ui-dialog-title').html(titleDialog.val());

                jQuery('.ui-dialog-titlebar-close').remove();
                DangNhap.poplogin_fefn();
            }
        });
    },
    showRecover: function () {
      //  alert('aa');
        var recoverPnl = jQuery('#login_fe-recovery');
        jQuery(recoverPnl).dialog({
            title: 'Quên mật khẩu',
            modal: true,
            closeOnEscape: false,
            buttons: {
                'Đóng lại': function () {
                    jQuery(recoverPnl).dialog('close');
                }
            },
            open: function () {
            }
        });
    },
    dologin_fe: function () {
        var login_fePnl = jQuery('#login_fe_pnl');
        var utxt = jQuery('.home-regPanel-email-fe', login_fePnl);
        var ptxt = jQuery('.home-regPanel-pwd-fe', login_fePnl);
        var rem = jQuery('.home-regPanel-rem-fe', login_fePnl);
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

        jQuery.ajax({
            url: '.plugin?ref=' + Math.random(),
            data: { 'u': u, 'p': p, 'r': r, 'act': 'loadPlug', 'rqPlug': 'docsoft.plugin.authentication.Class1, docsoft.plugin.authentication' },
            success: function (data) {
                if (data == '0') { alert('Tên và mật khẩu không hợp lệ'); }
                else {
                    document.location.href = domain + '/lib/admin/';
                }
            }
        });
    },
    poplogin_fefn: function () {
        var login_fePnl = jQuery('#login_fe_pnl');
        var utxt = jQuery('.home-regPanel-email-fe');
        var ptxt = jQuery('.home-regPanel-pwd-fe');
        //        var utxt = jQuery('#authentication-txtlogin_fe', login_fePnl);
        //        var ptxt = jQuery('#authentication-txtLogout', login_fePnl);
        jQuery(utxt).focus(function () {
            jQuery(utxt).unbind('keypress').bind('keypress', function (evt) {
                if (evt.keyCode == 13) {

                    DangNhap.dologin_fe();
                }
            });
        });
        jQuery(ptxt).focus(function () {
            jQuery(ptxt).unbind('keypress').bind('keypress', function (evt) {
                if (evt.keyCode == 13) {
                    DangNhap.dologin_fe();
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
            document.location.href = l;
        });
    },
    setup: function (s) {
        var l = '<div id=\"adm-banner\" class=\"ui-layout-north ui-widget ui-widget-content\">';
        l += '<div id=\"adm-banner-left\">';
        l += '<a href=\"javascript:;\">' + s + '</a><a _resource=\"admin.system.label.logout\" href=\"javascript:DangNhap.logout();\">Thoát</a></div>';
        l += '</div>';
        l += '<div id=\"LeftPane\" class=\"ui-layout-west ui-widget ui-widget-content\">';
        l += '<div id=\"LeftPanel-top\"></div>';
        l += '<div onclick=\"adm.viewClip();\" class=\"ui-widget ui-widget-content ui-corner-all\" id=\"LeftPanel-bot\"></div>';
        l += '</div>';
        l += '<div id=\"RightPane\" class=\"ui-layout-center ui-helper-reset ui-widget-content\" ><div id=\"tabs\" class=\"jqgtabs\"><ul><li><a href=\"#desktopMdl\">Bàn làm việc</a></li></ul><div id=\"desktopMdl\" style=\"font-size:12px;\"></div></div></div><div id=\"global-dialog-alert\"></div>';
        jQuery('body').append(l);
        //                jQuery.getScript('http://phanmemthuyloi.vn/livezilla/server.php?request=track&output=jcrpt&nse=linhnx',function(){
        //                    jQuery('#LeftPane').prepend('<div style=\"text-align:center;width:160px;\"><a href=\"javascript:void(window.open(\'http://phanmemthuyloi.vn/livezilla/livezilla.php\',\'\',\'width=590,height=550,left=0,top=0,resizable=yes,menubar=no,location=no,status=yes,scrollbars=yes\'))\"><img src=\"http://phanmemthuyloi.vn/livezilla/image.php?id=03\" width=\"160\" border=\"0\" alt=\"LiveZilla Live Help\"></a></div><div id=\"livezilla_tracking\" style=\"display:none\"></div>');
        //                });
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
                jQuery('.mdl-list, .sub-mdl-list').jqGrid('setGridHeight', (jQueryPane.innerHeight() / 2) - 90);
            }
            , north__onresize: function (pane, jQueryPane) {
                //alert('north h:' + jQueryPane.innerHeight() + ' w:' + jQueryPane.innerWidth());
            }
        });
        jQuery.jgrid.defaults = jQuery.extend(jQuery.jgrid.defaults, { loadui: "enable" });
        DangNhap.loadMenu(function () {
            DangNhap.realtime();
            //            DangNhap.loadDesk(function () {
            //                adm.live();
            //            });
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
                        adm.loadPlug(_url, { 'fn_id': _id }, function (data) {
                            jQuery(st, "#tabs").append(data);
                        });
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
    homeLogin: function () {
        var btn = jQuery('.home-regPanel-loginBtn-fe');
        if (jQuery(btn).length == 0) return false;
        btn.click(function () {
            var Email = jQuery('.home-regPanel-email-fe');
            var Pwd = jQuery('.home-regPanel-pwd-fe');
            var Re = jQuery('.home-regPanel-rem-fe');
            var _u = Email.val();
            var _pwd = Pwd.val();
            var _r = Re.is(':checked');
            if (_u == '' || _pwd == '') { alert('Bạn cần nhập thông tin'); return false; }
            jQuery.ajax({
                url: '.plugin?ref=' + Math.random(),
                data: { 'u': _u, 'p': _pwd, 'r': _r, 'act': 'loadPlug', 'rqPlug': 'docsoft.plugin.authentication.Class1, docsoft.plugin.authentication' },
                success: function (data) {
                    if (data == '0') { alert('Tên và mật khẩu không hợp lệ'); }
                    else {
                        document.location.href = domain + '/lib/admin/';
                    }
                }
            });
        });
    },
    closedialog: function () {
        var login_fePnl = jQuery('#login_fe_pnl');
        var btn = jQuery('.home-regPanel-closeBtn-fe');
        if (jQuery(btn).length == 0) return false;
        btn.click(function () {
            jQuery(login_fePnl).dialog('close');
        });
    }
    ,
    realtime: function () {


        adm.regType(typeof (tinnhanpopupObj), 'cnn.plugin.popUp.Class1, cnn.plugin.popUp', function () {
            // alert('aaaaaaaa');
            // tinnhanpopupObj.add();
            //            jQuery.ajax({ url: adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.popUp.Class1, cnn.plugin.popUp',
            //            dataType: 'script',
            //            success: function (_dt) {
            ////               tinnhanpopupObj.add();
            //                     
            //                        
            //            }});
        });


    }
}