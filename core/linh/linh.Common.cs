using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Caching;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Diagnostics;
using System.Web.Hosting;
using System.Xml;
using System.Security.Cryptography;
using Google.YouTube;
using System.Linq;
namespace linh.common
{
    public class Lib
    {
        //public static string TinhTuoi(bool Sinh,DateTime date)
        //{
        //    if(Sinh)
        //    {
        //        var diffDate = DateTime.Now - date.AddDays(-280);
        //        int monthDiff = System.Data.Linq.SqlClient.SqlMethods.DateDiffMonth(date.AddDays(-280), DateTime.Now);
        //    }
            
        //}
        public static string TinhTuoi(bool MangThai, DateTime dob)
        {
            var dt = DateTime.Now;
            if (MangThai)
            {
                dob = dob.AddDays(-280);
            }

            int days = dt.Day - dob.Day;
            if (days < 0)
            {
                dt = dt.AddMonths(-1);
                days += DateTime.DaysInMonth(dt.Year, dt.Month);
            }
            int weeks = Convert.ToInt32(Math.Floor(Convert.ToDouble(days / 7)));

            days = days % 7;

            var months = dt.Month - dob.Month;
            if (months < 0)
            {
                dt = dt.AddYears(-1);
                months += 12;
            }

            var years = dt.Year - dob.Year;

            return string.Format("{0}{1}{2}{3}",
                years == 0 ? "" : string.Format("{0} năm, ", years),
                                 months == 0 ? "" : string.Format("{0} tháng, ", months),
                                 weeks == 0 ? "" : string.Format("{0} tuần, ", weeks),
                                 days == 0 ? "" : string.Format("{0} ngày", days));
        }
        public static string TinhTuoi(bool MangThai, DateTime dob, DateTime cDate)
        {
            var dt = cDate;
            if (MangThai)
            {
                dob = dob.AddDays(-280);
            }

            int days = dt.Day - dob.Day;
            if (days < 0)
            {
                dt = dt.AddMonths(-1);
                days += DateTime.DaysInMonth(dt.Year, dt.Month);
            }
            int weeks = Convert.ToInt32(Math.Floor(Convert.ToDouble(days / 7)));

            days = days % 7;

            var months = dt.Month - dob.Month;
            if (months < 0)
            {
                dt = dt.AddYears(-1);
                months += 12;
            }

            var years = dt.Year - dob.Year;

            return string.Format("{0}{1}{2}{3}",
                years == 0 ? "" : string.Format("{0} năm, ", years),
                                 months == 0 ? "" : string.Format("{0} tháng, ", months),
                                 weeks == 0 ? "" : string.Format("{0} tuần, ", weeks),
                                 days == 0 ? "" : string.Format("{0} ngày", days));
        }

        public static int ThangTuoi(bool MangThai, DateTime dob)
        {
            var dt = DateTime.Now;
            if (MangThai)
            {
                dob = dob.AddDays(-280);
            }
            var months = dt.Month - dob.Month;
            if (months < 0)
            {
                dt = dt.AddYears(-1);
                months += 12;
            }

            var years = dt.Year - dob.Year;
            return years*12 + months;

        }


