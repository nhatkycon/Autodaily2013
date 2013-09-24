<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TheoDoi_Edit.ascx.cs" Inherits="lib_ui_TheoDoi_TheoDoi_Edit" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<%@ Register src="~/lib/ui/TheoDoi/AddTheoDoi.ascx" tagname="AddTheoDoi" tagprefix="uc2" %>
<div class="full-content effect6">
    <div class="row-fluid">
        <div class="span2">
            <a href="/lib/pages/TheoDoi/View.aspx?BCTD_ID=<%=ItemBaoCao.ID %>&ID=<%=ItemBaoCao.PID_ID %>" class="btn btn-default btn-large">
                <i class="icon icon-chevron-sign-left"></i> Quay lại
            </a>    
        </div>
        <div class="span10">
            <div class="album-view-ten p-title">Chỉnh sửa <%=Item.Ten%> của bé <%=BeItem.Alias %></div>
        </div>
    </div>
    <hr class="hr"/>  
    <div class="TheoDoi-View">
        <table class="table table-hover">
            <thead>
            <tr>
                   <td>
                       Ngày ghi
                   </td>
                   <td>
                       Mốc
                   </td>
                   <td>
                       Chiều cao/dài
                   </td>
                   <td>
                       Chiều cao/dài chuẩn
                   </td>
                   <td>
                       Cân nặng
                   </td>
                   <td>
                       Cân nặng chuẩn
                   </td>
                   <td>
                       
                   </td>
               </tr>    
            </thead>
            
            <% foreach (var item in List)
               {%>
               <tr data-id="<%=item.ID %>">
                   <td>
                       <%= item.NgayGhi==DateTime.MinValue? "" : item.NgayGhi.ToString("dd/MM/yy") %>
                   </td>
                   <td>
                       <%=item._DanhMuc.Ten %>
                   </td>
                   <td>
                       <%=item.ChieuCao %>
                   </td>
                   <td>
                       <%=item._DanhMuc.GiaTri%>
                   </td>
                   <td>
                       <%=item.CanNang %>
                   </td>
                   <td>
                       <%=item._DanhMuc.Ma %>
                   </td>
                   <td>
                       <%if(ItemBaoCao.Username==Security.Username){ %>
                       <div class=" pull-right">                           
                           <button data-id="<%=item.ID %>" class="btn theoDoiSuaBtn">
                               <i class="icon icon-edit"></i>
                               Sửa
                           </button>    
                       </div>
                       <%} %>
                   </td>
               </tr>
            <%  } %>
        </table>
    </div>   
</div>
<uc2:AddTheoDoi ID="AddTheoDoi1" runat="server" />
