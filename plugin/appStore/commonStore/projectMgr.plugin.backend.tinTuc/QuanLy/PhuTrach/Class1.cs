using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web;
using linh;
using linh.core.dal;
using linh.frm;
using linh.json;
using linh.common;
using linh.controls;
using docsoft;
using docsoft.entities;
using System.Xml;
using System.Globalization;
using System.IO;
using seo.entities;
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.QuanLy.PhuTrach.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.QuanLy.PhuTrach.htm.htm", "text/html")]
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.QuanLy.PhuTrach.TinLienQuan.htm", "text/html")]
namespace projectMgr.plugin.backend.tinTuc.QuanLy.PhuTrach
{
    public class Class1 : docPlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        void sendmailThongbao(string email, string tieude, string noidung)
        {
            omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "Cangtin.com", "123$5678");
        }
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
            string _F_ID = Request["F_ID"];
            string _GH_ID = Request["GH_ID"];
            string _Lang = Request["Lang"];
            string _Alias = Request["Alias"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _LangBased = Request["LangBased"];
            string _KeyWords = Request["KeyWords"];
            string _Description = Request["Description"];
            string _PID = Request["DMID"];
            string _PTen = Request["DMTen"];
            string _Ten = Request["Ten"];
            string _Mota = Request["Mota"];
            string _NoiDung_tt = Request["NoiDung_tt"];
            string _ThuTu = Request["ThuTu"];
            string _Anh = Request["Anh"];
            string _Hot = Request["Hot"];
            string _q = Request["q"];
            string _HetHan = Request["HetHan"];
            string _NgayHetHan = Request["NgayHetHan"];
            string _NgayCapNhat = Request["NgayCapNhat"];
            string _Status = Request["status"];
            string _Nguon = Request["Nguon"];
            string _CID = Request["CID"];
            string _HG_GioDang = Request["HG_GioDang"];
            List<jgridRow> ListRow;
            #endregion
            var emailTemp = Lib.GetResource(Assembly.GetExecutingAssembly(), "DuyetTin.email-duyet.htm");
            var dele = new DuyetTin.Class1.sendEmailDele(sendmailThongbao);
            string _NguoiTao = Security.Username;
            var admin = false;
            if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "TIN_NgayCapNhat";
            if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
            var itemDuyet = new Tin();
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách


                    var pagerGet = TinDal.PagerPhuTrach(string.Empty, false, Convert.ToInt32(jgRows),
                                                        jgrsidx + " " + jgrsord, _PID, _q, false, Security.Username, true,
                                                        false);

                    ListRow = new List<jgridRow>();
                    foreach (Tin item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,item.LangBased.ToString()
                            ,item._ID.ToString()
                            ,item.Lang
                            ,item.ThuTu.ToString()
                            ,string.Format("<img src=\"../up/tintuc/{0}\" style=\"width:50px;height:50px; \"/>",item.Anh)
                            , string.Format(@"<a target=""_blanks"" href=""{0}/lib/pages/?pages=Tin-tuc-view&TIN-ID={1}"">{2}</a>",domain,item.ID,item.Ten) 
                            ,item.MoTa
                            ,item.DM_Ten
                            ,item.Views.ToString()
                            ,string.Format(@"<a onclick=""tinQuanLyPhuTrachFn.viewThongTinNguoiViet('{0}');"" href=""javascript:;"">{0}</a>", item.NguoiTao)
                            ,item.NgayTao.ToString("HH:mm dd/MM/yyyy")
                            ,item.Active.ToString()
                            ,item.Hot.ToString()
                            ,item.HetHan.ToString()
                            , item.HG_GioDang == DateTime.MinValue ? "" : item.HG_GioDang.ToString("HH:mm - dd/MM")
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pagerGet.TotalPages.ToString(), pagerGet.Total.ToString(), ListRow);
                    //jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getSubTin":
                    #region lấy danh sách
                    var listTinRelation = TinDal.tinLienQuanByRelationPid(Convert.ToInt32(jgRows) , _ID);
                    ListRow = new List<jgridRow>();
                    foreach (var item in listTinRelation)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,string.Format("<img src=\"../up/tintuc/{0}\" style=\"width:50px;height:50px; \"/>",item.Anh)
                            ,item.Ten
                            ,item.MoTa
                            ,item.NguoiTao
                            ,item.NgayCapNhat.ToString("dd/MM/yyyy")
                        }));
                    }
                    jgrid grid1 = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, listTinRelation.Count.ToString(), listTinRelation.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid1));
                    break;
                    #endregion
                case "addSubTin":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        RelationDal.Insert(new Relation()
                                               {
                                                   CID = new Guid(_CID),
                                                   PID = new Guid(_ID),
                                                   RowId = Guid.NewGuid()
                                               });
                    }
                    break;
                    #endregion
                case "delSubTin":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        RelationDal.DeleteByCidPid(_CID,_ID);
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(TinDal.SelectByIdView(_ID)));                        
                    }
                    break;
                    #endregion
                case "yeuCauDuyet":
                    #region Duyệt tin hàng loạt
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        var itemyeuCauDuyet = new Tin();
                        itemyeuCauDuyet.multiID = _ID;
                        itemyeuCauDuyet.Publish = Convert.ToBoolean(_Status);
                        TinDal.UpdateMultiYeuCauDuyet(itemyeuCauDuyet);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        TinDal.DeleteMultiById(_ID, "TIN_TUC");
                    }
                    break;
                    #endregion
                case "duyet":
                    #region Duyệt tin hàng loạt
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        using (SqlConnection con = DAL.con())
                        {
                            con.Open();
                            SqlTransaction tran = con.BeginTransaction();
                            try
                            {
                                TaiKhoan tkItem;
                                //bool Khoa = Convert.ToBoolean(_Khoa);
                                double total = 0;
                                foreach (var id in _ID.Split(new char[] { ',' }))
                                {
                                    if (!string.IsNullOrEmpty(id))
                                    {
                                        itemDuyet.multiID = _ID;
                                        TinDal.UpdateGhId(itemDuyet, _GH_ID, tran);
                                        var tinDuyet = TinDal.SelectById(tran, id);

                                        tkItem = TaiKhoanDal.SelectByUsername(tinDuyet.NguoiTao, tran);
                                        if (!string.IsNullOrEmpty(tkItem.Tk))
                                        {
                                            total = Convert.ToDouble(maHoa.DecryptString(tkItem.Tk, tinDuyet.NguoiTao));
                                        }
                                        var danhMucItem = DanhMucDal.SelectById(tinDuyet.GH_ID);
                                        if(string.IsNullOrEmpty(danhMucItem.GiaTri))
                                        {
                                            renderText("0");
                                        }
                                        var giaTri = Convert.ToDouble(danhMucItem.GiaTri);
                                        total = giaTri + total;
                                        TaiKhoanDal.UpdateTk(tkItem.ID, maHoa.EncryptString(total.ToString(), tinDuyet.NguoiTao), tran);

                                        itemDuyet.Active = Convert.ToBoolean(_Status);
                                        TinDal.UpdateMulti(itemDuyet, tran);

                                        if (tinDuyet.NguoiTao.IndexOf("@") > 0)
                                        {
                                            dele.BeginInvoke(tinDuyet.NguoiTao
                                                             , "Cangtin.com - Bài viết của bạn được duyệt"
                                                             , string.Format(emailTemp, DateTime.Now, tinDuyet.Ten, domain, tinDuyet.ID, tinDuyet.NguoiTao)
                                                             , null, null);
                                        }
                                        sb.Append("1");
                                    }
                                }

                                tran.Commit();
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();
                                sb.Append(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }

                        }
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "duyetHenGio":
                    #region Duyệt tin hàng loạt
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        using (SqlConnection con = DAL.con())
                        {
                            con.Open();
                            SqlTransaction tran = con.BeginTransaction();
                            try
                            {
                                TaiKhoan tkItem;
                                //bool Khoa = Convert.ToBoolean(_Khoa);
                                double total = 0;
                                foreach (var id in _ID.Split(new char[] { ',' }))
                                {
                                    if (!string.IsNullOrEmpty(id))
                                    {
                                        itemDuyet.multiID = _ID;
                                        TinDal.UpdateGhId(itemDuyet, _GH_ID, tran);
                                        var tinDuyet = TinDal.SelectById(tran, id);
                                        tkItem = TaiKhoanDal.SelectByUsername(tinDuyet.NguoiTao, tran);
                                        if (!string.IsNullOrEmpty(tkItem.Tk))
                                        {
                                            total = Convert.ToDouble(maHoa.DecryptString(tkItem.Tk, tinDuyet.NguoiTao));
                                        }
                                        var danhMucItem = DanhMucDal.SelectById(tinDuyet.GH_ID);
                                        if (string.IsNullOrEmpty(danhMucItem.GiaTri))
                                        {
                                            renderText("0");
                                        }
                                        var giaTri = Convert.ToDouble(danhMucItem.GiaTri);
                                        total = giaTri + total;
                                        TaiKhoanDal.UpdateTk(tkItem.ID, maHoa.EncryptString(total.ToString(), tinDuyet.NguoiTao), tran);

                                        itemDuyet.multiID = _ID;
                                        itemDuyet.Active = Convert.ToBoolean(_Status);
                                        //TinDal.UpdateMulti(itemDuyet, tran);

                                        if (tinDuyet.NguoiTao.IndexOf("@") > 0)
                                        {
                                            dele.BeginInvoke(tinDuyet.NguoiTao
                                                             , "Cangtin.com - Bài viết của bạn được duyệt"
                                                             , string.Format(emailTemp, DateTime.Now, tinDuyet.Ten, domain, tinDuyet.ID, tinDuyet.NguoiTao)
                                                             , null, null);
                                        }
                                        var henGioItem = new HenGio()
                                        {
                                            Active = false,
                                            ID = Guid.NewGuid()
                                            ,
                                            TIN_ID = new Guid(id),
                                            NguoiTao = Security.Username
                                            ,
                                            NgayTao = DateTime.Now
                                        };
                                        if (!string.IsNullOrEmpty(_HG_GioDang))
                                        {
                                            //henGioItem.GioDang = DateTime.Parse(_HG_GioDang);
                                            henGioItem.GioDang= Convert.ToDateTime(_HG_GioDang, new CultureInfo("vi-Vn"));
                                            HenGioDal.Insert(henGioItem, tran);
                                        }

                                        sb.Append("1");
                                    }
                                }

                                tran.Commit();
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();
                                sb.Append(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }

                        }
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "autoCompleteSearch":
                    #region autoCompleteSearch
                    var pagerSearch = TinDal.PagerQuanTri(string.Empty, false, Convert.ToInt32(20),
                                                          jgrsidx + " " + jgrsord, string.Empty, _q, true, Security.Username,
                                                          null, true);
                    sb.Append(JavaScriptConvert.SerializeObject(pagerSearch.List));
                    break;
                    #endregion
                case "hot":
                    #region Chuyển thành tin hot
                    Tin ItemHot = new Tin();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemHot.multiID = _ID;
                        ItemHot.Hot = Convert.ToBoolean(_Status);
                        TinDal.UpdateHotMulti(ItemHot);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "hethan":
                    #region Hết hạn
                    Tin ItemHetHan = new Tin();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemHetHan.multiID = _ID;
                        ItemHetHan.HetHan = Convert.ToBoolean(_Status);
                        if (ItemHetHan.HetHan == true)
                        {
                            ItemHetHan.NgayHetHan = DateTime.Now;
                        }
                        TinDal.UpdateHetHanMulti(ItemHetHan);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "save":
                    #region lưu
                    var itemSave = new Tin();
                    if (string.IsNullOrEmpty(_Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        itemSave = TinDal.SelectById(_ID);
                    }
                    if (!string.IsNullOrEmpty(_Nguon))
                    {
                        itemSave.Nguon = (_Nguon);
                    }
                    itemSave.Ten = _Ten;
                    itemSave.DM_ID = new Guid(_PID);
                    // ItemSave.DM_Ten = _PTen;
                    itemSave.Anh = _Anh;
                    if (string.IsNullOrEmpty(_ThuTu))
                    {
                        _ThuTu = "0";
                    }
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        itemSave.GH_ID = new Guid(_GH_ID);
                    }
                    itemSave.ThuTu = Convert.ToInt32(_ThuTu);
                    itemSave.MoTa = _Mota;
                    itemSave.NoiDung = _NoiDung_tt;
                    itemSave.KeyWords = _KeyWords;
                    itemSave.Description = _Description;
                    itemSave.Alias = _Alias;
                    //itemSave.Lang = _Lang;
                    itemSave.LangBased = Convert.ToBoolean(_LangBased);
                    if (!string.IsNullOrEmpty(_LangBased_ID))
                    {
                        itemSave.LangBased_ID = new Guid(_LangBased_ID);
                    }
                    itemSave.Hot = Convert.ToBoolean(_Hot);
                    itemSave.NgayCapNhat = DateTime.Now;
                    if (_Public == "1")
                    {
                        itemSave.NgayDang = DateTime.Now;
                    }
                    itemSave.NguoiCapNhat = Security.Username;
                    itemSave.HetHan = Convert.ToBoolean(_HetHan);
                    if (!string.IsNullOrEmpty(_NgayHetHan))
                    {
                        itemSave.NgayHetHan = Convert.ToDateTime(_NgayHetHan, new CultureInfo("vi-Vn"));
                    }
                    if (!string.IsNullOrEmpty(_NgayCapNhat))
                    {
                        itemSave.NgayCapNhat = Convert.ToDateTime(_NgayCapNhat, new CultureInfo("vi-Vn"));//.AddHours(dt.Hour).AddMinutes(dt.Minute).AddSeconds(dt.Second);
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        itemSave = TinDal.Update(itemSave);
                    }
                    else
                    {
                        itemSave.NguoiTao = Security.Username;
                        itemSave.NgayTao = DateTime.Now;
                        itemSave.RowId = Guid.NewGuid();
                        itemSave.ID = Guid.NewGuid();
                        itemSave = TinDal.Insert(itemSave);
                    }                   
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.QuanLy.PhuTrach.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "QuanLy.PhuTrach.mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.QuanLy.PhuTrach.JScript1.js")
                        , "{tinQuanLyPhuTrachFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
