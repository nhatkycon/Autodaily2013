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
    #region MemberRole
    #region BO
    public class MemberRole : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Username { get; set; }
        public Int32 ROLE_ID { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        #endregion
        #region Contructor
        public MemberRole()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return MemberRoleDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class MemberRoleCollection : BaseEntityCollection<MemberRole>
    { }
    #endregion
    #region Dal
    public class MemberRoleDal
    {
        #region Methods

        public static void DeleteById(Int32 MR_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MR_ID", MR_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMemberRole_Delete_DeleteById_linhnx", obj);
        }

        public static MemberRole Insert(MemberRole Inserted)
        {
            MemberRole Item = new MemberRole();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("MR_Username", Inserted.Username);
            obj[1] = new SqlParameter("MR_ROLE_ID", Inserted.ROLE_ID);
            obj[2] = new SqlParameter("MR_RowId", Inserted.RowId);
            obj[3] = new SqlParameter("MR_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("MR_NgayCapNhat", Inserted.NgayCapNhat);
            obj[5] = new SqlParameter("MR_NguoiTao", Inserted.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMemberRole_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static MemberRole Update(MemberRole Updated)
        {
            MemberRole Item = new MemberRole();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("MR_ID", Updated.ID);
            obj[1] = new SqlParameter("MR_Username", Updated.Username);
            obj[2] = new SqlParameter("MR_ROLE_ID", Updated.ROLE_ID);
            obj[3] = new SqlParameter("MR_RowId", Updated.RowId);
            obj[4] = new SqlParameter("MR_NgayTao", Updated.NgayTao);
            obj[5] = new SqlParameter("MR_NgayCapNhat", Updated.NgayCapNhat);
            obj[6] = new SqlParameter("MR_NguoiTao", Updated.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMemberRole_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static MemberRole SelectById(Int32 MR_ID)
        {
            MemberRole Item = new MemberRole();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MR_ID", MR_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMemberRole_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static MemberRoleCollection SelectAll()
        {
            MemberRoleCollection List = new MemberRoleCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMemberRole_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<MemberRole> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<MemberRole> pg = new Pager<MemberRole>("sp_tblMemberRole_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static MemberRole getFromReader(IDataReader rd)
        {
            MemberRole Item = new MemberRole();
            Item.ID = (Int32)(rd["MR_ID"]);
            Item.Username = (String)(rd["MR_Username"]);
            Item.ROLE_ID = (Int32)(rd["MR_ROLE_ID"]);
            Item.RowId = (Guid)(rd["MR_RowId"]);
            Item.NgayTao = (DateTime)(rd["MR_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["MR_NgayCapNhat"]);
            Item.NguoiTao = (String)(rd["MR_NguoiTao"]);
            return Item;
        }
        #endregion
        #region Extend
        public static void UpdateRoleListUsername(string roleList, string Username)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("roleList", roleList);
            obj[1] = new SqlParameter("Username", Username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMemberRole_Update_UpdateRoleListUsername_linhnx", obj);
        }
        public static void UpdateUserListRole(string UserList, string ROLE_ID, string Username)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("UserList", UserList);
            obj[1] = new SqlParameter("ROLE_ID", ROLE_ID);
            obj[2] = new SqlParameter("Username", Username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMemberRole_Update_UpdateUserListRole_linhnx", obj);
        }
        public static bool IsInRole(string Username,string RoleName)
        {
            
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("RoleName", RoleName);
            return Convert.ToBoolean(SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblMemberRole_Select_IsInRole_linhnx", obj).ToString());
            
        }
        public static MemberRole Insert(SqlTransaction tran, int ROLE_ID, string Username)
        {
            MemberRole Item = new MemberRole();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("MR_Username", Username);
            obj[1] = new SqlParameter("MR_ROLE_ID", ROLE_ID);
            obj[2] = new SqlParameter("MR_RowId", Guid.NewGuid());
            obj[3] = new SqlParameter("MR_NgayTao", DateTime.Now);
            obj[4] = new SqlParameter("MR_NgayCapNhat", DateTime.Now);
            obj[5] = new SqlParameter("MR_NguoiTao", Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblMemberRole_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static MemberRole InsertDangKyCaNhan(SqlTransaction tran, int CQ_ID, string Username)
        {
            MemberRole Item = new MemberRole();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblMemberRole_Insert_InsertDangKyCaNhan_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static void InsertDangKyGianHang(SqlTransaction tran, int CQ_ID, string Username, string Ten, string lang)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("CQ_ID", CQ_ID);
            obj[2] = new SqlParameter("Ten", Ten);
            obj[3] = new SqlParameter("Lang", lang);
            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "sp_tblMemberRole_Insert_InsertDangKyGianHang_linhnx", obj);



           
        }

       

        #endregion
    }
    #endregion

    #endregion
    
}


