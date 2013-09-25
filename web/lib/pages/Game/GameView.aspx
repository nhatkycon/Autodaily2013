<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="GameView.aspx.cs" Inherits="lib_pages_Game_GameView" %>

<%@ Register src="~/lib/ui/Auto/Game/AdminDanhSachQuestion.ascx" tagname="AdminDanhSachQuestion" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="post-box effect2  QuestionThemPnl">
        <div class="navigation">        
            <button class="btn btn-primary addBtn">Thêm</button> &nbsp; <a class="btn" href="/lib/pages/Game/Game.aspx?ID=<%=G_ID %>">
                                                                            <i class="icon icon-picture"></i>
                                                                        </a>
            <div class="row-fluid spacer addPnl">
                
            </div>
        </div>
    </div>
    <div class="QuestionList">
        <uc1:AdminDanhSachQuestion ID="AdminDanhSachQuestion1" runat="server" />            
    </div>
<script src="/lib/js/Html5MultiUpload/jquery.iframe-transport.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.ui.widget.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.fileupload.js" type="text/javascript"></script>
<script src="/lib/js/jquery.tmpl.min.js" type="text/javascript"></script>
<script id="QItem" type="text/x-jquery-tmpl">
    <div data-g-id="<%=G_ID %>" data-id="${ID}" class="well well-large addForm" style="margin-top: 10px;">
        <div class="row row-fluid">
            <div class="span1">

    Tên: 
            </div>
            <div class="span8">
                <input value="${Ten}" class="input-xxlarge Ten" type="text"/>
            </div>
            <div class="span1">
    Thứ tự: 
            </div>
            <div class="span1">
                <input value="${ThuTu}" class="input-mini ThuTu" type="text"/>
                
            </div>
        </div>
        <div class="row row-fluid">
            <div class="span1">
    Mô tả: 

            </div>
            <div class="span11">
                <textarea class="input-xxlarge MoTa">${MoTa}</textarea>
            </div>
        </div>
        <div class="row row-fluid spacer">
            <div class="span1">
                Ảnh nhỏ: 
            </div>
            <div class="span3">
                <img class="img-polaroid AnhDaiDien" src="/lib/up/i/${AnhDaiDien}"/>
            </div>
            <div class="span1">
                Ảnh lớn: 
            </div>
            <div class="span6">
                <img class="img-polaroid Anh" src="/lib/up/i/${Anh}"/>
            </div>
        </div>
       <div class="row row-fluid">
           <div class="span1">
               <input value="${Active}" class="input-mini Active" type="checkbox"/> Active
            </div>
            <div class="span11">
                <button data-g-id="<%=G_ID %>"  data-id="${ID}" class="btn btn-info cancelBtn">Hủy</button> &nbsp; <button data-id="${ID}" class="btn btn-primary saveBtn">Lưu</button>
            </div>
        </div>
    </div>
</script>
<script id="anh-item" type="text/x-jquery-tmpl">
    <div class="row-fluid item-anh-uploadPreview" data-id="${Id}">
        <div class="span3">
            <div class="anh-img-box">
                <img src="/lib/up/i/${Thumbnail_url}" class="anh-img"/>
            </div>
        </div>    
        <div class="span9">
            <input value="" data-id="${Id}" class="input-mini ThuTuAnh ThuTu" type="text"/>
            <button class="btn btn-warning XoaAnhBtn" data-id="${Id}" style="margin-bottom: 10px;">Xóa</button>
        </div>
    </div>
</script>
    <style>
    .spacer {
        margin-top: 20px; /* define margin as you see fit */
    }
    .AnhDaiDien {
        display: inline-block;
        width: 120px;
        height: 80px;
    }
    .Anh {
        display: inline-block;
        width: 200px;
        height: 150px;
    }
</style>
</asp:Content>


