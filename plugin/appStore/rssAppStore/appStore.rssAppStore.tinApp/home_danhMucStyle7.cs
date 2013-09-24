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
    public class home_danhMucStyle7 : PlugUI
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
            ModuleSetting Tab1Settings1 = new ModuleSetting();
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
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            bool login = Security.IsAuthenticated();

            NhomCollection ListNhom = NhomDal.SelectAll(con);
            int i = 0;
            foreach (Nhom item in ListNhom)
            {
                if (item.Active)
                {
                    sb1.AppendFormat(@"<a href=""javascript:;"" _rel=""tin-nhom-{0}"" class=""box-header-label box-header-label-item{2}"">{1}</a>", item.ID, item.Ten, i == 0 ? " box-header-label-item-active" : "");
                    i++;
                }
            }
            i = 0;
            sb.AppendFormat(@"
<div class=""box2"" style=""{0}"">
    <div class=""box-header"">
        {3}
    </div>
        <div class=""box-body"">", Css, Ten, Header_Url, sb1);

            List<NhomTin> List = new List<NhomTin>();
            #region tin noi bat
            foreach (Nhom item in ListNhom)
            {
                if (item.Active)
                {
                    sb.AppendFormat(@"<div class=""tin-nhom-box{1}""  _rel=""tin-nhom-{0}"">", item.ID, i == 0 ? " tin-nhom-box-active" : "");
                    List = NhomTinDal.SelectByNhomId(con, item.ID.ToString());
                    foreach (NhomTin item1 in List)
                    {
                        sb.Append(TinDal.formatDanhMucStyle7Tiny(item1._Tin, domain));
                    }
                    sb.AppendFormat(@"</div>");
                    i++;
                }
            }
            #endregion
            sb.AppendFormat(@"
        </div>
</div>");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }   
}
