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
[assembly: WebResource("appStore.pmSpa.desktop.controls.KHang.DangKy.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.pmSpa.desktop.controls.KHang
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
            var cs = page.ClientScript;

            var KhId = c.Request["KH_ID"];
            if (!string.IsNullOrEmpty(KhId))
            {
                var khItem = KhachHangDal.SelectById(new Guid(KhId));
                var sbHh = new StringBuilder();
                var sbAnh = new StringBuilder();
                var sbAnhFs = new StringBuilder();

                var sbSuKien = new StringBuilder();
                var sbTuVan = new StringBuilder();
                var sbAlbum = new StringBuilder();


                var itemFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.view.htm");
                var itemSk = Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.kh-sk-item.htm");
                var itemTv = Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.tv-item.htm");
                var itemAlbum = Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.item-album.htm");

                var suKienList = SuKienDal.SelectByKhId(con, null, "20", KhId);
                var tuVanList = TuVanDal.SelectByKhId(con, KhId);
                var albumList = AlbumDal.SelectByPid(con, KhId);
                foreach (var tv in tuVanList)
                {
                    sbTuVan.AppendFormat(itemTv
                        , tv.So
                        , tv.NgayTao.ToString("dd/MM/yyyy")
                        , tv.TuVanVien_Ten
                        , tv.TinhTrangSucKhoe
                        , tv.TinhTrangLanDa
                        , tv.ID
                        , domain);
                }

                foreach (var album in albumList)
                {
                    sbAlbum.AppendFormat(itemAlbum
                                         , album.ID
                                         , domain
                                         , Lib.imgSize(album.AnhDaiDien, "240x180")
                                         , album.Ten);
                }

                foreach (var sk in suKienList)
                {
                    sbSuKien.AppendFormat(itemSk
                        , sk.NgayBatDau.ToString("HH:mm dd/MM/yy")
                        , sk.Ten
                        , sk.MoTa
                        , sk.NhanVien_Ten
                        , sk.ID
                        , sk.KH_ID);
                }

                sb.AppendFormat(itemFormat
               , domain
               , khItem.Ten
               , khItem.Email
               , khItem.Ma
               , Lib.imgSize(khItem.Anh,"240x180")
               , khItem.Mobile
               , khItem.Phone
               , khItem.KhuVuc_Ten
               , khItem.DiaChi
               , khItem.Ym
               , khItem.NgaySinh.ToString("dd/MM/yy")
               , khItem.NguonGoc_Ten
               , khItem.ID
               , sbSuKien
               , sbTuVan
               , sbAlbum
               );
                sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.kh-sk-item-tmpl.htm"));
                sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.tv-item-tmpl.htm"));
                sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.item-album-tmpl.htm"));
                sb.AppendFormat(@"<script src=""{0}""></script>",
                                cs.GetWebResourceUrl(typeof (View), "appStore.pmSpa.desktop.controls.KHang.DangKy.js"));
                sb.Append(@"<script>
        $(function() {
            $.simpleTabs($('.tablet-content-tabs-box-container'), $('.tablet-content-tabs-box-item'), $('.tablet-content-tabs-header-item'));
        });
    </script>");
            }

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
