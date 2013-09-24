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
using spa.entitites;

namespace docsoft.entities
{

    #region DanhMuc
    #region BO
    public class DanhMuc : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid GH_ID { get; set; }
        public Guid PID { get; set; }
        public Guid LDM_ID { get; set; }
        public String Lang { get; set; }
        public Boolean LangBased { get; set; }
        public Guid LangBased_ID { get; set; }
        public String Alias { get; set; }
        public String KyHieu { get; set; }
        public String Ten { get; set; }
        public String Anh { get; set; }
        public String Ma { get; set; }
        public String GiaTri { get; set; }
        public Int32 ThuTu { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiSua { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String KeyWords { get; set; }
        public String Description { get; set; }
        public Guid RowId { get; set; }
        public Boolean Deleted { get; set; }
        #endregion
        #region Contructor
        public DanhMuc()
        { }
        #endregion
        #region Customs properties
        public String LDM_Ten { get; set; }
        public Int32 Level { get; set; }
        public string PID_Ten { get; set; }
        public List<Tin> Tins { get; set; }
        public List<SpaHoiDap> SpaHoiDaps { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DanhMucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DanhMucCollection : BaseEntityCollection<DanhMuc>
    { }
    #endregion
    #region Dal
    public class DanhMucDal
    {
        #region Methods

        public static void DeleteById(Guid DM_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Delete_DeleteById_linhnx", obj);
        }

        public static DanhMuc Insert(DanhMuc item)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("DM_ID", item.ID);
            obj[1] = new SqlParameter("DM_GH_ID", item.GH_ID);
            obj[2] = new SqlParameter("DM_PID", item.PID);
            obj[3] = new SqlParameter("DM_LDM_ID", item.LDM_ID);
            obj[4] = new SqlParameter("DM_Lang", item.Lang);
            obj[5] = new SqlParameter("DM_LangBased", item.LangBased);
            obj[6] = new SqlParameter("DM_LangBased_ID", item.LangBased_ID);
            obj[7] = new SqlParameter("DM_Alias", item.Alias);
            obj[8] = new SqlParameter("DM_KyHieu", item.KyHieu);
            obj[9] = new SqlParameter("DM_Ten", item.Ten);
            obj[10] = new SqlParameter("DM_Anh", item.Anh);
            obj[11] = new SqlParameter("DM_Ma", item.Ma);
            obj[12] = new SqlParameter("DM_GiaTri", item.GiaTri);
            obj[13] = new SqlParameter("DM_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("DM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[14] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            obj[15] = new SqlParameter("DM_NguoiTao", item.NguoiTao);
            obj[16] = new SqlParameter("DM_NguoiSua", item.NguoiSua);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[18] = new SqlParameter("DM_KeyWords", item.KeyWords);
            obj[19] = new SqlParameter("DM_Description", item.Description);
            obj[20] = new SqlParameter("DM_RowId", item.RowId);
            obj[21] = new SqlParameter("DM_Deleted", item.Deleted);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DanhMuc Update(DanhMuc item)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("DM_ID", item.ID);
            obj[1] = new SqlParameter("DM_GH_ID", item.GH_ID);
            obj[2] = new SqlParameter("DM_PID", item.PID);
            obj[3] = new SqlParameter("DM_LDM_ID", item.LDM_ID);
            obj[4] = new SqlParameter("DM_Lang", item.Lang);
            obj[5] = new SqlParameter("DM_LangBased", item.LangBased);
            obj[6] = new SqlParameter("DM_LangBased_ID", item.LangBased_ID);
            obj[7] = new SqlParameter("DM_Alias", item.Alias);
            obj[8] = new SqlParameter("DM_KyHieu", item.KyHieu);
            obj[9] = new SqlParameter("DM_Ten", item.Ten);
            obj[10] = new SqlParameter("DM_Anh", item.Anh);
            obj[11] = new SqlParameter("DM_Ma", item.Ma);
            obj[12] = new SqlParameter("DM_GiaTri", item.GiaTri);
            obj[13] = new SqlParameter("DM_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[14] = new SqlParameter("DM_NgayTao", item.NgayTao);
            }
            else
            {
                obj[14] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            obj[15] = new SqlParameter("DM_NguoiTao", item.NguoiTao);
            obj[16] = new SqlParameter("DM_NguoiSua", item.NguoiSua);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[18] = new SqlParameter("DM_KeyWords", item.KeyWords);
            obj[19] = new SqlParameter("DM_Description", item.Description);
            obj[20] = new SqlParameter("DM_RowId", item.RowId);
            obj[21] = new SqlParameter("DM_Deleted", item.Deleted);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DanhMuc SelectById(Guid DM_ID)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DanhMucCollection SelectAll()
        {
            var List = new DanhMucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static Pager<DanhMuc> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<DanhMuc>("sp_tblDanhMuc_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DanhMuc getFromReader(IDataReader rd)
        {
            var Item = new DanhMuc();
            if (rd.FieldExists("DM_ID"))
            {
                Item.ID = (Guid)(rd["DM_ID"]);
            }
            if (rd.FieldExists("DM_GH_ID"))
            {
                Item.GH_ID = (Guid)(rd["DM_GH_ID"]);
            }
            if (rd.FieldExists("DM_PID"))
            {
                Item.PID = (Guid)(rd["DM_PID"]);
            }
            if (rd.FieldExists("DM_LDM_ID"))
            {
                Item.LDM_ID = (Guid)(rd["DM_LDM_ID"]);
            }
            if (rd.FieldExists("DM_Lang"))
            {
                Item.Lang = (String)(rd["DM_Lang"]);
            }
            if (rd.FieldExists("DM_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["DM_LangBased"]);
            }
            if (rd.FieldExists("DM_LangBased_ID"))
            {
                Item.LangBased_ID = (Guid)(rd["DM_LangBased_ID"]);
            }
            if (rd.FieldExists("DM_Alias"))
            {
                Item.Alias = (String)(rd["DM_Alias"]);
            }
            if (rd.FieldExists("DM_KyHieu"))
            {
                Item.KyHieu = (String)(rd["DM_KyHieu"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                Item.Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("DM_Anh"))
            {
                Item.Anh = (String)(rd["DM_Anh"]);
            }
            if (rd.FieldExists("DM_Ma"))
            {
                Item.Ma = (String)(rd["DM_Ma"]);
            }
            if (rd.FieldExists("DM_GiaTri"))
            {
                Item.GiaTri = (String)(rd["DM_GiaTri"]);
            }
            if (rd.FieldExists("DM_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            }
            if (rd.FieldExists("DM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DM_NgayTao"]);
            }
            if (rd.FieldExists("DM_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["DM_NguoiTao"]);
            }
            if (rd.FieldExists("DM_NguoiSua"))
            {
                Item.NguoiSua = (String)(rd["DM_NguoiSua"]);
            }
            if (rd.FieldExists("DM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["DM_NgayCapNhat"]);
            }
            if (rd.FieldExists("DM_KeyWords"))
            {
                Item.KeyWords = (String)(rd["DM_KeyWords"]);
            }
            if (rd.FieldExists("DM_Description"))
            {
                Item.Description = (String)(rd["DM_Description"]);
            }
            if (rd.FieldExists("DM_RowId"))
            {
                Item.RowId = (Guid)(rd["DM_RowId"]);
            }
            if (rd.FieldExists("DM_Deleted"))
            {
                Item.Deleted = (Boolean)(rd["DM_Deleted"]);
            }

            if (rd.FieldExists("LDM_Ten"))
            {
                Item.LDM_Ten = (String)(rd["LDM_Ten"]);
            }
            if (rd.FieldExists("DM_Level"))
            {
                Item.Level = (Int32)(rd["DM_Level"]);
            }
            if (rd.FieldExists("PID_Ten"))
            {
                Item.PID_Ten = (String)(rd["PID_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static DanhMuc SelectById(SqlConnection con, Guid DM_ID)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMucCollection SelectByLDMID(string LDM_ID)
        {
            var List = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByLDMID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectByLDMID(SqlConnection con, string LDM_ID)
        {
            var List = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByLDMID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectByLDMMa(string LDM_Ma)
        {
            var List = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(LDM_Ma))
            {
                obj[0] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByLDM_Ma_linhnx",obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectByLDMMa(SqlConnection con, string LDM_Ma)
        {
            var List = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(LDM_Ma))
            {
                obj[0] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByLDM_Ma_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMuc SelectByMa(string DM_Ma, SqlConnection con)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_Ma))
            {
                obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            }
            else
            {
                obj[0] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc SelectByMa(string DM_Ma)
        {
            var Item = new DanhMuc();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_Ma))
            {
                obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            }
            else
            {
                obj[0] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DanhMucCollection SelectParentByDmId(string DM_ID)
        {
            var list = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[0] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectParentByDmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static DanhMucCollection SelectParentByDmId(SqlConnection con, string DM_ID)
        {
            var list = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[0] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectParentByDmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static DanhMucCollection SelectTreeByDmMa(SqlConnection con, string Ma)
        {
            var list = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(Ma))
            {
                obj[0] = new SqlParameter("Ma", Ma);
            }
            else
            {
                obj[0] = new SqlParameter("Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_SelectTreeByDmMa", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        /// <summary>
        /// Dành cho tư vấn
        /// </summary>
        /// <param name="TV_ID"></param>
        /// <returns></returns>
        public static DanhMucCollection SelectByTvId(string TV_ID)
        {
            var List = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(TV_ID))
            {
                obj[0] = new SqlParameter("TV_ID", TV_ID);
            }
            else
            {
                obj[0] = new SqlParameter("TV_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByTvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static DanhMucCollection SelectByPid(string PID)
        {
            var List = new DanhMucCollection();
            var obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(PID))
            {
                obj[0] = new SqlParameter("PID", PID);
            }
            else
            {
                obj[0] = new SqlParameter("PID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByPid_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion
}


