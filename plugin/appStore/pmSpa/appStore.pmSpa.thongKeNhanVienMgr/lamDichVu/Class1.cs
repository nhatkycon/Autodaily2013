using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

[assembly: WebResource("appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.DangKySanPhamDacTrung.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.DangKySanPhamMenu.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.DuyetSPDT.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.pmSpa.thongKeNhanVienMgr.lamDichVu
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
            var NhanVien = Request["NhanVien"];
            
            var _q = Request["q"];
            var draff = Request["draff"];
            var Loai = Request["Loai"];
            var TuNgay = Request["TuNgay"];
            var DenNgay = Request["DenNgay"];
            List<jgridRow> ListRow = new List<jgridRow>();

            var danhMucLoaiXuatNhap = DanhMucDal.SelectByMa("LXN-X");
            var isXuat = true;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    
                    var pagerGet = TuVanLamDichVuDal.ByNhanVienTuNgayDenNgay(null, false, jgrsidx + " " + jgrsord, _q,
                                                                             Convert.ToInt32(jgRows), NhanVien, TuNgay,
                                                                             DenNgay);
                    foreach (var item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.NhanVien_Ten
                            , item.KH_Ten
                            , item.DV_Ten
                            , item._TuVanDichVu.ThanhToan.ToString()
                            , item._TuVanDichVu.Gia.ToString()
                            , string.Format("{0:dd/MM/yy}",item.NgayLam)
                        }));
                    }
                    var gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , pagerGet.TotalPages.ToString()
                        , pagerGet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var item = XuatNhapDal.SelectById(new Guid(ID));
                        string prefixMa = danhMucLoaiXuatNhap.KyHieu;
                        item.Ma = prefixMa + item.Ma;
                        item.XNCT = XuatNhapChiTietDal.SelectByXN_ID(item.ID.ToString());
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "draff":
                    #region draff
                    if (Security.IsAuthenticated())
                    {
                        var item = XuatNhapDal.SelectByDraff(isXuat);
                        string prefixMa = danhMucLoaiXuatNhap.KyHieu;
                        item.Ma = prefixMa + item.Ma;
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "autoCompleteByQ":
                    #region lấy dữ liệu cho grid
                    //var pagerByQ = HangHoaDal.ByDm("", false, string.Empty, _q, 10, string.Empty);
                    //sb.Append(JavaScriptConvert.SerializeObject(pagerByQ.List));
                    break;
                    #endregion
                case "reports":
                    #region bao cao
                    var pagerGet1 = TuVanLamDichVuDal.ByNhanVienTuNgayDenNgay(null, false, "LDV_NhanVien asc, LDV_NgayLam asc", _q,
                                                                             1000, NhanVien, TuNgay,
                                                                             DenNgay);

                    var list1 = (from ldv in pagerGet1.List  
                                     select new { ldv.NhanVien, ldv.NhanVien_Ten }).Distinct();

                        var itemIn = Lib.GetResource(Assembly.GetExecutingAssembly(), "lamDichVu.in.htm");
                        var itemInRow = Lib.GetResource(Assembly.GetExecutingAssembly(), "lamDichVu.in-row.htm");
                        var itemInRowFooter = Lib.GetResource(Assembly.GetExecutingAssembly(), "lamDichVu.in-row-footer.htm");
                        var danhMucReportHeader = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI");

                        var sbRow = new StringBuilder();
                        var stt = 0;
                        double total = 0;

                        foreach (var ldv in list1)
                        {
                            var sbItem = new StringBuilder();
                            var listByUsername = from p in pagerGet1.List
                                                 where p.NhanVien == ldv.NhanVien
                                                 orderby p.NgayLam
                                                 select p;
                            total = 0;
                            foreach (var xnct in listByUsername)
                            {
                                stt++;
                                sbItem.AppendFormat(itemInRow
                                    , stt
                                    , xnct.NhanVien_Ten
                                    , xnct.KH_Ten
                                    , xnct.DV_Ten
                                    , Lib.TienVietNam(xnct._TuVanDichVu.ThanhToan)
                                    , Lib.TienVietNam(xnct._TuVanDichVu.Gia)
                                    , string.Format("{0:dd/MM/yy}", xnct.NgayLam)
                                    );
                                total += xnct._TuVanDichVu.Gia;
                            }
                            sbRow.AppendFormat(
                                itemInRowFooter
                                , ldv.NhanVien_Ten
                                , sbItem
                                , Lib.TienVietNam(total)
                                , listByUsername.Count()
                                );
                        }

                        
                        var dNow = DateTime.Now;
                        sb.AppendFormat(itemIn
                            , danhMucReportHeader.Description
                            , string.Format("Ng&agrave;y {4}{0} th&aacute;ng {3}{1} năm {2}", dNow.Day, dNow.Month, dNow.Year, dNow.Month < 10 ? "0" : "", dNow.Day < 10 ? "0" : "")
                            , sbRow
                            , domain
                            );
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "lamDichVu.mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.thongKeNhanVienMgr.lamDichVu.JScript1.js")
                        , "{lamDichVuFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}


