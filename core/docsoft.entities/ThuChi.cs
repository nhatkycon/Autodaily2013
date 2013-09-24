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
    #region ThuChi
    #region BO
    public class ThuChi : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid NDTC_ID { get; set; }
        public String SoPhieu { get; set; }
        public Double SoTien { get; set; }
        public String Mota { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgaySua { get; set; }
        public String NguoiSua { get; set; }
        public Int32 LoaiQuy { get; set; }
        public Int32 LoaiCandoi { get; set; }
        public Boolean isCandoi { get; set; }
        public Boolean Thu { get; set; }
        public Guid XN_ID { get; set; }
        public Guid P_ID { get; set; }
        public Guid DV_ID { get; set; }
        #endregion
        #region Contructor
        public ThuChi()
        { }
        #endregion
        #region Customs properties

        public string NDTC_Ten { get; set; }
        public string P_Ten { get; set; }
        public string NguoiTao_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuChiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuChiCollection : BaseEntityCollection<ThuChi>
    { }
    #endregion
    #region Dal
    public class ThuChiDal
    {
        #region Methods

        public static void DeleteById(Guid TC_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TC_ID", TC_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Delete_DeleteById_linhnx", obj);
        }

        public static ThuChi Insert(ThuChi item)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[16];
            obj[0] = new SqlParameter("TC_ID", item.ID);
            obj[1] = new SqlParameter("TC_NDTC_ID", item.NDTC_ID);
            obj[2] = new SqlParameter("TC_SoPhieu", item.SoPhieu);
            obj[3] = new SqlParameter("TC_SoTien", item.SoTien);
            obj[4] = new SqlParameter("TC_Mota", item.Mota);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("TC_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("TC_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("TC_NguoiTao", item.NguoiTao);
            if (item.NgaySua > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TC_NgaySua", item.NgaySua);
            }
            else
            {
                obj[7] = new SqlParameter("TC_NgaySua", DBNull.Value);
            }
            obj[8] = new SqlParameter("TC_NguoiSua", item.NguoiSua);
            obj[9] = new SqlParameter("TC_LoaiQuy", item.LoaiQuy);
            obj[10] = new SqlParameter("TC_LoaiCandoi", item.LoaiCandoi);
            obj[11] = new SqlParameter("TC_isCandoi", item.isCandoi);
            obj[12] = new SqlParameter("TC_Thu", item.Thu);
            obj[13] = new SqlParameter("TC_XN_ID", item.XN_ID);
            obj[14] = new SqlParameter("TC_P_ID", item.P_ID);
            obj[15] = new SqlParameter("TC_DV_ID", item.DV_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChi Update(ThuChi item)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[16];
            obj[0] = new SqlParameter("TC_ID", item.ID);
            obj[1] = new SqlParameter("TC_NDTC_ID", item.NDTC_ID);
            obj[2] = new SqlParameter("TC_SoPhieu", item.SoPhieu);
            obj[3] = new SqlParameter("TC_SoTien", item.SoTien);
            obj[4] = new SqlParameter("TC_Mota", item.Mota);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("TC_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("TC_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("TC_NguoiTao", item.NguoiTao);
            if (item.NgaySua > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TC_NgaySua", item.NgaySua);
            }
            else
            {
                obj[7] = new SqlParameter("TC_NgaySua", DBNull.Value);
            }
            obj[8] = new SqlParameter("TC_NguoiSua", item.NguoiSua);
            obj[9] = new SqlParameter("TC_LoaiQuy", item.LoaiQuy);
            obj[10] = new SqlParameter("TC_LoaiCandoi", item.LoaiCandoi);
            obj[11] = new SqlParameter("TC_isCandoi", item.isCandoi);
            obj[12] = new SqlParameter("TC_Thu", item.Thu);
            obj[13] = new SqlParameter("TC_XN_ID", item.XN_ID);
            obj[14] = new SqlParameter("TC_P_ID", item.P_ID);
            obj[15] = new SqlParameter("TC_DV_ID", item.DV_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChi SelectById(Guid TC_ID)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TC_ID", TC_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChiCollection SelectAll()
        {
            var List = new ThuChiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ThuChi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<ThuChi>("sp_tblThuChi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ThuChi getFromReader(IDataReader rd)
        {
            var Item = new ThuChi();
            if (rd.FieldExists("TC_ID"))
            {
                Item.ID = (Guid)(rd["TC_ID"]);
            }
            if (rd.FieldExists("TC_NDTC_ID"))
            {
                Item.NDTC_ID = (Guid)(rd["TC_NDTC_ID"]);
            }
            if (rd.FieldExists("TC_SoPhieu"))
            {
                Item.SoPhieu = (String)(rd["TC_SoPhieu"]);
            }
            if (rd.FieldExists("TC_SoTien"))
            {
                Item.SoTien = (Double)(rd["TC_SoTien"]);
            }
            if (rd.FieldExists("TC_Mota"))
            {
                Item.Mota = (String)(rd["TC_Mota"]);
            }
            if (rd.FieldExists("TC_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TC_NgayTao"]);
            }
            if (rd.FieldExists("TC_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TC_NguoiTao"]);
            }
            if (rd.FieldExists("TC_NgaySua"))
            {
                Item.NgaySua = (DateTime)(rd["TC_NgaySua"]);
            }
            if (rd.FieldExists("TC_NguoiSua"))
            {
                Item.NguoiSua = (String)(rd["TC_NguoiSua"]);
            }
            if (rd.FieldExists("TC_LoaiQuy"))
            {
                Item.LoaiQuy = (Int32)(rd["TC_LoaiQuy"]);
            }
            if (rd.FieldExists("TC_LoaiCandoi"))
            {
                Item.LoaiCandoi = (Int32)(rd["TC_LoaiCandoi"]);
            }
            if (rd.FieldExists("TC_isCandoi"))
            {
                Item.isCandoi = (Boolean)(rd["TC_isCandoi"]);
            }
            if (rd.FieldExists("TC_Thu"))
            {
                Item.Thu = (Boolean)(rd["TC_Thu"]);
            }
            if (rd.FieldExists("TC_XN_ID"))
            {
                Item.XN_ID = (Guid)(rd["TC_XN_ID"]);
            }
            if (rd.FieldExists("TC_P_ID"))
            {
                Item.P_ID = (Guid)(rd["TC_P_ID"]);
            }
            if (rd.FieldExists("TC_DV_ID"))
            {
                Item.DV_ID = (Guid)(rd["TC_DV_ID"]);
            }
            if (rd.FieldExists("TC_NDTC_Ten"))
            {
                Item.NDTC_Ten = (String)(rd["TC_NDTC_Ten"]);
            }
            if (rd.FieldExists("TC_P_Ten"))
            {
                Item.P_Ten = (String)(rd["TC_P_Ten"]);
            }
            if (rd.FieldExists("TC_NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["TC_NguoiTao_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<ThuChi> pagerTuNgayDenNgay(string sort, string q, int size, bool? Thu,string TuNgay, string DenNgay, string NDTC_ID)
        {
            return pagerTuNgayDenNgay(sort, q, size, Thu, TuNgay, DenNgay, NDTC_ID, null, false);
        }
        public static Pager<ThuChi> pagerTuNgayDenNgay(string sort, string q, int size, bool? Thu, string TuNgay, string DenNgay, string NDTC_ID, string P_ID)
        {
            return pagerTuNgayDenNgay(sort, q, size, Thu, TuNgay, DenNgay, NDTC_ID, P_ID, null);
        }
        public static Pager<ThuChi> pagerTuNgayDenNgay(string sort, string q, int size, bool? Thu, string TuNgay, string DenNgay, string NDTC_ID, string P_ID, bool? isCanDoi)
        {
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (Thu != null)
            {
                obj[2] = new SqlParameter("Thu", Thu);
            }
            else
            {
                obj[2] = new SqlParameter("Thu", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[3] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[3] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[4] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[4] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NDTC_ID))
            {
                obj[5] = new SqlParameter("NDTC_ID", NDTC_ID);
            }
            else
            {
                obj[5] = new SqlParameter("NDTC_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(P_ID))
            {
                obj[6] = new SqlParameter("P_ID", P_ID);
            }
            else
            {
                obj[6] = new SqlParameter("P_ID", DBNull.Value);
            }
            if (isCanDoi != null)
            {
                obj[7] = new SqlParameter("isCanDoi", isCanDoi);
            }
            else
            {
                obj[7] = new SqlParameter("isCanDoi", DBNull.Value);
            }
            var pg = new Pager<ThuChi>("sp_tblThuChi_Pager_pagerTuNgayDenNgay_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static ThuChi SelectByDraff(bool Thu)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Thu", Thu);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Select_SelectDraff_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ThuChi SelectByXnId(string XN_ID)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XN_ID", XN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Select_SelectByXnId_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ThuChi SelectByDvId(string DV_ID)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DV_ID", DV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Select_SelectByDvId_linhnx", obj))
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
