using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core;
public partial class lib_ajax_BaoCaoTheoDoi_Default : BasedPage
{
    public BaoCaoTheoDoi Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var ID = Request["ID"];
        var P_ID = Request["P_ID"];
        var Ten = Request["Ten"];
        var LOAI_ID = Request["LOAI_ID"];
        var Active = Request["Active"];
        switch (subAct)
        {
            case "add":
                #region add
                Item = new BaoCaoTheoDoi();
                Item.ID = Guid.NewGuid();
                if (!string.IsNullOrEmpty(P_ID))
                {
                    Item.PID_ID = new Guid(P_ID);
                }
                if (!string.IsNullOrEmpty(LOAI_ID))
                {
                    Item.LOAI_ID = new Guid(LOAI_ID);
                }
                Item.Ten = Ten;
                if(!string.IsNullOrEmpty(Active))
                {
                    Item.Active = Convert.ToBoolean(Active);                    
                }
                Item.NgayTao = DateTime.Now;
                Item.Username = Security.Username;
                Item = BaoCaoTheoDoiDal.Insert(Item);
                rendertext(Item.ID.ToString());
                break;
                #endregion
            default:
                break;

        }
    }
}