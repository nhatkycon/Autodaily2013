using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using System.Data.SqlClient;
using linh.core.dal;
using System.Web.UI;
using System.Web;
using docbao.entitites;
namespace appStore.rssAppStore.tinApp
{
    public class home_headLines : PlugUI
    {
        public string Ma_Trang_Chu { get; set; }
        public string Ma_Sub { get; set; }
        public string Css { get; set; }        
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Ma_Trang_Chu = GetSetting("Ma_Trang_Chu", SettingNode);
            Ma_Sub = GetSetting("Ma_Sub", SettingNode);
            Css = GetSetting("Css", SettingNode);
            base.LoadSetting(SettingNode);
        }
        public override void AddTabs()
        {
            base.AddTabs();
            ModuleSetting Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Ma_Trang_Chu";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Ma_Trang_Chu;
            Tab1Settings1.Title = "Mã trang chủ";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            ModuleSetting Tab1Settings2 = new ModuleSetting();
            Tab1Settings2.Key = "Css";
            Tab1Settings2.Type = "String";
            Tab1Settings2.Value = Css;
            Tab1Settings2.Title = "Css";
            this.Tabs[0].Settings.Add(Tab1Settings2);

            ModuleSetting Tab1Settings3 = new ModuleSetting();
            Tab1Settings3.Key = "Ma_Sub";
            Tab1Settings3.Type = "String";
            Tab1Settings3.Value = Ma_Sub;
            Tab1Settings3.Title = "Danh mục phụ";
            this.Tabs[0].Settings.Add(Tab1Settings3);
        }
        public override void ImportPlugin()
        {
            if (Ma_Trang_Chu == null) Ma_Trang_Chu = "6";
            if (Ma_Sub == null) Ma_Sub = "8";
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
            sb.AppendFormat(@"
<div class=""box6"" style=""{0}"">    
        <div class=""box-body"">", Css);
            sb.Append(@"<div class=""box-body-top"">");
            HttpContext c = HttpContext.Current;
            if (string.IsNullOrEmpty(Ma_Trang_Chu)) Ma_Trang_Chu = "6";
            if (Ma_Sub == null) Ma_Sub = "8";
            #region Tin mới nhất
            sb.Append(@"<div class=""newest-box"">");
            int i = 0;
            foreach (Tin item in TinDal.SelectTop(con, 7))
            {
                if (i == 0)
                {
                    sb.Append(TinDal.formatHeadNewestBig(item, domain));
                }
                else
                {
                    sb.Append(TinDal.formatHeadNewestTiny(item, domain));
                }
                i++;
            }
            sb.Append(@"</div>");
            #endregion
            #region Tin trang chu

            sb.Append(@"<div class=""headline-box"">");
            List<NhomTin> List = NhomTinDal.SelectByNhomId(con, Ma_Trang_Chu);
            NhomTin Item = new NhomTin();
            if (List.Count > 0)
            {
                Item = List[0];
                sb.Append(TinDal.formatHeadBig(Item._Tin, domain));
                foreach (NhomTin item in List)
                {
                    if (item.ID != Item.ID)
                    {
                        sb.Append(TinDal.formatHeadTiny(item._Tin, domain));
                    }
                }
            }
            sb.Append(@"</div>");
            #endregion
            sb.Append(@"</div>");
            sb.Append(@"<div class=""box-body-center"">");
            sb.Append(@"<div class=""box-body-center-r""></div>");
            sb.Append(@"<div class=""box-body-center-l""></div>");
            sb.Append(@"</div>");

            #region Tin bên dưới
            sb.Append(@"<div class=""box-body-bottom"">");
            sb.Append(@"<div class=""headline-subbox"">");
            List = NhomTinDal.SelectByNhomId(con, Ma_Sub).Take(4).ToList();
            foreach (NhomTin item in List)
            {
                sb.Append(TinDal.formatSubHeadTiny(item._Tin, domain));
            }
            sb.Append(@"</div>");
            sb.Append(@"</div>");
            #endregion

           sb.AppendFormat(@"
        </div>
</div>");
           c.Session["Title"] = "KenhThongTin.vn";
           Html = sb.ToString();
            base.KhoiTao(con);
        }
    }   
}
