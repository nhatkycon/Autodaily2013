using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core;
using linh.json;

public partial class lib_ajax_TayDua_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var ID = Request["ID"];
        var ThuTu = Request["ThuTu"];
        var Ten = Request["Ten"];
        var MoTa = Request["MoTa"];
        var Anh = Request["Anh"];
        var AnhDaiDien = Request["AnhDaiDien"];
        var LOAI_ID = Request["LOAI_ID"];
        var Diem = Request["Diem"];
        var G_ID = Request["G_ID"];
        var Q_ID = Request["Q_ID"];
        var CH_ID = Request["CH_ID"];
        var Active = Request["Active"];
        var Email = Request["Email"];
        var LUOT_ID = Request["LUOT_ID"];
        var location = Server.MapPath("~/lib/up/i/");
        CapNhat Item;
        switch (subAct)
        {
            case "saveDapAn":
                #region saveQuestion

                if (Security.IsAuthenticated())
                {
                    var item = string.IsNullOrEmpty(ID) ? new DapAn() : DapAnDal.SelectById(new Guid(ID));
                    item.Ten = Ten;
                    item.ThuTu = Convert.ToInt32(ThuTu);
                    if (!string.IsNullOrEmpty(CH_ID))
                    {
                        item.CH_ID = new Guid(CH_ID);
                    }
                    item.ID = string.IsNullOrEmpty(ID) ? Guid.NewGuid() : new Guid(ID);
                    item = string.IsNullOrEmpty(ID) ? DapAnDal.Insert(item) : DapAnDal.Update(item);
                    AdminDapAnItem1.Item = item;
                    AdminDapAnItem1.Visible = true;
                }
                break;
                #endregion
            case "saveCauHoi":
                #region saveQuestion

                if (Security.IsAuthenticated())
                {
                    var item = string.IsNullOrEmpty(ID) ? new CauHoi() : CauHoiDal.SelectById(new Guid(ID));
                    item.Ten = Ten;
                    item.MoTa = MoTa;
                    item.Diem = Convert.ToInt32(Diem);
                    if(!string.IsNullOrEmpty(LOAI_ID))
                    {
                        item.LOAI_ID = new Guid(LOAI_ID);
                    }
                    item.ID = string.IsNullOrEmpty(ID) ? Guid.NewGuid() : new Guid(ID);
                    item = string.IsNullOrEmpty(ID) ? CauHoiDal.Insert(item) : CauHoiDal.Update(item);
                    AdminCauHoiItem1.Item = item;
                    AdminCauHoiItem1.Visible = true;
                }
                break;
                #endregion
            case "getDapAnList":
                #region Xoa
                if (!string.IsNullOrEmpty(ID))
                {
                    var List = DapAnDal.SelectByChId(ID);
                    AdminDapAnList1.List = List;
                    AdminDapAnList1.Visible = true;
                }
                break;
                #endregion
            case "editQuestion":
                #region Sua tieu de
                if (Security.IsAuthenticated())
                {
                    var item = QuestionDal.SelectById(new Guid(ID));
                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(item)));
                }
                break;
                #endregion
            case "updateDapAnThuTu":
                #region Cap nhat updateThuTuAnswer
                if (Security.IsAuthenticated())
                {
                    var item = DapAnDal.SelectById(new Guid(ID));
                    item.ThuTu = Convert.ToInt32(ThuTu);
                    item = DapAnDal.Update(item);
                }
                break;
                #endregion
            case "updateDapAnTen":
                #region Cap nhat updateDapAnTen
                if (Security.IsAuthenticated())
                {
                    var item = DapAnDal.SelectById(new Guid(ID));
                    item.Ten = Ten;
                    item = DapAnDal.Update(item);
                }
                break;
                #endregion
            case "updateDapAnDung":
                #region Cap nhat updateDapAnDung
                if (Security.IsAuthenticated())
                {
                    var item = DapAnDal.SelectById(new Guid(ID));
                    item.Dung = true;
                    item = DapAnDal.Update(item);
                }
                break;
                #endregion
            case "editCauHoi":
                #region Sua tieu de
                if (!string.IsNullOrEmpty(ID))
                {
                    var item = CauHoiDal.SelectById(new Guid(ID));
                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(item)));
                }
                break;
                #endregion
            case "updateQuestionActive":
                #region Cap nhat updateQuestionActive
                if (!string.IsNullOrEmpty(ID))
                {
                    var item = QuestionDal.SelectById(new Guid(ID));
                    item.Active = Convert.ToBoolean(Active);
                    item = QuestionDal.Update(item);
                }
                break;
                #endregion
            case "removeCauHoi":
                #region Xoa
                if (Security.IsAuthenticated())
                {
                    CauHoiDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion
            case "newCauHoi":
                #region Xoa
                if (!string.IsNullOrEmpty(Email))
                {
                    var u = MemberDal.SelectByUsername(Email);
                    if(string.IsNullOrEmpty(u.Password))
                    {
                        u = new Member
                                {
                                    Username = Email,
                                    Email = Email,
                                    Ten = Ten,
                                    NgayTao = DateTime.Now,
                                    NgayCapNhat = DateTime.Now,
                                    XacNhan = true,
                                    Password = maHoa.EncryptString("123", Email)
                                };
                        u = MemberDal.Insert(u);
                    }
                    var luot = new LuotChoi()
                                   {
                                       Diem = 0
                                       ,
                                       ID = Guid.NewGuid()
                                       ,
                                       NgayTao = DateTime.Now
                                       ,
                                       Ten = Ten
                                       ,
                                       Username = Email
                                   };
                    luot = LuotChoiDal.Insert(luot);
                    rendertext(luot.ID.ToString());
                }
                break;
                #endregion
            case "ketQuaCauHoi":
                #region ketQuaCauHoi
                if (!string.IsNullOrEmpty(ID))
                {
                    var ketQua = KetQuaDal.SelectByLuotId(ID);
                    var diem = from p in ketQua
                               where p.Diem == 1
                               select p;
                    rendertext(string.Format(@"<h1>Bạn đã về đích</h1>
Bạn đạt {0}/{1}<br>", diem.Count() , 10));
                }
                break;
                #endregion
            case "saveDapAnCauHoi":
                #region saveDapAnCauHoi
                if (!string.IsNullOrEmpty(ID) && !string.IsNullOrEmpty(LUOT_ID))
                {
                    var luot = LuotChoiDal.SelectById(new Guid(LUOT_ID));
                    var dapAn = DapAnDal.SelectById(new Guid(ID));
                    var ketQua = KetQuaDal.SelectByLuotIdChId(LUOT_ID, dapAn.CH_ID.ToString());

                    if(ketQua.ID==Guid.Empty)
                    {
                        ketQua = KetQuaDal.Insert(new KetQua()
                                                      {
                                                          CH_ID = dapAn.CH_ID
                                                          ,
                                                          Diem = dapAn.Dung ? 1 : 0
                                                          ,
                                                          ID = Guid.NewGuid()
                                                          ,
                                                          LUOT_ID = luot.ID
                                                          ,
                                                          Username = luot.Username
                                                      });
                    }
                    ketQua.Diem = dapAn.Dung ? 1 : 0;
                    ketQua = KetQuaDal.Update(ketQua);
                }
                break;
                #endregion
            case "removeDapAn":
                #region Xoa
                if (Security.IsAuthenticated())
                {
                    DapAnDal.DeleteById(new Guid(ID));
                }
                break;
                #endregion
            default:
                Response.Write("s");
                break;
        }
    }
}