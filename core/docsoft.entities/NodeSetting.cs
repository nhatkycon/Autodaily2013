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
    #region NodeSetting
    #region BO
    public class NodeSetting : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 NODE_ID { get; set; }
        public Guid CID { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public NodeSetting()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return NodeSettingDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class NodeSettingCollection : BaseEntityCollection<NodeSetting>
    { }
    #endregion
    #region Dal
    public class NodeSettingDal
    {
        #region Methods

        public static void DeleteById(Int32 NS_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NS_ID", NS_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeSetting_Delete_DeleteById_linhnx", obj);
        }

        public static NodeSetting Insert(NodeSetting Inserted)
        {
            NodeSetting Item = new NodeSetting();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("NS_NODE_ID", Inserted.NODE_ID);
            obj[1] = new SqlParameter("NS_CID", Inserted.CID);
            obj[2] = new SqlParameter("NS_NguoiTao", Inserted.NguoiTao);
            obj[3] = new SqlParameter("NS_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("NS_NgayCapNhat", Inserted.NgayCapNhat);
            obj[5] = new SqlParameter("NS_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeSetting_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeSetting Update(NodeSetting Updated)
        {
            NodeSetting Item = new NodeSetting();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("NS_ID", Updated.ID);
            obj[1] = new SqlParameter("NS_NODE_ID", Updated.NODE_ID);
            obj[2] = new SqlParameter("NS_CID", Updated.CID);
            obj[3] = new SqlParameter("NS_NguoiTao", Updated.NguoiTao);
            obj[4] = new SqlParameter("NS_NgayTao", Updated.NgayTao);
            obj[5] = new SqlParameter("NS_NgayCapNhat", Updated.NgayCapNhat);
            obj[6] = new SqlParameter("NS_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeSetting_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static NodeSetting UpdateLoaiNhom(string UpdateList,string NODE_ID,string Username)
        {
            NodeSetting Item = new NodeSetting();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("UpdateList", UpdateList);
            obj[1] = new SqlParameter("NODE_ID", NODE_ID);
            obj[2] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeSetting_Update_UpdateLoaiNhom_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static NodeSetting SelectById(Int32 NS_ID)
        {
            NodeSetting Item = new NodeSetting();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NS_ID", NS_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeSetting_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeSettingCollection SelectAll()
        {
            NodeSettingCollection List = new NodeSettingCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeSetting_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<NodeSetting> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<NodeSetting> pg = new Pager<NodeSetting>("sp_tblNodeSetting_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static NodeSetting getFromReader(IDataReader rd)
        {
            NodeSetting Item = new NodeSetting();
            Item.ID = (Int32)(rd["NS_ID"]);
            Item.NODE_ID = (Int32)(rd["NS_NODE_ID"]);
            Item.CID = (Guid)(rd["NS_CID"]);
            Item.NguoiTao = (String)(rd["NS_NguoiTao"]);
            Item.NgayTao = (DateTime)(rd["NS_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["NS_NgayCapNhat"]);
            Item.RowId = (Guid)(rd["NS_RowId"]);
            return Item;
        }
        #endregion
        #region Extend
        #endregion
    }
    #endregion

    #endregion
}
