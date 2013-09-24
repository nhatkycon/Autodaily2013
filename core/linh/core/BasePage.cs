using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
namespace linh.core
{
    public class BasedPage:Page
    {
        public void rendertext(string txt)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(string txt,string contentType)
        {
            Response.ClearContent();
            Response.ContentType = contentType;
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(StringBuilder sb)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(sb.ToString());
            Response.End();
        }
        public string subAct
        {
            get { return Request["subAct"]; }
        }
        public string act
        {
            get { return Request["act"]; }
        }
    }
    public class BasedUi : System.Web.UI.UserControl
    {
        public void rendertext(string txt)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(string txt, string contentType)
        {
            Response.ClearContent();
            Response.ContentType = contentType;
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(StringBuilder sb)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(sb.ToString());
            Response.End();
        }
        public void rendertext(StringBuilder sb, string contentType)
        {
            Response.ClearContent();
            Response.ContentType = contentType;
            Response.Write(sb.ToString());
            Response.End();
        }
        public string domain
        {
            get
            {
                return string.Format("http://{0}{1}", Request.Url.Host, Request.IsLocal ? string.Format(":{0}{1}", Request.Url.Port, Request.ApplicationPath) : "");
            }
        }
    }
}
