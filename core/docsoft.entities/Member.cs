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
    #region Member
    #region BO
    [Serializable()]
    public class Member : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ho { get; set; }
        public String Ten { get; set; }
        public String Mota { get; set; }
        public String Anh { get; set; }
        public Int32 CQ_ID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public String DiaChi { get; set; }
        public Boolean Active { get; set; }
        public Boolean Khoa { get; set; }
        public Boolean XacNhan { get; set; }
        public Boolean NgayXacNhan { get; set; }
        public Boolean ChungThuc { get; set; }
        public Boolean Admin { get; set; }
        public Guid RowId { get; set; }
        public String NguoiTao { get; set; }
        public Int32 Loai { get; set; }
        public String RefUsername { get; set; }
        public Boolean ThuKy { get; set; }
        public Int32 SLOnline { get; set; }
        public String Loai_Ten { get; set; }
        public String Phone { get; set; }
        public Int32 Tinh { get; set; }
        
        #endregion
        #region Contructor
        public Member()
        { }
        #endregion
        #region Customs properties
        public CoQuan _CoQuan { get; set; }
        public List<Role> _Roles { get; set; }
        public List<Function> _Functions { get; set; }
        public String GH_Ten { get; set; }
        public Int32 GH_ID { get; set; }
        public bool Thich { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return MemberDal.getFromReader(rd) ;
        }

    }
    #endregion
    #region Collection
    [Serializable()]
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
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Delete_DeleteById_linhnx", obj);
        }

        public static Member Insert(Member Inserted)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("MEM_Ho", Inserted.Ho);
            obj[1] = new SqlParameter("MEM_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("MEM_Mota", Inserted.Mota);
            obj[3] = new SqlParameter("MEM_Anh", Inserted.Anh);
            obj[4] = new SqlParameter("MEM_CQ_ID", Inserted.CQ_ID);
            obj[5] = new SqlParameter("MEM_Username", Inserted.Username);
            obj[6] = new SqlParameter("MEM_Password", Inserted.Password);
            obj[7] = new SqlParameter("MEM_NgayTao", Inserted.NgayTao);
            obj[8] = new SqlParameter("MEM_NgayCapNhat", Inserted.NgayCapNhat);
            obj[9] = new SqlParameter("MEM_Email", Inserted.Email);
            obj[10] = new SqlParameter("MEM_Mobile", Inserted.Mobile);
            obj[11] = new SqlParameter("MEM_DiaChi", Inserted.DiaChi);
            obj[12] = new SqlParameter("MEM_Active", Inserted.Active);
            obj[13] = new SqlParameter("MEM_Khoa", Inserted.Khoa);
            obj[14] = new SqlParameter("MEM_XacNhan", Inserted.XacNhan);
            obj[15] = new SqlParameter("MEM_NgayXacNhan", Inserted.NgayXacNhan);
            obj[16] = new SqlParameter("MEM_ChungThuc", Inserted.ChungThuc);
            obj[17] = new SqlParameter("MEM_Admin", Inserted.Admin);
            obj[18] = new SqlParameter("MEM_RowId", Inserted.RowId);
            obj[19] = new SqlParameter("MEM_NguoiTao", Inserted.NguoiTao);
            obj[20] = new SqlParameter("MEM_Loai", Inserted.Loai);
            obj[21] = new SqlParameter("MEM_RefUsername", Inserted.RefUsername);
            obj[22] = new SqlParameter("MEM_ThuKy", Inserted.ThuKy);
            obj[23] = new SqlParameter("MEM_Loai_Ten", Inserted.Loai_Ten);
            obj[24] = new SqlParameter("MEM_Phone", Inserted.Phone);
            obj[25] = new SqlParameter("MEM_Tinh", Inserted.Tinh);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        /// <summary>
        /// ham nay dung de chuyen du lieu Duc viet
        /// </summary>
        /// <param name="Inserted"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static Member Insert(Member Inserted, SqlTransaction tran)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("MEM_Ho", Inserted.Ho);
            obj[1] = new SqlParameter("MEM_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("MEM_Mota", Inserted.Mota);
            obj[3] = new SqlParameter("MEM_Anh", Inserted.Anh);
            obj[4] = new SqlParameter("MEM_CQ_ID", Inserted.CQ_ID);
            obj[5] = new SqlParameter("MEM_Username", Inserted.Username);
            obj[6] = new SqlParameter("MEM_Password", Inserted.Password);
            obj[7] = new SqlParameter("MEM_NgayTao", Inserted.NgayTao);
            obj[8] = new SqlParameter("MEM_NgayCapNhat", Inserted.NgayCapNhat);
            obj[9] = new SqlParameter("MEM_Email", Inserted.Email);
            obj[10] = new SqlParameter("MEM_Mobile", Inserted.Mobile);
            obj[11] = new SqlParameter("MEM_DiaChi", Inserted.DiaChi);
            obj[12] = new SqlParameter("MEM_Active", Inserted.Active);
            obj[13] = new SqlParameter("MEM_Khoa", Inserted.Khoa);
            obj[14] = new SqlParameter("MEM_XacNhan", Inserted.XacNhan);
            obj[15] = new SqlParameter("MEM_NgayXacNhan", Inserted.NgayXacNhan);
            obj[16] = new SqlParameter("MEM_ChungThuc", Inserted.ChungThuc);
            obj[17] = new SqlParameter("MEM_Admin", Inserted.Admin);
            obj[18] = new SqlParameter("MEM_RowId", Inserted.RowId);
            obj[19] = new SqlParameter("MEM_NguoiTao", Inserted.NguoiTao);
            obj[20] = new SqlParameter("MEM_Loai", Inserted.Loai);
            obj[21] = new SqlParameter("MEM_RefUsername", Inserted.RefUsername);
            obj[22] = new SqlParameter("MEM_ThuKy", Inserted.ThuKy);
            obj[23] = new SqlParameter("MEM_Loai_Ten", Inserted.Loai_Ten);
            obj[24] = new SqlParameter("MEM_Phone", Inserted.Phone);
            obj[25] = new SqlParameter("MEM_Tinh", Inserted.Tinh);
            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblMember_Insert_InsertNormal_linhnx", obj))
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
            SqlParameter[] obj = new SqlParameter[27];
            obj[0] = new SqlParameter("MEM_ID", Updated.ID);
            obj[1] = new SqlParameter("MEM_Ho", Updated.Ho);
            obj[2] = new SqlParameter("MEM_Ten", Updated.Ten);
            obj[3] = new SqlParameter("MEM_Mota", Updated.Mota);
            obj[4] = new SqlParameter("MEM_Anh", Updated.Anh);
            obj[5] = new SqlParameter("MEM_CQ_ID", Updated.CQ_ID);
            obj[6] = new SqlParameter("MEM_Username", Updated.Username);
            if (!string.IsNullOrEmpty(Updated.Password))
            {
                obj[7] = new SqlParameter("MEM_Password", Updated.Password);                
            }
            else
            {
                obj[7] = new SqlParameter("MEM_Password", DBNull.Value);                
            }
            obj[8] = new SqlParameter("MEM_NgayTao", Updated.NgayTao);
            obj[9] = new SqlParameter("MEM_NgayCapNhat", Updated.NgayCapNhat);
            obj[10] = new SqlParameter("MEM_Email", Updated.Email);
            obj[11] = new SqlParameter("MEM_Mobile", Updated.Mobile);
            obj[12] = new SqlParameter("MEM_DiaChi", Updated.DiaChi);
            obj[13] = new SqlParameter("MEM_Active", Updated.Active);
            obj[14] = new SqlParameter("MEM_Khoa", Updated.Khoa);
            obj[15] = new SqlParameter("MEM_XacNhan", Updated.XacNhan);
            obj[16] = new SqlParameter("MEM_NgayXacNhan", Updated.NgayXacNhan);
            obj[17] = new SqlParameter("MEM_ChungThuc", Updated.ChungThuc);
            obj[18] = new SqlParameter("MEM_Admin", Updated.Admin);
            obj[19] = new SqlParameter("MEM_RowId", Updated.RowId);
            obj[20] = new SqlParameter("MEM_NguoiTao", Updated.NguoiTao);
            obj[21] = new SqlParameter("MEM_Loai", Updated.Loai);
            obj[22] = new SqlParameter("MEM_RefUsername", Updated.RefUsername);
            obj[23] = new SqlParameter("MEM_ThuKy", Updated.ThuKy);
            obj[24] = new SqlParameter("MEM_Loai_Ten", Updated.Loai_Ten);
            obj[25] = new SqlParameter("MEM_Phone", Updated.Phone);
            obj[26] = new SqlParameter("MEM_Tinh", Updated.Tinh);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Update_UpdateNormal_linhnx", obj))
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
            CoQuan _cq = new CoQuan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_ID", MEM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    _cq.Ten = rd["CQ_Ten"].ToString();
                }
            }
            Item._CoQuan = _cq;
            return Item;
        }

        public static Member SelectByUser(string username)
        {
            return SelectByUser(DAL.con(), username);
        }
        public static Member SelectByUser(SqlConnection con, string username)
        {
            Member Item = new Member();
            CoQuan _cq = new CoQuan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("username", username);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblMember_Select_SelectByUsername_Hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    _cq.Ten = rd["CQ_Ten"].ToString();
                }
            }
            Item._CoQuan = _cq;
            return Item;
        }
        public static Member Select_InsertIntoLhByUser(string User)
        {
            Member Item = new Member();
            CoQuan _cq = new CoQuan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("username", User);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_InsertIntoLhByUser_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);                 
                }
            }           
            return Item;
        }
        public static Member SelectByUser(SqlConnection con, string username, string refUser)
        {
            Member Item = new Member();
            CoQuan _cq = new CoQuan();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("username", username);
            if (!string.IsNullOrEmpty(refUser))
            {
                obj[1] = new SqlParameter("refUser", refUser);    
            }
            else
            {
                obj[1] = new SqlParameter("refUser", DBNull.Value);
            }
            obj[0] = new SqlParameter("username", username);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblMember_Select_SelectByUsernameRefUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    _cq.Ten = rd["CQ_Ten"].ToString();
                }
            }
            Item._CoQuan = _cq;
            return Item;
        }

        public static bool SelectChungThuc(string Username)
        {
            return MemberDal.SelectByUsername(Username).ChungThuc;
        }

        public static Member SelectByRowId(String MEM_RowId)
        {
            Member Item = new Member();
            CoQuan _cq = new CoQuan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_RowId", MEM_RowId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectByRowId_linhnx", obj))
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
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static MemberCollection SelectLanhDaoByCQID(string MEM_CQ_ID)
        {
            MemberCollection List = new MemberCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_CQ_ID", Convert.ToInt32(MEM_CQ_ID));
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectLanhDaoByCQID_hungpm", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static MemberCollection SelectLanhDaoVanBanDi()
        {
            MemberCollection List = new MemberCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectLanhDaoVanBanDi_linhnx"))
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
            Pager<Member> pg = new Pager<Member>("sp_tblMember_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Member> pagerAllChildByUsername(string url, bool rewrite, string sort
            , string Username, string MEM_CQ_ID, string q,string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[4];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            obj[1] = new SqlParameter("Username", Username);
            if (string.IsNullOrEmpty(MEM_CQ_ID))
            {
                obj[2] = new SqlParameter("MEM_CQ_ID", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("MEM_CQ_ID", MEM_CQ_ID);
            }
            obj[3] = new SqlParameter("q", q);
            Pager<Member> pg = new Pager<Member>("sp_tblMember_Pager_AllChildByUsername_linhnx", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Member> pagerAllByUsername(string url, bool rewrite, string sort, string Username, string MEM_CQ_ID, string q, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[4];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            obj[1] = new SqlParameter("Username", Username);
            if (string.IsNullOrEmpty(MEM_CQ_ID))
            {
                obj[2] = new SqlParameter("MEM_CQ_ID", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("MEM_CQ_ID", MEM_CQ_ID);
            }
            obj[3] = new SqlParameter("q", q);
            Pager<Member> pg = new Pager<Member>("sp_tblMember_Pager_AllByUsername_ductt", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
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
            if (rd.FieldExists("MEM_Ho"))
            {
                Item.Ho = (String)(rd["MEM_Ho"]);
            }
            if (rd.FieldExists("MEM_Ten"))
            {
                Item.Ten = (String)(rd["MEM_Ten"]);
            }
            if (rd.FieldExists("MEM_Mota"))
            {
                Item.Mota = (String)(rd["MEM_Mota"]);
            }
            if (rd.FieldExists("MEM_Anh"))
            {
                Item.Anh = (String)(rd["MEM_Anh"]);
            }
            if (rd.FieldExists("MEM_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["MEM_CQ_ID"]);
            }
            if (rd.FieldExists("MEM_Username"))
            {
                Item.Username = (String)(rd["MEM_Username"]);
            }
            if (rd.FieldExists("MEM_Password"))
            {
                Item.Password = (String)(rd["MEM_Password"]);
            }
            if (rd.FieldExists("MEM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["MEM_NgayTao"]);
            }
            if (rd.FieldExists("MEM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["MEM_NgayCapNhat"]);
            }
            if (rd.FieldExists("MEM_Email"))
            {
                Item.Email = (String)(rd["MEM_Email"]);
            }
            if (rd.FieldExists("MEM_Mobile"))
            {
                Item.Mobile = (String)(rd["MEM_Mobile"]);
            }
            if (rd.FieldExists("MEM_Phone"))
            {
                Item.Phone = (String)(rd["MEM_Phone"]);
            }
            if (rd.FieldExists("MEM_DiaChi"))
            {
                Item.DiaChi = (String)(rd["MEM_DiaChi"]);
            }
            if (rd.FieldExists("MEM_Active"))
            {
                Item.Active = (Boolean)(rd["MEM_Active"]);
            }
            if (rd.FieldExists("MEM_Khoa"))
            {
                Item.Khoa = (Boolean)(rd["MEM_Khoa"]);
            }
            if (rd.FieldExists("MEM_XacNhan"))
            {
                Item.XacNhan = (Boolean)(rd["MEM_XacNhan"]);
            }
            if (rd.FieldExists("MEM_NgayXacNhan"))
            {
                Item.NgayXacNhan = (Boolean)(rd["MEM_NgayXacNhan"]);
            }
            if (rd.FieldExists("MEM_ChungThuc"))
            {
                Item.ChungThuc = (Boolean)(rd["MEM_ChungThuc"]);
            }
            if (rd.FieldExists("MEM_Admin"))
            {
                Item.Admin = (Boolean)(rd["MEM_Admin"]);
            }
            if (rd.FieldExists("MEM_RowId"))
            {
                Item.RowId = (Guid)(rd["MEM_RowId"]);
            }
            if (rd.FieldExists("MEM_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["MEM_NguoiTao"]);
            }
            if (rd.FieldExists("MEM_Loai"))
            {
                Item.Loai = (Int32)(rd["MEM_Loai"]);
            }
            if (rd.FieldExists("MEM_RefUsername"))
            {
                Item.RefUsername = (String)(rd["MEM_RefUsername"]);
            }
            if (rd.FieldExists("MEM_ThuKy"))
            {
                Item.ThuKy = (Boolean)(rd["MEM_ThuKy"]);
            }
            if (rd.FieldExists("MEM_Loai_Ten"))
            {
                Item.Loai_Ten = (String)(rd["MEM_Loai_Ten"]);
            }
            if (rd.FieldExists("GH_Ten"))
            {
                Item.GH_Ten = (String)(rd["GH_Ten"]);
            }
            if (rd.FieldExists("GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["GH_ID"]);
            }
            if (rd.FieldExists("MEM_Tinh"))
            {
                Item.Tinh = (Int32)(rd["MEM_Tinh"]);
            }
            if (rd.FieldExists("MEM_Thich"))
            {
                Item.Thich = (Boolean)(rd["MEM_Thich"]);
            }
            CoQuan _CQ = new CoQuan();
            if (rd.FieldExists("CQ_Ten"))
            {
                _CQ.Ten = (String)(rd["CQ_Ten"]);
            }
            Item._CoQuan = _CQ;
            return Item;
        }
        #endregion

        #region expanded
        public static List<string> SelectAllEmail(SqlConnection con)
        {
            var list = new List<string>();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblMember_Select_SelectAllEmail_linhnx"))
            {
                while (rd.Read())
                {
                    if (rd.FieldExists("MEM_Email"))
                    {
                        list.Add((String)(rd["MEM_Email"]));
                    }
                }
            }
            return list;
        }
        public static bool ValidEmail(string Email)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_Email", Email);
            string _l = SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_ValidEmail_linhnx", obj).ToString();
            if (_l != "-1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static MemberCollection SelectLanhDaoByCQMa(string CQ_Ma)
        {
            MemberCollection List = new MemberCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_Ma", CQ_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectAllByCoQuanMa_hungpm", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static MemberCollection SelectLamDichVu(string TVDV_ID, string Username)
        {
            var list = new MemberCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TVDV_ID", TVDV_ID);
            if (string.IsNullOrEmpty(Username))
            {
                obj[1] = new SqlParameter("Username", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("Username", Username);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_select_selectLamDichVu_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static Member getFromReaderTiny(IDataReader rd)
        {
            Member Item = new Member();
            Item.ID = (Int32)(rd["MEM_ID"]);
            Item.Ten = (String)(rd["MEM_Ten"]);
            Item.CQ_ID = (Int32)(rd["MEM_CQ_ID"]);
            Item.Username = (String)(rd["MEM_Username"]);
            Item.Password = (String)(rd["MEM_Password"]);
            Item.NgayTao = (DateTime)(rd["MEM_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["MEM_NgayCapNhat"]);
            Item.Email = (String)(rd["MEM_Email"]);
            Item.Khoa = (Boolean)(rd["MEM_Khoa"]);
            Item.NguoiTao = (String)(rd["MEM_NguoiTao"]);
            return Item;
        }
        public static MemberCollection SelectByRole(string ROLE_ID)
        {
            MemberCollection List = new MemberCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ROLE_ID", ROLE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectByRole_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderTiny(rd));
                }
            }
            return List;
        }
        public static MemberCollection SelectAllByCoQuan(string CQ_ID)
        {
            MemberCollection List = new MemberCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectAllByCoQuan_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static MemberCollection SelectCungDonVi(string Username)
        {
            MemberCollection List = new MemberCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure
                , "sp_tblMember_Select_SelectCungDonVi_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static MemberCollection SelectGianHangUsername()
        {
            MemberCollection List = new MemberCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure
                , "sp_tblMember_Select_SelectUsername_SelectGianHang_Hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Member SelectByUsername(string p)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_Username", p);
            Item.Username = p;
            Item.Password = SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectByUserName_linhnx", obj).ToString();
            return Item;
        }
        public static Member SelectAllByUserName(string strMem)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_Username", strMem);
            Item.Username = strMem;
            Item.Ten = SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectAllByUserName_hungpm", obj).ToString();

            return Item;
        }
        public static string ValidEmailUsername(string Email, string Username)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("MEM_Username", Username);
            obj[1] = new SqlParameter("MEM_Email", Email);
            return SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_ValidEmailUsername_linhnx", obj).ToString();
        }
        public static void DeleteByIdList(string IDList)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("IDList", IDList);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Delete_DeleteByIdList_linhnx", obj);
        }
        public static MemberCollection SelectByNodeAndWfId(string VBNODE_ID, string WF_ID, string q, string TOP, string Username)
        {
            MemberCollection List = new MemberCollection();
            SqlParameter[] obj = new SqlParameter[5];
            if (string.IsNullOrEmpty(VBNODE_ID))
            {
                obj[0] = new SqlParameter("VBNODE_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("VBNODE_ID", VBNODE_ID);
            }
            obj[1] = new SqlParameter("WF_ID", WF_ID);
            obj[2] = new SqlParameter("q", q);
            obj[3] = new SqlParameter("TOP", TOP);
            obj[4] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectByNodeAndWfId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderAuto(rd));
                }
            }
            return List;
        }
        public static Member getFromReaderAuto(IDataReader rd)
        {
            Member Item = new Member();
            Item.ID = (Int32)(rd["MEM_ID"]);
            Item.Ten = (String)(rd["MEM_Ten"]);
            Item.Username = (String)(rd["MEM_Username"]);
            Item.RowId = (Guid)(rd["MEM_RowId"]);
            return Item;
        }
        public static MemberCollection UserOnline(string Username,int Top)
        {
            MemberCollection List = new MemberCollection();
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(Username))
            {
                obj[0] = new SqlParameter("Username", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Username", Username);
            }
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_UserOnline_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderOnline(rd));
                }
            }
            return List;
        }
        public static Member getFromReaderOnline(IDataReader rd)
        {
            Member Item = new Member();
            Item.Username = (String)(rd["CQ_Ten"]);
            Item.SLOnline = (Int32)(rd["CQ_Count"]);
            return Item;
        }
        public static void updateOnline(string Username)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Update_updateOnline_linhnx", obj);
        }
        public static Member Insert(SqlTransaction tran, int CQ_ID, string Ten,string Username,string Mobile,string DiaChi, string Pwd)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("MEM_Ho", string.Empty);
            obj[1] = new SqlParameter("MEM_Ten", Ten);
            obj[2] = new SqlParameter("MEM_Mota", string.Empty);
            obj[3] = new SqlParameter("MEM_Anh", string.Empty);
            obj[4] = new SqlParameter("MEM_CQ_ID", CQ_ID);
            obj[5] = new SqlParameter("MEM_Username", Username);
            obj[6] = new SqlParameter("MEM_Password", Pwd);
            obj[7] = new SqlParameter("MEM_NgayTao", DateTime.Now);
            obj[8] = new SqlParameter("MEM_NgayCapNhat", DateTime.Now);
            obj[9] = new SqlParameter("MEM_Email", Username);
            obj[10] = new SqlParameter("MEM_Mobile", Mobile);
            obj[11] = new SqlParameter("MEM_DiaChi", DiaChi);
            obj[12] = new SqlParameter("MEM_Active", true);
            obj[13] = new SqlParameter("MEM_Khoa", false);
            obj[14] = new SqlParameter("MEM_XacNhan", false);
            obj[15] = new SqlParameter("MEM_NgayXacNhan", false);
            obj[16] = new SqlParameter("MEM_ChungThuc", false);
            obj[17] = new SqlParameter("MEM_Admin",false);
            obj[18] = new SqlParameter("MEM_RowId", Guid.NewGuid());
            obj[19] = new SqlParameter("MEM_NguoiTao", Username);
            obj[20] = new SqlParameter("MEM_Loai", 0);
            obj[21] = new SqlParameter("MEM_RefUsername", string.Empty);
            obj[22] = new SqlParameter("MEM_ThuKy", false);
            obj[23] = new SqlParameter("MEM_Loai_Ten", string.Empty);
            obj[24] = new SqlParameter("MEM_Phone", string.Empty);
            obj[25] = new SqlParameter("MEM_Tinh", 0);
            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblMember_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Member Update(Member Updated,SqlConnection con)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[27];
            obj[0] = new SqlParameter("MEM_ID", Updated.ID);
            obj[1] = new SqlParameter("MEM_Ho", Updated.Ho);
            obj[2] = new SqlParameter("MEM_Ten", Updated.Ten);
            obj[3] = new SqlParameter("MEM_Mota", Updated.Mota);
            obj[4] = new SqlParameter("MEM_Anh", Updated.Anh);
            obj[5] = new SqlParameter("MEM_CQ_ID", Updated.CQ_ID);
            obj[6] = new SqlParameter("MEM_Username", Updated.Username);
            obj[7] = new SqlParameter("MEM_Password", Updated.Password);
            obj[8] = new SqlParameter("MEM_NgayTao", Updated.NgayTao);
            obj[9] = new SqlParameter("MEM_NgayCapNhat", Updated.NgayCapNhat);
            obj[10] = new SqlParameter("MEM_Email", Updated.Email);
            obj[11] = new SqlParameter("MEM_Mobile", Updated.Mobile);
            obj[12] = new SqlParameter("MEM_DiaChi", Updated.DiaChi);
            obj[13] = new SqlParameter("MEM_Active", Updated.Active);
            obj[14] = new SqlParameter("MEM_Khoa", Updated.Khoa);
            obj[15] = new SqlParameter("MEM_XacNhan", Updated.XacNhan);
            obj[16] = new SqlParameter("MEM_NgayXacNhan", Updated.NgayXacNhan);
            obj[17] = new SqlParameter("MEM_ChungThuc", Updated.ChungThuc);
            obj[18] = new SqlParameter("MEM_Admin", Updated.Admin);
            obj[19] = new SqlParameter("MEM_RowId", Updated.RowId);
            obj[20] = new SqlParameter("MEM_NguoiTao", Updated.NguoiTao);
            obj[21] = new SqlParameter("MEM_Loai", Updated.Loai);
            obj[22] = new SqlParameter("MEM_RefUsername", Updated.RefUsername);
            obj[23] = new SqlParameter("MEM_ThuKy", Updated.ThuKy);
            obj[24] = new SqlParameter("MEM_Loai_Ten", Updated.Loai_Ten);
            obj[25] = new SqlParameter("MEM_Phone", Updated.Phone);
            obj[26] = new SqlParameter("MEM_Tinh", Updated.Tinh);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblMember_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static void changePassword(string Username, string pwd)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("pwd", pwd);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Update_changePassword_linhnx", obj);
        }
        public static Member SelectEmailByUserName(string strMem)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", strMem);
            Item.Username = strMem;
            Item.Email = SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectEmailByUserName_linhnx", obj).ToString();            
            return Item;
        }
        public static Member SelectInfoByUserName(string strMem)
        {
            Member Item = new Member();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", strMem);
            Item.Username = strMem;
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Select_SelectInfoByUserName_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static bool UpdatePasswordByCode(string Username, string Code, string Password)
        {
            bool ok = false;
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Code", Code);
            obj[2] = new SqlParameter("Password", Password);
            ok = Convert.ToBoolean(SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Update_UpdatePasswordByCode_linhnx", obj).ToString());
            return ok;
        }
        public static void UpdateCodeByUsername(string strMem, string code)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", strMem);
            obj[1] = new SqlParameter("Code", code);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Update_UpdateCodeByUsername_linhnx", obj).ToString();

        }
        public static void UpdateInfoByUsername(string strMem, string Ten,string Email, string Mobile)
        {
            var obj = new SqlParameter[4];
            if (!string.IsNullOrEmpty(strMem))
            {
                obj[0] = new SqlParameter("Username", strMem);
                
            }
            else
            {
                obj[0] = new SqlParameter("Username", DBNull.Value);
                
            }
            if (!string.IsNullOrEmpty(Ten))
            {
                obj[1] = new SqlParameter("Ten", Ten);

            }
            else
            {

                obj[1] = new SqlParameter("Ten", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Email))
            {
                obj[2] = new SqlParameter("Email", Email);

            }
            else
            {
                obj[2] = new SqlParameter("Email", DBNull.Value);

            }
            if (!string.IsNullOrEmpty(Mobile))
            {
                obj[3] = new SqlParameter("Mobile", Mobile);

            }
            else
            {
                obj[3] = new SqlParameter("Mobile", DBNull.Value);

            }
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Update_UpdateInfoByUsername_linhnx", obj).ToString();

        }
        public static void UpdateAnh(string Username, string Anh)
        {
            var obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(Username))
            {
                obj[0] = new SqlParameter("Username", Username);

            }
            else
            {
                obj[0] = new SqlParameter("Username", DBNull.Value);

            }
            if (!string.IsNullOrEmpty(Anh))
            {
                obj[1] = new SqlParameter("Anh", Anh);

            }
            else
            {

                obj[1] = new SqlParameter("Anh", DBNull.Value);
            }
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Update_UpdateAnh_linhnx", obj).ToString();

        }
        public static void XacNhanById(string MEM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MEM_ID", MEM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMember_Update_XacNhanById_linhnx", obj);
        }
        public static MemberCollection SelectAllEmailUsername(SqlConnection connection)
        {
            MemberCollection List = new MemberCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, "sp_tblMember_Select_SelectAll_linhnx"))
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


