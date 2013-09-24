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

[assembly: WebResource("appStore.commonStore.xuatNhapMgr.baoCaoKho.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.xuatNhapMgr.baoCaoKho.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.xuatNhapMgr.baoCaoKho
{
    
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số
            var TuNgay = Request["TuNgay"];
            var DenNgay = Request["DenNgay"];
            var KHO_ID = Request["KHO_ID"];
            var DM_ID = Request["DM_ID"];
            var d = DateTime.Now;
            var DauThang = new DateTime(d.Year, d.Month, 1).ToString("yyyy-MM-dd");
            var CuoiThang = new DateTime(d.Year, d.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            if(!string.IsNullOrEmpty(TuNgay))
            {
                DauThang = Convert.ToDateTime(TuNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                CuoiThang = Convert.ToDateTime(DenNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");
            }
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid

                    double DauKy_Tien = 0;
                    double Nhap_Tien = 0;
                    double Xuat_Tien = 0;
                    double CuoiKy_Tien = 0;
                    foreach (var item in XuatNhapReportDal.baoCaoTuNgayDenNgayTheoKho(DauThang, CuoiThang, KHO_ID, DM_ID))
                    {
                        ListRow.Add(new jgridRow(item.HH_ID.ToString(), new string[] { 
                            item.HH_ID.ToString()
                            , item.HH_Ma
                            , item.HH_Ten
                            , item.HH_DonVi
                            , Lib.TienVietNam(item.HH_GiaNhap)
                            , Lib.TienVietNam(item.DauKy_SoLuong)
                            , Lib.TienVietNam(item.DauKy_Tien)
                            , Lib.TienVietNam(item.Nhap_SoLuong)
                            , Lib.TienVietNam(item.Nhap_Tien)
                            , Lib.TienVietNam(item.Xuat_SoLuong)
                            , Lib.TienVietNam(item.Xuat_Tien)
                            , Lib.TienVietNam(item.CuoiKy_SoLuong)
                            , Lib.TienVietNam(item.CuoiKy_Tien)
                        }));
                        DauKy_Tien += item.DauKy_Tien;
                        Nhap_Tien += item.Nhap_Tien;
                        Xuat_Tien += item.Xuat_Tien;
                        CuoiKy_Tien += item.CuoiKy_Tien;
                    }
                    var uData = new Dictionary<string, object>();
                    uData.Add("HH_Ten", "Tổng");
                    uData.Add("DauKy_Tien", Lib.TienVietNam(DauKy_Tien));
                    uData.Add("Nhap_Tien", Lib.TienVietNam(Nhap_Tien));
                    uData.Add("Xuat_Tien", Lib.TienVietNam(Xuat_Tien));
                    uData.Add("CuoiKy_Tien", Lib.TienVietNam(CuoiKy_Tien));
                    var gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , "1"
                        , "10000"
                        , ListRow
                        , uData
                            );
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                    #endregion
                case "reports":
                    #region bao cao
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var itemXn = XuatNhapDal.SelectById(new Guid(ID));
                        var listRpXn = new List<XuatNhap>();
                        listRpXn.Add(itemXn);

                        var listRpKh = new List<KhachHang>();
                        listRpKh.Add(KhachHangDal.SelectById(itemXn.KH_ID));

                        var listRpXnCt=XuatNhapChiTietDal.SelectByXN_ID(ID);

                    }
                    
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.xuatNhapMgr.baoCaoKho.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "baoCaoKho.mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.xuatNhapMgr.baoCaoKho.JScript1.js")
                        , "{baoCaoKhoFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }


    }
}


