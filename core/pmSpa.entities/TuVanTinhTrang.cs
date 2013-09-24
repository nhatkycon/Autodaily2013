using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using docsoft.entities;
using linh.controls;
using linh.core;
using linh.core.dal;

namespace pmSpa.entities
{
    #region TuVanTinhTrang
    #region BO
    public class TuVanTinhTrang : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid TV_ID { get; set; }
        public Guid TT_ID { get; set; }
        public Int32 ThuTu { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public TuVanTinhTrang()
        { }
        #endregion
        #region Customs properties

        public DanhMuc _DanhMuc { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TuVanTinhTrangDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TuVanTinhTrangCollection : BaseEntityCollection<TuVanTinhTrang>
    { }
    #endregion
    #region Dal
    public class TuVanTinhTrangDal
    {
        #region Methods

        public static void DeleteById(Guid TTDV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TTDV_ID", TTDV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanTinhTrang_Delete_DeleteById_linhnx", obj);
        }

        public static TuVanTinhTrang Insert(TuVanTinhTrang item)
        {
            var Item = new TuVanTinhTrang();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("TTDV_ID", item.ID);
            obj[1] = new SqlParameter("TTDV_TV_ID", item.TV_ID);
            obj[2] = new SqlParameter("TTDV_TT_ID", item.TT_ID);
            obj[3] = new SqlParameter("TTDV_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("TTDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("TTDV_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanTinhTrang_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanTinhTrang Update(TuVanTinhTrang item)
        {
            var Item = new TuVanTinhTrang();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("TTDV_ID", item.ID);
            obj[1] = new SqlParameter("TTDV_TV_ID", item.TV_ID);
            obj[2] = new SqlParameter("TTDV_TT_ID", item.TT_ID);
            obj[3] = new SqlParameter("TTDV_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("TTDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("TTDV_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanTinhTrang_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanTinhTrang SelectById(Guid TTDV_ID)
        {
            var Item = new TuVanTinhTrang();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TTDV_ID", TTDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanTinhTrang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TuVanTinhTrangCollection SelectAll()
        {
            var List = new TuVanTinhTrangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanTinhTrang_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TuVanTinhTrang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<TuVanTinhTrang>("sp_tblSpaMgr_TuVanTinhTrang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TuVanTinhTrang getFromReader(IDataReader rd)
        {
            var Item = new TuVanTinhTrang();
            if (rd.FieldExists("TTDV_ID"))
            {
                Item.ID = (Guid)(rd["TTDV_ID"]);
            }
            if (rd.FieldExists("TTDV_TV_ID"))
            {
                Item.TV_ID = (Guid)(rd["TTDV_TV_ID"]);
            }
            if (rd.FieldExists("TTDV_TT_ID"))
            {
                Item.TT_ID = (Guid)(rd["TTDV_TT_ID"]);
            }
            if (rd.FieldExists("TTDV_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TTDV_ThuTu"]);
            }
            if (rd.FieldExists("TTDV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TTDV_NgayTao"]);
            }
            Item._DanhMuc = DanhMucDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteByTvIdVaTtId(string TT_ID,string TV_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TT_ID", TT_ID);
            obj[1] = new SqlParameter("TV_ID", TV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanTinhTrang_Delete_DeleteByTvIdVaTtIdlinhnx", obj);
        }
        public static TuVanTinhTrangCollection SelectByTvId(string TV_ID)
        {
            var List = new TuVanTinhTrangCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_TuVanTinhTrang_Select_SelectByTvId_linhnx", obj))
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
