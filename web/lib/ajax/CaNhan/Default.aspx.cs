using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;

public partial class lib_ajax_CaNhan_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Ten = Request["Ten"];
        var NoiDung = Request["NoiDung"];
        var P_ID = Request["P_ID"];
        var Anh = Request["Anh"];
        var HoatDong_ID = Request["HoatDong_ID"];
        CapNhat Item;
        switch (subAct)
        {
            case "update":
                #region add
                if(Security.IsAuthenticated())
                {
                    MemberDal.UpdateInfoByUsername(Security.Username, Ten, null, null);
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
                    img.Resize(300);
                    img.Save(Server.MapPath("~/lib/up/i/") + key + img.Ext);
                    MemberDal.UpdateAnh(Security.Username, key + img.Ext);
                    rendertext(key + img.Ext);
                }
                break;
                #endregion
            default:
                break;

        }
    }
}