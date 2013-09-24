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
using linh.common;
using System.Web;

namespace seo.entities
{
    #region KhachHang
    #region BO
    public class KhachHang : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String GioiThieu { get; set; }
        public String Anh { get; set; }
        public String DiaChi { get; set; }
        public String Mobile { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Website { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean Publish { get; set; }
        public Boolean Active { get; set; }
        public Boolean Confirmed { get; set; }
        #endregion
        #region Contructor
        public KhachHang()
        { }
        public KhachHang(IDataReader rd)
        {
            if (rd.FieldExists("KH_ID"))
            {
                ID = (Int64)(rd["KH_ID"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Ten = (String)(rd["KH_Ten"]);
            }
            if (rd.FieldExists("KH_MoTa"))
            {
                MoTa = (String)(rd["KH_MoTa"]);
            }
            if (rd.FieldExists("KH_GioiThieu"))
            {
                GioiThieu = (String)(rd["KH_GioiThieu"]);
            }
            if (rd.FieldExists("KH_Anh"))
            {
                Anh = (String)(rd["KH_Anh"]);
            }
            if (rd.FieldExists("KH_DiaChi"))
            {
                DiaChi = (String)(rd["KH_DiaChi"]);
            }
            if (rd.FieldExists("KH_Mobile"))
            {
                Mobile = (String)(rd["KH_Mobile"]);
            }
            if (rd.FieldExists("KH_Phone"))
            {
                Phone = (String)(rd["KH_Phone"]);
            }
            if (rd.FieldExists("KH_Email"))
            {
                Email = (String)(rd["KH_Email"]);
            }
            if (rd.FieldExists("KH_Website"))
            {
                Website = (String)(rd["KH_Website"]);
            }
            if (rd.FieldExists("KH_RowId"))
            {
                RowId = (Guid)(rd["KH_RowId"]);
            }
            if (rd.FieldExists("KH_NgayTao"))
            {
                NgayTao = (DateTime)(rd["KH_NgayTao"]);
            }
            if (rd.FieldExists("KH_NguoiTao"))
            {
                NguoiTao = (String)(rd["KH_NguoiTao"]);
            }
            if (rd.FieldExists("KH_NgayCapNhat"))
            {
                NgayCapNhat = (DateTime)(rd["KH_NgayCapNhat"]);
            }
            if (rd.FieldExists("KH_NguoiCapNhat"))
            {
                NguoiCapNhat = (String)(rd["KH_NguoiCapNhat"]);
            }
            if (rd.FieldExists("KH_Publish"))
            {
                Publish = (Boolean)(rd["KH_Publish"]);
            }
            if (rd.FieldExists("KH_Active"))
            {
                Active = (Boolean)(rd["KH_Active"]);
            }
            if (rd.FieldExists("KH_Confirmed"))
            {
                Confirmed = (Boolean)(rd["KH_Confirmed"]);
            }

        }
        #endregion
        #region Customs properties

        #endregion
        #region getFromReader
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return new KhachHang(rd);
        }
        public string format(int Loai)
        {
            StringBuilder sb = new StringBuilder();
            switch (Loai)
            {
                case 0:
                    #region 0 :
                    break;
                    #endregion
                case 1:
                    #region 1 :
                    break;
                    #endregion
                case 2:
                    #region 2 :
                    break;
                    #endregion
                case 3:
                    #region 3 :
                    break;
                    #endregion
                default:
                    #region mac dinh
                    break;
                    #endregion
            }
            return sb.ToString();
        }
        #endregion
    }
    #endregion
    #region Collection
    public class KhachHangCollection : BaseEntityCollection<KhachHang>
    { }
    #endregion
    #region Dal
    public class KhachHangDal
    {
        #region Methods

        public static void DeleteById(Int32 KH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoKhachHang_Delete_DeleteById_linhnx", obj);
        }
        public static KhachHang Insert(KhachHang Inserted)
        {
            KhachHang Item = new KhachHang();
            SqlParameter[] obj = new SqlParameter[17];
            obj[0] = new SqlParameter("KH_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("KH_MoTa", Inserted.MoTa);
            obj[2] = new SqlParameter("KH_GioiThieu", Inserted.GioiThieu);
            obj[3] = new SqlParameter("KH_Anh", Inserted.Anh);
            obj[4] = new SqlParameter("KH_DiaChi", Inserted.DiaChi);
            obj[5] = new SqlParameter("KH_Mobile", Inserted.Mobile);
            obj[6] = new SqlParameter("KH_Phone", Inserted.Phone);
            obj[7] = new SqlParameter("KH_Email", Inserted.Email);
            obj[8] = new SqlParameter("KH_Website", Inserted.Website);
            obj[9] = new SqlParameter("KH_RowId", Inserted.RowId);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("KH_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("KH_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("KH_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("KH_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("KH_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("KH_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[14] = new SqlParameter("KH_Publish", Inserted.Publish);
            obj[15] = new SqlParameter("KH_Active", Inserted.Active);
            obj[16] = new SqlParameter("KH_Confirmed", Inserted.Confirmed);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoKhachHang_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new KhachHang(rd);
                }
            }
            return Item;
        }
        public static KhachHang Insert(KhachHang Inserted, SqlConnection con)
        {
            KhachHang Item = new KhachHang();
            SqlParameter[] obj = new SqlParameter[17];
            obj[0] = new SqlParameter("KH_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("KH_MoTa", Inserted.MoTa);
            obj[2] = new SqlParameter("KH_GioiThieu", Inserted.GioiThieu);
            obj[3] = new SqlParameter("KH_Anh", Inserted.Anh);
            obj[4] = new SqlParameter("KH_DiaChi", Inserted.DiaChi);
            obj[5] = new SqlParameter("KH_Mobile", Inserted.Mobile);
            obj[6] = new SqlParameter("KH_Phone", Inserted.Phone);
            obj[7] = new SqlParameter("KH_Email", Inserted.Email);
            obj[8] = new SqlParameter("KH_Website", Inserted.Website);
            obj[9] = new SqlParameter("KH_RowId", Inserted.RowId);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("KH_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("KH_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("KH_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("KH_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("KH_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("KH_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[14] = new SqlParameter("KH_Publish", Inserted.Publish);
            obj[15] = new SqlParameter("KH_Active", Inserted.Active);
            obj[16] = new SqlParameter("KH_Confirmed", Inserted.Confirmed);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoKhachHang_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new KhachHang(rd);
                }
            }
            return Item;
        }
        public static KhachHang Update(KhachHang Updated)
        {
            KhachHang Item = new KhachHang();
            SqlParameter[] obj = new SqlParameter[18];
            obj[0] = new SqlParameter("KH_ID", Updated.ID);
            obj[1] = new SqlParameter("KH_Ten", Updated.Ten);
            obj[2] = new SqlParameter("KH_MoTa", Updated.MoTa);
            obj[3] = new SqlParameter("KH_GioiThieu", Updated.GioiThieu);
            obj[4] = new SqlParameter("KH_Anh", Updated.Anh);
            obj[5] = new SqlParameter("KH_DiaChi", Updated.DiaChi);
            obj[6] = new SqlParameter("KH_Mobile", Updated.Mobile);
            obj[7] = new SqlParameter("KH_Phone", Updated.Phone);
            obj[8] = new SqlParameter("KH_Email", Updated.Email);
            obj[9] = new SqlParameter("KH_Website", Updated.Website);
            obj[10] = new SqlParameter("KH_RowId", Updated.RowId);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("KH_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[11] = new SqlParameter("KH_NgayTao", DBNull.Value);
            }
            obj[12] = new SqlParameter("KH_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("KH_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("KH_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("KH_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[15] = new SqlParameter("KH_Publish", Updated.Publish);
            obj[16] = new SqlParameter("KH_Active", Updated.Active);
            obj[17] = new SqlParameter("KH_Confirmed", Updated.Confirmed);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoKhachHang_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new KhachHang(rd);
                }
            }
            return Item;
        }
        public static KhachHang Update(KhachHang Updated, SqlConnection con)
        {
            KhachHang Item = new KhachHang();
            SqlParameter[] obj = new SqlParameter[18];
            obj[0] = new SqlParameter("KH_ID", Updated.ID);
            obj[1] = new SqlParameter("KH_Ten", Updated.Ten);
            obj[2] = new SqlParameter("KH_MoTa", Updated.MoTa);
            obj[3] = new SqlParameter("KH_GioiThieu", Updated.GioiThieu);
            obj[4] = new SqlParameter("KH_Anh", Updated.Anh);
            obj[5] = new SqlParameter("KH_DiaChi", Updated.DiaChi);
            obj[6] = new SqlParameter("KH_Mobile", Updated.Mobile);
            obj[7] = new SqlParameter("KH_Phone", Updated.Phone);
            obj[8] = new SqlParameter("KH_Email", Updated.Email);
            obj[9] = new SqlParameter("KH_Website", Updated.Website);
            obj[10] = new SqlParameter("KH_RowId", Updated.RowId);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("KH_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[11] = new SqlParameter("KH_NgayTao", DBNull.Value);
            }
            obj[12] = new SqlParameter("KH_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("KH_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("KH_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("KH_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[15] = new SqlParameter("KH_Publish", Updated.Publish);
            obj[16] = new SqlParameter("KH_Active", Updated.Active);
            obj[17] = new SqlParameter("KH_Confirmed", Updated.Confirmed);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoKhachHang_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new KhachHang(rd);
                }
            }
            return Item;
        }
        public static KhachHang SelectById(Int32 KH_ID)
        {
            KhachHang Item = new KhachHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoKhachHang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new KhachHang(rd);
                }
            }
            return Item;
        }
        public static KhachHang SelectById(Int32 KH_ID, SqlConnection con)
        {
            KhachHang Item = new KhachHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoKhachHang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new KhachHang(rd);
                }
            }
            return Item;
        }
        public static KhachHangCollection SelectAll()
        {
            KhachHangCollection List = new KhachHangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoKhachHang_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new KhachHang(rd));
                }
            }
            return List;
        }
        public static KhachHangCollection SelectAll(SqlConnection con)
        {
            KhachHangCollection List = new KhachHangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoKhachHang_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new KhachHang(rd));
                }
            }
            return List;
        }
        public static Pager<KhachHang> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<KhachHang> pg = new Pager<KhachHang>("tblSeo_sp_tblKhachHang_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<KhachHang> pagerNormal(SqlConnection con, string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<KhachHang> pg = new Pager<KhachHang>(con, "tblSeo_sp_tblKhachHang_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        #endregion
        #region Extend
        #endregion
    }
    #endregion
    #endregion
}


