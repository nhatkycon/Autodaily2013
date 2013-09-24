using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;

public partial class lib_ui_GiaDinh_DanhSach : homeUi
{
    public List<GiaDinh> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(List!=null)
        {
            postList.DataSource = List;
            postList.DataBind();
        }
    }
}