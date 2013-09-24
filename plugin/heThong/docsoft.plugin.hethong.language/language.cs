using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh;
using linh.frm;
using linh.json;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.common;
[assembly: WebResource("docsoft.plugin.hethong.language.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.hethong.language.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace docsoft.plugin.hethong.language
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
            string _Ma = Request["Ma"];
            string _KyHieu = Request["KyHieu"];
            string _ThuTu = Request["ThuTu"];
            string _q = Request["q"];
            string _Active = Request["Active"];
            Language Item;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<Language> PagerGet = LanguageDal.pagerNormal("", false, "L_" + jgrsidx + " " + jgrsord, Request["rows"]);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (Language item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(),
                            new string[] { item.ID.ToString()
                                , item.Ma
                                , item.Ten
                                , item.ThuTu.ToString()
                                , item.Active.ToString()}));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "save":
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = LanguageDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new Language();
                    }
                    Item.Ten = _Ten;
                    Item.Ma = _Ma;
                    Item.ThuTu = Int32.Parse(_ThuTu);
                    Item.Active = Convert.ToBoolean(_Active);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = LanguageDal.Update(Item);
                    }
                    else
                    {
                        Item = LanguageDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(LanguageDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "getActive":
                    #region chỉnh sửa
                    sb.Append(JavaScriptConvert.SerializeObject(LanguageDal.SelectAll()));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        LanguageDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "AutoComplete":
                    #region xóa
                    JavaScriptConvert.SerializeObject(LanguageDal.SelectAll());
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.language.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-languageFn"" />
</span>
<a _resource=""admin.system.label.add"" class=""mdl-head-btn mdl-head-add"" id=""languageMdl-addBtn"" href=""javascript:languageFn.add();"">Thêm</a>
<a _resource=""admin.system.label.edit"" class=""mdl-head-btn mdl-head-edit"" id=""languageMdl-editBtn"" href=""javascript:languageFn.edit();"">Sửa</a>
<a  _resource=""admin.system.label.del"" class=""mdl-head-btn mdl-head-del"" id=""languageMdl-delBtn"" href=""javascript:languageFn.del();"">Xóa</a>
</div>

<table id=""languageMdl-List"" class=""mdl-list""></table>
<div id=""languageMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.language.JScript1.js")
                        , "{languageFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn)); 
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
