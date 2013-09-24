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
[assembly: WebResource("docsoft.plugin.hethong.pagesMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.hethong.pagesMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace docsoft.plugin.hethong.pagesMgr
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["_ID"];
            string _Ten = Request["_Ten"];
            string _Active = Request["_Active"];
            string _Alias = Request["_Alias"];
            string _KeyWords = Request["_KeyWords"];
            string _Descriptions = Request["_Descriptions"];
            string _q = Request["q"];
            PagesMgr Item = new PagesMgr();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "PG_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
                    Pager<PagesMgr> PagerGet = PagesMgrDal.pagerNormal(jgrsidx + " " + jgrsord, Convert.ToInt32(jgRows));
                    
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (PagesMgr item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                              item.ID.ToString()
                            ,  item.Ten
                            , item.Alias
                            , item.KeyWords
                            , item.Descriptions
                            , item.Active.ToString()
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
                        PagesMgrDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat(@"({0})",JavaScriptConvert.SerializeObject(PagesMgrDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = PagesMgrDal.SelectById(Convert.ToInt32(_ID));
                    }       
                    Item.Ten = _Ten;
                    Item.Alias = _Alias;
                    Item.KeyWords = _KeyWords;
                    Item.Descriptions = _Descriptions;
                    Item.Active = Convert.ToBoolean(_Active);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = PagesMgrDal.Update(Item);
                    }
                    else
                    {
                        Item = PagesMgrDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "autoComplete":
                    #region Lấy danh sách danh mục
                    PagesMgrCollection autoCompleteList = PagesMgrDal.SelectAll();
                    sb.Append(JavaScriptConvert.SerializeObject(autoCompleteList));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.pagesMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-pagesMgrFn"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""pagesMgrMdl-addBtn"" href=""javascript:;"" onclick=""pagesMgrFn.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""pagesMgrMdl-editBtn"" href=""javascript:;"" onclick=""pagesMgrFn.edit('#pagesMgrMdl-List');"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""pagesMgrMdl-delBtn"" href=""javascript:;"" onclick=""pagesMgrFn.del('#pagesMgrMdl-List');"">Xóa</a>
</div>
<table id=""pagesMgrMdl-List"" class=""mdl-list""></table>
<div id=""pagesMgrMdl-Pager""></div>

<div class=""sub-mdl"">
<ul>
    <li>
    <a id=""pagesMgrMdl-functionmdl-subMdlBtn"" href=""#pagesMgrMdl-coQuanMdl"">Đơn vị sử dụng</a>
    </li>
</ul>
    <div id=""pagesMgrMdl-mdl-12"">
        <div class=""mdl-submdl-panel"" id=""pagesMgrMdl-coQuanMdl"">
        </div>
    </div>
</div>

");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.pagesMgr.JScript1.js")
                        , "{pagesMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        #region nghiệp vụ cho coquanfunction
        string getTop(CoQuanCollection list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CoQuan item in list)
            {
                if (item.PID == 0)
                {
                    var childInSide = hasChild(item.ID, list);
                    sb.AppendFormat(@"<li id=""phtml_{1}"" _ID=""{1}"" class=""{3}  {2}""><a href=""javascript:;"">{0}</a>"
                        , item.Ten, item.ID, item.Active ? "jstree-checked" : "jstree-unchecked"
                        , childInSide ? "jstree-open" : "");
                    if (childInSide)
                    {
                        sb.Append(getChild(item.ID, list));
                    }
                    sb.AppendFormat("</li>");
                }
            }
            return sb.ToString();
        }
        string getChild(int _Id, CoQuanCollection list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<ul>");
            foreach (CoQuan item in list)
            {
                if (item.PID == _Id)
                {
                    var childInSide = hasChild(item.ID, list);
                    sb.AppendFormat(@"<li id=""phtml_{1}"" class=""{3} {2}"" _ID=""{1}"" ><a href=""javascript:;"">{0}</a>", item.Ten, item.ID
                        , item.Active ? "jstree-checked" : "jstree-unchecked", childInSide ? "jstree-open" : "");
                    if (childInSide)
                    {
                        sb.Append(getChild(item.ID, list));
                    }
                    sb.AppendFormat("</li>");
                }
            }
            sb.AppendFormat("</ul>");
            return sb.ToString();
        }
        bool hasChild(int _Id, CoQuanCollection list)
        {
            bool oke = false;
            foreach (CoQuan item in list)
            {
                if (item.PID == _Id && item.ID != _Id)
                {
                    return true;
                }
            }
            return oke;
        }
        #endregion
    }
}
