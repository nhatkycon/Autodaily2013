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
    #region Link
    #region BO
    public class Link : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public String Code { get; set; }
        public Int64 CD_ID { get; set; }
        public Int64 W_ID { get; set; }
        public String Url { get; set; }
        public Double Gia { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayHienThi { get; set; }
        public DateTime NgayKiemTra { get; set; }
        public Boolean IsGood { get; set; }
        public Boolean IsRequestChecked { get; set; }
        public Boolean IsNeedReChecked { get; set; }
        public Boolean IsChecked { get; set; }
        public Boolean IsPaid { get; set; }
        public Boolean IsReports { get; set; }
        public String MoTa { get; set; }
        public Int32 Comments { get; set; }
        #endregion
        #region Contructor
        public Link()
        { }
        public Link(IDataReader rd)
        {
            if (rd.FieldExists("L_ID"))
            {
                ID = (Int64)(rd["L_ID"]);
            }
            if (rd.FieldExists("L_Code"))
            {
                Code = (String)(rd["L_Code"]);
            }
            if (rd.FieldExists("L_CD_ID"))
            {
                CD_ID = (Int64)(rd["L_CD_ID"]);
            }
            if (rd.FieldExists("L_W_ID"))
            {
                W_ID = (Int64)(rd["L_W_ID"]);
            }
            if (rd.FieldExists("L_Url"))
            {
                Url = (String)(rd["L_Url"]);
            }
            if (rd.FieldExists("L_Gia"))
            {
                Gia = (Double)(rd["L_Gia"]);
            }
            if (rd.FieldExists("L_NgayTao"))
            {
                NgayTao = (DateTime)(rd["L_NgayTao"]);
            }
            if (rd.FieldExists("L_NguoiTao"))
            {
                NguoiTao = (String)(rd["L_NguoiTao"]);
            }
            if (rd.FieldExists("L_NgayHienThi"))
            {
                NgayHienThi = (DateTime)(rd["L_NgayHienThi"]);
            }
            if (rd.FieldExists("L_NgayKiemTra"))
            {
                NgayKiemTra = (DateTime)(rd["L_NgayKiemTra"]);
            }
            if (rd.FieldExists("L_IsGood"))
            {
                IsGood = (Boolean)(rd["L_IsGood"]);
            }
            if (rd.FieldExists("L_IsRequestChecked"))
            {
                IsRequestChecked = (Boolean)(rd["L_IsRequestChecked"]);
            }
            if (rd.FieldExists("L_IsNeedReChecked"))
            {
                IsNeedReChecked = (Boolean)(rd["L_IsNeedReChecked"]);
            }
            if (rd.FieldExists("L_IsChecked"))
            {
                IsChecked = (Boolean)(rd["L_IsChecked"]);
            }
            if (rd.FieldExists("L_IsPaid"))
            {
                IsPaid = (Boolean)(rd["L_IsPaid"]);
            }
            if (rd.FieldExists("L_IsReports"))
            {
                IsReports = (Boolean)(rd["L_IsReports"]);
            }
            if (rd.FieldExists("L_MoTa"))
            {
                MoTa = (String)(rd["L_MoTa"]);
            }
            if (rd.FieldExists("L_CD_Ten"))
            {
                CD_Ten = (String)(rd["L_CD_Ten"]);
            }
            if (rd.FieldExists("L_Comments"))
            {
                Comments = (Int32)(rd["L_Comments"]);
            }

        }
        #endregion
        #region Customs properties
        public String CD_Ten { get; set; }
        #endregion
        #region getFromReader
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return new Link(rd);
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
    public class LinkCollection : BaseEntityCollection<Link>
    { }
    #endregion
    #region Dal
    public class LinkDal
    {
        #region Methods

        public static void DeleteById(Int64 L_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("L_ID", L_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Delete_DeleteById_linhnx", obj);
        }
        public static Link Insert(Link Inserted)
        {
            Link Item = new Link();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("L_Code", Inserted.Code);
            obj[1] = new SqlParameter("L_CD_ID", Inserted.CD_ID);
            obj[2] = new SqlParameter("L_W_ID", Inserted.W_ID);
            obj[3] = new SqlParameter("L_Url", Inserted.Url);
            obj[4] = new SqlParameter("L_Gia", Inserted.Gia);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("L_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("L_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("L_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayHienThi > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("L_NgayHienThi", Inserted.NgayHienThi);
            }
            else
            {
                obj[7] = new SqlParameter("L_NgayHienThi", DBNull.Value);
            }
            if (Inserted.NgayKiemTra > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("L_NgayKiemTra", Inserted.NgayKiemTra);
            }
            else
            {
                obj[8] = new SqlParameter("L_NgayKiemTra", DBNull.Value);
            }
            obj[9] = new SqlParameter("L_IsGood", Inserted.IsGood);
            obj[10] = new SqlParameter("L_IsRequestChecked", Inserted.IsRequestChecked);
            obj[11] = new SqlParameter("L_IsNeedReChecked", Inserted.IsNeedReChecked);
            obj[12] = new SqlParameter("L_IsChecked", Inserted.IsChecked);
            obj[13] = new SqlParameter("L_IsPaid", Inserted.IsPaid);
            obj[14] = new SqlParameter("L_IsReports", Inserted.IsReports);
            obj[15] = new SqlParameter("L_MoTa", Inserted.MoTa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Link(rd);
                }
            }
            return Item;
        }
        public static Link Insert(Link Inserted, SqlConnection con)
        {
            Link Item = new Link();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("L_Code", Inserted.Code);
            obj[1] = new SqlParameter("L_CD_ID", Inserted.CD_ID);
            obj[2] = new SqlParameter("L_W_ID", Inserted.W_ID);
            obj[3] = new SqlParameter("L_Url", Inserted.Url);
            obj[4] = new SqlParameter("L_Gia", Inserted.Gia);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("L_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("L_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("L_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayHienThi > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("L_NgayHienThi", Inserted.NgayHienThi);
            }
            else
            {
                obj[7] = new SqlParameter("L_NgayHienThi", DBNull.Value);
            }
            if (Inserted.NgayKiemTra > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("L_NgayKiemTra", Inserted.NgayKiemTra);
            }
            else
            {
                obj[8] = new SqlParameter("L_NgayKiemTra", DBNull.Value);
            }
            obj[9] = new SqlParameter("L_IsGood", Inserted.IsGood);
            obj[10] = new SqlParameter("L_IsRequestChecked", Inserted.IsRequestChecked);
            obj[11] = new SqlParameter("L_IsNeedReChecked", Inserted.IsNeedReChecked);
            obj[12] = new SqlParameter("L_IsChecked", Inserted.IsChecked);
            obj[13] = new SqlParameter("L_IsPaid", Inserted.IsPaid);
            obj[14] = new SqlParameter("L_IsReports", Inserted.IsReports);
            obj[15] = new SqlParameter("L_MoTa", Inserted.MoTa);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Link(rd);
                }
            }
            return Item;
        }
        public static Link Update(Link Updated)
        {
            Link Item = new Link();
            SqlParameter[] obj = new SqlParameter[17];
            obj[0] = new SqlParameter("L_ID", Updated.ID);
            obj[1] = new SqlParameter("L_Code", Updated.Code);
            obj[2] = new SqlParameter("L_CD_ID", Updated.CD_ID);
            obj[3] = new SqlParameter("L_W_ID", Updated.W_ID);
            obj[4] = new SqlParameter("L_Url", Updated.Url);
            obj[5] = new SqlParameter("L_Gia", Updated.Gia);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("L_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("L_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("L_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayHienThi > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("L_NgayHienThi", Updated.NgayHienThi);
            }
            else
            {
                obj[8] = new SqlParameter("L_NgayHienThi", DBNull.Value);
            }
            if (Updated.NgayKiemTra > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("L_NgayKiemTra", Updated.NgayKiemTra);
            }
            else
            {
                obj[9] = new SqlParameter("L_NgayKiemTra", DBNull.Value);
            }
            obj[10] = new SqlParameter("L_IsGood", Updated.IsGood);
            obj[11] = new SqlParameter("L_IsRequestChecked", Updated.IsRequestChecked);
            obj[12] = new SqlParameter("L_IsNeedReChecked", Updated.IsNeedReChecked);
            obj[13] = new SqlParameter("L_IsChecked", Updated.IsChecked);
            obj[14] = new SqlParameter("L_IsPaid", Updated.IsPaid);
            obj[15] = new SqlParameter("L_IsReports", Updated.IsReports);
            obj[16] = new SqlParameter("L_MoTa", Updated.MoTa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Link(rd);
                }
            }
            return Item;
        }
        public static Link Update(Link Updated, SqlConnection con)
        {
            Link Item = new Link();
            SqlParameter[] obj = new SqlParameter[17];
            obj[0] = new SqlParameter("L_ID", Updated.ID);
            obj[1] = new SqlParameter("L_Code", Updated.Code);
            obj[2] = new SqlParameter("L_CD_ID", Updated.CD_ID);
            obj[3] = new SqlParameter("L_W_ID", Updated.W_ID);
            obj[4] = new SqlParameter("L_Url", Updated.Url);
            obj[5] = new SqlParameter("L_Gia", Updated.Gia);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("L_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("L_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("L_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayHienThi > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("L_NgayHienThi", Updated.NgayHienThi);
            }
            else
            {
                obj[8] = new SqlParameter("L_NgayHienThi", DBNull.Value);
            }
            if (Updated.NgayKiemTra > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("L_NgayKiemTra", Updated.NgayKiemTra);
            }
            else
            {
                obj[9] = new SqlParameter("L_NgayKiemTra", DBNull.Value);
            }
            obj[10] = new SqlParameter("L_IsGood", Updated.IsGood);
            obj[11] = new SqlParameter("L_IsRequestChecked", Updated.IsRequestChecked);
            obj[12] = new SqlParameter("L_IsNeedReChecked", Updated.IsNeedReChecked);
            obj[13] = new SqlParameter("L_IsChecked", Updated.IsChecked);
            obj[14] = new SqlParameter("L_IsPaid", Updated.IsPaid);
            obj[15] = new SqlParameter("L_IsReports", Updated.IsReports);
            obj[16] = new SqlParameter("L_MoTa", Updated.MoTa);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Link(rd);
                }
            }
            return Item;
        }
        public static Link SelectById(Int64 L_ID)
        {
            Link Item = new Link();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("L_ID", L_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Link(rd);
                }
            }
            return Item;
        }
        public static Link SelectById(Int64 L_ID, SqlConnection con)
        {
            Link Item = new Link();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("L_ID", L_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Link(rd);
                }
            }
            return Item;
        }
        public static Link SelectById(Int64 L_ID, SqlTransaction con)
        {
            Link Item = new Link();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("L_ID", L_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new Link(rd);
                }
            }
            return Item;
        }
        public static LinkCollection SelectAll()
        {
            LinkCollection List = new LinkCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new Link(rd));
                }
            }
            return List;
        }
        public static LinkCollection SelectAll(SqlConnection con)
        {
            LinkCollection List = new LinkCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new Link(rd));
                }
            }
            return List;
        }
        public static Pager<Link> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Link> pagerNormal(SqlConnection con, string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Link> pg = new Pager<Link>(con, "tblSeo_sp_tblSeoLink_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        #endregion
        #region Extend
        
        public static Pager<Link> pagerByUserChuaDuyet(string sort,int size,string username)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("username", username);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_Pager_pagerByUserChuaDuyet_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerByUserchoThanhToan(string sort, int size, string username)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("username", username);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_Pager_pagerByUserchoThanhToan_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerByUserchoThanhToan(SqlConnection con, int size, string username)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", "L_ID desc");
            obj[1] = new SqlParameter("username", username);
            Pager<Link> pg = new Pager<Link>(con, "tblSeo_sp_tblSeoLink_Pager_pagerByUserchoThanhToan_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerByUserchoThanhToan(SqlTransaction con, int size, string username)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", "L_ID desc");
            obj[1] = new SqlParameter("username", username);
            Pager<Link> pg = new Pager<Link>(con, "tblSeo_sp_tblSeoLink_Pager_pagerByUserchoThanhToan_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerByUserloi(string sort, int size, string username)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("username", username);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_Pager_pagerByUserloi_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerByUserdaThanhToan(string sort, int size, string username)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("username", username);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_pagerByUserdaThanhToan_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerByUserall(string sort, int size, string username)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("username", username);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_pagerByUserall_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }

        public static Pager<Link> pagerChuaDuyet(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_Pager_pagerChuaDuyet_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerchoThanhToan(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_Pager_pagerchoThanhToan_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerloi(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_Pager_pagerloi_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerdaThanhToan(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_pagerdaThanhToan_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerall(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_pagerall_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }

        public static bool ValidateUrl(string Url)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Url", Url);
            return Convert.ToBoolean(SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Select_ValidateUrl_linhnx", obj).ToString());
        }
        public static void DuyetMulti(string ID, string ok)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("ID", ID);
            obj[1] = new SqlParameter("ok", ok);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Update_DuyetMulti_linhnx", obj);
        }
        public static void ThanhToanMulti(string ID, string ok)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("ID", ID);
            obj[1] = new SqlParameter("ok", ok);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Update_ThanhToanMulti_linhnx", obj);
        }
        public static void XoaMulti(string ID, string ok)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ID", ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Delete_XoaMulti_linhnx", obj);
        }
        public static void UpdateThanhToan(SqlConnection con, string ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ID", ID);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Update_UpdateThanhToan_linhnx", obj);
        }
        public static void UpdateThanhToan(SqlTransaction con, string ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ID", ID);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Update_UpdateThanhToan_linhnx", obj);
        }
        public static void UpdateDuyet(SqlTransaction con, string ID,string ok)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("ID", ID);
            obj[1] = new SqlParameter("ok", ok);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoLink_Update_UpdateDuyet_linhnx", obj);
        }


        public static Pager<Link> pagerChuaDuyetByChienDich(string sort, int size, string CD_ID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("CD_ID", CD_ID);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_Pager_pagerChuaDuyetByChienDich_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<Link> pagerDaDuyetByChienDich(string sort, int size, string CD_ID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("CD_ID", CD_ID);
            Pager<Link> pg = new Pager<Link>("tblSeo_sp_tblSeoLink_Pager_pagerDaDuyetByChienDich_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        #endregion
    }
    #endregion
    #endregion
}


