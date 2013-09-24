using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using System.Data;
using System.Data.SqlClient;
using linh.core;
namespace linh.frm
{
    #region linhLayout
    #region BO
    public class linhLayout : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 MEM_ID { get; set; }
        public String Ten { get; set; }
        public String Width { get; set; }
        public Boolean Show { get; set; }
        public Int32 ThuTu { get; set; }
        #endregion
        #region Contructor
        public linhLayout()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return linhLayoutDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class linhLayoutCollection : BaseEntityCollection<linhLayout>
    { }
    #endregion
    #region Dal
    public class linhLayoutDal
    {
        #region Methods

        public static void DeleteById(Int32 LAY_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LAY_ID", LAY_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tbllinhLayout_Delete_DeleteById_linhnx", obj);
        }

        public static linhLayout Insert(linhLayout Inserted)
        {
            linhLayout Item = new linhLayout();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("LAY_MEM_ID", Inserted.MEM_ID);
            obj[1] = new SqlParameter("LAY_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("LAY_Width", Inserted.Width);
            obj[3] = new SqlParameter("LAY_Show", Inserted.Show);
            obj[4] = new SqlParameter("LAY_ThuTu", Inserted.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tbllinhLayout_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static linhLayout Update(linhLayout Updated)
        {
            linhLayout Item = new linhLayout();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("LAY_ID", Updated.ID);
            obj[1] = new SqlParameter("LAY_MEM_ID", Updated.MEM_ID);
            obj[2] = new SqlParameter("LAY_Ten", Updated.Ten);
            obj[3] = new SqlParameter("LAY_Width", Updated.Width);
            obj[4] = new SqlParameter("LAY_Show", Updated.Show);
            obj[5] = new SqlParameter("LAY_ThuTu", Updated.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tbllinhLayout_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static linhLayout SelectById(Int32 LAY_ID)
        {
            linhLayout Item = new linhLayout();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LAY_ID", LAY_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tbllinhLayout_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static linhLayoutCollection SelectByUsername(string Username)
        {
            linhLayoutCollection List = new linhLayoutCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tbllinhLayout_Select_byUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static linhLayoutCollection SelectAll()
        {
            linhLayoutCollection List = new linhLayoutCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tbllinhLayout_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<linhLayout> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<linhLayout> pg = new Pager<linhLayout>("sp_tbllinhLayout_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static linhLayout getFromReader(IDataReader rd)
        {
            linhLayout Item = new linhLayout();
            Item.ID = (Int32)(rd["LAY_ID"]);
            Item.MEM_ID = (Int32)(rd["LAY_MEM_ID"]);
            Item.Ten = (String)(rd["LAY_Ten"]);
            Item.Width = (String)(rd["LAY_Width"]);
            Item.Show = (Boolean)(rd["LAY_Show"]);
            Item.ThuTu = (Int32)(rd["LAY_ThuTu"]);
            return Item;
        }
        #endregion
    }
    #endregion
    #endregion
}

