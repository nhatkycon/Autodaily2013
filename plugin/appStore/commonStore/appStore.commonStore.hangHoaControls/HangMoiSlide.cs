using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;

namespace appStore.commonStore.hangHoaControls
{
    public class HangMoiSlide : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            var sb = new StringBuilder();
            var mainStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "HangMoiSlide.htm");
            var itemStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "HangMoiSlide_item.htm");
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            var sb3 = new StringBuilder();
            var list1 = HangHoaDal.SelectTopHot(con, Top);

            foreach (var item in list1)
            {
                if(item.Hot1)
                {
                    sb1.AppendFormat(itemStr, Lib.Bodau(item.DM_Ten), item.Ten, item.ID, Lib.imgSize(item.Anh, "326"), item.Ten);
                }
            }
            foreach (var item in list1)
            {
                if (item.Hot2)
                {
                    sb2.AppendFormat(itemStr, Lib.Bodau(item.DM_Ten), item.Ten, item.ID, Lib.imgSize(item.Anh, "326"), item.Ten);
                }
            }
            foreach (var item in list1)
            {
                if (item.Hot3)
                {
                    sb3.AppendFormat(itemStr, Lib.Bodau(item.DM_Ten), item.Ten, item.ID, Lib.imgSize(item.Anh, "326"), item.Ten);
                }
            }
            sb.AppendFormat(mainStr, sb1, sb2, sb3);
            Html = sb.ToString();
            base.KhoiTao(con);
        }
        

        public string Ma { get; set; }
        public string Css { get; set; }
        public string ItemCss { get; set; }
        public string Top { get; set; }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Ma = GetSetting("Ma", SettingNode);
            Css = GetSetting("Css", SettingNode);
            Top = GetSetting("Top", SettingNode);
            ItemCss = GetSetting("ItemCss", SettingNode);
            base.LoadSetting(SettingNode);
        }
        public override void AddTabs()
        {
            base.AddTabs();
            ModuleSetting Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Ma";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Ma;
            Tab1Settings1.Title = "Mã danh mục";
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
            Tab1Settings1.Key = "ItemCss";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = ItemCss;
            Tab1Settings1.Title = "Class của hàng hóa";
            this.Tabs[0].Settings.Add(Tab1Settings1);
        }
        public override void ImportPlugin()
        {
            if (Ma == null) Ma = "";
            if (Top == null) Top = "5";
            if (Css == null) Css = "";
            base.ImportPlugin();
        }
    }
}
