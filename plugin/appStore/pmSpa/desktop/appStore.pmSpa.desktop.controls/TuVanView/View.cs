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
[assembly: WebResource("appStore.pmSpa.desktop.controls.TuVanView.TuVan.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.TuVanView.html.htm", "text/html", PerformSubstitution = true)]
namespace appStore.pmSpa.desktop.controls.TuVanView
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

            var KhId = c.Request["TV_ID"];
            if (!string.IsNullOrEmpty(KhId))
            {
                var khItem = TuVanDal.SelectById(con, new Guid(KhId));
                var sbHh = new StringBuilder();
                var sbAnh = new StringBuilder();
                var sbAnhFs = new StringBuilder();

                var sbDichVu = new StringBuilder();
                var sbLamDichVu = new StringBuilder();
                var sbTinhTrang = new StringBuilder();
                var sbMuaKem = new StringBuilder();

                var itemFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "TuVanView.view.htm");
                var itemDvFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "TuVanView.dv-item.htm");
                var itemLdvFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "TuVanView.lamDichVu-item.htm");
                var itemTTFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "TuVanView.tinhTrang-item.htm");
                var itemMuaKemFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "TuVanView.muakem-item.htm");


                var listMuaKem = XuatNhapChiTietDal.SelectByTV_ID(KhId);

                foreach (var mk in listMuaKem)
                {
                    sbMuaKem.AppendFormat(itemMuaKemFormat
                                          , mk.HH_ID
                                          , mk.HH_Ten
                                          , mk.SoLuong);
                }
                foreach (var tt in TuVanTinhTrangDal.SelectByTvId(KhId))
                {
                    sbTinhTrang.AppendFormat(itemTTFormat
                                                 , tt.ID
                                                 , domain
                                                 , tt._DanhMuc.Ten);
                }

                foreach (var dv in TuVanDichVuDal.SelectByTvId(con, KhId))
                {
                    sbLamDichVu=new StringBuilder();
                    foreach (var ldv in TuVanLamDichVuDal.SelectByTvDvId(con, dv.ID.ToString()))
                    {
                        sbLamDichVu.AppendFormat(itemLdvFormat
                                                 , ldv.ID
                                                 , ldv.ThuTu
                                                 , ldv.NhanVien_Ten
                                                 , ldv.NgayLam.ToString("dd/MM/yy")
                                                 , ldv.TVDV_ID);
                    }
                    sbDichVu.AppendFormat(itemDvFormat
                                          , dv.ID
                                          , dv._DichVu.Ten
                                          , Lib.TienVietNam(dv.Gia)
                                          , dv.SoLan
                                          , dv.NgayLap.ToString("dd/MM/yy")
                                          , dv.BaoHanh_Ten
                                          , dv.GhiChu
                                          , sbLamDichVu
                                          );
                }

                sb.AppendFormat(itemFormat
               , domain
               , khItem.KH_ID
               , khItem.TuVanVien_Ten
               , khItem.NgayTao.ToString("dd/MM/yyyy")
               , khItem.TinhTrangSucKhoe
               , khItem.TinhTrangLanDa
               , khItem.GhiChu
               , khItem.YKienKhachHang
               , sbDichVu
               , sbMuaKem
               , KhId
               , sbTinhTrang
               );
                sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "TuVanView.dv-item-tmpl.htm"));
                sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "TuVanView.dv-item-tmpl-edit.htm"));
                sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "TuVanView.lamDichVu-item-tmpl.htm"));
                //sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.tv-item-tmpl.htm"));


                sb.AppendFormat(@"<script src=""{0}""></script>",
                                cs.GetWebResourceUrl(typeof(View), "appStore.pmSpa.desktop.controls.TuVanView.TuVan.js"));
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
