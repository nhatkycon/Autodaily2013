using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

[assembly: WebResource("appStore.pmSpa.khuyenMaiMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.khuyenMaiMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.pmSpa.khuyenMaiMgr
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            var c = HttpContext.Current;
            #region Variables
            var ID = c.Request["ID"];
            var Ten = c.Request["Ten"];
            var MoTa = c.Request["MoTa"];
            var Ma = c.Request["Ma"];
            var NoiDung = c.Request["NoiDung"];
            var TuNgay = c.Request["TuNgay"];
            var DenNgay = c.Request["DenNgay"];
            var SoLuong = c.Request["SoLuong"];
            var ChietKhau = c.Request["ChietKhau"];
            var TienChietKhau = c.Request["TienChietKhau"];
            var Active = c.Request["Active"];
            var ThuTu = c.Request["ThuTu"];
            var NgayTao = c.Request["NgayTao"];
            var NgayCapNhat = c.Request["NgayCapNhat"];
            var NguoiTao = c.Request["NguoiTao"];
            var NguoiCapNhat = c.Request["NguoiCapNhat"];

            if(!Security.IsAuthenticated())
            {
                Response.Clear();
                Response.End();                
            }
            var _q = c.Request["q"];
            #endregion

            List<jgridRow> ListRow = new List<jgridRow>();
            switch (subAct)
            {
                case "get":
                    #region get
                    var pagerGet = KhuyenMaiDal.pagerNormal("", false, "KM_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows));
                    foreach (var item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.Ma
                            , item.Ten
                            , item.SoLuong.ToString()
                            , string.Format("{0:dd-MM-yy}-{1:dd-MM-yy}",item.TuNgay,item.DenNgay)
                            , Lib.TienVietNam(item.TienChietKhau)
                            , item.ChietKhau.ToString()
                            , item.Active.ToString()
                            , item.ThuTu.ToString()
                            , string.Format("{0:dd/MM/yy}",item.NgayCapNhat
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
                case "search":
                    #region search
                    var pagerSearch = KhuyenMaiDal.pagerNormal("", false, "KM_NgayTao desc", _q, 20);
                    sb.Append(JavaScriptConvert.SerializeObject(pagerSearch.List));
                    break;
                    #endregion
                case "save":
                    #region chỉnh sửa
                    if (Security.IsAuthenticated())
                    {
                        var item = new KhuyenMai();
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = KhuyenMaiDal.SelectById(new Guid(ID));
                        }
                        item.Active = Convert.ToBoolean(Active);
                        item.ChietKhau = Convert.ToDouble(ChietKhau);
                        item.DenNgay = Convert.ToDateTime(DenNgay, new CultureInfo("vi-Vn"));
                        item.Ma = Ma;
                        item.MoTa = MoTa;
                        item.NgayCapNhat = DateTime.Now;
                        item.NguoiCapNhat = Security.Username;
                        item.NoiDung = NoiDung;
                        item.SoLuong = Convert.ToInt32(SoLuong);
                        item.Ten = Ten;
                        item.ThuTu = Convert.ToInt32(ThuTu);
                        item.TienChietKhau = Convert.ToDouble(TienChietKhau);
                        item.TuNgay = Convert.ToDateTime(TuNgay, new CultureInfo("vi-Vn"));
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = KhuyenMaiDal.Update(item);
                        }
                        else
                        {
                            item.ID = Guid.NewGuid();
                            item.NgayTao = DateTime.Now;
                            item.NguoiTao = Security.Username;
                            item = KhuyenMaiDal.Insert(item);
                        }
                        sb.Append("1");
                    }
                    
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(KhuyenMaiDal.SelectById(new Guid(ID))));

                    }
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
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.khuyenMaiMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region default
                    {
                        var ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                        sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                        sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                            , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.khuyenMaiMgr.JScript1.js")
                            , "{KhuyenMaiMgrFn.loadgrid();}");
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
