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
    #region LuotChoi
    #region BO
    public class LuotChoi : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ten { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 Diem { get; set; }
        #endregion
        #region Contructor
        public LuotChoi()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LuotChoiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LuotChoiCollection : BaseEntityCollection<LuotChoi>
    { }
    #endregion
    #region Dal
    public class LuotChoiDal
    {
        #region Methods

        public static void DeleteById(Guid LUOT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LUOT_ID", LUOT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_LuotChoi_Delete_DeleteById_linhnx", obj);
        }

        public static LuotChoi Insert(LuotChoi item)
        {
            var Item = new LuotChoi();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("LUOT_ID", item.ID);
            obj[1] = new SqlParameter("LUOT_Ten", item.Ten);
            obj[2] = new SqlParameter("LUOT_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("LUOT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("LUOT_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("LUOT_Diem", item.Diem);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_LuotChoi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LuotChoi Update(LuotChoi item)
        {
            var Item = new LuotChoi();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("LUOT_ID", item.ID);
            obj[1] = new SqlParameter("LUOT_Ten", item.Ten);
            obj[2] = new SqlParameter("LUOT_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("LUOT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("LUOT_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("LUOT_Diem", item.Diem);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_LuotChoi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LuotChoi SelectById(Guid LUOT_ID)
        {
            var Item = new LuotChoi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LUOT_ID", LUOT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_LuotChoi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LuotChoiCollection SelectAll()
        {
            var List = new LuotChoiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_LuotChoi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LuotChoi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<LuotChoi>("sp_tblAuto_LuotChoi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static LuotChoi getFromReader(IDataReader rd)
        {
            var Item = new LuotChoi();
            if (rd.FieldExists("LUOT_ID"))
            {
                Item.ID = (Guid)(rd["LUOT_ID"]);
            }
            if (rd.FieldExists("LUOT_Ten"))
            {
                Item.Ten = (String)(rd["LUOT_Ten"]);
            }
            if (rd.FieldExists("LUOT_Username"))
            {
                Item.Username = (String)(rd["LUOT_Username"]);
            }
            if (rd.FieldExists("LUOT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LUOT_NgayTao"]);
            }
            if (rd.FieldExists("LUOT_Diem"))
            {
                Item.Diem = (Int32)(rd["LUOT_Diem"]);
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


