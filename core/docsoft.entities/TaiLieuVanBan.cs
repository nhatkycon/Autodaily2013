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
    #region TaiLieuVanBan
    #region BO
    public class TaiLieuVanBan : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 VB_ID { get; set; }
        public String Ten { get; set; }
        public Int32 Loai { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public TaiLieuVanBan()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TaiLieuVanBanDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TaiLieuVanBanCollection : BaseEntityCollection<TaiLieuVanBan>
    { }
    #endregion
    #region Dal
    public class TaiLieuVanBanDal
    {
        #region Methods

        public static void DeleteById(Int32 TLVB_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TLVB_ID", TLVB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuVanBan_Delete_DeleteById_linhnx", obj);
        }

        public static TaiLieuVanBan Insert(TaiLieuVanBan Inserted)
        {
            TaiLieuVanBan Item = new TaiLieuVanBan();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("TLVB_VB_ID", Inserted.VB_ID);
            obj[1] = new SqlParameter("TLVB_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("TLVB_Loai", Inserted.Loai);
            obj[3] = new SqlParameter("TLVB_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("TLVB_NguoiTao", Inserted.NguoiTao);
            obj[5] = new SqlParameter("TLVB_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuVanBan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieuVanBan Update(TaiLieuVanBan Updated)
        {
            TaiLieuVanBan Item = new TaiLieuVanBan();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("TLVB_ID", Updated.ID);
            obj[1] = new SqlParameter("TLVB_VB_ID", Updated.VB_ID);
            obj[2] = new SqlParameter("TLVB_Ten", Updated.Ten);
            obj[3] = new SqlParameter("TLVB_Loai", Updated.Loai);
            obj[4] = new SqlParameter("TLVB_NgayTao", Updated.NgayTao);
            obj[5] = new SqlParameter("TLVB_NguoiTao", Updated.NguoiTao);
            obj[6] = new SqlParameter("TLVB_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuVanBan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieuVanBan SelectById(Int32 TLVB_ID)
        {
            TaiLieuVanBan Item = new TaiLieuVanBan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TLVB_ID", TLVB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuVanBan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TaiLieuVanBanCollection SelectAll()
        {
            TaiLieuVanBanCollection List = new TaiLieuVanBanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuVanBan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TaiLieuVanBan> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TaiLieuVanBan> pg = new Pager<TaiLieuVanBan>("sp_tblTaiLieuVanBan_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TaiLieuVanBan getFromReader(IDataReader rd)
        {
            TaiLieuVanBan Item = new TaiLieuVanBan();
            if (rd.FieldExists("TLVB_ID"))
            {
                Item.ID = (Int32)(rd["TLVB_ID"]);
            }
            if (rd.FieldExists("TLVB_VB_ID"))
            {
                Item.VB_ID = (Int32)(rd["TLVB_VB_ID"]);
            }
            if (rd.FieldExists("TLVB_Ten"))
            {
                Item.Ten = (String)(rd["TLVB_Ten"]);
            }
            if (rd.FieldExists("TLVB_Loai"))
            {
                Item.Loai = (Int32)(rd["TLVB_Loai"]);
            }
            if (rd.FieldExists("TLVB_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TLVB_NgayTao"]);
            }
            if (rd.FieldExists("TLVB_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TLVB_NguoiTao"]);
            }
            if (rd.FieldExists("TLVB_RowId"))
            {
                Item.RowId = (Guid)(rd["TLVB_RowId"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static TaiLieuVanBanCollection SelectByVanBan(string VB_ID)
        {
            TaiLieuVanBanCollection List = new TaiLieuVanBanCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTaiLieuVanBan_Select_SelectByVanBan_linhnx",obj))
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


