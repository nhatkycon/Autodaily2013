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
    #region HenGio
    #region BO
    public class HenGio : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public DateTime GioDang { get; set; }
        public Guid TIN_ID { get; set; }
        public Boolean Active { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public HenGio()
        { }
        #endregion
        #region Customs properties
        public String TIN_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return HenGioDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class HenGioCollection : BaseEntityCollection<HenGio>
    { }
    #endregion
    #region Dal
    public class HenGioDal
    {
        #region Methods

        public static void DeleteById(Guid HG_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HG_ID", HG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHenGio_Delete_DeleteById_linhnx", obj);
        }

        public static HenGio Insert(HenGio item)
        {
            var Item = new HenGio();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("HG_ID", item.ID);
            if (item.GioDang > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("HG_GioDang", item.GioDang);
            }
            else
            {
                obj[1] = new SqlParameter("HG_GioDang", DBNull.Value);
            }
            obj[2] = new SqlParameter("HG_TIN_ID", item.TIN_ID);
            obj[3] = new SqlParameter("HG_Active", item.Active);
            obj[4] = new SqlParameter("HG_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("HG_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("HG_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHenGio_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static HenGio Insert (HenGio item, SqlTransaction tran)
        {
            var Item = new HenGio();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("HG_ID", item.ID);
            if (item.GioDang > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("HG_GioDang", item.GioDang);
            }
            else
            {
                obj[1] = new SqlParameter("HG_GioDang", DBNull.Value);
            }
            obj[2] = new SqlParameter("HG_TIN_ID", item.TIN_ID);
            obj[3] = new SqlParameter("HG_Active", item.Active);
            obj[4] = new SqlParameter("HG_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("HG_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("HG_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblHenGio_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static HenGio Update(HenGio item)
        {
            var Item = new HenGio();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("HG_ID", item.ID);
            if (item.GioDang > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("HG_GioDang", item.GioDang);
            }
            else
            {
                obj[1] = new SqlParameter("HG_GioDang", DBNull.Value);
            }
            obj[2] = new SqlParameter("HG_TIN_ID", item.TIN_ID);
            obj[3] = new SqlParameter("HG_Active", item.Active);
            obj[4] = new SqlParameter("HG_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("HG_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("HG_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHenGio_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HenGio SelectById(Guid HG_ID)
        {
            var Item = new HenGio();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HG_ID", HG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHenGio_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HenGioCollection SelectAll()
        {
            var List = new HenGioCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHenGio_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<HenGio> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<HenGio>("sp_tblHenGio_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static HenGio getFromReader(IDataReader rd)
        {
            var Item = new HenGio();
            if (rd.FieldExists("HG_ID"))
            {
                Item.ID = (Guid)(rd["HG_ID"]);
            }
            if (rd.FieldExists("HG_GioDang"))
            {
                Item.GioDang = (DateTime)(rd["HG_GioDang"]);
            }
            if (rd.FieldExists("HG_TIN_ID"))
            {
                Item.TIN_ID = (Guid)(rd["HG_TIN_ID"]);
            }
            if (rd.FieldExists("HG_Active"))
            {
                Item.Active = (Boolean)(rd["HG_Active"]);
            }
            if (rd.FieldExists("HG_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["HG_NguoiTao"]);
            }
            if (rd.FieldExists("TIN_Ten"))
            {
                Item.TIN_Ten = (String)(rd["TIN_Ten"]);
            }
            if (rd.FieldExists("HG_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["HG_NgayTao"]);
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


