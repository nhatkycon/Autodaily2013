using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_pages_NhatKy_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        if (string.IsNullOrEmpty(id))
            return;
        using(var con=DAL.con() )
        {
            var item = BeDal.SelectById(con, new Guid(id), Security.Username);
            
            CoverImage1.BeItem = item;
            Avatar1.BeItem = item;

            Navigator1.BeItem = item;
            Post_List1.BeItem = item;

            var listCapNhat = CapNhatDal.WallById(con, "10", id, Security.Username, null);
            var postList = new List<CapNhat>();
            foreach (var post in listCapNhat)
            {
                post.BeItem = item;
                postList.Add(post);
            }
            Post_List1.List = postList;

            GiaDinh1.BeItem = item;
            GiaDinh1.List = GiaDinhDal.SelectByPid(con, id, 10);
            LoiChuc1.BeItem = item;
            LoiChuc1.List = LoiChucDal.SelectPid(con, 10, id);
            CungTuoi1.Visible = false;
            //CungTuoi1.BeItem = item;
            //CungTuoi1.List = BeDal.CungTuoi(con, id, 5);
            Title = string.Format("Nhật ký của {0} - NhatKyCon.com", item.Alias);
        }
    }
}