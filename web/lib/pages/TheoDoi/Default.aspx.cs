using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_pages_TheoDoi_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        if (string.IsNullOrEmpty(id))
            return;
        using (var con = DAL.con())
        {
            var item = BeDal.SelectById(con, new Guid(id), Security.Username);
            CoverImage1.BeItem = item;
            Navigator1.BeItem = item;
            var list = BaoCaoTheoDoiDal.SelectByPid(con, id);
            Navigator1.List = list;
            DanhSach1.BeItem = item;
            DanhSach1.List = list;
        }
    }
}