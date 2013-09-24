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
    #region Language
    #region BO
    public class Language : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Active { get; set; }
        #endregion
        #region Contructor
        public Language()
        { }
        public Language(Int32? id, String ten, String ma, Int32? thutu, Boolean? active)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            Ten = ten;
            Ma = ma;
            if (thutu != null)
            {
                ThuTu = thutu.Value;
            }
            if (active != null)
            {
                Active = active.Value;
            }

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LanguageDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LanguageCollection : BaseEntityCollection<Language>
    { }
    #endregion
    #region Dal
    public class LanguageDal
    {
        #region Methods

        public static void DeleteById(Int32 L_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("L_ID", L_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblLanguage_Delete_DeleteById_linhnx", obj);
        }
        public static Language Insert(Language Inserted)
        {
            Language Item = new Language();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("L_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("L_Ma", Inserted.Ma);
            obj[2] = new SqlParameter("L_ThuTu", Inserted.ThuTu);
            obj[3] = new SqlParameter("L_Active", Inserted.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblLanguage_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Language Insert(Int32? id, String ten, String ma, Int32? thutu, Boolean? active)
        {
            Language Item = new Language();
            SqlParameter[] obj = new SqlParameter[4];
            if (ten != null)
            {
                obj[0] = new SqlParameter("L_Ten", ten);
            }
            else
            {
                obj[0] = new SqlParameter("L_Ten", DBNull.Value);
            }
            if (ma != null)
            {
                obj[1] = new SqlParameter("L_Ma", ma);
            }
            else
            {
                obj[1] = new SqlParameter("L_Ma", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[2] = new SqlParameter("L_ThuTu", thutu);
            }
            else
            {
                obj[2] = new SqlParameter("L_ThuTu", DBNull.Value);
            }
            if (active != null)
            {
                obj[3] = new SqlParameter("L_Active", active);
            }
            else
            {
                obj[3] = new SqlParameter("L_Active", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblLanguage_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Language Update(Language Updated)
        {
            Language Item = new Language();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("L_ID", Updated.ID);
            obj[1] = new SqlParameter("L_Ten", Updated.Ten);
            obj[2] = new SqlParameter("L_Ma", Updated.Ma);
            obj[3] = new SqlParameter("L_ThuTu", Updated.ThuTu);
            obj[4] = new SqlParameter("L_Active", Updated.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblLanguage_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Language Update(Int32? id, String ten, String ma, Int32? thutu, Boolean? active)
        {
            Language Item = new Language();
            SqlParameter[] obj = new SqlParameter[5];
            if (id != null)
            {
                obj[0] = new SqlParameter("L_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("L_ID", DBNull.Value);
            }
            if (ten != null)
            {
                obj[1] = new SqlParameter("L_Ten", ten);
            }
            else
            {
                obj[1] = new SqlParameter("L_Ten", DBNull.Value);
            }
            if (ma != null)
            {
                obj[2] = new SqlParameter("L_Ma", ma);
            }
            else
            {
                obj[2] = new SqlParameter("L_Ma", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[3] = new SqlParameter("L_ThuTu", thutu);
            }
            else
            {
                obj[3] = new SqlParameter("L_ThuTu", DBNull.Value);
            }
            if (active != null)
            {
                obj[4] = new SqlParameter("L_Active", active);
            }
            else
            {
                obj[4] = new SqlParameter("L_Active", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblLanguage_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Language SelectById(Int32 L_ID)
        {
            Language Item = new Language();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("L_ID", L_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblLanguage_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static LanguageCollection SelectAll()
        {
            LanguageCollection List = new LanguageCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblLanguage_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Language> pagerNormal(string url, bool rewrite, string sort,string size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Language> pg = new Pager<Language>("tbl_sp_tblLanguage_Pager_Normal_linhnx", "q", Convert.ToInt32(20), 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Language getFromReader(IDataReader rd)
        {
            Language Item = new Language();
            if (rd.FieldExists("L_ID"))
            {
                Item.ID = (Int32)(rd["L_ID"]);
            }
            if (rd.FieldExists("L_Ten"))
            {
                Item.Ten = (String)(rd["L_Ten"]);
            }
            if (rd.FieldExists("L_Ma"))
            {
                Item.Ma = (String)(rd["L_Ma"]);
            }
            if (rd.FieldExists("L_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["L_ThuTu"]);
            }
            if (rd.FieldExists("L_Active"))
            {
                Item.Active = (Boolean)(rd["L_Active"]);
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


