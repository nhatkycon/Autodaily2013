<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Post_ViewTemplate.ascx.cs" Inherits="lib_ui_nhatKy_templates_Post_ViewTemplate" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<% switch (Item.Loai)
    {%>
        <%case 1: %>
        <div class="post-view">
            <div class="post" data-id="<%=Item.ID %>">
                <div class="post-date">
                    <span class="post-date-lbl">Ngày</span>
                    <span class="post-date-day"><%= Item.NgayViet.Day %></span>
                    <span class="post-date-separate">/</span>
                    <span class="post-date-month"><%= Item.NgayViet.ToString("MM/yy") %></span>
                    <span class="post-date-lbl">, lúc </span>
                    <span class="post-date-time"><%= Item.NgayViet.ToString("hh:mm") %></span>
                </div>
                <div class="post-task">
                    <%if(Item.Username==Security.Username){ %>
                    <a data-id="<% =Item.ID %>" href="javascript:;" class="icon-remove icon-large post-remove">
                    </a>
                    <%}else{ %>
                    <a data-id="<% =Item.ID %>" href="javascript:;" class="icon-heart icon-large post-likeBtn<% = Item.Thich ? " liked" : "" %>">
                    </a>
                    <%} %>
                </div>
                <div class="post-body">
                    <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" class="post-title"><%=Item.Ten %></a>
                    <%if (!string.IsNullOrEmpty(Item.Anh)){ %>
                    <span class="post-img-box post-img-box-view">
                        <img src="/lib/up/i/<%=Item.Anh %>" class="post-img"/>                        
                    </span>
                    <%} %>
                    <hr/>
                    <div class="post-content">
                        <%=Item.NoiDung %>
                    </div>
                </div>
                <div class="post-footer">
                    <span class="post-age">
                        <%=Lib.TinhTuoi(Item.BeItem.MangThai, Item.BeItem.MangThai ? Item.BeItem.NgayDuSinh : Item.BeItem.NgaySinh, Item.NgayViet)%>
                    </span>
                    <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" class="post-comments">
                        <i class="icon-comment icon-large"></i>
                        <%if (Item.LuotBinhLuan > 0)
                          { %>
                            <%= Item.LuotBinhLuan %>&nbsp;
                        <% }%>
                        Bình luận
                    </a>
                    <div class="post-fbLikeBox">
                        <div class="fb-like" data-href="http://nhatkycon.com/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" data-send="true" data-layout="button_count" data-width="120" data-show-faces="false"></div>
                    </div>
                </div>
            </div>
        </div>
        <meta property="og:title" content="Nhật ký: <%=Item.Ten %>" />
        <meta property="og:description" content="<%=Lib.Rutgon(Giga.Common.Lib._string.getHTML(Item.NoiDung),300) %>" />
        <% if (!string.IsNullOrEmpty(Item.Anh))
            { %>
        <meta property="og:image" content="/lib/up/i/<%=Item.Anh %>" />
        <% }%>
        <%break;%>

        <%case 2: %>
        <div class="post-view">
            <div class="post" data-id="<%=Item.ID %>">
                <div class="post-date">
                    <span class="post-date-lbl">Ngày</span>
                    <span class="post-date-day"><%= Item.NgayViet.Day %></span>
                    <span class="post-date-separate">/</span>
                    <span class="post-date-month"><%= Item.NgayViet.ToString("MM/yy") %></span>
                    <span class="post-date-lbl">, lúc </span>
                    <span class="post-date-time"><%= Item.NgayViet.ToString("hh:mm") %></span>
                    <span class="post-event">
                        <i class="icon-calendar"></i>
                        <%=Item.HoatDong_Ten%>
                    </span>
                </div>
                <div class="post-task">
                    <%if(Item.Username==Security.Username){ %>
                    <a data-id="<% =Item.ID %>" href="javascript:;" class="icon-remove icon-large post-remove">
                    </a>
                    <%}else{ %>
                    <a data-id="<% =Item.ID %>" href="javascript:;" class="icon-heart icon-large post-likeBtn<% = Item.Thich ? " liked" : "" %>">
                    </a>
                    <%} %>
                </div>
                <div class="post-body">
                    <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" class="post-title"><%=Item.Ten %></a>
                    <span class="post-img-box">
                        <img src="/lib/up/i/<%=Item.Anh %>" class="post-img"/>                        
                    </span>
                    <div class="post-content">
                        <%=Item.NoiDung %>
                    </div>
                </div>
                <div class="post-footer">
                    <span class="post-age">
                        <%=Lib.TinhTuoi(Item.BeItem.MangThai, Item.BeItem.MangThai ? Item.BeItem.NgayDuSinh : Item.BeItem.NgaySinh, Item.NgayViet)%>
                    </span>
                    <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" class="post-comments">
                        <i class="icon-comment icon-large"></i>
                        <%if (Item.LuotBinhLuan > 0)
                          { %>
                            <%= Item.LuotBinhLuan %>&nbsp;
                        <% }%>
                        Bình luận
                    </a>
                    <div class="post-fbLikeBox">
                        <div class="fb-like" data-href="http://nhatkycon.com/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" data-send="true" data-layout="button_count" data-width="120" data-show-faces="false"></div>
                    </div>
                </div>
            </div>
        </div>
        <meta property="og:title" content="Sự kiện: <%=Item.Ten %>" />
        <meta property="og:description" content="<%=Lib.Rutgon(Giga.Common.Lib._string.getHTML(Item.NoiDung),300) %>" />
        <% if (!string.IsNullOrEmpty(Item.Anh))
            { %>
        <meta property="og:image" content="/lib/up/i/<%=Item.Anh %>" />
        <% }%>
        <%break;%>
                
        <%case 3: %>
        <div class="post-view">
            <div class="post" data-id="<%=Item.ID %>">
                <div class="post-date">
                    <span class="post-date-lbl">Ngày</span>
                    <span class="post-date-day"><%= Item.NgayViet.Day %></span>
                    <span class="post-date-separate">/</span>
                    <span class="post-date-month"><%= Item.NgayViet.ToString("MM/yy") %></span>
                    <span class="post-date-lbl">, lúc </span>
                    <span class="post-date-time"><%= Item.NgayViet.ToString("hh:mm") %></span>
                </div>
                <div class="post-task">
                    <%if(Item.Username==Security.Username){ %>
                    <a data-id="<% =Item.ID %>" href="javascript:;" class="icon-remove icon-large post-remove">
                    </a>
                    <%}else{ %>
                    <a data-id="<% =Item.ID %>" href="javascript:;" class="icon-heart icon-large post-likeBtn<% = Item.Thich ? " liked" : "" %>">
                    </a>
                    <%} %>
                </div>
                <div class="post-body">
                    <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" class="post-title"><%=Item.Ten %></a>
                    <div class="post-video-box">
                        <iframe width="520" height="293" src="http://www.youtube.com/embed/<%=Item.VideoUrl %>" frameborder="0" allowfullscreen></iframe>                            
                    </div>
                </div>
                <div class="post-footer">
                    <span class="post-age">
                        <%=Lib.TinhTuoi(Item.BeItem.MangThai, Item.BeItem.MangThai ? Item.BeItem.NgayDuSinh : Item.BeItem.NgaySinh, Item.NgayViet)%>
                    </span>
                    <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" class="post-comments">
                        <i class="icon-comment icon-large"></i>
                        <%if (Item.LuotBinhLuan > 0)
                          { %>
                            <%= Item.LuotBinhLuan %>&nbsp;
                        <% }%>
                        Bình luận
                    </a>
                    <div class="post-fbLikeBox">
                        <div class="fb-like" data-href="http://nhatkycon.com/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" data-send="true" data-layout="button_count" data-width="120" data-show-faces="false"></div>
                    </div>
                </div>
            </div>
        </div>
        <meta property="og:title" content="Video: <%=Item.Ten %>" />
        <meta property="og:description" content="Video <%=Item.Ten %> của bé" />
        <% if (!string.IsNullOrEmpty(Item.Anh))
            { %>
        <meta property="og:image" content="/lib/up/i/<%=Item.Anh %>" />
        <% }%>
        <meta property="og:type" content="video">
        <meta property="og:video" content="http://www.youtube.com/v/<%=Item.VideoUrl %>?autohide=1&amp;version=3">
        <meta property="og:video:type" content="application/x-shockwave-flash">
        <meta property="og:video:width" content="640">
        <meta property="og:video:height" content="360">
        <%break;%>
                
        <%case 4: %>
        <div class="post-view">
            <div class="post" data-id="<%=Item.ID %>">
                <div class="post-date">
                    <span class="post-date-lbl">Ngày</span>
                    <span class="post-date-day"><%= Item.NgayViet.Day %></span>
                    <span class="post-date-separate">/</span>
                    <span class="post-date-month"><%= Item.NgayViet.ToString("MM/yy") %></span>
                    <span class="post-date-lbl">, lúc </span>
                    <span class="post-date-time"><%= Item.NgayViet.ToString("hh:mm") %></span>
                    <a style="margin-left: 10px;" href="/lib/pages/NhatKy/Album.aspx?ID=<%=Item.AB_ID %>" class="btn">
                        <i class="icon icon-picture"></i>
                    </a>
                </div>
                <div class="post-task">
                    <%if(Item.Username==Security.Username){ %>
                    <a data-id="<% =Item.ID %>" href="javascript:;" class="icon-remove icon-large post-remove">
                    </a>
                    <%}else{ %>
                    <a data-id="<% =Item.ID %>" href="javascript:;" class="icon-heart icon-large post-likeBtn<% = Item.Thich ? " liked" : "" %>">
                    </a>
                    <%} %>
                </div>
                <div class="post-body">
                    <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" class="post-title"><%=Item.Ten %></a>
                    
                    <%if(Item.Anhs != null){ %>
                    <% foreach (var anh in Item.Anhs)
                        {%>
                        <a href="/lib/pages/NhatKy/Album.aspx?ID=<%=Item.AB_ID %>" class="post-img-box post-img-box-view">
                            <img src="/lib/up/anh/<%=anh.FileAnh %>" class="post-img"/>                        
                        </a>
                    <%} %>
                    <%} %>
                </div>
                <div class="post-footer">
                    <span class="post-age">
                        <%=Lib.TinhTuoi(Item.BeItem.MangThai, Item.BeItem.MangThai ? Item.BeItem.NgayDuSinh : Item.BeItem.NgaySinh, Item.NgayViet)%>
                    </span>
                    <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" class="post-comments">
                        <i class="icon-comment icon-large"></i>
                        <%if (Item.LuotBinhLuan > 0)
                          { %>
                            <%= Item.LuotBinhLuan %>&nbsp;
                        <% }%>
                        Bình luận
                    </a>
                    <div class="post-fbLikeBox">
                        <div class="fb-like" data-href="http://nhatkycon.com/lib/pages/NhatKy/Post.aspx?ID=<%=Item.ID %>" data-send="true" data-layout="button_count" data-width="120" data-show-faces="false"></div>
                    </div>
                </div>
            </div>
        </div>
        <meta property="og:title" content="Album ảnh: <%=Item.Ten %>" />
        <meta property="og:description" content="Album ảnh <%=Item.Ten %>" />
        <% if (!string.IsNullOrEmpty(Item.Anh))
            { %>
        <meta property="og:image" content="http://NhatKyCon.Vn/lib/up/i/<%=Item.Anh %>" />
        <% }%>
        <%break;%>                
        <%default: %>
        <%break;%>
    <% } %>