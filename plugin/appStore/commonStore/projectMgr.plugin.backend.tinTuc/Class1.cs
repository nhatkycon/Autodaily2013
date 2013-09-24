using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web;
using linh;
using linh.frm;
using linh.json;
using linh.common;
using linh.controls;
using docsoft;
using docsoft.entities;
using System.Xml;
using System.Globalization;
using System.IO;
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.htm.htm", "text/html")]
[assembly: WebResource("projectMgr.plugin.backend.TinLienQuan.htm", "text/html")]
namespace projectMgr.plugin.backend.tinTuc
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
            string _F_ID = Request["F_ID"];
            string _GH_ID = Request["GH_ID"];
            string _Lang = Request["Lang"];
            string _Alias = Request["Alias"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _LangBased = Request["LangBased"];
            string _KeyWords = Request["KeyWords"];
            string _Description = Request["Description"];
            string _PID = Request["DMID"];
            string _PTen = Request["DMTen"];
            string _Ten = Request["Ten"];
            string _Mota = Request["Mota"];
            string _NoiDung_tt = Request["NoiDung_tt"];
            string _ThuTu = Request["ThuTu"];
            string _Anh = Request["Anh"];
            string _Hot = Request["Hot"];
            string _q = Request["q"];
            string _HetHan = Request["HetHan"];
            string _NgayHetHan = Request["NgayHetHan"];
            string _NgayCapNhat = Request["NgayCapNhat"];
            string _Status = Request["status"];
            string _Nguon = Request["Nguon"];
            string _CID = Request["CID"];
            List<jgridRow> ListRow;
            #endregion
            string _NguoiTao = Security.Username;
            var admin = false;
            if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "TIN_NgayCapNhat";
            if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc"; 
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    

                    var pagerGet = TinDal.PagerQuanTri(string.Empty, false, Convert.ToInt32(jgRows), jgrsidx + " " + jgrsord, _PID, _q, null, Security.Username, null, true);

                    ListRow = new List<jgridRow>();
                    foreach (Tin item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,item.LangBased.ToString()
                            ,item._ID.ToString()
                            ,item.Lang
                            ,item.ThuTu.ToString()
                            ,item.Active.ToString()
                            ,item.Hot.ToString()
                            ,string.Format("<img src=\"../up/tintuc/{0}\" style=\"width:50px;height:50px; \"/>",item.Anh)
                            ,item.Ten
                            ,item.MoTa
                            ,item.DM_Ten
                            ,item.Views.ToString()
                            ,item.NguoiTao
                            ,item.NgayCapNhat.ToString("dd/MM/yyyy")                            
                            ,item.HetHan.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pagerGet.TotalPages.ToString(), pagerGet.Total.ToString(), ListRow);
                    //jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getSubTin":
                    #region lấy danh sách
                    var listTinRelation = TinDal.tinLienQuanByRelationPid(Convert.ToInt32(jgRows) , _ID);
                    ListRow = new List<jgridRow>();
                    foreach (var item in listTinRelation)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,string.Format("<img src=\"../up/tintuc/{0}\" style=\"width:50px;height:50px; \"/>",item.Anh)
                            ,item.Ten
                            ,item.MoTa
                            ,item.NguoiTao
                            ,item.NgayCapNhat.ToString("dd/MM/yyyy")
                        }));
                    }
                    jgrid grid1 = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, listTinRelation.Count.ToString(), listTinRelation.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid1));
                    break;
                    #endregion
                case "addSubTin":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        RelationDal.Insert(new Relation()
                                               {
                                                   CID = new Guid(_CID),
                                                   PID = new Guid(_ID),
                                                   RowId = Guid.NewGuid()
                                               });
                    }
                    break;
                    #endregion
                case "delSubTin":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        RelationDal.DeleteByCidPid(_CID,_ID);
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(TinDal.SelectByIdView(_ID)));                        
                    }
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        TinDal.DeleteMultiById(_ID, "TIN_TUC");
                    }
                    break;
                    #endregion
                case "duyet":
                    #region Duyệt tin hàng loạt
                    var itemDuyet = new Tin();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        itemDuyet.multiID = _ID;
                        itemDuyet.Active = Convert.ToBoolean(_Status);
                        TinDal.UpdateMulti(itemDuyet);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "autoCompleteSearch":
                    #region autoCompleteSearch
                    var pagerSearch = TinDal.PagerQuanTri(string.Empty, false, Convert.ToInt32(20),
                                                          jgrsidx + " " + jgrsord, string.Empty, _q, true, Security.Username,
                                                          null, true);
                    sb.Append(JavaScriptConvert.SerializeObject(pagerSearch.List));
                    break;
                    #endregion
                case "hot":
                    #region Chuyển thành tin hot
                    Tin ItemHot = new Tin();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemHot.multiID = _ID;
                        ItemHot.Hot = Convert.ToBoolean(_Status);
                        TinDal.UpdateHotMulti(ItemHot);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "hethan":
                    #region Hết hạn
                    Tin ItemHetHan = new Tin();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemHetHan.multiID = _ID;
                        ItemHetHan.HetHan = Convert.ToBoolean(_Status);
                        if (ItemHetHan.HetHan == true)
                        {
                            ItemHetHan.NgayHetHan = DateTime.Now;
                        }
                        TinDal.UpdateHetHanMulti(ItemHetHan);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "save":
                    #region lưu
                    var itemSave = new Tin();
                    if (string.IsNullOrEmpty(_Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        itemSave = TinDal.SelectById(_ID);
                    }
                    if (!string.IsNullOrEmpty(_Nguon))
                    {
                        itemSave.Nguon = (_Nguon);
                    }
                    itemSave.Ten = _Ten;
                    itemSave.DM_ID = new Guid(_PID);
                    // ItemSave.DM_Ten = _PTen;
                    itemSave.Anh = _Anh;
                    if (string.IsNullOrEmpty(_ThuTu))
                    {
                        _ThuTu = "0";
                    }
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        itemSave.GH_ID = new Guid(_GH_ID);
                    }
                    itemSave.ThuTu = Convert.ToInt32(_ThuTu);
                    itemSave.MoTa = _Mota;
                    itemSave.NoiDung = _NoiDung_tt;
                    itemSave.KeyWords = _KeyWords;
                    itemSave.Description = _Description;
                    itemSave.Alias = _Alias;
                    //itemSave.Lang = _Lang;
                    itemSave.LangBased = Convert.ToBoolean(_LangBased);
                    if (!string.IsNullOrEmpty(_LangBased_ID))
                    {
                        itemSave.LangBased_ID = new Guid(_LangBased_ID);
                    }
                    itemSave.Hot = Convert.ToBoolean(_Hot);
                    itemSave.NgayCapNhat = DateTime.Now;
                    if (_Public == "1")
                    {
                        itemSave.NgayDang = DateTime.Now;
                    }
                    itemSave.NguoiCapNhat = Security.Username;
                    itemSave.HetHan = Convert.ToBoolean(_HetHan);
                    if (!string.IsNullOrEmpty(_NgayHetHan))
                    {
                        itemSave.NgayHetHan = Convert.ToDateTime(_NgayHetHan, new CultureInfo("vi-Vn"));
                    }
                    if (!string.IsNullOrEmpty(_NgayCapNhat))
                    {
                        itemSave.NgayCapNhat = Convert.ToDateTime(_NgayCapNhat, new CultureInfo("vi-Vn"));//.AddHours(dt.Hour).AddMinutes(dt.Minute).AddSeconds(dt.Second);
                    }
                    else
                    {
                        itemSave.NgayCapNhat = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        itemSave = TinDal.Update(itemSave);
                    }
                    else
                    {
                        itemSave.NguoiTao = Security.Username;
                        itemSave.NgayTao = DateTime.Now;
                        itemSave.RowId = Guid.NewGuid();
                        itemSave.ID = Guid.NewGuid();
                        itemSave = TinDal.Insert(itemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.JScript1.js")
                        , "{tinfn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
