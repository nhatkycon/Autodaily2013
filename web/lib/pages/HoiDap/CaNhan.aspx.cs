using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using spa.entitites;

public partial class lib_pages_HoiDap_CaNhan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Security.IsAuthenticated())
        {
            TrangThaiBe1.Visible = false;
            CauHoiCuaToi1.Visible = false;
        }
        using (var con = DAL.con())
        {
            var danhSachBe = BeDal.ByUser(con, Security.Username, 50);
            TrangThaiBe1.List = danhSachBe;
            var listDanhMuc = DanhMucDal.SelectTreeByDmMa(con, "TIN-TUC-ROOT");
            Menu1.List = listDanhMuc;
            var listHoiDap = SpaHoiDapDal.SelectByUsername(con, Security.Username, 50);
            CauHoiCuaToi1.List = listHoiDap;
        }
    }
}