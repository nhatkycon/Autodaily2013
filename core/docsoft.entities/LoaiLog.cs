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
    #region LoaiLog
    #region BO
    public class LoaiLog : BaseEntity
    {
        #region Properties
        public Int16 ID { get; set; }
        public String Ten { get; set; }
        #endregion
        #region Contructor
        public LoaiLog()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LoaiLogDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LoaiLogCollection : BaseEntityCollection<LoaiLog>
    { }
    #endregion
    #region Dal
    public class LoaiLogDal
    {
        #region Methods

        public static void DeleteById(Int16 LLOG_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LLOG_ID", LLOG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiLog_Delete_DeleteById_linhnx", obj);
        }

        public static LoaiLog Insert(LoaiLog Inserted)
        {
            LoaiLog Item = new LoaiLog();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LLOG_Ten", Inserted.Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiLog_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiLog Update(LoaiLog Updated)
        {
            LoaiLog Item = new LoaiLog();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("LLOG_ID", Updated.ID);
            obj[1] = new SqlParameter("LLOG_Ten", Updated.Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiLog_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiLog SelectById(Int16 LLOG_ID)
        {
            LoaiLog Item = new LoaiLog();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LLOG_ID", LLOG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiLog_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiLogCollection SelectAll()
        {
            LoaiLogCollection List = new LoaiLogCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiLog_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LoaiLog> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<LoaiLog> pg = new Pager<LoaiLog>("sp_tblLoaiLog_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static LoaiLog getFromReader(IDataReader rd)
        {
            LoaiLog Item = new LoaiLog();
            Item.ID = (Int16)(rd["LLOG_ID"]);
            Item.Ten = (String)(rd["LLOG_Ten"]);
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
    
}


