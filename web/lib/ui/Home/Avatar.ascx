<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Avatar.ascx.cs" Inherits="lib_ui_Home_Avatar" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<%@ Register src="~/lib/ui/CaNhan/DoiNick.ascx" tagname="DoiNick" tagprefix="uc1" %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="pull-right">
                <%if(BeItem != null && Security.Username == BeItem.Username){ %>
                    <a data-id="<% =BeItem.ID %>" href="/lib/pages/CaNhan/SuaBe.aspx?ID=<%=BeItem.ID %>" class="btn">
                        <i  class="icon icon-edit"></i>
                    </a>    
                <%}else{ %>           
                    <a data-id="<% =BeItem.ID %>" href="javascript:;" class="icon-heart icon-large be-likeBtn post-likeBtn<% = BeItem.Thich ? " liked" : "" %>">
                    </a>         
                <%} %>                
            </div>
            <div class="block-title">
                <span class="block-title-lbl"><%=BeItem.Alias %></span>
            </div>                    
        </div>                        
        <div class="block-body">
            <div class="be-infobox">
                <%if (!string.IsNullOrEmpty(BeItem.Ten) && !string.IsNullOrEmpty(BeItem.Ho)){ %>
                <%=BeItem.Ho %> <%=BeItem.Ten %> - 
                <%}
                  else
                  {%>    
                  <%=BeItem.Alias %> đang được 
                  <%} %>
                <%=Lib.TinhTuoi(BeItem.MangThai, BeItem.MangThai ? BeItem.NgayDuSinh : BeItem.NgaySinh)%>
                
            </div>
            
            <div class="avartar-box avatar-320 avatar-home">
                <%if(BeItem != null && !string.IsNullOrEmpty(BeItem.Anh)){ %>
                    <img class="avatar-img" src="/lib/up/avatar/<%=BeItem.Anh %>"/>
                <%}else{ %>
                    <img class="avatar-img avatar-img-empty"/>
                <%} %>
                <%if(BeItem != null && Security.Username == BeItem.Username){ %>
                <div class="avatar-img-doiAnhBtn" data-id="<%=BeItem.ID %>" >
                    <a href="javascript:" class="btn btn-success ">Đổi ảnh</a>            
                </div>
                <%} %>                
                
            </div>  
        </div>
    </div>
</div>
