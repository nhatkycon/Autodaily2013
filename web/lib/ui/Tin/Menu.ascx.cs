using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_Tin_Menu : System.Web.UI.UserControl
{
    public List<DanhMuc> List { get; set; }
    public List<DanhMuc> List1 { get; set; }
    public List<DanhMuc> List2 { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var list1 = from p in List
                    where p.Level == 1
                    select p;
        List1 = list1.ToList();
    }
}