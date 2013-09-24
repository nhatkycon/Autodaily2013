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
    #region Role
    #region BO
    public class Role : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 CQ_ID { get; set; }
        public String Ten { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        public Boolean HeThong { get; set; }
        public Boolean Active { get; set; }
        public String NguoiTao { get; set; }
        public Guid Loai_ID { get; set; }
        public String Loai_Ten { get; set; }
       
        #endregion
        #region Contructor
        public Role()
        { }
        #endregion
        #region Customs properties
        public CoQuan _CoQuan { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return RoleDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class RoleCollection : BaseEntityCollection<Role>
    { }
    #endregion
    #region Dal
    public class RoleDal
    {
        #region Methods

        public static void DeleteById(Int32 ROLE_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ROLE_ID", ROLE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRole_Delete_DeleteById_linhnx", obj);
        }
        public static void DeleteById(string ROLE_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ROLE_ID", ROLE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRole_Delete_DeleteByIdList_linhnx", obj);
        }
        public static Role Insert(Role Inserted)
        {
            Role Item = new Role();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("ROLE_CQ_ID", Inserted.CQ_ID);
            obj[1] = new SqlParameter("ROLE_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("ROLE_NgayTao", Inserted.NgayTao);
            obj[3] = new SqlParameter("ROLE_NgayCapNhat", Inserted.NgayCapNhat);
            obj[4] = new SqlParameter("ROLE_RowId", Inserted.RowId);
            obj[5] = new SqlParameter("ROLE_HeThong", Inserted.HeThong);
            obj[6] = new SqlParameter("ROLE_Active", Inserted.Active);
            obj[7] = new SqlParameter("ROLE_NguoiTao", Inserted.NguoiTao);
            obj[8] = new SqlParameter("ROLE_Loai_ID", Inserted.Loai_ID);
            obj[9] = new SqlParameter("ROLE_Loai_Ten", Inserted.Loai_Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRole_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Role Update(Role Updated)
        {
            Role Item = new Role();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("ROLE_ID", Updated.ID);
            obj[1] = new SqlParameter("ROLE_CQ_ID", Updated.CQ_ID);
            obj[2] = new SqlParameter("ROLE_Ten", Updated.Ten);
            obj[3] = new SqlParameter("ROLE_NgayTao", Updated.NgayTao);
            obj[4] = new SqlParameter("ROLE_NgayCapNhat", Updated.NgayCapNhat);
            obj[5] = new SqlParameter("ROLE_RowId", Updated.RowId);
            obj[6] = new SqlParameter("ROLE_HeThong", Updated.HeThong);
            obj[7] = new SqlParameter("ROLE_Active", Updated.Active);
            obj[8] = new SqlParameter("ROLE_NguoiTao", Updated.NguoiTao);
            obj[9] = new SqlParameter("ROLE_Loai_ID", Updated.Loai_ID);
            obj[10] = new SqlParameter("ROLE_Loai_Ten", Updated.Loai_Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRole_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Role SelectById(Int32 ROLE_ID)
        {
            Role Item = new Role();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ROLE_ID", ROLE_ID);
            CoQuan _Item = new CoQuan();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRole_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    _Item.Ten = rd["CQ_Ten"].ToString();
                }
            }
            Item._CoQuan = _Item;
            return Item;
        }

        public static RoleCollection SelectAll()
        {
            RoleCollection List = new RoleCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRole_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Role> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Role> pg = new Pager<Role>("sp_tblRole_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Role getFromReader(IDataReader rd)
        {
            var Item = new Role();
            if (rd.FieldExists("ROLE_ID"))
            {
                Item.ID = (Int32)(rd["ROLE_ID"]);
            }
            if (rd.FieldExists("ROLE_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["ROLE_CQ_ID"]);
            }
            if (rd.FieldExists("ROLE_Ten"))
            {
                Item.Ten = (String)(rd["ROLE_Ten"]);
            }
            if (rd.FieldExists("ROLE_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["ROLE_NgayTao"]);
            }
            if (rd.FieldExists("ROLE_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["ROLE_NgayCapNhat"]);
            }
            if (rd.FieldExists("ROLE_RowId"))
            {
                Item.RowId = (Guid)(rd["ROLE_RowId"]);
            }
            if (rd.FieldExists("ROLE_HeThong"))
            {
                Item.HeThong = (Boolean)(rd["ROLE_HeThong"]);
            }
            if (rd.FieldExists("ROLE_Active"))
            {
                Item.Active = (Boolean)(rd["ROLE_Active"]);
            }
            if (rd.FieldExists("ROLE_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["ROLE_NguoiTao"]);
            }
            if (rd.FieldExists("ROLE_Loai_Ten"))
            {
                Item.Loai_Ten = (String)(rd["ROLE_Loai_Ten"]);
            }
            if (rd.FieldExists("ROLE_Loai_ID"))
            {
                Item.Loai_ID = (Guid)(rd["ROLE_Loai_ID"]);
            }
            return Item; 
        }
        #endregion
        #region extend
        public static RoleCollection SelectAllByUsernameCQ(string Username)
        {
            RoleCollection List = new RoleCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRole_Select_SelectAllByUsernameCQ_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static RoleCollection TreeByUsername(string Username, string q, string ROLE_CQ_ID, string Sort)
        {
            RoleCollection List = new RoleCollection();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Username", Username);
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(ROLE_CQ_ID))
            {
                obj[2] = new SqlParameter("ROLE_CQ_ID", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("ROLE_CQ_ID", ROLE_CQ_ID);
            }
            obj[3] = new SqlParameter("Sort", Sort);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRole_Select_TreeByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    CoQuan _item = new CoQuan();
                    _item.Ten = rd["CQ_Ten"].ToString();
                    Role item = new Role();
                    item = getFromReader(rd);
                    item._CoQuan = _item;
                    List.Add(item);
                }
            }
            return List;
        }
        public static Role Insert(SqlTransaction tran, int CQ_ID, string Username)
        {
            Role Item = new Role();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            obj[1] = new SqlParameter("Username", Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblRole_Insert_InsertDangKyCaNhan_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        /// <summary>
        /// ham nay dung cho chuyen du lieu Ductt viet ngay 270711
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="CQ_ID"></param>
        /// <param name="Username"></param>
        /// <param name="Ten"></param>
        public static Role InsertDangKyGianHang2(SqlTransaction tran, int CQ_ID, string Username, string Ten)
        {
            Role Item = new Role();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("CQ_ID", CQ_ID);
            obj[2] = new SqlParameter("Ten", Ten);
            // SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "CT001", obj);

            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblMemberRole_Insert_InsertDangKyGianHang_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;



        }
        public static Role InsertDangKyGianHanghampv(SqlTransaction tran, int CQ_ID, string Username, string Ten,int LangBaseID,string Lang,string DoanhNghiepID)
        {
            Role Item = new Role();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("CQ_ID", CQ_ID);
            obj[2] = new SqlParameter("Ten", Ten);
            obj[3] = new SqlParameter("LangBaseID", LangBaseID);
            obj[4] = new SqlParameter("Lang", Lang);
            obj[5] = new SqlParameter("DoanhNghiepID", DoanhNghiepID);
            // SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "CT001", obj);

            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblMemberRole_Insert_InsertDangKyGianHang_hampv", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;



        }
        #endregion
    }
    #endregion

    #endregion
    
}


