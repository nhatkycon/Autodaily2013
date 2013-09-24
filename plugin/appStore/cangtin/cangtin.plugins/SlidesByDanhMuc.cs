using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;
using System.Web;
[assembly: WebResource("appStore.commonStore.tinControls.slides.min.jquery.js", "text/javascript", PerformSubstitution = true)]
namespace cangtin.plugins
{
    public class SlidesByDanhMuc : docPlugUI
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
            var c = HttpContext.Current;
            var dmMa = c.Request["DM_Ma"];

            #region header
            sb.AppendFormat(@"
<div class=""{0}"">
    <div class=""box-header"">
        <a href=""{2}"" class=""box-header-label"">{1}</a>
    </div>
        <div class=""box-body"">", Css, Ten, Header_Url);
            #endregion
            if (string.IsNullOrEmpty(Ma))
            {
                sb.Append("Vui lòng cấu hình <b>Mã</b>");
                Html = sb.ToString();
                return;
            }
            var list = DanhMucDal.SelectByLDMMa(con, Ma);

            sb.Append(@"
<div id=""container"">
    <div id=""slides"">
	    <div class=""slides_container"">");
            foreach (var item in list)
            {
                sb.AppendFormat(@"
<div class=""slide"">
    <a href=""{1}"" target=""_blank"">
    <img class=""tin-item-img"" src=""{0}/lib/up/i/{2}""></a>
    <div class=""caption""></div>
</div>", domain, string.Format(item.GiaTri, domain), Lib.imgSize(item.Anh, "full"));
            }
            sb.AppendFormat(
@"
	    </div>
        <a href=""#"" class=""prev""><img src=""{0}/lib/css/web/images-with-captions/img/arrow-prev.png"" width=""24"" height=""43"" alt=""Arrow Prev""></a>
		<a href=""#"" class=""next""><img src=""{0}/lib/css/web/images-with-captions/img/arrow-next.png"" width=""24"" height=""43"" alt=""Arrow Next""></a>
    </div>
</div>
<script src=""{0}/lib/css/web/images-with-captions/js/slides.min.jquery.js"" type=""text/javascript""></script>", domain);
            #region footer


            sb.Append(
                @"
<script>
    $(function () {
        $('#slides').slides({
            preload: false,
            play: 3000,
            pause: 3000,
            hoverPause: true,
            animationStart: function (current) {
                $('.caption').animate({
                    bottom: -35
                }, 100);
            },
            animationComplete: function (current) {
                $('.caption').animate({
                    bottom: 0
                }, 200);
            },
            slidesLoaded: function () {
                $('.caption').animate({
                    bottom: 0
                }, 200);
            }
        });
    });
</script>");

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
        public string ItemCss { get; set; }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Ma = GetSetting("Ma", SettingNode);
            Ten = GetSetting("Ten", SettingNode);
            Css = GetSetting("Css", SettingNode);
            Top = GetSetting("Top", SettingNode);
            ItemCss = GetSetting("ItemCss", SettingNode);
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

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "ItemCss";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = ItemCss;
            Tab1Settings1.Title = "Class của tin";
            this.Tabs[0].Settings.Add(Tab1Settings1);
        }
        public override void ImportPlugin()
        {
            if (Ma == null) Ma = "";
            if (Top == null) Top = "5";
            if (Ten == null) Ten = "Tên Module";
            if (Css == null) Css = "";
            if (Header_Url == null) Header_Url = "";
            base.ImportPlugin();
        }
    }

}
