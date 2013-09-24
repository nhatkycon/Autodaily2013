<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigatorBased.ascx.cs" Inherits="lib_ui_heThong_NavigatorBased" %>
<%@ Import Namespace="docsoft" %>
<%@ Register TagPrefix="uc1" TagName="Blog_Add" Src="~/lib/ui/nhatKy/Blog_Add.ascx" %>
<%@ Register TagPrefix="uc2" TagName="HoatDong_Add" Src="~/lib/ui/nhatKy/HoatDong_Add.ascx" %>
<%@ Register TagPrefix="uc3" TagName="Video_Add" Src="~/lib/ui/nhatKy/Video_Add.ascx" %>
<%if(BeItem != null && BeItem.Username==Security.Username){ %>
    <a href="#" class="navigation-icon navigation-icon-add dropdown-toggle" data-toggle="dropdown">
        <i class="icon-edit icon-large icon-2x"></i>
        <span class="navigation-lbl">Viết nhật ký</span>                        
    </a>
    <ul class="dropdown-menu">
        <li>
            <a href="#AddBlogDialog" data-toggle="modal">
                <i class="icon-pencil icon-large"></i> Nhật ký blog
            </a>
        </li>
        <li>
            <a href="/lib/pages/NhatKy/Album_Add.aspx?ID=<%=Request["ID"] %>">
                <i class="icon-camera icon-large"></i> Album ảnh
            </a>
        </li>
        <li>
            <a href="#AddVideoDialog" data-toggle="modal">
                <i class="icon-play-circle icon-large"></i> Video
            </a>
        </li>
        <li class="divider"></li>
        <li>
            <a href="#AddHoatDongDialog" data-toggle="modal">
                <i class="icon-calendar icon-large"></i> Sự kiện
            </a>
        </li>
    </ul>
    
    <%} %>
<a href="/lib/pages/NhatKy/Default.aspx?ID=<%=BeItem.ID %>" class="navigation-icon">
    <i class="icon-book icon-large icon-2x"></i>
    <span class="navigation-lbl">Nhật ký</span>                        
</a>
<a href="/lib/pages/TheoDoi/Default.aspx?ID=<%=BeItem.ID %>" class="navigation-icon">
    <i class="icon-bar-chart icon-large icon-2x"></i>
    <span class="navigation-lbl">Theo dõi</span>                        
</a>
<a href="/lib/pages/NhatKy/Anh.aspx?ID=<%=BeItem.ID %>" class="navigation-icon">
    <i class="icon-picture icon-large icon-2x"></i>
    <span class="navigation-lbl">Ảnh</span>                        
</a>
<a href="/lib/pages/NhatKy/GiaDinh.aspx?ID=<%=BeItem.ID %>" class="navigation-icon">
    <i class="icon-group icon-large icon-2x"></i>
    <span class="navigation-lbl">Gia đình</span>                        
</a>
<%if(BeItem != null && BeItem.Username==Security.Username){ %>
<uc1:Blog_Add ID="Blog_Add1" runat="server" />
<uc2:HoatDong_Add ID="HoatDong_Add1" runat="server" />
<uc3:Video_Add ID="Video_Add1" runat="server" />
<%} %>