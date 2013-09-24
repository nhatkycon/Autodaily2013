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
    #region Bao
    #region BO
    public class Bao : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Url { get; set; }
        public String RssUrl { get; set; }
        public Int32 TotalTin { get; set; }
        #endregion
        #region Contructor
        public Bao()
        { }
        public Bao(Int32? id, String ten, String url, String rssurl, Int32? totaltin)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            Ten = ten;
            Url = url;
            RssUrl = rssurl;
            if (totaltin != null)
            {
                TotalTin = totaltin.Value;
            }

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BaoDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BaoCollection : BaseEntityCollection<Bao>
    { }
    #endregion
    #region Dal
    public class BaoDal
    {
        #region Methods

        public static void DeleteById(Int32 B_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("B_ID", B_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBao_Delete_DeleteById_linhnx", obj);
        }
        public static Bao Insert(Bao Inserted)
        {
            Bao Item = new Bao();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("B_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("B_Url", Inserted.Url);
            obj[2] = new SqlParameter("B_RssUrl", Inserted.RssUrl);
            obj[3] = new SqlParameter("B_TotalTin", Inserted.TotalTin);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBao_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Bao Insert(Int32? id, String ten, String url, String rssurl, Int32? totaltin)
        {
            Bao Item = new Bao();
            SqlParameter[] obj = new SqlParameter[4];
            if (ten != null)
            {
                obj[0] = new SqlParameter("B_Ten", ten);
            }
            else
            {
                obj[0] = new SqlParameter("B_Ten", DBNull.Value);
            }
            if (url != null)
            {
                obj[1] = new SqlParameter("B_Url", url);
            }
            else
            {
                obj[1] = new SqlParameter("B_Url", DBNull.Value);
            }
            if (rssurl != null)
            {
                obj[2] = new SqlParameter("B_RssUrl", rssurl);
            }
            else
            {
                obj[2] = new SqlParameter("B_RssUrl", DBNull.Value);
            }
            if (totaltin != null)
            {
                obj[3] = new SqlParameter("B_TotalTin", totaltin);
            }
            else
            {
                obj[3] = new SqlParameter("B_TotalTin", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBao_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Bao Update(Bao Updated)
        {
            Bao Item = new Bao();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("B_ID", Updated.ID);
            obj[1] = new SqlParameter("B_Ten", Updated.Ten);
            obj[2] = new SqlParameter("B_Url", Updated.Url);
            obj[3] = new SqlParameter("B_RssUrl", Updated.RssUrl);
            obj[4] = new SqlParameter("B_TotalTin", Updated.TotalTin);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBao_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Bao Update(Int32? id, String ten, String url, String rssurl, Int32? totaltin)
        {
            Bao Item = new Bao();
            SqlParameter[] obj = new SqlParameter[5];
            if (id != null)
            {
                obj[0] = new SqlParameter("B_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("B_ID", DBNull.Value);
            }
            if (ten != null)
            {
                obj[1] = new SqlParameter("B_Ten", ten);
            }
            else
            {
                obj[1] = new SqlParameter("B_Ten", DBNull.Value);
            }
            if (url != null)
            {
                obj[2] = new SqlParameter("B_Url", url);
            }
            else
            {
                obj[2] = new SqlParameter("B_Url", DBNull.Value);
            }
            if (rssurl != null)
            {
                obj[3] = new SqlParameter("B_RssUrl", rssurl);
            }
            else
            {
                obj[3] = new SqlParameter("B_RssUrl", DBNull.Value);
            }
            if (totaltin != null)
            {
                obj[4] = new SqlParameter("B_TotalTin", totaltin);
            }
            else
            {
                obj[4] = new SqlParameter("B_TotalTin", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBao_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Bao SelectById(Int32 B_ID)
        {
            Bao Item = new Bao();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("B_ID", B_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBao_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static BaoCollection SelectAll()
        {
            BaoCollection List = new BaoCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBao_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Bao> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Bao> pg = new Pager<Bao>("tblRss_sp_tblBao_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Bao getFromReader(IDataReader rd)
        {
            Bao Item = new Bao();
            if (rd.FieldExists("B_ID"))
            {
                Item.ID = (Int32)(rd["B_ID"]);
            }
            if (rd.FieldExists("B_Ten"))
            {
                Item.Ten = (String)(rd["B_Ten"]);
            }
            if (rd.FieldExists("B_Url"))
            {
                Item.Url = (String)(rd["B_Url"]);
            }
            if (rd.FieldExists("B_RssUrl"))
            {
                Item.RssUrl = (String)(rd["B_RssUrl"]);
            }
            if (rd.FieldExists("B_TotalTin"))
            {
                Item.TotalTin = (Int32)(rd["B_TotalTin"]);
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
