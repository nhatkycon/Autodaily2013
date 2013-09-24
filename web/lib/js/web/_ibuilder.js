var dropStyle = '';
jQuery(function () {
    $('.toolbox-item').click(function () {
        var item = $(this);
        var _url = item.attr('_url');
        if (item.hasClass('toolbox-item-active')) return false;
        item.parent().find('.toolbox-item-active').removeClass('toolbox-item-active');
        item.addClass('toolbox-item-active');
        item.parent().next().find('.toolbox-body-active').removeClass('toolbox-body-active');
        item.parent().next().find('[_ref=\'' + item.attr('_ref') + '\']').addClass('toolbox-body-active');
        if (_url == '') return false;
        var _load = item.parent().next().find('.toolbox-body-active').attr('_load');
        if (_load == '1') return false;
        $.ajax({
            url: domain + '/lib/ajax/',
            data: {
                'ref': Math.random(),
                'act': _url
            },
            success: function (dt) {
                item.parent().next().find('.toolbox-body-active').attr('_load', '1');
                item.parent().next().find('.toolbox-body-active').find('.toolbox-mainContent').html(dt);
                if (_url == 'portal-module-get') {
                    homeFn.dragFn();
                }
                else {
                    $.each($('.thm-item'), function (i, _itemcss) {
                        var itemCss = $(_itemcss);
                        itemCss.unbind('click').click(function () {
                            var _kyhieu = itemCss.attr('_kyhieu');
                            var _locate = itemCss.attr('_locate');
                            var _id = itemCss.attr('_id');
                            var css = $('#css');
                            css.attr('href', _locate);
                            $.ajax({
                                url: domain + '/lib/ajax/',
                                data: {
                                    'ref': Math.random(),
                                    'act': 'saveThemes',
                                    'kyHieu': _kyhieu,
                                    'id': _id
                                },
                                success: function (_dtN) {
                                    itemCss.parent().find('.thm-item-active').removeClass('thm-item-active');
                                    itemCss.addClass('thm-item-active');
                                }
                            });
                        });
                    });
                }
            }
        });
    });
    $('.toolbox-cancel').click(function () {
        var item = $(this);
        item.parent().parent().parent().parent().find('.toolbox-item-active').removeClass('toolbox-item-active');
        item.parent().parent().parent().find('.toolbox-body-active').removeClass('toolbox-body-active');
    });
    homeFn.moveFn();
    var slideShowTimer;
    var slideShowInterval = 2000;
    var slideShowInt = 0;
    jQuery.each(jQuery('li', '.navi-top-m'), function (i, _item) {
        var item = jQuery(_item);

        var flyOut = item.find('.navi-top-m-item-list-div');
        var aItem = item.find('.navi-top-item');
        if (jQuery(flyOut).length > 0) {
            item.mouseenter(function () {
                aItem.addClass('navi-top-item-focus');
                var previousItem = item.prev();
                if ($(previousItem).length > 0) {
                    previousItem.find('.navi-top-item').addClass('navi-top-item-prev');
                }
                getEl(item, function (_t, _l, _w, _t1) {
                    flyOut.show().css({ 'left': (_l) + 'px', 'top': (_t1 - 1) + 'px' });
                    item.mouseleave(function () {
                        flyOut.hide();
                        aItem.removeClass('navi-top-item-focus');
                        if ($(previousItem).length > 0) {
                            previousItem.find('.navi-top-item').removeClass('navi-top-item-prev');
                        }
                    });
                });
            });
        }
    });

    $('.navi-top-m').find('.navi-top-item:last').addClass('navi-top-item-last');
    $('.tin-lienQuan-body').find('.tin-item:last').addClass('tin-item-last');
    $('.item-danhMuc-pnl:last').addClass('item-danhMuc-pnl-last');

    var searchBtn = jQuery('.search-btn');
    searchBtn.click(function () {
        var searchTxt = jQuery('.search-txt');
        var _txt = searchTxt.val();
        var _gh_id = $(searchBtn).attr('_GH_ID');
        var _gh_alias = $(searchBtn).attr('_GH_Alias');
        var _Lang = $(searchBtn).attr('_Lang');
        document.location.href = domain + '/lib/pages/store/TimKiemGianHang.aspx?q=' + _txt + '&GH_ID=' + _gh_id + '&GH_Alias=' + _gh_alias + '&Lang=' + _Lang;
    });

    var searchTxt = jQuery('.search-txt');
    searchTxt.focus(function () {
        searchTxt.unbind('keypress').bind('keypress', function (evt) {
            if (evt.keyCode == 13) {
                var _txt = searchTxt.val();
                if (_txt == '') { alert('Vui lòng nhập từ khóa để tìm kiếm'); searchTxt.focus(); return false; }
                var _gh_id = $(searchBtn).attr('_GH_ID');
                var _gh_alias = $(searchBtn).attr('_GH_Alias');
                var _Lang = $(searchBtn).attr('_Lang');
                document.location.href = domain + '/lib/pages/store/TimKiemGianHang.aspx?q=' + _txt + '&GH_ID=' + _gh_id + '&GH_Alias=' + _gh_alias + '&Lang=' + _Lang;
                return false;
            }
        });
    });

    function getEl(el, fn) {
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

    $.each($('.tin-item-anh'), function (i, _item) {
        var item = $(_item);
        item.error(function () {
            item.parent().remove();
        });
    });

});
var homeFn = {
    moveFn: function () {
        $.each($('.zone-content'), function (i, _item) {
            if ($(_item).children().length == 0 && $(_item).attr('modify').toString().toLowerCase() == 'true') {
                $(_item).addClass('contentPlaceHolder');
            }
            else {
                if ($(_item).hasClass('contentPlaceHolder')) $(_item).removeClass('contentPlaceHolder');
            }
        });
        $('.zone-content').sortable({
            opacity: 1,
            //helper: 'clone',
            revert: true,
            items: 'div.mdl',
            placeholder: 'mdlDrag',
            handle: '.mdl-move-icon',
            dropOnEmpty: true,
            connectWith: '.zone-content',
            helper: function () {
                return $("<div class='mdl-helper'></div>");
            },
            receive: function () {
            },
            stop: function (event, ui) {
                if (dropStyle != 'move') return false;
                $.each($('.zone-content'), function (i, _item) {
                    if ($(_item).children().length == 0 && $(_item).attr('modify').toString().toLowerCase() == 'true') {
                        $(_item).addClass('contentPlaceHolder');
                    }
                    else {
                        if ($(_item).hasClass('contentPlaceHolder')) $(_item).removeClass('contentPlaceHolder');
                    }
                });
                var item = ui.item;
                var l = '';
                var c = 0;
                $.each($('.zone'), function (i, _zone) {
                    var zone = $(_zone);
                    i = 0;
                    $.each(zone.find('.mdl'), function (i, _mdl) {
                        var mdl = $(_mdl);
                        i++;
                        l += mdl.attr('id') + '|' + zone.attr('id') + '|' + i + ',';
                    });
                });
                common.loading('Đang lưu');
                $.ajax({
                    url: domain + '/lib/ajax/' + _url,
                    data: {
                        'ref': Math.random(),
                        'act': 'portal-module-move',
                        'settings': l
                    },
                    success: function () {
                        common.loading(null);
                    }
                });
            },
            start: function (event, ui) {
                dropStyle = 'move';
            }
        }).disableSelection();
        $('.mdl').mouseenter(function () {
            var item = $(this);
            item.find('.mdl-head').show();
            item.mouseleave(function () {
                item.find('.mdl-head').hide();
            });
        });

        $('.mdl-tool-del').unbind('click').click(function () {
            var item = $(this);
            var _confirm = confirm('Bạn muốn xóa bỏ module này?');
            if (_confirm) {
                var _id = item.attr('_id');
                common.loading('Lưu');
                $.ajax({
                    url: domain + '/lib/ajax/',
                    data: {
                        'ref': Math.random(),
                        'act': 'portal-module-del',
                        'id': _id
                    },
                    success: function () {
                        common.loading(null);
                        item.parent().parent().parent().hide(1000).remove();
                        $.each($('.zone-content'), function (i, _item) {
                            if ($(_item).children().length == 0 && $(_item).attr('modify').toString().toLowerCase() == 'true') {
                                $(_item).addClass('contentPlaceHolder');
                            }
                            else {
                                if ($(_item).hasClass('contentPlaceHolder')) $(_item).removeClass('contentPlaceHolder');
                            }
                        });
                        common.fbMsg('Xóa thành công', 'Bạn đã xóa thành công module', 200, 'msg-portal-pop', function () {
                            setTimeout(function () {
                                $(document).trigger('close.facebox', 'msg-portal-pop');
                            }, 1000);
                        });
                    }
                });
            }
        });
        $('.mdl-tool-edit').unbind('click').click(function () {
            var item = $(this);
            var _id = item.attr('_id');
            var _type = item.attr('_type');
            
            common.fbAjax('Sửa', domain + '/lib/ajax/', { 'act': 'portal-module-edit', 'id': _id }, 600, 'edit-mdl-' + _id, function (b) {
                common.createFck($('textarea', b));
                var footer = b.find('.facebox-footer');
                $('<a href=\"javascript:;\" class=\"globalSave\">Lưu</a>').appendTo(footer).click(function () {
                    var iList = '';

                    $.each(b.find('[pluginfield]'), function (j, jitem) {
                        var inputName = $(jitem).get(0).tagName.toLocaleLowerCase();
                        var inputValue = '';
                        var inputType = $(jitem).attr('type').toLocaleLowerCase();
                        if (inputName == 'select') {
                            inputValue = $(jitem).children('option:selected').val();
                            iList += $(jitem).attr('pluginfield') + '|' + inputValue + '|';
                        }
                        else {
                            if (inputType == 'checkbox') {
                                inputValue = $(jitem).is(':checked');
                                iList += $(jitem).attr('pluginfield') + '|' + inputValue + '|';
                            }
                            else {
                                inputValue = $(jitem).val().replace('|', ' ');
                                if (inputValue != '') {
                                    iList += $(jitem).attr('pluginfield') + '|' + inputValue + '|';
                                }
                            }
                        }
                    });

                    $.post(domain + '/lib/ajax/Default.aspx' + _url, {
                        'act': 'portal-module-save',
                        'iList': iList,
                        'id': _id,
                        'type': _type
                    }, function (_dt) {
                        var mdl = $('[id=\"' + _id + '\"]').eq(0);
                        $(mdl).find('.mdl-body').html(_dt);
                        common.fbMsg('Lưu thành công', 'Bạn đã lưu thành công ', 200, 'msg-portal-pop', function () {
                            setTimeout(function () {
                                $(document).trigger('close.facebox', 'msg-portal-pop');
                            }, 1000);
                        });
                    });
                });
            });
        });
    },
    dragFn: function () {
        $(".module-store div.mdl-store-item").draggable({
            containment: 'document',
            opacity: 0.6,
            //revert: true,
            zIndex: 100,
            helper: function () {
                return $("<div class='mdl-helper'></div>");
            },
            stop: function (event, ui) {
                dropStyle = 'add';
            },
            start: function () {
                dropStyle = 'add';
            }
        });
        $('.zone-content').droppable({
            activeClass: "zone-content-active",
            hoverClass: "zone-content-hover",
            accept: "div.mdl-store-item",
            drop: function (event, ui) {
                var _zone = $(this);
                var _type = ui.draggable.attr('_type');
                var _id = ui.draggable.attr('_id');
                //var _index = $(_zone).index('.zone-content') + 1;
                var _index = $(_zone).parent().attr('id');
                $.ajax({
                    url: domain + '/lib/ajax/' + _url,
                    data: {
                        'ref': Math.random(),
                        'act': 'portal-module-render',
                        'type': _type,
                        'id': _id,
                        'index': _index
                    },
                    success: function (_dt) {
                        //_zone.append(_dt);
                        $(_dt).prependTo(_zone);
                        homeFn.moveFn();
                    }
                });
            }
        })
    }
};