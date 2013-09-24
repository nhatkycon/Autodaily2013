using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using spa.entitites;

public partial class lib_ui_HoiDap_DanhSachTraLoi : System.Web.UI.UserControl
{
    public SpaHoiDap Item { get; set; }
    public List<SpaHoiDap> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        TraLoi1.Item = Item;
        postList.DataSource = List;
        postList.DataBind();
    }
}