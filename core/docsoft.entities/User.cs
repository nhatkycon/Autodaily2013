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
    #region User
    #region BO
    public class User : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Boolean GioiTinh { get; set; }
        public String Ten { get; set; }
        public String Mobile { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public String Nick { get; set; }
        public String Skype { get; set; }
        public String Pwd { get; set; }
        public String Anh { get; set; }
        public String Stt { get; set; }
        public Int32 Q_ID { get; set; }
        public String Q_Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public DateTime LastLogin { get; set; }
        public Boolean IsOnline { get; set; }
        public Guid RowId { get; set; }
        public Boolean Publish { get; set; }
        public Boolean Active { get; set; }
        public String ActiveCode { get; set; }
        public DateTime ActiveDate { get; set; }
        #endregion
        #region Contructor
        public User()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return UserDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class UserCollection : BaseEntityCollection<User>
    { }
    #endregion
    #region Dal
    public class UserDal
    {
        #region Methods

        public static void DeleteById(Int32 U_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("U_ID", U_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Delete_DeleteById_linhnx", obj);
        }

        public static User Insert(User Inserted)
        {
            User Item = new User();
            SqlParameter[] obj = new SqlParameter[22];
            obj[0] = new SqlParameter("U_GioiTinh", Inserted.GioiTinh);
            obj[1] = new SqlParameter("U_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("U_Mobile", Inserted.Mobile);
            obj[3] = new SqlParameter("U_Username", Inserted.Username);
            obj[4] = new SqlParameter("U_Email", Inserted.Email);
            obj[5] = new SqlParameter("U_Nick", Inserted.Nick);
            obj[6] = new SqlParameter("U_Skype", Inserted.Skype);
            obj[7] = new SqlParameter("U_Pwd", Inserted.Pwd);
            obj[8] = new SqlParameter("U_Anh", Inserted.Anh);
            obj[9] = new SqlParameter("U_Stt", Inserted.Stt);
            obj[10] = new SqlParameter("U_Q_ID", Inserted.Q_ID);
            obj[11] = new SqlParameter("U_Q_Ten", Inserted.Q_Ten);
            obj[12] = new SqlParameter("U_NgaySinh", Inserted.NgaySinh);
            obj[13] = new SqlParameter("U_NgayTao", Inserted.NgayTao);
            obj[14] = new SqlParameter("U_NgayCapNhat", Inserted.NgayCapNhat);
            obj[15] = new SqlParameter("U_LastLogin", Inserted.LastLogin);
            obj[16] = new SqlParameter("U_IsOnline", Inserted.IsOnline);
            obj[17] = new SqlParameter("U_RowId", Inserted.RowId);
            obj[18] = new SqlParameter("U_Publish", Inserted.Publish);
            obj[19] = new SqlParameter("U_Active", Inserted.Active);
            obj[20] = new SqlParameter("U_ActiveCode", Inserted.ActiveCode);
            obj[21] = new SqlParameter("U_ActiveDate", Inserted.ActiveDate);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static User Update(User Updated)
        {
            User Item = new User();
            SqlParameter[] obj = new SqlParameter[23];
            obj[0] = new SqlParameter("U_ID", Updated.ID);
            obj[1] = new SqlParameter("U_GioiTinh", Updated.GioiTinh);
            obj[2] = new SqlParameter("U_Ten", Updated.Ten);
            obj[3] = new SqlParameter("U_Mobile", Updated.Mobile);
            obj[4] = new SqlParameter("U_Username", Updated.Username);
            obj[5] = new SqlParameter("U_Email", Updated.Email);
            obj[6] = new SqlParameter("U_Nick", Updated.Nick);
            obj[7] = new SqlParameter("U_Skype", Updated.Skype);
            obj[8] = new SqlParameter("U_Pwd", Updated.Pwd);
            obj[9] = new SqlParameter("U_Anh", Updated.Anh);
            obj[10] = new SqlParameter("U_Stt", Updated.Stt);
            obj[11] = new SqlParameter("U_Q_ID", Updated.Q_ID);
            obj[12] = new SqlParameter("U_Q_Ten", Updated.Q_Ten);
            obj[13] = new SqlParameter("U_NgaySinh", Updated.NgaySinh);
            obj[14] = new SqlParameter("U_NgayTao", Updated.NgayTao);
            obj[15] = new SqlParameter("U_NgayCapNhat", Updated.NgayCapNhat);
            obj[16] = new SqlParameter("U_LastLogin", Updated.LastLogin);
            obj[17] = new SqlParameter("U_IsOnline", Updated.IsOnline);
            obj[18] = new SqlParameter("U_RowId", Updated.RowId);
            obj[19] = new SqlParameter("U_Publish", Updated.Publish);
            obj[20] = new SqlParameter("U_Active", Updated.Active);
            obj[21] = new SqlParameter("U_ActiveCode", Updated.ActiveCode);
            obj[22] = new SqlParameter("U_ActiveDate", Updated.ActiveDate);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static User SelectById(Int32 U_ID)
        {
            User Item = new User();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("U_ID", U_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static UserCollection SelectAll()
        {
            UserCollection List = new UserCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<User> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<User> pg = new Pager<User>("sp_tblUser_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static User getFromReader(IDataReader rd)
        {
            User Item = new User();
            if (rd.FieldExists("U_ID"))
            {
                Item.ID = (Int32)(rd["U_ID"]);
            }
            if (rd.FieldExists("U_GioiTinh"))
            {
                Item.GioiTinh = (Boolean)(rd["U_GioiTinh"]);
            }
            if (rd.FieldExists("U_Ten"))
            {
                Item.Ten = (String)(rd["U_Ten"]);
            }
            if (rd.FieldExists("U_Mobile"))
            {
                Item.Mobile = (String)(rd["U_Mobile"]);
            }
            if (rd.FieldExists("U_Username"))
            {
                Item.Username = (String)(rd["U_Username"]);
            }
            if (rd.FieldExists("U_Email"))
            {
                Item.Email = (String)(rd["U_Email"]);
            }
            if (rd.FieldExists("U_Nick"))
            {
                Item.Nick = (String)(rd["U_Nick"]);
            }
            if (rd.FieldExists("U_Skype"))
            {
                Item.Skype = (String)(rd["U_Skype"]);
            }
            if (rd.FieldExists("U_Pwd"))
            {
                Item.Pwd = (String)(rd["U_Pwd"]);
            }
            if (rd.FieldExists("U_Anh"))
            {
                Item.Anh = (String)(rd["U_Anh"]);
            }
            if (rd.FieldExists("U_Stt"))
            {
                Item.Stt = (String)(rd["U_Stt"]);
            }
            if (rd.FieldExists("U_Q_ID"))
            {
                Item.Q_ID = (Int32)(rd["U_Q_ID"]);
            }
            if (rd.FieldExists("U_Q_Ten"))
            {
                Item.Q_Ten = (String)(rd["U_Q_Ten"]);
            }
            if (rd.FieldExists("U_NgaySinh"))
            {
                Item.NgaySinh = (DateTime)(rd["U_NgaySinh"]);
            }
            if (rd.FieldExists("U_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["U_NgayTao"]);
            }
            if (rd.FieldExists("U_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["U_NgayCapNhat"]);
            }
            if (rd.FieldExists("U_LastLogin"))
            {
                Item.LastLogin = (DateTime)(rd["U_LastLogin"]);
            }
            if (rd.FieldExists("U_IsOnline"))
            {
                Item.IsOnline = (Boolean)(rd["U_IsOnline"]);
            }
            if (rd.FieldExists("U_RowId"))
            {
                Item.RowId = (Guid)(rd["U_RowId"]);
            }
            if (rd.FieldExists("U_Publish"))
            {
                Item.Publish = (Boolean)(rd["U_Publish"]);
            }
            if (rd.FieldExists("U_Active"))
            {
                Item.Active = (Boolean)(rd["U_Active"]);
            }
            if (rd.FieldExists("U_ActiveCode"))
            {
                Item.ActiveCode = (String)(rd["U_ActiveCode"]);
            }
            if (rd.FieldExists("U_ActiveDate"))
            {
                Item.ActiveDate = (DateTime)(rd["U_ActiveDate"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static User SelectByUsername(string p)
        {
            User Item = new User();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", p);
            Item.Username = p;
            Item.Pwd = SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Select_SelectPwdByUserName_linhnx", obj).ToString();
            return Item;
        }
        public static bool ValidEmail(string Email)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("U_Email", Email);
            string _l = SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Select_ValidEmail_linhnx", obj).ToString();
            if (_l != "-1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ValidUsername(string Username)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("U_Username", Username);
            string _l = SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Select_ValidUsername_linhnx", obj).ToString();
            if (_l != "-1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ValidActiveCode(string ActiveCode, string Username)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("U_Username", Username);
            obj[1] = new SqlParameter("U_ActiveCode", ActiveCode);
            string _l = SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Select_ValidActiveCode_linhnx", obj).ToString();
            if (_l != "-1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void UpdateEmail(string Username, string Email)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("U_Username", Username);
            obj[1] = new SqlParameter("U_Email", Email);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblUser_Update_UpdateEmail_linhnx", obj).ToString();
        }
        #endregion
    }
    #endregion

    #endregion
}


