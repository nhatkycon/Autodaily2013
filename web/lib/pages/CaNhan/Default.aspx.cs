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

public partial class lib_pages_CaNhan_Default : BasedPage   
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Security.IsAuthenticated())
            Response.Redirect("~/");
        using(var con=DAL.con())
        {
            var mem = MemberDal.SelectByUser(con, Security.Username);
            CaiDat1.Item = mem;
        }
    }
}