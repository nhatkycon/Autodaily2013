<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Post_List.ascx.cs" Inherits="lib_ui_Home_Post_List" %>
<%@ Import Namespace="linh.common" %>
<%@ Register src="/lib/ui/nhatKy/templates/Post_PureTemplate.ascx" tagname="Post_PureTemplate" tagprefix="uc1" %>
<div class="capNhat-list">
<%if(List != null){%>
     <asp:Repeater runat="server" ID="postList">
         <ItemTemplate>
            <uc1:Post_PureTemplate ID="Post_PureTemplate1" runat="server" Item='<%# Container.DataItem %>' />
         </ItemTemplate>
     </asp:Repeater>
     <%if(List.Count>9){ %>
     <div class="post-box effect6">
         <div class="post post-more" data-id="<%=Request["ID"] %>">
             <div class="row-fluid">
                 <div class="span5">
                 
                 </div>
                 <div class="span3">
                 <button data-date="<%=List.Last().NgayViet.ToString("yyyy-MM-dd HH:mm:s") %>" data-id="<%=Request["ID"] %>" class="btn btn-info post-more-btn">
                     Xem thêm
                 </button>                 
                 </div>
                 <div class="span4">
                 
                 </div>    
             </div>
         </div>
     </div>
     <%} %>
<%} else{%>
<%} %>
</div>
