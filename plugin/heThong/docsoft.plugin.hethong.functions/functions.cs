using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh;
using linh.frm;
using linh.json;
using linh.common;
using docsoft;
using docsoft.entities;
using System.Xml;
[assembly: WebResource("docsoft.plugin.hethong.functions.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.hethong.functions.htm.htm", "text/html", PerformSubstitution = true)]
namespace docsoft.plugin.hethong.functions
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
            string _PID = Request["PID"];
            string _Ten = Request["Ten"];
            string _Mota = Request["Mota"];
            string _Ma = Request["Ma"];
            string _Url = Request["Url"];
            string _GiaTriMacDinh = Request["GiaTriMacDinh"];
            string _Loai = Request["Loai"];
            string _ThuTu = Request["ThuTu"];
            string _Publish = Request["Publish"];
            string _Anh = Request["Anh"];
            string _Desk = Request["Desk"];
            string _DeskMacDinh = Request["DeskMacDinh"];
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    List<Function> ListGet = getTree(FunctionDal.SelectTree(Request["q"]));
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (Function item in ListGet)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            , item.Ten
                            , item.Loai != 3 ? string.Format("<img class=\"adm-fn-icon\" src=\"../up/i/{0}\" />", string.IsNullOrEmpty(item.Anh) ? "fn-icon.jpg" :item.Anh) : ""
                            , item.Ma
                            , item.Url
                            , item.ThuTu.ToString()
                            , item.Loai.ToString()
                            , item.Publish.ToString()
                            , item.GiaTriMacDinh.ToString()
                            , item.Level.ToString(), item.PID.ToString(), "true", "false" }));
                    }
                    jgrid grid = new jgrid("1", "1", ListGet.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getPid":
                    #region danh sách chọn sẵn
                    FunctionCollection ListGetPid = FunctionDal.SelectTree(Request["q"]);
                    sb.Append(JavaScriptConvert.SerializeObject(ListGetPid));
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        FunctionDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})",JavaScriptConvert.SerializeObject(FunctionDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":
                    #region lưu dữ liệu
                    Function ItemSave = new Function();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = FunctionDal.SelectById(Convert.ToInt32(_ID));
                    }
                    ItemSave.NgayCapNhat = DateTime.Now;
                    ItemSave.Ten = _Ten;
                    ItemSave.MoTa = _Mota;
                    ItemSave.Loai = Convert.ToInt16(_Loai);
                    ItemSave.Ma = _Ma;
                    ItemSave.Anh = string.Empty;
                    int ThuTu = 0;
                    if (!string.IsNullOrEmpty(_ThuTu))
                    {
                        ThuTu = Convert.ToInt32(_ThuTu);
                    }
                    ItemSave.Publish = Convert.ToBoolean(_Publish);
                    ItemSave.PID = string.IsNullOrEmpty(_PID) ? 0 : Convert.ToInt32(_PID);
                    ItemSave.ThuTu = ThuTu;
                    ItemSave.Url = _Url;
                    ItemSave.NguoiTao = Security.Username;
                    ItemSave.GiaTriMacDinh = Convert.ToBoolean(_GiaTriMacDinh);
                    ItemSave.Anh = _Anh;
                    ItemSave.Desk = Convert.ToBoolean(_Desk);
                    ItemSave.DeskMacDinh = Convert.ToBoolean(_DeskMacDinh);
                    if (ItemSave.Desk)
                    {
                        try
                        {
                            //ItemSave.Doc = ;
                            XmlDocument doc = new XmlDocument();
                            XmlNode node = doc.ImportNode(PlugHelper.RenderXml(ItemSave.Url), true);
                            doc.AppendChild(node);
                            string _DocValue = linh.common.Lib.GetXmlString(doc);
                            ItemSave.Doc = _DocValue;

                        }
                        catch (Exception ex)
                        {
                            ItemSave.Doc = string.Empty;
                            ItemSave.Desk = false;
                            sb.Append("Loi + " + ex.Message);
                        }
                    }
                    else
                    {
                        ItemSave.Doc = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = FunctionDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.Level = 0;
                        ItemSave.PIDList = string.Empty;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave = FunctionDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                default:
                    #region nạp 
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    //<input type=""text"" class=""mdl-head-txt mdl-head-search"" />
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-functions"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""functionsmdl-addBtn"" href=""javascript:functions.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""functionsmdl-editBtn"" href=""javascript:functions.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""functionsmdl-delBtn"" href=""javascript:functions.del();"">Xóa</a>
</div>
<table id=""functionsmdl-List"" class=""mdl-list"">
</table>
<div id=""functionsmdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.functions.JScript1.js")
                        , "{functions.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));                    
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        #region TreeProcess
        List<Function> getTree(List<Function> inputList)
        {
            List<Function> list = new List<Function>();
            foreach (HierarchyNode<Function> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        void buildChild(HierarchyNode<Function> item, List<Function> list)
        {
            foreach (HierarchyNode<Function> _item in item.ChildNodes)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<Function>> buildTree(List<Function> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ThuTu).ToList().AsHierarchy(e => e.ID, e => e.PID);
            List<HierarchyNode<Function>> _list = new List<HierarchyNode<Function>>();
            foreach (HierarchyNode<Function> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        #endregion
    }
}
