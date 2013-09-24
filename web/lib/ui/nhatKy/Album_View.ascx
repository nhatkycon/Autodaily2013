<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Album_View.ascx.cs" Inherits="lib_ui_nhatKy_Album_View" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="full-content effect6">
    <div class="row-fluid">
        <div class="span2">
            <a href="Default.aspx?ID=<%=AlbumItem.P_RowId %>" class="btn btn-default btn-large">
                <i class="icon icon-chevron-sign-left"></i> Quay lại
            </a>    
        </div>
        <div class="span8">
            <div class="album-view-ten p-title"><%=AlbumItem.Ten %></div>
        </div>
        <%if(AlbumItem.NguoiTao==Security.Username){ %>
        <div class="span2" style="text-align: right;">
            <a class="btn btn-success btn-large" href="Album_Add.aspx?AB_ID=<%=AlbumItem.ID %>&ID=<%=AlbumItem.P_RowId %>">
                <i class="icon icon-edit-sign"></i> Sửa
            </a>
        </div>
        <%} %>
    </div>
    <hr class="hr"/>     
    <%if (List.Any())
      {%>  
      <script>
          var albumSwipe;
          var albumSwipeRender = false;
    </script>
     <div class="album-view-anh view-anh-slider">
        <% foreach (var item in List)
           {%>
            <div data-url="/lib/pages/NhatKy/Anh-view.aspx?ID=<%= item.ID %>" data-id="<%= item.ID %>" data-full="<%= Lib.imgSize(item.FileAnh, "full") %>" class="anh-album-view-item">
                <a class="anh-img-box">
                    <img src="/lib/up/anh/<%= item.FileAnh %>" class="anh-img"/>                    
                </a>
            </div>                                  
        <% } %>
    </div>
    <div class="album-view-anh view-anh-sliderView" style="display: none;">
        <p>
            <button class="btn btn-default btn-large closeViewBtn pull-right">
                <i class="icon icon-remove icon-large"></i>
            </button>
            <br/><br/>
        </p>
        <hr>
        <div id="album-view-slider" class="swipe album-view-swipe">
            <div class="swipe-wrap">
                <% foreach (var item in List)
                   {%>
                    <div data-url="/lib/pages/NhatKy/Anh-view.aspx?ID=<%= item.ID %>" data-id="<%= item.ID %>" data-full="<%= Lib.imgSize(item.FileAnh, "full") %>" class="anh-album-slide-item">
                        <div class="anh-album-slide-item-overlay">
                            <a onclick="albumSwipe.next()" href="javascript:;" class="gd-slider-navigator-next">
                                <i class="icon-chevron-sign-right icon-large"></i>    
                            </a>
                            <a onclick="albumSwipe.prev()" href="javascript:;" class="gd-slider-navigator-prev">
                                <i class="icon-chevron-sign-left icon-large"></i>    
                            </a>
                            <span class="anh-album-ten">
                                <%=item.Ten %>
                            </span>                                        
                        </div>
                        <div class="anh-img-box">
                            <img src="/lib/up/anh/<%= Lib.imgSize(item.FileAnh,"full") %>" class="anh-img"/>                    
                        </div>
                        
                    </div>                                  
                <% } %>
            </div>
        </div>        
    </div>
    <% } %>
    <hr/>
    <div class="fb-like" data-href="http://nhatkycon.com/lib/pages/NhatKy/Album.aspx?ID=<%=AlbumItem.ID %>" data-send="true" data-layout="button_count" data-width="120" data-show-faces="false"></div>
</div>
<script src="/lib/js/swipe.js" type="text/javascript"></script>

