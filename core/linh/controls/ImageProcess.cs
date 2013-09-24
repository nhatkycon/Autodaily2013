using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
using System.Web.Hosting;
using System.Xml;
namespace linh.controls
{
    public class ImageProcess: IDisposable
    {
        public string CacheKey { get; set; }
        public byte[] Bytes
        {
            get
            {
                return (byte[])(HttpRuntime.Cache[CacheKey]);
            }
            set
            {
                HttpRuntime.Cache.Insert(CacheKey, value, null);
            }
        }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public string Mime { get; set; }
        public string Ext { get; set; }
        public byte[] localBytes { get; set; }
        HttpContext c = HttpContext.Current;
        const string uAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
        #region Contruct
        /// <summary>
        /// 
        /// </summary>
        public ImageProcess() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStream"></param>
        /// <param name="cacheKey"></param>
        public ImageProcess(Stream inputStream,string cacheKey)
        {
            CacheKey = cacheKey;
            Bytes = convertFromStream(inputStream);
            using (Image bmp = convertFromByte(Bytes))
            {
                Width = bmp.Width;
                Heigth = bmp.Height;
                Mime = getMimeType(bmp);
                Ext = getExtionsion(Mime);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="cacheKey"></param>
        public ImageProcess(String fileName,string cacheKey)
        {
            CacheKey = cacheKey;
            using (Image bmp = Bitmap.FromFile(fileName))
            {
                Width = bmp.Width;
                Heigth = bmp.Height;
                Mime = getMimeType(bmp);
                Ext = getExtionsion(Mime);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cacheKey"></param>
        public ImageProcess(Uri url, string cacheKey)
        {
            CacheKey = cacheKey;
            HttpWebRequest rq = (HttpWebRequest)(WebRequest.Create(url));
            rq.UserAgent = uAgent;
            rq.Timeout = 20000;
            HttpWebResponse rp;
            try
            {
                rp = (HttpWebResponse)(rq.GetResponse());
                using (Stream dt = rp.GetResponseStream())
                {
                    Bytes = convertFromStream(dt);
                    using (Image bmp = convertFromByte(Bytes))
                    {
                        if (bmp != null)
                        {
                            Width = bmp.Width;
                            Heigth = bmp.Height;
                            Mime = getMimeType(bmp);
                            Ext = getExtionsion(Mime);
                        }
                        else
                        {
                            Width = 0;
                            Heigth = 0;
                        }
                    }
                }
                rp.Close();
            }
            catch (WebException ex)
            {
                HttpWebResponse _ex = (HttpWebResponse)(ex.Response);
                Width = 0;
                Heigth = 0;
                //throw new Exception(_ex.StatusCode.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputByte"></param>
        /// <param name="cacheKey"></param>
        public ImageProcess(byte[] inputByte, string cacheKey)
        {
            CacheKey = cacheKey;
            Bytes = inputByte;
            using (Image bmp = convertFromByte(inputByte))
            {
                Width = bmp.Width;
                Heigth = bmp.Height;
                Mime = getMimeType(bmp);
                Ext = getExtionsion(Mime);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey"></param>
        public ImageProcess(string cacheKey)
        {
            CacheKey = cacheKey;            
            using (Image bmp = convertFromByte(Bytes))
            {
                Width = bmp.Width;
                Heigth = bmp.Height;
                Mime = getMimeType(bmp);
                Ext = getExtionsion(Mime);
            }
        }
        #endregion
        #region Xử lý ảnh
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_width"></param>
        public void Resize(int _width)
        {
            using (Image img = convertFromByte(Bytes))
            {
                Single nPercentW = 0;
                nPercentW = Convert.ToSingle(_width) / Convert.ToSingle(Width);
                int _height = Convert.ToInt32(Heigth * nPercentW);
                using (Bitmap bmp = new Bitmap(_width, _height))
                {
                    bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                    using (Graphics grp = Graphics.FromImage(bmp))
                    {
                        grp.CompositingMode = CompositingMode.SourceCopy;
                        grp.PixelOffsetMode = PixelOffsetMode.Half;
                        grp.CompositingQuality = CompositingQuality.HighSpeed;
                        grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        grp.SmoothingMode = SmoothingMode.HighQuality;
                        grp.DrawImage(img, new Rectangle(0, 0, _width, _height));
                        MemoryStream ms = new MemoryStream();
                        bmp.Save(ms, getImageFormat(Mime));
                        localBytes = ms.ToArray();
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_width"></param>
        /// <param name="_height"></param>
        public void Crop(int _width, int _height)
        {
            using (Image img = convertFromByte(Bytes))
            {
                Single nPercent = 0;
                Single nPercentW = 0;
                Single nPercentH = 0;
                nPercentW = Convert.ToSingle(_width) / Convert.ToSingle(Width);
                nPercentH = Convert.ToSingle(_height) / Convert.ToSingle(Heigth);
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentW;
                }
                else
                {
                    nPercent = nPercentH;
                }
                int desWidth = Convert.ToInt32(Width * nPercent);
                int desHeight = Convert.ToInt32(Heigth * nPercent);
                using (Bitmap bmp = new Bitmap(_width, _height))
                {
                    bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                    using (Graphics grp = Graphics.FromImage(bmp))
                    {
                        grp.CompositingMode = CompositingMode.SourceCopy;
                        grp.PixelOffsetMode = PixelOffsetMode.Half;
                        grp.CompositingQuality = CompositingQuality.HighSpeed;
                        grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        grp.SmoothingMode = SmoothingMode.HighQuality;
                        grp.DrawImage(img, new Rectangle(0, 0, desWidth, desHeight));
                        MemoryStream ms = new MemoryStream();
                        bmp.Save(ms, getImageFormat(Mime));
                        localBytes = ms.ToArray();
                    }
                }
            }
        }
        #endregion
        #region Lưu ảnh
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public void Save(string file)
        {
            using (Image img = convertFromByte(localBytes == null ? Bytes : localBytes))
            {
                img.Save(file);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            using (Image img = convertFromByte(localBytes==null? Bytes : localBytes))
            {
                c.Response.ClearContent();
                c.Response.ContentType = getMimeType(img);
                MemoryStream ms=new MemoryStream();
                img.Save(ms,getImageFormat(Mime));
                c.Response.OutputStream.Write(ms.ToArray(), 0, Convert.ToInt32(ms.Length));
                ms.Close();
                c.Response.End();
            }
        }
        #endregion
        #region Utilities
        public string getMimeType(Image _Image)
        {
            foreach (ImageCodecInfo code in ImageCodecInfo.GetImageDecoders())
            {
                if (code.FormatID == _Image.RawFormat.Guid)
                {
                    return code.MimeType;
                }
            }
            return string.Empty;
        }
        public ImageFormat getImageFormat(string mimeType)
        {
            switch (mimeType.ToLower())
            {
                case "image/png":
                    return ImageFormat.Png;
                    break;
                case "image/jpeg":
                    return ImageFormat.Jpeg;
                    break;
                case "image/gif":
                    return ImageFormat.Gif;
                    break;
                case "image/icon":
                    return ImageFormat.Icon;
                    break;
                case "image/bmp":
                    return ImageFormat.Bmp;                             
                    break;
                default:
                    return ImageFormat.Jpeg;
                    break;
            }
        }
        public Image convertFromByte(byte[] bytes)
        {
            ImageConverter ic = new ImageConverter();
            Image img = null;
            try
            {
                img = (Image)(ic.ConvertFrom(bytes));
            }
            catch
            {
            }
            return img;
        }
        public byte[] convertFromStream(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buffer = new byte[2048];
                int byteReaded = 0;
                do
                {
                    byteReaded = stream.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, byteReaded);
                } while (byteReaded != 0);
                buffer = ms.ToArray();
                return buffer;
            }
        }
        public string getExtionsion(string mimeType)
        {
            if (!string.IsNullOrEmpty(mimeType))
            {
                return ("." + mimeType.Substring(mimeType.LastIndexOf("/") + 1));
            }
            return string.Empty;
        }
        #endregion
        #region Destroy
        bool disposed = false;
        void IDisposable.Dispose()
        {
            if (!this.disposed)
            {
                disposed = true;
                if (localBytes != null)
                {
                    localBytes = null;
                }
                c.Cache.Remove(CacheKey);
                GC.SuppressFinalize(this);
            }
        }
        #endregion
    }
}
