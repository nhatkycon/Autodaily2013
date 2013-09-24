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
    #region PluginZone
    #region BO
    public class PluginZone : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 Z_ID { get; set; }
        public String Settings { get; set; }
        public Int32 ThuTu { get; set; }
        #endregion
        #region Contructor
        public PluginZone()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PluginZoneDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PluginZoneCollection : BaseEntityCollection<PluginZone>
    { }
    #endregion
    #region Dal
    public class PluginZoneDal
    {
        #region Methods

        public static void DeleteById(Int32 PZ_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PZ_ID", PZ_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblPluginZone_Delete_DeleteById_hoangda", obj);
        }

        public static PluginZone Insert(PluginZone Inserted)
        {
            PluginZone Item = new PluginZone();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("PZ_Z_ID", Inserted.Z_ID);
            obj[1] = new SqlParameter("PZ_Settings", Inserted.Settings);
            obj[2] = new SqlParameter("PZ_ThuTu", Inserted.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPluginZone_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PluginZone Update(PluginZone Updated)
        {
            PluginZone Item = new PluginZone();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("PZ_ID", Updated.ID);
            obj[1] = new SqlParameter("PZ_Z_ID", Updated.Z_ID);
            obj[2] = new SqlParameter("PZ_Settings", Updated.Settings);
            obj[3] = new SqlParameter("PZ_ThuTu", Updated.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPluginZone_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PluginZone SelectById(Int32 PZ_ID)
        {
            PluginZone Item = new PluginZone();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PZ_ID", PZ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPluginZone_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PluginZoneCollection SelectAll()
        {
            PluginZoneCollection List = new PluginZoneCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPluginZone_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PluginZone> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<PluginZone> pg = new Pager<PluginZone>("sp_tblPluginZone_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PluginZone getFromReader(IDataReader rd)
        {
            PluginZone Item = new PluginZone();
            if (rd.FieldExists("PZ_ID"))
            {
                Item.ID = (Int32)(rd["PZ_ID"]);
            }
            if (rd.FieldExists("PZ_Z_ID"))
            {
                Item.Z_ID = (Int32)(rd["PZ_Z_ID"]);
            }
            if (rd.FieldExists("PZ_Settings"))
            {
                Item.Settings = (String)(rd["PZ_Settings"]);
            }
            if (rd.FieldExists("PZ_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["PZ_ThuTu"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static PluginZoneCollection SelectByZid(SqlConnection con, int Z_ID)
        {
            PluginZoneCollection List = new PluginZoneCollection();
            SqlParameter[] obj = new SqlParameter[] { 
                new SqlParameter("Z_ID",Z_ID)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblPluginZone_Select_SelectByZId_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static PluginZone UpdateMove(string id,string z_id,string thuTu)
        {
            PluginZone Item = new PluginZone();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("PZ_ID", id);
            obj[1] = new SqlParameter("PZ_Z_ID", z_id);
            obj[2] = new SqlParameter("PZ_ThuTu", thuTu);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPluginZone_Update_UpdateMove_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static PluginZone Add(string Z_ID, string Settings,string ThuTu)
        {
            PluginZone Item = new PluginZone();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("PZ_Z_ID", Z_ID);
            obj[1] = new SqlParameter("PZ_Settings", Settings);
            obj[2] = new SqlParameter("PZ_ThuTu", ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPluginZone_Insert_InsertNormal_hoangda", obj))
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
