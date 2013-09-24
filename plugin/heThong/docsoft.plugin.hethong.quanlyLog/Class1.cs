using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using System.Web.UI;
using docsoft;
using docsoft.entities;

using linh.json;
using linh.controls;
[assembly: WebResource("docsoft.plugin.hethong.quanlyLog.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace docsoft.plugin.hethong.quanlyLog
{
    public class Class1 : docPlugUI
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _userName = Request["UserName"];
             string _IP = Request["IPTruyCap"];
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<Log> PagerGet = LogDal.pagerNormal("", false, "LOG_" + jgrsidx + " " + jgrsord,_userName,_IP, Request["rows"]);

                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (Log log in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(log.ID.ToString(), new string[] { log.ID.ToString(), log.LLOG_ID.ToString(), log.NgayTao.ToString(), log.Username, log.RawUrl, log.RequestIp }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.quanlyLog.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
            <div id=""mdl-head"">
<input type=""text"" _value="""" class=""admtxt UserName""/><button class=""admfilter-btn""></button>
<input type=""text"" class=""admtxt-medium ui-corner-all IPTruyCap"" /><button class=""admSearch-btn""></button> 

     
            </div>
<table id=""quanlylogmdl-List"" class=""mdl-list""></table>
<div id=""quanlylogmdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.quanlyLog.JScript1.js")
                        , "{quanlylog.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
