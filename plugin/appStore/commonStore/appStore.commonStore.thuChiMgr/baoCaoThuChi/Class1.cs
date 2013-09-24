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

[assembly: WebResource("appStore.commonStore.thuChiMgr.baoCaoThuChi.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.thuChiMgr.baoCaoThuChi.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.thuChiMgr.baoCaoThuChi
{
    
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số

            HttpContext c = HttpContext.Current;
            var TuNgay = c.Request["TuNgay"];
            var DenNgay = c.Request["DenNgay"];
            var dNow = DateTime.Now;
            var dauThang = new DateTime(dNow.Year, 1, 1).ToString("yyyy-MM-dd");
            var cuoiThang = new DateTime(dNow.Year, dNow.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            TuNgay = string.IsNullOrEmpty(TuNgay) ? dauThang : Convert.ToDateTime(TuNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");
            DenNgay = string.IsNullOrEmpty(DenNgay) ? cuoiThang : Convert.ToDateTime(DenNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");


            var _q = c.Request["q"];
            List<jgridRow> ListRow = new List<jgridRow>();
            var danhMucKyHieuChi = DanhMucDal.SelectByMa("TC-CHI");
            var danhMucKyHieuThu = DanhMucDal.SelectByMa("TC-THU");
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid

                    var pagerGet = ThuChiReportDal.SelectTuNgayDenNgay(TuNgay, DenNgay);
                    var prefixMaChi = danhMucKyHieuChi.KyHieu;
                    var prefixMaThu = danhMucKyHieuThu.KyHieu;
                    foreach (var item in pagerGet)
                    {
                        ListRow.Add(new jgridRow(item.ma.ToString(), new string[]
                                                                         {
                                                                             item.ma.ToString()
                                                                             ,
                                                                             item.sophieu == "0" ? "" : string.Format("{0}{1}",
                                                                                           (item.isthu
                                                                                                ? prefixMaThu
                                                                                                : prefixMaChi),
                                                                                           item.sophieu)
                                                                             , item.diengiai
                                                                             , Lib.TienVietNam(item.thu_tk)
                                                                             , Lib.TienVietNam(item.thu_tm)
                                                                             , Lib.TienVietNam(item.thu_t)
                                                                             , Lib.TienVietNam(item.chi_tk)
                                                                             , Lib.TienVietNam(item.chi_tm)
                                                                             , Lib.TienVietNam(item.chi_t)
                                                                             , Lib.TienVietNam(item.tt_tk)
                                                                             , Lib.TienVietNam(item.tt_tm)
                                                                             , Lib.TienVietNam(item.tt_t)
                                                                             , Lib.TienVietNam(item.sodu_tk)
                                                                             , Lib.TienVietNam(item.sodu_tm)
                                                                             , Lib.TienVietNam(item.sodu_t)
                                                                             , item.loaiquy.ToString()
                                                                             , item.isthu.ToString()
                                                                             , item.isCandoi.ToString()
                                                                             , item.ngay
                                                                             , item.NguoiTao
                                                                         }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , "1"
                        , pagerGet.Count.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.baoCaoThuChi.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.baoCaoThuChi.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "baoCaoThuChi.mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.baoCaoThuChi.JScript1.js")
                        , "{baoCaoThuChiFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}


