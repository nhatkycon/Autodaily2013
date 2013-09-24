using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using linh.controls;

namespace docsoft.entities
{
    #region Thuvien
    #region BO
    public class Thuvien : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }
        public String Ten { get; set; }
        public String Mota { get; set; }
        public String Keyword { get; set; }
        public String UrlImage { get; set; }
        public String Url { get; set; }
        public Int16 Thutu { get; set; }
        public Int16 Loai { get; set; }
        public DateTime Ngaytao { get; set; }
        public Boolean Active { get; set; }
        public Guid RowId { get; set; }
        public Int16 CateID { get; set; }
        public String NguoiTao { get; set; }
        #endregion
        #region Contructor
        public Thuvien()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuvienDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuvienCollection : BaseEntityCollection<Thuvien>
    { }
    #endregion
    #region Dal
    public class ThuvienDal
    {
        #region Methods

        public static void DeleteById(Int32 TV_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Delete_DeleteById_dtm", obj);
        }

        public static Thuvien Insert(Thuvien Inserted)
        {
            Thuvien Item = new Thuvien();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("TV_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("TV_Mota", Inserted.Mota);
            obj[2] = new SqlParameter("TV_Keyword", Inserted.Keyword);
            obj[3] = new SqlParameter("TV_UrlImage", Inserted.UrlImage);
            obj[4] = new SqlParameter("TV_Url", Inserted.Url);
            obj[5] = new SqlParameter("TV_Thutu", Inserted.Thutu);
            obj[6] = new SqlParameter("TV_Loai", Inserted.Loai);
            obj[7] = new SqlParameter("TV_Ngaytao", Inserted.Ngaytao);
            obj[8] = new SqlParameter("TV_Active", Inserted.Active);
            obj[9] = new SqlParameter("TV_RowId", Inserted.RowId);
            obj[10] = new SqlParameter("TV_CateID", Inserted.CateID);
            obj[11] = new SqlParameter("TV_NguoiTao", Inserted.NguoiTao);
            obj[12] = new SqlParameter("TV_GH_ID", Inserted.GH_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Insert_InsertNormal_dtm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Thuvien InsertVideo(Thuvien Inserted)
        {
            Thuvien Item = new Thuvien();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("TV_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("TV_Mota", Inserted.Mota);
            obj[2] = new SqlParameter("TV_Keyword", Inserted.Keyword);
            obj[3] = new SqlParameter("TV_UrlImage", Inserted.UrlImage);
            obj[4] = new SqlParameter("TV_Url", Inserted.Url);
            obj[5] = new SqlParameter("TV_Thutu", Inserted.Thutu);
            obj[6] = new SqlParameter("TV_Loai", Inserted.Loai);
            obj[7] = new SqlParameter("TV_Ngaytao", Inserted.Ngaytao);
            obj[8] = new SqlParameter("TV_Active", Inserted.Active);
            obj[9] = new SqlParameter("TV_RowId", Inserted.RowId);
            obj[10] = new SqlParameter("TV_CateID", Inserted.CateID);
            obj[11] = new SqlParameter("TV_NguoiTao", Inserted.NguoiTao);
            obj[12] = new SqlParameter("TV_GH_ID", Inserted.GH_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVien_Insert_InsertNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Thuvien Update(Thuvien Updated)
        {
            Thuvien Item = new Thuvien();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("TV_ID", Updated.ID);
            obj[1] = new SqlParameter("TV_Ten", Updated.Ten);
            obj[2] = new SqlParameter("TV_Mota", Updated.Mota);
            obj[3] = new SqlParameter("TV_Keyword", Updated.Keyword);
            obj[4] = new SqlParameter("TV_UrlImage", Updated.UrlImage);
            obj[5] = new SqlParameter("TV_Url", Updated.Url);
            obj[6] = new SqlParameter("TV_Thutu", Updated.Thutu);
            obj[7] = new SqlParameter("TV_Loai", Updated.Loai);
            obj[8] = new SqlParameter("TV_Ngaytao", Updated.Ngaytao);
            obj[9] = new SqlParameter("TV_Active", Updated.Active);
            obj[10] = new SqlParameter("TV_RowId", Updated.RowId);
            obj[11] = new SqlParameter("TV_CateID", Updated.CateID);
            obj[12] = new SqlParameter("TV_NguoiTao", Updated.NguoiTao);
            obj[13] = new SqlParameter("TV_GH_ID", Updated.GH_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Update_UpdateNormal_dtm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Thuvien SelectById(Int32 TV_ID)
        {
            Thuvien Item = new Thuvien();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Select_SelectById_dtm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        

        public static ThuvienCollection SelectAll()
        {
            ThuvienCollection List = new ThuvienCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Select_SelectAll_dtm"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Thuvien> pagerNormal(string url, bool rewrite, string sort, int pagesize, string q, string _DonViID, int acp, string _Nguoitao, string gianhang_id)
        {
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
           if (!string.IsNullOrEmpty(_DonViID))
            {
                obj[2] = new SqlParameter("MEM_CQ_ID", _DonViID);
            }
            else
            {
                obj[2] = new SqlParameter("MEM_CQ_ID", DBNull.Value);
            }
            obj[3] = new SqlParameter("acp", acp);
            obj[4] = new SqlParameter("NguoiTao", _Nguoitao);
            obj[5] = new SqlParameter("gh_id", gianhang_id);
            Pager<Thuvien> pg = new Pager<Thuvien>("sp_tblThuvien_Pager_Normal_dtm", "page", pagesize, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Thuvien> pagerNormalMember(string url, bool rewrite, string sort, int pagesize, string q, int acp, string gh_id, string username)
        {
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
 
            obj[2] = new SqlParameter("acp", acp);
        
            obj[3] = new SqlParameter("gh_id", gh_id);
            obj[4] = new SqlParameter("username",username);
            Pager<Thuvien> pg = new Pager<Thuvien>("sp_tblThuVien_Pager_NormalMember_hiennb", "page", pagesize, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<Thuvien> pagerNormalDuyet(string url, bool rewrite, string sort, int pagesize, string q, string _DonViID, int acp, string _Nguoitao)
        {
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("Sort", sort);
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            if (!string.IsNullOrEmpty(_DonViID))
            {
                obj[2] = new SqlParameter("MEM_CQ_ID", _DonViID);
            }
            else
            {
                obj[2] = new SqlParameter("MEM_CQ_ID", DBNull.Value);
            }
            obj[3] = new SqlParameter("acp", acp);
            obj[4] = new SqlParameter("NguoiTao", _Nguoitao);
            Pager<Thuvien> pg = new Pager<Thuvien>("sp_tblThuvien_Pager_Normal_dtm_Duyet", "page", pagesize, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Thuvien getFromReader(IDataReader rd)
        {
            Thuvien Item = new Thuvien();
            if (rd.FieldExists("TV_ID"))
            {
                Item.ID = (Int32)(rd["TV_ID"]);
            }
            if (rd.FieldExists("TV_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["TV_GH_ID"]);
            }
            if (rd.FieldExists("TV_Ten"))
            {
                Item.Ten = (String)(rd["TV_Ten"]);
            }
            if (rd.FieldExists("TV_Mota"))
            {
                Item.Mota = (String)(rd["TV_Mota"]);
            }
            if (rd.FieldExists("TV_Keyword"))
            {
                Item.Keyword = (String)(rd["TV_Keyword"]);
            }
            if (rd.FieldExists("TV_UrlImage"))
            {
                Item.UrlImage = (String)(rd["TV_UrlImage"]);
            }
            if (rd.FieldExists("TV_Url"))
            {
                Item.Url = (String)(rd["TV_Url"]);
            }
            if (rd.FieldExists("TV_Thutu"))
            {
                Item.Thutu = (Int16)(rd["TV_Thutu"]);
            }
            if (rd.FieldExists("TV_Loai"))
            {
                Item.Loai = (Int16)(rd["TV_Loai"]);
            }
            if (rd.FieldExists("TV_Ngaytao"))
            {
                Item.Ngaytao = (DateTime)(rd["TV_Ngaytao"]);
            }
            if (rd.FieldExists("TV_Active"))
            {
                Item.Active = (Boolean)(rd["TV_Active"]);
            }
            if (rd.FieldExists("TV_RowId"))
            {
                Item.RowId = (Guid)(rd["TV_RowId"]);
            }
            if (rd.FieldExists("TV_CateID"))
            {
                Item.CateID = (Int16)(rd["TV_CateID"]);
            }
            if (rd.FieldExists("TV_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TV_NguoiTao"]);
            }
            return Item;                    
        }
        #endregion

        #region extend
        public static ThuvienCollection SelectTop(int Top)
        {
            ThuvienCollection List = new ThuvienCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Select_SelectTop_dtm", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static ThuvienCollection SelectTopById(int Top, int Id)
        {
            ThuvienCollection List = new ThuvienCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Id", Id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Select_SelectTopById_dtm", obj))
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
