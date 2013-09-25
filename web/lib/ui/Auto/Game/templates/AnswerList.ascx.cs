using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_Auto_Game_templates_AnswerList : System.Web.UI.UserControl
{
    public List<Answer> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List != null)
        {
            rpt.DataSource = List;
            rpt.DataBind();    
        }
        
    }
}