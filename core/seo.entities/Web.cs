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
using linh.common;
using System.Web;

namespace seo.entities
{
    #region Website
    #region BO
    public class Website : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int64 DM_ID { get; set; }
        public String Url { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public Boolean Star { get; set; }
        public Boolean Active { get; set; }
        public Boolean Publish { get; set; }
        public Boolean UserOnly { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public Website()
        { }
        public Website(IDataReader rd)
        {
            if (rd.FieldExists("W_ID"))
            {
                ID = (Int64)(rd["W_ID"]);
            }
            if (rd.FieldExists("W_DM_ID"))
            {
                DM_ID = (Int64)(rd["W_DM_ID"]);
            }
            if (rd.FieldExists("W_Url"))
            {
                Url = (String)(rd["W_Url"]);
            }
            if (rd.FieldExists("W_Ten"))
            {
                Ten = (String)(rd["W_Ten"]);
            }
            if (rd.FieldExists("W_MoTa"))
            {
                MoTa = (String)(rd["W_MoTa"]);
            }
            if (rd.FieldExists("W_Star"))
            {
                Star = (Boolean)(rd["W_Star"]);
            }
            if (rd.FieldExists("W_Active"))
            {
                Active = (Boolean)(rd["W_Active"]);
            }
            if (rd.FieldExists("W_Publish"))
            {
                Publish = (Boolean)(rd["W_Publish"]);
            }
            if (rd.FieldExists("W_UserOnly"))
            {
                UserOnly = (Boolean)(rd["W_UserOnly"]);
            }
            if (rd.FieldExists("W_NguoiTao"))
            {
                NguoiTao = (String)(rd["W_NguoiTao"]);
            }
            if (rd.FieldExists("W_NgayTao"))
            {
                NgayTao = (DateTime)(rd["W_NgayTao"]);
            }
            if (rd.FieldExists("W_RowId"))
            {
                RowId = (Guid)(rd["W_RowId"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                DM_Ten = (String)(rd["DM_Ten"]);
            }
        }
        #endregion
        #region Customs properties
        public string DM_Ten { get; set; }
        #endregion
        #region getFromReader
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return new Website(rd);
        }
        public string format(int Loai)
        {
            StringBuilder sb = new StringBuilder();
            switch (Loai)
            {
                case 0:
                    #region 0 :
                    break;
                    #endregion
                case 1:
                    #region 1 :
                    break;
                    #endregion
                case 2:
                    #region 2 :
                    break;
                    #endregion
                case 3:
                    #region 3 :
                    break;
                    #endregion
                default:
                    #region mac dinh
                    break;
                    #endregion
            }
            return sb.ToString();
        }
        #endregion
    }
    #endregion
    #region Collection
    public class WebsiteCollection : BaseEntityCollection<Website>
    { }
    #endregion
    #region Dal
    public class WebsiteDal
    {
        #region Methods

        public static void DeleteById(Int64 W_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("W_ID", W_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoWebsite_Delete_DeleteById_linhnx", obj);
        }
        public static Website Insert(Website Inserted)
        {
            Website Item = new Website();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("W_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("W_Url", Inserted.Url);
            obj[2] = new SqlParameter("W_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("W_MoTa", Inserted.MoTa);
            obj[4] = new SqlParameter("W_Star", Inserted.Star);
            obj[5] = new SqlParameter("W_Active", Inserted.Active);
            obj[6] = new SqlParameter("W_Publish", Inserted.Publish);
            obj[7] = new SqlParameter("W_UserOnly", Inserted.UserOnly);
            obj[8] = new SqlParameter("W_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("W_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("W_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("W_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoWebsite_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Website(rd);
                }
            }
            return Item;
        }
        public static Website Insert(Website Inserted, SqlConnection con)
        {
            Website Item = new Website();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("W_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("W_Url", Inserted.Url);
            obj[2] = new SqlParameter("W_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("W_MoTa", Inserted.MoTa);
            obj[4] = new SqlParameter("W_Star", Inserted.Star);
            obj[5] = new SqlParameter("W_Active", Inserted.Active);
            obj[6] = new SqlParameter("W_Publish", Inserted.Publish);
            obj[7] = new SqlParameter("W_UserOnly", Inserted.UserOnly);
            obj[8] = new SqlParameter("W_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("W_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("W_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("W_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoWebsite_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Website(rd);
                }
            }
            return Item;
        }
        public static Website Update(Website Updated)
        {
            Website Item = new Website();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("W_ID", Updated.ID);
            obj[1] = new SqlParameter("W_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("W_Url", Updated.Url);
            obj[3] = new SqlParameter("W_Ten", Updated.Ten);
            obj[4] = new SqlParameter("W_MoTa", Updated.MoTa);
            obj[5] = new SqlParameter("W_Star", Updated.Star);
            obj[6] = new SqlParameter("W_Active", Updated.Active);
            obj[7] = new SqlParameter("W_Publish", Updated.Publish);
            obj[8] = new SqlParameter("W_UserOnly", Updated.UserOnly);
            obj[9] = new SqlParameter("W_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("W_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("W_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("W_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoWebsite_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Website(rd);
                }
            }
            return Item;
        }
        public static Website Update(Website Updated, SqlConnection con)
        {
            Website Item = new Website();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("W_ID", Updated.ID);
            obj[1] = new SqlParameter("W_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("W_Url", Updated.Url);
            obj[3] = new SqlParameter("W_Ten", Updated.Ten);
            obj[4] = new SqlParameter("W_MoTa", Updated.MoTa);
            obj[5] = new SqlParameter("W_Star", Updated.Star);
            obj[6] = new SqlParameter("W_Active", Updated.Active);
            obj[7] = new SqlParameter("W_Publish", Updated.Publish);
            obj[8] = new SqlParameter("W_UserOnly", Updated.UserOnly);
            obj[9] = new SqlParameter("W_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("W_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("W_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("W_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoWebsite_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Website(rd);
                }
            }
            return Item;
        }
        public static Website SelectById(Int64 W_ID)
        {
            Website Item = new Website();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("W_ID", W_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoWebsite_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Website(rd);
                }
            }
            return Item;
        }
        public static Website SelectById(Int64 W_ID, SqlConnection con)
        {
            Website Item = new Website();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("W_ID", W_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoWebsite_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Website(rd);
                }
            }
            return Item;
        }
        public static WebsiteCollection SelectAll()
        {
            WebsiteCollection List = new WebsiteCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoWebsite_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new Website(rd));
                }
            }
            return List;
        }
        public static WebsiteCollection SelectAll(SqlConnection con)
        {
            WebsiteCollection List = new WebsiteCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoWebsite_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new Website(rd));
                }
            }
            return List;
        }
        public static Pager<Website> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Website> pg = new Pager<Website>("tblSeo_sp_tblWebsite_Pager_Normal_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Website> pagerUser(string url, bool rewrite, string sort, string Username)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("Username", Username);
            Pager<Website> pg = new Pager<Website>("tblSeo_sp_tblWebsite_Pager_pagerUser_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Website> pagerNormal(SqlConnection con, string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Website> pg = new Pager<Website>(con, "tblSeo_sp_tblWebsite_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        #endregion
        #region Extend
        #endregion
    }
    #endregion
    #endregion
}


