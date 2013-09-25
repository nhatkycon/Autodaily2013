using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Game_Question : System.Web.UI.Page
{
    public string ID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ID = Request["ID"];
        using (var con = DAL.con())
        {
            QuestionView1.List = AnswerDal.SelectByQuestionId(con, ID);
            QuestionView1.Item = QuestionDal.SelectById(new Guid(ID));
        }
    }
}