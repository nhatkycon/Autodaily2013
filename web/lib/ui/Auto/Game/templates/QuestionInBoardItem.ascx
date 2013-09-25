<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuestionInBoardItem.ascx.cs" Inherits="lib_ui_Auto_Game_templates_QuestionInBoardItem" %>
<%if(Item.Active){ %>
<a href="/lib/pages/Game/Question.aspx?ID=<%=Item.ID %>" class="view view-tenth">
    <img src="/lib/up/i/<%=Item.Anh %>">
    <span class="mask">
        <h2>
            <%=Item.ThuTu %>
        </h2>
    </span>
</a>
<%}else{ %>
<a href="/lib/pages/Game/Question.aspx?ID=<%=Item.ID %>" class="view view-inActive">
    <img src="/lib/up/i/<%=Item.Anh %>">
    <span class="mask">
        <h2>
            <%=Item.ThuTu %>
        </h2>
    </span>
</a>
<%} %>