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
    #region Relation
    #region BO
    public class Relation : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Guid CID { get; set; }
        public Guid PID { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public Relation()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return RelationDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class RelationCollection : BaseEntityCollection<Relation>
    { }
    #endregion
    #region Dal
    public class RelationDal
    {
        #region Methods

        public static void DeleteById(Int64 REL_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("REL_ID", REL_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Delete_DeleteById_linhnx", obj);
        }

        public static Relation Insert(Relation Inserted)
        {
            Relation Item = new Relation();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("REL_CID", Inserted.CID);
            obj[1] = new SqlParameter("REL_PID", Inserted.PID);
            obj[2] = new SqlParameter("REL_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Relation Update(Relation Updated)
        {
            Relation Item = new Relation();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("REL_ID", Updated.ID);
            obj[1] = new SqlParameter("REL_CID", Updated.CID);
            obj[2] = new SqlParameter("REL_PID", Updated.PID);
            obj[3] = new SqlParameter("REL_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Relation SelectById(Int64 REL_ID)
        {
            Relation Item = new Relation();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("REL_ID", REL_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static RelationCollection SelectAll()
        {
            RelationCollection List = new RelationCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Relation> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Relation> pg = new Pager<Relation>("sp_tblRelation_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }

        
        
        #endregion

        #region Utilities
        public static Relation getFromReader(IDataReader rd)
        {
            Relation Item = new Relation();
            Item.ID = (Int64)(rd["REL_ID"]);
            Item.CID = (Guid)(rd["REL_CID"]);
            Item.PID = (Guid)(rd["REL_PID"]);
            Item.RowId = (Guid)(rd["REL_RowId"]);
            return Item;
        }
        #endregion
        #region Extend
        public static void deleteList(string iList, string PID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("iList", iList);
            obj[1] = new SqlParameter("PID", PID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Delete_deleteList_hungpm", obj);
        }

        public static void updateList(string iList,string PID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("iList", iList);
            obj[1] = new SqlParameter("PID", PID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Update_updateList_linhnx", obj);
        }

        public static void DeleteByCidPid(string CID, string PID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("CID", CID);
            obj[1] = new SqlParameter("PID", PID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Delete_DeleteByCidPid_linhnx", obj);
        }
        public static RelationCollection SelectByPid(string PID)
        {
            var list = new RelationCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PID", PID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Select_SelectByPid_linhnx",obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        #endregion
    }
    #endregion

    #endregion
    
}


