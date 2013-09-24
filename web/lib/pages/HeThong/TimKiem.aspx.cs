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

public partial class lib_pages_HeThong_TimKiem : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var con = DAL.con())
        {
            TimKiem1.List = BeDal.Search(con, Request["q"], 10);
        }
    }
}