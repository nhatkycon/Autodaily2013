using System;
using System.Text;
using linh.json;
using docsoft.entities;
using docsoft;
using linh.common;

public partial class lib_aspx_datHang_Default : basePage
{
    public string strMon;
    public delegate void SendEmailDele(string email, string tieude, string noidung);
    void sendmailThongbao(string email, string tieude, string noidung)
    {
        omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "mamvui.com", "123$5678");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = Request["act"];
        string _ID = Request["ID"];
        string _SoLuong = Request["SoLuong"];
        string _Ten = Request["Ten"];
        string _Gia = Request["Gia"];
        string _Img = Request["Img"];
        string _Email = Request["Email"];
        string _Mobile = Request["Mobile"];
        string _DiaChi = Request["DiaChi"];
        string _GhiChu = Request["GhiChu"];
        var gh = new GioHang();
        var item = new HangHoa();
        var _dele = new SendEmailDele(sendmailThongbao);
        var sb = new StringBuilder();

        switch (act)
        {
            case "add":
            #region add
                item = HangHoaDal.SelectById(new Guid(_ID));
                gh.Add(item, _SoLuong);
                break;
            #endregion
            case "save":
                #region save

                var itemDh = new DatHang
                                 {
                                     ID=Guid.NewGuid(),
                                     GiaoHang = false,
                                     GiaTri = gh.Total,
                                     KH_DiaChi = _DiaChi,
                                     KH_Email = _Email,
                                     KH_Mobile = _Mobile,
                                     KH_Ten = _Ten,
                                     NgayTao = DateTime.Now,
                                     PhiVanChuyen = gh.ShipCost,
                                     Readed = false,
                                     Tong = gh.Total + gh.ShipCost,
                                     NgayGiao = DateTime.Now
                                 };
                itemDh = DatHangDal.Insert(itemDh);
                var itemDhCt = new DatHangChiTiet();
                var sbDh = new System.Text.StringBuilder();
                sbDh.AppendFormat(@"Khách hàng: {0}<br/>Email: {1}<br/>Mobile: {2}<br/>Địa chỉ: {3}<br/>Ghi chú: {4}<br/>Ngày đặt hàng: {5}<br/><h3>Chi tiết</h3>"
                    ,_Ten,_Email,_Mobile,_DiaChi, _GhiChu,DateTime.Now);
                foreach (GioHangItem ghItem in gh.List.Values)
                {
                    itemDhCt = new DatHangChiTiet();
                    itemDhCt.ID = Guid.NewGuid();
                    itemDhCt.DH_ID = itemDh.ID;
                    itemDhCt.HH_Gia = ghItem.Gia;
                    itemDhCt.HH_SoLuong = ghItem.SoLuong;
                    itemDhCt.HH_Ten = ghItem.Ten;
                    itemDhCt.HH_Tong = ghItem.Gia * ghItem.SoLuong;
                    itemDhCt.NgayTao = DateTime.Now;
                    DatHangChiTietDal.Insert(itemDhCt);
                    sbDh.AppendFormat("Món:{0} - {1}<br/>Số lượng: {2}<br/>Tổng: {3}<hr/>", ghItem.Ten, ghItem.Gia, ghItem.SoLuong, ghItem.Gia * ghItem.SoLuong);
                }
                sbDh.AppendFormat(@"Tổng:{0}<br/>Phí vận chuyển: {1}<br/>Tổng cộng: {2}"
                    , gh.Total, gh.ShipCost, gh.Total + gh.ShipCost);
                _dele.BeginInvoke("danhbaspa@gmail.com"
                            , string.Format("mamvui.com - Đặt hàng mới: {0}  {1} [{2}.000đ]", _Ten, DateTime.Now.ToString("hh:mm-dd/MM/yy"),gh.Total + gh.ShipCost)
                            , sbDh.ToString()
                            , null, null);
                gh.Clear();
                break;
                #endregion
            case "UpSl":
                #region UpSl
                item = HangHoaDal.SelectById(new Guid(_ID));
                gh.UpdateSl(item, _SoLuong);
                break;
                #endregion
            case "del":
                #region add
                gh.Remove(_ID);
                break;
                #endregion
            case "clear":
                #region add
                gh.Clear();
                break;
                #endregion
            case "get":
                #region get
                break;
            #endregion
            default:
                break;
        }
        //sb.Append(format_gioHang(gh));
        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(gh));
        rendertext(sb, "text/plain");
        
    }
    string format_item(GioHangItem item)
    {
        return string.Format(@"<div class=""cart-item"">
                                <span class=""cart-item-gia"">{0}.000đ</span>
                                <img src=""../up/sanpham/{2}"" class=""cart-item-img"" />
                                <span class=""cart-item-ten"">{1}</span><br />
                                {3}
                                <a href=""javascript:;"" class=""cart-item-xoa"">xóa</a>
                            </div>", item.Gia, item.Ten, item.Img, buildSoLuong(item.SoLuong));
    }
    string format_gioHang(GioHang item) {
        var sb = new System.Text.StringBuilder();
        sb.Append(@"<div class=""cart-top"">
        </div>
        <div class=""cart-body"">");
        foreach(GioHangItem gioHangItem in item.List.Values){
            sb.Append(format_item(gioHangItem));
        }
        if (item.ShipCost > 0) {
            sb.Append(@"<div class=""cart-ship"">
                <span class=""cart-ship-gia"">5.000đ</span>
                <span class=""cart-ship-label"">Phí vận chuyển</span><br />
                <span class=""cart-ship-info"">Dưới 80k, quý khách vui lòng phụ thêm 5k vận chuyển</span>
            </div>");
        }
        sb.AppendFormat(@"<div class=""cart-tong"">
                                Tổng cộng: <span class=""cart-tong-label"">{0}.000đ</span>
                            </div>", item.Total + item.ShipCost);
        sb.Append(@"<div class=""cart-info cart-info-active"">
            <table style=""width:100%;"" cellpadding=""4"" cellspacing=""2"">
                <tr>
                    <td valign=""top"" class=""td-header"">Tên:</td>
                    <td valign=""top"">
                        <input class=""input-small Ten"" />
                    </td>
                </tr>
                <tr>
                    <td valign=""top"" class=""td-header"">Email:</td>
                    <td valign=""top"">
                        <input class=""input-small Email"" />
                    </td>
                </tr>
                <tr>
                    <td valign=""top"" class=""td-header"">Mobile:</td>
                    <td valign=""top"">
                        <input class=""input-small Mobile"" />
                    </td>
                </tr>
                <tr>
                    <td valign=""top"" class=""td-header"">Địa chỉ:</td>
                    <td valign=""top"">
                        <input class=""input-small DiaChi"" />
                    </td>
                </tr>
                <tr>
                    <td colspan=""2"" valign=""top"">
                        <textarea class=""textarea-tiny GhiChu"" ></textarea>
                    </td>                                                                                
                </tr>
                <tr>
                    <td colspan=""2"" valign=""top"">
                        <a href=""javascript:;"" class=""cart-send"">Gửi Đặt hàng</a>
                    </td>
                </tr>
            </table>
        </div>");
        sb.Append("</div>");

        return sb.ToString();
    }
    string buildSoLuong(int SoLuong) {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<select class=""cart-item-soLuong"">");
        for (int i = 0; i < 10; i++) {
            sb.AppendFormat(@"<option value=""{0}""{1}>{0}</option>", i, i == SoLuong ? @" selected=""selected""" : "");
        }
        if(SoLuong>10){
            sb.AppendFormat(@"<option value=""{0}"" selected=""selected"">{0}</option>", SoLuong);
        }
        sb.Append(@"</select>");
        return sb.ToString();
    }
}