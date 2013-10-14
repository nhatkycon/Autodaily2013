<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/TayDua.master" AutoEventWireup="true" CodeFile="DanhSachGame.aspx.cs" Inherits="lib_pages_Game_DanhSachGame" %>

<%@ Register src="~/lib/ui/Auto/Game/AdminDanhSachGame.ascx" tagname="AdminDanhSachGame" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="post-box effect2  GameThemPnl">
        <div class="navigation">        
            Tên: <input class="input-large Ten"/>  Thứ tự: <input class="input-mini ThuTu"/> <button class="btn btn-primary">Thêm</button>
        </div>
    </div>
    <div class="GameList">
        <uc1:AdminDanhSachGame ID="AdminDanhSachGame1" runat="server" />            
    </div>
<script src="/lib/js/jquery.tmpl.min.js" type="text/javascript"></script>
<script id="GameItem" type="text/x-jquery-tmpl">
    <div class="well well-large" style="margin-top: 10px;">
    Tên: <input value="${Ten}" class="input-xlarge Ten" type="text"/>
    Thứ tự: <input value="${ThuTu}" class="input-mini ThuTu" type="text"/>
        <button data-id="${ID}" class="btn btn-info cancelBtn">Hủy</button>
        <button data-id="${ID}" class="btn btn-primary saveBtn">Lưu</button>
    </div>

</script>
</asp:Content>

