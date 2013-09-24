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
    public class DanhSach : docPlugUI
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
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();

            var c = HttpContext.Current;
            var bodyFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "DichVu.Body.htm");

            var list = getTree(DanhMucDal.SelectByLDMMa(con, "NHOM-DV"));
            sb1.AppendFormat(@"<div _ref=""0"" class=""dv-item dv-item-header dv-item-header-active"">
        <a href=""javascript:;"" class=""dv-item-ten"">Tất cả dịch vụ
        </a>
    </div>");
            var itemFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "DichVu.dv-item.htm");
            foreach (var item in list)
            {
                sb1.AppendFormat(@"<div _ref=""{1}"" class=""dv-item dv-item-header"">
        <a href=""javascript:;"" class=""dv-item-ten"">{0}
        </a>
    </div>", item.Ten, item.ID);
                var listDv = DichVuDal.SelectByDm(con, item.ID.ToString());
                foreach (var dv in listDv)
                {
                    sb2.AppendFormat(itemFormat
                        , domain
                   , dv.Ten
                   , string.Format(new CultureInfo("vi-Vn"), "{0:c}", dv.Gia).Replace(",00 ₫","")
                   , dv.ID
                   , Lib.imgSize(dv.Anh, "100x100")
                   , dv.MoTa
                   , dv.SoLan
                   , dv.ThoiGian
                   , dv.DM_ID
                   , dv.KhuyenMai ? " dv-item-khuyen-mai" : "");
                }
            }

//            sb.AppendFormat(@"
//<table width=""100%"">
//    <tr>
//        <td valign=""top"" style=""width: 300px;""><div class=""dv-pnl-left"">{0}</div></td>
//        <td valign=""top""><div class=""dv-pnl-right fullScrollPanel"">{1}</div></td>
//    </tr>
//</table>", sb1, sb2);
            sb.AppendFormat(@"<div class=""dv-pnl-left"">{0}</div><div class=""dv-pnl-right"">{1}</div>", sb1, sb2);
            //Html = string.Format(bodyFormat, domain, sb);
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

        #region TreeProcess
        List<DanhMuc> getTree(List<DanhMuc> inputList)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            var plist = from c in buildTree(inputList)
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> item in plist)
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        List<DanhMuc> getTreeTop(List<DanhMuc> inputList)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            foreach (HierarchyNode<DanhMuc> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                break;
            }
            return list;
        }
        void buildChild(HierarchyNode<DanhMuc> item, List<DanhMuc> list)
        {
            var plist = from c in item.ChildNodes
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> _item in plist)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<DanhMuc>> buildTree(List<DanhMuc> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ID).ToList().AsHierarchy(e => e.ID, e => e.PID);
            List<HierarchyNode<DanhMuc>> _list = new List<HierarchyNode<DanhMuc>>();
            foreach (HierarchyNode<DanhMuc> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        #endregion
    }
}
