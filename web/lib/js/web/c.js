var _cache = {}, _lastXhr, ajaxBusy, ajaxTimer;
$(function () {
    common.setup();
    common.scrollMsg();
    
});
function FormatDateTimeJson(jsonDate) {
    var value = new Date(jsonDate);
    return value.getHours() + ':' + (value.getMinutes() == 0 ? "00" : value.getMinutes()) + ' ' + value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear();
}
function FormatDateJson(jsonDate) {
    var value = new Date(jsonDate);
    return value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear();
}
function formatMoney(_num) {
    if (_num == '') {
        return 0;
    }
    var num = parseInt(_num);
    var p = num.toFixed(2).split(".");
    return p[0].split("").reverse().reduce(function (acc, num, i, orig) {
        return num + (i && !(i % 3) ? "," : "") + acc;
    }, "");
}
var common = {
    guid:function () {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
    , imgSize: function (_Avatar, size) {
        if (_Avatar == null) return 'avatar.gif';
        if (_Avatar.length == 0) return 'avatar.gif';
        var mime = _Avatar.substr(_Avatar.lastIndexOf('.'));
        var ten = _Avatar.substr(0, _Avatar.lastIndexOf('.'));
        _Avatar = ten + size + mime;
        return _Avatar;
    },
    formatTien: function (obj) {
        common.regJPlugin(jQuery().formatCurrency, 'lib/js/jquery.formatCurrency-1.4.0.min.js', function () {
            // Format while typing & warn on decimals entered, no cents
            obj.formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: 0, symbol: '' });
            obj.blur(function () {
                obj.html(null);
                $(this).formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: 0, symbol: '' });
            })
			.keyup(function (e) {
			    var e = window.event || e;
			    var keyUnicode = e.charCode || e.keyCode;
			    if (e !== undefined) {
			        switch (keyUnicode) {
			            case 16: break; // Shift
			            case 27: this.value = ''; break; // Esc: clear entry
			            case 35: break; // End
			            case 36: break; // Home
			            case 37: break; // cursor left
			            case 38: break; // cursor up
			            case 39: break; // cursor right
			            case 40: break; // cursor down
			            case 78: break; // N (Opera 9.63+ maps the "." from the number key section to the "N" key too!) (See: http://unixpapa.com/js/key.html search for ". Del")
			            case 110: break; // . number block (Opera 9.63+ maps the "." from the number block to the "N" key (78) !!!)
			            case 190: break; // .
			            default: $(this).formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: -1, eventOnDecimalsEntered: true, symbol: '' });
			        }
			    }
			})
			.bind('decimalsEntered', function (e, cents) {
			    //var errorMsg = 'Please do not enter any cents (0.' + cents + ')';
			    //$('#formatWhileTypingAndWarnOnDecimalsEnteredNotification').html(errorMsg);
			    //log('Event on decimals entered: ' + errorMsg);
			});
        });

    },
    loadHtml: function (dlg, url, fn) {
        if ($(dlg).length < 1) {
            common.loading('Dựng from');
            $.ajax({
                url: url,
                success: function (dt) {
                    common.loading(null);
                    var _temp = $('#_temp');
                    if ($(_temp).length < 1) { $('body').append('<div style=\"display:none !important;\" id=\"_temp\"></div>'); }
                    _temp = $('#_temp');
                    _temp.append(dt);
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
    },
    createFck: function (el) {
        var config = {
            toolbar:
		[
			['Source', '-', 'Save', 'NewPage', 'DocProps', 'Preview', 'Print', '-', 'Templates'],
             ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'],
              ['Find', 'Replace', '-', 'SelectAll', '-', 'SpellChecker', 'Scayt'],
                ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
			['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'],
		    ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'],
		    ['Link', 'Unlink', 'Anchor'],
		    ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'],
		    ['Styles', 'Format', 'Font', 'FontSize'],
		    ['TextColor', 'BGColor'],
		    ['Maximize', 'ShowBlocks', '-', 'About']
		], height: '60px'
        };
        var editor = jQuery(el).ckeditor(config, function () {
            CKFinder.setupCKEditor(this, '../js/ckfinder/');
        });
    },
    getQuery: function () {
        var fullURL = document.location.href;
        return fullURL.substring(fullURL.indexOf('?') + 3, fullURL.length);
    },
    logout: function () { $.ajax({ url: common._domain + '/lib/aspx/sys/authenticate.aspx?ref=' + Math.random(), data: { 'act': 'LogOut' }, success: function (data) { var h = document.location.hash; var d = document.location.href; if (h.length > 0) { d = d.substr(0, d.indexOf(h)); } document.location.href = d; } }); },
    fbMsg: function (title, msg, _width, _id, fn) {
        if (_id == null) { var _id = Math.random().toString().replace('.', ''); }
        if (_id == '') _id = Math.random().toString().replace('.', '');
        if (_width == null) _width = '400';
        var l = '';
        if (title != null) { l += '<div class=\"header-facebox-title\">' + title + '<a onclick=\"$(document).trigger(\'close.facebox\',\'' + _id + '\')\" href=\"javascript:;\" class=\"header-facebox-close\">x</a></div>'; }
        l += '<div style=\"width:' + _width + 'px;\" class=\"facebox-box\">' + msg + '</div>';
        l += '<div class=\"facebox-footer\"><a href=\"javascript:;\" onclick=\"$(document).trigger(\'close.facebox\',\'' + _id + '\')\" class=\"globalSave facebox-footer-close\">Đóng</a></div>';
        $.facebox(l, false, _id);
        var b = $('#' + _id);
        $('.facebox-footer-close', b).focus();
        if (typeof (fn) == 'function') {
             fn(b);
        }
    },
    fbJquery: function (title, node, _width, _id, fn) {
        if (_id == null) { var _id = Math.random().toString().replace('.', ''); }
        if (_id == '') _id = Math.random().toString().replace('.', '');
        if (_width == null) _width = '400';
        var l = '';
        if (title != null) { l += '<div class=\"header-facebox-title\">' + title + '<a onclick=\"$(document).trigger(\'close.facebox\',\'' + _id + '\')\" href=\"javascript:;\" class=\"header-facebox-close\">x</a></div>'; }
        l += '<div style=\"width:' + _width + 'px;\" class=\"facebox-box\">' + ($(node).length > 0 ? node.html() : ('thiếu ' + _id)) + '</div>';
        l += '<div class=\"facebox-footer\"><a href=\"javascript:;\" onclick=\"$(document).trigger(\'close.facebox\',\'' + _id + '\')\" class=\"globalSave facebox-footer-close\">Close</a></div>';
        $.facebox(l, false, _id);
        var b = $('#' + _id);
        $('.facebox-footer-close', b).focus();
        if (typeof (fn) == 'function') { fn(b); }
    },
    fbAjax: function (title, url, data, _width, _id, fn) {
        if (_id == null) { var _id = Math.random().toString().replace('.', ''); }
        if (_id == '') _id = Math.random().toString().replace('.', '');
        if (_width == null) _width = '400';
        $.facebox(function () {
            $.ajax({
                url: url,
                data: data,
                error: function (x, e) {
                    $(document).trigger('close.facebox', '' + _id + '');
                    var l = '';
                    if (x.status == 0) { l = 'Bạn đang offline!!\n'; }
                    else if (x.status == 404) { l = 'Lỗi mã: HTTP404. Tài nguyên không tồn tại'; }
                    else if (x.status == 401) { l = 'Lỗi mã: HTTP401. Không đủ quyền truy cập'; }
                    else if (x.status == 500) { l = 'Lỗi mã: HTTP500. Máy chủ đang bận'; }
                    else if (e == 'parsererror') { l = 'Lỗi mã: JSONDECO. Biên dịch lỗi'; }
                    else if (e == 'timeout') { l = 'Lỗi mã: TIMEOUT. Hết hạn'; }
                    else { l = 'Lỗi: ' + x.responseText; }
                    common.fbMsg('Lỗi ajax', l, null, 'fb-error-ajax', function () { });
                },
                success: function (dt) {
                    var l = '';
                    if (title != null) {
                        l += '<div class=\"header-facebox-title\">' + title + '<a onclick=\"$(document).trigger(\'close.facebox\',\'' + _id + '\')\" href=\"javascript:;\" class=\"header-facebox-close\">x</a></div>';
                    }
                    l += '<div style=\"width:' + _width + 'px;\" class=\"facebox-box\">' + dt + '</div>';
                    l += '<div class=\"facebox-footer\"><a href=\"javascript:;\" onclick=\"$(document).trigger(\'close.facebox\',\'' + _id + '\')\" class=\"globalSave facebox-footer-close\">Close</a></div>';
                    $.facebox(l, false, _id);
                    var b = $('#' + _id);
                    $('.facebox-footer-close', b).focus();
                    if (typeof (fn) == 'function') { fn(b); }
                }
            });
        }, false, _id);
    },
    setup: function () {
        window.defaultOnError = window.onerror;
        window.onerror = function(errorMeaage, fileName, lineNumber) {
            //common.fbMsg('Lỗi ', '00x014 MSG:' + errorMeaage + '<br/>FILE:' + fileName + ' <br/>LINE:<br/>' + lineNumber, null, 'fb-error-msg', function () { }); return true;
            console.log('00x014 MSG:' + errorMeaage + '<br/>FILE:' + fileName + ' <br/>LINE:<br/>' + lineNumber);
        };
        $.ajaxSetup({
            error: function (x, e) {
                var l = '';
                if (x.status == 0) { l = 'Bạn đang offline!!\n'; }
                else if (x.status == 404) { l = 'Lỗi mã: HTTP404. Tài nguyên không tồn tại'; }
                else if (x.status == 401) { l = 'Lỗi mã: HTTP401. Không đủ quyền truy cập'; }
                else if (x.status == 403) {
                    l = '403 : Bạn cần đăng nhập lại';
                    common.regType(typeof (registerFn), 'lib/js.lib.v01.1/register.js', function () { registerFn.login(); });
                }
                else if (x.status == 500) { l = 'Lỗi mã: HTTP500. Máy chủ đang bận'; }
                else if (e == 'parsererror') { l = 'Lỗi mã: JSONDECO. Biên dịch lỗi'; }
                else if (e == 'timeout') { l = 'Lỗi mã: TIMEOUT. Hết hạn'; }
                else { l = 'Lỗi: ' + x.responseText; }
                common.fbMsg('Lỗi ajax', l, null, 'fb-error-ajax', function () { });
            },
            failure: function (result) { common.fbMsg('Lỗi ajax', result, null, 'fb-error-ajax', function () { }); }
        });

        common.watermarks('.login-input', function (item) { if (!$(item).hasClass('login-input-focus')) $(item).addClass('login-input-focus'); }, function (item) { if ($(item).hasClass('reg-input-focus')) $(item).removeClass('reg-input-focus'); });

        var _trackUrlTimer, _hash = '';
        var trackUrl = function () {
            if (_trackUrlTimer) clearInterval(_trackUrlTimer);
            _trackUrlTimer = setInterval(function () {
                if (_hash != document.location.hash) {
                    _hash = document.location.hash;
                    _hash = _hash.replace('#', '');
                    console.log(_hash);
                    common.loading(_hash);
                    //                    $.ajax({
                    //                        url: _hash.replace('#', '') + '&',
                    //                        data: { 'Asyn': '1' },
                    //                        success: function (dt) {
                    //                            $('.main').html(dt);
                    //                        }
                    //                    });
                }
                _hash = document.location.hash;
                trackUrl();
            }, 1);
        }
        trackUrl();


        var regBtn = $('.top-r-register');
        if ($(regBtn).length > 0) {
            regBtn.click(function () {
                common.regPlug(typeof (userFn), 'appStore.authorityStore.userMgr.authentication, appStore.authorityStore.userMgr', function () {
                    userFn.register();
                });
            });
        }

    },
    watermarks: function (el, fn1, fn2) {
        if ($(el).length < 1) return false;
        $.each($(el), function (i, item) {
            var txt = $(item).attr('waterMark');
            $(item).val(txt);
            $(item).focus(function () {
                var _v = $(item).val();
                if (_v == txt) {
                    $(item).val('');
                }
                if (typeof (fn1) == 'function') fn1(item);
            });
            $(item).blur(function () {
                var _v = $(item).val();
                if (_v == '') {
                    $(item).val(txt);
                    if (typeof (fn2) == 'function') fn2(item);
                }
            });
        });
    },
    isInt: function (s) {
        var isInteger = function (s) {
            var i;
            if (isEmpty(s))
                if (isInteger.arguments.length == 1) return false;
                else return (isInteger.arguments[1] == true);

            for (i = 0; i < s.length; i++) {
                var c = s.charAt(i);

                if (!isDigit(c)) return false;
            }
            function isEmpty(s) {
                return ((s == null) || (s.length == 0))
            }

            function isDigit(c) {
                return ((c >= "0") && (c <= "9"))
            }
            return true;
        }
        return isInteger(s);
    },
    isEmail: function (email) {
        var status = false;
        var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
        if (email.search(emailRegEx) == -1) { status = false; }
        else { status = true; }
        return status;
    },
    isDate: function (text) {
        var marker = "/";
        var submitDate = text;
        var dateComp = submitDate.split(marker);
        var now = new Date();
        var yearNow = now.getFullYear();
        dayInmonth = new Array(12);
        dayInmonth[0] = 31; dayInmonth[1] = 29; dayInmonth[2] = 31; dayInmonth[3] = 30; dayInmonth[4] = 31; dayInmonth[5] = 30; dayInmonth[6] = 31; dayInmonth[7] = 31; dayInmonth[8] = 31; dayInmonth[9] = 31; dayInmonth[10] = 30; dayInmonth[11] = 31;
        if (dateComp.length != 3) {//alert("Please enter correct date format for " + text + " (mm/dd/yyyy)!");
            //adm.highlight(el); 
            return false;
        }
        for (var i = 0; i < 3; i++) {
            if (isNaN(dateComp[i])) {//alert("Please enter numeric for month, date, and year ( " + text + " )!");
                //adm.highlight(el); 
                return false;
            }
        }
        if (dateComp[1] > 12 || dateComp[1] < 1) {//alert("Please enter a valid month for " + text + " (1 to 12)!");
            //adm.highlight(el); 
            return false;
        }
        //        if (dateComp[2] > yearNow + 1) {//alert("Please enter a valid year for " + text + "! (future)");
        //            //adm.highlight(el); 
        //            return false;
        //        }
        //        if (dateComp[2] < yearNow - 1) {//alert("Please enter a valid year for " + text + "! (past)");
        //            //adm.highlight(el); 
        //            return false;
        //        }
        if (dateComp[2] % 4 == 0) { dayInmonth[0] = 29; }
        else { dayInmonth[0] = 28; }
        if (dateComp[0] > dayInmonth[dateComp[1] - 1] || dateComp[0] < 1) {//alert("Please enter a valid date!");
            //adm.highlight(el); 
            return false;
        }
        return true;
    },
    inorgeCaseMap: { 'á': 'a', 'ạ': 'a', 'ả': 'a', 'ă': 'a', 'ắ': 'a', 'ặ': 'a', 'ö': 'o', 'ụ': 'u', 'ộ': 'o', 'ỷ': 'y', 'ủ': 'u', 'ư': 'u', 'ê': 'e', 'ế': 'e', 'ệ': 'e', 'ề': 'e', 'ể': 'e', 'é': 'e', 'è': 'e', 'ẹ': 'e', 'í': 'i', 'ị': 'i', 'ả': 'a', 'á': 'a', 'ạ': 'a', 'ợ': 'o', 'ờ': 'o', 'ớ': 'o', 'ợ': 'o', ' ờ': 'o', 'ổ': 'o', 'ồ': 'o', 'ố': 'o', 'ộ': 'o', 'ị': 'i', 'ì': 'i', 'í': 'i', 'ỉ': 'i', 'ô': 'o', 'ò': 'o', 'ó': 'o', 'ỏ': 'o', 'â': 'a', 'ầ': 'a', 'ấ': 'a', 'ũ': 'u', 'ụ': 'u', ' ủ': 'u', 'à': 'a', ' á': 'a', 'đ': 'd', 'ữ': 'u', 'ứ': 'u', 'ừ': 'u', 'ử': 'u', 'ự': 'u', 'ở': 'o', 'ể': 'e' }
    ,
    inorgeCaseMapUrl: { 'á': 'a', 'ạ': 'a', 'ả': 'a', 'ă': 'a', 'ắ': 'a', 'ặ': 'a', 'ö': 'o', 'ụ': 'u', 'ộ': 'o', 'ỷ': 'y', 'ủ': 'u', 'ư': 'u', 'ê': 'e', 'ế': 'e', 'ệ': 'e', 'ề': 'e', 'ể': 'e', 'é': 'e', 'è': 'e', 'ẹ': 'e', 'í': 'i', 'ị': 'i', 'ả': 'a', 'á': 'a', 'ạ': 'a', 'ợ': 'o', 'ờ': 'o', 'ớ': 'o', 'ợ': 'o', ' ờ': 'o', 'ổ': 'o', 'ồ': 'o', 'ố': 'o', 'ộ': 'o', 'ị': 'i', 'ì': 'i', 'í': 'i', 'ỉ': 'i', 'ô': 'o', 'ò': 'o', 'ó': 'o', 'ỏ': 'o', 'â': 'a', 'ầ': 'a', 'ấ': 'a', 'ũ': 'u', 'ụ': 'u', ' ủ': 'u', 'à': 'a', ' á': 'a', 'đ': 'd', 'ữ': 'u', 'ứ': 'u', 'ừ': 'u', 'ử': 'u', 'ự': 'u', 'ở': 'o', 'ể': 'e', ' ': '-', ':': '', '>': '', '<': '', '?': '', '@': '', '$': '', '#': '', '&': '', '^': '', '\'': '', '"': '', '!': '', '`': '', '~': '', ')': '', '(': '', '*': '', '+': '', '-': '', '/': '', '?': '', '}': '', '{': '', ';': '' }
    , normalizeStr: function (term) {
        var ret = "";
        for (var i = 0; i < term.length; i++) {
            ret += common.inorgeCaseMap[term.charAt(i)] || term.charAt(i);
        }
        return ret;
    }
    , normalizeStrUrl: function (term) {
        var ret = "";
        term = term.toLowerCase();
        for (var i = 0; i < term.length; i++) {
            ret += common.inorgeCaseMapUrl[term.charAt(i)] || term.charAt(i);
        }
        ret = ret.replace(/[^a-zA-Z 0-9]+/g, '');
        return ret;
    }, validInputValueAjax: function (el, fn) {
        var _t;
        $(el).keyup(function () {
            var _v = $(el).val();
            var _old = $(el).attr('_old');
            if (_t) {
                clearInterval(_t);
            }
            _t = setInterval(function () {
                if (_t) {
                    clearInterval(_t);
                }
                if (_v == '') return false;
                if (_old == _v) return false;
                if (typeof (fn) == 'function') {
                    $(el).attr('_old', _v);
                    fn(_v, _t);
                }
            }, 800);
        });
    },
    ajaxReq: function (url, param, queue, _type, dtType, sendFn, successFn, errorFn, failFn) {
        var loadajax = function () {
            if (queue) {
                if (ajaxBusy) { if (ajaxTimer) { clearInterval(ajaxTimer); } ajaxTimer = setInterval(loadajax, 1000); return false; }
                if (_type == null) _type = 'GET'; if (dtType == null) dtType = 'text/html';
                if (ajaxTimer) clearInterval(ajaxTimer);
            }
            _lastXhr = $.ajax({
                type: _type,
                url: url,
                data: param,
                dataType: dtType,
                timeout: 100000,
                beforeSend: function () { ajaxBusy = true; if (typeof (sendFn) == 'function') { sendFn(); } },
                success: function (dt) { ajaxBusy = false; if (typeof (successFn) == 'function') successFn(dt); },
                error: function (x, e) { ajaxBusy = false; if (typeof (errorFn) == 'function') { errorFn(x, e); } else { ajaxTimer = setInterval(loadajax, 5000); } },
                failure: function (result) { ajaxBusy = false; if (typeof (failFn) == 'function') { failFn(result); } else { ajaxTimer = setInterval(loadajax, 5000); } }
            });
        }
        loadajax();
    },
    loadPlug: function (plug, param, fn) {
        var defaultParam = { 'act': 'loadPlug', 'rqPlug': plug, 'ref': Math.random() };
        param = jQuery.extend(defaultParam, param);
        common.loading('Đang tải' + plug);
        jQuery.post(domain + '/lib/admin/Default.aspx', param, function (data) {
            common.loading(null);
            if (typeof (fn) == 'function') {
                fn(data);
            }
        });
    },
    regPlug: function (_t, plug, fn) {
        if (_t == 'undefined') {
            common.loading('Nạp ' + plug);
            common.loadPlug(plug, { 'subAct': 'scpt' }, function (data) {
                common.loading('Get script' + _t);
                jQuery.getScript(data, function () {
                    common.loading(null);
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                });
            });
        }
        else {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
    },
    regType: function (_t, src, fn) {
        if (_t == 'undefined') {
            common.loading('Nạp ' + src);
            $.getScript(domain + '/' + src, function () {
                if (typeof (fn) == 'function') {
                    fn();
                }
            });
        }
        else {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
    },
    regJPlugin: function (pluginName, src, fn) {
        if (pluginName) {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
        else {
            $.getScript(domain + '/' + src, function () {
                if (typeof (fn) == 'function') {
                    fn();
                }
            });
        }
    },
    scrollMsg: function () {
        var cScroll = jQuery(window).scrollTop() + jQuery(window).height();
    },
    loading: function (msg) {
        var msgBox = $('.top-fixed-msg');
        if ($(msgBox).length == 0) return false;
        if (msg == null) {
            $(msgBox).hide();
        }
        else {
            $(msgBox).show();
            $(msgBox).find('.top-fixed-msg-body-content').html(msg);
        }
    },
    styleButton: function (el) {
        if (jQuery(el).length > 1) {
            jQuery(el).button();
        }
        jQuery('.mdl-head-btn').button();

        jQuery('.admfilter-btn').html('&nbsp;');
        jQuery('.admfilter-btn').button({
            icons: {
                primary: 'ui-icon-triangle-1-s'
            },
            text: false
        });

        jQuery('.admSearch-btn').html('&nbsp;');
        jQuery('.admSearch-btn').button({
            icons: {
                primary: 'ui-icon-search'
            },
            text: false
        });

        jQuery('.admfilter-btn').unbind('click').click(function () {
            var item = jQuery(this);
            jQuery(item).prev().prev().autocomplete('search', '');
        });
        jQuery('.admfilter-btnDate').unbind('click').click(function () {
            var item = jQuery(this);
            jQuery(item).prev().datepicker('show');
        });
    },
    upload: function (uploadBtn, type, param, callback) {
        common.regType(typeof (Ajax_upload), 'lib/js/ajaxupload.js', function () {
            var defaultParam = { 'act': 'upload', 'subAct': type };
            param = $.extend(defaultParam, param);
            new Ajax_upload($(uploadBtn), {
                action: domain + '/.plugin?act=upload&ref=' + Math.random(),
                name: 'anh',
                data: param,
                onSubmit: function (file, ext) {
                    if (type == 'anh' || type == 'adv') {
                        if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    }
                    else if (type == 'doc') {
                        if (!(ext && /^(doc|docx|xls|xlsx|txt|zip|rar|gz|mp3|avi|ppt|pptx)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    }
                    common.loading('Đang nạp');
                },
                onComplete: function (file, response) {
                    if (typeof (callback) == 'function') {
                        callback(response, file);
                    }
                    common.loading(null);
                    try { $.each(jQuery.browser, function (i, val) { if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9") gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1; }); } catch (err) { }
                }
            });
        });
    },
    getEl: function (el, fn) {
        var _offset = jQuery(el).offset();
        var _t = _offset.top;
        var _l = _offset.left;
        var _w = el.width();
        var _h = el.height();
        var _pt = parseInt(el.css('padding-top').toString().toLowerCase().replace('px', ''));
        var _pb = parseInt(el.css('padding-bottom').toString().toLowerCase().replace('px', ''));
        var _mt = parseInt(el.css('margin-top').toString().toLowerCase().replace('px', ''));
        var _mb = parseInt(el.css('margin-bottom').toString().toLowerCase().replace('px', ''));
        var _bb = parseInt(el.css('border-bottom-width').toString().toLowerCase().replace('px', ''));
        var _bt = parseInt(el.css('border-top-width').toString().toLowerCase().replace('px', ''));
        var _t1 = 0;
        _t1 = _t + _h + ((_pt == NaN) ? _pt : 0) + ((_pb == NaN) ? _pb : 0) + ((_mt == NaN) ? _mt : 0) + ((_mb == NaN) ? _mb : 0) + ((_bb == NaN) ? _bb : 0) + ((_bt == NaN) ? _bt : 0);
        if (typeof (fn) == 'function') { fn(_t, _l, _w, _t1); }
    }
}
