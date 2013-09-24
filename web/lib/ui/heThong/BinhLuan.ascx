<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BinhLuan.ascx.cs" Inherits="lib_ui_heThong_BinhLuan" %>
<%@ Import Namespace="docsoft" %>
<div class="full-content effect6">
    <div class="binhLuan-box" data-id="<%=PID %>">
        <%if(Security.IsAuthenticated()){ %>
        <div class="binhLuan-postBox">
            <form>
                <div style="margin:7px 14px 7px 0;">
                <textarea required="" style="width: 100%;" class="binhLuan-Txt" name="new_message" placeholder="Nhập bình luận của bạn" rows="3"></textarea>            
                </div>
                <%--<h6 class="pull-right">320 characters remaining</h6>--%>
                <button class="btn btn-info" type="submit">Gửi bình luận</button>
            </form>
        </div>
        <%}
          else
          {%>
          <div class="row-fluid">
              <div class="span2"></div>
             <div class="span8">
                 <div class="p-title">
                     Đăng nhập để bình luận
                 </div>
                 <br/><br/>
                <a href="#loginDialog" data-toggle="modal" class="btn btn-primary btn-large">Đăng nhập</a>
             </div>
             <div class="span2"></div>
          </div>  
        <%} %>
        <div class="binhLuan-list">
        
        </div>
    </div>
</div>