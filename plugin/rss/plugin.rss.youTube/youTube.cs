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
using linh.common; 
[assembly: WebResource("plugin.rss.youTube.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.rss.youTube.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.rss.youTube
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
            string _Ten = Request["Ten"];
            string _Url = Request["Url"];
            string _MoTa = Request["MoTa"];
            string _YID = Request["YID"];
            string _Views = Request["Views"];
            string _Diem = Request["Diem"];
            string _Active = Request["Active"];
            string _Home = Request["Home"];
            string _Hot = Request["Hot"];
            string _Hot1 = Request["Hot1"];
            string _Hot2 = Request["Hot2"];
            string _Hot3 = Request["Hot3"];
            string _Anh = Request["Anh"];
            Video Item;
            List<jgridRow> ListRow = new List<jgridRow>();
            jgrid grid = new jgrid();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "T_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    Pager<Video> PagerGet = VideoDal.pagerNormal("", false, jgrsidx + " " + jgrsord);

                    TopicCollection List = TopicDal.SelectAll();
                    foreach (Video dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , string.Format("<img src=\"../up/i/{0}\" />", dm.Anh)
                            , dm.Ten
                            , dm.Url
                            , dm.MoTa
                            , string.Format("{0}/{1}", dm.Views,dm.Diem)
                            , dm.Active.ToString()
                            , dm.Hot.ToString()
                            , dm.Hot1.ToString()
                            , dm.Hot2.ToString()
                            , dm.Hot3.ToString()
                            , dm.Home.ToString()
                        }));
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        VideoDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(VideoDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = VideoDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new Video();
                    }
                    //if (!string.IsNullOrEmpty(_DM_ID))
                    //{
                    //    Item.DM_ID = Convert.ToInt32(_DM_ID);
                    //}
                    if (!string.IsNullOrEmpty(_Diem))
                    {
                        Item.Diem = Convert.ToInt32(_Diem);
                    }
                    if (!string.IsNullOrEmpty(_Views))
                    {
                        Item.Views = Convert.ToInt32(_Views);
                    }
                    Item.YID = _YID;
                    Item.Url = _Url;
                    Item.Ten = _Ten;
                    Item.Active = Convert.ToBoolean(_Active);
                    Item.Anh = _Anh;
                    Item.Home = Convert.ToBoolean(_Home);
                    Item.Hot = Convert.ToBoolean(_Hot);
                    Item.Hot1 = Convert.ToBoolean(_Hot1);
                    Item.Hot2 = Convert.ToBoolean(_Hot2);
                    Item.Hot3 = Convert.ToBoolean(_Hot3);
                    Item.MoTa = _MoTa;                    
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = VideoDal.Update(Item);
                    }
                    else
                    {
                        Item = VideoDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "wrappUrl":
                    #region wrappUrl: Đọc url
                    if (!string.IsNullOrEmpty(_Url))
                    {
                        youTubeVideo vd = Lib.YouTubeCode(_Url);
                        string imgTen = Guid.NewGuid().ToString();
                        string imgLoc = Server.MapPath(@"~/lib/up/i/");
                        ImageProcess imgVd = new ImageProcess(new Uri(vd.Anh), imgTen);
                        imgVd.Save(imgLoc + imgTen + imgVd.Ext);
                        vd.Anh = imgTen + imgVd.Ext;
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(vd));
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.youTube.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-youTuBeMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""youTuBeMdl-addBtn"" href=""javascript:youTuBeFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""youTuBeMdl-editBtn"" href=""javascript:youTuBeFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""youTuBeMdl-delBtn"" href=""javascript:youTuBeFn.del();"">Xóa</a>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-kenhRssFilterByBao""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-kenhRssFilterByDanhMuc""/>
    </span>
</div>
<table id=""youTuBeMdl-List"" class=""mdl-list""></table>
<div id=""youTuBeMdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.youTube.JScript1.js")
                        , "{youTuBeFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
