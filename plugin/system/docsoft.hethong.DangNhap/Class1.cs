using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh.frm;
using docsoft.entities;
using docsoft;
using linh.json;
[assembly: WebResource("docsoft.hethong.DangNhap.JScript1.js", "text/javascript", PerformSubstitution=true)]
[assembly: WebResource("docsoft.hethong.DangNhap.login.htm", "text/html")]
[assembly: WebResource("docsoft.hethong.DangNhap.recover.htm", "text/html")]
namespace docsoft.hethong.DangNhap
{
    public class Class1:PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            bool login_fe = Security.IsAuthenticated();
            string subAct = Request["subAct"];
            ClientScriptManager cs = this.Page.ClientScript;
            if (subAct != "dangky_home" && subAct!="Ho_tro_khach_hang")
            {
                sb.AppendFormat("jQuery.getScript('{0}',"
                    , cs.GetWebResourceUrl(typeof(Class1), "docsoft.hethong.DangNhap.JScript1.js"));
                sb.Append("function(){");
            }
           
            string Ma = Request["Ma"];
            if (!Security.IsAuthenticated())
            {
                switch (subAct)
                {

                    case "lite":
                        #region thu nhỏ
                        if (login_fe)
                        {
                            sb.AppendFormat("DangNhap.setup('{0}');", Security.Username);
                        }
                        else
                        {
                            sb.AppendFormat("DangNhap.login_fe('{0}');", Ma);
                        }
                        break;
                        #endregion
                    case "dangky_home":
                        {


                            sb.Append("(" + JavaScriptConvert.SerializeObject(DanhMucDal.SelectByMa(Ma)) + ")");
                            break;
                        }
                    default:
                        if (login_fe && !Security.IsAuthenticated())
                        {
                            sb.AppendFormat("DangNhap.setup('{0}');", Security.Username);
                        }
                        else
                        {
                            sb.AppendFormat("DangNhap.login_fe('{0}');", Ma);
                        }
                        break;
                }
            }
            if (subAct != "dangky_home" && subAct != "Ho_tro_khach_hang")
            {
                sb.Append("});");
            }

            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
