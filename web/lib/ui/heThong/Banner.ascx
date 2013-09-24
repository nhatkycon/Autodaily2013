<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Banner.ascx.cs" Inherits="lib_ui_heThong_Banner" %>
<%@ Import Namespace="docsoft" %>
<div class="banner">
    <div class="globalBox">
    <div class="banner-right">
        <%if(Security.IsAuthenticated()){ %>
            <div class="dropdown">
                <a href="javascript:;" class="dropdown-toggle" id="dLabel"  data-target="#"  data-toggle="dropdown">
                  Chào  
                  <strong>
                  <%=Security.Username %>!                      
                  </strong>
                  &nbsp;
                    <i class="icon-user icon-large icon-2x">                    
                    </i>
                </a>
                <ul class="dropdown-menu" role="menu" aria-labelledby="dLabel">
                    <li>
                        <a href="/lib/pages/CaNhan/YeuThich.aspx">
                            <i  class="icon-heart icon-large"></i> &nbsp; Yêu thích
                        </a>
                    </li>
                    <li>
                        <a href="/lib/pages/CaNhan/">
                            <i  class="icon-cog icon-large"></i> &nbsp; Cá nhân
                        </a>
                    </li>
                    <li>
                        <a href="/lib/pages/HeThong/HuongDan.aspx">
                            <i  class="icon icon-info icon-large"></i> &nbsp; Hướng dẫn
                        </a>
                    </li>
                    <li class="divider"></li>
                    <li>
                        <a href="javascript:;">
                            <i class="icon-off icon-large log-out">
                            </i>&nbsp; Thoát
                         </a>
                    </li>
                </ul> 
            </div>
        <%}else{%>
            <a href="#loginDialog" data-toggle="modal">
                <i class="icon-lock icon-large icon-2x">
                </i>
                Đăng nhập
            </a>                   
            <a href="/lib/pages/HeThong/Register.aspx">
                <i class="icon-user icon-large icon-2x">
                </i>
                Tạo nhật ký cho con bạn
            </a> 
        <%} %>
    </div>
    <a href="/" class="logo"></a>
    <div class="top-navi">
        <a  data-toggle="tooltip" class="icon-home icon-large icon-2x" title="Trang chủ, danh sách các bé" href="/lib/pages/CaNhan/QuanLyBe.aspx">
        </a> 
        <a  data-toggle="tooltip" class="icon-comments icon-large icon-2x" title="Hỏi đáp, cùng nuôi bé" href="/lib/pages/HoiDap/">
        </a> 
        <a  data-toggle="tooltip" class="icon-book icon-large icon-2x" title="Bài viết hữu ích cùng nuôi bé" href="/lib/pages/Tin/">
        </a> 
    </div>
    <div id="custom-search-form" class="form-search">
        <div class="input-append"><input class="search-query" type="text" id="" placeholder="Tìm bé" name="">
        <a href="/lib/pages/HeThong/TimKiem.aspx" class="add-on"><i class="icon-search"></i></a></div>
    </div>
    </div>
</div>
<script>
    $('.top-navi a').tooltip({placement : 'bottom' });
</script>    
