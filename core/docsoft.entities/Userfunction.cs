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
    #region UserFunction
    #region BO
    public class UserFunction : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Username { get; set; }
        public Int32 LAY_ID { get; set; }
        public Int32 FN_ID { get; set; }
        public String FN_Url { get; set; }
        public String Doc { get; set; }
        public Int32 ThuTu { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        #endregion
        #region Contructor
        public UserFunction()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return UserFunctionDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class UserFunctionCollection : BaseEntityCollection<UserFunction>
    { }
    #endregion
    #region Dal
    public class UserFunctionDal
    {
        #region Methods

        public static void DeleteById(Int32 UF_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("UF_ID", UF_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblUserFunction_Delete_DeleteById_linhnx", obj);
        }

        public static UserFunction Insert(UserFunction Inserted)
        {
            UserFunction Item = new UserFunction();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("UF_Username", Inserted.Username);
            obj[1] = new SqlParameter("UF_LAY_ID", Inserted.LAY_ID);
            obj[2] = new SqlParameter("UF_FN_ID", Inserted.FN_ID);
            obj[3] = new SqlParameter("UF_FN_Url", Inserted.FN_Url);
            obj[4] = new SqlParameter("UF_Doc", Inserted.Doc);
            obj[5] = new SqlParameter("UF_ThuTu", Inserted.ThuTu);
            obj[6] = new SqlParameter("UF_RowId", Inserted.RowId);
            obj[7] = new SqlParameter("UF_NgayTao", Inserted.NgayTao);
            obj[8] = new SqlParameter("UF_NguoiTao", Inserted.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblUserFunction_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static UserFunction Update(UserFunction Updated)
        {
            UserFunction Item = new UserFunction();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("UF_ID", Updated.ID);
            obj[1] = new SqlParameter("UF_Username", Updated.Username);
            obj[2] = new SqlParameter("UF_LAY_ID", Updated.LAY_ID);
            obj[3] = new SqlParameter("UF_FN_ID", Updated.FN_ID);
            obj[4] = new SqlParameter("UF_FN_Url", Updated.FN_Url);
            obj[5] = new SqlParameter("UF_Doc", Updated.Doc);
            obj[6] = new SqlParameter("UF_ThuTu", Updated.ThuTu);
            obj[7] = new SqlParameter("UF_RowId", Updated.RowId);
            obj[8] = new SqlParameter("UF_NgayTao", Updated.NgayTao);
            obj[9] = new SqlParameter("UF_NguoiTao", Updated.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblUserFunction_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static UserFunction SelectById(Int32 UF_ID)
        {
            UserFunction Item = new UserFunction();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("UF_ID", UF_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblUserFunction_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static void UpdateReorder(string List)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("List", List);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblUserFunction_Update_Reorder_linhnx", obj);
        }

        public static UserFunctionCollection SelecbyLayOutId(Int32 LayID)
        {
            UserFunctionCollection List = new UserFunctionCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LAY_ID", LayID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblUserFunction_Select_byLayOutId_linhnx",obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }


        public static UserFunctionCollection SelectAll()
        {
            UserFunctionCollection List = new UserFunctionCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblUserFunction_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<UserFunction> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<UserFunction> pg = new Pager<UserFunction>("sp_tblUserFunction_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static UserFunction getFromReader(IDataReader rd)
        {
            UserFunction Item = new UserFunction();
            Item.ID = (Int32)(rd["UF_ID"]);
            Item.Username = (String)(rd["UF_Username"]);
            Item.LAY_ID = (Int32)(rd["UF_LAY_ID"]);
            Item.FN_ID = (Int32)(rd["UF_FN_ID"]);
            Item.FN_Url = (String)(rd["UF_FN_Url"]);
            Item.Doc = (String)(rd["UF_Doc"]);
            Item.ThuTu = (Int32)(rd["UF_ThuTu"]);
            Item.RowId = (Guid)(rd["UF_RowId"]);
            Item.NgayTao = (DateTime)(rd["UF_NgayTao"]);
            Item.NguoiTao = (String)(rd["UF_NguoiTao"]);
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
}
