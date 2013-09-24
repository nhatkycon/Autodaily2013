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
    #region Draff
    #region BO
    public class Draff : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public Draff()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DraffDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DraffCollection : BaseEntityCollection<Draff>
    { }
    #endregion
    #region Dal
    public class DraffDal
    {
        #region Methods

        public static void DeleteById(Int32 D_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("D_ID", D_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDraff_Delete_DeleteById_hoangda", obj);
        }

        public static Draff Insert(Draff Inserted)
        {
            Draff Item = new Draff();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("D_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDraff_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Draff Update(Draff Updated)
        {
            Draff Item = new Draff();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("D_ID", Updated.ID);
            obj[1] = new SqlParameter("D_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDraff_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Draff SelectById(Int32 D_ID)
        {
            Draff Item = new Draff();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("D_ID", D_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDraff_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DraffCollection SelectAll()
        {
            DraffCollection List = new DraffCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDraff_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Draff> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            Pager<Draff> pg = new Pager<Draff>("sp_tblDraff_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Draff getFromReader(IDataReader rd)
        {
            Draff Item = new Draff();
            if (rd.FieldExists("D_ID"))
            {
                Item.ID = (Int32)(rd["D_ID"]);
            }
            if (rd.FieldExists("D_RowId"))
            {
                Item.RowId = (Guid)(rd["D_RowId"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion
}
