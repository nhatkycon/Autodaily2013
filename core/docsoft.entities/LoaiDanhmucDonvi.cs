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
    #region LoaiDanhMucDonVi
    #region BO
    public class LoaiDanhMucDonVi : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String KyHieu { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 ThuTu { get; set; }
        public String NguoiSua { get; set; }
        #endregion
        #region Contructor
        public LoaiDanhMucDonVi()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LoaiDanhMucDonViDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LoaiDanhMucDonViCollection : BaseEntityCollection<LoaiDanhMucDonVi>
    { }
    #endregion
    #region Dal
    public class LoaiDanhMucDonViDal
    {
        #region Methods

        public static void DeleteById(Int32 LDM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMucDonVi_Delete_DeleteById_hoangda", obj);
        }
        public static void DeleteByUsername(string Username)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMucDonVi_Delete_DeleteByUsername_hoangda", obj);
        }

        public static LoaiDanhMucDonVi Insert(LoaiDanhMucDonVi Inserted)
        {
            LoaiDanhMucDonVi Item = new LoaiDanhMucDonVi();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("LDM_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("LDM_Ma", Inserted.Ma);
            obj[2] = new SqlParameter("LDM_KyHieu", Inserted.KyHieu);
            obj[3] = new SqlParameter("LDM_RowId", Inserted.RowId);
            obj[4] = new SqlParameter("LDM_NgayTao", Inserted.NgayTao);
            obj[5] = new SqlParameter("LDM_NguoiTao", Inserted.NguoiTao);
            obj[6] = new SqlParameter("LDM_NgayCapNhat", Inserted.NgayCapNhat);
            obj[7] = new SqlParameter("LDM_ThuTu", Inserted.ThuTu);
            obj[8] = new SqlParameter("LDM_NguoiSua", Inserted.NguoiSua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMucDonVi_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiDanhMucDonVi Update(LoaiDanhMucDonVi Updated)
        {
            LoaiDanhMucDonVi Item = new LoaiDanhMucDonVi();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("LDM_ID", Updated.ID);
            obj[1] = new SqlParameter("LDM_Ten", Updated.Ten);
            obj[2] = new SqlParameter("LDM_Ma", Updated.Ma);
            obj[3] = new SqlParameter("LDM_KyHieu", Updated.KyHieu);
            obj[4] = new SqlParameter("LDM_RowId", Updated.RowId);
            obj[5] = new SqlParameter("LDM_NgayTao", Updated.NgayTao);
            obj[6] = new SqlParameter("LDM_NguoiTao", Updated.NguoiTao);
            obj[7] = new SqlParameter("LDM_NgayCapNhat", Updated.NgayCapNhat);
            obj[8] = new SqlParameter("LDM_ThuTu", Updated.ThuTu);
            obj[9] = new SqlParameter("LDM_NguoiSua", Updated.NguoiSua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMucDonVi_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiDanhMucDonVi SelectById(Int32 LDM_ID)
        {
            LoaiDanhMucDonVi Item = new LoaiDanhMucDonVi();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMucDonVi_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiDanhMucDonViCollection SelectAll(string Username)
        {
            LoaiDanhMucDonViCollection List = new LoaiDanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMucDonVi_Select_SelectAll_hoangda",obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static LoaiDanhMucDonViCollection SelectAll(string Username, string Ma)
        {
            LoaiDanhMucDonViCollection List = new LoaiDanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Ma", Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMucDonVi_Select_SelectAll_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static LoaiDanhMucDonViCollection SelectAll()
        {
            LoaiDanhMucDonViCollection List = new LoaiDanhMucDonViCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMucDonVi_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LoaiDanhMucDonVi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<LoaiDanhMucDonVi> pg = new Pager<LoaiDanhMucDonVi>("sp_tblLoaiDanhMucDonVi_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        public static Pager<LoaiDanhMucDonVi> pagerNormal(string url, bool rewrite, string sort, string q, string pagesize, string Username)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            obj[2] = new SqlParameter("Username", Username);
            if (string.IsNullOrEmpty(pagesize)) pagesize = "20";
            Pager<LoaiDanhMucDonVi> pg = new Pager<LoaiDanhMucDonVi>("sp_tblLoaiDanhMucDonVi_Pager_Normal_hoangda", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static LoaiDanhMucDonViCollection SelectTree(string Username)
        {
            LoaiDanhMucDonViCollection List = new LoaiDanhMucDonViCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMucDonVi_Select_SelectAll_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #region Utilities
        public static LoaiDanhMucDonVi getFromReader(IDataReader rd)
        {
            LoaiDanhMucDonVi Item = new LoaiDanhMucDonVi();
            if (rd.FieldExists("LDM_ID"))
            {
                Item.ID = (Int32)(rd["LDM_ID"]);
            }
            if (rd.FieldExists("LDM_Ten"))
            {
                Item.Ten = (String)(rd["LDM_Ten"]);
            }
            if (rd.FieldExists("LDM_Ma"))
            {
                Item.Ma = (String)(rd["LDM_Ma"]);
            }
            if (rd.FieldExists("LDM_KyHieu"))
            {
                Item.KyHieu = (String)(rd["LDM_KyHieu"]);
            }
            if (rd.FieldExists("LDM_RowId"))
            {
                Item.RowId = (Guid)(rd["LDM_RowId"]);
            }
            if (rd.FieldExists("LDM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LDM_NgayTao"]);
            }
            if (rd.FieldExists("LDM_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["LDM_NguoiTao"]);
            }
            if (rd.FieldExists("LDM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["LDM_NgayCapNhat"]);
            }
            if (rd.FieldExists("LDM_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["LDM_ThuTu"]);
            }
            if (rd.FieldExists("LDM_NguoiSua"))
            {
                Item.NguoiSua = (String)(rd["LDM_NguoiSua"]);
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
