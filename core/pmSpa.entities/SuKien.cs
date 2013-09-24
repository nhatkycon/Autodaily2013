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
    #region SuKien
    #region BO
    public class SuKien : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid PID { get; set; }
        public Guid DM_ID { get; set; }
        public Guid KH_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String NhanVien { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public Boolean CaNgay { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean BoQua { get; set; }
        public Boolean Xoa { get; set; }
        #endregion
        #region Contructor
        public SuKien()
        { }
        #endregion
        #region Customs properties
        public String NhanVien_Ten { get; set; }
        public String DM_Ten { get; set; }
        public String KH_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SuKienDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SuKienCollection : BaseEntityCollection<SuKien>
    { }
    #endregion
    #region Dal
    public class SuKienDal
    {
        #region Methods

        public static void DeleteById(Guid SK_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SK_ID", SK_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Delete_DeleteById_linhnx", obj);
        }

        public static SuKien Insert(SuKien item)
        {
            var Item = new SuKien();
            var obj = new SqlParameter[16];
            obj[0] = new SqlParameter("SK_ID", item.ID);
            obj[1] = new SqlParameter("SK_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("SK_PID", item.PID);
            obj[3] = new SqlParameter("SK_KH_ID", item.KH_ID);
            obj[4] = new SqlParameter("SK_Ten", item.Ten);
            obj[5] = new SqlParameter("SK_MoTa", item.MoTa);
            obj[6] = new SqlParameter("SK_NhanVien", item.NhanVien);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("SK_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[7] = new SqlParameter("SK_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("SK_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[8] = new SqlParameter("SK_NgayKetThuc", DBNull.Value);
            }
            obj[9] = new SqlParameter("SK_CaNgay", item.CaNgay);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("SK_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("SK_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("SK_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("SK_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("SK_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("SK_NguoiCapNhat", item.NguoiCapNhat);
            obj[14] = new SqlParameter("SK_BoQua", item.BoQua);
            obj[15] = new SqlParameter("SK_Xoa", item.Xoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SuKien Update(SuKien item)
        {
            var Item = new SuKien();
            var obj = new SqlParameter[16];
            obj[0] = new SqlParameter("SK_ID", item.ID);
            obj[1] = new SqlParameter("SK_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("SK_PID", item.PID);
            obj[3] = new SqlParameter("SK_KH_ID", item.KH_ID);
            obj[4] = new SqlParameter("SK_Ten", item.Ten);
            obj[5] = new SqlParameter("SK_MoTa", item.MoTa);
            obj[6] = new SqlParameter("SK_NhanVien", item.NhanVien);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("SK_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[7] = new SqlParameter("SK_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("SK_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[8] = new SqlParameter("SK_NgayKetThuc", DBNull.Value);
            }
            obj[9] = new SqlParameter("SK_CaNgay", item.CaNgay);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("SK_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("SK_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("SK_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("SK_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("SK_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("SK_NguoiCapNhat", item.NguoiCapNhat);
            obj[14] = new SqlParameter("SK_BoQua", item.BoQua);
            obj[15] = new SqlParameter("SK_Xoa", item.Xoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SuKien SelectById(Guid SK_ID)
        {
            var Item = new SuKien();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SK_ID", SK_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SuKienCollection SelectAll()
        {
            var List = new SuKienCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<SuKien> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<SuKien>("sp_tblSpaMgr_SuKien_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static SuKien getFromReader(IDataReader rd)
        {
            var Item = new SuKien();
            if (rd.FieldExists("SK_ID"))
            {
                Item.ID = (Guid)(rd["SK_ID"]);
            }
            if (rd.FieldExists("SK_DM_ID"))
            {
                Item.DM_ID = (Guid)(rd["SK_DM_ID"]);
            }
            if (rd.FieldExists("SK_PID"))
            {
                Item.PID = (Guid)(rd["SK_PID"]);
            }
            if (rd.FieldExists("SK_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["SK_KH_ID"]);
            }
            if (rd.FieldExists("SK_Ten"))
            {
                Item.Ten = (String)(rd["SK_Ten"]);
            }
            if (rd.FieldExists("SK_MoTa"))
            {
                Item.MoTa = (String)(rd["SK_MoTa"]);
            }
            if (rd.FieldExists("SK_NhanVien"))
            {
                Item.NhanVien = (String)(rd["SK_NhanVien"]);
            }
            if (rd.FieldExists("SK_NgayBatDau"))
            {
                Item.NgayBatDau = (DateTime)(rd["SK_NgayBatDau"]);
            }
            if (rd.FieldExists("SK_NgayKetThuc"))
            {
                Item.NgayKetThuc = (DateTime)(rd["SK_NgayKetThuc"]);
            }
            if (rd.FieldExists("SK_CaNgay"))
            {
                Item.CaNgay = (Boolean)(rd["SK_CaNgay"]);
            }
            if (rd.FieldExists("SK_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["SK_NgayTao"]);
            }
            if (rd.FieldExists("SK_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["SK_NguoiTao"]);
            }
            if (rd.FieldExists("SK_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["SK_NgayCapNhat"]);
            }
            if (rd.FieldExists("SK_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["SK_NguoiCapNhat"]);
            }
            if (rd.FieldExists("SK_BoQua"))
            {
                Item.BoQua = (Boolean)(rd["SK_BoQua"]);
            }
            if (rd.FieldExists("SK_Xoa"))
            {
                Item.Xoa = (Boolean)(rd["SK_Xoa"]);
            }
            if (rd.FieldExists("SK_NhanVien_Ten"))
            {
                Item.NhanVien_Ten = (String)(rd["SK_NhanVien_Ten"]);
            }
            if (rd.FieldExists("SK_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["SK_DM_Ten"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["KH_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend

        public static SuKienCollection SelectUnXoa(SqlConnection con, string xoa, string top)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(xoa))
            {
                obj[0] = new SqlParameter("xoa", xoa);
            }
            else
            {
                obj[0] = new SqlParameter("xoa", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(top))
            {
                obj[1] = new SqlParameter("top", top);
            }
            else
            {
                obj[1] = new SqlParameter("top", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectUnXoa_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SuKienCollection SelectByKhId(SqlConnection con,string xoa, string top, string KH_ID)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(xoa))
            {
                obj[0] = new SqlParameter("xoa", xoa);
            }
            else
            {
                obj[0] = new SqlParameter("xoa", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(top))
            {
                obj[1] = new SqlParameter("top", top);
            }
            else
            {
                obj[1] = new SqlParameter("top", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(KH_ID))
            {
                obj[2] = new SqlParameter("KH_ID", KH_ID);
            }
            else
            {
                obj[2] = new SqlParameter("KH_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectByKhId_linhnx", obj))
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
