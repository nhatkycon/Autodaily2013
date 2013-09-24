using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web;
using linh.json;
using linh.common;
using docsoft;
using docsoft.entities;

[assembly: WebResource("cangtin.plugins.nhomMgr.Admin.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cangtin.plugins.nhomMgr.Admin.htm.htm", "text/html")]
[assembly: WebResource("cangtin.plugins.nhomMgr.Admin.thanhVien.htm", "text/html")]
namespace cangtin.plugins.nhomMgr.Admin
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến

            var context = HttpContext.Current;
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            var _ID = Request["ID"];
            string _q = Request["q"];

            var ID = context.Request["ID"];
            var PID_ID = context.Request["PID_ID"];
            var Ten = context.Request["Ten"];
            var MoTa = context.Request["MoTa"];
            var GioiThieu = context.Request["GioiThieu"];
            var Anh = context.Request["Anh"];
            var NgayTao = context.Request["NgayTao"];
            var NguoiTao = context.Request["NguoiTao"];
            var Home = context.Request["Home"];
            var Hot = context.Request["Hot"];
            var ThuTu = context.Request["ThuTu"];
            var DM_ID = context.Request["DM_ID"];


            var NHOM_ID = context.Request["NHOM_ID"];
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
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "NHOM_NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    var pg = NhomDal.pagerNormal(string.Empty, false, jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows));

                    ListRow=new List<jgridRow>();
                    foreach (var item in pg.List)
                    {
                        ListRow.Add(new jgridRow(
                            item.ID.ToString(), new string[]
                                                    {
                                                        item.ID.ToString(),
                                                        item.Home.ToString(),
                                                        item.Hot.ToString(),
                                                        item.DM_Ten,
                                                        item.PID_Ten,
                                                        item.Ten,
                                                        item.NguoiTao,
                                                        item.NgayTao.ToString("dd-MM-yy HH:mm")
                                                    }
                            ));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pg.Total.ToString(), pg.TotalPages.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getThanhVien":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "NTV_NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    var pgThanhVien = NhomThanhVienDal.pagerNormal(string.Empty, false, jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), PID_ID);

                    ListRow = new List<jgridRow>();
                    foreach (var item in pgThanhVien.List)
                    {
                        ListRow.Add(new jgridRow(
                            item.ID.ToString(), new string[]
                                                    {
                                                        item.ID.ToString(),
                                                        item.Duyet.ToString(),
                                                        item.Admin.ToString(),
                                                        item.Vip.ToString(),
                                                        item.Mod.ToString(),
                                                        item.Ten,
                                                        item.Username,
                                                        item.Mobile,
                                                        item.NgayTao.ToString("dd-MM-yy HH:mm")
                                                    }
                            ));
                    }
                    jgrid grid1 = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pgThanhVien.TotalPages.ToString(), pgThanhVien.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid1));
                    break;
                    #endregion
                case "autoComplete":
                    #region lấy danh sách
                    var pgAutoComplete = NhomDal.pagerNormal(string.Empty, false, "NHOM_NgayTao desc", _q, 50);
                    sb.Append(JavaScriptConvert.SerializeObject(pgAutoComplete.List));
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(NhomDal.SelectById(new Guid(ID))));
                    }
                    break;
                    #endregion
                case "editThanhVien":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(NhomThanhVienDal.SelectById(new Guid(ID))));
                    }
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        NhomDal.DeleteMultiById(ID);
                    }
                    break;
                    #endregion                                
                case "delThanhVien":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        NhomThanhVienDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion                                
                case "save":
                    #region lưu

                    var Item = string.IsNullOrEmpty(ID) ? new Nhom() : NhomDal.SelectById(new Guid(ID));
                    Item.Anh = Anh;
                    if(!string.IsNullOrEmpty(DM_ID))
                    {
                        Item.DM_ID = new Guid(DM_ID);
                    }
                    Item.GioiThieu = GioiThieu;
                    Item.Home = Convert.ToBoolean(Home);
                    Item.Hot = Convert.ToBoolean(Hot);
                    Item.MoTa = MoTa;
                    Item.Ten = Ten;
                    Item.ThuTu = Convert.ToInt32(ThuTu);
                    if(!string.IsNullOrEmpty(ID))
                    {
                        Item = NhomDal.Update(Item);
                    }
                    else
                    {
                        Item.ID = Guid.NewGuid();
                        Item.NgayTao = DateTime.Now;
                        Item.NguoiTao = Security.Username;
                        Item = NhomDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "saveThanhVien":
                    #region lưu

                    var ItemTv = string.IsNullOrEmpty(ID) ? new NhomThanhVien() : NhomThanhVienDal.SelectById(new Guid(ID));
                    ItemTv.Username = Username;
                    if (!string.IsNullOrEmpty(NHOM_ID))
                    {
                        ItemTv.NHOM_ID = new Guid(NHOM_ID);
                    }
                    ItemTv.Admin = Convert.ToBoolean(Admin);
                    ItemTv.Vip = Convert.ToBoolean(Vip);
                    ItemTv.Mod = Convert.ToBoolean(Mod);
                    ItemTv.Duyet = Convert.ToBoolean(Duyet);
                    if (!string.IsNullOrEmpty(ID))
                    {
                        ItemTv = NhomThanhVienDal.Update(ItemTv);
                    }
                    else
                    {
                        ItemTv.ID = Guid.NewGuid();
                        ItemTv.NgayTao = DateTime.Now;
                        ItemTv.NguoiTao = Security.Username;
                        ItemTv = NhomThanhVienDal.Insert(ItemTv);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cangtin.plugins.nhomMgr.Admin.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "Admin.mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cangtin.plugins.nhomMgr.Admin.JScript1.js")
                        , "{nhomMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
