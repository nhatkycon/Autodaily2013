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
    #region LienHe
    #region BO
    public class LienHe : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Guid PRowId { get; set; }
        public Int32 PID { get; set; }
        public String Lang { get; set; }
        public Boolean LangBased { get; set; }
        public Int32 LangBasedId { get; set; }
        public Int32 GH_ID { get; set; }
        public String ChucDanh { get; set; }
        public String Anh { get; set; }
        public String Ten { get; set; }
        public Boolean GioiTinh { get; set; }
        public String DiaChi { get; set; }
        public String CongTy { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public String Phone { get; set; }
        public String Skype { get; set; }
        public String Ym { get; set; }
        public String Website { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean Active { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public LienHe()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LienHeDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LienHeCollection : BaseEntityCollection<LienHe>
    { }
    #endregion
    #region Dal
    public class LienHeDal
    {
        #region Methods

        public static void DeleteByIdList(string LH_IDList)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LH_IDlist", LH_IDList);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Delete_DeleteByListId", obj);
        }
        public static void SelectByGhId(SqlConnection con,string GH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", GH_ID);
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_tblLienhe_Select_SelectByGhId_hoangda", obj);
        }
        public static void DeleteById(Int32 LH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LH_ID", LH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Delete_DeleteById", obj);
        }

        public static LienHe Insert(LienHe Inserted)
        {
            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[23];
            obj[0] = new SqlParameter("LH_PRowId", Inserted.PRowId);
            obj[1] = new SqlParameter("LH_PID", Inserted.PID);
            obj[2] = new SqlParameter("LH_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("LH_DiaChi", Inserted.DiaChi);
            obj[4] = new SqlParameter("LH_CongTy", Inserted.CongTy);
            obj[5] = new SqlParameter("LH_Email", Inserted.Email);
            obj[6] = new SqlParameter("LH_Mobile", Inserted.Mobile);
            obj[7] = new SqlParameter("LH_Phone", Inserted.Phone);
            obj[8] = new SqlParameter("LH_Skype", Inserted.Skype);
            obj[9] = new SqlParameter("LH_Ym", Inserted.Ym);
            obj[10] = new SqlParameter("LH_Website", Inserted.Website);
            obj[11] = new SqlParameter("LH_NgayTao", Inserted.NgayTao);
            obj[12] = new SqlParameter("LH_NgayCapNhat", Inserted.NgayCapNhat);
            obj[13] = new SqlParameter("LH_NguoiTao", Inserted.NguoiTao);
            obj[14] = new SqlParameter("LH_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[15] = new SqlParameter("LH_Active", Inserted.Active);
            obj[16] = new SqlParameter("LH_RowId", Inserted.RowId);
            obj[17] = new SqlParameter("LH_GioiTinh", Inserted.GioiTinh);
            obj[18] = new SqlParameter("LH_ChucDanh", Inserted.ChucDanh);
            obj[19] = new SqlParameter("LH_Anh", Inserted.Anh);
            obj[20] = new SqlParameter("LH_Lang", Inserted.Lang);
            obj[21] = new SqlParameter("LH_LangBased", Inserted.LangBased);
            obj[22] = new SqlParameter("LH_LangBasedId", Inserted.LangBasedId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Insert_InsertNormal", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LienHe Update(LienHe Updated)
        {
            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[25];
            obj[0] = new SqlParameter("LH_ID", Updated.ID);
            obj[1] = new SqlParameter("LH_PRowId", Updated.PRowId);
            obj[2] = new SqlParameter("LH_PID", Updated.PID);
            obj[3] = new SqlParameter("LH_GH_ID", Updated.GH_ID);
            obj[4] = new SqlParameter("LH_Lang", Updated.Lang);
            obj[5] = new SqlParameter("LH_LangBased", Updated.LangBased);
            obj[6] = new SqlParameter("LH_LangBasedId", Updated.LangBasedId);
            obj[7] = new SqlParameter("LH_Anh", Updated.Anh);
            obj[8] = new SqlParameter("LH_ChucDanh", Updated.ChucDanh);
            obj[9] = new SqlParameter("LH_Ten", Updated.Ten);
            obj[10] = new SqlParameter("LH_GioiTinh", Updated.GioiTinh);
            obj[11] = new SqlParameter("LH_DiaChi", Updated.DiaChi);
            obj[12] = new SqlParameter("LH_CongTy", Updated.CongTy);
            obj[13] = new SqlParameter("LH_Email", Updated.Email);
            obj[14] = new SqlParameter("LH_Mobile", Updated.Mobile);
            obj[15] = new SqlParameter("LH_Phone", Updated.Phone);
            obj[16] = new SqlParameter("LH_Skype", Updated.Skype);
            obj[17] = new SqlParameter("LH_Ym", Updated.Ym);
            obj[18] = new SqlParameter("LH_Website", Updated.Website);
            if (Updated.NgayTao != DateTime.MinValue)
            {
                obj[19] = new SqlParameter("LH_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[19] = new SqlParameter("LH_NgayTao", DBNull.Value);
            }
            obj[20] = new SqlParameter("LH_NgayCapNhat", Updated.NgayCapNhat);
            obj[21] = new SqlParameter("LH_NguoiTao", Updated.NguoiTao);
            obj[22] = new SqlParameter("LH_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[23] = new SqlParameter("LH_Active", Updated.Active);
            obj[24] = new SqlParameter("LH_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LienHe SelectById(Int32 LH_ID)
        {
            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LH_ID", LH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Select_SelectById", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static LienHe SelectByPId(string LH_PID)
        {
            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LH_PID", LH_PID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Select_SelectByPId_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static LienHe SelectByGhId(Int32 gh_id)
        {
            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("gh_id", gh_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Select_SelectByGhId_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static LienHeCollection SelectByGH_ID(Int32 GH_ID) // manhtv
        {
            LienHeCollection list = new LienHeCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("gh_id", GH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Select_SelectByGhId_hiennb", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static LienHe SelectByGhId(SqlConnection con,Int32 gh_id)
        {
            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("gh_id", gh_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblLienHe_Select_SelectByGhId_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static LienHe SelectByProwID(SqlConnection con, Guid PRowID)
        {
            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PRowID", PRowID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblLienHe_Select_SelectByProwID_Hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static LienHeCollection SelectByActive(bool active) {
            LienHeCollection list = new LienHeCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("active", active);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Select_SelectByActive", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static LienHe SelectByuser(string username)
        {
            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("username", username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Select_SelectByUser_lord", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static LienHeCollection SelectAll()
        {
            LienHeCollection List = new LienHeCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienHe_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LienHe> pagerNormal(string url, bool rewrite, string sort, string q, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            Pager<LienHe> pg = new Pager<LienHe>("sp_tblLienHe_Pager_Normal", "Page", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static LienHe getFromReader(IDataReader rd)
        {
            LienHe Item = new LienHe();
            if (rd.FieldExists("LH_ID"))
            {
                Item.ID = (Int32)(rd["LH_ID"]);
            }
            if (rd.FieldExists("LH_PRowId"))
            {
                Item.PRowId = (Guid)(rd["LH_PRowId"]);
            }
            
            if (rd.FieldExists("LH_PID"))
            {
                Item.PID = (Int32)(rd["LH_PID"]);
            }
            if (rd.FieldExists("LH_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["LH_LangBased"]);
            }
            if (rd.FieldExists("LH_LangBasedId"))
            {
                Item.LangBasedId = (Int32)(rd["LH_LangBasedId"]);
            }
            if (rd.FieldExists("LH_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["LH_GH_ID"]);
            }
            if (rd.FieldExists("LH_Lang"))
            {
                Item.Lang = (String)(rd["LH_Lang"]);
            }
            if (rd.FieldExists("LH_Ten"))
            {
                Item.Ten = (String)(rd["LH_Ten"]);
            }
            if (rd.FieldExists("LH_ChucDanh"))
            {
                Item.ChucDanh = (String)(rd["LH_ChucDanh"]);
            }
            if (rd.FieldExists("LH_Anh"))
            {
                Item.Anh = (String)(rd["LH_Anh"]);
            }
            if (rd.FieldExists("LH_GioiTinh"))
            {
                Item.GioiTinh = (Boolean)(rd["LH_GioiTinh"]);
            }
            if (rd.FieldExists("LH_DiaChi"))
            {
                Item.DiaChi = (String)(rd["LH_DiaChi"]);
            }
            if (rd.FieldExists("LH_CongTy"))
            {
                Item.CongTy = (String)(rd["LH_CongTy"]);
            }
            if (rd.FieldExists("LH_Email"))
            {
                Item.Email = (String)(rd["LH_Email"]);
            }
            if (rd.FieldExists("LH_Mobile"))
            {
                Item.Mobile = (String)(rd["LH_Mobile"]);
            }
            if (rd.FieldExists("LH_Phone"))
            {
                Item.Phone = (String)(rd["LH_Phone"]);
            }
            if (rd.FieldExists("LH_Skype"))
            {
                Item.Skype = (String)(rd["LH_Skype"]);
            }
            if (rd.FieldExists("LH_Ym"))
            {
                Item.Ym = (String)(rd["LH_Ym"]);
            }
            if (rd.FieldExists("LH_Website"))
            {
                Item.Website = (String)(rd["LH_Website"]);
            }
            if (rd.FieldExists("LH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LH_NgayTao"]);
            }
            if (rd.FieldExists("LH_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["LH_NgayCapNhat"]);
            }
            if (rd.FieldExists("LH_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["LH_NguoiTao"]);
            }
            if (rd.FieldExists("LH_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["LH_NguoiCapNhat"]);
            }
            if (rd.FieldExists("LH_Active"))
            {
                Item.Active = (Boolean)(rd["LH_Active"]);
            }
            if (rd.FieldExists("LH_RowId"))
            {
                Item.RowId = (Guid)(rd["LH_RowId"]);
            }
            return Item;
        }
        #endregion

        #region Extend

        public static LienHe InsertLH(SqlTransaction tran, string lh_PRowId)
        {

            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[20];
            obj[0] = new SqlParameter("LH_PRowId", lh_PRowId);
            obj[1] = new SqlParameter("LH_PID", string.Empty);
            obj[2] = new SqlParameter("LH_Ten", string.Empty);
            obj[3] = new SqlParameter("LH_DiaChi", string.Empty);
            obj[4] = new SqlParameter("LH_CongTy", string.Empty);
            obj[5] = new SqlParameter("LH_Email", string.Empty);
            obj[6] = new SqlParameter("LH_Mobile", string.Empty);
            obj[7] = new SqlParameter("LH_Phone", string.Empty);
            obj[8] = new SqlParameter("LH_Skype", string.Empty);
            obj[9] = new SqlParameter("LH_Ym", string.Empty);
            obj[10] = new SqlParameter("LH_Website", string.Empty);
            obj[11] = new SqlParameter("LH_NgayTao", DateTime.Now);
            obj[12] = new SqlParameter("LH_NgayCapNhat", string.Empty);
            obj[13] = new SqlParameter("LH_NguoiTao", string.Empty);
            obj[14] = new SqlParameter("LH_NguoiCapNhat", string.Empty);
            obj[15] = new SqlParameter("LH_Active", string.Empty);
            obj[16] = new SqlParameter("LH_RowId", Guid.NewGuid());
            obj[17] = new SqlParameter("LH_GioiTinh", string.Empty);
            obj[18] = new SqlParameter("LH_ChucDanh", string.Empty);
            obj[19] = new SqlParameter("LH_Anh", string.Empty);
            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblLienHe_Insert_InsertNormal", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static LienHe Insert2(LienHe Inserted,SqlConnection con)
        {
            LienHe Item = new LienHe();
            SqlParameter[] obj = new SqlParameter[20];
            obj[0] = new SqlParameter("LH_PRowId", Inserted.PRowId);
            obj[1] = new SqlParameter("LH_PID", Inserted.PID);
            obj[2] = new SqlParameter("LH_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("LH_DiaChi", Inserted.DiaChi);
            obj[4] = new SqlParameter("LH_CongTy", Inserted.CongTy);
            obj[5] = new SqlParameter("LH_Email", Inserted.Email);
            obj[6] = new SqlParameter("LH_Mobile", Inserted.Mobile);
            obj[7] = new SqlParameter("LH_Phone", Inserted.Phone);
            obj[8] = new SqlParameter("LH_Skype", Inserted.Skype);
            obj[9] = new SqlParameter("LH_Ym", Inserted.Ym);
            obj[10] = new SqlParameter("LH_Website", Inserted.Website);
            obj[11] = new SqlParameter("LH_NgayTao", Inserted.NgayTao);
            obj[12] = new SqlParameter("LH_NgayCapNhat", Inserted.NgayCapNhat);
            obj[13] = new SqlParameter("LH_NguoiTao", Inserted.NguoiTao);
            obj[14] = new SqlParameter("LH_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[15] = new SqlParameter("LH_Active", Inserted.Active);
            obj[16] = new SqlParameter("LH_RowId", Inserted.RowId);
            obj[17] = new SqlParameter("LH_GioiTinh", Inserted.GioiTinh);
            obj[18] = new SqlParameter("LH_ChucDanh", Inserted.ChucDanh);
            obj[19] = new SqlParameter("LH_Anh", Inserted.Anh);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblLienHe_Insert_InsertNormal", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
}
