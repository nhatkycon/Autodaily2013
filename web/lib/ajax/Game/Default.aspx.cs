using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core;
using linh.json;
public partial class lib_ajax_Game_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var ID = Request["ID"];
        var ThuTu = Request["ThuTu"];
        var Ten = Request["Ten"];
        var MoTa = Request["MoTa"];
        var Anh = Request["Anh"];
        var AnhDaiDien = Request["AnhDaiDien"];
        var G_ID = Request["G_ID"];
        var Q_ID = Request["Q_ID"];
        var Active = Request["Active"];
        var location = Server.MapPath("~/lib/up/i/");
        CapNhat Item;
        switch (subAct)
        {
            case "uploadAnh":
                #region upload
                if (Security.IsAuthenticated())
                {
                    var key = Guid.NewGuid().ToString();
                    var img = new linh.controls.ImageProcess(Request.Files[0].InputStream, key);
                    img.Resize(1280);
                    img.Save(Server.MapPath("~/lib/up/i/") + key + img.Ext);
                    rendertext(key + img.Ext);
                }
                break;
                #endregion
            case "uploadAnhDaiDien":
                #region upload
                if (Security.IsAuthenticated())
                {
                    var key = Guid.NewGuid().ToString();
                    var img = new linh.controls.ImageProcess(Request.Files[0].InputStream, key);
                    img.Resize(320);
                    img.Save(Server.MapPath("~/lib/up/i/") + key + img.Ext);
                    rendertext(key + img.Ext);
                }
                break;
                #endregion
            case "xoaAnh":
                #region Xoa anh
                if (Security.IsAuthenticated())
                {
                    var item = AnhDal.SelectById(new Guid(ID));
                    AnhDal.DeleteById(new Guid(ID));
                    try
                    {
                        File.Delete(location + item.FileAnh);
                        File.Delete(location + Lib.imgSize(item.FileAnh, "full"));
                    }
                    catch
                    {

                    }
                }
                break;
                #endregion
            case "editGame":
                #region Sua tieu de
                if (Security.IsAuthenticated())
                {
                    var item = GameDal.SelectById(new Guid(ID));
                    rendertext(string.Format("({0})",JavaScriptConvert.SerializeObject(item)));
                }
                break;
                #endregion
            case "addGame":
                #region Them moi game

                if (Security.IsAuthenticated())
                {
                    var item = new Game
                                   {
                                       ID = Guid.NewGuid(),
                                       Ten = Ten,
                                       ThuTu = Convert.ToInt32(ThuTu),
                                       NgayTao = DateTime.Now
                                   };
                    item = GameDal.Insert(item);
                    GameItem1.Visible = true;
                    GameItem1.Item = item;
                }
                break;
                #endregion
            case "saveGame":
                #region save Game

                if (Security.IsAuthenticated())
                {
                    var item = GameDal.SelectById(new Guid(ID));
                    item.Ten = Ten;
                    item.ThuTu = Convert.ToInt32(ThuTu);
                    item = GameDal.Update(item);
                    GameItem1.Visible = true;
                    GameItem1.Item = item;
                }
                break;
                #endregion
            case "saveQuestion":
                #region saveQuestion

                if (Security.IsAuthenticated())
                {
                    var item = string.IsNullOrEmpty(ID) ? new Question() : QuestionDal.SelectById(new Guid(ID));
                    item.Ten = Ten;
                    item.ThuTu = ThuTu;
                    item.MoTa = MoTa;
                    item.Anh = Anh;
                    item.G_ID = new Guid(G_ID);
                    item.AnhDaiDien = AnhDaiDien;
                    item.Active = Convert.ToBoolean(Active);
                    item.ID = string.IsNullOrEmpty(ID) ? Guid.NewGuid() : new Guid(ID);
                    item = string.IsNullOrEmpty(ID) ? QuestionDal.Insert(item) : QuestionDal.Update(item);
                    QuestionItem1.Item = item;
                    QuestionItem1.Visible = true;
                }
                break;
                #endregion
            case "editQuestion":
                #region Sua tieu de
                if (Security.IsAuthenticated())
                {
                    var item = QuestionDal.SelectById(new Guid(ID));
                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(item)));
                }
                break;
                #endregion
            case "updateThuTuAnswer":
                #region Cap nhat updateThuTuAnswer
                if (Security.IsAuthenticated())
                {
                    var item = AnswerDal.SelectById(new Guid(ID));
                    item.ThuTu = Convert.ToInt32(ThuTu);
                    item = AnswerDal.Update(item);
                }
                break;
                #endregion
            case "updateQuestionActive":
                #region Cap nhat updateQuestionActive
                if (!string.IsNullOrEmpty(ID))
                {
                    var item = QuestionDal.SelectById(new Guid(ID));
                    item.Active = Convert.ToBoolean(Active);
                    item = QuestionDal.Update(item);
                }
                break;
                #endregion
            case "uploadAnswerAnh":
                #region upload anh
                Response.ContentType = "text/plain";//"application/json";
                var r = new List<ViewDataUploadFilesResult>();
                var js = new JavaScriptSerializer();
                var ThuTuAnh = 1;
                foreach (string file in Request.Files)
                {


                    var hpf = Request.Files[file] as HttpPostedFile;
                    var key = Guid.NewGuid().ToString();




                    var img = new linh.controls.ImageProcess(hpf.InputStream, key);
                    var fileName = key + img.Ext;

                    var item = new Answer();
                    if (!string.IsNullOrEmpty(Q_ID))
                    {
                        item.Q_ID = new Guid(Q_ID);
                    }
                    item.ThuTu = ThuTuAnh;
                    item.Anh = fileName;
                    item.ID = Guid.NewGuid();
                    item = AnswerDal.Insert(item);


                    if (img.Width > 1280)
                    {
                        img.Resize(1280);
                    }
                    img.Save(location + key + "full" + img.Ext);

                    img.Resize(520);
                    img.Save(location + key + img.Ext);

                    r.Add(new ViewDataUploadFilesResult()
                    {
                        Id = item.ID.ToString(),
                        Thumbnail_url = key + img.Ext,
                        Name = key,
                        Length = hpf.ContentLength,
                        Type = hpf.ContentType
                    });
                    var uploadedFiles = new
                    {
                        files = r.ToArray()
                    };
                    var jsonObj = js.Serialize(uploadedFiles);
                    Response.Write(jsonObj.ToString());
                    ThuTuAnh++;
                }
                ;
                break;
                #endregion
            case "removeQuestion":
                #region Xoa
                if (Security.IsAuthenticated())
                {
                    QuestionDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion
            case "getAnswerList":
                #region Xoa
                if (Security.IsAuthenticated())
                {
                    var List = AnswerDal.SelectByQuestionId(ID);
                    AnswerList1.List = List;
                    AnswerList1.Visible = true;
                }
                break;
                #endregion
            case "xoaAnhAnswer":
                #region Xoa
                if (Security.IsAuthenticated())
                {
                    AnswerDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion
            case "removeGame":
                #region Xoa
                if (Security.IsAuthenticated())
                {
                    GameDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion
            default:
                Response.Write("s");
                break;
        }
    }
}