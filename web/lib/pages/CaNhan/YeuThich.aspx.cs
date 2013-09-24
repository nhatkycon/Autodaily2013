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

public partial class lib_pages_CaNhan_YeuThich : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Security.IsAuthenticated())
            Response.Redirect("~/");
        using (var con = DAL.con())
        {
            var beYeuThich = BeDal.beYeuThichByUser(string.Empty, false, null, Security.Username, 50);
            var capNhatYeuThich = CapNhatDal.capNhatYeuThichByUsername(string.Empty, false, null, 50, Security.Username);
            YeuThich1.beYeuThich = beYeuThich;
            YeuThich1.postYeuThich = capNhatYeuThich;
        }
    }
}