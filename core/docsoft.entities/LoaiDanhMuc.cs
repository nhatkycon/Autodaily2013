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
    #region LoaiDanhMuc
    #region BO
    public class LoaiDanhMuc : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String KyHieu { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 ThuTu { get; set; }
        public String NguoiSua { get; set; }
        public Boolean Deleted { get; set; }
        #endregion
        #region Contructor
        public LoaiDanhMuc()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LoaiDanhMucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LoaiDanhMucCollection : BaseEntityCollection<LoaiDanhMuc>
    { }
    #endregion
    #region Dal
    public class LoaiDanhMucDal
    {
        #region Methods

        public static void DeleteById(Guid LDM_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Delete_DeleteById_linhnx", obj);
        }

        public static LoaiDanhMuc Insert(LoaiDanhMuc item)
        {
            var Item = new LoaiDanhMuc();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("LDM_ID", item.ID);
            obj[1] = new SqlParameter("LDM_Ten", item.Ten);
            obj[2] = new SqlParameter("LDM_Ma", item.Ma);
            obj[3] = new SqlParameter("LDM_KyHieu", item.KyHieu);
            obj[4] = new SqlParameter("LDM_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("LDM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("LDM_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("LDM_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("LDM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("LDM_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("LDM_ThuTu", item.ThuTu);
            obj[9] = new SqlParameter("LDM_NguoiSua", item.NguoiSua);
            obj[10] = new SqlParameter("LDM_Deleted", item.Deleted);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiDanhMuc Update(LoaiDanhMuc item)
        {
            var Item = new LoaiDanhMuc();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("LDM_ID", item.ID);
            obj[1] = new SqlParameter("LDM_Ten", item.Ten);
            obj[2] = new SqlParameter("LDM_Ma", item.Ma);
            obj[3] = new SqlParameter("LDM_KyHieu", item.KyHieu);
            obj[4] = new SqlParameter("LDM_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("LDM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("LDM_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("LDM_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("LDM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("LDM_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("LDM_ThuTu", item.ThuTu);
            obj[9] = new SqlParameter("LDM_NguoiSua", item.NguoiSua);
            obj[10] = new SqlParameter("LDM_Deleted", item.Deleted);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiDanhMuc SelectById(Guid LDM_ID)
        {
            var Item = new LoaiDanhMuc();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiDanhMucCollection SelectAll()
        {
            var List = new LoaiDanhMucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LoaiDanhMuc> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<LoaiDanhMuc>("sp_tblLoaiDanhMuc_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static LoaiDanhMuc getFromReader(IDataReader rd)
        {
            var Item = new LoaiDanhMuc();
            if (rd.FieldExists("LDM_ID"))
            {
                Item.ID = (Guid)(rd["LDM_ID"]);
            }
            if (rd.FieldExists("LDM_Ten"))
            {
                Item.Ten = (String)(rd["LDM_Ten"]);
            }
            if (rd.FieldExists("LDM_Ma"))
            {
                Item.Ma = (String)(rd["LDM_Ma"]);
            }
            if (rd.FieldExists("LDM_KyHieu"))
            {
                Item.KyHieu = (String)(rd["LDM_KyHieu"]);
            }
            if (rd.FieldExists("LDM_RowId"))
            {
                Item.RowId = (Guid)(rd["LDM_RowId"]);
            }
            if (rd.FieldExists("LDM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LDM_NgayTao"]);
            }
            if (rd.FieldExists("LDM_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["LDM_NguoiTao"]);
            }
            if (rd.FieldExists("LDM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["LDM_NgayCapNhat"]);
            }
            if (rd.FieldExists("LDM_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["LDM_ThuTu"]);
            }
            if (rd.FieldExists("LDM_NguoiSua"))
            {
                Item.NguoiSua = (String)(rd["LDM_NguoiSua"]);
            }
            if (rd.FieldExists("LDM_Deleted"))
            {
                Item.Deleted = (Boolean)(rd["LDM_Deleted"]);
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


