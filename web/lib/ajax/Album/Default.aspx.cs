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

public partial class lib_ajax_Album_Default : BasedPage 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var ID = Request["ID"];
        var P_ID = Request["P_ID"];
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
                    if(!string.IsNullOrEmpty(ID))
                    {
                        item.AB_ID = new Guid(ID);
                    }
                    item.FileAnh = fileName;
                    item.ID = Guid.NewGuid();
                    item.NgayTao = DateTime.Now;
                    if(!string.IsNullOrEmpty(P_ID))
                    {
                        item.P_ID = new Guid(P_ID);                        
                    }
                    item = AnhDal.Insert(item);


                    if(img.Width > 1000)
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
                    Response.Write( jsonObj.ToString());
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
                        File.Delete(location + Lib.imgSize(item.FileAnh,"full"));
                    }
                    catch
                    {
                        
                    }
                }
                break;
                #endregion
            case "editCaption":
                #region Sua tieu de
                if (Security.IsAuthenticated())
                {
                    var item = AnhDal.SelectById(new Guid(ID));
                    item.Ten = Ten;
                    AnhDal.Update(item);
                }
                break;
                #endregion
            case "addAlbum":
                #region Them moi album
                if (Security.IsAuthenticated())
                {
                    var item = new Album();
                    item.ID = new Guid(ID);
                    item.Ten = Ten;
                    item.NgayTao = DateTime.Now;
                    item.NguoiTao = Security.Username;
                    item.P_RowId = new Guid(P_ID);
                    item.Active = true;
                    item = AlbumDal.Insert(item);

                    Item = new CapNhat();
                    Item.ID = Guid.NewGuid();
                    Item.Ten = Ten;
                    Item.NgayTao = DateTime.Now;
                    Item.Username = Security.Username;
                    Item.NgayViet = DateTime.Now;
                    if (!string.IsNullOrEmpty(P_ID))
                    {
                        Item.P_ID = new Guid(P_ID);
                    }

                    Item.Loai = 4;// Album
                    Item.AB_ID = item.ID;
                    Item = CapNhatDal.Insert(Item);
                    rendertext(Item.ID.ToString());
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
            case "xoaAlbum":
                #region Cap nhat album
                if (Security.IsAuthenticated())
                {
                    AlbumDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion
            default:
                Response.Write("s");
                break;
        }
    }
}