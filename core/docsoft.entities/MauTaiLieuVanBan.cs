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
    #region MauTaiLieuVanBan
    #region BO
    public class MauTaiLieuVanBan : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 MTL_ID { get; set; }
        public Int32 VB_ID { get; set; }
        public Int32 Loai { get; set; }
        #endregion
        #region Contructor
        public MauTaiLieuVanBan()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return MauTaiLieuVanBanDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class MauTaiLieuVanBanCollection : BaseEntityCollection<MauTaiLieuVanBan>
    { }
    #endregion
    #region Dal
    public class MauTaiLieuVanBanDal
    {
        #region Methods

        public static void DeleteById(Int32 MTLVB_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MTLVB_ID", MTLVB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieuVanBan_Delete_DeleteById_linhnx", obj);
        }

        public static MauTaiLieuVanBan Insert(MauTaiLieuVanBan Inserted)
        {
            MauTaiLieuVanBan Item = new MauTaiLieuVanBan();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("MTLVB_MTL_ID", Inserted.MTL_ID);
            obj[1] = new SqlParameter("MTLVB_VB_ID", Inserted.VB_ID);
            obj[2] = new SqlParameter("MTLVB_Loai", Inserted.Loai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieuVanBan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static MauTaiLieuVanBan Update(MauTaiLieuVanBan Updated)
        {
            MauTaiLieuVanBan Item = new MauTaiLieuVanBan();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("MTLVB_ID", Updated.ID);
            obj[1] = new SqlParameter("MTLVB_MTL_ID", Updated.MTL_ID);
            obj[2] = new SqlParameter("MTLVB_VB_ID", Updated.VB_ID);
            obj[3] = new SqlParameter("MTLVB_Loai", Updated.Loai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieuVanBan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static MauTaiLieuVanBan SelectById(Int32 MTLVB_ID)
        {
            MauTaiLieuVanBan Item = new MauTaiLieuVanBan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("MTLVB_ID", MTLVB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieuVanBan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static MauTaiLieuVanBanCollection SelectAll()
        {
            MauTaiLieuVanBanCollection List = new MauTaiLieuVanBanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblMauTaiLieuVanBan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<MauTaiLieuVanBan> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<MauTaiLieuVanBan> pg = new Pager<MauTaiLieuVanBan>("sp_tblMauTaiLieuVanBan_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static MauTaiLieuVanBan getFromReader(IDataReader rd)
        {
            MauTaiLieuVanBan Item = new MauTaiLieuVanBan();
            if (rd.FieldExists("MTLVB_ID"))
            {
                Item.ID = (Int32)(rd["MTLVB_ID"]);
            }
            if (rd.FieldExists("MTLVB_MTL_ID"))
            {
                Item.MTL_ID = (Int32)(rd["MTLVB_MTL_ID"]);
            }
            if (rd.FieldExists("MTLVB_VB_ID"))
            {
                Item.VB_ID = (Int32)(rd["MTLVB_VB_ID"]);
            }
            if (rd.FieldExists("MTLVB_Loai"))
            {
                Item.Loai = (Int32)(rd["MTLVB_Loai"]);
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


