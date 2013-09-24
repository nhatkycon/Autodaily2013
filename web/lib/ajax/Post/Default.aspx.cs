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

public partial class lib_ajax_Post_Default : BasedPage
{
    public CapNhat Item { get; set; }
    public string ID { get; set; }
    public Be BeItem { get; set; }
    public List<CapNhat> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var Ten = Request["Ten"];
        var NoiDung = Request["NoiDung"];
        var P_ID = Request["P_ID"];
        var Anh = Request["Anh"];
        var NgayViet = Request["NgayViet"];
        var FromDate = Request["FromDate"];
        ID = Request["ID"];
        switch (subAct)
        {
            case "add":
                #region add
                Item = new CapNhat();
                Item.ID = Guid.NewGuid();
                Item.Ten = Ten;
                Item.NoiDung = NoiDung;
                Item.NgayTao = DateTime.Now;
                Item.Username = Security.Username;
                if(!string.IsNullOrEmpty(P_ID))
                {
                    Item.P_ID = new Guid(P_ID);
                }
                if (!string.IsNullOrEmpty(NgayViet))
                {
                    Item.NgayViet = Convert.ToDateTime(NgayViet, new CultureInfo("vi-Vn"));
                }
                Item.Anh = Anh;
                Item.Loai = 1;// Blog
                Item = CapNhatDal.Insert(Item);
                rendertext(Item.ID.ToString());
                break;
                #endregion
            case "remove":
                #region remove
                if(Security.IsAuthenticated())
                {
                    if(!string.IsNullOrEmpty(ID))
                    {
                        var item = CapNhatDal.SelectById(new Guid(ID));
                        if(item.Username==Security.Username)
                        {
                            CapNhatDal.DeleteById(item.ID);
                        }
                    }
                }
                break;
                #endregion
            case "more":
                #region more
                using(var con = DAL.con())
                {
                    var BeItem = BeDal.SelectById(con, new Guid(ID), Security.Username);
                    List = CapNhatDal.WallById(con, "10", ID, Security.Username, FromDate);
                    var _postList = new List<CapNhat>();
                    foreach (var post in List)
                    {
                        post.BeItem = BeItem;
                        _postList.Add(post);
                    }
                    postList.DataSource = _postList;    
                    postList.DataBind();
                    postList.Visible = true;
                }

                break;
                #endregion
            case "upload":
            #region upload
                if (Security.IsAuthenticated())
                {
                    var key = Guid.NewGuid().ToString();
                    var img = new linh.controls.ImageProcess(Request.Files[0].InputStream, key);
                    if (img.Width < 300)
                        rendertext("300");
                    img.Resize(520);
                    img.Save(Server.MapPath("~/lib/up/i/") + key + img.Ext);
                    rendertext(key + img.Ext);
                }
                break;                
            #endregion
            default:
                break;

        }
        switch (act)
        {
            case "view":
                #region xem post
                using(var con=DAL.con())
                {
                    var Item = CapNhatDal.SelectById(con, new Guid(ID));
                    Item.BeItem = BeDal.SelectById(con, new Guid(ID));
                    Post_PureTemplate1.Visible = true;
                    Post_PureTemplate1.Item = Item;
                }
                break;
                #endregion
            default: break;
        }
    }
}