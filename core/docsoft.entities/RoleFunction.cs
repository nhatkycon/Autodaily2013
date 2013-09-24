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
    #region RoleFunction
    #region BO
    public class RoleFunction : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 FN_ID { get; set; }
        public Int32 ROLE_ID { get; set; }
        public Boolean Active { get; set; }
        public Guid RowId { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        #endregion
        #region Contructor
        public RoleFunction()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return RoleFunctionDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class RoleFunctionCollection : BaseEntityCollection<RoleFunction>
    { }
    #endregion
    #region Dal
    public class RoleFunctionDal
    {
        #region Methods

        public static void DeleteById(Int32 RF_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("RF_ID", RF_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRoleFunction_Delete_DeleteById_linhnx", obj);
        }

        public static RoleFunction Insert(RoleFunction Inserted)
        {
            RoleFunction Item = new RoleFunction();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("RF_FN_ID", Inserted.FN_ID);
            obj[1] = new SqlParameter("RF_ROLE_ID", Inserted.ROLE_ID);
            obj[2] = new SqlParameter("RF_Active", Inserted.Active);
            obj[3] = new SqlParameter("RF_RowId", Inserted.RowId);
            obj[4] = new SqlParameter("RF_NguoiTao", Inserted.NguoiTao);
            obj[5] = new SqlParameter("RF_NgayTao", Inserted.NgayTao);
            obj[6] = new SqlParameter("RF_NgayCapNhat", Inserted.NgayCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRoleFunction_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static RoleFunction UpdateByRoleIdFunctionList(string ROLE_ID, string FN_List, string NguoiTao)
        {
            RoleFunction Item = new RoleFunction();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("ROLE_ID", ROLE_ID);
            obj[1] = new SqlParameter("FN_List", FN_List);
            obj[2] = new SqlParameter("NguoiTao", NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRoleFunction_Update_UpdateByRoleIdFunctionList_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static RoleFunction Update(RoleFunction Updated)
        {
            RoleFunction Item = new RoleFunction();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("RF_ID", Updated.ID);
            obj[1] = new SqlParameter("RF_FN_ID", Updated.FN_ID);
            obj[2] = new SqlParameter("RF_ROLE_ID", Updated.ROLE_ID);
            obj[3] = new SqlParameter("RF_Active", Updated.Active);
            obj[4] = new SqlParameter("RF_RowId", Updated.RowId);
            obj[5] = new SqlParameter("RF_NguoiTao", Updated.NguoiTao);
            obj[6] = new SqlParameter("RF_NgayTao", Updated.NgayTao);
            obj[7] = new SqlParameter("RF_NgayCapNhat", Updated.NgayCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRoleFunction_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static RoleFunction SelectById(Int32 RF_ID)
        {
            RoleFunction Item = new RoleFunction();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("RF_ID", RF_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRoleFunction_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static RoleFunctionCollection SelectAll()
        {
            RoleFunctionCollection List = new RoleFunctionCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRoleFunction_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<RoleFunction> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<RoleFunction> pg = new Pager<RoleFunction>("sp_tblRoleFunction_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static RoleFunction getFromReader(IDataReader rd)
        {
            RoleFunction Item = new RoleFunction();
            Item.ID = (Int32)(rd["RF_ID"]);
            Item.FN_ID = (Int32)(rd["RF_FN_ID"]);
            Item.ROLE_ID = (Int32)(rd["RF_ROLE_ID"]);
            Item.Active = (Boolean)(rd["RF_Active"]);
            Item.RowId = (Guid)(rd["RF_RowId"]);
            Item.NguoiTao = (String)(rd["RF_NguoiTao"]);
            Item.NgayTao = (DateTime)(rd["RF_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["RF_NgayCapNhat"]);
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
    
}


