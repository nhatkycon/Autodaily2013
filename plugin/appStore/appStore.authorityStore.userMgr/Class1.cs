using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using System.Data.SqlClient;
using linh.core.dal;
using docsoft;
using docsoft.entities;
using System.Web.UI;
using System.Web;
using linh.controls;
using linh.common;
[assembly: WebResource("appStore.authorityStore.userMgr.js.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("appStore.authorityStore.userMgr.htm.htm", "text/html", PerformSubstitution = true)]
namespace appStore.authorityStore.userMgr
{
    #region authentication
    public class authentication : PlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        const string emailActiveBody = @"<b>chào: {0}</b><br/>Mã kích hoạt của bạn là: <p><b>{1}</b></p><br/>hoặc click vào địa chỉ sau:<br/>
<h3><a href=""{2}/lib/aspx/sys/authenticate.aspx?act=ActiveByCode&Email={3}&ActiveCode={1}&type=mail"">{2}/lib/aspx/sys/authenticate.aspx?act=ActiveByCode&Email={3}&ActiveCode={1}&type=mail</a></h3>";
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {

            bool login = SecurityCangTin.IsAuthenticated();
            Page _Page = new Page();
            ClientScriptManager cs = _Page.ClientScript;
            StringBuilder sb = new StringBuilder();
            HttpContext c = HttpContext.Current;
            string _Usr = c.Request["Usr"];
            string _Pwd = c.Request["Pwd"];
            string _Rem = c.Request["Rem"];
            string _Ten = c.Request["Ten"];
            string _Email = c.Request["Email"];
            string _ActiveCode = c.Request["ActiveCode"];
            string _GioiTinh = c.Request["GioiTinh"];
            switch (subAct)
            {
                case "Login":
                    #region Login
                    sb.Append(SecurityCangTin.Login(_Usr, _Pwd, _Rem).ToString());
                    break;
                    #endregion
                case "LogOut":
                    #region LogOut
                    Security.LogOut();
                    break;
                    #endregion
                case "Reg":
                    #region Reg: Đăng ký
                    if (!string.IsNullOrEmpty(_Email) && !string.IsNullOrEmpty(_Usr))
                    {
                        string activeCode = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 6);
                        User Item = new User();
                        Item.Active = false;
                        Item.ActiveCode = activeCode;
                        Item.Email = _Email;
                        Item.NgayTao = DateTime.Now;
                        Item.Ten = _Ten;
                        Item.RowId = Guid.NewGuid();
                        Item.Username = _Usr;
                        Item.GioiTinh = Convert.ToBoolean(_GioiTinh);
                        Item.Pwd = linh.common.maHoa.EncryptString(_Usr, _Usr);
                        Item = UserDal.Insert(Item);
                        sendEmailDele dele = new sendEmailDele(omail.SendthongBao);
                        IAsyncResult ar = dele.BeginInvoke(_Email, "Căng tin (cangtin.com) - Email kích hoạt", string.Format(emailActiveBody, _Ten, Item.ActiveCode
                            , domain, _Email), null, null);
                        sb.Append(Item.ID.ToString());
                    }
                    break;
                    #endregion
                case "ValidateEmail":
                    #region ValidateEmail : Kiểm tra email
                    if (!string.IsNullOrEmpty(_Email))
                    {
                        sb.Append(MemberDal.ValidEmail(_Email).ToString());
                    }
                    break;
                    #endregion
                case "ActiveByCode":
                    #region AciveByCode : Kiểm tra ActiveCode
                    if (!string.IsNullOrEmpty(_ActiveCode))
                    {
                        bool ok = UserDal.ValidActiveCode(_ActiveCode, Security.Username);
                        if (!ok)
                        {
                            SecurityCangTin.Login(Security.Username, "True");
                            c.Session["c-user"] = null;

                        }
                        if (!string.IsNullOrEmpty(Request["type"]))
                        {
                            c.Response.Redirect(domain);
                        }
                        else
                        {
                            sb.Append(ok.ToString());
                        }
                    }
                    break;
                    #endregion
                case "ReSendActiveEmail":
                    #region ReSendActiveEmail : Gửi lại mail
                    if (!string.IsNullOrEmpty(_Email))
                    {
                        User Item = UserDal.SelectByUsername(Security.Username);
                        if (_Email != Item.Email)
                        {
                            if (UserDal.ValidEmail(_Email))
                            {
                                sb.Append("0");
                            }
                            else
                            {
                                UserDal.UpdateEmail(Security.Username, _Email);
                            }
                        }
                        sendEmailDele dele = new sendEmailDele(omail.SendthongBao);
                        IAsyncResult ar = dele.BeginInvoke(_Email, "Căng tin (cangtin.com) - Email kích hoạt", string.Format(emailActiveBody, _Ten, Item.ActiveCode
                            , domain, _Email), null, null);
                        rendertext("1");
                    }
                    break;
                    #endregion
                case "ValidateUsername":
                    #region ValidateUsername : Kiểm tra username
                    if (!string.IsNullOrEmpty(_Usr))
                    {
                        sb.Append(UserDal.ValidUsername(_Usr).ToString());
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(authentication), "appStore.authorityStore.userMgr.js.js"));
                    break;
                    #endregion
                default: break;
            }
            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }
    #endregion
}
