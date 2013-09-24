using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_pages_NhatKy_Anh_view : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        if (string.IsNullOrEmpty(id))
            return;
        using (var con = DAL.con())
        {
            var anh = AnhDal.SelectById(new Guid(id));
            var item = AlbumDal.SelectById(anh.AB_ID);
            Anh_View1.AlbumItem = item;
            Anh_View1.List = AnhDal.SelectByAbId(con, item.ID.ToString());
            BinhLuan1.PID = item.ID.ToString();
        }
    }
}