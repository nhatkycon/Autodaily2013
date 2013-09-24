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
    #region Tag
    #region BO
    public class Tag : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public Int32 SoLuong { get; set; }
        #endregion
        #region Contructor
        public Tag()
        { }
        public Tag(Int32? id, String ten, Int32? soluong)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            Ten = ten;
            if (soluong != null)
            {
                SoLuong = soluong.Value;
            }

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TagDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TagCollection : BaseEntityCollection<Tag>
    { }
    #endregion
    #region Dal
    public class TagDal
    {
        #region Methods

        public static void DeleteById(Int32 TAG_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TAG_ID", TAG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTag_Delete_DeleteById_linhnx", obj);
        }
        public static Tag Insert(Tag Inserted)
        {
            Tag Item = new Tag();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TAG_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("TAG_SoLuong", Inserted.SoLuong);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTag_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tag Insert(Int32? id, String ten, Int32? soluong,Int32? tin_id)
        {
            Tag Item = new Tag();
            SqlParameter[] obj = new SqlParameter[3];
            if (ten != null)
            {
                obj[0] = new SqlParameter("TAG_Ten", ten);
            }
            else
            {
                obj[0] = new SqlParameter("TAG_Ten", DBNull.Value);
            }
            if (soluong != null)
            {
                obj[1] = new SqlParameter("TAG_SoLuong", soluong);
            }
            else
            {
                obj[1] = new SqlParameter("TAG_SoLuong", DBNull.Value);
            }
            if (tin_id != null)
            {
                obj[2] = new SqlParameter("TIN_ID", tin_id);
            }
            else
            {
                obj[2] = new SqlParameter("TIN_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTag_Insert_InsertTin_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tag Update(Tag Updated)
        {
            Tag Item = new Tag();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TAG_ID", Updated.ID);
            obj[1] = new SqlParameter("TAG_Ten", Updated.Ten);
            obj[2] = new SqlParameter("TAG_SoLuong", Updated.SoLuong);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTag_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tag Update(Int32? id, String ten, Int32? soluong)
        {
            Tag Item = new Tag();
            SqlParameter[] obj = new SqlParameter[3];
            if (id != null)
            {
                obj[0] = new SqlParameter("TAG_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("TAG_ID", DBNull.Value);
            }
            if (ten != null)
            {
                obj[1] = new SqlParameter("TAG_Ten", ten);
            }
            else
            {
                obj[1] = new SqlParameter("TAG_Ten", DBNull.Value);
            }
            if (soluong != null)
            {
                obj[2] = new SqlParameter("TAG_SoLuong", soluong);
            }
            else
            {
                obj[2] = new SqlParameter("TAG_SoLuong", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTag_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tag SelectById(Int32 TAG_ID)
        {
            Tag Item = new Tag();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TAG_ID", TAG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTag_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TagCollection SelectAll()
        {
            TagCollection List = new TagCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTag_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tag> pagerNormal(string url, bool rewrite, string sort,string q)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            Pager<Tag> pg = new Pager<Tag>("tblRss_sp_tblTag_Pager_Normal_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Tag getFromReader(IDataReader rd)
        {
            Tag Item = new Tag();
            if (rd.FieldExists("TAG_ID"))
            {
                Item.ID = (Int32)(rd["TAG_ID"]);
            }
            if (rd.FieldExists("TAG_Ten"))
            {
                Item.Ten = (String)(rd["TAG_Ten"]);
            }
            if (rd.FieldExists("TAG_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["TAG_SoLuong"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static TagCollection SelectTagCloud(int top)
        {
            TagCollection List = new TagCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure
                , "tblRss_sp_tblRssTag_Select_SelectTagCloud_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TagCollection SelectByTinId(int Tin_Id)
        {
            TagCollection List = new TagCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Tin_Id", Tin_Id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure
                , "tblRss_sp_tblRssTag_Select_SelectByTinId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TagCollection SelectByTinId(SqlConnection con, int Tin_Id)
        {
            TagCollection List = new TagCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Tin_Id", Tin_Id);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure
                , "tblRss_sp_tblRssTag_Select_SelectByTinId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion
    #endregion
}
