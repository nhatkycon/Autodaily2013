<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="lib_ui_HoiDap_Header" %>
<%@ Import Namespace="docsoft" %>
<%@ Register src="~/lib/ui/HoiDap/DatCauHoi.ascx" tagname="DatCauHoi" tagprefix="uc1" %>
<div class="post-box effect2">
    <div class="navigation">
        <a href="/lib/pages/HoiDap/" class="navigation-icon">
            <i class="icon-question icon-large icon-2x"></i>
            <span class="navigation-lbl">Câu hỏi mới</span>                        
        </a>
    <%if(Security.IsAuthenticated()){ %>
        <a href="/lib/pages/HoiDap/CaNhan.aspx" class="navigation-icon">
            <i class="icon-user icon-large icon-2x"></i>
            <span class="navigation-lbl">Câu hỏi đã đặt</span>                        
        </a>
        <div class="pull-right" >
            <a href="#AddCauHoiDialog" data-toggle="modal" class="btn btn-primary btn-large">
                <i class="icon icon-question-sign"></i> &nbsp;
                Đặt câu hỏi
            </a>
        </div>
    <uc1:DatCauHoi ID="DatCauHoi1" runat="server" />
    <%} %>
    </div>
</div>
