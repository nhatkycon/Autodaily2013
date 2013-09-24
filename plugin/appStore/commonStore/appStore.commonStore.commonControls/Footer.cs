using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;

namespace appStore.commonStore.commonControls
{
    public class Footer : PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            var sb = new StringBuilder();
            var sbMenu = new StringBuilder();
            var listDm = GetTree(DanhMucDal.SelectByLDMMa(con, "MENU"));
            var itemDm = DanhMucDal.SelectByMa("HETHONG-FOOTER", con);

            var mainStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "footer.htm");
            var itemStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "footer_item.htm");

            var list1 = from p in listDm
                        where p.Level == 1
                        orderby p.ThuTu ascending
                        select p;
            var totalItem = list1.Count();
            var i = 1;
            foreach (var item in list1)
            {
                sbMenu.AppendFormat(itemStr, item.GiaTri, item.Ten
                    , i != totalItem ? "" : " class=\"lst\""
                    , i == 1 ? " class=\"fst\"" : "");
            }
            sb.AppendFormat(mainStr, sbMenu, itemDm.Description);
            Html = sb.ToString();
            base.KhoiTao(con);
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
    }
}
