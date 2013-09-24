<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Album_Add.ascx.cs" Inherits="lib_ui_nhatKy_Album_Add" %>
<div class="full-content effect6">
    <div class="album-upload-box" data-id="<%= string.IsNullOrEmpty(AB_ID) ? Guid.NewGuid().ToString() : AB_ID %>" data-pid="<%=ID %>">
        <h1>Thêm mới album ảnh</h1>
        <hr/>
        <input placeholder="Tên album ảnh" required="" value="<%=AlbumItem!= null ? AlbumItem.Ten : "" %>" class="input-xxlarge TenAlbum" style="" size="16" type="text">
        <hr/>
        <span class="btn btn-success album-upload-postBox">
            <i class="icon-plus icon-white"></i>
            <span>Chọn ảnh</span>
            <!-- The file input field used as target for the file upload widget -->
            <input type="file" multiple="" class="uploadAnhBtn" name="files[]" id="fileupload">
        </span>    
        <br/><br/>
        <div id="progress" class="progress progress-success progress-striped" style="display: none;">
            <div class="bar"></div>
        </div>
        <br/>
        <div class="well-large album-view-list">
            <%if (List!=null){ %>
            <% foreach (var item in List)
               {%>
              <div class="row-fluid item-anh-uploadPreview" data-id="<%=item.ID %>">
                    <div class="span3">
                        <div class="anh-img-box">
                            <img src="/lib/up/anh/<%=item.FileAnh %>" class="anh-img"/>
                        </div>
                    </div>    
                    <div class="span9">
                        <input data-id="<%=item.ID %>" class="input-xxlarge Ten" value="<%=item.Ten %>" type="text"/>
                        <button class="btn btn-warning" data-id="<%=item.ID %>" style="margin-bottom: 10px;">Xóa</button>
                    </div>
                </div>
            <%} %>    
            <%} %>
        </div>
        <br/>
        <%if (!string.IsNullOrEmpty(AB_ID))
          {%>
        <button class="btn btn-primary btn-large UpdateAlbumBtn">Lưu</button>
        <button class="btn btn-warning btn-large xoaAlbumBtn">Xóa</button>
        <%}
          else
          {%>
        <button class="btn btn-primary btn-large SaveAlbumBtn">Lưu</button>
  
          <%} %>
        <a href="Default.aspx?ID=<%=ID %>" class="btn btn-default btn-large">Bỏ qua</a>
    </div>    
</div>



<script src="/lib/js/Html5MultiUpload/jquery.iframe-transport.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.ui.widget.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.fileupload.js" type="text/javascript"></script>
<script src="/lib/js/jquery.tmpl.min.js" type="text/javascript"></script>
<script id="anh-item" type="text/x-jquery-tmpl">
    <div class="row-fluid item-anh-uploadPreview" data-id="${Id}">
        <div class="span3">
            <div class="anh-img-box">
                <img src="/lib/up/anh/${Thumbnail_url}" class="anh-img"/>
            </div>
        </div>    
        <div class="span9">
            <input value="" data-id="${Id}" class="input-xxlarge Ten" type="text"/>
            <button class="btn btn-warning" data-id="${Id}" style="margin-bottom: 10px;">Xóa</button>
        </div>
    </div>
</script>