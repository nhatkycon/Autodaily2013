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
    #region XuatNhapReport
    #region BO
    public class XuatNhapReport : BaseEntity
    {
        #region Properties
        public Guid HH_ID { get; set; }
        public String HH_Ten { get; set; }
        public String HH_Ma { get; set; }
        public String HH_DonVi { get; set; }
        public Double DauKy_SoLuong { get; set; }
        public Double DauKy_Tien { get; set; }
        public Double Nhap_SoLuong { get; set; }
        public Double Nhap_Tien { get; set; }
        public Double Xuat_SoLuong { get; set; }
        public Double Xuat_Tien { get; set; }
        public Double CuoiKy_SoLuong { get; set; }
        public Double CuoiKy_Tien { get; set; }
        public Double HH_GiaNhap { get; set; }
        #endregion
        #region Contructor
        public XuatNhapReport()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return XuatNhapReportDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class XuatNhapReportCollection : BaseEntityCollection<XuatNhapReport>
    { }
    #endregion
    #region Dal
    public class XuatNhapReportDal
    {
        #region Methods

        public static void DeleteById(Guid BCXN_HH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BCXN_HH_ID", BCXN_HH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapReport_Delete_DeleteById_linhnx", obj);
        }

        public static XuatNhapReport Insert(XuatNhapReport item)
        {
            var Item = new XuatNhapReport();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("BCXN_HH_ID", item.HH_ID);
            obj[1] = new SqlParameter("BCXN_HH_Ten", item.HH_Ten);
            obj[2] = new SqlParameter("BCXN_HH_Ma", item.HH_Ma);
            obj[3] = new SqlParameter("BCXN_HH_DonVi", item.HH_DonVi);
            obj[4] = new SqlParameter("BCXN_DauKy_SoLuong", item.DauKy_SoLuong);
            obj[5] = new SqlParameter("BCXN_DauKy_Tien", item.DauKy_Tien);
            obj[6] = new SqlParameter("BCXN_Nhap_SoLuong", item.Nhap_SoLuong);
            obj[7] = new SqlParameter("BCXN_Nhap_Tien", item.Nhap_Tien);
            obj[8] = new SqlParameter("BCXN_Xuat_SoLuong", item.Xuat_SoLuong);
            obj[9] = new SqlParameter("BCXN_Xuat_Tien", item.Xuat_Tien);
            obj[10] = new SqlParameter("BCXN_CuoiKy_SoLuong", item.CuoiKy_SoLuong);
            obj[11] = new SqlParameter("BCXN_CuoiKy_Tien", item.CuoiKy_Tien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapReport_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XuatNhapReport Update(XuatNhapReport item)
        {
            var Item = new XuatNhapReport();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("BCXN_HH_ID", item.HH_ID);
            obj[1] = new SqlParameter("BCXN_HH_Ten", item.HH_Ten);
            obj[2] = new SqlParameter("BCXN_HH_Ma", item.HH_Ma);
            obj[3] = new SqlParameter("BCXN_HH_DonVi", item.HH_DonVi);
            obj[4] = new SqlParameter("BCXN_DauKy_SoLuong", item.DauKy_SoLuong);
            obj[5] = new SqlParameter("BCXN_DauKy_Tien", item.DauKy_Tien);
            obj[6] = new SqlParameter("BCXN_Nhap_SoLuong", item.Nhap_SoLuong);
            obj[7] = new SqlParameter("BCXN_Nhap_Tien", item.Nhap_Tien);
            obj[8] = new SqlParameter("BCXN_Xuat_SoLuong", item.Xuat_SoLuong);
            obj[9] = new SqlParameter("BCXN_Xuat_Tien", item.Xuat_Tien);
            obj[10] = new SqlParameter("BCXN_CuoiKy_SoLuong", item.CuoiKy_SoLuong);
            obj[11] = new SqlParameter("BCXN_CuoiKy_Tien", item.CuoiKy_Tien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapReport_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XuatNhapReport SelectById(Guid BCXN_HH_ID)
        {
            var Item = new XuatNhapReport();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BCXN_HH_ID", BCXN_HH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapReport_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XuatNhapReportCollection SelectAll()
        {
            var List = new XuatNhapReportCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapReport_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<XuatNhapReport> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<XuatNhapReport>("sp_tblXuatNhapReport_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static XuatNhapReport getFromReader(IDataReader rd)
        {
            var Item = new XuatNhapReport();
            if (rd.FieldExists("HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["HH_ID"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.HH_Ten = (String)(rd["HH_Ten"]);
            }
            if (rd.FieldExists("HH_Ma"))
            {
                Item.HH_Ma = (String)(rd["HH_Ma"]);
            }
            if (rd.FieldExists("HH_DonVi"))
            {
                Item.HH_DonVi = (String)(rd["HH_DonVi"]);
            }
            if (rd.FieldExists("DauKy_SoLuong"))
            {
                Item.DauKy_SoLuong = (Double)(rd["DauKy_SoLuong"]);
            }
            if (rd.FieldExists("DauKy_Tien"))
            {
                Item.DauKy_Tien = (Double)(rd["DauKy_Tien"]);
            }
            if (rd.FieldExists("Nhap_SoLuong"))
            {
                Item.Nhap_SoLuong = (Double)(rd["Nhap_SoLuong"]);
            }
            if (rd.FieldExists("Nhap_Tien"))
            {
                Item.Nhap_Tien = (Double)(rd["Nhap_Tien"]);
            }
            if (rd.FieldExists("Xuat_SoLuong"))
            {
                Item.Xuat_SoLuong = (Double)(rd["Xuat_SoLuong"]);
            }
            if (rd.FieldExists("Xuat_Tien"))
            {
                Item.Xuat_Tien = (Double)(rd["Xuat_Tien"]);
            }
            if (rd.FieldExists("CuoiKy_SoLuong"))
            {
                Item.CuoiKy_SoLuong = (Double)(rd["CuoiKy_SoLuong"]);
            }
            if (rd.FieldExists("CuoiKy_Tien"))
            {
                Item.CuoiKy_Tien = (Double)(rd["CuoiKy_Tien"]);
            }
            if (rd.FieldExists("HH_GiaNhap"))
            {
                Item.HH_GiaNhap = (Double)(rd["HH_GiaNhap"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static XuatNhapReportCollection baoCaoTuNgayDenNgayTheoKho(string TuNgay, string DenNgay, string KHO_ID, string DM_ID)
        {
            var List = new XuatNhapReportCollection();
            var obj = new SqlParameter[4];
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[0] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[0] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[1] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[1] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KHO_ID))
            {
                obj[2] = new SqlParameter("KHO_ID", KHO_ID);
            }
            else
            {
                obj[2] = new SqlParameter("KHO_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[3] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[3] = new SqlParameter("DM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhap_BaoCao_TonKho_TuNgayDenNgayKhoIdDmId_linhnx", obj))
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


