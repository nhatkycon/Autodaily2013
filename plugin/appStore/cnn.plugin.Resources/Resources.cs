using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using linh;
using linh.frm;
using linh.json;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.common;
[assembly: WebResource("cnn.plugin.Resources.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.Resources.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace cnn.plugin.Resources
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
           
            #region Tham số
            string _ID = Request["ID"];
            string _Lang = Request["Lang"];
            string _K = Request["K"];
            string _V = Request["V"];
            string _q = Request["q"];
            var c = HttpRuntime.Cache;
            
            docsoft.entities.Resources Item;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<docsoft.entities.Resources> PagerGet = ResourcesDal.pagerByLang("", false, "R_" + jgrsidx + " " + jgrsord, Convert.ToInt32(jgRows), _Lang);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (docsoft.entities.Resources item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(),
                            new string[] { item.ID.ToString()
                                , item.Lang
                                , item.K
                                , item.V}));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "save":
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = ResourcesDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new docsoft.entities.Resources();
                    }
                    Item.Lang = _Lang;
                    Item.K = _K;
                    Item.V = _V;
                    //Item.Ten = _Ten;
                    //Item.Ma = _Ma;
                    //Item.ThuTu = Int32.Parse(_ThuTu);
                    //Item.Active = Convert.ToBoolean(_Active);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = ResourcesDal.Update(Item);
                    }
                    else
                    {
                        Item = ResourcesDal.Insert(Item);
                    }
                    c.Remove("Resources-" + Item.Lang);
                    sb.Append("1");
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(ResourcesDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "getByLang":
                    #region getByLang: lay theo ngon ngu
                    if (!string.IsNullOrEmpty(_Lang))
                    {
                        sb.AppendFormat("ResourcesArr={0}", toArray(ResourcesDal.SelectByLang(_Lang)));
                    }
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = ResourcesDal.SelectById(Convert.ToInt32(_ID));
                        ResourcesDal.DeleteById(Convert.ToInt32(_ID));
                        c.Remove("Resources-" + Item.Lang);
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.Resources.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-ResourcesFn"" />
</span>
<a _resource=""admin.system.label.add"" class=""mdl-head-btn mdl-head-add"" id=""ResourcesMdl-addBtn"" href=""javascript:ResourcesFn.add();"">Thêm</a>
<a _resource=""admin.system.label.edit"" class=""mdl-head-btn mdl-head-edit"" id=""ResourcesMdl-editBtn"" href=""javascript:ResourcesFn.edit();"">Sửa</a>
<a _resource=""admin.system.label.del"" class=""mdl-head-btn mdl-head-del"" id=""ResourcesMdl-delBtn"" href=""javascript:ResourcesFn.del();"">Xóa</a>
<select class=""slt"" onchange=""ResourcesFn.changeLang(this);"" id=""ResourcesMdl-changeLangSlt""></select>
</div>
<table id=""ResourcesMdl-List"" class=""mdl-list""></table>
<div id=""ResourcesMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.Resources.JScript1.js")
                        , "{ResourcesFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn)); 
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        string toArray(ResourcesCollection list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            int i=0;
            foreach (docsoft.entities.Resources item in list)
            {
                sb.AppendFormat(@"""{0}"":""{1}""{2}", item.K, item.V, i == list.Count - 1 ? "" : ",");
                i++;
            }
        sb.Append("}");    
        return sb.ToString();
        }
    }
}
