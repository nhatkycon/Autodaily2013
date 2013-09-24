using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.controls;
using linh.core;
using linh.json;

public partial class lib_ajax_YouTube_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Ten = Request["Ten"];
        var Url = Request["Url"];
        var P_ID = Request["P_ID"];
        var Anh = Request["Anh"];
        var Yid = Request["Yid"];
        var NgayViet = Request["NgayViet"];
        CapNhat Item;
        switch (subAct)
        {
            case "add":
                #region add
                Item = new CapNhat();
                Item.ID = Guid.NewGuid();
                Item.Ten = Ten;
                Item.NgayTao = DateTime.Now;
                Item.Username = Security.Username;
                if (!string.IsNullOrEmpty(P_ID))
                {
                    Item.P_ID = new Guid(P_ID);
                }
                if (!string.IsNullOrEmpty(NgayViet))
                {
                    Item.NgayViet = Convert.ToDateTime(NgayViet, new CultureInfo("vi-Vn"));
                }
                Item.Anh = Anh;
                Item.Loai = 3;// Video
                Item.VideoUrl = Yid;
                Item = CapNhatDal.Insert(Item);
                rendertext(Item.ID.ToString());
                break;
                #endregion
            case "wrappUrl":
                #region wrappUrl: Đọc url
                if (!string.IsNullOrEmpty(Url))
                {
                    youTubeVideo vd = Lib.YouTubeCode(Url);
                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(vd)));
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