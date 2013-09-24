<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TheoDoiView.ascx.cs" Inherits="lib_ui_TheoDoi_templates_TheoDoiView" %>
<tr data-id="<%=Item.ID %>">
    <td>
        <%= Item.NgayGhi==DateTime.MinValue? "" : Item.NgayGhi.ToString("dd/MM/yy") %>
    </td>
    <td>
        <%=Item._DanhMuc.Ten %>
    </td>
    <td>
        <%=Item.ChieuCao %>
    </td>
    <td>
        <%=Item._DanhMuc.GiaTri%>
    </td>
    <td>
        <%=Item.CanNang %>
    </td>
    <td>
        <%=Item._DanhMuc.Ma %>
    </td>
    <td>
        <div class=" pull-right">                           
            <button data-id="<%=Item.ID %>" class="btn theoDoiSuaBtn">
                <i class="icon icon-edit"></i>
                Sửa
            </button>    
        </div>
    </td>
</tr>