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
[assembly: WebResource("docsoft.plugin.hethong.zoneMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.hethong.zoneMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace docsoft.plugin.hethong.zoneMgr
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["_ID"];
            string _PG_ID = Request["_PG_ID"];
            string _Ma = Request["_Ma"];
            string _SID = Request["_SID"];
            string _ThuTu = Request["_ThuTu"];
            string _CssClass = Request["_CssClass"];
            string _Width = Request["_Width"];
            string _HtmlBefore = Request["_HtmlBefore"];
            string _HtmlAfter = Request["_HtmlAfter"];
            string _q = Request["q"];
            Zone Item = new Zone();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "Z_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
                    Pager<Zone> PagerGet = ZoneDal.pagerNormal(jgrsidx + " " + jgrsord, Convert.ToInt32(jgRows));
                    
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (Zone item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                              item.ID.ToString()
                            ,  item.PG_Ten
                            , item.Ma
                            , item.SID
                            , item.ThuTu.ToString()
                            ,item.Width
                            ,item.CssClass
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
                        ZoneDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat(@"({0})", JavaScriptConvert.SerializeObject(ZoneDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = ZoneDal.SelectById(Convert.ToInt32(_ID));
                    }
                    Item.PG_ID = Convert.ToInt32(_PG_ID);
                    Item.Ma = _Ma;
                    Item.SID = _SID;
                    Item.ThuTu = Convert.ToInt32(_ThuTu);
                    Item.CssClass = _CssClass;
                    Item.Width = _Width;
                    Item.HtmlAfter = _HtmlAfter;
                    Item.HtmlBefore = _HtmlBefore;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = ZoneDal.Update(Item);
                    }
                    else
                    {
                        Item = ZoneDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "autoComplete":
                    #region Lấy danh sách danh mục
                    ZoneCollection autoCompleteList = ZoneDal.SelectAll();
                    sb.Append(JavaScriptConvert.SerializeObject(autoCompleteList));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.zoneMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-zoneMgrFn"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""zoneMgrFnMdl-addBtn"" href=""javascript:;"" onclick=""zoneMgrFn.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""zoneMgrFnMdl-editBtn"" href=""javascript:;"" onclick=""zoneMgrFn.edit('#zoneMgrFnMdl-List');"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""zoneMgrFnMdl-delBtn"" href=""javascript:;"" onclick=""zoneMgrFn.del('#zoneMgrFnMdl-List');"">Xóa</a>
</div>
<table id=""zoneMgrFnMdl-List"" class=""mdl-list""></table>
<div id=""zoneMgrFnMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.zoneMgr.JScript1.js")
                        , "{zoneMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
