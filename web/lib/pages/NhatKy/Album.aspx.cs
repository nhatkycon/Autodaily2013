using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_pages_NhatKy_Album :BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        if (string.IsNullOrEmpty(id))
            return;
        using (var con = DAL.con())
        {
            var item = AlbumDal.SelectById(new Guid(id));
            Album_View1.AlbumItem = item;
            Album_View1.List = AnhDal.SelectByAbId(con, id);
            BinhLuan1.PID = id;
            Title = string.Format("Album: {0} - NhatKyCon", item.Ten);
        }
    }
}