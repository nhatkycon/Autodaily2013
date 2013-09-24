using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using pmSpa.entities;

[assembly: WebResource("appStore.pmSpa.danhMucDichVuMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.danhMucDichVuMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.pmSpa.danhMucDichVuMgr
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số
            var ID = Request["ID"];
            var DM_ID = Request["DM_ID"];
            var Ten = Request["Ten"];
            var Ma = Request["Ma"];
            var MoTa = Request["MoTa"];
            var GhiChu = Request["GhiChu"];
            var NoiDung = Request["NoiDung"];
            var ThaoTac = Request["ThaoTac"];
            var Anh = Request["Anh"];
            var Gia = Request["Gia"];
            var ThoiGian = Request["ThoiGian"];
            var Active = Request["Active"];
            var KhuyenMai = Request["KhuyenMai"];
            var SoLan = Request["SoLan"];

            var DV_ID = Request["DV_ID"];
            var SoLuong = Request["SoLuong"];
            var ThuTu = Request["ThuTu"];
            var HH_ID = Request["HH_ID"];

            string q = Request["q"];
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    var pg = DichVuDal.ByDmIdUser(string.Empty, false, jgrsidx + " " + jgrsord, q, DM_ID, Security.Username, Convert.ToInt32(jgRows));

                    var listRow = pg.List.Select(item => new jgridRow(item.ID.ToString(), new string[]
                                                                                                               {
                                                                                                                   item.ID.ToString(),item.DM_Ten, item.Ma, item.Ten, item.MoTa,  item.Gia.ToString("###,###,###"), item.Active.ToString()
                                                                                                               })).ToList();
                    var grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "0", "0", listRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "autoCompleteByQ":
                    #region lấy dữ liệu cho autoCompleteByQ
                    var pgautoCompleteByQ = DichVuDal.ByDmIdUser(string.Empty, false, "DV_NgayTao desc", q, string.Empty, Security.Username, 100);
                    sb.Append(JavaScriptConvert.SerializeObject(pgautoCompleteByQ.List));
                    break;
                    #endregion
                case "getSub":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    var listSub = DichVuChiTietDal.SelectByDvId(DV_ID);

                    var listRowSub = listSub.Select(item => new jgridRow(item.ID.ToString(), new string[]
                                                                                                               {
                                                                                                                   item.ID.ToString(), 
                                                                                                                   item.ThuTu.ToString(),  
                                                                                                                   item.HH_Ten, 
                                                                                                                   item.Gia.ToString("###,###,###"), 
                                                                                                                   item.SoLuong.ToString(), 
                                                                                                                   item.Tong.ToString("###,###,###"), 
                                                                                                                   item.NgayTao.ToString("dd:mm:yyyy")
                                                                                                               })).ToList();
                    var gridSub = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "0", "0", listRowSub);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSub));
                    break;
                    #endregion
                case "save":
                    #region lưu
                    var itemSave = new DichVu();
                    if (!string.IsNullOrEmpty(ID))
                    {
                        itemSave = DichVuDal.SelectById(new Guid(ID));
                    }
                    else
                    {
                        itemSave.ID = Guid.NewGuid();
                    }
                    if (string.IsNullOrEmpty(Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    itemSave.Active = Convert.ToBoolean(Active);
                    itemSave.Anh = Anh;
                    if (!string.IsNullOrEmpty(DM_ID))
                    {
                        itemSave.DM_ID = new Guid(DM_ID);
                    }
                    itemSave.SoLan = Convert.ToInt32(SoLan);
                    itemSave.Gia = Convert.ToInt32(Gia);
                    itemSave.KhuyenMai = Convert.ToBoolean(KhuyenMai);
                    itemSave.Ma = Ma;
                    itemSave.MoTa = MoTa;
                    itemSave.NgayCapNhat = DateTime.Now;
                    itemSave.NguoiCapNhat = Security.Username;
                    itemSave.NoiDung = NoiDung;
                    itemSave.Ten = Ten;
                    itemSave.ThaoTac = ThaoTac;
                    itemSave.GhiChu = GhiChu;
                    itemSave.ThoiGian = Convert.ToInt32(ThoiGian);
                    if (!string.IsNullOrEmpty(ID))
                    {
                        itemSave = DichVuDal.Update(itemSave);
                    }
                    else
                    {
                        itemSave.NgayTao = DateTime.Now;
                        itemSave.NguoiTao = Security.Username;
                        itemSave.NgayTao = DateTime.Now;
                        itemSave.NguoiCapNhat = Security.Username;
                        itemSave = DichVuDal.Insert(itemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(DichVuDal.SelectById(new Guid(ID))));
                    }
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        DichVuDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "saveSub":
                    #region lưu
                    var itemSub = new DichVuChiTiet();
                    if (!string.IsNullOrEmpty(ID))
                    {
                        itemSub = DichVuChiTietDal.SelectById(new Guid(ID));
                    }
                    else
                    {
                        itemSub.ID = Guid.NewGuid();
                    }
                    if (!string.IsNullOrEmpty(HH_ID))
                    {
                        itemSub.HH_ID = new Guid(HH_ID);
                    }
                    if (!string.IsNullOrEmpty(DV_ID))
                    {
                        itemSub.DV_ID = new Guid(DV_ID);
                    }
                    itemSub.SoLuong = Convert.ToInt32(SoLuong);
                    itemSub.Gia = Convert.ToDouble(Gia);
                    itemSub.NgayCapNhat = DateTime.Now;
                    itemSub.NguoiCapNhat = Security.Username;
                    itemSub.ThuTu = Convert.ToInt32(ThuTu);
                    if (!string.IsNullOrEmpty(ID))
                    {
                        itemSub = DichVuChiTietDal.Update(itemSub);
                    }
                    else
                    {
                        itemSub.NgayTao = DateTime.Now;
                        itemSub.NguoiTao = Security.Username;
                        itemSub.NgayTao = DateTime.Now;
                        itemSub.NguoiCapNhat = Security.Username;
                        itemSub = DichVuChiTietDal.Insert(itemSub);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "editSub":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(DichVuChiTietDal.SelectById(new Guid(ID))));
                    }
                    break;
                    #endregion
                case "delSub":
                    #region xóa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        DichVuChiTietDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.danhMucDichVuMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.danhMucDichVuMgr.JScript1.js")
                        , "{danhMucDichVuMgr.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
