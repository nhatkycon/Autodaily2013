using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_CaNhan_Profile : homeUi
{
    public Member Item { get; set; }
    public List<Be> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}