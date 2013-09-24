using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using docbao.entitites;
using linh.frm;
using System.Data.SqlClient;
using linh.core.dal;
using docsoft;
using System.Web.UI;
using System.Web;
using linh.controls;
using linh.common;

namespace appStore.rssAppStore.commonApp
{
    public class NaviTop : PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            StringBuilder sb = new StringBuilder();
            var ListDm = getTree(docbao.entitites.DanhMucDal.SelectAll(con));
            var List1 = from p in ListDm
                        where p.Level == 1
                        orderby p.ThuTu ascending
                        select p;
            sb.AppendFormat(@"
<div class=""bodyGlobal top-navi"">
    <div class=""boxGlobal"">
        <div class=""box1Global"">
            <a href=""{0}rss.rss"" class=""top-navi-rss-icon""></a>
            ", domain);
            sb.AppendFormat(@"<div class=""top-navi-logo-sub"">");
            docsoft.entities.DanhMuc ItemDm = docsoft.entities.DanhMucDal.SelectByMa("HETHONG-LOGO", con);
                sb.AppendFormat("{0}", String.IsNullOrEmpty(ItemDm.Description) ? string.Format(@"<a href="""" class=""logo""></a>", domain) : ItemDm.Description);
            sb.AppendFormat(@"</div>");
            sb.Append(@"<div class=""navi-top""><ul>");
            foreach (docbao.entitites.DanhMuc item in List1)
            {
                sb.AppendFormat(@"<li class=""menu-li""><a title=""{3}"" class=""navi-top-item"" href=""{0}{1}/"">{3}</a>"
                    , domain, item.Alias, item.ID, item.Ten);
                sb.Append(getSub(ListDm, item));
                sb.Append("</li>");

            }
            sb.Append("</ul></div>");
            sb.AppendFormat(@"</div>                
    </div>
</div>");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
        public string getSub(List<DanhMuc> list, DanhMuc pitem)
        {
            StringBuilder sb = new StringBuilder();
            var List1 = from p in list
                        where p.P_ID == pitem.ID
                        orderby p.ThuTu ascending
                        select p;
            if (List1.ToList().Count > 0)
            {
                sb.Append(@"<div class=""menu-flyOut"">");
                foreach (docbao.entitites.DanhMuc item in List1)
                {
                    sb.AppendFormat(@"<a title=""{5}"" class=""navi-top-subItem"" href=""{0}{1}/{3}/"">{5}</a>"
                        , domain, pitem.Alias, pitem.ID, item.Alias,item.ID, item.Ten);
                }
                sb.Append("</div>");
            }
            return sb.ToString();
        }
        #region TreeProcess
        List<docbao.entitites.DanhMuc> getTree(List<DanhMuc> inputList)
        {
            var list = new List<DanhMuc>();
            var plist = from c in buildTree(inputList)
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<docbao.entitites.DanhMuc> item in plist)
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        List<docbao.entitites.DanhMuc> getTreeTop(List<docbao.entitites.DanhMuc> inputList)
        {
            List<docbao.entitites.DanhMuc> list = new List<docbao.entitites.DanhMuc>();
            foreach (HierarchyNode<docbao.entitites.DanhMuc> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                break;
            }
            return list;
        }
        void buildChild(HierarchyNode<docbao.entitites.DanhMuc> item, List<docbao.entitites.DanhMuc> list)
        {
            var plist = from c in item.ChildNodes
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<docbao.entitites.DanhMuc> _item in plist)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<docbao.entitites.DanhMuc>> buildTree(List<docbao.entitites.DanhMuc> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ID).ToList().AsHierarchy(e => e.ID, e => e.P_ID);
            List<HierarchyNode<docbao.entitites.DanhMuc>> _list = new List<HierarchyNode<docbao.entitites.DanhMuc>>();
            foreach (HierarchyNode<docbao.entitites.DanhMuc> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        #endregion
    }
    public class NaviBottom : PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            StringBuilder sb = new StringBuilder();
            List<docbao.entitites.DanhMuc> ListDm = getTree(docbao.entitites.DanhMucDal.SelectAll(con));
            var List1 = from p in ListDm
                        where p.Level == 1
                        orderby p.ThuTu ascending
                        select p;
            sb.AppendFormat(@"
<div class=""bodyGlobal top-navi"">
    <div class=""boxGlobal"">
        <div class=""box1Global"">
            <a href=""{0}rss.rss"" class=""top-navi-rss-icon""></a>
            ", domain);
            sb.AppendFormat(@"<div class=""top-navi-logo-sub"">");
            docsoft.entities.DanhMuc ItemDm = docsoft.entities.DanhMucDal.SelectByMa("HETHONG-LOGO", con);
            sb.AppendFormat("{0}", String.IsNullOrEmpty(ItemDm.Description) ? string.Format(@"<a href="""" class=""logo""></a>", domain) : ItemDm.Description);

            sb.AppendFormat(@"</div>");
            sb.Append(@"<div class=""navi-top""><ul>");
            foreach (docbao.entitites.DanhMuc item in List1)
            {
                sb.AppendFormat(@"<li class=""menu-li""><a title=""{3}"" class=""navi-top-item"" href=""{0}{1}/"">{3}</a>"
                    , domain, item.Alias, item.ID, item.Ten);
                sb.Append("</li>");

            }
            sb.Append("</ul></div>");
            sb.AppendFormat(@"</div>                
    </div>
</div>");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
        public string getSub(List<docbao.entitites.DanhMuc> list, docbao.entitites.DanhMuc pitem)
        {
            StringBuilder sb = new StringBuilder();
            var List1 = from p in list
                        where p.P_ID == pitem.ID
                        orderby p.ThuTu ascending
                        select p;
            if (List1.ToList().Count > 0)
            {
                sb.Append(@"<div class=""menu-flyOut"">");
                foreach (docbao.entitites.DanhMuc item in List1)
                {
                    sb.AppendFormat(@"<a title=""{5}"" class=""navi-top-subItem"" href=""{0}{1}/{3}/"">{5}</a>"
                        , domain, pitem.Alias, pitem.ID, item.Alias, item.ID, item.Ten);
                }
                sb.Append("</div>");
            }
            return sb.ToString();
        }
        #region TreeProcess
        List<docbao.entitites.DanhMuc> getTree(List<docbao.entitites.DanhMuc> inputList)
        {
            List<docbao.entitites.DanhMuc> list = new List<docbao.entitites.DanhMuc>();
            var plist = from c in buildTree(inputList)
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<docbao.entitites.DanhMuc> item in plist)
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        List<docbao.entitites.DanhMuc> getTreeTop(List<docbao.entitites.DanhMuc> inputList)
        {
            List<docbao.entitites.DanhMuc> list = new List<docbao.entitites.DanhMuc>();
            foreach (HierarchyNode<docbao.entitites.DanhMuc> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                break;
            }
            return list;
        }
        void buildChild(HierarchyNode<docbao.entitites.DanhMuc> item, List<docbao.entitites.DanhMuc> list)
        {
            var plist = from c in item.ChildNodes
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<docbao.entitites.DanhMuc> _item in plist)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<docbao.entitites.DanhMuc>> buildTree(List<docbao.entitites.DanhMuc> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ID).ToList().AsHierarchy(e => e.ID, e => e.P_ID);
            List<HierarchyNode<docbao.entitites.DanhMuc>> _list = new List<HierarchyNode<docbao.entitites.DanhMuc>>();
            foreach (HierarchyNode<docbao.entitites.DanhMuc> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        #endregion
    }
}
