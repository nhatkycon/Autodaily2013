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
    #region TheKhuyenMai
    #region BO
    public class TheKhuyenMai : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid KM_ID { get; set; }
        public String Ma { get; set; }
        public Guid KH_ID { get; set; }
        public Guid DVTC_ID { get; set; }
        public Double GiaNY { get; set; }
        public Double Gia { get; set; }
        public DateTime HanSuDung { get; set; }
        public DateTime HanDoiThe { get; set; }
        public Boolean TinhTrang { get; set; }
        public Guid DV_ID { get; set; }
        public DateTime NgayPhatHanh { get; set; }
        public DateTime NgayNhan { get; set; }
        public String NguoiNhan { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean DaDung { get; set; }
        #endregion
        #region Contructor
        public TheKhuyenMai()
        { }
        #endregion
        #region Customs properties
        public String KM_Ten { get; set; }
        public String KH_Ten { get; set; }
        public String DV_Ten { get; set; }
        public String DVTC_Ten { get; set; }
        public String NguoiNhan_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TheKhuyenMaiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TheKhuyenMaiCollection : BaseEntityCollection<TheKhuyenMai>
    { }
    #endregion
    #region Dal
    public class TheKhuyenMaiDal
    {
        #region Methods

        public static void DeleteById(Guid TKM_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TKM_ID", TKM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TheKhuyenMai_Delete_DeleteById_linhnx", obj);
        }

        public static TheKhuyenMai Insert(TheKhuyenMai item)
        {
            var Item = new TheKhuyenMai();
            var obj = new SqlParameter[19];
            obj[0] = new SqlParameter("TKM_ID", item.ID);
            obj[1] = new SqlParameter("TKM_KM_ID", item.KM_ID);
            obj[2] = new SqlParameter("TKM_Ma", item.Ma);
            obj[3] = new SqlParameter("TKM_KH_ID", item.KH_ID);
            obj[4] = new SqlParameter("TKM_DVTC_ID", item.DVTC_ID);
            obj[5] = new SqlParameter("TKM_GiaNY", item.GiaNY);
            obj[6] = new SqlParameter("TKM_Gia", item.Gia);
            if (item.HanSuDung > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TKM_HanSuDung", item.HanSuDung);
            }
            else
            {
                obj[7] = new SqlParameter("TKM_HanSuDung", DBNull.Value);
            }
            if (item.HanDoiThe > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TKM_HanDoiThe", item.HanDoiThe);
            }
            else
            {
                obj[8] = new SqlParameter("TKM_HanDoiThe", DBNull.Value);
            }
            obj[9] = new SqlParameter("TKM_TinhTrang", item.TinhTrang);
            obj[10] = new SqlParameter("TKM_DV_ID", item.DV_ID);
            if (item.NgayPhatHanh > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("TKM_NgayPhatHanh", item.NgayPhatHanh);
            }
            else
            {
                obj[11] = new SqlParameter("TKM_NgayPhatHanh", DBNull.Value);
            }
            if (item.NgayNhan > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("TKM_NgayNhan", item.NgayNhan);
            }
            else
            {
                obj[12] = new SqlParameter("TKM_NgayNhan", DBNull.Value);
            }
            obj[13] = new SqlParameter("TKM_NguoiNhan", item.NguoiNhan);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("TKM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[14] = new SqlParameter("TKM_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("TKM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[15] = new SqlParameter("TKM_NgayCapNhat", DBNull.Value);
            }
            obj[16] = new SqlParameter("TKM_NguoiTao", item.NguoiTao);
            obj[17] = new SqlParameter("TKM_NguoiCapNhat", item.NguoiCapNhat);
            obj[18] = new SqlParameter("TKM_DaDung", item.DaDung);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TheKhuyenMai_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TheKhuyenMai Update(TheKhuyenMai item)
        {
            var Item = new TheKhuyenMai();
            var obj = new SqlParameter[19];
            obj[0] = new SqlParameter("TKM_ID", item.ID);
            obj[1] = new SqlParameter("TKM_KM_ID", item.KM_ID);
            obj[2] = new SqlParameter("TKM_Ma", item.Ma);
            obj[3] = new SqlParameter("TKM_KH_ID", item.KH_ID);
            obj[4] = new SqlParameter("TKM_DVTC_ID", item.DVTC_ID);
            obj[5] = new SqlParameter("TKM_GiaNY", item.GiaNY);
            obj[6] = new SqlParameter("TKM_Gia", item.Gia);
            if (item.HanSuDung > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("TKM_HanSuDung", item.HanSuDung);
            }
            else
            {
                obj[7] = new SqlParameter("TKM_HanSuDung", DBNull.Value);
            }
            if (item.HanDoiThe > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TKM_HanDoiThe", item.HanDoiThe);
            }
            else
            {
                obj[8] = new SqlParameter("TKM_HanDoiThe", DBNull.Value);
            }
            obj[9] = new SqlParameter("TKM_TinhTrang", item.TinhTrang);
            obj[10] = new SqlParameter("TKM_DV_ID", item.DV_ID);
            if (item.NgayPhatHanh > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("TKM_NgayPhatHanh", item.NgayPhatHanh);
            }
            else
            {
                obj[11] = new SqlParameter("TKM_NgayPhatHanh", DBNull.Value);
            }
            if (item.NgayNhan > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("TKM_NgayNhan", item.NgayNhan);
            }
            else
            {
                obj[12] = new SqlParameter("TKM_NgayNhan", DBNull.Value);
            }
            obj[13] = new SqlParameter("TKM_NguoiNhan", item.NguoiNhan);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("TKM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[14] = new SqlParameter("TKM_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("TKM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[15] = new SqlParameter("TKM_NgayCapNhat", DBNull.Value);
            }
            obj[16] = new SqlParameter("TKM_NguoiTao", item.NguoiTao);
            obj[17] = new SqlParameter("TKM_NguoiCapNhat", item.NguoiCapNhat);
            obj[18] = new SqlParameter("TKM_DaDung", item.DaDung);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TheKhuyenMai_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TheKhuyenMai SelectById(Guid TKM_ID)
        {
            var Item = new TheKhuyenMai();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TKM_ID", TKM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TheKhuyenMai_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TheKhuyenMaiCollection SelectAll()
        {
            var List = new TheKhuyenMaiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TheKhuyenMai_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TheKhuyenMai> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<TheKhuyenMai>("sp_tblSpaMgr_TheKhuyenMai_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TheKhuyenMai getFromReader(IDataReader rd)
        {
            var Item = new TheKhuyenMai();
            if (rd.FieldExists("TKM_ID"))
            {
                Item.ID = (Guid)(rd["TKM_ID"]);
            }
            if (rd.FieldExists("TKM_KM_ID"))
            {
                Item.KM_ID = (Guid)(rd["TKM_KM_ID"]);
            }
            if (rd.FieldExists("TKM_Ma"))
            {
                Item.Ma = (String)(rd["TKM_Ma"]);
            }
            if (rd.FieldExists("TKM_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["TKM_KH_ID"]);
            }
            if (rd.FieldExists("TKM_DVTC_ID"))
            {
                Item.DVTC_ID = (Guid)(rd["TKM_DVTC_ID"]);
            }
            if (rd.FieldExists("TKM_GiaNY"))
            {
                Item.GiaNY = (Double)(rd["TKM_GiaNY"]);
            }
            if (rd.FieldExists("TKM_Gia"))
            {
                Item.Gia = (Double)(rd["TKM_Gia"]);
            }
            if (rd.FieldExists("TKM_HanSuDung"))
            {
                Item.HanSuDung = (DateTime)(rd["TKM_HanSuDung"]);
            }
            if (rd.FieldExists("TKM_HanDoiThe"))
            {
                Item.HanDoiThe = (DateTime)(rd["TKM_HanDoiThe"]);
            }
            if (rd.FieldExists("TKM_TinhTrang"))
            {
                Item.TinhTrang = (Boolean)(rd["TKM_TinhTrang"]);
            }
            if (rd.FieldExists("TKM_DV_ID"))
            {
                Item.DV_ID = (Guid)(rd["TKM_DV_ID"]);
            }
            if (rd.FieldExists("TKM_NgayPhatHanh"))
            {
                Item.NgayPhatHanh = (DateTime)(rd["TKM_NgayPhatHanh"]);
            }
            if (rd.FieldExists("TKM_NgayNhan"))
            {
                Item.NgayNhan = (DateTime)(rd["TKM_NgayNhan"]);
            }
            if (rd.FieldExists("TKM_NguoiNhan"))
            {
                Item.NguoiNhan = (String)(rd["TKM_NguoiNhan"]);
            }
            if (rd.FieldExists("TKM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TKM_NgayTao"]);
            }
            if (rd.FieldExists("TKM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TKM_NgayCapNhat"]);
            }
            if (rd.FieldExists("TKM_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TKM_NguoiTao"]);
            }
            if (rd.FieldExists("TKM_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TKM_NguoiCapNhat"]);
            }
            if (rd.FieldExists("TKM_DaDung"))
            {
                Item.DaDung = (Boolean)(rd["TKM_DaDung"]);
            }
            if (rd.FieldExists("TKM_KM_Ten"))
            {
                Item.KM_Ten = (String)(rd["TKM_KM_Ten"]);
            }
            if (rd.FieldExists("TKM_KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["TKM_KH_Ten"]);
            }
            if (rd.FieldExists("TKM_DV_Ten"))
            {
                Item.DV_Ten = (String)(rd["TKM_DV_Ten"]);
            }
            if (rd.FieldExists("TKM_DVTC_Ten"))
            {
                Item.DVTC_Ten = (String)(rd["TKM_DVTC_Ten"]);
            }
            if (rd.FieldExists("TKM_NguoiNhan_Ten"))
            {
                Item.NguoiNhan_Ten = (String)(rd["TKM_NguoiNhan_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<TheKhuyenMai> pagerAll(string sort, string q, int size, string KM_ID, string DVTC_ID, string DV_ID, string TinhTrang, string DaDung)
        {
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KM_ID))
            {
                obj[2] = new SqlParameter("KM_ID", KM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("KM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DVTC_ID))
            {
                obj[3] = new SqlParameter("DVTC_ID", DVTC_ID);
            }
            else
            {
                obj[3] = new SqlParameter("DVTC_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TinhTrang))
            {
                obj[4] = new SqlParameter("TinhTrang", TinhTrang);
            }
            else
            {
                obj[4] = new SqlParameter("TinhTrang", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DV_ID))
            {
                obj[5] = new SqlParameter("DV_ID", DV_ID);
            }
            else
            {
                obj[5] = new SqlParameter("DV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DaDung))
            {
                obj[6] = new SqlParameter("DaDung", DaDung);
            }
            else
            {
                obj[6] = new SqlParameter("DaDung", DBNull.Value);
            }
            var pg = new Pager<TheKhuyenMai>("sp_tblSpaMgr_TheKhuyenMai_Pager_All_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
}
