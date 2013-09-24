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
    #region CoQuan
    #region BO
    [Serializable()]
    public class CoQuan : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 PID { get; set; }
        public Int32 ThuTu { get; set; }
        public Int32 Loai { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String MoTa { get; set; }
        public String PIDList { get; set; }
        public Int32 Level { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public Boolean Active { get; set; }
        public String NguoiCapNhat { get; set; }
        #endregion
        #region Contructor
        public CoQuan()
        { }
        #endregion
        #region Customs properties
        public CoQuan _Parent { get; set; }
        public int NSD { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return CoQuanDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class CoQuanCollection : BaseEntityCollection<CoQuan>
    { }
    #endregion
    #region Dal
    public class CoQuanDal
    {
        #region Methods

        public static void DeleteById(Int32 CQ_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuan_Delete_DeleteById_linhnx", obj);
        }

        public static CoQuan Insert(CoQuan Inserted)
        {
            CoQuan Item = new CoQuan();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("CQ_PID", Inserted.PID);
            obj[1] = new SqlParameter("CQ_ThuTu", Inserted.ThuTu);
            obj[2] = new SqlParameter("CQ_Loai", Inserted.Loai);
            obj[3] = new SqlParameter("CQ_Ten", Inserted.Ten);
            obj[4] = new SqlParameter("CQ_Ma", Inserted.Ma);
            obj[5] = new SqlParameter("CQ_MoTa", Inserted.MoTa);
            obj[6] = new SqlParameter("CQ_PIDList", Inserted.PIDList);
            obj[7] = new SqlParameter("CQ_Level", Inserted.Level);
            obj[8] = new SqlParameter("CQ_RowId", Inserted.RowId);
            obj[9] = new SqlParameter("CQ_NgayTao", Inserted.NgayTao);
            obj[10] = new SqlParameter("CQ_NgayCapNhat", Inserted.NgayCapNhat);
            obj[11] = new SqlParameter("CQ_NguoiTao", Inserted.NguoiTao);
            obj[12] = new SqlParameter("CQ_Active", Inserted.Active);
            obj[13] = new SqlParameter("CQ_NguoiCapNhat", Inserted.NguoiCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static CoQuan Update(CoQuan Updated)
        {
            CoQuan Item = new CoQuan();
            SqlParameter[] obj = new SqlParameter[15];
            obj[0] = new SqlParameter("CQ_ID", Updated.ID);
            obj[1] = new SqlParameter("CQ_PID", Updated.PID);
            obj[2] = new SqlParameter("CQ_ThuTu", Updated.ThuTu);
            obj[3] = new SqlParameter("CQ_Loai", Updated.Loai);
            obj[4] = new SqlParameter("CQ_Ten", Updated.Ten);
            obj[5] = new SqlParameter("CQ_Ma", Updated.Ma);
            obj[6] = new SqlParameter("CQ_MoTa", Updated.MoTa);
            obj[7] = new SqlParameter("CQ_PIDList", Updated.PIDList);
            obj[8] = new SqlParameter("CQ_Level", Updated.Level);
            obj[9] = new SqlParameter("CQ_RowId", Updated.RowId);
            obj[10] = new SqlParameter("CQ_NgayTao", Updated.NgayTao);
            obj[11] = new SqlParameter("CQ_NgayCapNhat", Updated.NgayCapNhat);
            obj[12] = new SqlParameter("CQ_NguoiTao", Updated.NguoiTao);
            obj[13] = new SqlParameter("CQ_Active", Updated.Active);
            obj[14] = new SqlParameter("CQ_NguoiCapNhat", Updated.NguoiCapNhat);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static CoQuanCollection SelectAll()
        {
            CoQuanCollection List = new CoQuanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<CoQuan> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<CoQuan> pg = new Pager<CoQuan>("sp_tblCoQuan_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static CoQuan getFromReader(IDataReader rd)
        {
            CoQuan Item = new CoQuan();
            if (rd.FieldExists("CQ_ID"))
            {
                Item.ID = (Int32)(rd["CQ_ID"]);
            }
            if (rd.FieldExists("CQ_PID"))
            {
                Item.PID = (Int32)(rd["CQ_PID"]);
            }
            if (rd.FieldExists("CQ_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["CQ_ThuTu"]);
            }
            if (rd.FieldExists("CQ_Loai"))
            {
                Item.Loai = (Int32)(rd["CQ_Loai"]);
            }
            if (rd.FieldExists("CQ_Ten"))
            {
                Item.Ten = (String)(rd["CQ_Ten"]);
            }
            if (rd.FieldExists("CQ_Ma"))
            {
                Item.Ma = (String)(rd["CQ_Ma"]);
            }
            if (rd.FieldExists("CQ_MoTa"))
            {
                Item.MoTa = (String)(rd["CQ_MoTa"]);
            }
            if (rd.FieldExists("CQ_PIDList"))
            {
                Item.PIDList = (String)(rd["CQ_PIDList"]);
            }
            if (rd.FieldExists("CQ_Level"))
            {
                Item.Level = (Int32)(rd["CQ_Level"]);
            }
            if (rd.FieldExists("CQ_RowId"))
            {
                Item.RowId = (Guid)(rd["CQ_RowId"]);
            }
            if (rd.FieldExists("CQ_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["CQ_NgayTao"]);
            }
            if (rd.FieldExists("CQ_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["CQ_NgayCapNhat"]);
            }
            if (rd.FieldExists("CQ_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["CQ_NguoiTao"]);
            }
            if (rd.FieldExists("CQ_Active"))
            {
                Item.Active = (Boolean)(rd["CQ_Active"]);
            }
            if (rd.FieldExists("CQ_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["CQ_NguoiCapNhat"]);
            }
            if (rd.FieldExists("NSD"))
            {
                Item.NSD = Convert.ToInt32(rd["NSD"]);
            }
            return Item;
        }
        public static CoQuan getFromReaderCQCon(IDataReader rd)
        {
            CoQuan Item = new CoQuan();
            if (rd.FieldExists("CQ_ID"))
            {
                Item.ID = (Int32)(rd["CQ_ID"]);
            }
            if (rd.FieldExists("CQ_PID"))
            {
                Item.PID = (Int32)(rd["CQ_PID"]);
            }
            if (rd.FieldExists("CQ_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["CQ_ThuTu"]);
            }
            if (rd.FieldExists("CQ_Loai"))
            {
                Item.Loai = (Int32)(rd["CQ_Loai"]);
            }
            if (rd.FieldExists("CQ_Ten"))
            {
                Item.Ten = (String)(rd["CQ_Ten"]);
            }
            if (rd.FieldExists("CQ_Ma"))
            {
                Item.Ma = (String)(rd["CQ_Ma"]);
            }
            if (rd.FieldExists("CQ_MoTa"))
            {
                Item.MoTa = (String)(rd["CQ_MoTa"]);
            }
            if (rd.FieldExists("CQ_PIDList"))
            {
                Item.PIDList = (String)(rd["CQ_PIDList"]);
            }
            if (rd.FieldExists("CQ_Level"))
            {
                Item.Level = (Int32)(rd["CQ_Level"]);
            }
            if (rd.FieldExists("CQ_RowId"))
            {
                Item.RowId = (Guid)(rd["CQ_RowId"]);
            }
            if (rd.FieldExists("CQ_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["CQ_NgayTao"]);
            }
            if (rd.FieldExists("CQ_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["CQ_NgayCapNhat"]);
            }
            if (rd.FieldExists("CQ_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["CQ_NguoiTao"]);
            }
            if (rd.FieldExists("CQ_Active"))
            {
                Item.Active = (Boolean)(rd["CQ_Active"]);
            }
            if (rd.FieldExists("CQ_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["CQ_NguoiCapNhat"]);
            }
            if (rd.FieldExists("NSD"))
            {
                Item.NSD = Convert.ToInt32(rd["NSD"]);
            }
            return Item;
        }
        public static CoQuan getFromReaderNSD(IDataReader rd)
        {
            CoQuan Item = new CoQuan();
            if (rd.FieldExists("CQ_ID"))
            {
                Item.ID = (Int32)(rd["CQ_ID"]);
            }
            if (rd.FieldExists("CQ_PID"))
            {
                Item.PID = (Int32)(rd["CQ_PID"]);
            }
            if (rd.FieldExists("CQ_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["CQ_ThuTu"]);
            }
            if (rd.FieldExists("CQ_Loai"))
            {
                Item.Loai = (Int32)(rd["CQ_Loai"]);
            }
            if (rd.FieldExists("CQ_Ten"))
            {
                Item.Ten = (String)(rd["CQ_Ten"]);
            }
            if (rd.FieldExists("CQ_Ma"))
            {
                Item.Ma = (String)(rd["CQ_Ma"]);
            }
            if (rd.FieldExists("CQ_MoTa"))
            {
                Item.MoTa = (String)(rd["CQ_MoTa"]);
            }
            if (rd.FieldExists("CQ_PIDList"))
            {
                Item.PIDList = (String)(rd["CQ_PIDList"]);
            }
            if (rd.FieldExists("CQ_Level"))
            {
                Item.Level = (Int32)(rd["CQ_Level"]);
            }
            if (rd.FieldExists("CQ_RowId"))
            {
                Item.RowId = (Guid)(rd["CQ_RowId"]);
            }
            if (rd.FieldExists("CQ_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["CQ_NgayTao"]);
            }
            if (rd.FieldExists("CQ_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["CQ_NgayCapNhat"]);
            }
            if (rd.FieldExists("CQ_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["CQ_NguoiTao"]);
            }
            if (rd.FieldExists("CQ_Active"))
            {
                Item.Active = (Boolean)(rd["CQ_Active"]);
            }
            if (rd.FieldExists("CQ_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["CQ_NguoiCapNhat"]);
            }
            if (rd.FieldExists("NSD"))
            {
                Item.NSD = Convert.ToInt32(rd["NSD"]);
            }
            return Item;
        }
        #endregion        
        #region Expand
        public static CoQuanCollection SelectByNodeAndWfId(string Username, string q, string TOP)
        {
            CoQuanCollection List = new CoQuanCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("q", q);
            obj[2] = new SqlParameter("TOP", TOP);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuan_Select_SelectByNodeAndWfId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderAuto(rd));
                }
            }
            return List;
        }
        public static CoQuan getFromReaderAuto(IDataReader rd)
        {
            CoQuan Item = new CoQuan();
            Item.ID = (Int32)(rd["CQ_ID"]);
            Item.Ten = (String)(rd["CQ_Ten"]);
            Item.RowId = (Guid)(rd["CQ_RowId"]);
            return Item;
        }
        public static CoQuan SelectById(Int32 CQ_ID)
        {
            CoQuan Item = new CoQuan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_ID", CQ_ID);
            CoQuan _Item = new CoQuan();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    _Item.Ten = rd["P_CQ_Ten"].ToString();
                }
            }
            Item._Parent = _Item;
            return Item;
        }
        public static CoQuan SelectByUsername(string Username)
        {
            CoQuan Item = new CoQuan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuan_Select_SelectByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static CoQuanCollection TreeByUsername(string Username, string q)
        {
            CoQuanCollection List = new CoQuanCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuan_Select_TreeByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderNSD(rd));
                }
            }
            return List;
        }
        public static CoQuanCollection CoQuanConByUsername(string Username)
        {
            CoQuanCollection List = new CoQuanCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCoQuan_Select_CoQuanConByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderCQCon(rd));
                }
            }
            return List;
        }
        public static CoQuan Insert(SqlTransaction tran, string Ten,String Username)
        {
            CoQuan Item = new CoQuan();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("CQ_PID", 1);
            obj[1] = new SqlParameter("CQ_ThuTu", 0);
            obj[2] = new SqlParameter("CQ_Loai", 0);
            obj[3] = new SqlParameter("CQ_Ten", Ten);
            obj[4] = new SqlParameter("CQ_Ma", string.Empty);
            obj[5] = new SqlParameter("CQ_MoTa", string.Empty);
            obj[6] = new SqlParameter("CQ_PIDList", string.Empty);
            obj[7] = new SqlParameter("CQ_Level", 0);
            obj[8] = new SqlParameter("CQ_RowId", Guid.NewGuid());
            obj[9] = new SqlParameter("CQ_NgayTao", DateTime.Now);
            obj[10] = new SqlParameter("CQ_NgayCapNhat", DateTime.Now);
            obj[11] = new SqlParameter("CQ_NguoiTao", Username);
            obj[12] = new SqlParameter("CQ_Active", true);
            obj[13] = new SqlParameter("CQ_NguoiCapNhat", Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblCoQuan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static CoQuan Insert(SqlTransaction tran, int Pid, string Ten, String Username)
        {
            CoQuan Item = new CoQuan();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("CQ_PID", Pid);
            obj[1] = new SqlParameter("CQ_ThuTu", 0);
            obj[2] = new SqlParameter("CQ_Loai", 0);
            obj[3] = new SqlParameter("CQ_Ten", Ten);
            obj[4] = new SqlParameter("CQ_Ma", string.Empty);
            obj[5] = new SqlParameter("CQ_MoTa", string.Empty);
            obj[6] = new SqlParameter("CQ_PIDList", string.Empty);
            obj[7] = new SqlParameter("CQ_Level", 0);
            obj[8] = new SqlParameter("CQ_RowId", Guid.NewGuid());
            obj[9] = new SqlParameter("CQ_NgayTao", DateTime.Now);
            obj[10] = new SqlParameter("CQ_NgayCapNhat", DateTime.Now);
            obj[11] = new SqlParameter("CQ_NguoiTao", Username);
            obj[12] = new SqlParameter("CQ_Active", true);
            obj[13] = new SqlParameter("CQ_NguoiCapNhat", Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblCoQuan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static CoQuan Insert(SqlTransaction tran, int Pid, string Ten, String Username, bool active)
        {
            CoQuan Item = new CoQuan();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("CQ_PID", Pid);
            obj[1] = new SqlParameter("CQ_ThuTu", 0);
            obj[2] = new SqlParameter("CQ_Loai", 0);
            obj[3] = new SqlParameter("CQ_Ten", Ten);
            obj[4] = new SqlParameter("CQ_Ma", string.Empty);
            obj[5] = new SqlParameter("CQ_MoTa", string.Empty);
            obj[6] = new SqlParameter("CQ_PIDList", string.Empty);
            obj[7] = new SqlParameter("CQ_Level", 0);
            obj[8] = new SqlParameter("CQ_RowId", Guid.NewGuid());
            obj[9] = new SqlParameter("CQ_NgayTao", DateTime.Now);
            obj[10] = new SqlParameter("CQ_NgayCapNhat", DateTime.Now);
            obj[11] = new SqlParameter("CQ_NguoiTao", Username);
            obj[12] = new SqlParameter("CQ_Active", active);
            obj[13] = new SqlParameter("CQ_NguoiCapNhat", Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblCoQuan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static CoQuan SelectByMa(SqlTransaction tran, string CQ_Ma)
        {
            CoQuan Item = new CoQuan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CQ_Ma", CQ_Ma);
            CoQuan _Item = new CoQuan();
            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblCoQuan_Select_SelectByMa_linhnx", obj))
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


