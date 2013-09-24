using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;

namespace appStore.commonStore.commonControls
{
    public class HangHoaMenuTop : PlugUI
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
            var menuSb = new StringBuilder();
            var subMenuSb = new StringBuilder();
            var loggedInSb = new StringBuilder();
            var loginFormSb = new StringBuilder();
            var loginSb = new StringBuilder();
            var listDm = GetTree(DanhMucDal.SelectByLDMMa(con, "MENU"));

            var list1 = from p in listDm
                        where p.Level == 1
                        orderby p.ThuTu ascending
                        select p;
            var headFacebookStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "header_facebookapp.htm");
            var headStr = Lib.GetResource(Assembly.GetExecutingAssembly(), "header_leena.htm");

            var loggedInTemplate = Lib.GetResource(Assembly.GetExecutingAssembly(), "header_leena_loggedIn.htm");
            var loginForm = Lib.GetResource(Assembly.GetExecutingAssembly(), "header_leena_loginForm.htm");


            if(Security.IsAuthenticated())
            {
                loginSb.Append(loggedInSb.AppendFormat(loggedInTemplate, Security.Username));
            }
            else
            {
                loginSb.Append(loginForm);
            }

            #region menu
            menuSb.Append(@"<ul class=""nav"">");
            var totalItem = list1.Count();
            var i = 1;
            foreach (var item in list1)
            {
                menuSb.AppendFormat(@"<li{2}{3}><a title=""{1}"" class=""navi-top-item"" href=""{0}"">{1}</a>", item.GiaTri,
                                    item.Ten, i != totalItem ? "" : " class=\"lst\""
                                    , i == 1 ? " class=\"fst\"" : "");
                menuSb.Append(GetSub(listDm, item));
                menuSb.Append("</li>");
                i++;
            }
            menuSb.Append("</ul>");
            #endregion

            #region subMenu
            listDm = GetTree(DanhMucDal.SelectByLDMMa(con, "SUBMENU"));
            subMenuSb.Append(@"<ul class=""navSub"">");
            foreach (var item in listDm)
            {
                subMenuSb.AppendFormat(@"<li><a title=""{1}""  href=""{0}"">{1}</a>"
                    , item.GiaTri, item.Ten);
                subMenuSb.Append(GetSub(listDm, item));
                subMenuSb.Append("</li>");
            }
            subMenuSb.Append("</ul>");
            #endregion

            sb.Append(headFacebookStr);
            sb.AppendFormat(headStr, menuSb, subMenuSb, loginSb);
            Html = sb.ToString();
            base.KhoiTao(con);
        }
        public string GetSub(List<DanhMuc> list, DanhMuc pitem)
        {
            var sb = new StringBuilder();
            var list1 = from p in list
                        where p.PID == pitem.ID
                        orderby p.ThuTu ascending
                        select p;
            if (list1.Any())
            {
                sb.Append(@"<ul class=""sub"">");
                foreach (var item in list1)
                {
                    sb.AppendFormat(@"<li><a title=""{1}"" class=""navi-top-subItem"" href=""{0}"">{1}</a></li>"
                        , item.GiaTri
                        , item.Ten);
                }
                sb.Append("</ul>");
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
    }
}
