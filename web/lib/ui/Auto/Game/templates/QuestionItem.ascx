<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuestionItem.ascx.cs" Inherits="lib_ui_Auto_Game_templates_QuestionItem" %>
<div class="QuestionItem" data-id="<%=Item.ID %>">
    <div class="well viewPnl">
        <div class="row-fluid">
            <div class="span3">
                <img class="img-rounded adm-upload-preview-img-60" src="/lib/up/i/<%=Item.AnhDaiDien %>"/>
            </div>
            <div class="span4">
                STT:<b><%=Item.ThuTu %></b><br/>
                <%=Item.Ten %><br/>
                <i><%=Item.MoTa %></i>
            </div>
            <div class="span1">
                <%if(Item.Active){ %>
                    <input type="checkbox" checked="checked" data-id="<%=Item.ID %>"/>
                <%}else{ %>
                    <input class="questionViewCheckbox" type="checkbox" data-id="<%=Item.ID %>"/>
                <%} %>
            </div>
            <div class="span4">
                <div class="pull-right">
                    <a data-id="<%=Item.ID %>" href="javascript:;" class="btn btn-primary showAnhBtn">
                        <i class="icon icon-picture"></i>
                    </a>
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
    <div class="editPnl spacer">
        
    </div>
    <div class="anhList spacer" data-loaded="0" data-show="0" style="display: none;">
        <div class="well well-large showAnhForm" style="margin-top: 10px;">
            <div class="showAnhForm-header">
                <%--<button data-q-id="<%=Item.ID %>" class="btn btn-success btnThemAnh">Thêm ảnh</button>--%>
                <button class="btn pull-right closeAnhBtn">
                    <i class="icon icon-remove"></i>
                </button>
                <span class="btn btn-success album-upload-postBox">
                    <i class="icon-plus icon-white"></i>
                    <span>Chọn ảnh</span>
                    <!-- The file input field used as target for the file upload widget -->
                    <input  data-q-id="<%=Item.ID %>" type="file" multiple="" class="uploadAnhBtn btnThemAnh" name="files[]" id="fileupload"> &nbsp;<span class="btnCount"></span>
                </span>
                <button data-q-id="<%=Item.ID %>" class="btn f5Btn">
                    <i class="icon icon-refresh"></i>
                </button>
            </div>
            <hr/>
            <div data-q-id="<%=Item.ID %>" class="showAnhForm-body">

            </div>
        </div>
    </div>
</div>