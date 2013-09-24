using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using System.Data.SqlClient;
using linh.core.dal;
using docsoft;
using docsoft.entities;
using System.Web.UI;
using System.Web;
using linh.controls;
using linh.common;

namespace appStore.rssAppStore.commonApp
{
    #region HtmlBoxHome
    public class HtmlBoxHome : PlugUI
    {
        public string Htmls { get; set; }
        public string Css { get; set; }
        public string Ten { get; set; }
        public string Header_Url { get; set; }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Htmls = GetSetting("Htmls", SettingNode);
            Css = GetSetting("Css", SettingNode);
            Ten = GetSetting("Ten", SettingNode);
            Header_Url = GetSetting("Header_Url", SettingNode);
            base.LoadSetting(SettingNode);
        }
        public override void AddTabs()
        {
            base.AddTabs();
            ModuleSetting Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Htmls";
            Tab1Settings1.Type = "html";
            Tab1Settings1.Value = Htmls;
            Tab1Settings1.Title = "Html";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Css";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Css;
            Tab1Settings1.Title = "Css";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Ten";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Ten;
            Tab1Settings1.Title = "Tên";
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
            base.ImportPlugin();
        }
        public override void KhoiTao(SqlConnection con)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
<div class=""box2"" style=""{0}"">{1} 
        <div class=""box-body"">", Css
                                 , string.IsNullOrEmpty(Ten) ? "" : string.Format(@"<div class=""box-header""><a href=""{1}"" class=""box-header-label"">{0}</a></div>", Ten, Header_Url));
            sb.Append(string.IsNullOrEmpty(Htmls) ? "nội dung html" : Htmls);
            sb.AppendFormat(@"
        </div>
</div>");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }
    #endregion
}
