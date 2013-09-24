using System;
using System.Collections.Generic;
using System.Globalization;
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

public partial class lib_ajax_SuKien_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Ten = Request["Ten"];
        var NoiDung = Request["NoiDung"];
        var P_ID = Request["P_ID"];
        var Anh = Request["Anh"];
        var HoatDong_ID = Request["HoatDong_ID"];
        var NgayViet = Request["NgayViet"];
        CapNhat Item;
        switch (subAct)
        {
            case "add":
                #region add
                Item = new CapNhat();
                Item.ID = Guid.NewGuid();
                Item.Ten = Ten;
                Item.NoiDung = NoiDung;
                Item.NgayTao = DateTime.Now;
                Item.Username = Security.Username;
                if (!string.IsNullOrEmpty(P_ID))
                {
                    Item.P_ID = new Guid(P_ID);
                }
                if (!string.IsNullOrEmpty(HoatDong_ID))
                {
                    Item.HoatDong_ID = new Guid(HoatDong_ID);
                }
                if (!string.IsNullOrEmpty(NgayViet))
                {
                    Item.NgayViet = Convert.ToDateTime(NgayViet, new CultureInfo("vi-Vn"));
                }
                Item.Anh = Anh;
                Item.Loai = 2;// Su kien
                Item = CapNhatDal.Insert(Item);
                rendertext(Item.ID.ToString());
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