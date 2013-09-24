using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core;
using linh.core.dal;

namespace pmSpa.entities
{
    #region TuVanDichVu
    #region BO
    public class TuVanDichVu : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid TV_ID { get; set; }
        public Guid DV_ID { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public Double Gia { get; set; }
        public String GhiChu { get; set; }
        public Int32 SoLan { get; set; }
        public Double ThanhToan { get; set; }
        public Double ConNo { get; set; }
        public DateTime NgayLap { get; set; }
        public Guid BaoHanh_ID { get; set; }
        public Guid KHO_ID { get; set; }
        public Double CK { get; set; }
        public String NhanVien { get; set; }
        #endregion
        #region Contructor
        public TuVanDichVu()
        { }
        #endregion
        #region Customs properties
        public String BaoHanh_Ten { get; set; }
        public String NhanVien_Ten { get; set; }
        public String KHO_Ten { get; set; }
        public DichVu _DichVu { get; set; }
        public TuVan _TuVan { get; set; }
        public KhachHang _KhachHang { get; set; }

        public Int32 Loai { get; set; }
        public Int32 LoaiQuy { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TuVanDichVuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TuVanDichVuCollection : BaseEntityCollection<TuVanDichVu>
    { }
    #endregion
    #region Dal
    public class TuVanDichVuDal
    {
        #region Methods

        public static void DeleteById(Guid TVDV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TVDV_ID", TVDV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanDichVu_Delete_DeleteById_linhnx", obj);
        }

        public static TuVanDichVu Insert(TuVanDichVu item)
        {
            var Item = new TuVanDichVu();
            var obj = new SqlParameter[15];
            obj[0] = new SqlParameter("TVDV_ID", item.ID);
            obj[1] = new SqlParameter("TVDV_TV_ID", item.TV_ID);
            obj[2] = new SqlParameter("TVDV_DV_ID", item.DV_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("TVDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("TVDV_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("TVDV_NguoiTao", item.NguoiTao);
            obj[5] = new SqlParameter("TVDV_Gia", item.Gia);
            obj[6] = new SqlParameter("TVDV_GhiChu", item.GhiChu);
            obj[7] = new SqlParameter("TVDV_SoLan", item.SoLan);
            obj[8] = new SqlParameter("TVDV_ThanhToan", item.ThanhToan);
            obj[9] = new SqlParameter("TVDV_ConNo", item.ConNo);
            if (item.NgayLap > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("TVDV_NgayLap", item.NgayLap);
            }
            else
            {
                obj[10] = new SqlParameter("TVDV_NgayLap", DBNull.Value);
            }
            obj[11] = new SqlParameter("TVDV_BaoHanh_ID", item.BaoHanh_ID);
            obj[12] = new SqlParameter("TVDV_KHO_ID", item.KHO_ID);
            obj[13] = new SqlParameter("TVDV_CK", item.CK);
            obj[14] = new SqlParameter("TVDV_NhanVien", item.NhanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanDichVu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanDichVu Update(TuVanDichVu item)
        {
            var Item = new TuVanDichVu();
            var obj = new SqlParameter[15];
            obj[0] = new SqlParameter("TVDV_ID", item.ID);
            obj[1] = new SqlParameter("TVDV_TV_ID", item.TV_ID);
            obj[2] = new SqlParameter("TVDV_DV_ID", item.DV_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("TVDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("TVDV_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("TVDV_NguoiTao", item.NguoiTao);
            obj[5] = new SqlParameter("TVDV_Gia", item.Gia);
            obj[6] = new SqlParameter("TVDV_GhiChu", item.GhiChu);
            obj[7] = new SqlParameter("TVDV_SoLan", item.SoLan);
            obj[8] = new SqlParameter("TVDV_ThanhToan", item.ThanhToan);
            obj[9] = new SqlParameter("TVDV_ConNo", item.ConNo);
            if (item.NgayLap > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("TVDV_NgayLap", item.NgayLap);
            }
            else
            {
                obj[10] = new SqlParameter("TVDV_NgayLap", DBNull.Value);
            }
            obj[11] = new SqlParameter("TVDV_BaoHanh_ID", item.BaoHanh_ID);
            obj[12] = new SqlParameter("TVDV_KHO_ID", item.KHO_ID);
            obj[13] = new SqlParameter("TVDV_CK", item.CK);
            obj[14] = new SqlParameter("TVDV_NhanVien", item.NhanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanDichVu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanDichVu SelectById(Guid TVDV_ID)
        {
            var Item = new TuVanDichVu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TVDV_ID", TVDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanDichVu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanDichVuCollection SelectAll()
        {
            var List = new TuVanDichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanDichVu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TuVanDichVu> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<TuVanDichVu>("sp_tblSpaMgr_TuVanDichVu_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TuVanDichVu SelectById(SqlConnection con, Guid TVDV_ID)
        {
            var Item = new TuVanDichVu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TVDV_ID", TVDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanDichVu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TuVanDichVu getFromReader(IDataReader rd)
        {
            var Item = new TuVanDichVu();
            if (rd.FieldExists("TVDV_ID"))
            {
                Item.ID = (Guid)(rd["TVDV_ID"]);
            }
            if (rd.FieldExists("TVDV_TV_ID"))
            {
                Item.TV_ID = (Guid)(rd["TVDV_TV_ID"]);
            }
            if (rd.FieldExists("TVDV_DV_ID"))
            {
                Item.DV_ID = (Guid)(rd["TVDV_DV_ID"]);
            }
            if (rd.FieldExists("TVDV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TVDV_NgayTao"]);
            }
            if (rd.FieldExists("TVDV_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TVDV_NguoiTao"]);
            }
            if (rd.FieldExists("TVDV_Gia"))
            {
                Item.Gia = (Double)(rd["TVDV_Gia"]);
            }
            if (rd.FieldExists("TVDV_GhiChu"))
            {
                Item.GhiChu = (String)(rd["TVDV_GhiChu"]);
            }
            if (rd.FieldExists("TVDV_SoLan"))
            {
                Item.SoLan = (Int32)(rd["TVDV_SoLan"]);
            }
            if (rd.FieldExists("TVDV_ThanhToan"))
            {
                Item.ThanhToan = (Double)(rd["TVDV_ThanhToan"]);
            }
            if (rd.FieldExists("TVDV_ConNo"))
            {
                Item.ConNo = (Double)(rd["TVDV_ConNo"]);
            }
            if (rd.FieldExists("TVDV_NgayLap"))
            {
                Item.NgayLap = (DateTime)(rd["TVDV_NgayLap"]);
            }
            if (rd.FieldExists("TVDV_BaoHanh_ID"))
            {
                Item.BaoHanh_ID = (Guid)(rd["TVDV_BaoHanh_ID"]);
            }
            if (rd.FieldExists("BaoHanh_Ten"))
            {
                Item.BaoHanh_Ten = (String)(rd["BaoHanh_Ten"]);
            }
            if (rd.FieldExists("KHO_Ten"))
            {
                Item.KHO_Ten = (String)(rd["KHO_Ten"]);
            }
            if (rd.FieldExists("TVDV_KHO_ID"))
            {
                Item.KHO_ID = (Guid)(rd["TVDV_KHO_ID"]);
            }
            if (rd.FieldExists("TVDV_CK"))
            {
                Item.CK = (Double)(rd["TVDV_CK"]);
            }
            if (rd.FieldExists("TVDV_NhanVien"))
            {
                Item.NhanVien = (String)(rd["TVDV_NhanVien"]);
            }
            if (rd.FieldExists("TVDV_NhanVien_Ten"))
            {
                Item.NhanVien_Ten = (String)(rd["TVDV_NhanVien_Ten"]);
            }
            if (rd.FieldExists("TVDV_Loai"))
            {
                Item.Loai = (Int32)(rd["TVDV_Loai"]);
            }
            if (rd.FieldExists("TVDV_LoaiQuy"))
            {
                Item.LoaiQuy = (Int32)(rd["TVDV_LoaiQuy"]);
            }
            Item._KhachHang = KhachHangDal.getFromReader(rd);
            Item._DichVu = DichVuDal.getFromReader(rd);
            Item._TuVan = TuVanDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteByTvIdVaTtId(string DV_ID, string TV_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DV_ID", DV_ID);
            obj[1] = new SqlParameter("TV_ID", TV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanTinhTrang_Delete_DeleteByTvIdVaTtIdlinhnx", obj);
        }
        public static TuVanDichVuCollection SelectByTvId(SqlConnection con, string TV_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            var List = new TuVanDichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanDichVu_Select_SelectByTvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TuVanDichVuCollection BaoCaoDoanhSoTuNgayDenNgay(SqlConnection con, string TuNgay, string DenNgay, string KH_ID)
        {
            var obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[1] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[2] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[2] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KH_ID))
            {
                obj[0] = new SqlParameter("KH_ID", KH_ID);
            }
            else
            {
                obj[0] = new SqlParameter("KH_ID", DBNull.Value);
            }
            var List = new TuVanDichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblThuChi_Select_baoCaoDoanhSo_linhnx", obj))
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
