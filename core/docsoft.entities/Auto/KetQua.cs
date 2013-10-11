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
    #region KetQua
    #region BO
    public class KetQua : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid LUOT_ID { get; set; }
        public Guid CH_ID { get; set; }
        public String Username { get; set; }
        public Int32 Diem { get; set; }
        #endregion
        #region Contructor
        public KetQua()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return KetQuaDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class KetQuaCollection : BaseEntityCollection<KetQua>
    { }
    #endregion
    #region Dal
    public class KetQuaDal
    {
        #region Methods

        public static void DeleteById(Guid KQ_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KQ_ID", KQ_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_KetQua_Delete_DeleteById_linhnx", obj);
        }

        public static KetQua Insert(KetQua item)
        {
            var Item = new KetQua();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("KQ_ID", item.ID);
            obj[1] = new SqlParameter("KQ_LUOT_ID", item.LUOT_ID);
            obj[2] = new SqlParameter("KQ_CH_ID", item.CH_ID);
            obj[3] = new SqlParameter("KQ_Username", item.Username);
            obj[4] = new SqlParameter("KQ_Diem", item.Diem);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_KetQua_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KetQua Update(KetQua item)
        {
            var Item = new KetQua();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("KQ_ID", item.ID);
            obj[1] = new SqlParameter("KQ_LUOT_ID", item.LUOT_ID);
            obj[2] = new SqlParameter("KQ_CH_ID", item.CH_ID);
            obj[3] = new SqlParameter("KQ_Username", item.Username);
            obj[4] = new SqlParameter("KQ_Diem", item.Diem);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_KetQua_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KetQua SelectById(Guid KQ_ID)
        {
            var Item = new KetQua();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KQ_ID", KQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_KetQua_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KetQuaCollection SelectAll()
        {
            var List = new KetQuaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_KetQua_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<KetQua> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<KetQua>("sp_tblAuto_KetQua_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static KetQua getFromReader(IDataReader rd)
        {
            var Item = new KetQua();
            if (rd.FieldExists("KQ_ID"))
            {
                Item.ID = (Guid)(rd["KQ_ID"]);
            }
            if (rd.FieldExists("KQ_LUOT_ID"))
            {
                Item.LUOT_ID = (Guid)(rd["KQ_LUOT_ID"]);
            }
            if (rd.FieldExists("KQ_CH_ID"))
            {
                Item.CH_ID = (Guid)(rd["KQ_CH_ID"]);
            }
            if (rd.FieldExists("KQ_Username"))
            {
                Item.Username = (String)(rd["KQ_Username"]);
            }
            if (rd.FieldExists("KQ_Diem"))
            {
                Item.Diem = (Int32)(rd["KQ_Diem"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static KetQua SelectByLuotIdChId(string LUOT_ID, string CH_ID)
        {
            var Item = new KetQua();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("LUOT_ID", LUOT_ID);
            obj[1] = new SqlParameter("CH_ID", CH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_KetQua_Select_SelectByLuotIdChId_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static KetQuaCollection SelectByLuotId(string LUOT_ID)
        {
            var List = new KetQuaCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LUOT_ID", LUOT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_KetQua_Select_SelectByLuotId_linhnx", obj))
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


