<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuestionItem.ascx.cs" Inherits="lib_ui_Auto_Game_templates_QuestionItem" %>
<div class="QuestionItem" data-id="<%=Item.ID %>">
    <div class="well viewPnl">
        <div class="row-fluid">
            <div class="span3">
                <img class="img-rounded" src="/lib/up/i/<%=Item.AnhDaiDien %>"/>
            </div>
            <div class="span4">
                <%=Item.Ten %>
            </div>
            <div class="span1">
                <%if(Item.Active){ %>
                    <input type="checkbox" checked="checked" data-id="<%=Item.ID %>"/>
                <%}else{ %>
                    <input type="checkbox" data-id="<%=Item.ID %>"/>
                <%} %>
            </div>
            <div class="span4">
                <div class="pull-right">
                    <a data-id="<%=Item.ID %>" href="javascript:;" class="btn edit">
                        <i class="icon icon-edit"></i>
                    </a>
                    <a data-id="<%=Item.ID %>" href="javascript:;" class="btn remove">
                        <i class="icon icon-remove"></i>
                    </a> 
                </div>
            </div>
        </div>
    </div>
    <div class="editPnl">
        
    </div>
</div>