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
    #region Comment
    #region BO
    public class Comment : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 PID { get; set; }
        public Int32 C_ID { get; set; }
        public String KH_Ten { get; set; }
        public String KH_Email { get; set; }
        public String KH_Mobile { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Active { get; set; }
        public Boolean Readed { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String Anh { get; set; }
        #endregion
        #region Contructor
        public Comment()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return CommentDal.getFromReader(rd);
        }
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
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Delete_DeleteById_hoangda", obj);
        }

        public static Comment Insert(Comment item)
        {
            var Item = new Comment();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("C_ID", item.ID);
            obj[1] = new SqlParameter("C_PID", item.PID);
            obj[2] = new SqlParameter("C_C_ID", item.C_ID);
            obj[3] = new SqlParameter("C_KH_Ten", item.KH_Ten);
            obj[4] = new SqlParameter("C_KH_Email", item.KH_Email);
            obj[5] = new SqlParameter("C_KH_Mobile", item.KH_Mobile);
            obj[6] = new SqlParameter("C_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("C_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("C_NgayTao", DBNull.Value);
            }
            obj[8] = new SqlParameter("C_Active", item.Active);
            obj[9] = new SqlParameter("C_Readed", item.Readed);
            obj[10] = new SqlParameter("C_Ten", item.Ten);
            obj[11] = new SqlParameter("C_MoTa", item.MoTa);
            obj[12] = new SqlParameter("C_Anh", item.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Comment Update(Comment item)
        {
            var Item = new Comment();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("C_ID", item.ID);
            obj[1] = new SqlParameter("C_PID", item.PID);
            obj[2] = new SqlParameter("C_C_ID", item.C_ID);
            obj[3] = new SqlParameter("C_KH_Ten", item.KH_Ten);
            obj[4] = new SqlParameter("C_KH_Email", item.KH_Email);
            obj[5] = new SqlParameter("C_KH_Mobile", item.KH_Mobile);
            obj[6] = new SqlParameter("C_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("C_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("C_NgayTao", DBNull.Value);
            }
            obj[8] = new SqlParameter("C_Active", item.Active);
            obj[9] = new SqlParameter("C_Readed", item.Readed);
            obj[10] = new SqlParameter("C_Ten", item.Ten);
            obj[11] = new SqlParameter("C_MoTa", item.MoTa);
            obj[12] = new SqlParameter("C_Anh", item.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Comment SelectById(Int32 C_ID)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("C_ID", C_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static CommentCollection SelectAll()
        {
            CommentCollection List = new CommentCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Comment> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<Comment> pg = new Pager<Comment>("sp_tblComment_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Comment getFromReader(IDataReader rd)
        {
            var Item = new Comment();
            if (rd.FieldExists("C_ID"))
            {
                Item.ID = (Int32)(rd["C_ID"]);
            }
            if (rd.FieldExists("C_PID"))
            {
                Item.PID = (Int32)(rd["C_PID"]);
            }
            if (rd.FieldExists("C_C_ID"))
            {
                Item.C_ID = (Int32)(rd["C_C_ID"]);
            }
            if (rd.FieldExists("C_KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["C_KH_Ten"]);
            }
            if (rd.FieldExists("C_KH_Email"))
            {
                Item.KH_Email = (String)(rd["C_KH_Email"]);
            }
            if (rd.FieldExists("C_KH_Mobile"))
            {
                Item.KH_Mobile = (String)(rd["C_KH_Mobile"]);
            }
            if (rd.FieldExists("C_NoiDung"))
            {
                Item.NoiDung = (String)(rd["C_NoiDung"]);
            }
            if (rd.FieldExists("C_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["C_NgayTao"]);
            }
            if (rd.FieldExists("C_Active"))
            {
                Item.Active = (Boolean)(rd["C_Active"]);
            }
            if (rd.FieldExists("C_Readed"))
            {
                Item.Readed = (Boolean)(rd["C_Readed"]);
            }
            if (rd.FieldExists("C_Ten"))
            {
                Item.Ten = (String)(rd["C_Ten"]);
            }
            if (rd.FieldExists("C_MoTa"))
            {
                Item.MoTa = (String)(rd["C_MoTa"]);
            }
            if (rd.FieldExists("C_Anh"))
            {
                Item.Anh = (String)(rd["C_Anh"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void ReadedById(Int32 C_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("C_ID", C_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Update_ReadedById_hoangda", obj);
        }
        public static Pager<Comment> pagerNormal(string q, string total)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", DBNull.Value);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            Pager<Comment> pg = new Pager<Comment>("sp_tblComment_Pager_Normal_hoangda", "page", Convert.ToInt32(total), 10, false, string.Empty, obj);
            return pg;
        }
        public static CommentCollection SelectActive(int Top)
        {
            CommentCollection List = new CommentCollection();
            SqlParameter[] obj = new SqlParameter[] { 
                new SqlParameter("Top",Top)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Select_SelectActive_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static CommentCollection SelectActive(int Top, string _ID)
        {
            CommentCollection List = new CommentCollection();
            SqlParameter[] obj = new SqlParameter[] { 
                new SqlParameter("Top",Top),
                new SqlParameter("ID",_ID)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Select_SelectActive_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static void ActiveById(string _id)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("id", _id);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Update_ActiveById_hoangda", obj);
        }

        public static Pager<Comment> pagerActive(SqlConnection con, string q, string total, string active)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", DBNull.Value);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(active))
            {
                obj[2] = new SqlParameter("active", active);
            }
            else
            {
                obj[2] = new SqlParameter("active", DBNull.Value);
            }

            Pager<Comment> pg = new Pager<Comment>(con, "sp_tblComment_Pager_Active_linhnx", "page", Convert.ToInt32(total), 10, false, string.Empty, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
}


