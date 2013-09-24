using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Web.Caching;
using System.Web.UI;
using System.Web;
namespace linh.frm
{
    public class PageHelper
    {
       // public static string getPage(string alias)
       // {
       //     StringBuilder sb = new StringBuilder();
       //     if (string.IsNullOrEmpty(alias)) return string.Format("{0} không tồn tại",alias);
       //     linhPage pg = linhPageDal.SelectByAlias(alias);
       //     linhLayoutPlugCollection plugs = linhLayoutPlugDal.SelectByPageAlias(alias);
       //     foreach(linhLayout lay in pg.layouts)
       //     {
       //         sb.AppendFormat(@"<div name=""{1}"" class=""LayOut"" style=""width:{0};"">"
       //             ,lay.Width
       //             ,alias);
       //         sb.AppendFormat(@"<div modify=""{1}"" layout=""{3}"" name=""{0}"" class=""contentNull{2}"">"
       //             ,lay.ID, true," content",lay.ID);
       //         foreach (linhLayoutPlug item in plugs)
       //         {
       //             if (item.LAY_ID == lay.ID)
       //             {
       //                 XmlDocument doc=new XmlDocument();
       //                 doc.LoadXml(item.Doc);
       //                 if (doc.LastChild != null)
       //                 {
       //                     sb.Append(PlugHelper.RenderHtml(doc.LastChild, item.ID));
       //                 }
       //                 else
       //                 {
       //                     sb.Append("Setting missed");
       //                 }
       //             }
       //         }
       //         sb.Append("</div>");
       //         sb.Append("</div>");
       //     }
       //     return sb.ToString();
       // }
       // public static string updatePlug(string layplug, string ilist, string plugtype)
       // {
       //     XmlDocument doc = new XmlDocument();
       //     XmlNode node = doc.ImportNode(PlugHelper.RenderXml(toList(ilist), plugtype), true);
       //     doc.AppendChild(node);
       //     linhLayoutPlug itemUpdate = linhLayoutPlugDal.SelectById(Convert.ToInt32(layplug));
       //     itemUpdate.Doc = linh.common.Lib.GetXmlString(doc);
       //     itemUpdate = linhLayoutPlugDal.Update(itemUpdate);
       //     return PlugHelper.RenderHtml(doc);
       // }
       // public static void updateOrder(string layplug, string layid, string thuTu, string ilist)
       // {
       //     linhLayoutPlug itemUpdate = linhLayoutPlugDal.SelectById(Convert.ToInt32(layplug));
       //     itemUpdate.LAY_ID = Convert.ToInt32(layid);
       //     itemUpdate.ThuTu = Convert.ToInt32(thuTu);
       //     itemUpdate = linhLayoutPlugDal.Update(itemUpdate);
       //     linhLayoutPlugDal.UpdateReorder(ilist);
       // }
       //public static object[] toList(string input)
       // {
       //     string[] list = input.Split(new char[] { '|' });
       //     int i = 0;
       //     foreach (string item in list)
       //     {
       //         if (item.Length > 0)
       //         {
       //             i += 1;
       //         }
       //     }
       //     object[] obj = new object[i];
       //     int j = 0;
       //     foreach (string item in list)
       //     {
       //         if (item.Length > 0)
       //         {
       //             obj[j] = item;
       //             j += 1;
       //         }
       //     }
       //     return obj;
       // }
    }
}
