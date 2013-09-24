using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;
using linh.core;

public partial class lib_ui_CaNhan_YeuThich : BasedUi
{
    public Pager<CapNhat> postYeuThich { get; set; }
    public Pager<Be> beYeuThich { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}