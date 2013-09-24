<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TheoDoi_View.ascx.cs" Inherits="lib_ui_TheoDoi_TheoDoi_View" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="full-content effect6">
    <div class="row-fluid">
        <div class="span4">
            <a href="/lib/pages/NhatKy/Default.aspx?ID=<%=BeItem.ID %>" class="btn btn-default btn-large">
                <i class="icon icon-chevron-sign-left"></i> Quay lại
            </a>    
                <%if(ItemBaoCao.Username == Security.Username){ %>
                <br /><br/>
                    <a href="/lib/pages/TheoDoi/Edit.aspx?BCTD_ID=<%=ItemBaoCao.ID %>&ID=<%=ItemBaoCao.PID_ID %>" class="btn btn-success btn-large">
                        <i class="icon icon-edit-sign"></i> Nhập cân nặng cho bé
                    </a>
                <%} %>
        </div>
        
        <div class="span8">
            <div class="album-view-ten p-title"><%=ItemBaoCao.Ten%></div>
        </div>
        
    </div>
    <hr class="hr"/>
    <div class="p-title">
        Theo dõi cân nặng (gram)
        <div class="pull-right">
            <a class="btn btn-link" target="_blank" href="http://nhatkycon.blogspot.dk/2013/06/bang-can-nang-chieu-cao-tu-who.html">Cơ sở khoa học?</a>
        </div>
    </div>
    <hr/>
    <div class="theoDoi-baocao-view-box">
        <div class="theoDoi-baocao-view-pnl">
            <div id="chart-region-CanNang" class="chart-region chart-region-CanNang">        
            </div>   
        </div>    
    </div>    
    <hr class="hr"/>
    <div class="p-title">Theo dõi chiều cao (cm)</div>
    <hr/>
    <div class="theoDoi-baocao-view-box">
        <div class="theoDoi-baocao-view-pnl">
            <div id="chart-region-ChieuCao" class="chart-region chart-region-ChieuCao">        
            </div>   
        </div>    
    </div>    
    <hr/>
    <div class="fb-like" data-href="http://nhatkycon.com/lib/pages/TheoDoi/View..aspx?ID=<%=ItemBaoCao.ID %>" data-send="true" data-layout="button_count" data-width="120" data-show-faces="false"></div>
</div>
<meta property="og:title" content="<%=ItemBaoCao.Ten %> - NhatKyCon" />
<meta property="og:description" content="<%=Item.Ten %> của bé <%=BeItem.Alias %>" />
<% if (!string.IsNullOrEmpty(BeItem.Anh))
    { %>
<meta property="og:image" content="/lib/up/i/<%=BeItem.Anh %>" />
<% }%>
<script src="/lib/js/chart/jqBarGraph.1.1.min.js" type="text/javascript"></script>
<script>
    <%if(List.Any()){ %>
    <% var i = 0; %>
    var arrayOfData = new Array(
        <% foreach (var item in List)
           { %>
            <%if(i==0){ %>
                  [[<%=item.CanNang %>,<%=item._DanhMuc.Ma %>], '<%=item._DanhMuc.Ten %>']
            <%}else{ %>
                , [[<%=item.CanNang %>,<%=item._DanhMuc.Ma %>], '<%=item._DanhMuc.Ten %>']
            <%} %>
            <% i++; %>
         <% } %>
    );
    $('#chart-region-CanNang').jqBarGraph({
        data: arrayOfData,
        colors: ['#336699', '#669900'],
        legends: ['Cân nặng','Cân nặng chuẩn'],
        legend: true,
        width: <%=List.Count * 200 %>,
        color: '#ffffff',
        type: 'multi'
        //postfix: '%',
        //, title: '<h3><%=Item.Ten %> của bé <b><%=BeItem.Alias %></b> <br /><small>Xem biểu đồ chuẩn</small></h3>'
    });
    
    <% i = 0; %>
    var arrayOfData1 = new Array(
        <% foreach (var item in List)
           { %>
            <%if(i==0){ %>
                  [[<%=item.ChieuCao %>, <%=item._DanhMuc.GiaTri %>], '<%=item._DanhMuc.Ten %>']
            <%}else{ %>
                , [[<%=item.ChieuCao %>, <%=item._DanhMuc.GiaTri %>], '<%=item._DanhMuc.Ten %>']
            <%} %>
            <% i++; %>
         <% } %>
    );
    $('#chart-region-ChieuCao').jqBarGraph({
        data: arrayOfData1,
        colors: ['#336699','#669900'],
        legends: ['Chiều cao','Chiều cao chuẩn'],
        legend: true,
        width: <%=List.Count * 200 %>,
        color: '#ffffff',
        type: 'multi'
        //postfix: '%',
        //, title: '<h3><%=Item.Ten %> của bé <b><%=BeItem.Alias %></b> <br /><small>Xem biểu đồ chuẩn</small></h3>'
    });
    <%} %>
</script>
