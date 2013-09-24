using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;
using docsoft;

namespace cangtin.plugins.suKienMgr.HienThi
{
    public class ChiTiet : PlugUI
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
            var dmMa = c.Request["DM_Ma"];
            var item = SuKienDal.SelectById(new Guid(dmMa));
            #region header
            sb.AppendFormat(@"
<div class=""{0}"">
    <div class=""box-header"">
        <a href=""{2}"" class=""box-header-label"">{1}</a>
    </div>
        <div class=""box-body"">", Css, Ten, Header_Url);
            #endregion

            var thanhVienThamGia = MemberDal.SelectBySuKien(con, dmMa, true, 1000);
            var daThamGia = !string.IsNullOrEmpty(SuKienThanhVienDal.SelectBySk_User(dmMa, Security.Username).Username);
            var itemRs = Lib.GetResource(Assembly.GetExecutingAssembly(), "HienThi.templates.chiTiet.htm");
            
            var sbThanhVien = new StringBuilder();
            var itemTv = Lib.GetResource(Assembly.GetExecutingAssembly(), "HienThi.templates.thanhVienChiTiet.htm");
            foreach (var tv in thanhVienThamGia)
            {
                sbThanhVien.AppendFormat(itemTv, domain, tv.RowId,tv.Anh,tv.Ten);
            }
            sb.AppendFormat(itemRs, ItemCss
                            , item.Ten
                            , item.MoTa
                            , item.NoiDung
                            , item.GhiChu
                            , item.NgayBatDau
                            , string.Format("{0}lib/up/i/{1}", domain, Lib.imgSize(item.Anh, "full"))
                            , daThamGia ? @"<a class=""sk-item-header-dajoin"" href=""javascript:;"">Đã đăng ký</a>" : string.Format(@"<a _id=""{0}"" class=""sk-item-header-join"" href=""javascript:;"">Tham gia</a><br/><span class=""sk-item-header-join-desc"">ai cũng có thể</span>",item.ID)
                            , item.ToaDo, item.DiaChi, item.HauTruong, sbThanhVien
                            , thanhVienThamGia.Count > 10 ? string.Format(" ({0})", thanhVienThamGia.Count) : "");
            #region script gmap
            sb.Append(@"
<script>
google.maps.event.addDomListener(window, 'load', function () {
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 16,");
            sb.AppendFormat(@"center: new google.maps.LatLng({0}),",item.ToaDo);
            sb.Append(@"mapTypeId: google.maps.MapTypeId.ROADMAP
        });
        var infoWindow = new google.maps.InfoWindow;
        var onMarkerClick = function () {
            var marker = this;
            var latLng = marker.getPosition();");
            sb.AppendFormat(@"infoWindow.setContent('<h1>{0}</h1>{1}<br/>{2:dd/MM/yyyy} - {3}');"
                ,item.Ten,item.DiaChi,item.NgayBatDau,item.MoTa);
            sb.Append(@"infoWindow.open(map, marker);
        };
        google.maps.event.addListener(map, 'click', function () {
            infoWindow.close();
        });
        var marker1 = new google.maps.Marker({
            map: map,");
            sb.AppendFormat(@"position: new google.maps.LatLng({0})", item.ToaDo);
            sb.Append(@"});
        google.maps.event.addListener(marker1, 'click', onMarkerClick);
        google.maps.event.addListener(marker1, 'click', function () {
        });
    });
</script>");
            #endregion
            #region footer
            sb.AppendFormat(@"
        </div>
</div>");
            #endregion

            Seo(page, item.MoTa, item.MoTa, item.Ten);
            Html = sb.ToString();
            base.KhoiTao(con);
        }


        public string Ma { get; set; }
        public string Css { get; set; }
        public string ItemCss { get; set; }
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
            Tab1Settings1.Title = "Css Item:";
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
