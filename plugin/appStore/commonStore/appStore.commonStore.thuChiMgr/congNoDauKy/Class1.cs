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

[assembly: WebResource("appStore.commonStore.thuChiMgr.congNoDauKy.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.thuChiMgr.congNoDauKy.in.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.thuChiMgr.congNoDauKy.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.thuChiMgr.congNoDauKy
{
    
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số

            HttpContext c = HttpContext.Current;
            var ID = Request["ID"];
            var KH_ID = Request["KH_ID"];
            var Tien = Request["Tien"];
            var No = Request["No"];

            var _q = c.Request["q"];
            List<jgridRow> ListRow = new List<jgridRow>();
            var danhMucKyHieu = DanhMucDal.SelectByMa("TC-THU");
            var danhMucReportHeader = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI");
            var danhMucReportFooter = DanhMucDal.SelectByMa("BAOCAO-FOOTER-THUCHI");
            var draff = Request["draff"];
            var isThu = true;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid

                    var pagerGet = CongNoDauKyDal.pagerByKhId(jgrsidx + " " + jgrsord, Convert.ToInt32(jgRows), KH_ID);
                    string prefixMas = danhMucKyHieu.KyHieu;
                    foreach (var item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            , item._KhachHang.Ten
                            , Lib.TienVietNam(item.Tien)
                            , item.No.ToString()
                            , item.NgayTao.ToString("dd-MM-yyyy")
                            , item.NguoiTao
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
                        CongNoDauKyDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var item = CongNoDauKyDal.SelectById(new Guid(ID));
                        item._KhachHang = KhachHangDal.SelectById(item.KH_ID);
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
                        var item = string.IsNullOrEmpty(ID) ? new CongNoDauKy() : CongNoDauKyDal.SelectById(new Guid(ID));
                        if (!string.IsNullOrEmpty(KH_ID))
                        {
                            item.KH_ID = new Guid(KH_ID);                            
                        }
                        item.Tien = Convert.ToDouble(Tien);
                        item.No = Convert.ToBoolean(No);
                        item.NguoiCapNhat = Security.Username;
                        item.NgayCapNhat = DateTime.Now;

                        if (string.IsNullOrEmpty(ID))
                        {
                            item.ID = Guid.NewGuid();
                            item.NguoiTao = Security.Username;
                            item.NgayTao = DateTime.Now;
                            item = CongNoDauKyDal.Insert(item);
                        }
                        else
                        {
                            item = CongNoDauKyDal.Update(item);
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
                        var itemIn = Lib.GetResource(Assembly.GetExecutingAssembly(), "congNoDauKy.in-natural.htm");
                        var item = ThuChiDal.SelectById(new Guid(ID));
                        sb.AppendFormat(itemIn
                            , string.Format("Ng&agrave;y {4}{0} th&aacute;ng {3}{1} năm {2}", item.NgayTao.Day, item.NgayTao.Month, item.NgayTao.Year, item.NgayTao.Month < 10 ? "0" : "", item.NgayTao.Day < 10 ? "0" : "")
                            , item.NDTC_Ten
                            , string.Format("{0}{1}",danhMucKyHieu.KyHieu, item.SoPhieu)
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
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.congNoDauKy.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.congNoDauKy.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "congNoDauKy.mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.congNoDauKy.JScript1.js")
                        , "{congNoDauKyFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}


