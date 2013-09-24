using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;
[assembly: WebResource("appStore.commonStore.tinControls.slides.min.jquery.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.tinControls
{
    public class ChiTiet : docPlugUI
    {
        

        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }

        public override void KhoiTao(SqlConnection con, Page page)
        {
            var sb = new StringBuilder();

            var c = HttpContext.Current;
            var Id = c.Request["TIN-ID"];
            #region header
            sb.AppendFormat(@"
<div class=""{0}"">
    <div class=""box-header"">
        <a href=""{2}"" class=""box-header-label"">{1}</a>
    </div>
        <div class=""box-body"">", Css, Ten, Header_Url);
            #endregion

            var item = TinDal.SelectById(Id);
            Seo(page, item.MoTa, item.MoTa, item.Ten);
            sb.AppendFormat(@"
<div class=""tin-view-item"">
    <div class=""tin-item-ten"">
        {0}
    </div>
     <div class=""tin-item-ngayTao"">
        {3:HH:mm:ss - dd/MM/yyyy}
    </div>
    <div class=""tin-item-moTa"">
        {1}
    </div>
    <div class=""tin-item-NoiDung"">
        {2}
    </div>
    <div class=""tin-item-tacGia"">
        {4}
    </div>
    <p>
		<div class=""fb-like"" data-href='{6}{5}' data-layout=""button_count"" data-send=""true"" data-show-faces=""false"" data-width=""850"">
			&nbsp;</div>
    </p>
</div>", item.Ten,item.MoTa,item.NoiDung,item.NgayTao, item.TacGia, c.Request.RawUrl, domain);

            #region footer
            sb.AppendFormat(@"
        </div>
</div>");
            #endregion
            Html = sb.ToString();
            base.KhoiTao(con);
        }

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
            Tab1Settings1.Title = "Url";
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
    }

}
