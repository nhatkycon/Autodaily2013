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
    #region Files
    #region BO
    public class Files : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Guid PID { get; set; }
        public Int32 VB_ID { get; set; }
        public String Ten { get; set; }
        public String Path { get; set; }
        public DateTime NgayTao { get; set; }
        public String ThuMuc { get; set; }
        public Guid RowId { get; set; }
        public String NguoiTao { get; set; }
        public Int32 Size { get; set; }
        public String MimeType { get; set; }
        public Int32 Download { get; set; }
        #endregion
        #region Contructor
        public Files()
        { }
        public Files(IDataReader rd)
        {
            if (rd.FieldExists("F_ID"))
            {
                ID = (Int32)(rd["F_ID"]);
            }
            if (rd.FieldExists("F_PID"))
            {
                PID = (Guid)(rd["F_PID"]);
            }
            if (rd.FieldExists("F_VB_ID"))
            {
                VB_ID = (Int32)(rd["F_VB_ID"]);
            }
            if (rd.FieldExists("F_Ten"))
            {
                Ten = (String)(rd["F_Ten"]);
            }
            if (rd.FieldExists("F_Path"))
            {
                Path = (String)(rd["F_Path"]);
            }
            if (rd.FieldExists("F_NgayTao"))
            {
                NgayTao = (DateTime)(rd["F_NgayTao"]);
            }
            if (rd.FieldExists("F_ThuMuc"))
            {
                ThuMuc = (String)(rd["F_ThuMuc"]);
            }
            if (rd.FieldExists("F_RowId"))
            {
                RowId = (Guid)(rd["F_RowId"]);
            }
            if (rd.FieldExists("F_NguoiTao"))
            {
                NguoiTao = (String)(rd["F_NguoiTao"]);
            }
            if (rd.FieldExists("F_Size"))
            {
                Size = (Int32)(rd["F_Size"]);
            }
            if (rd.FieldExists("F_MimeType"))
            {
                MimeType = (String)(rd["F_MimeType"]);
            }
            if (rd.FieldExists("F_Download"))
            {
                Download = (Int32)(rd["F_Download"]);
            }

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return FilesDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class FilesCollection : BaseEntityCollection<Files>
    { }
    #endregion
    #region Dal
    public class FilesDal
    {
        #region Methods

        public static void DeleteById(Int32 F_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("F_ID", F_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblFiles_Delete_DeleteById_linhnx", obj);
        }

        public static Files Insert(Files Inserted)
        {
            Files Item = new Files();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("F_PID", Inserted.PID);
            obj[1] = new SqlParameter("F_VB_ID", Inserted.VB_ID);
            obj[2] = new SqlParameter("F_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("F_Path", Inserted.Path);
            obj[4] = new SqlParameter("F_NgayTao", Inserted.NgayTao);
            obj[5] = new SqlParameter("F_ThuMuc", Inserted.ThuMuc);
            obj[6] = new SqlParameter("F_RowId", Inserted.RowId);
            obj[7] = new SqlParameter("F_NguoiTao", Inserted.NguoiTao);
            obj[8] = new SqlParameter("F_Size", Inserted.Size);
            obj[9] = new SqlParameter("F_MimeType", Inserted.MimeType);
            obj[10] = new SqlParameter("F_Download", Inserted.Download);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFiles_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Files Update(Files Updated)
        {
            Files Item = new Files();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("F_ID", Updated.ID);
            obj[1] = new SqlParameter("F_PID", Updated.PID);
            obj[2] = new SqlParameter("F_VB_ID", Updated.VB_ID);
            obj[3] = new SqlParameter("F_Ten", Updated.Ten);
            obj[4] = new SqlParameter("F_Path", Updated.Path);
            obj[5] = new SqlParameter("F_NgayTao", Updated.NgayTao);
            obj[6] = new SqlParameter("F_ThuMuc", Updated.ThuMuc);
            obj[7] = new SqlParameter("F_RowId", Updated.RowId);
            obj[8] = new SqlParameter("F_NguoiTao", Updated.NguoiTao);
            obj[9] = new SqlParameter("F_Size", Updated.Size);
            obj[10] = new SqlParameter("F_MimeType", Updated.MimeType);
            obj[11] = new SqlParameter("F_Download", Updated.Download);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFiles_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Files SelectById(Int32 F_ID)
        {
            Files Item = new Files();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("F_ID", F_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFiles_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static FilesCollection SelectByPRowId(Guid F_PID)
        {
            FilesCollection List = new FilesCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("F_PID", F_PID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFiles_Select_SelectByPRowId_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(new Files(rd));
                }
            }
            return List;
        }

        public static FilesCollection SelectByPRowId(SqlConnection con,Guid F_PID, int Sobantin)
        {
            FilesCollection List = new FilesCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("F_PID", F_PID);
            obj[1] = new SqlParameter("Sobantin", Sobantin);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblFiles_Select_SelectByPRowId_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(new Files(rd));
                }
            }
            return List;
        }

        public static FilesCollection SelectByTinnhanID(SqlConnection con, Guid PH_ID)
        {
            FilesCollection List = new FilesCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PH_ID", PH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblFiles_Select_SelectByTinnhan_ductt", obj))
            {
                while (rd.Read())
                {
                    List.Add(new Files(rd));
                }
            }
            return List;
        }
        public static FilesCollection SelectAll()
        {
            FilesCollection List = new FilesCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFiles_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Files> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Files> pg = new Pager<Files>("sp_tblFiles_Pager_Normal_linhnx", "q", 2, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<Files> pagerNormal(string url, bool rewrite, string sort, string dambao, string active, string _q, string _nhomdn_id, string _tinh_id, string _ltv_id, string _ldn_id, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", _q);
            obj[2] = new SqlParameter("dambao", dambao);
            obj[7] = new SqlParameter("active", active);
            if (!string.IsNullOrEmpty(_ldn_id))
            {
                obj[3] = new SqlParameter("LDN_ID", _ldn_id);
            }
            else
            {
                obj[3] = new SqlParameter("LDN_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_ltv_id))
            {
                obj[4] = new SqlParameter("LTV_ID", _ltv_id);
            }
            else
            {
                obj[4] = new SqlParameter("LTV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_nhomdn_id))
            {
                obj[5] = new SqlParameter("NhomDN_ID", _nhomdn_id);
            }
            else
            {
                obj[5] = new SqlParameter("NhomDN_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(_tinh_id))
            {
                obj[6] = new SqlParameter("TINH_ID", _tinh_id);
            }
            else
            {
                obj[6] = new SqlParameter("TINH_ID", DBNull.Value);
            }



            Pager<Files> pg = new Pager<Files>("sp_tblGianHang_Pager_Normal_hiennb", "Page", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }

        #endregion
        #region Utilities
        public static Files getFromReader(IDataReader rd)
        {
            Files Item = new Files();
            Item.ID = (Int32)(rd["F_ID"]);
            Item.PID = (Guid)(rd["F_PID"]);
            Item.VB_ID = (Int32)(rd["F_VB_ID"]);
            Item.Ten = (String)(rd["F_Ten"]);
            Item.Path = (String)(rd["F_Path"]);
            Item.NgayTao = (DateTime)(rd["F_NgayTao"]);
            Item.ThuMuc = (String)(rd["F_ThuMuc"]);
            Item.RowId = (Guid)(rd["F_RowId"]);
            Item.NguoiTao = (String)(rd["F_NguoiTao"]);
            Item.Size = (Int32)(rd["F_Size"]);
            Item.MimeType = (String)(rd["F_MimeType"]);
            Item.Download = (Int32)(rd["F_Download"]);
            return Item;
        }
        #endregion
        #region Extend
        public static string formatItem(Files item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<li>");
            sb.Append("<ul>");
            sb.AppendFormat(@"<li><a href=""?ID={0}"">{0}</a></li><li>{1}</li>", item.ID, item.Ten);
            sb.Append("</ul>");
            sb.Append("</li>");
            return sb.ToString();
        }
        #endregion
    }
    #endregion

    #endregion	
}


