using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_pages_NhatKy_Post : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var ID = Request["ID"];
        if (string.IsNullOrEmpty(ID))
            return;
        using (var con = DAL.con())
        {

            var Item = CapNhatDal.SelectById(con, new Guid(ID));
            Item.Anhs = AnhDal.SelectByAbId(DAL.con(), Item.AB_ID.ToString(), 30);
            var item = BeDal.SelectById(con,Item.P_ID);
            Item.BeItem = item;
            Post_View1.Item = Item;
            CoverImage1.BeItem = item;
            Avatar1.BeItem = item;
            Navigator1.BeItem = item;
            GiaDinh1.BeItem = item;
            GiaDinh1.List = GiaDinhDal.SelectByPid(con, Item.P_ID.ToString(), 10);
            LoiChuc1.BeItem = item;
            LoiChuc1.List = LoiChucDal.SelectPid(con, 10, Item.P_ID.ToString());
            BinhLuan1.PID = ID;
            Title = string.Format("{0} - NhatKyCon.com", Item.Ten);
        }
    }
}