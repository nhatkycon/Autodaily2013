using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Caching;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using System.Web.Hosting;
using System.Xml;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
namespace linh.seo.common
{
    public class seoLib
    {
        public static bool validLink(string link, string cd_code)
        {
            bool ok = false;
            cd_code = "code" + cd_code;
            #region xu ly
            try
            {
                HttpWebRequest wrq;
                wrq = (HttpWebRequest)(WebRequest.Create(link));
                string host = new Uri(link).Host;
                wrq.Credentials = CredentialCache.DefaultCredentials;
                wrq.Method = "GET";
                wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
                if (link.IndexOf("zing.vn") != -1)
                {
                    wrq.Referer = "http://mp3.zing.vn";
                }
                HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
                StreamReader rd = new StreamReader(wrp.GetResponseStream());
                string str = rd.ReadToEnd();
                if (str.IndexOf(cd_code) != -1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            #endregion
            return ok;
        }
        public static bool validLink(string link, string cd_code, out string inStr)
        {
            bool ok = false;
            cd_code = "code" + cd_code;
            #region xu ly
            HttpWebRequest wrq;
            wrq = (HttpWebRequest)(WebRequest.Create(link));
            string host = new Uri(link).Host;
            wrq.Credentials = CredentialCache.DefaultCredentials;
            wrq.Method = "GET";
            wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
            if (link.IndexOf("zing.vn") != -1)
            {
                wrq.Referer = "http://mp3.zing.vn";
            }
            HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
            StreamReader rd = new StreamReader(wrp.GetResponseStream());
            string str = rd.ReadToEnd();
            inStr = str;
            if (str.IndexOf(cd_code) != -1)
            {
                return true;
            }
            #endregion
            return ok;
        }
        public static string formatUrl(string link)
        {
            string hots = new Uri(link).Host;
            string clink = link;
            link = string.Format(@"<span style=""color:#999;margin-left: 5px;"">{0}</span>", link);
            link = link.Replace(hots, string.Format(@"<span style=""color:#000;font-weight: bold;"">{0}</span>", hots));
            link = string.Format(@"<a target=""_blank"" href=""{0}"">#</a>{1}", clink, link);
            return link;
        }
    }
}
