using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using HtmlAgilityPack;
using System.Text;
using System.Web.Hosting;
using System.Xml;
using System.Linq;
using linh.controls;
using System.Text.RegularExpressions;
namespace linh.controls
{    
    public class LinkGrap
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<string> Images { get; set; }
        public List<string> OutLink { get; set; }
        public List<string> InLink { get; set; }
        public string contentType { get; set; }
        public string Content { get; set; }
        public string ContentRawHtml { get; set; }
        public string ContentRawText { get; set; }
        public Dictionary<string, LinkKeyword> KeyWords { get; set; }
        public IEnumerable<LinkKeyword> KeyWordsIEnum { get; set; }
        public LinkGrap()
        {

        }
        private const string cacheKey = "links-grap-{0}";
        #region oldContructor
        //public LinkGrap(string link)
        //{
        //    LinkGrap Item;
        //    string saveLocation = HostingEnvironment.MapPath("~/upload/anh/");
        //    Item = (LinkGrap)HttpContext.Current.Cache[string.Format(cacheKey, link)];
        //    if (Item == null)
        //    {
        //        #region xử lý Link
        //        HttpWebRequest wrq;
        //        wrq = (HttpWebRequest)(WebRequest.Create(link));               
        //        wrq.Credentials = CredentialCache.DefaultCredentials;                
        //        wrq.Method = "GET";
        //        wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";            
        //        wrq.SendChunked = true;
        //        if (link.IndexOf("zing.vn") != -1)
        //        {
        //            wrq.UserAgent = "1234556";
        //            wrq.Referer = "http://mp3.zing.vn";
        //        }
        //        try
        //        {
        //            HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
        //            HtmlDocument doc = new HtmlDocument();
        //            contentType = wrp.ContentType;
        //            if (contentType.ToLower().IndexOf("html") != -1)
        //            {
        //                doc.Load(wrp.GetResponseStream(), System.Text.Encoding.UTF8);
        //                string domain = "http://" + (new Uri(link)).Host;
        //                if (doc.DocumentNode.SelectNodes("//title | //TITLE") != null)
        //                {
        //                    HtmlNode titleNode = doc.DocumentNode.SelectNodes("//title | //TITLE")[0];
        //                    Title = titleNode.InnerText;
        //                }
        //                if (doc.DocumentNode.SelectNodes("//meta[@name='description'] | //meta[@name='DESCRIPTION']") != null)
        //                {
        //                    HtmlNode titleNode = doc.DocumentNode.SelectNodes("//meta[@name='description'] | //meta[@name='DESCRIPTION']")[0];
        //                    Description = titleNode.Attributes["content"].Value;
        //                }
        //                if (doc.DocumentNode.SelectNodes("//img | //IMG") != null)
        //                {
        //                    List<string> _list = new List<string>();
        //                    foreach (HtmlNode _img in doc.DocumentNode.SelectNodes("//img | //IMG"))
        //                    {
        //                        if (_img.Attributes["src"] != null)
        //                        {
        //                            string src = _img.Attributes["src"].Value;
        //                            if (src.ToLower().IndexOf("http://") != 0)
        //                            {
        //                                src = domain + src;
        //                            }
        //                            ImageProcess gimg = new ImageProcess(new Uri(src), src);
        //                            if (gimg.Width > 100 && gimg.Heigth > 75)
        //                            {
        //                                _list.Add(src);
        //                            }
        //                        }
        //                    }
        //                    Images = _list;
        //                }
        //            }
        //            else
        //            {
        //                Title = link;
        //                Description = link;
        //                List<string> _list = new List<string>();
        //                ImageProcess gimg = new ImageProcess(new Uri(link), link);
        //                if (gimg.Width > 100 && gimg.Heigth > 75)
        //                {
        //                    _list.Add(link);
        //                }
        //                Images = _list;
        //            }
        //            LinkGrap _obj = new LinkGrap();
        //            _obj.Title = Title;
        //            _obj.Description = Description;
        //            _obj.Images = Images;
        //            _obj.contentType = contentType;
        //            HttpContext.Current.Cache.Insert(string.Format(cacheKey, link), _obj);
        //            Item = _obj;
        //        }
        //        catch(WebException ex)
        //        {
        //            LinkGrap _obj2 = new LinkGrap();
        //            _obj2.Title = "0";
        //            _obj2.Description = Description;
        //            _obj2.Images = Images;
        //            _obj2.contentType = contentType;
        //            HttpContext.Current.Cache.Remove(string.Format(cacheKey, link));
        //            Item = _obj2;
        //        }


        //        #endregion
        //    }

