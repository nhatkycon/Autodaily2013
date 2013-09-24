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
    public class danhMuc_headLine1 : PlugUI
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
            HttpContext c = HttpContext.Current;
            bool login = Security.IsAuthenticated();
            string _DM_Ten = c.Request["DM_Ten"];


            #region đường dẫn
            DanhMuc Item = DanhMucDal.SelectByAlias(con, _DM_Ten);
            c.Session["Title"] = Item.Ten;
            sb1.Append(@"<ul class=""tin-view-navi"" id=""tin-view-navi-menus"">");
            sb1.AppendFormat(@"<li class=""page_item""><a href=""{0}"" class=""tin-view-navi-menus-item home"">Trang chủ</a></li>", domain);
            sb1.AppendFormat(@"<li class=""page_item""><a href=""{0}{1}/"" class=""tin-view-navi-menus-item"">{2}</a></li>", domain, Item.Alias, Item.Ten);
            sb1.AppendFormat(@"<li class=""page_item""><a href=""{0}rss/{1}.rss"" class=""tin-view-navi-menus-item""><span class=""box_head_task_rss""></span></a></li>", domain, Item.Alias, Item.Ten);
            sb1.Append(@"</ul>");
            #endregion
            List<Tin> list = TinDal.SelectNoiBatDanhMuc(con, 3, _DM_Ten);
            sb.AppendFormat(@"
<div class=""box8"" style=""{0}"">
        <div class=""box-body"">", Css, Ten, Header_Url);
            sb.AppendFormat(@"<div class=""danhMucStyle8-pnlLeft"">");
            sb.Append(sb1);
            if (list.Count > 0)
            {
                sb.AppendFormat(@"<div class=""danhMucStyle8-header"">");
                Tin ItemTin = list[0];
                sb.Append(TinDal.formatDanhMucStyle8Big(ItemTin, domain));
                sb.AppendFormat(@"<div class=""danhMucStyle8-header-leftPnl"">");
                foreach (Tin item in list)
                {
                    sb.Append(TinDal.formatDanhMucStyle8Medium(item, domain));
                }
                sb.AppendFormat(@"</div>");
                sb.AppendFormat(@"</div>");
            }
            sb.AppendFormat(@"</div>");
            sb.AppendFormat(@"<div class=""danhMucStyle8-pnlRight"">");
            List<docsoft.entities.DanhMuc> listDm = docsoft.entities.DanhMucDal.SelectByLDMMa(con, "QC-DM-TOPLEFT");
            foreach (docsoft.entities.DanhMuc item in listDm)
            {
                sb.AppendFormat(@"<div class=""danhMucStyle8-pnlRight-item"">{0}</div>",item.Description);
            }
            sb.AppendFormat(@"</div>");
            sb.AppendFormat(@"
        </div>
</div>");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }   
}
