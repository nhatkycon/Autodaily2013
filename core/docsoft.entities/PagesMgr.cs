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
    #region PagesMgr
    #region BO
    public class PagesMgr : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Alias { get; set; }
        public Boolean Active { get; set; }
        public String KeyWords { get; set; }
        public String Descriptions { get; set; }
        #endregion
        #region Contructor
        public PagesMgr()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PagesMgrDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PagesMgrCollection : BaseEntityCollection<PagesMgr>
    { }
    #endregion
    #region Dal
    public class PagesMgrDal
    {
        #region Methods

        public static void DeleteById(Int32 PG_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PG_ID", PG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblPagesMgr_Delete_DeleteById_linhnx", obj);
        }

        public static PagesMgr Insert(PagesMgr Inserted)
        {
            PagesMgr Item = new PagesMgr();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("PG_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("PG_Alias", Inserted.Alias);
            obj[2] = new SqlParameter("PG_Active", Inserted.Active);
            obj[3] = new SqlParameter("PG_KeyWords", Inserted.KeyWords);
            obj[4] = new SqlParameter("PG_Descriptions", Inserted.Descriptions);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPagesMgr_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PagesMgr Update(PagesMgr Updated)
        {
            PagesMgr Item = new PagesMgr();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("PG_ID", Updated.ID);
            obj[1] = new SqlParameter("PG_Ten", Updated.Ten);
            obj[2] = new SqlParameter("PG_Alias", Updated.Alias);
            obj[3] = new SqlParameter("PG_Active", Updated.Active);
            obj[4] = new SqlParameter("PG_KeyWords", Updated.KeyWords);
            obj[5] = new SqlParameter("PG_Descriptions", Updated.Descriptions);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPagesMgr_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PagesMgr SelectById(Int32 PG_ID)
        {
            PagesMgr Item = new PagesMgr();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PG_ID", PG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPagesMgr_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PagesMgrCollection SelectAll()
        {
            PagesMgrCollection List = new PagesMgrCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPagesMgr_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PagesMgr> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<PagesMgr> pg = new Pager<PagesMgr>("sp_tblPagesMgr_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<PagesMgr> pagerNormal(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<PagesMgr> pg = new Pager<PagesMgr>("sp_tblPagesMgr_Pager_Normal_linhnx", "pages", size, 10, false, string.Empty, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PagesMgr getFromReader(IDataReader rd)
        {
            PagesMgr Item = new PagesMgr();
            if (rd.FieldExists("PG_ID"))
            {
                Item.ID = (Int32)(rd["PG_ID"]);
            }
            if (rd.FieldExists("PG_Ten"))
            {
                Item.Ten = (String)(rd["PG_Ten"]);
            }
            if (rd.FieldExists("PG_Alias"))
            {
                Item.Alias = (String)(rd["PG_Alias"]);
            }
            if (rd.FieldExists("PG_Active"))
            {
                Item.Active = (Boolean)(rd["PG_Active"]);
            }
            if (rd.FieldExists("PG_KeyWords"))
            {
                Item.KeyWords = (String)(rd["PG_KeyWords"]);
            }
            if (rd.FieldExists("PG_Descriptions"))
            {
                Item.Descriptions = (String)(rd["PG_Descriptions"]);
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
