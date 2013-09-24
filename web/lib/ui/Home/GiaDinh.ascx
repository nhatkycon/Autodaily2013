<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GiaDinh.ascx.cs" Inherits="lib_ui_Home_GiaDinh" %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="block-title">
                <i class="block-title-icon icon-group"></i>
                <a href="/lib/pages/NhatKy/GiaDinh.aspx?ID=<%=BeItem.ID %>" class="block-title-lbl">Gia đình</a>
            </div>                    
        </div>
        <div class="block-body">
            <%if(List!= null){ %>
            <script>
                var mySwipe;
            </script>
            <div id="gd-slider" class="swipe gd-slider">
                <div class="swipe-wrap">
                    <% foreach (var item in List)
                       {%>
                        <div>
                            <div class="gd-item">
                                <img class="gd-img" src="/lib/up/i/<%=item.Anh %>"/>
                                <div class="gd-overlay">
                                    <a onclick="mySwipe.next()" href="javascript:;" class="gd-slider-navigator-next">
                                        <i class="icon-chevron-sign-right icon-large"></i>    
                                    </a>
                                    <a onclick="mySwipe.prev()" href="javascript:;" class="gd-slider-navigator-prev">
                                        <i class="icon-chevron-sign-left icon-large"></i>    
                                    </a>
                                    <span class="gd-item-name">
                                        <%=item.LOAI_Ten %>: <%=item.Ten %>
                                    </span>                                        
                                        
                                </div>
                            </div> 
                        </div>
                    <%} %>
                    
                </div>
            </div>  
            <%} %>                  
        </div>
    </div>
</div>
<script src="/lib/js/swipe.js" type="text/javascript"></script>
<script>
    bcy1Fn.GiaDinhSliderHome();    
</script>
