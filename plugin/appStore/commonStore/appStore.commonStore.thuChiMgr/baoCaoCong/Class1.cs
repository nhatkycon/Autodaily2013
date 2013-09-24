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

[assembly: WebResource("appStore.commonStore.thuChiMgr.baoCaoCong.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.thuChiMgr.baoCaoCong.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.thuChiMgr.baoCaoCong
{
    
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số

            HttpContext c = HttpContext.Current;
            var listRow = new List<jgridRow>();
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid

                    foreach (var item in KhachHangDal.SelectCongNo(false.ToString()))
                    {
                        listRow.Add(new jgridRow(item.ID.ToString(), new string[]
                                                                         {
                                                                             item.ID.ToString()
                                                                             ,item.Ten
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
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.baoCaoCong.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.baoCaoCong.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "baoCaoCong.mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.thuChiMgr.baoCaoCong.JScript1.js")
                        , "{baoCaoCongFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}


