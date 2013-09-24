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
using linh.common;
[assembly: WebResource("plugin.rss.phanLoai.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.rss.phanLoai.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.rss.phanLoai
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
            string _PID = Request["PID"];
            string _Alias = Request["Alias"];
            string _ThuTu = Request["ThuTu"];
            string _Keywords = Request["Keywords"];
            string _Description = Request["Description"];
            docbao.entitites.DanhMuc ItemSave;
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "BAO_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<docbao.entitites.DanhMuc> PagerGet = docbao.entitites.DanhMucDal.pagerNormal("", false, jgrsidx + " " + jgrsord);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (docbao.entitites.DanhMuc dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                              dm.ID.ToString()                            
                            , dm.P_Ten
                            , dm.Ten
                            , dm.Alias
                            ,dm.ThuTu.ToString()
                            ,dm.Keywords
                            ,dm.Description
                            ,dm.TongSoTin.ToString()
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
                        docbao.entitites.DanhMucDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(docbao.entitites.DanhMucDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    ItemSave = new docbao.entitites.DanhMuc();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = docbao.entitites.DanhMucDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        ItemSave = new docbao.entitites.DanhMuc();
                    }
                    ItemSave.Ten = _Ten;
                    ItemSave.P_ID = Convert.ToInt32(_PID);
                    ItemSave.Alias = _Alias;
                    ItemSave.Keywords = _Keywords;
                    ItemSave.Description = _Description;
                    ItemSave.ThuTu = Convert.ToInt32(_ThuTu);                         
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = docbao.entitites.DanhMucDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave = docbao.entitites.DanhMucDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getautoComplete":
                    #region Lấy danh sách danh mục
                    sb.Append(JavaScriptConvert.SerializeObject(getTree(docbao.entitites.DanhMucDal.SelectAll())));
                    break;
                    #endregion
                case "getautoCompletePid":
                    #region Lấy danh sách danh mục
                    sb.Append(JavaScriptConvert.SerializeObject(docbao.entitites.DanhMucDal.SelectPid()));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.phanLoai.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-phanLoaiMdl"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""phanLoaiMdl-addBtn"" href=""javascript:phanLoaiFn.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""phanLoaiMdl-editBtn"" href=""javascript:phanLoaiFn.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""phanLoaiMdl-delBtn"" href=""javascript:phanLoaiFn.del();"">Xóa</a>
</div>
<table id=""phanLoaiMdl-List"" class=""mdl-list""></table>
<div id=""phanLoaiMdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.phanLoai.JScript1.js")
                        , "{phanLoaiFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        #region TreeProcess
        List<docbao.entitites.DanhMuc> getTree(List<docbao.entitites.DanhMuc> inputList)
        {
            List<docbao.entitites.DanhMuc> list = new List<docbao.entitites.DanhMuc>();
            foreach (HierarchyNode<docbao.entitites.DanhMuc> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        void buildChild(HierarchyNode<docbao.entitites.DanhMuc> item, List<docbao.entitites.DanhMuc> list)
        {
            foreach (HierarchyNode<docbao.entitites.DanhMuc> _item in item.ChildNodes)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<docbao.entitites.DanhMuc>> buildTree(List<docbao.entitites.DanhMuc> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ThuTu).ToList().AsHierarchy(e => e.ID, e => e.P_ID);
            List<HierarchyNode<docbao.entitites.DanhMuc>> _list = new List<HierarchyNode<docbao.entitites.DanhMuc>>();
            foreach (HierarchyNode<docbao.entitites.DanhMuc> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        #endregion
    }
}
