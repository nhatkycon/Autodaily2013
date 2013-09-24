using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.frm;
using linh.controls;
using linh.common;
using pmSpa.entities;
using System.Globalization;
using System.Reflection;
namespace appStore.pmSpa.desktop.controls.DichVu
{
    public class View : docPlugUI
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

            var Id = c.Request["VID"];

            var dv = DichVuDal.SelectById(new Guid(Id));

            var listSub = DichVuChiTietDal.SelectByDvId(Id).ToList().OrderBy(p => p.ThuTu);

            var sbHh = new StringBuilder();
            var sbAnh = new StringBuilder();
            var sbAnhFs = new StringBuilder();
            
            var itemFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "DichVu.view.htm");
            var anhFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "DichVu.anh-dich-vu.htm");
            var anhFsFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "DichVu.anh-dich-vu-full.htm");
            var dichVuChiTietFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "DichVu.dich-vu-chi-tiet.htm");

            var albumList = AlbumDal.SelectByPid(con, dv.ID.ToString());
            var slideIndex = 0;
            int count = 0;
            foreach (var hh in listSub)
            {
                count++;
                sbHh.AppendFormat(dichVuChiTietFormat, hh.HH_Ten, hh.SoLuong);
            }
            foreach (var album in albumList)
            {
                foreach (var anh in FilesDal.SelectByPRowId(album.ID))
                {
                    sbAnh.AppendFormat(anhFormat, slideIndex, domain, Lib.imgSize(anh.Path, "400x400"), anh.ThuMuc);
                    sbAnhFs.AppendFormat(anhFsFormat, slideIndex == 0 ? "block" : "none", domain, Lib.imgSize(anh.Path, "full"), anh.ThuMuc);
                    slideIndex++;
                }
            }

            sb.AppendFormat(itemFormat
           , domain
           , dv.Ten
           , string.Format(new CultureInfo("vi-Vn"), "{0:c}", dv.Gia).Replace(",00 ₫", "")
           , dv.Ma
           , Lib.imgSize(dv.Anh, "240x180")
           , dv.MoTa
           , dv.ThoiGian
           , dv.SoLan
           , dv.NoiDung
           , dv.GhiChu
           , dv.ThaoTac
           , sbHh
           , sbAnh
           , sbAnhFs
           );
            sb.Append(@"<script>
        
    $(function() {
        $.simpleTabs($('.tablet-content-tabs-box-container'), $('.tablet-content-tabs-box-item'), $('.tablet-content-tabs-header-item'));
        $('.anh-item').each(function (i) {
            var item = $(this);
            item.click(function() {
                $('.dv-fs-box').show();
                $('.dv-fs-closeBtn').unbind('click').click(function() {
                    $('.dv-fs-box').hide();
                });
                if(!dichVuDsSlidesInitial) {
                    dichVuFsSlide = new Swipe(document.getElementById('dv-fs-body'));
                    dichVuDsSlidesInitial = true;
                }
            });
        });
    });
</script>");

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
