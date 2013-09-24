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

[assembly: WebResource("appStore.pmSpa.khoHangMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.khoHangMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.pmSpa.khoHangMgr
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
            var DiaChi = c.Request["DiaChi"];
            var Ma = c.Request["Ma"];
            var KV_ID = c.Request["KV_ID"];
            var HH_ID = c.Request["HH_ID"];
            if(!Security.IsAuthenticated())
            {
                Response.Clear();
                Response.End();                
            }
            var _q = c.Request["q"];
            #endregion

            var listRow = new List<jgridRow>();
            switch (subAct)
            {
                case "get":
                    #region get
                    var pagerGet = KhoHangDal.pagerNormal("", false, "KH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows));
                    foreach (var item in pagerGet.List)
                    {
                        listRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.Ma
                            , item.Ten
                            , item.DiaChi
                            , item.KV_Ten
                        }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , pagerGet.TotalPages.ToString()
                        , pagerGet.Total.ToString()
                        , listRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                #endregion
                case "search":
                    #region search
                    var pagerGetSearch = KhoHangDal.pagerNormal("", false, "KH_Ten", _q, 20);
                    sb.Append(JavaScriptConvert.SerializeObject(pagerGetSearch.List));
                    break;
                    #endregion
                case "searchByHangHoa":
                    #region search
                    var pagerGetSearchByHangHoa = KhoHangDal.SelectByHangHoa(HH_ID);
                    sb.Append(JavaScriptConvert.SerializeObject(pagerGetSearchByHangHoa));
                    break;
                    #endregion
                case "save":
                    #region chỉnh sửa
                    if (Security.IsAuthenticated())
                    {
                        var item = new KhoHang();
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = KhoHangDal.SelectById(new Guid(ID));
                        }
                        item.Ma = Ma;
                        item.DiaChi = DiaChi;
                        item.Ten = Ten;
                        if(!string.IsNullOrEmpty(KV_ID))
                        {
                            item.KV_ID = new Guid(KV_ID);
                        }
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = KhoHangDal.Update(item);
                        }
                        else
                        {
                            item.ID = Guid.NewGuid();
                            item = KhoHangDal.Insert(item);
                        }
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(KhoHangDal.SelectById(new Guid(ID))));

                    }
                    break;
                    #endregion
                case "del":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        KhoHangDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion                
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.khoHangMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region default
                    {
                        var ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                        sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                        sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                            , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.khoHangMgr.JScript1.js")
                            , "{KhoHangMgrFn.loadgrid();}");
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
