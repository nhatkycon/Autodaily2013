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

[assembly: WebResource("appStore.commonStore.thuChiMgr.quanLyChi.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.thuChiMgr.quanLyChi.in.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.thuChiMgr.quanLyChi.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.thuChiMgr.quanLyChi
{
    
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số

            HttpContext c = HttpContext.Current;
            var ID = c.Request["ID"];
            var NDTC_ID = c.Request["NDTC_ID"];
            var SoPhieu = c.Request["SoPhieu"];
            var SoTien = c.Request["SoTien"];
            var Mota = c.Request["Mota"];
            var NgayTao = c.Request["NgayTao"];
            var NguoiTao = c.Request["NguoiTao"];
            var NgaySua = c.Request["NgaySua"];
            var NguoiSua = c.Request["NguoiSua"];
            var LoaiQuy = c.Request["LoaiQuy"];
            var LoaiCandoi = c.Request["LoaiCandoi"];
            var isCandoi = c.Request["isCandoi"];
            var Thu = c.Request["Thu"];
            var XN_ID = c.Request["XN_ID"];
            var P_ID = c.Request["P_ID"];
            var DV_ID = c.Request["DV_ID"];
            var TuNgay = c.Request["TuNgay"];
            var DenNgay = c.Request["DenNgay"];
            var _q = c.Request["q"];
            List<jgridRow> ListRow = new List<jgridRow>();
            var danhMucKyHieu = DanhMucDal.SelectByMa("TC-CHI");
            var danhMucReportHeader = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI");
            var danhMucReportFooter = DanhMucDal.SelectByMa("BAOCAO-FOOTER-THUCHI");
            var draff = Request["draff"];
            var isThu = false;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid

                    var pagerGet = ThuChiDal.pagerTuNgayDenNgay(jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows),
                                                                isThu, TuNgay, DenNgay, NDTC_ID);
                    string prefixMas = danhMucKyHieu.KyHieu;
                    foreach (var item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
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
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        ThuChiDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var item = ThuChiDal.SelectById(new Guid(ID));
                        string prefixMa = danhMucKyHieu.KyHieu;
                        item.SoPhieu = prefixMa + item.SoPhieu;
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "draff":
                    #region draff
                    if (Security.IsAuthenticated())
                    {
                        var item = ThuChiDal.SelectByDraff(isThu);
                        string prefixMa = danhMucKyHieu.KyHieu;
                        item.SoPhieu = prefixMa + item.SoPhieu;
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "save":
                    #region save
                    if (Security.IsAuthenticated())
                    {
                        var item = draff == "1" ? new ThuChi() : ThuChiDal.SelectById(new Guid(ID));
                        var prefixMa = danhMucKyHieu.KyHieu;
                        SoPhieu = SoPhieu.Replace(prefixMa, "");
                        item.SoPhieu = SoPhieu;
                        if (!string.IsNullOrEmpty(DV_ID))
                        {
                            item.DV_ID = new Guid(DV_ID);                            
                        }
                        item.LoaiCandoi = Convert.ToInt32(LoaiCandoi);
                        item.LoaiQuy = Convert.ToInt32(LoaiQuy);
                        item.Mota = Mota;
                        if (!string.IsNullOrEmpty(NDTC_ID))
                        {
                            item.NDTC_ID = new Guid(NDTC_ID);
                        }
                        item.NgaySua = DateTime.Now;
                        item.NguoiSua = Security.Username;
                        if (!string.IsNullOrEmpty(P_ID))
                        {
                            item.P_ID = new Guid(P_ID);
                        }
                        item.SoTien = Convert.ToDouble(SoTien);
                        item.Thu = isThu;
                        if (!string.IsNullOrEmpty(XN_ID))
                        {
                            item.XN_ID = new Guid(XN_ID);
                        }
                        item.isCandoi = false;
                        item.NgayTao = Convert.ToDateTime(NgayTao, new CultureInfo("vi-Vn"));
                        if (draff == "1")
                        {
                            item.ID = new Guid(ID);
                            item.NguoiTao = NguoiTao;
                            item = ThuChiDal.Insert(item);
                        }
                        else
                        {
                            item = ThuChiDal.Update(item);
                        }
                        // TODO: Tiếp tục phần thu chi                      
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "reports":
                    #region bao cao
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var itemIn = Lib.GetResource(Assembly.GetExecutingAssembly(), "quanLyChi.in-natural.htm");
                        var item = ThuChiDal.SelectById(new Guid(ID));
                        sb.AppendFormat(itemIn
                            , string.Format("Ng&agrave;y {4}{0} th&aacute;ng {3}{1} năm {2}", item.NgayTao.Day, item.NgayTao.Month, item.NgayTao.Year, item.NgayTao.Month < 10 ? "0" : "", item.NgayTao.Day < 10 ? "0" : "")
                            , item.NDTC_Ten
                            , string.Format("{0}{1}", danhMucKyHieu.KyHieu, item.SoPhieu)
                            , (item.LoaiQuy == 1 ? "Tài khoản" : "Tiền mặt")
                            , Lib.TienVietNam(item.SoTien)
                            , Lib.So_chu(item.SoTien)
                            , item.P_Ten
                            , item.NguoiTao_Ten
                            , item.Mota
                            , domain
                            , danhMucReportHeader.Description
                            , danhMucReportFooter.Description);
                    }

                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.quanLyChi.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.quanLyChi.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "quanLyChi.mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.quanLyChi.JScript1.js")
                        , "{quanLyChiFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}


