using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh.frm;
using docsoft.entities;
using docsoft;
using linh.json;
[assembly: WebResource("docsoft.hethong.preload.JScript1.js", "text/javascript", PerformSubstitution=true)]
[assembly: WebResource("docsoft.hethong.preload.login.htm", "text/html")]
[assembly: WebResource("docsoft.hethong.preload.recover.htm", "text/html")]
namespace docsoft.hethong.preload
{
    public class Class1:PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            bool login = Security.IsAuthenticated();
            ClientScriptManager cs = this.Page.ClientScript;          
            sb.AppendFormat("$.getScript('{0}',"
                , cs.GetWebResourceUrl(typeof(Class1), "docsoft.hethong.preload.JScript1.js"));
            sb.Append("function(){");
            string subAct = Request["subAct"];
            switch (subAct)
            {
                case "get":
                    sb = new StringBuilder();
                    sb.AppendFormat("{0:hh:mm dd-MM-yy}", DateTime.Now);
                    writer.Write(sb.ToString());
                     base.Render(writer);
                    return;
                    break;
                case "lite":
                #region thu nhỏ
                    if (login)
                    {
                        sb.AppendFormat("preload.setup('{0}');", Security.Username);
                    }
                    else
                    {
                        sb.AppendFormat("preload.login();");
                    }
                    break;
                #endregion
                case "getGhLink":
                    sb = new StringBuilder();
                    //sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(GianHangDal.SelectByUserName(Security.Username)));
                     writer.Write(sb.ToString());                    
                    base.Render(writer);
                    return;
                    break;
                case "getHomelogin":
                    sb = new StringBuilder();
                    sb.AppendFormat("{0}',"
                , cs.GetWebResourceUrl(typeof(Class1), "docsoft.hethong.preload.JScript1.js"));
                     writer.Write(sb.ToString());
                    base.Render(writer);
                    return;
                    break;
                case "loginSmall":
                    sb.Append("preload.loginDesktop();");
                    break;
                default:
                    if (login)
                    {
                        sb.AppendFormat("preload.setup('{0}');", Security.Username);
                    }
                    else
                    {
                        sb.AppendFormat("preload.login();");
                    }
                    break;
            }            
            sb.Append("});");
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
