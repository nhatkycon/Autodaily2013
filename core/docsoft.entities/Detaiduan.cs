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
    #region DeTaiDuAn
    #region BO
    public class DeTaiDuAn : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 Loai_ID { get; set; }
        public String Loai_Ten { get; set; }
        public Int32 ChuongTrinh_ID { get; set; }
        public String ChuongTrinh_Ten { get; set; }
        public Int32 XuatXu_ID { get; set; }
        public String XuatXu_Ten { get; set; }
        public String CapThiet { get; set; }
        public String MucTieu { get; set; }
        public String NoiDung { get; set; }
        public String SanPham { get; set; }
        public String KhaNang { get; set; }
        public String DiaChi { get; set; }
        public Decimal KinhPhi { get; set; }
        public Decimal KP_NganSach { get; set; }
        public Decimal KP_Khac { get; set; }
        public String CaNhanDeXuat { get; set; }
        public String ThuTruong { get; set; }
        public Int32 ThoiGian { get; set; }
        public Int32 LinhVuc_ID { get; set; }
        public String LinhVuc_Ten { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public String Ten { get; set; }
        public Int32 DeTaiDuAn_ID { get; set; }
        public String DeTaiDuAn_Ten { get; set; }
        public Int32 TrangThai_ID { get; set; }
        public String TrangThai_Ten { get; set; }
        public Int32 SoTT { get; set; }
        public Boolean Draff { get; set; }
        public Int32 CQ_ID { get; set; }
        public String CQ_Ma { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        #endregion
        #region Contructor
        public DeTaiDuAn()
        { }
        #endregion
        #region Customs properties
        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DeTaiDuAnDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DeTaiDuAnCollection : BaseEntityCollection<DeTaiDuAn>
    { }
    #endregion
    #region Dal
    public class DeTaiDuAnDal
    {
        #region Methods

        public static void DeleteById(Int32 DTDA_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DTDA_ID", DTDA_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDeTaiDuAn_Delete_DeleteById_linhnx", obj);
        }

        public static DeTaiDuAn Insert(DeTaiDuAn Inserted)
        {
            DeTaiDuAn Item = new DeTaiDuAn();
            SqlParameter[] obj = new SqlParameter[34];
            obj[0] = new SqlParameter("DTDA_Loai_ID", Inserted.Loai_ID);
            obj[1] = new SqlParameter("DTDA_Loai_Ten", Inserted.Loai_Ten);
            obj[2] = new SqlParameter("DTDA_ChuongTrinh_ID", Inserted.ChuongTrinh_ID);
            obj[3] = new SqlParameter("DTDA_ChuongTrinh_Ten", Inserted.ChuongTrinh_Ten);
            obj[4] = new SqlParameter("DTDA_XuatXu_ID", Inserted.XuatXu_ID);
            obj[5] = new SqlParameter("DTDA_XuatXu_Ten", Inserted.XuatXu_Ten);
            obj[6] = new SqlParameter("DTDA_CapThiet", Inserted.CapThiet);
            obj[7] = new SqlParameter("DTDA_MucTieu", Inserted.MucTieu);
            obj[8] = new SqlParameter("DTDA_NoiDung", Inserted.NoiDung);
            obj[9] = new SqlParameter("DTDA_SanPham", Inserted.SanPham);
            obj[10] = new SqlParameter("DTDA_KhaNang", Inserted.KhaNang);
            obj[11] = new SqlParameter("DTDA_DiaChi", Inserted.DiaChi);
            obj[12] = new SqlParameter("DTDA_KinhPhi", Inserted.KinhPhi);
            obj[13] = new SqlParameter("DTDA_KP_NganSach", Inserted.KP_NganSach);
            obj[14] = new SqlParameter("DTDA_KP_Khac", Inserted.KP_Khac);
            obj[15] = new SqlParameter("DTDA_CaNhanDeXuat", Inserted.CaNhanDeXuat);
            obj[16] = new SqlParameter("DTDA_ThuTruong", Inserted.ThuTruong);
            obj[17] = new SqlParameter("DTDA_ThoiGian", Inserted.ThoiGian);
            obj[18] = new SqlParameter("DTDA_LinhVuc_ID", Inserted.LinhVuc_ID);
            obj[19] = new SqlParameter("DTDA_LinhVuc_Ten", Inserted.LinhVuc_Ten);
            obj[20] = new SqlParameter("DTDA_RowId", Inserted.RowId);
            obj[21] = new SqlParameter("DTDA_NgayTao", Inserted.NgayTao);
            obj[22] = new SqlParameter("DTDA_NgayCapNhat", Inserted.NgayCapNhat);
            obj[23] = new SqlParameter("DTDA_NguoiTao", Inserted.NguoiTao);
            obj[24] = new SqlParameter("DTDA_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[25] = new SqlParameter("DTDA_Ten", Inserted.Ten);
            obj[26] = new SqlParameter("DTDA_DeTaiDuAn_ID", Inserted.DeTaiDuAn_ID);
            obj[27] = new SqlParameter("DTDA_DeTaiDuAn_Ten", Inserted.DeTaiDuAn_Ten);
            obj[28] = new SqlParameter("DTDA_TrangThai_ID", Inserted.TrangThai_ID);
            obj[29] = new SqlParameter("DTDA_TrangThai_Ten", Inserted.TrangThai_Ten);
            obj[30] = new SqlParameter("DTDA_SoTT", Inserted.SoTT);
            obj[31] = new SqlParameter("DTDA_Draff", Inserted.Draff);

            string htl = string.Format("{0:dd/MM/yy}", Inserted.TuNgay);
            if (htl != "01/01/01")
            {
                obj[32] = new SqlParameter("DTDA_TuNgay", Inserted.TuNgay);
            }
            else
            {
                obj[32] = new SqlParameter("DTDA_TuNgay", DBNull.Value);
            }
            htl = string.Format("{0:dd/MM/yy}", Inserted.DenNgay);
            if (htl != "01/01/01")
            {
                obj[33] = new SqlParameter("DTDA_DenNgay", Inserted.DenNgay);
            }
            else
            {
                obj[33] = new SqlParameter("DTDA_DenNgay", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDeTaiDuAn_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DeTaiDuAn Update(DeTaiDuAn Updated)
        {
            DeTaiDuAn Item = new DeTaiDuAn();
            SqlParameter[] obj = new SqlParameter[35];
            obj[0] = new SqlParameter("DTDA_ID", Updated.ID);
            obj[1] = new SqlParameter("DTDA_Loai_ID", Updated.Loai_ID);
            obj[2] = new SqlParameter("DTDA_Loai_Ten", Updated.Loai_Ten);
            obj[3] = new SqlParameter("DTDA_ChuongTrinh_ID", Updated.ChuongTrinh_ID);
            obj[4] = new SqlParameter("DTDA_ChuongTrinh_Ten", Updated.ChuongTrinh_Ten);
            obj[5] = new SqlParameter("DTDA_XuatXu_ID", Updated.XuatXu_ID);
            obj[6] = new SqlParameter("DTDA_XuatXu_Ten", Updated.XuatXu_Ten);
            obj[7] = new SqlParameter("DTDA_CapThiet", Updated.CapThiet);
            obj[8] = new SqlParameter("DTDA_MucTieu", Updated.MucTieu);
            obj[9] = new SqlParameter("DTDA_NoiDung", Updated.NoiDung);
            obj[10] = new SqlParameter("DTDA_SanPham", Updated.SanPham);
            obj[11] = new SqlParameter("DTDA_KhaNang", Updated.KhaNang);
            obj[12] = new SqlParameter("DTDA_DiaChi", Updated.DiaChi);
            obj[13] = new SqlParameter("DTDA_KinhPhi", Updated.KinhPhi);
            obj[14] = new SqlParameter("DTDA_KP_NganSach", Updated.KP_NganSach);
            obj[15] = new SqlParameter("DTDA_KP_Khac", Updated.KP_Khac);
            obj[16] = new SqlParameter("DTDA_CaNhanDeXuat", Updated.CaNhanDeXuat);
            obj[17] = new SqlParameter("DTDA_ThuTruong", Updated.ThuTruong);
            obj[18] = new SqlParameter("DTDA_ThoiGian", Updated.ThoiGian);
            obj[19] = new SqlParameter("DTDA_LinhVuc_ID", Updated.LinhVuc_ID);
            obj[20] = new SqlParameter("DTDA_LinhVuc_Ten", Updated.LinhVuc_Ten);
            obj[21] = new SqlParameter("DTDA_RowId", Updated.RowId);
            string htl = string.Format("{0:dd/MM/yy}", Updated.TuNgay);
            if (htl != "01/01/01")
            {
                obj[22] = new SqlParameter("DTDA_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[22] = new SqlParameter("DTDA_NgayTao", DBNull.Value);
            }

            string htl1 = string.Format("{0:dd/MM/yy}", Updated.NgayCapNhat);
            if (htl1 != "01/01/01")
            {
                obj[23] = new SqlParameter("DTDA_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[23] = new SqlParameter("DTDA_NgayCapNhat", DBNull.Value);
            }
            obj[24] = new SqlParameter("DTDA_NguoiTao", Updated.NguoiTao);
            obj[25] = new SqlParameter("DTDA_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[26] = new SqlParameter("DTDA_Ten", Updated.Ten);
            obj[27] = new SqlParameter("DTDA_DeTaiDuAn_ID", Updated.DeTaiDuAn_ID);
            obj[28] = new SqlParameter("DTDA_DeTaiDuAn_Ten", Updated.DeTaiDuAn_Ten);
            obj[29] = new SqlParameter("DTDA_TrangThai_ID", Updated.TrangThai_ID);
            obj[30] = new SqlParameter("DTDA_TrangThai_Ten", Updated.TrangThai_Ten);
            obj[31] = new SqlParameter("DTDA_SoTT", Updated.SoTT);
            obj[32] = new SqlParameter("DTDA_Draff", Updated.Draff);
            string htl2 = string.Format("{0:dd/MM/yy}", Updated.TuNgay);
            if (htl2 != "01/01/01")
            {
                obj[33] = new SqlParameter("DTDA_TuNgay", Updated.TuNgay);
            }
            else
            {
                obj[33] = new SqlParameter("DTDA_TuNgay", DBNull.Value);
            }
            string htl3 = string.Format("{0:dd/MM/yy}", Updated.DenNgay);
            if (htl3 != "01/01/01")
            {
                obj[34] = new SqlParameter("DTDA_DenNgay", Updated.DenNgay);
            }
            else
            {
                obj[34] = new SqlParameter("DTDA_DenNgay", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDeTaiDuAn_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DeTaiDuAn SelectById(Int32 DTDA_ID)
        {
            DeTaiDuAn Item = new DeTaiDuAn();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DTDA_ID", DTDA_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDeTaiDuAn_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DeTaiDuAn SelectByIdView(Int32 DTDA_ID)
        {
            DeTaiDuAn Item = new DeTaiDuAn();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DTDA_ID", DTDA_ID);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDeTaiDuAn_Select_SelectByIdView_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    Files item = new Files();
                    item.Ten = rd["F_Ten"].ToString();
                    item.ID = Convert.ToInt32(rd["F_ID"]);
                    item.NguoiTao = rd["F_NguoiTao"].ToString();
                    filelist.Add(item);
                }
            }
            Item.Filelist = filelist;
            return Item;
        }

        public static DeTaiDuAn SelectDraff(string DTDA_Ma, string userName)
        {
            DeTaiDuAn Item = new DeTaiDuAn();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DTDA_Ma", DTDA_Ma);
            obj[1] = new SqlParameter("Username", userName);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDeTaiDuAn_Select_SelectDraff_hungpm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        

        public static DeTaiDuAnCollection SelectAll()
        {
            DeTaiDuAnCollection List = new DeTaiDuAnCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDeTaiDuAn_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DeTaiDuAn> pagerNormal(string url, bool rewrite, string sort, string _q, string _loai_ID, string _linhVuc_ID, string _chuongTrinh_ID, string _deTaiDuAn_ID, string _trangThai_ID, string _xuatXu_ID, string _userName, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", _q);
            obj[2] = new SqlParameter("Loai_ID", _loai_ID);
            if (!string.IsNullOrEmpty(_linhVuc_ID))
            {
                obj[3] = new SqlParameter("LV_ID", _linhVuc_ID);
            }
            else
            {
                obj[3] = new SqlParameter("LV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_chuongTrinh_ID))
            {
                obj[4] = new SqlParameter("ChuongTrinh_ID", _chuongTrinh_ID);
            }
            else
            {
                obj[4] = new SqlParameter("ChuongTrinh_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_deTaiDuAn_ID))
            {
                obj[5] = new SqlParameter("DeTaiDuAn_ID", _deTaiDuAn_ID);
            }
            else
            {
                obj[5] = new SqlParameter("DeTaiDuAn_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(_xuatXu_ID))
            {
                obj[6] = new SqlParameter("XuatXu_ID", _xuatXu_ID);
            }
            else
            {
                obj[6] = new SqlParameter("XuatXu_ID", DBNull.Value);
            }
            obj[7] = new SqlParameter("Username",  _userName);
            if (!string.IsNullOrEmpty(_trangThai_ID))
            {
                obj[8] = new SqlParameter("TrangThai_ID", _trangThai_ID);
            }
            else
            {
                obj[8] = new SqlParameter("TrangThai_ID", DBNull.Value);
            }

            if (string.IsNullOrEmpty(pagesize)) pagesize = "20";
            Pager<DeTaiDuAn> pg = new Pager<DeTaiDuAn>("sp_tblDeTaiDuAn_Pager_Normal_linhnx", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DeTaiDuAn getFromReader(IDataReader rd)
        {
            DeTaiDuAn Item = new DeTaiDuAn();
            if (rd.FieldExists("DTDA_ID"))
            {
                Item.ID = (Int32)(rd["DTDA_ID"]);
            }
            if (rd.FieldExists("DTDA_Loai_ID"))
            {
                Item.Loai_ID = (Int32)(rd["DTDA_Loai_ID"]);
            }
            if (rd.FieldExists("DTDA_Loai_Ten"))
            {
                Item.Loai_Ten = (String)(rd["DTDA_Loai_Ten"]);
            }
            if (rd.FieldExists("DTDA_ChuongTrinh_ID"))
            {
                Item.ChuongTrinh_ID = (Int32)(rd["DTDA_ChuongTrinh_ID"]);
            }
            if (rd.FieldExists("DTDA_ChuongTrinh_Ten"))
            {
                Item.ChuongTrinh_Ten = (String)(rd["DTDA_ChuongTrinh_Ten"]);
            }
            if (rd.FieldExists("DTDA_XuatXu_ID"))
            {
                Item.XuatXu_ID = (Int32)(rd["DTDA_XuatXu_ID"]);
            }
            if (rd.FieldExists("DTDA_XuatXu_Ten"))
            {
                Item.XuatXu_Ten = (String)(rd["DTDA_XuatXu_Ten"]);
            }
            if (rd.FieldExists("DTDA_CapThiet"))
            {
                Item.CapThiet = (String)(rd["DTDA_CapThiet"]);
            }
            if (rd.FieldExists("DTDA_MucTieu"))
            {
                Item.MucTieu = (String)(rd["DTDA_MucTieu"]);
            }
            if (rd.FieldExists("DTDA_NoiDung"))
            {
                Item.NoiDung = (String)(rd["DTDA_NoiDung"]);
            }
            if (rd.FieldExists("DTDA_SanPham"))
            {
                Item.SanPham = (String)(rd["DTDA_SanPham"]);
            }
            if (rd.FieldExists("DTDA_KhaNang"))
            {
                Item.KhaNang = (String)(rd["DTDA_KhaNang"]);
            }
            if (rd.FieldExists("DTDA_DiaChi"))
            {
                Item.DiaChi = (String)(rd["DTDA_DiaChi"]);
            }
            if (rd.FieldExists("DTDA_KinhPhi"))
            {
                Item.KinhPhi = (Decimal)(rd["DTDA_KinhPhi"]);
            }
            if (rd.FieldExists("DTDA_KP_NganSach"))
            {
                Item.KP_NganSach = (Decimal)(rd["DTDA_KP_NganSach"]);
            }
            if (rd.FieldExists("DTDA_KP_Khac"))
            {
                Item.KP_Khac = (Decimal)(rd["DTDA_KP_Khac"]);
            }
            if (rd.FieldExists("DTDA_CaNhanDeXuat"))
            {
                Item.CaNhanDeXuat = (String)(rd["DTDA_CaNhanDeXuat"]);
            }
            if (rd.FieldExists("DTDA_ThuTruong"))
            {
                Item.ThuTruong = (String)(rd["DTDA_ThuTruong"]);
            }
            if (rd.FieldExists("DTDA_ThoiGian"))
            {
                Item.ThoiGian = (Int32)(rd["DTDA_ThoiGian"]);
            }
            if (rd.FieldExists("DTDA_LinhVuc_ID"))
            {
                Item.LinhVuc_ID = (Int32)(rd["DTDA_LinhVuc_ID"]);
            }
            if (rd.FieldExists("DTDA_LinhVuc_Ten"))
            {
                Item.LinhVuc_Ten = (String)(rd["DTDA_LinhVuc_Ten"]);
            }
            if (rd.FieldExists("DTDA_RowId"))
            {
                Item.RowId = (Guid)(rd["DTDA_RowId"]);
            }
            if (rd.FieldExists("DTDA_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DTDA_NgayTao"]);
            }
            if (rd.FieldExists("DTDA_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["DTDA_NgayCapNhat"]);
            }
            if (rd.FieldExists("DTDA_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["DTDA_NguoiTao"]);
            }
            if (rd.FieldExists("DTDA_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["DTDA_NguoiCapNhat"]);
            }
            if (rd.FieldExists("DTDA_Ten"))
            {
                Item.Ten = (String)(rd["DTDA_Ten"]);
            }

            if (rd.FieldExists("DTDA_DeTaiDuAn_ID"))
            {
                Item.DeTaiDuAn_ID = (Int32)(rd["DTDA_DeTaiDuAn_ID"]);
            }

            if (rd.FieldExists("DTDA_DeTaiDuAn_Ten"))
            {
                Item.DeTaiDuAn_Ten = (String)(rd["DTDA_DeTaiDuAn_Ten"]);
            }
            if (rd.FieldExists("DTDA_TrangThai_ID"))
            {
                Item.TrangThai_ID = (Int32)(rd["DTDA_TrangThai_ID"]);
            }
            if (rd.FieldExists("DTDA_TrangThai_Ten"))
            {
                Item.TrangThai_Ten = (String)(rd["DTDA_TrangThai_Ten"]);
            }
            if (rd.FieldExists("DTDA_SoTT"))
            {
                Item.SoTT = (Int32)(rd["DTDA_SoTT"]);
            }
            if (rd.FieldExists("DTDA_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["DTDA_CQ_ID"]);
            }
            if (rd.FieldExists("DTDA_CQ_Ma"))
            {
                Item.CQ_Ma = (String)(rd["DTDA_CQ_Ma"]);
            }
            if (rd.FieldExists("DTDA_TuNgay"))
            {
                Item.TuNgay = (DateTime)(rd["DTDA_TuNgay"]);
            }
            if (rd.FieldExists("DTDA_DenNgay"))
            {
                Item.DenNgay = (DateTime)(rd["DTDA_DenNgay"]);
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
