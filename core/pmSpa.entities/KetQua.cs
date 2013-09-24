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

    #region KetQua
    #region BO
    public class KetQua : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid DV_ID { get; set; }
        public Guid TT_ID { get; set; }
        public Guid DM_ID { get; set; }
        public Guid KH_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String Anh { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Active { get; set; }
        #endregion
        #region Contructor
        public KetQua()
        { }
        #endregion
        #region Customs properties
        public String TT_Ten { get; set; }
        public String KH_Ten { get; set; }

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return KetQuaDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class KetQuaCollection : BaseEntityCollection<KetQua>
    { }
    #endregion
    #region Dal
    public class KetQuaDal
    {
        #region Methods

        public static void DeleteById(Guid KQ_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KQ_ID", KQ_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KetQua_Delete_DeleteById_linhnx", obj);
        }

        public static KetQua Insert(KetQua item)
        {
            var Item = new KetQua();
            var obj = new SqlParameter[15];
            obj[0] = new SqlParameter("KQ_ID", item.ID);
            obj[1] = new SqlParameter("KQ_DV_ID", item.DV_ID);
            obj[2] = new SqlParameter("KQ_TT_ID", item.TT_ID);
            obj[3] = new SqlParameter("KQ_DM_ID", item.DM_ID);
            obj[4] = new SqlParameter("KQ_KH_ID", item.KH_ID);
            obj[5] = new SqlParameter("KQ_Ten", item.Ten);
            obj[6] = new SqlParameter("KQ_MoTa", item.MoTa);
            obj[7] = new SqlParameter("KQ_Anh", item.Anh);
            obj[8] = new SqlParameter("KQ_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("KQ_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("KQ_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("KQ_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[10] = new SqlParameter("KQ_NgayCapNhat", DBNull.Value);
            }
            obj[11] = new SqlParameter("KQ_NguoiTao", item.NguoiTao);
            obj[12] = new SqlParameter("KQ_NguoiCapNhat", item.NguoiCapNhat);
            obj[13] = new SqlParameter("KQ_ThuTu", item.ThuTu);
            obj[14] = new SqlParameter("KQ_Active", item.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KetQua_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KetQua Update(KetQua item)
        {
            var Item = new KetQua();
            var obj = new SqlParameter[15];
            obj[0] = new SqlParameter("KQ_ID", item.ID);
            obj[1] = new SqlParameter("KQ_DV_ID", item.DV_ID);
            obj[2] = new SqlParameter("KQ_TT_ID", item.TT_ID);
            obj[3] = new SqlParameter("KQ_DM_ID", item.DM_ID);
            obj[4] = new SqlParameter("KQ_KH_ID", item.KH_ID);
            obj[5] = new SqlParameter("KQ_Ten", item.Ten);
            obj[6] = new SqlParameter("KQ_MoTa", item.MoTa);
            obj[7] = new SqlParameter("KQ_Anh", item.Anh);
            obj[8] = new SqlParameter("KQ_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("KQ_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("KQ_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("KQ_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[10] = new SqlParameter("KQ_NgayCapNhat", DBNull.Value);
            }
            obj[11] = new SqlParameter("KQ_NguoiTao", item.NguoiTao);
            obj[12] = new SqlParameter("KQ_NguoiCapNhat", item.NguoiCapNhat);
            obj[13] = new SqlParameter("KQ_ThuTu", item.ThuTu);
            obj[14] = new SqlParameter("KQ_Active", item.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KetQua_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KetQua SelectById(Guid KQ_ID)
        {
            var Item = new KetQua();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KQ_ID", KQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KetQua_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KetQuaCollection SelectAll()
        {
            var List = new KetQuaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KetQua_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<KetQua> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<KetQua>("sp_tblSpaMgr_KetQua_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static KetQua getFromReader(IDataReader rd)
        {
            var Item = new KetQua();
            if (rd.FieldExists("KQ_ID"))
            {
                Item.ID = (Guid)(rd["KQ_ID"]);
            }
            if (rd.FieldExists("KQ_DV_ID"))
            {
                Item.DV_ID = (Guid)(rd["KQ_DV_ID"]);
            }
            if (rd.FieldExists("KQ_TT_ID"))
            {
                Item.TT_ID = (Guid)(rd["KQ_TT_ID"]);
            }
            if (rd.FieldExists("KQ_DM_ID"))
            {
                Item.DM_ID = (Guid)(rd["KQ_DM_ID"]);
            }
            if (rd.FieldExists("KQ_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["KQ_KH_ID"]);
            }
            if (rd.FieldExists("KQ_Ten"))
            {
                Item.Ten = (String)(rd["KQ_Ten"]);
            }
            if (rd.FieldExists("KQ_MoTa"))
            {
                Item.MoTa = (String)(rd["KQ_MoTa"]);
            }
            if (rd.FieldExists("KQ_Anh"))
            {
                Item.Anh = (String)(rd["KQ_Anh"]);
            }
            if (rd.FieldExists("KQ_NoiDung"))
            {
                Item.NoiDung = (String)(rd["KQ_NoiDung"]);
            }
            if (rd.FieldExists("KQ_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["KQ_NgayTao"]);
            }
            if (rd.FieldExists("KQ_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["KQ_NgayCapNhat"]);
            }
            if (rd.FieldExists("KQ_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["KQ_NguoiTao"]);
            }
            if (rd.FieldExists("KQ_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["KQ_NguoiCapNhat"]);
            }
            if (rd.FieldExists("KQ_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["KQ_ThuTu"]);
            }
            if (rd.FieldExists("KQ_Active"))
            {
                Item.Active = (Boolean)(rd["KQ_Active"]);
            }

            if (rd.FieldExists("TT_Ten"))
            {
                Item.TT_Ten = (String)(rd["TT_Ten"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["KH_Ten"]);
            }

            return Item;
        }
        #endregion

        #region Extend
        public static KetQuaCollection SelectByTTId(SqlConnection con, string TT_ID)
        {
            var List = new KetQuaCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(TT_ID))
            {
                obj[0] = new SqlParameter("TT_ID", TT_ID);
            }
            else
            {
                obj[0] = new SqlParameter("TT_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_KetQua_Select_SelectByTTId_linhnx", obj))
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
