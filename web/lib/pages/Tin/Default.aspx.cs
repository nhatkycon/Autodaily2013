using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Tin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var con = DAL.con())
        {
            var listDanhMuc = DanhMucDal.SelectTreeByDmMa(con, "TIN-TUC-ROOT");
            Menu1.List = listDanhMuc;
            var listPhanLoai = DanhMucDal.SelectByLDMMa(con, "HOI-DAP").OrderBy(p=>p.ThuTu).ToList();
            var newListPhanLoai = new List<DanhMuc>();
            foreach (var item in listPhanLoai)
            {
                item.Tins = TinDal.SelectByPhanLoai(item.ID, 5, con);
                newListPhanLoai.Add(item);
            }
            Home1.List = newListPhanLoai;
        }
    }
}