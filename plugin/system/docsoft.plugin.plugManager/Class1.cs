using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh.frm;
using docsoft;
using docsoft.entities;
using linh.json;
using linh.common;
using System.Xml;
[assembly: WebResource("docsoft.plugin.plugManager.admin.js", "text/javascript", PerformSubstitution = true)]
namespace docsoft.plugin.plugManager
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string subAct = Request["subAct"];
            switch (subAct)
            {
                case "menu":
                    //List<Function> MenuList = getTree(FunctionDal.SelectByUser(Security.Username));
                    //List<jgridRow> ListRow = new List<jgridRow>();
                    //foreach (Function fn in MenuList)
                    //{
                    //    if (fn.Loai != 3)
                    //    {
                    //        ListRow.Add(new jgridRow(fn.ID.ToString(), new string[] { fn.ID.ToString(), fn.Ten, fn.Url, fn.Level.ToString(), fn.PID.ToString(), fn.Level == 1 ? "false" : "true", "false" }));
                    //    }
                    //}
                    //jgrid grid = new jgrid("1", "1", MenuList.Count.ToString(), ListRow);
                    //sb.Append(JavaScriptConvert.SerializeObject(grid));
                    sb.AppendFormat(getTop(getTree(FunctionDal.SelectByUser(Security.Username,"0"))));
                    break;
                case "desk":
                    sb.AppendFormat(@"<script src=""{0}"" type=""text/javascript""></script>"
                       , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.plugManager.admin.js"));
                    sb.AppendFormat(@"<div id=""desktopMdl-content-head"">
                    <a href=""javascript:;"" id=""desktopMdl-content-head-showbtn"">
                    <span id=""desktopMdl-content-head-showbtn-title"" class=""ui-widget-content ui-corner-top"">
                    Thêm Module
                    </span>
                    <span id=""desktopMdl-content-head-showbtn-box"">
                        <span class=""ui-widget-content ui-corner-all"" id=""desktopMdl-content-head-showbtn-boxPnl"">
                            <span class=""ui-widget-content ui-corner-all"" id=""desktopMdl-content-head-showbtn-boxPnl-content"">");
                    
                    FunctionCollection UFC = FunctionDal.SelectByUser(Security.Username, "1");
                    foreach (Function ufcItem in UFC)
                    {
                        sb.AppendFormat(@"<span onclick=""myModule.add('{0}','{1}')"" class=""desktopMdl-content-head-showbtn-boxPnl-content-item""><span onclick=""myModule.add('{0}','{1}')"" class=""desktopMdl-content-button-add"">Add</span>{2}</span>", ufcItem.ID, ufcItem.Url, ufcItem.Ten);
                    }
                     sb.AppendFormat(@"</span>
                        </span>
                    </span>
                    </a>");
                    Member mMember = MemberDal.SelectAllByUserName(Security.Username);

                    sb.AppendFormat(@"<b id=""desktopMdl-content-head-title"">Phiên làm việc: {0} <span id=""desktopMdl-content-head-date"">{1}</span></b>
                </div>", mMember.Ten.ToString(), string.Format("{0:dd/MM/yyyy}",DateTime.Now));
                sb.AppendFormat(@"<div id=""desktopMdl-content-body"">"); 
                    foreach (linhLayout LAY in linhLayoutDal.SelectByUsername(Security.Username))
                    {
                        sb.AppendFormat(@"<div name=""{1}"" class=""LayOut"" style=""width:{0};"">"
                    , LAY.Width
                    , LAY.Ten);
                        sb.AppendFormat(@"<div modify=""{1}"" layout=""{3}"" name=""{0}"" class=""contentNull{2}"">"
                            , LAY.ID, true, " content", LAY.ID);
                        foreach (UserFunction UF in UserFunctionDal.SelecbyLayOutId(LAY.ID))
                        {
                            if (UF.LAY_ID == LAY.ID)
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(UF.Doc);
                                if (doc.LastChild != null)
                                {
                                    sb.Append(PlugHelper.RenderHtml(doc.LastChild, UF.ID));
                                }
                                else
                                {
                                    sb.Append("Setting missed");
                                }
                            }
                        }
                        sb.Append("</div>");
                        sb.Append("</div>");
                    }
                    sb.Append("</div>");
                    break;
                case "Update":
                    if (!string.IsNullOrEmpty(Request["layplug"]))
                    {
                        string layplug = Request["layplug"];
                        XmlDocument doc = new XmlDocument();
                        XmlNode node = doc.ImportNode(PlugHelper.RenderXml(toList(Request["iList"]), Request["plugtype"]), true);
                        doc.AppendChild(node);
                        UserFunction itemUpdate = UserFunctionDal.SelectById(Convert.ToInt32(layplug));
                        itemUpdate.Doc = linh.common.Lib.GetXmlString(doc);
                        itemUpdate = UserFunctionDal.Update(itemUpdate);
                        sb.Append(PlugHelper.RenderHtml(doc));
                    }
                    break;
                case "ReOrder":
                    if (!string.IsNullOrEmpty(Request["NewZoneIndex"]))
                    {
                        string layplug = Request["layplug"];
                        string layid = Request["NewZoneIndex"];
                        UserFunction itemUpdate = UserFunctionDal.SelectById(Convert.ToInt32(layplug));
                        itemUpdate.LAY_ID = Convert.ToInt32(layid);
                        itemUpdate.ThuTu = Convert.ToInt32(Request["NewModuleIndex"]);
                        itemUpdate = UserFunctionDal.Update(itemUpdate);
                        UserFunctionDal.UpdateReorder(Request["NewZoneOrderList"]);
                    }
                    break;
                case "Remove":
                    if (!string.IsNullOrEmpty(Request["layplug"]))
                    {
                        string layplug = Request["layplug"];
                        UserFunction itemRemove = UserFunctionDal.SelectById(Convert.ToInt32(layplug));
                        UserFunctionDal.DeleteById(itemRemove.ID);
                    }
                    break;
                case "Add":
                    string _FN_ID = Request["FN_ID"];
                    string _Url = Request["Url"];
                    string _LayID = Request["LayID"];
                    string _DocValue = "";
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlNode node = doc.ImportNode(PlugHelper.RenderXml(_Url), true);
                        doc.AppendChild(node);
                        _DocValue = linh.common.Lib.GetXmlString(doc);
                         UserFunction ItemSave = new UserFunction();
                        ItemSave.FN_ID = Convert.ToInt32(_FN_ID);
                        ItemSave.FN_Url = _Url;
                        ItemSave.LAY_ID = Convert.ToInt32(_LayID);
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.NguoiTao = Security.Username;
                        ItemSave.Username = Security.Username;
                        ItemSave.ThuTu = 1;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave.Doc = _DocValue;
                        ItemSave = UserFunctionDal.Insert(ItemSave);

                        sb.Append(PlugHelper.RenderHtml(doc.LastChild, ItemSave.ID));
                    }
                    catch (Exception ex)
                    {

                    }             
                    break;
                default:
                    break;
            }
            sb.AppendFormat(@"<script src=""{0}"" type=""text/javascript""></script>"
   , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.plugManager.admin.js"));
            writer.Write(sb.ToString());
            base.Render(writer);
        }

        public static string updatePlug(string layplug, string ilist, string plugtype)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.ImportNode(PlugHelper.RenderXml(toList(ilist), plugtype), true);
            doc.AppendChild(node);
            UserFunction itemUpdate = UserFunctionDal.SelectById(Convert.ToInt32(layplug));
            itemUpdate.Doc = linh.common.Lib.GetXmlString(doc);
            itemUpdate = UserFunctionDal.Update(itemUpdate);
            return PlugHelper.RenderHtml(doc);
        }
        public static void updateOrder(string layplug, string layid, string thuTu, string ilist)
        {
            UserFunction itemUpdate = UserFunctionDal.SelectById(Convert.ToInt32(layplug));
            itemUpdate.LAY_ID = Convert.ToInt32(layid);
            itemUpdate.ThuTu = Convert.ToInt32(thuTu);
            itemUpdate = UserFunctionDal.Update(itemUpdate);
            UserFunctionDal.UpdateReorder(ilist);
        }

       public static object[] toList(string input)
        {
            string[] list = input.Split(new char[] { '|' });
            int i = 0;
            foreach (string item in list)
            {
                if (item.Length > 0)
                {
                    i += 1;
                }
            }
            object[] obj = new object[i];
            int j = 0;
            foreach (string item in list)
            {
                if (item.Length > 0)
                {
                    obj[j] = item;
                    j += 1;
                }
            }
            return obj;
        }

        #region nghiệp vụ cho coquanfunction
        string getTop(List<Function> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Function item in list)
            {
                if (item.PID == 0)
                {
                    sb.AppendFormat(@"<h3><a href=""javascript:;"" _fn_id=""{1}"">{0}</a></h3>"
                        ,item.Ten,item.ID);
                    sb.AppendFormat("<div>");
                    sb.AppendFormat(getChild(item.ID, list));
                    sb.AppendFormat("</div>");
                }
            }
            return sb.ToString();
        }
        string getChild(int _Id, List<Function> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div class=""mnu-list"">");
            foreach (Function item in list)
            {
                if (item.PID == _Id)
                {
                    sb.AppendFormat(@"<a href=""javascript:;"" class=""mnu-item ui-corner-all"" _url=""{2}"" title=""{1}"" _fn_id=""{0}""><span class=""mnu-item-div""><img class=""mnu-item-icon"" src=""../up/i/{3}"" /><span class=""mnu-item-title"">{1}</span></span></a>"
                        , item.ID, item.Ten, item.Url, string.IsNullOrEmpty(item.Anh) ? "fn-icon.jpg" : item.Anh);
                }
            }
            sb.AppendFormat("</div>");
            return sb.ToString();
        }
        #endregion
        #region TreeProcess
        List<Function> getTree(List<Function> inputList)
        {
            List<Function> list = new List<Function>();
            foreach (HierarchyNode<Function> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        void buildChild(HierarchyNode<Function> item, List<Function> list)
        {
            foreach (HierarchyNode<Function> _item in item.ChildNodes)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<Function>> buildTree(List<Function> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ThuTu).ToList().AsHierarchy(e => e.ID, e => e.PID);
            List<HierarchyNode<Function>> _list = new List<HierarchyNode<Function>>();
            foreach (HierarchyNode<Function> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        #endregion
    }
}
