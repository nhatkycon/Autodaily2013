using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_TayDua_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var con = DAL.con())
        {
            var nList = new List<CauHoi>();
            var list= CauHoiDal.SelectTopRandom(10,con);
            foreach (var item in list)
            {
                var nitem = item;
                nitem.DapAns = DapAnDal.SelectByChId(con, item.ID.ToString());
                nList.Add(nitem);
            }
            CauHoiView.List = nList;
        }
    }
}