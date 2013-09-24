using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.frm;
using linh.common;
using System.Reflection;
using linh.json;
using pmSpa.entities;
using System.Globalization;
using Microsoft.Reporting.WebForms;
using docbao.entitites;
using DanhMucDal = docsoft.entities.DanhMucDal;
using HangHoaDal = docsoft.entities.HangHoaDal;

[assembly: WebResource("appStore.pmSpa.desktop.controls.TuVanView.TuVan.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.TuVanView.html.htm", "text/html", PerformSubstitution = true)]
namespace appStore.pmSpa.desktop.controls.TuVanView
{
    public class DanhSach : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con(), this.Page);
            writer.Write(Html);
            base.Render(writer);
        }

        public override void KhoiTao(SqlConnection con, Page page)
        {
            var sb = new StringBuilder();
            var cs = page.ClientScript;
            var c = HttpContext.Current;
            var _id = c.Request["VID"];

            #region bien
            var ID = c.Request["ID"];
            var TV_ID = c.Request["TV_ID"];
            var DV_ID = c.Request["DV_ID"];
            var NgayTao = c.Request["NgayTao"];
            var NguoiTao = c.Request["NguoiTao"];
            var Gia = c.Request["Gia"];
            var GhiChu = c.Request["GhiChu"];
            var SoLan = c.Request["SoLan"];
            var ThanhToan = c.Request["ThanhToan"];
            var ConNo = c.Request["ConNo"];
            var NgayLap = c.Request["NgayLap"];
            var BaoHanh_ID = c.Request["BaoHanh_ID"];
            var Xoa = c.Request["Xoa"];
            var NgayLam = c.Request["NgayLam"];
            var ThuTu = c.Request["ThuTu"];
            var TVDV_ID = c.Request["TVDV_ID"];
            var KHO_ID = c.Request["KHO_ID"];
            var CKTyLe = Request["CKTyLe"];
            var CKTien = Request["CKTien"];
            var HH_ID = Request["HH_ID"];
            var SoLuong = Request["SoLuong"];
            var DonGia = Request["DonGia"];
            var Tong = Request["Tong"];
            var VAT = Request["VAT"];
            var XN_ID = Request["XN_ID"];
            var KH_ID = Request["KH_ID"];
            var CK = Request["CK"];
            var NhanVien = Request["NhanVien"];
            var LoaiQuy = Request["LoaiQuy"];
            #endregion

            switch (subAct)
            {
                case "get":
                    #region Nạp js
                    break;
                    #endregion
                case "draff":
                    #region Nạp draff
                    if (Security.IsAuthenticated())
                    {
                        var tuVanDichVuItem = TuVanDichVuDal.SelectById(con, new Guid(TVDV_ID));
                        var tieuHaoList = DichVuChiTietDal.SelectByDvId(con, tuVanDichVuItem.DV_ID.ToString());
                        var item = XuatNhapDal.SelectByDraff(true);
                        foreach (var tieuHao in tieuHaoList)
                        {
                            var itemHH = HangHoaDal.SelectById(tieuHao.HH_ID);

                            XuatNhapChiTietDal.Insert(new XuatNhapChiTiet()
                                                          {
                                                              CKTien = 0
                                                              , CKTyLe = 0
                                                              , DonGia = tieuHao.Gia
                                                              , Draff = true
                                                              , DraffDate = DateTime.Now
                                                              , DV_ID = itemHH.DonVi_ID
                                                              , GhiChu = "Xuất kho tiêu hao làm dịch vụ"
                                                              , HH_ID = tieuHao.HH_ID
                                                              , NgayCapNhat = DateTime.Now
                                                              , NgayTao = DateTime.Now
                                                              , NguoiTao = Security.Username
                                                              , SoLuong = tieuHao.SoLuong
                                                              , VAT = 0
                                                              , Tong = tieuHao.Gia * tieuHao.SoLuong
                                                              , XN_ID = item.ID
                                                              , ID = Guid.NewGuid()
                                                          });
                        }
                        var danhMucLoaiXuatNhap = DanhMucDal.SelectByMa("LXN-X");
                        string prefixMa = danhMucLoaiXuatNhap.KyHieu;
                        item.Ma = prefixMa + item.Ma;
                        item.XNCT = XuatNhapChiTietDal.SelectByXN_ID(item.ID.ToString());
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "saveTuVanDichVu":
                    #region Save TuVanDichVu
                    if (!string.IsNullOrEmpty(DV_ID))
                    {
                        // Phiếu tư vấn dịch vụ
                        var item = new TuVanDichVu();
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = TuVanDichVuDal.SelectById(new Guid(ID));   
                        }
                        if (!string.IsNullOrEmpty(DV_ID))
                        {
                            item.DV_ID = new Guid(DV_ID);
                        }
                        if (!string.IsNullOrEmpty(TV_ID))
                        {
                            item.TV_ID = new Guid(TV_ID);
                        }
                        if (!string.IsNullOrEmpty(BaoHanh_ID))
                        {
                            item.BaoHanh_ID = new Guid(BaoHanh_ID);
                        }
                        if (!string.IsNullOrEmpty(TV_ID))
                        {
                            item.TV_ID = new Guid(TV_ID);
                        }
                        if (!string.IsNullOrEmpty(KHO_ID))
                        {
                            item.KHO_ID = new Guid(KHO_ID);
                        }
                        if (!string.IsNullOrEmpty(SoLan))
                        {
                            item.SoLan = Convert.ToInt32(SoLan);
                        }
                        item.NhanVien = NhanVien;
                        item.CK = Convert.ToDouble(CK);
                        item.GhiChu = GhiChu;
                        item.Gia = Convert.ToDouble(Gia);
                        item.ConNo = Convert.ToDouble(ConNo);
                        item.ThanhToan = Convert.ToDouble(ThanhToan);
                        if(!string.IsNullOrEmpty(NgayLap))
                        {
                            item.NgayLap = Convert.ToDateTime(NgayLap, new CultureInfo("vi-Vn"));
                        }
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item =TuVanDichVuDal.Update(item);
                        }
                        else
                        {
                            item.ID = Guid.NewGuid();
                            item.NgayTao = DateTime.Now;
                            item.NguoiTao = Security.Username;
                            item = TuVanDichVuDal.Insert(item);
                        }
                        // Thu chi
                        var thuChi = ThuChiDal.SelectByDvId(item.ID.ToString());
                        thuChi.LoaiQuy = Convert.ToInt32(LoaiQuy);
                        thuChi.SoTien = item.ThanhToan;
                        thuChi.NgayTao = Convert.ToDateTime(NgayLap, new CultureInfo("vi-Vn"));
                        if (thuChi.ID == Guid.Empty)
                        {
                            var ndtcItem = DanhMucDal.SelectByMa("NDTC-THU-KHANGTRA-DVU");
                            thuChi = ThuChiDal.SelectByDraff(true);
                            thuChi.LoaiCandoi = 0;
                            thuChi.Mota = string.Format("{0}: {1}", ndtcItem.Ten, item._DichVu.Ten);
                            thuChi.NDTC_ID = ndtcItem.ID;
                            thuChi.Thu = true;
                            thuChi.DV_ID = item.ID;
                            thuChi.NguoiTao = Security.Username;
                            thuChi.NguoiSua = Security.Username;
                            thuChi.NgaySua = DateTime.Now;
                            thuChi.P_ID = item._TuVan.KH_ID;
                            thuChi.isCandoi = false;
                            thuChi.SoTien = item.ThanhToan;
                            ThuChiDal.Insert(thuChi);
                        }
                        else
                        {
                            thuChi.NguoiSua = Security.Username;
                            thuChi.NgaySua = DateTime.Now;
                            ThuChiDal.Update(thuChi);
                        }
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
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
                        if (!string.IsNullOrEmpty(KH_ID))
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
                    if (!string.IsNullOrEmpty(XN_ID))
                    {
                        var itemHH = docsoft.entities.HangHoaDal.SelectById(new Guid(HH_ID));
                        var itemXNCT = new XuatNhapChiTiet();
                        var tuVanItem = TuVanDal.SelectById(new Guid(TV_ID));
                        itemXNCT.CKTien = 0;
                        itemXNCT.CKTyLe = 0;
                        itemXNCT.DonGia = itemHH.GNY;
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
                        itemXNCT.XN_ID = new Guid(XN_ID);
                        itemXNCT.Draff = true;
                        itemXNCT.DraffDate = DateTime.Now;
                        itemXNCT = XuatNhapChiTietDal.Insert(itemXNCT);
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemXNCT));
                    }
                    break;
                    #endregion
                case "saveLamDichVu":
                    #region saveLamDichVu
                    if (!string.IsNullOrEmpty(TVDV_ID) || !string.IsNullOrEmpty(ID))
                    {
                        var item = new TuVanLamDichVu();
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = TuVanLamDichVuDal.SelectById(new Guid(ID));
                        }                        

                        if (!string.IsNullOrEmpty(TVDV_ID))
                        {
                            item.TVDV_ID = new Guid(TVDV_ID);
                            var itemDv = TuVanDichVuDal.SelectById(con, new Guid(TVDV_ID));
                            var itemTv = TuVanDal.SelectById(itemDv.TV_ID);
                            item.KH_ID = itemTv.KH_ID;
                        }

                        if (!string.IsNullOrEmpty(ThuTu))
                        {
                            item.ThuTu = Convert.ToInt32(ThuTu);
                        }
                        item.NhanVien = NhanVien;
                        if (!string.IsNullOrEmpty(NgayLam))
                        {
                            item.NgayLam = Convert.ToDateTime(NgayLam, new CultureInfo("vi-Vn"));
                        }
                        if (!string.IsNullOrEmpty(ID))
                        {
                            item = TuVanLamDichVuDal.Update(item);
                        }
                        else
                        {
                            item.ID = Guid.NewGuid();
                            item = TuVanLamDichVuDal.Insert(item);
                        }

                        var itemTvdv = TuVanDichVuDal.SelectById(item.TVDV_ID);
                        var khItem = KhachHangDal.SelectById(itemTvdv._TuVan.KH_ID);
                        // Phiếu Xuất nhập
                        var itemXn = XuatNhapDal.SelectTvDv(item.ID);
                        //itemXn.CongTienHang = itemTvdv.Gia;
                        //itemXn.ThanhToan = itemTvdv.ThanhToan;
                        //itemXn.ConNo = itemTvdv.Gia - itemTvdv.ThanhToan;
                        itemXn.Xuat = true;
                        itemXn.KH_ID = itemTvdv._TuVan.KH_ID;
                        itemXn.NgayCapNhat = DateTime.Now;
                        itemXn.NguoiCapNhat = Security.Username;
                        itemXn.DienGiai = string.Format("Xuất hàng kèm dịch vụ [{0}] cho khách hàng {1}, ", itemTvdv._DichVu.Ten, khItem.Ten);
                        itemXn.GhiChu = string.Format("Xuất hàng kèm dịch vụ [{0}] cho khách hàng {1}, ", itemTvdv._DichVu.Ten, khItem.Ten);
                        if (itemXn.ID == Guid.Empty)
                        {
                            var itemXn1 = XuatNhapDal.SelectByDraff(true);
                            itemXn1.ID = new Guid(XN_ID);
                            itemXn.Ma = itemXn1.Ma;
                            var danhMucLoaiXuatNhap = DanhMucDal.SelectByMa("LXN-X");
                            itemXn.LOAI_ID = danhMucLoaiXuatNhap.ID;
                            itemXn.ChietKhau = 0;
                            itemXn.NgayHoaDon = itemTvdv.NgayLap;
                            itemXn.NhanVien = Security.Username;
                            itemXn.VAT = 0;
                            itemXn.ID = Guid.NewGuid();
                            itemXn.KHO_ID = itemTvdv.KHO_ID;
                            itemXn.TVDV_ID = item.ID;
                            itemXn.NgayTao = DateTime.Now;
                            itemXn.NguoiTao = Security.Username;
                            itemXn.KH_ID = khItem.ID;
                            itemXn = XuatNhapDal.Insert(itemXn);
                        }
                        else
                        {
                            itemXn = XuatNhapDal.Update(itemXn);
                        }

                        // Xuất nhập chi tiết
                        // Xóa bỏ cũ
                        XuatNhapChiTietDal.DeleteByXnId(itemXn.ID);
                        // Thêm mới
                        foreach (var xnChiTiet in DichVuChiTietDal.SelectByDvId(con, itemTvdv.DV_ID.ToString()))
                        {
                            var itemXNCT = new XuatNhapChiTiet();
                            var hhItem = docsoft.entities.HangHoaDal.SelectById(xnChiTiet.HH_ID);
                            itemXNCT.CKTien = 0;
                            itemXNCT.CKTyLe = 0;
                            itemXNCT.DonGia = xnChiTiet.Gia;
                            itemXNCT.DV_ID = hhItem.DonVi_ID;
                            itemXNCT.HH_ID = xnChiTiet.HH_ID;
                            itemXNCT.ID = Guid.NewGuid();
                            itemXNCT.NgayCapNhat = DateTime.Now;
                            itemXNCT.NgayTao = itemXn.NgayTao;
                            itemXNCT.NguoiCapNhat = Security.Username;
                            itemXNCT.NguoiTao = Security.Username;
                            itemXNCT.SoLuong = xnChiTiet.SoLuong;
                            itemXNCT.Tong = itemXNCT.SoLuong * itemXNCT.DonGia;
                            itemXNCT.VAT = Convert.ToDouble(0);
                            itemXNCT.XN_ID = itemXn.ID;
                            itemXNCT.Draff = false;
                            itemXNCT.DraffDate = DateTime.Now;
                            itemXNCT = XuatNhapChiTietDal.Insert(itemXNCT);
                        }

                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "delTuVan":
                    #region delTuVan
                    if (Security.IsAuthenticated())
                    {
                        TuVanDichVuDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "delDichVu":
                    #region delDichVu
                    if (Security.IsAuthenticated())
                    {
                        TuVanDichVuDal.DeleteById(new Guid(ID));
                        var thuChi = ThuChiDal.SelectByDvId(ID);
                        ThuChiDal.DeleteById(thuChi.ID);
                    }
                    break;
                    #endregion
                case "delLamDichVu":
                    #region delDichVu
                    if (!string.IsNullOrEmpty(ID))
                    {
                        TuVanLamDichVuDal.DeleteById(new Guid(ID));
                        var xnItem = XuatNhapDal.SelectTvDv(new Guid(ID));
                        XuatNhapDal.DeleteById(xnItem.ID);
                        XuatNhapChiTietDal.DeleteByXnId(xnItem.ID);
                    }
                    break;
                    #endregion
                case "editTuVan":
                    #region edit
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(TuVanDichVuDal.SelectById(new Guid(ID))));
                    break;
                    #endregion
                case "editDichVu":
                    #region editDichVu
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(TuVanDichVuDal.SelectById(new Guid(ID))));
                    break;
                    #endregion
                case "editLamDichVu":
                    #region editLamDichVu
                    if(!string.IsNullOrEmpty(ID))
                    {
                        var itemLdv = TuVanLamDichVuDal.SelectById(new Guid(ID));
                        itemLdv._XuatNhap = XuatNhapDal.SelectTvDv(itemLdv.ID);
                        itemLdv._XuatNhap.XNCT = XuatNhapChiTietDal.SelectByXN_ID(itemLdv._XuatNhap.ID.ToString());
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemLdv));                        
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(DanhSach), "appStore.pmSpa.desktop.controls.TuVanView.TuVan.js"));
                    break;
                    #endregion                
                default:
                    #region nạp
                    
                    break;
                    #endregion
            }

            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }    
}
