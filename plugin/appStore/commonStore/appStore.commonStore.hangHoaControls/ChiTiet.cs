using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;

namespace appStore.commonStore.hangHoaControls
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
            var sbFiles = new StringBuilder();
            var sbFiles1 = new StringBuilder();
            var sbLienQuan = new StringBuilder();
            var c = HttpContext.Current;
            var Id = c.Request["HH-ID"];
            var mainStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "ChiTiet.htm");
            var itemStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "ChiTiet_item.htm");
            var itemLienQuanStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "ChiTiet_lienQuan_item.htm");
            if (!string.IsNullOrEmpty(Id))
            {
                var item = HangHoaDal.SelectById(new Guid(Id));
                item.ListFiles = FilesDal.SelectByPRowId(item.ID).Take(5).ToList();

                var i = 0;

                foreach (var img in item.ListFiles)
                {
                    if(i<3)
                    {
                        sbFiles.AppendFormat(itemStr
                            , img.ThuMuc, img.Ten + img.MimeType, img.Ten + "full" + img.MimeType, item.Ten);    
                    }
                    else
                    {
                        sbFiles1.AppendFormat(itemStr
                        , img.ThuMuc, img.Ten + img.MimeType, img.Ten + "full" + img.MimeType, item.Ten);
                    }
                    
                    i++;
                }

                var listLienQuan = HangHoaDal.SelectTopLienQuan(Id, Top, con);

                foreach (var itemLq in listLienQuan)
                {
                    sbLienQuan.AppendFormat(itemLienQuanStr, Lib.Bodau(itemLq.DM_Ten), itemLq.Ten, itemLq.ID,
                                        Lib.imgSize(itemLq.Anh, "326"), item.Ten, Lib.TienVietNam(itemLq.GNY));
                }

                Seo(page, item.MoTa,item.Keywords,item.Ten);
                sb.AppendFormat(mainStr, item.Ten, Lib.TienVietNam(item.GNY)
                                , Lib.imgSize(item.Anh, "326"), sbFiles, sbFiles1, sbLienQuan, item.NoiDung, item.DM_Ten, item.ID);

            }
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
            Tab1Settings1.Title = "Class của hàng hóa";
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
