using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using docbao.entitites;
[assembly: WebResource("plugin.rss.bao.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.rss.bao.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.rss.bao
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _Ten = Request["Ten"];
            string _Url = Request["Url"];
            string _RssUrl = Request["RssUrl"];
            Bao ItemSave;
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "BAO_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<Bao> PagerGet = BaoDal.pagerNormal("", false, jgrsidx + " " + jgrsord);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (Bao dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                              dm.ID.ToString()                            
                            , dm.Ten
                            , dm.Url
                            , dm.RssUrl
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        BaoDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(BaoDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    ItemSave = new Bao();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = BaoDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        ItemSave = new Bao();
                    }
                    ItemSave.Ten = _Ten;
                    ItemSave.Url = _Url;
                    ItemSave.RssUrl = _RssUrl;                    
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = BaoDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave = BaoDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getautoComplete":
                    #region Lấy danh sách danh mục
                    sb.Append(JavaScriptConvert.SerializeObject(BaoDal.SelectAll()));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.bao.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-baoMdl"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""baoMdl-addBtn"" href=""javascript:baoFn.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""baoMdl-editBtn"" href=""javascript:baoFn.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""baoMdl-delBtn"" href=""javascript:baoFn.del();"">Xóa</a>
</div>
<table id=""baoMdl-List"" class=""mdl-list""></table>
<div id=""baoMdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.bao.JScript1.js")
                        , "{baoFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
