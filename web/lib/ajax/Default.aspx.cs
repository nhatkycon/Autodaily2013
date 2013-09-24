using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using linh.frm;
using System.Xml;
using docsoft.entities;
using linh.core;
using linh.core.dal;
public partial class lib_ajax_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = Request["act"];
        StringBuilder sb = new StringBuilder();
        string _setting = Request["settings"];
        string _kyHieu = Request["kyHieu"];
        string _type = Request["type"];
        string _id = Request["id"];
        string _index = Request["index"];
        string _iList = Request["iList"];
        docsoft.entities.Plugin Item;
        PluginZone ItemPZ;
        switch (act)
        {
            case "portal-module-move":
                #region portal-module-move: Di chuyển module
                foreach (string mdlstr in _setting.Split(new char[] { ',' }))
                {
                    if (mdlstr.Trim().Length > 1)
                    {
                        string[] objStr = mdlstr.Split(new char[] { '|' });
                        PluginZoneDal.UpdateMove(objStr[0], objStr[1], objStr[2]);
                    }
                }
                break;
                #endregion
            case "portal-module-get":
                #region portal-module-get: Lấy danh sách module
                foreach (docsoft.entities.Plugin plugin in PluginDal.SelectAll())
                {
                    sb.AppendFormat(@"
<div class=""mdl-store-item mdl"" _id=""{3}"" _type=""{2}"">
    <div class=""mdl-store-item-ten"">{0}</div>
    <img src=""{4}/lib/up/i/{1}"" class=""mdl-store-item-anh"" />
</div>
", plugin.Ten, plugin.Anh, plugin.Kieu, plugin.ID, domain);
                }
                rendertext(sb);
                break;
                #endregion
            case "portal-module-render":
                #region portal-module-render: Lấy module theo kiểu                
                if (!string.IsNullOrEmpty(_type))
                {
                    Type type = Type.GetType(_type);
                    IPlug plug = (IPlug)Activator.CreateInstance(type);
                    plug.ImportPlugin();
                    Item = PluginDal.SelectById(Convert.ToInt32(_id));
                    using (SqlConnection con = linh.core.dal.DAL.con())
                    {
                        plug.KhoiTao(con);
                        ItemPZ = PluginZoneDal.Add(_index, linh.common.Lib.GetXmlString(PlugHelper.RenderXml(plug)), "1");
                        rendertext(buildModule(plug, ItemPZ.ID, ItemPZ.Z_ID));
                    }
                }

                break;
                #endregion
            case "portal-module-del":
                #region portal-module-del: Xóa module
                if (!string.IsNullOrEmpty(_id))
                {
                    PluginZoneDal.DeleteById(Convert.ToInt32(_id));
                }
                break;
                #endregion
            case "portal-module-edit":
                #region portal-module-edit: Edit Module
                if (!string.IsNullOrEmpty(_id))
                {
                    ItemPZ = PluginZoneDal.SelectById(Convert.ToInt32(_id));
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(ItemPZ.Settings);
                    rendertext(PlugHelper.RenderHtml_Edit(doc.LastChild, _id));
                }
                break;
                #endregion
            case "portal-module-save":
                #region portal-module-save: save Module
                if (!string.IsNullOrEmpty(_id))
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode node = doc.ImportNode(PlugHelper.RenderXml(toList(_iList), _type), true);
                    doc.AppendChild(node);
                    

                    Type type = Type.GetType(_type);
                    IPlug plug = (IPlug)Activator.CreateInstance(type);
                    plug.ImportPlugin();
                    plug.LoadSetting(doc.LastChild);
                    
                    ItemPZ = PluginZoneDal.SelectById(Convert.ToInt32(_id));
                    ItemPZ.Settings = linh.common.Lib.GetXmlString(doc);
                    ItemPZ = PluginZoneDal.Update(ItemPZ);

                    using (SqlConnection con = linh.core.dal.DAL.con())
                    {
                        plug.KhoiTao(con, this.Page);
                        //rendertext(buildModule(plug, ItemPZ.ID, ItemPZ.Z_ID));
                        rendertext(plug.Html);
                    }

                    

                }
                break;
                #endregion
            case "portal-module-save-quick":
                #region portal-module-save: save Module
                if (!string.IsNullOrEmpty(_id))
                {
                    ItemPZ = PluginZoneDal.SelectById(Convert.ToInt32(_id));
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(ItemPZ.Settings);
                    var xmlNode1 = doc.SelectSingleNode(@"//*[@Key='Top']").FirstChild;
                    xmlNode1.Value = Request["Top"];
                    var node1 = xmlNode1.CloneNode(true);
                    doc.ImportNode(node1, true);
                    xmlNode1.ParentNode.ReplaceChild(node1, xmlNode1);
                    ItemPZ.Settings = linh.common.Lib.GetXmlString(doc);
                    ItemPZ = PluginZoneDal.Update(ItemPZ);

                    Type type = Type.GetType(_type);
                    IPlug plug = (IPlug)Activator.CreateInstance(type);
                    plug.ImportPlugin();
                    plug.LoadSetting(doc.LastChild);
                    using (SqlConnection con = linh.core.dal.DAL.con())
                    {
                        plug.KhoiTao(con);
                        //rendertext(buildModule(plug, ItemPZ.ID, ItemPZ.Z_ID));
                        rendertext(plug.Html);
                    }
                }
                break;
                #endregion
            case "getThemes":
                #region portal-module-save: save Module
                List<DanhMuc> ListThemes = DanhMucDal.SelectByLDMMa(DAL.con(), "THEMES");
                foreach (DanhMuc item in ListThemes)
                {
                    sb.AppendFormat(@"
<div class=""thm-item{5}"" _id=""{3}"" _kyHieu=""{2}"" _locate=""{4}/lib/css/web/{2}/1.css"">
    <div class=""thm-item-ten"">{0}</div>
    <img src=""{4}/lib/up/i/{1}"" class=""thm-item-anh"" />
</div>", item.Ten, item.Anh, item.GiaTri, item.ID, domain, item.KyHieu == "1" ? " thm-item-active" : "");
                }
                rendertext(sb);
                break;
                #endregion
            case "saveThemes":
                #region saveThemes: save giao dien
                if (!string.IsNullOrEmpty(_id))
                {
                    //DanhMucDal.UpdateThemes(_id);
                }
                break;
                #endregion
            default:
                break;
        }
    }
    public string domain
    {
        get
        {
            HttpContext c = HttpContext.Current;
            return string.Format("http://{0}{1}", c.Request.Url.Host
                , c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : (string.IsNullOrEmpty(c.Request.ApplicationPath) ? "" : string.Format("{0}", c.Request.ApplicationPath)));
        }
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
    public string buildModule(IPlug _IPlug, int id, int zone)
    {
        return string.Format(@"
<div id=""{2}"" class=""mdl"" zone=""{3}"">
    <div class=""mdl-head"">
        <span class=""mdl-tool"">
            <a href=""javascript:;"" _type=""{4}"" _id=""{2}"" class=""mdl-tool-btn mdl-tool-edit"">sửa</a>
            <a href=""javascript:;"" _id=""{2}"" class=""mdl-tool-btn mdl-tool-del"">xóa</a>
        </span>
        <span class=""mdl-move-icon""></span>
        <span class=""mdl-title"">{0}</span>
    </div>
    <div class=""mdl-body"">{1}</div>
</div>", _IPlug.Title, _IPlug.Html, id, zone, _IPlug.PluginType);
    }
}