        public static string GetResource(Assembly assembly, string key)
        {
            using (var stream = assembly.GetManifestResourceStream(assembly.GetName().Name + "." + key))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
        
        public static string Bodau(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            string[] VietnameseSigns = new string[]
    {

        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"

    };
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Trim().Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }
            Regex reg = new Regex(@"[^A-Za-z0-9]");
            str = reg.Replace(str, " ").Trim().Replace(" ","-").Replace("-----", "-").Replace("----", "-").Replace("---", "-").Replace("--", "-");
            return str;

        }
        public static string TienVietNam(double input)
        {
            return string.Format(new CultureInfo("vi-Vn"), "{0:c}", input).Replace(" ₫", "");
        }
        public static string YouTubeValidUrl(string url)
        {
            if (url.IndexOf("youtube.com/watch?v=") > 0)
            {
                var v = url.Substring(url.IndexOf("?v=") + "?v=".Length);
                if (v.IndexOf("&") > 0)
                {
                    v = v.Substring(0, v.IndexOf("&"));
                    return v;
                }
                return v;
            }
            else if (url.IndexOf("youtube.com/embed/") > 0)
            {
                var v = url.Substring(url.LastIndexOf("/") + 1);
                return v;
            }
            return string.Empty;
        }
        public static youTubeVideo YouTubeCode(string url)
        {
            youTubeVideo item = new youTubeVideo();
            if (url == null || url == "") return item;
            var urlwatch = YouTubeValidUrl(url);
            if (urlwatch == string.Empty) return item;
            Uri videoEntryUrl = new Uri(string.Format("http://gdata.youtube.com/feeds/api/videos/{0}"
           , urlwatch));
            YouTubeRequestSettings setting = new YouTubeRequestSettings("obanbe", "obanbe", "AI39si7C5Kqeb1jEKO1tMbniRmamABGuDrk6g2uq2sRGup0hG94OIFG1DsInk-rW4BLklge1Wd9F_lbZum4V5-ebmgSHUaRejg");
            YouTubeRequest rq = new YouTubeRequest(setting);
            Video video = new Video();
            try
            {
                video = rq.Retrieve<Video>(videoEntryUrl);
                string title;
                string desc;
                string img;
                title = video.Title;
                desc = video.Description;
                img = video.Thumbnails[3].Url;
                item.Anh = img;
                item.Ten = title;
                item.Url = url;
                item.YId = urlwatch;
                item.MoTa = desc;
                return item;
            }
            catch (Exception ex)
            {
                item.Url = url;
                item.YId = urlwatch;
                return item;
            }
            
        }
        public static string Rutgon(string input
            , int Dai)
        {
            if (input.Length < Dai) return input;
            input = input.Substring(0, Dai);
            if (input.LastIndexOf(" ") != -1)
            {
                input = input.Substring(0, input.LastIndexOf(" "));
            }
            return input;
        }
        public string FormatTemplate(string input, object obj)
        {
            if (input == null) return string.Empty;
            if (obj == null) return input;
            Type t = Type.GetType(typeName: obj.GetType().AssemblyQualifiedName);
            if (t != null)
                input = t.GetProperties().Where(p => p.GetValue(obj, null) != null).Aggregate(input, (current, p) => current.Replace(string.Format("[{0}]", p.Name), p.GetValue(obj, null).ToString()));

            return input;
        }

