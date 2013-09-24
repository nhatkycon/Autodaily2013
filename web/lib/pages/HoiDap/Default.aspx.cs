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

public partial class lib_pages_HoiDap_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Security.IsAuthenticated())
        {
            TrangThaiBe1.Visible = false;
        }
        using (var con = DAL.con())
        {
            var danhSachBe = BeDal.ByUser(con, Security.Username, 50);
            TrangThaiBe1.List = danhSachBe;
            var listDanhMuc = DanhMucDal.SelectTreeByDmMa(con, "TIN-TUC-ROOT");
            var listPhanLoai = DanhMucDal.SelectByLDMMa(con, "HOI-DAP").OrderBy(p => p.ThuTu).ToList();
            var newListPhanLoai = new List<DanhMuc>();
            foreach (var item in listPhanLoai)
            {
                item.SpaHoiDaps = SpaHoiDapDal.SelectByDanhMuc(con,item.ID.ToString(), 5);
                newListPhanLoai.Add(item);
            }
            Home1.List = newListPhanLoai;
            Menu1.List = listDanhMuc;
        }
    }
}