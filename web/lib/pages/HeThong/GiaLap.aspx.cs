using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;

public partial class lib_pages_HeThong_GiaLap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var u = Request["u"];
        if(!string.IsNullOrEmpty(u))
        {
            Security.Login(u, "true");            
        }
    }
}