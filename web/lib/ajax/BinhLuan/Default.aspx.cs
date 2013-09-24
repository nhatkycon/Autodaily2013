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

public partial class lib_ajax_BinhLuan_Default : BasedPage
{
    public BinhLuan Item { get; set; }
    public List<BinhLuan> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Txt = Request["Txt"];
        var ID = Request["ID"];
        var Url = Request["Url"];
        var FromDate = Request["FromDate"];
        var bcyMail = new BcyMail();
        switch (subAct)
        {
            case "add":
                #region add
                if(Security.IsAuthenticated())
                {
                    Item=new BinhLuan();
                    if(!string.IsNullOrEmpty(ID))
                    {
                        Item.P_RowId = new Guid(ID);                        
                    }
                    if (!string.IsNullOrEmpty(Txt))
                    {
                        Txt = Giga.Common.Lib._string.getHTML(Txt);
                    }
                    Item.ID = Guid.NewGuid();
                    Item.NoiDung = Txt;
                    Item.Username = Security.Username;
                    Item.NgayTao = DateTime.Now;
                    Item.Url = Url;
                    Item = BinhLuanDal.Insert(Item);
                    bcyMail.BinhLuan(Item.ID);
                    rendertext(Item.ID.ToString());                    
                }
                break;
                #endregion
            case "xoa":
                #region add
                if (Security.IsAuthenticated())
                {
                    if (!string.IsNullOrEmpty(ID))
                    {
                        BinhLuanDal.DeleteById(new Guid(ID));
                    }
                }
                break;
                #endregion
            default:
                break;

        }

        switch (act)
        {
            case "list":
            #region get list
                if (!string.IsNullOrEmpty(ID))
                {
                    rpt.DataSource = BinhLuanDal.ByPid(DAL.con(), ID, FromDate, "20", Security.Username);
                    rpt.DataBind();    
                }
                break;
            #endregion
            case "view":
                #region get view
                if (!string.IsNullOrEmpty(ID))
                {
                    Item = BinhLuanDal.SelectById(new Guid(ID));
                    BinhLuan_PureTemplates2.Item = Item;
                    BinhLuan_PureTemplates2.Visible = true;
                }
                break;
            #endregion
            default: break;
        }
    }
}