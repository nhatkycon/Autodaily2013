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

public partial class lib_pages_CaNhan_Profile : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var U = Request["U"];
        if (string.IsNullOrEmpty(U))
            return;
        using (var con = DAL.con())
        {
            var mem = MemberDal.SelectByUser(con, U, Security.Username);
            Profile1.Item = mem;
            var list = BeDal.ByUser(con, U, 50);
            Profile1.List = list;
        }
    }
}