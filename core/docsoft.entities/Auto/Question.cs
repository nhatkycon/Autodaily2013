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
    #region Question
    #region BO
    public class Question : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid G_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String Anh { get; set; }
        public String AnhDaiDien { get; set; }
        public String ThuTu { get; set; }
        public Boolean Active { get; set; }
        #endregion
        #region Contructor
        public Question()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return QuestionDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class QuestionCollection : BaseEntityCollection<Question>
    { }
    #endregion
    #region Dal
    public class QuestionDal
    {
        #region Methods

        public static void DeleteById(Guid Q_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Q_ID", Q_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Question_Delete_DeleteById_linhnx", obj);
        }

        public static Question Insert(Question item)
        {
            var Item = new Question();
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Q_ID", item.ID);
            obj[1] = new SqlParameter("Q_G_ID", item.G_ID);
            obj[2] = new SqlParameter("Q_Ten", item.Ten);
            obj[3] = new SqlParameter("Q_MoTa", item.MoTa);
            obj[4] = new SqlParameter("Q_Anh", item.Anh);
            obj[5] = new SqlParameter("Q_AnhDaiDien", item.AnhDaiDien);
            obj[6] = new SqlParameter("Q_ThuTu", item.ThuTu);
            obj[7] = new SqlParameter("Q_Active", item.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Question_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Question Update(Question item)
        {
            var Item = new Question();
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Q_ID", item.ID);
            obj[1] = new SqlParameter("Q_G_ID", item.G_ID);
            obj[2] = new SqlParameter("Q_Ten", item.Ten);
            obj[3] = new SqlParameter("Q_MoTa", item.MoTa);
            obj[4] = new SqlParameter("Q_Anh", item.Anh);
            obj[5] = new SqlParameter("Q_AnhDaiDien", item.AnhDaiDien);
            obj[6] = new SqlParameter("Q_ThuTu", item.ThuTu);
            obj[7] = new SqlParameter("Q_Active", item.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Question_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Question SelectById(Guid Q_ID)
        {
            var Item = new Question();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Q_ID", Q_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Question_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuestionCollection SelectAll()
        {
            var List = new QuestionCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Question_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Question> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<Question>("sp_tblAuto_Question_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Question getFromReader(IDataReader rd)
        {
            var Item = new Question();
            if (rd.FieldExists("Q_ID"))
            {
                Item.ID = (Guid)(rd["Q_ID"]);
            }
            if (rd.FieldExists("Q_G_ID"))
            {
                Item.G_ID = (Guid)(rd["Q_G_ID"]);
            }
            if (rd.FieldExists("Q_Ten"))
            {
                Item.Ten = (String)(rd["Q_Ten"]);
            }
            if (rd.FieldExists("Q_MoTa"))
            {
                Item.MoTa = (String)(rd["Q_MoTa"]);
            }
            if (rd.FieldExists("Q_Anh"))
            {
                Item.Anh = (String)(rd["Q_Anh"]);
            }
            if (rd.FieldExists("Q_AnhDaiDien"))
            {
                Item.AnhDaiDien = (String)(rd["Q_AnhDaiDien"]);
            }
            if (rd.FieldExists("Q_ThuTu"))
            {
                Item.ThuTu = (String)(rd["Q_ThuTu"]);
            }
            if (rd.FieldExists("Q_Active"))
            {
                Item.Active = (Boolean)(rd["Q_Active"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static QuestionCollection SelectByGameId(SqlConnection con, string G_ID)
        {
            var List = new QuestionCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("G_ID", G_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAuto_Question_Select_SelectByGameId_linhnx", obj))
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


