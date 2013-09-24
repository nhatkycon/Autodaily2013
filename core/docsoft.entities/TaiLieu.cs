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
using docsoft.entities;
namespace docsoft.entities
{
    #region TaiLieu
    #region BO
    public class TaiLieu : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public Int32 ThuTu { get; set; }
        public Int32 DM_ID { get; set; }
        public String DM_Ten { get; set; }
        public String Url { get; set; }
        public Guid RowId { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Boolean Draff { get; set; }
        public Int32 Views { get; set; }
        public String TacGia { get; set; }
        public String NhaXuatBan { get; set; }
        public String KichThuoc { get; set; }
        public String NgonNgu { get; set; }
        public String GiaBan { get; set; }
        public String Anh { get; set; }
        #endregion
        #region Contructor
        public TaiLieu()
        { }
        #endregion
        #region Customs properties
        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TaiLieuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TaiLieuCollection : BaseEntityCollection<TaiLieu>
    { }
    #endregion
    #region Dal
    public class TaiLieuDal
    {
        #region Methods

        public static void DeleteById(Int32 TL_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TL_ID", TL_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Delete_DeleteById_linhnx", obj);
        }

        public static TaiLieu Insert(TaiLieu Inserted)
        {
            TaiLieu Item = new TaiLieu();
            SqlParameter[] obj = new SqlParameter[18];
            obj[0] = new SqlParameter("TL_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("TL_ThuTu", Inserted.ThuTu);
            obj[2] = new SqlParameter("TL_DM_ID", Inserted.DM_ID);
            obj[3] = new SqlParameter("TL_DM_Ten", Inserted.DM_Ten);
            obj[4] = new SqlParameter("TL_Url", Inserted.Url);
            obj[5] = new SqlParameter("TL_RowId", Inserted.RowId);
            obj[6] = new SqlParameter("TL_NguoiTao", Inserted.NguoiTao);
            obj[7] = new SqlParameter("TL_NgayTao", Inserted.NgayTao);
            obj[8] = new SqlParameter("TL_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[9] = new SqlParameter("TL_NgayCapNhat", Inserted.NgayCapNhat);
            obj[10] = new SqlParameter("TL_Draff", Inserted.Draff);
            obj[11] = new SqlParameter("TL_Views", Inserted.Views);
            obj[12] = new SqlParameter("TL_TacGia", Inserted.TacGia);
            obj[13] = new SqlParameter("TL_NhaXuatBan", Inserted.NhaXuatBan);
            obj[14] = new SqlParameter("TL_KichThuoc", Inserted.KichThuoc);
            obj[15] = new SqlParameter("TL_NgonNgu", Inserted.NgonNgu);
            obj[16] = new SqlParameter("TL_GiaBan", Inserted.GiaBan);
            obj[17] = new SqlParameter("TL_Anh", Inserted.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieu Update(TaiLieu Updated)
        {
            TaiLieu Item = new TaiLieu();
            SqlParameter[] obj = new SqlParameter[19];
            obj[0] = new SqlParameter("TL_ID", Updated.ID);
            obj[1] = new SqlParameter("TL_Ten", Updated.Ten);
            obj[2] = new SqlParameter("TL_ThuTu", Updated.ThuTu);
            obj[3] = new SqlParameter("TL_DM_ID", Updated.DM_ID);
            obj[4] = new SqlParameter("TL_DM_Ten", Updated.DM_Ten);
            obj[5] = new SqlParameter("TL_Url", Updated.Url);
            obj[6] = new SqlParameter("TL_RowId", Updated.RowId);
            obj[7] = new SqlParameter("TL_NguoiTao", Updated.NguoiTao);
            obj[8] = new SqlParameter("TL_NgayTao", Updated.NgayTao);
            obj[9] = new SqlParameter("TL_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[10] = new SqlParameter("TL_NgayCapNhat", Updated.NgayCapNhat);
            obj[11] = new SqlParameter("TL_Draff", Updated.Draff);
            obj[12] = new SqlParameter("TL_Views", Updated.Views);
            obj[13] = new SqlParameter("TL_TacGia", Updated.TacGia);
            obj[14] = new SqlParameter("TL_NhaXuatBan", Updated.NhaXuatBan);
            obj[15] = new SqlParameter("TL_KichThuoc", Updated.KichThuoc);
            obj[16] = new SqlParameter("TL_NgonNgu", Updated.NgonNgu);
            obj[17] = new SqlParameter("TL_GiaBan", Updated.GiaBan);
            obj[18] = new SqlParameter("TL_Anh", Updated.Anh);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieu SelectById(Int32 TL_ID)
        {
            TaiLieu Item = new TaiLieu();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TL_ID", TL_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieuCollection SelectAll()
        {
            TaiLieuCollection List = new TaiLieuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static Pager<TaiLieu> pagerNormal(string url, bool rewrite, string sort, string q, string dm)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            Pager<TaiLieu> pg = new Pager<TaiLieu>("sp_tblTaiLieu_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TaiLieu getFromReader(IDataReader rd)
        {
            TaiLieu Item = new TaiLieu();
            if (rd.FieldExists("TL_ID"))
            {
                Item.ID = (Int32)(rd["TL_ID"]);
            }
            if (rd.FieldExists("TL_Ten"))
            {
                Item.Ten = (String)(rd["TL_Ten"]);
            }
            if (rd.FieldExists("TL_Anh"))
            {
                Item.Anh = (String)(rd["TL_Anh"]);
            }
            if (rd.FieldExists("TL_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TL_ThuTu"]);
            }
            if (rd.FieldExists("TL_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["TL_DM_ID"]);
            }
            if (rd.FieldExists("TL_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["TL_DM_Ten"]);
            }
            if (rd.FieldExists("TL_Url"))
            {
                Item.Url = (String)(rd["TL_Url"]);
            }
            if (rd.FieldExists("TL_RowId"))
            {
                Item.RowId = (Guid)(rd["TL_RowId"]);
            }
            if (rd.FieldExists("TL_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TL_NguoiTao"]);
            }
            if (rd.FieldExists("TL_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TL_NgayTao"]);
            }
            if (rd.FieldExists("TL_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TL_NguoiCapNhat"]);
            }
            if (rd.FieldExists("TL_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TL_NgayCapNhat"]);
            }
            if (rd.FieldExists("TL_TacGia"))
            {
                Item.TacGia = (String)(rd["TL_TacGia"]);
            }
            if (rd.FieldExists("TL_NhaXuatBan"))
            {
                Item.NhaXuatBan = (String)(rd["TL_NhaXuatBan"]);
            }
            if (rd.FieldExists("TL_NgonNgu"))
            {
                Item.NgonNgu = (String)(rd["TL_NgonNgu"]);
            }
            if (rd.FieldExists("TL_GiaBan"))
            {
                Item.GiaBan = (String)(rd["TL_GiaBan"]);
            }
            if (rd.FieldExists("TL_KichThuoc"))
            {
                Item.KichThuoc = (String)(rd["TL_KichThuoc"]);
            }
            if (rd.FieldExists("TL_Views"))
            {
                Item.Views = (Int32)(rd["TL_Views"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteMultiById(String TL_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TL_ID", TL_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Delete_DeleteMultiById_hungpm", obj);
        }

        public static TaiLieu InsertDraff(TaiLieu Inserted)
        {
            TaiLieu Item = new TaiLieu();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("TL_RowId", Inserted.RowId);
            obj[1] = new SqlParameter("TL_NguoiTao", Inserted.NguoiTao);
            obj[2] = new SqlParameter("TL_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[3] = new SqlParameter("TL_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("TL_NgayCapNhat", Inserted.NgayCapNhat);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Insert_InsertDraff_hungpm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieu SelectByIdView(Int32 VBD_ID)
        {
            TaiLieu Item = new TaiLieu();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TL_ID", VBD_ID);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Select_SelectByIdView_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    Files item = new Files();
                    if (rd.FieldExists("F_Ten"))
                    {
                        item.Ten = (String)(rd["F_Ten"]);
                    }

                    if (rd.FieldExists("F_ID"))
                    {
                        item.ID = (Int32)(rd["F_ID"]);
                    }
                    if (rd.FieldExists("F_NguoiTao"))
                    {
                        item.NguoiTao = (String)(rd["F_NguoiTao"]);
                    }
                    if (rd.FieldExists("F_Size"))
                    {
                        item.Size = (Int32)(rd["F_Size"]);
                    }
                    if (rd.FieldExists("F_MimeType"))
                    {
                        item.MimeType = (String)(rd["F_MimeType"]);
                    }
                    if (rd.FieldExists("F_Download"))
                    {
                        item.Download = (Int32)(rd["F_Download"]);
                    }
                    filelist.Add(item);
                }
            }
            Item.Filelist = filelist;
            return Item;
        }

        public static TaiLieuCollection SelectTop(int Top)
        {
            TaiLieuCollection List = new TaiLieuCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Select_SelectTop_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static TaiLieuCollection SelectTop(int Top, string sOrder)
        {
            TaiLieuCollection List = new TaiLieuCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Order", sOrder);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Select_SelectTopOrder_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static TaiLieuCollection SelectByDanhMuc(string DM_ID, int Top)
        {
            TaiLieuCollection List = new TaiLieuCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            obj[2] = new SqlParameter("TL_ID", DBNull.Value);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Select_SelectByDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static TaiLieuCollection SelectByDanhMuc(string DM_ID, int Top, string TL_ID)
        {
            TaiLieuCollection List = new TaiLieuCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            obj[2] = new SqlParameter("TL_ID", TL_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieu_Select_SelectByDanhMuc_linhnx", obj))
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
