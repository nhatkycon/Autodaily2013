using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using docsoft;
using pmSpa.entities;

[assembly: WebResource("appStore.pmSpa.hangHoaMgr.DanhSachHangHoa.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.hangHoaMgr.DanhSachHangHoa.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.pmSpa.hangHoaMgr.DanhSachHangHoa
{
    public class Class1 : docPlugUI
    {
        protected override void OnLoad(EventArgs e)
        {
            #region variables
            var ID = Request["ID"];
            var DM_ID = Request["DM_ID"];
            var Ma = Request["Ma"];
            var MoTa = Request["MoTa"];
            var NoiDung = Request["NoiDung"];
            var CongDung = Request["CongDung"];
            var CachDung = Request["CachDung"];
            var CacBuoc = Request["CacBuoc"];
            var DV_ID = Request["DV_ID"];
            var GiaNhap = Request["GiaNhap"];
            var GiaXuat = Request["GiaXuat"];
            var TonDinhMuc = Request["TonDinhMuc"];
            var Anh = Request["Anh"];
            var NgayTao = Request["NgayTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiTao = Request["NguoiTao"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var Active = Request["Active"];
            var KhuyenMai = Request["KhuyenMai"];
            var DuaLenWeb = Request["DuaLenWeb"];            
            #endregion

            switch (subAct)
            {
                case "get":
                    var hangHoaList = new HangHoaCollection()
                                          {
                                              new HangHoa() {Active = true, Anh = string.Empty, CacBuoc = string.Empty, DM_ID = Guid.NewGuid(),DuaLenWeb = true, DV_ID = Guid.NewGuid(), GiaNhap = 1000, GiaXuat = 1200,HetHang = false, ID = Guid.NewGuid()}
                                          };

                    break;
                default:
                    break;
            }
            base.OnLoad(e);
        }
    }
}