        public static string imgSize(string _Avatar, string size)
        {
            if (_Avatar == null) return "avatar.jpg";
            if (_Avatar.Length == 0) return "avatar.jpg";
            string mime = _Avatar.Substring(_Avatar.LastIndexOf("."));
            string ten = _Avatar.Substring(0, _Avatar.LastIndexOf("."));
            _Avatar = ten + size + mime;
            return _Avatar;
        }
        public static string RutgonSeo(string input
            , int Dai)
        {
            string _input = input;
            char[] list = new char[] { ':', '^' };
            char rep = ' ';
            foreach (char item in list)
            {
                _input.Replace(item, rep);
            }
            if (_input.Length < Dai) return _input;
            _input = _input.Substring(0, Dai);
            if (_input.LastIndexOf(" ") != -1)
            {
                _input = _input.Substring(0, _input.LastIndexOf(" "));
            }
            return _input;
        }
        public static string app(string key)
        {
            Cache c = HttpRuntime.Cache;
            object obj = c["app-" + key];
            if (obj == null)
            {
                CacheDependency dep = new CacheDependency(HostingEnvironment.MapPath("~/Web.config"));
              
                c.Insert("app-" + key, ConfigurationManager.AppSettings[key].ToString(), dep);
                return ConfigurationManager.AppSettings[key].ToString();
            }
            return obj.ToString();
        }
        public static bool isEmail(string inputEmail)
        {
            if (inputEmail == null || inputEmail == "") return false;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime)
        {
            long InitialJavaScriptDateTicks = (new DateTime(1970, 1, 1)).Ticks;
            DateTime MinimumJavaScriptDate = new DateTime(100, 1, 1);
            if (dateTime < MinimumJavaScriptDate)
                dateTime = MinimumJavaScriptDate;
            long javaScriptTicks = (dateTime.Ticks - InitialJavaScriptDateTicks) / (long)10000;
            return javaScriptTicks;
        }
        public static DateTime ConvertJavaScriptTicksToDateTime(long javaScriptTicks)
        {
            long InitialJavaScriptDateTicks = (new DateTime(1970, 1, 1)).Ticks;
            DateTime dateTime = new DateTime((javaScriptTicks * 10000) + InitialJavaScriptDateTicks);
            return dateTime;
        }
        public static string GetXmlString(XmlDocument xmlDoc)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlDoc.WriteTo(xw);
            return sw.ToString();
        }
        public static string GetXmlString(XmlNode xmlNode)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode root = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, null, null);
            xmlDoc.AppendChild(root);
            XmlNode nNode = xmlDoc.ImportNode(xmlNode, true);
            xmlDoc.AppendChild(nNode);
            xmlDoc.WriteTo(xw);
            return sw.ToString();
        }
        public static string GetXmlString(string strFile)
        {
            // Load the xml file into XmlDocument object.
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(strFile);
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
            }
            // Now create StringWriter object to get data from xml document.
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlDoc.WriteTo(xw);
            return sw.ToString();
        }
        public static List<thoitiet> GetThoiTiet(string link)
        {
            List<thoitiet> List = new List<thoitiet>();
            #region xử lý link
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
             try
             {
                 using (HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse())
                 {
                     XmlDocument doc = new XmlDocument();
                     doc.Load(wrp.GetResponseStream());
                     XmlNodeList _l = doc.SelectNodes("//Item");
                     if (List != null)
                     {
                         foreach (XmlNode n in _l)
                         {
                             thoitiet item = new thoitiet();
                             if (n.SelectSingleNode("//AdImg") != null)
                             {
                                 item.AdImg = n.SelectSingleNode("AdImg").InnerText;
                             }
                             if (n.SelectSingleNode("//AdImg1") != null)
                             {
                                 item.AdImg1 = n.SelectSingleNode("AdImg1").InnerText;
                             }
                             if (n.SelectSingleNode("//AdImg2") != null)
                             {
                                 item.AdImg2 = n.SelectSingleNode("AdImg2").InnerText;
                             }
                             if (n.SelectSingleNode("//AdImg3") != null)
                             {
                                 item.AdImg3 = n.SelectSingleNode("AdImg3").InnerText;
                             }
                             if (n.SelectSingleNode("//AdImg4") != null)
                             {
                                 item.AdImg4 = n.SelectSingleNode("AdImg4").InnerText;
                             }
                             if (n.SelectSingleNode("//AdImg5") != null)
                             {
                                 item.AdImg5 = n.SelectSingleNode("AdImg5").InnerText;
                             }
                             if (n.SelectSingleNode("//Weather") != null)
                             {
                                 item.Weather = n.SelectSingleNode("Weather").InnerText;
                             }
                             List.Add(item);
                         }
                     }
                 }
             }
             catch (WebException ex)
             {
                 thoitiet _obj2 = new thoitiet();
                 _obj2.Weather = string.Empty;
             }
            #endregion
            return  List;
        }
        public static List<linkrss> GetLinkFromRss(string link)
        {
            List<linkrss> List = new List<linkrss>();
            #region xử lý Link
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
            try
            {
                using (HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse())
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(wrp.GetResponseStream());
                    XmlNodeList _l = doc.SelectNodes("//item");
                    if (List != null)
                    {
                        foreach (XmlNode n in _l)
                        {
                            linkrss item = new linkrss();
                            if (n.SelectSingleNode("title") != null)
                            {
                                item.Ten = n.SelectSingleNode("title").InnerText;
                            }
                            if (n.SelectSingleNode("description") != null)
                            {
                                item.Mota = n.SelectSingleNode("description").InnerText;

                            }
                            if (n.SelectSingleNode("link | LINK") != null)
                            {
                                item.Url = n.SelectSingleNode("link | LINK").InnerText.Trim();
                            }
                            List.Add(item);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                linkrss _obj2 = new linkrss();
                _obj2.Ten = string.Empty;
            }
            #endregion
            return List;
        }

        #region Doc Tien
        private static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }
        private static string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }
        private static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";

            }


            return Ktach;

        }
        public static string So_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";

            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod 
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";

            return lso_chu.ToString().Trim();

        }
        #endregion

    }
    public class youTubeVideo
    {
        public string Ten { get; set; }
        public string YId { get; set; }
        public string MoTa { get; set; }
        public string Anh { get; set; }
        public string Url { get; set; }
        public youTubeVideo() { }
        public youTubeVideo(string ten, string yid, string mota, string anh, string url)
        {
            Ten = ten;
            YId = yid;
            MoTa = mota;
            Anh = anh;
            Url = url;
        }
    }
    public class thoitiet
    {
        public string AdImg { get; set; }
        public string AdImg1 { get; set; }
        public string AdImg2 { get; set; }
        public string AdImg3 { get; set; }
        public string AdImg4 { get; set; }
        public string AdImg5 { get; set; }
        public string Weather { get; set; }
        public thoitiet (){ }
        public thoitiet(string adimg,string adimg1,string adimg2,string adimg3,string adimg4,string adimg5,string weather)
        {
            adimg = AdImg;
            adimg1 = AdImg1;
            adimg2 = AdImg2;
            adimg3 = AdImg3;
            adimg4 = AdImg4;
            adimg5 = AdImg5;
            weather = Weather;
        }
    }
    public class linkrss
    {
        public string Ten { get; set; }
        public string Mota { get; set; }
        public string Url { get; set; }
        public linkrss() { }
        public linkrss(string ten, string mota, string url) 
        {
            Ten = ten;
            Mota = mota;
            Url = url;
        }
    }
    public class omail
    {
        
        public static void SendthongBao(string email,string tieude,string noidung)
        {
            string _email = Lib.app("Obanbe.Email.ThongBao.Uid");
            string _pwd = Lib.app("Obanbe.Email.ThongBao.Pwd");
            try
            {
                if (email.IndexOf(",") != -1)
                {
                    string[] emailList = email.Split(new char[] { ',' });
                    Send(emailList, tieude, noidung, _email, "Obanbe", _pwd);
                }
                else
                {
                    Send(email, email, tieude, noidung, _email, "Obanbe", _pwd);
                }
            }
            catch (Exception ex)
            {
                
            }            
        }
        public static void SendLoiMoi(string email, string tieude, string noidung)
        {
            string _email = Lib.app("Obanbe.Email.Invite.Uid");
            string _pwd = Lib.app("Obanbe.Email.Invite.Pwd");
            try
            {
                //GigaMail.Send("smtp.gmail.com", 465, _email, _pwd
                //, "Thư mời", _email, "Obanbe", email, tieude, noidung, true);
                if (email.IndexOf(",") != -1)
                {
                    string[] emailList = email.Split(new char[] { ',' });
                    Send(emailList, tieude, noidung, _email, "Obanbe", _pwd);
                }
                else
                {
                    Send(email, email, tieude, noidung, _email, "Obanbe", _pwd);
                }
            }
            catch (Exception ex)
            {
            }            
            
        }
        public static void Send(string toEmail, string toTen, string subject, string body, string fromEmail, string fromName, string pwd)
        {
            var fromAddress = new MailAddress(fromEmail, fromName);
            var toAddress = new MailAddress(toEmail, toTen);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, pwd),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                BodyEncoding = System.Text.Encoding.UTF8,
                SubjectEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true

            })
            {
                try
                {
                    smtp.Send(message);
                }
                catch (SmtpException ex)
                {

                }
            }

        }
        public static void Send(string[] toEmail, string subject, string body, string fromEmail, string fromName, string pwd)
        {
            var fromAddress = new MailAddress(fromEmail, fromName);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, pwd),
                Timeout = 20000
            };
            var message = new MailMessage()
            {
                Subject = subject,
                Body = body,
                BodyEncoding = System.Text.Encoding.UTF8,
                SubjectEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true

            };
            message.From = fromAddress;
            foreach (string email in toEmail)
            {
                if (email.Length > 1)
                {
                    message.To.Add(email);
                }
            }
            try
            {
                smtp.Send(message);
            }
            catch (SmtpException ex)
            {

            }

        }
    }
    public class maHoa
    {
        private const string defaultKey = "linhnxObanbe";
        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }
        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt;
            try
            {
                DataToDecrypt = Convert.FromBase64String(Message);
            }
            catch
            {
                return string.Empty;
            }
            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

        public static string MD5Encrypt(string data)
        {
            byte[] output;
            byte[] input;
            string result = "";
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            int n = data.Length;
            input = new byte[n];

            for (int i = 0; i < n; i++)
            {
                input[i] = Convert.ToByte(data[i]);
            }
            output = md5.ComputeHash(input);

            n = output.Length;
            for (int i = 0; i < n; i++)
            {
                result = result + Convert.ToString(output[i]);
            }

            return result;

            //byte[] data, output;
            //UTF8Encoding encoder = new UTF8Encoding();
            //MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider();

            //data = encoder.GetBytes(plainText);
            //output = hasher.ComputeHash(data);

            //return BitConverter.ToString(output).Replace("-", "").ToLower();
        }
    }
    public class HierarchyNode<T> where T : class
    {
        public T Entity { get; set; }
        public IEnumerable<HierarchyNode<T>> ChildNodes { get; set; }
        public int Depth { get; set; }
    }
    public static class LinqExtensionMethods
    {
        private static System.Collections.Generic.IEnumerable<HierarchyNode<TEntity>> CreateHierarchy<TEntity, TProperty>
          (IEnumerable<TEntity> allItems, TEntity parentItem,
          Func<TEntity, TProperty> idProperty, Func<TEntity, TProperty> parentIdProperty, int depth) where TEntity : class
        {
            IEnumerable<TEntity> childs;

            if (parentItem == null)
                childs = allItems.Where(i => parentIdProperty(i).Equals(default(TProperty)));
            else
                childs = allItems.Where(i => parentIdProperty(i).Equals(idProperty(parentItem)));

            if (childs.Count() > 0)
            {
                depth++;

                foreach (var item in childs)
                    yield return new HierarchyNode<TEntity>()
                    {
                        Entity = item,
                        ChildNodes = CreateHierarchy<TEntity, TProperty>
                            (allItems, item, idProperty, parentIdProperty, depth),
                        Depth = depth
                    };
            }
        }

        /// <summary>
        /// LINQ IEnumerable AsHierachy() extension method
        /// </summary>
        /// <typeparam name="TEntity">Entity class</typeparam>
        /// <typeparam name="TProperty">Property of entity class</typeparam>
        /// <param name="allItems">Flat collection of entities</param>
        /// <param name="idProperty">Reference to Id/Key of entity</param>
        /// <param name="parentIdProperty">Reference to parent Id/Key</param>
        /// <returns>Hierarchical structure of entities</returns>
        public static System.Collections.Generic.IEnumerable<HierarchyNode<TEntity>> AsHierarchy<TEntity, TProperty>
          (this IEnumerable<TEntity> allItems, Func<TEntity, TProperty> idProperty, Func<TEntity, TProperty> parentIdProperty)
          where TEntity : class
        {
            return CreateHierarchy(allItems, default(TEntity), idProperty, parentIdProperty, 0);
        }
    }
}