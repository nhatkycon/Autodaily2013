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
[assembly: WebResource("plugin.rss.nhom.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.rss.nhom.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.rss.nhom
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
            string _DM_ID = Request["DM_ID"];
            string _ThuTu = Request["ThuTu"];
            string _Active = Request["Active"];
            string _Hot = Request["Hot"];
            string _Hot1 = Request["Hot1"];
            string _Hot2 = Request["Hot2"];
            string _Hot3 = Request["Hot3"];
            Nhom ItemSave;
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "BAO_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    List<Nhom> List = NhomDal.SelectAll();
                    ListRow = new List<jgridRow>();
                    foreach (Nhom dm in List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                              dm.ID.ToString()     
                            , dm._DanhMuc.Ten
                            , dm.Ten
                            , dm.ThuTu.ToString()
                            , dm.Active.ToString()
                            , dm.Hot.ToString()
                            , dm.Hot1.ToString()
                            , dm.Hot2.ToString()
                            , dm.Hot3.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, List.Count.ToString(), List.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        NhomDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(NhomDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    ItemSave = new Nhom();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = NhomDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        ItemSave = new Nhom();
                    }
                    ItemSave.Ten = _Ten;
                    ItemSave.ThuTu = Convert.ToInt32(_ThuTu);
                    ItemSave.Active = Convert.ToBoolean(_Active);
                    ItemSave.Hot = Convert.ToBoolean(_Hot);
                    ItemSave.Hot1 = Convert.ToBoolean(_Hot1);
                    ItemSave.Hot2 = Convert.ToBoolean(_Hot2);
                    ItemSave.Hot3 = Convert.ToBoolean(_Hot3);
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        ItemSave.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = NhomDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave = NhomDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getautoComplete":
                    #region Lấy danh sách danh mục
                    sb.Append(JavaScriptConvert.SerializeObject(NhomDal.SelectAll()));
                    break;
                    #endregion
                case "getSubTin":
                    #region getSubTin: Lấy tin theo topic
                    NhomTinCollection List1 = NhomTinDal.SelectByNhomId(_ID);
                    foreach (NhomTin dm in List1)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , string.Format("<img src=\"http://tintuc.me/lib/up/{0}\" />", linh.common.Lib.imgSize(dm._Tin.Anh,"100x100"))
                            , dm._Tin.Ten
                            , dm._Tin.MoTa
                            , dm._Tin.Url
                            , dm._Tin.NgayTao.ToString("hh:mm - dd/MM/yyyy")
                        }));
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, List1.Count.ToString(), List1.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "addSubTin":
                    #region addSubTin: Thêm tin vào topic
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        NhomTinDal.Insert(new NhomTin(null
                            , Convert.ToInt32(_ID)
                            , Convert.ToInt32(Request["N_ID"])                            
                            ));
                    }
                    break;
                    #endregion
                case "delSubTin":
                    #region delSubTin:Xóa bỏ tin
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        NhomTinDal.DeleteTinListByNid(_ID, Request["IDs"]);
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.nhom.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-nhomMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""nhomMdl-addBtn"" href=""javascript:nhomFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""nhomMdl-editBtn"" href=""javascript:nhomFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""nhomMdl-delBtn"" href=""javascript:nhomFn.del();"">Xóa</a>
</div>
<table id=""nhomMdl-List"" class=""mdl-list""></table>
<div id=""nhomMdl-Pager""></div>

<div class=""sub-mdl"">
<ul>
    <li><a id=""nhomMdl-subTinMdl-Btn"" href=""#nhomMdl-subTinMdl-Box"">Tin</a></li>
</ul>
<div>    
    <div class=""mdl-submdl-panel"" id=""nhomMdl-subTinMdl-Box"">
        <div class=""mdl-head"">
            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
            <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-subTinMdl-nhomMdl"" />
            </span>
            <a class=""mdl-head-btn mdl-head-del"" id=""nhomMdl-subTinMdl-delBtn"" href=""javascript:nhomFn.delSubTin();"">Xóa</a>
            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-nhomMdlSearchTin""/>
            </span>
            <a class=""mdl-head-btn mdl-head-del"" id=""nhomMdl-subTinMdl-addBtn"" _id="""" href=""javascript:;"">Thêm</a>
        </div>
        <table id=""nhomMdl-subTinMdl-List"" class=""mdl-list""></table>
        <div  id=""nhomMdl-subTinMdl-Pager""></div>
    </div>
</div>
</div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.nhom.JScript1.js")
                        , "{nhomFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
