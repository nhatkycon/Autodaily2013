<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CauHoiCuaToi.ascx.cs" Inherits="lib_ui_HoiDap_CauHoiCuaToi" %>
<% int i = 1; %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="block-title">
                
               <div class="block-title-lbl">
                   Danh sách câu hỏi mà bạn đã tạo
               </div>
            </div>
        </div>
        <div class="block-body thang-list-box">
        <% foreach (var item in List)
           {%>   
             <div class="hoiDap-my-item">
                 <a href="/lib/pages/HoiDap/View.aspx?ID=<%=item.ID %>">
                    <%=i %>. &nbsp; <%=item.Ten %>
                 </a>
                 <div class="pull-right">
                     <%if (item.DaTraLoi)
                       { %>
                       <span class="label label-success">Đã trả lời</span>
                     <% }
                       else
                       {%>
                       <span class="label">Chưa có trả lời</span>  
                      <% } %>
                      &nbsp;
                      <a class="btn" href="/lib/pages/HoiDap/View.aspx?ID=<%=item.ID %>">
                        <i class="icon icon-arrow-right"></i>
                    </a>
                 </div>
             </div>  
             <% i++; %>
        <% } %>
        </div>
    </div>
</div>