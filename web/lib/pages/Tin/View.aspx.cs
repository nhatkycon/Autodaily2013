using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Tin_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        if(string.IsNullOrEmpty(id))
            View1.Visible = false;
        using (var con = DAL.con())
        {
            var listDanhMuc = DanhMucDal.SelectTreeByDmMa(con, "TIN-TUC-ROOT");
            Menu1.List = listDanhMuc;
            View1.Item = TinDal.SelectById(con, id);
            LienQuan1.List = TinDal.SelectLienQuan(id, 20, con);
            BinhLuan1.PID = id;
        }
    }
}