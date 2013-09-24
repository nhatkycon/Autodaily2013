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
    #region Album
    #region BO
    public class Album : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid SPA_ID { get; set; }
        public String Ma { get; set; }
        public Guid P_RowId { get; set; }
        public String Ten { get; set; }
        public String AnhDaiDien { get; set; }
        public String MoTa { get; set; }
        public Int32 ThuTu { get; set; }
        public Int32 TongSoAnh { get; set; }
        public Boolean Active { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean MacDinh { get; set; }
        #endregion
        #region Contructor
        public Album()
        { }
        #endregion
        #region Customs properties
        public List<Files> ListFiles { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return AlbumDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class AlbumCollection : BaseEntityCollection<Album>
    { }
    #endregion
    #region Dal
    public class AlbumDal
    {
        #region Methods

        public static void DeleteById(Guid AB_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("AB_ID", AB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAlbum_Delete_DeleteById_linhnx", obj);
        }

        public static Album Insert(Album item)
        {
            var Item = new Album();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("AB_ID", item.ID);
            obj[1] = new SqlParameter("AB_SPA_ID", item.SPA_ID);
            obj[2] = new SqlParameter("AB_Ma", item.Ma);
            obj[3] = new SqlParameter("AB_P_RowId", item.P_RowId);
            obj[4] = new SqlParameter("AB_Ten", item.Ten);
            obj[5] = new SqlParameter("AB_AnhDaiDien", item.AnhDaiDien);
            obj[6] = new SqlParameter("AB_MoTa", item.MoTa);
            obj[7] = new SqlParameter("AB_ThuTu", item.ThuTu);
            obj[8] = new SqlParameter("AB_TongSoAnh", item.TongSoAnh);
            obj[9] = new SqlParameter("AB_Active", item.Active);
            obj[10] = new SqlParameter("AB_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("AB_NgayTao", item.NgayTao);
            }
            else
            {
                obj[11] = new SqlParameter("AB_NgayTao", DBNull.Value);
            }
            obj[12] = new SqlParameter("AB_MacDinh", item.MacDinh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAlbum_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Album Update(Album item)
        {
            var Item = new Album();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("AB_ID", item.ID);
            obj[1] = new SqlParameter("AB_SPA_ID", item.SPA_ID);
            obj[2] = new SqlParameter("AB_Ma", item.Ma);
            obj[3] = new SqlParameter("AB_P_RowId", item.P_RowId);
            obj[4] = new SqlParameter("AB_Ten", item.Ten);
            obj[5] = new SqlParameter("AB_AnhDaiDien", item.AnhDaiDien);
            obj[6] = new SqlParameter("AB_MoTa", item.MoTa);
            obj[7] = new SqlParameter("AB_ThuTu", item.ThuTu);
            obj[8] = new SqlParameter("AB_TongSoAnh", item.TongSoAnh);
            obj[9] = new SqlParameter("AB_Active", item.Active);
            obj[10] = new SqlParameter("AB_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("AB_NgayTao", item.NgayTao);
            }
            else
            {
                obj[11] = new SqlParameter("AB_NgayTao", DBNull.Value);
            }
            obj[12] = new SqlParameter("AB_MacDinh", item.MacDinh);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAlbum_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Album SelectById(Guid AB_ID)
        {
            var Item = new Album();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("AB_ID", AB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAlbum_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static AlbumCollection SelectAll()
        {
            var List = new AlbumCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAlbum_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Album> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Album>("sp_tblAlbum_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Album getFromReader(IDataReader rd)
        {
            var Item = new Album();
            if (rd.FieldExists("AB_ID"))
            {
                Item.ID = (Guid)(rd["AB_ID"]);
            }
            if (rd.FieldExists("AB_SPA_ID"))
            {
                Item.SPA_ID = (Guid)(rd["AB_SPA_ID"]);
            }
            if (rd.FieldExists("AB_Ma"))
            {
                Item.Ma = (String)(rd["AB_Ma"]);
            }
            if (rd.FieldExists("AB_P_RowId"))
            {
                Item.P_RowId = (Guid)(rd["AB_P_RowId"]);
            }
            if (rd.FieldExists("AB_Ten"))
            {
                Item.Ten = (String)(rd["AB_Ten"]);
            }
            if (rd.FieldExists("AB_AnhDaiDien"))
            {
                Item.AnhDaiDien = (String)(rd["AB_AnhDaiDien"]);
            }
            if (rd.FieldExists("AB_MoTa"))
            {
                Item.MoTa = (String)(rd["AB_MoTa"]);
            }
            if (rd.FieldExists("AB_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["AB_ThuTu"]);
            }
            if (rd.FieldExists("AB_TongSoAnh"))
            {
                Item.TongSoAnh = (Int32)(rd["AB_TongSoAnh"]);
            }
            if (rd.FieldExists("AB_Active"))
            {
                Item.Active = (Boolean)(rd["AB_Active"]);
            }
            if (rd.FieldExists("AB_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["AB_NguoiTao"]);
            }
            if (rd.FieldExists("AB_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["AB_NgayTao"]);
            }
            if (rd.FieldExists("AB_MacDinh"))
            {
                Item.MacDinh = (Boolean)(rd["AB_MacDinh"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Album SelectById(SqlConnection con, Guid AB_ID)
        {
            var Item = new Album();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("AB_ID", AB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAlbum_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static AlbumCollection SelectAll(SqlConnection con)
        {
            var List = new AlbumCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAlbum_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static AlbumCollection SelectByPid(SqlConnection con, string PID)
        {
            var List = new AlbumCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(PID))
            {
                obj[0] = new SqlParameter("PID", PID);
            }
            else
            {
                obj[0] = new SqlParameter("PID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAlbum_Select_SelectByPid_linhnx", obj))
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


