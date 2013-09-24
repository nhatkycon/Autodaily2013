<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CoverImage.ascx.cs" Inherits="lib_ui_Home_CoverImage" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="post-box effect2">
    <div class="be-cover">
        <div class="be-cover-content">               
        <%if(BeItem != null && Security.Username == BeItem.Username){ %>
            <div class="be-cover-box">
                <%if(BeItem != null && !string.IsNullOrEmpty(BeItem.Cover)){ %>
                    <img style="<%=BeItem.CoverCss%>" data-id="<%=BeItem.ID %>" class="be-image draggable" src="/lib/up/avatar/<%=BeItem.Cover %>"/>
                <%}else{ %>
                    <img data-id="<%=BeItem.ID %>" class="be-image draggable be-image-empty"/>
                <%} %>
            </div>
            <div class="be-cover-doiAnhBtn" data-id="<%=BeItem.ID %>" >
                <a href="javascript:" class="btn btn-success ">Đổi ảnh</a>            
            </div>
            <div class="be-cover-keoBtn">
                <button class="btn btn-large">
                    <i class="icon icon-align-justify icon-large"></i>
                    Kéo ảnh để thay đổi vị trí
                </button>
            </div>
        <%}
          else
          {%>
              <div class="be-cover-box">
                <%if(BeItem != null && !string.IsNullOrEmpty(BeItem.Cover)){ %>
                    <img style="<%=BeItem.CoverCss%>" class="be-image" src="/lib/up/avatar/<%=BeItem.Cover %>"/>
                <%}else{ %>
                    <img class="be-image be-image-empty"/>
                <%} %>
                </div>
         <% } %>
        </div>
    </div>    
</div>
<meta property="og:title" content="Nhật ký của <%= BeItem.Alias %>" />
<meta property="og:description" content="Nhật ký, album ảnh, video của bé <%=BeItem.Alias%>" />
<% if (!string.IsNullOrEmpty(BeItem.Anh))
    { %>
<meta property="og:image" content="/lib/up/avatar/<%=BeItem.Anh %>" />
<% }%>