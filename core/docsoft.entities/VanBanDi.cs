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
    #region VanBanDi
    #region BO
    public class VanBanDi : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 CapDo_ID { get; set; }
        public String CapDo_Ten { get; set; }
        public Int32 LoaiVanBan_ID { get; set; }
        public String LoaiVanBan_Ten { get; set; }
        public String SoKyHieuSo { get; set; }
        public String SoKyHieuChu { get; set; }
        public DateTime NgayVanBan { get; set; }
        public String TrichYeu { get; set; }
        public Int32 DonViThao_ID { get; set; }
        public String DonViThao_Ten { get; set; }
        public DateTime HanTraLoi { get; set; }
        public String NguoiThao { get; set; }
        public Int32 NoiNhan_ID { get; set; }
        public String NoiNhan_Ten { get; set; }
        public Int32 MEM_ID { get; set; }
        public String MEM_Ten { get; set; }
        public Int32 MEM_Loai { get; set; }
        public String MEM_Loai_Ten { get; set; }
        public Int32 SoTrang { get; set; }
        public String GhiChu { get; set; }
        public Byte TrangThai { get; set; }
        public Boolean VaoSo { get; set; }
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
        public DateTime TT_LDB_NgayTrinh { get; set; }
        public String TT_LDB_YKien { get; set; }
        public Int32 TT_LDB_ID { get; set; }
        public String TT_LDB_Username { get; set; }
        public String TT_LDB_Ten { get; set; }
        public String TT_LDB_Loai_Ten { get; set; }
        public DateTime TT_LDB_NgayKy { get; set; }
        public DateTime TT_NgayChuyenPhatHanh { get; set; }
        public String TT_LyDoTraLai { get; set; }
        public DateTime TT_NgayTraLai { get; set; }
        public Int32 TT_DonVi_So { get; set; }
        #endregion
        #region Contructor
        public VanBanDi()
        { }
        #endregion
        #region Customs properties
        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }
        public string NgayVanBan_Tuan { get; set; }
        public string NgayVanBan_Thang { get; set; }
        public string HanTraLoiX { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return VanBanDiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class VanBanDiCollection : BaseEntityCollection<VanBanDi>
    { }
    #endregion
    #region Dal
    public class VanBanDiDal
    {
        #region Methods

        public static void DeleteById(Int32 VBD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Delete_DeleteById_linhnx", obj);
        }

        public static VanBanDi Insert(VanBanDi Inserted)
        {
            VanBanDi Item = new VanBanDi();
            SqlParameter[] obj = new SqlParameter[27];
            obj[0] = new SqlParameter("VBD_CapDo_ID", Inserted.CapDo_ID);
            obj[1] = new SqlParameter("VBD_CapDo_Ten", Inserted.CapDo_Ten);
            obj[2] = new SqlParameter("VBD_LoaiVanBan_ID", Inserted.LoaiVanBan_ID);
            obj[3] = new SqlParameter("VBD_LoaiVanBan_Ten", Inserted.LoaiVanBan_Ten);
            obj[4] = new SqlParameter("VBD_SoKyHieuSo", Inserted.SoKyHieuSo);
            obj[5] = new SqlParameter("VBD_SoKyHieuChu", Inserted.SoKyHieuChu);
            obj[6] = new SqlParameter("VBD_NgayVanBan", Inserted.NgayVanBan);
            obj[7] = new SqlParameter("VBD_TrichYeu", Inserted.TrichYeu);
            obj[8] = new SqlParameter("VBD_DonViThao_ID", Inserted.DonViThao_ID);
            obj[9] = new SqlParameter("VBD_DonViThao_Ten", Inserted.DonViThao_Ten);
            obj[10] = new SqlParameter("VBD_HanTraLoi", Inserted.HanTraLoi);
            obj[11] = new SqlParameter("VBD_NguoiThao", Inserted.NguoiThao);
            obj[12] = new SqlParameter("VBD_NoiNhan_ID", Inserted.NoiNhan_ID);
            obj[13] = new SqlParameter("VBD_NoiNhan_Ten", Inserted.NoiNhan_Ten);
            obj[14] = new SqlParameter("VBD_MEM_ID", Inserted.MEM_ID);
            obj[15] = new SqlParameter("VBD_MEM_Ten", Inserted.MEM_Ten);
            obj[16] = new SqlParameter("VBD_MEM_Loai", Inserted.MEM_Loai);
            obj[17] = new SqlParameter("VBD_SoTrang", Inserted.SoTrang);
            obj[18] = new SqlParameter("VBD_GhiChu", Inserted.GhiChu);
            obj[20] = new SqlParameter("VBD_VaoSo", Inserted.VaoSo);
            obj[21] = new SqlParameter("VBD_RowId", Inserted.RowId);
            obj[22] = new SqlParameter("VBD_NguoiTao", Inserted.NguoiTao);
            obj[23] = new SqlParameter("VBD_NguoiSua", Inserted.NguoiSua);
            obj[24] = new SqlParameter("VBD_NgayTao", Inserted.NgayTao);
            obj[25] = new SqlParameter("VBD_NgayCapNhat", Inserted.NgayCapNhat);
            obj[26] = new SqlParameter("VBD_MEM_Loai_Ten", Inserted.MEM_Loai_Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VanBanDi Update(VanBanDi Updated)
        {
            VanBanDi Item = new VanBanDi();
            SqlParameter[] obj = new SqlParameter[28];
            obj[0] = new SqlParameter("VBD_ID", Updated.ID);
            obj[1] = new SqlParameter("VBD_CapDo_ID", Updated.CapDo_ID);
            obj[2] = new SqlParameter("VBD_CapDo_Ten", Updated.CapDo_Ten);
            obj[3] = new SqlParameter("VBD_LoaiVanBan_ID", Updated.LoaiVanBan_ID);
            obj[4] = new SqlParameter("VBD_LoaiVanBan_Ten", Updated.LoaiVanBan_Ten);
            obj[5] = new SqlParameter("VBD_SoKyHieuSo", Updated.SoKyHieuSo);
            obj[6] = new SqlParameter("VBD_SoKyHieuChu", Updated.SoKyHieuChu);
            string htl = string.Format("{0:dd/MM/yy}", Updated.NgayVanBan);
            if (htl != "01/01/01")
            {
                obj[7] = new SqlParameter("VBD_NgayVanBan", Updated.NgayVanBan);
            }
            else
            {
                obj[7] = new SqlParameter("VBD_NgayVanBan", Updated.NgayVanBan);
            }
            obj[8] = new SqlParameter("VBD_TrichYeu", Updated.TrichYeu);
            obj[9] = new SqlParameter("VBD_DonViThao_ID", Updated.DonViThao_ID);
            obj[10] = new SqlParameter("VBD_DonViThao_Ten", Updated.DonViThao_Ten);
            obj[11] = new SqlParameter("VBD_TrangThai", Updated.TrangThai);
            obj[12] = new SqlParameter("VBD_NguoiThao", Updated.NguoiThao);
            obj[13] = new SqlParameter("VBD_NoiNhan_ID", Updated.NoiNhan_ID);
            obj[14] = new SqlParameter("VBD_NoiNhan_Ten", Updated.NoiNhan_Ten);
            obj[15] = new SqlParameter("VBD_MEM_ID", Updated.MEM_ID);
            obj[16] = new SqlParameter("VBD_MEM_Ten", Updated.MEM_Ten);
            obj[17] = new SqlParameter("VBD_MEM_Loai", Updated.MEM_Loai);
            obj[18] = new SqlParameter("VBD_SoTrang", Updated.SoTrang);
            obj[19] = new SqlParameter("VBD_GhiChu", Updated.GhiChu);
            obj[21] = new SqlParameter("VBD_VaoSo", Updated.VaoSo);
            obj[22] = new SqlParameter("VBD_RowId", Updated.RowId);
            obj[23] = new SqlParameter("VBD_NguoiTao", Updated.NguoiTao);
            obj[24] = new SqlParameter("VBD_NguoiSua", Updated.NguoiSua);
            obj[25] = new SqlParameter("VBD_NgayTao", Updated.NgayTao);
            obj[26] = new SqlParameter("VBD_NgayCapNhat", Updated.NgayCapNhat);
            obj[27] = new SqlParameter("VBD_MEM_Loai_Ten", Updated.MEM_Loai_Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VanBanDi SelectById(Int32 VBD_ID)
        {
            VanBanDi Item = new VanBanDi();
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
        public static VanBanDiCollection SelectAll()
        {
            VanBanDiCollection List = new VanBanDiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<VanBanDi> pagerNormal(string url, bool rewrite, string sort,int pagesize
            , string VBD_CapDo_Id
            ,string VBD_PhatHanh
            , string VBD_LoaiVanBan_ID
            , string VBD_DonViThao_ID
            , string VBD_MEM_ID
            , string Ngay
            , string Tuan
            , string Thang
            ,string q
            ,string tungay
            ,string denngay
            ,string trangthai)
        {
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(VBD_CapDo_Id))
            {
                obj[1] = new SqlParameter("VBD_CapDo_Id", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("VBD_CapDo_Id", VBD_CapDo_Id);
            }
            if (string.IsNullOrEmpty(VBD_PhatHanh))
            {
                obj[2] = new SqlParameter("VBD_PhatHanh", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("VBD_PhatHanh", VBD_PhatHanh);
            }
            if (string.IsNullOrEmpty(VBD_LoaiVanBan_ID))
            {
                obj[3] = new SqlParameter("VBD_LoaiVanBan_ID", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("VBD_LoaiVanBan_ID", VBD_LoaiVanBan_ID);
            }
            if (string.IsNullOrEmpty(VBD_DonViThao_ID))
            {
                obj[4] = new SqlParameter("VBD_DonViThao_ID", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("VBD_DonViThao_ID", VBD_DonViThao_ID);
            }
            if (string.IsNullOrEmpty(VBD_MEM_ID))
            {
                obj[5] = new SqlParameter("VBD_MEM_ID", DBNull.Value);
            }
            else
            {
                obj[5] = new SqlParameter("VBD_MEM_ID", VBD_MEM_ID);
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
            if (string.IsNullOrEmpty(tungay))
            {
                obj[10] = new SqlParameter("tungay", DBNull.Value);
            }
            else
            {
                obj[10] = new SqlParameter("tungay", tungay);
            }
            if (string.IsNullOrEmpty(denngay))
            {
                obj[11] = new SqlParameter("denngay", DBNull.Value);
            }
            else
            {
                obj[11] = new SqlParameter("denngay", denngay);
            }
            if (string.IsNullOrEmpty(trangthai))
            {
                obj[12] = new SqlParameter("trangthai", DBNull.Value);
            }
            else
            {
                obj[12] = new SqlParameter("trangthai", trangthai);
            }
            Pager<VanBanDi> pg = new Pager<VanBanDi>("sp_tblVanBanDi_Pager_Normal_linhnx", "page", pagesize, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static VanBanDi getFromReader(IDataReader rd)
        {
            VanBanDi Item = new VanBanDi();
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
            if (rd.FieldExists("VBD_SoKyHieuSo"))
            {
                Item.SoKyHieuSo = (String)(rd["VBD_SoKyHieuSo"]);
            }
            if (rd.FieldExists("VBD_SoKyHieuChu"))
            {
                Item.SoKyHieuChu = (String)(rd["VBD_SoKyHieuChu"]);
            }
            if (rd.FieldExists("VBD_NgayVanBan"))
            {
                Item.NgayVanBan = (DateTime)(rd["VBD_NgayVanBan"]);
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
            if (rd.FieldExists("VBD_HanTraLoi"))
            {
                Item.HanTraLoi = (DateTime)(rd["VBD_HanTraLoi"]);
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
            if (rd.FieldExists("VBD_MEM_ID"))
            {
                Item.MEM_ID = (Int32)(rd["VBD_MEM_ID"]);
            }
            if (rd.FieldExists("VBD_MEM_Ten"))
            {
                Item.MEM_Ten = (String)(rd["VBD_MEM_Ten"]);
            }
            if (rd.FieldExists("VBD_MEM_Loai"))
            {
                Item.MEM_Loai = (Int32)(rd["VBD_MEM_Loai"]);
            }
            if (rd.FieldExists("VBD_MEM_Loai_Ten"))
            {
                Item.MEM_Loai_Ten = (String)(rd["VBD_MEM_Loai_Ten"]);
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
            if (rd.FieldExists("VBD_VaoSo"))
            {
                Item.VaoSo = (Boolean)(rd["VBD_VaoSo"]);
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
            if (rd.FieldExists("VBD_TT_LyDoTraLai"))
            {
                Item.TT_LyDoTraLai = (String)(rd["VBD_TT_LyDoTraLai"]);
            }
            if (rd.FieldExists("VBD_TT_NgayTraLai"))
            {
                Item.TT_NgayTraLai = (DateTime)(rd["VBD_TT_NgayTraLai"]);
            }
            if (rd.FieldExists("VBD_NgayVanBan_Tuan"))
            {
                Item.NgayVanBan_Tuan = (String)(rd["VBD_NgayVanBan_Tuan"]);
            }
            if (rd.FieldExists("VBD_NgayVanBan_Thang"))
            {
                Item.NgayVanBan_Thang = (String)(rd["VBD_NgayVanBan_Thang"]);
            }
            return Item;             
        }
        #endregion                                 
        #region Extend
        public static VanBanDiCollection GetVanBanChuaPhatHanh(string sort, int numRow, string UserName)
        {
            VanBanDiCollection List = new VanBanDiCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("Top", numRow);
            obj[2] = new SqlParameter("Username", UserName);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Select_Desktop_hungpm", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static void DeleteMultiById(String VBD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Delete_DeleteMultiById_hungpm", obj);
        }
        public static void PhatHanhMultiById(String VBD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_ID", VBD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Delete_PhatHanhMultiById_hungpm", obj);
        }
        public static VanBanDi InsertDraff(VanBanDi Inserted)
        {
            VanBanDi Item = new VanBanDi();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("VBD_RowId", Inserted.RowId);
            obj[1] = new SqlParameter("VBD_NguoiTao", Inserted.NguoiTao);
            obj[2] = new SqlParameter("VBD_NguoiSua", Inserted.NguoiSua);
            obj[3] = new SqlParameter("VBD_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("VBD_NgayCapNhat", Inserted.NgayCapNhat);
            obj[5] = new SqlParameter("VBD_TT_So", Inserted.TT_So);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Insert_InsertDraff_hungpm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReaderDraff(rd);
                }
            }
            return Item;
        }
        public static VanBanDi SelectDraffById(Int32 VBD_ID)
        {
            VanBanDi Item = new VanBanDi();
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
        public static VanBanDi getFromReaderDraff2(IDataReader rd)
        {
            VanBanDi Item = new VanBanDi();
            Item.ID = (Int32)(rd["VBD_ID"]);
            Item.CapDo_ID = (Int32)(rd["VBD_CapDo_ID"]);
            Item.RowId = (Guid)(rd["VBD_RowId"]);
            Item.NguoiTao = (String)(rd["VBD_NguoiTao"]);
            Item.NguoiSua = (String)(rd["VBD_NguoiSua"]);
            Item.NgayTao = (DateTime)(rd["VBD_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["VBD_NgayCapNhat"]);
            return Item;
        }
        public static VanBanDi getFromReaderTiny(IDataReader rd)
        {
             VanBanDi Item = new VanBanDi();
            Item.ID = (Int32)(rd["VBD_ID"]);
            Item.SoKyHieuSo = (String)(rd["VBD_SoKyHieuSo"]);
            Item.SoKyHieuChu = (String)(rd["VBD_SoKyHieuChu"]);
            Item.NgayVanBan = (DateTime)(rd["VBD_NgayVanBan"]);
            Item.LoaiVanBan_Ten = (String)(rd["VBD_LoaiVanBan_Ten"]);
            Item.MEM_Ten = (String)(rd["VBD_MEM_Ten"]);
            return Item;
        }
        public static VanBanDi getFromReaderDraff(IDataReader rd)
        {
            VanBanDi Item = new VanBanDi();
            Item.ID = (Int32)(rd["VBD_ID"]);
            Item.CapDo_ID = (Int32)(rd["VBD_CapDo_ID"]);
            Item.RowId = (Guid)(rd["VBD_RowId"]);
            Item.NguoiTao = (String)(rd["VBD_NguoiTao"]);
            Item.NguoiSua = (String)(rd["VBD_NguoiSua"]);
            Item.NgayTao = (DateTime)(rd["VBD_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["VBD_NgayCapNhat"]);
            Item.TT_So = (Int32)(rd["VBD_TT_So"]);
            if (rd.FieldExists("VBD_TT_DonVi_So"))
            {
                Item.TT_DonVi_So = (Int32)(rd["VBD_TT_DonVi_So"]);
            }
            return Item;
        }
        public static VanBanDi getFromReaderPager(IDataReader rd)
        {
            VanBanDi Item = new VanBanDi();
            Item.ID = (Int32)(rd["VBD_ID"]);
            Item.CapDo_Ten = (String)(rd["VBD_CapDo_Ten"]);
            Item.LoaiVanBan_Ten = (String)(rd["VBD_LoaiVanBan_Ten"]);
            Item.SoKyHieuSo = (String)(rd["VBD_SoKyHieuSo"]);
            Item.SoKyHieuChu = (String)(rd["VBD_SoKyHieuChu"]);
            Item.NgayVanBan = (DateTime)(rd["VBD_NgayVanBan"]);
            Item.TrichYeu = (String)(rd["VBD_TrichYeu"]);
            Item.DonViThao_Ten = (String)(rd["VBD_DonViThao_Ten"]);
            Item.NguoiThao = (String)(rd["VBD_NguoiThao"]);
            Item.NoiNhan_Ten = (String)(rd["VBD_NoiNhan_Ten"]);
            Item.MEM_Ten = (String)(rd["VBD_MEM_Ten"]);
            Item.RowId = (Guid)(rd["VBD_RowId"]);
            Item.TrangThai = (byte)(rd["VBD_TrangThai"]);
            Item.NgayVanBan_Thang = (String)(rd["VBD_NgayVanBan_Thang"]);
            Item.NgayVanBan_Tuan = (String)(rd["VBD_NgayVanBan_Tuan"]);
            return Item;
        }
        public static VanBanDi SelectByIdView(Int32 VBD_ID)
        {
            VanBanDi Item = new VanBanDi();
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
        public static string SelectMaxKyHieuSoByCapDo(String VBD_CapDo_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBD_CapDo_ID", VBD_CapDo_ID);
            return SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Select_MaxKyHieuSoByCapDo_linhnx", obj).ToString();
        }
        public static VanBanDiCollection SelectTTSo()
        {
            VanBanDiCollection List = new VanBanDiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanDi_Select_TTSo_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion
    #endregion
}
