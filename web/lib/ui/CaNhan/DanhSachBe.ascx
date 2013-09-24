<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhSachBe.ascx.cs" Inherits="lib_ui_CaNhan_DanhSachBe" %>
<%@ Register src="~/lib/ui/CaNhan/DoiNick.ascx" tagname="DoiNick" tagprefix="uc1" %>
<div class="full-content effect6 BeYeuThichList">
    <h2>
        <a href="/lib/pages/CaNhan/TaoBe.aspx" class="btn btn-primary btn-large pull-right">
            <i class="icon icon-add icon-large"></i>
            Thêm bé
        </a>
        <i class="icon icon-user icon-large"></i>
        Danh sách nhật ký
    </h2>
    <hr/>
    <% foreach (var item in List)
        {%>
        <div class="YeuThich-Item BeYeuThich-Item">
            <div class="row-fluid">
                <div class="span2">
                    <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=item.ID %>" class="YeuThich-Item-img-box">
                        <img src="/lib/up/avatar/<%=item.Anh %>" class="YeuThich-Item-img"/>
                    </a>        
                </div>
                <div class="span7">
                    <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=item.ID %>" class="YeuThich-Item-ten">
                        <%=item.Alias %>
                    </a>      
                    <p class="well well-small">
                        <%if (!string.IsNullOrEmpty(item.Nick)){ %>
                            Địa chỉ ngắn:&nbsp; <strong><a href="http://NhatKyCon.Vn/<%=item.Nick %>">http://NhatKyCon.Vn/<%=item.Nick %></a></strong>
                            &nbsp;-&nbsp;<a href="#NickDialog" data-nick="<%=item.Nick %>" class="btn btn-link editNick" data-id="<%=item.ID %>">Sửa</a>
                        <% }else{%>
                            Chưa có&nbsp;-&nbsp;<a href="#NickDialog" class="btn btn-link editNick" data-nick="<%=item.Nick %>" data-id="<%=item.ID %>">Sửa</a>
                        <% }%>    
                    </p>
                </div>
                <div class="span3">
                    <div class="pull-right">
                        <a href="/lib/pages/CaNhan/SuaBe.aspx?ID=<%=item.ID %>" class="btn btn-default btn-large UnLikeBtn" data-id="<%=item.ID %>">
                            <i class="icon icon-edit"></i>
                        </a>
                        <a class="btn btn-info btn-large btnKhongChiaSeBtn" data-id="<%=item.ID %>" href="javascript:">
                            <i class="icon <%=item.KhongChiaSe? " icon-lock" : " icon-unlock" %>"></i>
                        </a>    
                    </div>
                </div>
            </div>
            <hr/>
        </div>
    <%} %>
</div>
<script src="/lib/js/web/CaNhan.js" type="text/javascript"></script>
<uc1:DoiNick ID="DoiNick1" runat="server" />

