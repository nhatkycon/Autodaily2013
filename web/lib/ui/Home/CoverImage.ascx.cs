using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;

public partial class lib_ui_Home_CoverImage : homeUi
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(BeItem!= null && BeItem.KhongChiaSe)
        {
            if(BeItem.Username!= Security.Username)
            {
                Server.Transfer("~/lib/pages/NhatKy/Lock.aspx");                
            }
        }        
    }
}