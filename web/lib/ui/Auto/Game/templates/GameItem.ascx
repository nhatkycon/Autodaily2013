<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GameItem.ascx.cs" Inherits="lib_ui_Auto_Game_templates_GameItem" %>
<div data-id="<%=Item.ID %>" class="well Game-Item">
    <div class="pull-right">
        <a data-id="<%=Item.ID %>" href="javascript:;" class="btn edit">
            <i class="icon icon-edit"></i>
        </a>
        <a data-id="<%=Item.ID %>" href="javascript:;" class="btn remove">
            <i class="icon icon-remove"></i>
        </a>        
    </div>
    <div class="viewpnl">
        <a target="_blank" href="/lib/pages/Game/GameView.aspx?ID=<%=Item.ID %>" class="btn">
            <i class="icon icon-link"></i>
        </a>
        <span class="Ten">
            <%=Item.Ten %>             
        </span>
        <a target="_blank" href="/lib/pages/Game/Game.aspx?ID=<%=Item.ID %>" class="btn">
            <i class="icon icon-picture"></i>
        </a>
    </div>
    <div class="editPnl">
        
    </div>
</div>