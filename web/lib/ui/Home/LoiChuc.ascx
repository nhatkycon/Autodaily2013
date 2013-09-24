<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoiChuc.ascx.cs" Inherits="lib_ui_Home_LoiChuc" %>
<%@ Import Namespace="docsoft" %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="block-title">
                <i class="block-title-icon icon-magic"></i>
                <a href="javascript:;" class="block-title-lbl">Lời chúc</a>
            </div>                    
        </div>
        <div class="block-body">
            <div class="media-list lc-list">
                <%foreach(var Item in List){ %>
                    <div class="media">
                        <%if(!string.IsNullOrEmpty(Item._Member.Anh)){ %>
                        <a class="pull-left" href="/lib/pages/CaNhan/Profile.aspx?U=<%=Item.Username %>">
                            <img class="media-object" src="/lib/up/i/<%=Item._Member.Anh %>">
                        </a>
                        <%} %>
                        <div class="media-body">
                            <h3 class="media-heading">
                                <%if(Security.Username== BeItem.Username){ %>
                                    <a href="javascript:;" class="btn loiChucXoaBtn pull-right" data-id="<%=Item.ID %>">
                                        <i class="icon icon-remove"></i>
                                    </a>            
                                <%} %>
                                <a name="<%=Item.ID %>" href="/lib/pages/CaNhan/Profile.aspx?U=<%=Item.Username %>"><%=Item._Member.Ten %></a>
                            </h3>
                            <%=Item.NoiDung %>
                            <br/>
                            <div class="loiChuc-ngayTao">
                            Vào lúc: <%=Item.NgayTao.ToString("HH:mm dd-MM-yyyy") %>                                
                            </div>
                        </div>
                    </div>
                <%} %>
            </div>  
            <%if(BeItem!= null && BeItem.Username != Security.Username && Security.IsAuthenticated()){ %>
            <div class="controls lc-home-post lc-post-box">
                <textarea name="textarea" class="input-xlarge"></textarea>
                <button data-id="<%=BeItem.ID %>" class="btn btn-large" type="button">Gửi lời chúc</button>
            </div>
            <%} %>
        </div>
    </div>
</div>