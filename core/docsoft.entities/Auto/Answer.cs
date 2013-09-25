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
    #region Answer
    #region BO
    public class Answer : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid Q_ID { get; set; }
        public String Ten { get; set; }
        public Int32 ThuTu { get; set; }
        public String Anh { get; set; }
        #endregion
        #region Contructor
        public Answer()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return AnswerDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class AnswerCollection : BaseEntityCollection<Answer>
    { }
    #endregion
    #region Dal
    public class AnswerDal
    {
        #region Methods

        public static void DeleteById(Guid A_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("A_ID", A_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Answer_Delete_DeleteById_linhnx", obj);
        }

        public static Answer Insert(Answer item)
        {
            var Item = new Answer();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("A_ID", item.ID);
            obj[1] = new SqlParameter("A_Q_ID", item.Q_ID);
            obj[2] = new SqlParameter("A_Ten", item.Ten);
            obj[3] = new SqlParameter("A_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("A_Anh", item.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Answer_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Answer Update(Answer item)
        {
            var Item = new Answer();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("A_ID", item.ID);
            obj[1] = new SqlParameter("A_Q_ID", item.Q_ID);
            obj[2] = new SqlParameter("A_Ten", item.Ten);
            obj[3] = new SqlParameter("A_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("A_Anh", item.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Answer_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Answer SelectById(Guid A_ID)
        {
            var Item = new Answer();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("A_ID", A_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Answer_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static AnswerCollection SelectAll()
        {
            var List = new AnswerCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Answer_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Answer> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Answer>("sp_tblAuto_Answer_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Answer getFromReader(IDataReader rd)
        {
            var Item = new Answer();
            if (rd.FieldExists("A_ID"))
            {
                Item.ID = (Guid)(rd["A_ID"]);
            }
            if (rd.FieldExists("A_Q_ID"))
            {
                Item.Q_ID = (Guid)(rd["A_Q_ID"]);
            }
            if (rd.FieldExists("A_Ten"))
            {
                Item.Ten = (String)(rd["A_Ten"]);
            }
            if (rd.FieldExists("A_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["A_ThuTu"]);
            }
            if (rd.FieldExists("A_Anh"))
            {
                Item.Anh = (String)(rd["A_Anh"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static AnswerCollection SelectByQuestionId(SqlConnection con,string Q_ID)
        {
            var List = new AnswerCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Q_ID", Q_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Answer_Select_SelectByQuestionId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static AnswerCollection SelectByQuestionId(string Q_ID)
        {
            return SelectByQuestionId(DAL.con(),Q_ID);
        }
        #endregion
    }
    #endregion

    #endregion
}


