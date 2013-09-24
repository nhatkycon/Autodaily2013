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
    #region systemMessage
    #region BO
    public class systemMessage : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ten { get; set; }
        public String NoiDung { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Active { get; set; }
        public Boolean ThanhVienMoi { get; set; }
        public Boolean HeThong { get; set; }
        public String Url { get; set; }
        public Int32 Loai { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public systemMessage()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return systemMessageDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class systemMessageCollection : BaseEntityCollection<systemMessage>
    { }
    #endregion
    #region Dal
    public class systemMessageDal
    {
        #region Methods

        public static void DeleteById(Guid SM_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SM_ID", SM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessage_Delete_DeleteById_linhnx", obj);
        }

        public static systemMessage Insert(systemMessage item)
        {
            var Item = new systemMessage();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("SM_ID", item.ID);
            obj[1] = new SqlParameter("SM_Ten", item.Ten);
            obj[2] = new SqlParameter("SM_NoiDung", item.NoiDung);
            obj[3] = new SqlParameter("SM_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("SM_Active", item.Active);
            obj[5] = new SqlParameter("SM_ThanhVienMoi", item.ThanhVienMoi);
            obj[6] = new SqlParameter("SM_HeThong", item.HeThong);
            obj[7] = new SqlParameter("SM_Url", item.Url);
            obj[8] = new SqlParameter("SM_Loai", item.Loai);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("SM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("SM_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessage_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static systemMessage Update(systemMessage item)
        {
            var Item = new systemMessage();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("SM_ID", item.ID);
            obj[1] = new SqlParameter("SM_Ten", item.Ten);
            obj[2] = new SqlParameter("SM_NoiDung", item.NoiDung);
            obj[3] = new SqlParameter("SM_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("SM_Active", item.Active);
            obj[5] = new SqlParameter("SM_ThanhVienMoi", item.ThanhVienMoi);
            obj[6] = new SqlParameter("SM_HeThong", item.HeThong);
            obj[7] = new SqlParameter("SM_Url", item.Url);
            obj[8] = new SqlParameter("SM_Loai", item.Loai);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("SM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("SM_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessage_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static systemMessage SelectById(Guid SM_ID)
        {
            var Item = new systemMessage();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SM_ID", SM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessage_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static systemMessageCollection SelectAll()
        {
            var List = new systemMessageCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessage_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<systemMessage> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<systemMessage>("sp_tblsystemMessage_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static systemMessage getFromReader(IDataReader rd)
        {
            var Item = new systemMessage();
            if (rd.FieldExists("SM_ID"))
            {
                Item.ID = (Guid)(rd["SM_ID"]);
            }
            if (rd.FieldExists("SM_Ten"))
            {
                Item.Ten = (String)(rd["SM_Ten"]);
            }
            if (rd.FieldExists("SM_NoiDung"))
            {
                Item.NoiDung = (String)(rd["SM_NoiDung"]);
            }
            if (rd.FieldExists("SM_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["SM_ThuTu"]);
            }
            if (rd.FieldExists("SM_Active"))
            {
                Item.Active = (Boolean)(rd["SM_Active"]);
            }
            if (rd.FieldExists("SM_ThanhVienMoi"))
            {
                Item.ThanhVienMoi = (Boolean)(rd["SM_ThanhVienMoi"]);
            }
            if (rd.FieldExists("SM_HeThong"))
            {
                Item.HeThong = (Boolean)(rd["SM_HeThong"]);
            }
            if (rd.FieldExists("SM_Url"))
            {
                Item.Url = (String)(rd["SM_Url"]);
            }
            if (rd.FieldExists("SM_Loai"))
            {
                Item.Loai = (Int32)(rd["SM_Loai"]);
            }
            if (rd.FieldExists("SM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["SM_NgayTao"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion

    #region systemMessageUser
    #region BO
    public class systemMessageUser : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid SM_ID { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Doc { get; set; }
        public DateTime NgayDoc { get; set; }
        #endregion
        #region Contructor
        public systemMessageUser()
        { }
        #endregion
        #region Customs properties

        public systemMessage _SystemMessage { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return systemMessageUserDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class systemMessageUserCollection : BaseEntityCollection<systemMessageUser>
    { }
    #endregion
    #region Dal
    public class systemMessageUserDal
    {
        #region Methods

        public static void DeleteById(Guid SMU_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SMU_ID", SMU_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessageUser_Delete_DeleteById_linhnx", obj);
        }

        public static systemMessageUser Insert(systemMessageUser item)
        {
            var Item = new systemMessageUser();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("SMU_ID", item.ID);
            obj[1] = new SqlParameter("SMU_SM_ID", item.SM_ID);
            obj[2] = new SqlParameter("SMU_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("SMU_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("SMU_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("SMU_Doc", item.Doc);
            if (item.NgayDoc > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("SMU_NgayDoc", item.NgayDoc);
            }
            else
            {
                obj[5] = new SqlParameter("SMU_NgayDoc", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessageUser_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static systemMessageUser Update(systemMessageUser item)
        {
            var Item = new systemMessageUser();
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("SMU_ID", item.ID);
            obj[1] = new SqlParameter("SMU_SM_ID", item.SM_ID);
            obj[2] = new SqlParameter("SMU_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("SMU_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("SMU_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("SMU_Doc", item.Doc);
            if (item.NgayDoc > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("SMU_NgayDoc", item.NgayDoc);
            }
            else
            {
                obj[5] = new SqlParameter("SMU_NgayDoc", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessageUser_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static systemMessageUser SelectById(Guid SMU_ID)
        {
            var Item = new systemMessageUser();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SMU_ID", SMU_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessageUser_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static systemMessageUserCollection SelectAll()
        {
            var List = new systemMessageUserCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblsystemMessageUser_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<systemMessageUser> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<systemMessageUser>("sp_tblsystemMessageUser_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static systemMessageUser getFromReader(IDataReader rd)
        {
            var Item = new systemMessageUser();
            if (rd.FieldExists("SMU_ID"))
            {
                Item.ID = (Guid)(rd["SMU_ID"]);
            }
            if (rd.FieldExists("SMU_SM_ID"))
            {
                Item.SM_ID = (Guid)(rd["SMU_SM_ID"]);
            }
            if (rd.FieldExists("SMU_Username"))
            {
                Item.Username = (String)(rd["SMU_Username"]);
            }
            if (rd.FieldExists("SMU_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["SMU_NgayTao"]);
            }
            if (rd.FieldExists("SMU_Doc"))
            {
                Item.Doc = (Boolean)(rd["SMU_Doc"]);
            }
            if (rd.FieldExists("SMU_NgayDoc"))
            {
                Item.NgayDoc = (DateTime)(rd["SMU_NgayDoc"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion
}


