using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Game_DanhSachGame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var con  = DAL.con())
        {
            AdminDanhSachGame1.List = GameDal.SelectAll(con);
        }
    }
}