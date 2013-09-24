using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_pages_NhatKy_Album_Add : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["AB_ID"];
        if (string.IsNullOrEmpty(id))
            return;
        using (var con = DAL.con())
        {
            var item = AlbumDal.SelectById(new Guid(id));
            Album_Add1.AlbumItem = item;
            Album_Add1.List = AnhDal.SelectByAbId(con, id);

        }
    }
    
}