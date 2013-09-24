using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Reporting.WebForms;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using System.IO;
using pmSpa.entities;

[assembly: WebResource("appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.DangKySanPhamDacTrung.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.DangKySanPhamMenu.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.DuyetSPDT.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet
{
    
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số
            var ID = Request["ID"];


            var XN_ID = Request["XN_ID"];
            var HH_ID = Request["HH_ID"];
            var DV_ID = Request["DV_ID"];
            var SoLuong = Request["SoLuong"];
            var DonGia = Request["DonGia"];
            var Tong = Request["Tong"];
            var VAT = Request["VAT"];
            var CKTyLe = Request["CKTyLe"];
            var CKTien = Request["CKTien"];
            var NgayTao = Request["NgayTao"];
            var NguoiTao = Request["NguoiTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var GhiChu = Request["GhiChu"];
            var TV_ID = Request["TV_ID"];

            var GH_ID = Request["GH_ID"];
            var LOAI_ID = Request["LOAI_ID"];
            var Ma = Request["Ma"];
            var KH_ID = Request["KH_ID"];
            var NgayHoaDon = Request["NgayHoaDon"];
            var NhanVien = Request["NhanVien"];
            var CongTienHang = Request["CongTienHang"];
            var DienGiai = Request["DienGiai"];
            var ThanhToan = Request["ThanhToan"];
            var ConNo = Request["ConNo"];
            var ChietKhau = Request["ChietKhau"];
            var KHO_ID = Request["KHO_ID"];
            var DM_ID = Request["DM_ID"];
            var _q = Request["q"];
            var draff = Request["draff"];
            var Loai = Request["Loai"];
            var Rep_Ten = Request["Rep_Ten"];
            var Rep_Ngay = Request["Rep_Ngay"];
            List<jgridRow> ListRow = new List<jgridRow>();

            var dmXuat = DanhMucDal.SelectByMa("LXN-X");
            var dmNhap = DanhMucDal.SelectByMa("LXN-N");
            var isXuat = true;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    var TuNgay = Request["TuNgay"];
                    var DenNgay = Request["DenNgay"];
                    var dNow = DateTime.Now;
                    var dauThang = new DateTime(dNow.Year, 1, 1).ToString("yyyy-MM-dd");
                    var cuoiThang = new DateTime(dNow.Year, dNow.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                    TuNgay = string.IsNullOrEmpty(TuNgay) ? dauThang : Convert.ToDateTime(TuNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");
                    DenNgay = string.IsNullOrEmpty(DenNgay) ? cuoiThang : Convert.ToDateTime(DenNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");

                    var pagerGet = XuatNhapChiTietDal.pagerTuNgayDenNgayKhoIdDmId(string.Empty, false, jgrsidx + " " + jgrsord,
                                                                                  _q,
                                                                                  Convert.ToInt32(jgRows), TuNgay,
                                                                                  DenNgay, KHO_ID, DM_ID, KH_ID);
                    foreach (var item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.XN_ID.ToString(), new string[] { 
                             
                            item.XN_ID.ToString()
                            , string.Format("{0}",item._XuatNhap.Xuat ? "Xuất" : "Nhập")
                            , string.Format("{0}{1}", ( item._XuatNhap.Xuat ? dmXuat.KyHieu : dmNhap.KyHieu) ,  item._XuatNhap.Ma)
                            , item._HangHoa.Ten
                            , item._XuatNhap.KH_Ten
                            , Lib.TienVietNam(item.DonGia)
                            , item.SoLuong.ToString()
                            , Lib.TienVietNam(item.CKTien)
                            , Lib.TienVietNam(item.VAT)
                            , Lib.TienVietNam(item.Tong)
                            , item._XuatNhap.NgayHoaDon.ToString("dd-MM-yyyy")
                        }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , pagerGet.TotalPages.ToString()
                        , pagerGet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                    #endregion
                case "reports":
                    #region bao cao
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var item = XuatNhapDal.SelectById(new Guid(ID));
                        item.Ma = string.Format("{0}{1}", (item.Xuat ? dmXuat.KyHieu : dmNhap.KyHieu), item.Ma);
                        item.XNCT = XuatNhapChiTietDal.SelectByXN_ID(item.ID.ToString());
                        var itemInXuat = Lib.GetResource(Assembly.GetExecutingAssembly(), "xuatNhapChiTiet.in.htm");
                        var itemInNhap = Lib.GetResource(Assembly.GetExecutingAssembly(), "quanLyNhap.in.htm");
                        var itemInRow = Lib.GetResource(Assembly.GetExecutingAssembly(), "xuatNhapChiTiet.in-row.htm");
                        var danhMucReportHeader = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI");

                        var sbRow = new StringBuilder();
                        var stt = 0;
                        foreach (var xnct in item.XNCT)
                        {
                            stt++;
                            sbRow.AppendFormat(itemInRow
                                , stt
                                , xnct.HH_Ten
                                , xnct.HH_Ma
                                , xnct.DV_Ten
                                , Lib.TienVietNam(xnct.DonGia)
                                , xnct.SoLuong
                                , Lib.TienVietNam(xnct.CKTien)
                                , Lib.TienVietNam(xnct.VAT)
                                , Lib.TienVietNam(xnct.Tong));
                        }

                        sb.AppendFormat(item.Xuat ? itemInXuat : itemInNhap
                            , string.Format("Ng&agrave;y {4}{0} th&aacute;ng {3}{1} năm {2}", item.NgayTao.Day, item.NgayTao.Month, item.NgayTao.Year, item.NgayTao.Month < 10 ? "0" : "", item.NgayTao.Day < 10 ? "0" : "")
                            , item.Ma
                            , item.KH_Ten
                            , item.GhiChu
                            , item.KHO_Ten
                            , Lib.TienVietNam(item.CongTienHang)
                            , Lib.TienVietNam(item.VAT)
                            , Lib.TienVietNam(item.ChietKhau)
                            , Lib.TienVietNam(item.CongTienHang - item.VAT - item.ChietKhau)
                            , Lib.TienVietNam(item.ThanhToan)
                            , Lib.TienVietNam(item.ConNo)
                            , danhMucReportHeader.Description
                            , domain
                            , sbRow
                            , Lib.So_chu(item.CongTienHang)
                            , item.NhanVien
                            );
                    }
                    
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "xuatNhapChiTiet.mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.xuatNhapMgr.xuatNhapChiTiet.JScript1.js")
                        , "{xuatNhapChiTietFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}


