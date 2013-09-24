using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using System.Data.SqlClient;

namespace appStore.authorityStore.content.html
{
    #region Footer
    public class Footer : PlugUI
    {
        public string Htmls { get; set; }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Htmls = GetSetting("Htmls", SettingNode);
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

        }
        public override void ImportPlugin()
        {
            base.ImportPlugin();
        }
        public override void KhoiTao(SqlConnection con)
        {
            Html = string.IsNullOrEmpty(Htmls) ? "nội dung html" : Htmls;
            base.KhoiTao(con);
        }
    }
    #endregion
}
