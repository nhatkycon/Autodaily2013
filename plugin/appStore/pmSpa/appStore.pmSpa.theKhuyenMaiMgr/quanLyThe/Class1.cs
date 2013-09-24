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

[assembly: WebResource("appStore.pmSpa.theKhuyenMaiMgr.quanLyThe.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.theKhuyenMaiMgr.quanLyThe.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.pmSpa.theKhuyenMaiMgr.quanLyThe
{
    public class Class1 : docPlugUI
    {
        delegate void sendEmailDelegate(string _email, string _title, string _body);
        void sendMail(string _email, string _title, string _body)
        {
            omail.Send(_email, "naturalsalon@gmail.com", _title, _body, "giaoban.pmtl@gmail.com", "Milan", "123$5678");
        }
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Variables
            var ID = Request["ID"];
            var KM_ID = Request["KM_ID"];
            var Ma = Request["Ma"];
            var KH_ID = Request["KH_ID"];
            var DVTC_ID = Request["DVTC_ID"];
            var GiaNY = Request["GiaNY"];
            var Gia = Request["Gia"];
            var HanSuDung = Request["HanSuDung"];
            var HanDoiThe = Request["HanDoiThe"];
            var TinhTrang = Request["TinhTrang"];
            var DV_ID = Request["DV_ID"];
            var NgayPhatHanh = Request["NgayPhatHanh"];
            var NgayNhan = Request["NgayNhan"];
            var NguoiNhan = Request["NguoiNhan"];
            var NgayTao = Request["NgayTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiTao = Request["NguoiTao"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var DaDung = Request["DaDung"];

            var EmailTitle = Request["EmailTitle"];
            var EmailBody = Request["EmailBody"];
            
            var _q = Request["q"];
            #endregion

            var ListRow = new List<jgridRow>();
            switch (subAct)
            {
                case "get":
                    #region get

                    var pagerGet = TheKhuyenMaiDal.pagerAll("a.TKM_" + jgrsidx + " " + jgrsord, _q,
                                                            Convert.ToInt32(jgRows), KM_ID, DVTC_ID, DV_ID, TinhTrang, DaDung);
                    foreach (var item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.DVTC_Ten
                            , item.KM_Ten
                            , item.Ma
                            , Lib.TienVietNam(item.Gia)
                            , Lib.TienVietNam(item.GiaNY)
                            , item.KH_Ten
                            , item.DV_Ten
                            , item.NgayPhatHanh== DateTime.MinValue ? "" : item.NgayPhatHanh.ToString("dd/MM/yyyy")
                            , item.HanSuDung== DateTime.MinValue ? "" : item.HanSuDung.ToString("dd/MM/yyyy")
                            , item.HanDoiThe== DateTime.MinValue ? "" : item.HanDoiThe.ToString("dd/MM/yyyy")
                            , item.TinhTrang.ToString()
                            , item.DaDung.ToString()
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
                        var item = new TheKhuyenMai();
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = TheKhuyenMaiDal.SelectById(new Guid(ID));
                        }
                        
                        if (!string.IsNullOrEmpty(DVTC_ID))
                        {
                            item.DVTC_ID = new Guid(DVTC_ID);
                        }
                        if (!string.IsNullOrEmpty(DV_ID))
                        {
                            item.DV_ID = new Guid(DV_ID);
                        }
                        item.Gia = Convert.ToDouble(Gia);
                        item.GiaNY = Convert.ToDouble(GiaNY);
                        if (!string.IsNullOrEmpty(HanDoiThe))
                        {
                            item.HanDoiThe = Convert.ToDateTime(HanDoiThe, new CultureInfo("vi-Vn"));
                        }
                        if (!string.IsNullOrEmpty(HanSuDung))
                        {
                            item.HanSuDung = Convert.ToDateTime(HanSuDung, new CultureInfo("vi-Vn"));
                        }
                        if (!string.IsNullOrEmpty(KH_ID))
                        {
                            item.KH_ID = new Guid(KH_ID);
                        }
                        if (!string.IsNullOrEmpty(KM_ID))
                        {
                            item.KM_ID = new Guid(KM_ID);
                        }
                        item.Ma = Ma;
                        if (!string.IsNullOrEmpty(NgayNhan))
                        {
                            item.NgayNhan = Convert.ToDateTime(NgayNhan, new CultureInfo("vi-Vn"));
                        }
                        if (!string.IsNullOrEmpty(NgayPhatHanh))
                        {
                            item.NgayPhatHanh = Convert.ToDateTime(NgayPhatHanh, new CultureInfo("vi-Vn"));
                        }
                        item.NgayCapNhat = DateTime.Now;
                        item.NguoiCapNhat = Security.Username;
                        item.NguoiNhan = NguoiNhan;
                        item.TinhTrang = Convert.ToBoolean(TinhTrang);
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = TheKhuyenMaiDal.Update(item);
                        }
                        else
                        {
                            item.ID = Guid.NewGuid();
                            item.NgayTao = DateTime.Now;
                            item.NguoiTao = Security.Username;
                            item = TheKhuyenMaiDal.Insert(item);
                        }
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(TheKhuyenMaiDal.SelectById(new Guid(ID))));

                    }
                    break;
                    #endregion
                case "del":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        TheKhuyenMaiDal.DeleteById(new Guid(ID));

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
                    var pagerSearch = TheKhuyenMaiDal.pagerNormal("", false, "a.KH_Ten", _q, 20);
                    sb.Append(JavaScriptConvert.SerializeObject(pagerSearch.List));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.theKhuyenMaiMgr.quanLyThe.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region default
                    {
                        var ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                        sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "quanLyThe.mdl.htm"));
                        sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                            , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.theKhuyenMaiMgr.quanLyThe.JScript1.js")
                            , "{quanLyTheFn.loadgrid();}");
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
