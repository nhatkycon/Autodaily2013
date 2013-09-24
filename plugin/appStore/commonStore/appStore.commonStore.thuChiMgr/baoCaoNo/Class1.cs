using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
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

[assembly: WebResource("appStore.commonStore.thuChiMgr.baoCaoNo.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.thuChiMgr.baoCaoNo.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.thuChiMgr.baoCaoNo
{
    
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số

            var _ID = Request["ID"];
            if (string.IsNullOrEmpty(_ID)) _ID = Guid.Empty.ToString();
            var No = Request["No"];
            HttpContext c = HttpContext.Current;
            var listRow = new List<jgridRow>();
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid

                    foreach (var item in KhachHangDal.SelectCongNo(No))
                    {
                        listRow.Add(new jgridRow(item.ID.ToString(), new string[]
                                                                         {
                                                                             item.ID.ToString()
                                                                             ,item.Ten
                                                                             , Lib.TienVietNam(item.CongNoDauKy)
                                                                             , Lib.TienVietNam(item.TongNhap)
                                                                             , Lib.TienVietNam(item.TongXuat)
                                                                             , Lib.TienVietNam(item.TongThu)
                                                                             , Lib.TienVietNam(item.TongChi)
                                                                             , Lib.TienVietNam(item.TongDichVu)
                                                                             , Lib.TienVietNam(item.CongNo)
                                                                         }));
                    }
                    var gridSpAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , "1"
                        , "1000"
                        , listRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSpAdm));
                    break;
                    #endregion
                case "getSubXuat":
                    #region getSubXuat
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        var danhMucLoaiXuatNhap = DanhMucDal.SelectByMa("LXN-X");
                        var pagerGet = XuatNhapDal.pagerXuatNhap(true.ToString(), false.ToString(), false.ToString(),false.ToString(),  _ID,
                                                                 jgrsidx + " " + jgrsord, string.Empty,
                                                                 Convert.ToInt32(jgRows));
                        string prefixMas = danhMucLoaiXuatNhap.KyHieu;
                        foreach (var item in pagerGet.List)
                        {
                            listRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LOAI_Ten
                            , prefixMas + item.Ma
                            , item.KH_Ten
                            , item.NgayHoaDon.ToString("dd-MM-yyyy")
                            , Lib.TienVietNam(item.CongTienHang)
                            , Lib.TienVietNam(item.VAT)
                            , Lib.TienVietNam(item.ChietKhau)
                            , Lib.TienVietNam(item.CongTienHang + item.VAT - item.ChietKhau)
                            , Lib.TienVietNam(item.ThanhToan)
                            , Lib.TienVietNam(item.ConNo)
                            , string.Format("{0:dd/MM/yy}",item.NgayCapNhat)
                        }));
                        }
                        jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                            , pagerGet.TotalPages.ToString()
                            , pagerGet.Total.ToString()
                            , listRow);
                        sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    }
                    break;
                    #endregion
                case "getSubNhap":
                    #region getSubNhap
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        var danhMucLoaiXuatNhap = DanhMucDal.SelectByMa("LXN-N");
                        var pagerGet = XuatNhapDal.pagerXuatNhap(false.ToString(), false.ToString(), false.ToString() , false.ToString(), _ID,
                                                                 jgrsidx + " " + jgrsord, string.Empty,
                                                                 Convert.ToInt32(jgRows));
                        string prefixMas = danhMucLoaiXuatNhap.KyHieu;
                        foreach (var item in pagerGet.List)
                        {
                            listRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LOAI_Ten
                            , prefixMas + item.Ma
                            , item.KH_Ten
                            , item.NgayHoaDon.ToString("dd-MM-yyyy")
                            , Lib.TienVietNam(item.CongTienHang)
                            , Lib.TienVietNam(item.VAT)
                            , Lib.TienVietNam(item.ChietKhau)
                            , Lib.TienVietNam(item.CongTienHang + item.VAT - item.ChietKhau)
                            , Lib.TienVietNam(item.ThanhToan)
                            , Lib.TienVietNam(item.ConNo)
                            , string.Format("{0:dd/MM/yy}",item.NgayCapNhat)
                        }));
                        }
                        jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                            , pagerGet.TotalPages.ToString()
                            , pagerGet.Total.ToString()
                            , listRow);
                        sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    }
                    break;
                    #endregion
                case "getSubThu":
                    #region getSubThu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        var pagerGet = ThuChiDal.pagerTuNgayDenNgay(jgrsidx + " " + jgrsord, null,
                                                                    Convert.ToInt32(jgRows),
                                                                    true, null, null, null, _ID);
                        var danhMucKyHieu = DanhMucDal.SelectByMa("TC-THU");
                        string prefixMas = danhMucKyHieu.KyHieu;
                        foreach (var item in pagerGet.List)
                        {
                            listRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            , item.NDTC_Ten
                            , prefixMas + item.SoPhieu
                            , item.P_Ten
                            , item.Mota
                            , item.NgayTao.ToString("dd-MM-yyyy")
                            , Lib.TienVietNam(item.SoTien)
                            , item.NguoiTao_Ten
                            , (item.NguoiTao == Security.Username).ToString()
                            , (item.XN_ID != Guid.Empty).ToString()
                            , (item.DV_ID != Guid.Empty).ToString()
                        }));
                        }
                        jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                            , pagerGet.TotalPages.ToString()
                            , pagerGet.Total.ToString()
                            , listRow);
                        sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    }
                    
                    break;
                    #endregion
                case "getSubChi":
                    #region lấy dữ liệu cho getSubThu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        var pagerGet = ThuChiDal.pagerTuNgayDenNgay(jgrsidx + " " + jgrsord, null,
                                                                    Convert.ToInt32(jgRows),
                                                                    false, null, null, null, _ID);
                        var danhMucKyHieu = DanhMucDal.SelectByMa("TC-CHI");
                        string prefixMas = danhMucKyHieu.KyHieu;
                        foreach (var item in pagerGet.List)
                        {
                            listRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            , item.NDTC_Ten
                            , prefixMas + item.SoPhieu
                            , item.P_Ten
                            , item.Mota
                            , item.NgayTao.ToString("dd-MM-yyyy")
                            , Lib.TienVietNam(item.SoTien)
                            , item.NguoiTao_Ten
                            , (item.NguoiTao == Security.Username).ToString()
                            , (item.XN_ID != Guid.Empty).ToString()
                            , (item.DV_ID != Guid.Empty).ToString()
                        }));
                        }
                        jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                            , pagerGet.TotalPages.ToString()
                            , pagerGet.Total.ToString()
                            , listRow);
                        sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    }

                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.baoCaoNo.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.baoCaoNo.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "baoCaoNo.mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.baoCaoNo.JScript1.js")
                        , "{baoCaoNoFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}


