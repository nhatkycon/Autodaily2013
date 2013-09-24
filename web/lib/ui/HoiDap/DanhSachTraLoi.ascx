<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSachTraLoi.ascx.cs" Inherits="lib_ui_HoiDap_DanhSachTraLoi" %>
<%@ Import Namespace="docsoft" %>
<%@ Register src="~/lib/ui/HoiDap/TraLoi.ascx" tagname="TraLoi" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/HoiDap/templates/traLoi.ascx" tagname="traLoi" tagprefix="uc2" %>
<div class="block-box effect6">
    <div class="block">
        <div class="block-header">
            <div class="block-title">
                <div class="block-title-lbl">                    
               </div>
               <%if(Security.IsAuthenticated()){ %>
               <div class="pull-right">
                   <a href="#AddTraLoiDialog" data-toggle="modal"  class="btn btn-primary btn-large">
                    <i class="icon icon-reply"></i> Trả lời câu hỏi
                </a> 
               </div>
              <uc1:TraLoi ID="TraLoi1" runat="server" />
               <%} %>
            </div>
        </div>
              <br clear="all"/>
        <div class="block-body thang-list-box traLoi-list-box">
            <%if(List!= null && List.Any()){ %>
                <asp:Repeater runat="server" ID="postList">
                     <ItemTemplate>
                        <uc2:traLoi ID="traLoi2" runat="server" Item='<%# Container.DataItem %>'/>
                     </ItemTemplate>
                 </asp:Repeater>
            <%}
              else
              {%>
              <hr/>
              <div class="row-fluid">
                  <div class="span3"></div>
                  <div class="span6">
                      <p class="p-subTitle">Chưa có câu trả lời nào</p>
                  </div>
                  <div class="span3"></div>
              </div>  
            <%  } %>
        </div>
    </div>
</div>

