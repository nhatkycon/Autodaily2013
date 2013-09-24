using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_nhatKy_Album_Add : System.Web.UI.UserControl
{
    public Album AlbumItem { get; set; }
    public List<Anh> List { get; set; }
    public string AB_ID { get; set; }
    public string ID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        AB_ID = Request["AB_ID"];
        ID = Request["ID"];
        
    }
}