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
    #region NodeLog
    #region BO
    public class NodeLog : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 VBNODE_ID { get; set; }
        public Guid CID { get; set; }
        public String ThamGia { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        public String NguoiTao { get; set; }
        #endregion
        #region Contructor
        public NodeLog()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return NodeLogDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class NodeLogCollection : BaseEntityCollection<NodeLog>
    { }
    #endregion
    #region Dal
    public class NodeLogDal
    {
        #region Methods

        public static void DeleteById(Int32 NLOG_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NLOG_ID", NLOG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeLog_Delete_DeleteById_linhnx", obj);
        }

        public static NodeLog Insert(NodeLog Inserted)
        {
            NodeLog Item = new NodeLog();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("NLOG_VBNODE_ID", Inserted.VBNODE_ID);
            obj[1] = new SqlParameter("NLOG_CID", Inserted.CID);
            obj[2] = new SqlParameter("NLOG_ThamGia", Inserted.ThamGia);
            obj[3] = new SqlParameter("NLOG_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("NLOG_NgayCapNhat", Inserted.NgayCapNhat);
            obj[5] = new SqlParameter("NLOG_RowId", Inserted.RowId);
            obj[6] = new SqlParameter("NLOG_NguoiTao", Inserted.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeLog_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeLog Update(NodeLog Updated)
        {
            NodeLog Item = new NodeLog();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("NLOG_ID", Updated.ID);
            obj[1] = new SqlParameter("NLOG_VBNODE_ID", Updated.VBNODE_ID);
            obj[2] = new SqlParameter("NLOG_CID", Updated.CID);
            obj[3] = new SqlParameter("NLOG_ThamGia", Updated.ThamGia);
            obj[4] = new SqlParameter("NLOG_NgayTao", Updated.NgayTao);
            obj[5] = new SqlParameter("NLOG_NgayCapNhat", Updated.NgayCapNhat);
            obj[6] = new SqlParameter("NLOG_RowId", Updated.RowId);
            obj[7] = new SqlParameter("NLOG_NguoiTao", Updated.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeLog_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeLog SelectById(Int32 NLOG_ID)
        {
            NodeLog Item = new NodeLog();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NLOG_ID", NLOG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeLog_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeLogCollection SelectAll()
        {
            NodeLogCollection List = new NodeLogCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeLog_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<NodeLog> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<NodeLog> pg = new Pager<NodeLog>("sp_tblNodeLog_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static NodeLog getFromReader(IDataReader rd)
        {
            NodeLog Item = new NodeLog();
            Item.ID = (Int32)(rd["NLOG_ID"]);
            Item.VBNODE_ID = (Int32)(rd["NLOG_VBNODE_ID"]);
            Item.CID = (Guid)(rd["NLOG_CID"]);
            Item.ThamGia = (String)(rd["NLOG_ThamGia"]);
            Item.NgayTao = (DateTime)(rd["NLOG_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["NLOG_NgayCapNhat"]);
            Item.RowId = (Guid)(rd["NLOG_RowId"]);
            Item.NguoiTao = (String)(rd["NLOG_NguoiTao"]);
            return Item;
        }
        #endregion
        #region Extend
        #endregion
    }
    #endregion

    #endregion    
}


