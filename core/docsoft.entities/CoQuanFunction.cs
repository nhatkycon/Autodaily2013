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
    #region CoQuanFunction
    #region BO
    public class CoQuanFunction : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 FN_ID { get; set; }
        public Int32 CQ_ID { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        #endregion
        #region Contructor
        public CoQuanFunction()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return CoQuanFunctionDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class CoQuanFunctionCollection : BaseEntityCollection<CoQuanFunction>
    { }
    #endregion
    #region Dal
    public class CoQuanFunctionDal
    {
        #region Methods

        public static void DeleteById(Int32 CF_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CF_ID", CF_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuanFunction_Delete_DeleteById_linhnx", obj);
        }

        public static CoQuanFunction Insert(CoQuanFunction Inserted)
        {
            CoQuanFunction Item = new CoQuanFunction();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("CF_FN_ID", Inserted.FN_ID);
            obj[1] = new SqlParameter("CF_CQ_ID", Inserted.CQ_ID);
            obj[2] = new SqlParameter("CF_NgayTao", Inserted.NgayTao);
            obj[3] = new SqlParameter("CF_NgayCapNhat", Inserted.NgayCapNhat);
            obj[4] = new SqlParameter("CF_NguoiTao", Inserted.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuanFunction_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static CoQuanFunction Update(CoQuanFunction Updated)
        {
            CoQuanFunction Item = new CoQuanFunction();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("CF_ID", Updated.ID);
            obj[1] = new SqlParameter("CF_FN_ID", Updated.FN_ID);
            obj[2] = new SqlParameter("CF_CQ_ID", Updated.CQ_ID);
            obj[3] = new SqlParameter("CF_NgayTao", Updated.NgayTao);
            obj[4] = new SqlParameter("CF_NgayCapNhat", Updated.NgayCapNhat);
            obj[5] = new SqlParameter("CF_NguoiTao", Updated.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuanFunction_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        /// <summary>
        /// Update cơ quan function bằng cách xóa các function trong cơ quan function rồi chèn vào danh sách các function mới
        /// </summary>
        /// <param name="CF_CQ_ID"></param>
        /// <param name="UpdateList"></param>
        /// <param name="CF_NguoiTao"></param>
        /// <returns></returns>
        public static string UpdateByUpdateListAndCQID(string CF_CQ_ID, string UpdateList, string CF_NguoiTao)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[1] = new SqlParameter("UpdateList", UpdateList);
            obj[2] = new SqlParameter("CF_CQ_ID", CF_CQ_ID);
            obj[0] = new SqlParameter("CF_NguoiTao", CF_NguoiTao);
            return SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuanFunction_Update_UpdateByUpdateListAndCQID_linhnx", obj).ToString();
        }

        public static CoQuanFunction SelectById(Int32 CF_ID)
        {
            CoQuanFunction Item = new CoQuanFunction();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CF_ID", CF_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuanFunction_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static CoQuanFunctionCollection SelectAll()
        {
            CoQuanFunctionCollection List = new CoQuanFunctionCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuanFunction_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<CoQuanFunction> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<CoQuanFunction> pg = new Pager<CoQuanFunction>("sp_tblCoQuanFunction_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static CoQuanFunction getFromReader(IDataReader rd)
        {
            CoQuanFunction Item = new CoQuanFunction();
            Item.ID = (Int32)(rd["CF_ID"]);
            Item.FN_ID = (Int32)(rd["CF_FN_ID"]);
            Item.CQ_ID = (Int32)(rd["CF_CQ_ID"]);
            Item.NgayTao = (DateTime)(rd["CF_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["CF_NgayCapNhat"]);
            Item.NguoiTao = (String)(rd["CF_NguoiTao"]);
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion

}


