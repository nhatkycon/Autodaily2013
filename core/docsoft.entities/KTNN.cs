using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace docsoft.entities
{
    #region KTNN
    #region BO
    public class KTNN : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }
        public Int32 DM_ID { get; set; }
        public String Lang { get; set; }
        public Boolean LangBased { get; set; }
        public Int32 LangBased_ID { get; set; }
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
        public Boolean Hot { get; set; }
        public Boolean Active { get; set; }
        public Boolean Publish { get; set; }
        public Boolean HetHan { get; set; }
        public Boolean Moi { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public KTNN()
        { }
        #endregion
        #region Customs properties
        public String multiID { get; set; }
        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }
        public string DM_Ten { get; set; }
        public Int32 _ID { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return KTNNDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class KTNNCollection : BaseEntityCollection<KTNN>
    { }
    #endregion
    #region Dal
    public class KTNNDal
    {
        #region Methods

        public static void DeleteById(Int64 KTNN_ID, string DM_Ma)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("KTNN_ID", KTNN_ID);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Delete_DeleteById_linhnx", obj);
        }

        public static KTNN Insert(KTNN Inserted)
        {
            KTNN Item = new KTNN();
            SqlParameter[] obj = new SqlParameter[28];
            obj[0] = new SqlParameter("KTNN_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("KTNN_DM_ID", Inserted.DM_ID);
            obj[2] = new SqlParameter("KTNN_Lang", Inserted.Lang);
            obj[3] = new SqlParameter("KTNN_LangBased", Inserted.LangBased);
            obj[4] = new SqlParameter("KTNN_LangBased_ID", Inserted.LangBased_ID);
            obj[5] = new SqlParameter("KTNN_Alias", Inserted.Alias);
            obj[6] = new SqlParameter("KTNN_Ten", Inserted.Ten);
            obj[7] = new SqlParameter("KTNN_MoTa", Inserted.MoTa);
            obj[8] = new SqlParameter("KTNN_NoiDung", Inserted.NoiDung);
            obj[9] = new SqlParameter("KTNN_TacGia", Inserted.TacGia);
            obj[10] = new SqlParameter("KTNN_Anh", Inserted.Anh);
            obj[11] = new SqlParameter("KTNN_ThuTu", Inserted.ThuTu);
            obj[12] = new SqlParameter("KTNN_Nguon", Inserted.Nguon);
            obj[13] = new SqlParameter("KTNN_NgayTao", Inserted.NgayTao);
            obj[14] = new SqlParameter("KTNN_NguoiTao", Inserted.NguoiTao);
            obj[15] = new SqlParameter("KTNN_NgayCapNhat", Inserted.NgayCapNhat);
            obj[16] = new SqlParameter("KTNN_NguoiCapNhat", Inserted.NguoiCapNhat);
            string htl = string.Format("{0:dd/MM/yy}", Inserted.NgayDang);
            if (htl != "01/01/01")
            {
                obj[17] = new SqlParameter("KTNN_NgayDang", Inserted.NgayDang);
            }
            else
            {
                obj[17] = new SqlParameter("KTNN_NgayDang", DBNull.Value);
            }
            obj[18] = new SqlParameter("KTNN_NgayHetHan", Inserted.NgayHetHan);
            string htl1 = string.Format("{0:dd/MM/yy}", Inserted.NgayHetHan);
            if (htl1 != "01/01/01")
            {
                obj[18] = new SqlParameter("KTNN_NgayHetHan", Inserted.NgayHetHan);
            }
            else
            {
                obj[18] = new SqlParameter("KTNN_NgayHetHan", DBNull.Value);
            }
            //obj[17] = new SqlParameter("KTNN_NgayDang", Inserted.NgayDang);
            //obj[18] = new SqlParameter("KTNN_NgayHetHan", Inserted.NgayHetHan);
            obj[19] = new SqlParameter("KTNN_Views", Inserted.Views);
            obj[20] = new SqlParameter("KTNN_Hot", Inserted.Hot);
            obj[21] = new SqlParameter("KTNN_Active", Inserted.Active);
            obj[22] = new SqlParameter("KTNN_Publish", Inserted.Publish);
            obj[23] = new SqlParameter("KTNN_HetHan", Inserted.HetHan);
            obj[24] = new SqlParameter("KTNN_Moi", Inserted.Moi);
            obj[25] = new SqlParameter("KTNN_RowId", Inserted.RowId);
            obj[26] = new SqlParameter("KTNN_KeyWords", Inserted.KeyWords);
            obj[27] = new SqlParameter("KTNN_Description", Inserted.Description);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KTNN Update(KTNN Updated)
        {
            KTNN Item = new KTNN();
            SqlParameter[] obj = new SqlParameter[29];
            obj[0] = new SqlParameter("KTNN_ID", Updated.ID);
            obj[1] = new SqlParameter("KTNN_GH_ID", Updated.GH_ID);
            obj[2] = new SqlParameter("KTNN_DM_ID", Updated.DM_ID);
            obj[3] = new SqlParameter("KTNN_Lang", Updated.Lang);
            obj[4] = new SqlParameter("KTNN_LangBased", Updated.LangBased);
            obj[5] = new SqlParameter("KTNN_LangBased_ID", Updated.LangBased_ID);
            obj[6] = new SqlParameter("KTNN_Alias", Updated.Alias);
            obj[7] = new SqlParameter("KTNN_Ten", Updated.Ten);
            obj[8] = new SqlParameter("KTNN_MoTa", Updated.MoTa);
            obj[9] = new SqlParameter("KTNN_NoiDung", Updated.NoiDung);
            obj[10] = new SqlParameter("KTNN_TacGia", Updated.TacGia);
            obj[11] = new SqlParameter("KTNN_Anh", Updated.Anh);
            obj[12] = new SqlParameter("KTNN_ThuTu", Updated.ThuTu);
            obj[13] = new SqlParameter("KTNN_Nguon", Updated.Nguon);
            obj[14] = new SqlParameter("KTNN_NgayTao", Updated.NgayTao);
            obj[15] = new SqlParameter("KTNN_NguoiTao", Updated.NguoiTao);
           // obj[16] = new SqlParameter("KTNN_NgayCapNhat", Updated.NgayCapNhat);
            string capnhat = string.Format("{0:dd/MM/yy}", Updated.NgayCapNhat);
            if (capnhat != "01/01/01")
            {
                obj[16] = new SqlParameter("KTNN_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[16] = new SqlParameter("KTNN_NgayCapNhat", DBNull.Value);
            }
            obj[17] = new SqlParameter("KTNN_NguoiCapNhat", Updated.NguoiCapNhat);


            string htl = string.Format("{0:dd/MM/yy}", Updated.NgayDang);
            if (htl != "01/01/01")
            {
                obj[18] = new SqlParameter("KTNN_NgayDang", Updated.NgayDang);
            }
            else
            {
                obj[18] = new SqlParameter("KTNN_NgayDang", DBNull.Value);
            }
           // obj[16] = new SqlParameter("KTNN_NgayHetHan", Updated.NgayHetHan);
            string htl1 = string.Format("{0:dd/MM/yy}", Updated.NgayHetHan);
            if (htl1 != "01/01/01")
            {
                obj[19] = new SqlParameter("KTNN_NgayHetHan", Updated.NgayHetHan);
            }
            else
            {
                obj[19] = new SqlParameter("KTNN_NgayHetHan", DBNull.Value);
            }

            //obj[18] = new SqlParameter("KTNN_NgayDang", Updated.NgayDang);
            //obj[19] = new SqlParameter("KTNN_NgayHetHan", Updated.NgayHetHan);
            obj[20] = new SqlParameter("KTNN_Views", Updated.Views);
            obj[21] = new SqlParameter("KTNN_Hot", Updated.Hot);
            obj[22] = new SqlParameter("KTNN_Active", Updated.Active);
            obj[23] = new SqlParameter("KTNN_Publish", Updated.Publish);
            obj[24] = new SqlParameter("KTNN_HetHan", Updated.HetHan);
            obj[25] = new SqlParameter("KTNN_Moi", Updated.Moi);
            obj[26] = new SqlParameter("KTNN_RowId", Updated.RowId);
            obj[27] = new SqlParameter("KTNN_KeyWords", Updated.KeyWords);
            obj[28] = new SqlParameter("KTNN_Description", Updated.Description);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }


        public static KTNN SelectById(Int64 KTNN_ID)
        {
            KTNN Item = new KTNN();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KTNN_ID", KTNN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static KTNN SelectByIdView(Int64 KTNN_ID)
        {
            KTNN Item = new KTNN();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KTNN_ID", KTNN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectById_linhnxView", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KTNN SelectByIdViewFD(Int64 KTNN_ID)
        {
            KTNN Item = new KTNN();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KTNN_ID", KTNN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectById_linhnxViewFD", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KTNNCollection SelectAll()
        {
            KTNNCollection List = new KTNNCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        //public static Pager<KTNN> pagerNormalSearch(SqlConnection con, string url, bool rewrite, string sort, string q, int size)
        //{
        //    SqlParameter[] obj = new SqlParameter[2];
        //    obj[0] = new SqlParameter("Sort", sort);
        //    if (!string.IsNullOrEmpty(q))
        //    {
        //        obj[1] = new SqlParameter("q", q);
        //    }
        //    else
        //    {
        //        obj[1] = new SqlParameter("q", DBNull.Value);
        //    }

        //    Pager<KTNN> pg = new Pager<KTNN>(con, "sp_tblHangHoa_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
        //    return pg;
        //}
        public static Pager<KTNN> pagerNormal(string url, bool rewrite, string sort, string q, string dm, string nguoitao, int acp,string _Code,string Lang)
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
            Pager<KTNN> pg = new Pager<KTNN>("sp_tblKTNN_Pager_Normal_linhnx_All", "pages", 10, 10, rewrite, url, obj);
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
        public static Pager<KTNN> pagerNormalView(SqlConnection cnn, string url, bool rewrite, string sort,  string dm, string _Code, string Lang, int size)
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
          
            Pager<KTNN> pg = new Pager<KTNN>(cnn, "sp_tblKTNN_Pager_Normal_linhnx_AllView", "Pages", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<KTNN> pagerNormalTin(string url, bool rewrite, string sort, string q, string dm, string nguoitao, int acp, string _Code, string Lang,string pagesize)
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
            Pager<KTNN> pg = new Pager<KTNN>("sp_tblKTNN_Pager_Normal_linhnx", "page",Convert.ToInt32(pagesize) , 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<KTNN> pagerDuyet(string url, bool rewrite, string sort, string q, string dm, string nguoitao, int acp, string _Code, string Lang)
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
            Pager<KTNN> pg = new Pager<KTNN>("sp_tblKTNN_Pager_Normal_linhnx_duyet", "page", 10, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<KTNN> pagerNormalThongke(string url, bool rewrite, string sort, string q, string dm, string nguoitao, string _tungay, string _denngay, int acp, string _Code)
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
            Pager<KTNN> pg = new Pager<KTNN>("sp_tblKTNN_Pager_Normal_linhnx_KT", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static KTNN getFromReader(IDataReader rd)
        {
            KTNN Item = new KTNN();
            if (rd.FieldExists("KTNN_ID"))
            {
                Item.ID = (Int32)(rd["KTNN_ID"]);
            }
            if (rd.FieldExists("_KTNN_ID"))
            {
                Item._ID = (Int32)(rd["_KTNN_ID"]);
            }
            if (rd.FieldExists("KTNN_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["KTNN_GH_ID"]);
            }
            if (rd.FieldExists("KTNN_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["KTNN_DM_ID"]);
            }
            if (rd.FieldExists("KTNN_Lang"))
            {
                Item.Lang = (String)(rd["KTNN_Lang"]);
            }
            if (rd.FieldExists("KTNN_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["KTNN_LangBased"]);
            }
            if (rd.FieldExists("KTNN_LangBased_ID"))
            {
                Item.LangBased_ID = (Int32)(rd["KTNN_LangBased_ID"]);
            }
            if (rd.FieldExists("KTNN_Alias"))
            {
                Item.Alias = (String)(rd["KTNN_Alias"]);
            }
            if (rd.FieldExists("KTNN_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["KTNN_DM_Ten"]);
            }
            if (rd.FieldExists("KTNN_Ten"))
            {
                Item.Ten = (String)(rd["KTNN_Ten"]);
            }
            if (rd.FieldExists("KTNN_MoTa"))
            {
                Item.MoTa = (String)(rd["KTNN_MoTa"]);
            }
            if (rd.FieldExists("KTNN_NoiDung"))
            {
                Item.NoiDung = (String)(rd["KTNN_NoiDung"]);
            }
            if (rd.FieldExists("KTNN_KeyWords"))
            {
                Item.KeyWords = (String)(rd["KTNN_KeyWords"]);
            }
            if (rd.FieldExists("KTNN_Description"))
            {
                Item.Description = (String)(rd["KTNN_Description"]);
            }
            if (rd.FieldExists("KTNN_TacGia"))
            {
                Item.TacGia = (String)(rd["KTNN_TacGia"]);
            }
            if (rd.FieldExists("KTNN_Anh"))
            {
                Item.Anh = (String)(rd["KTNN_Anh"]);
            }
            if (rd.FieldExists("KTNN_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["KTNN_ThuTu"]);
            }
            if (rd.FieldExists("KTNN_Nguon"))
            {
                Item.Nguon = (String)(rd["KTNN_Nguon"]);
            }
            if (rd.FieldExists("KTNN_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["KTNN_NgayTao"]);
            }
            if (rd.FieldExists("KTNN_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["KTNN_NguoiTao"]);
            }
            if (rd.FieldExists("KTNN_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["KTNN_NgayCapNhat"]);
            }
            if (rd.FieldExists("KTNN_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["KTNN_NguoiCapNhat"]);
            }
            if (rd.FieldExists("KTNN_NgayDang"))
            {
                Item.NgayDang = (DateTime)(rd["KTNN_NgayDang"]);
            }
            if (rd.FieldExists("KTNN_NgayHetHan"))
            {
                Item.NgayHetHan = (DateTime)(rd["KTNN_NgayHetHan"]);
            }
            if (rd.FieldExists("KTNN_Views"))
            {
                Item.Views = (Int32)(rd["KTNN_Views"]);
            }
            if (rd.FieldExists("KTNN_Hot"))
            {
                Item.Hot = (Boolean)(rd["KTNN_Hot"]);
            }
            if (rd.FieldExists("KTNN_Active"))
            {
                Item.Active = (Boolean)(rd["KTNN_Active"]);
            }
            if (rd.FieldExists("KTNN_Publish"))
            {
                Item.Publish = (Boolean)(rd["KTNN_Publish"]);
            }
            if (rd.FieldExists("KTNN_HetHan"))
            {
                Item.HetHan = (Boolean)(rd["KTNN_HetHan"]);
            }
            if (rd.FieldExists("KTNN_Moi"))
            {
                Item.Moi = (Boolean)(rd["KTNN_Moi"]);
            }
            if (rd.FieldExists("KTNN_RowId"))
            {
                Item.RowId = (Guid)(rd["KTNN_RowId"]);
            }
            if (rd.FieldExists("KTNN_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["KTNN_DM_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteMultiById(String KTNN_ID, string DM_Ma)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("KTNN_ID", KTNN_ID);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Delete_DeleteMultiById_hungpm", obj);
        }
        public static void UpdateHotMulti(KTNN KTNN_Hot)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("KTNN_ID", KTNN_Hot.multiID);
            obj[1] = new SqlParameter("KTNN_Hot", KTNN_Hot.Hot);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Update_UpdateHotMultiById_hungpm", obj);
        }
        public static void UpdateMulti(KTNN KTNN_Active)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("KTNN_ID", KTNN_Active.multiID);
            obj[1] = new SqlParameter("KTNN_Active", KTNN_Active.Active);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Update_UpdateMultiById_hungpm", obj);
        }
        public static void UpdateHetHanMulti(KTNN TinHetHan)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("KTNN_ID", TinHetHan.multiID);
            obj[1] = new SqlParameter("KTNN_HetHan", TinHetHan.HetHan);
            obj[2] = new SqlParameter("KTNN_NgayHetHan", TinHetHan.NgayHetHan);
            string htl = string.Format("{0:dd/MM/yy}", TinHetHan.NgayHetHan);
            if (htl != "01/01/01")
            {
                obj[2] = new SqlParameter("KTNN_NgayHetHan", TinHetHan.NgayHetHan);
            }
            else
            {
                obj[2] = new SqlParameter("KTNN_NgayHetHan", DBNull.Value);
            }
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Update_UpdateHetHanMultiById_hungpm", obj);
        }      
        public static KTNNCollection SelectTopTen()
        {
            KTNNCollection List = new KTNNCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectTopTen_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static KTNNCollection SelectTopTen( SqlConnection con )
        {
            KTNNCollection List = new KTNNCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectTopTen_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection SelectTop(int Top)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectTop_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static KTNNCollection SelectTopViewAlot(int Top)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectTopViewAlot_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection SelectDanhSachHome(int top)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssKTNN_Select_SelectDanhSachHome_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection SelectTopThongBao(int top)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssKTNN_Select_SelectTopThongBao_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection byDanhMuc(int top,string dm_id)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_id", dm_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssKTNN_Select_byDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection byLoaiDanhMuc(int top, string dm_id)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_id", dm_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssKTNN_Select_byLoaiDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection byMaLoaiDanhMuc(int top, string dm_id)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_id", dm_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssKTNN_Select_byMaLoaiDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection GetTinbyMaDanhMuc(int top, string DM_Ma)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssKTNN_Select_byDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection SelectByDanhMuc(string DM_Ma,int Top)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectByDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection SelectByDanhMuc(string DM_ID, int Top, DateTime NgayCapNhat)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            obj[2] = new SqlParameter("NgayCapNhat", NgayCapNhat);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectByDanhMucID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection SelectByDanhMucNew(string DM_ID, int Top)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectByDanhMucNewID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection SelectByDiemBaoNew( int Top)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[1];
          
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectByDiemBaoNewID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNNCollection SelectTopHot(int Top)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectTopHot_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<KTNN> pagerByDanhMuc(string url, bool rewrite, string sort, string dm)
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
            Pager<KTNN> pg = new Pager<KTNN>("sp_tblKTNN_Pager_pagerByDanhMuc_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static KTNNCollection lienQuan(int Top, string Id, int dmId)
        {
            KTNNCollection List = new KTNNCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Id", Id);
            obj[2] = new SqlParameter("DM_ID", dmId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_lienQuan_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static KTNN SelectByIdView(Int32 VBD_ID)
        {
            KTNN Item = new KTNN();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KTNN_ID", VBD_ID);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKTNN_Select_SelectByIdView_linhnx", obj))
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
        public static Pager<KTNN> pagerBySearch(string url, bool rewrite, string sort, string q)
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
            Pager<KTNN> pg = new Pager<KTNN>("sp_tblKTNN_Pager_pagerBySearch_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion
    #endregion
}
