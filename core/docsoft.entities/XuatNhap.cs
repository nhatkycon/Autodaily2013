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
    #region XuatNhap
    #region BO
    public class XuatNhap : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid GH_ID { get; set; }
        public Guid LOAI_ID { get; set; }
        public String Ma { get; set; }
        public Guid KH_ID { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public String NhanVien { get; set; }
        public Double CongTienHang { get; set; }
        public String DienGiai { get; set; }
        public Double VAT { get; set; }
        public Double ThanhToan { get; set; }
        public Double ConNo { get; set; }
        public Double ChietKhau { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public String GhiChu { get; set; }
        public Guid KHO_ID { get; set; }
        public Boolean Xuat { get; set; }
        public Guid TVDV_ID { get; set; }
        public Boolean DauKy { get; set; }
        public Boolean NoiBo { get; set; }
        public Boolean ChuyenDoi { get; set; }
        public String TuVanVien { get; set; }
        #endregion
        #region Contructor
        public XuatNhap()
        { }
        #endregion
        #region Customs properties
        public string KH_Ten { get; set; }
        public string LOAI_Ten { get; set; }
        public string KHO_Ten { get; set; }
        public List<XuatNhapChiTiet> XNCT { get; set; }
        public ThuChi _ThuChi { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return XuatNhapDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class XuatNhapCollection : BaseEntityCollection<XuatNhap>
    { }
    #endregion
    #region Dal
    public class XuatNhapDal
    {
        #region Methods

        public static void DeleteById(Guid XN_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XN_ID", XN_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhap_Delete_DeleteById_linhnx", obj);
        }

        public static XuatNhap Insert(XuatNhap item)
        {
            var Item = new XuatNhap();
            var obj = new SqlParameter[25];
            obj[0] = new SqlParameter("XN_ID", item.ID);
            obj[1] = new SqlParameter("XN_GH_ID", item.GH_ID);
            obj[2] = new SqlParameter("XN_LOAI_ID", item.LOAI_ID);
            obj[3] = new SqlParameter("XN_Ma", item.Ma);
            obj[4] = new SqlParameter("XN_KH_ID", item.KH_ID);
            if (item.NgayHoaDon > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("XN_NgayHoaDon", item.NgayHoaDon);
            }
            else
            {
                obj[5] = new SqlParameter("XN_NgayHoaDon", DBNull.Value);
            }
            obj[6] = new SqlParameter("XN_NhanVien", item.NhanVien);
            obj[7] = new SqlParameter("XN_CongTienHang", item.CongTienHang);
            obj[8] = new SqlParameter("XN_DienGiai", item.DienGiai);
            obj[9] = new SqlParameter("XN_VAT", item.VAT);
            obj[10] = new SqlParameter("XN_ThanhToan", item.ThanhToan);
            obj[11] = new SqlParameter("XN_ConNo", item.ConNo);
            obj[12] = new SqlParameter("XN_ChietKhau", item.ChietKhau);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("XN_NgayTao", item.NgayTao);
            }
            else
            {
                obj[13] = new SqlParameter("XN_NgayTao", DBNull.Value);
            }
            obj[14] = new SqlParameter("XN_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("XN_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[15] = new SqlParameter("XN_NgayCapNhat", DBNull.Value);
            }
            obj[16] = new SqlParameter("XN_NguoiCapNhat", item.NguoiCapNhat);
            obj[17] = new SqlParameter("XN_GhiChu", item.GhiChu);
            obj[18] = new SqlParameter("XN_KHO_ID", item.KHO_ID);
            obj[19] = new SqlParameter("XN_Xuat", item.Xuat);
            obj[20] = new SqlParameter("XN_TVDV_ID", item.TVDV_ID);
            obj[21] = new SqlParameter("XN_DauKy", item.DauKy);
            obj[22] = new SqlParameter("XN_NoiBo", item.NoiBo);
            obj[23] = new SqlParameter("XN_ChuyenDoi", item.ChuyenDoi);
            obj[24] = new SqlParameter("XN_TuVanVien", item.TuVanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhap_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XuatNhap Update(XuatNhap item)
        {
            var Item = new XuatNhap();
            var obj = new SqlParameter[25];
            obj[0] = new SqlParameter("XN_ID", item.ID);
            obj[1] = new SqlParameter("XN_GH_ID", item.GH_ID);
            obj[2] = new SqlParameter("XN_LOAI_ID", item.LOAI_ID);
            obj[3] = new SqlParameter("XN_Ma", item.Ma);
            obj[4] = new SqlParameter("XN_KH_ID", item.KH_ID);
            if (item.NgayHoaDon > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("XN_NgayHoaDon", item.NgayHoaDon);
            }
            else
            {
                obj[5] = new SqlParameter("XN_NgayHoaDon", DBNull.Value);
            }
            obj[6] = new SqlParameter("XN_NhanVien", item.NhanVien);
            obj[7] = new SqlParameter("XN_CongTienHang", item.CongTienHang);
            obj[8] = new SqlParameter("XN_DienGiai", item.DienGiai);
            obj[9] = new SqlParameter("XN_VAT", item.VAT);
            obj[10] = new SqlParameter("XN_ThanhToan", item.ThanhToan);
            obj[11] = new SqlParameter("XN_ConNo", item.ConNo);
            obj[12] = new SqlParameter("XN_ChietKhau", item.ChietKhau);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("XN_NgayTao", item.NgayTao);
            }
            else
            {
                obj[13] = new SqlParameter("XN_NgayTao", DBNull.Value);
            }
            obj[14] = new SqlParameter("XN_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("XN_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[15] = new SqlParameter("XN_NgayCapNhat", DBNull.Value);
            }
            obj[16] = new SqlParameter("XN_NguoiCapNhat", item.NguoiCapNhat);
            obj[17] = new SqlParameter("XN_GhiChu", item.GhiChu);
            obj[18] = new SqlParameter("XN_KHO_ID", item.KHO_ID);
            obj[19] = new SqlParameter("XN_Xuat", item.Xuat);
            obj[20] = new SqlParameter("XN_TVDV_ID", item.TVDV_ID);
            obj[21] = new SqlParameter("XN_DauKy", item.DauKy);
            obj[22] = new SqlParameter("XN_NoiBo", item.NoiBo);
            obj[23] = new SqlParameter("XN_ChuyenDoi", item.ChuyenDoi);
            obj[24] = new SqlParameter("XN_TuVanVien", item.TuVanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhap_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
                

        public static XuatNhap SelectById(Guid XN_ID)
        {
            var Item = new XuatNhap();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("XN_ID", XN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhap_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static XuatNhapCollection SelectAll()
        {
            var List = new XuatNhapCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhap_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<XuatNhap> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<XuatNhap>("sp_tblXuatNhap_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static XuatNhap getFromReader(IDataReader rd)
        {
            var Item = new XuatNhap();
            if (rd.FieldExists("XN_ID"))
            {
                Item.ID = (Guid)(rd["XN_ID"]);
            }
            if (rd.FieldExists("XN_GH_ID"))
            {
                Item.GH_ID = (Guid)(rd["XN_GH_ID"]);
            }
            if (rd.FieldExists("XN_LOAI_ID"))
            {
                Item.LOAI_ID = (Guid)(rd["XN_LOAI_ID"]);
            }
            if (rd.FieldExists("XN_Ma"))
            {
                Item.Ma = (String)(rd["XN_Ma"]);
            }
            if (rd.FieldExists("XN_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["XN_KH_ID"]);
            }
            if (rd.FieldExists("XN_NgayHoaDon"))
            {
                Item.NgayHoaDon = (DateTime)(rd["XN_NgayHoaDon"]);
            }
            if (rd.FieldExists("XN_NhanVien"))
            {
                Item.NhanVien = (String)(rd["XN_NhanVien"]);
            }
            if (rd.FieldExists("XN_CongTienHang"))
            {
                Item.CongTienHang = (Double)(rd["XN_CongTienHang"]);
            }
            if (rd.FieldExists("XN_DienGiai"))
            {
                Item.DienGiai = (String)(rd["XN_DienGiai"]);
            }
            if (rd.FieldExists("XN_VAT"))
            {
                Item.VAT = (Double)(rd["XN_VAT"]);
            }
            if (rd.FieldExists("XN_ThanhToan"))
            {
                Item.ThanhToan = (Double)(rd["XN_ThanhToan"]);
            }
            if (rd.FieldExists("XN_ConNo"))
            {
                Item.ConNo = (Double)(rd["XN_ConNo"]);
            }
            if (rd.FieldExists("XN_ChietKhau"))
            {
                Item.ChietKhau = (Double)(rd["XN_ChietKhau"]);
            }
            if (rd.FieldExists("XN_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["XN_NgayTao"]);
            }
            if (rd.FieldExists("XN_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["XN_NguoiTao"]);
            }
            if (rd.FieldExists("XN_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["XN_NgayCapNhat"]);
            }
            if (rd.FieldExists("XN_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["XN_NguoiCapNhat"]);
            }
            if (rd.FieldExists("XN_GhiChu"))
            {
                Item.GhiChu = (String)(rd["XN_GhiChu"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["KH_Ten"]);
            }

            if (rd.FieldExists("LOAI_Ten"))
            {
                Item.LOAI_Ten = (String)(rd["LOAI_Ten"]);
            }
            if (rd.FieldExists("XN_KHO_ID"))
            {
                Item.KHO_ID = (Guid)(rd["XN_KHO_ID"]);
            }
            if (rd.FieldExists("XN_KHO_Ten"))
            {
                Item.KHO_Ten = (String)(rd["XN_KHO_Ten"]);
            }
            if (rd.FieldExists("XN_Xuat"))
            {
                Item.Xuat = (Boolean)(rd["XN_Xuat"]);
            }
            if (rd.FieldExists("XN_TV_ID"))
            {
                Item.TVDV_ID = (Guid)(rd["XN_TVDV_ID"]);
            }
            if (rd.FieldExists("XN_DauKy"))
            {
                Item.DauKy = (Boolean)(rd["XN_DauKy"]);
            }
            if (rd.FieldExists("XN_NoiBo"))
            {
                Item.NoiBo = (Boolean)(rd["XN_NoiBo"]);
            }
            if (rd.FieldExists("XN_ChuyenDoi"))
            {
                Item.ChuyenDoi = (Boolean)(rd["XN_ChuyenDoi"]);
            }
            if (rd.FieldExists("XN_TuVanVien"))
            {
                Item.TuVanVien = (String)(rd["XN_TuVanVien"]);
            }
            Item._ThuChi = ThuChiDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<XuatNhap> pagerXuatNhap(string xuat, string DauKy, string NoiBo, string ChuyenDoi, string KH_ID, string sort, string q, int size)
        {
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(xuat))
            {
                obj[2] = new SqlParameter("Xuat", xuat);
            }
            else
            {
                obj[2] = new SqlParameter("Xuat", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DauKy))
            {
                obj[3] = new SqlParameter("DauKy", DauKy);
            }
            else
            {
                obj[3] = new SqlParameter("DauKy", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NoiBo))
            {
                obj[4] = new SqlParameter("NoiBo", NoiBo);
            }
            else
            {
                obj[4] = new SqlParameter("NoiBo", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(ChuyenDoi))
            {
                obj[5] = new SqlParameter("ChuyenDoi", ChuyenDoi);
            }
            else
            {
                obj[5] = new SqlParameter("ChuyenDoi", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KH_ID))
            {
                obj[6] = new SqlParameter("KH_ID", KH_ID);
            }
            else
            {
                obj[6] = new SqlParameter("KH_ID", DBNull.Value);
            }
            var pg = new Pager<XuatNhap>("sp_tblXuatNhap_Pager_XuatNhap_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static XuatNhap SelectByDraff(SqlConnection con)
        {
            var Item = new XuatNhap();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Select_SelectDraff_linhnx"))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static XuatNhap SelectByDraff(bool xuat)
        {
            var Item = new XuatNhap();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Xuat", xuat);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhapChiTiet_Select_SelectDraff_linhnx" , obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }


        public static XuatNhap SelectTvDv(Guid TVDV_ID)
        {
            var Item = new XuatNhap();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TVDV_ID", TVDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblXuatNhap_Select_SelectByTvDvId_linhnx", obj))
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
