using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Game_GameView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var G_ID = Request["G_ID"];
        using (var con = DAL.con())
        {
            AdminDanhSachQuestion1.List = QuestionDal.SelectByGameId(con, G_ID);
        }
    }
}