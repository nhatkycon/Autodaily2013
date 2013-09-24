using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_Tin_ViewDanhMuc : System.Web.UI.UserControl
{
    public Pager<Tin> pager { get; set; }
    public DanhMuc PhanLoai { get; set; }
    public DanhMuc Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}