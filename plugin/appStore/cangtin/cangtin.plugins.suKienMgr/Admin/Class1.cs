using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web;
using linh;
using linh.frm;
using linh.json;
using linh.common;
using linh.controls;
using docsoft;
using docsoft.entities;
using System.Xml;
using System.Globalization;
using System.IO;
[assembly: WebResource("cangtin.plugins.suKienMgr.Admin.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cangtin.plugins.suKienMgr.Admin.htm.htm", "text/html")]
[assembly: WebResource("cangtin.plugins.suKienMgr.Admin.thanhVien.htm", "text/html")]
namespace cangtin.plugins.suKienMgr.Admin
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            var context = HttpContext.Current;
            ClientScriptManager cs = this.Page.ClientScript;
            var _ID = Request["ID"];
            string _q = Request["q"];

            var ID = Request["ID"];
            var DM_ID = Request["DM_ID"];
            var Ten = Request["Ten"];
            var MoTa = Request["MoTa"];
            var NoiDung = Request["NoiDung"];
            var NgayBatDau = Request["NgayBatDau"];
            var GhiChu = Request["GhiChu"];
            var MienPhi = Request["MienPhi"];
            var LePhi = Request["LePhi"];
            var LuotXem = Request["LuotXem"];
            var DangKy = Request["DangKy"];
            var ThamGia = Request["ThamGia"];
            var NgayTao = Request["NgayTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiTao = Request["NguoiTao"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var Active = Request["Active"];
            var Anh = Request["Anh"];
            var DiaChi = Request["DiaChi"];
            var ToaDo = Request["ToaDo"];
            var HauTruong = Request["HauTruong"];
            var PID_ID = Request["PID_ID"];

            var SK_ID = context.Request["SK_ID"];
            var Username = context.Request["Username"];
            var Admin = context.Request["Admin"];
            var Duyet = context.Request["Duyet"];
            var Vip = context.Request["Vip"];
            var Mod = context.Request["Mod"];

            List<jgridRow> ListRow;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "SK_NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    var list = SuKienDal.SelectAll();

                    ListRow=new List<jgridRow>();
                    foreach (var item in list)
                    {
                        ListRow.Add(new jgridRow(
                            item.ID.ToString(), new string[]
                                                    {
                                                        item.ID.ToString(),
                                                        item.DM_Ten,
                                                        item.Ten,
                                                        item.NgayBatDau.ToString("dd-MM-yy"),
                                                        item.MienPhi ? "" : item.LePhi.ToString("###.###"),
                                                        item.LuotXem.ToString(),
                                                        item.DangKy.ToString(),
                                                        item.ThamGia.ToString(),
                                                        item.Active.ToString(),
                                                        item.NgayCapNhat.ToString("dd-MM-yy HH:mm")
                                                    }
                            ));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, list.Count.ToString(), list.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(SuKienDal.SelectById(new Guid(ID))));
                    }
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        SuKienDal.DeleteMultiById(ID);
                    }
                    break;
                    #endregion                                
                case "save":
                    #region lưu

                    var Item = string.IsNullOrEmpty(ID) ? new SuKien() : SuKienDal.SelectById(new Guid(ID));
                    Item.Active = Convert.ToBoolean(Active);
                    Item.Anh = Anh;
                    if(!string.IsNullOrEmpty(DM_ID))
                    {
                        Item.DM_ID = new Guid(DM_ID);
                    }
                    Item.GhiChu = GhiChu;
                    Item.LePhi = Convert.ToDouble(LePhi);
                    Item.MienPhi = Convert.ToBoolean(MienPhi);
                    Item.MoTa = MoTa;
                    Item.NgayBatDau = Convert.ToDateTime(NgayBatDau, new CultureInfo("vi-Vn"));
                    Item.NoiDung = NoiDung;
                    Item.Ten = Ten;
                    Item.NgayCapNhat = DateTime.Now;
                    Item.NguoiCapNhat = Security.Username;
                    Item.DiaChi = DiaChi;
                    Item.ToaDo = ToaDo;
                    Item.HauTruong = HauTruong;
                    if(!string.IsNullOrEmpty(ID))
                    {
                        Item = SuKienDal.Update(Item);
                    }
                    else
                    {
                        Item.ID = Guid.NewGuid();
                        Item.NgayTao = DateTime.Now;
                        Item.NguoiTao = Security.Username;
                        Item = SuKienDal.Insert(Item);

                        
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cangtin.plugins.suKienMgr.Admin.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "Admin.mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cangtin.plugins.suKienMgr.Admin.JScript1.js")
                        , "{suKienMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
