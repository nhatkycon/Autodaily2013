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
    #region TaiKhoan
    #region BO
    public class TaiKhoan : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Username { get; set; }
        public String Tk { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public DateTime NgayTao { get; set; }
        public String ThongTin { get; set; }
        #endregion
        #region Contructor
        public TaiKhoan()
        { }
        public TaiKhoan(IDataReader rd)
        {
            if (rd.FieldExists("SD_ID"))
            {
                ID = (Int32)(rd["SD_ID"]);
            }
            if (rd.FieldExists("SD_Username"))
            {
                Username = (String)(rd["SD_Username"]);
            }
            if (rd.FieldExists("SD_Tk"))
            {
                Tk = (String)(rd["SD_Tk"]);
            }
            if (rd.FieldExists("SD_NgayCapNhat"))
            {
                NgayCapNhat = (DateTime)(rd["SD_NgayCapNhat"]);
            }
            if (rd.FieldExists("SD_NgayTao"))
            {
                NgayTao = (DateTime)(rd["SD_NgayTao"]);
            }
            if (rd.FieldExists("SD_ThongTin"))
            {
                ThongTin = (String)(rd["SD_ThongTin"]);
            }
        }
        #endregion
        #region Customs properties

        #endregion
        #region getFromReader
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return new TaiKhoan(rd);
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
    public class TaiKhoanCollection : BaseEntityCollection<TaiKhoan>
    { }
    #endregion
    #region Dal
    public class TaiKhoanDal
    {
        #region Methods

        public static void DeleteById(Int32 SD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SD_ID", SD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSeoTaiKhoan_Delete_DeleteById_linhnx", obj);
        }
        public static TaiKhoan Insert(TaiKhoan Inserted)
        {
            TaiKhoan Item = new TaiKhoan();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("SD_Username", Inserted.Username);
            obj[1] = new SqlParameter("SD_Tk", Inserted.Tk);
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("SD_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[2] = new SqlParameter("SD_NgayCapNhat", DBNull.Value);
            }
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("SD_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("SD_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("SD_ThongTin", Inserted.ThongTin);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSeoTaiKhoan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new TaiKhoan(rd);
                }
            }
            return Item;
        }
        public static TaiKhoan Insert(TaiKhoan Inserted, SqlConnection con)
        {
            TaiKhoan Item = new TaiKhoan();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("SD_Username", Inserted.Username);
            obj[1] = new SqlParameter("SD_Tk", Inserted.Tk);
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("SD_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[2] = new SqlParameter("SD_NgayCapNhat", DBNull.Value);
            }
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("SD_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("SD_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("SD_ThongTin", Inserted.ThongTin);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new TaiKhoan(rd);
                }
            }
            return Item;
        }
        public static TaiKhoan Update(TaiKhoan Updated)
        {
            TaiKhoan Item = new TaiKhoan();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("SD_ID", Updated.ID);
            obj[1] = new SqlParameter("SD_Username", Updated.Username);
            obj[2] = new SqlParameter("SD_Tk", Updated.Tk);
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("SD_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[3] = new SqlParameter("SD_NgayCapNhat", DBNull.Value);
            }
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("SD_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("SD_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("SD_ThongTin", Updated.ThongTin);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new TaiKhoan(rd);
                }
            }
            return Item;
        }
        public static TaiKhoan Update(TaiKhoan Updated, SqlConnection con)
        {
            TaiKhoan Item = new TaiKhoan();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("SD_ID", Updated.ID);
            obj[1] = new SqlParameter("SD_Username", Updated.Username);
            obj[2] = new SqlParameter("SD_Tk", Updated.Tk);
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("SD_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[3] = new SqlParameter("SD_NgayCapNhat", DBNull.Value);
            }
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("SD_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("SD_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("SD_ThongTin", Updated.ThongTin);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new TaiKhoan(rd);
                }
            }
            return Item;
        }
        public static TaiKhoan SelectById(Int32 SD_ID)
        {
            TaiKhoan Item = new TaiKhoan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SD_ID", SD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new TaiKhoan(rd);
                }
            }
            return Item;
        }
        public static TaiKhoan SelectById(Int32 SD_ID, SqlConnection con)
        {
            TaiKhoan Item = new TaiKhoan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SD_ID", SD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new TaiKhoan(rd);
                }
            }
            return Item;
        }
        public static TaiKhoanCollection SelectAll()
        {
            TaiKhoanCollection List = new TaiKhoanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new TaiKhoan(rd));
                }
            }
            return List;
        }
        public static TaiKhoanCollection SelectAll(SqlConnection con)
        {
            TaiKhoanCollection List = new TaiKhoanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new TaiKhoan(rd));
                }
            }
            return List;
        }
        public static Pager<TaiKhoan> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TaiKhoan> pg = new Pager<TaiKhoan>("tblSeo_sp_tblSeoTaiKhoan_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<TaiKhoan> pagerNormal(SqlConnection con, string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TaiKhoan> pg = new Pager<TaiKhoan>(con, "tblSeo_sp_tblSeoTaiKhoan_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        #endregion
        #region Extend
        public static void UpdateTk(Int32 SD_ID, string Tk)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("SD_ID", SD_ID);
            obj[1] = new SqlParameter("Tk", Tk);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Update_UpdateTk_linhnx", obj);
        }
        public static TaiKhoan SelectByUsername(string Username, SqlConnection con)
        {
            TaiKhoan Item = new TaiKhoan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Select_SelectByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new TaiKhoan(rd);
                }
            }
            return Item;
        }
        public static TaiKhoan SelectByUsername(string Username, SqlTransaction con)
        {
            TaiKhoan Item = new TaiKhoan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Select_SelectByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new TaiKhoan(rd);
                }
            }
            return Item;
        }
        public static void UpdateTk(Int32 SD_ID, string Tk, SqlTransaction con)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("SD_ID", SD_ID);
            obj[1] = new SqlParameter("Tk", Tk);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoTaiKhoan_Update_UpdateTk_linhnx", obj);
        }

        public static void UpdateThongTinByUser(TaiKhoan Updated)
        {
            var obj = new SqlParameter[2];
            obj[1] = new SqlParameter("SD_Username", Updated.Username);
            obj[0] = new SqlParameter("SD_ThongTin", Updated.ThongTin);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure,
                                      "tblSeo_sp_tblSeoTaiKhoan_Update_UpdateThongTinByUser_linhnx", obj);
        }
        #endregion
    }
    #endregion
    #endregion
}


