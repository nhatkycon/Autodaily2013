using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using docsoft.entities;
using linh.common;
namespace docsoft
{
    public class Security
    {
        private const string cookieName = "linhUser";
        private const string sessionName = "Username";
        public static bool IsAuthenticated()
        {
            bool ok = false;
            if (HttpContext.Current.Session[sessionName] != null)
            {
                ok = true;
            }
            else
            {
                HttpCookie c = HttpContext.Current.Request.Cookies[cookieName];
                if (c != null)
                {
                    ok = true;
                }
            }
            return ok;
        }
        public static string Username
        {
            get
            {
                if (HttpContext.Current.Session[sessionName] != null)
                {
                    Member Item = (Member)(HttpContext.Current.Session[sessionName]);
                    return Item.Username;
                }
                else
                {
                    HttpCookie c = HttpContext.Current.Request.Cookies[cookieName];
                    if (c != null)
                    {
                        return c.Values["Username"].ToString();
                    }
                }
                return string.Empty;
            }
        }
        public static bool Login(string username, string pwd, string ReUser)
        {
            bool isOke = false;
            if (username == null || pwd == null)
            {
                return isOke;
            }
            HttpContext.Current.Session[sessionName] = null;
            Member Item = new Member();
            Item = MemberDal.SelectByUsername(username);
            HttpCookie c = new HttpCookie(cookieName);
            Item.Username = username;
            HttpContext.Current.Session[sessionName] = null;
            string temp = maHoa.MD5Encrypt(pwd);
            if (Item.Password != null)
            {
                if ((Item.Password == maHoa.MD5Encrypt(pwd)) || (maHoa.DecryptString(Item.Password, username) == pwd))
                {
                    HttpContext.Current.Session[sessionName] = Item;
                    isOke = true;
                    if (ReUser.ToLower() == "true")
                    {
                        c.Values.Add("Username", username);
                        c.Expires = DateTime.Now.AddDays(14);
                        HttpContext.Current.Response.Cookies.Add(c);
                    }
                    else if (ReUser.ToLower() == "false")
                    {
                        c.Expires = DateTime.Now.AddDays(-1);
                        HttpContext.Current.Response.Cookies.Add(c);
                    }
                }
                else
                {
                    c.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(c);
                }
            }
            else
            {
                c.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(c);
            }
            return isOke;
        }
        public static bool Login(string username, string ReUser)
        {
            bool isOke = false;
            HttpContext.Current.Session[sessionName] = null;
            Member Item = new Member();
            HttpCookie c = new HttpCookie(cookieName);
            Item.Username = username;
            HttpContext.Current.Session[sessionName] = null;
            HttpContext.Current.Session[sessionName] = Item;
            isOke = true;
            if (ReUser.ToLower() == "true")
            {
                c.Values.Add("Username", username);
                c.Expires = DateTime.Now.AddDays(14);
                HttpContext.Current.Response.Cookies.Add(c);
            }
            else if (ReUser.ToLower() == "false")
            {
                c.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(c);
            }
            return isOke;
        }
        public static void LogOut()
        {
            HttpContext.Current.Session[sessionName] = null;
            HttpCookie c = new HttpCookie(cookieName);
            c.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(c);
        }
    }
    public class SecurityCangTin
    {
        private const string cookieName = "cangTinUser";
        private const string sessionName = "cangTinUsername";
        public static bool IsAuthenticated()
        {
            bool ok = false;
            if (HttpContext.Current.Session[sessionName] != null)
            {
                ok = true;
            }
            else
            {
                HttpCookie c = HttpContext.Current.Request.Cookies[cookieName];
                if (c != null)
                {
                    ok = true;
                }
            }
            return ok;
        }
        public static string Username
        {
            get
            {
                if (HttpContext.Current.Session[sessionName] != null)
                {
                    User Item = (User)(HttpContext.Current.Session[sessionName]);
                    return Item.Username;
                }
                else
                {
                    HttpCookie c = HttpContext.Current.Request.Cookies[cookieName];
                    if (c != null)
                    {
                        return c.Values["Username"].ToString();
                    }
                }
                return string.Empty;
            }
        }
        public static bool Login(string username, string pwd, string ReUser)
        {
            bool isOke = false;
            if (username == null || pwd == null)
            {
                return isOke;
            }
            HttpContext.Current.Session[sessionName] = null;
            User Item = new User();
            Item = UserDal.SelectByUsername(username);
            HttpCookie c = new HttpCookie(cookieName);
            Item.Username = username;
            HttpContext.Current.Session[sessionName] = null;
            string temp = maHoa.MD5Encrypt(pwd);
            if (Item.Pwd != null)
            {
                if ((Item.Pwd == maHoa.MD5Encrypt(pwd)) || (maHoa.DecryptString(Item.Pwd, username) == pwd))
                {
                    HttpContext.Current.Session[sessionName] = Item;
                    isOke = true;
                    if (ReUser.ToLower() == "true")
                    {
                        c.Values.Add("Username", username);
                        c.Expires = DateTime.Now.AddDays(14);
                        HttpContext.Current.Response.Cookies.Add(c);
                    }
                    else if (ReUser.ToLower() == "false")
                    {
                        c.Expires = DateTime.Now.AddDays(-1);
                        HttpContext.Current.Response.Cookies.Add(c);
                    }
                }
                else
                {
                    c.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(c);
                }
            }
            else
            {
                c.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(c);
            }
            return isOke;
        }
        public static bool Login(string username, string ReUser)
        {
            bool isOke = false;
            HttpContext.Current.Session[sessionName] = null;
            User Item = new User();
            HttpCookie c = new HttpCookie(cookieName);
            Item.Username = username;
            HttpContext.Current.Session[sessionName] = null;
            HttpContext.Current.Session[sessionName] = Item;
            isOke = true;
            if (ReUser.ToLower() == "true")
            {
                c.Values.Add("Username", username);
                c.Expires = DateTime.Now.AddDays(14);
                HttpContext.Current.Response.Cookies.Add(c);
            }
            else if (ReUser.ToLower() == "false")
            {
                c.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(c);
            }
            return isOke;
        }
        public static void LogOut()
        {
            HttpContext.Current.Session[sessionName] = null;
            HttpCookie c = new HttpCookie(cookieName);
            c.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(c);
        }
    }
}
