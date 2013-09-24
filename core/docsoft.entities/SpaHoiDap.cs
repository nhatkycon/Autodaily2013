using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using docsoft.entities;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace spa.entitites
{
    #region SpaHoiDap
    #region BO
    public class SpaHoiDap : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 HD_ID { get; set; }
        public Guid DM_ID { get; set; }
        public Guid DoTuoi_ID { get; set; }
        public String Ten { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public Boolean DaTraLoi { get; set; }
        public Boolean Active { get; set; }
        public Boolean Hot { get; set; }
        #endregion
        #region Contructor
        public SpaHoiDap()
        { }
        #endregion
        #region Customs properties
        public DanhMuc _DanhMuc { get; set; }
        public string DoTuoi_Ten { get; set; }
        public string HD_Ten { get; set; }
        public Member _Member { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SpaHoiDapDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SpaHoiDapCollection : BaseEntityCollection<SpaHoiDap>
    { }
    #endregion
    #region Dal
    public class SpaHoiDapDal
    {
        #region Methods

        public static void DeleteById(Int32 HD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HD_ID", HD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaHoiDap_Delete_DeleteById_hoangda", obj);
        }

        public static SpaHoiDap Insert(SpaHoiDap Inserted)
        {
            SpaHoiDap Item = new SpaHoiDap();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("HD_HD_ID", Inserted.HD_ID);
            obj[1] = new SqlParameter("HD_DM_ID", Inserted.DM_ID);
            obj[2] = new SqlParameter("HD_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("HD_NoiDung", Inserted.NoiDung);
            obj[4] = new SqlParameter("HD_NgayTao", Inserted.NgayTao);
            obj[5] = new SqlParameter("HD_NguoiTao", Inserted.NguoiTao);
            obj[6] = new SqlParameter("HD_Email", Inserted.Email);
            obj[7] = new SqlParameter("HD_Mobile", Inserted.Mobile);
            obj[8] = new SqlParameter("HD_DaTraLoi", Inserted.DaTraLoi);
            obj[9] = new SqlParameter("HD_Active", Inserted.Active);
            obj[10] = new SqlParameter("HD_Hot", Inserted.Hot);
            obj[11] = new SqlParameter("HD_DoTuoi_ID", Inserted.DoTuoi_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaHoiDap_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaHoiDap Update(SpaHoiDap Updated)
        {
            SpaHoiDap Item = new SpaHoiDap();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("HD_ID", Updated.ID);
            obj[1] = new SqlParameter("HD_HD_ID", Updated.HD_ID);
            obj[2] = new SqlParameter("HD_DM_ID", Updated.DM_ID);
            obj[3] = new SqlParameter("HD_Ten", Updated.Ten);
            obj[4] = new SqlParameter("HD_NoiDung", Updated.NoiDung);
            obj[5] = new SqlParameter("HD_NgayTao", Updated.NgayTao);
            obj[6] = new SqlParameter("HD_NguoiTao", Updated.NguoiTao);
            obj[7] = new SqlParameter("HD_Email", Updated.Email);
            obj[8] = new SqlParameter("HD_Mobile", Updated.Mobile);
            obj[9] = new SqlParameter("HD_DaTraLoi", Updated.DaTraLoi);
            obj[10] = new SqlParameter("HD_Active", Updated.Active);
            obj[11] = new SqlParameter("HD_Hot", Updated.Hot);
            obj[12] = new SqlParameter("HD_DoTuoi_ID", Updated.DoTuoi_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaHoiDap_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaHoiDap SelectById(Int32 HD_ID)
        {
            SpaHoiDap Item = new SpaHoiDap();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HD_ID", HD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaHoiDap_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaHoiDapCollection SelectAll()
        {
            SpaHoiDapCollection List = new SpaHoiDapCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaHoiDap_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<SpaHoiDap> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<SpaHoiDap> pg = new Pager<SpaHoiDap>("sp_tblSpaHoiDap_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static SpaHoiDap getFromReader(IDataReader rd)
        {
            SpaHoiDap Item = new SpaHoiDap();
            if (rd.FieldExists("HD_ID"))
            {
                Item.ID = (Int32)(rd["HD_ID"]);
            }
            if (rd.FieldExists("HD_HD_ID"))
            {
                Item.HD_ID = (Int32)(rd["HD_HD_ID"]);
            }
            if (rd.FieldExists("HD_DM_ID"))
            {
                Item.DM_ID = new Guid(rd["HD_DM_ID"].ToString());
            }
            if (rd.FieldExists("HD_DoTuoi_ID"))
            {
                Item.DoTuoi_ID = new Guid(rd["HD_DoTuoi_ID"].ToString());
            }
            if (rd.FieldExists("HD_Ten"))
            {
                Item.Ten = (String)(rd["HD_Ten"]);
            }
            if (rd.FieldExists("HD_NoiDung"))
            {
                Item.NoiDung = (String)(rd["HD_NoiDung"]);
            }
            if (rd.FieldExists("HD_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["HD_NgayTao"]);
            }
            if (rd.FieldExists("HD_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["HD_NguoiTao"]);
            }
            if (rd.FieldExists("HD_Email"))
            {
                Item.Email = (String)(rd["HD_Email"]);
            }
            if (rd.FieldExists("HD_DoTuoi_Ten"))
            {
                Item.DoTuoi_Ten = (String)(rd["HD_DoTuoi_Ten"]);
            }
            if (rd.FieldExists("HD_Mobile"))
            {
                Item.Mobile = (String)(rd["HD_Mobile"]);
            }
            if (rd.FieldExists("HD_DaTraLoi"))
            {
                Item.DaTraLoi = (Boolean)(rd["HD_DaTraLoi"]);
            }
            if (rd.FieldExists("HD_Active"))
            {
                Item.Active = (Boolean)(rd["HD_Active"]);
            }
            if (rd.FieldExists("HD_Hot"))
            {
                Item.Hot = (Boolean)(rd["HD_Hot"]);
            }
            if (rd.FieldExists("HD_HD_Ten"))
            {
                Item.HD_Ten = (String)(rd["HD_HD_Ten"]);
            }
            var _danhMuc = new DanhMuc();
            var _mem = new Member();
            _danhMuc = DanhMucDal.getFromReader(rd);
            _mem = MemberDal.getFromReader(rd);
            Item._DanhMuc = _danhMuc;
            Item._Member = _mem;
            return Item;
        }
        #endregion

        #region Extend
        public static SpaHoiDap SelectById(SqlConnection con, Int32 HD_ID)
        {
            SpaHoiDap Item = new SpaHoiDap();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HD_ID", HD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaHoiDap_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Pager<SpaHoiDap> pagerByDichVu(string sort, string q, string cUrl, string _dm_id, int size)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_dm_id))
            {
                obj[2] = new SqlParameter("dm_id", _dm_id);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            Pager<SpaHoiDap> pg = new Pager<SpaHoiDap>("sp_tblSpaHoiDap_Pager_pagerByDichVu_hoangda", "pages", size, 10, false, cUrl, obj);
            return pg;
        }
        public static Pager<SpaHoiDap> pagerByDichVu(string sort, string q, string _dm_id, int size)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_dm_id))
            {
                obj[2] = new SqlParameter("dm_id", _dm_id);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            Pager<SpaHoiDap> pg = new Pager<SpaHoiDap>("sp_tblSpaHoiDap_Pager_pagerByDichVu_hoangda", "pages", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<SpaHoiDap> pagerCauHoi(string q, int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(q))
            {
                obj[0] = new SqlParameter("q", q);
            }
            else
            {
                obj[0] = new SqlParameter("q", DBNull.Value);
            }
            Pager<SpaHoiDap> pg = new Pager<SpaHoiDap>("sp_tblSpaHoiDap_Pager_pagerCauHoi_hoangda", "pages", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static SpaHoiDapCollection SelectHome(int Top)
        {
            SpaHoiDapCollection List = new SpaHoiDapCollection();
            SqlParameter[] obj = new SqlParameter[]{
                new SqlParameter("Top",Top)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaHoiDap_Select_SelectHome_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaHoiDapCollection SelectHome(SqlConnection con, int Top)
        {
            SpaHoiDapCollection List = new SpaHoiDapCollection();
            SqlParameter[] obj = new SqlParameter[]{
                new SqlParameter("Top",Top)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaHoiDap_Select_SelectHome_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaHoiDapCollection CauTraLoi(SqlConnection con, string HD_ID, int Top)
        {
            var List = new SpaHoiDapCollection();
            var obj = new SqlParameter[]{
                new SqlParameter("Top",Top)
                , new SqlParameter("HD_ID", HD_ID), 
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaHoiDap_Select_CauTraLoi_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaHoiDapCollection CauHoiLienQuan(SqlConnection con, string HD_ID, int Top)
        {
            var List = new SpaHoiDapCollection();
            var obj = new SqlParameter[]{
                new SqlParameter("Top",Top)
                , new SqlParameter("HD_ID", HD_ID), 
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaHoiDap_Select_CauHoiLienQuan_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaHoiDapCollection SelectByUsername(SqlConnection con, string Username, int Top)
        {
            SpaHoiDapCollection List = new SpaHoiDapCollection();
            SqlParameter[] obj = new SqlParameter[]{
                new SqlParameter("Top",Top)
                , new SqlParameter("Username", Username), 
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaHoiDap_Select_SelectByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaHoiDapCollection SelectByDanhMuc(SqlConnection con, string DM_ID, int Top)
        {
            SpaHoiDapCollection List = new SpaHoiDapCollection();
            SqlParameter[] obj = new SqlParameter[]{
                new SqlParameter("Top",Top)
                , new SqlParameter("DM_ID", DM_ID), 
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaHoiDap_Select_SelectByDanhMuc_linhnx", obj))
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

