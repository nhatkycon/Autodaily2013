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
    #region Nodes
    #region BO
    public class Nodes : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 WF_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public Boolean KetThuc { get; set; }
        public Boolean BatDau { get; set; }
        public Int32 ThuTu { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public Guid RowId { get; set; }
        public Boolean AddMember { get; set; }
        public Boolean AddCoQuan { get; set; }
        public Boolean ChuyenTiep { get; set; }
        public Boolean ChuyenNguoc { get; set; }
        public Boolean AddAllMember { get; set; }
        #endregion
        #region Contructor
        public Nodes()
        { }
        #endregion
        #region Customs properties
        public List<NodeButton> buttons { get; set; }
        public List<NodeChiTiet> chitiets { get; set; }
        public List<NodeSetting> settings { get; set; }
        public VanbanNode vanBanNode { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return NodesDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class NodesCollection : BaseEntityCollection<Nodes>
    { }
    #endregion
    #region Dal
    public class NodesDal
    {
        #region Methods

        public static void DeleteById(Int32 NODE_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NODE_ID", NODE_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblNodes_Delete_DeleteById_linhnx", obj);
        }

        public static Nodes Insert(Nodes Inserted)
        {
            Nodes Item = new Nodes();
            SqlParameter[] obj = new SqlParameter[15];
            obj[0] = new SqlParameter("NODE_WF_ID", Inserted.WF_ID);
            obj[1] = new SqlParameter("NODE_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("NODE_MoTa", Inserted.MoTa);
            obj[3] = new SqlParameter("NODE_KetThuc", Inserted.KetThuc);
            obj[4] = new SqlParameter("NODE_BatDau", Inserted.BatDau);
            obj[5] = new SqlParameter("NODE_ThuTu", Inserted.ThuTu);
            obj[6] = new SqlParameter("NODE_NgayTao", Inserted.NgayTao);
            obj[7] = new SqlParameter("NODE_NgayCapNhat", Inserted.NgayCapNhat);
            obj[8] = new SqlParameter("NODE_NguoiTao", Inserted.NguoiTao);
            obj[9] = new SqlParameter("NODE_RowId", Inserted.RowId);
            obj[10] = new SqlParameter("NODE_AddMember", Inserted.AddMember);
            obj[11] = new SqlParameter("NODE_AddCoQuan", Inserted.AddCoQuan);
            obj[12] = new SqlParameter("NODE_ChuyenTiep", Inserted.ChuyenTiep);
            obj[13] = new SqlParameter("NODE_ChuyenNguoc", Inserted.ChuyenNguoc);
            obj[14] = new SqlParameter("NODE_AddAllMember", Inserted.AddAllMember);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodes_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Nodes Update(Nodes Updated)
        {
            Nodes Item = new Nodes();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("NODE_ID", Updated.ID);
            obj[1] = new SqlParameter("NODE_WF_ID", Updated.WF_ID);
            obj[2] = new SqlParameter("NODE_Ten", Updated.Ten);
            obj[3] = new SqlParameter("NODE_MoTa", Updated.MoTa);
            obj[4] = new SqlParameter("NODE_KetThuc", Updated.KetThuc);
            obj[5] = new SqlParameter("NODE_BatDau", Updated.BatDau);
            obj[6] = new SqlParameter("NODE_ThuTu", Updated.ThuTu);
            obj[7] = new SqlParameter("NODE_NgayTao", Updated.NgayTao);
            obj[8] = new SqlParameter("NODE_NgayCapNhat", Updated.NgayCapNhat);
            obj[9] = new SqlParameter("NODE_NguoiTao", Updated.NguoiTao);
            obj[10] = new SqlParameter("NODE_RowId", Updated.RowId);
            obj[11] = new SqlParameter("NODE_AddMember", Updated.AddMember);
            obj[12] = new SqlParameter("NODE_AddCoQuan", Updated.AddCoQuan);
            obj[13] = new SqlParameter("NODE_ChuyenTiep", Updated.ChuyenTiep);
            obj[14] = new SqlParameter("NODE_ChuyenNguoc", Updated.ChuyenNguoc);
            obj[15] = new SqlParameter("NODE_AddAllMember", Updated.AddAllMember);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodes_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Nodes SelectById(Int32 NODE_ID)
        {
            Nodes Item = new Nodes();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NODE_ID", NODE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodes_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static NodesCollection SelectAll()
        {
            NodesCollection List = new NodesCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodes_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Nodes> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Nodes> pg = new Pager<Nodes>("sp_tblNodes_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Nodes getFromReader(IDataReader rd)
        {
            Nodes Item = new Nodes();
            Item.ID = (Int32)(rd["NODE_ID"]);
            Item.WF_ID = (Int32)(rd["NODE_WF_ID"]);
            Item.Ten = (String)(rd["NODE_Ten"]);
            Item.MoTa = (String)(rd["NODE_MoTa"]);
            Item.KetThuc = (Boolean)(rd["NODE_KetThuc"]);
            Item.BatDau = (Boolean)(rd["NODE_BatDau"]);
            Item.ThuTu = (Int32)(rd["NODE_ThuTu"]);
            Item.NgayTao = (DateTime)(rd["NODE_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["NODE_NgayCapNhat"]);
            Item.NguoiTao = (String)(rd["NODE_NguoiTao"]);
            Item.RowId = (Guid)(rd["NODE_RowId"]);
            Item.AddMember = (Boolean)(rd["NODE_AddMember"]);
            Item.AddCoQuan = (Boolean)(rd["NODE_AddCoQuan"]);
            Item.ChuyenTiep = (Boolean)(rd["NODE_ChuyenTiep"]);
            Item.ChuyenNguoc = (Boolean)(rd["NODE_ChuyenNguoc"]);
            Item.AddAllMember = (Boolean)(rd["NODE_AddAllMember"]);
            return Item;
        }
        #endregion
        #region Extend
        public static NodesCollection SelectByWf(string WF_ID)
        {
            NodesCollection List = new NodesCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("WF_ID", WF_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodes_Select_SelectByWf_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Nodes SelectByVanBan(Int32 VB_ID)
        {
            Nodes Item = new Nodes();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            VanbanNode item = new VanbanNode();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblNodes_Select_SelectByVanBan_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    item = VanbanNodeDal.getFromReader(rd);
                }
            }
            Item.vanBanNode = item;
            return Item;
        }

        #endregion
    }
    #endregion

    #endregion
}


