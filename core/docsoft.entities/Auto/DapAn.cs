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
    #region DapAn
    #region BO
    public class DapAn : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid CH_ID { get; set; }
        public String Ten { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Dung { get; set; }
        #endregion
        #region Contructor
        public DapAn()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DapAnDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DapAnCollection : BaseEntityCollection<DapAn>
    { }
    #endregion
    #region Dal
    public class DapAnDal
    {
        #region Methods

        public static void DeleteById(Guid DA_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DA_ID", DA_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_DapAn_Delete_DeleteById_linhnx", obj);
        }

        public static DapAn Insert(DapAn item)
        {
            var Item = new DapAn();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("DA_ID", item.ID);
            obj[1] = new SqlParameter("DA_CH_ID", item.CH_ID);
            obj[2] = new SqlParameter("DA_Ten", item.Ten);
            obj[3] = new SqlParameter("DA_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("DA_Dung", item.Dung);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_DapAn_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DapAn Update(DapAn item)
        {
            var Item = new DapAn();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("DA_ID", item.ID);
            obj[1] = new SqlParameter("DA_CH_ID", item.CH_ID);
            obj[2] = new SqlParameter("DA_Ten", item.Ten);
            obj[3] = new SqlParameter("DA_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("DA_Dung", item.Dung);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_DapAn_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DapAn SelectById(Guid DA_ID)
        {
            var Item = new DapAn();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DA_ID", DA_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_DapAn_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DapAnCollection SelectAll()
        {
            var List = new DapAnCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_DapAn_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DapAn> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<DapAn>("sp_tblAuto_DapAn_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DapAn getFromReader(IDataReader rd)
        {
            var Item = new DapAn();
            if (rd.FieldExists("DA_ID"))
            {
                Item.ID = (Guid)(rd["DA_ID"]);
            }
            if (rd.FieldExists("DA_CH_ID"))
            {
                Item.CH_ID = (Guid)(rd["DA_CH_ID"]);
            }
            if (rd.FieldExists("DA_Ten"))
            {
                Item.Ten = (String)(rd["DA_Ten"]);
            }
            if (rd.FieldExists("DA_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["DA_ThuTu"]);
            }
            if (rd.FieldExists("DA_Dung"))
            {
                Item.Dung = (Boolean)(rd["DA_Dung"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static DapAnCollection SelectByChId(SqlConnection con,string CH_ID)
        {
            var List = new DapAnCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CH_ID", CH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAuto_DapAn_Select_SelectByChId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DapAnCollection SelectByChId(string CH_ID)
        {

            return SelectByChId(DAL.con(),CH_ID);
        }
        #endregion
    }
    #endregion

    #endregion
}


