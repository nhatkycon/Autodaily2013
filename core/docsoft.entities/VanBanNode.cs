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
    #region VanbanNode
    #region BO
    public class VanbanNode : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 VB_ID { get; set; }
        public Int32 NODE_ID { get; set; }
        public Boolean Active { get; set; }
        public Boolean KetThuc { get; set; }
        public Boolean BatDau { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        public Boolean ThongBao { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Doc { get; set; }
        public Boolean XuLy { get; set; }
        #endregion
        #region Contructor
        public VanbanNode()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return VanbanNodeDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class VanbanNodeCollection : BaseEntityCollection<VanbanNode>
    { }
    #endregion
    #region Dal
    public class VanbanNodeDal
    {
        #region Methods

        public static void DeleteById(Int32 VBNODE_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBNODE_ID", VBNODE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanbanNode_Delete_DeleteById_linhnx", obj);
        }

        public static VanbanNode Insert(VanbanNode Inserted)
        {
            VanbanNode Item = new VanbanNode();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("VBNODE_VB_ID", Inserted.VB_ID);
            obj[1] = new SqlParameter("VBNODE_NODE_ID", Inserted.NODE_ID);
            obj[2] = new SqlParameter("VBNODE_Active", Inserted.Active);
            obj[3] = new SqlParameter("VBNODE_KetThuc", Inserted.KetThuc);
            obj[4] = new SqlParameter("VBNODE_BatDau", Inserted.BatDau);
            obj[5] = new SqlParameter("VBNODE_NguoiTao", Inserted.NguoiTao);
            obj[6] = new SqlParameter("VBNODE_NgayTao", Inserted.NgayTao);
            obj[7] = new SqlParameter("VBNODE_NgayCapNhat", Inserted.NgayCapNhat);
            obj[8] = new SqlParameter("VBNODE_RowId", Inserted.RowId);
            obj[9] = new SqlParameter("VBNODE_ThongBao", Inserted.ThongBao);
            obj[10] = new SqlParameter("VBNODE_ThuTu", Inserted.ThuTu);
            obj[11] = new SqlParameter("VBNODE_Doc", Inserted.Doc);
            obj[12] = new SqlParameter("VBNODE_XuLy", Inserted.XuLy);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanbanNode_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VanbanNode Update(VanbanNode Updated)
        {
            VanbanNode Item = new VanbanNode();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("VBNODE_ID", Updated.ID);
            obj[1] = new SqlParameter("VBNODE_VB_ID", Updated.VB_ID);
            obj[2] = new SqlParameter("VBNODE_NODE_ID", Updated.NODE_ID);
            obj[3] = new SqlParameter("VBNODE_Active", Updated.Active);
            obj[4] = new SqlParameter("VBNODE_KetThuc", Updated.KetThuc);
            obj[5] = new SqlParameter("VBNODE_BatDau", Updated.BatDau);
            obj[6] = new SqlParameter("VBNODE_NguoiTao", Updated.NguoiTao);
            obj[7] = new SqlParameter("VBNODE_NgayTao", Updated.NgayTao);
            obj[8] = new SqlParameter("VBNODE_NgayCapNhat", Updated.NgayCapNhat);
            obj[9] = new SqlParameter("VBNODE_RowId", Updated.RowId);
            obj[10] = new SqlParameter("VBNODE_ThongBao", Updated.ThongBao);
            obj[11] = new SqlParameter("VBNODE_ThuTu", Updated.ThuTu);
            obj[12] = new SqlParameter("VBNODE_Doc", Updated.Doc);
            obj[13] = new SqlParameter("VBNODE_XuLy", Updated.XuLy);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanbanNode_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        
        public static VanbanNode SelectById(Int32 VBNODE_ID)
        {
            VanbanNode Item = new VanbanNode();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VBNODE_ID", VBNODE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanbanNode_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VanbanNodeCollection SelectAll()
        {
            VanbanNodeCollection List = new VanbanNodeCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanbanNode_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<VanbanNode> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<VanbanNode> pg = new Pager<VanbanNode>("sp_tblVanbanNode_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static VanbanNode getFromReader(IDataReader rd)
        {
            VanbanNode Item = new VanbanNode();
            Item.ID = (Int32)(rd["VBNODE_ID"]);
            Item.VB_ID = (Int32)(rd["VBNODE_VB_ID"]);
            Item.NODE_ID = (Int32)(rd["VBNODE_NODE_ID"]);
            Item.Active = (Boolean)(rd["VBNODE_Active"]);
            Item.KetThuc = (Boolean)(rd["VBNODE_KetThuc"]);
            Item.BatDau = (Boolean)(rd["VBNODE_BatDau"]);
            Item.NguoiTao = (String)(rd["VBNODE_NguoiTao"]);
            Item.NgayTao = (DateTime)(rd["VBNODE_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["VBNODE_NgayCapNhat"]);
            Item.RowId = (Guid)(rd["VBNODE_RowId"]);
            Item.ThongBao = (Boolean)(rd["VBNODE_ThongBao"]);
            Item.ThuTu = (Int32)(rd["VBNODE_ThuTu"]);
            Item.Doc = (Boolean)(rd["VBNODE_Doc"]);
            Item.XuLy = (Boolean)(rd["VBNODE_XuLy"]);
            return Item;
        }
        #endregion
        #region Extend
        public static void UpdateNode(
            string VB_ID,
            string Username,
            string CIDList,
            string NguoiTao,
            string NoiDung,
            Boolean MucDo,
            string GhiChu
            )
        {
            //VanbanNode Item = new VanbanNode();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            obj[1] = new SqlParameter("Username", Username);
            obj[2] = new SqlParameter("CIDList", CIDList);
            obj[3] = new SqlParameter("NguoiTao", NguoiTao);
            obj[4] = new SqlParameter("NoiDung", NoiDung);
            obj[5] = new SqlParameter("MucDo", MucDo);
            obj[6] = new SqlParameter("GhiChu", GhiChu);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanbanNode_Update_UpdateNode_linhnx", obj);
            //using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanbanNode_Update_UpdateNode_linhnx", obj))
            //{
            //    while (rd.Read())
            //    {
            //        Item = getFromReader(rd);
            //    }
            //}
            //return Item;
        }
        #endregion
    }
    #endregion

    #endregion
}


