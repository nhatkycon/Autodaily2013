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
    #region NodeChiTiet
    #region BO
    public class NodeChiTiet : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 VBNODE_ID { get; set; }
        public Guid CID { get; set; }
        public Boolean Chinh { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayGiaoviec { get; set; }
        public DateTime NgayHoanThanh { get; set; }
        public Guid RowId { get; set; }
        public Boolean MucDo { get; set; }
        public String GhiChu { get; set; }
        #endregion
        #region Contructor
        public NodeChiTiet()
        { }
        #endregion
        #region Customs properties
        public String GiaoViec { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return NodeChiTietDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class NodeChiTietCollection : BaseEntityCollection<NodeChiTiet>
    { }
    #endregion
    #region Dal
    public class NodeChiTietDal
    {
        #region Methods

        public static void DeleteById(Int32 NCT_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NCT_ID", NCT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeChiTiet_Delete_DeleteById_linhnx", obj);
        }

        public static NodeChiTiet Insert(NodeChiTiet Inserted)
        {
            NodeChiTiet Item = new NodeChiTiet();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("NCT_VBNODE_ID", Inserted.VBNODE_ID);
            obj[1] = new SqlParameter("NCT_CID", Inserted.CID);
            obj[2] = new SqlParameter("NCT_Chinh", Inserted.Chinh);
            obj[3] = new SqlParameter("NCT_NoiDung", Inserted.NoiDung);
            obj[4] = new SqlParameter("NCT_NgayTao", Inserted.NgayTao);
            obj[5] = new SqlParameter("NCT_NgayCapNhat", Inserted.NgayCapNhat);
            obj[6] = new SqlParameter("NCT_NguoiTao", Inserted.NguoiTao);
            obj[7] = new SqlParameter("NCT_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeChiTiet_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeChiTiet Update(NodeChiTiet Updated)
        {
            NodeChiTiet Item = new NodeChiTiet();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("NCT_ID", Updated.ID);
            obj[1] = new SqlParameter("NCT_VBNODE_ID", Updated.VBNODE_ID);
            obj[2] = new SqlParameter("NCT_CID", Updated.CID);
            obj[3] = new SqlParameter("NCT_Chinh", Updated.Chinh);
            obj[4] = new SqlParameter("NCT_NoiDung", Updated.NoiDung);
            obj[5] = new SqlParameter("NCT_NgayTao", Updated.NgayTao);
            obj[6] = new SqlParameter("NCT_NgayCapNhat", Updated.NgayCapNhat);
            obj[7] = new SqlParameter("NCT_NguoiTao", Updated.NguoiTao);
            obj[8] = new SqlParameter("NCT_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeChiTiet_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeChiTiet SelectById(Int32 NCT_ID)
        {
            NodeChiTiet Item = new NodeChiTiet();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NCT_ID", NCT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeChiTiet_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static NodeChiTiet SelectByNodeIDUsername(Int32 VBNODE_ID,string Username)
        {
            NodeChiTiet Item = new NodeChiTiet();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("VBNODE_ID", VBNODE_ID);
            obj[1] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeChiTiet_Select_SelectByNodeIDUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static NodeChiTietCollection SelectAll()
        {
            NodeChiTietCollection List = new NodeChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeChiTiet_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<NodeChiTiet> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<NodeChiTiet> pg = new Pager<NodeChiTiet>("sp_tblNodeChiTiet_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static NodeChiTiet SelectByVBNode_IDWidthCID(Int32 VBNODE_ID, string Cid)
        {
            NodeChiTiet Item = new NodeChiTiet();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("VBNODE_ID", VBNODE_ID);
            obj[1] = new SqlParameter("Cid", Cid);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeChiTiet_Select_SelectByVBNodeIDWithCid_hungpm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    if (rd.FieldExists("NCT_GiaoViec"))
                    { 
                        Item.GiaoViec = (String)rd["NCT_GiaoViec"]; 
                    }
                }
            }
            return Item;
        }
        #endregion

        #region Utilities
        public static NodeChiTiet getFromReader(IDataReader rd)
        {
            NodeChiTiet Item = new NodeChiTiet();
            if (rd.FieldExists("NCT_ID"))
            {
                Item.ID = (Int32)(rd["NCT_ID"]);
            }
            if (rd.FieldExists("NCT_VBNODE_ID"))
            {
                Item.VBNODE_ID = (Int32)(rd["NCT_VBNODE_ID"]);
            }
            if (rd.FieldExists("NCT_CID"))
            {
                Item.CID = (Guid)(rd["NCT_CID"]);
            }
            if (rd.FieldExists("NCT_Chinh"))
            {
                Item.Chinh = (Boolean)(rd["NCT_Chinh"]);
            }
            if (rd.FieldExists("NCT_NoiDung"))
            {
                Item.NoiDung = (String)(rd["NCT_NoiDung"]);
            }
            if (rd.FieldExists("NCT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["NCT_NgayTao"]);
            }
            if (rd.FieldExists("NCT_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["NCT_NgayCapNhat"]);
            }
            if (rd.FieldExists("NCT_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["NCT_NguoiTao"]);
            }
            if (rd.FieldExists("NCT_RowId"))
            {
                Item.RowId = (Guid)(rd["NCT_RowId"]);
            }
            if (rd.FieldExists("NCT_NgayGiaoViec"))
            {
                Item.NgayGiaoviec = (DateTime)(rd["NCT_NgayGiaoViec"]);
            }
            if (rd.FieldExists("NCT_NgayHoanThanh"))
            {
                Item.NgayHoanThanh = (DateTime)(rd["NCT_NgayHoanThanh"]);
            }
            if (rd.FieldExists("NCT_MucDo"))
            {
                Item.MucDo = (Boolean)(rd["NCT_MucDo"]);
            }
            if (rd.FieldExists("NCT_GhiChu"))
            {
                Item.GhiChu = (String)(rd["NCT_GhiChu"]);
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


