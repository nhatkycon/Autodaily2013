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
    #region ToTrinhTraLai
    #region BO
    public class ToTrinhTraLai : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 VBD_ID { get; set; }
        public DateTime NgayTrinh { get; set; }
        public DateTime NgayTraLai { get; set; }
        public Int32 LanhDao_ID { get; set; }
        public String LanhDao_Ten { get; set; }
        public String LanhDao_UserName { get; set; }
        public Int32 TT_So { get; set; }
        public String LyDo { get; set; }
        public Int32 LanThu { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        public Int16 TrangThai { get; set; }
        #endregion
        #region Contructor
        public ToTrinhTraLai()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ToTrinhTraLaiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ToTrinhTraLaiCollection : BaseEntityCollection<ToTrinhTraLai>
    { }
    #endregion
    #region Dal
    public class ToTrinhTraLaiDal
    {
        #region Methods

        public static void DeleteById(Int32 TL_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TL_ID", TL_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblToTrinhTraLai_Delete_DeleteById_linhnx", obj);
        }

        public static ToTrinhTraLai Insert(ToTrinhTraLai Inserted)
        {
            ToTrinhTraLai Item = new ToTrinhTraLai();
            SqlParameter[] obj = new SqlParameter[15];
            obj[0] = new SqlParameter("TL_VBD_ID", Inserted.VBD_ID);
            obj[1] = new SqlParameter("TL_NgayTrinh", Inserted.NgayTrinh);
            string htl = string.Format("{0:dd/MM/yy}", Inserted.NgayTrinh);
            if (htl != "01/01/01")
            {
                obj[1] = new SqlParameter("TL_NgayTrinh", Inserted.NgayTrinh);
            }
            else
            {
                obj[1] = new SqlParameter("TL_NgayTrinh", DBNull.Value);
            }
            obj[2] = new SqlParameter("TL_NgayTraLai", Inserted.NgayTraLai);
            string htl1 = string.Format("{0:dd/MM/yy}", Inserted.NgayTraLai);
            if (htl1 != "01/01/01")
            {
                obj[2] = new SqlParameter("TL_NgayTraLai", Inserted.NgayTraLai);
            }
            else
            {
                obj[2] = new SqlParameter("TL_NgayTraLai", DBNull.Value);
            }
            obj[3] = new SqlParameter("TL_LanhDao_ID", Inserted.LanhDao_ID);
            obj[4] = new SqlParameter("TL_LanhDao_Ten", Inserted.LanhDao_Ten);
            obj[5] = new SqlParameter("TL_LanhDao_UserName", Inserted.LanhDao_UserName);
            obj[6] = new SqlParameter("TL_TT_So", Inserted.TT_So);
            obj[7] = new SqlParameter("TL_LyDo", Inserted.LyDo);
            obj[8] = new SqlParameter("TL_LanThu", Inserted.LanThu);
            obj[9] = new SqlParameter("TL_NguoiTao", Inserted.NguoiTao);
            obj[10] = new SqlParameter("TL_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[11] = new SqlParameter("TL_NgayTao", Inserted.NgayTao);
            obj[12] = new SqlParameter("TL_NgayCapNhat", Inserted.NgayCapNhat);
            obj[13] = new SqlParameter("TL_RowId", Inserted.RowId);
            obj[14] = new SqlParameter("TL_TrangThai", Inserted.TrangThai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblToTrinhTraLai_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ToTrinhTraLai Update(ToTrinhTraLai Updated)
        {
            ToTrinhTraLai Item = new ToTrinhTraLai();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("TL_ID", Updated.ID);
            obj[1] = new SqlParameter("TL_VBD_ID", Updated.VBD_ID);
            obj[2] = new SqlParameter("TL_NgayTrinh", Updated.NgayTrinh);
            obj[3] = new SqlParameter("TL_NgayTraLai", Updated.NgayTraLai);
            obj[4] = new SqlParameter("TL_LanhDao_ID", Updated.LanhDao_ID);
            obj[5] = new SqlParameter("TL_LanhDao_Ten", Updated.LanhDao_Ten);
            obj[6] = new SqlParameter("TL_LanhDao_UserName", Updated.LanhDao_UserName);
            obj[7] = new SqlParameter("TL_TT_So", Updated.TT_So);
            obj[8] = new SqlParameter("TL_LyDo", Updated.LyDo);
            obj[9] = new SqlParameter("TL_LanThu", Updated.LanThu);
            obj[10] = new SqlParameter("TL_NguoiTao", Updated.NguoiTao);
            obj[11] = new SqlParameter("TL_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[12] = new SqlParameter("TL_NgayTao", Updated.NgayTao);
            obj[13] = new SqlParameter("TL_NgayCapNhat", Updated.NgayCapNhat);
            obj[14] = new SqlParameter("TL_RowId", Updated.RowId);
            obj[15] = new SqlParameter("TL_RowId", Updated.TrangThai);
            
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblToTrinhTraLai_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ToTrinhTraLai SelectById(Int32 TL_ID)
        {
            ToTrinhTraLai Item = new ToTrinhTraLai();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TL_ID", TL_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblToTrinhTraLai_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ToTrinhTraLaiCollection SelectAll()
        {
            ToTrinhTraLaiCollection List = new ToTrinhTraLaiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblToTrinhTraLai_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ToTrinhTraLai> pagerNormal(string url, bool rewrite, string sort, int pagesize, string _ID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(_ID))
            {
                obj[1] = new SqlParameter("TL_VBD_ID", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("TL_VBD_ID", _ID);
            }
            Pager<ToTrinhTraLai> pg = new Pager<ToTrinhTraLai>("sp_tblToTrinhTraLai_Pager_Normal_linhnx", "page", pagesize, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ToTrinhTraLai getFromReader(IDataReader rd)
        {
            ToTrinhTraLai Item = new ToTrinhTraLai();
            if (rd.FieldExists("TL_ID"))
            {
                Item.ID = (Int32)(rd["TL_ID"]);
            }
            if (rd.FieldExists("TL_VBD_ID"))
            {
                Item.VBD_ID = (Int32)(rd["TL_VBD_ID"]);
            }
            if (rd.FieldExists("TL_NgayTrinh"))
            {
                Item.NgayTrinh = (DateTime)(rd["TL_NgayTrinh"]);
            }
            if (rd.FieldExists("TL_NgayTraLai"))
            {
                Item.NgayTraLai = (DateTime)(rd["TL_NgayTraLai"]);
            }
            if (rd.FieldExists("TL_LanhDao_ID"))
            {
                Item.LanhDao_ID = (Int32)(rd["TL_LanhDao_ID"]);
            }
            if (rd.FieldExists("TL_LanhDao_Ten"))
            {
                Item.LanhDao_Ten = (String)(rd["TL_LanhDao_Ten"]);
            }
            if (rd.FieldExists("TL_LanhDao_UserName"))
            {
                Item.LanhDao_UserName = (String)(rd["TL_LanhDao_UserName"]);
            }
            if (rd.FieldExists("TL_TT_So"))
            {
                Item.TT_So = (Int32)(rd["TL_TT_So"]);
            }
            if (rd.FieldExists("TL_TrangThai"))
            {
                Item.TrangThai = (Int16)(rd["TL_TrangThai"]);
            }
            if (rd.FieldExists("TL_LyDo"))
            {
                Item.LyDo = (String)(rd["TL_LyDo"]);
            }
            if (rd.FieldExists("TL_LanThu"))
            {
                Item.LanThu = (Int32)(rd["TL_LanThu"]);
            }
            if (rd.FieldExists("TL_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TL_NguoiTao"]);
            }
            if (rd.FieldExists("TL_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TL_NguoiCapNhat"]);
            }
            if (rd.FieldExists("TL_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TL_NgayTao"]);
            }
            if (rd.FieldExists("TL_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TL_NgayCapNhat"]);
            }
            if (rd.FieldExists("TL_RowId"))
            {
                Item.RowId = (Guid)(rd["TL_RowId"]);
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
