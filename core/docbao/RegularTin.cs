using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Hosting;
using HtmlAgilityPack;
using docbao.entitites;
using linh.controls;

namespace docbao
{
    public class RegularTin
    {
        public RegularTin() { }
        public Dictionary<string, LinkKeyword> KeyWords { get; set; }
        public string Url { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public string Anh { get; set; }
        public HtmlAgilityPack.HtmlDocument loadDoc(string _url)
        {
            var wrq = (HttpWebRequest)(WebRequest.Create(_url));
            string host = new Uri(_url).Host;
            wrq.Credentials = CredentialCache.DefaultCredentials;
            wrq.Method = "GET";
            wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
            wrq.SendChunked = false;
            var wrp = (HttpWebResponse)wrq.GetResponse();
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(wrp.GetResponseStream(), Encoding.UTF8);
            return doc;
        }
        public RegularTin(string url)
        {
            string _host = string.Empty;
            _host = new Uri(url).Host.ToLower();
            HtmlAgilityPack.HtmlDocument doc = loadDoc(url);
            List<QuyTac> List = QuyTacDal.SelectByHost(_host).ToList();
            WrapperClean(_host, url, doc);
            #region Lấy Ten,Mota, Noi Dung
            foreach (QuyTac item in List)
            {
                HtmlNode _c = doc.DocumentNode.SelectSingleNode(@item.Xpath);
                switch (item.Loai)
                {
                    case 0:// renew doc
                        if (_c != null)
                        {
                            doc = new HtmlAgilityPack.HtmlDocument();
                            doc.LoadHtml(_c.InnerHtml);
                        }
                        break;
                    case 1:// Title
                        if (_c != null)
                        {
                            Ten = _c.InnerText;
                        }
                        else
                        {
                            _c = doc.DocumentNode.SelectNodes(@"//title | //TITLE")[0];
                            if (_c != null)
                            {
                                Ten = _c.InnerText;
                            }
                        }
                        break;
                    case 2:
                        if (_c != null)
                        {
                            MoTa = _c.InnerHtml;
                        }
                        else
                        {
                            _c = doc.DocumentNode.SelectNodes(@"//meta[@name='description'] | //meta[@name='DESCRIPTION'] | //meta[@name='Description']")[0];
                            if (_c != null)
                            {
                                MoTa = _c.InnerText;
                            }
                        }
                        break;
                    case 3:

                        if (item.Xoa)
                        {
                            if (_c != null)
                            {
                                _c.ParentNode.RemoveChild(_c, false);
                            }
                        }
                        else
                        {
                            if (_c != null)
                            {
                                NoiDung = _c.InnerHtml;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            #endregion
            #region Images
            if (!string.IsNullOrEmpty(NoiDung))
            {
                HtmlAgilityPack.HtmlDocument _doc1 = new HtmlAgilityPack.HtmlDocument();
                _doc1.LoadHtml(NoiDung);
                #region Keywords
                using (LinkKeyword _linkKeyword = new LinkKeyword(_doc1.DocumentNode.InnerText))
                {
                    if (_linkKeyword.ListKeyWord != null)
                    {
                        KeyWords = _linkKeyword.ListKeyWord;
                    }
                }
                #endregion
                string domain = "http://" + _host;
                string saveLocation = HostingEnvironment.MapPath("~/lib/up/");
                //string uploadDir = @"D:\Work\linh\ktt_x1\web\lib\up\rss\";
                string uploadDir = @"C:\inetpub\wwwroot\kttvn\web\lib\up\rss\";
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
                                var gimg = new ImageProcess(new Uri(src), src);
                                if (gimg.Width > 250 && gimg.Heigth > 200)
                                {
                                    _list.Add(src);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                        }
                    }
                    if (_list.Count == 0) return;
                    Anh = _list[0];
                }
            }

            #endregion
        }
        public RegularTin(string url, string uploadDir)
        {
            string _host = string.Empty;
            _host = new Uri(url).Host.ToLower();
            HtmlAgilityPack.HtmlDocument doc = loadDoc(url);
            List<QuyTac> List = QuyTacDal.SelectByHost(_host).ToList();
            WrapperClean(_host, url, doc);
            #region Lấy Ten,Mota, Noi Dung
            foreach (QuyTac item in List)
            {
                HtmlNode _c = doc.DocumentNode.SelectSingleNode(@item.Xpath);
                switch (item.Loai)
                {
                    case 0:// renew doc
                        if (_c != null)
                        {
                            doc = new HtmlAgilityPack.HtmlDocument();
                            doc.LoadHtml(_c.InnerHtml);
                        }
                        break;
                    case 1:// Title
                        if (_c != null)
                        {
                            Ten = _c.InnerText;
                        }
                        else
                        {
                            _c = doc.DocumentNode.SelectNodes(@"//title | //TITLE")[0];
                            if (_c != null)
                            {
                                Ten = _c.InnerText;
                            }
                        }
                        break;
                    case 2:
                        if (_c != null)
                        {
                            MoTa = _c.InnerHtml;
                        }
                        else
                        {
                            _c = doc.DocumentNode.SelectNodes(@"//meta[@name='description'] | //meta[@name='DESCRIPTION'] | //meta[@name='Description']")[0];
                            if (_c != null)
                            {
                                MoTa = _c.InnerText;
                            }
                        }
                        break;
                    case 3:

                        if (item.Xoa)
                        {
                            if (_c != null)
                            {
                                _c.ParentNode.RemoveChild(_c, false);
                            }
                        }
                        else
                        {
                            if (_c != null)
                            {
                                NoiDung = _c.InnerHtml;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            #endregion
            #region Images
            if (!string.IsNullOrEmpty(NoiDung))
            {
                HtmlAgilityPack.HtmlDocument _doc1 = new HtmlAgilityPack.HtmlDocument();
                _doc1.LoadHtml(NoiDung);
                #region Keywords
                using (LinkKeyword _linkKeyword = new LinkKeyword(_doc1.DocumentNode.InnerText))
                {
                    if (_linkKeyword.ListKeyWord != null)
                    {
                        KeyWords = _linkKeyword.ListKeyWord;
                    }
                }
                #endregion
                string domain = "http://" + _host;
                string saveLocation = HostingEnvironment.MapPath("~/lib/up/");
                //string uploadDir = @"D:\Work\linh\ktt_x1\web\lib\up\rss\";
                //string uploadDir = @"C:\inetpub\wwwroot\kttvn\web\lib\up\rss\";
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
                                    var gimg_t = Guid.NewGuid().ToString().Replace("-", "");
                                    var gimg_ten = gimg_t + gimg.Ext;
                                    _list.Add(gimg_ten);

                                    gimg_ten = gimg_t + "420x290" + gimg.Ext;
                                    gimg.Crop(420, 300);
                                    saveLocation = Path.Combine(uploadDir, gimg_ten);
                                    gimg.Save(saveLocation);
                                    _list.Add(gimg_ten);

                                    gimg_ten = gimg_t + "150x160" + gimg.Ext;
                                    gimg.Crop(150, 160);
                                    saveLocation = Path.Combine(uploadDir, gimg_ten);
                                    gimg.Save(saveLocation);
                                    _list.Add(gimg_ten);


                                    gimg_ten = gimg_t + "105x70" + gimg.Ext;
                                    gimg.Crop(105, 70);
                                    saveLocation = Path.Combine(uploadDir, gimg_ten);
                                    gimg.Save(saveLocation);
                                    _list.Add(gimg_ten);

                                    gimg_ten = gimg_t + "100x100" + gimg.Ext;
                                    gimg.Crop(100, 100);
                                    saveLocation = Path.Combine(uploadDir, gimg_ten);
                                    gimg.Save(saveLocation);
                                    _list.Add(gimg_ten);

                                    gimg_ten = gimg_t + "50x50" + gimg.Ext;
                                    gimg.Crop(50, 50);
                                    saveLocation = Path.Combine(uploadDir, gimg_ten);
                                    gimg.Save(saveLocation);
                                    _list.Add(gimg_ten);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                        }
                    }
                    if (_list.Count == 0) return;
                    Anh = _list[0];
                }
            }

            #endregion
        }
        public RegularTin(string url, string uploadDir, List<ImageSize> images)
        {
            var host = new Uri(url).Host.ToLower();
            var doc = loadDoc(url);
            var list = QuyTacDal.SelectByHost(host).ToList();
            WrapperClean(host, url, doc);
            #region Lấy Ten,Mota, Noi Dung
            foreach (var item in list)
            {
                var c = doc.DocumentNode.SelectSingleNode(@item.Xpath);
                switch (item.Loai)
                {
                    case 0:// renew doc
                        if (c != null)
                        {
                            doc = new HtmlAgilityPack.HtmlDocument();
                            doc.LoadHtml(c.InnerHtml);
                        }
                        break;
                    case 1:// Title
                        if (c != null)
                        {
                            Ten = c.InnerText;
                        }
                        else
                        {
                            c = doc.DocumentNode.SelectNodes(@"//title | //TITLE")[0];
                            if (c != null)
                            {
                                Ten = c.InnerText;
                            }
                        }
                        break;
                    case 2:
                        if (c != null)
                        {
                            MoTa = c.InnerHtml;
                        }
                        else
                        {
                            c = doc.DocumentNode.SelectNodes(@"//meta[@name='description'] | //meta[@name='DESCRIPTION'] | //meta[@name='Description']")[0];
                            if (c != null)
                            {
                                MoTa = c.InnerText;
                            }
                        }
                        break;
                    case 3:

                        if (item.Xoa)
                        {
                            if (c != null)
                            {
                                c.ParentNode.RemoveChild(c, false);
                            }
                        }
                        else
                        {
                            if (c != null)
                            {
                                NoiDung = c.InnerHtml;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            #endregion
            #region Images

            if (string.IsNullOrEmpty(NoiDung)) return;
            var doc1 = new HtmlAgilityPack.HtmlDocument();
            doc1.LoadHtml(NoiDung);
            #region Keywords
            using (var linkKeyword = new LinkKeyword(doc1.DocumentNode.InnerText))
            {
                if (linkKeyword.ListKeyWord != null)
                {
                    KeyWords = linkKeyword.ListKeyWord;
                }
            }
            #endregion
            var domain = "http://" + host;
            var saveLocation = HostingEnvironment.MapPath("~/lib/up/");
            List<string> _list = new List<string>();
            if (doc1.DocumentNode.SelectNodes("//img | //IMG") != null)
            {
                foreach (var img in doc1.DocumentNode.SelectNodes("//img | //IMG"))
                {
                    if (img.Attributes["src"] != null)
                    {
                        string src = img.Attributes["src"].Value;
                        if (src.ToLower().IndexOf("http://", System.StringComparison.Ordinal) != 0)
                        {
                            if (src.IndexOf("/", System.StringComparison.Ordinal) != 0) src = "/" + src;
                            src = domain + src;
                        }
                        try
                        {
                            var gimg = new ImageProcess(new Uri(src), src);
                            if (gimg.Width > 250 && gimg.Heigth > 200)
                            {
                                var imgTen = Guid.NewGuid().ToString().Replace("-", "");
                                foreach (var imageSize in images)
                                {
                                    gimg.Crop(imageSize.Width, imageSize.Height);
                                    gimg.Save(Path.Combine(uploadDir,
                                                           string.Format("{0}{1}.{2}", imgTen,
                                                                         imageSize.DefaultImage
                                                                             ? ""
                                                                             : string.Format("{0}x{1}",
                                                                                             imageSize.Width,
                                                                                             imageSize.Height),
                                                                         gimg.Ext)));
                                }
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                    }
                }
                if (_list.Count == 0) return;
                Anh = _list[0];
            }

            #endregion
        }
        public HtmlAgilityPack.HtmlDocument WrapperClean(string host, string link, HtmlAgilityPack.HtmlDocument doc)
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
            HtmlNodeCollection ncImg = doc.DocumentNode.SelectNodes("//img | //IMG");
            if (ncImg != null)
            {
                foreach (var img in ncImg)
                {
                    if (img.Attributes["src"] != null)
                    {
                        string src = img.Attributes["src"].Value;
                        if (host.ToLower().IndexOf("ngoisao.net") != -1)
                        {
                            //src = link + "/" + src;
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
                        img.SetAttributeValue("src", src);
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
                                    href = string.Format("http://kenhthongtin.vn/lib/pages/wrap.aspx?url={0}", href);
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
    }
    public class ImageSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool DefaultImage { get; set; }
        public ImageSize(){}
        public ImageSize(int width,int height, bool defaultImage)
        {
            Width = width;
            Height = height;
            DefaultImage = defaultImage;
        }
    }
}
