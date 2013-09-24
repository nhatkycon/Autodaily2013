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

public partial class lib_pages_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var nick = Request["Nick"];
        var email = Request["e"];
        var token = Request["token"];
        using (var con = DAL.con())
        {
            Title = "Web viết nhật ký cho con - Nhật Ký Con.Vn";
            if(Security.IsAuthenticated())
            {
                var danhSachBe = BeDal.ByUser(con, Security.Username, 50);
                DanhSachBe1.List = danhSachBe;                    
            }
            if (!string.IsNullOrEmpty(nick))
            {
                var be = BeDal.SelectByNick(con, nick, Security.Username);
                if(be.ID!= Guid.Empty)
                {
                    //Response.Redirect(string.Format("~/lib/pages/NhatKy/Default.aspx?ID={0}", be.ID));
                    Server.Transfer(string.Format("~/lib/pages/NhatKy/Default.aspx?ID={0}", be.ID));
                    //Response.Write(string.Format("~/lib/pages/NhatKy/Default.aspx?ID={0}", be.ID));
                }
            }
            if(!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(email))
            {
                var mem = MemberDal.SelectById(Convert.ToInt32(token));
                if(mem.Email==email)
                {
                    Security.Login(mem.Username, "true");
                }
                Response.Redirect(string.Format("~/lib/pages/Default.aspx"));
            }
        }
    }
}