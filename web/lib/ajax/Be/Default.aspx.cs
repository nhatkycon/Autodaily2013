using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_Be_Default : BasedPage    
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Ten = Request["Ten"];
        var Ho = Request["Ho"];
        var Alias = Request["Alias"];
        var GioiTinh = Request["GioiTinh"];
        var NgaySinh = Request["NgaySinh"];
        var NgayDuSinh = Request["NgayDuSinh"];
        var MangThai = Request["MangThai"];
        var CanNangKhiSinh = Request["CanNang"];
        var Nick = Request["Nick"];
        var ID = Request["ID"];
        var Css = Request["css"];
        var KhongChiaSe = Request["KhongChiaSe"];
        Be Item;
        switch (subAct)
        {
            case "add":
            #region add
                Item = new Be();
                Item.Alias = Alias;
                Item.MangThai = MangThai == "1";
                Item.ID = Guid.NewGuid();
                if(Item.MangThai)
                {
                    if (!string.IsNullOrEmpty(NgayDuSinh))
                    {
                        Item.NgayDuSinh = Convert.ToDateTime(NgayDuSinh, new CultureInfo("vi-Vn"));                        
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(NgaySinh))
                    {
                        Item.NgaySinh = Convert.ToDateTime(NgaySinh, new CultureInfo("vi-Vn"));
                    }
                    Item.GioiTinh = Convert.ToBoolean(GioiTinh);
                    if (!string.IsNullOrEmpty(CanNangKhiSinh))
                    {
                        Item.CanNangKhiSinh = Convert.ToInt32(CanNangKhiSinh);
                    }
                    Item.Ten = Ten;
                    Item.Ho = Ho;
                    Item.Alias = Alias;
                }
                Item.NgayTao = DateTime.Now;
                Item.Username = Security.Username;
                Item.Khoa = false;
                Item.KhongChiaSe = false;
                Item = BeDal.Insert(Item);
                rendertext(Item.ID.ToString());
                break;
            #endregion
            case "save":
                #region save

                Item = BeDal.SelectById(new Guid(ID));
                Item.Alias = Alias;
                Item.MangThai = MangThai == "1";
                if (Item.MangThai)
                {
                    if (!string.IsNullOrEmpty(NgayDuSinh))
                    {
                        Item.NgayDuSinh = Convert.ToDateTime(NgayDuSinh, new CultureInfo("vi-Vn"));
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(NgaySinh))
                    {
                        Item.NgaySinh = Convert.ToDateTime(NgaySinh, new CultureInfo("vi-Vn"));
                    }
                    Item.GioiTinh = Convert.ToBoolean(GioiTinh);
                    if (!string.IsNullOrEmpty(CanNangKhiSinh))
                    {
                        Item.CanNangKhiSinh = Convert.ToInt32(CanNangKhiSinh);
                    }
                    Item.Ten = Ten;
                    Item.Ho = Ho;
                    Item.Alias = Alias;
                }
                Item = BeDal.Update(Item);
                rendertext(Item.ID.ToString());
                break;
                #endregion
            case "doiAnh":
            #region Doi anh
                if(Security.IsAuthenticated())
                {
                    var key = Guid.NewGuid().ToString();
                    var img = new linh.controls.ImageProcess(Request.Files[0].InputStream, key);
                    if(img.Width < 930)
                        rendertext("930");
                    img.Resize(930);
                    img.Save(Server.MapPath("~/lib/up/avatar/") + key + img.Ext);
                    Item = BeDal.SelectById(new Guid(ID));
                    Item.Cover = key + img.Ext;
                    BeDal.Update(Item);
                    rendertext(key + img.Ext);
                }
                break;
            #endregion
            case "SuaNick":
                #region SuaNick
                if (Security.IsAuthenticated())
                {
                    var be = BeDal.SelectByNick(DAL.con(), Nick, Security.Username);
                    var beId = BeDal.SelectById(new Guid(ID));

                    if(be.ID != Guid.Empty && be.ID!=beId.ID)
                    {
                        rendertext("0");
                    }
                    else
                    {
                        beId.Nick = Nick.ToLower();
                        BeDal.Update(beId);
                        rendertext("1");
                    }

                }
                break;
                #endregion
            case "moveCover":
                #region moveCover
                if (Security.IsAuthenticated())
                {
                    Item = BeDal.SelectById(new Guid(ID));
                    if (Item.Username == Security.Username)
                    {
                        Item.CoverCss = Css;
                        BeDal.Update(Item);    
                    }
                    rendertext(Css);                    
                }
                break;
                #endregion
            case "UpdateChiaSe":
                #region moveCover
                if (Security.IsAuthenticated())
                {
                    Item = BeDal.SelectById(new Guid(ID));
                    if (Item.Username==Security.Username)
                    {
                        Item.KhongChiaSe = Convert.ToBoolean(KhongChiaSe);
                        BeDal.Update(Item);    
                    }
                }
                break;
                #endregion
            case "doiAvatar":
                #region Doi Avatar
                if (Security.IsAuthenticated())
                {
                    var key = Guid.NewGuid().ToString();
                    var img = new linh.controls.ImageProcess(Request.Files[0].InputStream, key);
                    img.Resize(400);
                    img.Save(Server.MapPath("~/lib/up/avatar/") + key + img.Ext);
                    Item = BeDal.SelectById(new Guid(ID));
                    Item.Anh = key + img.Ext;
                    BeDal.Update(Item);
                    rendertext(key + img.Ext);
                }
                break;
                #endregion
            default:
                break;
                
        }
    }
}