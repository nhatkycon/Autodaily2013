using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using linh.json;
using docsoft;
using System.Web.UI;
using linh.controls;
using docbao.entitites;
[assembly: WebResource("plugin.rss.tin.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.rss.tin.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.rss.tin
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _DM_ID = Request["DM_ID"];
            string _CM_ID = Request["CM_ID"];
            string _Ten = Request["Ten"];
            string _ThuTu = Request["ThuTu"];
            string _MoTa = Request["MoTa"];
            string _Keywords = Request["Keywords"];
            string _NoiDung = Request["NoiDung"];
            string _Active = Request["Active"];
            string _Home = Request["Home"];
            string _Hot = Request["Hot"];
            string _Hot1 = Request["Hot1"];
            string _Hot2 = Request["Hot2"];
            string _NoiBatHome = Request["NoiBatHome"];
            string _NoiBatDm = Request["NoiBatDm"];
            string _DocNhieu = Request["DocNhieu"];
            string _Hot3 = Request["Hot3"];
            string _Anh = Request["Anh"];
            string _q = Request["q"];
            string _Bao = Request["Bao"];
            string _TpId = Request["TpId"];
            string _Nid = Request["Nid"];
            string _Ngay = Request["Ngay"];
            string _BlId = Request["BlId"];
            string _tag = Request["tag"];
            string _jsoncallback = Request["jsoncallback"];
            Tin Item;
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "T_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    Pager<Tin> PagerGet = TinDal.pagerAll("", false, Convert.ToInt32(jgRows), jgrsidx + " " + jgrsord, _q, _DM_ID, _CM_ID, _Bao, _TpId, _Nid, _Ngay, _tag);
                    foreach (Tin dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , string.Format("<img  src=\"../up/rss/{0}\" />", linh.common.Lib.imgSize(dm.Anh,"50x50"))
                            , string.Format("<b>{0}</b><br/>{2}",dm.Ten, "", dm.Url)
                            , string.Format("{0} > {1}",dm.CM_Ten,dm.DM_Ten)
                            , dm.NgayTao.ToString("hh:mm - dd/MM/yyyy")
                            , dm.Hot.ToString()
                            , dm.Hot1.ToString()
                            , dm.Hot2.ToString()
                            , dm.Hot3.ToString()
                            , dm.NoiBatDm.ToString()
                            , dm.NoiBatHome.ToString()
                            , dm.DocNhieu.ToString()
                            , dm.Views.ToString()
                            , dm.BinhChon.ToString()
                            , dm.Diem.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.AppendFormat("{0}", string.IsNullOrEmpty(_jsoncallback) ? string.Format("{0}",JavaScriptConvert.SerializeObject(grid)) : string.Format("{0}({1})",_jsoncallback, JavaScriptConvert.SerializeObject(grid)));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        TinDal.DeleteById(Convert.ToInt32(_ID));
                        sb.AppendFormat("{0}{1}", _jsoncallback, 1);
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("{0}({1})", _jsoncallback, JavaScriptConvert.SerializeObject(TinDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = TinDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new Tin();
                    }
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                   
                    Item.Ten = _Ten;
                    Item.Anh = _Anh;
                    Item.MoTa = _MoTa;
                    Item.NoiDung = _NoiDung;                    
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = TinDal.Update(Item);
                    }
                    else
                    {
                        Item.Url = domain;
                        Item = TinDal.Insert(Item);
                    }
                    sb.AppendFormat("{0}{1}", _jsoncallback, 1);
                    break;
                    #endregion
                case "saveTinAttr":
                    #region saveTinAttr: lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = TinDal.SelectById(Convert.ToInt32(_ID));
                        if (!string.IsNullOrEmpty(_NoiBatHome))
                        {
                            Item.NoiBatHome = Convert.ToBoolean(_NoiBatHome);
                        }
                        if (!string.IsNullOrEmpty(_NoiBatDm))
                        {
                            Item.NoiBatDm = Convert.ToBoolean(_NoiBatDm);
                        }
                        if (!string.IsNullOrEmpty(_DocNhieu))
                        {
                            Item.DocNhieu = Convert.ToBoolean(_DocNhieu);
                        }
                        if (!string.IsNullOrEmpty(_Hot))
                        {
                            Item.Hot = Convert.ToBoolean(_Hot);
                        }
                        if (!string.IsNullOrEmpty(_Hot1))
                        {
                            Item.Hot1 = Convert.ToBoolean(_Hot1);
                        }
                        if (!string.IsNullOrEmpty(_Hot2))
                        {
                            Item.Hot2 = Convert.ToBoolean(_Hot2);
                        }
                        if (!string.IsNullOrEmpty(_Hot3))
                        {
                            Item.Hot3 = Convert.ToBoolean(_Hot3);
                        }
                        Item = TinDal.UpdateAttr(_ID, _NoiBatHome, _NoiBatDm, _DocNhieu, _Hot, _Hot1, _Hot2, _Hot3);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getautoComplete":
                    #region Lấy danh sách danh mục
                    sb.Append(JavaScriptConvert.SerializeObject(TopicDal.SelectAll()));
                    break;
                    #endregion
                case "autoCompleteSearch":
                    #region autoCompleteSearch: Tìm kiếm
                    sb.Append(JavaScriptConvert.SerializeObject(TinDal.SelectTopTimKiem(20, _q)));
                    break;
                    #endregion
                case "getTopicByTinId":
                    #region getTopicByTinId: Lấy danh sách topic theo tinId
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        TopicCollection List12 = TopicDal.SelectByTin(_ID);
                        foreach (Topic dm in List12)
                        {
                            ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , dm.Ten
                            , dm.ThuTu.ToString()
                            , dm.MoTa
                            , string.Format(@"<input _id=""{2}""  {0} type=""checkbox"" onclick=""tinFn.saveTopic(this,'{1}');"" />",dm.Active ? @" checked=""checked""" : "",_ID,dm.ID)
                        }));
                        }
                        grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, List12.Count.ToString(), List12.Count.ToString(), ListRow);
                        sb.Append(JavaScriptConvert.SerializeObject(grid));
                    }
                    break;
                    #endregion
                case "getNhomByTinId":
                    #region getNhomByTinId: Lấy danh sách nhóm theo tinId
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        NhomCollection List12 = NhomDal.SelectByTin(_ID);
                        foreach (Nhom dm in List12)
                        {
                            ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , dm.Ten
                            , dm.ThuTu.ToString()
                            , string.Format(@"<input _id=""{2}"" type=""checkbox"" {0} onclick=""tinFn.saveNhom(this,'{1}');"" />",dm.Active ? @" checked=""checked""" : "",_ID,dm.ID)
                        }));
                        }
                        grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, List12.Count.ToString(), List12.Count.ToString(), ListRow);
                        sb.Append(JavaScriptConvert.SerializeObject(grid));
                    }
                    break;
                    #endregion
                case "getBinhLuanByTinId":
                    #region getBinhLuanByTinId: Lấy danh sách Bình luận theo tinId
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        BinhLuanCollection List12 = BinhLuanDal.SelectByTinId(_ID, null);
                        foreach (BinhLuan dm in List12)
                        {
                            ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , dm.Ten
                            , dm.NoiDung
                            , dm.NgayTao.ToString("hh:mm - dd/MM/yyyy")
                            , dm.Email
                            , string.Format(@"<input _id=""{2}"" type=""checkbox""  {0} onclick=""tinFn.saveBinhLuan(this,'{1}');"" />",dm.Active ? @" checked=""checked""" : "",_ID,dm.ID)
                            , string.Format(@"<a href=""javascript:;"" onclick=""tinFn.xoaBinhLuan(this,'{0}');"">xóa</a>",dm.ID)
                        }));
                        }
                        grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, List12.Count.ToString(), List12.Count.ToString(), ListRow);
                        sb.Append(JavaScriptConvert.SerializeObject(grid));
                    }
                    break;
                    #endregion
                case "saveTopic":
                    #region saveTopic: Lưu trạng thái Topic
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        bool active = Convert.ToBoolean(_Active);
                        if (active)
                        {
                            TopicTinDal.Insert(null,
                                Convert.ToInt32(_TpId)
                                ,Convert.ToInt32(_ID)
                                ,Convert.ToInt32(0)
                            );
                        }
                        else
                        {
                            TopicTinDal.DeleteByTpIdAndTid(_TpId, _ID);
                        }
                    }
                    break;
                    #endregion
                case "saveNhom":
                    #region saveNhom: Lưu trạng thái nhóm
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        bool active = Convert.ToBoolean(_Active);
                        if (active)
                        {
                            NhomTinDal.Insert(null, Convert.ToInt32(_Nid), Convert.ToInt32(_ID));
                        }
                        else
                        {
                            NhomTinDal.DeleteByNIdAndTid(_Nid, _ID);
                        }
                    }
                    break;
                    #endregion
                case "saveBinhLuan":
                    #region saveBinhLuan: Lưu trạng thái bình luận
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        bool active = Convert.ToBoolean(_Active);
                        BinhLuan item = BinhLuanDal.SelectById(Convert.ToInt32(_BlId));
                        item.Active = active;
                        BinhLuanDal.Update(item);
                    }
                    break;
                    #endregion
                case "xoaBinhLuan":
                    #region saveBinhLuan: Lưu trạng thái bình luận
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        BinhLuanDal.DeleteById(Convert.ToInt32(_BlId));
                    }
                    break;
                    #endregion
                case "getSapXeByTinId":
                    #region getSapXeByTinId: Sắp xếp theo tin id
                    sb.Append(@"<table cellpadding=""4"">
        <tr>
            <td class=""sapXep-header"">Nhóm</td>
            <td class=""sapXep-header"">Chủ đề
            </td>
            <td class=""sapXep-header"">Khác
            </td>
        </tr>
        <tr>");
                    if (!string.IsNullOrEmpty(_ID))
                    {

                        sb.Append(@"<td valign=""top""><div class=""topic"">");
                        foreach (Topic dm in TopicDal.SelectByTin(_ID))
                        {
                            sb.AppendFormat(@"<div class=""sapXep-item""><input _id=""{2}""  {0} type=""checkbox"" onclick=""tinFn.saveTopic(this,'{1}');"" />{3}</div>"
                                , dm.Active ? @" checked=""checked""" : ""
                                , _ID
                                , dm.ID
                                , dm.Ten);
                        }
                        sb.Append(@"</div></td>");
                        sb.Append(@"<td valign=""top""><div class=""nhom"">");
                        foreach (Nhom dm in NhomDal.SelectByTin(_ID))
                        {
                            sb.AppendFormat(@"<div class=""sapXep-item""><input _id=""{2}"" type=""checkbox"" {0} onclick=""tinFn.saveNhom(this,'{1}');"" />{3}</div>"
                                , dm.Active ? @" checked=""checked""" : ""
                                , _ID
                                , dm.ID
                                , dm.Ten);
                        }
                        sb.Append(@"</div></td>");
                        sb.Append(@"<td valign=""top""><div class=""khac"">");
                        Item = TinDal.SelectById(Convert.ToInt32(_ID));

                        sb.AppendFormat(@"<div class=""sapXep-item""><input _id=""{1}"" type=""checkbox"" {0} onclick=""tinFn.saveTinAttr(this,'{1}','NoiBatHome');"" />Nổi bật trang chủ</div>"
                                , Item.NoiBatHome ? @" checked=""checked""" : ""
                                , Item.ID);
                        sb.AppendFormat(@"<div class=""sapXep-item""><input _id=""{1}"" type=""checkbox"" {0} onclick=""tinFn.saveTinAttr(this,'{1}','NoiBatHome');"" />Nổi bật Danh mục</div>"
                                , Item.NoiBatDm ? @" checked=""checked""" : ""
                                , Item.ID);
                        sb.AppendFormat(@"<div class=""sapXep-item""><input _id=""{1}"" type=""checkbox"" {0} onclick=""tinFn.saveTinAttr(this,'{1}','NoiBatHome');"" />Đọc nhiều</div>"
                                , Item.DocNhieu ? @" checked=""checked""" : ""
                                , Item.ID);
                        sb.AppendFormat(@"<div class=""sapXep-item""><input _id=""{1}"" type=""checkbox"" {0} onclick=""tinFn.saveTinAttr(this,'{1}','NoiBatHome');"" />Hot</div>"
                                , Item.Hot ? @" checked=""checked""" : ""
                                , Item.ID);

                        sb.AppendFormat(@"<div class=""sapXep-item""><input _id=""{1}"" type=""checkbox"" {0} onclick=""tinFn.saveTinAttr(this,'{1}','NoiBatHome');"" />Hot 1</div>"
                                , Item.Hot1 ? @" checked=""checked""" : ""
                                , Item.ID);
                        sb.AppendFormat(@"<div class=""sapXep-item""><input _id=""{1}"" type=""checkbox"" {0} onclick=""tinFn.saveTinAttr(this,'{1}','NoiBatHome');"" />Hot 2</div>"
                                , Item.Hot2 ? @" checked=""checked""" : ""
                                , Item.ID);
                        sb.AppendFormat(@"<div class=""sapXep-item""><input _id=""{1}"" type=""checkbox"" {0} onclick=""tinFn.saveTinAttr(this,'{1}','NoiBatHome');"" />Hot 3</div>"
                                , Item.Hot3 ? @" checked=""checked""" : ""
                                , Item.ID);

                        sb.Append(@"</div></td>");

                        sb.Append(@"</tr></table>");
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.tin.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    //FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""tinMdl-addBtn"" href=""javascript:tinFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""tinMdl-editBtn"" href=""javascript:tinFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""tinMdl-delBtn"" href=""javascript:tinFn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#tinMdl-List').trigger('reloadGrid');"">Nạp</a>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByBao""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByDanhMuc""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByNhom""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByTopic""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByNgay""/>
    </span>
</div>
<table id=""tinMdl-List"" class=""mdl-list""></table>
<div id=""tinMdl-Pager""></div>
<div class=""sub-mdl-list"">
    <div  id=""tinMdl-subTinNhomMdl"" class=""sub-mdl-list-item"">
        <div class=""mdl-head"">
            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinNhomMdl"" />
            </span>            
        </div>
        <table id=""tinMdl-subTinNhomMdl-List"" class=""mdl-list""></table>
    </div>
    <div id=""tinMdl-subTinTopicMdl"" class=""sub-mdl-list-item"">
        <div class=""mdl-head"">
            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinTopicMdl"" />
            </span>            
        </div>
        <table id=""tinMdl-subTinTopicMdl-List"" class=""mdl-list""></table>
    </div>
    <div id=""tinMdl-subTinBinhLuanMdl"" class=""sub-mdl-list-item"">
        <div class=""mdl-head"">
            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinBinhLuanMdl"" />
            </span>            
        </div>
        <table id=""tinMdl-subTinBinhLuanMdl-List"" class=""mdl-list""></table>
    </div>
</div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.tin.JScript1.js")
                        , "{tinFn.loadgrid();}");
                    //sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
