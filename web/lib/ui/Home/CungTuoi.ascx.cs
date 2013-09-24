using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class lib_ui_Home_CungTuoi : homeUi
{
    public List<Be> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (BeItem != null && BeItem.KhongChiaSe)
        {
            if (BeItem.Username != Security.Username)
            {
                Server.Transfer("~/lib/pages/NhatKy/Lock.aspx");
            }            
        }
        if (List != null && List.Any())
        {
            this.Visible = true;
        }
        else
        {
            this.Visible = false;
        }
        //if (BeItem.Username == Security.Username && List.Any())
        //{
        //    this.Visible = true;
        //}
        //else
        //{
        //    this.Visible = false;
        //}
    }
}