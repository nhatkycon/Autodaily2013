<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="TaoBe.aspx.cs" Inherits="lib_pages_HeThong_TaoBe" %>

<%@ Register src="../../ui/heThong/TaoBe.ascx" tagname="TaoBe" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<div id="TaobeForm" class="span5 form-register">
    <uc1:TaoBe ID="TaoBe1" runat="server" />
</div> 
<div class="span6">
    <h3>Rơi nước mắt!</h3>
    <p>Khi bạn đọc lại những dòng đã viết cho con</p>    
    <div class="well well-large">
        <img src="/lib/css/web/1/be/Soc.jpg" class="img-rounded"/>
        <p class="quote">
            ĐÂY LÀ NƠI CÓ HAI NGƯỜI YÊU CON HƠN HẾT THẢY MỌI NGƯỜI TRÊN THẾ GIAN NÀY
        </p>
        
    </div>
    <h3>
            * Nhật ký riêng tư
        </h3>
        <p>
            Có thể bạn không muốn ai khác ngoài bạn đọc được những dòng nhật ký cho con yêu
            <br/>
            Bạn có thể khóa nhật ký lại, điều này giúp chỉ một mình bạn có thể viết và đọc nhật ký con mỗi ngày.
            <br/>
            <a href="http://nhatkycon.blogspot.com/2013/06/huong-dan-khoa-tai-khoan-nhat-ky.html" target="_blank" class="btn btn-primary">Tìm hiểu thêm</a>
        </p>
</div> 
</asp:Content>

