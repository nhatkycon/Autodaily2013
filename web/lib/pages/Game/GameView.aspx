<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="GameView.aspx.cs" Inherits="lib_pages_Game_GameView" %>

<%@ Register src="~/lib/ui/Auto/Game/AdminDanhSachQuestion.ascx" tagname="AdminDanhSachQuestion" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="post-box effect2  QuestionThemPnl">
        <div class="navigation">        
            <button class="btn btn-primary">Thêm</button>
        </div>
    </div>
    <div class="QuestionList">
        <uc1:AdminDanhSachQuestion ID="AdminDanhSachQuestion1" runat="server" />            
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


