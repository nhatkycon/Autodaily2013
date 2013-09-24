using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.common;
using linh.core;
using docsoft;
using docsoft.entities;
using linh.core;
public partial class lib_ajax_LuuBut_Default : BasedPage
{
    public LoiChuc Item { get; set; }
    public List<LoiChuc> List { get; set; }
    delegate void sendEmailSingleDelegate(string _email, string _title, string _body);
    BcyMail bcyMail=new BcyMail();
    protected void Page_Load(object sender, EventArgs e)
    {

        var NoiDung = Request["NoiDung"];
        var ID = Request["ID"];
        LoiChuc Item;

        switch (subAct)
        {
            case "add":
                #region add
                Item = new LoiChuc();
                if(!string.IsNullOrEmpty(NoiDung))
                {
                    NoiDung = Giga.Common.Lib._string.getHTML(NoiDung);
                }
                Item.NoiDung = NoiDung;
                Item.Username = Security.Username;
                if(!string.IsNullOrEmpty(ID))
                {
                    Item.P_ID = new Guid(ID);
                }
                Item.NgayTao = DateTime.Now;
                Item.LuotThich = 0;
                Item.ID = Guid.NewGuid();
                Item = LoiChucDal.Insert(Item);
                bcyMail.LoiChuc(Item.ID);
                rendertext(Item.ID.ToString());                
                break;
                #endregion
            case "remove":
                #region remove
                if (Security.IsAuthenticated())
                {
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var item = LoiChucDal.SelectById(new Guid(ID));
                        var beItem = BeDal.SelectById(item.P_ID);
                        if (item.Username == Security.Username || beItem.Username==Security.Username)
                        {
                            LoiChucDal.DeleteById(item.ID);
                        }
                    }
                }
                break;
                #endregion
            default:
                break;

        }
    }
    void sendMailSingle(string _email, string _title, string _body)
    {
        omail.Send(_email, "NhatKyCon - Thong Bao", _title, _body, "gigawebhome@gmail.com", "NhatKyCon", "25111987");
    }
}