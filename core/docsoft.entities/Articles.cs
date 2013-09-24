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
    #region Articles
    #region BO
    public class Articles : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 PortalID { get; set; }
        public String Subject { get; set; }
        public String Title { get; set; }
        public String Summary { get; set; }
        public String Content { get; set; }
        public Int32 SourceID { get; set; }
        public Int32 PhotoID { get; set; }
        public String PhotoPath { get; set; }
        public String VideoPath { get; set; }
        public Boolean Checked { get; set; }
        public Int32 Counter { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime DisplayTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime ReviewedTime { get; set; }
        public String CreatedBy { get; set; }
        public String UpdatedBy { get; set; }
        public String ReviewedBy { get; set; }
        public Int32 DesktopViewID { get; set; }
        public String Language { get; set; }
        public String FileAttath { get; set; }
        #endregion
        #region Contructor
        public Articles()
        { }
        #endregion

        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ArticlesDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ArticlesCollection : BaseEntityCollection<Articles>
    { }
    #endregion
    #region Dal
    public class ArticlesDal
    {
        #region Methods

        public static void DeleteById(Int32 ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ID", ID);
            SqlHelper.ExecuteNonQuery(linh.core.dal.DAL.con(), CommandType.StoredProcedure, "sp_Articles_Delete_DeleteById_linhnx", obj);
        }

        public static Articles Insert(Articles Inserted)
        {
            Articles Item = new Articles();
            SqlParameter[] obj = new SqlParameter[21];
            obj[0] = new SqlParameter("PortalID", Inserted.PortalID);
            obj[1] = new SqlParameter("Subject", Inserted.Subject);
            obj[2] = new SqlParameter("Title", Inserted.Title);
            obj[3] = new SqlParameter("Summary", Inserted.Summary);
            obj[4] = new SqlParameter("Content", Inserted.Content);
            obj[5] = new SqlParameter("SourceID", Inserted.SourceID);
            obj[6] = new SqlParameter("PhotoID", Inserted.PhotoID);
            obj[7] = new SqlParameter("PhotoPath", Inserted.PhotoPath);
            obj[8] = new SqlParameter("VideoPath", Inserted.VideoPath);
            obj[9] = new SqlParameter("Checked", Inserted.Checked);
            obj[10] = new SqlParameter("Counter", Inserted.Counter);
            obj[11] = new SqlParameter("CreatedTime", Inserted.CreatedTime);
            obj[12] = new SqlParameter("DisplayTime", Inserted.DisplayTime);
            obj[13] = new SqlParameter("UpdatedTime", Inserted.UpdatedTime);
            obj[14] = new SqlParameter("ReviewedTime", Inserted.ReviewedTime);
            obj[15] = new SqlParameter("CreatedBy", Inserted.CreatedBy);
            obj[16] = new SqlParameter("UpdatedBy", Inserted.UpdatedBy);
            obj[17] = new SqlParameter("ReviewedBy", Inserted.ReviewedBy);
            obj[18] = new SqlParameter("DesktopViewID", Inserted.DesktopViewID);
            obj[19] = new SqlParameter("Language", Inserted.Language);
            obj[20] = new SqlParameter("FileAttath", Inserted.FileAttath);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_Articles_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Articles Update(Articles Updated)
        {
            Articles Item = new Articles();
            SqlParameter[] obj = new SqlParameter[22];
            obj[0] = new SqlParameter("ID", Updated.ID);
            obj[1] = new SqlParameter("PortalID", Updated.PortalID);
            obj[2] = new SqlParameter("Subject", Updated.Subject);
            obj[3] = new SqlParameter("Title", Updated.Title);
            obj[4] = new SqlParameter("Summary", Updated.Summary);
            obj[5] = new SqlParameter("Content", Updated.Content);
            obj[6] = new SqlParameter("SourceID", Updated.SourceID);
            obj[7] = new SqlParameter("PhotoID", Updated.PhotoID);
            obj[8] = new SqlParameter("PhotoPath", Updated.PhotoPath);
            obj[9] = new SqlParameter("VideoPath", Updated.VideoPath);
            obj[10] = new SqlParameter("Checked", Updated.Checked);
            obj[11] = new SqlParameter("Counter", Updated.Counter);
            obj[12] = new SqlParameter("CreatedTime", Updated.CreatedTime);
            obj[13] = new SqlParameter("DisplayTime", Updated.DisplayTime);
            obj[14] = new SqlParameter("UpdatedTime", Updated.UpdatedTime);
            obj[15] = new SqlParameter("ReviewedTime", Updated.ReviewedTime);
            obj[16] = new SqlParameter("CreatedBy", Updated.CreatedBy);
            obj[17] = new SqlParameter("UpdatedBy", Updated.UpdatedBy);
            obj[18] = new SqlParameter("ReviewedBy", Updated.ReviewedBy);
            obj[19] = new SqlParameter("DesktopViewID", Updated.DesktopViewID);
            obj[20] = new SqlParameter("Language", Updated.Language);
            obj[21] = new SqlParameter("FileAttath", Updated.FileAttath);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_Articles_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Articles SelectById(Int32 ID)
        {
            Articles Item = new Articles();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ID", ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_Articles_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ArticlesCollection SelectAll()
        {
            ArticlesCollection List = new ArticlesCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_Articles_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Articles> pagerNormal(string url, bool rewrite, string sort,
            string title,
            string summary,
            string content,
            string _userID,
            string CreatedTime,
            string UpdatedTime, string pagesize
            )
        {
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("Sort", sort);


            if (string.IsNullOrEmpty(title))
            {
                obj[1] = new SqlParameter("Title", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("Title", title);
            }
            if (string.IsNullOrEmpty(summary))
            {
                obj[2] = new SqlParameter("Summary", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("Summary", summary);
            }

            if (string.IsNullOrEmpty(content))
            {
                obj[3] = new SqlParameter("Content", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("Content", content);
            }

            if (string.IsNullOrEmpty(_userID))
            {
                obj[4] = new SqlParameter("SourceID", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("SourceID", _userID);
            }

            if (string.IsNullOrEmpty(CreatedTime))
            {
                obj[5] = new SqlParameter("CreatedTime", DBNull.Value);
            }
            else
            {
                obj[5] = new SqlParameter("CreatedTime", CreatedTime);
            }

            if (string.IsNullOrEmpty(UpdatedTime))
            {
                obj[6] = new SqlParameter("UpdatedTime", DBNull.Value);
            }
            else
            {
                obj[6] = new SqlParameter("UpdatedTime", UpdatedTime);
            }
            Pager<Articles> pg = new Pager<Articles>("sp_Articles_Pager_Normal_linhnx", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
          //  Pager<Articles> pg = new Pager<Articles>("sp_Articles_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);

            return pg;
        }
        #endregion

        #region Utilities
        public static Articles getFromReader(IDataReader rd)
        {
            Articles Item = new Articles();
            if (rd.FieldExists("ID"))
            {
                Item.ID = (Int32)(rd["ID"]);
            }
            if (rd.FieldExists("PortalID"))
            {
                Item.PortalID = (Int32)(rd["PortalID"]);
            }
            if (rd.FieldExists("Subject"))
            {
                Item.Subject = (String)(rd["Subject"]);
            }
            if (rd.FieldExists("Title"))
            {
                Item.Title = (String)(rd["Title"]);
            }
            if (rd.FieldExists("Summary"))
            {
                Item.Summary = (String)(rd["Summary"]);
            }
            if (rd.FieldExists("Content"))
            {
                Item.Content = (String)(rd["Content"]);
            }
            if (rd.FieldExists("SourceID"))
            {
                Item.SourceID = (Int32)(rd["SourceID"]);
            }
            if (rd.FieldExists("PhotoID"))
            {
                Item.PhotoID = (Int32)(rd["PhotoID"]);
            }
            if (rd.FieldExists("PhotoPath"))
            {
                Item.PhotoPath = (String)(rd["PhotoPath"]);
            }
            if (rd.FieldExists("VideoPath"))
            {
                Item.VideoPath = (String)(rd["VideoPath"]);
            }
            if (rd.FieldExists("Checked"))
            {
                Item.Checked = (Boolean)(rd["Checked"]);
            }
            if (rd.FieldExists("Counter"))
            {
                Item.Counter = (Int32)(rd["Counter"]);
            }
            if (rd.FieldExists("CreatedTime"))
            {
                Item.CreatedTime = (DateTime)(rd["CreatedTime"]);
            }
            if (rd.FieldExists("DisplayTime"))
            {
                Item.DisplayTime = (DateTime)(rd["DisplayTime"]);
            }
            if (rd.FieldExists("UpdatedTime"))
            {
                Item.UpdatedTime = (DateTime)(rd["UpdatedTime"]);
            }
            if (rd.FieldExists("ReviewedTime"))
            {
                Item.ReviewedTime = (DateTime)(rd["ReviewedTime"]);
            }
            if (rd.FieldExists("CreatedBy"))
            {
                Item.CreatedBy = (String)(rd["CreatedBy"]);
            }
            if (rd.FieldExists("UpdatedBy"))
            {
                Item.UpdatedBy = (String)(rd["UpdatedBy"]);
            }
            if (rd.FieldExists("ReviewedBy"))
            {
                Item.ReviewedBy = (String)(rd["ReviewedBy"]);
            }
            if (rd.FieldExists("DesktopViewID"))
            {
                Item.DesktopViewID = (Int32)(rd["DesktopViewID"]);
            }
            if (rd.FieldExists("Language"))
            {
                Item.Language = (String)(rd["Language"]);
            }
            if (rd.FieldExists("FileAttath"))
            {
                Item.FileAttath = (String)(rd["FileAttath"]);
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
