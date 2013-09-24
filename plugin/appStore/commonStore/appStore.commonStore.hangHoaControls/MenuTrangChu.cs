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

namespace appStore.commonStore.hangHoaControls
{
    public class MenuTrangChu : docPlugUI
    {
        int i = 0;
        int j = 0;
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            var sb = new StringBuilder();
            var listDm = GetTree(DanhMucDal.SelectByLDMMa(con, "NHOM-HH"));
            var list1 = from p in listDm
                        where p.Level == 1
                        orderby p.ThuTu ascending
                        select p;

            #region header
            sb.AppendFormat(@"
<div class=""{0}"">
    <div class=""box-header"">
        <a href=""{2}"" class=""box-header-label"">{1}</a>
    </div>
        <div class=""box-body"">", Css, Ten, Header_Url);
            #endregion

            sb.Append(@"<ul class=""cate-home-ul"">");

            foreach (DanhMuc item in list1)
            {
                sb.AppendFormat(@"<li class=""cate-home-li""><a title=""{1}"" class=""cate-item"" href=""{0}/Products/{2}/"">{1}</a>"
                    , domain
                    , item.Ten
                    , item.Ma);
                sb.Append(GetSub(listDm, item));
                sb.Append("</li>");

            }
            sb.Append("</ul>");

            #region footer
            sb.AppendFormat(@"
        </div>
</div>");
            #endregion
            Html = sb.ToString();
            base.KhoiTao(con);
        }
        public string GetSub(List<DanhMuc> list, DanhMuc pid)
        {            
            j = 0;
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            
            var sb = new StringBuilder();
            var myList = from p
                         in list
                         where p.PID == pid.ID
                         select p;
            if (myList.Any())
            {
                sb.Append(@"<div class=""cate-flyOut"">");
                int max = 0;
                int total = 0;
                foreach (DanhMuc muc in myList)
                    total++;
                if (total % 2 == 0)
                {
                    max = total / 2;
                }
                else
                {
                    max = Convert.ToInt32(Math.Floor(Convert.ToDecimal(myList.Count() / 2))) + 1;
                }
                foreach (DanhMuc item in myList)
                {
                    if (j < max)
                    {
                        sb1.AppendFormat(@"<a href=""{0}/Products/{1}/"" title=""{2}"" Class=""cate-flyOut-subCate-item"">{2}</a>", domain, item.Ma, item.Ten);
                    }
                    else
                    {

                        sb2.AppendFormat(@"<a href=""{0}/Products/{1}/"" title=""{2}"" Class=""cate-flyOut-subCate-item"">{2}</a>", domain, item.Ma, item.Ten);
                    }
                    j++;
                }
                if (!string.IsNullOrEmpty(sb1.ToString()))
                {
                    sb.AppendFormat(@"<div class=""cate-flyOut-subCate-panel"">{0}</div>", sb1);
                }
                if (!string.IsNullOrEmpty(sb2.ToString()))
                {
                    sb.AppendFormat(@"<div class=""cate-flyOut-subCate-panel"">{0}</div>", sb2);
                }                
                sb.Append("</div>");
            }
            return sb.ToString();
        }
        #region TreeProcess
        List<DanhMuc> GetTree(List<DanhMuc> inputList)
        {
            var list = new List<DanhMuc>();
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
        List<DanhMuc> GetTreeTop(List<DanhMuc> inputList)
        {
            var list = new List<DanhMuc>();
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
            return tree.ToList();
        }
        #endregion

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
