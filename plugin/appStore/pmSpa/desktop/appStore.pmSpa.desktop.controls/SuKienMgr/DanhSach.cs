using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.frm;
using linh.common;
using System.Reflection;
using linh.json;
using pmSpa.entities;
using System.Globalization;
using Microsoft.Reporting.WebForms;
using docbao.entitites;
[assembly: WebResource("appStore.pmSpa.desktop.controls.SuKienMgr.SuKien.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.SuKienMgr.SuKienAll.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.SuKienMgr.htm.htm", "text/html", PerformSubstitution = true)]
namespace appStore.pmSpa.desktop.controls.SuKienMgr
{
    public class DanhSach : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con(), this.Page);
            writer.Write(Html);
            base.Render(writer);
        }

        public override void KhoiTao(SqlConnection con, Page page)
        {
            var sb = new StringBuilder();
            var cs = page.ClientScript;
            var c = HttpContext.Current;
            var _id = c.Request["VID"];

            #region bien
            var ID = c.Request["ID"];
            var PID = c.Request["PID"];
            var KH_ID = c.Request["KH_ID"];
            var DM_ID = c.Request["DM_ID"];
            var Ten = c.Request["Ten"];
            var MoTa = c.Request["MoTa"];
            var NhanVien = c.Request["NhanVien"];
            var NgayBatDau = c.Request["NgayBatDau"];
            var NgayKetThuc = c.Request["NgayKetThuc"];
            var Ngay = c.Request["Ngay"];
            var Gio = c.Request["Gio"];
            var CaNgay = c.Request["CaNgay"];
            var NgayTao = c.Request["NgayTao"];
            var NguoiTao = c.Request["NguoiTao"];
            var NgayCapNhat = c.Request["NgayCapNhat"];
            var NguoiCapNhat = c.Request["NguoiCapNhat"];
            var BoQua = c.Request["BoQua"];
            var Xoa = c.Request["Xoa"];
            #endregion

            switch (subAct)
            {
                case "get":
                    #region Nạp js
                        sb.Append(JavaScriptConvert.SerializeObject(SuKienDal.SelectUnXoa(con, Xoa, "100")));
                    break;
                    #endregion
                case "draff":
                    #region Nạp draff
                    sb.Append(Guid.NewGuid().ToString());
                    break;
                    #endregion
                case "save":
                    #region save
                    if (!string.IsNullOrEmpty(Ten))
                    {
                        var item = new SuKien();
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = SuKienDal.SelectById(new Guid(ID));   
                        }
                        item.NgayBatDau = Convert.ToDateTime(string.Format("{0} {1}",Ngay, Gio) , new CultureInfo("vi-Vn"));
                        item.NgayCapNhat = DateTime.Now;
                        item.MoTa = MoTa;
                        item.NguoiCapNhat = Security.Username;
                        item.NhanVien = NhanVien;
                        item.Ten = Ten;
                        if (!string.IsNullOrEmpty(DM_ID))
                        {
                            item.DM_ID = new Guid(DM_ID);
                        }
                        if (!string.IsNullOrEmpty(KH_ID))
                        {
                            item.KH_ID = new Guid(KH_ID);
                        }
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = SuKienDal.Update(item);
                        }
                        else
                        {
                            item.ID = Guid.NewGuid();
                            item.NgayTao = DateTime.Now;
                            item.NguoiTao = Security.Username;
                            item = SuKienDal.Insert(item);
                        }
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "del":
                    #region save
                    if (Security.IsAuthenticated())
                    {
                        SuKienDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region edit
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(SuKienDal.SelectById(new Guid(ID))));
                    break;
                    #endregion
                case "getGio":
                    #region Nạp Gio
                    var listGio = new List<string>();
                    for (int i = 8; i < 19; i++)
                    {
                        for (int j = 0; j < 60; j += 20)
                        {
                            listGio.Add(string.Format("{0}:{1}", i.ToString().Length == 1 ? string.Format("0{0}", i) : i.ToString(), j.ToString().Length == 1 ? string.Format("0{0}", j) : j.ToString()));
                        }
                    }
                    sb.Append(JavaScriptConvert.SerializeObject(listGio));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(DanhSach), "appStore.pmSpa.desktop.controls.SuKienMgr.SuKien.js"));
                    break;
                    #endregion                
                default:
                    #region nạp
                    var mdlFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "SuKienMgr.mdl.htm");
                    var itemFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "SuKienMgr.su-kien-item.htm");
                    var sbItem = new StringBuilder();
                    foreach (var sk in SuKienDal.SelectUnXoa(con, Xoa, "100"))
                    {
                        sbItem.AppendFormat(itemFormat
                            , sk.ID
                            , sk.NgayBatDau.ToString("hh:mm dd/MM/yyyy")
                            , sk.Ten
                            , sk.MoTa
                            , sk.NhanVien_Ten
                            , sk.KH_Ten);
                    }
                    sb.Append(string.Format(mdlFormat, sbItem));
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "SuKienMgr.su-kien-item-tmpl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(DanhSach), "appStore.pmSpa.desktop.controls.SuKienMgr.SuKienAll.js")
                        , "{SuKienAllFn.init();}");
                    break;
                    #endregion
            }

            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }    
}
