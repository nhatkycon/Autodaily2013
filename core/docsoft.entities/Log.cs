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
    #region Log
    #region BO
    public class Log : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int16 LLOG_ID { get; set; }
        public String Ten { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public String RequestIp { get; set; }
        public XmlDocument GiaTriCu { get; set; }
        public XmlDocument GiaTriMoi { get; set; }
        public String RawUrl { get; set; }
        public String Info { get; set; }
        public Boolean Checked { get; set; }
        #endregion
        #region Contructor
        public Log()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LogDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LogCollection : BaseEntityCollection<Log>
    { }
    #endregion
    #region Dal
    public class LogDal
    {
        #region Methods

        public static void DeleteById(Int32 LOG_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LOG_ID", LOG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLog_Delete_DeleteById_linhnx", obj);
        }

        public static Log Insert(Log Inserted)
        {
            Log Item = new Log();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("LOG_LLOG_ID", Inserted.LLOG_ID);
            obj[1] = new SqlParameter("LOG_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("LOG_Username", Inserted.Username);
            obj[3] = new SqlParameter("LOG_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("LOG_RequestIp", Inserted.RequestIp);
            obj[5] = new SqlParameter("LOG_GiaTriCu", Inserted.GiaTriCu);
            obj[6] = new SqlParameter("LOG_GiaTriMoi", Inserted.GiaTriMoi);
            obj[7] = new SqlParameter("LOG_RawUrl", Inserted.RawUrl);
            obj[8] = new SqlParameter("LOG_Info", Inserted.Info);
            obj[9] = new SqlParameter("LOG_Checked", Inserted.Checked);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLog_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Log Update(Log Updated)
        {
            Log Item = new Log();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("LOG_ID", Updated.ID);
            obj[1] = new SqlParameter("LOG_LLOG_ID", Updated.LLOG_ID);
            obj[2] = new SqlParameter("LOG_Ten", Updated.Ten);
            obj[3] = new SqlParameter("LOG_Username", Updated.Username);
            obj[4] = new SqlParameter("LOG_NgayTao", Updated.NgayTao);
            obj[5] = new SqlParameter("LOG_RequestIp", Updated.RequestIp);
            obj[6] = new SqlParameter("LOG_GiaTriCu", Updated.GiaTriCu);
            obj[7] = new SqlParameter("LOG_GiaTriMoi", Updated.GiaTriMoi);
            obj[8] = new SqlParameter("LOG_RawUrl", Updated.RawUrl);
            obj[9] = new SqlParameter("LOG_Info", Updated.Info);
            obj[10] = new SqlParameter("LOG_Checked", Updated.Checked);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLog_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Log SelectById(Int32 LOG_ID)
        {
            Log Item = new Log();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LOG_ID", LOG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLog_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LogCollection SelectAll()
        {
            LogCollection List = new LogCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLog_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Log> pagerNormal(string url, bool rewrite, string sort,string _username,string _IP ,string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[2];
            //if (string.IsNullOrEmpty(sort))
            //{
            //    obj[0] = new SqlParameter("Sort", DBNull.Value);
            //}
            //else
            //{
            //    obj[0] = new SqlParameter("Sort", sort);
            //}
            if (string.IsNullOrEmpty(_username))
            {
                obj[0] = new SqlParameter("UserName", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("UserName", _username);
            }
            if (string.IsNullOrEmpty(sort))
            {
                obj[1] = new SqlParameter("IP", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("IP", _IP);
            }
            if (string.IsNullOrEmpty(pagesize)) pagesize = "50";
            Pager<Log> pg = new Pager<Log>("sp_tblLog_Pager_Normal_linhnx", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Log getFromReader(IDataReader rd)
        {
            Log Item = new Log();
            if (rd.FieldExists("LOG_ID"))
            {
                Item.ID = (Int32)(rd["LOG_ID"]);
            }
            if (rd.FieldExists("LOG_LLOG_ID"))
            {
                Item.LLOG_ID = (Int16)(rd["LOG_LLOG_ID"]);
            }
            if (rd.FieldExists("LOG_Ten"))
            {
                Item.Ten = (String)(rd["LOG_Ten"]);
            }
            if (rd.FieldExists("LOG_Username"))
            {
                Item.Username = (String)(rd["LOG_Username"]);
            }
            if (rd.FieldExists("LOG_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LOG_NgayTao"]);
            }
            if (rd.FieldExists("LOG_RequestIp"))
            {
                Item.RequestIp = (String)(rd["LOG_RequestIp"]);
            }
            if (rd.FieldExists("LOG_GiaTriCu"))
            {
                Item.GiaTriCu = (XmlDocument)(rd["LOG_GiaTriCu"]);
            }
            if (rd.FieldExists("LOG_GiaTriMoi"))
            {
                Item.GiaTriMoi = (XmlDocument)(rd["LOG_GiaTriMoi"]);
            }
            if (rd.FieldExists("LOG_RawUrl"))
            {
                Item.RawUrl = (String)(rd["LOG_RawUrl"]);
            }
            if (rd.FieldExists("LOG_Info"))
            {
                Item.Info = (String)(rd["LOG_Info"]);
            }
            if (rd.FieldExists("LOG_Checked"))
            {
                Item.Checked = (Boolean)(rd["LOG_Checked"]);
            }
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
    
}


