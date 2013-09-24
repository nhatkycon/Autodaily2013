using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;

public partial class lib_ajax_Thich_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var ID = Request["ID"];
        var liked = Request["liked"];
        switch (subAct)
        {
            case "like":
                #region add
               if(Security.IsAuthenticated())
               {
                   var likedVal = Convert.ToBoolean(liked);
                   if(likedVal)
                   {
                       ThichDal.DeleteByPIdUsername(new Guid(ID),Security.Username);
                   }
                   else
                   {
                       ThichDal.Insert(new Thich()
                                           {
                                               ID = Guid.NewGuid()
                                               , NgayTao = DateTime.Now
                                               , P_ID = new Guid(ID)
                                               , Username = Security.Username
                                           });
                   }
               }
                break;
                #endregion
            default:
                break;

        }
    }
}