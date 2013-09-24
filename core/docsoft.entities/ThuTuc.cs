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
    #region ThuTuc
    #region BO
    public class ThuTuc : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String KyHieu { get; set; }
        public String GiaTri { get; set; }
        public Int32 LV_ID { get; set; }
        public String LV_Ten { get; set; }
        public Int32 CQ_ID { get; set; }
        public String CQ_Ten { get; set; }
        public Guid RowId { get; set; }
        public Int32 ThuTu { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayCapNhat { get; set; }
        #endregion
        #region Contructor
        public ThuTuc()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuTucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuTucCollection : BaseEntityCollection<ThuTuc>
    { }
    #endregion
    #region Dal
    public class ThuTucDal
    {
        #region Methods
        public static void DeleteById(Int32 TT_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TT_ID", TT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuTuc_Delete_DeleteById_linhnx", obj);
        }
        public static ThuTuc Insert(ThuTuc Inserted)
        {
            ThuTuc Item = new ThuTuc();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("TT_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("TT_Ma", Inserted.Ma);
            obj[2] = new SqlParameter("TT_KyHieu", Inserted.KyHieu);
            obj[3] = new SqlParameter("TT_GiaTri", Inserted.GiaTri);
            obj[4] = new SqlParameter("TT_LV_ID", Inserted.LV_ID);
            obj[5] = new SqlParameter("TT_LV_Ten", Inserted.LV_Ten);
            obj[6] = new SqlParameter("TT_CQ_ID", Inserted.CQ_ID);
            obj[7] = new SqlParameter("TT_CQ_Ten", Inserted.CQ_Ten);
            obj[8] = new SqlParameter("TT_RowId", Inserted.RowId);
            obj[9] = new SqlParameter("TT_ThuTu", Inserted.ThuTu);
            obj[10] = new SqlParameter("TT_NguoiTao", Inserted.NguoiTao);
            obj[11] = new SqlParameter("TT_NgayTao", Inserted.NgayTao);
            obj[12] = new SqlParameter("TT_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[13] = new SqlParameter("TT_NgayCapNhat", Inserted.NgayCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuTuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ThuTuc Update(ThuTuc Updated)
        {
            ThuTuc Item = new ThuTuc();
            SqlParameter[] obj = new SqlParameter[15];
            obj[0] = new SqlParameter("TT_ID", Updated.ID);
            obj[1] = new SqlParameter("TT_Ten", Updated.Ten);
            obj[2] = new SqlParameter("TT_Ma", Updated.Ma);
            obj[3] = new SqlParameter("TT_KyHieu", Updated.KyHieu);
            obj[4] = new SqlParameter("TT_GiaTri", Updated.GiaTri);
            obj[5] = new SqlParameter("TT_LV_ID", Updated.LV_ID);
            obj[6] = new SqlParameter("TT_LV_Ten", Updated.LV_Ten);
            obj[7] = new SqlParameter("TT_CQ_ID", Updated.CQ_ID);
            obj[8] = new SqlParameter("TT_CQ_Ten", Updated.CQ_Ten);
            obj[9] = new SqlParameter("TT_RowId", Updated.RowId);
            obj[10] = new SqlParameter("TT_ThuTu", Updated.ThuTu);
            obj[11] = new SqlParameter("TT_NguoiTao", Updated.NguoiTao);
            obj[12] = new SqlParameter("TT_NgayTao", Updated.NgayTao);
            obj[13] = new SqlParameter("TT_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[14] = new SqlParameter("TT_NgayCapNhat", Updated.NgayCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuTuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ThuTuc SelectById(Int32 TT_ID)
        {
            ThuTuc Item = new ThuTuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TT_ID", TT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuTuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ThuTucCollection SelectAll()
        {
            ThuTucCollection List = new ThuTucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuTuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ThuTuc> pagerNormal(string url, bool rewrite, string sort, string q, string _TT_LV_ID, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            obj[1] = new SqlParameter("q", q);
            if (string.IsNullOrEmpty(_TT_LV_ID))
            {
                obj[2] = new SqlParameter("lv", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("lv", _TT_LV_ID);
            }
            if (string.IsNullOrEmpty(pagesize)) pagesize = "20";
            Pager<ThuTuc> pg = new Pager<ThuTuc>("sp_tblThuTuc_Pager_Normal_linhnx", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static ThuTucCollection SearchByLV(string LV_ID, string q)
        {
            ThuTucCollection List = new ThuTucCollection();
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(LV_ID))
            {
                obj[0] = new SqlParameter("LV_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LV_ID", LV_ID);
            }
            obj[1] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuTuc_Select_SearchByLV_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion

        #region Utilities
        public static ThuTuc getFromReader(IDataReader rd)
        {
            ThuTuc Item = new ThuTuc();
            if (rd.FieldExists("TT_ID"))
            {
                Item.ID = (Int32)(rd["TT_ID"]);
            }
            if (rd.FieldExists("TT_Ten"))
            {
                Item.Ten = (String)(rd["TT_Ten"]);
            }
            if (rd.FieldExists("TT_Ma"))
            {
                Item.Ma = (String)(rd["TT_Ma"]);
            }
            if (rd.FieldExists("TT_KyHieu"))
            {
                Item.KyHieu = (String)(rd["TT_KyHieu"]);
            }
            if (rd.FieldExists("TT_GiaTri"))
            {
                Item.GiaTri = (String)(rd["TT_GiaTri"]);
            }
            if (rd.FieldExists("TT_LV_ID"))
            {
                Item.LV_ID = (Int32)(rd["TT_LV_ID"]);
            }
            if (rd.FieldExists("TT_LV_Ten"))
            {
                Item.LV_Ten = (String)(rd["TT_LV_Ten"]);
            }
            if (rd.FieldExists("TT_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["TT_CQ_ID"]);
            }
            if (rd.FieldExists("TT_CQ_Ten"))
            {
                Item.CQ_Ten = (String)(rd["TT_CQ_Ten"]);
            }
            if (rd.FieldExists("TT_RowId"))
            {
                Item.RowId = (Guid)(rd["TT_RowId"]);
            }
            if (rd.FieldExists("TT_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TT_ThuTu"]);
            }
            if (rd.FieldExists("TT_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TT_NguoiTao"]);
            }
            if (rd.FieldExists("TT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TT_NgayTao"]);
            }
            if (rd.FieldExists("TT_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TT_NguoiCapNhat"]);
            }
            if (rd.FieldExists("TT_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TT_NgayCapNhat"]);
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
