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
        var location = Server.MapPath("~/lib/up/anh/");
        CapNhat Item;
        switch (subAct)
        {
            case "upload":
                #region upload anh
                Response.ContentType = "text/plain";//"application/json";
                var r = new List<ViewDataUploadFilesResult>();
                var js = new JavaScriptSerializer();
                foreach (string file in Request.Files)
                {


                    var hpf = Request.Files[file] as HttpPostedFile;
                    var key = Guid.NewGuid().ToString();




                    var img = new linh.controls.ImageProcess(hpf.InputStream, key);
                    var fileName = key + img.Ext;

                    var item = new Anh();
                    if (!string.IsNullOrEmpty(ID))
                    {
                        item.AB_ID = new Guid(ID);
                    }
                    item.FileAnh = fileName;
                    item.ID = Guid.NewGuid();
                    item.NgayTao = DateTime.Now;
                    //if (!string.IsNullOrEmpty(P_ID))
                    //{
                    //    item.P_ID = new Guid(P_ID);
                    //}
                    item = AnhDal.Insert(item);


                    if (img.Width > 1000)
                    {
                        img.Resize(1000);
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
                }
                ;
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
            case "updateAlbum":
                #region Cap nhat album
                if (Security.IsAuthenticated())
                {
                    var item = AlbumDal.SelectById(new Guid(ID));
                    item.Ten = Ten;
                    item = AlbumDal.Update(item);
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