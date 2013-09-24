using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_TheoDoi_TheoDoi_View : homeUi
{
    public DanhMuc Item { get; set; }
    public BaoCaoTheoDoi ItemBaoCao { get; set; }
    public List<TheoDoi> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}