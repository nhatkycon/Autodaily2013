<%@ Page Title="" Language="C#"  MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_Default" %>
<%@ Import Namespace="docsoft" %>

<%@ Register src="~/lib/ui/CaNhan/DanhSachBe.ascx" tagname="DanhSachBe" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/heThong/AboutUs.ascx" tagname="AboutUs" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/heThong/Banner.ascx" tagname="Banner" tagprefix="uc2" %>

<%@ Register src="~/lib/ui/heThong/Home.ascx" tagname="Home" tagprefix="uc3" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Web viết nhật ký cho con - Nhật Ký Con.Vn</title>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <%if(Security.IsAuthenticated()){ %>
    <div class="globalBox">
        <uc1:DanhSachBe ID="DanhSachBe1" runat="server" />
    </div>
    <%}
      else
      {%>
        <uc3:Home ID="Home1" runat="server" Visible="False" />  
        <uc1:AboutUs ID="AboutUs1" runat="server" />
      <%} %>
    <meta name="description" content="Viết nhật ký cho con bằng ảnh, album ảnh, video. Sau này con lớn sẽ có khối chuyện để kể" />
</asp:Content>

