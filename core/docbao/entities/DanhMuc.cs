using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using linh.core.dal;
using linh.controls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
namespace docbao.entitites
{
    #region DanhMuc
    #region BO
    public class DanhMuc : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 P_ID { get; set; }
        public String P_Ten { get; set; }
        public String P_Alias { get; set; }
        public Int32 ThuTu { get; set; }
        public String Ten { get; set; }
        public String Alias { get; set; }
        public String Keywords { get; set; }
        public String Description { get; set; }
        public Int32 TongSoTin { get; set; }
        public Int32 TongSoTinMoi { get; set; }
        public Boolean Active { get; set; }
        #endregion
        #region Contructor
        public DanhMuc()
        { }
        public DanhMuc(Int32? id, Int32? p_id, String p_ten, String p_alias, Int32? thutu, String ten, String alias, String keywords, String description, Int32? tongsotin, Int32? tongsotinmoi, Boolean? active)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (p_id != null)
            {
                P_ID = p_id.Value;
            }
            P_Ten = p_ten;
            P_Alias = p_alias;
            if (thutu != null)
            {
                ThuTu = thutu.Value;
            }
            Ten = ten;
            Alias = alias;
            Keywords = keywords;
            Description = description;
            if (tongsotin != null)
            {
                TongSoTin = tongsotin.Value;
            }
            if (tongsotinmoi != null)
            {
                TongSoTinMoi = tongsotinmoi.Value;
            }
            if (active != null)
            {
                Active = active.Value;
            }

        }
        #endregion
        #region Customs properties
        public int Level { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DanhMucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DanhMucCollection : BaseEntityCollection<DanhMuc>
    { }
    #endregion
    #region Dal
    public class DanhMucDal
    {
        #region Methods

        public static void DeleteById(Int32 DM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Delete_DeleteById_linhnx", obj);
        }
        public static DanhMuc Insert(DanhMuc Inserted)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("DM_P_ID", Inserted.P_ID);
            obj[1] = new SqlParameter("DM_P_Ten", Inserted.P_Ten);
            obj[2] = new SqlParameter("DM_P_Alias", Inserted.P_Alias);
            obj[3] = new SqlParameter("DM_ThuTu", Inserted.ThuTu);
            obj[4] = new SqlParameter("DM_Ten", Inserted.Ten);
            obj[5] = new SqlParameter("DM_Alias", Inserted.Alias);
            obj[6] = new SqlParameter("DM_Keywords", Inserted.Keywords);
            obj[7] = new SqlParameter("DM_Description", Inserted.Description);
            obj[8] = new SqlParameter("DM_TongSoTin", Inserted.TongSoTin);
            obj[9] = new SqlParameter("DM_TongSoTinMoi", Inserted.TongSoTinMoi);
            obj[10] = new SqlParameter("DM_Active", Inserted.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc Insert(Int32? id, Int32? p_id, String p_ten, String p_alias, Int32? thutu, String ten, String alias, String keywords, String description, Int32? tongsotin, Int32? tongsotinmoi, Boolean? active)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[11];
            if (p_id != null)
            {
                obj[0] = new SqlParameter("DM_P_ID", p_id);
            }
            else
            {
                obj[0] = new SqlParameter("DM_P_ID", DBNull.Value);
            }
            if (p_ten != null)
            {
                obj[1] = new SqlParameter("DM_P_Ten", p_ten);
            }
            else
            {
                obj[1] = new SqlParameter("DM_P_Ten", DBNull.Value);
            }
            if (p_alias != null)
            {
                obj[2] = new SqlParameter("DM_P_Alias", p_alias);
            }
            else
            {
                obj[2] = new SqlParameter("DM_P_Alias", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[3] = new SqlParameter("DM_ThuTu", thutu);
            }
            else
            {
                obj[3] = new SqlParameter("DM_ThuTu", DBNull.Value);
            }
            if (ten != null)
            {
                obj[4] = new SqlParameter("DM_Ten", ten);
            }
            else
            {
                obj[4] = new SqlParameter("DM_Ten", DBNull.Value);
            }
            if (alias != null)
            {
                obj[5] = new SqlParameter("DM_Alias", alias);
            }
            else
            {
                obj[5] = new SqlParameter("DM_Alias", DBNull.Value);
            }
            if (keywords != null)
            {
                obj[6] = new SqlParameter("DM_Keywords", keywords);
            }
            else
            {
                obj[6] = new SqlParameter("DM_Keywords", DBNull.Value);
            }
            if (description != null)
            {
                obj[7] = new SqlParameter("DM_Description", description);
            }
            else
            {
                obj[7] = new SqlParameter("DM_Description", DBNull.Value);
            }
            if (tongsotin != null)
            {
                obj[8] = new SqlParameter("DM_TongSoTin", tongsotin);
            }
            else
            {
                obj[8] = new SqlParameter("DM_TongSoTin", DBNull.Value);
            }
            if (tongsotinmoi != null)
            {
                obj[9] = new SqlParameter("DM_TongSoTinMoi", tongsotinmoi);
            }
            else
            {
                obj[9] = new SqlParameter("DM_TongSoTinMoi", DBNull.Value);
            }
            if (active != null)
            {
                obj[10] = new SqlParameter("DM_Active", active);
            }
            else
            {
                obj[10] = new SqlParameter("DM_Active", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc Update(DanhMuc Updated)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("DM_ID", Updated.ID);
            obj[1] = new SqlParameter("DM_P_ID", Updated.P_ID);
            obj[2] = new SqlParameter("DM_P_Ten", Updated.P_Ten);
            obj[3] = new SqlParameter("DM_P_Alias", Updated.P_Alias);
            obj[4] = new SqlParameter("DM_ThuTu", Updated.ThuTu);
            obj[5] = new SqlParameter("DM_Ten", Updated.Ten);
            obj[6] = new SqlParameter("DM_Alias", Updated.Alias);
            obj[7] = new SqlParameter("DM_Keywords", Updated.Keywords);
            obj[8] = new SqlParameter("DM_Description", Updated.Description);
            obj[9] = new SqlParameter("DM_TongSoTin", Updated.TongSoTin);
            obj[10] = new SqlParameter("DM_TongSoTinMoi", Updated.TongSoTinMoi);
            obj[11] = new SqlParameter("DM_Active", Updated.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc Update(Int32? id, Int32? p_id, String p_ten, String p_alias, Int32? thutu, String ten, String alias, String keywords, String description, Int32? tongsotin, Int32? tongsotinmoi, Boolean? active)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[12];
            if (id != null)
            {
                obj[0] = new SqlParameter("DM_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (p_id != null)
            {
                obj[1] = new SqlParameter("DM_P_ID", p_id);
            }
            else
            {
                obj[1] = new SqlParameter("DM_P_ID", DBNull.Value);
            }
            if (p_ten != null)
            {
                obj[2] = new SqlParameter("DM_P_Ten", p_ten);
            }
            else
            {
                obj[2] = new SqlParameter("DM_P_Ten", DBNull.Value);
            }
            if (p_alias != null)
            {
                obj[3] = new SqlParameter("DM_P_Alias", p_alias);
            }
            else
            {
                obj[3] = new SqlParameter("DM_P_Alias", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[4] = new SqlParameter("DM_ThuTu", thutu);
            }
            else
            {
                obj[4] = new SqlParameter("DM_ThuTu", DBNull.Value);
            }
            if (ten != null)
            {
                obj[5] = new SqlParameter("DM_Ten", ten);
            }
            else
            {
                obj[5] = new SqlParameter("DM_Ten", DBNull.Value);
            }
            if (alias != null)
            {
                obj[6] = new SqlParameter("DM_Alias", alias);
            }
            else
            {
                obj[6] = new SqlParameter("DM_Alias", DBNull.Value);
            }
            if (keywords != null)
            {
                obj[7] = new SqlParameter("DM_Keywords", keywords);
            }
            else
            {
                obj[7] = new SqlParameter("DM_Keywords", DBNull.Value);
            }
            if (description != null)
            {
                obj[8] = new SqlParameter("DM_Description", description);
            }
            else
            {
                obj[8] = new SqlParameter("DM_Description", DBNull.Value);
            }
            if (tongsotin != null)
            {
                obj[9] = new SqlParameter("DM_TongSoTin", tongsotin);
            }
            else
            {
                obj[9] = new SqlParameter("DM_TongSoTin", DBNull.Value);
            }
            if (tongsotinmoi != null)
            {
                obj[10] = new SqlParameter("DM_TongSoTinMoi", tongsotinmoi);
            }
            else
            {
                obj[10] = new SqlParameter("DM_TongSoTinMoi", DBNull.Value);
            }
            if (active != null)
            {
                obj[11] = new SqlParameter("DM_Active", active);
            }
            else
            {
                obj[11] = new SqlParameter("DM_Active", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc SelectById(Int32 DM_ID)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMucCollection SelectAll()
        {
            DanhMucCollection List = new DanhMucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static List<DanhMuc> SelectAll(SqlConnection con)
        {
            List<DanhMuc> List = new List<DanhMuc>();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DanhMuc> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<DanhMuc> pg = new Pager<DanhMuc>("tblRss_sp_tblRssDanhMuc_Pager_Normal_linhnx", "q", 200, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static DanhMuc getFromReader(IDataReader rd)
        {
            DanhMuc Item = new DanhMuc();
            if (rd.FieldExists("DM_ID"))
            {
                Item.ID = (Int32)(rd["DM_ID"]);
            }
            if (rd.FieldExists("DM_P_ID"))
            {
                Item.P_ID = (Int32)(rd["DM_P_ID"]);
            }
            if (rd.FieldExists("DM_P_Ten"))
            {
                Item.P_Ten = (String)(rd["DM_P_Ten"]);
            }
            if (rd.FieldExists("DM_P_Alias"))
            {
                Item.P_Alias = (String)(rd["DM_P_Alias"]);
            }
            if (rd.FieldExists("DM_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                Item.Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("DM_Alias"))
            {
                Item.Alias = (String)(rd["DM_Alias"]);
            }
            if (rd.FieldExists("DM_Keywords"))
            {
                Item.Keywords = (String)(rd["DM_Keywords"]);
            }
            if (rd.FieldExists("DM_Description"))
            {
                Item.Description = (String)(rd["DM_Description"]);
            }
            if (rd.FieldExists("DM_TongSoTin"))
            {
                Item.TongSoTin = (Int32)(rd["DM_TongSoTin"]);
            }
            if (rd.FieldExists("DM_TongSoTinMoi"))
            {
                Item.TongSoTinMoi = (Int32)(rd["DM_TongSoTinMoi"]);
            }
            if (rd.FieldExists("DM_Active"))
            {
                Item.Active = (Boolean)(rd["DM_Active"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static DanhMuc SelectByAlias(string DM_Alias)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_Alias", DM_Alias);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Select_SelectByAlias_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc SelectByAlias(SqlConnection con, string DM_Alias)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_Alias", DM_Alias);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Select_SelectByAlias_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMucCollection SelectPid()
        {
            DanhMucCollection List = new DanhMucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssDanhMuc_Select_SelectPid_linhnx"))
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