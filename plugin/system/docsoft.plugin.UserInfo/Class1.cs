using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh.frm;
using docsoft.entities;
using docsoft;
using linh.common;
[assembly: WebResource("docsoft.plugin.UserInfo.JScript1.js", "text/javascript", PerformSubstitution=true)]
[assembly: WebResource("docsoft.plugin.UserInfo.login.htm", "text/html")]
[assembly: WebResource("docsoft.plugin.UserInfo.recover.htm", "text/html")]
namespace docsoft.plugin.UserInfo
{
    public class Class1:PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            bool login = Security.IsAuthenticated();
            ClientScriptManager cs = this.Page.ClientScript;
            string username = Security.Username;
            string subAct = Request["subAct"];
            string pwd1 = Request["pwd1"];
            string pwd2 = Request["pwd2"];
            if (!login) renderText("un-authorized", "text/plain");
            switch (subAct)
            {
                case "changePass":
                #region thu nhỏ
                    if (!string.IsNullOrEmpty(pwd1))
                    {
                        Member Item = new Member();
                        Item = MemberDal.SelectByUsername(username);
                        Item.Username = username;
                        if (maHoa.DecryptString(Item.Password, username) == pwd1)
                        {
                            pwd2 = maHoa.EncryptString(pwd2, username);
                            MemberDal.changePassword(username, pwd2);
                            sb.Append("1");
                        }
                        else
                        {
                            sb.Append("0");
                        }
                    }
                    else
                    {
                        sb.Append("0");
                    }
                    break;
                #endregion
                default:
                    sb.Append(@"
<div id=""userInfoDlg"">
<table width=""100%"">
    <tr>
        <td style=""width:160px; text-align:right;"" valign=""top"">
        Mật khẩu cũ:
        </td>
        <td valign=""top"">
        <input class=""admtxt oldPwd"" type=""password"" />
        </td>
    </tr>
    <tr>
        <td style=""width:160px; text-align:right;"" valign=""top"">
        Mật khẩu mới:
        </td>
        <td valign=""top"">
        <input class=""admtxt newPwd"" type=""password"" />
        </td>
    </tr>
    <tr>
        <td colspan=""2"">   
            <a class=""mdl-head-btn mdl-head-add"" id=""userInfoMdl-saveBtn"" onclick=""userInfoFn.save();"" href=""javascript:;"">Lưu</a>     
        </td>        
    </tr>
</table>
</div>
                    ");
                    sb.AppendFormat("<script>$.getScript('{0}',"
                , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.UserInfo.JScript1.js"));
            sb.Append("function(){");
            sb.Append(@"adm.styleButton('.mdl-head-btn');");
            sb.Append("});</script>");
                    break;
            }            
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
