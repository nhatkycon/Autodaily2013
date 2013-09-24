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
    #region DichVuChiTiet
    #region BO
    public class DichVuChiTiet : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid DV_ID { get; set; }
        public Guid HH_ID { get; set; }
        public String HH_Ten { get; set; }
        public Int32 ThuTu { get; set; }
        public Int32 SoLuong { get; set; }
        public Double Gia { get; set; }
        public Double Tong { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        #endregion
        #region Contructor
        public DichVuChiTiet()
        { }
        #endregion
        #region Customs properties 
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DichVuChiTietDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DichVuChiTietCollection : BaseEntityCollection<DichVuChiTiet>
    { }
    #endregion
    #region Dal
    public class DichVuChiTietDal
    {
        #region Methods

        public static void DeleteById(Guid DVCT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DVCT_ID", DVCT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVuChiTiet_Delete_DeleteById_linhnx", obj);
        }

        public static DichVuChiTiet Insert(DichVuChiTiet item)
        {
            var Item = new DichVuChiTiet();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("DVCT_ID", item.ID);
            obj[1] = new SqlParameter("DVCT_DV_ID", item.DV_ID);
            obj[2] = new SqlParameter("DVCT_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("DVCT_HH_Ten", item.HH_Ten);
            obj[4] = new SqlParameter("DVCT_ThuTu", item.ThuTu);
            obj[5] = new SqlParameter("DVCT_SoLuong", item.SoLuong);
            obj[6] = new SqlParameter("DVCT_Gia", item.Gia);
            obj[7] = new SqlParameter("DVCT_Tong", item.Tong);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("DVCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("DVCT_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("DVCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[9] = new SqlParameter("DVCT_NgayCapNhat", DBNull.Value);
            }
            obj[10] = new SqlParameter("DVCT_NguoiTao", item.NguoiTao);
            obj[11] = new SqlParameter("DVCT_NguoiCapNhat", item.NguoiCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVuChiTiet_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DichVuChiTiet Update(DichVuChiTiet item)
        {
            var Item = new DichVuChiTiet();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("DVCT_ID", item.ID);
            obj[1] = new SqlParameter("DVCT_DV_ID", item.DV_ID);
            obj[2] = new SqlParameter("DVCT_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("DVCT_HH_Ten", item.HH_Ten);
            obj[4] = new SqlParameter("DVCT_ThuTu", item.ThuTu);
            obj[5] = new SqlParameter("DVCT_SoLuong", item.SoLuong);
            obj[6] = new SqlParameter("DVCT_Gia", item.Gia);
            obj[7] = new SqlParameter("DVCT_Tong", item.Tong);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("DVCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("DVCT_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("DVCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[9] = new SqlParameter("DVCT_NgayCapNhat", DBNull.Value);
            }
            obj[10] = new SqlParameter("DVCT_NguoiTao", item.NguoiTao);
            obj[11] = new SqlParameter("DVCT_NguoiCapNhat", item.NguoiCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVuChiTiet_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DichVuChiTiet SelectById(Guid DVCT_ID)
        {
            var Item = new DichVuChiTiet();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DVCT_ID", DVCT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVuChiTiet_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DichVuChiTietCollection SelectAll()
        {
            var List = new DichVuChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVuChiTiet_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DichVuChiTiet> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<DichVuChiTiet>("sp_tblSpaMgr_DichVuChiTiet_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DichVuChiTiet getFromReader(IDataReader rd)
        {
            var Item = new DichVuChiTiet();
            if (rd.FieldExists("DVCT_ID"))
            {
                Item.ID = (Guid)(rd["DVCT_ID"]);
            }
            if (rd.FieldExists("DVCT_DV_ID"))
            {
                Item.DV_ID = (Guid)(rd["DVCT_DV_ID"]);
            }
            if (rd.FieldExists("DVCT_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["DVCT_HH_ID"]);
            }
            if (rd.FieldExists("DVCT_HH_Ten"))
            {
                Item.HH_Ten = (String)(rd["DVCT_HH_Ten"]);
            }
            if (rd.FieldExists("DVCT_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["DVCT_ThuTu"]);
            }
            if (rd.FieldExists("DVCT_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["DVCT_SoLuong"]);
            }
            if (rd.FieldExists("DVCT_Gia"))
            {
                Item.Gia = (Double)(rd["DVCT_Gia"]);
            }
            if (rd.FieldExists("DVCT_Tong"))
            {
                Item.Tong = (Double)(rd["DVCT_Tong"]);
            }
            if (rd.FieldExists("DVCT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DVCT_NgayTao"]);
            }
            if (rd.FieldExists("DVCT_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["DVCT_NgayCapNhat"]);
            }
            if (rd.FieldExists("DVCT_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["DVCT_NguoiTao"]);
            }
            if (rd.FieldExists("DVCT_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["DVCT_NguoiCapNhat"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static DichVuChiTietCollection SelectByDvId(string DV_ID)
        {
            var List = new DichVuChiTietCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DV_ID))
            {
                obj[0] = new SqlParameter("DV_ID", DV_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DV_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_DichVuChiTiet_Select_SelectByDvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static DichVuChiTietCollection SelectByDvId(SqlConnection con, string DV_ID)
        {
            var List = new DichVuChiTietCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DV_ID))
            {
                obj[0] = new SqlParameter("DV_ID", DV_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DV_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_DichVuChiTiet_Select_SelectByDvId_linhnx", obj))
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
