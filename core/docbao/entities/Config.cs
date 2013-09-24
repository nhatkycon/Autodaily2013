using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using linh.core.dal;
using linh.controls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
namespace docbao.entitites
{
    #region Config
    #region BO
    public class Config : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Key { get; set; }
        public String Gt { get; set; }
        #endregion
        #region Contructor
        public Config()
        { }
        public Config(Int32? id, String key, String gt)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            Key = key;
            Gt = gt;

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ConfigDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ConfigCollection : BaseEntityCollection<Config>
    { }
    #endregion
    #region Dal
    public class ConfigDal
    {
        #region Methods

        public static void DeleteById(Int32 CF_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CF_ID", CF_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssConfig_Delete_DeleteById_linhnx", obj);
        }
        public static Config Insert(Config Inserted)
        {
            Config Item = new Config();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("CF_Key", Inserted.Key);
            obj[1] = new SqlParameter("CF_Gt", Inserted.Gt);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssConfig_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Config Insert(Int32? id, String key, String gt)
        {
            Config Item = new Config();
            SqlParameter[] obj = new SqlParameter[2];
            if (key != null)
            {
                obj[0] = new SqlParameter("CF_Key", key);
            }
            else
            {
                obj[0] = new SqlParameter("CF_Key", DBNull.Value);
            }
            if (gt != null)
            {
                obj[1] = new SqlParameter("CF_Gt", gt);
            }
            else
            {
                obj[1] = new SqlParameter("CF_Gt", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssConfig_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Config Update(Config Updated)
        {
            Config Item = new Config();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("CF_ID", Updated.ID);
            obj[1] = new SqlParameter("CF_Key", Updated.Key);
            obj[2] = new SqlParameter("CF_Gt", Updated.Gt);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssConfig_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Config Update(Int32? id, String key, String gt)
        {
            Config Item = new Config();
            SqlParameter[] obj = new SqlParameter[3];
            if (id != null)
            {
                obj[0] = new SqlParameter("CF_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("CF_ID", DBNull.Value);
            }
            if (key != null)
            {
                obj[1] = new SqlParameter("CF_Key", key);
            }
            else
            {
                obj[1] = new SqlParameter("CF_Key", DBNull.Value);
            }
            if (gt != null)
            {
                obj[2] = new SqlParameter("CF_Gt", gt);
            }
            else
            {
                obj[2] = new SqlParameter("CF_Gt", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssConfig_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Config SelectById(Int32 CF_ID)
        {
            Config Item = new Config();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CF_ID", CF_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssConfig_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static string SelectByKey(string CF_Key)
        {
            Config Item = new Config();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CF_Key", CF_Key);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssConfig_Select_SelectByKey_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item.Gt;
        }
        public static ConfigCollection SelectAll()
        {
            ConfigCollection List = new ConfigCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssConfig_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Config> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Config> pg = new Pager<Config>("tblRss_sp_tblConfig_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Config getFromReader(IDataReader rd)
        {
            Config Item = new Config();
            if (rd.FieldExists("CF_ID"))
            {
                Item.ID = (Int32)(rd["CF_ID"]);
            }
            if (rd.FieldExists("CF_Key"))
            {
                Item.Key = (String)(rd["CF_Key"]);
            }
            if (rd.FieldExists("CF_Gt"))
            {
                Item.Gt = (String)(rd["CF_Gt"]);
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
