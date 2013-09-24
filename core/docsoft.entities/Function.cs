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
    #region Function
    #region BO
    public class Function : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 PID { get; set; }
        public Int32 Level { get; set; }
        public Int16 Loai { get; set; }
        public String Ten { get; set; }
        public String Anh { get; set; }
        public String MoTa { get; set; }
        public String Ma { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Active { get; set; }
        public Boolean GiaTriMacDinh { get; set; }
        public String Url { get; set; }
        public Guid RowId { get; set; }
        public String PIDList { get; set; }
        public Boolean Publish { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public Boolean Desk { get; set; }
        public Boolean DeskMacDinh { get; set; }
        public String Doc { get; set; }
        #endregion
        #region Contructor
        public Function()
        { }
        #endregion
        #region Customs properties
        public Function _Parent { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return FunctionDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class FunctionCollection : BaseEntityCollection<Function>
    { }
    #endregion
    #region Dal
    public class FunctionDal
    {
        #region Methods

        public static void DeleteById(Int32 FN_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("FN_ID", FN_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Delete_DeleteById_linhnx", obj);
        }
        public static Function Insert(Function Inserted)
        {
            Function Item = new Function();
            SqlParameter[] obj = new SqlParameter[20];
            obj[0] = new SqlParameter("FN_PID", Inserted.PID);
            obj[1] = new SqlParameter("FN_Level", Inserted.Level);
            obj[2] = new SqlParameter("FN_Loai", Inserted.Loai);
            obj[3] = new SqlParameter("FN_Ten", Inserted.Ten);
            obj[4] = new SqlParameter("FN_Anh", Inserted.Anh);
            obj[5] = new SqlParameter("FN_MoTa", Inserted.MoTa);
            obj[6] = new SqlParameter("FN_Ma", Inserted.Ma);
            obj[7] = new SqlParameter("FN_ThuTu", Inserted.ThuTu);
            obj[8] = new SqlParameter("FN_Active", Inserted.Active);
            obj[9] = new SqlParameter("FN_GiaTriMacDinh", Inserted.GiaTriMacDinh);
            obj[10] = new SqlParameter("FN_Url", Inserted.Url);
            obj[11] = new SqlParameter("FN_RowId", Inserted.RowId);
            obj[12] = new SqlParameter("FN_PIDList", Inserted.PIDList);
            obj[13] = new SqlParameter("FN_Publish", Inserted.Publish);
            obj[14] = new SqlParameter("FN_NgayTao", Inserted.NgayTao);
            obj[15] = new SqlParameter("FN_NgayCapNhat", Inserted.NgayCapNhat);
            obj[16] = new SqlParameter("FN_NguoiTao", Inserted.NguoiTao);
            obj[17] = new SqlParameter("FN_Desk", Inserted.Desk);
            obj[18] = new SqlParameter("FN_DeskMacDinh", Inserted.DeskMacDinh);
            obj[19] = new SqlParameter("FN_Doc", Inserted.Doc);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Function Update(Function Updated)
        {
            Function Item = new Function();
            SqlParameter[] obj = new SqlParameter[21];
            obj[0] = new SqlParameter("FN_ID", Updated.ID);
            obj[1] = new SqlParameter("FN_PID", Updated.PID);
            obj[2] = new SqlParameter("FN_Level", Updated.Level);
            obj[3] = new SqlParameter("FN_Loai", Updated.Loai);
            obj[4] = new SqlParameter("FN_Ten", Updated.Ten);
            obj[5] = new SqlParameter("FN_Anh", Updated.Anh);
            obj[6] = new SqlParameter("FN_MoTa", Updated.MoTa);
            obj[7] = new SqlParameter("FN_Ma", Updated.Ma);
            obj[8] = new SqlParameter("FN_ThuTu", Updated.ThuTu);
            obj[9] = new SqlParameter("FN_Active", Updated.Active);
            obj[10] = new SqlParameter("FN_GiaTriMacDinh", Updated.GiaTriMacDinh);
            obj[11] = new SqlParameter("FN_Url", Updated.Url);
            obj[12] = new SqlParameter("FN_RowId", Updated.RowId);
            obj[13] = new SqlParameter("FN_PIDList", Updated.PIDList);
            obj[14] = new SqlParameter("FN_Publish", Updated.Publish);
            obj[15] = new SqlParameter("FN_NgayTao", Updated.NgayTao);
            obj[16] = new SqlParameter("FN_NgayCapNhat", Updated.NgayCapNhat);
            obj[17] = new SqlParameter("FN_NguoiTao", Updated.NguoiTao);
            obj[18] = new SqlParameter("FN_Desk", Updated.Desk);
            obj[19] = new SqlParameter("FN_DeskMacDinh", Updated.DeskMacDinh);
            obj[20] = new SqlParameter("FN_Doc", Updated.Doc);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Function SelectById(Int32 FN_ID)
        {
            Function Item = new Function();
            SqlParameter[] obj = new SqlParameter[1];
            Function _Item = new Function();
            obj[0] = new SqlParameter("FN_ID", FN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    _Item.Ten = (String)(rd["FN_PTen"]);
                    Item = getFromReader(rd);
                }
            }
            Item._Parent = _Item;
            return Item;
        }
        public static FunctionCollection SelectByUser(string Username, string Desk)
        {
            FunctionCollection List = new FunctionCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Desk", Desk);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Select_SelectByUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static FunctionCollection SelectByUserAndCQID(string Username, string CQ_ID)
        {
            FunctionCollection List = new FunctionCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Select_SelectByUserAndCQID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static FunctionCollection SelectAllByCqID(string CQ_ID)
        {
            FunctionCollection List = new FunctionCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Select_SelectAllByCqID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static FunctionCollection SelectAllFunctionByRole(string ROLE_ID)
        {
            FunctionCollection List = new FunctionCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ROLE_ID", ROLE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Select_SelectAllFunctionByRole_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static FunctionCollection SelectByUserAndFNID(string Username, string FNID)
        {
            FunctionCollection List = new FunctionCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("FN_ID", FNID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Select_SelectByUserAndFNID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static FunctionCollection SelectTree(string q)
        {
            FunctionCollection List = new FunctionCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Select_SelectTree_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static FunctionCollection SelectAll()
        {
            FunctionCollection List = new FunctionCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static FunctionCollection SelectDeskTop()
        {
            FunctionCollection List = new FunctionCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFunction_Select_SelectDeskTop_hungpm"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Function> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Function> pg = new Pager<Function>("sp_tblFunction_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Function getFromReader(IDataReader rd)
        {
            //Function Item = new Function();
            //Item.ID = (Int32)(rd["FN_ID"]);
            //Item.PID = (Int32)(rd["FN_PID"]);
            //Item.Level = (Int32)(rd["FN_Level"]);
            //Item.Loai = (Int16)(rd["FN_Loai"]);
            //Item.Ten = (String)(rd["FN_Ten"]);
            //Item.Anh = (String)(rd["FN_Anh"]);
            //Item.MoTa = (String)(rd["FN_MoTa"]);
            //Item.Ma = (String)(rd["FN_Ma"]);
            //Item.ThuTu = (Int32)(rd["FN_ThuTu"]);
            //Item.Active = (Boolean)(rd["FN_Active"]);
            //Item.GiaTriMacDinh = (Boolean)(rd["FN_GiaTriMacDinh"]);
            //Item.Url = (String)(rd["FN_Url"]);
            //Item.RowId = (Guid)(rd["FN_RowId"]);
            //Item.PIDList = (String)(rd["FN_PIDList"]);
            //Item.Publish = (Boolean)(rd["FN_Publish"]);
            //Item.NgayTao = (DateTime)(rd["FN_NgayTao"]);
            //Item.NgayCapNhat = (DateTime)(rd["FN_NgayCapNhat"]);
            //Item.NguoiTao = (String)(rd["FN_NguoiTao"]);
            //Item.Desk = (Boolean)(rd["FN_Desk"]);
            //Item.DeskMacDinh = (Boolean)(rd["FN_DeskMacDinh"]);
            //Item.Doc = (String)(rd["FN_Doc"]);
            //return Item;
            Function Item = new Function();
            if (rd.FieldExists("FN_ID"))
            {
                Item.ID = (Int32)(rd["FN_ID"]);
            }
            if (rd.FieldExists("FN_PID"))
            {
                Item.PID = (Int32)(rd["FN_PID"]);
            }
            //if (rd.FieldExists("FN_Lang"))
            //{
            //    Item.Lang = (String)(rd["FN_Lang"]);
            //}
            //if (rd.FieldExists("FN_LangBased"))
            //{
            //    Item.LangBased = (Boolean)(rd["FN_LangBased"]);
            //}
            //if (rd.FieldExists("FN_LangBasedId"))
            //{
            //    Item.LangBasedId = (Int32)(rd["FN_LangBasedId"]);
            //}
            if (rd.FieldExists("FN_Level"))
            {
                Item.Level = (Int32)(rd["FN_Level"]);
            }
            if (rd.FieldExists("FN_Loai"))
            {
                Item.Loai = (Int16)(rd["FN_Loai"]);
            }
            if (rd.FieldExists("FN_Ten"))
            {
                Item.Ten = (String)(rd["FN_Ten"]);
            }
            if (rd.FieldExists("FN_Anh"))
            {
                Item.Anh = (String)(rd["FN_Anh"]);
            }
            if (rd.FieldExists("FN_MoTa"))
            {
                Item.MoTa = (String)(rd["FN_MoTa"]);
            }
            if (rd.FieldExists("FN_Ma"))
            {
                Item.Ma = (String)(rd["FN_Ma"]);
            }
            if (rd.FieldExists("FN_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["FN_ThuTu"]);
            }
            if (rd.FieldExists("FN_Active"))
            {
                Item.Active = (Boolean)(rd["FN_Active"]);
            }
            if (rd.FieldExists("FN_GiaTriMacDinh"))
            {
                Item.GiaTriMacDinh = (Boolean)(rd["FN_GiaTriMacDinh"]);
            }
            if (rd.FieldExists("FN_Url"))
            {
                Item.Url = (String)(rd["FN_Url"]);
            }
            if (rd.FieldExists("FN_RowId"))
            {
                Item.RowId = (Guid)(rd["FN_RowId"]);
            }
            if (rd.FieldExists("FN_PIDList"))
            {
                Item.PIDList = (String)(rd["FN_PIDList"]);
            }
            if (rd.FieldExists("FN_Publish"))
            {
                Item.Publish = (Boolean)(rd["FN_Publish"]);
            }
            if (rd.FieldExists("FN_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["FN_NgayTao"]);
            }
            if (rd.FieldExists("FN_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["FN_NgayCapNhat"]);
            }
            if (rd.FieldExists("FN_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["FN_NguoiTao"]);
            }
            if (rd.FieldExists("FN_Desk"))
            {
                Item.Desk = (Boolean)(rd["FN_Desk"]);
            }
            if (rd.FieldExists("FN_DeskMacDinh"))
            {
                Item.DeskMacDinh = (Boolean)(rd["FN_DeskMacDinh"]);
            }
            if (rd.FieldExists("FN_Doc"))
            {
                Item.Doc = (String)(rd["FN_Doc"]);
            }
            return Item;      
        }
        #endregion
    }
    #endregion

    #endregion
    
}


