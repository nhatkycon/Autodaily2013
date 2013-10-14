using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lib_master_TayDua : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string domain
    {
        get
        {
            HttpContext c = HttpContext.Current;
            if (c.Request.Url.Host.ToLower() == "localhost")
            {
                return string.Format("http://{0}{1}", c.Request.Url.Host
                , c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : (c.Request.Url.Port == 80 ? "" : ":" + c.Request.Url.Port));
            }
            return string.Format("http://{0}{1}", c.Request.Url.Host, (c.Request.Url.Port == 80 ? "" : ":" + c.Request.Url.Port));
        }
    }
}
