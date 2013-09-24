using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using linh.core.dal;
using linh.controls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
namespace docbao.entitites
{
    #region Member
    #region BO
    public class Member : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String IP { get; set; }
        public String Email { get; set; }
        public String Ten { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime NgayTao { get; set; }
        public String Anh { get; set; }
        #endregion
        #region Contructor
        public Member()
        { }
        public Member(Int32? id, String username, String password, String ip, String email, String ten, DateTime? lastlogin, DateTime? ngaytao, String anh)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            Username = username;
            Password = password;
            IP = ip;
            Email = email;
            Ten = ten;
            if (lastlogin != null)
            {
                LastLogin = lastlogin.Value;
            }
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }
            Anh = anh;

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return MemberDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class MemberCollection : BaseEntityCollection<Member>
    { }
    #endregion
    #region Dal
    public class MemberDal
    {
        #region Methods

        public static void DeleteById(Int32 MEM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_ID", MEM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblMember_Delete_DeleteById_linhnx", obj);
        }
        public static Member Insert(Member Inserted)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("MEM_ID", Inserted.ID);
            obj[1] = new SqlParameter("MEM_Password", Inserted.Password);
            obj[2] = new SqlParameter("MEM_IP", Inserted.IP);
            obj[3] = new SqlParameter("MEM_Email", Inserted.Email);
            obj[4] = new SqlParameter("MEM_Ten", Inserted.Ten);
            if (Inserted.LastLogin > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("MEM_LastLogin", Inserted.LastLogin);
            }
            else
            {
                obj[5] = new SqlParameter("MEM_LastLogin", DBNull.Value);
            }
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("MEM_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("MEM_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("MEM_Anh", Inserted.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblMember_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Member Insert(Int32? id, String username, String password, String ip, String email, String ten, DateTime? lastlogin, DateTime? ngaytao, String anh)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[8];
            if (id != null)
            {
                obj[0] = new SqlParameter("MEM_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("MEM_ID", DBNull.Value);
            }
            if (password != null)
            {
                obj[1] = new SqlParameter("MEM_Password", password);
            }
            else
            {
                obj[1] = new SqlParameter("MEM_Password", DBNull.Value);
            }
            if (ip != null)
            {
                obj[2] = new SqlParameter("MEM_IP", ip);
            }
            else
            {
                obj[2] = new SqlParameter("MEM_IP", DBNull.Value);
            }
            if (email != null)
            {
                obj[3] = new SqlParameter("MEM_Email", email);
            }
            else
            {
                obj[3] = new SqlParameter("MEM_Email", DBNull.Value);
            }
            if (ten != null)
            {
                obj[4] = new SqlParameter("MEM_Ten", ten);
            }
            else
            {
                obj[4] = new SqlParameter("MEM_Ten", DBNull.Value);
            }
            if (lastlogin != null)
            {
                obj[5] = new SqlParameter("MEM_LastLogin", lastlogin);
            }
            else
            {
                obj[5] = new SqlParameter("MEM_LastLogin", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[6] = new SqlParameter("MEM_NgayTao", ngaytao);
            }
            else
            {
                obj[6] = new SqlParameter("MEM_NgayTao", DBNull.Value);
            }
            if (anh != null)
            {
                obj[7] = new SqlParameter("MEM_Anh", anh);
            }
            else
            {
                obj[7] = new SqlParameter("MEM_Anh", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblMember_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Member Update(Member Updated)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("MEM_ID", Updated.ID);
            obj[1] = new SqlParameter("MEM_Username", Updated.Username);
            obj[2] = new SqlParameter("MEM_Password", Updated.Password);
            obj[3] = new SqlParameter("MEM_IP", Updated.IP);
            obj[4] = new SqlParameter("MEM_Email", Updated.Email);
            obj[5] = new SqlParameter("MEM_Ten", Updated.Ten);
            if (Updated.LastLogin > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("MEM_LastLogin", Updated.LastLogin);
            }
            else
            {
                obj[6] = new SqlParameter("MEM_LastLogin", DBNull.Value);
            }
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("MEM_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("MEM_NgayTao", DBNull.Value);
            }
            obj[8] = new SqlParameter("MEM_Anh", Updated.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblMember_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Member Update(Int32? id, String username, String password, String ip, String email, String ten, DateTime? lastlogin, DateTime? ngaytao, String anh)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[9];
            if (id != null)
            {
                obj[0] = new SqlParameter("MEM_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("MEM_ID", DBNull.Value);
            }
            if (username != null)
            {
                obj[1] = new SqlParameter("MEM_Username", username);
            }
            else
            {
                obj[1] = new SqlParameter("MEM_Username", DBNull.Value);
            }
            if (password != null)
            {
                obj[2] = new SqlParameter("MEM_Password", password);
            }
            else
            {
                obj[2] = new SqlParameter("MEM_Password", DBNull.Value);
            }
            if (ip != null)
            {
                obj[3] = new SqlParameter("MEM_IP", ip);
            }
            else
            {
                obj[3] = new SqlParameter("MEM_IP", DBNull.Value);
            }
            if (email != null)
            {
                obj[4] = new SqlParameter("MEM_Email", email);
            }
            else
            {
                obj[4] = new SqlParameter("MEM_Email", DBNull.Value);
            }
            if (ten != null)
            {
                obj[5] = new SqlParameter("MEM_Ten", ten);
            }
            else
            {
                obj[5] = new SqlParameter("MEM_Ten", DBNull.Value);
            }
            if (lastlogin != null)
            {
                obj[6] = new SqlParameter("MEM_LastLogin", lastlogin);
            }
            else
            {
                obj[6] = new SqlParameter("MEM_LastLogin", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[7] = new SqlParameter("MEM_NgayTao", ngaytao);
            }
            else
            {
                obj[7] = new SqlParameter("MEM_NgayTao", DBNull.Value);
            }
            if (anh != null)
            {
                obj[8] = new SqlParameter("MEM_Anh", anh);
            }
            else
            {
                obj[8] = new SqlParameter("MEM_Anh", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblMember_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Member SelectById(Int32 MEM_ID)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_ID", MEM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblMember_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static MemberCollection SelectAll()
        {
            MemberCollection List = new MemberCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblMember_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Member> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Member> pg = new Pager<Member>("tbl_sp_tblMember_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Member getFromReader(IDataReader rd)
        {
            Member Item = new Member();
            if (rd.FieldExists("MEM_ID"))
            {
                Item.ID = (Int32)(rd["MEM_ID"]);
            }
            if (rd.FieldExists("MEM_Username"))
            {
                Item.Username = (String)(rd["MEM_Username"]);
            }
            if (rd.FieldExists("MEM_Password"))
            {
                Item.Password = (String)(rd["MEM_Password"]);
            }
            if (rd.FieldExists("MEM_IP"))
            {
                Item.IP = (String)(rd["MEM_IP"]);
            }
            if (rd.FieldExists("MEM_Email"))
            {
                Item.Email = (String)(rd["MEM_Email"]);
            }
            if (rd.FieldExists("MEM_Ten"))
            {
                Item.Ten = (String)(rd["MEM_Ten"]);
            }
            if (rd.FieldExists("MEM_LastLogin"))
            {
                Item.LastLogin = (DateTime)(rd["MEM_LastLogin"]);
            }
            if (rd.FieldExists("MEM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["MEM_NgayTao"]);
            }
            if (rd.FieldExists("MEM_Anh"))
            {
                Item.Anh = (String)(rd["MEM_Anh"]);
            }
            return Item;
        }
        public static Member InsertQuick(string ip, string email, string ten)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("ip", ip);
            obj[1] = new SqlParameter("email", email);
            obj[2] = new SqlParameter("ten", ten);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblMember_select_selectByIp_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        #endregion
        #region Extend
        #endregion
    }
    #endregion
    #endregion
}
