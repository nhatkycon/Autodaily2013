<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TimKiem.ascx.cs" Inherits="lib_ui_heThong_TimKiem" %>
<div class="row-fluid">
      <div class="full-content effect6 BeYeuThichList">
            <h2>
                <i class="icon icon-user icon-large"></i>
                Kết quả tìm kiếm
            </h2>
            <hr/>
            <%if(List.Any()){ %>
            <% foreach (var item in List)
               {%>
               <div class="YeuThich-Item BeYeuThich-Item">
                   <div class="row-fluid">
                       <div class="span2">
                           <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=item.ID %>" class="YeuThich-Item-img-box">
                               <img src="/lib/up/avatar/<%=item.Anh %>" class="YeuThich-Item-img"/>
                           </a>        
                       </div>
                       <div class="span10">
                           <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=item.ID %>" class="YeuThich-Item-ten">
                               <%=item.Alias %>
                           </a>        
                       </div>
                   </div>
                   <hr/>
               </div>
            <%} %>
            <%}else{ %>
            <div class="row-fluid">
                <div class="span3"></div>
                <div class="span4">
                    <div class="p-title">Không có bé nào phù hợp bạn ơi!<br/>
                    Thử tìm với từ khóa khác bạn nhé</div>
                </div>
                <div class="span3"></div>
            </div>
            <%} %>
        </div>  
</div>