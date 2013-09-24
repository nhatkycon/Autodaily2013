using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Tin_DanhMuc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var dm_id = Request["DM_ID"];
        var phanLoai_id = Request["PHANLOAI_ID"];
        using (var con = DAL.con())
        {
            var listDanhMuc = DanhMucDal.SelectTreeByDmMa(con, "TIN-TUC-ROOT");
            Menu1.List = listDanhMuc;
            var pg = TinDal.pagerByDmIdPhanLoaiId(con, null, false, null, dm_id, phanLoai_id);
            if(!string.IsNullOrEmpty(dm_id))
            {
                var item = DanhMucDal.SelectById(con, new Guid(dm_id));
                ViewDanhMuc1.Item = item;
            }
            if (!string.IsNullOrEmpty(phanLoai_id))
            {
                var phanLoai = DanhMucDal.SelectById(con, new Guid(phanLoai_id));
                ViewDanhMuc1.PhanLoai = phanLoai;
            }
            ViewDanhMuc1.pager = pg;
        }
    }
}