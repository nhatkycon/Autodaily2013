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
using linh.common;
using System.Web;

namespace seo.entities
{
    #region ChienDich
    #region BO
    public class ChienDich : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public String Code { get; set; }
        public Int64 DM_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public Int64 KH_ID { get; set; }
        public Double Gia { get; set; }
        public Int32 SoLuong { get; set; }
        public Int32 PotThanhCong { get; set; }
        public String KeyWord { get; set; }
        public String TieuDe { get; set; }
        public String NoiDung { get; set; }
        public String NoiDung_Normal { get; set; }
        public String NoiDung_VBB { get; set; }
        public String NoiDung_BPP { get; set; }
        public String NoiDung_FCK { get; set; }
        public String LienLac { get; set; }
        public Boolean SingleUrl { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public Object NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean Active { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public Boolean KetThuc { get; set; }
        #endregion
        #region Contructor
        public ChienDich()
        { }
        public ChienDich(IDataReader rd)
        {
            if (rd.FieldExists("CD_ID"))
            {
                ID = (Int64)(rd["CD_ID"]);
            }
            if (rd.FieldExists("CD_Code"))
            {
                Code = (String)(rd["CD_Code"]);
            }
            if (rd.FieldExists("CD_DM_ID"))
            {
                DM_ID = (Int64)(rd["CD_DM_ID"]);
            }
            if (rd.FieldExists("CD_Ten"))
            {
                Ten = (String)(rd["CD_Ten"]);
            }
            if (rd.FieldExists("CD_MoTa"))
            {
                MoTa = (String)(rd["CD_MoTa"]);
            }
            if (rd.FieldExists("CD_KH_ID"))
            {
                KH_ID = (Int64)(rd["CD_KH_ID"]);
            }
            if (rd.FieldExists("CD_Gia"))
            {
                Gia = (Double)(rd["CD_Gia"]);
            }
            if (rd.FieldExists("CD_SoLuong"))
            {
                SoLuong = (Int32)(rd["CD_SoLuong"]);
            }
            if (rd.FieldExists("CD_PotThanhCong"))
            {
                PotThanhCong = (Int32)(rd["CD_PotThanhCong"]);
            }
            if (rd.FieldExists("CD_KeyWord"))
            {
                KeyWord = (String)(rd["CD_KeyWord"]);
            }
            if (rd.FieldExists("CD_TieuDe"))
            {
                TieuDe = (String)(rd["CD_TieuDe"]);
            }
            if (rd.FieldExists("CD_NoiDung"))
            {
                NoiDung = (String)(rd["CD_NoiDung"]);
            }
            if (rd.FieldExists("CD_NoiDung_Normal"))
            {
                NoiDung_Normal = (String)(rd["CD_NoiDung_Normal"]);
            }
            if (rd.FieldExists("CD_NoiDung_VBB"))
            {
                NoiDung_VBB = (String)(rd["CD_NoiDung_VBB"]);
            }
            if (rd.FieldExists("CD_NoiDung_BPP"))
            {
                NoiDung_BPP = (String)(rd["CD_NoiDung_BPP"]);
            }
            if (rd.FieldExists("CD_NoiDung_FCK"))
            {
                NoiDung_FCK = (String)(rd["CD_NoiDung_FCK"]);
            }
            if (rd.FieldExists("CD_LienLac"))
            {
                LienLac = (String)(rd["CD_LienLac"]);
            }
            if (rd.FieldExists("CD_SingleUrl"))
            {
                SingleUrl = (Boolean)(rd["CD_SingleUrl"]);
            }
            if (rd.FieldExists("CD_NgayTao"))
            {
                NgayTao = (DateTime)(rd["CD_NgayTao"]);
            }
            if (rd.FieldExists("CD_NguoiTao"))
            {
                NguoiTao = (String)(rd["CD_NguoiTao"]);
            }
            if (rd.FieldExists("CD_NgayCapNhat"))
            {
                NgayCapNhat = (Object)(rd["CD_NgayCapNhat"]);
            }
            if (rd.FieldExists("CD_NguoiCapNhat"))
            {
                NguoiCapNhat = (String)(rd["CD_NguoiCapNhat"]);
            }
            if (rd.FieldExists("CD_Active"))
            {
                Active = (Boolean)(rd["CD_Active"]);
            }
            if (rd.FieldExists("CD_RowId"))
            {
                RowId = (Guid)(rd["CD_RowId"]);
            }
            if (rd.FieldExists("CD_NgayBatDau"))
            {
                NgayBatDau = (DateTime)(rd["CD_NgayBatDau"]);
            }
            if (rd.FieldExists("CD_NgayKetThuc"))
            {
                NgayKetThuc = (DateTime)(rd["CD_NgayKetThuc"]);
            }
            if (rd.FieldExists("CD_KetThuc"))
            {
                KetThuc = (Boolean)(rd["CD_KetThuc"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                KH_Ten = (String)(rd["KH_Ten"]);
            }
        }
        #endregion
        #region Customs properties
        public string KH_Ten { get; set; }
        #endregion
        #region getFromReader
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return new ChienDich(rd);
        }
        public string format(int Loai)
        {
            StringBuilder sb = new StringBuilder();
            switch (Loai)
            {
                case 0:
                    #region 0 :
                    break;
                    #endregion
                case 1:
                    #region 1 :
                    break;
                    #endregion
                case 2:
                    #region 2 :
                    break;
                    #endregion
                case 3:
                    #region 3 :
                    break;
                    #endregion
                default:
                    #region mac dinh
                    break;
                    #endregion
            }
            return sb.ToString();
        }
        #endregion
    }
    #endregion
    #region Collection
    public class ChienDichCollection : BaseEntityCollection<ChienDich>
    { }
    #endregion
    #region Dal
    public class ChienDichDal
    {
        #region Methods

        public static void DeleteById(Int64 CD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CD_ID", CD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Delete_DeleteById_linhnx", obj);
        }
        public static ChienDich Insert(ChienDich Inserted)
        {
            ChienDich Item = new ChienDich();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("CD_Code", Inserted.Code);
            obj[1] = new SqlParameter("CD_DM_ID", Inserted.DM_ID);
            obj[2] = new SqlParameter("CD_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("CD_MoTa", Inserted.MoTa);
            obj[4] = new SqlParameter("CD_KH_ID", Inserted.KH_ID);
            obj[5] = new SqlParameter("CD_Gia", Inserted.Gia);
            obj[6] = new SqlParameter("CD_SoLuong", Inserted.SoLuong);
            obj[7] = new SqlParameter("CD_PotThanhCong", Inserted.PotThanhCong);
            obj[8] = new SqlParameter("CD_KeyWord", Inserted.KeyWord);
            obj[9] = new SqlParameter("CD_TieuDe", Inserted.TieuDe);
            obj[10] = new SqlParameter("CD_NoiDung", Inserted.NoiDung);
            obj[11] = new SqlParameter("CD_NoiDung_Normal", Inserted.NoiDung_Normal);
            obj[12] = new SqlParameter("CD_NoiDung_VBB", Inserted.NoiDung_VBB);
            obj[13] = new SqlParameter("CD_NoiDung_BPP", Inserted.NoiDung_BPP);
            obj[14] = new SqlParameter("CD_NoiDung_FCK", Inserted.NoiDung_FCK);
            obj[15] = new SqlParameter("CD_LienLac", Inserted.LienLac);
            obj[16] = new SqlParameter("CD_SingleUrl", Inserted.SingleUrl);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("CD_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[17] = new SqlParameter("CD_NgayTao", DBNull.Value);
            }
            obj[18] = new SqlParameter("CD_NguoiTao", Inserted.NguoiTao);
            obj[19] = new SqlParameter("CD_NgayCapNhat", Inserted.NgayCapNhat);
            obj[20] = new SqlParameter("CD_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[21] = new SqlParameter("CD_Active", Inserted.Active);
            obj[22] = new SqlParameter("CD_RowId", Inserted.RowId);
            if (Inserted.NgayBatDau > DateTime.MinValue)
            {
                obj[23] = new SqlParameter("CD_NgayBatDau", Inserted.NgayBatDau);
            }
            else
            {
                obj[23] = new SqlParameter("CD_NgayBatDau", DBNull.Value);
            }
            if (Inserted.NgayKetThuc > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("CD_NgayKetThuc", Inserted.NgayKetThuc);
            }
            else
            {
                obj[24] = new SqlParameter("CD_NgayKetThuc", DBNull.Value);
            }
            obj[25] = new SqlParameter("CD_KetThuc", Inserted.KetThuc);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ChienDich(rd);
                }
            }
            return Item;
        }
        public static ChienDich Insert(ChienDich Inserted, SqlConnection con)
        {
            ChienDich Item = new ChienDich();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("CD_Code", Inserted.Code);
            obj[1] = new SqlParameter("CD_DM_ID", Inserted.DM_ID);
            obj[2] = new SqlParameter("CD_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("CD_MoTa", Inserted.MoTa);
            obj[4] = new SqlParameter("CD_KH_ID", Inserted.KH_ID);
            obj[5] = new SqlParameter("CD_Gia", Inserted.Gia);
            obj[6] = new SqlParameter("CD_SoLuong", Inserted.SoLuong);
            obj[7] = new SqlParameter("CD_PotThanhCong", Inserted.PotThanhCong);
            obj[8] = new SqlParameter("CD_KeyWord", Inserted.KeyWord);
            obj[9] = new SqlParameter("CD_TieuDe", Inserted.TieuDe);
            obj[10] = new SqlParameter("CD_NoiDung", Inserted.NoiDung);
            obj[11] = new SqlParameter("CD_NoiDung_Normal", Inserted.NoiDung_Normal);
            obj[12] = new SqlParameter("CD_NoiDung_VBB", Inserted.NoiDung_VBB);
            obj[13] = new SqlParameter("CD_NoiDung_BPP", Inserted.NoiDung_BPP);
            obj[14] = new SqlParameter("CD_NoiDung_FCK", Inserted.NoiDung_FCK);
            obj[15] = new SqlParameter("CD_LienLac", Inserted.LienLac);
            obj[16] = new SqlParameter("CD_SingleUrl", Inserted.SingleUrl);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("CD_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[17] = new SqlParameter("CD_NgayTao", DBNull.Value);
            }
            obj[18] = new SqlParameter("CD_NguoiTao", Inserted.NguoiTao);
            obj[19] = new SqlParameter("CD_NgayCapNhat", Inserted.NgayCapNhat);
            obj[20] = new SqlParameter("CD_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[21] = new SqlParameter("CD_Active", Inserted.Active);
            obj[22] = new SqlParameter("CD_RowId", Inserted.RowId);
            if (Inserted.NgayBatDau > DateTime.MinValue)
            {
                obj[23] = new SqlParameter("CD_NgayBatDau", Inserted.NgayBatDau);
            }
            else
            {
                obj[23] = new SqlParameter("CD_NgayBatDau", DBNull.Value);
            }
            if (Inserted.NgayKetThuc > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("CD_NgayKetThuc", Inserted.NgayKetThuc);
            }
            else
            {
                obj[24] = new SqlParameter("CD_NgayKetThuc", DBNull.Value);
            }
            obj[25] = new SqlParameter("CD_KetThuc", Inserted.KetThuc);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ChienDich(rd);
                }
            }
            return Item;
        }
        public static ChienDich Update(ChienDich Updated)
        {
            ChienDich Item = new ChienDich();
            SqlParameter[] obj = new SqlParameter[27];
            obj[0] = new SqlParameter("CD_ID", Updated.ID);
            obj[1] = new SqlParameter("CD_Code", Updated.Code);
            obj[2] = new SqlParameter("CD_DM_ID", Updated.DM_ID);
            obj[3] = new SqlParameter("CD_Ten", Updated.Ten);
            obj[4] = new SqlParameter("CD_MoTa", Updated.MoTa);
            obj[5] = new SqlParameter("CD_KH_ID", Updated.KH_ID);
            obj[6] = new SqlParameter("CD_Gia", Updated.Gia);
            obj[7] = new SqlParameter("CD_SoLuong", Updated.SoLuong);
            obj[8] = new SqlParameter("CD_PotThanhCong", Updated.PotThanhCong);
            obj[9] = new SqlParameter("CD_KeyWord", Updated.KeyWord);
            obj[10] = new SqlParameter("CD_TieuDe", Updated.TieuDe);
            obj[11] = new SqlParameter("CD_NoiDung", Updated.NoiDung);
            obj[12] = new SqlParameter("CD_NoiDung_Normal", Updated.NoiDung_Normal);
            obj[13] = new SqlParameter("CD_NoiDung_VBB", Updated.NoiDung_VBB);
            obj[14] = new SqlParameter("CD_NoiDung_BPP", Updated.NoiDung_BPP);
            obj[15] = new SqlParameter("CD_NoiDung_FCK", Updated.NoiDung_FCK);
            obj[16] = new SqlParameter("CD_LienLac", Updated.LienLac);
            obj[17] = new SqlParameter("CD_SingleUrl", Updated.SingleUrl);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("CD_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[18] = new SqlParameter("CD_NgayTao", DBNull.Value);
            }
            obj[19] = new SqlParameter("CD_NguoiTao", Updated.NguoiTao);
            obj[20] = new SqlParameter("CD_NgayCapNhat", Updated.NgayCapNhat);
            obj[21] = new SqlParameter("CD_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[22] = new SqlParameter("CD_Active", Updated.Active);
            obj[23] = new SqlParameter("CD_RowId", Updated.RowId);
            if (Updated.NgayBatDau > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("CD_NgayBatDau", Updated.NgayBatDau);
            }
            else
            {
                obj[24] = new SqlParameter("CD_NgayBatDau", DBNull.Value);
            }
            if (Updated.NgayKetThuc > DateTime.MinValue)
            {
                obj[25] = new SqlParameter("CD_NgayKetThuc", Updated.NgayKetThuc);
            }
            else
            {
                obj[25] = new SqlParameter("CD_NgayKetThuc", DBNull.Value);
            }
            obj[26] = new SqlParameter("CD_KetThuc", Updated.KetThuc);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ChienDich(rd);
                }
            }
            return Item;
        }
        public static ChienDich Update(ChienDich Updated, SqlConnection con)
        {
            ChienDich Item = new ChienDich();
            SqlParameter[] obj = new SqlParameter[27];
            obj[0] = new SqlParameter("CD_ID", Updated.ID);
            obj[1] = new SqlParameter("CD_Code", Updated.Code);
            obj[2] = new SqlParameter("CD_DM_ID", Updated.DM_ID);
            obj[3] = new SqlParameter("CD_Ten", Updated.Ten);
            obj[4] = new SqlParameter("CD_MoTa", Updated.MoTa);
            obj[5] = new SqlParameter("CD_KH_ID", Updated.KH_ID);
            obj[6] = new SqlParameter("CD_Gia", Updated.Gia);
            obj[7] = new SqlParameter("CD_SoLuong", Updated.SoLuong);
            obj[8] = new SqlParameter("CD_PotThanhCong", Updated.PotThanhCong);
            obj[9] = new SqlParameter("CD_KeyWord", Updated.KeyWord);
            obj[10] = new SqlParameter("CD_TieuDe", Updated.TieuDe);
            obj[11] = new SqlParameter("CD_NoiDung", Updated.NoiDung);
            obj[12] = new SqlParameter("CD_NoiDung_Normal", Updated.NoiDung_Normal);
            obj[13] = new SqlParameter("CD_NoiDung_VBB", Updated.NoiDung_VBB);
            obj[14] = new SqlParameter("CD_NoiDung_BPP", Updated.NoiDung_BPP);
            obj[15] = new SqlParameter("CD_NoiDung_FCK", Updated.NoiDung_FCK);
            obj[16] = new SqlParameter("CD_LienLac", Updated.LienLac);
            obj[17] = new SqlParameter("CD_SingleUrl", Updated.SingleUrl);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("CD_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[18] = new SqlParameter("CD_NgayTao", DBNull.Value);
            }
            obj[19] = new SqlParameter("CD_NguoiTao", Updated.NguoiTao);
            obj[20] = new SqlParameter("CD_NgayCapNhat", Updated.NgayCapNhat);
            obj[21] = new SqlParameter("CD_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[22] = new SqlParameter("CD_Active", Updated.Active);
            obj[23] = new SqlParameter("CD_RowId", Updated.RowId);
            if (Updated.NgayBatDau > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("CD_NgayBatDau", Updated.NgayBatDau);
            }
            else
            {
                obj[24] = new SqlParameter("CD_NgayBatDau", DBNull.Value);
            }
            if (Updated.NgayKetThuc > DateTime.MinValue)
            {
                obj[25] = new SqlParameter("CD_NgayKetThuc", Updated.NgayKetThuc);
            }
            else
            {
                obj[25] = new SqlParameter("CD_NgayKetThuc", DBNull.Value);
            }
            obj[26] = new SqlParameter("CD_KetThuc", Updated.KetThuc);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ChienDich(rd);
                }
            }
            return Item;
        }
        public static ChienDich SelectById(Int64 CD_ID)
        {
            ChienDich Item = new ChienDich();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CD_ID", CD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ChienDich(rd);
                }
            }
            return Item;
        }
        public static ChienDich SelectById(Int64 CD_ID, SqlConnection con)
        {
            ChienDich Item = new ChienDich();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CD_ID", CD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ChienDich(rd);
                }
            }
            return Item;
        }
        public static ChienDich SelectById(Int64 CD_ID, SqlTransaction con)
        {
            ChienDich Item = new ChienDich();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CD_ID", CD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ChienDich(rd);
                }
            }
            return Item;
        }
        public static ChienDichCollection SelectAll()
        {
            ChienDichCollection List = new ChienDichCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new ChienDich(rd));
                }
            }
            return List;
        }
        public static ChienDichCollection SelectAll(SqlConnection con)
        {
            ChienDichCollection List = new ChienDichCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new ChienDich(rd));
                }
            }
            return List;
        }
        public static Pager<ChienDich> pagerNormal(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<ChienDich> pg = new Pager<ChienDich>("tblSeo_sp_tblChienDich_Pager_Normal_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<ChienDich> pagerNormal(SqlConnection con, string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<ChienDich> pg = new Pager<ChienDich>(con, "tblSeo_sp_tblChienDich_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        #endregion
        #region Extend
        public static ChienDichCollection SelectByUser(string Username, int Top)
        {
            ChienDichCollection List = new ChienDichCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Select_SelectByUser_linhnx",obj))
            {
                while (rd.Read())
                {
                    List.Add(new ChienDich(rd));
                }
            }
            return List;
        }
        public static Pager<ChienDich> pagerQtriAll(string sort, int size, string q)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {

                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            Pager<ChienDich> pg = new Pager<ChienDich>("tblSeo_sp_tblChienDich_Pager_pagerQtriAll_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<ChienDich> pagerQtriChuaDuyet(string sort, int size, string q)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {

                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            Pager<ChienDich> pg = new Pager<ChienDich>("tblSeo_sp_tblChienDich_Pager_pagerQtriChuaDuyet_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<ChienDich> pagerQtriDuyetChuaKetThuc(string sort, int size, string q)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {

                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            Pager<ChienDich> pg = new Pager<ChienDich>("tblSeo_sp_tblChienDich_Pager_pagerQtriDuyetChuaKetThuc_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static void UpdatePotThanhCong(long ID,int PotThanhCong, SqlTransaction con)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("CD_ID", ID);
            obj[1] = new SqlParameter("CD_PotThanhCong", PotThanhCong);
            obj[2] = new SqlParameter("CD_NgayCapNhat", DateTime.Now);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Update_UpdatePotThanhCong_linhnx", obj);
        }

        public static Pager<ChienDich> pagerQtriUserChuaDuyet(string sort, string Username, int size, string q)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {

                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            obj[2] = new SqlParameter("Username", Username);
            Pager<ChienDich> pg = new Pager<ChienDich>("tblSeo_sp_tblChienDich_Pager_pagerQtriUserChuaDuyet_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<ChienDich> pagerQtriUserDangChay(string sort, string Username, int size, string q)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {

                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            obj[2] = new SqlParameter("Username", Username);
            Pager<ChienDich> pg = new Pager<ChienDich>("tblSeo_sp_tblChienDich_Pager_pagerQtriUserDangChay_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<ChienDich> pagerQtriUserKetThuc(string sort, string Username, int size, string q)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {

                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            obj[2] = new SqlParameter("Username", Username);
            Pager<ChienDich> pg = new Pager<ChienDich>("tblSeo_sp_tblChienDich_Pager_pagerQtriUserKetThuc_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static void UpdateKetThuc(Int64 CD_ID, string CD_KetThuc)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("CD_ID", CD_ID);
            obj[1] = new SqlParameter("CD_KetThuc", CD_KetThuc);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoChienDich_Update_UpdateKetThuc_linhnx", obj);
        }
        #endregion
    }
    #endregion
    #endregion
}


