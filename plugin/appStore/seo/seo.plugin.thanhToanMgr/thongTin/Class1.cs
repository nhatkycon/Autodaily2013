using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh;
using linh.frm;
using linh.json;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.common;
using seo.entities;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using System.Globalization;
[assembly: WebResource("seo.plugin.thanhToanMgr.thongTin.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("seo.plugin.thanhToanMgr.thongTin.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace seo.plugin.thanhToanMgr.thongTin
{
    public class Class1:docPlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        void sendmailThongbao(string email, string tieude, string noidung)
        {
            omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "potbai.com", "123$5678");
        }
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _SoDu = Request["SoDu"];
            string _Duyet = Request["Duyet"];
            string _DaChuyenTien = Request["DaChuyenTien"];
            string _MoTa = Request["MoTa"];
            string _q = Request["q"];
            List<jgridRow> ListRow = new List<jgridRow>();
            ThanhToan Item;
            TaiKhoan ItemTk;
            string Username = Security.Username;
            bool logged = Security.IsAuthenticated();
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<ThanhToan> PagerGet = ThanhToanDal.pagerByUser("T_" + jgrsidx + " " + jgrsord, Convert.ToInt32(jgRows), Username);
                    foreach (ThanhToan item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), 
                            new string[] { 
                            item.ID.ToString(),
                           item.SoDu.ToString("C",new CultureInfo("vi-Vn")),
                            item.NgayTao.ToString("hh:mm dd/MM/yy"),
                            string.Format(@"<input disabled=""disabled"" type=""checkbox"" {0}/> {1}",item.Duyet ? @" checked=""checked""" : @"class=""yctt-unchecked""",item.Duyet ? "" : string.Format(@"- <a href=""javascript:;"" onclick=""ThanhToanMgrthongTinFn.edit1('{0}')"">Sửa</a>",item.ID))
                            }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "saveSoDu":
                    #region lưu
                    if (!MemberDal.SelectChungThuc(Username))
                    {
                        _dele.BeginInvoke("danhbaspa@gmail.com"
                            , string.Format("potbai - Yeu cau chung thuc: {0} - {1}", Username, DateTime.Now.ToString("hh:mm-dd/MM/yy"))
                            , string.Format("Username:{0}<br/>So du:{1}<br/>Date:{2}<br/>IP:{3}", Username, _SoDu, DateTime.Now.ToString("hh:mm-dd/MM/yy"), Request.UserHostAddress)
                            , null, null);
                        sb.Append("-1");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_ID))
                        {
                            Item = ThanhToanDal.SelectById(Convert.ToInt32(_ID));
                        }
                        else
                        {
                            Item = new ThanhToan();
                        }
                        if (!string.IsNullOrEmpty(_Duyet))
                        {
                            Item.Duyet = Convert.ToBoolean(_Duyet);
                        }
                        if (!string.IsNullOrEmpty(_DaChuyenTien))
                        {
                            Item.DaChuyenTien = Convert.ToBoolean(_DaChuyenTien);
                        }
                        Item.SoDu = Convert.ToInt32(_SoDu);

                        if (!string.IsNullOrEmpty(_ID))
                        {
                            Item = ThanhToanDal.Update(Item);
                            _dele.BeginInvoke("danhbaspa@gmail.com"
                            , string.Format("potbai - Yeu cau thanh toan sua: {0} - {1}", Username, DateTime.Now.ToString("hh:mm-dd/MM/yy"))
                            , string.Format("ID:{4}<br/>Username:{0}<br/>SoDu:{1}<br/>Date:{2}<br/>IP:{3}", Username, Item.SoDu, DateTime.Now.ToString("hh:mm-dd/MM/yy"), Request.UserHostAddress, Item.ID)
                            , null, null);
                        }
                        else
                        {
                            Item.NguoiYeuCau = Security.Username;
                            Item.NgayTao = DateTime.Now;
                            Item = ThanhToanDal.Insert(Item);
                            _dele.BeginInvoke("danhbaspa@gmail.com"
                            , string.Format("potbai - Yeu cau thanh toan moi: {0} - {1}", Username, DateTime.Now.ToString("hh:mm-dd/MM/yy"))
                            , string.Format("ID:{4}<br/>Username:{0}<br/>SoDu:{1}<br/>Date:{2}<br/>IP:{3}", Username, Item.SoDu, DateTime.Now.ToString("hh:mm-dd/MM/yy"), Request.UserHostAddress,Item.ID)
                            , null, null);
                        }
                        sb.Append("1");
                    }
                    break;
                    #endregion                
                case "saveTaiKhoan":
                    #region lưu
                    TaiKhoanDal.UpdateThongTinByUser(new TaiKhoan()
                                                         {
                                                             Username = Username,
                                                             ThongTin = _MoTa
                                                         });
                    sb.Append("1");
                    break;
                    #endregion                
                case "editSoDu":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = ThanhToanDal.SelectById(Convert.ToInt32(_ID));
                        if (!Item.Duyet)
                        {
                            sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(Item));
                        }
                        else
                        {
                            sb.Append("0");
                        }
                    }
                    break;
                    #endregion
                case "editTaiKhoan":
                    #region chỉnh sửa
                    sb.Append(TaiKhoanDal.SelectByUsername(Security.Username, DAL.con()).ThongTin);
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = ThanhToanDal.SelectById(Convert.ToInt32(_ID));
                        if (!Item.Duyet)
                        {
                            LinkDal.DeleteById(Item.ID);
                        
                        }
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "seo.plugin.thanhToanMgr.thongTin.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    if (!logged)
                    {
                        renderText("un-authorized", "text/plain");
                    }
                    double total = 0;
                    TaiKhoan tkItem = TaiKhoanDal.SelectByUsername(Username, DAL.con());
                    if(!string.IsNullOrEmpty(tkItem.Tk))
                    {
                        total = Convert.ToDouble(maHoa.DecryptString(tkItem.Tk, Username));
                    }
                    sb.AppendFormat(@"
<div class=""mdl-head"">
    <a class=""mdl-head-btn mdl-head-del"" id=""ThanhToanMgrthongTin-tkBtn"" _value=""{1}"" href=""javascript:;"">Số dư: {0}</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""ThanhToanMgrthongTin-thanhToanBtn"" href=""javascript:;"" onclick=""ThanhToanMgrthongTinFn.add1();"">Yêu cầu thanh toán</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""ThanhToanMgrthongTin-thongTinBtn"" href=""javascript:;"" onclick=""ThanhToanMgrthongTinFn.edit2();"">Thông tin thanh toán</a>    
</div>
<table id=""ThanhToanMgrthongTin-List"" class=""mdl-list""></table>
<div id=""ThanhToanMgrthongTin-Pager""></div>
", total.ToString("C", new CultureInfo("vi-Vn")),total);
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "seo.plugin.thanhToanMgr.thongTin.JScript1.js")
                        , "{ThanhToanMgrthongTinFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn)); 
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
