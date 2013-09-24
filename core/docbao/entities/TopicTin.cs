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
using System.Web;
using linh.common;
namespace docbao.entitites
{
    #region TopicTin
    #region BO
    public class TopicTin : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 TP_ID { get; set; }
        public Int32 T_ID { get; set; }
        public Int32 ThuTu { get; set; }
        #endregion
        #region Contructor
        public TopicTin()
        { }
        public TopicTin(Int32? id, Int32? tp_id, Int32? t_id, Int32? thutu)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (tp_id != null)
            {
                TP_ID = tp_id.Value;
            }
            if (t_id != null)
            {
                T_ID = t_id.Value;
            }
            if (thutu != null)
            {
                ThuTu = thutu.Value;
            }

        }
        #endregion
        #region Customs properties
        public Tin _Tin { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TopicTinDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TopicTinCollection : BaseEntityCollection<TopicTin>
    { }
    #endregion
    #region Dal
    public class TopicTinDal
    {
        #region Methods

        public static void DeleteById(Int32 TPT_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TPT_ID", TPT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Delete_DeleteById_linhnx", obj);
        }
        public static TopicTin Insert(TopicTin Inserted)
        {
            TopicTin Item = new TopicTin();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TPT_TP_ID", Inserted.TP_ID);
            obj[1] = new SqlParameter("TPT_T_ID", Inserted.T_ID);
            obj[2] = new SqlParameter("TPT_ThuTu", Inserted.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TopicTin Insert(Int32? id, Int32? tp_id, Int32? t_id, Int32? thutu)
        {
            TopicTin Item = new TopicTin();
            SqlParameter[] obj = new SqlParameter[3];
            if (tp_id != null)
            {
                obj[0] = new SqlParameter("TPT_TP_ID", tp_id);
            }
            else
            {
                obj[0] = new SqlParameter("TPT_TP_ID", DBNull.Value);
            }
            if (t_id != null)
            {
                obj[1] = new SqlParameter("TPT_T_ID", t_id);
            }
            else
            {
                obj[1] = new SqlParameter("TPT_T_ID", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[2] = new SqlParameter("TPT_ThuTu", thutu);
            }
            else
            {
                obj[2] = new SqlParameter("TPT_ThuTu", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TopicTin Update(TopicTin Updated)
        {
            TopicTin Item = new TopicTin();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("TPT_ID", Updated.ID);
            obj[1] = new SqlParameter("TPT_TP_ID", Updated.TP_ID);
            obj[2] = new SqlParameter("TPT_T_ID", Updated.T_ID);
            obj[3] = new SqlParameter("TPT_ThuTu", Updated.ThuTu);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TopicTin Update(Int32? id, Int32? tp_id, Int32? t_id, Int32? thutu)
        {
            TopicTin Item = new TopicTin();
            SqlParameter[] obj = new SqlParameter[4];
            if (id != null)
            {
                obj[0] = new SqlParameter("TPT_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("TPT_ID", DBNull.Value);
            }
            if (tp_id != null)
            {
                obj[1] = new SqlParameter("TPT_TP_ID", tp_id);
            }
            else
            {
                obj[1] = new SqlParameter("TPT_TP_ID", DBNull.Value);
            }
            if (t_id != null)
            {
                obj[2] = new SqlParameter("TPT_T_ID", t_id);
            }
            else
            {
                obj[2] = new SqlParameter("TPT_T_ID", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[3] = new SqlParameter("TPT_ThuTu", thutu);
            }
            else
            {
                obj[3] = new SqlParameter("TPT_ThuTu", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TopicTin SelectById(Int32 TPT_ID)
        {
            TopicTin Item = new TopicTin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TPT_ID", TPT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TopicTinCollection SelectAll()
        {
            TopicTinCollection List = new TopicTinCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TopicTin> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TopicTin> pg = new Pager<TopicTin>("tblRss_sp_tblTopicTin_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static TopicTin getFromReader(IDataReader rd)
        {
            TopicTin Item = new TopicTin();
            Tin _Item = new Tin();
            _Item = TinDal.getFromReader(rd);
            if (rd.FieldExists("TPT_ID"))
            {
                Item.ID = (Int32)(rd["TPT_ID"]);
            }
            if (rd.FieldExists("TPT_TP_ID"))
            {
                Item.TP_ID = (Int32)(rd["TPT_TP_ID"]);
            }
            if (rd.FieldExists("TPT_T_ID"))
            {
                Item.T_ID = (Int32)(rd["TPT_T_ID"]);
            }
            if (rd.FieldExists("TPT_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TPT_ThuTu"]);
            }
            Item._Tin = _Item;
            return Item;
        }
        #endregion
        #region Extend
        public static TopicTinCollection SelectByTopicId(string TpId)
        {
            TopicTinCollection List = new TopicTinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TpId", TpId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Select_SelectByTopicId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static void DeleteTinListByTpId(string TP_ID, string T_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Delete_DeleteTinListByTpId_linhnx", obj);
        }
        public static void DeleteByTpIdAndTid(string TP_ID,string T_ID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TP_ID", TP_ID);
            obj[1] = new SqlParameter("T_ID", T_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopicTin_Delete_DeleteByTpIdAndTid_linhnx", obj);
        }
        #endregion
    }
    #endregion
    #endregion
}
