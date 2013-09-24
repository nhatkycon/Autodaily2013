using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh.json;
using docsoft;
using docsoft.entities;
using linh.controls;

[assembly: WebResource("mamvui.plugin.datHang.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("mamvui.plugin.datHang.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace mamvui.plugin.datHang
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _Ten = Request["Ten"];
            string _Ma = Request["Ma"];
            string _KyHieu = Request["KyHieu"];
            string _ThuTu = Request["ThuTu"];
            string _q = Request["q"];
            string _Active = Request["Active"];
            var ListRow = new List<jgridRow>();
            Language Item;
            var grid = new jgrid();

            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<DatHang> PagerGet = DatHangDal.pagerNormal("", false, "DH_" + jgrsidx + " " + jgrsord,"", Convert.ToInt32(Request["rows"]));
                    foreach (DatHang item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(),
                            new string[] { item.ID.ToString()
                                , item.KH_Ten
                                , item.KH_Mobile
                                , item.KH_DiaChi
                                ,string.Format("{0}.000đ",item.Tong)
                                ,string.Format("{0:dd-MM-yy HH:mm}",item.NgayTao)
                                ,string.Format(@"<input type=""checkbox"" _id=""{0}"" {1}/>",item.ID,item.GiaoHang ? @" checked=""checked""" : "")
                            }));
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getSubGrid":
                #region getSubGrid

                    ListRow.AddRange(DatHangChiTietDal.SelectByDhId(_ID).Select(item => new jgridRow(item.ID.ToString(), new string[]
                                                                                                                             {
                                                                                                                                 item.ID.ToString(), item.HH_Ten, string.Format("{0}.000đ", item.HH_Gia), item.HH_SoLuong.ToString(), string.Format("{0}.000đ", item.HH_Gia*item.HH_SoLuong)
                                                                                                                             })));
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "100", "100", ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                #endregion
                case "save":
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = LanguageDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new Language();
                    }
                    Item.Ten = _Ten;
                    Item.Ma = _Ma;
                    Item.ThuTu = Int32.Parse(_ThuTu);
                    Item.Active = Convert.ToBoolean(_Active);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = LanguageDal.Update(Item);
                    }
                    else
                    {
                        Item = LanguageDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(LanguageDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "getActive":
                    #region chỉnh sửa
                    sb.Append(JavaScriptConvert.SerializeObject(LanguageDal.SelectAll()));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DatHangDal.DeleteById(new Guid(_ID));
                    }
                    break;
                    #endregion
                case "AutoComplete":
                    #region xóa
                    JavaScriptConvert.SerializeObject(LanguageDal.SelectAll());
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "mamvui.plugin.datHang.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-languageFn"" />
</span>
<a  _resource=""admin.system.label.del"" class=""mdl-head-btn mdl-head-del"" id=""datHangMdl-delBtn"" href=""javascript:datHangFn.del();"">Xóa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""giaoViecMdl-delBtn"" href=""javascript:datHangFn.nap();"">Nạp lại</a>
</div>

<table id=""datHangMdl-List"" class=""mdl-list""></table>
<div id=""datHangMdl-Pager""></div>
<div class=""sub-mdl"">
    <div class=""mdl-head"">
    </div>
    <table id=""datHangChiTietMdl-List"" class=""mdl-list""></table>
</div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "mamvui.plugin.datHang.JScript1.js")
                        , "{datHangFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn)); 
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
