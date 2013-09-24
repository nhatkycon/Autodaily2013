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
    #region MauTaiLieu
    #region BO
    public class MauTaiLieu : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public String DM_Ten { get; set; }
        public String DM_Ma { get; set; }
        public String DM_KyHieu { get; set; }
        public String Ten { get; set; }
        public Boolean Check { get; set; }
        public Guid RowId { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiSua { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 Loai { get; set; }
        public Int32 SoLuong { get; set; }
        #endregion
        #region Contructor
        public MauTaiLieu()
        { }
        #endregion
        #region Customs properties
        public Int32 DM_Check { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return MauTaiLieuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class MauTaiLieuCollection : BaseEntityCollection<MauTaiLieu>
    { }
    #endregion
    #region Dal
    public class MauTaiLieuDal
    {
        #region Methods

        public static void DeleteById(Int32 MTL_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MTL_ID", MTL_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieu_Delete_DeleteById_linhnx", obj);
        }

        public static MauTaiLieu Insert(MauTaiLieu Inserted)
        {
            MauTaiLieu Item = new MauTaiLieu();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("MTL_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("MTL_DM_Ten", Inserted.DM_Ten);
            obj[2] = new SqlParameter("MTL_DM_Ma", Inserted.DM_Ma);
            obj[3] = new SqlParameter("MTL_DM_KyHieu", Inserted.DM_KyHieu);
            obj[4] = new SqlParameter("MTL_Ten", Inserted.Ten);
            obj[5] = new SqlParameter("MTL_Check", Inserted.Check);
            obj[6] = new SqlParameter("MTL_RowId", Inserted.RowId);
            obj[7] = new SqlParameter("MTL_NguoiTao", Inserted.NguoiTao);
            obj[8] = new SqlParameter("MTL_NguoiSua", Inserted.NguoiSua);
            obj[9] = new SqlParameter("MTL_NgayTao", Inserted.NgayTao);
            obj[10] = new SqlParameter("MTL_NgayCapNhat", Inserted.NgayCapNhat);
            obj[11] = new SqlParameter("MTL_Loai", Inserted.Loai);
            obj[12] = new SqlParameter("MTL_SoLuong", Inserted.SoLuong);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static MauTaiLieu Update(MauTaiLieu Updated)
        {
            MauTaiLieu Item = new MauTaiLieu();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("MTL_ID", Updated.ID);
            obj[1] = new SqlParameter("MTL_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("MTL_DM_Ten", Updated.DM_Ten);
            obj[3] = new SqlParameter("MTL_DM_Ma", Updated.DM_Ma);
            obj[4] = new SqlParameter("MTL_DM_KyHieu", Updated.DM_KyHieu);
            obj[5] = new SqlParameter("MTL_Ten", Updated.Ten);
            obj[6] = new SqlParameter("MTL_Check", Updated.Check);
            obj[7] = new SqlParameter("MTL_RowId", Updated.RowId);
            obj[8] = new SqlParameter("MTL_NguoiTao", Updated.NguoiTao);
            obj[9] = new SqlParameter("MTL_NguoiSua", Updated.NguoiSua);
            obj[10] = new SqlParameter("MTL_NgayTao", Updated.NgayTao);
            obj[11] = new SqlParameter("MTL_NgayCapNhat", Updated.NgayCapNhat);
            obj[12] = new SqlParameter("MTL_Loai", Updated.Loai);
            obj[13] = new SqlParameter("MTL_SoLuong", Updated.SoLuong);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static MauTaiLieu SelectById(Int32 MTL_ID)
        {
            MauTaiLieu Item = new MauTaiLieu();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MTL_ID", MTL_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static MauTaiLieuCollection SelectAll()
        {
            MauTaiLieuCollection List = new MauTaiLieuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<MauTaiLieu> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<MauTaiLieu> pg = new Pager<MauTaiLieu>("sp_tblMauTaiLieu_Pager_Normal_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<MauTaiLieu> pagerNormalMTL(string url, bool rewrite, string sort, string RowId)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(RowId))
            {
                obj[1] = new SqlParameter("RowId", RowId);
            }
            else
            {
                obj[1] = new SqlParameter("RowId", DBNull.Value);
            }
            Pager<MauTaiLieu> pg = new Pager<MauTaiLieu>("sp_tblMauTaiLieuThuTuc_Pager_Normal_hungpm", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static MauTaiLieu getFromReader(IDataReader rd)
        {
            MauTaiLieu Item = new MauTaiLieu();
            if (rd.FieldExists("MTL_ID"))
            {
                Item.ID = (Int32)(rd["MTL_ID"]);
            }
            if (rd.FieldExists("MTL_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["MTL_DM_ID"]);
            }
            if (rd.FieldExists("MTL_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["MTL_DM_Ten"]);
            }
            if (rd.FieldExists("MTL_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["MTL_SoLuong"]);
            }
            if (rd.FieldExists("MTL_DM_Check"))
            {
                Item.DM_Check = (Int32)(rd["MTL_DM_Check"]);
            }
            if (rd.FieldExists("MTL_DM_Ma"))
            {
                Item.DM_Ma = (String)(rd["MTL_DM_Ma"]);
            }
            if (rd.FieldExists("MTL_DM_KyHieu"))
            {
                Item.DM_KyHieu = (String)(rd["MTL_DM_KyHieu"]);
            }
            if (rd.FieldExists("MTL_Ten"))
            {
                Item.Ten = (String)(rd["MTL_Ten"]);
            }
            if (rd.FieldExists("MTL_Check"))
            {
                Item.Check = (Boolean)(rd["MTL_Check"]);
            }
            if (rd.FieldExists("MTL_RowId"))
            {
                Item.RowId = (Guid)(rd["MTL_RowId"]);
            }
            if (rd.FieldExists("MTL_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["MTL_NguoiTao"]);
            }
            if (rd.FieldExists("MTL_NguoiSua"))
            {
                Item.NguoiSua = (String)(rd["MTL_NguoiSua"]);
            }
            if (rd.FieldExists("MTL_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["MTL_NgayTao"]);
            }
            if (rd.FieldExists("MTL_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["MTL_NgayCapNhat"]);
            }
            if (rd.FieldExists("MTL_Loai"))
            {
                Item.Loai = (Int32)(rd["MTL_Loai"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static MauTaiLieuCollection Select_ByVBID(string DM_ID, string VB_ID)
        {
            MauTaiLieuCollection List = new MauTaiLieuCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("VB_ID", VB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieu_Select_SelectAll_linhnx",obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static MauTaiLieuCollection Select_ByListId(string _CId)
        {
            MauTaiLieuCollection List = new MauTaiLieuCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("iList", _CId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieu_Select_SelectByIdList_hungpm", obj))
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


