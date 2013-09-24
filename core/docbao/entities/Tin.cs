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
    #region Tin
    #region BO
    public class Tin : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public String DM_Ten { get; set; }
        public String DM_Alias { get; set; }
        public Int32 CM_ID { get; set; }
        public Int32 C_ID { get; set; }
        public Int32 B_ID { get; set; }
        public String CM_Ten { get; set; }
        public String CM_Alias { get; set; }
        public String Alias { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public String Anh { get; set; }
        public String Url { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 Views { get; set; }
        public Int32 BinhChon { get; set; }
        public Int32 Diem { get; set; }
        public String Tags { get; set; }
        public Boolean NoiBatHome { get; set; }
        public Boolean NoiBatDm { get; set; }
        public Boolean DocNhieu { get; set; }
        public Boolean Hot { get; set; }
        public Boolean Hot1 { get; set; }
        public Boolean Hot2 { get; set; }
        public Boolean Hot3 { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public Tin()
        { }
        public Tin(Int32? id, Int32? dm_id, String dm_ten, String dm_alias, Int32? cm_id, String cm_ten, String cm_alias, String alias, String ten, String mota, String noidung, String anh, String url, DateTime? ngaytao, Int32? views, Int32? binhchon, Int32? diem, String tags, Boolean? noibathome, Boolean? noibatdm, Boolean? docnhieu, Boolean? hot, Boolean? hot1, Boolean? hot2, Boolean? hot3, Guid? rowid)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (dm_id != null)
            {
                DM_ID = dm_id.Value;
            }
            DM_Ten = dm_ten;
            DM_Alias = dm_alias;
            if (cm_id != null)
            {
                CM_ID = cm_id.Value;
            }
            CM_Ten = cm_ten;
            CM_Alias = cm_alias;
            Alias = alias;
            Ten = ten;
            MoTa = mota;
            NoiDung = noidung;
            Anh = anh;
            Url = url;
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }
            if (views != null)
            {
                Views = views.Value;
            }
            if (binhchon != null)
            {
                BinhChon = binhchon.Value;
            }
            if (diem != null)
            {
                Diem = diem.Value;
            }
            Tags = tags;
            if (noibathome != null)
            {
                NoiBatHome = noibathome.Value;
            }
            if (noibatdm != null)
            {
                NoiBatDm = noibatdm.Value;
            }
            if (docnhieu != null)
            {
                DocNhieu = docnhieu.Value;
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
            if (rowid != null)
            {
                RowId = rowid.Value;
            }

        }
        #endregion
        #region Customs properties
        public Channel _Channel { get; set; }
        public Bao _Bao { get; set; }
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

        public static void DeleteById(Int32 T_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Delete_DeleteById_linhnx", obj);
        }
        public static Tin Insert(Tin Inserted)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[27];
            obj[0] = new SqlParameter("T_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("T_DM_Ten", Inserted.DM_Ten);
            obj[2] = new SqlParameter("T_DM_Alias", Inserted.DM_Alias);
            obj[3] = new SqlParameter("T_CM_ID", Inserted.CM_ID);
            obj[4] = new SqlParameter("T_CM_Ten", Inserted.CM_Ten);
            obj[5] = new SqlParameter("T_CM_Alias", Inserted.CM_Alias);
            obj[6] = new SqlParameter("T_B_ID", Inserted.B_ID);
            obj[7] = new SqlParameter("T_C_ID", Inserted.C_ID);
            obj[8] = new SqlParameter("T_Alias", Inserted.Alias);
            obj[9] = new SqlParameter("T_Ten", Inserted.Ten);
            obj[10] = new SqlParameter("T_MoTa", Inserted.MoTa);
            obj[11] = new SqlParameter("T_NoiDung", Inserted.NoiDung);
            obj[12] = new SqlParameter("T_Anh", Inserted.Anh);
            obj[13] = new SqlParameter("T_Url", Inserted.Url);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("T_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[14] = new SqlParameter("T_NgayTao", DBNull.Value);
            }
            obj[15] = new SqlParameter("T_Views", Inserted.Views);
            obj[16] = new SqlParameter("T_BinhChon", Inserted.BinhChon);
            obj[17] = new SqlParameter("T_Diem", Inserted.Diem);
            obj[18] = new SqlParameter("T_Tags", Inserted.Tags);
            obj[19] = new SqlParameter("T_NoiBatHome", Inserted.NoiBatHome);
            obj[20] = new SqlParameter("T_NoiBatDm", Inserted.NoiBatDm);
            obj[21] = new SqlParameter("T_DocNhieu", Inserted.DocNhieu);
            obj[22] = new SqlParameter("T_Hot", Inserted.Hot);
            obj[23] = new SqlParameter("T_Hot1", Inserted.Hot1);
            obj[24] = new SqlParameter("T_Hot2", Inserted.Hot2);
            obj[25] = new SqlParameter("T_Hot3", Inserted.Hot3);
            obj[26] = new SqlParameter("T_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinCollection InsertLaytinId(Int32 T_ID, string user)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", T_ID);
            obj[1] = new SqlParameter("UserID", user);
           // SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinlaytin_Insert_InsertNormal_linhnx", obj);
            TinCollection List = new TinCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinlaytin_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection InsertLaytinKTNNId(string T_ID,string _DM, string user)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("KTNN_ID", T_ID);
            obj[1] = new SqlParameter("KTNN_DM_ID", _DM);
            obj[2] = new SqlParameter("UserID", user);
            // SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinlaytin_Insert_InsertNormal_linhnx", obj);
            TinCollection List = new TinCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinlaytinKTNN_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Tin Update(Tin Updated)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[28];
            obj[0] = new SqlParameter("T_ID", Updated.ID);
            obj[1] = new SqlParameter("T_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("T_DM_Ten", Updated.DM_Ten);
            obj[3] = new SqlParameter("T_DM_Alias", Updated.DM_Alias);
            obj[4] = new SqlParameter("T_CM_ID", Updated.CM_ID);
            obj[5] = new SqlParameter("T_CM_Ten", Updated.CM_Ten);
            obj[6] = new SqlParameter("T_CM_Alias", Updated.CM_Alias);
            obj[7] = new SqlParameter("T_B_ID", Updated.B_ID);
            obj[8] = new SqlParameter("T_C_ID", Updated.C_ID);
            obj[9] = new SqlParameter("T_Alias", Updated.Alias);
            obj[10] = new SqlParameter("T_Ten", Updated.Ten);
            obj[11] = new SqlParameter("T_MoTa", Updated.MoTa);
            obj[12] = new SqlParameter("T_NoiDung", Updated.NoiDung);
            obj[13] = new SqlParameter("T_Anh", Updated.Anh);
            obj[14] = new SqlParameter("T_Url", Updated.Url);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("T_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[15] = new SqlParameter("T_NgayTao", DBNull.Value);
            }
            obj[16] = new SqlParameter("T_Views", Updated.Views);
            obj[17] = new SqlParameter("T_BinhChon", Updated.BinhChon);
            obj[18] = new SqlParameter("T_Diem", Updated.Diem);
            obj[19] = new SqlParameter("T_Tags", Updated.Tags);
            obj[20] = new SqlParameter("T_NoiBatHome", Updated.NoiBatHome);
            obj[21] = new SqlParameter("T_NoiBatDm", Updated.NoiBatDm);
            obj[22] = new SqlParameter("T_DocNhieu", Updated.DocNhieu);
            obj[23] = new SqlParameter("T_Hot", Updated.Hot);
            obj[24] = new SqlParameter("T_Hot1", Updated.Hot1);
            obj[25] = new SqlParameter("T_Hot2", Updated.Hot2);
            obj[26] = new SqlParameter("T_Hot3", Updated.Hot3);
            obj[27] = new SqlParameter("T_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tin SelectById(Int32 T_ID)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
           
           
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectById_linhnx", obj))
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
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tin> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Tin getFromReader(IDataReader rd)
        {
            Tin Item = new Tin();
            Bao bao = BaoDal.getFromReader(rd);
            Channel channel = ChannelDal.getFromReader(rd);
            Item._Bao = bao;
            Item._Channel = channel;
            if (rd.FieldExists("T_ID"))
            {
                Item.ID = (Int32)(rd["T_ID"]);
            }
            if (rd.FieldExists("T_C_ID"))
            {
                Item.C_ID = (Int32)(rd["T_C_ID"]);
            }
            if (rd.FieldExists("T_B_ID"))
            {
                Item.B_ID = (Int32)(rd["T_B_ID"]);
            }
            if (rd.FieldExists("T_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["T_DM_ID"]);
            }
            if (rd.FieldExists("T_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["T_DM_Ten"]);
            }
            if (rd.FieldExists("T_DM_Alias"))
            {
                Item.DM_Alias = (String)(rd["T_DM_Alias"]);
            }
            if (rd.FieldExists("T_CM_ID"))
            {
                Item.CM_ID = (Int32)(rd["T_CM_ID"]);
            }
            if (rd.FieldExists("T_CM_Ten"))
            {
                Item.CM_Ten = (String)(rd["T_CM_Ten"]);
            }
            if (rd.FieldExists("T_CM_Alias"))
            {
                Item.CM_Alias = (String)(rd["T_CM_Alias"]);
            }
            if (rd.FieldExists("T_Alias"))
            {
                Item.Alias = (String)(rd["T_Alias"]);
            }
            if (rd.FieldExists("T_Ten"))
            {
                Item.Ten = (String)(rd["T_Ten"]);
            }
            if (rd.FieldExists("T_MoTa"))
            {
                Item.MoTa = (String)(rd["T_MoTa"]);
                Item.MoTa = Giga.Common.Lib._string.getHTML(Item.MoTa);
            }
            if (rd.FieldExists("T_NoiDung"))
            {
                Item.NoiDung = (String)(rd["T_NoiDung"]);
            }
            if (rd.FieldExists("T_Anh"))
            {
                Item.Anh = (String)(rd["T_Anh"]);
            }
            if (rd.FieldExists("T_Url"))
            {
                Item.Url = (String)(rd["T_Url"]);
            }
            if (rd.FieldExists("T_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["T_NgayTao"]);
            }
            if (rd.FieldExists("T_Views"))
            {
                Item.Views = (Int32)(rd["T_Views"]);
            }
            if (rd.FieldExists("T_BinhChon"))
            {
                Item.BinhChon = (Int32)(rd["T_BinhChon"]);
            }
            if (rd.FieldExists("T_Diem"))
            {
                Item.Diem = (Int32)(rd["T_Diem"]);
            }
            if (rd.FieldExists("T_Tags"))
            {
                Item.Tags = (String)(rd["T_Tags"]);
            }
            if (rd.FieldExists("T_NoiBatHome"))
            {
                Item.NoiBatHome = (Boolean)(rd["T_NoiBatHome"]);
            }
            if (rd.FieldExists("T_NoiBatDm"))
            {
                Item.NoiBatDm = (Boolean)(rd["T_NoiBatDm"]);
            }
            if (rd.FieldExists("T_DocNhieu"))
            {
                Item.DocNhieu = (Boolean)(rd["T_DocNhieu"]);
            }
            if (rd.FieldExists("T_Hot"))
            {
                Item.Hot = (Boolean)(rd["T_Hot"]);
            }
            if (rd.FieldExists("T_Hot1"))
            {
                Item.Hot1 = (Boolean)(rd["T_Hot1"]);
            }
            if (rd.FieldExists("T_Hot2"))
            {
                Item.Hot2 = (Boolean)(rd["T_Hot2"]);
            }
            if (rd.FieldExists("T_Hot3"))
            {
                Item.Hot3 = (Boolean)(rd["T_Hot3"]);
            }
            if (rd.FieldExists("T_RowId"))
            {
                Item.RowId = (Guid)(rd["T_RowId"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static Tin SelectById(SqlConnection con, Int32 T_ID)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tin SelectByUrl(SqlConnection con, string T_Url)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_Url", T_Url);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectByUrl_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinCollection SelectNoiBatHome(int top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectNoiBatHome_linhnx",obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectHotHome(int top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectHotHome_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTrangChu(SqlConnection con, int top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectTrangChu_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }        
        public static TinCollection SelectDocNhieuHome(int top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectDocNhieuHome_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectDocNhieuHome(SqlConnection con, int top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectDocNhieuHome_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }  
        public static TinCollection SelectNoiBatDanhMuc(int top,string dm_ten)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_ten", dm_ten);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectNoiBatDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectNoiBatDanhMuc(SqlConnection con, int top, string dm_ten)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_ten", dm_ten);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectNoiBatDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectMoiDanhMuc(SqlConnection con, int top, string dm_ten)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_ten", dm_ten);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectMoiDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectMoiChuyenMuc(SqlConnection con, int top, string dm_ten)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_ten", dm_ten);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectMoiChuyenMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectNoiBatChuyenMuc(int top, string cm_ten)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("cm_ten", cm_ten);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectNoiBatChuyenMuc_linhnx", obj))
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
        public static TinCollection SelectTinLienQuanDanhMuc(int top,string alias)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("alias", alias);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectTinLienQuanDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTinLienQuanChuyenMuc(int top, string alias)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("alias", alias);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectTinLienQuanChuyenMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        //public static Tin SelectByAlias(string alias)
        //{
        //    Tin Item = new Tin();
        //    SqlParameter[] obj = new SqlParameter[1];
        //    obj[0] = new SqlParameter("alias", alias);
        //    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectByAlias_linhnx", obj))
        //    {
        //        while (rd.Read())
        //        {
        //            Item = getFromReader(rd);
        //        }
        //    }
        //    return Item;
        //}
        public static TinCollection SelectByAlias(int top, string alias, string username)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("alias", alias);
            obj[2] = new SqlParameter("username", username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectByAlias_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectByAlias(SqlConnection con, int top, string alias, string username)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("alias", alias);
            obj[2] = new SqlParameter("username", username);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectByAlias_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tin> pagerDanhMuc(string url, bool rewrite,string dm_ten)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("dm_ten", dm_ten);
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_danhMuc_linhnx", "page", 10, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerDanhMuc(SqlConnection con, string url, bool rewrite, string dm_ten)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("dm_ten", dm_ten);
            Pager<Tin> pg = new Pager<Tin>(con, "tblRss_sp_tblTin_Pager_danhMuc_linhnx", "page", 10, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerChuyenMuc(string url, bool rewrite, string cm_ten)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("cm_ten", cm_ten);
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_chuyenMuc_linhnx", "page", 10, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerChuyenMuc(SqlConnection con, string url, bool rewrite, string cm_ten)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("cm_ten", cm_ten);
            Pager<Tin> pg = new Pager<Tin>(con, "tblRss_sp_tblTin_Pager_chuyenMuc_linhnx", "page", 10, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerDaDoc(string url, bool rewrite, string username)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("username", username);
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_pagerDaDoc_linhnx", "Pages", 10, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerTimKiem(string url, bool rewrite, string q)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("q", q);
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_timKiem_linhnx", "Pages", 10, 10, rewrite, url, obj);
            return pg;
        }
        //public static Pager<Tin> pagerTimKiem(string q,int size,int index)
        //{
        //    SqlParameter[] obj = new SqlParameter[1];
        //    obj[0] = new SqlParameter("q", q);
        //    Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_timKiem_linhnx", index, size, obj);
        //    return pg;
        //}
        public static Pager<Tin> pagerTags(string url, bool rewrite, string tags)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("tags", tags);
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_tags_linhnx", "Pages", 10, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerAll(string url, bool rewrite, int max, string sort, string q,string dm,string cm,string bao,string tpId,string nId,string ngay,string tag)
        {
            SqlParameter[] obj = new SqlParameter[9];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("sort", sort);
            }
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("dm", dm);
            }
            if (string.IsNullOrEmpty(cm))
            {
                obj[3] = new SqlParameter("cm", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("cm", cm);
            }
            if (string.IsNullOrEmpty(bao))
            {
                obj[4] = new SqlParameter("bao", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("bao", bao);
            }
            if (string.IsNullOrEmpty(tpId))
            {
                obj[5] = new SqlParameter("tpId", DBNull.Value);
            }
            else
            {
                obj[5] = new SqlParameter("tpId", tpId);
            }
            if (string.IsNullOrEmpty(nId))
            {
                obj[6] = new SqlParameter("nId", DBNull.Value);
            }
            else
            {
                obj[6] = new SqlParameter("nId", nId);
            }
            if (string.IsNullOrEmpty(ngay))
            {
                obj[7] = new SqlParameter("ngay", DBNull.Value);
            }
            else
            {
                obj[7] = new SqlParameter("ngay", ngay);
            }
            if (string.IsNullOrEmpty(tag))
            {
                obj[8] = new SqlParameter("tag", DBNull.Value);
            }
            else
            {
                obj[8] = new SqlParameter("tag", tag);
            }
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_pagerAll_linhnx", "page", max, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerTinXuLy(string url, bool rewrite, int max, string sort, string q, string dm, string cm, string bao, string tpId, string nId, string ngay, string tag, string Hot3)
        {
            SqlParameter[] obj = new SqlParameter[10];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("sort", sort);
            }
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("dm", dm);
            }
            if (string.IsNullOrEmpty(cm))
            {
                obj[3] = new SqlParameter("cm", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("cm", cm);
            }
            if (string.IsNullOrEmpty(bao))
            {
                obj[4] = new SqlParameter("bao", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("bao", bao);
            }
            if (string.IsNullOrEmpty(tpId))
            {
                obj[5] = new SqlParameter("tpId", DBNull.Value);
            }
            else
            {
                obj[5] = new SqlParameter("tpId", tpId);
            }
            if (string.IsNullOrEmpty(nId))
            {
                obj[6] = new SqlParameter("nId", DBNull.Value);
            }
            else
            {
                obj[6] = new SqlParameter("nId", nId);
            }
            if (string.IsNullOrEmpty(ngay))
            {
                obj[7] = new SqlParameter("ngay", DBNull.Value);
            }
            else
            {
                obj[7] = new SqlParameter("ngay", ngay);
            }
            if (string.IsNullOrEmpty(tag))
            {
                obj[8] = new SqlParameter("tag", DBNull.Value);
            }
            else
            {
                obj[8] = new SqlParameter("tag", tag);
            }
            if (string.IsNullOrEmpty(Hot3))
            {
                obj[9] = new SqlParameter("Hot3", DBNull.Value);
            }
            else
            {
                obj[9] = new SqlParameter("Hot3", Hot3);
            }
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_pagerTinXuLy_linhnx", "page", max, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerKTNNXuLy(string url, bool rewrite, int max, string sort, string q, string dm, string cm, string bao, string tpId, string nId, string ngay, string tag, string Hot2)
        {
            SqlParameter[] obj = new SqlParameter[10];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("sort", sort);
            }
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("dm", dm);
            }
            if (string.IsNullOrEmpty(cm))
            {
                obj[3] = new SqlParameter("cm", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("cm", cm);
            }
            if (string.IsNullOrEmpty(bao))
            {
                obj[4] = new SqlParameter("bao", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("bao", bao);
            }
            if (string.IsNullOrEmpty(tpId))
            {
                obj[5] = new SqlParameter("tpId", DBNull.Value);
            }
            else
            {
                obj[5] = new SqlParameter("tpId", tpId);
            }
            if (string.IsNullOrEmpty(nId))
            {
                obj[6] = new SqlParameter("nId", DBNull.Value);
            }
            else
            {
                obj[6] = new SqlParameter("nId", nId);
            }
            if (string.IsNullOrEmpty(ngay))
            {
                obj[7] = new SqlParameter("ngay", DBNull.Value);
            }
            else
            {
                obj[7] = new SqlParameter("ngay", ngay);
            }
            if (string.IsNullOrEmpty(tag))
            {
                obj[8] = new SqlParameter("tag", DBNull.Value);
            }
            else
            {
                obj[8] = new SqlParameter("tag", tag);
            }
            if (string.IsNullOrEmpty(Hot2))
            {
                obj[9] = new SqlParameter("Hot2", DBNull.Value);
            }
            else
            {
                obj[9] = new SqlParameter("Hot2", Hot2);
            }
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_pagerKTNNXuLy_linhnx", "page", max, 10, rewrite, url, obj);
            return pg;
        }
        public static bool ValidateLink(string Url)
        {
            bool ok = true;
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Url", Url);
            ok = Convert.ToBoolean(SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_ValidateLink_linhnx", obj).ToString());
            return ok;
        }
        public static bool ValidateLink(string Url,string title)
        {
            bool ok = true;
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Url", Url);
            obj[1] = new SqlParameter("Ten", title);
            ok = Convert.ToBoolean(SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_ValidateLink2_linhnx", obj).ToString());
            return ok;
        }
        public static string format(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item""><span class=""tin-item-task""><span class=""tin-item-task-bl"">{8}</span><span _id=""{9}"" class=""tin-item-task-view"">{11}</span></span>
{1}
<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a><br/>
<span class=""tin-item-desc"">{6}</span>
<span class=""tin-item-author"">{7}<!-- - nguồn:{10}</span>--></div>"
                , domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/{1}"">"
                , _domain, Lib.imgSize(item.Anh, "100x100")), string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatSlides(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
<div class=""slide"">
    <a href=""{0}{2}/{3}/{4}/{9}.html"" target=""_blank"">
    <img class=""tin-item-img"" width=""430"" height=""300"" src=""{12}/lib/up/{1}""></a>
    <div class=""caption"">
    <p><b>{5}</b><br/>{6}</p>
    </div>
</div>"         , domain
                , Lib.imgSize(item.Anh, "430x300")
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias
                , string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias
                , item.Alias
                , item.Ten
                , Giga.Common.Lib._string.getHTML(item.MoTa)
                , item.NgayTao.ToString("HH:mm tt dd/MM/yyyy")
                , item.BinhChon
                , item.ID
                , new Uri(item.Url).Host
               , item.Views
               , _domain);
            return sb.ToString();
        }
        public static string formatMostView(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-mostView"">
{1}
<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a></div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/{1}"">", _domain, Lib.imgSize(item.Anh, "50x50"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }

        public static string formatHeadTiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-tinyHead"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" _src=""{0}/lib/up/rss/{2}"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"), Lib.imgSize(item.Anh, "420x290"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }

        public static string formatSubHeadTiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-tinySubHead"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "100x100"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatHeadNewestTiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-tinyNewest""><a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a></div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatHeadNewestBig(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-bigNewest"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatHeadBig(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-bigHead"">{1}
<div class=""tin-item-overlay-box"">
    <div class=""tin-item-overlay"">
        <a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
        <span class=""tin-item-mota"">{6}</span>
    </div>
</div>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "420x290"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle1Big(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle1Big"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "420x290"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle1Medium(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle1Medium"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle1Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle1Tiny""><a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }

        public static string formatDanhMucStyle21Big(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle21Big"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle21Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle21Tiny""><a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }

        public static string formatDanhMucStyle22Big(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle22Big"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "420x290"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle22Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle22Tiny"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }

        #region 3
        public static string formatDanhMucStyle3Big(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle3Big"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "150x160"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle3Medium(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle3Medium"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "150x160"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle3Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle3Tiny""><a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a></div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "150x160"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        #endregion
        public static string formatDanhMucStyle4Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle4Tiny"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a></div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle41Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle41Tiny"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a></div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle5Big(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle5Big"">{1}
<div class=""tin-item-overlay-box"">
    <div class=""tin-item-overlay"">
        <a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
        <span class=""tin-item-mota"">{6}</span>
    </div>
</div>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "420x290"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle5Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle5Tiny"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a></div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }

        public static string formatDanhMucStyle6Big(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle6Big"">{1}
<div class=""tin-item-overlay-box"">
    <div class=""tin-item-overlay"">
        <a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
        <span class=""tin-item-mota"">{6}</span>
    </div>
</div>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "420x290")                )
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle6Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle6Tiny"">{1}
<div class=""tin-item-overlay-box"">
    <div class=""tin-item-overlay"">
        <a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
        <span class=""tin-item-mota"">{6}</span>
    </div>
</div>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "420x290"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle7Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle7Tiny"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a></div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "105x70"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }


        public static string formatDanhMuc1Big(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMuc1Big"">{1}
<div class=""tin-item-overlay-box"">
    <div class=""tin-item-overlay"">
        <a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
        <span class=""tin-item-mota"">{6}</span>
    </div>
</div>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "420x290"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMuc1Tiny(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMuc1Tiny"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a><span class=""tin-item-mota"">{6}</span></div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "100x100"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }

        public static string formatTinLienQuan1(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-TinLienQuan1"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a><span class=""tin-item-mota"">{6}</span></div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "100x100"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }

        #region 8
        public static string formatDanhMucStyle8Big(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle8Big"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
<span class=""tin-item-mota"">{6}</span>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "420x290"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatDanhMucStyle8Medium(Tin item, string _domain)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-DanhMucStyle8Medium"">{1}<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a>
</div>"
                , _domain
                , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/rss/{1}"">", _domain, Lib.imgSize(item.Anh, "420x290"))
                , string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        #endregion

        public static string formatMap(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<a class=""tin-item-map"" class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html""><img class=""tin-item-img"" src=""{12}/lib/up/{1}""></a>", domain, Lib.imgSize(item.Anh, "50x50"), string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatRelated(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item-relate"">
{1}
<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a><br/>
<span class=""tin-item-desc"">{6}</span><br/>
<span class=""tin-item-author"">{7}</span></div>", domain, string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<img class=""tin-item-img"" src=""{0}/lib/up/{1}"">",_domain, Lib.imgSize(item.Anh, "100x100")), string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatTiny(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" class=""tin-item""><span class=""tin-item-task""><span class=""tin-item-task-bl"">{8}</span><span _id=""{9}"" class=""tin-item-task-view"">{11}</span></span>
<img class=""tin-item-img"" src=""{12}/lib/up/{1}"">
<a class=""tin-item-ten"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a><br/>
<span class=""tin-item-author"">{7} - nguồn:{10}</span></div>", domain, Lib.imgSize(item.Anh, "50x50"), item.DM_Alias, item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatTag(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div class=""tin_panel"">
            <span class=""VotePanel""><span class=""VotePanel_Core"">{8}</span><a rev=""0"" _id=""{9}"" class=""VotePanel_vote"" href=""javascript:void(0);""></a></span>
            <img class=""tin_img"" src=""{0}/lib/up/{1}"">            
            <a class=""tin_show_title"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a><br/>
            <span class=""tin_show_author"">
             {7} <a href=""{0}/{2}/"" class=""tin_show_danhMuc"">{10}</a> >
            <a href=""{0}/{2}/{3}/"" class=""tin_show_danhMuc"">{11}</a>
            </span><br/>
            <span class=""tin_show_desc"">{6}</span>            
        </div>", domain, Lib.imgSize(item.Anh, "101x58"), item.DM_Alias, item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID
               , item.DM_Ten, item.CM_Ten);
            return sb.ToString();
        }
        public static string format_head(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div class=""tin_panel_head"">
            <span class=""VotePanel""><span class=""VotePanel_Core"">{8}</span><a rev=""0"" _id=""{9}"" class=""VotePanel_vote"" href=""javascript:void(0);""></a></span>
            <img class=""tin_img"" src=""{0}/lib/up/{1}"">            
            <a class=""tin_show_title"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a><br/>
            <span class=""tin_show_desc"">{6}</span><br/>
            <span class=""tin_show_author"">{7}</span>                     
        </div>", domain, Lib.imgSize(item.Anh, "320x188"), item.DM_Alias, item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID);
            return sb.ToString();
        }
        public static Pager<Tin> pagerAdm(string q, string Sort, string DM_ID, string CM_ID, string Ngay)
        {
            SqlParameter[] obj = new SqlParameter[5];
            if (string.IsNullOrEmpty(q))
            {
                obj[0] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(Sort))
            {
                obj[1] = new SqlParameter("Sort", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("Sort", Sort);
            }
            if (string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            if (string.IsNullOrEmpty(CM_ID))
            {
                obj[3] = new SqlParameter("CM_ID", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("CM_ID", CM_ID);
            }
            if (string.IsNullOrEmpty(Ngay))
            {
                obj[4] = new SqlParameter("Ngay", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("Ngay", Ngay);
            }
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_adm_linhnx", "page", 50, 10, false, "", obj);
            return pg;
        }
        public static Pager<Tin> pagerAdm(string q, int Top, string DM_ID, string CM_ID, string Ngay)
        {
            SqlParameter[] obj = new SqlParameter[5];
            if (string.IsNullOrEmpty(q))
            {
                obj[0] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("q", q);
            }
            obj[1] = new SqlParameter("Sort", DBNull.Value);
            if (string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            if (string.IsNullOrEmpty(CM_ID))
            {
                obj[3] = new SqlParameter("CM_ID", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("CM_ID", CM_ID);
            }
            if (string.IsNullOrEmpty(Ngay))
            {
                obj[4] = new SqlParameter("Ngay", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("Ngay", Ngay);
            }
            Pager<Tin> pg = new Pager<Tin>("tblRss_sp_tblTin_Pager_adm_linhnx", "page", Top, 10, false, "", obj);
            return pg;
        }
        public static TinCollection mobile(string q, int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblTin_select_mobile_linhnx",obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Tin SelectInfo()
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectInfo_linhnx"))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tin SelectUnReadByUser(string username)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("username", username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectUnReadByUser_linhnx",obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinCollection SelectTop(SqlConnection con, int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblTin_select_SelectTop_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTop(int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblTin_select_SelectTop_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection LastestByUser(string username,string ID, int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("username", username);
            obj[1] = new SqlParameter("ID", ID);
            obj[2] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_LastestByUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection MoreByUser(string username, string ID, int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("username", username);
            obj[1] = new SqlParameter("ID", ID);
            obj[2] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_MoreByUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTopTimKiem(int top, string q)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", top);
            obj[1] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblTin_Select_topTimKiem_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTopTimKiemWs(int top, string q)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", top);
            obj[1] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblTin_Select_topTimKiemWs_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Tin UpdateAttr(string id
            ,  string noibathome
            , string noibatdm
            , string docnhieu
            , string hot, string hot1, string hot2, string hot3)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[8];
            if (id != null)
            {
                obj[0] = new SqlParameter("T_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("T_ID", DBNull.Value);
            }
            if (noibathome != null)
            {
                obj[1] = new SqlParameter("T_NoiBatHome", noibathome);
            }
            else
            {
                obj[1] = new SqlParameter("T_NoiBatHome", DBNull.Value);
            }
            if (noibatdm != null)
            {
                obj[2] = new SqlParameter("T_NoiBatDm", noibatdm);
            }
            else
            {
                obj[2] = new SqlParameter("T_NoiBatDm", DBNull.Value);
            }
            if (docnhieu != null)
            {
                obj[3] = new SqlParameter("T_DocNhieu", docnhieu);
            }
            else
            {
                obj[3] = new SqlParameter("T_DocNhieu", DBNull.Value);
            }
            if (hot != null)
            {
                obj[4] = new SqlParameter("T_Hot", hot);
            }
            else
            {
                obj[4] = new SqlParameter("T_Hot", DBNull.Value);
            }
            if (hot1 != null)
            {
                obj[5] = new SqlParameter("T_Hot1", hot1);
            }
            else
            {
                obj[5] = new SqlParameter("T_Hot1", DBNull.Value);
            }
            if (hot2 != null)
            {
                obj[6] = new SqlParameter("T_Hot2", hot2);
            }
            else
            {
                obj[6] = new SqlParameter("T_Hot2", DBNull.Value);
            }
            if (hot3 != null)
            {
                obj[7] = new SqlParameter("T_Hot3", hot3);
            }
            else
            {
                obj[7] = new SqlParameter("T_Hot3", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Update_UpdateAttr_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static string formatPostBBCode(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
[left][url={0}/{2}/{3}/{4}/{9}.html] [img]{12}/lib/up/{1}[/img][/url][/left]
[size=+1][b][url={0}/{2}/{3}/{4}/{9}.html]{5}[/url][/b][/size]
{6}
{7}
", domain, Lib.imgSize(item.Anh, "100x100"), string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatPostBBCodeMax(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
[size=+2][b][url={0}/{2}/{3}/{4}/{9}.html]{5}[/url][/b][/size]
[left][url={0}/{2}/{3}/{4}/{9}.html] [img]{12}/lib/up/{1}[/img][/url][/left]
{6}
{7}
[size=+2][b][url={0}/{2}/{3}/{4}/{9}.html]Xem thêm[/url][/b][/size]
[size=+1][b]Tin liên quan[/b][/size]
", domain, Lib.imgSize(item.Anh, "430x300"), string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatPostHtml(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" style=""padding:5px;padding-right:5px;height:106px;border-top:solid 1px #ccc;overflow:hidden;"">
<img style=""float:left;margin-right:5px;border:solid 1px #EEE;padding:2px;""src=""{12}/lib/up/{1}"">
<a style=""text-decoration:none;color:#333;font-size:14px;font-weight:bold;padding:2px;margin-bottom:5px;"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a><br/>
<span style=""color:#666;font-size:11px;line-height:13px;display:block;max-height:65px;overflow:hidden;"">{6}</span><br/>
<span style=""color:#999;font-size:10px;line-height:12px;"">{7}</span></div>", domain, Lib.imgSize(item.Anh, "100x100"), string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        public static string formatPostHtmlMax(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string _domain = "http://tintuc.me";
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<div _id=""{9}"" style=""padding:5px;padding-right:5px;height:320px;border-top:solid 1px #ccc;overflow:hidden;"">
<img style=""float:left;margin-right:5px;border:solid 1px #EEE;padding:2px;""src=""{12}/lib/up/{1}"">
<a style=""text-decoration:none;color:#333;font-size:18px;font-weight:bold;padding:2px;margin-bottom:5px;"" href=""{0}{2}/{3}/{4}/{9}.html"">{5}</a><br/>
<span style=""color:#666;font-size:11px;line-height:13px;display:block;max-height:65px;overflow:hidden;"">{6}</span><br/>
<span style=""color:#999;font-size:10px;line-height:12px;"">{7}</span><hr color=""#333;"" size=""1""/></div>", domain, Lib.imgSize(item.Anh, "430x300"), string.IsNullOrEmpty(item.DM_Alias) ? "x" : item.DM_Alias, string.IsNullOrEmpty(item.CM_Alias) ? "x" : item.CM_Alias, item.Alias, item.Ten, item.MoTa, item.NgayTao.ToString("HH:mm tt dd/MM/yyyy"), item.BinhChon, item.ID, new Uri(item.Url).Host
               , item.Views, _domain);
            return sb.ToString();
        }
        #endregion
    }
    #endregion
    #endregion
}
