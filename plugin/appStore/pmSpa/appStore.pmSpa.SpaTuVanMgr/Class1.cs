using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using linh.core.dal;
using linh.frm;
using linh.json;
using docsoft.entities;
using pmSpa.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using System.IO;
using System.Web;

[assembly: WebResource("appStore.pmSpa.SpaTuVanMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.SpaTuVanMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.pmSpa.SpaTuVanMgr
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            var c = HttpContext.Current;
            #region Variables

            var ID = Request["ID"];
            var TT_ID = Request["TT_ID"];
            var DV_ID = Request["DV_ID"];
            var Ma = Request["Ma"];
            var So = Request["So"];
            var KH_ID = Request["KH_ID"];
            var TuVanVien = Request["TuVanVien"];
            var Ngay = Request["Ngay"];
            var NgayTao = Request["NgayTao"];
            var NguoiTao = Request["NguoiTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var TinhTrangSucKhoe = Request["TinhTrangSucKhoe"];
            var TinhTrangLanDa = Request["TinhTrangLanDa"];
            var GhiChu = Request["GhiChu"];
            var YKienKhachHang = Request["YKienKhachHang"];
            var HieuQua = Request["HieuQua"];
            var PDV_ID = Request["PDV_ID"];
            var TuVanVienDanhGia = Request["TuVanVienDanhGia"];
            var KhongTheoDoi = Request["KhongTheoDoi"];
            var DichVuDieuTriKhac = Request["DichVuDieuTriKhac"];
            var KH_NguoiGioiThieu = Request["KH_NguoiGioiThieu"];
            
            var _q = c.Request["q"];
            #endregion

            var ListRow = new List<jgridRow>();
            switch (subAct)
            {
                case "get":
                    #region get
                    var pagerGet = TuVanDal.pagerNormal("", false, "TV_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), KH_ID);
                    foreach (var item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.So
                            , item.KH_Ten
                            , item.TuVanVien_Ten
                            , string.Format("{0:dd/MM/yy}",item.Ngay
                            )
                        }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , pagerGet.TotalPages.ToString()
                        , pagerGet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                #endregion
                case "draffTuVan":
                    #region draffTuVan
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(TuVanDal.SelectDraff(DAL.con())));
                    break;
                    #endregion
                case "addTinhTrang":
                    #region addTinhTrang
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var itemTuVanTinhTrang = TuVanTinhTrangDal.Insert(new TuVanTinhTrang()
                        {
                            ID = Guid.NewGuid()
                            ,
                            NgayTao = DateTime.Now
                            ,
                            TT_ID = new Guid(TT_ID)
                            ,
                            ThuTu = 0
                            ,
                            TV_ID = new Guid(ID)
                        });
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemTuVanTinhTrang));
                    }

                    break;
                    #endregion
                case "delTinhTrang":
                    #region delTinhTrang
                    TuVanTinhTrangDal.DeleteById(new Guid(TT_ID));
                    break;
                    #endregion
                case "search":
                    #region search
                    var pagerSearch = TuVanDal.pagerNormal("", false, "KM_Ngay desc", _q, 20);
                    sb.Append(JavaScriptConvert.SerializeObject(pagerSearch.List));
                    break;
                    #endregion
                case "save":
                     #region saveTuVan
                    if (!string.IsNullOrEmpty(So))
                    {
                        var tvItem = string.IsNullOrEmpty(ID) ? new TuVan() : TuVanDal.SelectById(new Guid(ID));

                        tvItem.ID = new Guid(ID);
                        tvItem.DichVuDieuTriKhac = DichVuDieuTriKhac;
                        tvItem.GhiChu = GhiChu;
                        tvItem.HieuQua = false;
                        tvItem.KH_ID = new Guid(KH_ID);
                        tvItem.Ma = Ma;
                        tvItem.Ngay = Convert.ToDateTime(Ngay, new CultureInfo("vi-Vn"));
                        tvItem.NgayCapNhat = DateTime.Now;
                        tvItem.NguoiCapNhat = Security.Username;
                        tvItem.So = So;
                        tvItem.TinhTrangLanDa = TinhTrangLanDa;
                        tvItem.TinhTrangSucKhoe = TinhTrangSucKhoe;
                        tvItem.TuVanVien = TuVanVien;
                        tvItem.YKienKhachHang = YKienKhachHang;
                        if(string.IsNullOrEmpty(ID) || tvItem.NgayTao==DateTime.MinValue)
                        {
                            tvItem.NgayTao = DateTime.Now;
                            tvItem.NguoiTao = Security.Username;
                            tvItem = TuVanDal.Insert(tvItem);
                        }
                        else
                        {
                            tvItem = TuVanDal.Update(tvItem);
                        }
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(tvItem));
                    }
                    break;
                    #endregion
                case "edit":
                     #region editTuVan
                    var itemEditTuvan = TuVanDal.SelectById(new Guid(ID));
                    itemEditTuvan._TuVanTinhTrang = TuVanTinhTrangDal.SelectByTvId(ID);
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemEditTuvan));
                    break;
                    #endregion
                case "del":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        KhuyenMaiDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion                
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.SpaTuVanMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region default
                    {
                        var ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                        sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                        sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                            , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.SpaTuVanMgr.JScript1.js")
                            , "{SpaTuVanMgrFn.loadgrid();}");
                        sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                        break;
                    }
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
