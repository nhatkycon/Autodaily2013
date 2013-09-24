using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace docsoft.entities
{
    #region Resources
    #region BO
    public class Resources : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String K { get; set; }
        public String V { get; set; }
        public String Lang { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public Resources()
        { }
        public Resources(Int32? id, String k, String v, String lang, Guid? rowid)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            K = k;
            V = v;
            Lang = lang;
            if (rowid != null)
            {
                RowId = rowid.Value;
            }

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ResourcesDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ResourcesCollection : BaseEntityCollection<Resources>
    { }
    #endregion
    #region Dal
    public class ResourcesDal
    {
        #region Methods

        public static void DeleteById(Int32 R_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("R_ID", R_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblResources_Delete_DeleteById_linhnx", obj);
        }
        public static Resources Insert(Resources Inserted)
        {
            Resources Item = new Resources();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("R_K", Inserted.K);
            obj[1] = new SqlParameter("R_V", Inserted.V);
            obj[2] = new SqlParameter("R_Lang", Inserted.Lang);
            obj[3] = new SqlParameter("R_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblResources_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Resources Insert(Int32? id, String k, String v, String lang, Guid? rowid)
        {
            Resources Item = new Resources();
            SqlParameter[] obj = new SqlParameter[4];
            if (k != null)
            {
                obj[0] = new SqlParameter("R_K", k);
            }
            else
            {
                obj[0] = new SqlParameter("R_K", DBNull.Value);
            }
            if (v != null)
            {
                obj[1] = new SqlParameter("R_V", v);
            }
            else
            {
                obj[1] = new SqlParameter("R_V", DBNull.Value);
            }
            if (lang != null)
            {
                obj[2] = new SqlParameter("R_Lang", lang);
            }
            else
            {
                obj[2] = new SqlParameter("R_Lang", DBNull.Value);
            }
            if (rowid != null)
            {
                obj[3] = new SqlParameter("R_RowId", rowid);
            }
            else
            {
                obj[3] = new SqlParameter("R_RowId", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblResources_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Resources Update(Resources Updated)
        {
            Resources Item = new Resources();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("R_ID", Updated.ID);
            obj[1] = new SqlParameter("R_K", Updated.K);
            obj[2] = new SqlParameter("R_V", Updated.V);
            obj[3] = new SqlParameter("R_Lang", Updated.Lang);
            obj[4] = new SqlParameter("R_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblResources_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Resources Update(Int32? id, String k, String v, String lang, Guid? rowid)
        {
            Resources Item = new Resources();
            SqlParameter[] obj = new SqlParameter[5];
            if (id != null)
            {
                obj[0] = new SqlParameter("R_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("R_ID", DBNull.Value);
            }
            if (k != null)
            {
                obj[1] = new SqlParameter("R_K", k);
            }
            else
            {
                obj[1] = new SqlParameter("R_K", DBNull.Value);
            }
            if (v != null)
            {
                obj[2] = new SqlParameter("R_V", v);
            }
            else
            {
                obj[2] = new SqlParameter("R_V", DBNull.Value);
            }
            if (lang != null)
            {
                obj[3] = new SqlParameter("R_Lang", lang);
            }
            else
            {
                obj[3] = new SqlParameter("R_Lang", DBNull.Value);
            }
            if (rowid != null)
            {
                obj[4] = new SqlParameter("R_RowId", rowid);
            }
            else
            {
                obj[4] = new SqlParameter("R_RowId", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblResources_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Resources SelectById(Int32 R_ID)
        {
            Resources Item = new Resources();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("R_ID", R_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblResources_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ResourcesCollection SelectAll()
        {
            ResourcesCollection List = new ResourcesCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblResources_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Resources> pagerNormal(string url, bool rewrite, string sort,int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Resources> pg = new Pager<Resources>("tbl_sp_tblResources_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        #endregion
        #region Utilities
        public static Resources getFromReader(IDataReader rd)
        {
            Resources Item = new Resources();
            if (rd.FieldExists("R_ID"))
            {
                Item.ID = (Int32)(rd["R_ID"]);
            }
            if (rd.FieldExists("R_K"))
            {
                Item.K = (String)(rd["R_K"]);
            }
            if (rd.FieldExists("R_V"))
            {
                Item.V = (String)(rd["R_V"]);
            }
            if (rd.FieldExists("R_Lang"))
            {
                Item.Lang = (String)(rd["R_Lang"]);
            }
            if (rd.FieldExists("R_RowId"))
            {
                Item.RowId = (Guid)(rd["R_RowId"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static ResourcesCollection SelectByLang(string lang)
        {
            var list = new ResourcesCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Lang", lang);
            //var c = HttpRuntime.Cache;
            //var items = c["Resources-" + lang];
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblResources_Select_SelectByLang_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            //c["Resources-" + lang] = list;
            return list;
        }
        public static Pager<Resources> pagerByLang(string url, bool rewrite, string sort, int size,string Lang)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("Lang", Lang);
            var pg = new Pager<Resources>("tbl_sp_tblResources_Pager_pagerByLang_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion
    #endregion
    
}


