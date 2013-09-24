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
using spa.entitites;
[assembly: WebResource("plugin.spa.SpaHoiDapMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.spa.SpaHoiDapMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.spa.SpaHoiDapMgr
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["_ID"];
            string _DM_ID = Request["_DM_ID"];
            string _HD_ID = Request["_HD_ID"];
            string _DoTuoi_ID = Request["_DoTuoi_ID"];
            string _Ten = Request["_Ten"];
            string _NguoiTao = Request["_NguoiTao"];
            string _Email = Request["_Email"];
            string _Mobile = Request["_Mobile"];
            string _NoiDung = Request["_NoiDung"];
            string _Active = Request["_Active"];
            string _DaTraLoi = Request["_DaTraLoi"];
            string _Hot = Request["_Hot"];
            string _q = Request["_q"];
            SpaHoiDap Item;
            List<jgridRow> ListRow = new List<jgridRow>();
            Pager<SpaHoiDap> PagerGet;
            #endregion            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "HD_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    PagerGet = SpaHoiDapDal.pagerByDichVu(jgrsidx + " " + jgrsord, _q, _DM_ID, 10);
                    foreach (SpaHoiDap item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             string.Format("{0}",item.ID)
                             , item.Ten
                            , item.NguoiTao
                            , item.Email
                            , item.Mobile
                            , item.HD_Ten
                            ,item.Active.ToString()
                            ,item.DaTraLoi.ToString()
                            ,item.Hot.ToString()
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
                        SpaHoiDapDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(SpaHoiDapDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaHoiDapDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new SpaHoiDap();
                    }
                    Item.Ten = _Ten;
                    Item.NguoiTao = _NguoiTao;
                    Item.Email = _Email;
                    Item.Mobile = _Mobile;
                    Item.NoiDung = _NoiDung;
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = new Guid(_DM_ID);
                    }
                    if (!string.IsNullOrEmpty(_DoTuoi_ID))
                    {
                        Item.DoTuoi_ID = new Guid(_DoTuoi_ID);
                    }
                    if (!string.IsNullOrEmpty(_HD_ID))
                    {
                        Item.HD_ID = Convert.ToInt32(_HD_ID);
                    }
                    Item.Active = Convert.ToBoolean(_Active);
                    Item.DaTraLoi = Convert.ToBoolean(_DaTraLoi);
                    Item.Hot = Convert.ToBoolean(_Hot);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaHoiDapDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item = SpaHoiDapDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "autocomplete":
                    #region Lấy danh sách autocomplete
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "HD_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    PagerGet = SpaHoiDapDal.pagerByDichVu(jgrsidx + " " + jgrsord, _q, _DM_ID, 10);
                    sb.Append(JavaScriptConvert.SerializeObject(PagerGet.List));
                    break;
                    #endregion
                case "autoCompleteCauHoi":
                    #region Lấy danh sách autocompleteCauHoi
                    PagerGet = SpaHoiDapDal.pagerCauHoi(_q, 10);
                    sb.Append(JavaScriptConvert.SerializeObject(PagerGet.List));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaHoiDapMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-spaHoiDapMgrMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""spaHoiDapMgrMdl-addBtn"" href=""javascript:spaHoiDapMgrFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""spaHoiDapMgrMdl-editBtn"" href=""javascript:spaHoiDapMgrFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""spaHoiDapMgrMdl-delBtn"" href=""javascript:spaHoiDapMgrFn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#spaHoiDapMgrMdl-List').trigger('reloadGrid');"">Nạp</a>    
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-spaHoiDapMgrMdlFilterByDm""/>
    </span>
</div>
<table id=""spaHoiDapMgrMdl-List"" class=""mdl-list""></table>
<div id=""spaHoiDapMgrMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaHoiDapMgr.JScript1.js")
                        , "{spaHoiDapMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
