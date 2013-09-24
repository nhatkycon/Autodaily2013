using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using pmSpa.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using System.IO;
using linh.core.dal;

[assembly: WebResource("appStore.pmSpa.khachHangMgr.DanhSachKhachHang.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.khachHangMgr.DanhSachKhachHang.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.pmSpa.khachHangMgr.DanhSachKhachHang
{
    public class Class1 : docPlugUI
    {
        delegate void sendEmailDelegate(string _email, string _title, string _body);
        void sendMail(string _email, string _title, string _body)
        {
            omail.Send(_email, "noreply@naturalsalon.vn", _title, _body, "giaoban.pmtl@gmail.com", "NaturalSalon", "123$5678");
        }
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Variables
            var ID = Request["ID"];
            var Ma = Request["Ma"];
            var Ten = Request["Ten"];
            var Ho = Request["Ho"];
            var XungHo = Request["XungHo"];
            var NgaySinh = Request["NgaySinh"];
            var GioiTinh = Request["GioiTinh"];
            var Email = Request["Email"];
            var Mobile = Request["Mobile"];
            var Phone = Request["Phone"];
            var CMND = Request["CMND"];
            var Ym = Request["Ym"];
            var FacebookUid = Request["FacebookUid"];
            var LinhVuc_ID = Request["LinhVuc_ID"];
            var NguonGoc_ID = Request["NguonGoc_ID"];
            var NguonGoc_ChiTiet_ID = Request["NguonGoc_ChiTiet_ID"];
            var DiaChi = Request["DiaChi"];
            var KhuVuc_ID = Request["KhuVuc_ID"];
            var NgayTao = Request["NgayTao"];
            var NguoiTao = Request["NguoiTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var NgungTheoDoi = Request["NgungTheoDoi"];
            var NoiBat = Request["NoiBat"];
            var ChiaSe = Request["ChiaSe"];
            var DanhGia = Request["DanhGia"];
            var KhongNhanEmail = Request["KhongNhanEmail"];
            var KhongDuocGoiDien = Request["KhongDuocGoiDien"];
            var ThoiGianGoiDien = Request["ThoiGianGoiDien"];
            var NguoiGioiThieu = Request["NguoiGioiThieu"];
            var TuVanVien = Request["TuVanVien"];
            var EmailTitle = Request["EmailTitle"];
            var EmailBody = Request["EmailBody"];
            
            var _q = Request["q"];
            #endregion

            var ListRow = new List<jgridRow>();
            switch (subAct)
            {
                case "get":
                    #region get
                    var pagerGet = KhachHangDal.pagerNormal("", false, "a.KH_" +  jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), KhuVuc_ID,NguonGoc_ID);
                    foreach (var item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.Ma
                            , item.Ten
                            , item.Mobile
                            , item.Email
                            , item.GioiTinh ? "Nam" : "Nữ"
                            , item.Ym
                            , item.NgaySinh.ToString("dd/MM/yy")  
                            , item.KhuVuc_Ten
                            , item.NguonGoc_Ten                          
                            , string.Format("{0:dd/MM/yy}",item.NgayCapNhat
                            )
                        }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , pagerGet.TotalPages.ToString()
                        , pagerGet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                #endregion
                case "save":
                    #region chỉnh sửa
                    if (Security.IsAuthenticated())
                    {
                        var item = new KhachHang();
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = KhachHangDal.SelectById(new Guid(ID));
                        }
                        item.CMND = CMND;
                        item.DiaChi = DiaChi;
                        item.Email = Email;
                        item.GioiTinh = Convert.ToBoolean(GioiTinh);
                        item.KhuVuc_ID = new Guid(KhuVuc_ID);
                        item.Ma = Ma;
                        item.Mobile = Mobile;
                        item.NgayCapNhat = DateTime.Now;
                        if (!string.IsNullOrEmpty(NgaySinh))
                        {
                            item.NgaySinh = Convert.ToDateTime(NgaySinh, new CultureInfo("vi-Vn"));                            
                        }
                        item.NgungTheoDoi = Convert.ToBoolean(NgungTheoDoi);
                        item.NguoiCapNhat = Security.Username;
                        item.NguonGoc_ID = new Guid(NguonGoc_ID);
                        item.Phone = Phone;
                        item.Ten = Ten;
                        item.Ym = Ym;

                        if(!string.IsNullOrEmpty(LinhVuc_ID))
                        {
                            item.LinhVuc_ID = new Guid(LinhVuc_ID);
                        }
                        if (!string.IsNullOrEmpty(NguoiGioiThieu))
                        {
                            item.NguoiGioiThieu = new Guid(NguoiGioiThieu);
                        }
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = KhachHangDal.Update(item);
                        }
                        else
                        {
                            item.ID = Guid.NewGuid();
                            item.NgayTao = DateTime.Now;
                            item.NguoiTao = Security.Username;
                            item = KhachHangDal.Insert(item);
                        }
                        sb.Append(item.ID.ToString());
                    }
                    
                    break;
                    #endregion
                case "draff":
                    #region draff
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(KhachHangDal.SelectDraff(DAL.con())));
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(KhachHangDal.SelectById(new Guid(ID))));

                    }
                    break;
                    #endregion
                case "del":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        KhachHangDal.DeleteById(new Guid(ID));

                    }
                    break;
                    #endregion
                case "sendmail":
                    #region sendmail
                    if (!string.IsNullOrEmpty(ID))
                    {
                        using (var con = DAL.con())
                        {
                            string[] _email = ID.Split(new char[] { ',' });
                            sendEmailDelegate _send = new sendEmailDelegate(sendMail);
                            foreach (var eitem in _email)
                            {
                                if (eitem != "")
                                {
                                    var kh = KhachHangDal.SelectById(new Guid(eitem), con);
                                    if (!string.IsNullOrEmpty(kh.Email))
                                    {
                                        _send.BeginInvoke(kh.Email, string.Format(EmailTitle,kh.Ten,kh.Email), string.Format(EmailBody,kh.Ten,kh.Email), null, null);
                                    }
                                }
                            }
                        }                                                                        
                    }
                    break;
                    #endregion
                case "search":
                    #region get
                    var pagerSearch = KhachHangDal.pagerNormal("", false, "a.KH_Ten", _q, 20, null, null);
                    sb.Append(JavaScriptConvert.SerializeObject(pagerSearch.List));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.khachHangMgr.DanhSachKhachHang.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region default
                    {
                        var ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                        sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "DanhSachKhachHang.mdl.htm"));
                        sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                            , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.khachHangMgr.DanhSachKhachHang.JScript1.js")
                            , "{DanhSachKhachHangFn.loadgrid();}");
                        sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                        break;
                    }
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
