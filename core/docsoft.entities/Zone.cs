using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using linh.controls;

namespace docsoft.entities
{
    #region Zone
    #region BO
    public class Zone : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ma { get; set; }
        public String SID { get; set; }
        public Int32 PG_ID { get; set; }
        public String Width { get; set; }
        public Int32 ThuTu { get; set; }
        public String CssClass { get; set; }
        public String HtmlBefore { get; set; }
        public String HtmlAfter { get; set; }
        #endregion
        #region Contructor
        public Zone()
        { }
        #endregion
        #region Customs properties
        public String PG_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ZoneDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ZoneCollection : BaseEntityCollection<Zone>
    { }
    #endregion
    #region Dal
    public class ZoneDal
    {
        #region Methods

        public static void DeleteById(Int32 Z_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Z_ID", Z_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblZone_Delete_DeleteById_linhnx", obj);
        }

        public static Zone Insert(Zone Inserted)
        {
            Zone Item = new Zone();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Z_Ma", Inserted.Ma);
            obj[1] = new SqlParameter("Z_SID", Inserted.SID);
            obj[2] = new SqlParameter("Z_PG_ID", Inserted.PG_ID);
            obj[3] = new SqlParameter("Z_Width", Inserted.Width);
            obj[4] = new SqlParameter("Z_ThuTu", Inserted.ThuTu);
            obj[5] = new SqlParameter("Z_CssClass", Inserted.CssClass);
            obj[6] = new SqlParameter("Z_HtmlBefore", Inserted.HtmlBefore);
            obj[7] = new SqlParameter("Z_HtmlAfter", Inserted.HtmlAfter);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblZone_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Zone Update(Zone Updated)
        {
            Zone Item = new Zone();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("Z_ID", Updated.ID);
            obj[1] = new SqlParameter("Z_Ma", Updated.Ma);
            obj[2] = new SqlParameter("Z_SID", Updated.SID);
            obj[3] = new SqlParameter("Z_PG_ID", Updated.PG_ID);
            obj[4] = new SqlParameter("Z_Width", Updated.Width);
            obj[5] = new SqlParameter("Z_ThuTu", Updated.ThuTu);
            obj[6] = new SqlParameter("Z_CssClass", Updated.CssClass);
            obj[7] = new SqlParameter("Z_HtmlBefore", Updated.HtmlBefore);
            obj[8] = new SqlParameter("Z_HtmlAfter", Updated.HtmlAfter);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblZone_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Zone SelectById(Int32 Z_ID)
        {
            Zone Item = new Zone();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Z_ID", Z_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblZone_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ZoneCollection SelectAll()
        {
            ZoneCollection List = new ZoneCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblZone_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Zone> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<Zone> pg = new Pager<Zone>("sp_tblZone_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        #endregion

        #region Utilities
        public static Zone getFromReader(IDataReader rd)
        {
            Zone Item = new Zone();
            if (rd.FieldExists("Z_ID"))
            {
                Item.ID = (Int32)(rd["Z_ID"]);
            }
            if (rd.FieldExists("Z_Ma"))
            {
                Item.Ma = (String)(rd["Z_Ma"]);
            }
            if (rd.FieldExists("Z_SID"))
            {
                Item.SID = (String)(rd["Z_SID"]);
            }
            if (rd.FieldExists("Z_PG_ID"))
            {
                Item.PG_ID = (Int32)(rd["Z_PG_ID"]);
            }
            if (rd.FieldExists("Z_Width"))
            {
                Item.Width = (String)(rd["Z_Width"]);
            }
            if (rd.FieldExists("Z_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["Z_ThuTu"]);
            }
            if (rd.FieldExists("Z_CssClass"))
            {
                Item.CssClass = (String)(rd["Z_CssClass"]);
            }
            if (rd.FieldExists("Z_PG_Ten"))
            {
                Item.PG_Ten = (String)(rd["Z_PG_Ten"]);
            }
            if (rd.FieldExists("Z_HtmlBefore"))
            {
                Item.HtmlBefore = (String)(rd["Z_HtmlBefore"]);
            }
            if (rd.FieldExists("Z_HtmlAfter"))
            {
                Item.HtmlAfter = (String)(rd["Z_HtmlAfter"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<Zone> pagerNormal(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Zone> pg = new Pager<Zone>("sp_tblZone_Pager_Normal_linhnx", "pages", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static ZoneCollection SelectByAlias(SqlConnection con, string Alias)
        {
            ZoneCollection List = new ZoneCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Alias", Alias);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblZone_Select_SelectByAlias_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Zone SelectByMa(SqlConnection con, string Ma)
        {
            Zone Item = new Zone();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Ma", Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblZone_Select_SelectByMa_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
}
