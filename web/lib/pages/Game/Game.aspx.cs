using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Game_Game : System.Web.UI.Page
{
    public string G_ID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        G_ID = Request["ID"];
        using (var con = DAL.con())
        {
            GameBoard1.List = QuestionDal.SelectByGameId(con, G_ID);
        }
    }
}