using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using docsoft;
using linh.frm;
using System.Web.UI;
using linh.common;
using docsoft.entities;
using linh.controls;
[assembly: WebResource("docsoft.plugin.authentication.login.htm", "text/html")]
[assembly: WebResource("docsoft.plugin.authentication.js.js", "text/javascript", PerformSubstitution = true)]
namespace docsoft.plugin.authentication
{
    public class Class1:PlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        void sendmail(string email, string tieude, string noidung)
        {
            omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "NhatKyCon", "123$5678");
        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            string u = Request["u"];
            string pwd = Request["p"];
            string r = Request["r"];
            string _code = Request["code"];
            string _email = Request["email"];
            StringBuilder sb = new StringBuilder();
            string subact = Request["subact"];
            switch (subact)
            {
                case "logout":
                    Security.LogOut();
                    sb.AppendFormat("1");
                    break;
                case "changePass":
                    #region changePass: Đổi mật khẩu
                    if (!string.IsNullOrEmpty(u))
                    {
                        pwd = maHoa.EncryptString(pwd, u);
                        if (MemberDal.UpdatePasswordByCode(u, _code, pwd))
                        {
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
                case "recovery":
                    #region recovery: Lấy lại mật khẩu
                    if (!string.IsNullOrEmpty(u))
                    {
                        string e = MemberDal.SelectEmailByUserName(u).Email;
                        if (!string.IsNullOrEmpty(e))
                        {
                            string newPass = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 5);
                            MemberDal.UpdateCodeByUsername(u, newPass);
                            sendEmailDele _dele = new sendEmailDele(sendmail);
                            _dele.BeginInvoke(e, "Ma xac nhan", string.Format("Username:{0}<br/>Ma xac nhan: {1}", e, newPass), null, null);
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
                   
                    bool ok = Security.Login(u, pwd, r.ToLower());
                    if (ok)
                    {
                        sb.AppendFormat(u);
                    }
                    else
                    {
                        sb.AppendFormat("0");
                    }
                    break;
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
