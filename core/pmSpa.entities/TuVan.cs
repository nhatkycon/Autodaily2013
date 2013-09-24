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
    #region TuVan
    #region BO
    public class TuVan : BaseEntity, BaseObject
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ma { get; set; }
        public String So { get; set; }
        public Guid KH_ID { get; set; }
        public String TuVanVien { get; set; }
        public DateTime Ngay { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public String TinhTrangSucKhoe { get; set; }
        public String TinhTrangLanDa { get; set; }
        public String GhiChu { get; set; }
        public String YKienKhachHang { get; set; }
        public Boolean HieuQua { get; set; }
        public Guid PDV_ID { get; set; }
        public Int32 TuVanVienDanhGia { get; set; }
        public Int32 KhongTheoDoi { get; set; }
        public String DichVuDieuTriKhac { get; set; }
        #endregion
        #region Contructor
        public TuVan()
        { }
        #endregion
        #region Customs properties
        public String TuVanVien_Ten { get; set; }
        public string KH_Ten { get; set; }
        public List<TuVanTinhTrang> _TuVanTinhTrang { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TuVanDal.getFromReader(rd);
        }

        public void del(string id)
        {
            TuVanDal.DeleteById(new Guid(id));
        }

        public BaseObject get(string id)
        {
            return TuVanDal.SelectById(new Guid(id));
        }
    }
    #endregion
    #region Collection
    public class TuVanCollection : BaseEntityCollection<TuVan>
    { }
    #endregion
    #region Dal
    public class TuVanDal
    {
        #region Methods

        public static void DeleteById(Guid TV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVan_Delete_DeleteById_linhnx", obj);
        }

        public static TuVan Insert(TuVan item)
        {
            var Item = new TuVan();
            var obj = new SqlParameter[19];
            obj[0] = new SqlParameter("TV_ID", item.ID);
            obj[1] = new SqlParameter("TV_Ma", item.Ma);
            obj[2] = new SqlParameter("TV_So", item.So);
            obj[3] = new SqlParameter("TV_KH_ID", item.KH_ID);
            obj[4] = new SqlParameter("TV_TuVanVien", item.TuVanVien);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("TV_Ngay", item.Ngay);
            }
            else
            {
                obj[5] = new SqlParameter("TV_Ngay", DBNull.Value);
            }
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("TV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("TV_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("TV_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("TV_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("TV_NguoiCapNhat", item.NguoiCapNhat);
            obj[10] = new SqlParameter("TV_TinhTrangSucKhoe", item.TinhTrangSucKhoe);
            obj[11] = new SqlParameter("TV_TinhTrangLanDa", item.TinhTrangLanDa);
            obj[12] = new SqlParameter("TV_GhiChu", item.GhiChu);
            obj[13] = new SqlParameter("TV_YKienKhachHang", item.YKienKhachHang);
            obj[14] = new SqlParameter("TV_HieuQua", item.HieuQua);
            obj[15] = new SqlParameter("TV_PDV_ID", item.PDV_ID);
            obj[16] = new SqlParameter("TV_TuVanVienDanhGia", item.TuVanVienDanhGia);
            obj[17] = new SqlParameter("TV_KhongTheoDoi", item.KhongTheoDoi);
            obj[18] = new SqlParameter("TV_DichVuDieuTriKhac", item.DichVuDieuTriKhac);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVan Update(TuVan item)
        {
            var Item = new TuVan();
            var obj = new SqlParameter[19];
            obj[0] = new SqlParameter("TV_ID", item.ID);
            obj[1] = new SqlParameter("TV_Ma", item.Ma);
            obj[2] = new SqlParameter("TV_So", item.So);
            obj[3] = new SqlParameter("TV_KH_ID", item.KH_ID);
            obj[4] = new SqlParameter("TV_TuVanVien", item.TuVanVien);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("TV_Ngay", item.Ngay);
            }
            else
            {
                obj[5] = new SqlParameter("TV_Ngay", DBNull.Value);
            }
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("TV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("TV_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("TV_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("TV_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("TV_NguoiCapNhat", item.NguoiCapNhat);
            obj[10] = new SqlParameter("TV_TinhTrangSucKhoe", item.TinhTrangSucKhoe);
            obj[11] = new SqlParameter("TV_TinhTrangLanDa", item.TinhTrangLanDa);
            obj[12] = new SqlParameter("TV_GhiChu", item.GhiChu);
            obj[13] = new SqlParameter("TV_YKienKhachHang", item.YKienKhachHang);
            obj[14] = new SqlParameter("TV_HieuQua", item.HieuQua);
            obj[15] = new SqlParameter("TV_PDV_ID", item.PDV_ID);
            obj[16] = new SqlParameter("TV_TuVanVienDanhGia", item.TuVanVienDanhGia);
            obj[17] = new SqlParameter("TV_KhongTheoDoi", item.KhongTheoDoi);
            obj[18] = new SqlParameter("TV_DichVuDieuTriKhac", item.DichVuDieuTriKhac);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TuVan SelectById(SqlConnection con, Guid TV_ID)
        {
            var Item = new TuVan();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_TuVan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TuVan SelectById(Guid TV_ID)
        {
            var Item = new TuVan();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanCollection SelectAll()
        {
            var List = new TuVanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TuVan> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            return pagerNormal(url, rewrite, sort, q, size, null);
        }
        public static Pager<TuVan> pagerNormal(string url, bool rewrite, string sort, string q, int size, string KH_ID)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KH_ID))
            {
                obj[2] = new SqlParameter("KH_ID", KH_ID);
            }
            else
            {
                obj[2] = new SqlParameter("KH_ID", DBNull.Value);
            }
            var pg = new Pager<TuVan>("sp_tblSpaMgr_TuVan_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TuVan getFromReader(IDataReader rd)
        {
            var Item = new TuVan();
            if (rd.FieldExists("TV_ID"))
            {
                Item.ID = (Guid)(rd["TV_ID"]);
            }
            if (rd.FieldExists("TV_Ma"))
            {
                Item.Ma = (String)(rd["TV_Ma"]);
            }
            if (rd.FieldExists("TV_So"))
            {
                Item.So = (String)(rd["TV_So"]);
            }
            if (rd.FieldExists("TV_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["TV_KH_ID"]);
            }
            if (rd.FieldExists("TV_TuVanVien"))
            {
                Item.TuVanVien = (String)(rd["TV_TuVanVien"]);
            }
            if (rd.FieldExists("TV_Ngay"))
            {
                Item.Ngay = (DateTime)(rd["TV_Ngay"]);
            }
            if (rd.FieldExists("TV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TV_NgayTao"]);
            }
            if (rd.FieldExists("TV_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TV_NguoiTao"]);
            }
            if (rd.FieldExists("TV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TV_NgayCapNhat"]);
            }
            if (rd.FieldExists("TV_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TV_NguoiCapNhat"]);
            }
            if (rd.FieldExists("TV_TinhTrangSucKhoe"))
            {
                Item.TinhTrangSucKhoe = (String)(rd["TV_TinhTrangSucKhoe"]);
            }
            if (rd.FieldExists("TV_TinhTrangLanDa"))
            {
                Item.TinhTrangLanDa = (String)(rd["TV_TinhTrangLanDa"]);
            }
            if (rd.FieldExists("TV_GhiChu"))
            {
                Item.GhiChu = (String)(rd["TV_GhiChu"]);
            }
            if (rd.FieldExists("TV_YKienKhachHang"))
            {
                Item.YKienKhachHang = (String)(rd["TV_YKienKhachHang"]);
            }
            if (rd.FieldExists("TV_HieuQua"))
            {
                Item.HieuQua = (Boolean)(rd["TV_HieuQua"]);
            }
            if (rd.FieldExists("TV_PDV_ID"))
            {
                Item.PDV_ID = (Guid)(rd["TV_PDV_ID"]);
            }
            if (rd.FieldExists("TV_TuVanVienDanhGia"))
            {
                Item.TuVanVienDanhGia = (Int32)(rd["TV_TuVanVienDanhGia"]);
            }
            if (rd.FieldExists("TV_KhongTheoDoi"))
            {
                Item.KhongTheoDoi = (Int32)(rd["TV_KhongTheoDoi"]);
            }
            if (rd.FieldExists("TV_DichVuDieuTriKhac"))
            {
                Item.DichVuDieuTriKhac = (String)(rd["TV_DichVuDieuTriKhac"]);
            }
            if (rd.FieldExists("TV_TuVanVien_Ten"))
            {
                Item.TuVanVien_Ten = (String)(rd["TV_TuVanVien_Ten"]);
            }
            if (rd.FieldExists("TV_KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["TV_KH_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static TuVan SelectDraff(SqlConnection con)
        {
            var Item = new TuVan();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_TuVan_Select_SelectDraff_linhnx"))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TuVanCollection SelectByKhId(SqlConnection con, string KH_ID)
        {
            var List = new TuVanCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVan_Select_SelectByKhId_linhnx", obj))
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
