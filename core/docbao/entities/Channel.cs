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
    #region Channel
    #region BO
    public class Channel : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public Int32 B_ID { get; set; }
        public Int32 DM_ID { get; set; }
        public String DM_Ten { get; set; }
        public String RssUrl { get; set; }
        public Guid RowId { get; set; }
        public Int32 TongSoLink { get; set; }
        public Boolean IsRss { get; set; }
        public String Class { get; set; }
        public String Class_Title { get; set; }
        public String Class_Mota { get; set; }
        public String Class_Detail { get; set; }
        public String Class_Item { get; set; }
        #endregion
        #region Contructor
        public Channel()
        { }
        public Channel(Int32? id, String ten, Int32? b_id, Int32? dm_id, String dm_ten, String rssurl, Guid? rowid, Int32? tongsolink, Boolean isRss, String _class, String _Class_title, String _Class_Mota, String _Class_Detail, String _Class_Item)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            Ten = ten;
            if (b_id != null)
            {
                B_ID = b_id.Value;
            }
            if (dm_id != null)
            {
                DM_ID = dm_id.Value;
            }
            DM_Ten = dm_ten;
            RssUrl = rssurl;
            if (rowid != null)
            {
                RowId = rowid.Value;
            }
            if (tongsolink != null)
            {
                TongSoLink = tongsolink.Value;
            }
            if (isRss != null)
            {
                IsRss = isRss;
            }
            if (_class != null)
            {
                Class = _class;
            }
            if (_class != null)
            {
                Class = _class;

            }
            if (_Class_title != null)
            {
                Class_Title = _Class_title;
            }
            if (_Class_Mota != null)
            {
                Class_Mota = _Class_Mota;
            }
            if (_Class_Detail != null)
            {
                Class_Detail = _Class_Detail;
            }
            if (_Class_Item != null)
            {
                Class_Item = _Class_Item;
            }
        }
        #endregion
        #region Customs properties
        public string B_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ChannelDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ChannelCollection : BaseEntityCollection<Channel>
    { }
    #endregion
    #region Dal
    public class ChannelDal
    {
        #region Methods

        public static void DeleteById(Int32 C_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("C_ID", C_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssChannel_Delete_DeleteById_linhnx", obj);
        }
        public static Channel Insert(Channel Inserted)
        {
            Channel Item = new Channel();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("C_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("C_B_ID", Inserted.B_ID);
            obj[2] = new SqlParameter("C_DM_ID", Inserted.DM_ID);
            obj[3] = new SqlParameter("C_DM_Ten", Inserted.DM_Ten);
            obj[4] = new SqlParameter("C_RssUrl", Inserted.RssUrl);
            obj[5] = new SqlParameter("C_RowId", Inserted.RowId);
            obj[6] = new SqlParameter("C_TongSoLink", Inserted.TongSoLink);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssChannel_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Channel Insert(Int32? id, String ten, Int32? b_id, Int32? dm_id, String dm_ten, String rssurl, Guid? rowid, Int32? tongsolink)
        {
            Channel Item = new Channel();
            SqlParameter[] obj = new SqlParameter[7];
            if (ten != null)
            {
                obj[0] = new SqlParameter("C_Ten", ten);
            }
            else
            {
                obj[0] = new SqlParameter("C_Ten", DBNull.Value);
            }
            if (b_id != null)
            {
                obj[1] = new SqlParameter("C_B_ID", b_id);
            }
            else
            {
                obj[1] = new SqlParameter("C_B_ID", DBNull.Value);
            }
            if (dm_id != null)
            {
                obj[2] = new SqlParameter("C_DM_ID", dm_id);
            }
            else
            {
                obj[2] = new SqlParameter("C_DM_ID", DBNull.Value);
            }
            if (dm_ten != null)
            {
                obj[3] = new SqlParameter("C_DM_Ten", dm_ten);
            }
            else
            {
                obj[3] = new SqlParameter("C_DM_Ten", DBNull.Value);
            }
            if (rssurl != null)
            {
                obj[4] = new SqlParameter("C_RssUrl", rssurl);
            }
            else
            {
                obj[4] = new SqlParameter("C_RssUrl", DBNull.Value);
            }
            if (rowid != null)
            {
                obj[5] = new SqlParameter("C_RowId", rowid);
            }
            else
            {
                obj[5] = new SqlParameter("C_RowId", DBNull.Value);
            }
            if (tongsolink != null)
            {
                obj[6] = new SqlParameter("C_TongSoLink", tongsolink);
            }
            else
            {
                obj[6] = new SqlParameter("C_TongSoLink", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssChannel_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Channel Update(Channel Updated)
        {
            Channel Item = new Channel();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("C_ID", Updated.ID);
            obj[1] = new SqlParameter("C_Ten", Updated.Ten);
            obj[2] = new SqlParameter("C_B_ID", Updated.B_ID);
            obj[3] = new SqlParameter("C_DM_ID", Updated.DM_ID);
            obj[4] = new SqlParameter("C_DM_Ten", Updated.DM_Ten);
            obj[5] = new SqlParameter("C_RssUrl", Updated.RssUrl);
            obj[6] = new SqlParameter("C_RowId", Updated.RowId);
            obj[7] = new SqlParameter("C_TongSoLink", Updated.TongSoLink);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssChannel_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Channel Update(Int32? id, String ten, Int32? b_id, Int32? dm_id, String dm_ten, String rssurl, Guid? rowid, Int32? tongsolink)
        {
            Channel Item = new Channel();
            SqlParameter[] obj = new SqlParameter[8];
            if (id != null)
            {
                obj[0] = new SqlParameter("C_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("C_ID", DBNull.Value);
            }
            if (ten != null)
            {
                obj[1] = new SqlParameter("C_Ten", ten);
            }
            else
            {
                obj[1] = new SqlParameter("C_Ten", DBNull.Value);
            }
            if (b_id != null)
            {
                obj[2] = new SqlParameter("C_B_ID", b_id);
            }
            else
            {
                obj[2] = new SqlParameter("C_B_ID", DBNull.Value);
            }
            if (dm_id != null)
            {
                obj[3] = new SqlParameter("C_DM_ID", dm_id);
            }
            else
            {
                obj[3] = new SqlParameter("C_DM_ID", DBNull.Value);
            }
            if (dm_ten != null)
            {
                obj[4] = new SqlParameter("C_DM_Ten", dm_ten);
            }
            else
            {
                obj[4] = new SqlParameter("C_DM_Ten", DBNull.Value);
            }
            if (rssurl != null)
            {
                obj[5] = new SqlParameter("C_RssUrl", rssurl);
            }
            else
            {
                obj[5] = new SqlParameter("C_RssUrl", DBNull.Value);
            }
            if (rowid != null)
            {
                obj[6] = new SqlParameter("C_RowId", rowid);
            }
            else
            {
                obj[6] = new SqlParameter("C_RowId", DBNull.Value);
            }
            if (tongsolink != null)
            {
                obj[7] = new SqlParameter("C_TongSoLink", tongsolink);
            }
            else
            {
                obj[7] = new SqlParameter("C_TongSoLink", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssChannel_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Channel SelectById(Int32 C_ID)
        {
            Channel Item = new Channel();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("C_ID", C_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssChannel_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ChannelCollection SelectAll()
        {
            ChannelCollection List = new ChannelCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssChannel_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Channel> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Channel> pg = new Pager<Channel>("tblRss_sp_tblChannel_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Channel getFromReader(IDataReader rd)
        {
            Channel Item = new Channel();
            if (rd.FieldExists("C_ID"))
            {
                Item.ID = (Int32)(rd["C_ID"]);
            }
            if (rd.FieldExists("C_Ten"))
            {
                Item.Ten = (String)(rd["C_Ten"]);
            }
            if (rd.FieldExists("C_B_ID"))
            {
                Item.B_ID = (Int32)(rd["C_B_ID"]);
            }
            if (rd.FieldExists("C_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["C_DM_ID"]);
            }
            if (rd.FieldExists("C_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["C_DM_Ten"]);
            }
            if (rd.FieldExists("C_RssUrl"))
            {
                Item.RssUrl = (String)(rd["C_RssUrl"]);
            }
            if (rd.FieldExists("C_RowId"))
            {
                Item.RowId = (Guid)(rd["C_RowId"]);
            }
            if (rd.FieldExists("C_TongSoLink"))
            {
                Item.TongSoLink = (Int32)(rd["C_TongSoLink"]);
            }
            if (rd.FieldExists("C_B_Ten"))
            {
                Item.B_Ten = (String)(rd["C_B_Ten"]);
            }
            if (rd.FieldExists("C_IsRss"))
            {
                Item.IsRss = (Boolean)(rd["C_IsRss"]);
            }
            if (rd.FieldExists("C_Class"))
            {
                Item.Class = (String)(rd["C_Class"]);
            }
            if (rd.FieldExists("C_Class_Title"))
            {
                Item.Class_Title = (String)(rd["C_Class_Title"]);
            }
            if (rd.FieldExists("C_Class_Mota"))
            {
                Item.Class_Mota = (String)(rd["C_Class_Mota"]);
            }
            if (rd.FieldExists("C_Class_Detail"))
            {
                Item.Class_Detail = (String)(rd["C_Class_Detail"]);
            }
            if (rd.FieldExists("C_Class_Item"))
            {
                Item.Class_Item = (String)(rd["C_Class_Item"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static ChannelCollection SelectByDmIdByBid(string DM_ID, string B_ID)
        {
            ChannelCollection List = new ChannelCollection();
            SqlParameter[] obj = new SqlParameter[2];
            if (String.IsNullOrEmpty(DM_ID))
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            else
            {

                obj[0] = new SqlParameter("DM_ID", DM_ID);
            }
            if (String.IsNullOrEmpty(B_ID))
            {
                obj[1] = new SqlParameter("B_ID", DBNull.Value);
            }
            else
            {

                obj[1] = new SqlParameter("B_ID", B_ID);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssChannel_Select_SelectByDmIdByBid_linhnx", obj))
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
