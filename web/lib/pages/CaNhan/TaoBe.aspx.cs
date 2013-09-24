using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;

public partial class lib_pages_CaNhan_TaoBe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Security.IsAuthenticated())
            Response.Redirect("~/");
    }
}