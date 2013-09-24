using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_pages_CaNhan_SuaBe : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Security.IsAuthenticated())
            Response.Redirect("~/");
        var id = Request["ID"];

        if (string.IsNullOrEmpty(id))
            return;
        using (var con = DAL.con())
        {
            var item = BeDal.SelectById(con, new Guid(id), Security.Username);
            SuaBe1.BeItem = item;
        }
    }
}