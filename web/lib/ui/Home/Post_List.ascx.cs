using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_Home_Post_List : homeUi
{
    public List<CapNhat> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        postList.DataSource = List;
        postList.DataBind();
    }
}