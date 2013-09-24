<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_ajax_Post_Default" %>
<%@ Import Namespace="docsoft.entities" %>
<%@ Import Namespace="linh.common" %>
<%@ Import Namespace="linh.core.dal" %>
<%@ Register src="/lib/ui/nhatKy/templates/Post_PureTemplate.ascx" tagname="Post_PureTemplate" tagprefix="uc1" %>
<uc1:Post_PureTemplate Visible="False" ID="Post_PureTemplate1" runat="server" />
<%if(List != null){%>
     <asp:Repeater Visible="False" runat="server" ID="postList">
         <ItemTemplate>
            <uc1:Post_PureTemplate ID="Post_PureTemplate2" runat="server" Item='<%# Container.DataItem %>' />
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