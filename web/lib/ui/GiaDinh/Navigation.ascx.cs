using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lib_ui_GiaDinh_Navigation : homeUi
{
    protected void Page_Load(object sender, EventArgs e)
    {
        navi1.BeItem = BeItem;
    }
}