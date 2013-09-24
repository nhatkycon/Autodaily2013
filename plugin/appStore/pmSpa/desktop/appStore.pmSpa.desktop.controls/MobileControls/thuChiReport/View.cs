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
using linh.json;
using pmSpa.entities;
using System.Globalization;
using System.Reflection;
[assembly: WebResource("appStore.pmSpa.desktop.controls.MobileControls.thuChiReport.js.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls..MobileControls.thuChiReport.view.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls..MobileControls.thuChiReport.htm.htm", "text/html", PerformSubstitution = true)]
namespace appStore.pmSpa.desktop.controls.MobileControls.thuChiReport
{
    public class View : docPlugUI
    {

        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con(), this.Page);
            writer.Write(Html);
            base.Render(writer);
        }

        public override void KhoiTao(SqlConnection con, Page page)
        {
            var sb = new StringBuilder();
            var c = HttpContext.Current;
            var cs = page.ClientScript;
            var subAct = c.Request["subAct"];
            var TC_ID = c.Request["TC_ID"];
            var danhMucKyHieuChi = DanhMucDal.SelectByMa("TC-CHI", con);
            var danhMucKyHieuThu = DanhMucDal.SelectByMa("TC-THU", con);

            var itemFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "MobileControls.thuChiReport.item.htm");
            var viewFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "MobileControls.thuChiReport.view.htm");
            var formFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "MobileControls.thuChiReport.htm.htm");

            switch (subAct)
            {
                case "edit":
                    #region edit
                    if (!string.IsNullOrEmpty(TC_ID))
                    {
                        var item = ThuChiDal.SelectById(new Guid(TC_ID));
                        if(item.Thu)
                        {

                            item.SoPhieu = danhMucKyHieuThu.KyHieu + item.SoPhieu;
                        }
                        else
                        {
                            item.SoPhieu = danhMucKyHieuChi.KyHieu + item.SoPhieu;
                        }
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                default:
                    #region mặc địch
                        var TuNgay = c.Request["TuNgay"];
                        var DenNgay = c.Request["DenNgay"];
                        var dNow = DateTime.Now;
                        var dauThang = new DateTime(dNow.Year, 1, 1).ToString("yyyy-MM-dd");
                        var cuoiThang = new DateTime(dNow.Year, dNow.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                        TuNgay = string.IsNullOrEmpty(TuNgay) ? dauThang : Convert.ToDateTime(TuNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");
                        DenNgay = string.IsNullOrEmpty(DenNgay) ? cuoiThang : Convert.ToDateTime(DenNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");
                        var pagerGet = ThuChiReportDal.SelectTuNgayDenNgay(TuNgay, DenNgay);
                        var sbItem = new StringBuilder();
                        foreach (var item in pagerGet)
                        {
                            sbItem.AppendFormat(itemFormat
                                , item.ma
                                            ,  item._ThuChi.Thu ? " thu" : " chi"
                                            , Lib.TienVietNam(item._ThuChi.SoTien)
                                            , item._ThuChi.LoaiQuy == 0 ? " bold" : ""
                                            , item.ngay
                                            , Lib.TienVietNam(item.sodu_tm)
                                            , Lib.TienVietNam(item.sodu_tk)
                                            , Lib.TienVietNam(item.sodu_t)
                                            , string.IsNullOrEmpty(item.sophieu) ? "Đầu kỳ"  : string.Format("{1}{0}", item._ThuChi.SoPhieu, item._ThuChi.Thu ? danhMucKyHieuThu.KyHieu : danhMucKyHieuChi.KyHieu)
                                            , item._ThuChi.LoaiQuy == 0 ? "" : " bold"
                                            , item._ThuChi.Thu ? "+" : "-"
                                            );
                        }
                        sb.AppendFormat(viewFormat, sbItem);
                        sb.Append(formFormat);
                        sb.AppendFormat(@"<script src=""{0}""></script>",
                                        cs.GetWebResourceUrl(typeof(View), "appStore.pmSpa.desktop.controls.MobileControls.thuChiReport.js.js"));
                    break;
                    #endregion
            }
           
            
            

            
            Html = sb.ToString();
            base.KhoiTao(con);
        }

        public bool tm(ThuChiReport item)
        {
            if (item.thu_tk > 0 || item.chi_tk > 0)
                return false;
            return true;
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
