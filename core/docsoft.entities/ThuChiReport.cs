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
    #region ThuChiReport
    #region BO
    public class ThuChiReport : BaseEntity
    {
        #region Properties
        public Guid ma { get; set; }
        public String sophieu { get; set; }
        public String diengiai { get; set; }
        public Double thu_tk { get; set; }
        public Double thu_tm { get; set; }
        public Double thu_t { get; set; }
        public Double chi_tk { get; set; }
        public Double chi_tm { get; set; }
        public Double chi_t { get; set; }
        public Double tt_tk { get; set; }
        public Double tt_tm { get; set; }
        public Double tt_t { get; set; }
        public Double sodu_tk { get; set; }
        public Double sodu_tm { get; set; }
        public Double sodu_t { get; set; }
        public Int32 loaiquy { get; set; }
        public Boolean isthu { get; set; }
        public Boolean isCandoi { get; set; }
        public String ngay { get; set; }
        #endregion
        #region Contructor
        public ThuChiReport()
        { }
        #endregion
        #region Customs properties
        public String NguoiTao { get; set; }
        public ThuChi _ThuChi { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuChiReportDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuChiReportCollection : BaseEntityCollection<ThuChiReport>
    { }
    #endregion
    #region Dal
    public class ThuChiReportDal
    {
        #region Methods

        public static void DeleteById(Guid TC_ma)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TC_ma", TC_ma);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChiReport_Delete_DeleteById_linhnx", obj);
        }

        public static ThuChiReport Insert(ThuChiReport item)
        {
            var Item = new ThuChiReport();
            var obj = new SqlParameter[19];
            obj[0] = new SqlParameter("TC_ma", item.ma);
            obj[1] = new SqlParameter("TC_sophieu", item.sophieu);
            obj[2] = new SqlParameter("TC_diengiai", item.diengiai);
            obj[3] = new SqlParameter("TC_thu_tk", item.thu_tk);
            obj[4] = new SqlParameter("TC_thu_tm", item.thu_tm);
            obj[5] = new SqlParameter("TC_thu_t", item.thu_t);
            obj[6] = new SqlParameter("TC_chi_tk", item.chi_tk);
            obj[7] = new SqlParameter("TC_chi_tm", item.chi_tm);
            obj[8] = new SqlParameter("TC_chi_t", item.chi_t);
            obj[9] = new SqlParameter("TC_tt_tk", item.tt_tk);
            obj[10] = new SqlParameter("TC_tt_tm", item.tt_tm);
            obj[11] = new SqlParameter("TC_tt_t", item.tt_t);
            obj[12] = new SqlParameter("TC_sodu_tk", item.sodu_tk);
            obj[13] = new SqlParameter("TC_sodu_tm", item.sodu_tm);
            obj[14] = new SqlParameter("TC_sodu_t", item.sodu_t);
            obj[15] = new SqlParameter("TC_loaiquy", item.loaiquy);
            obj[16] = new SqlParameter("TC_isthu", item.isthu);
            obj[17] = new SqlParameter("TC_isCandoi", item.isCandoi);
            obj[18] = new SqlParameter("TC_ngay", item.ngay);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChiReport_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChiReport Update(ThuChiReport item)
        {
            var Item = new ThuChiReport();
            var obj = new SqlParameter[19];
            obj[0] = new SqlParameter("TC_ma", item.ma);
            obj[1] = new SqlParameter("TC_sophieu", item.sophieu);
            obj[2] = new SqlParameter("TC_diengiai", item.diengiai);
            obj[3] = new SqlParameter("TC_thu_tk", item.thu_tk);
            obj[4] = new SqlParameter("TC_thu_tm", item.thu_tm);
            obj[5] = new SqlParameter("TC_thu_t", item.thu_t);
            obj[6] = new SqlParameter("TC_chi_tk", item.chi_tk);
            obj[7] = new SqlParameter("TC_chi_tm", item.chi_tm);
            obj[8] = new SqlParameter("TC_chi_t", item.chi_t);
            obj[9] = new SqlParameter("TC_tt_tk", item.tt_tk);
            obj[10] = new SqlParameter("TC_tt_tm", item.tt_tm);
            obj[11] = new SqlParameter("TC_tt_t", item.tt_t);
            obj[12] = new SqlParameter("TC_sodu_tk", item.sodu_tk);
            obj[13] = new SqlParameter("TC_sodu_tm", item.sodu_tm);
            obj[14] = new SqlParameter("TC_sodu_t", item.sodu_t);
            obj[15] = new SqlParameter("TC_loaiquy", item.loaiquy);
            obj[16] = new SqlParameter("TC_isthu", item.isthu);
            obj[17] = new SqlParameter("TC_isCandoi", item.isCandoi);
            obj[18] = new SqlParameter("TC_ngay", item.ngay);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChiReport_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChiReport SelectById(Guid TC_ma)
        {
            var Item = new ThuChiReport();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TC_ma", TC_ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChiReport_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChiReportCollection SelectAll()
        {
            var List = new ThuChiReportCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChiReport_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ThuChiReport> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<ThuChiReport>("sp_tblThuChiReport_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ThuChiReport getFromReader(IDataReader rd)
        {
            var Item = new ThuChiReport();
            if (rd.FieldExists("ma"))
            {
                Item.ma = (Guid)(rd["ma"]);
            }
            if (rd.FieldExists("sophieu"))
            {
                Item.sophieu = (String)(rd["sophieu"]);
            }
            if (rd.FieldExists("diengiai"))
            {
                Item.diengiai = (String)(rd["diengiai"]);
            }
            if (rd.FieldExists("thu_tk"))
            {
                Item.thu_tk = (Double)(rd["thu_tk"]);
            }
            if (rd.FieldExists("thu_tm"))
            {
                Item.thu_tm = (Double)(rd["thu_tm"]);
            }
            if (rd.FieldExists("thu_t"))
            {
                Item.thu_t = (Double)(rd["thu_t"]);
            }
            if (rd.FieldExists("chi_tk"))
            {
                Item.chi_tk = (Double)(rd["chi_tk"]);
            }
            if (rd.FieldExists("chi_tm"))
            {
                Item.chi_tm = (Double)(rd["chi_tm"]);
            }
            if (rd.FieldExists("chi_t"))
            {
                Item.chi_t = (Double)(rd["chi_t"]);
            }
            if (rd.FieldExists("tt_tk"))
            {
                Item.tt_tk = (Double)(rd["tt_tk"]);
            }
            if (rd.FieldExists("tt_tm"))
            {
                Item.tt_tm = (Double)(rd["tt_tm"]);
            }
            if (rd.FieldExists("tt_t"))
            {
                Item.tt_t = (Double)(rd["tt_t"]);
            }
            if (rd.FieldExists("sodu_tk"))
            {
                Item.sodu_tk = (Double)(rd["sodu_tk"]);
            }
            if (rd.FieldExists("sodu_tm"))
            {
                Item.sodu_tm = (Double)(rd["sodu_tm"]);
            }
            if (rd.FieldExists("sodu_t"))
            {
                Item.sodu_t = (Double)(rd["sodu_t"]);
            }
            if (rd.FieldExists("loaiquy"))
            {
                Item.loaiquy = (Int32)(rd["loaiquy"]);
            }
            if (rd.FieldExists("isthu"))
            {
                Item.isthu = (Boolean)(rd["isthu"]);
            }
            if (rd.FieldExists("isCandoi"))
            {
                Item.isCandoi = (Boolean)(rd["isCandoi"]);
            }
            if (rd.FieldExists("ngay"))
            {
                Item.ngay = (String)(rd["ngay"]);
            }
            if (rd.FieldExists("TC_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TC_NguoiTao"]);
            }
            Item._ThuChi = ThuChiDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static ThuChiReportCollection SelectTuNgayDenNgay(string TuNgay, string DenNgay)
        {
            var List = new ThuChiReportCollection();
            var obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[0] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[0] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[1] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("TuNgay", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_rpt_ThuChiTuNgayDenNgay", obj))
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
