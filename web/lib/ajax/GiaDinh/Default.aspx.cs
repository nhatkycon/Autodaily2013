using System;
using docsoft;
using docsoft.entities;
using linh.core;

public partial class lib_ajax_GiaDinh_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Ten = Request["Ten"];
        var Email = Request["Email"];
        var NoiDung = Request["NoiDung"];
        var P_ID = Request["P_ID"];
        var ID = Request["ID"];
        var Anh = Request["Anh"];
        var LOAI_ID = Request["LOAI_ID"];
        GiaDinh Item;
        switch (subAct)
        {
            case "add":
                #region add
                Item = new GiaDinh();
                Item.ID = Guid.NewGuid();
                Item.Anh = Anh;
                Item.Email = Email;
                if (!string.IsNullOrEmpty(LOAI_ID))
                {
                    Item.LOAI_ID = new Guid(LOAI_ID);                    
                }
                if (!string.IsNullOrEmpty(P_ID))
                {
                    Item.P_ID = new Guid(P_ID);
                }
                Item.NgayTao = DateTime.Now;
                Item.NoiDung = NoiDung;
                Item.Ten = Ten;
                Item.ThuTu = 0;
                Item.Username = Security.Username;
                Item = GiaDinhDal.Insert(Item);
                GiaDinhItem1.item = Item;
                GiaDinhItem1.Visible = true;
                //rendertext(Item.ID.ToString());
                break;
                #endregion
            case "remove":
                #region add
               if(Security.IsAuthenticated())
               {
                   if(!string.IsNullOrEmpty(ID))
                   {
                       Item = GiaDinhDal.SelectById(new Guid(ID));
                       if(Item.Username==Security.Username)
                       {
                           GiaDinhDal.DeleteById(new Guid(ID));
                       }
                   }
               }
                break;
                #endregion
            case "upload":
                #region upload
                if (Security.IsAuthenticated())
                {
                    var key = Guid.NewGuid().ToString();
                    var img = new linh.controls.ImageProcess(Request.Files[0].InputStream, key);
                    if (img.Width < 300)
                        rendertext("300");
                    img.Resize(520);
                    img.Save(Server.MapPath("~/lib/up/i/") + key + img.Ext);
                    rendertext(key + img.Ext);
                }
                break;
                #endregion
            default:
                break;

        }
    }
}