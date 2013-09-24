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
    #region NhomTin
    #region BO
    public class NhomTin : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 N_ID { get; set; }
        public Int32 T_ID { get; set; }
        #endregion
        #region Contructor
        public NhomTin()
        { }
        public NhomTin(Int32? id, Int32? n_id, Int32? t_id)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (n_id != null)
            {
                N_ID = n_id.Value;
            }
            if (t_id != null)
            {
                T_ID = t_id.Value;
            }

        }
        #endregion
        #region Customs properties
        public Tin _Tin { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return NhomTinDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class NhomTinCollection : BaseEntityCollection<NhomTin>
    { }
    #endregion
    #region Dal
    public class NhomTinDal
    {
        #region Methods

        public static void DeleteById(Int32 NT_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NT_ID", NT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Delete_DeleteById_linhnx", obj);
        }
        public static NhomTin Insert(NhomTin Inserted)
        {
            NhomTin Item = new NhomTin();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("NT_N_ID", Inserted.N_ID);
            obj[1] = new SqlParameter("NT_T_ID", Inserted.T_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static NhomTin Insert(Int32? id, Int32? n_id, Int32? t_id)
        {
            NhomTin Item = new NhomTin();
            SqlParameter[] obj = new SqlParameter[2];
            if (n_id != null)
            {
                obj[0] = new SqlParameter("NT_N_ID", n_id);
            }
            else
            {
                obj[0] = new SqlParameter("NT_N_ID", DBNull.Value);
            }
            if (t_id != null)
            {
                obj[1] = new SqlParameter("NT_T_ID", t_id);
            }
            else
            {
                obj[1] = new SqlParameter("NT_T_ID", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static NhomTin Update(NhomTin Updated)
        {
            NhomTin Item = new NhomTin();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("NT_ID", Updated.ID);
            obj[1] = new SqlParameter("NT_N_ID", Updated.N_ID);
            obj[2] = new SqlParameter("NT_T_ID", Updated.T_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        /// <summary>
        /// hampv
        /// </summary>
        /// <param name="ROLE_ID"></param>
        /// <param name="FN_List"></param>
        /// <param name="NguoiTao"></param>
        /// <returns></returns>
        public static NhomTin UpdateByTIN_IdDanhmucList(string TIN_ID, string DM_List)
        {
            NhomTin Item = new NhomTin();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            obj[1] = new SqlParameter("DM_List", DM_List);
           

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssNhomTin_Update_UpdateByDM_IdDanhmucList_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        
        public static NhomTin Update(Int32? id, Int32? n_id, Int32? t_id)
        {
            NhomTin Item = new NhomTin();
            SqlParameter[] obj = new SqlParameter[3];
            if (id != null)
            {
                obj[0] = new SqlParameter("NT_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("NT_ID", DBNull.Value);
            }
            if (n_id != null)
            {
                obj[1] = new SqlParameter("NT_N_ID", n_id);
            }
            else
            {
                obj[1] = new SqlParameter("NT_N_ID", DBNull.Value);
            }
            if (t_id != null)
            {
                obj[2] = new SqlParameter("NT_T_ID", t_id);
            }
            else
            {
                obj[2] = new SqlParameter("NT_T_ID", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static NhomTin SelectById(Int32 NT_ID)
        {
            NhomTin Item = new NhomTin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NT_ID", NT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static NhomTinCollection SelectAll()
        {
            NhomTinCollection List = new NhomTinCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<NhomTin> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<NhomTin> pg = new Pager<NhomTin>("tblRss_sp_tblNhomTin_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static NhomTin getFromReader(IDataReader rd)
        {
            NhomTin Item = new NhomTin();
            Tin _Item = new Tin();
            _Item = TinDal.getFromReader(rd);
            if (rd.FieldExists("NT_ID"))
            {
                Item.ID = (Int32)(rd["NT_ID"]);
            }
            if (rd.FieldExists("NT_N_ID"))
            {
                Item.N_ID = (Int32)(rd["NT_N_ID"]);
            }
            if (rd.FieldExists("NT_T_ID"))
            {
                Item.T_ID = (Int32)(rd["NT_T_ID"]);
            }
            Item._Tin = _Item;
            return Item;
        }
        #endregion
        #region Extend
        public static NhomTinCollection SelectByNhomId(SqlConnection con, string Nid)
        {
            NhomTinCollection List = new NhomTinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Nid", Nid);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Select_SelectByNid_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static NhomTinCollection SelectByNhomId(SqlConnection con, string Nid, string Top)
        {
            NhomTinCollection List = new NhomTinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Nid", Nid);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Select_SelectByNid_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static NhomTinCollection SelectByNhomId(string Nid)
        {
            NhomTinCollection List = new NhomTinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Nid", Nid);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Select_SelectByNid_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static void DeleteTinListByNid(string N_ID, string T_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Delete_DeleteTinList_linhnx", obj);
        }
        public static void DeleteByNIdAndTid(string N_ID, string T_ID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("N_ID", N_ID);
            obj[1] = new SqlParameter("T_ID", T_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_tblRssNhomTin_Delete_DeleteByTpIdAndTid_linhnx", obj);
        }
        public static NhomTinCollection SelectByNhomDanhMuc(SqlConnection con, int top, string DM_Ma)
        {
            NhomTinCollection List = new NhomTinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Select_SelectByNhomDanhMuc_linhnx", obj))
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
