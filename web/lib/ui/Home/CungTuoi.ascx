<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CungTuoi.ascx.cs" Inherits="lib_ui_Home_CungTuoi" %>
<%@ Import Namespace="docsoft" %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header block-header-liner">
            <div class="block-title">
                <i class="block-title-icon icon-list"></i>
                <a href="javascript:;" class="block-title-lbl">Bé cùng tuổi với <%=BeItem.Alias %></a>
            </div>                    
        </div>
        <div class="block-body">
           <%if(List.Any()){ %>
            <% foreach (var item in List)
               {%>
               <div class="YeuThich-Item BeYeuThich-Item">
                   <div class="row-fluid">
                       <div class="span6">
                           <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=item.ID %>" class="YeuThich-Item-img-box">
                               <img src="/lib/up/avatar/<%=item.Anh %>" class="YeuThich-Item-img"/>
                           </a>        
                       </div>
                       <div class="span6">
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
                <div class="span1"></div>
                <div class="span10">
                    <div class="p-title">Không có bé nào cùng tuổi <%=BeItem.Alias %>!<br/>
                    <%=BeItem.Alias %> thật khác biệt! ^ ^
                    </div>
                </div>
                <div class="span1"></div>
            </div>
            <%} %>
        </div>
    </div>
</div>