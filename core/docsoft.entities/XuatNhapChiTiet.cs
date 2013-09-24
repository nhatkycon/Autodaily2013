using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using linh.controls;

namespace docsoft.entities
{
    #region XuatNhapChiTiet
    #region BO
    public class XuatNhapChiTiet : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid XN_ID { get; set; }
        public Guid HH_ID { get; set; }
        public Guid DV_ID { get; set; }
        public Double SoLuong { get; set; }
        public Double DonGia { get; set; }
        public Double Tong { get; set; }
        public Double VAT { get; set; }
        public Double CKTyLe { get; set; }
        public Double CKTien { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public String GhiChu { get; set; }
        public Boolean Draff { get; set; }
        public DateTime DraffDate { get; set; }
        public Guid KH_ID { get; set; }
        #endregion
        #region Contructor
        public XuatNhapChiTiet()
        { }
        #endregion
        #region Customs properties
        public string HH_Ten { get; set; }
        public string HH_Ma { get; set; }
        public string DV_Ten { get; set; }
        public string KH_Ten { get; set; }
        public HangHoa _HangHoa { get; set; }
        public XuatNhap _XuatNhap { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return XuatNhapChiTietDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class XuatNhapChiTietCollection : BaseEntityCollection<XuatNhapChiTiet>
    { }
    #endregion
    #region Dal
    public class XuatNhapChiTietDal
    {
        #region Methods

        public static void DeleteById(Guid XNCT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XNCT_ID", XNCT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Delete_DeleteById_linhnx", obj);
        }

        public static XuatNhapChiTiet Insert(XuatNhapChiTiet item)
        {
            var Item = new XuatNhapChiTiet();
            var obj = new SqlParameter[18];
            obj[0] = new SqlParameter("XNCT_ID", item.ID);
            obj[1] = new SqlParameter("XNCT_XN_ID", item.XN_ID);
            obj[2] = new SqlParameter("XNCT_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("XNCT_DV_ID", item.DV_ID);
            obj[4] = new SqlParameter("XNCT_SoLuong", item.SoLuong);
            obj[5] = new SqlParameter("XNCT_DonGia", item.DonGia);
            obj[6] = new SqlParameter("XNCT_Tong", item.Tong);
            obj[7] = new SqlParameter("XNCT_VAT", item.VAT);
            obj[8] = new SqlParameter("XNCT_CKTyLe", item.CKTyLe);
            obj[9] = new SqlParameter("XNCT_CKTien", item.CKTien);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("XNCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("XNCT_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("XNCT_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("XNCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("XNCT_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("XNCT_NguoiCapNhat", item.NguoiCapNhat);
            obj[14] = new SqlParameter("XNCT_GhiChu", item.GhiChu);
            obj[15] = new SqlParameter("XNCT_Draff", item.Draff);
            if (item.DraffDate > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("XNCT_DraffDate", item.DraffDate);
            }
            else
            {
                obj[16] = new SqlParameter("XNCT_DraffDate", DBNull.Value);
            }
            obj[17] = new SqlParameter("XNCT_KH_ID", item.KH_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XuatNhapChiTiet Update(XuatNhapChiTiet item)
        {
            var Item = new XuatNhapChiTiet();
            var obj = new SqlParameter[18];
            obj[0] = new SqlParameter("XNCT_ID", item.ID);
            obj[1] = new SqlParameter("XNCT_XN_ID", item.XN_ID);
            obj[2] = new SqlParameter("XNCT_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("XNCT_DV_ID", item.DV_ID);
            obj[4] = new SqlParameter("XNCT_SoLuong", item.SoLuong);
            obj[5] = new SqlParameter("XNCT_DonGia", item.DonGia);
            obj[6] = new SqlParameter("XNCT_Tong", item.Tong);
            obj[7] = new SqlParameter("XNCT_VAT", item.VAT);
            obj[8] = new SqlParameter("XNCT_CKTyLe", item.CKTyLe);
            obj[9] = new SqlParameter("XNCT_CKTien", item.CKTien);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("XNCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("XNCT_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("XNCT_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("XNCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("XNCT_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("XNCT_NguoiCapNhat", item.NguoiCapNhat);
            obj[14] = new SqlParameter("XNCT_GhiChu", item.GhiChu);
            obj[15] = new SqlParameter("XNCT_Draff", item.Draff);
            if (item.DraffDate > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("XNCT_DraffDate", item.DraffDate);
            }
            else
            {
                obj[16] = new SqlParameter("XNCT_DraffDate", DBNull.Value);
            }
            obj[17] = new SqlParameter("XNCT_KH_ID", item.KH_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XuatNhapChiTiet SelectById(Guid XNCT_ID)
        {
            var Item = new XuatNhapChiTiet();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XNCT_ID", XNCT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XuatNhapChiTietCollection SelectAll()
        {
            var List = new XuatNhapChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<XuatNhapChiTiet> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<XuatNhapChiTiet>("sp_tblXuatNhapChiTiet_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static XuatNhapChiTiet getFromReader(IDataReader rd)
        {
            var Item = new XuatNhapChiTiet();
            if (rd.FieldExists("XNCT_ID"))
            {
                Item.ID = (Guid)(rd["XNCT_ID"]);
            }
            if (rd.FieldExists("XNCT_XN_ID"))
            {
                Item.XN_ID = (Guid)(rd["XNCT_XN_ID"]);
            }
            if (rd.FieldExists("XNCT_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["XNCT_HH_ID"]);
            }
            if (rd.FieldExists("XNCT_DV_ID"))
            {
                Item.DV_ID = (Guid)(rd["XNCT_DV_ID"]);
            }
            if (rd.FieldExists("XNCT_SoLuong"))
            {
                Item.SoLuong = (Double)(rd["XNCT_SoLuong"]);
            }
            if (rd.FieldExists("XNCT_DonGia"))
            {
                Item.DonGia = (Double)(rd["XNCT_DonGia"]);
            }
            if (rd.FieldExists("XNCT_Tong"))
            {
                Item.Tong = (Double)(rd["XNCT_Tong"]);
            }
            if (rd.FieldExists("XNCT_VAT"))
            {
                Item.VAT = (Double)(rd["XNCT_VAT"]);
            }
            if (rd.FieldExists("XNCT_CKTyLe"))
            {
                Item.CKTyLe = (Double)(rd["XNCT_CKTyLe"]);
            }
            if (rd.FieldExists("XNCT_CKTien"))
            {
                Item.CKTien = (Double)(rd["XNCT_CKTien"]);
            }
            if (rd.FieldExists("XNCT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["XNCT_NgayTao"]);
            }
            if (rd.FieldExists("XNCT_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["XNCT_NguoiTao"]);
            }
            if (rd.FieldExists("XNCT_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["XNCT_NgayCapNhat"]);
            }
            if (rd.FieldExists("XNCT_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["XNCT_NguoiCapNhat"]);
            }
            if (rd.FieldExists("XNCT_GhiChu"))
            {
                Item.GhiChu = (String)(rd["XNCT_GhiChu"]);
            }
            if (rd.FieldExists("XNCT_Draff"))
            {
                Item.Draff = (Boolean)(rd["XNCT_Draff"]);
            }
            if (rd.FieldExists("XNCT_DraffDate"))
            {
                Item.DraffDate = (DateTime)(rd["XNCT_DraffDate"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.HH_Ten = (String)(rd["HH_Ten"]);
            }
            if (rd.FieldExists("DV_Ten"))
            {
                Item.DV_Ten = (String)(rd["DV_Ten"]);
            }
            if (rd.FieldExists("XNCT_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["XNCT_KH_ID"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["KH_Ten"]);
            }
            if (rd.FieldExists("HH_Ma"))
            {
                Item.HH_Ma = (String)(rd["HH_Ma"]);
            }
            Item._XuatNhap = XuatNhapDal.getFromReader(rd);
            Item._HangHoa = HangHoaDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static XuatNhapChiTietCollection SelectByXN_ID(string XN_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XN_ID", XN_ID);
            var List = new XuatNhapChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Select_SelectByXN_ID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static XuatNhapChiTietCollection SelectByTV_ID(string TV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            var List = new XuatNhapChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Select_SelectByTV_ID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static void DeleteByXnId(Guid XN_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XN_ID", XN_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Delete_DeleteByXnId_linhnx", obj);
        }
        public static Pager<XuatNhapChiTiet> pagerTuNgayDenNgayKhoIdDmId(string url, bool rewrite, string sort, string q, int size, string TuNgay, string DenNgay, string KHO_ID,string DM_ID, string KH_ID)
        {
            var obj = new SqlParameter[7];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
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
            if (!string.IsNullOrEmpty(KHO_ID))
            {
                obj[4] = new SqlParameter("KHO_ID", KHO_ID);
            }
            else
            {
                obj[4] = new SqlParameter("KHO_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[5] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[5] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KH_ID))
            {
                obj[6] = new SqlParameter("KH_ID", KH_ID);
            }
            else
            {
                obj[6] = new SqlParameter("KH_ID", DBNull.Value);
            }
            var pg = new Pager<XuatNhapChiTiet>("sp_tblXuatNhapChiTiet_Select_TuNgayDenNgayKhoIdDmId_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
}
