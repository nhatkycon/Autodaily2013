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
    #region ThanhToan
    #region BO
    public class ThanhToan : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String NguoiYeuCau { get; set; }
        public Int32 SoDu { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Duyet { get; set; }
        public Boolean DaChuyenTien { get; set; }
        public Boolean DaNhanTien { get; set; }
        public DateTime NgayChuyenTien { get; set; }
        public DateTime NgayNhanTien { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public ThanhToan()
        { }
        public ThanhToan(IDataReader rd)
        {
            if (rd.FieldExists("T_ID"))
            {
                ID = (Int32)(rd["T_ID"]);
            }
            if (rd.FieldExists("T_NguoiYeuCau"))
            {
                NguoiYeuCau = (String)(rd["T_NguoiYeuCau"]);
            }
            if (rd.FieldExists("T_SoDu"))
            {
                SoDu = (Int32)(rd["T_SoDu"]);
            }
            if (rd.FieldExists("T_NgayTao"))
            {
                NgayTao = (DateTime)(rd["T_NgayTao"]);
            }
            if (rd.FieldExists("T_Duyet"))
            {
                Duyet = (Boolean)(rd["T_Duyet"]);
            }
            if (rd.FieldExists("T_DaChuyenTien"))
            {
                DaChuyenTien = (Boolean)(rd["T_DaChuyenTien"]);
            }
            if (rd.FieldExists("T_DaNhanTien"))
            {
                DaNhanTien = (Boolean)(rd["T_DaNhanTien"]);
            }
            if (rd.FieldExists("T_NgayChuyenTien"))
            {
                NgayChuyenTien = (DateTime)(rd["T_NgayChuyenTien"]);
            }
            if (rd.FieldExists("T_NgayNhanTien"))
            {
                NgayNhanTien = (DateTime)(rd["T_NgayNhanTien"]);
            }
            if (rd.FieldExists("T_RowId"))
            {
                RowId = (Guid)(rd["T_RowId"]);
            }

        }
        #endregion
        #region Customs properties

        #endregion
        #region getFromReader
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return new ThanhToan(rd);
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
    public class ThanhToanCollection : BaseEntityCollection<ThanhToan>
    { }
    #endregion
    #region Dal
    public class ThanhToanDal
    {
        #region Methods

        public static void DeleteById(Int32 T_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSeoThanhToan_Delete_DeleteById_linhnx", obj);
        }
        public static ThanhToan Insert(ThanhToan Inserted)
        {
            ThanhToan Item = new ThanhToan();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("T_NguoiYeuCau", Inserted.NguoiYeuCau);
            obj[1] = new SqlParameter("T_SoDu", Inserted.SoDu);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("T_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[2] = new SqlParameter("T_NgayTao", DBNull.Value);
            }
            obj[3] = new SqlParameter("T_Duyet", Inserted.Duyet);
            obj[4] = new SqlParameter("T_DaChuyenTien", Inserted.DaChuyenTien);
            obj[5] = new SqlParameter("T_DaNhanTien", Inserted.DaNhanTien);
            if (Inserted.NgayChuyenTien > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("T_NgayChuyenTien", Inserted.NgayChuyenTien);
            }
            else
            {
                obj[6] = new SqlParameter("T_NgayChuyenTien", DBNull.Value);
            }
            if (Inserted.NgayNhanTien > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("T_NgayNhanTien", Inserted.NgayNhanTien);
            }
            else
            {
                obj[7] = new SqlParameter("T_NgayNhanTien", DBNull.Value);
            }
            obj[8] = new SqlParameter("T_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSeoThanhToan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ThanhToan(rd);
                }
            }
            return Item;
        }
        public static ThanhToan Insert(ThanhToan Inserted, SqlConnection con)
        {
            ThanhToan Item = new ThanhToan();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("T_NguoiYeuCau", Inserted.NguoiYeuCau);
            obj[1] = new SqlParameter("T_SoDu", Inserted.SoDu);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("T_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[2] = new SqlParameter("T_NgayTao", DBNull.Value);
            }
            obj[3] = new SqlParameter("T_Duyet", Inserted.Duyet);
            obj[4] = new SqlParameter("T_DaChuyenTien", Inserted.DaChuyenTien);
            obj[5] = new SqlParameter("T_DaNhanTien", Inserted.DaNhanTien);
            if (Inserted.NgayChuyenTien > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("T_NgayChuyenTien", Inserted.NgayChuyenTien);
            }
            else
            {
                obj[6] = new SqlParameter("T_NgayChuyenTien", DBNull.Value);
            }
            if (Inserted.NgayNhanTien > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("T_NgayNhanTien", Inserted.NgayNhanTien);
            }
            else
            {
                obj[7] = new SqlParameter("T_NgayNhanTien", DBNull.Value);
            }
            obj[8] = new SqlParameter("T_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblSeoThanhToan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ThanhToan(rd);
                }
            }
            return Item;
        }
        public static ThanhToan Update(ThanhToan Updated)
        {
            ThanhToan Item = new ThanhToan();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("T_ID", Updated.ID);
            obj[1] = new SqlParameter("T_NguoiYeuCau", Updated.NguoiYeuCau);
            obj[2] = new SqlParameter("T_SoDu", Updated.SoDu);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("T_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("T_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("T_Duyet", Updated.Duyet);
            obj[5] = new SqlParameter("T_DaChuyenTien", Updated.DaChuyenTien);
            obj[6] = new SqlParameter("T_DaNhanTien", Updated.DaNhanTien);
            if (Updated.NgayChuyenTien > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("T_NgayChuyenTien", Updated.NgayChuyenTien);
            }
            else
            {
                obj[7] = new SqlParameter("T_NgayChuyenTien", DBNull.Value);
            }
            if (Updated.NgayNhanTien > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("T_NgayNhanTien", Updated.NgayNhanTien);
            }
            else
            {
                obj[8] = new SqlParameter("T_NgayNhanTien", DBNull.Value);
            }
            obj[9] = new SqlParameter("T_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSeoThanhToan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ThanhToan(rd);
                }
            }
            return Item;
        }
        public static ThanhToan Update(ThanhToan Updated, SqlConnection con)
        {
            ThanhToan Item = new ThanhToan();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("T_ID", Updated.ID);
            obj[1] = new SqlParameter("T_NguoiYeuCau", Updated.NguoiYeuCau);
            obj[2] = new SqlParameter("T_SoDu", Updated.SoDu);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("T_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("T_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("T_Duyet", Updated.Duyet);
            obj[5] = new SqlParameter("T_DaChuyenTien", Updated.DaChuyenTien);
            obj[6] = new SqlParameter("T_DaNhanTien", Updated.DaNhanTien);
            if (Updated.NgayChuyenTien > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("T_NgayChuyenTien", Updated.NgayChuyenTien);
            }
            else
            {
                obj[7] = new SqlParameter("T_NgayChuyenTien", DBNull.Value);
            }
            if (Updated.NgayNhanTien > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("T_NgayNhanTien", Updated.NgayNhanTien);
            }
            else
            {
                obj[8] = new SqlParameter("T_NgayNhanTien", DBNull.Value);
            }
            obj[9] = new SqlParameter("T_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblSeoThanhToan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ThanhToan(rd);
                }
            }
            return Item;
        }
        public static ThanhToan SelectById(Int32 T_ID)
        {
            ThanhToan Item = new ThanhToan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSeoThanhToan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ThanhToan(rd);
                }
            }
            return Item;
        }
        public static ThanhToan SelectById(Int32 T_ID, SqlConnection con)
        {
            ThanhToan Item = new ThanhToan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoThanhToan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ThanhToan(rd);
                }
            }
            return Item;
        }
        public static ThanhToanCollection SelectAll()
        {
            ThanhToanCollection List = new ThanhToanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblSeo_sp_tblSeoThanhToan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new ThanhToan(rd));
                }
            }
            return List;
        }
        public static ThanhToanCollection SelectAll(SqlConnection con)
        {
            ThanhToanCollection List = new ThanhToanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblSeo_sp_tblSeoThanhToan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new ThanhToan(rd));
                }
            }
            return List;
        }
        public static Pager<ThanhToan> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<ThanhToan> pg = new Pager<ThanhToan>("tblSeo_sp_tblSeoThanhToan_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<ThanhToan> pagerNormal(SqlConnection con, string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<ThanhToan> pg = new Pager<ThanhToan>(con, "tblSeo_sp_tblSeoThanhToan_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        #endregion
        #region Extend
        public static Pager<ThanhToan> pagerByUser(string sort, int size,string username)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("username", username);
            Pager<ThanhToan> pg = new Pager<ThanhToan>("tblSeo_sp_tblSeoThanhToan_Pager_pagerByUser_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<ThanhToan> pagerYeuCau(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<ThanhToan> pg = new Pager<ThanhToan>("tblSeo_sp_tblSeoThanhToan_Pager_pagerYeuCau_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<ThanhToan> pagerdaThanhToan(string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<ThanhToan> pg = new Pager<ThanhToan>("tblSeo_sp_tblSeoThanhToan_Pager_pagerdaThanhToan_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static void Duyet(string ID, string ok,  SqlTransaction con)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("ID", ID);
            obj[1] = new SqlParameter("ok", ok);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "tbl_sp_tblSeoThanhToan_Update_Duyet_linhnx", obj);
        }
        public static ThanhToan SelectById(Int32 T_ID,SqlTransaction con)
        {
            ThanhToan Item = new ThanhToan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblSeoThanhToan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new ThanhToan(rd);
                }
            }
            return Item;
        }
        #endregion
    }
    #endregion
    #endregion
}


