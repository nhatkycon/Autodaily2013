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
    #region DanhMucDonVi
    #region BO
    public class DanhMucDonVi : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 LDM_ID { get; set; }
        public String LDM_Ma { get; set; }
        public String LDM_Ten { get; set; }
        public String Ten { get; set; }
        public String KyHieu { get; set; }
        public String Ma { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String GiaTri { get; set; }
        public Int32 ThuTu { get; set; }
        public String NguoiSua { get; set; }
        #endregion
        #region Contructor
        public DanhMucDonVi()
        { }
        #endregion
        #region Customs properties
        public LoaiDanhMuc loaiDanhMuc { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DanhMucDonViDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DanhMucDonViCollection : BaseEntityCollection<DanhMucDonVi>
    { }
    #endregion
    #region Dal
    public class DanhMucDonViDal
    {
        #region Methods
        public static void DeleteById(Int32 DM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Delete_DeleteById_hoangda", obj);
        }
        public static DanhMucDonVi Insert(DanhMucDonVi Inserted)
        {
            DanhMucDonVi Item = new DanhMucDonVi();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("DM_LDM_Ma", Inserted.LDM_Ma);
            obj[1] = new SqlParameter("DM_LDM_ID", Inserted.LDM_ID);
            obj[2] = new SqlParameter("DM_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("DM_KyHieu", Inserted.KyHieu);
            obj[4] = new SqlParameter("DM_Ma", Inserted.Ma);
            obj[5] = new SqlParameter("DM_RowId", Inserted.RowId);
            obj[6] = new SqlParameter("DM_NgayTao", Inserted.NgayTao);
            obj[7] = new SqlParameter("DM_NguoiTao", Inserted.NguoiTao);
            obj[8] = new SqlParameter("DM_NgayCapNhat", Inserted.NgayCapNhat);
            obj[9] = new SqlParameter("DM_GiaTri", Inserted.GiaTri);
            obj[10] = new SqlParameter("DM_ThuTu", Inserted.ThuTu);
            obj[11] = new SqlParameter("DM_NguoiSua", Inserted.NguoiSua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMucDonVi Update(DanhMucDonVi Updated)
        {
            DanhMucDonVi Item = new DanhMucDonVi();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("DM_ID", Updated.ID);
            obj[1] = new SqlParameter("DM_LDM_Ma", Updated.LDM_Ma);
            obj[2] = new SqlParameter("DM_LDM_ID", Updated.LDM_ID);
            obj[3] = new SqlParameter("DM_Ten", Updated.Ten);
            obj[4] = new SqlParameter("DM_KyHieu", Updated.KyHieu);
            obj[5] = new SqlParameter("DM_Ma", Updated.Ma);
            obj[6] = new SqlParameter("DM_RowId", Updated.RowId);
            obj[7] = new SqlParameter("DM_NgayTao", Updated.NgayTao);
            obj[8] = new SqlParameter("DM_NguoiTao", Updated.NguoiTao);
            obj[9] = new SqlParameter("DM_NgayCapNhat", Updated.NgayCapNhat);
            obj[10] = new SqlParameter("DM_GiaTri", Updated.GiaTri);
            obj[11] = new SqlParameter("DM_ThuTu", Updated.ThuTu);
            obj[12] = new SqlParameter("DM_NguoiSua", Updated.NguoiSua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMucDonVi SelectById(Int32 DM_ID)
        {
            DanhMucDonVi Item = new DanhMucDonVi();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMucDonViCollection SelectAll()
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucDonVi QuickSave(string Ten, string KyHieu, string LDM_Ma)
        {
            DanhMucDonVi Item = new DanhMucDonVi();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Ten", Ten);
            obj[1] = new SqlParameter("KyHieu", KyHieu);
            obj[2] = new SqlParameter("LDM_Ma", LDM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Insert_QuickSave_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Pager<DanhMucDonVi> pagerNormal(string url, bool rewrite, string sort, string q, string _DM_LDM_Ma, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            obj[1] = new SqlParameter("q", q);
            if (string.IsNullOrEmpty(_DM_LDM_Ma))
            {
                obj[2] = new SqlParameter("ldm", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("ldm", _DM_LDM_Ma);
            }
            if (string.IsNullOrEmpty(pagesize)) pagesize = "20";
            Pager<DanhMucDonVi> pg = new Pager<DanhMucDonVi>("sp_tblDanhMucDonVi_Pager_Normal_hoangda", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<DanhMucDonVi> pagerNormal(string url, bool rewrite, string sort, string q, string _DM_LDM_Ma, string pagesize,string Username)
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
            obj[1] = new SqlParameter("q", q);
            if (string.IsNullOrEmpty(_DM_LDM_Ma))
            {
                obj[2] = new SqlParameter("ldm", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("ldm", _DM_LDM_Ma);
            }
            if (string.IsNullOrEmpty(Username))
            {
                obj[3] = new SqlParameter("Username", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("Username", Username);
            }
            if (string.IsNullOrEmpty(pagesize)) pagesize = "20";
            Pager<DanhMucDonVi> pg = new Pager<DanhMucDonVi>("sp_tblDanhMucDonVi_Pager_Normal_hoangda", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static DanhMucDonViCollection SearchByLDM(string LDM_Ma, string q,string Username)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[0] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(Username))
            {
                obj[2] = new SqlParameter("Username",DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("Username", Username);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Select_SearchByLDM_Username_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucDonViCollection SearchNguoiThao(string Top, string q)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Select_SearchNguoiThao_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucDonViCollection ByLdmAndPID(string LDM_ID, string PID)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            obj[1] = new SqlParameter("PID", PID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Select_ByLdmAndPID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderSearch(rd));
                }
            }
            return List;
        }
        public static DanhMucDonViCollection NoiGuiListDmGiaTri(string LDM_ID)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Select_NoiGuiListDmGiaTri_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderNoiGuiListDmGiaTri(rd));
                }
            }
            return List;
        }
        public static DanhMucDonViCollection NoiGuiListDmbyPid(string LDM_ID, string PID)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            obj[1] = new SqlParameter("PID", PID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Select_NoiGuiListDmbyPid_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderNoiGuiDm(rd));
                }
            }
            return List;
        }
        #endregion
        //sp_tblDanhMucDonVi_Pager_Normal_hoangda
        #region Utilities
        public static DanhMucDonVi getFromReaderNoiGuiDm(IDataReader rd)
        {
            DanhMucDonVi Item = new DanhMucDonVi();
            Item.ID = (Int32)(rd["DM_ID"]);
            Item.Ten = (String)(rd["DM_Ten"]);
            Item.KyHieu = (String)(rd["DM_KyHieu"]);
            Item.Ma = (String)(rd["DM_Ma"]);
            Item.RowId = (Guid)(rd["DM_RowId"]);
            Item.NguoiTao = (String)(rd["DM_NguoiTao"]);
            Item.GiaTri = (String)(rd["DM_GiaTri"]);
            Item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            Item.NguoiSua = (String)(rd["DM_NguoiSua"]);
            return Item;
        }
        public static DanhMucDonVi getFromReaderSearch(IDataReader rd)
        {
            DanhMucDonVi Item = new DanhMucDonVi();
            Item.ID = (Int32)(rd["DM_ID"]);
            Item.LDM_ID = (Int32)(rd["DM_LDM_ID"]);
            Item.Ten = (String)(rd["DM_Ten"]);
            Item.KyHieu = (String)(rd["DM_KyHieu"]);
            Item.Ma = (String)(rd["DM_Ma"]);
            Item.RowId = (Guid)(rd["DM_RowId"]);
            Item.NgayTao = (DateTime)(rd["DM_NgayTao"]);
            Item.NguoiTao = (String)(rd["DM_NguoiTao"]);
            Item.NgayCapNhat = (DateTime)(rd["DM_NgayCapNhat"]);
            Item.GiaTri = (String)(rd["DM_GiaTri"]);
            Item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            Item.NguoiSua = (String)(rd["DM_NguoiSua"]);
            return Item;
        }
        public static DanhMucDonVi getFromReaderNoiGuiListDmGiaTri(IDataReader rd)
        {
            DanhMucDonVi Item = new DanhMucDonVi();
            Item.Ten = (String)(rd["DM_Ten"]);
            Item.GiaTri = (String)(rd["DM_GiaTri"]);
            return Item;
        }
        public static DanhMucDonVi getFromReader(IDataReader rd)
        {
            DanhMucDonVi Item = new DanhMucDonVi();
            if (rd.FieldExists("DM_ID"))
            {
                Item.ID = (Int32)(rd["DM_ID"]);
            }
            if (rd.FieldExists("DM_LDM_ID"))
            {
                Item.LDM_ID = (Int32)(rd["DM_LDM_ID"]);
            }
            if (rd.FieldExists("DM_LDM_Ma"))
            {
                Item.LDM_Ma = (String)(rd["DM_LDM_Ma"]);
            }
            if (rd.FieldExists("LDM_Ten"))
            {
                Item.LDM_Ten = (String)(rd["LDM_Ten"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                Item.Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("DM_KyHieu"))
            {
                Item.KyHieu = (String)(rd["DM_KyHieu"]);
            }
            if (rd.FieldExists("DM_Ma"))
            {
                Item.Ma = (String)(rd["DM_Ma"]);
            }
            if (rd.FieldExists("DM_RowId"))
            {
                Item.RowId = (Guid)(rd["DM_RowId"]);
            }
            if (rd.FieldExists("DM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DM_NgayTao"]);
            }
            if (rd.FieldExists("DM_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["DM_NguoiTao"]);
            }
            if (rd.FieldExists("DM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["DM_NgayCapNhat"]);
            }
            if (rd.FieldExists("DM_GiaTri"))
            {
                Item.GiaTri = (String)(rd["DM_GiaTri"]);
            }
            if (rd.FieldExists("DM_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            }
            if (rd.FieldExists("DM_NguoiSua"))
            {
                Item.NguoiSua = (String)(rd["DM_NguoiSua"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static DanhMucDonViCollection SelectAllByUserLDM_Ma(SqlConnection con,string Username, string LDM_Ma)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Ma", LDM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMucDonVi_SelectDanhMucDonVi_By_GH_ID_LDM_Ma", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucDonViCollection SelectAllByUserLDM_Ma(string Username, string LDM_Ma)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Ma", LDM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_SelectDanhMucDonVi_By_User_LDM_Ma", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucDonViCollection SelectAll(string Username, string Ma)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Ma", Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Select_SelectAll_hoangda_Fix", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucDonViCollection DeleteByDM_Ma(string Username, string Ma)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Ma", Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_Delete_ByDMMa_hoangda_Fix", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucDonViCollection DanhMucHeThog(string LDM_ID, string DM_Alias,string ListID)
        {
            DanhMucDonViCollection List = new DanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            else { obj[0] = new SqlParameter("LDM_ID", DBNull.Value); }
            if (!string.IsNullOrEmpty(DM_Alias))
            {
                obj[1] = new SqlParameter("DM_Alias", DM_Alias);
            }
            else {
                obj[1] = new SqlParameter("DM_Alias", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(ListID))
            {
                obj[2] = new SqlParameter("ListID", ListID);
            }
            else
            {
                obj[2] = new SqlParameter("ListID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMucDonVi_HeThong_Select_SelectAll_hoangda_Fix", obj))
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
