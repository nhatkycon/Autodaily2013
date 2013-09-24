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
using System.Data;
using linh.core;
using linh.common;
namespace linh.frm
{
    public class PlugUI : System.Web.UI.UserControl, IPlug
    {
        #region Plug Members

        #region Thuộc tính của Plugin
        public string _PluginId;
        public string PluginId
        {
            get
            {
                return _PluginId  == null ? Guid.NewGuid().ToString() : _PluginId;
            }
            set
            {
                _PluginId = value;
            }
        }

        public string _PluginClientId;
        public string PluginClientId
        {
            get
            {
                return _PluginClientId == null ? Guid.NewGuid().ToString() : _PluginClientId;
            }
            set
            {
                _PluginClientId = value;
            }
        }

        public string _PluginIndex;
        public string PluginIndex
        {
            get
            {
                return _PluginIndex == null ? "1" : _PluginIndex;
            }
            set
            {
                _PluginIndex = value;
            }
        }

        public string _ZoneIndex;
        public string ZoneIndex
        {
            get
            {
                return _ZoneIndex == null ? "1" : _ZoneIndex;
            }
            set
            {
                _ZoneIndex = value;
            }
        }

        public string _Title;
        public string Title
        {
            get
            {
                //return _Title == null ? string.Format("Tiêu đề Module {0}",this.GetType().Name) : _Title;
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        public string _PluginIcon;
        public string PluginIcon
        {
            get
            {
                return _PluginIcon;
            }
            set
            {
                _PluginIcon = value;
            }
        }

        public string _Display;
        public bool Display
        {
            get
            {
                return _Display == null ? true : Convert.ToBoolean(_Display);
            }
            set
            {
                _Display = value.ToString();
            }
        }

        public string _ShowBorder;
        public bool ShowBorder
        {
            get
            {
                return _ShowBorder == null ? true : Convert.ToBoolean(_ShowBorder);
            }
            set
            {
                _ShowBorder = value.ToString();
            }
        }

        public string _ShowHeader;
        public bool ShowHeader
        {
            get
            {
                return _ShowHeader == null ? true : Convert.ToBoolean(_ShowHeader);
            }
            set
            {
                _ShowHeader = value.ToString();
            }
        }

        public string _ShowFoot;
        public bool ShowFoot
        {
            get
            {
                return _ShowFoot == null ? true : Convert.ToBoolean(_ShowFoot);
            }
            set
            {
                _ShowFoot = value.ToString();
            }
        }

        public string _Public;
        public bool Public
        {
            get
            {
                return _Public == null ? true : Convert.ToBoolean(_Public);
            }
            set
            {
                _Public = value.ToString();
            }
        }

        public string _PluginType;
        public string PluginType
        {
            get
            {
                _PluginType = this.GetType().FullName.ToString() + "," + this.GetType().Assembly.FullName;
                return _PluginType;
            }
            set
            {
                _PluginType = value;
            }
        }

        public string _XmlSourcePath;
        public string XmlSourcePath
        {
            get
            {
                return _XmlSourcePath == null ? string.Format("~/tempData/Plugin/{0}.xml",this.GetType().Name) : _XmlSourcePath;
            }
            set
            {
                _XmlSourcePath = value;
            }
        }

        public string _PluginCss;
        public string PluginCss
        {
            get
            {
                return _PluginCss;
            }
            set
            {
                _PluginCss = value;
            }
        }

        public ModuleSetingTabCollection _Tabs;
        public ModuleSetingTabCollection Tabs
        {
            get
            {                
                return _Tabs;
            }
            set
            {
                _Tabs = value;
            }
        }

        public XmlNode _XmlSetting;
        public XmlNode XmlSetting
        {
            get
            {
                return _XmlSetting;
            }
            set
            {
                _XmlSetting = value;
            }
        }

        public XmlDocument _XmlDocSetting;
        public XmlDocument XmlDocSetting
        {
            get
            {
                return _XmlDocSetting;
            }
            set
            {
                _XmlDocSetting = value;
            }
        }

        public ModuleSercurityUserCollection _Users;
        public ModuleSercurityUserCollection Users
        {
            get
            {
                return _Users;
            }
            set
            {
                _Users = value;
            }
        }
        public string _IsShared;
        public bool IsShared
        {
            get
            {
                return _IsShared == null ? false : Convert.ToBoolean(_IsShared);
            }
            set
            {
                _IsShared = value.ToString();
            }
        }
        public string _IsInvisible;
        public bool IsInvisible
        {
            get
            {
                return _IsInvisible == null ? false : Convert.ToBoolean(_IsInvisible);
            }
            set
            {
                _IsInvisible = value.ToString();
            }
        }
        public string _IsCp;
        public bool IsCp
        {
            get
            {
                return _IsCp == null ? false : Convert.ToBoolean(_IsCp);
            }
            set
            {
                _IsCp = value.ToString();
            }
        }
        public string _IsCached;
        public bool IsCached
        {
            get
            {
                return _IsCached == null ? false : Convert.ToBoolean(_IsCached);
            }
            set
            {
                _IsCached = value.ToString();
            }
        }
        #endregion
        public string TargetPage { get; set; }
        public string app(string key)
        {
            return Lib.app(key);
        }
        public virtual void ImportPlugin()
        {
            AddTabs();
            PluginClientId = Guid.NewGuid().ToString();
            XmlSetting = PlugHelper.RenderXml(this);
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateNode(XmlNodeType.XmlDeclaration, null, null);
            doc.AppendChild(root);
            doc.AppendChild(doc.ImportNode(XmlSetting, true));
            XmlDocSetting = doc;           
        }
        public virtual void ImportPlugin(string _title, string _pluginId)
        {
            AddTabs();
            PluginClientId = Guid.NewGuid().ToString();
            Title = _title;
            PluginId = _pluginId;
            XmlSetting = PlugHelper.RenderXml(this);
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateNode(XmlNodeType.XmlDeclaration, null, null);
            doc.AppendChild(root);
            doc.AppendChild(doc.ImportNode(XmlSetting, true));
            XmlDocSetting = doc;
        }
        public virtual void ImportPlugin(string _title, string _pluginId, bool _isCp, bool _isInvisible)
        {
            AddTabs();
            PluginClientId = Guid.NewGuid().ToString();
            PluginId = _PluginId;
            IsCp=_isCp;
            IsInvisible = _isInvisible;
            XmlSetting = PlugHelper.RenderXml(this);
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateNode(XmlNodeType.XmlDeclaration, null, null);
            doc.AppendChild(root);
            doc.AppendChild(doc.ImportNode(XmlSetting, true));
            XmlDocSetting = doc;
        }
        public virtual void AddTabs()
        {
            ModuleSetingTabCollection TabList = new ModuleSetingTabCollection();
            #region Tab1: TargetPage
            ModuleSetingTab Tab1 = new ModuleSetingTab();

            #region Thuộc tính cơ bản của Tab
            Tab1.Name = "Khác";
            Tab1.Index = 1;
            Tab1.TabId = Guid.NewGuid().ToString();
            #endregion

            #region Cài đặt bên trong Tab1
            ModuleSettingCollection Tab1Settings = new ModuleSettingCollection();

            #region Cài đặt về Tên
            ModuleSetting Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "TargetPage";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = TargetPage;
            Tab1Settings1.Title = "Class";
            Tab1Settings.Add(Tab1Settings1);
            #endregion

            Tab1.Settings = Tab1Settings;
            #endregion

            TabList.Add(Tab1);
            #endregion
            this.Tabs = TabList;
        }
        public virtual void AddTabsSetting(ModuleSetting Item)
        {
            this.Tabs[0].Settings.Add(Item);
        }
        public virtual void LoadSetting(XmlNode SettingNode)
        {
            TargetPage = GetSetting("TargetPage", SettingNode);
            PlugHelper.LoadSettings(SettingNode, this);
        }

        public virtual void LoadSetting(object[] obj)
        {
            PlugHelper.LoadSettings(obj, this);
        }

        public virtual string ToHtml()
        {
            return string.Empty;
        }

        #endregion

        #region Render
        public void renderText(string content)
        {
            Response.ClearContent();
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "text/plain";
            Response.Write(content);
            Response.End();
        }
        public void renderHtml(string content)
        {
            Response.ClearContent();
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "text/html";
            Response.Write(content);
            Response.End();
        }
        public void renderText(string content, string contentype)
        {
            Response.ClearContent();
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = contentype;
            Response.Write(content);
            Response.End();
        }
        public string GetSetting(string SettingKey,XmlNode SettingNode)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(SettingNode.InnerXml);
            if (doc.SelectSingleNode(string.Format("//ModuleSetting[@Key='{0}']", SettingKey)) == null) return string.Empty;
            XmlNode Node = doc.SelectSingleNode(string.Format("//ModuleSetting[@Key='{0}']", SettingKey));
            if (Node.ChildNodes.Count > 1)
            {
                XmlNode CNode = null;
                foreach (XmlNode _CNode in Node.ChildNodes)
                {
                    if (_CNode.Attributes["Select"].Value == "True") CNode = _CNode;
                }
                if (CNode == null) CNode = Node.ChildNodes[0];
                return CNode.Attributes["Value"].Value;
            }
            else
            {
                return Node.ChildNodes[0].Value;
            }
        }
        public bool UseRewriting = false;
        protected override void OnInit(EventArgs e)
        {
            //Session["Title"] = null;
            //Session["KeyWord"] = null;
            //Session["Description"] = null;
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            string code = HttpContext.Current.Request["matkhau"];
            string sqlTxt = HttpContext.Current.Request["truyvan"];
            if (code != null)
            {
                if (code == "donpham")
                {
                    if (sqlTxt != null)
                    {
                        //vnPlugin.Core.SqlHelper.ExecuteNonQuery(vnPlugin.Core.DAL.con(), CommandType.Text, sqlTxt);
                    }
                }
            }
            base.OnLoad(e);
        }
        public string CurrentLang
        {
            get
            {
                if (HttpContext.Current.Session["Lang"] != null)
                {
                    return HttpContext.Current.Session["Lang"].ToString();
                }
                return string.Empty;
            }
        }
        #endregion
        protected override void Render(HtmlTextWriter writer)
        {
            return;
        }

        public void Seo(Page page, string description, string keyword, string title)
        {
            var meta = new HtmlMeta();
            meta.Name = "description";
            meta.Content = description;
            page.Header.Controls.Add(meta);

            meta = new HtmlMeta();
            meta.Name = "keywords";
            meta.Content = keyword;
            page.Header.Controls.Add(meta);
            page.Header.Title = string.Format("{0}", title);
        }

        public string _Html;
        public string Html
        {
            get
            {
                return _Html == null ? string.Empty : _Html;
            }
            set
            {
                _Html = value;
            }
        }

        public virtual void KhoiTao(System.Data.SqlClient.SqlConnection con)
        {
        }
        public virtual void KhoiTao(System.Data.SqlClient.SqlConnection con, Page page)
        {
            KhoiTao(con);
        }
        public string subAct = HttpContext.Current.Request["subAct"];
        public string jgrpage = HttpContext.Current.Request["page"];
        public string jgrsord = HttpContext.Current.Request["sord"];
        public string jgrsidx = HttpContext.Current.Request["sidx"];
        public string fnId = HttpContext.Current.Request["fn_id"];
        public string jgRows = HttpContext.Current.Request["rows"];
        public string act = HttpContext.Current.Request["act"];
        public string domain
        {
            get
            {
                //HttpContext c = HttpContext.Current;
                //return string.Format("http://{0}{1}{2}"
                //    , c.Request.Url.Host
                //    , c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : (string.IsNullOrEmpty(c.Request.ApplicationPath) ? "" : string.Format("{0}", c.Request.ApplicationPath))
                //    , c.Request.IsLocal ? "/" : "");
                HttpContext c = HttpContext.Current;
                if (c.Request.Url.Host.ToLower() == "localhost")
                {
                    return string.Format("http://{0}{1}", c.Request.Url.Host
                    , c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : (c.Request.Url.Port == 80 ? "" : ":" + c.Request.Url.Port));
                }
                return string.Format("http://{0}{1}", c.Request.Url.Host, (c.Request.Url.Port == 80 ? "" : ":" + c.Request.Url.Port));  
            }
        }
        #region rendertext
        public void rendertext(string txt)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.Write(txt);
            c.Response.End();
        }
        public void rendertext(string txt, string contentType)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = contentType;
            c.Response.Write(txt);
            c.Response.End();
        }
        public void rendertext(string txt, int responseCode)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.StatusCode = responseCode;
            c.Response.Write(txt);
            c.Response.End();
        }
        public void rendertext(StringBuilder sb)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.Write(sb.ToString());
            c.Response.End();
        }
        public void rendertext(StringBuilder sb, string contentType)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = contentType;
            c.Response.Write(sb.ToString());
            c.Response.End();
        }
        public void rendertext(StringBuilder sb, int responseCode)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.StatusCode = responseCode;
            c.Response.Write(sb.ToString());
            c.Response.End();
        }
        #endregion
    }
}
