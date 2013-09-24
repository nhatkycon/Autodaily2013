using System;
using System.Globalization;
//using System.Web.Script.Serialization;
using docsoft.entities;
using linh.core;
using linh.json;

public partial class lib_ajax_TheoDoi_Default : BasedPage
{
    public TheoDoi Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var ChieuCao = Request["ChieuCao"];
        var CanNang = Request["CanNang"];
        var P_ID = Request["P_ID"];
        var NgayGhi = Request["NgayGhi"];
        var LOAI_ID = Request["LOAI_ID"];
        var LOAISUB_ID = Request["LOAISUB_ID"];
        var ID = Request["ID"];
        switch (subAct)
        {
            case "update":
                #region add
                if(!string.IsNullOrEmpty(ID))
                {
                    Item = TheoDoiDal.SelectById(new Guid(ID));
                    if (!string.IsNullOrEmpty(ChieuCao))
                    {
                        Item.ChieuCao = Convert.ToInt32(ChieuCao);
                    }
                    if (!string.IsNullOrEmpty(CanNang))
                    {
                        Item.CanNang = Convert.ToInt32(CanNang);
                    }
                    if (!string.IsNullOrEmpty(NgayGhi))
                    {
                        Item.NgayGhi = Convert.ToDateTime(NgayGhi, new CultureInfo("vi-Vn"));
                    }
                    Item = TheoDoiDal.Update(Item);
                    TheoDoiView1.Item = Item;
                    TheoDoiView1.Visible = true;
                }
                break;
                #endregion
            case "get":
                #region get
                if (!string.IsNullOrEmpty(ID))
                {
                    EditTheoDoi1.Item = TheoDoiDal.SelectById(new Guid(ID));
                    EditTheoDoi1.Visible = true;
                }
                break;
                #endregion
            default:
                break;

        }
    }
}