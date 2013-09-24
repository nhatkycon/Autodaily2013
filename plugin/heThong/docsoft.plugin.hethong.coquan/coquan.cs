using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh.json;
using linh.frm;
using docsoft;
using docsoft.entities;
using linh.common;
using System.Globalization;
[assembly: WebResource("docsoft.plugin.hethong.coquan.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.hethong.coquan.htm.htm", "text/html", PerformSubstitution = true)]
namespace docsoft.plugin.hethong.coquan
{
    public class Class1: docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region các dữ liệu yêu cầu từ client
            string _ID = Request["ID"];
            string _PID = Request["PID"];
            string _Ten = Request["Ten"];
            string _Mota = Request["Mota"];
            string _ThuTu = Request["ThuTu"];
            string _CQ_ID = Request["CQ_ID"];
            string _UpdateList = Request["UpdateList"];
            string _CQ_Active = Request["Active"];
            string _CQ_Ma = Request["Ma"];
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    List<CoQuan> ListCq = getTree(CoQuanDal.TreeByUsername(Security.Username, Request["q"]));
                    List<jgridRow> ListRow = new List<jgridRow>();                    
                    foreach (CoQuan cq in ListCq)
                    {
                        ListRow.Add(new jgridRow(cq.ID.ToString(), new string[] { 
                            cq.ID.ToString()
                            , cq.ThuTu.ToString()
                            , cq.Ma
                            , cq.Ten
                            ,cq.MoTa
                            , cq.NguoiTao
                            , string.Format("{0} {1:dd-MM-yy}/{2} {3:dd/MM/yy}"
                            ,cq.NguoiTao,cq.NgayTao,cq.NguoiCapNhat,cq.NgayCapNhat)
                            ,cq.NSD.ToString()
                            , cq.Level.ToString(), cq.PID.ToString(), "true", "false" }));
                    }
                    jgrid grid = new jgrid("1", "1", ListCq.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getPid":
                    #region lấy toàn bộ danh mục
                    List<CoQuan> ListCqGetList = getTree(CoQuanDal.TreeByUsername(Security.Username, Request["q"]));
                    sb.Append(JavaScriptConvert.SerializeObject(ListCqGetList));
                    break;
                    #endregion
                case "getCoQuanConByUsername":
                    #region lấy toàn bộ danh mục
                    CoQuanCollection ListCqGetConByUsername = CoQuanDal.CoQuanConByUsername(Security.Username);
                    sb.Append(JavaScriptConvert.SerializeObject(ListCqGetConByUsername));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        CoQuanDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "new":
                    break;
                case "edit":
                    #region edit
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append(JavaScriptConvert.SerializeObject(CoQuanDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":
                    #region lưu
                    CoQuan ItemSave = new CoQuan();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = CoQuanDal.SelectById(Convert.ToInt32(_ID));
                    }
                    int ThuTu = 0;
                    if (!string.IsNullOrEmpty(_ThuTu))
                    {
                        ThuTu = Convert.ToInt32(_ThuTu);
                    }
                    ItemSave.ThuTu = ThuTu;
                    ItemSave.Ma = _CQ_Ma;
                    ItemSave.Ten = _Ten;
                    ItemSave.MoTa = _Mota;
                    ItemSave.PID = string.IsNullOrEmpty(_PID) ? 0 : Convert.ToInt32(_PID);
                    ItemSave.NgayCapNhat = DateTime.Now;
                    ItemSave.NguoiCapNhat = Security.Username;
                    ItemSave.Active = Convert.ToBoolean(_CQ_Active);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = CoQuanDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NguoiTao = Security.Username;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.Level = 0;
                        ItemSave.PIDList = string.Empty;
                        ItemSave = CoQuanDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getFunction":
                    #region lấy quyền theo cq_id
                    FunctionCollection ListGetFunction = FunctionDal.SelectByUserAndCQID(Security.Username, _CQ_ID);
                    sb.Append(getTop(ListGetFunction));
                    break;
                    #endregion
                case "upadteFunction":
                    #region Lưu phân tính năng
                    sb.Append(CoQuanFunctionDal.UpdateByUpdateListAndCQID(_CQ_ID, _UpdateList, Security.Username));
                    break;
                    #endregion
                case "SelectByNodeAndWfId":
                    #region lấy theo WF_ID và NODE_ID
                    sb.Append(JavaScriptConvert.SerializeObject(CoQuanDal.SelectByNodeAndWfId(Security.Username, Request["q"], "20")));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.coquan.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region mặc định - trả về module ban đầu
//<input type=""text"" class=""mdl-head-txt mdl-head-search"" />
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-coQuan"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""coquanmdl-addBtn"" href=""javascript:coquan.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""coquanmdl-editBtn"" href=""javascript:coquan.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""coquanmdl-delBtn"" href=""javascript:coquan.del();"">Xóa</a>
</div>
<table id=""coquanmdl-List"" class=""mdl-list"">
</table>
<div id=""coquanmdl-Pager""></div>
<div class=""sub-mdl"">

<ul>
<li>
<a id=""coquanmdl-functionmdl-subMdlBtn"" href=""#coquanmdl-functionmdl-coQuanFnMdl"">Phân quyền sử dụng</a>
</li>
</ul>
<div id=""mdl-1"">
<div class=""mdl-submdl-panel"" id=""coquanmdl-functionmdl-coQuanFnMdl"">
</div>
</div>
</div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.coquan.JScript1.js")
                        ,"{coquan.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        #region nghiệp vụ cho coquanfunction
        string getTop(FunctionCollection list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Function item in list)
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
        string getChild(int _Id, FunctionCollection list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<ul>");
            foreach (Function item in list)
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
        bool hasChild(int _Id, FunctionCollection list)
        {
            bool oke = false;
            foreach (Function item in list)
            {
                if (item.PID == _Id && item.ID != _Id)
                {
                    return true;
                }
            }
            return oke;
        }
        #endregion
        #region TreeProcess
        List<CoQuan> getTree(List<CoQuan> inputList)
        {
            List<CoQuan> list = new List<CoQuan>();
            foreach (HierarchyNode<CoQuan> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        void buildChild(HierarchyNode<CoQuan> item, List<CoQuan> list)
        {
            foreach (HierarchyNode<CoQuan> _item in item.ChildNodes)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<CoQuan>> buildTree(List<CoQuan> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ThuTu).ToList().AsHierarchy(e => e.ID, e => e.PID);
            List<HierarchyNode<CoQuan>> _list = new List<HierarchyNode<CoQuan>>();
            foreach (HierarchyNode<CoQuan> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        #endregion
    }    
}
