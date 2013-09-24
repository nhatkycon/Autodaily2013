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
    #region HangHoa
    #region BO
    public class HangHoa : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid DM_ID { get; set; }
        public String Ma { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public String CongDung { get; set; }
        public String CachDung { get; set; }
        public String CacBuoc { get; set; }
        public Guid DV_ID { get; set; }
        public Int32 GiaNhap { get; set; }
        public Int32 GiaXuat { get; set; }
        public Int32 TonDinhMuc { get; set; }
        public String Anh { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean Active { get; set; }
        public Boolean KhuyenMai { get; set; }
        public Boolean DuaLenWeb { get; set; }
        public Int32 SoLuongHienTai { get; set; }
        public Boolean HetHang { get; set; }
        #endregion
        #region Contructor
        public HangHoa()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return HangHoaDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class HangHoaCollection : BaseEntityCollection<HangHoa>
    { }
    #endregion
    #region Dal
    public class HangHoaDal
    {
        #region Methods

        public static void DeleteById(Guid HH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_HangHoa_Delete_DeleteById_linhnx", obj);
        }

        public static HangHoa Insert(HangHoa item)
        {
            var Item = new HangHoa();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("HH_ID", item.ID);
            obj[1] = new SqlParameter("HH_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("HH_Ma", item.Ma);
            obj[3] = new SqlParameter("HH_MoTa", item.MoTa);
            obj[4] = new SqlParameter("HH_NoiDung", item.NoiDung);
            obj[5] = new SqlParameter("HH_CongDung", item.CongDung);
            obj[6] = new SqlParameter("HH_CachDung", item.CachDung);
            obj[7] = new SqlParameter("HH_CacBuoc", item.CacBuoc);
            obj[8] = new SqlParameter("HH_DV_ID", item.DV_ID);
            obj[9] = new SqlParameter("HH_GiaNhap", item.GiaNhap);
            obj[10] = new SqlParameter("HH_GiaXuat", item.GiaXuat);
            obj[11] = new SqlParameter("HH_TonDinhMuc", item.TonDinhMuc);
            obj[12] = new SqlParameter("HH_Anh", item.Anh);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("HH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[13] = new SqlParameter("HH_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("HH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[14] = new SqlParameter("HH_NgayCapNhat", DBNull.Value);
            }
            obj[15] = new SqlParameter("HH_NguoiTao", item.NguoiTao);
            obj[16] = new SqlParameter("HH_NguoiCapNhat", item.NguoiCapNhat);
            obj[17] = new SqlParameter("HH_Active", item.Active);
            obj[18] = new SqlParameter("HH_KhuyenMai", item.KhuyenMai);
            obj[19] = new SqlParameter("HH_DuaLenWeb", item.DuaLenWeb);
            obj[20] = new SqlParameter("HH_SoLuongHienTai", item.SoLuongHienTai);
            obj[21] = new SqlParameter("HH_HetHang", item.HetHang);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_HangHoa_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HangHoa Update(HangHoa item)
        {
            var Item = new HangHoa();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("HH_ID", item.ID);
            obj[1] = new SqlParameter("HH_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("HH_Ma", item.Ma);
            obj[3] = new SqlParameter("HH_MoTa", item.MoTa);
            obj[4] = new SqlParameter("HH_NoiDung", item.NoiDung);
            obj[5] = new SqlParameter("HH_CongDung", item.CongDung);
            obj[6] = new SqlParameter("HH_CachDung", item.CachDung);
            obj[7] = new SqlParameter("HH_CacBuoc", item.CacBuoc);
            obj[8] = new SqlParameter("HH_DV_ID", item.DV_ID);
            obj[9] = new SqlParameter("HH_GiaNhap", item.GiaNhap);
            obj[10] = new SqlParameter("HH_GiaXuat", item.GiaXuat);
            obj[11] = new SqlParameter("HH_TonDinhMuc", item.TonDinhMuc);
            obj[12] = new SqlParameter("HH_Anh", item.Anh);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("HH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[13] = new SqlParameter("HH_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("HH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[14] = new SqlParameter("HH_NgayCapNhat", DBNull.Value);
            }
            obj[15] = new SqlParameter("HH_NguoiTao", item.NguoiTao);
            obj[16] = new SqlParameter("HH_NguoiCapNhat", item.NguoiCapNhat);
            obj[17] = new SqlParameter("HH_Active", item.Active);
            obj[18] = new SqlParameter("HH_KhuyenMai", item.KhuyenMai);
            obj[19] = new SqlParameter("HH_DuaLenWeb", item.DuaLenWeb);
            obj[20] = new SqlParameter("HH_SoLuongHienTai", item.SoLuongHienTai);
            obj[21] = new SqlParameter("HH_HetHang", item.HetHang);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_HangHoa_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HangHoa SelectById(Guid HH_ID)
        {
            var Item = new HangHoa();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_HangHoa_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HangHoaCollection SelectAll()
        {
            var List = new HangHoaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_HangHoa_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<HangHoa> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<HangHoa>("sp_tblHangHoa_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static HangHoa getFromReader(IDataReader rd)
        {
            var Item = new HangHoa();
            if (rd.FieldExists("HH_ID"))
            {
                Item.ID = (Guid)(rd["HH_ID"]);
            }
            if (rd.FieldExists("HH_DM_ID"))
            {
                Item.DM_ID = (Guid)(rd["HH_DM_ID"]);
            }
            if (rd.FieldExists("HH_Ma"))
            {
                Item.Ma = (String)(rd["HH_Ma"]);
            }
            if (rd.FieldExists("HH_MoTa"))
            {
                Item.MoTa = (String)(rd["HH_MoTa"]);
            }
            if (rd.FieldExists("HH_NoiDung"))
            {
                Item.NoiDung = (String)(rd["HH_NoiDung"]);
            }
            if (rd.FieldExists("HH_CongDung"))
            {
                Item.CongDung = (String)(rd["HH_CongDung"]);
            }
            if (rd.FieldExists("HH_CachDung"))
            {
                Item.CachDung = (String)(rd["HH_CachDung"]);
            }
            if (rd.FieldExists("HH_CacBuoc"))
            {
                Item.CacBuoc = (String)(rd["HH_CacBuoc"]);
            }
            if (rd.FieldExists("HH_DV_ID"))
            {
                Item.DV_ID = (Guid)(rd["HH_DV_ID"]);
            }
            if (rd.FieldExists("HH_GiaNhap"))
            {
                Item.GiaNhap = (Int32)(rd["HH_GiaNhap"]);
            }
            if (rd.FieldExists("HH_GiaXuat"))
            {
                Item.GiaXuat = (Int32)(rd["HH_GiaXuat"]);
            }
            if (rd.FieldExists("HH_TonDinhMuc"))
            {
                Item.TonDinhMuc = (Int32)(rd["HH_TonDinhMuc"]);
            }
            if (rd.FieldExists("HH_Anh"))
            {
                Item.Anh = (String)(rd["HH_Anh"]);
            }
            if (rd.FieldExists("HH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["HH_NgayTao"]);
            }
            if (rd.FieldExists("HH_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["HH_NgayCapNhat"]);
            }
            if (rd.FieldExists("HH_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["HH_NguoiTao"]);
            }
            if (rd.FieldExists("HH_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["HH_NguoiCapNhat"]);
            }
            if (rd.FieldExists("HH_Active"))
            {
                Item.Active = (Boolean)(rd["HH_Active"]);
            }
            if (rd.FieldExists("HH_KhuyenMai"))
            {
                Item.KhuyenMai = (Boolean)(rd["HH_KhuyenMai"]);
            }
            if (rd.FieldExists("HH_DuaLenWeb"))
            {
                Item.DuaLenWeb = (Boolean)(rd["HH_DuaLenWeb"]);
            }
            if (rd.FieldExists("HH_SoLuongHienTai"))
            {
                Item.SoLuongHienTai = (Int32)(rd["HH_SoLuongHienTai"]);
            }
            if (rd.FieldExists("HH_HetHang"))
            {
                Item.HetHang = (Boolean)(rd["HH_HetHang"]);
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
