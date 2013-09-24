using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Web.Caching;
using linh.core.dal;

namespace linh.frm
{
    public class PlugHelper
    {
        public static string RenderHtml_Edit(XmlNode Mdl, string layPlugId)
        {
            StringBuilder sb = new StringBuilder();
            #region Module
            bool LoggedIn = true;
            #region Nạp biến Module
            bool IsShared = Convert.ToBoolean(Mdl.Attributes["IsShared"].Value);
            string XmlSourcePath = Mdl.Attributes["XmlSourcePath"].Value;
            //if (IsShared)
            //{
            //    XmlDocument docShared = new XmlDocument();
            //    docShared.Load(HttpContext.Current.Server.MapPath(XmlSourcePath));
            //    if (File.Exists(HttpContext.Current.Server.MapPath(XmlSourcePath))) Mdl = docShared.LastChild;

            //}
            string ModuleTitle = Mdl.Attributes["Title"].Value;
            string PluginClientId = Mdl.Attributes["PluginClientId"].Value;
            string PluginIndex = Mdl.Attributes["PluginIndex"].Value;
            string PluginId = Mdl.Attributes["ID"].Value;
            string ModuleType = Mdl.Attributes["PluginType"].Value;
            bool ModuleDisplay = Convert.ToBoolean(Mdl.Attributes["Display"].Value);
            bool ShowBorder = Convert.ToBoolean(Mdl.Attributes["ShowBorder"].Value);
            bool ShowHeader = Convert.ToBoolean(Mdl.Attributes["ShowHeader"].Value);
            bool ShowFoot = Convert.ToBoolean(Mdl.Attributes["ShowFoot"].Value);
            bool ModulePublic = Convert.ToBoolean(Mdl.Attributes["Public"].Value);
            string PluginCss = string.Empty;
            if (Mdl.Attributes["PluginCss"] != null)
            {
                PluginCss = Mdl.Attributes["PluginCss"].Value;
            }
            string PluginIcon = Mdl.Attributes["PluginIcon"].Value;

            #endregion

            if (ModuleDisplay || LoggedIn)
            {
                if (LoggedIn)//Cài đặt của Module
                {
                    #region Setting
                    XmlNode ModuleSettings = Mdl.ChildNodes[0];
                    StringBuilder TabContent = new StringBuilder();
                    #region Cài đặt chung
                    XmlNode ModuleSercurity = Mdl.LastChild;
                    TabContent.Append("<table style=\"width: 100%;\" cellspacing=\"4\">");
                    #region Tên Module
                    TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                    TabContent.Append("Tên");
                    TabContent.Append(":</td><td>");
                    TabContent.AppendFormat("<input pluginField=\"Title\" class=\"Module_Edit_Title\" type=\"text\" value=\"{0}\" />"
                        , ModuleTitle);
                    TabContent.Append("</td></tr>");
                    #endregion
                    #region Hiển thị
                    TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                    TabContent.Append("Hiển thị");
                    TabContent.Append(":</td><td>");
                    TabContent.AppendFormat("<input pluginField=\"Display\" type=\"checkbox\" {0} />"
                                            , Mdl.Attributes["Display"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                    TabContent.Append("</td></tr>");
                    #endregion
                    #region Viền
                    TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                    TabContent.Append("Viền");
                    TabContent.Append(":</td><td>");
                    TabContent.AppendFormat("<input pluginField=\"ShowBorder\" type=\"checkbox\" {0} />"
                                            , Mdl.Attributes["ShowBorder"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                    TabContent.Append("</td></tr>");
                    #endregion
                    #region Hiện Tiêu đề
                    TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                    TabContent.Append("Tiêu đề");
                    TabContent.Append(":</td><td>");
                    TabContent.AppendFormat("<input pluginField=\"ShowHeader\" type=\"checkbox\" {0} />"
                                            , Mdl.Attributes["ShowHeader"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                    TabContent.Append("</td></tr>");
                    #endregion
                    #region Chân Module
                    TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                    TabContent.Append("Chân");
                    TabContent.Append(":</td><td>");
                    TabContent.AppendFormat("<input pluginField=\"ShowFoot\" type=\"checkbox\" {0} />"
                                            , Mdl.Attributes["ShowFoot"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");

                    TabContent.Append("</td></tr>");
                    #endregion
                    #region Hạn chế
                    TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                    TabContent.Append("Hạn chế");
                    TabContent.Append(":</td><td>");
                    TabContent.AppendFormat("<input pluginField=\"Public\"  type=\"checkbox\" {0} />"
                                            , Mdl.Attributes["Public"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                    TabContent.Append("</td></tr>");
                    #endregion
                    #region IsCached
                    TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                    TabContent.Append("Cache");
                    TabContent.Append(":</td><td>");
                    TabContent.AppendFormat("<input pluginField=\"IsCached\"  type=\"checkbox\" {0} />"
                                            , Mdl.Attributes["IsCached"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                    TabContent.Append("</td></tr>");
                    #endregion                    
                    #region IsShared
                    TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                    TabContent.Append("Chia sẻ");
                    TabContent.Append(":</td><td>");
                    TabContent.AppendFormat("<input pluginField=\"IsShared\"  type=\"checkbox\" {0} />"
                                            , Mdl.Attributes["IsShared"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                    TabContent.Append("</td></tr>");
                    #endregion
                    TabContent.Append("</table>");
                    TabContent = new StringBuilder();
                    #endregion
                    #region Tab
                    foreach (XmlNode Tab in ModuleSettings.ChildNodes)
                    {

                        #region EditContent
                        TabContent.Append("<table style=\"width: 100%;\" cellspacing=\"4\">");
                        /// PluginCss
                        #region PluginCss
                        TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                        TabContent.Append("PluginCss");
                        TabContent.Append(":</td><td>");
                        TabContent.AppendFormat("<input pluginField=\"PluginCss\" class=\"Module_Edit_Title\" type=\"text\" value=\"{0}\" />"
                            , PluginCss);
                        TabContent.Append("</td></tr>");
                        #endregion

                        foreach (XmlNode ModuleSetting in Tab.ChildNodes)
                        {
                            #region Dòng
                            TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                            TabContent.Append(ModuleSetting.Attributes["Title"].Value);
                            TabContent.Append(":</td><td>");

                            string ModuleSettingType = ModuleSetting.Attributes["Type"].Value.ToLower();

                            #region Gán giá trị cho các Setting
                            if (ModuleSetting.ChildNodes.Count > 1) // Có nhiều lựa chọn
                            {
                                #region Nếu setting dạng select
                                TabContent.AppendFormat("<select pluginField=\"{0}\" class=\"{0}\">"
                                    , ModuleSetting.Attributes["Key"].Value);
                                foreach (XmlNode ModuleSettingItem in ModuleSetting.ChildNodes)
                                {
                                    if (ModuleSettingItem.Attributes["Select"].Value.ToLower() == "true")
                                    {
                                        TabContent.AppendFormat("<option value=\"{1}\" selected=\"selected\">{0}</option>"
                                        , ModuleSettingItem.InnerText
                                        , ModuleSettingItem.Attributes["Value"].Value);
                                    }
                                    else
                                    {
                                        TabContent.AppendFormat("<option value=\"{1}\">{0}</option>"
                                        , ModuleSettingItem.InnerText
                                         , ModuleSettingItem.Attributes["Value"].Value);
                                    }

                                }
                                TabContent.Append("</select>");
                                #endregion

                            }
                            else
                            {
                                switch (ModuleSettingType)
                                {
                                    case "boolean":
                                        TabContent.AppendFormat("<input pluginField=\"{1}\" class=\"{1}\" type=\"checkbox\" {0} />"
                                            , ModuleSetting.InnerText.ToLower() == "true" ? "checked=\"checked\"" : ""
                                            , ModuleSetting.Attributes["Key"].Value);
                                        break;
                                    case "html":
                                        TabContent.AppendFormat("<textarea id=\"{2}\" pluginField=\"{1}\" type=\"html\" class=\"Module_Edit_TextArea\" >{0}</textarea>"
                                                                   , ModuleSetting.InnerText
                                                                   , ModuleSetting.Attributes["Key"].Value
                                                                   , Guid.NewGuid().ToString().Replace("-", ""));
                                        break;
                                    default:
                                        TabContent.AppendFormat("<input id=\"{2}\" pluginField=\"{1}\" type=\"text\" class=\"Module_Edit_Text\" value=\"{0}\" />"
                                                                   , ModuleSetting.InnerText
                                                                   , ModuleSetting.Attributes["Key"].Value
                                                                   , Guid.NewGuid().ToString().Replace("-", ""));
                                        break;
                                }
                            }
                            #endregion


                            TabContent.Append("</td></tr>");
                            #endregion
                        }
                        TabContent.Append("</table>");

                        #endregion

                    }
                    #endregion
                    sb.Append(TabContent);
                    #endregion
                }
                else// module hạn chế truy cập nội dung
                {
                    #region Noi dung
                    sb.Append("\nBạn không đủ quyền xem nội dung này");
                    #endregion
                }

            }
            sb.AppendFormat("\r\n<!-- End {0} -->\n\n", ModuleTitle);


            #endregion
            return sb.ToString();
        }
        /// <summary>
        /// Trả Plugin về dạng HTML  với các thiết lập đã có sẵn
        /// </summary>
        /// <param name="_IPlug">IPlug: Plugin đã được cài đặt sẵn các thuộc tính</param>
        /// <returns>Dữ liệu dạng HTML</returns>
        public static string RenderHtml(IPlug _IPlug)
        {
            if (_IPlug == null) return string.Empty;
            Page pageHolder = new Page();
            UserControl uc = (UserControl)(_IPlug);
            pageHolder.Controls.Add(uc);
            StringWriter sw = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, sw, true);
            return sw.ToString();
        }
        /// <summary>
        /// Trả về Plugin dạng HTML với các thiết đặt ban đầu
        /// </summary>
        /// <param name="_IPlugType"></param>
        /// <returns></returns>
        public static string RenderHtml(string _IPlugType)
        {
            if (_IPlugType == null) return string.Empty;
            Type type = Type.GetType(_IPlugType);
            IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
            _IPlug.ImportPlugin();
            //_IPlug.KhoiTao(DAL.con());
            Page pageHolder = new Page();
            UserControl uc = (UserControl)(_IPlug);
            pageHolder.Controls.Add(uc);
            StringWriter sw = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, sw, true);
            return sw.ToString();
        }
        /// <summary>
        /// Trả Plugin về dạng HTML với kiểu Plugin và các cài đặt dạng Object[] kèm theo
        /// </summary>
        /// <param name="_IPlugType">String: Tên kiểu Plugin</param>
        /// <param name="obj">Object[]: Mảng dạng Object chứa các cài đặt</param>
        /// <returns></returns>
        public static string RenderHtml(string _IPlugType, object[] obj)
        {
            if (_IPlugType == null) return string.Empty;
            Type type = Type.GetType(_IPlugType);
            IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
            _IPlug.LoadSetting(obj);
            Page pageHolder = new Page();
            UserControl uc = (UserControl)(_IPlug);
            pageHolder.Controls.Add(uc);
            StringWriter sw = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, sw, true);
            return sw.ToString();
        }
        /// <summary>
        /// Trả Plugin về dạng HTML với kiểu Plugin và các cài đặt dạng XMLNode kèm theo
        /// </summary>
        /// <param name="_IPlugType">String: Tên kiểu Plugin</param>
        /// <param name="SettingNode">XMLNode: Node chức các cài đặt</param>
        /// <returns></returns>
        public static string RenderHtml(string _IPlugType, XmlNode SettingNode)
        {
            if (_IPlugType == null) return string.Empty;
            string XmlSourcePath = SettingNode.Attributes["XmlSourcePath"].Value;
            bool IsCached = Convert.ToBoolean(SettingNode.Attributes["IsCached"].Value);
            bool IsShared = Convert.ToBoolean(SettingNode.Attributes["IsShared"].Value);
            string PluginClientId = SettingNode.Attributes["PluginClientId"].Value;
            //if (IsShared)
            //{
            //    XmlDocument docShared = new XmlDocument();
            //    docShared.Load(HttpContext.Current.Server.MapPath(XmlSourcePath));
            //    if (File.Exists(HttpContext.Current.Server.MapPath(XmlSourcePath))) SettingNode = docShared.LastChild;
            //}
            //if (IsCached)
            //{
            //    string cacheKey = string.Format("Plugin-{0}", PluginClientId);
            //    object obj = HttpContext.Current.Cache[cacheKey];
            //    string depFile = SettingNode.BaseURI.Substring(SettingNode.BaseURI.IndexOf("///") + 3, SettingNode.BaseURI.Length - SettingNode.BaseURI.IndexOf("///") - 3);
            //    CacheDependency dep = new CacheDependency(depFile);
            //    if (obj == null)
            //    {
            //        Type type = Type.GetType(_IPlugType);
            //        IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
            //        Page pageHolder = new Page();
            //        _IPlug.LoadSetting(SettingNode);
            //        UserControl uc = (UserControl)(_IPlug);
            //        pageHolder.Controls.Add(uc);
            //        StringWriter sw = new StringWriter();
            //        HttpContext.Current.Server.Execute(pageHolder, sw, true);
            //        HttpContext.Current.Cache.Insert(cacheKey, sw.ToString(), dep);
            //        return sw.ToString();
            //    }
            //    return obj.ToString();
            //}
            //else
            //{
                Type type = Type.GetType(_IPlugType);
                IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
                Page pageHolder = new Page();
                _IPlug.LoadSetting(SettingNode);
                UserControl uc = (UserControl)(_IPlug);
                pageHolder.Controls.Add(uc);
                StringWriter sw = new StringWriter();
                HttpContext.Current.Server.Execute(pageHolder, sw, true);
                return sw.ToString();
            //}
            
        }
        public static string RenderHtml(XmlNode Mdl,Int32 layPlugId)
        {
            StringBuilder sb = new StringBuilder();
            #region Module
            bool LoggedIn = true;
            #region Nạp biến Module
            bool IsShared = Convert.ToBoolean(Mdl.Attributes["IsShared"].Value);
            string XmlSourcePath = Mdl.Attributes["XmlSourcePath"].Value;
            //if (IsShared)
            //{
            //    XmlDocument docShared = new XmlDocument();
            //    docShared.Load(HttpContext.Current.Server.MapPath(XmlSourcePath));
            //    if (File.Exists(HttpContext.Current.Server.MapPath(XmlSourcePath))) Mdl = docShared.LastChild;

            //}
            string ModuleTitle = Mdl.Attributes["Title"].Value;
            string PluginClientId = Mdl.Attributes["PluginClientId"].Value;
            string PluginIndex = Mdl.Attributes["PluginIndex"].Value;
            string PluginId = Mdl.Attributes["ID"].Value;
            string ModuleType = Mdl.Attributes["PluginType"].Value;
            bool ModuleDisplay = Convert.ToBoolean(Mdl.Attributes["Display"].Value);
            bool ShowBorder = Convert.ToBoolean(Mdl.Attributes["ShowBorder"].Value);
            bool ShowHeader = Convert.ToBoolean(Mdl.Attributes["ShowHeader"].Value);
            bool ShowFoot = Convert.ToBoolean(Mdl.Attributes["ShowFoot"].Value);
            bool ModulePublic = Convert.ToBoolean(Mdl.Attributes["Public"].Value);
            string PluginIcon = Mdl.Attributes["PluginIcon"].Value;

            #endregion


            sb.AppendFormat("\r\n\n<!-- Plugin {0} -->", ModuleTitle);
            sb.AppendFormat("\n<div moduleIndex=\"{2}\" plugtype=\"{4}\" layplug=\"{3}\" zoneIndex=\"{0}\" style=\"{1}\" class=\"Module ui-widget ui-widget-content ui-corner-all\">"
                    , ""
                    //, (ModuleDisplay ? (ShowBorder) : false) || LoggedIn ? "border: solid;" : ""
                    , (ModuleDisplay ? (ShowBorder) : false) || LoggedIn ? "" : ""
                    , ""
                    , layPlugId
                    , ModuleType);
            if (ModuleDisplay || LoggedIn)
            {
                if (ModulePublic || LoggedIn)// Nếu Module không hạn chế truy cập nội dung
                {
                    if (ShowHeader || LoggedIn)// Module hiện tiêu đề
                    {
                        #region Head
                        sb.AppendFormat("\n<div class=\"Module_Head ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix\">"
                           , "");
                        if (LoggedIn)
                        {
                            #region Tác vụ
                            sb.AppendFormat("<div class=\"Module_Task\">");
                            //sb.AppendFormat("<a href=\"javascript:;\" class=\"Module_Task_Link Module_Task_Edit\"><span class=\"ui-icon ui-icon-gear\"></span></a>", "");
                            //sb.AppendFormat("<a href=\"javascript:;\" class=\"Module_Task_Link Module_Task_Maximize\"><span class=\"ui-icon ui-icon-circle-triangle-n\"></span></a>", "");
                            //sb.AppendFormat("<a href=\"javascript:;\" class=\"Module_Task_Link Module_Task_Close\"><span class=\"ui-icon ui-icon-circle-close\"></span></a>", "");
                            sb.AppendFormat("<a href=\"javascript:;\" class=\"Module_Task_Link Module_Task_Edit\">Sửa</a>", "");
                            sb.AppendFormat("<a href=\"javascript:;\" class=\"Module_Task_Link Module_Task_Maximize\">Thu nhỏ</a>", "");
                            sb.AppendFormat("<a href=\"javascript:;\" class=\"Module_Task_Link Module_Task_Close\">Xóa</a>", "");
                            sb.Append("</div>");
                            #endregion
                        }

                        #region Tên Module
                        sb.AppendFormat("<a href=\"javascript:;\" class=\"Module_Title\">{0}</a>"
                            , ModuleTitle);
                        sb.Append("</div>");
                        #endregion
                        #endregion
                    }
                    if (LoggedIn)//Cài đặt của Module
                    {
                        #region Setting


                        XmlNode ModuleSettings = Mdl.ChildNodes[0];
                        sb.AppendFormat("\r\n<div class=\"Module_Edit\">"
                           , "");

                        StringBuilder TabContent = new StringBuilder();

                        #region Cài đặt chung
                        XmlNode ModuleSercurity = Mdl.LastChild;
                        TabContent.Append("<div name=\"PublicSettings\" class=\"Module_Edit_ContentBox Module_Edit_ContentBoxShow\">");
                        TabContent.Append("<table style=\"width: 100%;\" cellspacing=\"4\">");
                        #region Tên Module
                        TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                        TabContent.Append("Tên");
                        TabContent.Append(":</td><td>");
                        TabContent.AppendFormat("<input pluginField=\"Title\" class=\"Module_Edit_Title\" type=\"text\" value=\"{0}\" />"
                            , ModuleTitle);
                        TabContent.Append("</td></tr>");
                        #endregion
                        #region Hiển thị
                        TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                        TabContent.Append("Hiển thị");
                        TabContent.Append(":</td><td>");
                        TabContent.AppendFormat("<input pluginField=\"Display\" type=\"checkbox\" {0} />"
                                                , Mdl.Attributes["Display"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                        TabContent.Append("</td></tr>");
                        #endregion
                        #region Viền
                        TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                        TabContent.Append("Viền");
                        TabContent.Append(":</td><td>");
                        TabContent.AppendFormat("<input pluginField=\"ShowBorder\" type=\"checkbox\" {0} />"
                                                , Mdl.Attributes["ShowBorder"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                        TabContent.Append("</td></tr>");
                        #endregion
                        #region Hiện Tiêu đề
                        TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                        TabContent.Append("Tiêu đề");
                        TabContent.Append(":</td><td>");
                        TabContent.AppendFormat("<input pluginField=\"ShowHeader\" type=\"checkbox\" {0} />"
                                                , Mdl.Attributes["ShowHeader"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                        TabContent.Append("</td></tr>");
                        #endregion
                        #region Chân Module
                        TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                        TabContent.Append("Chân");
                        TabContent.Append(":</td><td>");
                        TabContent.AppendFormat("<input pluginField=\"ShowFoot\" type=\"checkbox\" {0} />"
                                                , Mdl.Attributes["ShowFoot"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");

                        TabContent.Append("</td></tr>");
                        #endregion
                        #region Hạn chế
                        TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                        TabContent.Append("Hạn chế");
                        TabContent.Append(":</td><td>");
                        TabContent.AppendFormat("<input pluginField=\"Public\"  type=\"checkbox\" {0} />"
                                                , Mdl.Attributes["Public"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                        TabContent.Append("</td></tr>");
                        #endregion
                        #region IsCached
                        TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                        TabContent.Append("Cache");
                        TabContent.Append(":</td><td>");
                        TabContent.AppendFormat("<input pluginField=\"IsCached\"  type=\"checkbox\" {0} />"
                                                , Mdl.Attributes["IsCached"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                        TabContent.Append("</td></tr>");
                        #endregion
                        #region IsShared
                        TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                        TabContent.Append("Chia sẻ");
                        TabContent.Append(":</td><td>");
                        TabContent.AppendFormat("<input pluginField=\"IsShared\"  type=\"checkbox\" {0} />"
                                                , Mdl.Attributes["IsShared"].Value.ToLower() == "true" ? "checked=\"checked\"" : "");
                        TabContent.Append("</td></tr>");
                        #endregion
                        TabContent.Append("</table>");
                        TabContent.Append("</div>");
                        #endregion

                        #region Tab
                        sb.AppendFormat("<div class=\"Module_Edit_Tab\">"
                          , "");
                        sb.Append("<a href=\"javascript:;\" rev=\"PublicSettings\" class=\"Module_Edit_TabBtn Module_Edit_Tab_Active\">Chung</a>");
                        foreach (XmlNode Tab in ModuleSettings.ChildNodes)
                        {
                            sb.AppendFormat("<a href=\"javascript:;\" rev=\"{1}\" class=\"Module_Edit_TabBtn Module_Edit_Tab_DeActive\">{0}</a>"
                                , Tab.Attributes["Name"].Value
                                , Tab.Attributes["ID"].Value);

                            #region EditContent
                            TabContent.AppendFormat("<div name=\"{0}\" class=\"Module_Edit_ContentBox\">"
                          , Tab.Attributes["ID"].Value);

                            TabContent.Append("<table style=\"width: 100%;\" cellspacing=\"4\">");
                            foreach (XmlNode ModuleSetting in Tab.ChildNodes)
                            {
                                #region Dòng
                                TabContent.Append(" <tr><td style=\"width: 100px;text-align: right;\" valign=\"top\">");
                                TabContent.Append(ModuleSetting.Attributes["Title"].Value);
                                TabContent.Append(":</td><td>");

                                string ModuleSettingType = ModuleSetting.Attributes["Type"].Value.ToLower();

                                #region Gán giá trị cho các Setting
                                if (ModuleSetting.ChildNodes.Count > 1) // Có nhiều lựa chọn
                                {
                                    #region Nếu setting dạng select
                                    TabContent.AppendFormat("<select pluginField=\"{0}\" class=\"{0}\">"
                                        , ModuleSetting.Attributes["Key"].Value);
                                    foreach (XmlNode ModuleSettingItem in ModuleSetting.ChildNodes)
                                    {
                                        if (ModuleSettingItem.Attributes["Select"].Value.ToLower() == "true")
                                        {
                                            TabContent.AppendFormat("<option value=\"{1}\" selected=\"selected\">{0}</option>"
                                            , ModuleSettingItem.InnerText
                                            , ModuleSettingItem.Attributes["Value"].Value);
                                        }
                                        else
                                        {
                                            TabContent.AppendFormat("<option value=\"{1}\">{0}</option>"
                                            , ModuleSettingItem.InnerText
                                             , ModuleSettingItem.Attributes["Value"].Value);
                                        }

                                    }
                                    TabContent.Append("</select>");
                                    #endregion

                                }
                                else
                                {
                                    switch (ModuleSettingType)
                                    {
                                        case "boolean":
                                            TabContent.AppendFormat("<input pluginField=\"{1}\" class=\"{1}\" type=\"checkbox\" {0} />"
                                                , ModuleSetting.InnerText.ToLower() == "true" ? "checked=\"checked\"" : ""
                                                , ModuleSetting.Attributes["Key"].Value);
                                            break;
                                        case "html":
                                            TabContent.AppendFormat("<textarea id=\"{2}\" pluginField=\"{1}\" class=\"Module_Edit_TextArea\" >{0}</textarea>"
                                                                       , ModuleSetting.InnerText
                                                                       , ModuleSetting.Attributes["Key"].Value
                                                                       , Guid.NewGuid().ToString().Replace("-", ""));
                                            break;
                                        default:
                                            TabContent.AppendFormat("<input id=\"{2}\" pluginField=\"{1}\" class=\"Module_Edit_Text\" value=\"{0}\" />"
                                                                       , ModuleSetting.InnerText
                                                                       , ModuleSetting.Attributes["Key"].Value
                                                                       , Guid.NewGuid().ToString().Replace("-", ""));
                                            break;
                                    }
                                }
                                #endregion


                                TabContent.Append("</td></tr>");
                                #endregion
                            }
                            TabContent.Append("</table>");

                            TabContent.Append("</div>");
                            #endregion

                        }
                        sb.Append("</div>");
                        #endregion

                        #region Nội dung tab xử lý phần trên
                        sb.AppendFormat("<div name=\"\" class=\"Module_Edit_Content\">"
                          , "");
                        sb.Append(TabContent);
                        sb.Append("</div>");
                        #endregion

                        #region Lưu cài đặt
                        sb.Append("</div>");
                        sb.AppendFormat("<div class=\"Module_Save\">"
                           , "");
                        sb.AppendFormat("<a Pages=\"{2}\" rev=\"{0}\" rel=\"{1}\" title=\"Lưu lại cài đặt của Module\" href=\"javascript:;\" class=\"Module_EditBtn Module_EditBtnSave\">Lưu</a>"
                            , ""
                            , ""
                            , "");
                        sb.AppendFormat("<a title=\"Đóng ô cài đặt lại\" href=\"javascript:;\" class=\"Module_EditBtn Module_EditBtnCancel\">Đóng lại</a>"
                            , "");
                        sb.Append("</div>");
                        #endregion

                        #endregion
                    }

                    #region Noi dung
                    sb.AppendFormat("\n<div class=\"Module_Body ui-accordion-content\">"
                        , "");
                    sb.Append(PlugHelper.RenderHtml(ModuleType, Mdl));
                    sb.Append("</div>");
                    #endregion

                    if (ShowFoot || LoggedIn)// Hiển thị chân trang
                    {
                        #region Foot
                        sb.AppendFormat("\n<div class=\"Module_Foot\">"
                            , "");
                        sb.Append("</div>");
                        #endregion
                    }
                }
                else// module hạn chế truy cập nội dung
                {
                    #region Noi dung
                    sb.Append("\n<div class=\"Module_Body\">Bạn không đủ quyền xem nội dung này");
                    sb.Append("</div>");
                    #endregion
                }

            }
            sb.Append("\n</div>");
            sb.AppendFormat("\r\n<!-- End {0} -->\n\n", ModuleTitle);


            #endregion
            return sb.ToString();
        }
        /// <summary>
        /// Trả Plugin về dạng HTML với Plugin và các cài đặt dạng Object[] kèm theo
        /// </summary>
        /// <param name="_IPlug">IPlug: Plugin </param>
        /// <param name="obj">Object[]: Mảng dạng Object chứa các cài đặt</param>
        /// <returns></returns>
        public static string RenderHtml(IPlug _IPlug, object[] obj)
        {
            if (_IPlug == null) return string.Empty;
            _IPlug.LoadSetting(obj);
            Page pageHolder = new Page();
            UserControl uc = (UserControl)(_IPlug);
            pageHolder.Controls.Add(uc);
            StringWriter sw = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, sw, true);
            return sw.ToString();
        }
        /// <summary>
        /// Trả Plugin về dạng HTML với Plugin và các cài đặt dạng XMLNode kèm theo
        /// </summary>
        /// <param name="_IPlug">IPlug: Plugin </param>
        /// <param name="SettingNode">XMLNode: Node chức các cài đặt</param>
        /// <returns></returns>
        public static string RenderHtml(IPlug _IPlug, XmlNode SettingNode)
        {
            if (_IPlug == null) return string.Empty;
            Page pageHolder = new Page();
            _IPlug.LoadSetting(SettingNode);
            UserControl uc = (UserControl)(_IPlug);
            pageHolder.Controls.Add(uc);
            StringWriter sw = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, sw, true);
            return sw.ToString();
        }
        public static string RenderHtml(XmlDocument doc)
        {
            if (doc == null) return string.Empty;
            string _PluginType = doc.LastChild.Attributes["PluginType"].Value;
            Type type = Type.GetType(_PluginType);
            IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
            Page pageHolder = new Page();
            _IPlug.LoadSetting(doc.LastChild);
            UserControl uc = (UserControl)(_IPlug);
            pageHolder.Controls.Add(uc);
            StringWriter sw = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, sw, true);
            return sw.ToString();
        }

        /// <summary>
        /// Trả về dạng XML với một Plugin có sẵn cài đặt mặc định (Thường khi Import Plugin từ DLL)
        /// </summary>
        /// <param name="_IPlug">IPlug: Plugin</param>
        /// <returns>XMLNode</returns>
        public static XmlNode RenderXml(IPlug _IPlug)
        {
            XmlDocument doc = new XmlDocument();

            XmlNode root = doc.CreateNode(XmlNodeType.XmlDeclaration, null, null);
            doc.AppendChild(root);
            // Root element: PluginNode
            XmlElement PluginNode = doc.CreateElement("Plugin");
            doc.AppendChild(PluginNode);

            #region Thuộc tính của Plugin
            XmlAttribute PluginNodePluginType = doc.CreateAttribute("PluginType");
            PluginNodePluginType.Value = _IPlug.PluginType;
            PluginNode.Attributes.Append(PluginNodePluginType);

            XmlAttribute PluginNodeID = doc.CreateAttribute("ID");
            PluginNodeID.Value = _IPlug.PluginId;
            PluginNode.Attributes.Append(PluginNodeID);

            XmlAttribute PluginNodePluginClientId = doc.CreateAttribute("PluginClientId");
            PluginNodePluginClientId.Value = _IPlug.PluginClientId;
            PluginNode.Attributes.Append(PluginNodePluginClientId);

            XmlAttribute PluginNodePluginIndex = doc.CreateAttribute("PluginIndex");
            PluginNodePluginIndex.Value = _IPlug.PluginIndex;
            PluginNode.Attributes.Append(PluginNodePluginIndex);

            XmlAttribute PluginNodeZoneIndex = doc.CreateAttribute("ZoneIndex");
            PluginNodeZoneIndex.Value = _IPlug.ZoneIndex;
            PluginNode.Attributes.Append(PluginNodeZoneIndex);

            XmlAttribute PluginNodeTitle = doc.CreateAttribute("Title");
            PluginNodeTitle.Value = _IPlug.Title;
            PluginNode.Attributes.Append(PluginNodeTitle);

            

            XmlAttribute PluginNodePluginIcon = doc.CreateAttribute("PluginIcon");
            PluginNodePluginIcon.Value = _IPlug.PluginIcon;
            PluginNode.Attributes.Append(PluginNodePluginIcon);

            XmlAttribute PluginNodeDisplay = doc.CreateAttribute("Display");
            PluginNodeDisplay.Value = _IPlug.Display.ToString();
            PluginNode.Attributes.Append(PluginNodeDisplay);

            XmlAttribute PluginNodeShowBorder = doc.CreateAttribute("ShowBorder");
            PluginNodeShowBorder.Value = _IPlug.ShowBorder.ToString();
            PluginNode.Attributes.Append(PluginNodeShowBorder);

            XmlAttribute PluginNodeShowHeader = doc.CreateAttribute("ShowHeader");
            PluginNodeShowHeader.Value = _IPlug.ShowHeader.ToString();
            PluginNode.Attributes.Append(PluginNodeShowHeader);

            XmlAttribute PluginNodeShowFoot = doc.CreateAttribute("ShowFoot");
            PluginNodeShowFoot.Value = _IPlug.ShowFoot.ToString();
            PluginNode.Attributes.Append(PluginNodeShowFoot);

            XmlAttribute PluginNodePublic = doc.CreateAttribute("Public");
            PluginNodePublic.Value = _IPlug.Public.ToString();
            PluginNode.Attributes.Append(PluginNodePublic);

            XmlAttribute PluginNodeXmlSourcePath = doc.CreateAttribute("XmlSourcePath");
            PluginNodeXmlSourcePath.Value = _IPlug.XmlSourcePath;
            PluginNode.Attributes.Append(PluginNodeXmlSourcePath);

            XmlAttribute PluginNodeIsCached = doc.CreateAttribute("IsCached");
            PluginNodeIsCached.Value = _IPlug.IsCached.ToString();
            PluginNode.Attributes.Append(PluginNodeIsCached);

            XmlAttribute PluginNodeIsCp = doc.CreateAttribute("IsCp");
            PluginNodeIsCp.Value = _IPlug.IsCp.ToString();
            PluginNode.Attributes.Append(PluginNodeIsCp);

            XmlAttribute PluginNodeIsInvisible = doc.CreateAttribute("IsInvisible");
            PluginNodeIsInvisible.Value = _IPlug.IsInvisible.ToString();
            PluginNode.Attributes.Append(PluginNodeIsInvisible);

            XmlAttribute PluginNodeIsShared = doc.CreateAttribute("IsShared");
            PluginNodeIsShared.Value = _IPlug.IsShared.ToString();
            PluginNode.Attributes.Append(PluginNodeIsShared);
            #endregion

            #region Thuộc tính khác
            XmlElement PluginSettings = doc.CreateElement("ModuleSettings");
            PluginNode.AppendChild(PluginSettings);
            foreach (ModuleSetingTab Tab in _IPlug.Tabs)
            {

                #region Thuộc tính cơ bản của SettingTab
                XmlElement TabElement = doc.CreateElement("ModuleSettingTabs");
                PluginSettings.AppendChild(TabElement);

                XmlAttribute TabID = doc.CreateAttribute("ID");
                TabID.Value = Tab.TabId.ToString();
                TabElement.Attributes.Append(TabID);

                XmlAttribute TabName = doc.CreateAttribute("Name");
                TabName.Value = Tab.Name;
                TabElement.Attributes.Append(TabName);

                XmlAttribute TabIndex = doc.CreateAttribute("Index");
                TabIndex.Value = Tab.Index.ToString();
                TabElement.Attributes.Append(TabIndex);
                #endregion

                #region Setting
                foreach (ModuleSetting Setting in Tab.Settings)
                {
                    XmlElement SettingElement = doc.CreateElement("ModuleSetting");
                    TabElement.AppendChild(SettingElement);

                    XmlAttribute SettingKey = doc.CreateAttribute("Key");
                    SettingKey.Value = Setting.Key;
                    SettingElement.Attributes.Append(SettingKey);

                    XmlAttribute SettingTitle = doc.CreateAttribute("Title");
                    SettingTitle.Value = Setting.Title;
                    SettingElement.Attributes.Append(SettingTitle);

                    XmlAttribute SettingType = doc.CreateAttribute("Type");
                    SettingType.Value = Setting.Type;
                    SettingElement.Attributes.Append(SettingType);
                    #region Value
                    if (Setting.Childrens != null) // Kiểm tra xem giá trị này có nhiều lựa chọn không
                    {
                        foreach (ModuleSettingItem SettingItem in Setting.Childrens)
                        {
                            XmlElement SettingItemElement = doc.CreateElement("ModuleSettingItem");
                            SettingElement.AppendChild(SettingItemElement);

                            XmlAttribute SettingItemElementSelect = doc.CreateAttribute("Select");
                            SettingItemElementSelect.Value = SettingItem.Value == Setting.Value ? "True" : "False";
                            SettingItemElement.Attributes.Append(SettingItemElementSelect);

                            XmlAttribute SettingItemElementValue = doc.CreateAttribute("Value");
                            SettingItemElementValue.Value = SettingItem.Value;
                            SettingItemElement.Attributes.Append(SettingItemElementValue);

                            XmlNode SettingItemElementHtml = doc.CreateCDataSection(SettingItem.Html);
                            SettingItemElement.AppendChild(SettingItemElementHtml);
                        }
                    }
                    else
                    {
                        XmlNode SettingValue = doc.CreateCDataSection(Setting.Value);
                        SettingElement.AppendChild(SettingValue);

                    }
                    #endregion

                }
                #endregion

            }
            #endregion

            #region ModuleSercurity

            if (_IPlug.Users != null)
            {
                XmlElement PluginSercurity = doc.CreateElement("Sercurity");
                PluginNode.AppendChild(PluginSercurity);
                foreach (ModuleSercurityUser User in _IPlug.Users)
                {
                    XmlElement PluginSercurityUser = doc.CreateElement("User");
                    PluginSercurity.AppendChild(PluginSercurityUser);

                    XmlAttribute PluginSercurityUserName = doc.CreateAttribute("Name");
                    PluginSercurityUserName.Value = User.Username;
                    PluginSercurityUser.Attributes.Append(PluginSercurityUserName);

                    XmlAttribute PluginSercurityPermision = doc.CreateAttribute("Permision");
                    PluginSercurityPermision.Value = User.Permision.ToString();
                    PluginSercurityUser.Attributes.Append(PluginSercurityPermision);
                }
            }

            #endregion

            return PluginNode;
        }
        public static XmlNode RenderXml(string _IPlugType)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateNode(XmlNodeType.XmlDeclaration, null, null);
            doc.AppendChild(root);
            // Root element: PluginNode
            XmlElement PluginNode = doc.CreateElement("Plugin");
            doc.AppendChild(PluginNode);
            if (_IPlugType == null) return doc;
            Type type = Type.GetType(_IPlugType);
            IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
            _IPlug.ImportPlugin();
            #region Thuộc tính của Plugin
            XmlAttribute PluginNodePluginType = doc.CreateAttribute("PluginType");
            PluginNodePluginType.Value = _IPlug.PluginType;
            PluginNode.Attributes.Append(PluginNodePluginType);

            XmlAttribute PluginNodeID = doc.CreateAttribute("ID");
            PluginNodeID.Value = _IPlug.PluginId;
            PluginNode.Attributes.Append(PluginNodeID);

            XmlAttribute PluginNodePluginClientId = doc.CreateAttribute("PluginClientId");
            PluginNodePluginClientId.Value = _IPlug.PluginClientId;
            PluginNode.Attributes.Append(PluginNodePluginClientId);

            XmlAttribute PluginNodePluginIndex = doc.CreateAttribute("PluginIndex");
            PluginNodePluginIndex.Value = _IPlug.PluginIndex;
            PluginNode.Attributes.Append(PluginNodePluginIndex);

            XmlAttribute PluginNodeZoneIndex = doc.CreateAttribute("ZoneIndex");
            PluginNodeZoneIndex.Value = _IPlug.ZoneIndex;
            PluginNode.Attributes.Append(PluginNodeZoneIndex);

            XmlAttribute PluginNodeTitle = doc.CreateAttribute("Title");
            PluginNodeTitle.Value = _IPlug.Title;
            PluginNode.Attributes.Append(PluginNodeTitle);



            XmlAttribute PluginNodePluginIcon = doc.CreateAttribute("PluginIcon");
            PluginNodePluginIcon.Value = _IPlug.PluginIcon;
            PluginNode.Attributes.Append(PluginNodePluginIcon);

            XmlAttribute PluginNodeDisplay = doc.CreateAttribute("Display");
            PluginNodeDisplay.Value = _IPlug.Display.ToString();
            PluginNode.Attributes.Append(PluginNodeDisplay);

            XmlAttribute PluginNodeShowBorder = doc.CreateAttribute("ShowBorder");
            PluginNodeShowBorder.Value = _IPlug.ShowBorder.ToString();
            PluginNode.Attributes.Append(PluginNodeShowBorder);

            XmlAttribute PluginNodeShowHeader = doc.CreateAttribute("ShowHeader");
            PluginNodeShowHeader.Value = _IPlug.ShowHeader.ToString();
            PluginNode.Attributes.Append(PluginNodeShowHeader);

            XmlAttribute PluginNodeShowFoot = doc.CreateAttribute("ShowFoot");
            PluginNodeShowFoot.Value = _IPlug.ShowFoot.ToString();
            PluginNode.Attributes.Append(PluginNodeShowFoot);

            XmlAttribute PluginNodePublic = doc.CreateAttribute("Public");
            PluginNodePublic.Value = _IPlug.Public.ToString();
            PluginNode.Attributes.Append(PluginNodePublic);

            XmlAttribute PluginNodeXmlSourcePath = doc.CreateAttribute("XmlSourcePath");
            PluginNodeXmlSourcePath.Value = _IPlug.XmlSourcePath;
            PluginNode.Attributes.Append(PluginNodeXmlSourcePath);

            XmlAttribute PluginNodeIsCached = doc.CreateAttribute("IsCached");
            PluginNodeIsCached.Value = _IPlug.IsCached.ToString();
            PluginNode.Attributes.Append(PluginNodeIsCached);

            XmlAttribute PluginNodeIsCp = doc.CreateAttribute("IsCp");
            PluginNodeIsCp.Value = _IPlug.IsCp.ToString();
            PluginNode.Attributes.Append(PluginNodeIsCp);

            XmlAttribute PluginNodeIsInvisible = doc.CreateAttribute("IsInvisible");
            PluginNodeIsInvisible.Value = _IPlug.IsInvisible.ToString();
            PluginNode.Attributes.Append(PluginNodeIsInvisible);

            XmlAttribute PluginNodeIsShared = doc.CreateAttribute("IsShared");
            PluginNodeIsShared.Value = _IPlug.IsShared.ToString();
            PluginNode.Attributes.Append(PluginNodeIsShared);
            #endregion
            #region Thuộc tính khác
            XmlElement PluginSettings = doc.CreateElement("ModuleSettings");
            PluginNode.AppendChild(PluginSettings);
            foreach (ModuleSetingTab Tab in _IPlug.Tabs)
            {

                #region Thuộc tính cơ bản của SettingTab
                XmlElement TabElement = doc.CreateElement("ModuleSettingTabs");
                PluginSettings.AppendChild(TabElement);

                XmlAttribute TabID = doc.CreateAttribute("ID");
                TabID.Value = Tab.TabId.ToString();
                TabElement.Attributes.Append(TabID);

                XmlAttribute TabName = doc.CreateAttribute("Name");
                TabName.Value = Tab.Name;
                TabElement.Attributes.Append(TabName);

                XmlAttribute TabIndex = doc.CreateAttribute("Index");
                TabIndex.Value = Tab.Index.ToString();
                TabElement.Attributes.Append(TabIndex);
                #endregion

                #region Setting
                foreach (ModuleSetting Setting in Tab.Settings)
                {
                    XmlElement SettingElement = doc.CreateElement("ModuleSetting");
                    TabElement.AppendChild(SettingElement);

                    XmlAttribute SettingKey = doc.CreateAttribute("Key");
                    SettingKey.Value = Setting.Key;
                    SettingElement.Attributes.Append(SettingKey);

                    XmlAttribute SettingTitle = doc.CreateAttribute("Title");
                    SettingTitle.Value = Setting.Title;
                    SettingElement.Attributes.Append(SettingTitle);

                    XmlAttribute SettingType = doc.CreateAttribute("Type");
                    SettingType.Value = Setting.Type;
                    SettingElement.Attributes.Append(SettingType);
                    #region Value
                    if (Setting.Childrens != null) // Kiểm tra xem giá trị này có nhiều lựa chọn không
                    {
                        foreach (ModuleSettingItem SettingItem in Setting.Childrens)
                        {
                            XmlElement SettingItemElement = doc.CreateElement("ModuleSettingItem");
                            SettingElement.AppendChild(SettingItemElement);

                            XmlAttribute SettingItemElementSelect = doc.CreateAttribute("Select");
                            SettingItemElementSelect.Value = SettingItem.Value == Setting.Value ? "True" : "False";
                            SettingItemElement.Attributes.Append(SettingItemElementSelect);

                            XmlAttribute SettingItemElementValue = doc.CreateAttribute("Value");
                            SettingItemElementValue.Value = SettingItem.Value;
                            SettingItemElement.Attributes.Append(SettingItemElementValue);

                            XmlNode SettingItemElementHtml = doc.CreateCDataSection(SettingItem.Html);
                            SettingItemElement.AppendChild(SettingItemElementHtml);
                        }
                    }
                    else
                    {
                        XmlNode SettingValue = doc.CreateCDataSection(Setting.Value);
                        SettingElement.AppendChild(SettingValue);

                    }
                    #endregion

                }
                #endregion

            }
            #endregion
            #region ModuleSercurity

            if (_IPlug.Users != null)
            {
                XmlElement PluginSercurity = doc.CreateElement("Sercurity");
                PluginNode.AppendChild(PluginSercurity);
                foreach (ModuleSercurityUser User in _IPlug.Users)
                {
                    XmlElement PluginSercurityUser = doc.CreateElement("User");
                    PluginSercurity.AppendChild(PluginSercurityUser);

                    XmlAttribute PluginSercurityUserName = doc.CreateAttribute("Name");
                    PluginSercurityUserName.Value = User.Username;
                    PluginSercurityUser.Attributes.Append(PluginSercurityUserName);

                    XmlAttribute PluginSercurityPermision = doc.CreateAttribute("Permision");
                    PluginSercurityPermision.Value = User.Permision.ToString();
                    PluginSercurityUser.Attributes.Append(PluginSercurityPermision);
                }
            }

            #endregion
            return PluginNode;
        }
        public static XmlNode RenderXml(object[] obj, string _IPlugType)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateNode(XmlNodeType.XmlDeclaration, null, null);
            doc.AppendChild(root);
            // Root element: PluginNode
            XmlElement PluginNode = doc.CreateElement("Plugin");
            doc.AppendChild(PluginNode);
            if (_IPlugType == null) return doc;
            Type type = Type.GetType(_IPlugType);
            IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
            _IPlug.LoadSetting(obj);
            _IPlug.ImportPlugin();
            #region Thuộc tính của Plugin
            XmlAttribute PluginNodePluginType = doc.CreateAttribute("PluginType");
            PluginNodePluginType.Value = _IPlug.PluginType;
            PluginNode.Attributes.Append(PluginNodePluginType);

            XmlAttribute PluginNodeID = doc.CreateAttribute("ID");
            PluginNodeID.Value = _IPlug.PluginId;
            PluginNode.Attributes.Append(PluginNodeID);

            XmlAttribute PluginNodePluginClientId = doc.CreateAttribute("PluginClientId");
            PluginNodePluginClientId.Value = _IPlug.PluginClientId;
            PluginNode.Attributes.Append(PluginNodePluginClientId);

            XmlAttribute PluginNodePluginIndex = doc.CreateAttribute("PluginIndex");
            PluginNodePluginIndex.Value = _IPlug.PluginIndex;
            PluginNode.Attributes.Append(PluginNodePluginIndex);

            XmlAttribute PluginNodeZoneIndex = doc.CreateAttribute("ZoneIndex");
            PluginNodeZoneIndex.Value = _IPlug.ZoneIndex;
            PluginNode.Attributes.Append(PluginNodeZoneIndex);

            XmlAttribute PluginNodeTitle = doc.CreateAttribute("Title");
            PluginNodeTitle.Value = _IPlug.Title;
            PluginNode.Attributes.Append(PluginNodeTitle);

            XmlAttribute PluginNodePluginCss = doc.CreateAttribute("PluginCss");
            PluginNodePluginCss.Value = _IPlug.PluginCss;
            PluginNode.Attributes.Append(PluginNodePluginCss);


            XmlAttribute PluginNodePluginIcon = doc.CreateAttribute("PluginIcon");
            PluginNodePluginIcon.Value = _IPlug.PluginIcon;
            PluginNode.Attributes.Append(PluginNodePluginIcon);

            XmlAttribute PluginNodeDisplay = doc.CreateAttribute("Display");
            PluginNodeDisplay.Value = _IPlug.Display.ToString();
            PluginNode.Attributes.Append(PluginNodeDisplay);

            XmlAttribute PluginNodeShowBorder = doc.CreateAttribute("ShowBorder");
            PluginNodeShowBorder.Value = _IPlug.ShowBorder.ToString();
            PluginNode.Attributes.Append(PluginNodeShowBorder);

            XmlAttribute PluginNodeShowHeader = doc.CreateAttribute("ShowHeader");
            PluginNodeShowHeader.Value = _IPlug.ShowHeader.ToString();
            PluginNode.Attributes.Append(PluginNodeShowHeader);

            XmlAttribute PluginNodeShowFoot = doc.CreateAttribute("ShowFoot");
            PluginNodeShowFoot.Value = _IPlug.ShowFoot.ToString();
            PluginNode.Attributes.Append(PluginNodeShowFoot);

            XmlAttribute PluginNodePublic = doc.CreateAttribute("Public");
            PluginNodePublic.Value = _IPlug.Public.ToString();
            PluginNode.Attributes.Append(PluginNodePublic);

            XmlAttribute PluginNodeXmlSourcePath = doc.CreateAttribute("XmlSourcePath");
            PluginNodeXmlSourcePath.Value = _IPlug.XmlSourcePath;
            PluginNode.Attributes.Append(PluginNodeXmlSourcePath);

            XmlAttribute PluginNodeIsCached = doc.CreateAttribute("IsCached");
            PluginNodeIsCached.Value = _IPlug.IsCached.ToString();
            PluginNode.Attributes.Append(PluginNodeIsCached);

            XmlAttribute PluginNodeIsCp = doc.CreateAttribute("IsCp");
            PluginNodeIsCp.Value = _IPlug.IsCp.ToString();
            PluginNode.Attributes.Append(PluginNodeIsCp);

            XmlAttribute PluginNodeIsInvisible = doc.CreateAttribute("IsInvisible");
            PluginNodeIsInvisible.Value = _IPlug.IsInvisible.ToString();
            PluginNode.Attributes.Append(PluginNodeIsInvisible);

            XmlAttribute PluginNodeIsShared = doc.CreateAttribute("IsShared");
            PluginNodeIsShared.Value = _IPlug.IsShared.ToString();
            PluginNode.Attributes.Append(PluginNodeIsShared);
            #endregion
            #region Thuộc tính khác
            XmlElement PluginSettings = doc.CreateElement("ModuleSettings");
            PluginNode.AppendChild(PluginSettings);
            foreach (ModuleSetingTab Tab in _IPlug.Tabs)
            {

                #region Thuộc tính cơ bản của SettingTab
                XmlElement TabElement = doc.CreateElement("ModuleSettingTabs");
                PluginSettings.AppendChild(TabElement);

                XmlAttribute TabID = doc.CreateAttribute("ID");
                TabID.Value = Tab.TabId.ToString();
                TabElement.Attributes.Append(TabID);

                XmlAttribute TabName = doc.CreateAttribute("Name");
                TabName.Value = Tab.Name;
                TabElement.Attributes.Append(TabName);

                XmlAttribute TabIndex = doc.CreateAttribute("Index");
                TabIndex.Value = Tab.Index.ToString();
                TabElement.Attributes.Append(TabIndex);
                #endregion

                #region Setting
                foreach (ModuleSetting Setting in Tab.Settings)
                {
                    XmlElement SettingElement = doc.CreateElement("ModuleSetting");
                    TabElement.AppendChild(SettingElement);

                    XmlAttribute SettingKey = doc.CreateAttribute("Key");
                    SettingKey.Value = Setting.Key;
                    SettingElement.Attributes.Append(SettingKey);

                    XmlAttribute SettingTitle = doc.CreateAttribute("Title");
                    SettingTitle.Value = Setting.Title;
                    SettingElement.Attributes.Append(SettingTitle);

                    XmlAttribute SettingType = doc.CreateAttribute("Type");
                    SettingType.Value = Setting.Type;
                    SettingElement.Attributes.Append(SettingType);
                    #region Value
                    if (Setting.Childrens != null) // Kiểm tra xem giá trị này có nhiều lựa chọn không
                    {
                        foreach (ModuleSettingItem SettingItem in Setting.Childrens)
                        {
                            XmlElement SettingItemElement = doc.CreateElement("ModuleSettingItem");
                            SettingElement.AppendChild(SettingItemElement);

                            XmlAttribute SettingItemElementSelect = doc.CreateAttribute("Select");
                            SettingItemElementSelect.Value = SettingItem.Value == Setting.Value ? "True" : "False";
                            SettingItemElement.Attributes.Append(SettingItemElementSelect);

                            XmlAttribute SettingItemElementValue = doc.CreateAttribute("Value");
                            SettingItemElementValue.Value = SettingItem.Value;
                            SettingItemElement.Attributes.Append(SettingItemElementValue);

                            XmlNode SettingItemElementHtml = doc.CreateCDataSection(SettingItem.Html);
                            SettingItemElement.AppendChild(SettingItemElementHtml);
                        }
                    }
                    else
                    {
                        XmlNode SettingValue = doc.CreateCDataSection(Setting.Value);
                        SettingElement.AppendChild(SettingValue);

                    }
                    #endregion

                }
                #endregion

            }
            #endregion
            #region ModuleSercurity

            if (_IPlug.Users != null)
            {
                XmlElement PluginSercurity = doc.CreateElement("Sercurity");
                PluginNode.AppendChild(PluginSercurity);
                foreach (ModuleSercurityUser User in _IPlug.Users)
                {
                    XmlElement PluginSercurityUser = doc.CreateElement("User");
                    PluginSercurity.AppendChild(PluginSercurityUser);

                    XmlAttribute PluginSercurityUserName = doc.CreateAttribute("Name");
                    PluginSercurityUserName.Value = User.Username;
                    PluginSercurityUser.Attributes.Append(PluginSercurityUserName);

                    XmlAttribute PluginSercurityPermision = doc.CreateAttribute("Permision");
                    PluginSercurityPermision.Value = User.Permision.ToString();
                    PluginSercurityUser.Attributes.Append(PluginSercurityPermision);
                }
            }

            #endregion
            return PluginNode;
        }
        /// <summary>
        /// Nạp các cài đặt dạng Object[] vào Plugin
        /// </summary>
        /// <param name="obj">Object[]: Mảng các cài đặt</param>
        /// <param name="_IPlug">IPlug: Plugin cần cài đặt</param>
        public static void LoadSettings(object[] obj, IPlug _IPlug)
        {
            if (obj != null)
            {
                if (obj.Length > 0)
                {
                    Type type = _IPlug.GetType();
                    for (int i = 0; i < (obj.Length - 1); i += 2)
                    {
                        PropertyInfo property = type.GetProperty(obj[i].ToString());
                        if (property != null && obj[i + 1] != null)
                        {
                            if (obj[i + 1].ToString() != "")
                            {
                                if (property.PropertyType.Name.ToLower() == "boolean")
                                {
                                    property.SetValue(_IPlug, Convert.ToBoolean(obj[i + 1]), null);

                                }
                                else
                                {
                                    property.SetValue(_IPlug, obj[i + 1], null);

                                }
                            }
                        }
                    }

                }
            }
        }
        /// <summary>
        /// Nạp các cài đặt dạng XMLNode vào Plugin
        /// </summary>
        /// <param name="SettingNode">XMLNode: Node chức các cài đặt</param>
        /// <param name="_IPlug">IPlug: Plugin cần cài đặt</param>
        public static void LoadSettings(XmlNode SettingNode, IPlug _IPlug)
        {
            if (SettingNode == null) throw new Exception("Xml cài đặt chưa có giá trị");
            _IPlug.PluginId = SettingNode.Attributes["ID"].Value;
            _IPlug.PluginClientId = SettingNode.Attributes["PluginClientId"].Value;
            _IPlug.PluginIndex = SettingNode.Attributes["PluginIndex"].Value;
            _IPlug.ZoneIndex = SettingNode.Attributes["ZoneIndex"].Value;
            _IPlug.Title = SettingNode.Attributes["Title"].Value;
            _IPlug.PluginIcon = SettingNode.Attributes["PluginIcon"].Value;
            _IPlug.Display = Convert.ToBoolean(SettingNode.Attributes["Display"].Value);
            _IPlug.ShowBorder = Convert.ToBoolean(SettingNode.Attributes["ShowBorder"].Value);
            _IPlug.ShowHeader = Convert.ToBoolean(SettingNode.Attributes["ShowHeader"].Value);
            _IPlug.ShowFoot = Convert.ToBoolean(SettingNode.Attributes["ShowFoot"].Value);
            _IPlug.Public = Convert.ToBoolean(SettingNode.Attributes["Public"].Value);
            _IPlug.PluginType = SettingNode.Attributes["PluginType"].Value;
            _IPlug.XmlSourcePath = SettingNode.Attributes["XmlSourcePath"].Value;
            _IPlug.IsCached = Convert.ToBoolean(SettingNode.Attributes["IsCached"].Value);
            _IPlug.IsCp = Convert.ToBoolean(SettingNode.Attributes["IsCp"].Value);
            _IPlug.IsInvisible = Convert.ToBoolean(SettingNode.Attributes["IsInvisible"].Value);
            _IPlug.IsShared = Convert.ToBoolean(SettingNode.Attributes["IsShared"].Value);
            if (SettingNode.Attributes["PluginCss"] != null)
            {
                _IPlug.PluginCss = SettingNode.Attributes["PluginCss"].Value;
            }
        }

    }
}
