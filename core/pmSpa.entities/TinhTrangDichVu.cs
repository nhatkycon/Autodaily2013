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
    #region TinhTrangDichVu
    #region BO
    public class TinhTrangDichVu : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid DM_ID { get; set; }
        public String DM_Ten { get; set; }
        public Guid DV_ID { get; set; }
        public String DV_Ten { get; set; }
        public Int32 SoLuong { get; set; }
        public Int32 ThuTu { get; set; }
        public String MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        #endregion
        #region Contructor
        public TinhTrangDichVu()
        { }
        #endregion
        #region Customs properties
        public int ThoiGian { get; set; }
        public int Gia { get; set; }
        public DichVu dvu { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinhTrangDichVuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinhTrangDichVuCollection : BaseEntityCollection<TinhTrangDichVu>
    { }
    #endregion
    #region Dal
    public class TinhTrangDichVuDal
    {
        #region Methods

        public static void DeleteById(Guid TTDV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TTDV_ID", TTDV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TinhTrangDichVu_Delete_DeleteById_linhnx", obj);
        }

        public static TinhTrangDichVu Insert(TinhTrangDichVu item)
        {
            var Item = new TinhTrangDichVu();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("TTDV_ID", item.ID);
            obj[1] = new SqlParameter("TTDV_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("TTDV_DM_Ten", item.DM_Ten);
            obj[3] = new SqlParameter("TTDV_DV_ID", item.DV_ID);
            obj[4] = new SqlParameter("TTDV_DV_Ten", item.DV_Ten);
            obj[5] = new SqlParameter("TTDV_SoLuong", item.SoLuong);
            obj[6] = new SqlParameter("TTDV_ThuTu", item.ThuTu);
            obj[7] = new SqlParameter("TTDV_MoTa", item.MoTa);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TTDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("TTDV_NgayTao", DBNull.Value);
            }
            obj[9] = new SqlParameter("TTDV_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("TTDV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[10] = new SqlParameter("TTDV_NgayCapNhat", DBNull.Value);
            }
            obj[11] = new SqlParameter("TTDV_NguoiCapNhat", item.NguoiCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TinhTrangDichVu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinhTrangDichVu Update(TinhTrangDichVu item)
        {
            var Item = new TinhTrangDichVu();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("TTDV_ID", item.ID);
            obj[1] = new SqlParameter("TTDV_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("TTDV_DM_Ten", item.DM_Ten);
            obj[3] = new SqlParameter("TTDV_DV_ID", item.DV_ID);
            obj[4] = new SqlParameter("TTDV_DV_Ten", item.DV_Ten);
            obj[5] = new SqlParameter("TTDV_SoLuong", item.SoLuong);
            obj[6] = new SqlParameter("TTDV_ThuTu", item.ThuTu);
            obj[7] = new SqlParameter("TTDV_MoTa", item.MoTa);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TTDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("TTDV_NgayTao", DBNull.Value);
            }
            obj[9] = new SqlParameter("TTDV_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("TTDV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[10] = new SqlParameter("TTDV_NgayCapNhat", DBNull.Value);
            }
            obj[11] = new SqlParameter("TTDV_NguoiCapNhat", item.NguoiCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TinhTrangDichVu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinhTrangDichVu SelectById(Guid TTDV_ID)
        {
            var Item = new TinhTrangDichVu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TTDV_ID", TTDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TinhTrangDichVu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinhTrangDichVuCollection SelectAll()
        {
            var List = new TinhTrangDichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TinhTrangDichVu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TinhTrangDichVu> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<TinhTrangDichVu>("sp_tblSpaMgr_TinhTrangDichVu_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TinhTrangDichVu getFromReader(IDataReader rd)
        {
            var Item = new TinhTrangDichVu();
            if (rd.FieldExists("TTDV_ID"))
            {
                Item.ID = (Guid)(rd["TTDV_ID"]);
            }
            if (rd.FieldExists("TTDV_DM_ID"))
            {
                Item.DM_ID = (Guid)(rd["TTDV_DM_ID"]);
            }
            if (rd.FieldExists("TTDV_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["TTDV_DM_Ten"]);
            }
            if (rd.FieldExists("TTDV_DV_ID"))
            {
                Item.DV_ID = (Guid)(rd["TTDV_DV_ID"]);
            }
            if (rd.FieldExists("TTDV_DV_Ten"))
            {
                Item.DV_Ten = (String)(rd["TTDV_DV_Ten"]);
            }
            if (rd.FieldExists("TTDV_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["TTDV_SoLuong"]);
            }
            if (rd.FieldExists("TTDV_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TTDV_ThuTu"]);
            }
            if (rd.FieldExists("TTDV_MoTa"))
            {
                Item.MoTa = (String)(rd["TTDV_MoTa"]);
            }
            if (rd.FieldExists("TTDV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TTDV_NgayTao"]);
            }
            if (rd.FieldExists("TTDV_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TTDV_NguoiTao"]);
            }
            if (rd.FieldExists("TTDV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TTDV_NgayCapNhat"]);
            }
            if (rd.FieldExists("TTDV_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TTDV_NguoiCapNhat"]);
            }
            if (rd.FieldExists("DV_ThoiGian"))
            {
                Item.ThoiGian = (Int32)(rd["DV_ThoiGian"]);
            }
            if (rd.FieldExists("DV_Gia"))
            {
                Item.Gia = (Int32)(rd["DV_Gia"]);
            }
            Item.dvu = DichVuDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static TinhTrangDichVuCollection SelectDmId(string DM_ID)
        {
            var List = new TinhTrangDichVuCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[0] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TinhTrangDichVu_Select_SelectDmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinhTrangDichVuCollection SelectDmId(SqlConnection con, string DM_ID)
        {
            var List = new TinhTrangDichVuCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[0] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_TinhTrangDichVu_Select_SelectDmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinhTrangDichVuCollection SelectByTvId(string TV_ID)
        {
            var List = new TinhTrangDichVuCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(TV_ID))
            {
                obj[0] = new SqlParameter("TV_ID", TV_ID);
            }
            else
            {
                obj[0] = new SqlParameter("TV_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TinhTrangDichVu_Select_SelectByTvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinhTrangDichVuCollection SelectByTvId(SqlConnection con, string TV_ID)
        {
            var List = new TinhTrangDichVuCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(TV_ID))
            {
                obj[0] = new SqlParameter("TV_ID", TV_ID);
            }
            else
            {
                obj[0] = new SqlParameter("TV_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_TinhTrangDichVu_Select_SelectByTvId_linhnx", obj))
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
