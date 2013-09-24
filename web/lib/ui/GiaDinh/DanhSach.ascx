<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSach.ascx.cs" Inherits="lib_ui_GiaDinh_DanhSach" %>
<%@ Import Namespace="docsoft" %>
<%@ Register src="~/lib/ui/GiaDinh/templates/GiaDinhItem.ascx" tagname="GiaDinhItem" tagprefix="uc1" %>
<%if(List.Any()){ %>
<div class="gd-view-list">
    <asp:Repeater runat="server" ID="postList">
         <ItemTemplate>
            <uc1:GiaDinhItem ID="GiaDinhItem1" item='<%# Container.DataItem %>' runat="server" />             
         </ItemTemplate>
     </asp:Repeater>
</div>
     
<%}else
  {%>
       <div class="post-box effect6">
         <div class="gd-view-item row-fluid">
             <div class="span2"></div>
             <div class="span8">
                 <div class="p-title">
                     Hiện tại chưa nhập thành viên gia đình nào cho bé <b><%=BeItem.Alias %></b>
                 </div>
                 <%if (BeItem != null && BeItem.Username == Security.Username)
                   { %>
                   <hr/>
                    <a href="#AddGiaDinhDialog" data-toggle="modal" class="btn btn-primary btn-large">Thêm thành viên ngay!</a>
                 <% } %>
             </div>
             <div class="span2"></div>
         </div>
     </div>  
<%  } %>