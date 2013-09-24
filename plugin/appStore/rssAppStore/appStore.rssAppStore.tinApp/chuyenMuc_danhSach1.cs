using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using System.Data.SqlClient;
using linh.core.dal;
using docsoft;
using System.Web.UI;
using System.Web;
using linh.controls;
using linh.common;
using docbao.entitites;
namespace appStore.rssAppStore.tinApp
{
    public class chuyenMuc_danhSach1 : PlugUI
    {
        public string Ma { get; set; }
        public string Css { get; set; }
        public string Ten { get; set; }
        public string Top { get; set; }
        public string Header_Url { get; set; }

        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Ma = GetSetting("Ma", SettingNode);
            Ten = GetSetting("Ten", SettingNode);
            Css = GetSetting("Css", SettingNode);
            Top = GetSetting("Top", SettingNode);
            Header_Url = GetSetting("Header_Url", SettingNode);
            base.LoadSetting(SettingNode);
        }
        public override void AddTabs()
        {
            base.AddTabs();
            var Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Ma";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Ma;
            Tab1Settings1.Title = "Mã danh mục";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Ten";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Ten;
            Tab1Settings1.Title = "Tên";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Top";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Top;
            Tab1Settings1.Title = "Số lượng";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Css";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Css;
            Tab1Settings1.Title = "Css";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Header_Url";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Header_Url;
            Tab1Settings1.Title = "Url header";
            this.Tabs[0].Settings.Add(Tab1Settings1);
        }
        public override void ImportPlugin()
        {
            if (Ma == null) Ma = "12";
            if (Top == null) Top = "5";
            if (Ten == null) Ten = "Tên Module";
            if (Css == null) Css = "";
            if (Header_Url == null) Header_Url = "";
            base.ImportPlugin();
        }
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            var sb = new StringBuilder();
            var sb1 = new StringBuilder();
            var c = HttpContext.Current;
            var login = Security.IsAuthenticated();
            var _CM_Ten = c.Request["CM_Ten"];
            var _DM_Ten = c.Request["DM_Ten"];
            #region đường dẫn
            var Item = DanhMucDal.SelectByAlias(con,_CM_Ten);
            c.Session["Title"] = Item.Ten;
            sb1.Append(@"<ul class=""tin-view-navi"" id=""tin-view-navi-menus"">");
            sb1.AppendFormat(@"<li class=""page_item""><a href=""{0}"" class=""tin-view-navi-menus-item home"">Trang chủ</a></li>", domain);
            sb1.AppendFormat(@"<li class=""page_item""><a href=""{0}{1}/"" class=""tin-view-navi-menus-item"">{2}</a></li>", domain, Item.P_Alias, Item.P_Ten);
            sb1.AppendFormat(@"<li class=""page_item""><a href=""{0}{1}/{2}/"" class=""tin-view-navi-menus-item"">{3}</a></li>", domain, Item.P_Alias, Item.Alias, Item.Ten);
            sb1.AppendFormat(@"<li class=""page_item""><a href=""{0}rss/{1}/{2}.rss"" class=""tin-view-navi-menus-item""><span class=""box_head_task_rss""></span></a></li>", domain, Item.P_Alias, Item.Alias, Item.Ten);
            sb1.Append(@"</ul>");
            #endregion
            int i = 0;

            Pager<Tin> _pager = TinDal.pagerChuyenMuc(con, string.Format("{0}{1}/{2}/", domain, _DM_Ten, _CM_Ten) + "{1}/{0}", true, _CM_Ten);
            sb.AppendFormat(@"
<div class=""box5"" style=""{0}"">
    <div class=""box-header"">
        {3}
    </div>
        <div class=""box-body"">", Css, Ten, Header_Url, sb1);
            foreach (Tin item in _pager.List)
            {
                if (i == 0)
                {
                    sb.Append(TinDal.formatDanhMuc1Big(item, domain));
                }
                else
                {
                    sb.Append(TinDal.formatDanhMuc1Tiny(item, domain));
                }
                i++;
            }
            sb.Append(@"<div class=""PagerList"">");
            sb.Append(_pager.Paging);
            sb.AppendFormat(@"</div>");
            sb.AppendFormat(@"
        </div>
</div>");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }   
}
