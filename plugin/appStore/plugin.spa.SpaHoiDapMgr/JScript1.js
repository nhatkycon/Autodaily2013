var spaHoiDapMgrFn = {
    urlDefault: adm.urlDefault + '&act=loadPlug&rqPlug=plugin.spa.SpaHoiDapMgr.Class1, plugin.spa.SpaHoiDapMgr',
    setup: function () {
    },
    loadgrid: function () {
        adm.loading('Đang lấy dữ liệu');
        adm.styleButton();
        $('#spaHoiDapMgrMdl-List').jqGrid({
            url: spaHoiDapMgrFn.urlDefault + '&subAct=get',
            datatype: 'json',
            colNames: ['ID', 'Tên', 'Người tạo', 'Email', 'Mobile', 'Câu hỏi', 'Active', 'Trả lời', 'Hot'],
            colModel: [
            { name: 'HD_ID', key: true, sortable: true, hidden: true },
            { name: 'HD_Ten', width: 40, sortable: false, editable: true },
            { name: 'HD_NguoiTao', width: 10, resizable: true, sortable: false },
            { name: 'HD_Email', width: 5, resizable: true, sortable: false },
            { name: 'HD_Mobile', width: 5, resizable: true, sortable: false },
            { name: 'HD_ID', width: 40, resizable: true, sortable: false },
            { name: 'HD_Active', width: 2, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'HD_DaTraLoi', width: 2, resizable: true, sortable: false, formatter: 'checkbox' },
            { name: 'HD_Hot', width: 2, resizable: true, sortable: false, formatter: 'checkbox' }
            ],
            caption: 'Top Spa',
            autowidth: true,
            multiselect: true,
            multiboxonly: true,
            height: 300,
            sortname: 'HD_ID',
            sortorder: 'desc',
            rowNum: 20,
            rowList: [5, 20, 100, 500, 1000],
            pager: jQuery('#spaHoiDapMgrMdl-Pager'),
            onSelectRow: function (rowid) {
                var treedata = $("#spaHoiDapMgrMdl-List").jqGrid('getRowData', rowid);
            },
            loadComplete: function () {
                adm.loading(null);
                spaHoiDapMgrFn.headFn();
            }
        });
    },
    headFn: function () {
        var searchTxt = $('.mdl-head-search-spaHoiDapMgrMdl');
        $(searchTxt).unbind('keyup').keyup(function () {
            spaHoiDapMgrFn.search();
        });
        var DM_ID = $('.mdl-head-spaHoiDapMgrMdlFilterByDm');
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteByLoai('DVU', DM_ID, function (event, ui) {
                $(DM_ID).attr('_value', ui.item.id);
                spaHoiDapMgrFn.search();
            });
        });
    },
    search: function () {
        var timerSearch;
        var searchTxt = $('.mdl-head-search-spaHoiDapMgrMdl');
        var __q = $(searchTxt).val();
        var DM_ID = $('.mdl-head-spaHoiDapMgrMdlFilterByDm');
        var _dm_id = '';
        if (DM_ID.val() != '') {
            _dm_id = DM_ID.attr('_value');
        }
        if (timerSearch) clearTimeout(timerSearch);
        timerSearch = setTimeout(function () {
            $('#spaHoiDapMgrMdl-List').jqGrid('setGridParam', { url: spaHoiDapMgrFn.urlDefault
             + '&q=' + __q
             + '&subAct=get'
             + '&_DM_ID=' + _dm_id
            }).trigger("reloadGrid");
        }, 1000);
    },
    datCauHoi: function (fn) {
        spaHoiDapMgrFn.loadHtml(function () {
            var newDlg = $('#spaDatCauHoiChungMdl-dlgNew');
            common.fbJquery('Đặt câu hỏi', newDlg, 900, 'dat-cau-hoi', function (bd) {
                var DM_ID = $('.DM_ID', bd);
                var Ten = $('.Ten', bd);
                var NguoiTao = $('.NguoiTao', bd);
                var Email = $('.Email', bd);
                var Mobile = $('.Mobile', bd);
                var NoiDung = $('.NoiDung', bd);

                adm.styleButton();

                adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                    danhmuc.autoCompleteByLoai('DVU', DM_ID, function (event, ui) {
                        DM_ID.attr('_value', ui.item.id);
                    });
                });
                adm.createFckMin(NoiDung);
                var footer = bd.find('.facebox-footer');
                footer.hide();
                bd.find('.datCauHoiBtn').click(function () {

                    var _DM_ID = DM_ID.attr('_value');
                    var _Ten = Ten.val();
                    var _NguoiTao = NguoiTao.val();
                    var _Email = Email.val();
                    var _Mobile = Mobile.val();
                    var _NoiDung = NoiDung.val();

                    var err = '';
                    if (_DM_ID == '') {
                        err += 'Chọn dịch vụ <br/>';
                    }
                    if (_Ten == '') {
                        err += 'Nhập tên câu hỏi<br/>';
                    }
                    if (_NguoiTao == '') {
                        err += 'Nhập tên của bạn <br/>';
                    }
                    if (_Email == '') {
                        err += 'Nhập e-mail của bạn <br/>';
                    }
                    if (_Mobile == '') {
                        err += 'Nhập điện thoại của bạn <br/>';
                    }
                    if (_NoiDung == '') {
                        err += 'Nhập nội dung câu hỏi<br/>';
                    }
                    if (err != '') {
                        common.fbMsg('Lỗi này bạn ơi', '<h1>Bạn cần chỉnh ngay nhé:</h1>' + err, 400, 'msg-portal-pop', function () {
                            setTimeout(function () {
                                $(document).trigger('close.facebox', 'msg-portal-pop');
                            }, 5000);
                        });
                        return false;
                    }
                    common.fbMsg('Đang xử lý', 'Vui lòng đợi 1 chút bạn nhé...' + err, 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 20000);
                    });
                    $.ajax({
                        url: spaHoiDapMgrFn.urlDefault,
                        data: {
                            'subAct': 'save',
                            '_DM_ID': _DM_ID,
                            '_Ten': _Ten,
                            '_NguoiTao': _NguoiTao,
                            '_Email': _Email,
                            '_Mobile': _Mobile,
                            '_NoiDung': _NoiDung,
                            '_Active': false,
                            '_Hot': false,
                            '_DaTraLoi': false
                        },
                        success: function (_dt) {
                            $(document).trigger('close.facebox', 'msg-portal-pop-processing');

                            if (_dt == '1') {
                                $(document).trigger('close.facebox', 'dk-user');
                                common.fbMsg('Xong rồi này', '<h1>Bạn đã gửi câu hỏi thành công</h1>Chúng tôi sẽ kiểm duyệt trước khi đăng bạn nhé', 400, 'msg-portal-pop', function () {
                                    setTimeout(function () {
                                        $(document).trigger('close.facebox', 'msg-portal-pop');
                                        if (typeof (fn) == "function") {
                                            fn();
                                        }
                                        else {
                                            document.location.reload();
                                        }
                                    }, 5000);
                                    bd.find('input, textarea').val('');
                                    $(document).trigger('close.facebox', 'dat-cau-hoi');
                                });
                            }
                            else {
                                common.fbMsg('Dính lỗi rồi :(( ặc ặc', '<h1>Có lỗi, chán quá vì mình sửa mãi mà nó vẫn bị</h1>' + _dt + '<br/>Copy lỗi trên rùi gửi cho mình nhé: linh_net', 200, 'msg-portal-pop', function () {
                                    setTimeout(function () {
                                        $(document).trigger('close.facebox', 'msg-portal-pop');
                                    }, 5000);
                                });
                            }
                        }
                    });
                });
            });
        });
    },
    datCauHoiDichVu: function (_DM_ID, fn) {
        spaHoiDapMgrFn.loadHtml(function () {
            var newDlg = $('#spaDatCauHoiDichVuMdl-dlgNew');
            common.fbJquery('Đặt câu hỏi', newDlg, 900, 'dat-cau-hoi', function (bd) {
                var Ten = $('.Ten', bd);
                var NguoiTao = $('.NguoiTao', bd);
                var Email = $('.Email', bd);
                var Mobile = $('.Mobile', bd);
                var NoiDung = $('.NoiDung', bd);

                var footer = bd.find('.facebox-footer');
                footer.hide();
                bd.find('.datCauHoiBtn').click(function () {

                    var _Ten = Ten.val();
                    var _NguoiTao = NguoiTao.val();
                    var _Email = Email.val();
                    var _Mobile = Mobile.val();
                    var _NoiDung = NoiDung.val();

                    var err = '';
                    if (_DM_ID == '') {
                        err += 'Chọn dịch vụ <br/>';
                    }
                    if (_Ten == '') {
                        err += 'Nhập tên câu hỏi<br/>';
                    }
                    if (_NguoiTao == '') {
                        err += 'Nhập tên của bạn <br/>';
                    }
                    if (_Email == '') {
                        err += 'Nhập e-mail của bạn <br/>';
                    }
                    if (_Mobile == '') {
                        err += 'Nhập điện thoại của bạn <br/>';
                    }
                    if (_NoiDung == '') {
                        err += 'Nhập nội dung câu hỏi<br/>';
                    }
                    if (err != '') {
                        common.fbMsg('Lỗi này bạn ơi', '<h1>Bạn cần chỉnh ngay nhé:</h1>' + err, 400, 'msg-portal-pop', function () {
                            setTimeout(function () {
                                $(document).trigger('close.facebox', 'msg-portal-pop');
                            }, 5000);
                        });
                        return false;
                    }
                    common.fbMsg('Đang xử lý', 'Vui lòng đợi 1 chút bạn nhé...' + err, 200, 'msg-portal-pop-processing', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 20000);
                    });
                    $.ajax({
                        url: spaHoiDapMgrFn.urlDefault,
                        data: {
                            'subAct': 'save',
                            '_DM_ID': _DM_ID,
                            '_Ten': _Ten,
                            '_NguoiTao': _NguoiTao,
                            '_Email': _Email,
                            '_Mobile': _Mobile,
                            '_NoiDung': _NoiDung,
                            '_Active': false,
                            '_Hot': false,
                            '_DaTraLoi': false
                        },
                        success: function (_dt) {
                            $(document).trigger('close.facebox', 'msg-portal-pop-processing');

                            if (_dt == '1') {
                                $(document).trigger('close.facebox', 'dk-user');
                                common.fbMsg('Xong rồi này', '<h1>Bạn đã gửi câu hỏi thành công</h1>Chúng tôi sẽ kiểm duyệt trước khi đăng bạn nhé', 400, 'msg-portal-pop', function () {
                                    setTimeout(function () {
                                        $(document).trigger('close.facebox', 'msg-portal-pop');
                                        if (typeof (fn) == "function") {
                                            fn();
                                        }
                                        else {
                                            document.location.reload();
                                        }
                                    }, 5000);
                                    bd.find('input, textarea').val('');
                                    $(document).trigger('close.facebox', 'dat-cau-hoi');
                                });
                            }
                            else {
                                common.fbMsg('Dính lỗi rồi :(( ặc ặc', '<h1>Có lỗi, chán quá vì mình sửa mãi mà nó vẫn bị</h1>' + _dt + '<br/>Copy lỗi trên rùi gửi cho mình nhé: linh_net', 200, 'msg-portal-pop', function () {
                                    setTimeout(function () {
                                        $(document).trigger('close.facebox', 'msg-portal-pop');
                                    }, 5000);
                                });
                            }
                        }
                    });
                });
            });
        });
    },
    edit: function () {
        var s = '';
        if (jQuery('#spaHoiDapMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#spaHoiDapMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để sửa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                spaHoiDapMgrFn.loadHtml(function () {
                    var newDlg = $('#spaHoiDapMgrMdl-dlgNew');
                    $(newDlg).dialog({
                        title: 'Sửa',
                        width: 900,
                        buttons: {
                            'Lưu': function () {
                                spaHoiDapMgrFn.save(function () { spaHoiDapMgrFn.clearform(); });
                            },
                            'Lưu và đóng': function () {
                                spaHoiDapMgrFn.save(function () { spaHoiDapMgrFn.clearform(); $(newDlg).dialog('close'); });
                            },
                            'Đóng': function () {
                                $(newDlg).dialog('close');
                            }
                        },
                        open: function () {
                            adm.loading('Đang nạp dữ liệu');
                            adm.styleButton();
                            spaHoiDapMgrFn.clearform();
                            spaHoiDapMgrFn.popfn();
                            $.ajax({
                                url: spaHoiDapMgrFn.urlDefault + '&subAct=edit',
                                dataType: 'script',
                                type: 'POST',
                                data: {
                                    '_ID': s
                                },
                                success: function (_dt) {
                                    adm.loading(null);
                                    var dt = eval(_dt);
                                    var ID = $('.ID', newDlg);
                                    var DM_ID = $('.DM_ID', newDlg);
                                    var HD_ID = $('.HD_ID', newDlg);
                                    var Ten = $('.Ten', newDlg);
                                    var NguoiTao = $('.NguoiTao', newDlg);
                                    var Email = $('.Email', newDlg);
                                    var Mobile = $('.Mobile', newDlg);
                                    var NoiDung = $('.NoiDung', newDlg);
                                    var Active = $('.Active', newDlg);
                                    var DaTraLoi = $('.DaTraLoi', newDlg);
                                    var Hot = $('.Hot', newDlg);
                                    var DoTuoi_ID = $('.DoTuoi_ID', newDlg); 
                                    var spbMsg = $('.admMsg', newDlg);

                                    ID.val(dt.ID);
                                    DM_ID.val(dt._DanhMuc.Ten); DM_ID.attr('_value', dt.DM_ID);
                                    DoTuoi_ID.val(dt.DoTuoi_Ten); DoTuoi_ID.attr('_value', dt.DoTuoi_ID);
                                    HD_ID.val(dt.HD_Ten); HD_ID.attr('_value', dt.HD_ID);

                                    Ten.val(dt.Ten);
                                    NguoiTao.val(dt.NguoiTao);
                                    Email.val(dt.Email);
                                    Mobile.val(dt.Mobile);
                                    NoiDung.val(dt.NoiDung);
                                    if (dt.Active) { Active.attr('checked', 'checked'); } else { Active.removeAttr('checked', 'checked'); }
                                    if (dt.DaTraLoi) { DaTraLoi.attr('checked', 'checked'); } else { DaTraLoi.removeAttr('checked', 'checked'); }
                                    if (dt.Hot) { Hot.attr('checked', 'checked'); } else { Hot.removeAttr('checked', 'checked'); }
                                    spbMsg.html('');
                                }
                            });
                        }
                    });
                });
            }
        }
    },
    del: function () {
        var s = '';
        if (jQuery('#spaHoiDapMgrMdl-List').jqGrid('getGridParam', 'selrow') != null) {
            s = jQuery('#spaHoiDapMgrMdl-List').jqGrid('getGridParam', 'selrow').toString();
        }
        if (s == '') {
            alert('Chọn mẩu tin để xóa');
        }
        else {
            if (s.indexOf(',') != -1) {
                alert('Chọn một mẩu tin');
            }
            else {
                if (confirm('Bạn có chắc chắn xóa danh mục này?')) {
                    $.ajax({
                        url: spaHoiDapMgrFn.urlDefault + '&subAct=del',
                        dataType: 'script',
                        data: {
                            '_ID': s
                        },
                        success: function (dt) {
                            jQuery('#spaHoiDapMgrMdl-List').trigger('reloadGrid');
                        }
                    });
                }
            }
        }
    },
    save: function (fn) {
        var newDlg = $('#spaHoiDapMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var HD_ID = $('.HD_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var DoTuoi_ID = $('.DoTuoi_ID', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var Email = $('.Email', newDlg);
        var Mobile = $('.Mobile', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Active = $('.Active', newDlg);
        var DaTraLoi = $('.DaTraLoi', newDlg);
        var Hot = $('.Hot', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        var _ID = $(ID).val();
        var _DM_ID = DM_ID.attr('_value');
        var _HD_ID = HD_ID.attr('_value');
        var _Ten = Ten.val();
        var _NguoiTao = NguoiTao.val();
        var _Email = Email.val();
        var _Mobile = Mobile.val();
        var _NoiDung = NoiDung.val();
        var _Active = Active.is(':checked');
        var _DaTraLoi = DaTraLoi.is(':checked');
        var _Hot = Hot.is(':checked');
        var _DoTuoi_ID = DoTuoi_ID.attr('_value');
        var err = '';
        if (_Ten == '') { err += 'Nhập tên<br/>'; }
        if (_DM_ID == '') {
            if (_HD_ID == '') {
                err += 'Chọn loại<br/>';
            }
        }
        if (err != '') { spbMsg.html(err); return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: spaHoiDapMgrFn.urlDefault + '&subAct=save',
            dataType: 'script',
            type: 'POST',
            data: {
                '_ID': _ID,
                '_DM_ID': _DM_ID,
                '_HD_ID': _HD_ID,
                '_Ten': _Ten,
                '_NguoiTao': _NguoiTao,
                '_Email': _Email,
                '_Mobile': _Mobile,
                '_NoiDung': _NoiDung,
                '_Active': _Active,
                '_DoTuoi_ID': _DoTuoi_ID,
                '_Hot': _Hot,
                '_DaTraLoi': _DaTraLoi
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    jQuery('#spaHoiDapMgrMdl-List').trigger('reloadGrid');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        })
    },
    add: function () {
        spaHoiDapMgrFn.loadHtml(function () {
            var newDlg = $('#spaHoiDapMgrMdl-dlgNew');
            $(newDlg).dialog({
                title: 'Thêm mới',
                width: 900,
                buttons: {
                    'Lưu': function () {
                        spaHoiDapMgrFn.save(function () {
                            spaHoiDapMgrFn.clearform();
                        }, '#spaHoiDapMgrMdl-List');
                    },
                    'Lưu và đóng': function () {
                        spaHoiDapMgrFn.save(function () {
                            $(newDlg).dialog('close');
                        }, '#spaHoiDapMgrMdl-List');
                    },
                    'Đóng': function () {
                        $(newDlg).dialog('close');
                    }
                },
                open: function () {
                    adm.styleButton();
                    spaHoiDapMgrFn.clearform();
                    spaHoiDapMgrFn.popfn();
                }
            });
        });
    },
    autoComplete: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'spaHoiDapMgrFn-autocomplete-';
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: spaHoiDapMgrFn.urlDefault + '&subAct=autocomplete',
                    dataType: 'script',
                    data: {
                        '_q': request.term
                    },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID
                                    }
                                }
                            }))
                        }
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            },
            change: function (event, ui) {
                if (!ui.item) {
                    if ($(this).val() == '') {
                        $(this).attr('_value', '');
                    }
                }
            },
            delay: 0,
            selectFirst: true
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    autoCompleteCauHoi: function (el, fn) {
        $(el).autocomplete({
            source: function (request, response) {
                var term = 'spaHoiDapMgrFn-autoCompleteCauHoi-';
                if (term in _cache) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.map(_cache[term], function (item) {
                        if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                            return {
                                label: item.Ten,
                                value: item.Ten,
                                id: item.ID
                            }
                        }
                    }))
                    return;
                }

                adm.loading('Nạp danh sách');
                _lastXhr = $.ajax({
                    url: spaHoiDapMgrFn.urlDefault + '&subAct=autoCompleteCauHoi',
                    dataType: 'script',
                    data: {
                        '_q': request.term
                    },
                    success: function (dt, status, xhr) {
                        adm.loading(null);
                        var data = eval(dt);
                        _cache[term] = data;
                        if (xhr === _lastXhr) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response($.map(data, function (item) {
                                if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                    return {
                                        label: item.Ten,
                                        value: item.Ten,
                                        id: item.ID
                                    }
                                }
                            }))
                        }
                    }
                });
            },
            minLength: 0,
            select: function (event, ui) {
                fn(event, ui);
            },
            change: function (event, ui) {
                if (!ui.item) {
                    if ($(this).val() == '') {
                        $(this).attr('_value', '');
                    }
                }
            },
            delay: 0,
            selectFirst: true
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a>" + item.label + "</a>")
				            .appendTo(ul);
        };
    },
    popfn: function () {
        var newDlg = $('#spaHoiDapMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var HD_ID = $('.HD_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var Email = $('.Email', newDlg);
        var Mobile = $('.Mobile', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Active = $('.Active', newDlg);
        var DaTraLoi = $('.DaTraLoi', newDlg);
        var Hot = $('.Hot', newDlg);
        var spbMsg = $('.admMsg', newDlg);
        var DoTuoi_ID = $('.DoTuoi_ID', newDlg);

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBasedByDM('', "TIN-TUC-ROOT", DoTuoi_ID, function (event, ui) {
                DoTuoi_ID.attr('_value', ui.item.id);
            });

            danhmuc.autoCompleteLangBased('', "HOI-DAP", DM_ID, function (event, ui) {
                DM_ID.attr('_value', ui.item.id);
            });
        });

        spaHoiDapMgrFn.autoCompleteCauHoi(HD_ID, function (event, ui) {
            HD_ID.attr('_value', ui.item.id);
        });
        adm.createFckFull(NoiDung);
    },
    clearform: function () {
        var newDlg = $('#spaHoiDapMgrMdl-dlgNew');
        var ID = $('.ID', newDlg);
        var DM_ID = $('.DM_ID', newDlg);
        var DoTuoi_ID = $('.DoTuoi_ID', newDlg);
        var HD_ID = $('.HD_ID', newDlg);
        var Ten = $('.Ten', newDlg);
        var NguoiTao = $('.NguoiTao', newDlg);
        var Email = $('.Email', newDlg);
        var Mobile = $('.Mobile', newDlg);
        var NoiDung = $('.NoiDung', newDlg);
        var Active = $('.Active', newDlg);
        var DaTraLoi = $('.DaTraLoi', newDlg);
        var Hot = $('.Hot', newDlg);
        var spbMsg = $('.admMsg', newDlg);

        ID.val('');
        DoTuoi_ID.val(''); DoTuoi_ID.attr('_value', '');
        DM_ID.val(''); DM_ID.attr('_value', '');
        HD_ID.val(''); HD_ID.attr('_value', '');
        $('input, textarea', newDlg).val('');
        spbMsg.html('');
    },
    loadHtml: function (fn) {
        var dlg = $('#spaHoiDapMgrMdl-dlgNew');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("plugin.spa.SpaHoiDapMgr.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
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