        //    Title = Item.Title;
        //    Description = Item.Description;
        //    Images = Item.Images;
        //    contentType = Item.contentType;
        //}
        #endregion
        public LinkGrap(string link, bool extractLink)
        {
            LinkGrap Item = null;
            string saveLocation = HostingEnvironment.MapPath("~/lib/up/rss/");
            //string uploadDir = @"D:\InetPub\tintucme\wwwroot\lib\up\";
            //C:\inetpub\wwwroot\choNongNghiep\web\lib\up\rss
            string uploadDir = @"D:\Work\linh\ktt_x1\web\lib\up\rss\";
            Item = (LinkGrap)HttpRuntime.Cache[string.Format(cacheKey, link)];
            Item = null;
            if (Item == null)
            {
                #region xử lý Link
                HttpWebRequest wrq;
                wrq = (HttpWebRequest)(WebRequest.Create(link));
                string host = new Uri(link).Host;
                wrq.Credentials = CredentialCache.DefaultCredentials;
                wrq.Method = "GET";
                wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
                wrq.SendChunked = false;
                if (link.IndexOf("zing.vn") != -1)
                {
                    wrq.Referer = "http://mp3.zing.vn";
                }
                try
                {
                    HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
                    HtmlDocument doc = new HtmlDocument();
                    contentType = wrp.ContentType;
                    if (contentType.ToLower().IndexOf("html") != -1)
                    {
                        doc.Load(wrp.GetResponseStream(), Encoding.UTF8);
                        string domain = "http://" + (new Uri(link)).Host;
                        #region Title
                        if (doc.DocumentNode.SelectNodes("//title | //TITLE") != null)
                        {
                            HtmlNode titleNode = doc.DocumentNode.SelectNodes("//title | //TITLE")[0];
                            Title = titleNode.InnerText;
                        }
                        #endregion
                        #region Desc
                        if (doc.DocumentNode.SelectNodes("//meta[@name='description'] | //meta[@name='DESCRIPTION']") != null)
                        {
                            HtmlNode titleNode = doc.DocumentNode.SelectNodes("//meta[@name='description'] | //meta[@name='DESCRIPTION']")[0];
                            Description = titleNode.Attributes["content"].Value;
                        }
                        #endregion
                        #region Content
                        ContentRawHtml = doc.DocumentNode.InnerHtml;
                        ContentRawText = doc.DocumentNode.InnerText;
                        Content = Wrapper(host, link, doc);
                        if (string.IsNullOrEmpty(Content)) return;
                        string contentTokeyword = Giga.Common.Lib._string.getHTML(Content);
                        if (!string.IsNullOrEmpty(contentTokeyword))
                        {
                            using (LinkKeyword _linkKeyword = new LinkKeyword(contentTokeyword))
                            {
                                if (_linkKeyword.ListKeyWord != null)
                                {
                                    KeyWords = _linkKeyword.ListKeyWord;
                                }
                            }
                        }
                        //if (string.IsNullOrEmpty(contentTokeyword)) contentTokeyword = ContentRawText;
                        //List<LinkKeyword> _ListKeyword = new List<LinkKeyword>();
                        #endregion
                        #region Images
                        HtmlDocument _doc1 = new HtmlDocument();
                        _doc1.LoadHtml(Content);
                        if (_doc1.DocumentNode.SelectNodes("//img | //IMG") != null)
                        {
                            List<string> _list = new List<string>();
                            foreach (HtmlNode _img in _doc1.DocumentNode.SelectNodes("//img | //IMG"))
                            {
                                if (_img.Attributes["src"] != null)
                                {
                                    string src = _img.Attributes["src"].Value;
                                    if (src.ToLower().IndexOf("http://") != 0)
                                    {
                                        if (src.IndexOf("/") != 0) src = "/" + src;
                                        src = domain + src;
                                    }
                                    try
                                    {
                                        ImageProcess gimg = new ImageProcess(new Uri(src), src);
                                        if (gimg.Width > 250 && gimg.Heigth > 200)
                                        {
                                            #region ảnh cũ
                                            //string _newid = Guid.NewGuid().ToString();
                                            //string _ten = saveLocation + _newid;
                                            //gimg.Save(_ten + gimg.Ext);
                                            //gimg.Crop(320, 188);
                                            //gimg.Save(_ten + "320x188" + gimg.Ext);
                                            //gimg.Crop(150, 160);
                                            //gimg.Save(_ten + "150x160" + gimg.Ext);
                                            //gimg.Crop(101, 58);
                                            //gimg.Save(_ten + "101x58" + gimg.Ext);
                                            //gimg.Crop(62, 36);
                                            //gimg.Save(_ten + "62x36" + gimg.Ext);
                                            //_list.Add(_newid + gimg.Ext);
                                            //HttpRuntime.Cache.Remove(src);
                                            #endregion
                                            string gimg_t = Guid.NewGuid().ToString().Replace("-", "");

                                            string gimg_ten = gimg_t + gimg.Ext;
                                            //saveLocation = Path.Combine(uploadDir, gimg_ten);
                                            //gimg.Save(saveLocation);
                                            _list.Add(gimg_ten);

                                            string gimg_ten_430x300 = gimg_t + "430x300" + gimg.Ext;
                                            gimg.Crop(430, 300);
                                            saveLocation = Path.Combine(uploadDir, gimg_ten_430x300);
                                            gimg.Save(saveLocation);
                                            _list.Add(gimg_ten_430x300);

                                            //string gimg_ten_100 = gimg_t + "200x150" + gimg.Ext;
                                            //gimg.Crop(200, 150);
                                            //saveLocation = Path.Combine(uploadDir, gimg_ten_100);
                                            //gimg.Save(saveLocation);
                                            //_list.Add(gimg_ten_100);

                                            string gimg_ten_101_58 = gimg_t + "100x100" + gimg.Ext;
                                            gimg.Crop(100, 100);
                                            saveLocation = Path.Combine(uploadDir, gimg_ten_101_58);
                                            gimg.Save(saveLocation);
                                            _list.Add(gimg_ten_101_58);

                                            string gimg_ten_62_36 = gimg_t + "50x50" + gimg.Ext;
                                            gimg.Crop(50, 50);
                                            saveLocation = Path.Combine(uploadDir, gimg_ten_62_36);
                                            gimg.Save(saveLocation);
                                            _list.Add(gimg_ten_62_36);
                                            break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    
                                }
                            }
                            if (_list.Count == 0) return;
                            Images = _list;
                        }
                        #endregion
                        #region Link
                        //List<string> _inLink = new List<string>();
                        //List<string> _outLink = new List<string>();
                        //foreach (HtmlNode a in doc.DocumentNode.SelectNodes("//a|//A"))
                        //{
                        //    string href = string.Empty;
                        //    if (a.Attributes["href"] != null)
                        //    {
                        //        href = a.Attributes["href"].Value;
                        //    }
                        //    else if (a.Attributes["HREF"] != null)
                        //    {
                        //        href = a.Attributes["HREF"].Value;
                        //    }
                        //    if (!string.IsNullOrEmpty(href))
                        //    {
                        //        if (href.ToLower().IndexOf("javascrip") != 0 && href.ToLower().IndexOf("#") != 0)
                        //        {
                        //            if (href.ToLower().IndexOf("http://") == 0)//HTTPLink
                        //            {
                        //                Uri _href = new Uri(href);
                        //                if (_href.Host.ToLower().IndexOf(host.ToLower()) != -1)
                        //                {
                        //                    _inLink.Add(href);
                        //                }
                        //                else
                        //                {
                        //                    _outLink.Add(href);
                        //                }
                        //            }
                        //            else
                        //            {
                        //                if (href.ToLower().IndexOf("/") == -1) href = "/" + href;
                        //                if (href.ToLower().IndexOf("../") == 0) href = href.Substring(href.LastIndexOf("../") + 3);
                        //                href = "http://" + host + href;
                        //                _inLink.Add(href);
                        //            }
                        //        }
                        //    }
                        //    InLink = _inLink;
                        //    OutLink = _outLink;
                        //}
                        #endregion

                    }
                    else
                    {

                        if (contentType.IndexOf("image") != -1)
                        {
                            Title = link;
                            Description = link;
                            List<string> _list = new List<string>();
                            ImageProcess gimg = new ImageProcess(new Uri(link), link);
                            if (gimg.Width > 100 && gimg.Heigth > 75)
                            {
                                _list.Add(link);
                            }
                            Images = _list;
                        }
                    }
                    LinkGrap _obj = new LinkGrap();
                    _obj.Title = Title;
                    _obj.Description = Description;
                    _obj.Images = Images;
                    _obj.contentType = contentType;
                    _obj.InLink = InLink;
                    _obj.OutLink = OutLink;
                    _obj.contentType = Content;
                    _obj.ContentRawText = ContentRawText;
                    _obj.ContentRawHtml = ContentRawHtml;
                    HttpRuntime.Cache.Insert(string.Format(cacheKey, link), _obj);
                    Item = _obj;
                }
                catch (WebException ex)
                {
                    LinkGrap _obj2 = new LinkGrap();
                    _obj2.Title = "0";
                    HttpRuntime.Cache.Remove(string.Format(cacheKey, link));
                    Item = _obj2;
                }


                #endregion
            }

            Title = Item.Title;
            Description = Item.Description;
            Images = Item.Images;
            contentType = Item.contentType;
            KeyWordsIEnum = Item.KeyWordsIEnum;
        }
        public LinkGrap(string link, bool extractLink, bool isRss)
        {
            #region xử lý Link
            HttpWebRequest wrq;
            if (link.IndexOf("http://222.255.31.205/") == 0) link = link.Substring("http://222.255.31.205/".Length);
            wrq = (HttpWebRequest)(WebRequest.Create(link));
            string host = new Uri(link).Host;
            wrq.Credentials = CredentialCache.DefaultCredentials;
            wrq.Method = "GET";
            wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
            wrq.SendChunked = true;
            if (link.IndexOf("zing.vn") != -1)
            {
                wrq.Referer = "http://mp3.zing.vn";
            }
            try
            {
                HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
                HtmlDocument doc = new HtmlDocument();
                contentType = wrp.ContentType;
                if (contentType.ToLower().IndexOf("html") != -1)
                {
                    doc.Load(wrp.GetResponseStream(), Encoding.UTF8);
                    string domain = "http://" + (new Uri(link)).Host;
                    #region Title
                    if (doc.DocumentNode.SelectNodes("//title | //TITLE") != null)
                    {
                        HtmlNode titleNode = doc.DocumentNode.SelectNodes("//title | //TITLE")[0];
                        Title = titleNode.InnerText;
                    }
                    #endregion
                    #region Desc
                    if (doc.DocumentNode.SelectNodes("//meta[@name='description'] | //meta[@name='DESCRIPTION']") != null)
                    {
                        HtmlNode titleNode = doc.DocumentNode.SelectNodes("//meta[@name='description'] | //meta[@name='DESCRIPTION']")[0];
                        if (titleNode.Attributes["content"] != null)
                        {
                            Description = titleNode.Attributes["content"].Value;
                        }
                    }
                    #endregion
                    #region Content
                    ContentRawHtml = doc.DocumentNode.InnerHtml;
                    ContentRawText = doc.DocumentNode.InnerText;
                    Content = Wrapper(host, link, doc);
                    #endregion
                    #region Images
                    if (!string.IsNullOrEmpty(Content))
                    {
                        doc = new HtmlDocument();
                        doc.LoadHtml(Content);
                        if (doc.DocumentNode.SelectNodes("//img | //IMG") != null)
                        {
                            List<string> _list = new List<string>();
                            foreach (HtmlNode _img in doc.DocumentNode.SelectNodes("//img | //IMG"))
                            {
                                if (_img.Attributes["src"] != null)
                                {
                                    string src = _img.Attributes["src"].Value;
                                    if (src.ToLower().IndexOf("http://") != 0)
                                    {
                                        if (src.IndexOf("/") != 0) src = "/" + src;
                                        src = domain + src;
                                    }
                                    ImageProcess gimg = new ImageProcess(new Uri(src), src);
                                    if (gimg.Width > 150 && gimg.Heigth > 100)
                                    {
                                        string saveLocation = string.Empty;
                                        string gimg_t = Guid.NewGuid().ToString().Replace("-", "");
                                        
                                        string gimg_ten = gimg_t + gimg.Ext;
                                        saveLocation = Path.Combine(@"C:\inetpub\wwwroot\choNongNghiep\web\lib\up\rss", gimg_ten);
                                        gimg.Save(saveLocation);

                                        string gimg_ten_400 = gimg_t + "400" + gimg.Ext;
                                        gimg.Resize(400);
                                        saveLocation = Path.Combine(@"C:\inetpub\wwwroot\choNongNghiep\web\lib\up\rss", gimg_ten_400);
                                        gimg.Save(saveLocation);

                                        string gimg_ten_100 = gimg_t + "100" + gimg.Ext;
                                        gimg.Crop(100, 100);
                                        saveLocation = Path.Combine(@"C:\inetpub\wwwroot\choNongNghiep\web\lib\up\rss", gimg_ten_100);
                                        gimg.Save(saveLocation);


                                        _list.Add(gimg_ten);
                                        break;
                                    }
                                }
                            }
                            Images = _list;
                        }
                    }
                    #endregion
                }
                else
                {
                    if (contentType.ToLower().IndexOf("xml") != -1)
                    {
                    
                    }
                }
            }
            catch (WebException ex)
            {
            }
            #endregion

        }
        public LinkGrap(string link, bool extractLink, bool isRss, string _title, string _mota, string _detail)
        {
            #region xử lý Link
            HttpWebRequest wrq;
            if (link.IndexOf("http://222.255.31.205/") == 0) link = link.Substring("http://222.255.31.205/".Length);
            wrq = (HttpWebRequest)(WebRequest.Create(link));
            string host = new Uri(link).Host;
            wrq.Credentials = CredentialCache.DefaultCredentials;
            wrq.Method = "GET";
            wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
            wrq.SendChunked = true;
            if (link.IndexOf("zing.vn") != -1)
            {
                wrq.Referer = "http://mp3.zing.vn";
            }
            HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
            HtmlDocument doc = new HtmlDocument();
            contentType = wrp.ContentType;
            try
            {

                if (contentType.ToLower().IndexOf("html") != -1)
                {
                    doc.Load(wrp.GetResponseStream(), Encoding.UTF8);
                    string domain = "http://" + (new Uri(link)).Host;
                    #region Title
                    HtmlNode titleNodes = doc.DocumentNode.SelectSingleNode("//*[@" + _title + "]");
                    ///if (doc.DocumentNode.SelectNodes(@"//class='title_bai'")!=null)
                   
                    //if (doc.DocumentNode.SelectNodes("//title | //TITLE") != null)
                    {
                        //   HtmlNode titleNode = doc.DocumentNode.SelectSingleNode(@"//class='title_bai'");//doc.DocumentNode.SelectNodes("//title | //TITLE")[0];
                        Title = titleNodes.InnerText;
                        // Title = doc.DocumentNode.SelectSingleNode("//div[@class='newTitle']").InnerHtml;
                    }

                    #endregion
                    #region Desc
                    //if (doc.documentnode.selectnodes("//meta[@name='description'] | //meta[@name='description']") != null)
                    //{
                    //    htmlnode titlenode = doc.documentnode.selectnodes("//meta[@name='description'] | //meta[@name='description']")[0];
                    //    if (titlenode.attributes["content"] != null)
                    //    {
                    //        description = titlenode.attributes["content"].value;
                    //    }
                    //}
                    //Content = "";
                    //Description = "";

                    HtmlNode titleNodett = doc.DocumentNode.SelectSingleNode("//*[@" + _mota + "]");
                    Description = titleNodett.InnerHtml;
                 //   HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("//*[@" + _detail + "]");
                   // Content = titleNode.InnerHtml;
                  
                    #endregion
                    #region Content
                    //      ContentRawHtml = doc.DocumentNode.InnerHtml;
                    //      ContentRawText = doc.DocumentNode.InnerText;
                    //string _anh = string.Empty;
                    //foreach (HtmlNode _img in doc.DocumentNode.SelectNodes("//img | //IMG"))
                    //{
                    //    if (_img.Attributes["src"] != null)
                    //    {
                    //        string src = _img.Attributes["src"].Value;
                    //        if (src.ToLower().IndexOf("http://") != 0)
                    //        {
                    //            if (src.IndexOf("/") != 0) src = "/" + src;
                    //            src = domain + src;
                    //        }
                    //        ImageProcess gimg = new ImageProcess(new Uri(src), src);
                    //        if (gimg.Width > 200 && gimg.Heigth > 120)
                    //        {
                    //            string newsrc = Guid.NewGuid().ToString() + gimg.Ext;
                    //            // string saveLocation = Path.Combine(@"C:\inetpub\wwwroot\choNongNghiep\web\lib\up\rss", newsrc);
                    //            string saveLocation = Path.Combine(@"C:\inetpub\wwwroot\images", newsrc);
                    //            gimg.Save(saveLocation);
                    //            _img.Attributes["src"].Value = "http://www.agromart.com.vn/Upload/images/" + newsrc;
                    //            _anh = newsrc;
                    //            break;
                    //        }
                    //    }
                    //}
                    //Images.Add(_anh);// = _anh;

                    // Content = Wrapper(host, link, doc);
                    #endregion
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode("//*[@" + _detail + "]");
                  //  MatchCollection m1 = Regex.Matches(Content, @"(<img([^>]+)>)", RegexOptions.Singleline);
                         Regex reImg = new Regex(@"<img\s[^>]*>", RegexOptions.IgnoreCase);
                         List<string> imgScrs = new List<string>();
                         MatchCollection mc = reImg.Matches(_c.InnerHtml);
                         Regex reSrc = new Regex(@"src=(?:(['""])(?<src>(?:(?!\1).)*)\1|(?<src>\S+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                       foreach (Match mImg in mc)
                       {
                          // if (reHeight.IsMatch(HTML))
                           {
                               Match mSrc = reSrc.Match(_c.InnerHtml);
                            //   Console.WriteLine("     src is: {0}", mSrc.Groups["src"].Value);
                               string src = mSrc.Groups["src"].Value;
                              // Title = src;
                               if (src.ToLower().IndexOf("http://") != 0)
                               {
                                   string saveLocation = string.Empty;
                                   if (src.IndexOf("/") != 0) src = "/" + src;
                                   src = domain + src;
                                   ImageProcess gimg = new ImageProcess(new Uri(src), src);
                                   string gimg_t = Guid.NewGuid().ToString().Replace("-", "");

                                   string gimg_ten = gimg_t + gimg.Ext;
                                  saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\agromart2012\web\lib\up\tintuc\rss", gimg_ten);
                                  //saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\Upload\images", gimg_ten);
                                   gimg.Save(saveLocation);

                                   string gimg_ten_400 = gimg_t + "400x400" + gimg.Ext;
                                   gimg.Resize(400);
                                   saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\agromart2012\web\lib\up\tintuc\rss", gimg_ten_400);
                                   gimg.Save(saveLocation);

                                   string gimg_ten_100 = gimg_t + "100x100" + gimg.Ext;
                                   gimg.Crop(100, 100);
                                   saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\agromart2012\web\lib\up\tintuc\rss", gimg_ten_100);
                                   gimg.Save(saveLocation);
                                   imgScrs.Add(gimg_ten);
                                   // Title = _c.InnerHtml;
                               }
                               else
                               {
                                   string saveLocation = string.Empty;
                                  // if (src.IndexOf("/") != 0) src = "/" + src;
                                 //  src = domain + src;
                                   ImageProcess gimg = new ImageProcess(new Uri(src), src);
                                   string gimg_t = Guid.NewGuid().ToString().Replace("-", "");

                                   string gimg_ten = gimg_t + gimg.Ext;
                                   //saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\agromart2012\web\lib\up\tintuc\rss", gimg_ten);
                                   saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\agromart2012\web\lib\up\tintuc\rss", gimg_ten);
                                   gimg.Save(saveLocation);

                                   string gimg_ten_400 = gimg_t + "400x400" + gimg.Ext;
                                   gimg.Resize(400);
                                   saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\agromart2012\web\lib\up\tintuc\rss", gimg_ten_400);
                                   gimg.Save(saveLocation);

                                   string gimg_ten_100 = gimg_t + "100x100" + gimg.Ext;
                                   gimg.Crop(100, 100);
                                   saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\agromart2012\web\lib\up\tintuc\rss", gimg_ten_100);
                                   gimg.Save(saveLocation);
                                   imgScrs.Add(gimg_ten);
                                   //   Regex reImg = new Regex(@"<img\s[^>]*>", RegexOptions.IgnoreCase);
                                   //  List<string> imgScrs = new List<string>();
                                   //    MatchCollection mc = reImg.Matches(_content);
                                   //  Regex reSrc = new Regex(@"src=(?:(['""])(?<src>(?:(?!\1).)*)\1|(?<src>\S+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
/*

                                   foreach (Match mImg1 in mc)
                                   {
                                       // if (reHeight.IsMatch(HTML))
                                       {
                                           Match mSrc1 = reSrc.Match(_c.InnerHtml);
                                           //   Console.WriteLine("     src is: {0}", mSrc.Groups["src"].Value);
                                           string src1 = mSrc1.Groups["src"].Value;
                                           if (src.ToLower().IndexOf("http://") != 0)
                                           {
                                               string pattern = @"src=['](?!http[:]//.*)([^']*)[']";
                                               _c.InnerHtml = Regex.Replace(_c.InnerHtml, pattern, "src='" + host.ToLower() + src1 + "'");
                                           }
                                       }
                                   }
  */
                               }
                           }

                       }
                       Images = imgScrs;
                       Content = WrapperNormal(host, _detail, link, doc);
                      // Content = WrapperNormal(host, _detail, link, doc);
                    // 2.
                    // Loop over each match.
                   
                    //foreach (Match m in m1)
                    //{
                    //    string value = m.Groups[1].Value;
                    //    // LinkItem i = new LinkItem();

                    //    // 3.
                    //    // Get href attribute.
                    //    Match m2 = Regex.Match(value, @"src=\""(.*?)\""",
                    //    RegexOptions.Singleline);
                    //    if (m2.Success)
                    //    {
                    //        string src = m2.Groups[1].Value;
                    //        if (src.ToLower().IndexOf("http://") != 0)
                    //        {
                    //            if (src.IndexOf("/") != 0) src = "/" + src;
                    //            src = domain + src;
                    //            ImageProcess gimg = new ImageProcess(new Uri(src), src);
                    //            string gimg_t = Guid.NewGuid().ToString().Replace("-", "");

                    //            string gimg_ten = gimg_t + gimg.Ext;
                    //            imgScrs.Add(gimg_ten);
                    //            // Title = src;
                    //        }
                    //       // item.Link = String.Format(hosting, m2.Groups[1].Value);
                    //        break;
                    //    }

                    //    // 4.
                    //    // Remove inner tags from text.
                    //    //string t = Regex.Replace(value, @"\s*<.*?>\s*", "",
                    //    //RegexOptions.Singleline);
                    //    //i.Text = t;

                    //    //list.Add(i);
                    //}
                    /*  
                    List<string> imgScrs = new List<string>();
                    HtmlDocument docs = new HtmlDocument();

                    docs.LoadHtml(doc.DocumentNode.SelectSingleNode("//*[@" + _detail + "]").InnerHtml);//or doc.Load(htmlFileStream)
                    var nodes = docs.DocumentNode.SelectNodes(@"//img[@src]");
                    // Title = doc.DocumentNode.SelectSingleNode("//*[@class='detail']").InnerHtml;
                    foreach (var imgs in nodes)
                    {
                        HtmlAttribute att = imgs.Attributes["src"];
                        //imgScrs.Add(att.Value);
                        if (att != null)
                        {
                            string src = att.Value;
                            if (src.ToLower().IndexOf("http://") != 0)
                            {
                                if (src.IndexOf("/") != 0) src = "/" + src;
                                src = domain + src;
                                // Title = src;
                            }
                            ImageProcess gimg = new ImageProcess(new Uri(src), src);
                            if (gimg.Width > 150 && gimg.Heigth > 100)
                            {
                                string saveLocation = string.Empty;
                                string gimg_t = Guid.NewGuid().ToString().Replace("-", "");

                                string gimg_ten = gimg_t + gimg.Ext;
                           
                               // saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\agromart2012\web\lib\up\tintuc\rss", gimg_ten);
                                saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\Upload\images", gimg_ten);
                                gimg.Save(saveLocation);

                                string gimg_ten_400 = gimg_t + "400x400" + gimg.Ext;
                                gimg.Resize(400);
                                saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\Upload\images", gimg_ten_400);
                                gimg.Save(saveLocation);

                                string gimg_ten_100 = gimg_t + "100x100" + gimg.Ext;
                                gimg.Crop(100, 100);
                                saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\Upload\images", gimg_ten_100);
                                gimg.Save(saveLocation);
                                imgScrs.Add(gimg_ten);
                                break;
                            }
                        }
                    }
                    Images = imgScrs;*/

                    //#region Images
                    //if (!string.IsNullOrEmpty(Content))
                    //{
                    //    doc = new HtmlDocument();
                    //    doc.LoadHtml(Content);
                    //    //if (doc.DocumentNode.SelectNodes("//img | //IMG") != null)
                    //  //  _n1.SelectNodes(".//table");
                    //    if (doc.DocumentNode.SelectNodes(".//img") != null)
                    //    {
                    //        List<string> _list = new List<string>();
                    //        foreach (HtmlNode _img in doc.DocumentNode.SelectNodes(".//img"))
                    //        {
                    //            if (_img.Attributes["src"] != null)
                    //            {
                    //                string src = _img.Attributes["src"].Value;
                    //                if (src.ToLower().IndexOf("http://") != 0)
                    //                {
                    //                    if (src.IndexOf("/") != 0) src = "/" + src;
                    //                    src = domain + src;
                    //                }
                    //                ImageProcess gimg = new ImageProcess(new Uri(src), src);
                    //                if (gimg.Width > 150 && gimg.Heigth > 100)
                    //                {
                    //                    string saveLocation = string.Empty;
                    //                    string gimg_t = Guid.NewGuid().ToString().Replace("-", "");

                    //                    string gimg_ten = gimg_t + gimg.Ext;
                    //                    saveLocation = Path.Combine(@"C:\inetpub\wwwroot\choNongNghiep\web\lib\up\rss", gimg_ten);
                    //                    gimg.Save(saveLocation);

                    //                    string gimg_ten_400 = gimg_t + "400" + gimg.Ext;
                    //                    gimg.Resize(400);
                    //                    saveLocation = Path.Combine(@"C:\inetpub\wwwroot\choNongNghiep\web\lib\up\rss", gimg_ten_400);
                    //                    gimg.Save(saveLocation);

                    //                    string gimg_ten_100 = gimg_t + "100" + gimg.Ext;
                    //                    gimg.Crop(100, 100);
                    //                    saveLocation = Path.Combine(@"C:\inetpub\wwwroot\PM\agromart\images", gimg_ten_100);
                    //                    gimg.Save(saveLocation);
                    //                    _list.Add(gimg_ten);
                    //                    break;
                    //                }
                    //            }
                    //        }
                    //        Images = _list;
                    //    }
                    //}
                    //#endregion
                }
                else
                {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                    if (contentType.ToLower().IndexOf("xml") != -1)
                    {

                    }
                }
            }
            catch (WebException ex)
            {
            }
            #endregion
            // Title = Description;

        }
        public LinkGrap(string link)
        {
            LinkGrap Item = null;
            string saveLocation = HostingEnvironment.MapPath("~/lib/u/");
            Item = (LinkGrap)HttpContext.Current.Cache[string.Format(cacheKey, link)];
            if (Item == null)
            {
                #region xử lý Link
                HttpWebRequest wrq;
                wrq = (HttpWebRequest)(WebRequest.Create(link));
                string host = new Uri(link).Host;
                wrq.Credentials = CredentialCache.DefaultCredentials;
                wrq.Method = "GET";
                wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
                wrq.SendChunked = true;
                if (link.IndexOf("zing.vn") != -1)
                {
                    wrq.Referer = "http://mp3.zing.vn";
                }
                try
                {
                    HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
                    HtmlDocument doc = new HtmlDocument();
                    contentType = wrp.ContentType;
                    if (contentType.ToLower().IndexOf("html") != -1)
                    {
                        doc.Load(wrp.GetResponseStream(), Encoding.UTF8);
                        string domain = "http://" + (new Uri(link)).Host;
                        #region Title
                        if (doc.DocumentNode.SelectNodes("//title | //TITLE") != null)
                        {
                            HtmlNode titleNode = doc.DocumentNode.SelectNodes("//title | //TITLE")[0];
                            Title = titleNode.InnerText;
                        }
                        #endregion
                        #region Desc
                        if (doc.DocumentNode.SelectNodes("//meta[@name='description'] | //meta[@name='DESCRIPTION']") != null)
                        {
                            HtmlNode titleNode = doc.DocumentNode.SelectNodes("//meta[@name='description'] | //meta[@name='DESCRIPTION']")[0];
                            Description = titleNode.Attributes["content"].Value;
                        }
                        #endregion
                        #region Content
                        ContentRawHtml = doc.DocumentNode.InnerHtml;
                        ContentRawText = doc.DocumentNode.InnerText;
                        Content = Wrapper(host, link, doc);
                        #endregion
                        #region Images
                        //if (doc.DocumentNode.SelectNodes("//img | //IMG") != null)
                        //{
                        //    List<string> _list = new List<string>();
                        //    foreach (HtmlNode _img in doc.DocumentNode.SelectNodes("//img | //IMG"))
                        //    {
                        //        if (_img.Attributes["src"] != null)
                        //        {
                        //            string src = _img.Attributes["src"].Value;
                        //            if (src.ToLower().IndexOf("http://") != 0)
                        //            {
                        //                src = domain + src;
                        //            }
                        //            _list.Add(src);
                        //        }
                        //    }
                        //    Images = _list;
                        //}
                        #endregion
                        #region Link
                        List<string> _inLink = new List<string>();
                        List<string> _outLink = new List<string>();
                        foreach (HtmlNode a in doc.DocumentNode.SelectNodes("//a|//A"))
                        {
                            string href = string.Empty;
                            if (a.Attributes["href"] != null)
                            {
                                href = a.Attributes["href"].Value;
                            }
                            else if (a.Attributes["HREF"] != null)
                            {
                                href = a.Attributes["HREF"].Value;
                            }
                            if (!string.IsNullOrEmpty(href))
                            {
                                if (href.ToLower().IndexOf("javascrip") != 0 && href.ToLower().IndexOf("#") != 0)
                                {
                                    if (href.ToLower().IndexOf("http://") == 0)//HTTPLink
                                    {
                                        Uri _href = new Uri(href);
                                        if (_href.Host.ToLower().IndexOf(host.ToLower()) != -1)
                                        {
                                            _inLink.Add(href);
                                        }
                                        else
                                        {
                                            _outLink.Add(href);
                                        }
                                    }
                                    else
                                    {
                                        if (href.ToLower().IndexOf("/") == -1) href = "/" + href;
                                        if (href.ToLower().IndexOf("../") == 0) href = href.Substring(href.LastIndexOf("../") + 3);
                                        href = "http://" + host + href;
                                        _inLink.Add(href);
                                    }
                                }
                            }
                            InLink = _inLink;
                            OutLink = _outLink;
                        }
                        #endregion

                    }
                    #region Ảnh
                    //else
                    //{
                    //    if (contentType.IndexOf("image") != -1)
                    //    {
                    //        Title = link;
                    //        Description = link;
                    //        List<string> _list = new List<string>();
                    //        ImageProcess gimg = new ImageProcess(new Uri(link), link);
                    //        if (gimg.Width > 100 && gimg.Heigth > 75)
                    //        {
                    //            _list.Add(link);
                    //        }
                    //        Images = _list;
                    //    }
                    //}
                    #endregion
                    HttpContext.Current.Cache.Insert(string.Format(cacheKey, link), this);
                }
                catch (WebException ex)
                {
                    LinkGrap _obj2 = new LinkGrap();
                    _obj2.Title = "0";
                    HttpContext.Current.Cache.Remove(string.Format(cacheKey, link));
                }
                #endregion
            }
        }
        public static List<LinkGrap> GetLinkFromRss(string link)
        {
            List<LinkGrap> List = new List<LinkGrap>();
            #region xử lý Link
            HttpWebRequest wrq;
            wrq = (HttpWebRequest)(WebRequest.Create(link));
            string host = new Uri(link).Host;
            wrq.Credentials = CredentialCache.DefaultCredentials;
            wrq.Method = "GET";
            wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
            wrq.SendChunked = false;
            if (link.IndexOf("zing.vn") != -1)
            {
                wrq.Referer = "http://mp3.zing.vn";
            }
            try
            {
                using (HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse())
                {
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        doc.Load(wrp.GetResponseStream());
                        XmlNodeList _l = doc.SelectNodes("//item");
                        if (List != null)
                        {
                            foreach (XmlNode n in _l)
                            {
                                LinkGrap item = new LinkGrap();
                                if (n.SelectSingleNode("title") != null)
                                {
                                    item.Title = n.SelectSingleNode("title").InnerText;
                                }
                                if (n.SelectSingleNode("description") != null)
                                {
                                    item.Description = n.SelectSingleNode("description").InnerText;

                                }
                                if (n.SelectSingleNode("link | LINK") != null)
                                {
                                    string itemlink = n.SelectSingleNode("link | LINK").InnerText.Trim();                                    
                                    if (itemlink.IndexOf("http://nld.com.vnhttp://worldcup") != -1) itemlink = itemlink.Substring("http://nld.com.vn".Length);
                                    item.Link = itemlink;
                                }
                                List.Add(item);
                            }
                        }
                    }
                    catch (XmlException xmlex)
                    {
                    }
                }
            }
            catch (WebException ex)
            {
                LinkGrap _obj2 = new LinkGrap();
                _obj2.Title = "0";
            }
            #endregion
            return List;
        }        
        public static List<LinkGrap> GetRss(string link)
        {
            List<LinkGrap> List = new List<LinkGrap>();
            #region xử lý Link
            HttpWebRequest wrq;
            wrq = (HttpWebRequest)(WebRequest.Create(link));
            string host = new Uri(link).Host;
            wrq.Credentials = CredentialCache.DefaultCredentials;
            wrq.Method = "GET";
            wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
            wrq.SendChunked = true;
            if (link.IndexOf("zing.vn") != -1)
            {
                wrq.Referer = "http://mp3.zing.vn";
            }
            try
            {
                using (HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse())
                {
                    HtmlDocument doc = new HtmlDocument();
                    doc.Load(wrp.GetResponseStream());
                    foreach (HtmlNode a in doc.DocumentNode.SelectNodes(@"//a[contains(text(),'rss') and contains(@href,'rss')]"))
                    {
                        LinkGrap item = new LinkGrap();
                        item.Link = a.Attributes["href"].Value;
                        item.Title = a.InnerText;
                        List.Add(item);
                    }
                }
            }
            catch (WebException ex)
            {
                LinkGrap _obj2 = new LinkGrap();
                _obj2.Title = "0";
            }
            #endregion
            return List;
        }

        #region xu ly link khong rss
        public  void insertLink(string link, string _class)
        {
            string domain = "http://" + (new Uri(link)).Host;
            HttpWebRequest wrq;
            wrq = (HttpWebRequest)(WebRequest.Create(link));
            string host = new Uri(link).Host;
            wrq.Credentials = CredentialCache.DefaultCredentials;
            wrq.Method = "GET";
            wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
            wrq.SendChunked = true;
            HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(wrp.GetResponseStream(), Encoding.UTF8);
            HtmlNode _n1 = doc.DocumentNode.SelectSingleNode(@"//td[@class='" + _class + "']");
            HtmlNode _n2 = _n1.SelectSingleNode(@"table/tbody");
            HtmlNode _n11 = _n2.ChildNodes[1];
            HtmlNode _n12 = _n2.ChildNodes[5].ChildNodes[1];
            HtmlNode _n13 = _n12.SelectSingleNode("i");
            HtmlNode _n14 = _n12.SelectSingleNode("span[@class='text666666 textnormalbold']");
            _n12.RemoveChild(_n13);
            _n12.RemoveChild(_n14);
            string _anh = string.Empty;
            foreach (HtmlNode _img in _n12.SelectNodes("//img | //IMG"))
            {
                if (_img.Attributes["src"] != null)
                {
                    string src = _img.Attributes["src"].Value;
                    if (src.ToLower().IndexOf("http://") != 0)
                    {
                        if (src.IndexOf("/") != 0) src = "/" + src;
                        src = domain + src;
                    }
                    ImageProcess gimg = new ImageProcess(new Uri(src), src);
                    if (gimg.Width > 200 && gimg.Heigth > 120)
                    {
                        string newsrc = Guid.NewGuid().ToString() + gimg.Ext;
                        // string saveLocation = Path.Combine(@"C:\inetpub\wwwroot\choNongNghiep\web\lib\up\rss", newsrc);
                        string saveLocation = Path.Combine(@"C:\inetpub\wwwroot\images", newsrc);
                        gimg.Save(saveLocation);
                        _img.Attributes["src"].Value = "http://www.agromart.com.vn/Upload/images/" + newsrc;
                        _anh = newsrc;
                        break;
                    }
                }
            }
           // insert(_n11.InnerText, _n14.InnerText, _n12.InnerHtml, _anh, link, "1", _n13.InnerText);
            //sb.AppendFormat("{0}<br/>{1}<br/>{2}<br/>{3}<br/>{4}", _n11.InnerText, _n12.InnerHtml, _n13.InnerText, _n14.InnerText, "");
        }
        public static List<LinkGrap> getLinkLists(string link, string _class)
        {
        // string   status = "Nạp danh sách";
            List<LinkGrap> List = new List<LinkGrap>();
            HttpWebRequest wrq;
            wrq = (HttpWebRequest)(WebRequest.Create(link));
            string host = new Uri(link).Host;
            wrq.Credentials = CredentialCache.DefaultCredentials;
            wrq.Method = "GET";
            wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
            wrq.SendChunked = true;
            HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(wrp.GetResponseStream(), Encoding.UTF8);
            HtmlNode _n1 = doc.DocumentNode.SelectSingleNode(@"//td[@class='"+_class+"']");
            HtmlNode _n2 = _n1.SelectSingleNode(@"table");
           
            HtmlNodeCollection _nl = _n2.SelectNodes("tr");
          //  status = "Đọc danh sách";
            foreach (HtmlNode _n3 in _nl)
            {
                LinkGrap item = new LinkGrap();
                HtmlNode _n11 = _n3.SelectSingleNode("td/table");
                HtmlNode _n111 = _n11.ChildNodes[1].ChildNodes[1].ChildNodes[1];
                item.Link =  _n111.Attributes["href"].Value;
                item.Title = _n3.InnerText;
                List.Add(item);
            }
            //foreach (HtmlNode _n3 in _nl)
            //{
            //    HtmlNode _n11 = _n3.SelectSingleNode("td/table");
            //    HtmlNode _n111 = _n11.ChildNodes[1].ChildNodes[1].ChildNodes[1];
            //    HtmlNode _n112 = _n11.ChildNodes[5].ChildNodes[1].ChildNodes[1];
            //    insertLinkDeledate _dele = new insertLinkDeledate(insertLink);
            //    _dele.BeginInvoke(string.Format("http://www.ttnn.com.vn{0}", _n111.Attributes["href"].Value), null, null);
            //}
            return List;
        }
        #endregion

        #region Xử lý nội dung
        public string Wrapper(string host, string _link, HtmlDocument doc)
        {
            string _content = string.Empty;
            doc = WrapperClean(host, _link, doc);
            /*
            if (host.ToLower().IndexOf("vnexpress.net") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='Title']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='Title']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='Lead']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='Lead']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@cpms_content='true']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@cpms_content='true']");
                    _content = _c.InnerHtml;
                }
            }

            else if (host.ToLower().IndexOf("quantrimang.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='infoDetail']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='infoDetail']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("dantri.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//*[@class='fon34 mt3 mr2 fon43']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//*[@class='fon34 mt3 mr2 fon43']");                    
                    _content = _c.InnerHtml;
                }
                //fon34 mt3 mr2 fon43
            }
            else if (host.ToLower().IndexOf("vietnamnet.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//*[@id='content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//*[@id='content']");
                    if (doc.DocumentNode.SelectSingleNode("//img[class='logo']") != null)
                    {
                        HtmlNode _logo = doc.DocumentNode.SelectSingleNode("//img[class='logo']");
                        _logo.ParentNode.RemoveChild(_logo, false);
                    }
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("kenh14.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//*[@id='ctl00_ContentPlaceHolder1_ctl00_lblNews_Content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//*[@id='ctl00_ContentPlaceHolder1_ctl00_lblNews_Content']");
                    _content = _c.InnerHtml;
                }
                if (doc.DocumentNode.SelectSingleNode(@"//*[@class='content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//*[@class='content']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("ngoisao.net") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//h1[@class='Title']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//h1[@class='Title']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//h2[@class='Lead']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//h2[@class='Lead']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//*[@cpms_content='true']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//*[@cpms_content='true']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("zing.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//h1[@class='pTitle']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//h1[@class='pTitle']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='pHead']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='pHead']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//*[@id='content_document']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//*[@id='content_document']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("thanhnien.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='pageContent']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='pageContent']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("24h.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='text-content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='text-content']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("cafef.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='KenhF_Content_News3']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='KenhF_Content_News3']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("tienphong.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='pTitle']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='pTitle']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='pHead']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='pHead']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='divContent']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='divContent']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("vtc.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='pageContent']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='pageContent']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("nld.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='content']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("laodong.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='NewsContent']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='NewsContent']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("pcworld.com.vn") != -1)
            {
                //if (doc.DocumentNode.SelectSingleNode(@"//td[@class='keyword']") != null)
                //{
                //    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//td[@class='keyword']");
                //    if (_c.ParentNode.ParentNode.ParentNode != null)
                //    {
                //        HtmlNode _cP = _c.ParentNode.ParentNode.ParentNode;
                //        _cP.ParentNode.RemoveChild(_cP, false);
                //    }

                //}
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='ar-content-html']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='ar-content-html']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("bongda.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='ctl00_BD_art_pnlNewsContainer']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='ctl00_BD_art_pnlNewsContainer']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("tuoitre.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='pTitle']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='pTitle']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='pHead']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='pHead']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='pSuperTitle']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='pSuperTitle']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='divContent']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='divContent']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("muctim.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//span[@class='Detail-Body']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//span[@class='Detail-Body']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("giadinh.net.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='ctl00_cphMain_gd_divTin_Chi_Tiet']/h1") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='ctl00_cphMain_gd_divTin_Chi_Tiet']/h1");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='ctl00_cphMain_gd_divTin_Chi_Tiet']/p[@class='sapo']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='ctl00_cphMain_gd_divTin_Chi_Tiet']/p[@class='sapo']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='ctl00_cphMain_gd_divTin_Chi_Tiet']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='ctl00_cphMain_gd_divTin_Chi_Tiet']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("vovnews.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//span[@id='ctl00_mContent_lbBody']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//span[@id='ctl00_mContent_lbBody']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("autonet.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='title']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='title']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='author box']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='author box']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='article']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='article']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("baodatviet.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//span[@id='DetailtBody1_lbBody']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//span[@id='DetailtBody1_lbBody']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("xaluan.com") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//h1[@class='Title']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//h1[@class='Title']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='Lead']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='Lead']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='emailprintback']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='emailprintback']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='VietAd']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='VietAd']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("thesaigontimes.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//span[@id='ctl00_cphContent_lblContentHtml']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//span[@id='ctl00_cphContent_lblContentHtml']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("vneconomy.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='divBodyTinChiTiet']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='divBodyTinChiTiet']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("vnmedia.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//td[@class='news_body']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//td[@class='news_body']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("vietnamplus.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='dtText']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='dtText']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("infotv.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='article-content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='article-content']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("tinkinhte.com") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//h1[@class='headline']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//h1[@class='headline']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='toolbox']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='toolbox']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//label[@class='dateline']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//label[@class='dateline']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='uss_art_detail_01']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='uss_art_detail_01']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("vnecono.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='article-content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='article-content']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("dddn.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='cat_name']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='cat_name']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='tinmoi']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='tinmoi']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='send-cm']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='send-cm']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='detail_content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='detail_content']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("ictnews.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='PTitle']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='PTitle']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='clearfix']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='clearfix']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='TagsContainer']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='TagsContainer']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='ArticleView']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='ArticleView']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("xahoithongtin.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='vote']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='vote']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='infovote']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='infovote']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='cont-article-main']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='cont-article-main']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("vinacorp.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='details']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='details']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("ione.net") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//h1[@class='Title']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//h1[@class='Title']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//h5[@class='timePost']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//h5[@class='timePost']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//p[@class='Lead']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//p[@class='Lead']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='tag_content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='tag_content']");
                    _c.ParentNode.RemoveChild(_c, false);
                }

                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='dtContent']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='dtContent']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("advice.vietnamworks.com") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//strong[contains(text(),'Bạn có thắc mắc liên quan')]") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//strong[contains(text(),'Bạn có thắc mắc liên quan')]");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                //[contains(text(),'ABC')]
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='vnw_nodedetail']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='vnw_nodedetail']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("autopro.com.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
                //[contains(text(),'ABC')]
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='mt3']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='mt3']");
                    _content = _c.InnerHtml;
                }
            }
            */
            ///
            if (host.ToLower().IndexOf("nongnghiep.vn") != -1)
            //else if (host.ToLower().IndexOf("agroviet.gov.vn") != -1)
            {
                //if (doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']") != null)
                //{
                //    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']");
                //    _c.ParentNode.RemoveChild(_c, false);
                //}
                //[contains(text(),'ABC')]
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='VietAd']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='VietAd']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("vietnamnet.vn") != -1)
            {
                //if (doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']") != null)
                //{
                //    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']");
                //    _c.ParentNode.RemoveChild(_c, false);
                //}
                //[contains(text(),'ABC')]
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='content']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='content']");
                    _content = _c.InnerHtml;
                }
            }
            else if (host.ToLower().IndexOf("tinkinhte.com") != -1)
            {
                //if (doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']") != null)
                //{
                //    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']");
                //    _c.ParentNode.RemoveChild(_c, false);
                //}
                //[contains(text(),'ABC')]
                if (doc.DocumentNode.SelectSingleNode(@"//div[@id='ussslot1_48_2_5']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='ussslot1_48_2_5']");
                    _content = _c.InnerHtml;
                }
            }
            return _content;
        }

        public HtmlDocument WrapperClean(string host, string link, HtmlDocument doc)
        {
            string domain = "http://" + host;
            HtmlNodeCollection nc = doc.DocumentNode.SelectNodes("//script|//link|//iframe|//frameset|//frame|//applet|//object");
            if (nc != null)
            {
                foreach (HtmlNode node in nc)
                {
                    node.ParentNode.RemoveChild(node, false);

                }
            }

            //remove hrefs to java/j/vbscript URLs
            nc = doc.DocumentNode.SelectNodes("//a[starts-with(@href, 'javascript')]|//a[starts-with(@href, 'jscript')]|//a[starts-with(@href, 'vbscript')]");
            if (nc != null)
            {

                foreach (HtmlNode node in nc)
                {
                    node.SetAttributeValue("href", "protected");
                }
            }



            //remove img with refs to java/j/vbscript URLs
            nc = doc.DocumentNode.SelectNodes("//img[starts-with(@src, 'javascript')]|//img[starts-with(@src, 'jscript')]|//img[starts-with(@src, 'vbscript')]");
            if (nc != null)
            {
                foreach (HtmlNode node in nc)
                {
                    node.SetAttributeValue("src", "protected");
                }
            }

            //remove on<Event> handlers from all tags
            nc = doc.DocumentNode.SelectNodes("//*[@onclick or @onmouseover or @onfocus or @onblur or @onmouseout or @ondoubleclick or @onload or @onunload]");
            if (nc != null)
            {
                foreach (HtmlNode node in nc)
                {
                    node.Attributes.Remove("onFocus");
                    node.Attributes.Remove("onBlur");
                    node.Attributes.Remove("onClick");
                    node.Attributes.Remove("onMouseOver");
                    node.Attributes.Remove("onMouseOut");
                    node.Attributes.Remove("onDoubleClick");
                    node.Attributes.Remove("onLoad");
                    node.Attributes.Remove("onUnload");
                }
            }

            if (host.ToLower().IndexOf("vietnamnet.com.vn") != -1)
            {
                HtmlNode nc1 = doc.DocumentNode.SelectSingleNode(@"//span[@class='tinTuc-moTa-chitiet']"); //doc.DocumentNode.SelectSingleNode("//*[@'tinTuc-moTa-chitiet']");
               // nc1.RemoveChild(nc1.FirstChild());
                nc1.RemoveChild(nc1.FirstChild);
               // src = link + "/" + src;
            }
            HtmlNodeCollection ncImg = doc.DocumentNode.SelectNodes("//img | //IMG");
            if(ncImg!=null)
            {
                foreach (HtmlNode _img in ncImg)
                {
                    if (_img.Attributes["src"] != null)
                    {
                        string src = _img.Attributes["src"].Value;
                        if (host.ToLower().IndexOf("ngoisao.net") != -1)
                        {
                            src = link + "/" + src;
                        }
                        if (host.ToLower().IndexOf("www.tienphong.vn") != -1)
                        {
                            if (src.IndexOf("ImageHandler.ashx") != -1)
                            {
                                src = "http://www.tienphong.vn/" + src.Substring(src.IndexOf("ImageHandler.ashx"));
                            }
                        }
                        else if (host.ToLower().IndexOf("xaluan.com") != -1)
                        {
                            if (src.IndexOf("http://") == -1)
                            {
                                src = "http://www.xaluan.com/" + src;
                            }
                        }
                        else
                        {
                            if (src.ToLower().IndexOf("http://") != 0)
                            {
                                src = domain + src;
                            }
                        }
                        _img.SetAttributeValue("src", src);
                    }
                }
            }
            HtmlNodeCollection ncA = doc.DocumentNode.SelectNodes("//a|//A");
            if (ncA != null)
            {
                foreach (HtmlNode a in ncA)
                {
                    string href = string.Empty;
                    if (a.Attributes["href"] != null)
                    {
                        href = a.Attributes["href"].Value;
                    }
                    else if (a.Attributes["HREF"] != null)
                    {
                        href = a.Attributes["HREF"].Value;
                    }
                    if (!string.IsNullOrEmpty(href))
                    {
                        if (href.ToLower().IndexOf("javascrip") != 0 && href.ToLower().IndexOf("#") != 0 && href.ToLower().IndexOf("ymsgr:") != 0)
                        {
                            href = href.Trim();
                            if (href.ToLower().IndexOf("/") == -1) href = "/" + href;
                            if (href.ToLower().IndexOf("../") == 0) href = href.Substring(href.LastIndexOf("../") + 3);
                            if (href.ToLower().IndexOf("http://") != 0) href = "http://" + host + href;
                            try
                            {
                                Uri _href = new Uri(href);
                                if (_href.Host.ToLower().IndexOf(host.ToLower()) != -1)
                                {
                                    a.SetAttributeValue("href", href);
                                    a.Attributes.Remove("target");
                                }
                                else
                                {
                                    a.ParentNode.RemoveChild(a, true);
                                }
                            }
                            catch (Exception ex)
                            {
                                a.ParentNode.RemoveChild(a, true);
                            }

                        }
                    }
                }
            }
            if (doc.DocumentNode.SelectNodes("//*") != null)
            {
                foreach (HtmlNode _n in doc.DocumentNode.SelectNodes("//*"))
                {
                    _n.Attributes.Remove("style");
                    //_n.Attributes.Remove("class");
                    _n.Attributes.Remove("align");
                    _n.Attributes.Remove("color");
                }
            }
            return doc;
        }
        public string WrapperNormal(string host,string _class, string _link, HtmlDocument doc)
        {
            string _content = string.Empty;
            doc = WrapperClean(host, _link, doc);
            /*
            
            */
            ///
            //if (host.ToLower().IndexOf("nongnghiep.vn") != -1)
            ////else if (host.ToLower().IndexOf("agroviet.gov.vn") != -1)
            //{
            //    //if (doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']") != null)
            //    //{
            //    //    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='box10 mt2']");
            //    //    _c.ParentNode.RemoveChild(_c, false);
            //    //}
            //    //[contains(text(),'ABC')]
            //    if (doc.DocumentNode.SelectSingleNode(@"//div[@id='VietAd']") != null)
            //    {
            //        HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@id='VietAd']");
            //        _content = _c.InnerHtml;
            //    }
            //}
           // else 
            if (host.ToLower().IndexOf("nongnghiep.vn") != -1)
            {
                if (doc.DocumentNode.SelectSingleNode(@"//div[@class='cat_other']") != null)
                {
                    HtmlNode _c = doc.DocumentNode.SelectSingleNode(@"//div[@class='cat_other']");
                    _c.ParentNode.RemoveChild(_c, false);
                }
            }
            if (host.ToLower().IndexOf("thuongmai.vn") != -1)
            {
                HtmlNode _c = doc.DocumentNode.SelectSingleNode("//*[@" + _class + "]");
                _content = Regex.Replace(_c.InnerHtml.ToString(), @"<span[^>]+class=""ja-social-bookmarking""[^>]*>", "<span>");
                _content = Regex.Replace(_content, @"<ul.*?>.*?</ul>", "");
                _content = Regex.Replace(_content, @"<ul>(?<t>.*?)</ul>", "");
                _content = Regex.Replace(_content, @"<div id=""olderitemtitle"".*?>(?<t>.*?)</div>", "");
                _content = Regex.Replace(_content, @"<div id=""prev_next_buttom"".*?>(?<t>.*?)</div>", "");
                _content = Regex.Replace(_content, @"<div id=""neweritemtitle"".*?>(?<t>.*?)</div>", "");
                //_content = _c.InnerHtml;

            }
            else
            { 
             HtmlNode _c = doc.DocumentNode.SelectSingleNode("//*[@" + _class + "]");
            _content = _c.InnerHtml.ToString();
            _content = Regex.Replace(_content, @"<ul.*?>.*?</ul>", "");
            _content = Regex.Replace(_content, @"<ul>(?<t>.*?)</ul>", "");
            //_content = Regex.Replace(_content, @"<div id=""box_comment"".*?>(?<t>.*?)</div>", "");
           // _content = Regex.Replace(_content, @"<div class=""cat_other"".*?>(.*?)</div>", "", RegexOptions.Multiline);
            _content = Regex.Replace(_content, @"<div id=""detail_new_other"" class=""cat_other"".*?>(.|\n)*?</div>", "", RegexOptions.Multiline);
            _content = Regex.Replace(_content, @"<div id=""box_comment"".*?>(.|\n)*?</div>", "", RegexOptions.Multiline);
            _content = Regex.Replace(_content, @"<div id=""detail_new_other"".*?>(?<t>.*?)</div>", "");
            _content = Regex.Replace(_content, @"<div id=""detail_new_other"" class=""cat_other"".*?>(.|\n)*?</div>", "");
           
                
            }
           
            Regex reImg = new Regex(@"<img\s[^>]*>", RegexOptions.IgnoreCase);
            List<string> imgScrs = new List<string>();
            MatchCollection mc = reImg.Matches(_content);
            Regex reSrc = new Regex(@"src=(?:(['""])(?<src>(?:(?!\1).)*)\1|(?<src>\S+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (host.ToLower().IndexOf("sgtt.vn") != -1)
            {
                host = "http://sgtt.vn";
            }
           // Title = "vao day";
            foreach (Match mImg in mc)
            {
               
                // if (reHeight.IsMatch(HTML))
                {
                    Match mSrc = reSrc.Match(_content);
                    //   Console.WriteLine("     src is: {0}", mSrc.Groups["src"].Value);
                    string src = mSrc.Groups["src"].Value;
                    
                    if (src.ToLower().IndexOf("http://") != 0)
                    {
                      //  Title += host + src;
                       // string pattern = @"src=['""](?!http[:]//.*)([^']*)[""]";
                       // _content = Regex.Replace(_content, pattern, "src='"+host.ToLower() + src + "'");
                        //string pattern = @"src=['](?!http[:]//.*)([^']*)[']";
                        if (host.ToLower().IndexOf("http://") != 0)
                        {
                            host = "http://" + host;
                        }
                        _content = Regex.Replace(_content, @"<img\s[^>]*>", "<img src='" + host.ToLower()  +src + "' />");
                    }
                }
            }
            return _content+host;
        }
        #endregion
    }
    public class LinkKeyword : IDisposable
    {
        public string key { get; set; }
        public int count { get; set; }
        public List<int> index { get; set; }
        public int loai { get; set; }
        public bool kill { get; set; }
        public string content { get; set; }
        public LinkKeyword(string _key, int _count, List<int> _index)
        {
            key = _key;
            count = _count;
            index = _index;
        }
        public LinkKeyword(string _key, int _count, List<int> _index, int _loai)
        {
            key = _key;
            count = _count;
            index = _index;
            loai = _loai;
        }
        public LinkKeyword(string _key, int _count, List<int> _index, int _loai, bool _kill)
        {
            key = _key;
            count = _count;
            index = _index;
            loai = _loai;
            kill = _kill;
        }
        public LinkKeyword() { }
        public IEnumerable<LinkKeyword> ListKeywordIEnum { get; set; }
        public Dictionary<string, LinkKeyword> ListKeyWord { get; set; }
        public LinkKeyword(string _content)
        {
            Dictionary<int, string> _IndexDic = GetIndexDic(_content);
            Dictionary<string, LinkKeyword> _DuplicateDic = GetDuplicateDic(_IndexDic);
            Dictionary<string, LinkKeyword> Dic2 = GetDic(_DuplicateDic, _IndexDic, _DuplicateDic);
            var dicList = (from keyw in Dic2
                           where keyw.Value.count > 1 && keyw.Value.kill == false
                           orderby keyw.Value.count descending, keyw.Value.loai descending
                           select keyw.Value).Take(20);
            ListKeywordIEnum = dicList;
            ListKeyWord = new Dictionary<string, LinkKeyword>();
            foreach (LinkKeyword key in dicList)
            {
                ListKeyWord.Add(key.key, key);
            }
        }
        public Dictionary<int, string> GetIndexDic(string inputString)
        {
            Dictionary<int, string> IndexDic = new Dictionary<int, string>();
            int i = 0;
            foreach (string item in inputString.Replace(",", "").Trim().Split(new char[] { ' ', '.' }))
            {
                if (item.Replace(" ", "").Trim().Length > 1)
                {
                    IndexDic.Add(i, item.Trim());
                    i++;
                }
            }
            return IndexDic;
        }
        public Dictionary<string, LinkKeyword> GetDuplicateDic(Dictionary<int, string> IndexDic)
        {
            Dictionary<string, LinkKeyword> DuplicateDic = new Dictionary<string, LinkKeyword>();

            foreach (KeyValuePair<int, string> item in IndexDic)
            {
                if (DuplicateDic.ContainsKey(item.Value))
                {
                    LinkKeyword _Key = DuplicateDic[item.Value];
                    List<int> List = _Key.index;
                    List.Add(item.Key);
                    DuplicateDic[item.Value] = new LinkKeyword(item.Value, DuplicateDic[item.Value].count + 1, List, 1);
                }
                else
                {
                    List<int> List = new List<int>();
                    List.Add(item.Key);
                    DuplicateDic.Add(item.Value, new LinkKeyword(item.Value, 1, List, 1));
                }
            }
            return DuplicateDic;
        }
        public Dictionary<string, LinkKeyword> GetDic(Dictionary<string, LinkKeyword> inputDic
        , Dictionary<int, string> IndexDic
        , Dictionary<string, LinkKeyword> DuplicateDic)
        {
            Dictionary<string, LinkKeyword> Dic8 = new Dictionary<string, LinkKeyword>();
            if (inputDic.Count > 0)
            {
                foreach (LinkKeyword item in new List<LinkKeyword>(inputDic.Values))
                {
                    if (item.count > 1)
                    {
                        int KeySize = item.loai;
                        foreach (int _index in item.index)
                        {
                            int newIndex = _index + KeySize;
                            if (newIndex < IndexDic.Count)
                            {
                                if (DuplicateDic.ContainsKey(IndexDic[newIndex]))
                                {
                                    string newKey = item.key + " " + IndexDic[newIndex];
                                    if (Dic8.ContainsKey(newKey))
                                    {
                                        LinkKeyword _Key = Dic8[newKey];
                                        List<int> List = _Key.index;
                                        List.Add(_index);
                                        Dic8[newKey] = new LinkKeyword(_Key.key, _Key.count + 1, List, KeySize + 1, false);
                                    }
                                    else
                                    {
                                        List<int> List = new List<int>();
                                        List.Add(_index);
                                        Dic8.Add(newKey, new LinkKeyword(newKey, 1, List, KeySize + 1, false));
                                    }
                                    //if (newIndex + 1 < IndexDic.Count)
                                    //{
                                    //    if (!DuplicateDic.ContainsKey(IndexDic[newIndex + 1]))
                                    //    {

                                    //    }
                                    //}
                                }
                            }
                        }
                    }
                }
                Dictionary<string, LinkKeyword> DicNone = GetDic(Dic8, IndexDic, DuplicateDic);
                foreach (KeyValuePair<string, LinkKeyword> item in DicNone)
                {
                    if (item.Value.loai > 1 && item.Value.count > 1)
                    {
                        string itemChild = item.Value.key.Substring(0, item.Value.key.LastIndexOf(" "));
                        if (Dic8.ContainsKey(itemChild))
                        {
                            LinkKeyword removeKey = Dic8[itemChild];
                            removeKey.kill = true;
                            Dic8[itemChild] = removeKey;
                        }
                    }
                    if (Dic8.ContainsKey(item.Key))
                    {
                        LinkKeyword _Key = Dic8[item.Key];
                        Dic8[item.Key] = new LinkKeyword(_Key.key, _Key.count + 1, _Key.index, item.Value.loai, _Key.kill);
                    }
                    else
                    {
                        Dic8.Add(item.Key, item.Value);
                    }
                }
            }
            return Dic8;
        }

        #region IDisposable Members
        bool disposed = false;
        public void Dispose()
        {
            if (!this.disposed)
            {
                if (content != null)
                {
                    content = null;
                    ListKeyWord.Clear();
                    ListKeywordIEnum = null;
                    GC.SuppressFinalize(this);
                }
            }
        }

        #endregion
    }
}
