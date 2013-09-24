using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;
using spa.entitites;

public partial class lib_ajax_Hoidap_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Ten = Request["Ten"];
        var DM_ID = Request["DM_ID"];
        var DoTuoi_ID = Request["DoTuoi_ID"];
        var NoiDung = Request["NoiDung"];
        var _ID = Request["ID"];
        SpaHoiDap Item;
        switch (subAct)
        {
            case "add":
                #region add
                if(Security.IsAuthenticated())
                {
                    if (string.IsNullOrEmpty(_ID))
                    {
                        Item = new SpaHoiDap();
                        Item.NgayTao = DateTime.Now;
                        Item.NguoiTao = Security.Username;
                    }
                    else
                    {
                        Item = SpaHoiDapDal.SelectById(Convert.ToInt32(_ID));

                    }
                    Item.Ten = Ten;
                    Item.NoiDung = NoiDung;
                    if (!string.IsNullOrEmpty(DoTuoi_ID))
                    {
                        Item.DoTuoi_ID = new Guid(DoTuoi_ID);                        
                    }
                    if (!string.IsNullOrEmpty(DM_ID))
                    {
                        Item.DM_ID = new Guid(DM_ID);
                    }
                    if (string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaHoiDapDal.Insert(Item);    
                        
                    }
                    else
                    {                        
                        Item = SpaHoiDapDal.Update(Item);    
                    }
                    rendertext(Item.ID.ToString());
                }
                break;
                #endregion
            case "traLoi":
                #region add
                if (Security.IsAuthenticated())
                {
                    Item = new SpaHoiDap();
                    Item.NgayTao = DateTime.Now;
                    Item.NguoiTao = Security.Username;
                    Item.NoiDung = NoiDung;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item.HD_ID = Convert.ToInt32(_ID);
                    }
                    Item = SpaHoiDapDal.Insert(Item);
                    traLoi1.Visible = true;
                    traLoi1.Item = Item;
                }
                break;
                #endregion
            case "remove":
                #region add
                if (Security.IsAuthenticated())
                {
                    if (!string.IsNullOrEmpty(ID))
                    {
                        Item = SpaHoiDapDal.SelectById(Convert.ToInt32(_ID));
                        if (Item.NguoiTao == Security.Username)
                        {
                            GiaDinhDal.DeleteById(new Guid(ID));
                        }
                    }
                }
                break;
                #endregion
            default:
                break;

        }
    }
}