using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core;
using linh.core.dal;

namespace pmSpa.entities
{
    #region KhachHang
    #region BO
    public class KhachHang : BaseEntity, BaseObject
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ma { get; set; }
        public String Ten { get; set; }
        public String Ho { get; set; }
        public String XungHo { get; set; }
        public DateTime NgaySinh { get; set; }
        public Boolean GioiTinh { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public String Phone { get; set; }
        public String CMND { get; set; }
        public String Ym { get; set; }
        public String FacebookUid { get; set; }
        public Guid LinhVuc_ID { get; set; }
        public Guid NguonGoc_ID { get; set; }
        public Guid NguonGoc_ChiTiet_ID { get; set; }
        public String DiaChi { get; set; }
        public Guid KhuVuc_ID { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean NgungTheoDoi { get; set; }
        public Boolean NoiBat { get; set; }
        public Boolean ChiaSe { get; set; }
        public Int16 DanhGia { get; set; }
        public Boolean KhongNhanEmail { get; set; }
        public Boolean KhongDuocGoiDien { get; set; }
        public String ThoiGianGoiDien { get; set; }
        public Guid NguoiGioiThieu { get; set; }
        public String Anh { get; set; }
        public String TuVanVien { get; set; }
        #endregion
        #region Contructor
        public KhachHang()
        { }
        #endregion
        #region Customs properties
        public string KhuVuc_Ten { get; set; }
        public string NguonGoc_Ten { get; set; }
        public string NguonGoc_ChiTiet_Ten { get; set; }
        public string NguoiGioiThieu_Ten { get; set; }
        public string LinhVuc_Ten { get; set; }
        public string TuVanVien_Ten { get; set; }
        public Double CongNo { get; set; }
        public Double DoanhSo { get; set; }
        public Double TongThu { get; set; }
        public Double TongChi { get; set; }
        public Double TongXuat { get; set; }
        public Double TongNhap { get; set; }
        public Double TongDichVu { get; set; }
        public Double CongNoDauKy { get; set; }
        public Int32 Tuoi { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return KhachHangDal.getFromReader(rd);
        }

        public void del(string id)
        {
            KhachHangDal.DeleteById(new Guid(id));
        }

        public BaseObject get(string id)
        {
            return KhachHangDal.SelectById(new Guid(id));
        }
    }
    #endregion
    #region Collection
    public class KhachHangCollection : BaseEntityCollection<KhachHang>
    { }
    #endregion
    #region Dal
    public class KhachHangDal
    {
        #region Methods

        public static void DeleteById(Guid KH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhachHang_Delete_DeleteById_linhnx", obj);
        }

        public static KhachHang Insert(KhachHang item)
        {
            var Item = new KhachHang();
            var obj = new SqlParameter[32];
            obj[0] = new SqlParameter("KH_ID", item.ID);
            obj[1] = new SqlParameter("KH_Ma", item.Ma);
            obj[2] = new SqlParameter("KH_Ten", item.Ten);
            obj[3] = new SqlParameter("KH_Ho", item.Ho);
            obj[4] = new SqlParameter("KH_XungHo", item.XungHo);
            if (item.NgaySinh > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("KH_NgaySinh", item.NgaySinh);
            }
            else
            {
                obj[5] = new SqlParameter("KH_NgaySinh", DBNull.Value);
            }
            obj[6] = new SqlParameter("KH_GioiTinh", item.GioiTinh);
            obj[7] = new SqlParameter("KH_Email", item.Email);
            obj[8] = new SqlParameter("KH_Mobile", item.Mobile);
            obj[9] = new SqlParameter("KH_Phone", item.Phone);
            obj[10] = new SqlParameter("KH_CMND", item.CMND);
            obj[11] = new SqlParameter("KH_Ym", item.Ym);
            obj[12] = new SqlParameter("KH_FacebookUid", item.FacebookUid);
            obj[13] = new SqlParameter("KH_LinhVuc_ID", item.LinhVuc_ID);
            obj[14] = new SqlParameter("KH_NguonGoc_ID", item.NguonGoc_ID);
            obj[15] = new SqlParameter("KH_NguonGoc_ChiTiet_ID", item.NguonGoc_ChiTiet_ID);
            obj[16] = new SqlParameter("KH_DiaChi", item.DiaChi);
            obj[17] = new SqlParameter("KH_KhuVuc_ID", item.KhuVuc_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("KH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[18] = new SqlParameter("KH_NgayTao", DBNull.Value);
            }
            obj[19] = new SqlParameter("KH_NguoiGioiThieu", item.NguoiGioiThieu);
            obj[20] = new SqlParameter("KH_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("KH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[21] = new SqlParameter("KH_NgayCapNhat", DBNull.Value);
            }
            obj[22] = new SqlParameter("KH_NguoiCapNhat", item.NguoiCapNhat);
            obj[23] = new SqlParameter("KH_NgungTheoDoi", item.NgungTheoDoi);
            obj[24] = new SqlParameter("KH_NoiBat", item.NoiBat);
            obj[25] = new SqlParameter("KH_ChiaSe", item.ChiaSe);
            obj[26] = new SqlParameter("KH_DanhGia", item.DanhGia);
            obj[27] = new SqlParameter("KH_KhongNhanEmail", item.KhongNhanEmail);
            obj[28] = new SqlParameter("KH_KhongDuocGoiDien", item.KhongDuocGoiDien);
            obj[29] = new SqlParameter("KH_ThoiGianGoiDien", item.ThoiGianGoiDien);
            obj[30] = new SqlParameter("KH_Anh", item.Anh);
            obj[31] = new SqlParameter("KH_TuVanVien", item.TuVanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhachHang_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KhachHang Update(KhachHang item)
        {
            var Item = new KhachHang();
            var obj = new SqlParameter[32];
            obj[0] = new SqlParameter("KH_ID", item.ID);
            obj[1] = new SqlParameter("KH_Ma", item.Ma);
            obj[2] = new SqlParameter("KH_Ten", item.Ten);
            obj[3] = new SqlParameter("KH_Ho", item.Ho);
            obj[4] = new SqlParameter("KH_XungHo", item.XungHo);
            if (item.NgaySinh > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("KH_NgaySinh", item.NgaySinh);
            }
            else
            {
                obj[5] = new SqlParameter("KH_NgaySinh", DBNull.Value);
            }
            obj[6] = new SqlParameter("KH_GioiTinh", item.GioiTinh);
            obj[7] = new SqlParameter("KH_Email", item.Email);
            obj[8] = new SqlParameter("KH_Mobile", item.Mobile);
            obj[9] = new SqlParameter("KH_Phone", item.Phone);
            obj[10] = new SqlParameter("KH_CMND", item.CMND);
            obj[11] = new SqlParameter("KH_Ym", item.Ym);
            obj[12] = new SqlParameter("KH_FacebookUid", item.FacebookUid);
            obj[13] = new SqlParameter("KH_LinhVuc_ID", item.LinhVuc_ID);
            obj[14] = new SqlParameter("KH_NguonGoc_ID", item.NguonGoc_ID);
            obj[15] = new SqlParameter("KH_NguonGoc_ChiTiet_ID", item.NguonGoc_ChiTiet_ID);
            obj[16] = new SqlParameter("KH_DiaChi", item.DiaChi);
            obj[17] = new SqlParameter("KH_KhuVuc_ID", item.KhuVuc_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("KH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[18] = new SqlParameter("KH_NgayTao", DBNull.Value);
            }
            obj[19] = new SqlParameter("KH_NguoiGioiThieu", item.NguoiGioiThieu);
            obj[20] = new SqlParameter("KH_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("KH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[21] = new SqlParameter("KH_NgayCapNhat", DBNull.Value);
            }
            obj[22] = new SqlParameter("KH_NguoiCapNhat", item.NguoiCapNhat);
            obj[23] = new SqlParameter("KH_NgungTheoDoi", item.NgungTheoDoi);
            obj[24] = new SqlParameter("KH_NoiBat", item.NoiBat);
            obj[25] = new SqlParameter("KH_ChiaSe", item.ChiaSe);
            obj[26] = new SqlParameter("KH_DanhGia", item.DanhGia);
            obj[27] = new SqlParameter("KH_KhongNhanEmail", item.KhongNhanEmail);
            obj[28] = new SqlParameter("KH_KhongDuocGoiDien", item.KhongDuocGoiDien);
            obj[29] = new SqlParameter("KH_ThoiGianGoiDien", item.ThoiGianGoiDien);
            obj[30] = new SqlParameter("KH_Anh", item.Anh);
            obj[31] = new SqlParameter("KH_TuVanVien", item.TuVanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhachHang_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KhachHang SelectById(Guid KH_ID)
        {
            var Item = new KhachHang();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhachHang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KhachHangCollection SelectAll()
        {
            var List = new KhachHangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhachHang_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<KhachHang> pagerNormal(string url, bool rewrite, string sort, string q, int size, string KhuVuc_ID, string NguonGoc_ID)
        {
            var obj = new SqlParameter[4];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(KhuVuc_ID))
            {
                obj[2] = new SqlParameter("KhuVuc_ID", KhuVuc_ID);
            }
            else
            {
                obj[2] = new SqlParameter("KhuVuc_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(NguonGoc_ID))
            {
                obj[3] = new SqlParameter("NguonGoc_ID", NguonGoc_ID);
            }
            else
            {
                obj[3] = new SqlParameter("NguonGoc_ID", DBNull.Value);
            }

            var pg = new Pager<KhachHang>("sp_tblSpaMgr_KhachHang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static KhachHang getFromReader(IDataReader rd)
        {
            var Item = new KhachHang();
            if (rd.FieldExists("KH_ID"))
            {
                Item.ID = (Guid)(rd["KH_ID"]);
            }
            if (rd.FieldExists("KH_Ma"))
            {
                Item.Ma = (String)(rd["KH_Ma"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.Ten = (String)(rd["KH_Ten"]);
            }
            if (rd.FieldExists("KH_Ho"))
            {
                Item.Ho = (String)(rd["KH_Ho"]);
            }
            if (rd.FieldExists("KH_XungHo"))
            {
                Item.XungHo = (String)(rd["KH_XungHo"]);
            }
            if (rd.FieldExists("KH_NgaySinh"))
            {
                Item.NgaySinh = (DateTime)(rd["KH_NgaySinh"]);
            }
            if (rd.FieldExists("KH_GioiTinh"))
            {
                Item.GioiTinh = (Boolean)(rd["KH_GioiTinh"]);
            }
            if (rd.FieldExists("KH_Email"))
            {
                Item.Email = (String)(rd["KH_Email"]);
            }
            if (rd.FieldExists("KH_Mobile"))
            {
                Item.Mobile = (String)(rd["KH_Mobile"]);
            }
            if (rd.FieldExists("KH_Phone"))
            {
                Item.Phone = (String)(rd["KH_Phone"]);
            }
            if (rd.FieldExists("KH_CMND"))
            {
                Item.CMND = (String)(rd["KH_CMND"]);
            }
            if (rd.FieldExists("KH_Ym"))
            {
                Item.Ym = (String)(rd["KH_Ym"]);
            }
            if (rd.FieldExists("KH_FacebookUid"))
            {
                Item.FacebookUid = (String)(rd["KH_FacebookUid"]);
            }
            if (rd.FieldExists("KH_LinhVuc_ID"))
            {
                Item.LinhVuc_ID = (Guid)(rd["KH_LinhVuc_ID"]);
            }
            if (rd.FieldExists("KH_NguonGoc_ID"))
            {
                Item.NguonGoc_ID = (Guid)(rd["KH_NguonGoc_ID"]);
            }
            if (rd.FieldExists("KH_NguonGoc_ChiTiet_ID"))
            {
                Item.NguonGoc_ChiTiet_ID = (Guid)(rd["KH_NguonGoc_ChiTiet_ID"]);
            }
            if (rd.FieldExists("KH_DiaChi"))
            {
                Item.DiaChi = (String)(rd["KH_DiaChi"]);
            }
            if (rd.FieldExists("KH_KhuVuc_ID"))
            {
                Item.KhuVuc_ID = (Guid)(rd["KH_KhuVuc_ID"]);
            }
            if (rd.FieldExists("KH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["KH_NgayTao"]);
            }
            if (rd.FieldExists("KH_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["KH_NguoiTao"]);
            }
            if (rd.FieldExists("KH_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["KH_NgayCapNhat"]);
            }
            if (rd.FieldExists("KH_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["KH_NguoiCapNhat"]);
            }
            if (rd.FieldExists("KH_NgungTheoDoi"))
            {
                Item.NgungTheoDoi = (Boolean)(rd["KH_NgungTheoDoi"]);
            }
            if (rd.FieldExists("KH_NoiBat"))
            {
                Item.NoiBat = (Boolean)(rd["KH_NoiBat"]);
            }
            if (rd.FieldExists("KH_ChiaSe"))
            {
                Item.ChiaSe = (Boolean)(rd["KH_ChiaSe"]);
            }
            if (rd.FieldExists("KH_DanhGia"))
            {
                Item.DanhGia = (Int16)(rd["KH_DanhGia"]);
            }
            if (rd.FieldExists("KH_KhongNhanEmail"))
            {
                Item.KhongNhanEmail = (Boolean)(rd["KH_KhongNhanEmail"]);
            }
            if (rd.FieldExists("KH_KhongDuocGoiDien"))
            {
                Item.KhongDuocGoiDien = (Boolean)(rd["KH_KhongDuocGoiDien"]);
            }
            if (rd.FieldExists("KH_ThoiGianGoiDien"))
            {
                Item.ThoiGianGoiDien = (String)(rd["KH_ThoiGianGoiDien"]);
            }

            if (rd.FieldExists("KH_NguonGoc_Ten"))
            {
                Item.NguonGoc_Ten = (String)(rd["KH_NguonGoc_Ten"]);
            }
            if (rd.FieldExists("KH_KhuVuc_Ten"))
            {
                Item.KhuVuc_Ten = (String)(rd["KH_KhuVuc_Ten"]);
            }
            if (rd.FieldExists("KH_NguonGoc_ChiTiet_Ten"))
            {
                Item.NguonGoc_ChiTiet_Ten = (String)(rd["KH_NguonGoc_ChiTiet_Ten"]);
            }
            if (rd.FieldExists("NguoiGioiThieu_Ten"))
            {
                Item.NguoiGioiThieu_Ten = (String)(rd["NguoiGioiThieu_Ten"]);
            }
            if (rd.FieldExists("KH_Anh"))
            {
                Item.Anh = (String)(rd["KH_Anh"]);
            }
            if (rd.FieldExists("KH_TuVanVien"))
            {
                Item.TuVanVien = (String)(rd["KH_TuVanVien"]);
            }
            if (rd.FieldExists("KH_LinhVuc_Ten"))
            {
                Item.LinhVuc_Ten = (String)(rd["KH_LinhVuc_Ten"]);
            }
            if (rd.FieldExists("KH_TuVanVien_Ten"))
            {
                Item.TuVanVien_Ten = (String)(rd["KH_TuVanVien_Ten"]);
            }
            if (rd.FieldExists("KH_CongNo"))
            {
                Item.CongNo = (Double)(rd["KH_CongNo"]);
            }
            if (rd.FieldExists("KH_DoanhSo"))
            {
                Item.DoanhSo = (Double)(rd["KH_DoanhSo"]);
            }
            if (rd.FieldExists("KH_TongThu"))
            {
                Item.TongThu = (Double)(rd["KH_TongThu"]);
            }
            if (rd.FieldExists("KH_TongChi"))
            {
                Item.TongChi = (Double)(rd["KH_TongChi"]);
            }
            if (rd.FieldExists("KH_TongXuat"))
            {
                Item.TongXuat = (Double)(rd["KH_TongXuat"]);
            }
            if (rd.FieldExists("KH_TongNhap"))
            {
                Item.TongNhap = (Double)(rd["KH_TongNhap"]);
            }
            if (rd.FieldExists("KH_TongDichVu"))
            {
                Item.TongDichVu = (Double)(rd["KH_TongDichVu"]);
            }
            if (rd.FieldExists("KH_CongNoDauKy"))
            {
                Item.CongNoDauKy = (Double)(rd["KH_CongNoDauKy"]);
            }
            if (rd.FieldExists("KH_Tuoi"))
            {
                Item.Tuoi = (Int32)(rd["KH_Tuoi"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<KhachHang> pagerAll(string url, bool rewrite, string sort, string q, int size, string KhuVuc_ID, string NguonGoc_Id)
        {
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KhuVuc_ID))
            {
                obj[2] = new SqlParameter("KhuVuc_ID", KhuVuc_ID);
            }
            else
            {
                obj[2] = new SqlParameter("KhuVuc_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NguonGoc_Id))
            {
                obj[3] = new SqlParameter("NguonGoc_Id", NguonGoc_Id);
            }
            else
            {
                obj[3] = new SqlParameter("NguonGoc_Id", DBNull.Value);
            }

            var pg = new Pager<KhachHang>("sp_tblSpaMgr_KhachHang_Pager_pagerAll_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static KhachHang SelectById(Guid KH_ID, SqlConnection con)
        {
            var Item = new KhachHang();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_KhachHang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static KhachHang SelectDraff(SqlConnection con)
        {
            var Item = new KhachHang();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_KhachHang_Select_SelectDraff_linhnx"))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static KhachHangCollection SelectCongNo(string No)
        {
            var List = new KhachHangCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(No))
            {
                obj[0] = new SqlParameter("No", No);
            }
            else
            {
                obj[0] = new SqlParameter("No", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhachHang_CongNo_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }

            return List;
        }
        public static Pager<KhachHang> pagerDoanhSo(string url, bool rewrite, string sort, string q, int size, string KhuVuc_ID, string NguonGoc_ID, string TuNgay, string DenNgay)
        {
            var obj = new SqlParameter[6];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(KhuVuc_ID))
            {
                obj[2] = new SqlParameter("KhuVuc_ID", KhuVuc_ID);
            }
            else
            {
                obj[2] = new SqlParameter("KhuVuc_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(NguonGoc_ID))
            {
                obj[3] = new SqlParameter("NguonGoc_ID", NguonGoc_ID);
            }
            else
            {
                obj[3] = new SqlParameter("NguonGoc_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[4] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[4] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[5] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[5] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<KhachHang>("sp_tblSpaMgr_KhachHang_Pager_pagerDoanhSoTuNgayDenNgay_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<KhachHang> pagerSinhNhat(string url, bool rewrite, string sort, string q, int size, string KhuVuc_ID, string NguonGoc_ID)
        {
            var obj = new SqlParameter[4];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(KhuVuc_ID))
            {
                obj[2] = new SqlParameter("KhuVuc_ID", KhuVuc_ID);
            }
            else
            {
                obj[2] = new SqlParameter("KhuVuc_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(NguonGoc_ID))
            {
                obj[3] = new SqlParameter("NguonGoc_ID", NguonGoc_ID);
            }
            else
            {
                obj[3] = new SqlParameter("NguonGoc_ID", DBNull.Value);
            }

            var pg = new Pager<KhachHang>("sp_tblSpaMgr_KhachHang_Pager_SinhNhat_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
}
