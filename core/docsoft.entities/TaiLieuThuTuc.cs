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
    #region TaiLieuThuTuc
    #region BO
    public class TaiLieuThuTuc : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public Guid CID { get; set; }
        public Guid PID { get; set; }
        public Guid RowId { get; set; }
        public Int32 Kieu { get; set; }
        public Int32 SoLuong { get; set; }
        #endregion
        #region Contructor
        public TaiLieuThuTuc()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TaiLieuThuTucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TaiLieuThuTucCollection : BaseEntityCollection<TaiLieuThuTuc>
    { }
    #endregion
    #region Dal
    public class TaiLieuThuTucDal
    {
        #region Methods

        public static void DeleteById(Int32 TLTT_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TLTT_ID", TLTT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuThuTuc_Delete_DeleteById_linhnx", obj);
        }

        public static TaiLieuThuTuc Insert(TaiLieuThuTuc Inserted)
        {
            TaiLieuThuTuc Item = new TaiLieuThuTuc();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("TLTT_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("TLTT_CID", Inserted.CID);
            obj[2] = new SqlParameter("TLTT_PID", Inserted.PID);
            obj[3] = new SqlParameter("TLTT_RowId", Inserted.RowId);
            obj[4] = new SqlParameter("TLTT_Kieu", Inserted.Kieu);
            obj[5] = new SqlParameter("TLTT_SoLuong", Inserted.SoLuong);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuThuTuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieuThuTuc Update(TaiLieuThuTuc Updated)
        {
            TaiLieuThuTuc Item = new TaiLieuThuTuc();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("TLTT_ID", Updated.ID);
            obj[1] = new SqlParameter("TLTT_Ten", Updated.Ten);
            obj[2] = new SqlParameter("TLTT_CID", Updated.CID);
            obj[3] = new SqlParameter("TLTT_PID", Updated.PID);
            obj[4] = new SqlParameter("TLTT_RowId", Updated.RowId);
            obj[5] = new SqlParameter("TLTT_Kieu", Updated.Kieu);
            obj[6] = new SqlParameter("TLTT_SoLuong", Updated.SoLuong);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuThuTuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieuThuTuc SelectById(Int32 TLTT_ID)
        {
            TaiLieuThuTuc Item = new TaiLieuThuTuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TLTT_ID", TLTT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuThuTuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieuThuTucCollection SelectAll()
        {
            TaiLieuThuTucCollection List = new TaiLieuThuTucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuThuTuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TaiLieuThuTuc> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TaiLieuThuTuc> pg = new Pager<TaiLieuThuTuc>("sp_tblTaiLieuThuTuc_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TaiLieuThuTuc getFromReader(IDataReader rd)
        {
            TaiLieuThuTuc Item = new TaiLieuThuTuc();
            if (rd.FieldExists("TLTT_ID"))
            {
                Item.ID = (Int32)(rd["TLTT_ID"]);
            }
            if (rd.FieldExists("TLTT_Ten"))
            {
                Item.Ten = (String)(rd["TLTT_Ten"]);
            }
            if (rd.FieldExists("TLTT_CID"))
            {
                Item.CID = (Guid)(rd["TLTT_CID"]);
            }
            if (rd.FieldExists("TLTT_PID"))
            {
                Item.PID = (Guid)(rd["TLTT_PID"]);
            }
            if (rd.FieldExists("TLTT_RowId"))
            {
                Item.RowId = (Guid)(rd["TLTT_RowId"]);
            }
            if (rd.FieldExists("TLTT_Kieu"))
            {
                Item.Kieu = (Int32)(rd["TLTT_Kieu"]);
            }
            if (rd.FieldExists("TLTT_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["TLTT_SoLuong"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void deleteList(string iList, string PID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("iList", iList);
            obj[1] = new SqlParameter("PID", PID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuThuTuc_Delete_deleteList_hungpm", obj);
        }

        public static void updateList(string iList, string PID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("iList", iList);
            obj[1] = new SqlParameter("PID", PID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuThuTuc_Update_updateList_linhnx", obj);
        }
        #endregion
    }
    #endregion

    #endregion
}
