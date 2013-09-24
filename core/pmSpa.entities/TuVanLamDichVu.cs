using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using docsoft.entities;
using linh.controls;
using linh.core;
using linh.core.dal;

namespace pmSpa.entities
{
    #region TuVanLamDichVu
    #region BO
    public class TuVanLamDichVu : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid TVDV_ID { get; set; }
        public Guid KH_ID { get; set; }
        public String NhanVien { get; set; }
        public DateTime NgayLam { get; set; }
        public Int32 ThuTu { get; set; }
        #endregion
        #region Contructor
        public TuVanLamDichVu()
        { }
        #endregion
        #region Customs properties

        public string NhanVien_Ten { get; set; }
        public string KH_Ten { get; set; }
        public string DV_Ten { get; set; }
        public TuVanDichVu _TuVanDichVu { get; set; }
        public XuatNhap _XuatNhap { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TuVanLamDichVuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TuVanLamDichVuCollection : BaseEntityCollection<TuVanLamDichVu>
    { }
    #endregion
    #region Dal
    public class TuVanLamDichVuDal
    {
        #region Methods

        public static void DeleteById(Guid LDV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDV_ID", LDV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanLamDichVu_Delete_DeleteById_linhnx", obj);
        }

        public static TuVanLamDichVu Insert(TuVanLamDichVu item)
        {
            var Item = new TuVanLamDichVu();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("LDV_ID", item.ID);
            obj[1] = new SqlParameter("LDV_TVDV_ID", item.TVDV_ID);
            obj[2] = new SqlParameter("LDV_KH_ID", item.KH_ID);
            obj[3] = new SqlParameter("LDV_NhanVien", item.NhanVien);
            if (item.NgayLam > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("LDV_NgayLam", item.NgayLam);
            }
            else
            {
                obj[4] = new SqlParameter("LDV_NgayLam", DBNull.Value);
            }
            obj[5] = new SqlParameter("LDV_ThuTu", item.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanLamDichVu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanLamDichVu Update(TuVanLamDichVu item)
        {
            var Item = new TuVanLamDichVu();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("LDV_ID", item.ID);
            obj[1] = new SqlParameter("LDV_TVDV_ID", item.TVDV_ID);
            obj[2] = new SqlParameter("LDV_KH_ID", item.KH_ID);
            obj[3] = new SqlParameter("LDV_NhanVien", item.NhanVien);
            if (item.NgayLam > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("LDV_NgayLam", item.NgayLam);
            }
            else
            {
                obj[4] = new SqlParameter("LDV_NgayLam", DBNull.Value);
            }
            obj[5] = new SqlParameter("LDV_ThuTu", item.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanLamDichVu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanLamDichVu SelectById(Guid LDV_ID)
        {
            var Item = new TuVanLamDichVu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDV_ID", LDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanLamDichVu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanLamDichVuCollection SelectAll()
        {
            var List = new TuVanLamDichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanLamDichVu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TuVanLamDichVu> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<TuVanLamDichVu>("sp_tblSpaMgr_TuVanLamDichVu_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TuVanLamDichVu getFromReader(IDataReader rd)
        {
            var Item = new TuVanLamDichVu();
            if (rd.FieldExists("LDV_ID"))
            {
                Item.ID = (Guid)(rd["LDV_ID"]);
            }
            if (rd.FieldExists("LDV_TVDV_ID"))
            {
                Item.TVDV_ID = (Guid)(rd["LDV_TVDV_ID"]);
            }
            if (rd.FieldExists("LDV_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["LDV_KH_ID"]);
            }
            if (rd.FieldExists("LDV_NhanVien"))
            {
                Item.NhanVien = (String)(rd["LDV_NhanVien"]);
            }
            if (rd.FieldExists("LDV_NgayLam"))
            {
                Item.NgayLam = (DateTime)(rd["LDV_NgayLam"]);
            }
            if (rd.FieldExists("LDV_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["LDV_ThuTu"]);
            }
            if (rd.FieldExists("LDV_NhanVien_Ten"))
            {
                Item.NhanVien_Ten = (String)(rd["LDV_NhanVien_Ten"]);
            }
            if (rd.FieldExists("LDV_KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["LDV_KH_Ten"]);
            }
            if (rd.FieldExists("LDV_DV_Ten"))
            {
                Item.DV_Ten = (String)(rd["LDV_DV_Ten"]);
            }
            Item._TuVanDichVu = TuVanDichVuDal.getFromReader(rd);
            Item._XuatNhap = XuatNhapDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static TuVanLamDichVuCollection SelectByTvDvId(SqlConnection con, string TVDV_ID)
        {
            var List = new TuVanLamDichVuCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TVDV_ID", TVDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanLamDichVu_Select_SelectByTvDvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TuVanLamDichVuCollection SelectByNhanVienTuNgayDenNgay(SqlConnection con, string Username, string TuNgay, string DenNgay)
        {
            var List = new TuVanLamDichVuCollection();
            var obj = new SqlParameter[4];
            if (!string.IsNullOrEmpty(Username))
            {
                obj[0] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[0] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[2] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[2] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[3] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[3] = new SqlParameter("DenNgay", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanLamDichVu_Select_thongKeByNhanVienTheoThang_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TuVanLamDichVu> ByNhanVienTuNgayDenNgay(string url, bool rewrite, string sort, string q, int size, string Username, string TuNgay, string DenNgay)
        {
            var obj = new SqlParameter[5];
           
            if (!string.IsNullOrEmpty(Username))
            {
                obj[0] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[0] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                obj[1] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[1] = new SqlParameter("Sort", DBNull.Value);
            } if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[2] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[2] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[3] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[3] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<TuVanLamDichVu>("sp_tblSpaMgr_TuVanLamDichVu_Pager_ByNhanVienTuNgayDenNgay_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
}
