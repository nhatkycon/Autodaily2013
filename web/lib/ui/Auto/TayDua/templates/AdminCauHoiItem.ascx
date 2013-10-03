<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminCauHoiItem.ascx.cs" Inherits="lib_ui_Auto_TayDua_templates_AdminCauHoiItem" %>
<div data-id="<%=Item.ID %>" class="CauHoiItem">
    <div class="well viewPnl">
        <div class="row-fluid">
            <div class="pull-left">
                <img class="img-rounded adm-upload-preview-img-60" src="/lib/up/i/<%=Item._DanhMuc.Anh %>"/>
            </div>
            <div class="span8">
                <b><%=Item.Ten %></b> - <strong><%=Item.Diem %></strong><br/>
                <i><%=Item.MoTa %></i>
                <div class="DapAnPnl" data-loaded="0">
                    <button class="btn pull-right closeDapAnBtn">
                        <i class="icon icon-remove"></i>
                    </button>
                    <button data-id="<%=Item.ID %>" class="btn f5Btn">
                        <i class="icon icon-refresh"></i>
                    </button>
                    <hr/>
                    <div class="DapAnList" data-ch-id="<%=Item.ID %>">
                    </div>
                    <div class="DapAnAdd" data-ch-id="<%=Item.ID %>">
                        <div class="DapAn-Item row-fluid" data-ch-id="<%=Item.ID %>" data-id="">
                            <div class="span10">
                                <input type="checkbox" class="Dung" name="<%=Item.ID %>"/>
                                <input type="text" class="input-xxlarge Ten"/> &nbsp;
                                STT: <input type="text" class="input-mini ThuTu"/>
                            </div>
                            <div class="pull-right">
                                <a data-ch-id="<%=Item.ID %>" href="javascript:;" class="btn btn-primary addDapAnBtn">
                                    <i class="icon icon-plus-sign"></i> Thêm
                                </a>
                            </div>
                        </div>
                    </div>    
                </div>
            </div>
            <div class="pull-right">
                <div class="pull-right">
                    <a data-show="0" data-id="<%=Item.ID %>" href="javascript:;" title="Danh sách câu hỏi" class="btn btn-primary showDapAnBtn">
                        <i class="icon icon-question-sign"></i> Câu hỏi
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
</div>
