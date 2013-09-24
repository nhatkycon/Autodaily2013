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
    #region Video
    #region BO
    public class Video : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public String Url { get; set; }
        public String YID { get; set; }
        public String Ten { get; set; }
        public String Anh { get; set; }
        public String MoTa { get; set; }
        public Boolean Home { get; set; }
        public Boolean Hot { get; set; }
        public Boolean Hot1 { get; set; }
        public Boolean Hot2 { get; set; }
        public Boolean Hot3 { get; set; }
        public Boolean Active { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 Views { get; set; }
        public Int32 Diem { get; set; }
        #endregion
        #region Contructor
        public Video()
        { }
        public Video(Int32? id, Int32? dm_id, String url, String yid, String ten, String anh, String mota, Boolean? home, Boolean? hot, Boolean? hot1, Boolean? hot2, Boolean? hot3, Boolean? active, DateTime? ngaytao, Int32? views, Int32? diem)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (dm_id != null)
            {
                DM_ID = dm_id.Value;
            }
            Url = url;
            YID = yid;
            Ten = ten;
            Anh = anh;
            MoTa = mota;
            if (home != null)
            {
                Home = home.Value;
            }
            if (hot != null)
            {
                Hot = hot.Value;
            }
            if (hot1 != null)
            {
                Hot1 = hot1.Value;
            }
            if (hot2 != null)
            {
                Hot2 = hot2.Value;
            }
            if (hot3 != null)
            {
                Hot3 = hot3.Value;
            }
            if (active != null)
            {
                Active = active.Value;
            }
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }
            if (views != null)
            {
                Views = views.Value;
            }
            if (diem != null)
            {
                Diem = diem.Value;
            }

        }
        #endregion
        #region Customs properties
        public docbao.entitites.DanhMuc _DanhMuc { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return VideoDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class VideoCollection : BaseEntityCollection<Video>
    { }
    #endregion
    #region Dal
    public class VideoDal
    {
        #region Methods

        public static void DeleteById(Int32 V_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("V_ID", V_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Delete_DeleteById_linhnx", obj);
        }
        public static Video Insert(Video Inserted)
        {
            Video Item = new Video();
            SqlParameter[] obj = new SqlParameter[15];
            obj[0] = new SqlParameter("V_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("V_Url", Inserted.Url);
            obj[2] = new SqlParameter("V_YID", Inserted.YID);
            obj[3] = new SqlParameter("V_Ten", Inserted.Ten);
            obj[4] = new SqlParameter("V_Anh", Inserted.Anh);
            obj[5] = new SqlParameter("V_MoTa", Inserted.MoTa);
            obj[6] = new SqlParameter("V_Home", Inserted.Home);
            obj[7] = new SqlParameter("V_Hot", Inserted.Hot);
            obj[8] = new SqlParameter("V_Hot1", Inserted.Hot1);
            obj[9] = new SqlParameter("V_Hot2", Inserted.Hot2);
            obj[10] = new SqlParameter("V_Hot3", Inserted.Hot3);
            obj[11] = new SqlParameter("V_Active", Inserted.Active);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("V_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("V_NgayTao", DBNull.Value);
            }
            obj[13] = new SqlParameter("V_Views", Inserted.Views);
            obj[14] = new SqlParameter("V_Diem", Inserted.Diem);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Video Insert(Int32? id, Int32? dm_id, String url, String yid, String ten, String anh, String mota, Boolean? home, Boolean? hot, Boolean? hot1, Boolean? hot2, Boolean? hot3, Boolean? active, DateTime? ngaytao, Int32? views, Int32? diem)
        {
            Video Item = new Video();
            SqlParameter[] obj = new SqlParameter[15];
            if (dm_id != null)
            {
                obj[0] = new SqlParameter("V_DM_ID", dm_id);
            }
            else
            {
                obj[0] = new SqlParameter("V_DM_ID", DBNull.Value);
            }
            if (url != null)
            {
                obj[1] = new SqlParameter("V_Url", url);
            }
            else
            {
                obj[1] = new SqlParameter("V_Url", DBNull.Value);
            }
            if (yid != null)
            {
                obj[2] = new SqlParameter("V_YID", yid);
            }
            else
            {
                obj[2] = new SqlParameter("V_YID", DBNull.Value);
            }
            if (ten != null)
            {
                obj[3] = new SqlParameter("V_Ten", ten);
            }
            else
            {
                obj[3] = new SqlParameter("V_Ten", DBNull.Value);
            }
            if (anh != null)
            {
                obj[4] = new SqlParameter("V_Anh", anh);
            }
            else
            {
                obj[4] = new SqlParameter("V_Anh", DBNull.Value);
            }
            if (mota != null)
            {
                obj[5] = new SqlParameter("V_MoTa", mota);
            }
            else
            {
                obj[5] = new SqlParameter("V_MoTa", DBNull.Value);
            }
            if (home != null)
            {
                obj[6] = new SqlParameter("V_Home", home);
            }
            else
            {
                obj[6] = new SqlParameter("V_Home", DBNull.Value);
            }
            if (hot != null)
            {
                obj[7] = new SqlParameter("V_Hot", hot);
            }
            else
            {
                obj[7] = new SqlParameter("V_Hot", DBNull.Value);
            }
            if (hot1 != null)
            {
                obj[8] = new SqlParameter("V_Hot1", hot1);
            }
            else
            {
                obj[8] = new SqlParameter("V_Hot1", DBNull.Value);
            }
            if (hot2 != null)
            {
                obj[9] = new SqlParameter("V_Hot2", hot2);
            }
            else
            {
                obj[9] = new SqlParameter("V_Hot2", DBNull.Value);
            }
            if (hot3 != null)
            {
                obj[10] = new SqlParameter("V_Hot3", hot3);
            }
            else
            {
                obj[10] = new SqlParameter("V_Hot3", DBNull.Value);
            }
            if (active != null)
            {
                obj[11] = new SqlParameter("V_Active", active);
            }
            else
            {
                obj[11] = new SqlParameter("V_Active", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[12] = new SqlParameter("V_NgayTao", ngaytao);
            }
            else
            {
                obj[12] = new SqlParameter("V_NgayTao", DBNull.Value);
            }
            if (views != null)
            {
                obj[13] = new SqlParameter("V_Views", views);
            }
            else
            {
                obj[13] = new SqlParameter("V_Views", DBNull.Value);
            }
            if (diem != null)
            {
                obj[14] = new SqlParameter("V_Diem", diem);
            }
            else
            {
                obj[14] = new SqlParameter("V_Diem", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Video Update(Video Updated)
        {
            Video Item = new Video();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("V_ID", Updated.ID);
            obj[1] = new SqlParameter("V_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("V_Url", Updated.Url);
            obj[3] = new SqlParameter("V_YID", Updated.YID);
            obj[4] = new SqlParameter("V_Ten", Updated.Ten);
            obj[5] = new SqlParameter("V_Anh", Updated.Anh);
            obj[6] = new SqlParameter("V_MoTa", Updated.MoTa);
            obj[7] = new SqlParameter("V_Home", Updated.Home);
            obj[8] = new SqlParameter("V_Hot", Updated.Hot);
            obj[9] = new SqlParameter("V_Hot1", Updated.Hot1);
            obj[10] = new SqlParameter("V_Hot2", Updated.Hot2);
            obj[11] = new SqlParameter("V_Hot3", Updated.Hot3);
            obj[12] = new SqlParameter("V_Active", Updated.Active);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("V_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[13] = new SqlParameter("V_NgayTao", DBNull.Value);
            }
            obj[14] = new SqlParameter("V_Views", Updated.Views);
            obj[15] = new SqlParameter("V_Diem", Updated.Diem);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Video Update(Int32? id, Int32? dm_id, String url, String yid, String ten, String anh, String mota, Boolean? home, Boolean? hot, Boolean? hot1, Boolean? hot2, Boolean? hot3, Boolean? active, DateTime? ngaytao, Int32? views, Int32? diem)
        {
            Video Item = new Video();
            SqlParameter[] obj = new SqlParameter[16];
            if (id != null)
            {
                obj[0] = new SqlParameter("V_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("V_ID", DBNull.Value);
            }
            if (dm_id != null)
            {
                obj[1] = new SqlParameter("V_DM_ID", dm_id);
            }
            else
            {
                obj[1] = new SqlParameter("V_DM_ID", DBNull.Value);
            }
            if (url != null)
            {
                obj[2] = new SqlParameter("V_Url", url);
            }
            else
            {
                obj[2] = new SqlParameter("V_Url", DBNull.Value);
            }
            if (yid != null)
            {
                obj[3] = new SqlParameter("V_YID", yid);
            }
            else
            {
                obj[3] = new SqlParameter("V_YID", DBNull.Value);
            }
            if (ten != null)
            {
                obj[4] = new SqlParameter("V_Ten", ten);
            }
            else
            {
                obj[4] = new SqlParameter("V_Ten", DBNull.Value);
            }
            if (anh != null)
            {
                obj[5] = new SqlParameter("V_Anh", anh);
            }
            else
            {
                obj[5] = new SqlParameter("V_Anh", DBNull.Value);
            }
            if (mota != null)
            {
                obj[6] = new SqlParameter("V_MoTa", mota);
            }
            else
            {
                obj[6] = new SqlParameter("V_MoTa", DBNull.Value);
            }
            if (home != null)
            {
                obj[7] = new SqlParameter("V_Home", home);
            }
            else
            {
                obj[7] = new SqlParameter("V_Home", DBNull.Value);
            }
            if (hot != null)
            {
                obj[8] = new SqlParameter("V_Hot", hot);
            }
            else
            {
                obj[8] = new SqlParameter("V_Hot", DBNull.Value);
            }
            if (hot1 != null)
            {
                obj[9] = new SqlParameter("V_Hot1", hot1);
            }
            else
            {
                obj[9] = new SqlParameter("V_Hot1", DBNull.Value);
            }
            if (hot2 != null)
            {
                obj[10] = new SqlParameter("V_Hot2", hot2);
            }
            else
            {
                obj[10] = new SqlParameter("V_Hot2", DBNull.Value);
            }
            if (hot3 != null)
            {
                obj[11] = new SqlParameter("V_Hot3", hot3);
            }
            else
            {
                obj[11] = new SqlParameter("V_Hot3", DBNull.Value);
            }
            if (active != null)
            {
                obj[12] = new SqlParameter("V_Active", active);
            }
            else
            {
                obj[12] = new SqlParameter("V_Active", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[13] = new SqlParameter("V_NgayTao", ngaytao);
            }
            else
            {
                obj[13] = new SqlParameter("V_NgayTao", DBNull.Value);
            }
            if (views != null)
            {
                obj[14] = new SqlParameter("V_Views", views);
            }
            else
            {
                obj[14] = new SqlParameter("V_Views", DBNull.Value);
            }
            if (diem != null)
            {
                obj[15] = new SqlParameter("V_Diem", diem);
            }
            else
            {
                obj[15] = new SqlParameter("V_Diem", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Video SelectById(Int32 V_ID)
        {
            Video Item = new Video();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("V_ID", V_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static VideoCollection SelectByIdList(string V_ID, int Top)
        {
            VideoCollection List = new VideoCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("V_ID", V_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Select_SelectByIdList_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static VideoCollection SelectAll()
        {
            VideoCollection List = new VideoCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Video> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Video> pg = new Pager<Video>("tblRss_sp_tblRssVideo_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Video getFromReader(IDataReader rd)
        {
            Video Item = new Video();
            docbao.entitites.DanhMuc _Item = docbao.entitites.DanhMucDal.getFromReader(rd);
            Item._DanhMuc = _Item;
            if (rd.FieldExists("V_ID"))
            {
                Item.ID = (Int32)(rd["V_ID"]);
            }
            if (rd.FieldExists("V_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["V_DM_ID"]);
            }
            if (rd.FieldExists("V_Url"))
            {
                Item.Url = (String)(rd["V_Url"]);
            }
            if (rd.FieldExists("V_YID"))
            {
                Item.YID = (String)(rd["V_YID"]);
            }
            if (rd.FieldExists("V_Ten"))
            {
                Item.Ten = (String)(rd["V_Ten"]);
            }
            if (rd.FieldExists("V_Anh"))
            {
                Item.Anh = (String)(rd["V_Anh"]);
            }
            if (rd.FieldExists("V_MoTa"))
            {
                Item.MoTa = (String)(rd["V_MoTa"]);
            }
            if (rd.FieldExists("V_Home"))
            {
                Item.Home = (Boolean)(rd["V_Home"]);
            }
            if (rd.FieldExists("V_Hot"))
            {
                Item.Hot = (Boolean)(rd["V_Hot"]);
            }
            if (rd.FieldExists("V_Hot1"))
            {
                Item.Hot1 = (Boolean)(rd["V_Hot1"]);
            }
            if (rd.FieldExists("V_Hot2"))
            {
                Item.Hot2 = (Boolean)(rd["V_Hot2"]);
            }
            if (rd.FieldExists("V_Hot3"))
            {
                Item.Hot3 = (Boolean)(rd["V_Hot3"]);
            }
            if (rd.FieldExists("V_Active"))
            {
                Item.Active = (Boolean)(rd["V_Active"]);
            }
            if (rd.FieldExists("V_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["V_NgayTao"]);
            }
            if (rd.FieldExists("V_Views"))
            {
                Item.Views = (Int32)(rd["V_Views"]);
            }
            if (rd.FieldExists("V_Diem"))
            {
                Item.Diem = (Int32)(rd["V_Diem"]);
            }
            return Item;
        }
        public static VideoCollection SelectHot(int Top)
        {
            VideoCollection List = new VideoCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Select_SelectHot_linhnx",obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static VideoCollection SelectHome(int Top)
        {
            VideoCollection List = new VideoCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Select_SelectHome_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static VideoCollection SelectHome(SqlConnection con, int Top)
        {
            VideoCollection List = new VideoCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Select_SelectHome_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static string formatHome(Video item, string _domain)
        {
            HttpContext c = HttpContext.Current;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{4}"" class=""video-home-itemTiny"">
<img class=""tin-item-img"" src=""{5}/lib/up/{1}"">
<a class=""tin-item-ten"" href=""{0}/clip/{2}/{4}.clip"">{3}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , item.Anh
                , Lib.Bodau(item.Ten)
                , item.Ten
                , item.ID
                , _domain
                , item.MoTa);
            return sb.ToString();
        }
        public static string formatHomeBig(Video item)
        {

            return string.Format(@"<div class=""video-home-itemBig""><object width=""285"" height=""233""><param name=""movie"" value=""http://www.youtube.com/v/{0}?fs=1&amp;hl=vi_VN""></param><param name=""allowFullScreen"" value=""true""></param><param name=""allowscriptaccess"" value=""always""></param><embed src=""http://www.youtube.com/v/{0}?fs=1&amp;hl=vi_VN"" type=""application/x-shockwave-flash"" width=""285"" height=""233"" allowscriptaccess=""always"" allowfullscreen=""true""></embed></object></div>"
                , item.YID);
        }
        #endregion
        #region Extend
        public static VideoCollection SelectAll(SqlConnection con)
        {
            VideoCollection List = new VideoCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssVideo_Select_SelectAll_linhnx"))
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
