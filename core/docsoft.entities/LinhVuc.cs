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
    #region LinhVuc
    #region BO
    public class LinhVuc : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public Guid RowId { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 ThuTu { get; set; }
        public String Ma { get; set; }
        public String KyHieu { get; set; }
        #endregion
        #region Contructor
        public LinhVuc()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LinhVucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LinhVucCollection : BaseEntityCollection<LinhVuc>
    { }
    #endregion
    #region Dal
    public class LinhVucDal
    {
        #region Methods

        public static void DeleteById(Int32 LV_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LV_ID", LV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLinhVuc_Delete_DeleteById_linhnx", obj);
        }

        public static LinhVuc Insert(LinhVuc Inserted)
        {
            LinhVuc Item = new LinhVuc();
            SqlParameter[] obj = new SqlParameter[9];
           
            obj[0] = new SqlParameter("LV_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("LV_Ma", Inserted.Ma);
            obj[2] = new SqlParameter("LV_KyHieu", Inserted.KyHieu);
            obj[3] = new SqlParameter("LV_RowId", Inserted.RowId);
            obj[4] = new SqlParameter("LV_NgayTao", Inserted.NgayTao);
            obj[5] = new SqlParameter("LV_NguoiTao", Inserted.NguoiTao);
            obj[6] = new SqlParameter("LV_NgayCapNhat", Inserted.NgayCapNhat);
            obj[7] = new SqlParameter("LV_ThuTu", Inserted.ThuTu);
            obj[8] = new SqlParameter("LV_NguoiCapNhat", Inserted.NguoiCapNhat); 

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLinhVuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LinhVuc Update(LinhVuc Updated)
        {
            LinhVuc Item = new LinhVuc();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("LV_ID", Updated.ID);
            obj[1] = new SqlParameter("LV_Ten", Updated.Ten);
            obj[2] = new SqlParameter("LV_Ma", Updated.Ma);
            obj[3] = new SqlParameter("LV_KyHieu", Updated.KyHieu);
            obj[4] = new SqlParameter("LV_RowId", Updated.RowId);
            obj[5] = new SqlParameter("LV_NgayTao", Updated.NgayTao);
            obj[6] = new SqlParameter("LV_NguoiTao", Updated.NguoiTao);
            obj[8] = new SqlParameter("LV_NgayCapNhat", Updated.NgayCapNhat);
            obj[9] = new SqlParameter("LV_ThuTu", Updated.ThuTu);
            obj[10] = new SqlParameter("LV_NguoiCapNhat", Updated.NguoiCapNhat); 

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLinhVuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LinhVuc SelectById(Int32 LV_ID)
        {
            LinhVuc Item = new LinhVuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LV_ID", LV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLinhVuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LinhVucCollection SelectAll()
        {
            LinhVucCollection List = new LinhVucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLinhVuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LinhVuc> pagerNormal(string url, bool rewrite, string sort, string q, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (string.IsNullOrEmpty(pagesize)) pagesize = "20";

            Pager<LinhVuc> pg = new Pager<LinhVuc>("sp_tblLinhVuc_Pager_Normal_linhnx", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static LinhVucCollection SelectTree(string q)
        {
            LinhVucCollection List = new LinhVucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLinhVuc_Select_SelectTree_hungpm", obj))
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
        public static LinhVuc getFromReader(IDataReader rd)
        {
            LinhVuc Item = new LinhVuc();
            if (rd.FieldExists("LV_ID"))
            {
                Item.ID = (Int32)(rd["LV_ID"]);
            }
            if (rd.FieldExists("LV_Ten"))
            {
                Item.Ten = (String)(rd["LV_Ten"]);
            }
            if (rd.FieldExists("LV_RowId"))
            {
                Item.RowId = (Guid)(rd["LV_RowId"]);
            }
            if (rd.FieldExists("LV_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["LV_NguoiTao"]);
            }
            if (rd.FieldExists("LV_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["LV_NguoiCapNhat"]);
            }
            if (rd.FieldExists("LV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LV_NgayTao"]);
            }
            if (rd.FieldExists("LV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["LV_NgayCapNhat"]);
            }
            if (rd.FieldExists("LV_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["LV_ThuTu"]);
            }
            if (rd.FieldExists("LV_Ma"))
            {
                Item.Ma = (String)(rd["LV_Ma"]);
            }
            if (rd.FieldExists("LV_KyHieu"))
            {
                Item.KyHieu = (String)(rd["LV_KyHieu"]);
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
