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
    #region Comment
    #region BO
    public class Comment : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Guid P_RowId { get; set; }
        public Int32 P_ID { get; set; }
        public String NoiDung { get; set; }
        public String Ten { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public Comment()
        { }
        public Comment(IDataReader rd)
        {
            if (rd.FieldExists("C_ID"))
            {
                ID = (Int32)(rd["C_ID"]);
            }
            if (rd.FieldExists("C_P_RowId"))
            {
                P_RowId = (Guid)(rd["C_P_RowId"]);
            }
            if (rd.FieldExists("C_P_ID"))
            {
                P_ID = (Int32)(rd["C_P_ID"]);
            }
            if (rd.FieldExists("C_NoiDung"))
            {
                NoiDung = (String)(rd["C_NoiDung"]);
            }
            if (rd.FieldExists("C_Ten"))
            {
                Ten = (String)(rd["C_Ten"]);
            }
            if (rd.FieldExists("C_NguoiTao"))
            {
                NguoiTao = (String)(rd["C_NguoiTao"]);
            }
            if (rd.FieldExists("C_NgayTao"))
            {
                NgayTao = (DateTime)(rd["C_NgayTao"]);
            }
            if (rd.FieldExists("C_RowId"))
            {
                RowId = (Guid)(rd["C_RowId"]);
            }

        }
        #endregion
        #region Customs properties

        #endregion
        #region getFromReader
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return new Comment(rd);
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
    public class CommentCollection : BaseEntityCollection<Comment>
    { }
    #endregion
    #region Dal
    public class CommentDal
    {
        #region Methods

        public static void DeleteById(Int32 C_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("C_ID", C_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblComment_Delete_DeleteById_linhnx", obj);
        }
        public static Comment Insert(Comment Inserted)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("C_P_RowId", Inserted.P_RowId);
            obj[1] = new SqlParameter("C_P_ID", Inserted.P_ID);
            obj[2] = new SqlParameter("C_NoiDung", Inserted.NoiDung);
            obj[3] = new SqlParameter("C_Ten", Inserted.Ten);
            obj[4] = new SqlParameter("C_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("C_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("C_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("C_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblComment_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Comment(rd);
                }
            }
            return Item;
        }
        public static Comment Insert(Comment Inserted, SqlConnection con)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("C_P_RowId", Inserted.P_RowId);
            obj[1] = new SqlParameter("C_P_ID", Inserted.P_ID);
            obj[2] = new SqlParameter("C_NoiDung", Inserted.NoiDung);
            obj[3] = new SqlParameter("C_Ten", Inserted.Ten);
            obj[4] = new SqlParameter("C_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("C_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("C_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("C_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblComment_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Comment(rd);
                }
            }
            return Item;
        }
        public static Comment Update(Comment Updated)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("C_ID", Updated.ID);
            obj[1] = new SqlParameter("C_P_RowId", Updated.P_RowId);
            obj[2] = new SqlParameter("C_P_ID", Updated.P_ID);
            obj[3] = new SqlParameter("C_NoiDung", Updated.NoiDung);
            obj[4] = new SqlParameter("C_Ten", Updated.Ten);
            obj[5] = new SqlParameter("C_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("C_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("C_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("C_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblComment_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Comment(rd);
                }
            }
            return Item;
        }
        public static Comment Update(Comment Updated, SqlConnection con)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("C_ID", Updated.ID);
            obj[1] = new SqlParameter("C_P_RowId", Updated.P_RowId);
            obj[2] = new SqlParameter("C_P_ID", Updated.P_ID);
            obj[3] = new SqlParameter("C_NoiDung", Updated.NoiDung);
            obj[4] = new SqlParameter("C_Ten", Updated.Ten);
            obj[5] = new SqlParameter("C_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("C_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("C_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("C_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblComment_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Comment(rd);
                }
            }
            return Item;
        }
        public static Comment SelectById(Int32 C_ID)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("C_ID", C_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblComment_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Comment(rd);
                }
            }
            return Item;
        }
        public static Comment SelectById(Int32 C_ID, SqlConnection con)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("C_ID", C_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblComment_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Comment(rd);
                }
            }
            return Item;
        }
        public static CommentCollection SelectAll()
        {
            CommentCollection List = new CommentCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblComment_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new Comment(rd));
                }
            }
            return List;
        }
        public static CommentCollection SelectAll(SqlConnection con)
        {
            CommentCollection List = new CommentCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblComment_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new Comment(rd));
                }
            }
            return List;
        }
        public static Pager<Comment> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Comment> pg = new Pager<Comment>("tbl_sp_tblComment_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Comment> pagerNormal(SqlConnection con, string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Comment> pg = new Pager<Comment>(con, "tbl_sp_tblComment_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        #endregion
        #region Extend
        public static Pager<Comment> pagerByPId(string sort, int size, string P_ID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("P_ID", P_ID);
            Pager<Comment> pg = new Pager<Comment>("tbl_sp_tblComment_Pager_pagerByPId_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        #endregion
    }
    #endregion
    #endregion
}


