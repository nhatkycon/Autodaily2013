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
    #region NodeButton
    #region BO
    public class NodeButton : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 NODE_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String Ma { get; set; }
        public Int32 ThuTu { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public NodeButton()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return NodeButtonDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class NodeButtonCollection : BaseEntityCollection<NodeButton>
    { }
    #endregion
    #region Dal
    public class NodeButtonDal
    {
        #region Methods

        public static void DeleteById(Int32 NB_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NB_ID", NB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeButton_Delete_DeleteById_linhnx", obj);
        }

        public static NodeButton Insert(NodeButton Inserted)
        {
            NodeButton Item = new NodeButton();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("NB_NODE_ID", Inserted.NODE_ID);
            obj[1] = new SqlParameter("NB_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("NB_MoTa", Inserted.MoTa);
            obj[3] = new SqlParameter("NB_Ma", Inserted.Ma);
            obj[4] = new SqlParameter("NB_ThuTu", Inserted.ThuTu);
            obj[5] = new SqlParameter("NB_NgayTao", Inserted.NgayTao);
            obj[6] = new SqlParameter("NB_NguoiTao", Inserted.NguoiTao);
            obj[7] = new SqlParameter("NB_NgayCapNhat", Inserted.NgayCapNhat);
            obj[8] = new SqlParameter("NB_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeButton_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeButton Update(NodeButton Updated)
        {
            NodeButton Item = new NodeButton();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("NB_ID", Updated.ID);
            obj[1] = new SqlParameter("NB_NODE_ID", Updated.NODE_ID);
            obj[2] = new SqlParameter("NB_Ten", Updated.Ten);
            obj[3] = new SqlParameter("NB_MoTa", Updated.MoTa);
            obj[4] = new SqlParameter("NB_Ma", Updated.Ma);
            obj[5] = new SqlParameter("NB_ThuTu", Updated.ThuTu);
            obj[6] = new SqlParameter("NB_NgayTao", Updated.NgayTao);
            obj[7] = new SqlParameter("NB_NguoiTao", Updated.NguoiTao);
            obj[8] = new SqlParameter("NB_NgayCapNhat", Updated.NgayCapNhat);
            obj[9] = new SqlParameter("NB_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeButton_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeButton SelectById(Int32 NB_ID)
        {
            NodeButton Item = new NodeButton();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NB_ID", NB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeButton_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodeButtonCollection SelectAll()
        {
            NodeButtonCollection List = new NodeButtonCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeButton_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static NodeButtonCollection SelectByNode(Int32 NODE_ID)
        {
            NodeButtonCollection List = new NodeButtonCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NODE_ID", NODE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodeButton_Select_SelectByNode_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<NodeButton> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<NodeButton> pg = new Pager<NodeButton>("sp_tblNodeButton_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static NodeButton getFromReader(IDataReader rd)
        {
            NodeButton Item = new NodeButton();
            Item.ID = (Int32)(rd["NB_ID"]);
            Item.NODE_ID = (Int32)(rd["NB_NODE_ID"]);
            Item.Ten = (String)(rd["NB_Ten"]);
            Item.MoTa = (String)(rd["NB_MoTa"]);
            Item.Ma = (String)(rd["NB_Ma"]);
            Item.ThuTu = (Int32)(rd["NB_ThuTu"]);
            Item.NgayTao = (DateTime)(rd["NB_NgayTao"]);
            Item.NguoiTao = (String)(rd["NB_NguoiTao"]);
            Item.NgayCapNhat = (DateTime)(rd["NB_NgayCapNhat"]);
            Item.RowId = (Guid)(rd["NB_RowId"]);
            return Item;
        }
        #endregion
        #region Extend
        #endregion
    }
    #endregion

    #endregion
    
}


