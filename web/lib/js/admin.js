var _gloTimer;
var _gloAjaxBusy = false;
var _gloTimeout = 1000;
var _cache = {}, _lastXhr;
var adm = {
    urlDefault: (typeof (domain) != 'undefined' ? domain : '') + '/lib/.plugin?ref=' + Math.random(),
    urlDefault1: 'Default.aspx?ref=' + Math.random(),
    loadPlug: function (plug, param, fn) {
        var defaultParam = { 'act': 'loadPlug', 'rqPlug': plug };
        param = jQuery.extend(defaultParam, param);
        //adm.loading('Đang nạp <b>' + plug + '</b>');
        adm.loading('Đang tải');
        jQuery.post(adm.urlDefault, param, function (data) {
            adm.loading(null);
            if (typeof (fn) == 'function') {
                fn(data);
            }
        });
    },
    VndToInt: function (input) {
        if (input.val() == '') {
            return 0;
        }
        //return parseInt(input.val().replace(/,/g, ''));
        return parseFloat($(input).asNumber()).toFixed(2);
    },
    VndToNumber: function (input) {
        if (input.val() == '') {
            return 0;
        }
        return parseInt(input.val().replace(/,/g, ''));
        //return parseFloat($(input).asNumber());
    },
    formatTienStr: function (_num) {
        if (_num == '') {
            return 0;
        }
        var num = parseInt(_num);
        var p = num.toFixed(2).split(".");
        return p[0].split("").reverse().reduce(function (acc, num, i, orig) {
            return num + (i && !(i % 3) ? "," : "") + acc;
        }, "");
    },
    shortvndate: function (_dDate) {
        var _sdate = new Date(_dDate);
        if (_sdate.getFullYear() == 100) {
            return "";
        }
        else {
            var year = '' + _sdate.getFullYear() + '';
            var years = year.substr(2);
            var fdate = _sdate.getDate()
            if (fdate < 10) {
                fdate = '0' + fdate
            }
            var fmonth = '' + (_sdate.getMonth() + 1);
            if (fmonth < 10) {
                fmonth = '0' + fmonth
            }
            return fdate + '/' + fmonth + '/' + years;
        }
    },
    formatTien: function (obj) {
        adm.regJPlugin(jQuery().formatCurrency, '/lib/js/jquery.formatCurrency-1.4.0.min.js', function () {
            // Format while typing & warn on decimals entered, no cents
            obj.formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: 2, symbol: '' });
            obj.blur(function () {
                obj.html(null);
                $(this).formatCurrency({ colorize: true, negativeFormat: '-%s%n', roundToDecimalPlace: 2, symbol: '' });
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
			            //case 37: break; // cursor left
			            //case 38: break; // cursor up
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
    formatNumber: function (obj) {
        adm.regJPlugin(jQuery().formatCurrency, '/lib/js/jquery.formatCurrency-1.4.0.min.js', function () {
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
			                //case 37: break; // cursor left
			                //case 38: break; // cursor up
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
    Dangnhap: function (Ma) {
        //        adm.setup();
        //        var h = document.location.hash;
        //        if (h == '') {
        //            adm.loading('Thiếu module', function () {
        //                setTimeout(function () { adm.loading(null); }, 5000);
        //            });
        //            return false;
        //        }
        //  alert(Ma);
        jQuery.post(adm.urlDefault, { 'act': 'loadPlug', 'rqPlug': 'docsoft.hethong.DangNhap.Class1, docsoft.hethong.DangNhap', 'subAct': 'lite', 'Ma': Ma }, function (data) { adm.loading(null); }, 'script');
    },
    preloadEnviroment: function () {
        adm.setup();
        var h = document.location.hash;
        if (h == '') {
            adm.loading('Thiếu module', function () {
                setTimeout(function () { adm.loading(null); }, 5000);
            });
            return false;
        }
        jQuery.post(adm.urlDefault, { 'act': 'loadPlug', 'rqPlug': 'docsoft.hethong.preload.Class1, docsoft.hethong.preload', 'subAct': 'lite' }, function (data) { adm.loading(null); }, 'script');
    },
    preload: function () {
        ///da ngon ngu admin _hiennb
        adm.regType(typeof (languageFn), 'docsoft.plugin.hethong.language.Class1, docsoft.plugin.hethong.language', function () {
            languageFn.setup(function () {
                $.each(LangArr, function (i, item) {
                    if (item.Active) {
                        Lang = item.Ma;
                    }
                });

            });
        });
        ///
        window.defaultOnError = window.onerror;
        window.onerror = function (errorMeaage, fileName, lineNumber) {
            adm.loading('00x014 MSG:' + errorMeaage + ' FILE:' + fileName + ' LINE:' + lineNumber, function () {
                adm.highlight(jQuery('#adm-loading'), function () {
                    setTimeout(function () {
                        adm.loading(null);
                    }, 10000);
                });
            });
            return true;
        }
        jQuery(function (jQuery) {
            jQuery.datepicker.regional['vi'] = {
                closeText: 'Đóng',
                prevText: '&#x3c;Trước',
                nextText: 'Tiếp&#x3e;',
                currentText: 'Hôm nay',
                monthNames: ['Tháng Một', 'Tháng Hai', 'Tháng Ba', 'Tháng Tư', 'Tháng Năm', 'Tháng Sáu',
		'Tháng Bảy', 'Tháng Tám', 'Tháng Chín', 'Tháng Mười', 'Tháng Mười Một', 'Tháng Mười Hai'],
                monthNamesShort: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6',
		'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
                dayNames: ['Chủ Nhật', 'Thứ Hai', 'Thứ Ba', 'Thứ Tư', 'Thứ Năm', 'Thứ Sáu', 'Thứ Bảy'],
                dayNamesShort: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
                dayNamesMin: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
                weekHeader: 'Tu',
                dateFormat: 'dd/mm/yy',
                firstDay: 0,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            jQuery.datepicker.setDefaults(jQuery.datepicker.regional['vi']);
        });
        adm.setupAjax();
        jQuery('body').append('<div id=\"adm-loading-panel\"><div id=\"adm-loading-panel-box\"><span class=\"ui-widget ui-widget-content ui-corner-all\" id=\"adm-loading\"></span></div></div>');
        adm.loading('Khởi động');
        
        (function (jQuery) {

            jQuery(".ui-autocomplete-input").on("autocompleteopen", function () {
                var autocomplete = jQuery(this).data("autocomplete"),
                menu = autocomplete.menu;

                if (!autocomplete.options.selectFirst) {
                    return;
                }

                menu.activate(jQuery.Event({ type: "mouseenter" }), menu.element.children().first());
            });

        } (jQuery));
        jQuery.post(adm.urlDefault, { 'act': 'loadPlug', 'rqPlug': 'docsoft.hethong.preload.Class1, docsoft.hethong.preload' }, function (data) {
            adm.loading(null);
        }, 'script');

        (function (jQuery) {

            jQuery(".ui-autocomplete-input").on("autocompleteopen", function () {
                var autocomplete = jQuery(this).data("autocomplete"),
                menu = autocomplete.menu;

                if (!autocomplete.options.selectFirst) {
                    return;
                }

                menu.activate(jQuery.Event({ type: "mouseenter" }), menu.element.children().first());
            });

        } (jQuery));

    },
    Dangnhaps: function () {
        //alert('afsafd');
        window.defaultOnError = window.onerror;
        window.onerror = function (errorMeaage, fileName, lineNumber) {
            adm.loading('00x014 MSG:' + errorMeaage + ' FILE:' + fileName + ' LINE:' + lineNumber, function () {
                adm.highlight(jQuery('#adm-loading'), function () {
                    setTimeout(function () {
                        adm.loading(null);
                    }, 10000);
                });
            });
            return true;
        }
        jQuery(function (jQuery) {
            jQuery.datepicker.regional['vi'] = {
                closeText: 'Đóng',
                prevText: '&#x3c;Trước',
                nextText: 'Tiếp&#x3e;',
                currentText: 'Hôm nay',
                monthNames: ['Tháng Một', 'Tháng Hai', 'Tháng Ba', 'Tháng Tư', 'Tháng Năm', 'Tháng Sáu',
		'Tháng Bảy', 'Tháng Tám', 'Tháng Chín', 'Tháng Mười', 'Tháng Mười Một', 'Tháng Mười Hai'],
                monthNamesShort: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6',
		'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
                dayNames: ['Chủ Nhật', 'Thứ Hai', 'Thứ Ba', 'Thứ Tư', 'Thứ Năm', 'Thứ Sáu', 'Thứ Bảy'],
                dayNamesShort: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
                dayNamesMin: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
                weekHeader: 'Tu',
                dateFormat: 'dd/mm/yy',
                firstDay: 0,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            jQuery.datepicker.setDefaults(jQuery.datepicker.regional['vi']);
        });
        adm.setupAjax();
        jQuery('body').append('<div id=\"adm-loading-panel\"><div id=\"adm-loading-panel-box\"><span class=\"ui-widget ui-widget-content ui-corner-all\" id=\"adm-loading\"></span></div></div>');
        adm.loading('Khởi động');
        (function (jQuery) {

            jQuery(".ui-autocomplete-input").live("autocompleteopen", function () {
                var autocomplete = jQuery(this).data("autocomplete"),
                menu = autocomplete.menu;

                if (!autocomplete.options.selectFirst) {
                    return;
                }

                menu.activate(jQuery.Event({ type: "mouseenter" }), menu.element.children().first());
            });

        } (jQuery));
        jQuery.post(adm.urlDefault, { 'act': 'loadPlug', 'rqPlug': 'docsoft.hethong.DangNhap.Class1, docsoft.hethong.DangNhap' }, function (data) {
            adm.loading(null);
        }, 'script');

        (function (jQuery) {

            jQuery(".ui-autocomplete-input").live("autocompleteopen", function () {
                var autocomplete = jQuery(this).data("autocomplete"),
		menu = autocomplete.menu;

                if (!autocomplete.options.selectFirst) {
                    return;
                }

                menu.activate(jQuery.Event({ type: "mouseenter" }), menu.element.children().first());
            });

        } (jQuery));

    },
    validFn: function (data) {
        var dt = eval(data);
        jQuery.each(dt, function (i, item) {
            if (!item.Active) {
                jQuery('#' + item.Ma).remove();
            }
        });
    },
    quickFindGridFn: function (el, v, c, fn) {
        jQuery(el).jqGrid('setCaption', c);
        jQuery(el).jqGrid('setGridParam', { url: v.urlDefault }).trigger('reloadGrid');
        if (typeof (fn) == "function") {
            fn();
        }
    },
    clearCombo: function (el) {
        jQuery.each(el, function (i, item) {
            item.attr('_value', '');
            item.val(item.attr('_hint'));
        });
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
    loading: function (status, fn) {
        if (status == null) {
            jQuery('#adm-loading').hide();
        }
        else {
            jQuery('#adm-loading').html(status).show();
            jQuery('<a id=\"adm-loading-close\" class=\"ui-icon ui-icon-close\" href=\"javascript:adm.loading(null);\">x</a>').prependTo('#adm-loading');
        }
        if (typeof (fn) == 'function') {
            fn();
        }
    },
    setupAjax: function () {
        jQuery.ajaxSetup({
            error: function (x, e) {
                var l = '';
                if (x.status == 0) {
                    l = 'Bạn đang offline!!\n';
                } else if (x.status == 404) {
                    l = 'Lỗi mã: HTTP404. Tài nguyên không tồn tại';
                } else if (x.status == 401) {
                    l = 'Lỗi mã: HTTP401. Không đủ quyền truy cập';
                }
                else if (x.status == 500) {
                    l = 'Lỗi mã: HTTP500. Máy chủ đang bận';
                } else if (e == 'parsererror') {
                    l = 'Lỗi mã: JSONDECO. Biên dịch lỗi';
                } else if (e == 'timeout') {
                    l = 'Lỗi mã: TIMEOUT. Hết hạn';
                } else {
                    l = 'Lỗi: ' + x.responseText;
                }
                adm.loading(l);
                setTimeout(function () {
                    adm.loading(null);
                }, 30000);
            },
            failure: function (result) {
                alert('failure');
            }
        });
    }
    ,
    upload: function (uploadBtn, type, param, callback, callbackFile, _call) {
        if (typeof (Ajax_upload) == 'undefined') {
            var fixUrl = '../js/ajaxupload.js';
            if (typeof(domain) != 'undefined') {
                fixUrl = domain + '/lib/js/ajaxupload.js';
            }
            jQuery.getScript(fixUrl, function () {
                var defaultParam = { 'act': 'upload', 'subAct': type };
                param = jQuery.extend(defaultParam, param);
                //return false;
                new Ajax_upload(jQuery(uploadBtn), {
                    action: adm.urlDefault,
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
                        else if (type == 'flash') {
                            if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                        else if (type == 'data') {
                            if (!(ext && /^(doc|docx|xls|xlsx|txt|zip|rar|gz|mp3|wma|mdi|mp4|avi|ppt|pptx|htm|html|mht|jpg|jpeg|png|sql|js|cs|aspx|)$/.test(ext))) {
                                // extension is not allowed
                                alert('Lỗi:\n Kiểu File không Hợp lệ');
                                // cancel upload
                                return false;
                            }
                        }
                        adm.loading('Đang nạp');
                    },
                    onComplete: function (file, response) {
                        var _response = response;
                        callback(_response);
                        if (typeof (callbackFile) == 'function') {
                            callbackFile(file);
                        }
                        if (typeof (_call) == 'function') {
                            _call(_response, file);
                        }
                        adm.loading(null);
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            });
        }
        else {
            var defaultParam = { 'act': 'upload', 'subAct': type };
            param = jQuery.extend(defaultParam, param);
            new Ajax_upload(jQuery(uploadBtn), {
                action: adm.urlDefault,
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
                    else if (type == 'flash') {
                        if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                    else if (type == 'data') {
                        if (!(ext && /^(doc|docx|xls|xlsx|txt|zip|rar|gz|mp3|wma|mdi|mp4|avi|ppt|pptx|htm|html|mht|jpg|jpeg|png|sql|js|cs|aspx|)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    }
                    adm.loading('Đang nạp');
                },
                onComplete: function (file, response) {
                    var _response = response;
                    callback(_response);
                    if (typeof (callbackFile) == 'function') {
                        callbackFile(file);
                    }
                    if (typeof (_call) == 'function') {
                        _call(_response, file);
                    }
                    adm.loading(null);
                    try {
                        jQuery.each(jQuery.browser, function (i, val) {
                            if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                        });
                    }
                    catch (err) {
                        //Handle errors here
                    }
                }
            });
        }


        // End Upload
    }
    ,
    uploadSanPham: function (uploadBtn, type, param, callback, callbackFile, _call) {
        if (typeof (Ajax_upload) == 'undefined') {
            var fixUrl = '../js/ajaxupload.js';
            if (typeof(domain) != 'undefined') {
                fixUrl = domain + '/lib/js/ajaxupload.js';
            }
            jQuery.getScript(fixUrl, function () {
                var defaultParam = { 'act': 'uploadSanPham', 'subAct': type };
                param = jQuery.extend(defaultParam, param);
                //return false;
                new Ajax_upload(jQuery(uploadBtn), {
                    action: adm.urlDefault,
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
                        else if (type == 'flash') {
                            if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                        adm.loading('Đang nạp');
                    },
                    onComplete: function (file, response) {
                        var _response = response;
                        callback(_response);
                        if (typeof (callbackFile) == 'function') {
                            callbackFile(file);
                        }
                        if (typeof (_call) == 'function') {
                            _call(_response, file);
                        }
                        adm.loading(null);
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            });
        }
        else {
            var defaultParam = { 'act': 'uploadSanPham', 'subAct': type };
            param = jQuery.extend(defaultParam, param);
            new Ajax_upload(jQuery(uploadBtn), {
                action: adm.urlDefault,
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
                    else if (type == 'flash') {
                        if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                    adm.loading('Đang nạp');
                },
                onComplete: function (file, response) {
                    var _response = response;
                    callback(_response);
                    if (typeof (callbackFile) == 'function') {
                        callbackFile(file);
                    }
                    if (typeof (_call) == 'function') {
                        _call(_response, file);
                    }
                    adm.loading(null);
                    try {
                        jQuery.each(jQuery.browser, function (i, val) {
                            if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                        });
                    }
                    catch (err) {
                        //Handle errors here
                    }
                }
            });
        }


        // End Upload
    },
    uploadTintuc: function (uploadBtn, type, param, callback, callbackFile, _call) {
        if (typeof (Ajax_upload) == 'undefined') {
            jQuery.getScript('../js/ajaxupload.js', function () {
                var defaultParam = { 'act': 'uploadTintuc', 'subAct': type };
                param = jQuery.extend(defaultParam, param);
                //return false;
                new Ajax_upload(jQuery(uploadBtn), {
                    action: adm.urlDefault,
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
                        else if (type == 'flash') {
                            if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                        adm.loading('Đang nạp');
                    },
                    onComplete: function (file, response) {
                        var _response = response;
                        callback(_response);
                        if (typeof (callbackFile) == 'function') {
                            callbackFile(file);
                        }
                        if (typeof (_call) == 'function') {
                            _call(_response, file);
                        }
                        adm.loading(null);
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            });
        }
        else {
            var defaultParam = { 'act': 'uploadTintuc', 'subAct': type };
            param = jQuery.extend(defaultParam, param);
            new Ajax_upload(jQuery(uploadBtn), {
                action: adm.urlDefault,
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
                    else if (type == 'flash') {
                        if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                    adm.loading('Đang nạp');
                },
                onComplete: function (file, response) {
                    var _response = response;
                    callback(_response);
                    if (typeof (callbackFile) == 'function') {
                        callbackFile(file);
                    }
                    if (typeof (_call) == 'function') {
                        _call(_response, file);
                    }
                    adm.loading(null);
                    try {
                        jQuery.each(jQuery.browser, function (i, val) {
                            if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                        });
                    }
                    catch (err) {
                        //Handle errors here
                    }
                }
            });
        }


        // End Upload
    },
    uploadKTNN: function (uploadBtn, type, param, callback, callbackFile, _call) {
        if (typeof (Ajax_upload) == 'undefined') {
            jQuery.getScript('../js/ajaxupload.js', function () {
                var defaultParam = { 'act': 'uploadKTNN', 'subAct': type };
                param = jQuery.extend(defaultParam, param);
                //return false;
                new Ajax_upload(jQuery(uploadBtn), {
                    action: adm.urlDefault,
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
                        else if (type == 'flash') {
                            if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                        adm.loading('Đang nạp');
                    },
                    onComplete: function (file, response) {
                        var _response = response;
                        callback(_response);
                        if (typeof (callbackFile) == 'function') {
                            callbackFile(file);
                        }
                        if (typeof (_call) == 'function') {
                            _call(_response, file);
                        }
                        adm.loading(null);
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            });
        }
        else {
            var defaultParam = { 'act': 'uploadKTNN', 'subAct': type };
            param = jQuery.extend(defaultParam, param);
            new Ajax_upload(jQuery(uploadBtn), {
                action: adm.urlDefault,
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
                    else if (type == 'flash') {
                        if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                    adm.loading('Đang nạp');
                },
                onComplete: function (file, response) {
                    var _response = response;
                    callback(_response);
                    if (typeof (callbackFile) == 'function') {
                        callbackFile(file);
                    }
                    if (typeof (_call) == 'function') {
                        _call(_response, file);
                    }
                    adm.loading(null);
                    try {
                        jQuery.each(jQuery.browser, function (i, val) {
                            if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                        });
                    }
                    catch (err) {
                        //Handle errors here
                    }
                }
            });
        }


        // End Upload
    },
    uploadQuangCao: function (height, width, uploadBtn, type, param, callback, callbackFile, _call) {
        if (typeof (Ajax_upload) == 'undefined') {
            jQuery.getScript('../js/ajaxupload.js', function () {
                var defaultParam = { 'act': 'uploadQuangCao', 'subAct': type, 'height': height, 'width': width };
                param = jQuery.extend(defaultParam, param);
                //return false;
                new Ajax_upload(jQuery(uploadBtn), {
                    action: adm.urlDefault,
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
                        else if (type == 'flash') {
                            if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                        adm.loading('Đang nạp');
                    },
                    onComplete: function (file, response) {
                        var _response = response;
                        callback(_response);
                        if (typeof (callbackFile) == 'function') {
                            callbackFile(file);
                        }
                        if (typeof (_call) == 'function') {
                            _call(_response, file);
                        }
                        adm.loading(null);
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            });
        }
        else {
            var defaultParam = { 'act': 'uploadQuangCao', 'subAct': type, 'height': height, 'width': width };
            param = jQuery.extend(defaultParam, param);
            new Ajax_upload(jQuery(uploadBtn), {
                action: adm.urlDefault,
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
                    else if (type == 'flash') {
                        if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
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
                    adm.loading('Đang nạp');
                },
                onComplete: function (file, response) {
                    var _response = response;
                    callback(_response);
                    if (typeof (callbackFile) == 'function') {
                        callbackFile(file);
                    }
                    if (typeof (_call) == 'function') {
                        _call(_response, file);
                    }
                    adm.loading(null);
                    try {
                        jQuery.each(jQuery.browser, function (i, val) {
                            if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                        });
                    }
                    catch (err) {
                        //Handle errors here
                    }
                }
            });
        }


        // End Upload
    },
    delOldUpFlash: function (uploadBtn, OldFileName, callback, callbackFile, _call) {
        var defaultParam = { 'act': 'DelOldFlash', 'subAct': 'flash' };
        OldFileName = jQuery.extend(defaultParam, OldFileName);
        new Ajax_upload(jQuery(uploadBtn), {
            action: adm.urlDefault,
            name: 'flash',
            data: OldFileName,
            onSubmit: function (file, ext) {
                if (type == 'flash') {
                    if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
                        // extension is not allowed
                        alert('Lỗi:\n Kiểu File không Hợp lệ');
                        // cancel upload
                        return false;
                    }
                }

                adm.loading('Đang nạp');
            },
            onComplete: function (OldFileName, response) {
                var _response = response;
                callback(_response);
                if (typeof (callbackFile) == 'function') {
                    callbackFile(OldFileName);
                }
                if (typeof (_call) == 'function') {
                    _call(_response, OldFileName);
                }
                adm.loading(null);
                try {
                    jQuery.each(jQuery.browser, function (i, val) {
                        if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                            gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                    });
                }
                catch (err) {
                    //Handle errors here
                }
            }
        });
    },
    uploadFlash: function (uploadBtn, type, param, callback, callbackFile, _call) {
        if (typeof (Ajax_upload) == 'undefined') {
            jQuery.getScript('../js/ajaxupload.js', function () {
                var defaultParam = { 'act': 'uploadFlash', 'subAct': type };
                param = jQuery.extend(defaultParam, param);
                //return false;
                new Ajax_upload(jQuery(uploadBtn), {
                    action: adm.urlDefault,
                    name: 'flash',
                    data: param,
                    onSubmit: function (file, ext) {
                        if (type == 'flash') {
                            if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
                                // extension is not allowed
                                alert('Lỗi:\n Kiểu File không Hợp lệ');
                                // cancel upload
                                return false;
                            }
                        }

                        adm.loading('Đang nạp');
                    },
                    onComplete: function (file, response) {
                        var _response = response;
                        callback(_response);
                        if (typeof (callbackFile) == 'function') {
                            callbackFile(file);
                        }
                        if (typeof (_call) == 'function') {
                            _call(_response, file);
                        }
                        adm.loading(null);
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            });
        }
        else {
            var defaultParam = { 'act': 'uploadFlash', 'subAct': type };
            param = jQuery.extend(defaultParam, param);
            new Ajax_upload(jQuery(uploadBtn), {
                action: adm.urlDefault,
                name: 'flash',
                data: param,
                onSubmit: function (file, ext) {
                    if (type == 'flash') {
                        if (!(ext && /^(jpg|png|jpeg|gif|swf)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    }

                    adm.loading('Đang nạp');
                },
                onComplete: function (file, response) {
                    var _response = response;
                    callback(_response);
                    if (typeof (callbackFile) == 'function') {
                        callbackFile(file);
                    }
                    if (typeof (_call) == 'function') {
                        _call(_response, file);
                    }
                    adm.loading(null);
                    try {
                        jQuery.each(jQuery.browser, function (i, val) {
                            if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                        });
                    }
                    catch (err) {
                        //Handle errors here
                    }
                }
            });
        }


        // End Upload
    },
    uploadFull: function (uploadBtn, type, param, callback, callbackFile, _call) {
        if (typeof (Ajax_upload) == 'undefined') {
            jQuery.getScript('../js/ajaxupload.js', function () {
                var defaultParam = { 'act': 'uploadFull', 'subAct': type };
                param = jQuery.extend(defaultParam, param);
                //return false;
                new Ajax_upload(jQuery(uploadBtn), {
                    action: adm.urlDefault,
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
                        adm.loading('Đang nạp');
                    },
                    onComplete: function (file, response) {
                        var _response = response;
                        callback(_response);
                        if (typeof (callbackFile) == 'function') {
                            callbackFile(file);
                        }
                        if (typeof (_call) == 'function') {
                            _call(_response, file);
                        }
                        adm.loading(null);
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            });
        }
        else {
            var defaultParam = { 'act': 'uploadFull', 'subAct': type };
            param = jQuery.extend(defaultParam, param);
            new Ajax_upload(jQuery(uploadBtn), {
                action: adm.urlDefault,
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
                        if (!(ext && /^(doc|docx|xls|xlsx|txt|zip|rar|gz|mp3|avi|ppt|pptx|swf)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    }
                    adm.loading('Đang nạp');
                },
                onComplete: function (file, response) {
                    var _response = response;
                    callback(_response);
                    if (typeof (callbackFile) == 'function') {
                        callbackFile(file);
                    }
                    if (typeof (_call) == 'function') {
                        _call(_response, file);
                    }
                    adm.loading(null);
                    try {
                        jQuery.each(jQuery.browser, function (i, val) {
                            if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                        });
                    }
                    catch (err) {
                        //Handle errors here
                    }
                }
            });
        }


        // End UploadFull
    },
    
    uploadvideo: function (uploadBtn, type, param, callback, callbackFile, _call) {
        if (typeof (Ajax_upload) == 'undefined') {
            jQuery.getScript('../js/ajaxupload.js', function () {
                var defaultParam = { 'act': 'uploadvideo', 'subAct': type };
                param = jQuery.extend(defaultParam, param);
                new Ajax_upload(jQuery(uploadBtn), {
                    action: adm.urlDefault1,
                    name: 'video',
                    data: param,

                    onSubmit: function (file, ext) {
                        if (type == 'video' || type == 'video') {
                            if (!(ext && /^(jpg|png|jpeg|gif|flv|mp4|avi|wmv)$/.test(ext))) {
                                // extension is not allowed
                                alert('Lỗi:\n Kiểu File không Hợp lệ');
                                // cancel upload
                                return false;
                            }
                        }
                        else if (type == 'video') {
                            if (!(ext && /^(doc|docx|xls|xlsx|txt|zip|rar|gz|mp3|avi|ppt|pptx|flv|mp4|wmv)$/.test(ext))) {
                                // extension is not allowed
                                alert('Lỗi:\n Kiểu File không Hợp lệ');
                                // cancel upload
                                return false;
                            }
                        }
                        adm.loading('Đang nạp');
                    },
                    onComplete: function (file, response) {
                        var _response = response;
                        callback(_response);

                        if (typeof (callbackFile) == 'function') {
                            callbackFile(file);
                        }
                        if (typeof (_call) == 'function') {
                            _call(_response, file);
                        }
                        adm.loading(null);
                        try {
                            jQuery.each(jQuery.browser, function (i, val) {
                                if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                    gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                            });
                        }
                        catch (err) {
                            //Handle errors here
                        }
                    }
                });
            });
        }
        else {
            var defaultParam = { 'act': 'uploadvideo', 'subAct': type };
            param = jQuery.extend(defaultParam, param);
            new Ajax_upload(jQuery(uploadBtn), {
                action: adm.urlDefault,
                name: 'video',
                data: param,

                onSubmit: function (file, ext) {
                    if (type == 'video' || type == 'video') {
                        if (!(ext && /^(jpg|png|jpeg|gif|flv|mp4|avi|wmv)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    }
                    else if (type == 'video') {
                        if (!(ext && /^(doc|docx|xls|xlsx|txt|zip|rar|gz|mp3|avi|ppt|pptx|flv|mp4|wmv)$/.test(ext))) {
                            // extension is not allowed
                            alert('Lỗi:\n Kiểu File không Hợp lệ');
                            // cancel upload
                            return false;
                        }
                    }
                    adm.loading('Đang nạp');
                },
                onComplete: function (file, response) {
                    var _response = response;

                    callback(_response);
                    if (typeof (callbackFile) == 'function') {
                        callbackFile(file);
                    }
                    if (typeof (_call) == 'function') {
                        _call(_response, file);
                    }
                    adm.loading(null);
                    try {
                        jQuery.each(jQuery.browser, function (i, val) {
                            if (i == "mozilla" && jQuery.browser.version.substr(0, 3) == "1.9")
                                gBrowser.selectedBrowser.markupDocumentViewer.fullZoom = 1;
                        });
                    }
                    catch (err) {
                        //Handle errors here
                    }
                }
            });
        }


        // End Upload
    },
    createCkFull: function (el) {
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
    createFckFull: function (el) {
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
    createFck_TN: function (el) {
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
    createTinyMce: function (el) {
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
    ckeditor_blogPost: function (el) {
        var config = {
            toolbar: [
			['Maximize','Source', 'Bold', 'Italic', 'RemoveFormat', 'FontSize', 'Link', 'Unlink', 'TextColor', 'BGColor'],
		    ['Image', 'NumberedList', 'BulletedList', 'Outdent', 'Indent', 'JustifyLeft', 'JustifyCenter', 'JustifyRight']
		], height: '100px'
        };
        var editor = jQuery(el).ckeditor(config, function () {
        });
    },
    createTinyMces: function (el) {
        adm.regJPlugin(jQuery().tinymce, '../Js/tinymce/jscripts/tiny_mce/jquery.tinymce.js', function () {
            jQuery(el).tinymce({
                // Location of TinyMCE script
                mode: 'textareas',
                script_url: '../js/tinymce/jscripts/tiny_mce/tiny_mce.js',
                // General options
                elements: 'tinybrowser',
                theme: "advanced",
                plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,advlist",
                // Theme options
                //theme_advanced_buttons1: "bold,italic,underline,strikethrough,justifyleft,justifycenter,justifyright,justifyfull,formatselect,fontselect,fontsizeselect,emotions,media,link,unlink,anchor,image,preview,forecolor,backcolor,charmap,fullscreen",
                //theme_advanced_buttons1: "bold,fontselect,fontsizeselect,emotions,media,link,image,preview,forecolor,backcolor",
                theme_advanced_buttons1: "bold,fontselect,fontsizeselect,forecolor,backcolor,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,formatselect,fontselect,fontsizeselect,code",
                theme_advanced_buttons2: "",
                theme_advanced_buttons3: "",
                theme_advanced_buttons4: "",
                file_browser_callback: "tinybrowser",
                //theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
                //theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime  ,preview,|,forecolor,backcolor",
                //theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
                //theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak",
                theme_advanced_toolbar_location: "top",
                theme_advanced_toolbar_align: "left",
                //theme_advanced_statusbar_location: "bottom",
                theme_advanced_resizing: true,
                // Example content CSS (should be your site CSS)
                //content_css: "css/content.css",
                // Drop lists for link/image/media/template dialogs
                //                template_external_list_url: "lists/template_list.js",
                //                external_link_list_url: "lists/link_list.js",
                //                external_image_list_url: "lists/image_list.js",
                //                media_external_list_url: "lists/media_list.js",
                template_external_list_url: "js/template_list.js",
                external_link_list_url: "js/link_list.js",
                external_image_list_url: "js/image_list.js",
                media_external_list_url: "js/media_list.js",

                width: "707px",
                height: "100px"
            });
        });
    },


    ajaxtimer: null,
    ajaxbusy: false,
    ajaxreq: function (param, url, dtType, callback, overrideSuccessFunc) {
        var loadajax = function () {
            if (adm.ajaxbusy) {
                if (adm.ajaxtimer) {
                    clearInterval(adm.ajaxtimer);
                }
                adm.ajaxtimer = setInterval(loadajax, 1000);
                return false;
            }
            if (adm.ajaxtimer) clearInterval(adm.ajaxtimer);
            jQuery.ajax({
                type: 'POST',
                url: url,
                data: param,
                dataType: dtType,
                timeout: 100000,
                beforeSend: function () {
                    adm.ajaxbusy = true;
                    adm.loading('Đang nạp', null);
                },
                success: function (dt) {
                    adm.ajaxbusy = false;
                    adm.loading(null);
                    overrideSuccessFunc(dt);
                }
            });
        }
        loadajax();
    },
    highlight: function (el, fn) {
        jQuery(el).animate({ backgroundColor: 'orange' }, 500, function () {
            jQuery(el).animate({ backgroundColor: 'white' }, 500, function () {
                if (typeof (fn) == 'function') {
                    fn();
                }
            });
        });
    },
    ajaxfilemanager: function (field_name, url, type, win) {

        var ajaxfilemanagerurl = "http://localhost:27878/web/lib/ajaxfilemanager/ajaxfilemanager.aspx?editor=tinymce";
        alert(ajaxfilemanagerurl);
        switch (type) {

            case "image":

                break;

            case "media":

                break;

            case "flash":

                break;

            case "file":

                break;

            default:

                return false;

        }

        var fileBrowserWindow = new Array();

        fileBrowserWindow["file"] = ajaxfilemanagerurl;

        fileBrowserWindow["title"] = "Ajax File Manager";

        fileBrowserWindow["width"] = "782";

        fileBrowserWindow["height"] = "440";

        fileBrowserWindow["close_previous"] = "no";

        tinymce.openWindow(fileBrowserWindow, {

            window: win,

            input: field_name,

            resizable: "yes",

            inline: "yes",

            editor_id: tinymce.getWindowArg("editor_id")

        });

        alert("aaaaaaa");

        return false;

    }
,
    watermark: function (el, txt, fn) {
        if (jQuery(el).length < 1) return false;
        jQuery(el).val(txt);
        jQuery(el).focus(function () {
            var _parent = jQuery(el).parent();
            var _clear = jQuery(el).prev();
            var _v = jQuery(el).val();
            if (_v == txt) {
                jQuery(el).val('');
            }
            if (_v != txt || _v != '') {
                jQuery(_clear).show();
            }
            jQuery(_parent).removeClass('mdl-head-txt-focus');
            jQuery(_parent).addClass('mdl-head-txt-focus');
        });
        jQuery(el).prev().unbind('click').click(function () {
            jQuery(el).val(txt);
            jQuery(el).attr('_value', '');
            jQuery(el).parent().removeClass('mdl-head-txt-focus');
            jQuery(el).prev().hide();
            fn();
        });
        jQuery(el).blur(function () {
            var _parent = jQuery(el).parent();
            var _clear = jQuery(el).prev();
            var _v = jQuery(el).val();
            if (_v == '') {
                jQuery(el).val(txt);
                jQuery(_clear).hide();
                jQuery(_parent).removeClass('mdl-head-txt-focus');
            }
        });
    },
    watermarks: function (el, txt, fn) {
        if (jQuery(el).length < 1) return false;
        jQuery(el).val(txt);
        jQuery(el).focus(function () {
            var _v = jQuery(el).val();
            if (_v == txt) {
                jQuery(el).val('');
            }
        });
        jQuery(el).blur(function () {
            var _v = jQuery(el).val();
            if (_v == '') {
                jQuery(el).val(txt);
                if (typeof (fn) == 'function') {
                    fn();
                }
            }
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

    isDate: function (el, text) {
        var marker = "/";
        var submitDate = text;
        var dateComp = submitDate.split(marker);
        var now = new Date();
        var yearNow = now.getFullYear();
        dayInmonth = new Array(12);
        dayInmonth[0] = 31;
        dayInmonth[1] = 29;
        dayInmonth[2] = 31;
        dayInmonth[3] = 30;
        dayInmonth[4] = 31;
        dayInmonth[5] = 30;
        dayInmonth[6] = 31;
        dayInmonth[7] = 31;
        dayInmonth[8] = 31;
        dayInmonth[9] = 31;
        dayInmonth[10] = 30;
        dayInmonth[11] = 31;
        if (dateComp.length != 3) {
            //alert("Please enter correct date format for " + text + " (mm/dd/yyyy)!");
            adm.highlight(el);
            return false;
        }
        for (var i = 0; i < 3; i++) {
            if (isNaN(dateComp[i])) {
                //alert("Please enter numeric for month, date, and year ( " + text + " )!");
                adm.highlight(el);
                return false;
            }
        }
        if (dateComp[1] > 12 || dateComp[1] < 1) {
            //alert("Please enter a valid month for " + text + " (1 to 12)!");
            adm.highlight(el);
            return false;
        }
        if (dateComp[2] > yearNow + 1) {
            //alert("Please enter a valid year for " + text + "! (future)");
            adm.highlight(el);
            return false;
        }
        if (dateComp[2] < yearNow - 1) {
            //alert("Please enter a valid year for " + text + "! (past)");
            adm.highlight(el);
            return false;
        }
        if (dateComp[2] % 4 == 0) {
            dayInmonth[0] = 29;
        }
        else {
            dayInmonth[0] = 28;
        }
        if (dateComp[0] > dayInmonth[dateComp[1] - 1] || dateComp[0] < 1) {
            //alert("Please enter a valid date!");
            adm.highlight(el);
            return false;
        }
        return true;
    },
    regScript: function (_t, src, fn) {
        if (_t == 'undefined') {
            adm.loading('Get script' + src);
            jQuery.getScript(src, function () {
                adm.loading(null);
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
    regType: function (_t, plug, fn) {
        if (_t == 'undefined') {
            adm.loading('Nạp ' + plug);
            adm.loadPlug(plug, { 'subAct': 'scpt' }, function (data) {
                adm.loading('Get script' + _t);
                jQuery.getScript(data, function () {
                    adm.loading(null);
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
    regTypeNew: function (_t, plug, fn) {
        if (_t == 'undefined') {
            adm.loading('Nạp ' + plug);
            adm.loadPlug(plug, { 'subAct': 'scpt1' }, function (data) {
                adm.loading('Get script' + _t);
                jQuery.getScript(data, function () {
                    adm.loading(null);
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
    regQS: function (el, _tableId) {
        if (jQuery().quicksearch) {
            jQuery(el).quicksearch('table#' + _tableId + ' tbody tr');
        }
        else {
            jQuery.getScript('../js/jquery.quicksearch.js', function () {
                jQuery(el).quicksearch('table#' + _tableId + ' tbody tr');
            });
        }
    },
    regJPlugin: function (pluginName, src, fn) {
        if (pluginName) {
            if (typeof (fn) == 'function') {
                fn();
            }
        }
        else {
            jQuery.getScript(src, function () {
                if (typeof (fn) == 'function') {
                    fn();
                }
            });
        }
    },
    tbao: function (s, fn) {
        var newDlg = jQuery('#global-dialog-alert');
        if (jQuery(newDlg).length < 1) {
            jQuery('body').append('<div id=\"global-dialog-alert\"></div>');
            newDlg = jQuery('#global-dialog-alert');
        }
        jQuery(newDlg).dialog({
            modal: true,
            title: 'Thông báo',
            buttons: {
                'Đóng': function () {
                    jQuery(newDlg).dialog('close');
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
            },
            open: function () {
                jQuery(newDlg).html(s);
            }
        });
    },
    // Created by: Justin Barlow | http://www.netlobo.com/
    // This script downloaded from www.JavaScriptBank.com

    // This function formats numbers by adding commas
    numberFormatfn: function (nStr) {
        nStr += '';
        x = nStr.split('.');
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1))
            x1 = x1.replace(rgx, 'jQuery1' + ',' + 'jQuery2');
        return x1 + x2;
    },

    // This function removes non-numeric characters
    stripNonNumericfn: function (str) {
        str += '';
        var rgx = /^\d|\.|-jQuery/;
        var out = '';
        for (var i = 0; i < str.length; i++) {
            if (rgx.test(str.charAt(i))) {
                if (!((str.charAt(i) == ',' && out.indexOf('.') != -1) ||
                 (str.charAt(i) == '-' && out.length != 0))) {
                    out += str.charAt(i);
                }
            }
        }
        return out;
    },
    // Có lỗi xảy ra khi bấm quay về đầu tiên và viết thêm vào
    formatdatefn: function (nstr) {
        //01/2011 ....
        var regexp = /(^\djQuery)|(^\d\/jQuery)|(^\d\d\/jQuery)|(^\d\djQuery)|(((^\d\/)|(^\d{2}\/))(\d|(\d{2})|(\d{3})|(\d{4}))jQuery)/;
        if (regexp.test(nstr)) {
            if (nstr.length == 1) {
                if (nstr > 1) {
                    nstr = '0' + nstr + '/';
                }
            }
            else {
                if (nstr.length == 2) {
                    if (nstr.substring(nstr.length - 1, nstr.length) == '/') {
                        nstr = '0' + nstr;
                    }
                    else {
                        if (nstr > 12) {
                            nstr = nstr.substring(0, nstr.length - 1)
                        }
                        else {
                            nstr += '/';
                        }
                    }
                }
            }
        }
        else {
            nstr = nstr.substring(0, nstr.length - 1)
        }
        return nstr;
    },

    replaceAll: function (str, from, to) {
        var idx = str.indexOf(from);

        while (idx > -1) {
            str = str.replace(from, to);
            idx = str.indexOf(from);
        }

        return str;
    },
    live: function (s) {//Channel realtim
        var loadajax = function () {
            if (_gloAjaxBusy) {
                if (_gloTimer) {
                    clearInterval(_gloTimer);
                }
                _gloTimer = setInterval(loadajax, 300000);
                return false;
            }
            _gloAjaxBusy = true;
            if (_gloTimer) clearInterval(_gloTimer);
            if (s == null) s = '';
            jQuery.ajax({
                url: adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.hethong.preload.Class1, docsoft.hethong.preload',
                dataType: 'script',
                data: {
                    'subAct': 'get',
                    's': s
                }, success: function (dt) {
                    _gloAjaxBusy = false;
                }, error: function (x, e) {
                    _gloAjaxBusy = false;
                    _gloTimer = setInterval(function () {
                        loadajax();
                    }, 300000);
                }
            });

        }
        setInterval(function () {
            loadajax();
        }, 5000);
    },
    loadIfr: function (url, fn, fn1) {
        if (typeof (fn) == 'function') {
            fn();
        }
        var ifr = jQuery('#ifr');
        if (jQuery(ifr).length < 1) {
            var l = '<iframe id=\"ifr\" style=\"display:none;\" />';
            jQuery('body').append(l);
        }
        ifr = jQuery('#ifr');
        jQuery(ifr).attr('src', url);
        jQuery(ifr).onload = function () {
            if (typeof (fn1) == 'function') {
                fn1();
            }
        }
    }
    , inorgeCaseMap: { 'á': 'a', 'ạ': 'a', 'ả': 'a', 'ă': 'a', 'ắ': 'a', 'ặ': 'a', 'ö': 'o', 'ụ': 'u', 'ộ': 'o', 'ỷ': 'y', 'ủ': 'u', 'ư': 'u', 'ê': 'e', 'ế': 'e', 'ệ': 'e', 'ề': 'e', 'ể': 'e', 'é': 'e', 'è': 'e', 'ẹ': 'e', 'í': 'i', 'ị': 'i', 'ả': 'a', 'á': 'a', 'ạ': 'a', 'ợ': 'o', 'ờ': 'o', 'ớ': 'o', 'ợ': 'o', ' ờ': 'o', 'ổ': 'o', 'ồ': 'o', 'ố': 'o', 'ộ': 'o', 'ị': 'i', 'ì': 'i', 'í': 'i', 'ỉ': 'i', 'ô': 'o', 'ò': 'o', 'ó': 'o', 'ỏ': 'o'
    , 'â': 'a', 'ầ': 'a', 'ấ': 'a', 'ũ': 'u', 'ụ': 'u', ' ủ': 'u', 'à': 'a', ' á': 'a', 'đ': 'd', 'ở': 'o'
    }
    , normalizeStr: function (term) {
        var ret = "";
        for (var i = 0; i < term.length; i++) {
            ret += adm.inorgeCaseMap[term.charAt(i)] || term.charAt(i);
        }
        return ret;
    },
    viewClip: function () {
        var l = '<object width=\"760\" height=\"595\"><param name=\"movie\" value=\"http://www.youtube.com/v/_Dqbvdjkrqs?fs=1&amp;hl=vi_VN&amp;hd=1&amp;color1=0x006699&amp;color2=0x54abd6&amp;autoplay=1\"></param><param name=\"allowFullScreen\" value=\"true\"></param><param name=\"allowscriptaccess\" value=\"always\"></param><embed src=\"http://www.youtube.com/v/_Dqbvdjkrqs?fs=1&amp;hl=vi_VN&amp;hd=1&amp;color1=0x006699&amp;color2=0x54abd6&amp;autoplay=1\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" width=\"760\" height=\"595\"></embed></object>';
        var newDlg = jQuery('#global-dialog-alert');
        if (jQuery(newDlg).length < 1) {
            jQuery('body').append('<div id=\"global-dialog-alert\"></div>');
            newDlg = jQuery('#global-dialog-alert');
        }
        jQuery(newDlg).dialog({
            modal: true,
            title: 'Video hướng dẫn',
            width: 800,
            height: 600,
            buttons: {
                'Đóng': function () {
                    jQuery(newDlg).dialog('close');
                }
            },
            open: function () {
                jQuery(newDlg).html(l);
            }
        });
    },
    validElValAjax: function (el, fn) {
        var _t;
        jQuery(el).keyup(function () {
            var _v = jQuery(el).val();
            var _old = jQuery(el).attr('_old');
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
                    jQuery(el).attr('_old', _v);
                    fn(_v, _t);
                }
            }, 800);
        });
    },
    verifyEmail: function (email) {
        var status = false;
        var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
        if (email.search(emailRegEx) == -1) {
            status = false;
        }
        else {
            status = true;
        }
        return status;
    }
}

