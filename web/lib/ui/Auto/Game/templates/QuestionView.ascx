<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuestionView.ascx.cs" Inherits="lib_ui_Auto_Game_templates_QuestionView" %>
<%@ Import Namespace="linh.common" %>
<script>
    var albumSwipe;
</script>
<div class="fs-top">
    <div class="logo-small"></div>
</div>
<div id="album-view-slider" class="swipe fs-slider">
    <div class="swipe-wrap">
        <% foreach (var item in List)
            {%>
            <div class="img-fs" style="background-image: url(//auto.vn/lib/up/i/<%= Lib.imgSize(item.Anh,"full") %>);">
            </div>                                  
        <% } %>
    </div>
</div>
<div class="view-rs" data-show="0" style="background-image: url(//auto.vn/lib/up/i/<%= Item.Anh %>);">    
    <div class="view-rs-Ten">
        <%=Item.Ten %>
    </div>
    <div class="view-rs-MoTa">
        <%=Item.MoTa %>
    </div>
</div>

<div class="overlay-fs">
    <div class="overlay-fs-pnl">
        <a href="/lib/pages/Game/Game.aspx?ID=<%=Item.G_ID %>">
            <i class="icon-home icon-large icon-3x"></i>    
        </a>
        <a onclick="albumSwipe.next()" href="javascript:;">
            <i class="icon-chevron-sign-right icon-large icon-3x"></i>    
        </a>
        <a onclick="albumSwipe.prev()" href="javascript:;">
            <i class="icon-chevron-sign-left icon-large icon-3x"></i>    
        </a>
        <a  class="showRs" href="javascript:;">
            <i class="icon-check icon-large icon-3x"></i>    
        </a>    
    </div>
</div>
<script src="/lib/js/swipe.js" type="text/javascript"></script>
<script>
    $(function () {
        albumSwipe = Swipe(document.getElementById('album-view-slider'));
        $('.showRs').click(function() {
            var viewrs = $('.view-rs');
            var slider = $('.fs-slider');
            var shown = viewrs.attr('data-show');
            if (shown == '0') {
                viewrs.show();
                slider.hide();
                viewrs.attr('data-show','1');
            }
            else if(shown == '1') {
                viewrs.hide();
                slider.show();
                viewrs.attr('data-show', '0');
            }
        });
        var overlayfs = $('.overlay-fs');
        overlayfs.mouseenter(function() {
            overlayfs.find('a').show();
            overlayfs.addClass('bg');
        });
        overlayfs.mouseleave(function () {
            overlayfs.find('a').hide();
            overlayfs.removeClass('bg');
        });
        
        $.ajax({
            url: domain + '/lib/ajax/Game/Default.aspx?ref=' + Math.random(),
            data: {
                subAct: 'updateQuestionActive',
                ID: '<% =Item.ID %>',
                Active: false
            },
            success: function (dt) {
                
            }
        });

    })
</script>

<style>
    
    body {
        overflow: hidden;
    }
   
</style>