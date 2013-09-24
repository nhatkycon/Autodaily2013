using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using System.Text;
using linh.frm;
using linh.common;
using System.IO;
using linh.controls;
using docsoft.entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using linh.core.dal;
using System.Diagnostics;
public partial class _admin_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        string imgSaveLoc = Server.MapPath("~/lib/up/i/");
        string imgSaveTintuc = Server.MapPath("~/lib/up/tintuc/");
        string imgTemp = Server.MapPath("~/lib/up/temp/");
        string docTemp = Server.MapPath("~/lib/up/d/");
        bool loggedIn = Security.IsAuthenticated();
        insertLog("0", Security.Username, Request.UserHostAddress, Request.Url.PathAndQuery);
        switch (act)
        {
            case "loadPlug":
                if (rqPlug != null)
                {
                    sb.Append(PlugHelper.RenderHtml(rqPlug));
                }
                rendertext(sb);
                break;
            case "loadPlugContent":
                if (rqPlug != null)
                {
                    Type type = Type.GetType(rqPlug);
                    IPlug plug = (IPlug)Activator.CreateInstance(type);
                    plug.ImportPlugin();
                    using (SqlConnection con = linh.core.dal.DAL.con())
                    {
                        plug.KhoiTao(con);
                        rendertext(plug.Html);
                    }
                }
                rendertext(sb);
                break;
            case "upload":
                #region upload ảnh
                if (Security.IsAuthenticated())
                {
                    if (Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(Request["oldFile"]);
                                if (File.Exists(imgSaveLoc + Request["oldFile"]))
                                {
                                    File.Delete(imgSaveLoc + Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Crop(730, 600);
                        img.Save(imgSaveLoc + imgten + "730x600" + img.Ext);
                        img.Crop(420, 280);
                        img.Save(imgSaveLoc + imgten + "420x280" + img.Ext);
                        img.Crop(130, 100);
                        img.Save(imgSaveLoc + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }
                break;
                #endregion
            case "uploadTintuc":
                #region upload ảnh
                if (Security.IsAuthenticated())
                {
                    if (Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(Request["oldFile"]);
                                if (File.Exists(imgSaveLoc + Request["oldFile"]))
                                {
                                    File.Delete(imgSaveLoc + Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Crop(730, 600);
                        img.Save(imgSaveTintuc + imgten + "730x600" + img.Ext);
                        img.Crop(420, 280);
                        img.Save(imgSaveTintuc + imgten + "420x280" + img.Ext);
                        img.Crop(130, 100);
                        img.Save(imgSaveTintuc + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }
                break;
                #endregion
            case "uploadFull":
                #region upload ảnh
                if (Security.IsAuthenticated())
                {
                    if (Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(Request["oldFile"]);
                                if (File.Exists(imgSaveLoc + Request["oldFile"]))
                                {
                                    File.Delete(imgSaveLoc + Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Save(imgSaveLoc + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }
                break;
                #endregion
            case "uploadfileDkLuong":
                #region upload tài liệu
                if (!loggedIn) rendertext("403");
                if (Request.Files[0] != null)
                {
                    string foldername = Guid.NewGuid().ToString().Replace("-", "");
                    string filename = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string fileType = Path.GetExtension(Request.Files[0].FileName);
                    Directory.CreateDirectory(docTemp + foldername);
                    Request.Files[0].SaveAs(docTemp + foldername + "/" + filename + fileType);
                    Files item = new Files();
                    item.Download = 0;
                    item.MimeType = fileType;
                    item.NgayTao = DateTime.Now;
                    item.NguoiTao = Security.Username;
                    item.Path = filename;
                    item.PID = Guid.NewGuid();
                    item.RowId = Guid.NewGuid();
                    item.Size = Request.Files[0].ContentLength;
                    item.Ten = filename;
                    item.ThuMuc = foldername;
                    item.VB_ID = 0;
                    item = FilesDal.Insert(item);
                    rendertext(item.ID.ToString());
                }
                break;
                #endregion
            case "download":
                string _F_ID = Request["ID"];
                if (!string.IsNullOrEmpty(_F_ID))
                {
                    Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                    Response.Buffer = true;
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment; filename=\"" + item.Ten + item.MimeType + "\"");
                    Response.ContentType = "octet/stream";
                    //Response.ContentType = "application/ms-word";
                    Response.WriteFile(Server.MapPath("~/lib/up/d/") + item.ThuMuc + "/" + item.Path + item.MimeType);
                }
                break;
            case "loadPlugDirect":
                if (!string.IsNullOrEmpty(rqPlug))
                {
                    string _IPlugType = rqPlug;
                    Type type = Type.GetType(_IPlugType);
                    IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
                    _IPlug.ImportPlugin();
                    Page pageHolder = new Page();
                    UserControl uc = (UserControl)(_IPlug);
                    this.Controls.Add(uc);
                }
                break;
            case "uploadvideo":
                //  imgSaveLoc = Server.MapPath("~/up/v/flv");
                if (Security.IsAuthenticated())
                {
                    if (Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        string strVideoRender = "";
                        //if (!string.IsNullOrEmpty(Request["oldFile"]))
                        //{
                        //    imgten = Path.GetFileNameWithoutExtension(Request["oldFile"]);
                        //    //if (File.Exists(Server.MapPath("~/up/v/") + Request["oldFile"]))
                        //    //{
                        //    //    File.Delete(Server.MapPath("~/up/v/") + Request["oldFile"]);
                        //    //}
                        //}
                        Request.Files[0].SaveAs(Server.MapPath("~/lib/up/v/") + imgten + Path.GetExtension(Request.Files[0].FileName));
                        // string fWmv=    convWMV(imgten + Path.GetExtension(Request.Files[0].FileName));
                        //   string fWmv = FLV_encode(imgten + Path.GetExtension(Request.Files[0].FileName), "320", "240", "32", "22050");
                        string _hinhanh = "";
                        string fWmv = "";
                        if (Path.GetExtension(Request.Files[0].FileName).ToLower() == ".flv")
                        {
                            fWmv = WMV_encode(imgten + Path.GetExtension(Request.Files[0].FileName), "320", "240", "64", "44100");
                            Request.Files[0].SaveAs(Server.MapPath("~/lib/up/v/") + fWmv);
                            _hinhanh = CreatImg(fWmv, imgten + Path.GetExtension(Request.Files[0].FileName));
                            System.IO.File.Delete(Server.MapPath("~/lib/up/v/") + fWmv);
                        }
                        else
                        {
                            fWmv = FLV_encode(imgten + Path.GetExtension(Request.Files[0].FileName), "320", "240", "64", "44100");

                            fWmv = Request.Files[0].FileName;
                            _hinhanh = CreatImg(imgten + Path.GetExtension(Request.Files[0].FileName), imgten + Path.GetExtension(Request.Files[0].FileName));
                        }
                        //  string fWmv = "D:\\Project\\agrobiotech\\web\\up\\v\\plugin.wmv";

                        //try
                        //{
                        //    System.IO.File.Delete(Server.MapPath("~/up/v/") + imgten + Path.GetExtension(Request.Files[0].FileName));
                        //}
                        //catch { }
                        rendertext(_hinhanh + ";" + imgten + Path.GetExtension(Request.Files[0].FileName));
                    }
                }

                break;
            default:
                string d = "12/9/2010";
                //DateTime da = Convert.ToDateTime(d, new System.Globalization.CultureInfo("vi-Vn"));
                //Response.Write(da.Month.ToString());
                Response.Write(maHoa.EncryptString("111", "phatcd"));
                break;
        }
    }
    protected override void OnError(EventArgs e)
    {
        insertLog("1", Security.Username, Request.UserHostAddress, Request.Url.PathAndQuery);
        insertLog(string.Format("MSG: {0} SRS: {1}", Server.GetLastError().InnerException, Server.GetLastError().Source), "1", Security.Username, Request.UserHostAddress, Request.Url.PathAndQuery);
        base.OnError(e);
    }
    void insertLog(string LOG_LLOG_ID, string Username, string LOG_RequestIp, string LOG_RawUrl)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlParameter[] obj = new SqlParameter[4];
        obj[0] = new SqlParameter("Username", Username);
        obj[1] = new SqlParameter("LOG_RequestIp", LOG_RequestIp);
        obj[2] = new SqlParameter("LOG_RawUrl", LOG_RawUrl);
        obj[3] = new SqlParameter("LOG_LLOG_ID", LOG_LLOG_ID);
        try
        {
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sptblLog_Insert_quick_linhnx", obj);
            con.Close();

        }
        finally
        {
            con.Close();
        }
    }
    void insertLog(string LOG_Ten, string LOG_LLOG_ID, string Username, string LOG_RequestIp, string LOG_RawUrl)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlParameter[] obj = new SqlParameter[5];
        obj[0] = new SqlParameter("Username", Username);
        obj[1] = new SqlParameter("LOG_RequestIp", LOG_RequestIp);
        obj[2] = new SqlParameter("LOG_RawUrl", LOG_RawUrl);
        obj[3] = new SqlParameter("LOG_LLOG_ID", LOG_LLOG_ID);
        obj[4] = new SqlParameter("LOG_Ten", LOG_Ten);
        try
        {
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sptblLog_Insert_quick1_linhnx", obj);
            con.Close();

        }
        finally
        {
            con.Close();
        }
    }
    private string convWMV(string _mediaName)
    {
        string ret = "";
        // Sample code for encoding any format video to wmv format.
        MediaHandler _mhandler = new MediaHandler();

        // required properties 

        string rootpath = Server.MapPath(Request.ApplicationPath);
        string inputpath = Server.MapPath("~/lib/up/v/");
        string outputpath = Server.MapPath("~/lib/up/v/");
        string _ffmpegpath = HttpContext.Current.Server.MapPath("~\\ffmpeg\\ffmpeg.dll");

        string filenameWMV = Guid.NewGuid().ToString().Substring(0, 10) + ".wmv";
        _mhandler.FFMPEGPath = _ffmpegpath;
        _mhandler.InputPath = inputpath;
        _mhandler.OutputPath = outputpath;
        _mhandler.FileName = _mediaName;

        // optional output filename

        _mhandler.OutputFileName = filenameWMV;

        // setting video related properties

        //_mhandler.Video_Bitrate = 786;
        //_mhandler.Audio_Bitrate = 64;
        //_mhandler.Audio_SamplingRate = 44100;

        // generate highest quality mp4 video, note by making this option true, video bitrate will no longer work.

        _mhandler.MaxQuality = true;

        // optional video width and height settings 

        _mhandler.Width = 538;
        _mhandler.Height = 400;

        // Optional parameters for setting audio and video codec for wmv video
        _mhandler.VCodec = "wmv2";
        _mhandler.ACodec = "wmav2";
        _mhandler.Audio_Bitrate = 64;
        _mhandler.Video_Bitrate = 1000;

        // posting watermark on wmv video, view detail in watermark section 
        //  _mhandler.WaterMarkPath = RootPath + "\\contents\\watermark";
        //  _mhandler.WaterMarkImage = "watermark.gif";

        // view more options in component documentation. 

        // Encode WMV Video using Media Handler Pro version 3.0 

        //  string output = _mhandler.Encode_WMV();

        // Encode WMV Video using Media Handler Pro version 4.0 or later 

        VideoInfo info = _mhandler.Encode_WMV();

        // Check for errors 
        if (info.ErrorCode > 0)
        {
            Response.Write("Video processing failed, Error code " + info.ErrorCode + " generated");
            return "";
        }
        ret = filenameWMV;
        return filenameWMV;
    }
    private string CreatImg(string _mediaName, string strname)
    {
        string ret = "";
        //   string filenameIMG = _mediaName;
        MediaHandler _mediahandler = new MediaHandler();

        string rootpath = Server.MapPath(Request.ApplicationPath);
        string inputpath = Server.MapPath("~/lib/up/v/");
        string outputpath = Server.MapPath("~/lib/up/v/"); // +"\\up\\v";
        string _ffmpegpath = HttpContext.Current.Server.MapPath("~\\ffmpeg\\ffmpeg.dll");
        string filenameIMG = Guid.NewGuid().ToString().Substring(0, 10) + ".jpg";

        _mediahandler.FFMPEGPath = _ffmpegpath;
        _mediahandler.InputPath = inputpath;
        _mediahandler.OutputPath = outputpath;
        _mediahandler.Width = 180;
        _mediahandler.Height = 130;
        _mediahandler.Frame_Time = "3";
        _mediahandler.Image_Format = "jpg";
        _mediahandler.FileName = _mediaName;
        _mediahandler.ImageName = filenameIMG;
        VideoInfo info = _mediahandler.Grab_Thumb();


        if (info.ErrorCode > 0 && info.ErrorCode != 121)
        {
            //lb_mess.Text = "Xử lý thông tin lỗi!";
            //lb_mess.Visible = true;
            return "";
        }
        ret = filenameIMG;
        return filenameIMG;
    }
    public string FLV_encode(string filename, string width, string height, string bitrate, string samplingrate)
    {
        try
        {
            string rootpath = Server.MapPath(Request.ApplicationPath);
            string inputpath = rootpath + "\\lib\\up\\v";
            string outputpath = rootpath + "\\lib\\up\\v";
            string _ffmpegpath = HttpContext.Current.Server.MapPath("~\\ffmpeg\\ffmpeg.dll");

            string outfile = "";
            string size = width + "*" + height;
            outfile = System.IO.Path.GetFileNameWithoutExtension(inputpath + filename);
            outfile = outfile + ".flv";

            string ffmpegarg = " -i " + inputpath + filename + " -acodec libmp3lame -ar " + samplingrate + " -ab " + bitrate + " -f flv -s " + size + " " + inputpath + outfile;
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = _ffmpegpath;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pProcess.StartInfo.Arguments = ffmpegarg;
            pProcess.EnableRaisingEvents = true;
            pProcess.Start();
            pProcess.WaitForExit();
            pProcess.Close();
            pProcess.Dispose();
            return outfile;
        }
        catch (Exception err)
        {
            return "KO";
        }
    }
    public string WMV_encode(string filename, string width, string height, string bitrate, string samplingrate)
    {
        try
        {
            string rootpath = Server.MapPath(Request.ApplicationPath);
            rootpath = rootpath + "\\lib\\up\\v\\";
            string outfile = "";
            string size = width + "*" + height;
            outfile = System.IO.Path.GetFileNameWithoutExtension(rootpath + filename);
            //  outfile = outfile + ".flv";
            outfile = Guid.NewGuid().ToString() + ".wmv";

            //   string ffmpegargs = " -i " + rootpath + filename + " -acodec libmp3lame -ar " + samplingrate + " -ab " + bitrate + " -f flv -s " + size + " " + rootpath + outfile;

            string ffmpegargs = " -i " + rootpath + filename + " -vcodec wmv2 -acodec wmav2 -ab 64k -b 300k -s " + size + " " + rootpath + outfile;
            //  string ffmpegargs = " -i " + rootpath + filename + " -vcodec copy -acodec copy -ab 64k -b 300k -s " + size + " " + rootpath + outfile;
            // string ffmpegargs = " -i " + rootpath + filename + " -target wmv2 " + rootpath + outfile;

            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = HttpContext.Current.Server.MapPath("~\\ffmpeg\\ffmpeg.dll");
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pProcess.StartInfo.Arguments = ffmpegargs;
            pProcess.EnableRaisingEvents = true;
            pProcess.Start();
            pProcess.WaitForExit();
            pProcess.Close();
            pProcess.Dispose();
            return outfile;
        }
        catch (Exception err)
        {
            return "KO";
        }
    }
}