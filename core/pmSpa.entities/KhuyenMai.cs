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
    #region KhuyenMai
    #region BO
    public class KhuyenMai : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String Ma { get; set; }
        public String NoiDung { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public Int32 SoLuong { get; set; }
        public Double ChietKhau { get; set; }
        public Double TienChietKhau { get; set; }
        public Boolean Active { get; set; }
        public Int32 ThuTu { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        #endregion
        #region Contructor
        public KhuyenMai()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return KhuyenMaiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class KhuyenMaiCollection : BaseEntityCollection<KhuyenMai>
    { }
    #endregion
    #region Dal
    public class KhuyenMaiDal
    {
        #region Methods

        public static void DeleteById(Guid KM_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KM_ID", KM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhuyenMai_Delete_DeleteById_linhnx", obj);
        }

        public static KhuyenMai Insert(KhuyenMai item)
        {
            var Item = new KhuyenMai();
            var obj = new SqlParameter[16];
            obj[0] = new SqlParameter("KM_ID", item.ID);
            obj[1] = new SqlParameter("KM_Ten", item.Ten);
            obj[2] = new SqlParameter("KM_MoTa", item.MoTa);
            obj[3] = new SqlParameter("KM_Ma", item.Ma);
            obj[4] = new SqlParameter("KM_NoiDung", item.NoiDung);
            if (item.TuNgay > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("KM_TuNgay", item.TuNgay);
            }
            else
            {
                obj[5] = new SqlParameter("KM_TuNgay", DBNull.Value);
            }
            if (item.DenNgay > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("KM_DenNgay", item.DenNgay);
            }
            else
            {
                obj[6] = new SqlParameter("KM_DenNgay", DBNull.Value);
            }
            obj[7] = new SqlParameter("KM_SoLuong", item.SoLuong);
            obj[8] = new SqlParameter("KM_ChietKhau", item.ChietKhau);
            obj[9] = new SqlParameter("KM_TienChietKhau", item.TienChietKhau);
            obj[10] = new SqlParameter("KM_Active", item.Active);
            obj[11] = new SqlParameter("KM_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("KM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("KM_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("KM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("KM_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("KM_NguoiTao", item.NguoiTao);
            obj[15] = new SqlParameter("KM_NguoiCapNhat", item.NguoiCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhuyenMai_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KhuyenMai Update(KhuyenMai item)
        {
            var Item = new KhuyenMai();
            var obj = new SqlParameter[16];
            obj[0] = new SqlParameter("KM_ID", item.ID);
            obj[1] = new SqlParameter("KM_Ten", item.Ten);
            obj[2] = new SqlParameter("KM_MoTa", item.MoTa);
            obj[3] = new SqlParameter("KM_Ma", item.Ma);
            obj[4] = new SqlParameter("KM_NoiDung", item.NoiDung);
            if (item.TuNgay > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("KM_TuNgay", item.TuNgay);
            }
            else
            {
                obj[5] = new SqlParameter("KM_TuNgay", DBNull.Value);
            }
            if (item.DenNgay > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("KM_DenNgay", item.DenNgay);
            }
            else
            {
                obj[6] = new SqlParameter("KM_DenNgay", DBNull.Value);
            }
            obj[7] = new SqlParameter("KM_SoLuong", item.SoLuong);
            obj[8] = new SqlParameter("KM_ChietKhau", item.ChietKhau);
            obj[9] = new SqlParameter("KM_TienChietKhau", item.TienChietKhau);
            obj[10] = new SqlParameter("KM_Active", item.Active);
            obj[11] = new SqlParameter("KM_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("KM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("KM_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("KM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("KM_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("KM_NguoiTao", item.NguoiTao);
            obj[15] = new SqlParameter("KM_NguoiCapNhat", item.NguoiCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhuyenMai_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KhuyenMai SelectById(Guid KM_ID)
        {
            var Item = new KhuyenMai();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KM_ID", KM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhuyenMai_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KhuyenMaiCollection SelectAll()
        {
            var List = new KhuyenMaiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_KhuyenMai_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<KhuyenMai> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<KhuyenMai>("sp_tblSpaMgr_KhuyenMai_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static KhuyenMai getFromReader(IDataReader rd)
        {
            var Item = new KhuyenMai();
            if (rd.FieldExists("KM_ID"))
            {
                Item.ID = (Guid)(rd["KM_ID"]);
            }
            if (rd.FieldExists("KM_Ten"))
            {
                Item.Ten = (String)(rd["KM_Ten"]);
            }
            if (rd.FieldExists("KM_MoTa"))
            {
                Item.MoTa = (String)(rd["KM_MoTa"]);
            }
            if (rd.FieldExists("KM_Ma"))
            {
                Item.Ma = (String)(rd["KM_Ma"]);
            }
            if (rd.FieldExists("KM_NoiDung"))
            {
                Item.NoiDung = (String)(rd["KM_NoiDung"]);
            }
            if (rd.FieldExists("KM_TuNgay"))
            {
                Item.TuNgay = (DateTime)(rd["KM_TuNgay"]);
            }
            if (rd.FieldExists("KM_DenNgay"))
            {
                Item.DenNgay = (DateTime)(rd["KM_DenNgay"]);
            }
            if (rd.FieldExists("KM_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["KM_SoLuong"]);
            }
            if (rd.FieldExists("KM_ChietKhau"))
            {
                Item.ChietKhau = (Double)(rd["KM_ChietKhau"]);
            }
            if (rd.FieldExists("KM_TienChietKhau"))
            {
                Item.TienChietKhau = (Double)(rd["KM_TienChietKhau"]);
            }
            if (rd.FieldExists("KM_Active"))
            {
                Item.Active = (Boolean)(rd["KM_Active"]);
            }
            if (rd.FieldExists("KM_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["KM_ThuTu"]);
            }
            if (rd.FieldExists("KM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["KM_NgayTao"]);
            }
            if (rd.FieldExists("KM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["KM_NgayCapNhat"]);
            }
            if (rd.FieldExists("KM_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["KM_NguoiTao"]);
            }
            if (rd.FieldExists("KM_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["KM_NguoiCapNhat"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static KhuyenMaiCollection SelectActive(SqlConnection con, string Active)
        {
            var List = new KhuyenMaiCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(Active))
            {
                obj[0] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[0] = new SqlParameter("Active", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_KhuyenMai_Select_SelectActive_linhnx"))
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
