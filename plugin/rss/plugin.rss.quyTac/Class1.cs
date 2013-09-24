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
[assembly: WebResource("plugin.rss.quyTac.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.rss.quyTac.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.rss.quyTac
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["_ID"];
            string _Loai = Request["_Loai"];
            string _Host = Request["_Host"];
            string _ThuTu = Request["_ThuTu"];
            string _Xoa = Request["_Xoa"];
            string _Xpath = Request["_Xpath"];
            QuyTac ItemSave;
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    List<jgridRow> ListRow = new List<jgridRow>();
                    QuyTacCollection List = QuyTacDal.SelectByHost(_Host);
                    foreach (QuyTac item in List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             string.Format("{0}",item.ID)
                             ,item.Host
                            , item.Loai.ToString()
                            ,item.Xpath
                            ,item.ThuTu.ToString()
                            ,item.Xoa.ToString()
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
                        QuyTacDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(QuyTacDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = QuyTacDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        ItemSave = new QuyTac();
                    }
                    ItemSave.Host = _Host;
                    ItemSave.Loai = Convert.ToInt32(_Loai);
                    ItemSave.ThuTu = Convert.ToInt32(_ThuTu);
                    ItemSave.Xoa = Convert.ToBoolean(_Xoa);
                    ItemSave.Xpath = _Xpath;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = QuyTacDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave = QuyTacDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getautoComplete":
                    #region Lấy danh sách danh mục
                    sb.Append(JavaScriptConvert.SerializeObject(QuyTacDal.SelectAll()));
                    break;
                    #endregion                
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.quyTac.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-quyTacMdl"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""quyTacMdl-addBtn"" href=""javascript:quyTacFn.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""quyTacMdl-editBtn"" href=""javascript:quyTacFn.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""quyTacMdl-delBtn"" href=""javascript:quyTacFn.del();"">Xóa</a>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-kenhRssFilterByBao""/>
</span>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-kenhRssFilterByDanhMuc""/>
</span>
</div>
<table id=""quyTacMdl-List"" class=""mdl-list""></table>
<div id=""quyTacMdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.quyTac.JScript1.js")
                        , "{quyTacFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
