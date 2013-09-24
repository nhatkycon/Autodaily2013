using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace docsoft.entities
{
    #region ToTrinh
    #region BO
    public class ToTrinh : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 CapDo_ID { get; set; }
        public String CapDo_Ten { get; set; }
        public Int32 LoaiVanBan_ID { get; set; }
        public String LoaiVanBan_Ten { get; set; }
        public String TrichYeu { get; set; }
        public Int32 DonViThao_ID { get; set; }
        public String DonViThao_Ten { get; set; }
        public String NguoiThao { get; set; }
        public Int32 NoiNhan_ID { get; set; }
        public String NoiNhan_Ten { get; set; }
        public Int32 SoTrang { get; set; }
        public String GhiChu { get; set; }
        public Byte TrangThai { get; set; }
        public Guid RowId { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiSua { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 TT_So { get; set; }
        public DateTime TT_NgayTrinh { get; set; }
        public DateTime TT_LDVP_NgayTrinh { get; set; }
        public String TT_LDVP_YKien { get; set; }
        public Int32 TT_LDVP_ID { get; set; }
        public String TT_LDVP_Username { get; set; }
        public String TT_LDVP_Ten { get; set; }
        public String TT_LDVP_Loai_Ten { get; set; }
        public DateTime TT_LDVP_NgayTraLai { get; set; }
        public String TT_LDVP_LyDo { get; set; }
        public DateTime TT_LDB_NgayTrinh { get; set; }
        public String TT_LDB_YKien { get; set; }
        public Int32 TT_LDB_ID { get; set; }
        public String TT_LDB_Username { get; set; }
        public String TT_LDB_Ten { get; set; }
        public String TT_LDB_Loai_Ten { get; set; }
        public DateTime TT_LDB_NgayKy { get; set; }
        public DateTime TT_LDB_NgayTraLai { get; set; }
        public String TT_LDB_LyDo { get; set; }
        public DateTime TT_NgayChuyenPhatHanh { get; set; }
        public String TT_DonVi { get; set; }
        public Int32 TT_DonVi_So { get; set; }
        #endregion
        #region Contructor
        public ToTrinh()
        { }
        #endregion
        #region Customs properties
        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }
        public string NgayTrinh_Tuan { get; set; }
        public string NgayTrinh_Thang { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ToTrinhDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ToTrinhCollection : BaseEntityCollection<ToTrinh>
    { }
    #endregion
    #region Dal
    public class ToTrinhDal
    {
        #region Methods
        public static void DeleteById(Int32 VBD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Delete_DeleteById_linhnx", obj);
        }
        public static ToTrinh Insert(ToTrinh Inserted)
        {
            ToTrinh Item = new ToTrinh();
            SqlParameter[] obj = new SqlParameter[37];

            obj[0] = new SqlParameter("VBD_LoaiVanBan_ID", Inserted.LoaiVanBan_ID);
            obj[1] = new SqlParameter("VBD_LoaiVanBan_Ten", Inserted.LoaiVanBan_Ten);
            obj[2] = new SqlParameter("VBD_TrichYeu", Inserted.TrichYeu);
            obj[3] = new SqlParameter("VBD_DonViThao_ID", Inserted.DonViThao_ID);
            obj[4] = new SqlParameter("VBD_DonViThao_Ten", Inserted.DonViThao_Ten);
            obj[5] = new SqlParameter("VBD_NguoiThao", Inserted.NguoiThao);
            obj[6] = new SqlParameter("VBD_NoiNhan_ID", Inserted.NoiNhan_ID);
            obj[7] = new SqlParameter("VBD_NoiNhan_Ten", Inserted.NoiNhan_Ten);
            obj[8] = new SqlParameter("VBD_SoTrang", Inserted.SoTrang);
            obj[9] = new SqlParameter("VBD_GhiChu", Inserted.GhiChu);
            obj[10] = new SqlParameter("VBD_TrangThai", Inserted.TrangThai);
            obj[11] = new SqlParameter("VBD_RowId", Inserted.RowId);
            obj[12] = new SqlParameter("VBD_NguoiTao", Inserted.NguoiTao);
            obj[13] = new SqlParameter("VBD_NguoiSua", Inserted.NguoiSua);
            obj[14] = new SqlParameter("VBD_NgayTao", Inserted.NgayTao);
            obj[15] = new SqlParameter("VBD_NgayCapNhat", Inserted.NgayCapNhat);
            obj[16] = new SqlParameter("VBD_TT_So", Inserted.TT_So);
            obj[17] = new SqlParameter("VBD_TT_NgayTrinh", Inserted.TT_NgayTrinh);
            obj[18] = new SqlParameter("VBD_TT_LDVP_NgayTrinh", Inserted.TT_LDVP_NgayTrinh);
            obj[19] = new SqlParameter("VBD_TT_LDVP_YKien", Inserted.TT_LDVP_YKien);
            obj[20] = new SqlParameter("VBD_TT_LDVP_ID", Inserted.TT_LDVP_ID);
            obj[21] = new SqlParameter("VBD_TT_LDVP_Username", Inserted.TT_LDVP_Username);
            obj[22] = new SqlParameter("VBD_TT_LDVP_Ten", Inserted.TT_LDVP_Ten);
            obj[23] = new SqlParameter("VBD_TT_LDVP_Loai_Ten", Inserted.TT_LDVP_Loai_Ten);
            obj[24] = new SqlParameter("VBD_TT_LDB_NgayTrinh", Inserted.TT_LDB_NgayTrinh);
            obj[25] = new SqlParameter("VBD_TT_LDB_YKien", Inserted.TT_LDB_YKien);
            obj[26] = new SqlParameter("VBD_TT_LDB_ID", Inserted.TT_LDB_ID);
            obj[27] = new SqlParameter("VBD_TT_LDB_Username", Inserted.TT_LDB_Username);
            obj[28] = new SqlParameter("VBD_TT_LDB_Ten", Inserted.TT_LDB_Ten);
            obj[29] = new SqlParameter("VBD_TT_LDB_Loai_Ten", Inserted.TT_LDB_Loai_Ten);
            obj[30] = new SqlParameter("VBD_TT_LDB_NgayKy", Inserted.TT_LDB_NgayKy);
            obj[31] = new SqlParameter("VBD_TT_NgayChuyenPhatHanh", Inserted.TT_NgayChuyenPhatHanh);
            obj[32] = new SqlParameter("VBD_TT_LDVP_LyDoTraLai", Inserted.TT_LDVP_LyDo);
            obj[33] = new SqlParameter("VBD_TT_LDVP_NgayTraLai", Inserted.TT_LDVP_NgayTraLai);
            obj[34] = new SqlParameter("VBD_TT_LDB_LyDoTraLai", Inserted.TT_LDB_LyDo);
            obj[35] = new SqlParameter("VBD_TT_LDB_NgayTraLai", Inserted.TT_LDB_NgayTraLai);
            obj[36] = new SqlParameter("VBD_TT_TT_DonVi_So", Inserted.TT_DonVi_So);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_TT_Insert_InsertNormal_hungpm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ToTrinh Update(ToTrinh Updated)
        {
            ToTrinh Item = new ToTrinh();
            SqlParameter[] obj = new SqlParameter[38];
            obj[0] = new SqlParameter("VBD_ID", Updated.ID);
            obj[1] = new SqlParameter("VBD_LoaiVanBan_ID", Updated.LoaiVanBan_ID);
            obj[2] = new SqlParameter("VBD_LoaiVanBan_Ten", Updated.LoaiVanBan_Ten);
            obj[3] = new SqlParameter("VBD_TrichYeu", Updated.TrichYeu);
            obj[4] = new SqlParameter("VBD_DonViThao_ID", Updated.DonViThao_ID);
            obj[5] = new SqlParameter("VBD_DonViThao_Ten", Updated.DonViThao_Ten);
            obj[6] = new SqlParameter("VBD_NguoiThao", Updated.NguoiThao);
            obj[7] = new SqlParameter("VBD_NoiNhan_ID", Updated.NoiNhan_ID);
            obj[8] = new SqlParameter("VBD_NoiNhan_Ten", Updated.NoiNhan_Ten);
            obj[9] = new SqlParameter("VBD_SoTrang", Updated.SoTrang);
            obj[10] = new SqlParameter("VBD_GhiChu", Updated.GhiChu);
            obj[11] = new SqlParameter("VBD_TrangThai", Updated.TrangThai);
            obj[12] = new SqlParameter("VBD_RowId", Updated.RowId);
            obj[13] = new SqlParameter("VBD_NguoiTao", Updated.NguoiTao);
            obj[14] = new SqlParameter("VBD_NguoiSua", Updated.NguoiSua);
            obj[15] = new SqlParameter("VBD_NgayTao", Updated.NgayTao);
            obj[16] = new SqlParameter("VBD_NgayCapNhat", Updated.NgayCapNhat);
            obj[17] = new SqlParameter("VBD_TT_So", Updated.TT_So);
            obj[18] = new SqlParameter("VBD_TT_NgayTrinh", Updated.TT_NgayTrinh);
            string htl = string.Format("{0:dd/MM/yy}", Updated.TT_NgayTrinh);
            if (htl != "01/01/01")
            {
                obj[18] = new SqlParameter("VBD_TT_NgayTrinh", Updated.TT_NgayTrinh);
            }
            else
            {
                obj[18] = new SqlParameter("VBD_TT_NgayTrinh", DBNull.Value);
            }


            obj[19] = new SqlParameter("VBD_TT_LDVP_NgayTrinh", Updated.TT_LDVP_NgayTrinh);
            string htl0 = string.Format("{0:dd/MM/yy}", Updated.TT_LDVP_NgayTrinh);
            if (htl0 != "01/01/01")
            {
                obj[19] = new SqlParameter("VBD_TT_LDVP_NgayTrinh", Updated.TT_LDVP_NgayTrinh);
            }
            else
            {
                obj[19] = new SqlParameter("VBD_TT_LDVP_NgayTrinh", DBNull.Value);
            }
            obj[20] = new SqlParameter("VBD_TT_LDVP_YKien", Updated.TT_LDVP_YKien);
            obj[21] = new SqlParameter("VBD_TT_LDVP_ID", Updated.TT_LDVP_ID);
            obj[22] = new SqlParameter("VBD_TT_LDVP_Username", Updated.TT_LDVP_Username);
            obj[23] = new SqlParameter("VBD_TT_LDVP_Ten", Updated.TT_LDVP_Ten);
            obj[24] = new SqlParameter("VBD_TT_LDVP_Loai_Ten", Updated.TT_LDVP_Loai_Ten);
            obj[25] = new SqlParameter("VBD_TT_LDB_NgayTrinh", Updated.TT_LDB_NgayTrinh);
            string htl1 = string.Format("{0:dd/MM/yy}", Updated.TT_LDB_NgayTrinh);
            if (htl1 != "01/01/01")
            {
                obj[25] = new SqlParameter("VBD_TT_LDB_NgayTrinh", Updated.TT_LDB_NgayTrinh);
            }
            else
            {
                obj[25] = new SqlParameter("VBD_TT_LDB_NgayTrinh", DBNull.Value);
            }
            obj[26] = new SqlParameter("VBD_TT_LDB_YKien", Updated.TT_LDB_YKien);
            obj[27] = new SqlParameter("VBD_TT_LDB_ID", Updated.TT_LDB_ID);
            obj[28] = new SqlParameter("VBD_TT_LDB_Username", Updated.TT_LDB_Username);
            obj[29] = new SqlParameter("VBD_TT_LDB_Ten", Updated.TT_LDB_Ten);
            obj[30] = new SqlParameter("VBD_TT_LDB_Loai_Ten", Updated.TT_LDB_Loai_Ten);
            obj[31] = new SqlParameter("VBD_TT_LDB_NgayKy", Updated.TT_LDB_NgayKy);
            string htl2 = string.Format("{0:dd/MM/yy}", Updated.TT_LDB_NgayKy);
            if (htl2 != "01/01/01")
            {
                obj[31] = new SqlParameter("VBD_TT_LDB_NgayKy", Updated.TT_LDB_NgayKy);
            }
            else
            {
                obj[31] = new SqlParameter("VBD_TT_LDB_NgayKy", DBNull.Value);
            }
            obj[32] = new SqlParameter("VBD_TT_NgayChuyenPhatHanh", Updated.TT_NgayChuyenPhatHanh);
            string htl3 = string.Format("{0:dd/MM/yy}", Updated.TT_NgayChuyenPhatHanh);
            if (htl3 != "01/01/01")
            {
                obj[32] = new SqlParameter("VBD_TT_NgayChuyenPhatHanh", Updated.TT_NgayChuyenPhatHanh);
            }
            else
            {
                obj[32] = new SqlParameter("VBD_TT_NgayChuyenPhatHanh", DBNull.Value);
            }
            obj[33] = new SqlParameter("VBD_TT_LDVP_LyDoTraLai", Updated.TT_LDVP_LyDo);
            obj[34] = new SqlParameter("VBDTT_LDVP_NgayTraLai", Updated.TT_LDVP_NgayTraLai);
            var htl4 = string.Format("{0:dd/MM/yy}", Updated.TT_LDVP_NgayTraLai);
            if (htl4 != "01/01/01")
            {
                obj[34] = new SqlParameter("VBD_TT_LDVP_NgayTraLai", Updated.TT_LDVP_NgayTraLai);
            }
            else
            {
                obj[34] = new SqlParameter("VBD_TT_LDVP_NgayTraLai", DBNull.Value);
            }

            obj[35] = new SqlParameter("VBD_TT_LDB_LyDoTraLai", Updated.TT_LDB_LyDo);
            obj[36] = new SqlParameter("VBD_TT_LDB_NgayTraLai", Updated.TT_LDB_NgayTraLai);
            var htl5 = string.Format("{0:dd/MM/yy}", Updated.TT_LDB_NgayTraLai);
            if (htl5 != "01/01/01")
            {
                obj[36] = new SqlParameter("VBD_TT_LDB_NgayTraLai", Updated.TT_LDB_NgayTraLai);
            }
            else
            {
                obj[36] = new SqlParameter("VBD_TT_LDB_NgayTraLai", DBNull.Value);
            }
            obj[37] = new SqlParameter("VBD_TT_DonVi_So", Updated.TT_DonVi_So);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_TT_Update_UpdateNormal_hungpm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Pager<ToTrinh> pagerNormal(string url, bool rewrite, string sort, int pagesize
            , string VBD_LoaiVanBan_ID
            , string VBD_DonViTrinh_ID
            , string VBD_TT_LDVP_ID
            , string VBD_TT_LDB_ID
            , string VBD_TrangThai
            , string Ngay
            , string Tuan
            , string Thang
            , string q
            , string TuNgay
            , string DenNgay
            , string DonVi)
        {
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(VBD_LoaiVanBan_ID))
            {
                obj[1] = new SqlParameter("VBD_LoaiVanBan_ID", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("VBD_LoaiVanBan_ID", VBD_LoaiVanBan_ID);
            }
            if (string.IsNullOrEmpty(VBD_DonViTrinh_ID))
            {
                obj[2] = new SqlParameter("VBD_DonViThao_ID", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("VBD_DonViThao_ID", VBD_DonViTrinh_ID);
            }
            if (string.IsNullOrEmpty(VBD_TT_LDVP_ID))
            {
                obj[3] = new SqlParameter("VBD_TT_LDVP_ID", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("VBD_TT_LDVP_ID", VBD_TT_LDVP_ID);
            }
            if (string.IsNullOrEmpty(VBD_TT_LDB_ID))
            {
                obj[4] = new SqlParameter("VBD_TT_LDB_ID", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("VBD_TT_LDB_ID", VBD_TT_LDB_ID);
            }
            if (string.IsNullOrEmpty(VBD_TrangThai))
            {
                obj[5] = new SqlParameter("VBD_TrangThai", DBNull.Value);
            }
            else
            {
                obj[5] = new SqlParameter("VBD_TrangThai", VBD_TrangThai);
            }
            if (string.IsNullOrEmpty(Ngay))
            {
                obj[6] = new SqlParameter("Ngay", DBNull.Value);
            }
            else
            {
                obj[6] = new SqlParameter("Ngay", Ngay);
            }
            if (string.IsNullOrEmpty(Tuan))
            {
                obj[7] = new SqlParameter("Tuan", DBNull.Value);
            }
            else
            {
                obj[7] = new SqlParameter("Tuan", Tuan);
            }
            if (string.IsNullOrEmpty(Thang))
            {
                obj[8] = new SqlParameter("Thang", DBNull.Value);
            }
            else
            {
                obj[8] = new SqlParameter("Thang", Thang);
            }
            if (string.IsNullOrEmpty(q))
            {
                obj[9] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[9] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(TuNgay))
            {
                obj[10] = new SqlParameter("tungay", DBNull.Value);
            }
            else
            {
                obj[10] = new SqlParameter("tungay", TuNgay);
            }
            if (string.IsNullOrEmpty(DenNgay))
            {
                obj[11] = new SqlParameter("denngay", DBNull.Value);
            }
            else
            {
                obj[11] = new SqlParameter("denngay", DenNgay);
            }
            if (string.IsNullOrEmpty(DonVi))
            {
                obj[12] = new SqlParameter("donvi", DBNull.Value);
            }
            else
            {
                obj[12] = new SqlParameter("donvi", DonVi);
            }
            Pager<ToTrinh> pg = new Pager<ToTrinh>("sp_tblVanBanDi_TT_Pager_Normal_linhnx", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<ToTrinh> pagerNormal_DV(string url, bool rewrite, string sort, int pagesize
            , string VBD_LoaiVanBan_ID
            , string VBD_DonViTrinh_ID
            , string VBD_TT_LDVP_ID
            , string VBD_TT_LDB_ID
            , string VBD_TrangThai
            , string Ngay
            , string Tuan
            , string Thang
            , string q
            , string TuNgay
            , string DenNgay
            , string DonVi)
        {
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(VBD_LoaiVanBan_ID))
            {
                obj[1] = new SqlParameter("VBD_LoaiVanBan_ID", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("VBD_LoaiVanBan_ID", VBD_LoaiVanBan_ID);
            }
            if (string.IsNullOrEmpty(VBD_DonViTrinh_ID))
            {
                obj[2] = new SqlParameter("VBD_DonViThao_ID", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("VBD_DonViThao_ID", VBD_DonViTrinh_ID);
            }
            if (string.IsNullOrEmpty(VBD_TT_LDVP_ID))
            {
                obj[3] = new SqlParameter("VBD_TT_LDVP_ID", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("VBD_TT_LDVP_ID", VBD_TT_LDVP_ID);
            }
            if (string.IsNullOrEmpty(VBD_TT_LDB_ID))
            {
                obj[4] = new SqlParameter("VBD_TT_LDB_ID", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("VBD_TT_LDB_ID", VBD_TT_LDB_ID);
            }
            if (string.IsNullOrEmpty(VBD_TrangThai))
            {
                obj[5] = new SqlParameter("VBD_TrangThai", DBNull.Value);
            }
            else
            {
                obj[5] = new SqlParameter("VBD_TrangThai", VBD_TrangThai);
            }
            if (string.IsNullOrEmpty(Ngay))
            {
                obj[6] = new SqlParameter("Ngay", DBNull.Value);
            }
            else
            {
                obj[6] = new SqlParameter("Ngay", Ngay);
            }
            if (string.IsNullOrEmpty(Tuan))
            {
                obj[7] = new SqlParameter("Tuan", DBNull.Value);
            }
            else
            {
                obj[7] = new SqlParameter("Tuan", Tuan);
            }
            if (string.IsNullOrEmpty(Thang))
            {
                obj[8] = new SqlParameter("Thang", DBNull.Value);
            }
            else
            {
                obj[8] = new SqlParameter("Thang", Thang);
            }
            if (string.IsNullOrEmpty(q))
            {
                obj[9] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[9] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(TuNgay))
            {
                obj[10] = new SqlParameter("tungay", DBNull.Value);
            }
            else
            {
                obj[10] = new SqlParameter("tungay", TuNgay);
            }
            if (string.IsNullOrEmpty(DenNgay))
            {
                obj[11] = new SqlParameter("denngay", DBNull.Value);
            }
            else
            {
                obj[11] = new SqlParameter("denngay", DenNgay);
            }
            if (string.IsNullOrEmpty(DonVi))
            {
                obj[12] = new SqlParameter("donvi", DBNull.Value);
            }
            else
            {
                obj[12] = new SqlParameter("donvi", DonVi);
            }
            Pager<ToTrinh> pg = new Pager<ToTrinh>("sp_tblVanBanDi_TT_Pager_Normal_DonVi_linhnx", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        
        public static Pager<ToTrinh> pagerNormalDaPhatHanh(string url, bool rewrite, string sort, int pagesize
            , string VBD_LoaiVanBan_ID
            , string VBD_DonViTrinh_ID
            , string VBD_TT_LDVP_ID
            , string VBD_TT_LDB_ID
            , string VBD_TrangThai
            , string Ngay
            , string Tuan
            , string Thang
            , string q
            , string TuNgay
            , string DenNgay
            , string DonVi)
        {
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(VBD_LoaiVanBan_ID))
            {
                obj[1] = new SqlParameter("VBD_LoaiVanBan_ID", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("VBD_LoaiVanBan_ID", VBD_LoaiVanBan_ID);
            }
            if (string.IsNullOrEmpty(VBD_DonViTrinh_ID))
            {
                obj[2] = new SqlParameter("VBD_DonViThao_ID", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("VBD_DonViThao_ID", VBD_DonViTrinh_ID);
            }
            if (string.IsNullOrEmpty(VBD_TT_LDVP_ID))
            {
                obj[3] = new SqlParameter("VBD_TT_LDVP_ID", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("VBD_TT_LDVP_ID", VBD_TT_LDVP_ID);
            }
            if (string.IsNullOrEmpty(VBD_TT_LDB_ID))
            {
                obj[4] = new SqlParameter("VBD_TT_LDB_ID", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("VBD_TT_LDB_ID", VBD_TT_LDB_ID);
            }
            if (string.IsNullOrEmpty(VBD_TrangThai))
            {
                obj[5] = new SqlParameter("VBD_TrangThai", DBNull.Value);
            }
            else
            {
                obj[5] = new SqlParameter("VBD_TrangThai", VBD_TrangThai);
            }
            if (string.IsNullOrEmpty(Ngay))
            {
                obj[6] = new SqlParameter("Ngay", DBNull.Value);
            }
            else
            {
                obj[6] = new SqlParameter("Ngay", Ngay);
            }
            if (string.IsNullOrEmpty(Tuan))
            {
                obj[7] = new SqlParameter("Tuan", DBNull.Value);
            }
            else
            {
                obj[7] = new SqlParameter("Tuan", Tuan);
            }
            if (string.IsNullOrEmpty(Thang))
            {
                obj[8] = new SqlParameter("Thang", DBNull.Value);
            }
            else
            {
                obj[8] = new SqlParameter("Thang", Thang);
            }
            if (string.IsNullOrEmpty(q))
            {
                obj[9] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[9] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(TuNgay))
            {
                obj[10] = new SqlParameter("tungay", DBNull.Value);
            }
            else
            {
                obj[10] = new SqlParameter("tungay", TuNgay);
            }
            if (string.IsNullOrEmpty(DenNgay))
            {
                obj[11] = new SqlParameter("denngay", DBNull.Value);
            }
            else
            {
                obj[11] = new SqlParameter("denngay", DenNgay);
            }
            if (string.IsNullOrEmpty(DonVi))
            {
                obj[12] = new SqlParameter("donvi", DBNull.Value);
            }
            else
            {
                obj[12] = new SqlParameter("donvi", DonVi);
            }
            Pager<ToTrinh> pg = new Pager<ToTrinh>("sp_tblVanBanDi_TT_DPH_Pager_Normal_linhnx", "page", pagesize, 10, rewrite, url, obj);
            return pg;
        }
        public static ToTrinh SelectById(Int32 VBD_ID)
        {
            ToTrinh Item = new ToTrinh();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ToTrinh SelectMaxSoToTrinh(Int32 VBD_ID)
        {
            ToTrinh Item = new ToTrinh();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Select_MaxSoToTrinh_hungpm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        
        #endregion
        #region Utilities
        public static ToTrinh getFromReader(IDataReader rd)
        {
            ToTrinh Item = new ToTrinh();
            if (rd.FieldExists("VBD_ID"))
            {
                Item.ID = (Int32)(rd["VBD_ID"]);
            }
            if (rd.FieldExists("VBD_CapDo_ID"))
            {
                Item.CapDo_ID = (Int32)(rd["VBD_CapDo_ID"]);
            }
            if (rd.FieldExists("VBD_CapDo_Ten"))
            {
                Item.CapDo_Ten = (String)(rd["VBD_CapDo_Ten"]);
            }
            if (rd.FieldExists("VBD_LoaiVanBan_ID"))
            {
                Item.LoaiVanBan_ID = (Int32)(rd["VBD_LoaiVanBan_ID"]);
            }
            if (rd.FieldExists("VBD_LoaiVanBan_Ten"))
            {
                Item.LoaiVanBan_Ten = (String)(rd["VBD_LoaiVanBan_Ten"]);
            }
            if (rd.FieldExists("VBD_TrichYeu"))
            {
                Item.TrichYeu = (String)(rd["VBD_TrichYeu"]);
            }
            if (rd.FieldExists("VBD_DonViThao_ID"))
            {
                Item.DonViThao_ID = (Int32)(rd["VBD_DonViThao_ID"]);
            }
            if (rd.FieldExists("VBD_DonViThao_Ten"))
            {
                Item.DonViThao_Ten = (String)(rd["VBD_DonViThao_Ten"]);
            }
            
            if (rd.FieldExists("VBD_NguoiThao"))
            {
                Item.NguoiThao = (String)(rd["VBD_NguoiThao"]);
            }
            if (rd.FieldExists("VBD_NoiNhan_ID"))
            {
                Item.NoiNhan_ID = (Int32)(rd["VBD_NoiNhan_ID"]);
            }
            if (rd.FieldExists("VBD_NoiNhan_Ten"))
            {
                Item.NoiNhan_Ten = (String)(rd["VBD_NoiNhan_Ten"]);
            }
            if (rd.FieldExists("VBD_SoTrang"))
            {
                Item.SoTrang = (Int32)(rd["VBD_SoTrang"]);
            }
            if (rd.FieldExists("VBD_GhiChu"))
            {
                Item.GhiChu = (String)(rd["VBD_GhiChu"]);
            }
            if (rd.FieldExists("VBD_TrangThai"))
            {
                Item.TrangThai = (Byte)(rd["VBD_TrangThai"]);
            }
            if (rd.FieldExists("VBD_RowId"))
            {
                Item.RowId = (Guid)(rd["VBD_RowId"]);
            }
            if (rd.FieldExists("VBD_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["VBD_NguoiTao"]);
            }
            if (rd.FieldExists("VBD_NguoiSua"))
            {
                Item.NguoiSua = (String)(rd["VBD_NguoiSua"]);
            }
            if (rd.FieldExists("VBD_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["VBD_NgayTao"]);
            }
            if (rd.FieldExists("VBD_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["VBD_NgayCapNhat"]);
            }
            if (rd.FieldExists("VBD_TT_So"))
            {
                Item.TT_So = (Int32)(rd["VBD_TT_So"]);
            }
            if (rd.FieldExists("VBD_TT_NgayTrinh"))
            {
                Item.TT_NgayTrinh = (DateTime)(rd["VBD_TT_NgayTrinh"]);
            }
            if (rd.FieldExists("VBD_TT_LDVP_NgayTrinh"))
            {
                Item.TT_LDVP_NgayTrinh = (DateTime)(rd["VBD_TT_LDVP_NgayTrinh"]);
            }
            if (rd.FieldExists("VBD_TT_LDVP_YKien"))
            {
                Item.TT_LDVP_YKien = (String)(rd["VBD_TT_LDVP_YKien"]);
            }
            if (rd.FieldExists("VBD_TT_LDVP_NgayTraLai"))
            {
                Item.TT_LDVP_NgayTraLai = (DateTime)(rd["VBD_TT_LDVP_NgayTraLai"]);
            }
            if (rd.FieldExists("VBD_TT_LDVP_LyDoTraLai"))
            {
                Item.TT_LDVP_LyDo = (String)(rd["VBD_TT_LDVP_LyDoTraLai"]);
            }
            if (rd.FieldExists("VBD_TT_LDB_NgayTraLai"))
            {
                Item.TT_LDB_NgayTraLai = (DateTime)(rd["VBD_TT_LDB_NgayTraLai"]);
            }
            if (rd.FieldExists("VBD_TT_LDB_LyDoTraLai"))
            {
                Item.TT_LDB_LyDo = (String)(rd["VBD_TT_LDB_LyDoTraLai"]);
            }
            if (rd.FieldExists("VBD_TT_LDVP_ID"))
            {
                Item.TT_LDVP_ID = (Int32)(rd["VBD_TT_LDVP_ID"]);
            }
            if (rd.FieldExists("VBD_TT_LDVP_Username"))
            {
                Item.TT_LDVP_Username = (String)(rd["VBD_TT_LDVP_Username"]);
            }
            if (rd.FieldExists("VBD_TT_LDVP_Ten"))
            {
                Item.TT_LDVP_Ten = (String)(rd["VBD_TT_LDVP_Ten"]);
            }
            if (rd.FieldExists("VBD_TT_LDVP_Loai_Ten"))
            {
                Item.TT_LDVP_Loai_Ten = (String)(rd["VBD_TT_LDVP_Loai_Ten"]);
            }
            if (rd.FieldExists("VBD_TT_LDB_NgayTrinh"))
            {
                Item.TT_LDB_NgayTrinh = (DateTime)(rd["VBD_TT_LDB_NgayTrinh"]);
            }
            if (rd.FieldExists("VBD_TT_LDB_YKien"))
            {
                Item.TT_LDB_YKien = (String)(rd["VBD_TT_LDB_YKien"]);
            }
            if (rd.FieldExists("VBD_TT_LDB_ID"))
            {
                Item.TT_LDB_ID = (Int32)(rd["VBD_TT_LDB_ID"]);
            }
            if (rd.FieldExists("VBD_TT_LDB_Username"))
            {
                Item.TT_LDB_Username = (String)(rd["VBD_TT_LDB_Username"]);
            }
            if (rd.FieldExists("VBD_TT_LDB_Ten"))
            {
                Item.TT_LDB_Ten = (String)(rd["VBD_TT_LDB_Ten"]);
            }
            if (rd.FieldExists("VBD_TT_LDB_Loai_Ten"))
            {
                Item.TT_LDB_Loai_Ten = (String)(rd["VBD_TT_LDB_Loai_Ten"]);
            }
            if (rd.FieldExists("VBD_TT_LDB_NgayKy"))
            {
                Item.TT_LDB_NgayKy = (DateTime)(rd["VBD_TT_LDB_NgayKy"]);
            }
            if (rd.FieldExists("VBD_TT_NgayChuyenPhatHanh"))
            {
                Item.TT_NgayChuyenPhatHanh = (DateTime)(rd["VBD_TT_NgayChuyenPhatHanh"]);
            }
            if (rd.FieldExists("VBD_TT_NgayTrinh_Tuan"))
            {
                Item.NgayTrinh_Tuan = (String)(rd["VBD_TT_NgayTrinh_Tuan"]);
            }
            if (rd.FieldExists("VBD_TT_NgayTrinh_Thang"))
            {
                Item.NgayTrinh_Thang = (String)(rd["VBD_TT_NgayTrinh_Thang"]);
            }
            if (rd.FieldExists("VBD_TT_DonVi"))
            {
                Item.TT_DonVi = (String)(rd["VBD_TT_DonVi"]);
            }
            if (rd.FieldExists("VBD_TT_DonVi_So"))
            {
                Item.TT_DonVi_So = (Int32)(rd["VBD_TT_DonVi_So"]);
            }  
            return Item;
        }
        #endregion
        #region Extend
        public static void DeleteMultiById(String VBD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Delete_DeleteMultiById_hungpm", obj);
        }
        public static void ChuyenPhatHanhMultiById(String VBD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Update_ChuyenPhatHanhMultiById_hungpm", obj);
        }
        public static ToTrinh SelectByIdView(Int32 VBD_ID)
        {
            ToTrinh Item = new ToTrinh();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Select_SelectByIdView_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    Files item = new Files();
                    item.Ten = rd["F_Ten"].ToString();
                    item.ID = Convert.ToInt32(rd["F_ID"]);
                    item.NguoiTao = rd["F_NguoiTao"].ToString();
                    filelist.Add(item);
                }
            }
            Item.Filelist = filelist;
            return Item;
        }
        public static ToTrinh SelectDraffById(Int32 VBD_ID)
        {
            ToTrinh Item = new ToTrinh();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReaderDraff2(rd);
                }
            }
            return Item;
        }
        public static ToTrinh getFromReaderDraff2(IDataReader rd)
        {
            ToTrinh Item = new ToTrinh();
            Item.ID = (Int32)(rd["VBD_ID"]);
            Item.CapDo_ID = (Int32)(rd["VBD_CapDo_ID"]);
            Item.RowId = (Guid)(rd["VBD_RowId"]);
            Item.NguoiTao = (String)(rd["VBD_NguoiTao"]);
            Item.NguoiSua = (String)(rd["VBD_NguoiSua"]);
            Item.NgayTao = (DateTime)(rd["VBD_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["VBD_NgayCapNhat"]);
            return Item;
        }
        #endregion
    }
    #endregion
    #endregion
}
