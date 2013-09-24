using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using linh.common;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace docsoft.entities
{
    #region Tin
    #region BO
    public class Tin : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid GH_ID { get; set; }
        public Guid DM_ID { get; set; }
        public String Lang { get; set; }
        public Boolean LangBased { get; set; }
        public Guid LangBased_ID { get; set; }
        public String Alias { get; set; }
        public String KeyWords { get; set; }
        public String Description { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public String TacGia { get; set; }
        public String Anh { get; set; }
        public Int32 ThuTu { get; set; }
        public String Nguon { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayDang { get; set; }
        public DateTime NgayHetHan { get; set; }
        public Int32 Views { get; set; }
        public Int32 BinhLuan { get; set; }
        public Boolean Hot { get; set; }
        public Boolean Active { get; set; }
        public Boolean Publish { get; set; }
        public Boolean HetHan { get; set; }
        public Boolean Moi { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public Tin()
        { }
        #endregion
        #region Customs properties
        public String multiID { get; set; }
        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }
        public string DM_Ten { get; set; }
        public string GH_Ten { get; set; }
        public string DM_Ma { get; set; }
        public Guid _ID { get; set; }
        public Boolean HG_Active { get; set; }
        public DateTime HG_GioDang { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinCollection : BaseEntityCollection<Tin>
    { }
    #endregion
    #region Dal
    public class TinDal
    {
        #region Methods

        public static void DeleteById(string TIN_ID, string DM_Ma)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Delete_DeleteById_linhnx", obj);
        }

        public static Tin Insert(Tin inserted)
        {
            var item = new Tin();
            var obj = new SqlParameter[29];
            obj[0] = new SqlParameter("TIN_ID", inserted.ID);
            obj[1] = new SqlParameter("TIN_GH_ID", inserted.GH_ID);
            obj[2] = new SqlParameter("TIN_DM_ID", inserted.DM_ID);
            obj[3] = new SqlParameter("TIN_Lang", inserted.Lang);
            obj[4] = new SqlParameter("TIN_LangBased", inserted.LangBased);
            obj[5] = new SqlParameter("TIN_LangBased_ID", inserted.LangBased_ID);
            obj[6] = new SqlParameter("TIN_Alias", inserted.Alias);
            obj[7] = new SqlParameter("TIN_Ten", inserted.Ten);
            obj[8] = new SqlParameter("TIN_MoTa", inserted.MoTa);
            obj[9] = new SqlParameter("TIN_NoiDung", inserted.NoiDung);
            obj[10] = new SqlParameter("TIN_TacGia", inserted.TacGia);
            obj[11] = new SqlParameter("TIN_Anh", inserted.Anh);
            obj[12] = new SqlParameter("TIN_ThuTu", inserted.ThuTu);
            obj[13] = new SqlParameter("TIN_Nguon", inserted.Nguon);
            obj[14] = new SqlParameter("TIN_NgayTao", inserted.NgayTao);
            obj[15] = new SqlParameter("TIN_NguoiTao", inserted.NguoiTao);
            // obj[16] = new SqlParameter("TIN_NgayCapNhat", Updated.NgayCapNhat);
            string capnhat = string.Format("{0:dd/MM/yy}", inserted.NgayCapNhat);
            if (capnhat != "01/01/01")
            {
                obj[16] = new SqlParameter("TIN_NgayCapNhat", inserted.NgayCapNhat);
            }
            else
            {
                obj[16] = new SqlParameter("TIN_NgayCapNhat", DBNull.Value);
            }
            obj[17] = new SqlParameter("TIN_NguoiCapNhat", inserted.NguoiCapNhat);


            string htl = string.Format("{0:dd/MM/yy}", inserted.NgayDang);
            if (htl != "01/01/01")
            {
                obj[18] = new SqlParameter("TIN_NgayDang", inserted.NgayDang);
            }
            else
            {
                obj[18] = new SqlParameter("TIN_NgayDang", DBNull.Value);
            }
            // obj[16] = new SqlParameter("TIN_NgayHetHan", Updated.NgayHetHan);
            string htl1 = string.Format("{0:dd/MM/yy}", inserted.NgayHetHan);
            if (htl1 != "01/01/01")
            {
                obj[19] = new SqlParameter("TIN_NgayHetHan", inserted.NgayHetHan);
            }
            else
            {
                obj[19] = new SqlParameter("TIN_NgayHetHan", DBNull.Value);
            }

            //obj[18] = new SqlParameter("TIN_NgayDang", Updated.NgayDang);
            //obj[19] = new SqlParameter("TIN_NgayHetHan", Updated.NgayHetHan);
            obj[20] = new SqlParameter("TIN_Views", inserted.Views);
            obj[21] = new SqlParameter("TIN_Hot", inserted.Hot);
            obj[22] = new SqlParameter("TIN_Active", inserted.Active);
            obj[23] = new SqlParameter("TIN_Publish", inserted.Publish);
            obj[24] = new SqlParameter("TIN_HetHan", inserted.HetHan);
            obj[25] = new SqlParameter("TIN_Moi", inserted.Moi);
            obj[26] = new SqlParameter("TIN_RowId", inserted.RowId);
            obj[27] = new SqlParameter("TIN_KeyWords", inserted.KeyWords);
            obj[28] = new SqlParameter("TIN_Description", inserted.Description);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    item = getFromReader(rd);
                }
            }
            return item;
        }

        public static Tin Update(Tin item)
        {
            var Item = new Tin();
            var obj = new SqlParameter[29];
            obj[0] = new SqlParameter("TIN_ID", item.ID);
            obj[1] = new SqlParameter("TIN_GH_ID", item.GH_ID);
            obj[2] = new SqlParameter("TIN_DM_ID", item.DM_ID);
            obj[3] = new SqlParameter("TIN_Lang", item.Lang);
            obj[4] = new SqlParameter("TIN_LangBased", item.LangBased);
            obj[5] = new SqlParameter("TIN_LangBased_ID", item.LangBased_ID);
            obj[6] = new SqlParameter("TIN_Alias", item.Alias);
            obj[7] = new SqlParameter("TIN_Ten", item.Ten);
            obj[8] = new SqlParameter("TIN_Keywords", item.KeyWords);
            obj[9] = new SqlParameter("TIN_Description", item.Description);
            obj[10] = new SqlParameter("TIN_MoTa", item.MoTa);
            obj[11] = new SqlParameter("TIN_NoiDung", item.NoiDung);
            obj[12] = new SqlParameter("TIN_TacGia", item.TacGia);
            obj[13] = new SqlParameter("TIN_Anh", item.Anh);
            obj[14] = new SqlParameter("TIN_ThuTu", item.ThuTu);
            obj[15] = new SqlParameter("TIN_Nguon", item.Nguon);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("TIN_NgayTao", item.NgayTao);
            }
            else
            {
                obj[16] = new SqlParameter("TIN_NgayTao", DBNull.Value);
            }
            obj[17] = new SqlParameter("TIN_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("TIN_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[18] = new SqlParameter("TIN_NgayCapNhat", DBNull.Value);
            }
            obj[19] = new SqlParameter("TIN_NguoiCapNhat", item.NguoiCapNhat);
            if (item.NgayDang > DateTime.MinValue)
            {
                obj[20] = new SqlParameter("TIN_NgayDang", item.NgayDang);
            }
            else
            {
                obj[20] = new SqlParameter("TIN_NgayDang", DBNull.Value);
            }
            if (item.NgayHetHan > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("TIN_NgayHetHan", item.NgayHetHan);
            }
            else
            {
                obj[21] = new SqlParameter("TIN_NgayHetHan", DBNull.Value);
            }
            obj[22] = new SqlParameter("TIN_Views", item.Views);
            obj[23] = new SqlParameter("TIN_Hot", item.Hot);
            obj[24] = new SqlParameter("TIN_Active", item.Active);
            obj[25] = new SqlParameter("TIN_Publish", item.Publish);
            obj[26] = new SqlParameter("TIN_HetHan", item.HetHan);
            obj[27] = new SqlParameter("TIN_Moi", item.Moi);
            obj[28] = new SqlParameter("TIN_RowId", item.RowId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }


        public static Tin SelectById(String TIN_ID)
        {
            return SelectById(DAL.con(), TIN_ID);
        }
        public static Tin SelectById(SqlConnection con, String TIN_ID)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tin SelectById(SqlTransaction con, String TIN_ID)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tin SelectById(Int32 TIN_ID)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tin SelectByLangBaseID(String TIN_LangBase_ID, string Lang)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_LangBase_ID", TIN_LangBase_ID);
            obj[1] = new SqlParameter("TIN_Lang", Lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByLangBaseId_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinCollection SelectAll()
        {
            TinCollection List = new TinCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tin> PagerNormal(string url, bool rewrite, string sort, string q, string DM_ID, string active)
        {
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            obj[3] = new SqlParameter("active", active);

            var pg = new Pager<Tin>("sp_tblTin_Pager_Normal_linhnx", "page", 10, 10, rewrite, url, obj);
            return pg;
        }
        /// <summary>
        /// hampv
        /// </summary>
        /// <param name="url"></param>
        /// <param name="rewrite"></param>
        /// <param name="sort"></param>
        /// <param name="q"></param>
        /// <param name="dm"></param>
        /// <param name="nguoitao"></param>
        /// <param name="acp"></param>
        /// <param name="_Code"></param>
        /// <param name="Lang"></param>
        /// <returns></returns>
        public static Pager<Tin> pagerNormalView(SqlConnection cnn, string url, bool rewrite, string sort, string dm, string _Code, string Lang, int size)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);

            if (!string.IsNullOrEmpty(dm))
            {
                obj[1] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[1] = new SqlParameter("dm_id", DBNull.Value);
            }

            obj[2] = new SqlParameter("DM_Ma", _Code);
            obj[3] = new SqlParameter("Lang", Lang);

            Pager<Tin> pg = new Pager<Tin>(cnn, "sp_tblTin_Pager_Normal_linhnx_AllView", "Pages", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerNormalTin(string url, bool rewrite, string sort, string q, string dm, string nguoitao, int acp, string _Code, string Lang)
        {
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            obj[3] = new SqlParameter("acp", acp);
            obj[4] = new SqlParameter("NguoiTao", nguoitao);
            obj[5] = new SqlParameter("DM_Ma", _Code);
            obj[6] = new SqlParameter("Lang", Lang);
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_Normal_linhnx_test", "page", 10, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerDuyet(string url, bool rewrite, string sort, string q, string dm, string nguoitao, int acp, string _Code, string Lang)
        {
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            obj[3] = new SqlParameter("acp", acp);
            obj[4] = new SqlParameter("NguoiTao", nguoitao);
            obj[5] = new SqlParameter("DM_Ma", _Code);
            obj[6] = new SqlParameter("Lang", Lang);
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_Normal_linhnx_duyet", "page", 10, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<Tin> pagerNormalThongke(string url, bool rewrite, string sort, string q, string dm, string nguoitao, string _tungay, string _denngay, int acp, string _Code, int size)
        {
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            obj[3] = new SqlParameter("acp", acp);
            obj[4] = new SqlParameter("NguoiTao", nguoitao);
            obj[5] = new SqlParameter("DM_Ma", _Code);
            if (!string.IsNullOrEmpty(_tungay))
            {
                obj[6] = new SqlParameter("TuNgay", _tungay);
            }
            else
            {
                obj[6] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_denngay))
            {
                obj[7] = new SqlParameter("DenNgay", _denngay);
            }
            else
            {
                obj[7] = new SqlParameter("DenNgay", DBNull.Value);
            }
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_Normal_linhnx_KT", "page", size, 10, rewrite, url, obj);
            return pg;
        }



        #endregion

        #region Utilities
        public static Tin getFromReader(IDataReader rd)
        {
            Tin Item = new Tin();
            if (rd.FieldExists("TIN_ID"))
            {
                Item.ID = (Guid)(rd["TIN_ID"]);
            }
            if (rd.FieldExists("TIN_ID"))
            {
                Item._ID = (Guid)(rd["TIN_ID"]);
            }
            if (rd.FieldExists("_TIN_ID"))
            {
                Item._ID = (Guid)(rd["_TIN_ID"]);
            }
            if (rd.FieldExists("TIN_GH_ID"))
            {
                Item.GH_ID = (Guid)(rd["TIN_GH_ID"]);
            }
            if (rd.FieldExists("TIN_DM_ID"))
            {
                Item.DM_ID = (Guid)(rd["TIN_DM_ID"]);
            }
            if (rd.FieldExists("TIN_Lang"))
            {
                Item.Lang = (String)(rd["TIN_Lang"]);
            }
            if (rd.FieldExists("TIN_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["TIN_LangBased"]);
            }
            if (rd.FieldExists("TIN_LangBased_ID"))
            {
                Item.LangBased_ID = (Guid)(rd["TIN_LangBased_ID"]);
            }
            if (rd.FieldExists("TIN_Alias"))
            {
                Item.Alias = (String)(rd["TIN_Alias"]);
            }
            if (rd.FieldExists("TIN_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["TIN_DM_Ten"]);
            }
            if (rd.FieldExists("TIN_Ten"))
            {
                Item.Ten = (String)(rd["TIN_Ten"]);
            }
            if (rd.FieldExists("TIN_MoTa"))
            {
                Item.MoTa = (String)(rd["TIN_MoTa"]);
            }
            if (rd.FieldExists("TIN_NoiDung"))
            {
                Item.NoiDung = (String)(rd["TIN_NoiDung"]);
            }
            if (rd.FieldExists("TIN_KeyWords"))
            {
                Item.KeyWords = (String)(rd["TIN_KeyWords"]);
            }
            if (rd.FieldExists("TIN_Description"))
            {
                Item.Description = (String)(rd["TIN_Description"]);
            }
            if (rd.FieldExists("TIN_TacGia"))
            {
                Item.TacGia = (String)(rd["TIN_TacGia"]);
            }
            if (rd.FieldExists("TIN_Anh"))
            {
                Item.Anh = (String)(rd["TIN_Anh"]);
            }
            if (rd.FieldExists("TIN_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TIN_ThuTu"]);
            }
            if (rd.FieldExists("TIN_Nguon"))
            {
                Item.Nguon = (String)(rd["TIN_Nguon"]);
            }
            if (rd.FieldExists("TIN_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TIN_NgayTao"]);
            }
            if (rd.FieldExists("TIN_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TIN_NguoiTao"]);
            }
            if (rd.FieldExists("TIN_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TIN_NgayCapNhat"]);
            }
            if (rd.FieldExists("TIN_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TIN_NguoiCapNhat"]);
            }
            if (rd.FieldExists("TIN_NgayDang"))
            {
                Item.NgayDang = (DateTime)(rd["TIN_NgayDang"]);
            }
            if (rd.FieldExists("TIN_NgayHetHan"))
            {
                Item.NgayHetHan = (DateTime)(rd["TIN_NgayHetHan"]);
            }
            if (rd.FieldExists("TIN_Views"))
            {
                Item.Views = (Int32)(rd["TIN_Views"]);
            }
            if (rd.FieldExists("TIN_BinhLuan"))
            {
                Item.BinhLuan = (Int32)(rd["TIN_BinhLuan"]);
            }
            if (rd.FieldExists("TIN_Hot"))
            {
                Item.Hot = (Boolean)(rd["TIN_Hot"]);
            }
            if (rd.FieldExists("TIN_Active"))
            {
                Item.Active = (Boolean)(rd["TIN_Active"]);
            }
            if (rd.FieldExists("TIN_Publish"))
            {
                Item.Publish = (Boolean)(rd["TIN_Publish"]);
            }
            if (rd.FieldExists("TIN_HetHan"))
            {
                Item.HetHan = (Boolean)(rd["TIN_HetHan"]);
            }
            if (rd.FieldExists("TIN_Moi"))
            {
                Item.Moi = (Boolean)(rd["TIN_Moi"]);
            }
            if (rd.FieldExists("TIN_RowId"))
            {
                Item.RowId = (Guid)(rd["TIN_RowId"]);
            }
            if (rd.FieldExists("TIN_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["TIN_DM_Ten"]);
            }
            if (rd.FieldExists("DM_Ma"))
            {
                Item.DM_Ma = (String)(rd["DM_Ma"]);
            }
            if (rd.FieldExists("GH_Ten"))
            {
                Item.GH_Ten = (String)(rd["GH_Ten"]);
            }
            if (rd.FieldExists("HG_GioDang"))
            {
                Item.HG_GioDang = (DateTime)(rd["HG_GioDang"]);
            }
            if (rd.FieldExists("HG_Active"))
            {
                Item.HG_Active = (Boolean)(rd["HG_Active"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static string formatSlides(Tin item, string domain)
        {
            var c = HttpContext.Current;
            var sb = new StringBuilder();
            sb.AppendFormat(@"
<div class=""slide"">
    <a href=""{4}"" target=""_blank"">
    <img class=""tin-item-img"" width=""990"" height=""340"" src=""{0}/lib/up/tintuc/{1}""></a>
    <div class=""caption"">
    <p><b>{3}</b><br/>{4}</p>
    </div>
</div>", domain
                , Lib.imgSize(item.Anh, "full")
                , item.Alias
                , item.Ten
                , item.MoTa
                , item.ID
                , item.Nguon);
            return sb.ToString();
        }
        public static string FormatTinMoi(Tin item, string domain)
        {
            var c = HttpContext.Current;
            var sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{4}"" class=""tin-item-DanhMucStyle1Tiny""><a class=""tin-item-ten"" href=""{0}/Tin-tuc/{2}/{3}/{4}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", domain, Lib.imgSize(item.Anh, "105x70"))
                , item.DM_Ma
                , Lib.Bodau(item.Ten)
                , item.ID
                , item.Ten
                , item.MoTa
                , item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"));
            return sb.ToString();
        }

        public static string FormatDanhMucItemBig(Tin item, string domain, string css)
        {
            return
                string.Format(
                    @"
<div class=""{8}"">
<a href=""{0}/Tin-tuc/{6}/{5}/{2}.html"" class=""tin-item-imgBox"">
    <img src=""{0}/lib/up/tintuc/{1}"" class=""tin-item-anh"" />
</a>
<a href=""{0}/Tin-tuc/{6}/{5}/{2}.html"" class=""tin-item-ten"">{3}</a>
<span class=""tin-item-moTa"">{4}</span>
</div>"
                    , domain
                    , Lib.imgSize(item.Anh, "full")
                    , item.ID
                    , item.Ten
                    , item.MoTa
                    , Lib.Bodau(item.Ten)
                    , item.DM_Ma
                    , item.DM_ID
                    , css);
        }
        public static string FormatDanhMucItemSmall(Tin item, string domain, string css)
        {
            return string.Format(@"
<div class=""{8}"">
<a href=""{0}/Tin-tuc/{6}/{5}/{2}.html"" class=""tin-item-imgBox"">
    <img src=""{0}/lib/up/tintuc/{1}"" class=""tin-item-img"" />
</a>
<a href=""{0}/Tin-tuc/{6}/{5}/{2}.html"" class=""tin-item-ten"">{3}</a>
<span class=""tin-item-moTa"">{4}</span>
</div>
"
                    , domain
                    , Lib.imgSize(item.Anh, "full")
                    , item.ID
                    , HttpContext.Current.Server.HtmlEncode(item.Ten)
                    , HttpContext.Current.Server.HtmlEncode(item.MoTa)
                    , Lib.Bodau(item.Ten)
                    , item.DM_Ma
                    , item.DM_ID
                    , css);
        }

        public static void DeleteMultiById(String TIN_ID, string DM_Ma)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Delete_DeleteMultiById_hungpm", obj);
        }
        public static void UpdateHotMulti(Tin TIN_Hot)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_Hot.multiID);
            obj[1] = new SqlParameter("TIN_Hot", TIN_Hot.Hot);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateHotMultiById_hungpm", obj);
        }
        // Xoa
        public static void UpdateHot1Multi(Tin TIN_Hot)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_Hot.multiID);
            obj[1] = new SqlParameter("TIN_Hot", TIN_Hot.Hot);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateHotMultiById_hungpm", obj);
        }
        public static void UpdateMulti(Tin TIN_Active)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_Active.multiID);
            obj[1] = new SqlParameter("TIN_Active", TIN_Active.Active);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateMultiById_hungpm", obj);
        }
        public static void UpdateMulti(Tin TIN_Active, SqlTransaction tran)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_Active.multiID);
            obj[1] = new SqlParameter("TIN_Active", TIN_Active.Active);
            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "sp_tblTin_Update_UpdateMultiById_hungpm", obj);
        }
        public static void UpdateGhId(Tin TIN_Active, string GH_ID, SqlTransaction tran)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_Active.multiID);
            obj[1] = new SqlParameter("GH_ID", GH_ID);
            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "sp_tblTin_Update_UpdateGhId_hungpm", obj);
        }
        public static void UpdateMultiYeuCauDuyet(Tin TIN_Active)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_Active.multiID);
            obj[1] = new SqlParameter("TIN_Publish", TIN_Active.Publish);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateMultiYeuCauDuyet_hungpm", obj);
        }
        public static void UpdateHetHanMulti(Tin TinHetHan)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TIN_ID", TinHetHan.multiID);
            obj[1] = new SqlParameter("TIN_HetHan", TinHetHan.HetHan);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateHetHanMultiById_hungpm", obj);
        }
        public static void UpdateView(string ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ID", ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateView_hungpm", obj);
        }
        public static void UpdateView(SqlConnection con, string ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ID", ID);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_tblTin_Update_UpdateView_hungpm", obj);
        }
        public static TinCollection SelectTopTen()
        {
            TinCollection List = new TinCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectTopTen_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTop(int Top, string _lang)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Lang", _lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectTop_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectDanhSachHome(int top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectDanhSachHome_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTopThongBao(int top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectTopThongBao_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection byDanhMuc(int top, string dm_id)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_id", dm_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssTin_Select_byDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection byLoaiDanhMuc(int top, string dm_id)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_id", dm_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssTin_Select_byLoaiDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static TinCollection GetTinbyMaDanhMuc(int top, string DM_Ma, string Lang, string listing, SqlConnection cnn)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            obj[2] = new SqlParameter("Lang", Lang);
            obj[3] = new SqlParameter("LIST_TIN_ID", listing);
            using (IDataReader rd = SqlHelper.ExecuteReader(cnn, CommandType.StoredProcedure, "sp_tblRssTin_Select_byDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection GetTinbyMaDanhMucHome(int top, string DM_Ma, string Lang, SqlConnection cnn)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            obj[2] = new SqlParameter("Lang", Lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(cnn, CommandType.StoredProcedure, "sp_tblRssTin_Select_byDanhMucHome_hampv", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection GetTinbyMaDanhMucHomeKhac(int top, string DM_Ma, string Lang, SqlConnection cnn)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            obj[2] = new SqlParameter("Lang", Lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(cnn, CommandType.StoredProcedure, "sp_tblRssTin_Select_byDanhMucHomeKhac_hampv", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectByDanhMuc(string DM_Ma, int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectByDanhMuc(string DM_Ma, int Top, SqlConnection con)
        {
            var list = new TinCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static TinCollection SelectByDanhMuc(string DM_ID, int Top, DateTime NgayCapNhat)
        {
            var list = new TinCollection();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            obj[2] = new SqlParameter("NgayCapNhat", NgayCapNhat);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDanhMucID_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static TinCollection SelectByDanhMucNew(string DM_ID, int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDanhMucNewID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectByDiemBaoNew(int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];

            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDiemBaoNewID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTopHot(int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectTopHot_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tin> pagerByDanhMuc(string url, bool rewrite, string sort, string dm)
        {
            SqlParameter[] obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(dm))
            {
                obj[1] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[1] = new SqlParameter("dm_id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_pagerByDanhMuc_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }


        public static Pager<Tin> pagerByDmIdPhanLoaiId(SqlConnection con, string url, bool rewrite, string sort, string dm, string gh_id)
        {
            SqlParameter[] obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(dm))
            {
                obj[1] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[1] = new SqlParameter("dm_id", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(gh_id))
            {
                obj[2] = new SqlParameter("gh_id", gh_id);
            }
            else
            {
                obj[2] = new SqlParameter("gh_id", DBNull.Value);
            }
            Pager<Tin> pg = new Pager<Tin>(con, "sp_tblTin_Pager_pagerByDmPhanLoai_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }

        public static TinCollection lienQuan(int Top, string Id, int dmId, string Lang)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Id", Id);
            obj[2] = new SqlParameter("DM_ID", dmId);
            obj[3] = new SqlParameter("TIN_Lang", Lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_lienQuan_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Tin SelectByIdView(string VBD_ID)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TIN_ID", VBD_ID);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByIdView_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    Files item = new Files();
                    if (rd.FieldExists("F_Ten"))
                    {
                        item.Ten = (String)(rd["F_Ten"]);
                    }

                    if (rd.FieldExists("F_ID"))
                    {
                        item.ID = (Int32)(rd["F_ID"]);
                    }
                    if (rd.FieldExists("F_NguoiTao"))
                    {
                        item.NguoiTao = (String)(rd["F_NguoiTao"]);
                    }
                    if (rd.FieldExists("F_Size"))
                    {
                        item.Size = (Int32)(rd["F_Size"]);
                    }
                    if (rd.FieldExists("F_MimeType"))
                    {
                        item.MimeType = (String)(rd["F_MimeType"]);
                    }
                    if (rd.FieldExists("F_Download"))
                    {
                        item.Download = (Int32)(rd["F_Download"]);
                    }
                    filelist.Add(item);
                }
            }
            Item.Filelist = filelist;
            return Item;
        }
        public static Pager<Tin> pagerBySearch(string url, bool rewrite, string sort, string q)
        {
            SqlParameter[] obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_pagerBySearch_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<Tin> PagerByMa(SqlConnection con, string url, bool rewrite, string sort, string q, string DM_Ma, int Top)
        {
            var obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_Ma))
            {
                obj[2] = new SqlParameter("DM_Ma", DM_Ma);
            }
            else
            {
                obj[2] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            var pg = new Pager<Tin>(con, "sp_tblTin_Pager_pagerByMa_linhnx", "page", Top, 10, rewrite, url, obj);
            return pg;
        }
        public static TinCollection SelectLienQuan(string ID, int Top, SqlConnection con)
        {
            var list = new TinCollection();
            var obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            else
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_SelectLienQuan_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static TinCollection lienQuanCuHon(SqlConnection con, int Top, string Id)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Id", Id);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_lienQuanCuHon_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection lienQuanMoiHon(SqlConnection con, int Top, string Id)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Id", Id);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_lienQuanMoiHon_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection tinLienQuanByRelationPid(int Top, string Id)
        {
            return tinLienQuanByRelationPid(DAL.con(), Top, Id);
        }
        public static TinCollection tinLienQuanByRelationPid(SqlConnection con, int Top, string Id)
        {
            var List = new TinCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            if (string.IsNullOrEmpty(Id))
            {

                obj[1] = new SqlParameter("Id", DBNull.Value);
            }
            else
            {

                obj[1] = new SqlParameter("Id", Id);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_tinLienQuanByRelationPid_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tin> PagerQuanTri(string url, bool rewrite, int Top, string Sort
            , string DM_ID, string q, bool? active, string Username, bool? Publish, bool? Admin)
        {
            return PagerQuanTri(DAL.con(), url, rewrite, Top, Sort, DM_ID, q, active, Username, Publish, Admin, false);
        }
        public static Pager<Tin> PagerQuanTri(string url, bool rewrite, int Top, string Sort
            , string DM_ID, string q, bool? active, string Username, bool? Publish, bool? Admin, bool? HetHan)
        {
            return PagerQuanTri(DAL.con(), url, rewrite, Top, Sort, DM_ID, q, active, Username, Publish, Admin, HetHan);
        }
        public static Pager<Tin> PagerQuanTri(SqlConnection con, string url, bool rewrite, int Top, string Sort
            , string DM_ID, string q, bool? active, string Username, bool? Publish, bool? Admin, bool? HetHan)
        {
            var obj = new SqlParameter[8];
            if (!string.IsNullOrEmpty(Sort))
            {
                obj[0] = new SqlParameter("Sort", Sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Username))
            {
                obj[3] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[3] = new SqlParameter("Username", DBNull.Value);
            }

            if (active != null)
            {
                obj[4] = new SqlParameter("active", active);
            }
            else
            {
                obj[4] = new SqlParameter("active", DBNull.Value);
            }

            if (Publish != null)
            {
                obj[5] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[5] = new SqlParameter("Publish", DBNull.Value);
            }

            if (Admin != null)
            {
                obj[6] = new SqlParameter("Admin", Admin);
            }
            else
            {
                obj[6] = new SqlParameter("Admin", DBNull.Value);
            }

            if (HetHan != null)
            {
                obj[7] = new SqlParameter("HetHan", HetHan);
            }
            else
            {
                obj[7] = new SqlParameter("HetHan", DBNull.Value);
            }

            var pg = new Pager<Tin>(con, "sp_tblTin_Pager_QuanTri_linhnx", "page", Top, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<Tin> PagerPhuTrach(string url, bool rewrite, int Top, string Sort
            , string DM_ID, string q, bool? active, string Username)
        {
            return PagerPhuTrach(DAL.con(), url, rewrite, Top, Sort, DM_ID, q, active, Username, null, null);
        }
        public static Pager<Tin> PagerPhuTrach(string url, bool rewrite, int Top, string Sort
            , string DM_ID, string q, bool? active, string Username, bool? Publish, bool? HetHan)
        {
            return PagerPhuTrach(DAL.con(), url, rewrite, Top, Sort, DM_ID, q, active, Username, Publish, HetHan);
        }
        public static Pager<Tin> PagerPhuTrach(SqlConnection con, string url, bool rewrite, int Top, string Sort
            , string DM_ID, string q, bool? active, string Username, bool? Publish, bool? HetHan)
        {
            var obj = new SqlParameter[7];
            if (!string.IsNullOrEmpty(Sort))
            {
                obj[0] = new SqlParameter("Sort", Sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Username))
            {
                obj[3] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[3] = new SqlParameter("Username", DBNull.Value);
            }

            if (active != null)
            {
                obj[4] = new SqlParameter("active", active);
            }
            else
            {
                obj[4] = new SqlParameter("active", DBNull.Value);
            }
            if (Publish != null)
            {
                obj[5] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[5] = new SqlParameter("Publish", DBNull.Value);
            }
            if (HetHan != null)
            {
                obj[6] = new SqlParameter("HetHan", HetHan);
            }
            else
            {
                obj[6] = new SqlParameter("HetHan", DBNull.Value);
            }

            var pg = new Pager<Tin>(con, "sp_tblTin_Pager_PagerPhuTrach_linhnx", "page", Top, 10, rewrite, url, obj);
            return pg;
        }

        public static TinCollection SelectByPhanLoai(string DM_Ma, int Top, SqlConnection con)
        {
            var list = new TinCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_SelectByPhanLoai_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static TinCollection SelectByPhanLoai(Guid DM_ID, int Top, SqlConnection con)
        {
            var list = new TinCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_SelectByPhanLoaiById_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        #endregion
    }
    #endregion
    #endregion
}
