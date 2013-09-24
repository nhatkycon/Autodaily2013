using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using linh.core.dal;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
[assembly: WebResource("docsoft.plugin.danhmuc.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.danhmuc.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace docsoft.plugin.danhmuc
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _PID = Request["PID"];
            string _LDMID = Request["LDMID"];
            string _Lang = Request["Lang"];
            string _Ten = Request["Ten"];
            string _Alias = Request["Alias"];
            string _Ma = Request["Ma"];
            string _KyHieu = Request["KyHieu"];
            string _GiaTri = Request["GiaTri"];
            string _KeyWords = Request["KeyWords"];
            string _Description = Request["Description"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _ThuTu = Request["ThuTu"];
            string _Anh = Request["Anh"];
            string _LangBased = Request["LangBased"];
            string _q = Request["q"];
            string _LDM_Ma = Request["LDM_Ma"];
            if (_PID == "0")
                _PID = string.Empty;
            DanhMuc Item;
            List<DanhMuc> List=new List<DanhMuc>();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    List = getTree(DanhMucDal.SelectByLDMID(_LDMID));
                    var listRow = List.Select(dm => new jgridRow(dm.ID.ToString(), new string[]
                                                                                       {
                                                                                           dm.ID.ToString(), dm.LangBased.ToString(), dm.ID.ToString(), dm.Lang, dm.ThuTu.ToString(), dm.LDM_Ten, dm.Ma, dm.KyHieu, dm.GiaTri, string.Format("<img class=\"adm-fn-icon\" src=\"../up/i/{0}?ref=\" />", string.IsNullOrEmpty(dm.Anh) ? "fn-icon.jpg" : dm.Anh, Guid.NewGuid().ToString().Replace("-", "")), dm.Ten, string.Format("{0:dd/MM/yy}", dm.NgayCapNhat), dm.NguoiTao + "/" + dm.NguoiSua, dm.Level.ToString(), dm.PID.ToString(), "true", "true"
                                                                                       })).ToList();
                    var grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, List.Count.ToString(), List.Count.ToString(), listRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion       
                case "getByMa":
                    #region lấy dữ liệu cho grid
                    List = getTree(DanhMucDal.SelectByLDMMa(_LDM_Ma));
                    var listRowByMa = List.Select(dm => new jgridRow(dm.ID.ToString(), new string[]
                                                                                       {
                                                                                           dm.ID.ToString(), dm.LangBased.ToString(), dm.ID.ToString(), dm.Lang, dm.ThuTu.ToString(), dm.LDM_Ten, dm.Ma, dm.KyHieu, dm.GiaTri, string.Format("<img class=\"adm-fn-icon\" src=\"../up/i/{0}?ref=\" />", string.IsNullOrEmpty(dm.Anh) ? "fn-icon.jpg" : dm.Anh, Guid.NewGuid().ToString().Replace("-", "")), dm.Ten, string.Format("{0:dd/MM/yy}", dm.NgayCapNhat), dm.NguoiTao + "/" + dm.NguoiSua, dm.Level.ToString(), dm.PID.ToString(), "true", "true"
                                                                                       })).ToList();
                    var gridByMa = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, List.Count.ToString(), List.Count.ToString(), listRowByMa);
                    sb.Append(JavaScriptConvert.SerializeObject(gridByMa));
                    break;
                    #endregion     
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DanhMucDal.DeleteById(new Guid(_ID));
                    }
                    break;
                    #endregion
                case "autoCompleteLangBased":
                    #region xóa
                    sb.Append(JavaScriptConvert.SerializeObject(getTree(DanhMucDal.SelectByLDMMa(_LDM_Ma))));
                    break;
                    #endregion
                case "autoCompleteLangBasedNoChild":
                    #region xóa

                    var list1 = DanhMucDal.SelectByLDMMa(_LDM_Ma);
                    var list2 = from p in list1
                                where p.PID==Guid.Empty
                                select p;
                    sb.Append(JavaScriptConvert.SerializeObject(getTree(list2.ToList())));
                    break;
                    #endregion
                case "autoCompleteByPid":
                    #region xóa
                    sb.Append(JavaScriptConvert.SerializeObject(DanhMucDal.SelectByPid(_ID)));
                    break;
                    #endregion
                case "autoCompleteLdmMa":
                    #region xóa
                    sb.Append(JavaScriptConvert.SerializeObject(getTree(DanhMucDal.SelectByLDMMa(_LDM_Ma))));
                    break;
                    #endregion
                case "autoCompleteLangBasedByDM":
                    #region xóa
                    sb.Append(JavaScriptConvert.SerializeObject(getTree(DanhMucDal.SelectTreeByDmMa(DAL.con(), _Ma))));
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(DanhMucDal.SelectById(new Guid(_ID))));
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = DanhMucDal.SelectById(new Guid(_ID));
                    }
                    else
                    {
                        Item = new DanhMuc();
                    }
                    Item.Ten = _Ten;
                    Item.Ma = _Ma;
                    Item.LDM_ID = new Guid(_LDMID);
                    Item.KyHieu = _KyHieu;
                    Item.NgayCapNhat = DateTime.Now;
                    Item.NguoiTao = Security.Username;
                    Item.GiaTri = _GiaTri;
                    Item.ThuTu = Convert.ToInt32(_ThuTu);
                    Item.NguoiSua = Security.Username;
                    Item.KeyWords = _KeyWords;
                    Item.Description = _Description;
                    Item.Alias = _Alias;
                    Item.Lang = _Lang;
                    Item.Anh = _Anh;
                    Item.LangBased = Convert.ToBoolean(_LangBased);
                    if (!string.IsNullOrEmpty(_LangBased_ID))
                    {
                        Item.LangBased_ID = new Guid(_LangBased_ID);
                    }
                    if (!string.IsNullOrEmpty(_PID))
                    {
                        Item.PID = new Guid(_PID);
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = DanhMucDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        Item.ID = Guid.NewGuid();
                        if (!string.IsNullOrEmpty(_LangBased_ID))
                        {
                            Item.LangBased_ID = Item.ID;
                        }
                        Item = DanhMucDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.danhmuc.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.danhmuc.JScript1.js")
                        , "{danhmuc.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        #region TreeProcess
        List<DanhMuc> getTree(List<DanhMuc> inputList)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            var plist = from c in buildTree(inputList)
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> item in plist)
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        List<DanhMuc> getTreeTop(List<DanhMuc> inputList)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            foreach (HierarchyNode<DanhMuc> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                break;
            }
            return list;
        }
        void buildChild(HierarchyNode<DanhMuc> item, List<DanhMuc> list)
        {
            var plist = from c in item.ChildNodes
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> _item in plist)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<DanhMuc>> buildTree(List<DanhMuc> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ID).ToList().AsHierarchy(e => e.ID, e => e.PID);
            List<HierarchyNode<DanhMuc>> _list = new List<HierarchyNode<DanhMuc>>();
            foreach (HierarchyNode<DanhMuc> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        #endregion
    }
}
