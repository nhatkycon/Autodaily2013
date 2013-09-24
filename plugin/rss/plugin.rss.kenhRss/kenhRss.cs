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
[assembly: WebResource("plugin.rss.kenhRss.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.rss.kenhRss.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.rss.kenhRss
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _B_ID = Request["B_ID"];
            string _DM_ID = Request["DM_ID"];
            string _RssUrl = Request["RssUrl"];
            Channel ItemSave;
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    List<jgridRow> ListRow = new List<jgridRow>();
                    ChannelCollection List = ChannelDal.SelectByDmIdByBid(_DM_ID, _B_ID);
                    foreach (Channel dm in List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , dm.B_Ten
                            , dm.DM_Ten
                            , dm.RssUrl
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
                        ChannelDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(ChannelDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = ChannelDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        ItemSave = new Channel();
                    }
                    if (!string.IsNullOrEmpty(_B_ID))
                    {
                        ItemSave.B_ID = Convert.ToInt32(_B_ID);
                    }
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        ItemSave.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    ItemSave.RssUrl = _RssUrl;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = ChannelDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave = ChannelDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getautoComplete":
                    #region Lấy danh sách danh mục
                    sb.Append(JavaScriptConvert.SerializeObject(docbao.entitites.DanhMucDal.SelectAll()));
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
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.kenhRss.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-kenhRssMdl"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""kenhRssMdl-addBtn"" href=""javascript:kenhRssFn.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""kenhRssMdl-editBtn"" href=""javascript:kenhRssFn.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""kenhRssMdl-delBtn"" href=""javascript:kenhRssFn.del();"">Xóa</a>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-kenhRssFilterByBao""/>
</span>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-kenhRssFilterByDanhMuc""/>
</span>
</div>
<table id=""kenhRssMdl-List"" class=""mdl-list""></table>
<div id=""kenhRssMdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.kenhRss.JScript1.js")
                        , "{kenhRssFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
