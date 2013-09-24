<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile.ascx.cs" Inherits="lib_ui_CaNhan_Profile" %>
<%@ Import Namespace="docsoft" %>
<div class="full-content effect6">
    <div class="row-fluid">
        <div class="span4">
            <div class="blog-post-img-box">
                <img class="blog-post-img" src="/lib/up/i/<%=Item.Anh %>" />
            </div>   
        </div>
        <div class="span8">            
            <div class="p-title">
                <%if(Security.Username!=Item.Username){ %>
                <div class="pull-right">
                    <a data-id="<% =Item.RowId %>" href="javascript:;" class="icon-heart icon-large pull-right post-likeBtn<% = Item.Thich ? " liked" : "" %>"></a>                    
                </div>
                <%}
                  else
                  {%>
                    <a href="/lib/pages/CaNhan/Default.aspx" class="icon icon-edit icon-large pull-right"></a>  
                  <%} %>
                  <div class="p-title">
                    <%=Item.Ten %>
                  </div>
            </div>
            <hr/>
            <div class="p-subTitle">
                Danh sách nhật ký của <%=Item.Ten %>
            </div>
            <div class="">
                <% foreach (var item in List)
                {%>
                <hr/>
                <div class="YeuThich-Item BeYeuThich-Item">
                    <div class="row-fluid">
                        <div class="span3">
                            <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=item.ID %>" class="YeuThich-Item-img-box">
                                <img src="/lib/up/avatar/<%=item.Anh %>" class="YeuThich-Item-img"/>
                            </a>        
                        </div>
                        <div class="span7">
                            <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=item.ID %>" class="YeuThich-Item-ten">
                                <%=item.Alias %>
                            </a>        
                        </div>
                        <div class="span2">
                            <a href="/lib/pages/CaNhan/SuaBe.aspx?ID=<%=item.ID %>" class="btn btn-default btn-large UnLikeBtn" data-id="<%=item.ID %>">
                                <i class="icon icon-edit"></i>
                            </a>
                        </div>
                    </div>
                </div>
            <%} %>
            </div>
        </div>
    </div>
</div>