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
[assembly: WebResource("plugin.rss.topic.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.rss.topic.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.rss.topic
{
    public class topic:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _DM_ID = Request["DM_ID"];
            string _Ten = Request["Ten"];
            string _ThuTu = Request["ThuTu"];
            string _MoTa = Request["MoTa"];
            string _Keywords = Request["Keywords"];
            string _Active = Request["Active"];
            string _Home = Request["Home"];
            string _Hot = Request["Hot"];
            string _Hot1 = Request["Hot1"];
            string _Hot2 = Request["Hot2"];
            string _Anh = Request["Anh"];
            Topic Item;
            List<jgridRow> ListRow = new List<jgridRow>();
            jgrid grid = new jgrid();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    TopicCollection List = TopicDal.SelectAll();
                    foreach (Topic dm in List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , string.Format("<img class=\"adm-fn-icon\" src=\"../lib/up/{0}\" />", string.IsNullOrEmpty(dm.Anh) ? "fn-icon.jpg" :dm.Anh)
                            , dm.Ten
                            , dm.ThuTu.ToString()
                            , dm.MoTa
                            , dm.Keywords
                            , dm.Active.ToString()
                            , dm.Hot.ToString()
                            , dm.Hot1.ToString()
                            , dm.Hot2.ToString()
                            , dm.Home.ToString()
                        }));
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, List.Count.ToString(), List.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        TopicDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(TopicDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = TopicDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new Topic();
                    }
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    if (!string.IsNullOrEmpty(_ThuTu))
                    {
                        Item.ThuTu = Convert.ToInt32(_ThuTu);
                    }
                    Item.Ten = _Ten;
                    Item.Active = Convert.ToBoolean(_Active);
                    Item.Anh = _Anh;
                    Item.Home = Convert.ToBoolean(_Home);
                    Item.Hot = Convert.ToBoolean(_Hot);
                    Item.Hot1 = Convert.ToBoolean(_Hot1);
                    Item.Hot2 = Convert.ToBoolean(_Hot2);
                    Item.Keywords = _Keywords;
                    Item.MoTa = _MoTa;                    
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = TopicDal.Update(Item);
                    }
                    else
                    {
                        Item = TopicDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getautoComplete":
                    #region Lấy danh sách danh mục
                    sb.Append(JavaScriptConvert.SerializeObject(TopicDal.SelectAll()));
                    break;
                    #endregion
                case "addSubTin":
                    #region addSubTin: Thêm tin vào topic
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        TopicTinDal.Insert(new TopicTin(null
                            , Convert.ToInt32(_ID)
                            , Convert.ToInt32(Request["T_ID"])
                            , Convert.ToInt32(0)
                            ));
                    }
                    break;
                    #endregion
                case "delSubTin":
                    #region delSubTin:Xóa bỏ tin
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        TopicTinDal.DeleteTinListByTpId(_ID, Request["IDs"]);
                    }
                    break;
                    #endregion
                case "scpt":
                      #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(topic), "plugin.rss.topic.JScript1.js"));
                    break;
                    #endregion
                   
                case "getSubTin":
                    #region getSubTin: Lấy tin theo topic
                    TopicTinCollection List1 = TopicTinDal.SelectByTopicId(_ID);
                    foreach (TopicTin dm in List1)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , string.Format("<img  src=\"http://tintuc.me/lib/up/{0}\" />", linh.common.Lib.imgSize(dm._Tin.Anh,"100x100"))
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
                default:
                    #region nạp
                    FunctionCollection ListFns = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
            <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-topicMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""topicMdl-addBtn"" href=""javascript:topicFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""topicMdl-editBtn"" href=""javascript:topicFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""topicMdl-delBtn"" href=""javascript:topicFn.del();"">Xóa</a>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
         <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
            <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-kenhRssFilterByBao""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
         <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-kenhRssFilterByDanhMuc""/>
    </span>
</div>
<table id=""topicMdl-List"" class=""mdl-list""></table>
<div id=""topicMdl-Pager""></div>

<div class=""sub-mdl"">
<ul>
    <li><a id=""topicMdl-subTinMdl-Btn"" href=""#topicMdl-subTinMdl-Box"">Tin</a></li>
</ul>
<div>    
    <div class=""mdl-submdl-panel"" id=""topicMdl-subTinMdl-Box"">
            <div class=""mdl-head"">
                    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-subTinMdl-topicMdl"" />
                    </span>
                    <a class=""mdl-head-btn mdl-head-del"" id=""topicMdl-subTinMdl-delBtn"" href=""javascript:topicFn.delSubTin();"">Xóa</a>
                    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-topicSearchTin""/>
                    </span>
                    <a class=""mdl-head-btn mdl-head-del"" id=""topicMdl-subTinMdl-addBtn"" _id="""" href=""javascript:;"">Thêm</a>
            </div>
            <table id=""topicMdl-subTinMdl-List"" class=""mdl-list""></table>
            <div  id=""topicMdl-subTinMdl-Pager""></div>
    </div>
</div>
</div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                      , cs.GetWebResourceUrl(typeof(topic), "plugin.rss.topic.JScript1.js")
                      , "{topicFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFns));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);

            //        sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
            //            , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.topic.JScript1.js")
            //            , "{topicFn.loadgrid();}");
            //        sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
            //        break;
            //        #endregion
            //}
            //writer.Write(sb.ToString());
            //base.Render(writer);
        }
    }
}
