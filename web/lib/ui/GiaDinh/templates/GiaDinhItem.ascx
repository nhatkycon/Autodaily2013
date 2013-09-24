<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GiaDinhItem.ascx.cs" Inherits="lib_ui_GiaDinh_templates_GiaDinhItem" %>
<%@ Import Namespace="docsoft" %>
<div class="post-box effect6">
         <div class="gd-view-item row-fluid">
             <div class="span7">
                 <div class="gd-img-box">
                     <img class="gd-img" src="/lib/up/i/<%=item.Anh %>"/>
                     <div class="gd-overlay">
                         <span class="gd-item-name">
                            <%=item.LOAI_Ten %>: <%=item.Ten %>
                        </span>           
                     </div>
                 </div>
             </div>
             <div class="span4">
                 <div class="gd-noiDung">
                     <%if (item.Username == Security.Username)
                       { %>
                        <a data-id="<% = item.ID %>" href="javascript:;" class="btn gd-remove pull-right">
                            <i class="icon-remove icon-large"></i>
                        </a>
                     <% } %>
                     <%=item.NoiDung %>
                 </div>
             </div>
         </div>
     </div>