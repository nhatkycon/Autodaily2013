var urlDefault = adm.urlDefault + '&act=loadPlug&rqPlug=docsoft.plugin.plugManager.Class1, docsoft.plugin.plugManager';
var AjaxBusy = false;
var AjaxBusyTimer;
var AjaxBusyTimeOut = 1000;
///////////////////////
//  Tính năng chính cho Module
//////////////////////
var ModuleFn = function () {


    ///////////////////////
    //  Khi nạp Module
    //////////////////////
    LoadFn();
    function LoadFn() {
        $.each($('.content'), function (i, item) {
            if ($(item).children().length == 0 && $(item).attr('modify').toString().toLowerCase() == 'true') {
                $(item).addClass('contentPlaceHolder');
            }
            else {
                if ($(item).hasClass('contentPlaceHolder')) $(item).removeClass('contentPlaceHolder');
            }
        });
        $.each($('.Module_Edit_Content').find('.Module_Edit_TextArea'), function (i, item) {
            if ($(item).prev().hasClass('wysiwyg')) $(item).prev().remove();
            //$(item).wysiwyg({ css: SiteDomain + 'themes/Default/themes.css' });
            //$(item).wysiwyg();
        });
    }
    ///////////////////////
    //  Nút chỉnh sửa Module
    //////////////////////
    EditBtnFn();
    function EditBtnFn() {
        $.each($('.Module_Task_Edit'), function (i, item) {
            $(item).unbind('click');
            var Module_Edit = $(item).parent().parent().next();
            var Module_Save = $(Module_Edit).next();
            $(item).click(function () {
                if ($(Module_Edit).is(':hidden')) {
                    $(Module_Edit).show();
                    $(Module_Save).show();
                    $(item).html('Lưu');
                    var Module_EditBtnCancel = $(Module_Save).find('.Module_EditBtnCancel');
//                    $(item).find('span').addClass('ui-icon-disk');
//                    $(item).find('span').removeClass('ui-icon-gear');
                    $(Module_EditBtnCancel).click(function () {
                        $(Module_Edit).hide();
                        $(Module_Save).hide();
                        //$(item).html('Sửa');
                    });
                }
                else {
//                    $(item).find('span').removeClass('ui-icon-disk');
//                    $(item).find('span').addClass('ui-icon-gear');
                    $(Module_Edit).hide();
                    $(Module_Save).hide();
                    $(item).html('Sửa');
                }
            });
        });
    }
    SaveFn();
    function SaveFn() {
        $.each($('.Module_EditBtnSave'), function (i, item) {
            $(item).unbind('click');
            $(item).click(function () {
                var Module_Edit = $(item).parent().prev();
                var ii = 0;
                var mdl = $(item).parent().parent();
                var mdlParent = $(mdl).parent();
                var ZoneIndex = $(mdlParent).attr('name'); //Zone mới
                var ModuleIndex = $(mdl).prevAll().length;
                var layPlugId = $(mdl).attr('layplug');
                var plugtype = $(mdl).attr('plugtype');
                var Pages = $(item).attr('Pages');
                var iList = 'PluginIndex|' + ModuleIndex + '|ZoneIndex|' + ZoneIndex + '|';
                $.each($(Module_Edit).find('[pluginfield]'), function (j, jitem) {
                    ii += 1;
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

                var loadData = function () {
                    if (AjaxBusy) {
                        //                        console.log('busy');
                        if (AjaxBusyTimer) clearInterval(AjaxBusyTimer);
                        AjaxBusyTimer = setInterval(loadData, AjaxBusyTimeOut);
                        return (false);
                    }
                    if (AjaxBusyTimer) clearInterval(AjaxBusyTimer);
                    AjaxBusy = true;
                    // Post Ajax Block
                    $(item).html('Đang lưu...');
                    $.post(urlDefault + '&ref=' + Math.random(), {
                        'subAct': 'Update',
                        'iList': iList,
                        'ModuleIndex': parseInt(ModuleIndex) + 1,
                        'ZoneIndex': ZoneIndex,
                        'Pages': Pages,
                        'layplug': layPlugId,
                        'plugtype': plugtype
                    }, function (data) {
                        AjaxBusy = false;
                        var ModuleTitleTxt = $(item).parent().prev().find('.Module_Edit_Title');
                        var ModuleTitleLbl = $(item).parent().prev().prev().find('.Module_Title');
                        $(ModuleTitleLbl).html($(ModuleTitleTxt).val());
                        $(item).parent().next().html(data);
                        $(item).html('Lưu');
                        //ModuleFn();
                    });
                    // End Post Ajax Block
                }
                loadData();
            });
        });
    }
    ///////////////////////
    //  Previews
    //////////////////////
    PreviewsFn();
    function PreviewsFn() {
        var botBarLeftLinkPreview = $('.botBarLeftLinkPreview');
        if ($(botBarLeftLinkPreview).length > 0) {
            $(botBarLeftLinkPreview).unbind('click');
            $(botBarLeftLinkPreview).click(function () {
                //Chuyển chế độ sang Xem thử
                if ($(this).attr('rev') == '0') {
                    $(this).addClass('botBarLeftLinkPreviewSelected');
                    $(this).attr('rev', '1');
                    $.each($('.Module'), function (i, item) {
                        var Module = $(item);
                        var ModuleHeader = $(item).find('.Module_Head');
                        var Module_Foot = $(item).find('.Module_Foot');
                        var Display = $(item).find('input[pluginfield=\'Display\']').is(':checked');
                        if (!Display) {
                            $(Module).hide();
                        }
                        var ShowHeader = $(item).find('input[pluginfield=\'ShowHeader\']').is(':checked');
                        if (!ShowHeader) {
                            $(ModuleHeader).hide();
                        }
                        var ShowBorder = $(item).find('input[pluginfield=\'ShowBorder\']').is(':checked');
                        if (!ShowBorder) {
                            $(Module).css('border', 'none');
                        }
                        var ShowFoot = $(item).find('input[pluginfield=\'ShowFoot\']').is(':checked');
                        if (!ShowFoot) {
                            $(Module_Foot).hide();
                        }
                    });
                    $.each($('.content'), function (i, item) {
                        if ($(item).children().length == 0) {
                            if ($(item).hasClass('contentPlaceHolder')) $(item).removeClass('contentPlaceHolder');
                        }
                    });
                }
                else if ($(this).attr('rev') == '1') {
                    $(this).attr('rev', '0');
                    $(this).removeClass('botBarLeftLinkPreviewSelected');
                    $.each($('.Module'), function (i, item) {
                        var Module = $(item);
                        var ModuleHeader = $(item).find('.Module_Head');
                        var Module_Foot = $(item).find('.Module_Foot');
                        $(Module).css('border', 'solid');
                        $(Module).show();
                        $(ModuleHeader).show();
                        $(Module_Foot).hide();
                    });
                    $.each($('.content'), function (i, item) {
                        if ($(item).children().length == 0) {
                            $(item).addClass('contentPlaceHolder');
                        }
                    });
                }
                $(this).blur();
            });
        }
    }


    ///////////////////////
    //  Nút mở rộng/ thu nhỏ
    //////////////////////
    MiniMizeBtnFn();
    function MiniMizeBtnFn() {
        $.each($('.Module_Task_Maximize'), function (i, item) {
            $(item).unbind('click');
            var Module_Body = $(item).parent().parent().parent().find('.Module_Body');
            $(item).click(function () {
                if ($(Module_Body).is(':hidden')) {
                    $(Module_Body).show();
                    $(item).html('Thu nhỏ');
//                    $(item).find('span').addClass('ui-icon-circle-triangle-s');
//                    $(item).find('span').removeClass('ui-icon-circle-triangle-n');
                }
                else {
                    $(Module_Body).hide();
                    $(item).html('Mở rộng');
//                    $(item).find('span').addClass('ui-icon-circle-triangle-n');
//                    $(item).find('span').removeClass('ui-icon-circle-triangle-s');
                }
            });
        });
    }
    ///////////////////////
    //  đóng Module
    //////////////////////
    CloseBtnFn();
    function CloseBtnFn() {
        $.each($('.Module_Task_Close'), function (i, item) {
            $(item).unbind('click');
            var Module = $(item).parent().parent().parent();
            $(item).click(function () {
                var con = confirm('Bạn có muốn xóa bỏ Module này không?');
                if (con) {
                    var mdl = $(item).parent().parent().parent();
                    var mdlParent = $(mdl).parent();
                    var ZoneIndex = $(mdlParent).attr('name'); //Zone mới
                    var ModuleIndex = $(mdl).prevAll().length;
                    var Pages = $(mdlParent).parent().attr('name');
                    var layPlugId = $(mdl).attr('layplug');
                    var plugtype = $(mdl).attr('plugtype');
                    var iList = 'PluginIndex|' + ModuleIndex + '|ZoneIndex|' + ZoneIndex + '|';
                    $(Module).remove();
                    LoadFn();
                    var loadData = function () {
                        if (AjaxBusy) {
                            //                        console.log('busy');
                            if (AjaxBusyTimer) clearInterval(AjaxBusyTimer);
                            AjaxBusyTimer = setInterval(loadData, AjaxBusyTimeOut);
                            return (false);
                        }
                        if (AjaxBusyTimer) clearInterval(AjaxBusyTimer);
                        AjaxBusy = true;
                        // Post Ajax Block
                        $.post(urlDefault + '&ref=' + Math.random(), {
                            'subAct': 'Remove',
                            'ModuleIndex': parseInt(ModuleIndex) + 1,
                            'ZoneIndex': ZoneIndex,
                            'PagesAlias': Pages,
                            'iList': iList,
                            'Pages': Pages,
                            'layplug': layPlugId,
                            'plugtype': plugtype

                        }, function (data) {
                            AjaxBusy = false;
                        });
                        // End Post Ajax Block
                    }
                    loadData();
                }
            });
        });
    }
    ///////////////////////
    //  Kéo thả module
    //////////////////////
    TabFn();
    function TabFn() {
        $.each($('.Module_Edit_TabBtn'), function (i, item) {
            $(item).unbind('click');
            $(item).click(function () {
                $(item).blur();
                if ($(item).hasClass('Module_Edit_Tab_Active')) return (false);
                $(item).parent().children('.Module_Edit_Tab_Active').addClass('Module_Edit_Tab_DeActive').removeClass('Module_Edit_Tab_Active');
                $(item).addClass('Module_Edit_Tab_Active').removeClass('Module_Edit_Tab_DeActive');
                $(item).parent().next().children('.Module_Edit_ContentBox').hide();
                $(item).parent().next().children('div[name=\'' + $(item).attr('rev') + '\']').show();
            });
        });
    }

    ///////////////////////
    //  Kéo thả module
    //////////////////////
    MoveFn();
    var OldUi;
    var OldZone;
    function MoveFn() {
        $('.content').sortable({
            opacity: 0.5,
            helper: 'clone',
            revert: true,
            items: 'div.Module',
            placeholder: 'ModuleOnDrag',
            handle: 'div.Module_Head',
            dropOnEmpty: true,
            connectWith: '.content',
            stop: function (event, ui) {
                var j = 0;
                var iList = '';
                LoadFn();
                var mdl = ui.item;
                var mdlParent = $(mdl).parent();
                var layplugId = $(mdl).attr('layplug');
                var NewZoneIndex = $(mdlParent).attr('name'); //Zone mới
                var NewModuleIndex = $(mdl).prevAll().length; // vị trí của Plugin trong zone mới
                var OldZoneIndex = $(OldZone).attr('name'); //Zone cũ
                var OldModuleIndex = $(OldUi).attr('moduleindex'); //vị trí của Plugin trong zone cũ

                // Lưu lại trên client vị trí mới
                $(mdl).attr('zoneindex', NewZoneIndex);
                $.each($(OldUi).parent().children(), function (ji, _mdl) {
                    $(_mdl).attr('moduleindex', $(_mdl).prevAll().length + 1);
                });
                $.each($(mdl).parent().children(), function (ji, _mdl) {
                    $(_mdl).attr('moduleindex', $(_mdl).prevAll().length + 1);
                });
                if (OldZoneIndex == NewZoneIndex && OldModuleIndex == (parseInt(NewModuleIndex) + 1)) return;
                var newModuleOrder = '';
                var zj = 0;
                $.each($(mdlParent).children(), function (ji, _mdl) {
                    newModuleOrder += $(_mdl).attr('layplug') + ',' + zj + ';';
                    zj++;
                });
                $.post(urlDefault + '&ref=' + Math.random(), {
                    'subAct': 'ReOrder',
                    'PagesAlias': $('.LayOut').attr('name'),
                    'OldZoneIndex': OldZoneIndex,
                    'NewZoneIndex': NewZoneIndex,
                    'OldModuleIndex': OldModuleIndex,
                    'NewModuleIndex': parseInt(NewModuleIndex) + 1,
                    'layplug': layplugId,
                    'NewZoneOrderList': newModuleOrder
                }, function (data) {
                });
            },
            start: function (event, ui) {
                var onDrag = ui.item;
                var helper = ui.helper;
                $('.ModuleOnDrag').css('height', $(onDrag).height());
                OldUi = ui.item;
                OldZone = $(OldUi).parent();
            }
        }).disableSelection();
    }
}

var myModule = {
    add: function (id, url) {
        //alert(id + ' - ' + url);
        var layid = $('.contentNull');
        if ($(layid).length < 1) {
            alert('Chưa vùng nào');
            return false;
        }
        else {
            var layIdValue = $(layid).eq(0).attr('name');
        }
        $.ajax({
            url: urlDefault + '&ref=' + Math.random(),
            dataType: 'script',
            data: {
                'subAct': 'Add',
                'FN_ID': id,
                'Url': url,
                'LayID': layIdValue
            },
            success: function (dt) {
                adm.loading(null);
                layid.eq(0).prepend(dt);
            }
        });

    }
}
ModuleFn();
