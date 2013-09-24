<%@ Control Language="C#" AutoEventWireup="true" CodeFile="YeuThich.ascx.cs" Inherits="lib_ui_CaNhan_YeuThich" %>
<div class="row-fluid">
    <div class="span6">
      <div class="full-content effect6 BeYeuThichList">
            <h2>
                <i class="icon icon-user icon-large"></i>
                Bé yêu thích
            </h2>
            <hr/>
            <% foreach (var item in beYeuThich.List)
               {%>
               <div class="YeuThich-Item BeYeuThich-Item">
                   <div class="row-fluid">
                       <div class="span4">
                           <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=item.ID %>" class="YeuThich-Item-img-box">
                               <img src="/lib/up/avatar/<%=item.Anh %>" class="YeuThich-Item-img"/>
                           </a>        
                       </div>
                       <div class="span6">
                           <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=item.ID %>" class="YeuThich-Item-ten">
                               <%=item.Alias %>
                           </a>        
                       </div>
                       <div class="span2">
                           <a href="javascript:;" class="btn btn-default btn-large UnLikeBtn" data-id="<%=item.ID %>">
                               <i class="icon icon-remove"></i>
                           </a>
                       </div>
                   </div>
                   <hr/>
               </div>
            <%} %>
        </div>  
    </div>
    <div class="span6">
      <div class="full-content effect6 PostYeuThichList">
            <h2>
                <i class="icon icon-edit-sign icon-large"></i>
                Post yêu thích
            </h2>
            <hr/>
            <% foreach (var item in postYeuThich.List)
               {%>
               <div class="YeuThich-Item BeYeuThich-Item">
                   <div class="row-fluid">
                       <div class="span4">
                           <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=item.ID %>" class="YeuThich-Item-img-box">
                               <img src="/lib/up/i/<%=item.Anh %>" class="YeuThich-Item-img"/>
                           </a>        
                       </div>
                       <div class="span6">
                           <a href="/lib/pages/NhatKy/Post.aspx?ID=<%=item.ID %>" class="YeuThich-Item-ten">
                               <%=item.Ten %>
                           </a>        
                       </div>
                       <div class="span2">
                           <a href="javascript:;" class="btn btn-default btn-large UnLikeBtn" data-id="<%=item.ID %>">
                               <i class="icon icon-remove"></i>
                           </a>
                       </div>
                   </div>
                   <hr/>
               </div>
            <%} %>
        </div>  
    </div>
</div>
<script src="/lib/js/web/CaNhan.js" type="text/javascript"></script>