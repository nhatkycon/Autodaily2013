<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CauHoiViewItem.ascx.cs" Inherits="lib_ui_Auto_TayDua_templates_CauHoiViewItem" %>
<div class="TayDua-CauHoiItem">
    <div class="TayDua-CauHoiItem-Body">
        <div class="TayDua-CauHoiItem-Ten">
          <%=Item.Luot %>.  <%=Item.Ten %>
        </div>
        <div class="TayDua-CauHoiItem-MoTa">
            <%=Item.MoTa %>
        </div>
        <div class="TayDua-CauHoiItem-DapAn">
            <%if (Item.DapAns!= null){ %>        
            <% foreach (var item in Item.DapAns)
               {%>
               <div class="TayDua-CauHoiItem-DapAn-Item">
                   <input class="radio" name="<%=item.CH_ID %>" id="<%=item.ID %>" title="" type="radio"/>
                   <label for="<%=item.ID %>"><%=item.Ten %> </label>                           
               </div>
             <%  } %>
             <%} %>
        </div>
        <div class="TayDua-CauHoiItem-Next">
            <a href="javascript:;" onclick="cauHoiSwipe.prev();" class="pull-left TayDua-CauHoiItem-PrevBtn btn btn-large">
                <i class="icon icon-backward"></i>Câu tiếp
            </a>
            <a href="javascript:;" onclick="cauHoiSwipe.next();" class="pull-right TayDua-CauHoiItem-NextBtn btn btn-large">
                <i class="icon icon-check"></i>Câu tiếp
            </a>
        </div>
    </div>
</div>