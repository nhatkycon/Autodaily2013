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
    #region Plugin
    #region BO
    public class Plugin : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Kieu { get; set; }
        public String Anh { get; set; }
        #endregion
        #region Contructor
        public Plugin()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PluginDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PluginCollection : BaseEntityCollection<Plugin>
    { }
    #endregion
    #region Dal
    public class PluginDal
    {
        #region Methods

        public static void DeleteById(Int32 P_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("P_ID", P_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblPlugin_Delete_DeleteById_hoangda", obj);
        }

        public static Plugin Insert(Plugin Inserted)
        {
            Plugin Item = new Plugin();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("P_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("P_Kieu", Inserted.Kieu);
            obj[2] = new SqlParameter("P_Anh", Inserted.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPlugin_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Plugin Update(Plugin Updated)
        {
            Plugin Item = new Plugin();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("P_ID", Updated.ID);
            obj[1] = new SqlParameter("P_Ten", Updated.Ten);
            obj[2] = new SqlParameter("P_Kieu", Updated.Kieu);
            obj[3] = new SqlParameter("P_Anh", Updated.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPlugin_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Plugin SelectById(Int32 P_ID)
        {
            Plugin Item = new Plugin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("P_ID", P_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPlugin_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PluginCollection SelectAll()
        {
            PluginCollection List = new PluginCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPlugin_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Plugin> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<Plugin> pg = new Pager<Plugin>("sp_tblPlugin_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Plugin getFromReader(IDataReader rd)
        {
            Plugin Item = new Plugin();
            if (rd.FieldExists("P_ID"))
            {
                Item.ID = (Int32)(rd["P_ID"]);
            }
            if (rd.FieldExists("P_Ten"))
            {
                Item.Ten = (String)(rd["P_Ten"]);
            }
            if (rd.FieldExists("P_Kieu"))
            {
                Item.Kieu = (String)(rd["P_Kieu"]);
            }
            if (rd.FieldExists("P_Anh"))
            {
                Item.Anh = (String)(rd["P_Anh"]);
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
