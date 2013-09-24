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
    #region Topic
    #region BO
    public class Topic : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Anh { get; set; }
        public String MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Active { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean TrangChu { get; set; }
        public Boolean Home { get; set; }
        public Int32 Views { get; set; }
        public String Keywords { get; set; }
        public Int32 Total { get; set; }
        public Boolean Hot { get; set; }
        public Boolean Hot1 { get; set; }
        public Boolean Hot2 { get; set; }
        public Int32 DM_ID { get; set; }
        #endregion
        #region Contructor
        public Topic()
        { }
        public Topic(Int32? id, String ten, String anh, String mota, DateTime? ngaytao, Boolean? active, Int32? thutu, Boolean? trangchu, Boolean? home, Int32? views, String keywords, Int32? total, Boolean? hot, Boolean? hot1, Boolean? hot2, Int32? dm_id)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            Ten = ten;
            Anh = anh;
            MoTa = mota;
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }
            if (active != null)
            {
                Active = active.Value;
            }
            if (thutu != null)
            {
                ThuTu = thutu.Value;
            }
            if (trangchu != null)
            {
                TrangChu = trangchu.Value;
            }
            if (home != null)
            {
                Home = home.Value;
            }
            if (views != null)
            {
                Views = views.Value;
            }
            Keywords = keywords;
            if (total != null)
            {
                Total = total.Value;
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
            if (dm_id != null)
            {
                DM_ID = dm_id.Value;
            }

        }
        #endregion
        #region Customs properties
        public docbao.entitites.DanhMuc _DanhMuc { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TopicDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TopicCollection : BaseEntityCollection<Topic>
    { }
    #endregion
    #region Dal
    public class TopicDal
    {
        #region Methods

        public static void DeleteById(Int32 TP_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TP_ID", TP_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Delete_DeleteById_linhnx", obj);
        }
        public static Topic Insert(Topic Inserted)
        {
            Topic Item = new Topic();
            SqlParameter[] obj = new SqlParameter[15];
            obj[0] = new SqlParameter("TP_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("TP_Anh", Inserted.Anh);
            obj[2] = new SqlParameter("TP_MoTa", Inserted.MoTa);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("TP_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("TP_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("TP_Active", Inserted.Active);
            obj[5] = new SqlParameter("TP_ThuTu", Inserted.ThuTu);
            obj[6] = new SqlParameter("TP_TrangChu", Inserted.TrangChu);
            obj[7] = new SqlParameter("TP_Home", Inserted.Home);
            obj[8] = new SqlParameter("TP_Views", Inserted.Views);
            obj[9] = new SqlParameter("TP_Keywords", Inserted.Keywords);
            obj[10] = new SqlParameter("TP_Total", Inserted.Total);
            obj[11] = new SqlParameter("TP_Hot", Inserted.Hot);
            obj[12] = new SqlParameter("TP_Hot1", Inserted.Hot1);
            obj[13] = new SqlParameter("TP_Hot2", Inserted.Hot2);
            obj[14] = new SqlParameter("TP_DM_ID", Inserted.DM_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Topic Insert(Int32? id, String ten, String anh, String mota, DateTime? ngaytao, Boolean? active, Int32? thutu, Boolean? trangchu, Boolean? home, Int32? views, String keywords, Int32? total, Boolean? hot, Boolean? hot1, Boolean? hot2, Int32? dm_id)
        {
            Topic Item = new Topic();
            SqlParameter[] obj = new SqlParameter[15];
            if (ten != null)
            {
                obj[0] = new SqlParameter("TP_Ten", ten);
            }
            else
            {
                obj[0] = new SqlParameter("TP_Ten", DBNull.Value);
            }
            if (anh != null)
            {
                obj[1] = new SqlParameter("TP_Anh", anh);
            }
            else
            {
                obj[1] = new SqlParameter("TP_Anh", DBNull.Value);
            }
            if (mota != null)
            {
                obj[2] = new SqlParameter("TP_MoTa", mota);
            }
            else
            {
                obj[2] = new SqlParameter("TP_MoTa", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[3] = new SqlParameter("TP_NgayTao", ngaytao);
            }
            else
            {
                obj[3] = new SqlParameter("TP_NgayTao", DBNull.Value);
            }
            if (active != null)
            {
                obj[4] = new SqlParameter("TP_Active", active);
            }
            else
            {
                obj[4] = new SqlParameter("TP_Active", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[5] = new SqlParameter("TP_ThuTu", thutu);
            }
            else
            {
                obj[5] = new SqlParameter("TP_ThuTu", DBNull.Value);
            }
            if (trangchu != null)
            {
                obj[6] = new SqlParameter("TP_TrangChu", trangchu);
            }
            else
            {
                obj[6] = new SqlParameter("TP_TrangChu", DBNull.Value);
            }
            if (home != null)
            {
                obj[7] = new SqlParameter("TP_Home", home);
            }
            else
            {
                obj[7] = new SqlParameter("TP_Home", DBNull.Value);
            }
            if (views != null)
            {
                obj[8] = new SqlParameter("TP_Views", views);
            }
            else
            {
                obj[8] = new SqlParameter("TP_Views", DBNull.Value);
            }
            if (keywords != null)
            {
                obj[9] = new SqlParameter("TP_Keywords", keywords);
            }
            else
            {
                obj[9] = new SqlParameter("TP_Keywords", DBNull.Value);
            }
            if (total != null)
            {
                obj[10] = new SqlParameter("TP_Total", total);
            }
            else
            {
                obj[10] = new SqlParameter("TP_Total", DBNull.Value);
            }
            if (hot != null)
            {
                obj[11] = new SqlParameter("TP_Hot", hot);
            }
            else
            {
                obj[11] = new SqlParameter("TP_Hot", DBNull.Value);
            }
            if (hot1 != null)
            {
                obj[12] = new SqlParameter("TP_Hot1", hot1);
            }
            else
            {
                obj[12] = new SqlParameter("TP_Hot1", DBNull.Value);
            }
            if (hot2 != null)
            {
                obj[13] = new SqlParameter("TP_Hot2", hot2);
            }
            else
            {
                obj[13] = new SqlParameter("TP_Hot2", DBNull.Value);
            }
            if (dm_id != null)
            {
                obj[14] = new SqlParameter("TP_DM_ID", dm_id);
            }
            else
            {
                obj[14] = new SqlParameter("TP_DM_ID", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Topic Update(Topic Updated)
        {
            Topic Item = new Topic();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("TP_ID", Updated.ID);
            obj[1] = new SqlParameter("TP_Ten", Updated.Ten);
            obj[2] = new SqlParameter("TP_Anh", Updated.Anh);
            obj[3] = new SqlParameter("TP_MoTa", Updated.MoTa);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("TP_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("TP_NgayTao", DBNull.Value);
            }
            obj[5] = new SqlParameter("TP_Active", Updated.Active);
            obj[6] = new SqlParameter("TP_ThuTu", Updated.ThuTu);
            obj[7] = new SqlParameter("TP_TrangChu", Updated.TrangChu);
            obj[8] = new SqlParameter("TP_Home", Updated.Home);
            obj[9] = new SqlParameter("TP_Views", Updated.Views);
            obj[10] = new SqlParameter("TP_Keywords", Updated.Keywords);
            obj[11] = new SqlParameter("TP_Total", Updated.Total);
            obj[12] = new SqlParameter("TP_Hot", Updated.Hot);
            obj[13] = new SqlParameter("TP_Hot1", Updated.Hot1);
            obj[14] = new SqlParameter("TP_Hot2", Updated.Hot2);
            obj[15] = new SqlParameter("TP_DM_ID", Updated.DM_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Topic Update(Int32? id, String ten, String anh, String mota, DateTime? ngaytao, Boolean? active, Int32? thutu, Boolean? trangchu, Boolean? home, Int32? views, String keywords, Int32? total, Boolean? hot, Boolean? hot1, Boolean? hot2, Int32? dm_id)
        {
            Topic Item = new Topic();
            SqlParameter[] obj = new SqlParameter[16];
            if (id != null)
            {
                obj[0] = new SqlParameter("TP_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("TP_ID", DBNull.Value);
            }
            if (ten != null)
            {
                obj[1] = new SqlParameter("TP_Ten", ten);
            }
            else
            {
                obj[1] = new SqlParameter("TP_Ten", DBNull.Value);
            }
            if (anh != null)
            {
                obj[2] = new SqlParameter("TP_Anh", anh);
            }
            else
            {
                obj[2] = new SqlParameter("TP_Anh", DBNull.Value);
            }
            if (mota != null)
            {
                obj[3] = new SqlParameter("TP_MoTa", mota);
            }
            else
            {
                obj[3] = new SqlParameter("TP_MoTa", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[4] = new SqlParameter("TP_NgayTao", ngaytao);
            }
            else
            {
                obj[4] = new SqlParameter("TP_NgayTao", DBNull.Value);
            }
            if (active != null)
            {
                obj[5] = new SqlParameter("TP_Active", active);
            }
            else
            {
                obj[5] = new SqlParameter("TP_Active", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[6] = new SqlParameter("TP_ThuTu", thutu);
            }
            else
            {
                obj[6] = new SqlParameter("TP_ThuTu", DBNull.Value);
            }
            if (trangchu != null)
            {
                obj[7] = new SqlParameter("TP_TrangChu", trangchu);
            }
            else
            {
                obj[7] = new SqlParameter("TP_TrangChu", DBNull.Value);
            }
            if (home != null)
            {
                obj[8] = new SqlParameter("TP_Home", home);
            }
            else
            {
                obj[8] = new SqlParameter("TP_Home", DBNull.Value);
            }
            if (views != null)
            {
                obj[9] = new SqlParameter("TP_Views", views);
            }
            else
            {
                obj[9] = new SqlParameter("TP_Views", DBNull.Value);
            }
            if (keywords != null)
            {
                obj[10] = new SqlParameter("TP_Keywords", keywords);
            }
            else
            {
                obj[10] = new SqlParameter("TP_Keywords", DBNull.Value);
            }
            if (total != null)
            {
                obj[11] = new SqlParameter("TP_Total", total);
            }
            else
            {
                obj[11] = new SqlParameter("TP_Total", DBNull.Value);
            }
            if (hot != null)
            {
                obj[12] = new SqlParameter("TP_Hot", hot);
            }
            else
            {
                obj[12] = new SqlParameter("TP_Hot", DBNull.Value);
            }
            if (hot1 != null)
            {
                obj[13] = new SqlParameter("TP_Hot1", hot1);
            }
            else
            {
                obj[13] = new SqlParameter("TP_Hot1", DBNull.Value);
            }
            if (hot2 != null)
            {
                obj[14] = new SqlParameter("TP_Hot2", hot2);
            }
            else
            {
                obj[14] = new SqlParameter("TP_Hot2", DBNull.Value);
            }
            if (dm_id != null)
            {
                obj[15] = new SqlParameter("TP_DM_ID", dm_id);
            }
            else
            {
                obj[15] = new SqlParameter("TP_DM_ID", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Topic SelectById(Int32 TP_ID)
        {
            Topic Item = new Topic();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TP_ID", TP_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TopicCollection SelectAll()
        {
            TopicCollection List = new TopicCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Topic> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Topic> pg = new Pager<Topic>("tblRss_sp_tblTopic_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Topic getFromReader(IDataReader rd)
        {
            Topic Item = new Topic();
            docbao.entitites.DanhMuc _Item = docbao.entitites.DanhMucDal.getFromReader(rd);
            Item._DanhMuc = _Item;
            if (rd.FieldExists("TP_ID"))
            {
                Item.ID = (Int32)(rd["TP_ID"]);
            }
            if (rd.FieldExists("TP_Ten"))
            {
                Item.Ten = (String)(rd["TP_Ten"]);
            }
            if (rd.FieldExists("TP_Anh"))
            {
                Item.Anh = (String)(rd["TP_Anh"]);
            }
            if (rd.FieldExists("TP_MoTa"))
            {
                Item.MoTa = (String)(rd["TP_MoTa"]);
            }
            if (rd.FieldExists("TP_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TP_NgayTao"]);
            }
            if (rd.FieldExists("TP_Active"))
            {
                Item.Active = (Boolean)(rd["TP_Active"]);
            }
            if (rd.FieldExists("TP_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TP_ThuTu"]);
            }
            if (rd.FieldExists("TP_TrangChu"))
            {
                Item.TrangChu = (Boolean)(rd["TP_TrangChu"]);
            }
            if (rd.FieldExists("TP_Home"))
            {
                Item.Home = (Boolean)(rd["TP_Home"]);
            }
            if (rd.FieldExists("TP_Views"))
            {
                Item.Views = (Int32)(rd["TP_Views"]);
            }
            if (rd.FieldExists("TP_Keywords"))
            {
                Item.Keywords = (String)(rd["TP_Keywords"]);
            }
            if (rd.FieldExists("TP_Total"))
            {
                Item.Total = (Int32)(rd["TP_Total"]);
            }
            if (rd.FieldExists("TP_Hot"))
            {
                Item.Hot = (Boolean)(rd["TP_Hot"]);
            }
            if (rd.FieldExists("TP_Hot1"))
            {
                Item.Hot1 = (Boolean)(rd["TP_Hot1"]);
            }
            if (rd.FieldExists("TP_Hot2"))
            {
                Item.Hot2 = (Boolean)(rd["TP_Hot2"]);
            }
            if (rd.FieldExists("TP_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["TP_DM_ID"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static TopicCollection SelectByTin(string T_ID)
        {
            TopicCollection List = new TopicCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Select_SelectByTin_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static TopicCollection SelectTopByDay(int Top)
        {
            TopicCollection List = new TopicCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Select_SelectTopByDay_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TopicCollection SelectTopByHot(int Top)
        {
            TopicCollection List = new TopicCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTopic_Select_SelectTopByHot_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static string formatHome(Topic item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{4}"" class=""tin-item-mostView"">
<img class=""tin-item-img"" src=""{5}/lib/up/{1}"">
<a class=""tin-item-ten"" href=""{0}/topic/{2}/{4}.topic"">{3}</a></div>"
                , domain
                , Lib.imgSize(item.Anh, "50x50")
                , Lib.Bodau(item.Ten)
                , item.Ten
                , item.ID
                ,_domain);
            return sb.ToString();
        }
        #endregion
    }
    #endregion
    #endregion
}
