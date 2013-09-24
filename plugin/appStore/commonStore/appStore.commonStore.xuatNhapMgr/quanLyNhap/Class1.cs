using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Reporting.WebForms;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using System.IO;
using pmSpa.entities;

[assembly: WebResource("appStore.commonStore.xuatNhapMgr.quanLyNhap.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.xuatNhapMgr.quanLyNhap.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.xuatNhapMgr.quanLyNhap
{
    
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số
            var ID = Request["ID"];


            var XN_ID = Request["XN_ID"];
            var HH_ID = Request["HH_ID"];
            var DV_ID = Request["DV_ID"];
            var SoLuong = Request["SoLuong"];
            var DonGia = Request["DonGia"];
            var Tong = Request["Tong"];
            var LoaiQuy = Request["LoaiQuy"];
            var VAT = Request["VAT"];
            var CKTyLe = Request["CKTyLe"];
            var CKTien = Request["CKTien"];
            var NgayTao = Request["NgayTao"];
            var NguoiTao = Request["NguoiTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var GhiChu = Request["GhiChu"];

            var GH_ID = Request["GH_ID"];
            var LOAI_ID = Request["LOAI_ID"];
            var Ma = Request["Ma"];
            var KH_ID = Request["KH_ID"];
            var NgayHoaDon = Request["NgayHoaDon"];
            var NhanVien = Request["NhanVien"];
            var CongTienHang = Request["CongTienHang"];
            var DienGiai = Request["DienGiai"];
            var ThanhToan = Request["ThanhToan"];
            var ConNo = Request["ConNo"];
            var ChietKhau = Request["ChietKhau"];
            var KHO_ID = Request["KHO_ID"];
            var _q = Request["q"];
            var draff = Request["draff"];
            var Loai = Request["Loai"];
            var Rep_Ten = Request["Rep_Ten"];
            var Rep_Ngay = Request["Rep_Ngay"];
            List<jgridRow> ListRow = new List<jgridRow>();

            var danhMucLoaiXuatNhap = DanhMucDal.SelectByMa("LXN-N");
            var isXuat = false;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid

                    var pagerGet = XuatNhapDal.pagerXuatNhap(false.ToString(), false.ToString(), false.ToString(),
                        false.ToString(), null,
                        jgrsidx + " " + jgrsord, _q,
                                                             Convert.ToInt32(jgRows));
                    string prefixMas = danhMucLoaiXuatNhap.KyHieu;
                    foreach (var item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LOAI_Ten
                            , prefixMas + item.Ma
                            , item.KH_Ten
                            , item.NgayHoaDon.ToString("dd-MM-yyyy")
                            , Lib.TienVietNam(item.CongTienHang)
                            , Lib.TienVietNam(item.VAT)
                            , Lib.TienVietNam(item.ChietKhau)
                            , Lib.TienVietNam(item.CongTienHang + item.VAT - item.ChietKhau)
                            , Lib.TienVietNam(item.ThanhToan)
                            , Lib.TienVietNam(item.ConNo)
                            , string.Format("{0:dd/MM/yy}",item.NgayCapNhat)
                        }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , pagerGet.TotalPages.ToString()
                        , pagerGet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        XuatNhapDal.DeleteById(new Guid(ID));
                        XuatNhapChiTietDal.DeleteByXnId(new Guid(ID));
                        var thuChi = ThuChiDal.SelectByXnId(ID);
                        ThuChiDal.DeleteById(thuChi.ID);
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var item = XuatNhapDal.SelectById(new Guid(ID));
                        string prefixMa = danhMucLoaiXuatNhap.KyHieu;
                        item.Ma = prefixMa + item.Ma;
                        item._ThuChi = ThuChiDal.SelectByXnId(item.ID.ToString());
                        item.XNCT = XuatNhapChiTietDal.SelectByXN_ID(item.ID.ToString());
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "draff":
                    #region draff
                    if (Security.IsAuthenticated())
                    {
                        var item = XuatNhapDal.SelectByDraff(isXuat);
                        string prefixMa = danhMucLoaiXuatNhap.KyHieu;
                        item.Ma = prefixMa + item.Ma;
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "autoCompleteByQ":
                    #region lấy dữ liệu cho grid
                    //var pagerByQ = HangHoaDal.ByDm("", false, string.Empty, _q, 10, string.Empty);
                    //sb.Append(JavaScriptConvert.SerializeObject(pagerByQ.List));
                    break;
                    #endregion
                case "save":
                    #region save
                    if (Security.IsAuthenticated())
                    {
                        var item = draff == "1" ? new XuatNhap() : XuatNhapDal.SelectById(new Guid(ID));
                        item.DauKy = false;
                        item.ChietKhau = Convert.ToDouble(ChietKhau);
                        item.CongTienHang = Convert.ToDouble(CongTienHang);
                        item.ConNo = Convert.ToDouble(ConNo);
                        item.GhiChu = GhiChu;
                        item.KH_ID = new Guid(KH_ID);
                        item.LOAI_ID = danhMucLoaiXuatNhap.ID;
                        item.Xuat = isXuat;
                        var prefixMa = danhMucLoaiXuatNhap.KyHieu;
                        Ma = Ma.Replace(prefixMa, "");
                        item.Ma = Ma;

                        if (!string.IsNullOrEmpty(KHO_ID))
                        {
                            item.KHO_ID = new Guid(KHO_ID);
                        }
                        item.NgayCapNhat = DateTime.Now;
                        item.NgayHoaDon = Convert.ToDateTime(NgayHoaDon, new CultureInfo("vi-Vn"));
                        item.NguoiCapNhat = Security.Username;
                        item.NhanVien = NhanVien;
                        item.ThanhToan = Convert.ToDouble(ThanhToan);
                        item.VAT = Convert.ToDouble(VAT);
                        item.ID = new Guid(ID);
                        if (draff == "1")
                        {
                            item.NgayTao = DateTime.Now;
                            item.NguoiTao = Security.Username;
                            item = XuatNhapDal.Insert(item);
                        }
                        else
                        {
                            item = XuatNhapDal.Update(item);
                        }
                        // TODO: Tiếp tục phần thu chi                      
                        var thuChi = ThuChiDal.SelectByXnId(ID);
                        thuChi.LoaiQuy = Convert.ToInt32(LoaiQuy);
                        thuChi.NgayTao = Convert.ToDateTime(NgayHoaDon, new CultureInfo("vi-Vn"));
                        thuChi.P_ID = item.KH_ID;
                        thuChi.SoTien = item.ThanhToan;
                        if (thuChi.ID == Guid.Empty)
                        {
                            var ndtcItem = DanhMucDal.SelectByMa("NDTC-CHI-TIENHANG");
                            thuChi = ThuChiDal.SelectByDraff(false);
                            thuChi.Mota = string.Format("{0}: {1}", ndtcItem.Ten, item.Ma);
                            thuChi.NDTC_ID = ndtcItem.ID;
                            thuChi.Thu = false;
                            thuChi.XN_ID = item.ID;
                            thuChi.NguoiTao = Security.Username;
                            thuChi.NguoiSua = Security.Username;
                            thuChi.NgaySua = DateTime.Now;
                            thuChi.isCandoi = false;
                            ThuChiDal.Insert(thuChi);
                        }
                        else
                        {
                            thuChi.NguoiSua = Security.Username;
                            thuChi.NgaySua = DateTime.Now;
                            ThuChiDal.Update(thuChi);
                        }
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "SaveXNChiTiet":
                    #region SaveXNChiTiet
                    if (Security.IsAuthenticated())
                    {
                        var item = XuatNhapChiTietDal.SelectById(new Guid(ID));
                        item.CKTien = Convert.ToDouble(CKTien);
                        item.CKTyLe = Convert.ToDouble(CKTyLe);
                        item.DonGia = Convert.ToDouble(DonGia);
                        item.DV_ID = new Guid(DV_ID);
                        item.GhiChu = GhiChu;
                        item.NgayCapNhat = DateTime.Now;
                        item.NguoiCapNhat = Security.Username;
                        item.SoLuong = Convert.ToDouble(SoLuong);
                        item.Tong = Convert.ToDouble(Tong);
                        item.VAT = Convert.ToDouble(VAT);
                        if(!string.IsNullOrEmpty(KH_ID))
                        {
                            item.KH_ID = new Guid(KH_ID);
                        }
                        item = XuatNhapChiTietDal.Update(item);                        
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "XoaXNChiTiet":
                    #region Xóa tài liệu đính kèm
                    if (!string.IsNullOrEmpty(ID))
                    {
                        XuatNhapChiTietDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "ThemXNChiTiet":
                    #region Them xuat nhap chi tiet
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var itemHH = docsoft.entities.HangHoaDal.SelectById(new Guid(HH_ID));
                        var itemXNCT = new XuatNhapChiTiet();
                        itemXNCT.CKTien = 0;
                        itemXNCT.CKTyLe = 0;
                        itemXNCT.DonGia = itemHH.GiaNhap;
                        itemXNCT.DV_ID = itemHH.DonVi_ID;
                        itemXNCT.HH_ID = itemHH.ID;
                        itemXNCT.ID = Guid.NewGuid();
                        itemXNCT.NgayCapNhat = DateTime.Now;
                        itemXNCT.NgayTao = DateTime.Now;
                        itemXNCT.NguoiCapNhat = Security.Username;
                        itemXNCT.NguoiTao = Security.Username;
                        itemXNCT.SoLuong = 1;
                        itemXNCT.Tong = itemXNCT.SoLuong * itemXNCT.DonGia;
                        itemXNCT.VAT = Convert.ToDouble(VAT);
                        itemXNCT.XN_ID = new Guid(ID);
                        itemXNCT.Draff = true;
                        itemXNCT.DraffDate = DateTime.Now;
                        itemXNCT = XuatNhapChiTietDal.Insert(itemXNCT);
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemXNCT));
                    }
                    break;
                    #endregion
                case "reports":
                    #region bao cao
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var item = XuatNhapDal.SelectById(new Guid(ID));
                        string prefixMa = danhMucLoaiXuatNhap.KyHieu;
                        item.Ma = prefixMa + item.Ma;
                        item.XNCT = XuatNhapChiTietDal.SelectByXN_ID(item.ID.ToString());
                        var itemIn = Lib.GetResource(Assembly.GetExecutingAssembly(), "quanLyNhap.in.htm");
                        var itemInRow = Lib.GetResource(Assembly.GetExecutingAssembly(), "quanLyNhap.in-row.htm");
                        var danhMucReportHeader = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI");

                        var sbRow = new StringBuilder();
                        var stt = 0;
                        foreach (var xnct in item.XNCT)
                        {
                            stt++;
                            sbRow.AppendFormat(itemInRow
                                , stt
                                , xnct.HH_Ten
                                , xnct.HH_Ma
                                , xnct.DV_Ten
                                , Lib.TienVietNam(xnct.DonGia)
                                , xnct.SoLuong
                                , Lib.TienVietNam(xnct.CKTien)
                                , Lib.TienVietNam(xnct.VAT)
                                , Lib.TienVietNam(xnct.Tong));
                        }

                        sb.AppendFormat(itemIn
                            , string.Format("Ng&agrave;y {4}{0} th&aacute;ng {3}{1} năm {2}", item.NgayTao.Day, item.NgayTao.Month, item.NgayTao.Year, item.NgayTao.Month < 10 ? "0" : "", item.NgayTao.Day < 10 ? "0" : "")
                            , item.Ma
                            , item.KH_Ten
                            , item.GhiChu
                            , item.KHO_Ten
                            , Lib.TienVietNam(item.CongTienHang)
                            , Lib.TienVietNam(item.VAT)
                            , Lib.TienVietNam(item.ChietKhau)
                            , Lib.TienVietNam(item.CongTienHang - item.VAT - item.ChietKhau)
                            , Lib.TienVietNam(item.ThanhToan)
                            , Lib.TienVietNam(item.ConNo)
                            , danhMucReportHeader.Description
                            , domain
                            , sbRow
                            , Lib.So_chu(item.CongTienHang)
                            , item.NhanVien
                            );
                    }
                    
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.xuatNhapMgr.quanLyNhap.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.xuatNhapMgr.quanLyNhap.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "quanLyNhap.mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.xuatNhapMgr.quanLyNhap.JScript1.js")
                        , "{quanLyNhapFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}


