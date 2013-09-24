<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_TheoDoi_DanhSach" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="full-content effect6">
    <div class="row-fluid">
        <%if(List.Any()){ %>
                <div class="p-title">
                     Danh sách theo dõi của bé <b><%=BeItem.Alias %></b>
                 </div>
                 <hr/>
                <% foreach (var item in List)
                   {%>
                   <p class="well well-small">
                       <a class="p-subTitle" href="/lib/pages/TheoDoi/View.aspx?BCTD_ID=<%=item.ID %>&ID=<%=item.PID_ID %>">
                           <i class="icon icon-signal"></i>&nbsp;                                                                                                    
                           <%=item.Ten %>
                           <span class="pull-right">
                                <i class="icon icon-share"></i>
                            </span>
                        </a>
                   </p> 
                <%   } %>  
        <%}else{ %>
            <div class="span2"></div>
             <div class="span8">
                 <div class="p-title">
                     Hiện tại bé <b><%=BeItem.Alias %></b> chưa có bảng theo dõi nào
                 </div>
                 <%if (BeItem != null && BeItem.Username == Security.Username)
                   { %>
                   <hr/>
                    <a href="#AddBaoCaoTheoDoiDialog" data-toggle="modal" class="btn btn-primary btn-large">Thêm bảng theo dõi ngay!</a>
                 <% } %>
             </div>
             <div class="span2"></div>
        <%} %>
    </div>
</div>