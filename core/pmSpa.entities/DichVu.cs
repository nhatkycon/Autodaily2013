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
    #region DichVu
    #region BO
    public class DichVu : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid SPA_ID { get; set; }
        public Guid DM_ID { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String MoTa { get; set; }
        public String GhiChu { get; set; }
        public String NoiDung { get; set; }
        public String ThaoTac { get; set; }
        public String Anh { get; set; }
        public Int32 Gia { get; set; }
        public Int32 ThoiGian { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean Active { get; set; }
        public Boolean KhuyenMai { get; set; }
        public Int32 SoLan { get; set; }
        #endregion
        #region Contructor
        public DichVu()
        { }
        #endregion
        #region Customs properties
        public String DM_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DichVuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DichVuCollection : BaseEntityCollection<DichVu>
    { }
    #endregion
    #region Dal
    public class DichVuDal
    {
        #region Methods

        public static void DeleteById(Guid DV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DV_ID", DV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVu_Delete_DeleteById_linhnx", obj);
        }

        public static DichVu Insert(DichVu item)
        {
            var Item = new DichVu();
            var obj = new SqlParameter[19];
            obj[0] = new SqlParameter("DV_ID", item.ID);
            obj[1] = new SqlParameter("DV_SPA_ID", item.SPA_ID);
            obj[2] = new SqlParameter("DV_DM_ID", item.DM_ID);
            obj[3] = new SqlParameter("DV_Ten", item.Ten);
            obj[4] = new SqlParameter("DV_Ma", item.Ma);
            obj[5] = new SqlParameter("DV_MoTa", item.MoTa);
            obj[6] = new SqlParameter("DV_GhiChu", item.GhiChu);
            obj[7] = new SqlParameter("DV_NoiDung", item.NoiDung);
            obj[8] = new SqlParameter("DV_ThaoTac", item.ThaoTac);
            obj[9] = new SqlParameter("DV_Anh", item.Anh);
            obj[10] = new SqlParameter("DV_Gia", item.Gia);
            obj[11] = new SqlParameter("DV_ThoiGian", item.ThoiGian);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("DV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("DV_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("DV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("DV_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("DV_NguoiTao", item.NguoiTao);
            obj[15] = new SqlParameter("DV_NguoiCapNhat", item.NguoiCapNhat);
            obj[16] = new SqlParameter("DV_Active", item.Active);
            obj[17] = new SqlParameter("DV_KhuyenMai", item.KhuyenMai);
            obj[18] = new SqlParameter("DV_SoLan", item.SoLan);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DichVu Update(DichVu item)
        {
            var Item = new DichVu();
            var obj = new SqlParameter[19];
            obj[0] = new SqlParameter("DV_ID", item.ID);
            obj[1] = new SqlParameter("DV_SPA_ID", item.SPA_ID);
            obj[2] = new SqlParameter("DV_DM_ID", item.DM_ID);
            obj[3] = new SqlParameter("DV_Ten", item.Ten);
            obj[4] = new SqlParameter("DV_Ma", item.Ma);
            obj[5] = new SqlParameter("DV_MoTa", item.MoTa);
            obj[6] = new SqlParameter("DV_GhiChu", item.GhiChu);
            obj[7] = new SqlParameter("DV_NoiDung", item.NoiDung);
            obj[8] = new SqlParameter("DV_ThaoTac", item.ThaoTac);
            obj[9] = new SqlParameter("DV_Anh", item.Anh);
            obj[10] = new SqlParameter("DV_Gia", item.Gia);
            obj[11] = new SqlParameter("DV_ThoiGian", item.ThoiGian);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("DV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("DV_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("DV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("DV_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("DV_NguoiTao", item.NguoiTao);
            obj[15] = new SqlParameter("DV_NguoiCapNhat", item.NguoiCapNhat);
            obj[16] = new SqlParameter("DV_Active", item.Active);
            obj[17] = new SqlParameter("DV_KhuyenMai", item.KhuyenMai);
            obj[18] = new SqlParameter("DV_SoLan", item.SoLan);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DichVu SelectById(Guid DV_ID)
        {
            var Item = new DichVu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DV_ID", DV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DichVuCollection SelectAll()
        {
            var List = new DichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DichVu> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<DichVu>("sp_tblSpaMgr_DichVu_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DichVu getFromReader(IDataReader rd)
        {
            var Item = new DichVu();
            if (rd.FieldExists("DV_ID"))
            {
                Item.ID = (Guid)(rd["DV_ID"]);
            }
            if (rd.FieldExists("DV_SPA_ID"))
            {
                Item.SPA_ID = (Guid)(rd["DV_SPA_ID"]);
            }
            if (rd.FieldExists("DV_DM_ID"))
            {
                Item.DM_ID = (Guid)(rd["DV_DM_ID"]);
            }
            if (rd.FieldExists("DV_Ten"))
            {
                Item.Ten = (String)(rd["DV_Ten"]);
            }
            if (rd.FieldExists("DV_Ma"))
            {
                Item.Ma = (String)(rd["DV_Ma"]);
            }
            if (rd.FieldExists("DV_MoTa"))
            {
                Item.MoTa = (String)(rd["DV_MoTa"]);
            }
            if (rd.FieldExists("DV_GhiChu"))
            {
                Item.GhiChu = (String)(rd["DV_GhiChu"]);
            }
            if (rd.FieldExists("DV_NoiDung"))
            {
                Item.NoiDung = (String)(rd["DV_NoiDung"]);
            }
            if (rd.FieldExists("DV_ThaoTac"))
            {
                Item.ThaoTac = (String)(rd["DV_ThaoTac"]);
            }
            if (rd.FieldExists("DV_Anh"))
            {
                Item.Anh = (String)(rd["DV_Anh"]);
            }
            if (rd.FieldExists("DV_Gia"))
            {
                Item.Gia = (Int32)(rd["DV_Gia"]);
            }
            if (rd.FieldExists("DV_ThoiGian"))
            {
                Item.ThoiGian = (Int32)(rd["DV_ThoiGian"]);
            }
            if (rd.FieldExists("DV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DV_NgayTao"]);
            }
            if (rd.FieldExists("DV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["DV_NgayCapNhat"]);
            }
            if (rd.FieldExists("DV_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["DV_NguoiTao"]);
            }
            if (rd.FieldExists("DV_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["DV_NguoiCapNhat"]);
            }
            if (rd.FieldExists("DV_Active"))
            {
                Item.Active = (Boolean)(rd["DV_Active"]);
            }
            if (rd.FieldExists("DV_KhuyenMai"))
            {
                Item.KhuyenMai = (Boolean)(rd["DV_KhuyenMai"]);
            }
            if (rd.FieldExists("DV_SoLan"))
            {
                Item.SoLan = (Int32)(rd["DV_SoLan"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["DM_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static DichVuCollection SelectByDm(string DM_ID)
        {
            var List = new DichVuCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[0] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVu_Select_SelectByDm_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DichVuCollection SelectByDm(SqlConnection con, string DM_ID)
        {
            var List = new DichVuCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[0] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_DichVu_Select_SelectByDm_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DichVu> ByDmIdUser(string url, bool rewrite, string sort, string q, string DM_ID, string User, int size)
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
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(User))
            {
                obj[3] = new SqlParameter("User", User);
            }
            else
            {
                obj[3] = new SqlParameter("User", DBNull.Value);
            }
            var pg = new Pager<DichVu>("sp_tblSpaMgr_DichVu_Pager_ByDmIdUser_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
}
