<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_ajax_LuuBut_Default" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="docsoft.entities" %>
<%switch(act){ %>
    <%case "view": %>
    <% Item = LoiChucDal.SelectById(new Guid(Request["ID"])); %>
    <div class="media">
        <%if(!string.IsNullOrEmpty(Item._Member.Anh)){ %>
        <a class="pull-left" href="javascript:;">
            <img class="media-object" src="/lib/up/i/<%=Item._Member.Anh %>">
        </a>
        <%} %>
        <div class="media-body">
            <h3 class="media-heading">
                <%if(Security.Username== Item.Username){ %>
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
    <% break; %>
    
    <%default: break; %>
<% } %>