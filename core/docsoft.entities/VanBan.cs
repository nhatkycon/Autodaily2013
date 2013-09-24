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
    #region VanBan
    #region BO
    public class VanBan : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 WF_ID { get; set; }
        public String Ten { get; set; }
        public String SoDen { get; set; }
        public String PhanLoai_ID { get; set; }
        public Int32 CapGui_ID { get; set; }
        public String CapGui_Ten { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTrenVanBan { get; set; }
        public String SoKyHieu { get; set; }
        public Int32 LoaiVanBan_ID { get; set; }
        public String LoaiVanBan_Ten { get; set; }
        public Int32 NoiGui_ID { get; set; }
        public String NoiGui_Ten { get; set; }
        public String TrichYeu { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Guid RowId { get; set; }
        public Boolean PhucDap { get; set; }
        public Int32 PhucDap_ID { get; set; }
        public Boolean Den { get; set; }
        public Int32 TrangThai { get; set; }
        public Int32 CQ_ID { get; set; }
        public String CQ_Ten { get; set; }
        public String MEM_Username { get; set; }
        public String MEM_Ten { get; set; }
        public String LichSu { get; set; }
        public Int32 CVBNODE_ID { get; set; }
        public Boolean Draff { get; set; }
        public Boolean Moi { get; set; }
        public String CVBNODE_Ten { get; set; }
        public Boolean Doc { get; set; }
        public Boolean XuLy { get; set; }
        public Boolean Chinh { get; set; }
        public String So_DonVi { get; set; }
        public Boolean MucDo { get; set; }
        public String GhiChu { get; set; }
        public String So_Phieu { get; set; }
        public String LanhDaoBo { get; set; }
        #endregion
        #region Contructor
        public VanBan()
        { }
        
        #endregion
        #region Customs properties
        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }
        public Nodes nodes { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return VanBanDal.getFromReaderPager(rd);
        }
    }
    #endregion
    #region Collection
    public class VanBanCollection : BaseEntityCollection<VanBan>
    { }
    #endregion
    #region Dal
    public class VanBanDal
    {

        #region Methods

        public static void DeleteById(Int32 VB_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Delete_DeleteById_linhnx", obj);
        }

        public static VanBan Insert(VanBan Inserted)
        {
            VanBan Item = new VanBan();
            SqlParameter[] obj = new SqlParameter[31];
            obj[0] = new SqlParameter("VB_WF_ID", Inserted.WF_ID);
            obj[1] = new SqlParameter("VB_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("VB_SoDen", Inserted.SoDen);
            obj[3] = new SqlParameter("VB_PhanLoai_ID", Inserted.PhanLoai_ID);
            obj[4] = new SqlParameter("VB_CapGui_ID", Inserted.CapGui_ID);
            obj[5] = new SqlParameter("VB_CapGui_Ten", Inserted.CapGui_Ten);
            obj[6] = new SqlParameter("VB_NgayNhan", Inserted.NgayNhan);
            obj[7] = new SqlParameter("VB_NgayTrenVanBan", Inserted.NgayTrenVanBan);
            obj[8] = new SqlParameter("VB_SoKyHieu", Inserted.SoKyHieu);
            obj[9] = new SqlParameter("VB_LoaiVanBan_ID", Inserted.LoaiVanBan_ID);
            obj[10] = new SqlParameter("VB_LoaiVanBan_Ten", Inserted.LoaiVanBan_Ten);
            obj[11] = new SqlParameter("VB_NoiGui_ID", Inserted.NoiGui_ID);
            obj[12] = new SqlParameter("VB_NoiGui_Ten", Inserted.NoiGui_Ten);
            obj[13] = new SqlParameter("VB_TrichYeu", Inserted.TrichYeu);
            obj[14] = new SqlParameter("VB_NgayTao", Inserted.NgayTao);
            obj[15] = new SqlParameter("VB_NguoiTao", Inserted.NguoiTao);
            obj[16] = new SqlParameter("VB_NgayCapNhat", Inserted.NgayCapNhat);
            obj[17] = new SqlParameter("VB_RowId", Inserted.RowId);
            obj[18] = new SqlParameter("VB_PhucDap", Inserted.PhucDap);
            obj[19] = new SqlParameter("VB_PhucDap_ID", Inserted.PhucDap_ID);
            obj[20] = new SqlParameter("VB_Den", Inserted.Den);
            obj[21] = new SqlParameter("VB_TrangThai", Inserted.TrangThai);
            obj[22] = new SqlParameter("VB_CQ_ID", Inserted.CQ_ID);
            obj[23] = new SqlParameter("VB_CQ_Ten", Inserted.CQ_Ten);
            obj[24] = new SqlParameter("VB_MEM_Username", Inserted.MEM_Username);
            obj[25] = new SqlParameter("VB_MEM_Ten", Inserted.MEM_Ten);
            obj[26] = new SqlParameter("VB_LichSu", Inserted.LichSu);
            obj[27] = new SqlParameter("VB_CVBNODE_ID", Inserted.CVBNODE_ID);
            obj[28] = new SqlParameter("VB_Draff", Inserted.Draff);
            obj[29] = new SqlParameter("VB_Moi", Inserted.Moi);
            obj[30] = new SqlParameter("VB_CVBNODE_Ten", Inserted.CVBNODE_Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VanBan Update(VanBan Updated)
        {
            VanBan Item = new VanBan();
            SqlParameter[] obj = new SqlParameter[32];
            obj[0] = new SqlParameter("VB_ID", Updated.ID);
            obj[1] = new SqlParameter("VB_WF_ID", Updated.WF_ID);
            obj[2] = new SqlParameter("VB_Ten", Updated.Ten);
            obj[3] = new SqlParameter("VB_SoDen", Updated.SoDen);
            obj[4] = new SqlParameter("VB_PhanLoai_ID", Updated.PhanLoai_ID);
            obj[5] = new SqlParameter("VB_CapGui_ID", Updated.CapGui_ID);
            obj[6] = new SqlParameter("VB_CapGui_Ten", Updated.CapGui_Ten);
            obj[7] = new SqlParameter("VB_NgayNhan", Updated.NgayNhan);
            obj[8] = new SqlParameter("VB_NgayTrenVanBan", Updated.NgayTrenVanBan);
            obj[9] = new SqlParameter("VB_SoKyHieu", Updated.SoKyHieu);
            obj[10] = new SqlParameter("VB_LoaiVanBan_ID", Updated.LoaiVanBan_ID);
            obj[11] = new SqlParameter("VB_LoaiVanBan_Ten", Updated.LoaiVanBan_Ten);
            obj[12] = new SqlParameter("VB_NoiGui_ID", Updated.NoiGui_ID);
            obj[13] = new SqlParameter("VB_NoiGui_Ten", Updated.NoiGui_Ten);
            obj[14] = new SqlParameter("VB_TrichYeu", Updated.TrichYeu);
            obj[15] = new SqlParameter("VB_NgayTao", Updated.NgayTao);
            obj[16] = new SqlParameter("VB_NguoiTao", Updated.NguoiTao);
            obj[17] = new SqlParameter("VB_NgayCapNhat", Updated.NgayCapNhat);
            obj[18] = new SqlParameter("VB_RowId", Updated.RowId);
            obj[19] = new SqlParameter("VB_PhucDap", Updated.PhucDap);
            obj[20] = new SqlParameter("VB_PhucDap_ID", Updated.PhucDap_ID);
            obj[21] = new SqlParameter("VB_Den", Updated.Den);
            obj[22] = new SqlParameter("VB_TrangThai", Updated.TrangThai);
            obj[23] = new SqlParameter("VB_CQ_ID", Updated.CQ_ID);
            obj[24] = new SqlParameter("VB_CQ_Ten", Updated.CQ_Ten);
            obj[25] = new SqlParameter("VB_MEM_Username", Updated.MEM_Username);
            obj[26] = new SqlParameter("VB_MEM_Ten", Updated.MEM_Ten);
            obj[27] = new SqlParameter("VB_LichSu", Updated.LichSu);
            obj[28] = new SqlParameter("VB_CVBNODE_ID", Updated.CVBNODE_ID);
            obj[29] = new SqlParameter("VB_Draff", Updated.Draff);
            obj[30] = new SqlParameter("VB_Moi", Updated.Moi);
            obj[31] = new SqlParameter("VB_CVBNODE_Ten", Updated.CVBNODE_Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReaderDraff(rd);
                }
            }
            return Item;
        }
        public static VanBan UpdateVanBan(VanBan Updated)
        {
            VanBan Item = new VanBan();
            SqlParameter[] obj = new SqlParameter[32];
            obj[0] = new SqlParameter("VB_ID", Updated.ID);
            obj[1] = new SqlParameter("VB_SoDen", Updated.SoDen);
            obj[2] = new SqlParameter("VB_PhanLoai_ID", Updated.PhanLoai_ID);
            obj[3] = new SqlParameter("VB_CapGui_ID", Updated.CapGui_ID);
            obj[4] = new SqlParameter("VB_CapGui_Ten", Updated.CapGui_Ten);
            obj[5] = new SqlParameter("VB_NgayNhan", Updated.NgayNhan);
            obj[6] = new SqlParameter("VB_NgayTrenVanBan", Updated.NgayTrenVanBan);
            obj[7] = new SqlParameter("VB_SoKyHieu", Updated.SoKyHieu);
            obj[8] = new SqlParameter("VB_LoaiVanBan_ID", Updated.LoaiVanBan_ID);
            obj[9] = new SqlParameter("VB_LoaiVanBan_Ten", Updated.LoaiVanBan_Ten);
            obj[10] = new SqlParameter("VB_NoiGui_ID", Updated.NoiGui_ID);
            obj[11] = new SqlParameter("VB_NoiGui_Ten", Updated.NoiGui_Ten);
            obj[12] = new SqlParameter("VB_TrichYeu", Updated.TrichYeu);
            obj[13] = new SqlParameter("VB_NgayCapNhat", Updated.NgayCapNhat);
            obj[14] = new SqlParameter("VB_PhucDap", Updated.PhucDap);
            obj[15] = new SqlParameter("VB_PhucDap_ID", Updated.PhucDap_ID);
            obj[16] = new SqlParameter("VB_Draff", Updated.Draff);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Update_UpdateVanBan_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReaderDraff(rd);
                }
            }
            return Item;
        }
        public static VanBan SelectById(Int32 VB_ID)
        {
            VanBan Item = new VanBan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VanBanCollection SelectAll()
        {
            VanBanCollection List = new VanBanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<VanBan> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<VanBan> pg = new Pager<VanBan>("sp_tblVanBan_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static VanBan getFromReader(IDataReader rd)
        {
            VanBan Item = new VanBan();
            if (rd.FieldExists("VB_ID"))
            {
                Item.ID = (Int32)(rd["VB_ID"]);
            }
            if (rd.FieldExists("VB_WF_ID"))
            {
                Item.WF_ID = (Int32)(rd["VB_WF_ID"]);
            }
            if (rd.FieldExists("VB_Ten"))
            {
                Item.Ten = (String)(rd["VB_Ten"]);
            }
            if (rd.FieldExists("VB_SoDen"))
            {
                Item.SoDen = (String)(rd["VB_SoDen"]);
            }
            if (rd.FieldExists("VB_PhanLoai_ID"))
            {
                Item.PhanLoai_ID = (String)(rd["VB_PhanLoai_ID"]);
            }
            if (rd.FieldExists("VB_CapGui_ID"))
            {
                Item.CapGui_ID = (Int32)(rd["VB_CapGui_ID"]);
            }
            if (rd.FieldExists("VB_CapGui_Ten"))
            {
                Item.CapGui_Ten = (String)(rd["VB_CapGui_Ten"]);
            }
            if (rd.FieldExists("VB_NgayNhan"))
            {
                Item.NgayNhan = (DateTime)(rd["VB_NgayNhan"]);
            }
            if (rd.FieldExists("VB_NgayTrenVanBan"))
            {
                Item.NgayTrenVanBan = (DateTime)(rd["VB_NgayTrenVanBan"]);
            }
            if (rd.FieldExists("VB_SoKyHieu"))
            {
                Item.SoKyHieu = (String)(rd["VB_SoKyHieu"]);
            }
            if (rd.FieldExists("VB_LoaiVanBan_ID"))
            {
                Item.LoaiVanBan_ID = (Int32)(rd["VB_LoaiVanBan_ID"]);
            }
            if (rd.FieldExists("VB_LoaiVanBan_Ten"))
            {
                Item.LoaiVanBan_Ten = (String)(rd["VB_LoaiVanBan_Ten"]);
            }
            if (rd.FieldExists("VB_NoiGui_ID"))
            {
                Item.NoiGui_ID = (Int32)(rd["VB_NoiGui_ID"]);
            }
            if (rd.FieldExists("VB_NoiGui_Ten"))
            {
                Item.NoiGui_Ten = (String)(rd["VB_NoiGui_Ten"]);
            }
            if (rd.FieldExists("VB_TrichYeu"))
            {
                Item.TrichYeu = (String)(rd["VB_TrichYeu"]);
            }
            if (rd.FieldExists("VB_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["VB_NgayTao"]);
            }
            if (rd.FieldExists("VB_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["VB_NguoiTao"]);
            }
            if (rd.FieldExists("VB_LanhDaoBo"))
            {
                Item.LanhDaoBo = (String)(rd["VB_LanhDaoBo"]);
            }
            if (rd.FieldExists("VB_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["VB_NgayCapNhat"]);
            }
            if (rd.FieldExists("VB_RowId"))
            {
                Item.RowId = (Guid)(rd["VB_RowId"]);
            }
            if (rd.FieldExists("VB_PhucDap"))
            {
                Item.PhucDap = (Boolean)(rd["VB_PhucDap"]);
            }
            if (rd.FieldExists("VB_PhucDap_ID"))
            {
                Item.PhucDap_ID = (Int32)(rd["VB_PhucDap_ID"]);
            }
            if (rd.FieldExists("VB_Den"))
            {
                Item.Den = (Boolean)(rd["VB_Den"]);
            }
            if (rd.FieldExists("VB_TrangThai"))
            {
                Item.TrangThai = (Int32)(rd["VB_TrangThai"]);
            }
            if (rd.FieldExists("VB_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["VB_CQ_ID"]);
            }
            if (rd.FieldExists("VB_CQ_Ten"))
            {
                Item.CQ_Ten = (String)(rd["VB_CQ_Ten"]);
            }
            if (rd.FieldExists("VB_MEM_Username"))
            {
                Item.MEM_Username = (String)(rd["VB_MEM_Username"]);
            }
            if (rd.FieldExists("VB_MEM_Ten"))
            {
                Item.MEM_Ten = (String)(rd["VB_MEM_Ten"]);
            }
            if (rd.FieldExists("VB_LichSu"))
            {
                Item.LichSu = (String)(rd["VB_LichSu"]);
            }
            if (rd.FieldExists("VB_CVBNODE_ID"))
            {
                Item.CVBNODE_ID = (Int32)(rd["VB_CVBNODE_ID"]);
            }
            if (rd.FieldExists("VB_Draff"))
            {
                Item.Draff = (Boolean)(rd["VB_Draff"]);
            }
            if (rd.FieldExists("VB_Moi"))
            {
                Item.Moi = (Boolean)(rd["VB_Moi"]);
            }
            if (rd.FieldExists("VB_CVBNODE_Ten"))
            {
                Item.CVBNODE_Ten = (String)(rd["VB_CVBNODE_Ten"]);
            }
            if (rd.FieldExists("VB_Doc"))
            {
                Item.Doc = (Boolean)(rd["VB_Doc"]);
            }
            if (rd.FieldExists("VB_XuLy"))
            {
                Item.XuLy = (Boolean)(rd["VB_XuLy"]);
            }
            if (rd.FieldExists("VB_Chinh"))
            {
                Item.Chinh = (Boolean)(rd["VB_Chinh"]);
            }
            if (rd.FieldExists("VB_So_DonVi"))
            {
                Item.MucDo = (Boolean)(rd["VB_So_DonVi"]);
            }
            if (rd.FieldExists("VB_MucDo"))
            {
                Item.MucDo = (Boolean)(rd["VB_MucDo"]);
            }
            if (rd.FieldExists("VB_GhiChu"))
            {
                Item.GhiChu = (String)(rd["VB_GhiChu"]);
            }
            if (rd.FieldExists("VB_So_Phieu"))
            {
                Item.GhiChu = (String)(rd["VB_So_Phieu"]);
            }
            
            return Item;
        }
        #endregion
        #region Extend
        public static Pager<VanBan> pagerPublic(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<VanBan> pg = new Pager<VanBan>("sp_tblVanBan_Pager_Public_linhnx", "q", 30, 10, rewrite, url, obj);
            return pg;
        }
        public static VanBan SelectDraffById(Int32 VB_ID)
        {
            VanBan Item = new VanBan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReaderDraff2(rd);
                }
            }
            return Item;
        }
        public static VanBan InsertDraff(VanBan Inserted)
        {
            VanBan Item = new VanBan();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("VB_NgayTao", Inserted.NgayTao);
            obj[1] = new SqlParameter("VB_NguoiTao", Inserted.NguoiTao);
            obj[2] = new SqlParameter("VB_NgayCapNhat", Inserted.NgayCapNhat);
            obj[3] = new SqlParameter("VB_RowId", Inserted.RowId);
            obj[4] = new SqlParameter("VB_Draff", Inserted.Draff);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Insert_InsertDraff_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReaderDraff(rd);
                }
            }
            return Item;
        }
        public static VanBan getFromReaderDraff(IDataReader rd)
        {
            VanBan Item = new VanBan();
            Item.ID = (Int32)(rd["VB_ID"]);
            Item.SoDen = rd["VB_SoDen"].ToString();
            return Item;
        }
        public static VanBan getFromReaderDraff2(IDataReader rd)
        {
            VanBan Item = new VanBan();
            Item.ID = (Int32)(rd["VB_ID"]);
            Item.SoDen = rd["VB_SoDen"].ToString();
            Item.NgayTao = Convert.ToDateTime(rd["VB_NgayTao"]);
            Item.NgayCapNhat = Convert.ToDateTime(rd["VB_NgayCapNhat"]);
            Item.NguoiTao = rd["VB_NguoiTao"].ToString();
            return Item;
        }
        public static Boolean CheckSoKyHieu(string kyhieu)
        {
            Boolean ok = false;
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("sokyhieu", kyhieu);
            ok = Convert.ToBoolean(SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Select_CheckSoKyHieu_linhnx", obj));
            return ok;
        }
        public static Pager<VanBan> PagerByUser(string url, bool rewrite, string sort,string pagesize
            , string Username, string VB_Draff, string VB_TrangThai, string VB_CQ_ID, string VB_MEM_Username
            , string VB_PhanLoai_ID, string VB_NoiGui_ID, string VB_LoaiVanBan_ID, string q)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("Username", Username);
            if (string.IsNullOrEmpty(VB_Draff))
            {
                obj[2] = new SqlParameter("VB_Draff", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("VB_Draff", VB_Draff);
            }
            if (string.IsNullOrEmpty(VB_TrangThai))
            {
                obj[3] = new SqlParameter("VB_TrangThai", DBNull.Value);
            }
            else
            {
                obj[3] = new SqlParameter("VB_TrangThai", VB_TrangThai);
            }
            if (string.IsNullOrEmpty(VB_CQ_ID))
            {
                obj[4] = new SqlParameter("VB_CQ_ID", DBNull.Value);
            }
            else
            {
                obj[4] = new SqlParameter("VB_CQ_ID", VB_CQ_ID);
            }
            if (string.IsNullOrEmpty(VB_MEM_Username))
            {
                obj[5] = new SqlParameter("VB_MEM_Username", DBNull.Value);
            }
            else
            {
                obj[5] = new SqlParameter("VB_MEM_Username", VB_MEM_Username);
            }
            if (string.IsNullOrEmpty(VB_PhanLoai_ID))
            {
                obj[6] = new SqlParameter("VB_PhanLoai_ID", DBNull.Value);
            }
            else
            {
                obj[6] = new SqlParameter("VB_PhanLoai_ID", VB_PhanLoai_ID);
            }
            if (string.IsNullOrEmpty(VB_NoiGui_ID))
            {
                obj[7] = new SqlParameter("VB_NoiGui_ID", DBNull.Value);
            }
            else
            {
                obj[7] = new SqlParameter("VB_NoiGui_ID", VB_NoiGui_ID);
            }
            if (string.IsNullOrEmpty(VB_LoaiVanBan_ID))
            {
                obj[8] = new SqlParameter("VB_LoaiVanBan_ID", DBNull.Value);                
            }
            else
            {
                obj[8] = new SqlParameter("VB_LoaiVanBan_ID", VB_LoaiVanBan_ID);
            }
            if (string.IsNullOrEmpty(q))
            {
                obj[9] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[9] = new SqlParameter("q", q);
            }
            if (string.IsNullOrEmpty(pagesize))
            {
                pagesize = "5";
            }
            Pager<VanBan> pg = new Pager<VanBan>("sp_tblVanBan_Pager_PagerByUser_linhnx", "page", Convert.ToInt16(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static VanBan getFromReaderPager(IDataReader rd)
        {
            VanBan Item = new VanBan();
            if (rd.FieldExists("VB_ID"))
            {
                Item.ID = (Int32)(rd["VB_ID"]);
            }
            if (rd.FieldExists("VB_SoDen"))
            {
                Item.SoDen = (String)(rd["VB_SoDen"]);
            }
            if (rd.FieldExists("VB_PhanLoai_ID"))
            {
                Item.PhanLoai_ID = (String)(rd["VB_PhanLoai_ID"]);
            }
            //Item.CapGui_ID = (Int32)(rd["VB_CapGui_ID"]);
            //Item.CapGui_Ten = (String)(rd["VB_CapGui_Ten"]);
            if (rd.FieldExists("VB_LanhDaoBo"))
            {
                Item.LanhDaoBo = (String)(rd["VB_LanhDaoBo"]);
            }
            if (rd.FieldExists("VB_NgayNhan"))
            {
                Item.NgayNhan = (DateTime)(rd["VB_NgayNhan"]);
            }
            if (rd.FieldExists("VB_NgayTrenVanBan"))
            {
                Item.NgayTrenVanBan = (DateTime)(rd["VB_NgayTrenVanBan"]);
            }
            if (rd.FieldExists("VB_SoKyHieu"))
            {
                Item.SoKyHieu = (String)(rd["VB_SoKyHieu"]);
            }
            if (rd.FieldExists("VB_NoiGui_ID"))
            {
                Item.NoiGui_ID = (Int32)(rd["VB_NoiGui_ID"]);
            }
            if (rd.FieldExists("VB_NoiGui_Ten"))
            {
                Item.NoiGui_Ten = (String)(rd["VB_NoiGui_Ten"]);
            }
            if (rd.FieldExists("VB_TrichYeu"))
            {
                Item.TrichYeu = (String)(rd["VB_TrichYeu"]);
            }
            if (rd.FieldExists("VB_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["VB_NgayTao"]);
            }
            if (rd.FieldExists("VB_Draff"))
            {
                Item.Draff = (Boolean)(rd["VB_Draff"]);
            }
            if (rd.FieldExists("VB_PhucDap"))
            {
                Item.PhucDap = (Boolean)(rd["VB_PhucDap"]);
            }
            if (rd.FieldExists("VB_PhucDap_ID"))
            {
                Item.PhucDap_ID = (Int32)(rd["VB_PhucDap_ID"]);
            }
            if (rd.FieldExists("VB_TrangThai"))
            {
                Item.TrangThai = (Int32)(rd["VB_TrangThai"]);
            }
            if (rd.FieldExists("VB_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["VB_CQ_ID"]);
            }
            if (rd.FieldExists("VB_CQ_Ten"))
            {
                Item.CQ_Ten = (String)(rd["VB_CQ_Ten"]);
            }
            if (rd.FieldExists("VB_MEM_Username"))
            {
                Item.MEM_Username = (String)(rd["VB_MEM_Username"]);
            }
            if (rd.FieldExists("VB_MEM_Ten"))
            {
                Item.MEM_Ten = (String)(rd["VB_MEM_Ten"]);
            }
            if (rd.FieldExists("VB_NguoiTao"))
            {
                Item.NguoiTao = rd["VB_NguoiTao"].ToString();
            }
            if (rd.FieldExists("VB_Doc"))
            {
                Item.Doc = (Boolean)(rd["VB_Doc"]);
            }
            if (rd.FieldExists("VB_XuLy"))
            {
                Item.XuLy = (Boolean)(rd["VB_XuLy"]);
            }
            if (rd.FieldExists("VB_Chinh"))
            {
                Item.Chinh = (Boolean)(rd["VB_Chinh"]);
            }
            return Item;
        }
        public static VanBan getFromReaderTiny(IDataReader rd)
        {
            VanBan Item = new VanBan();
            Item.ID = (Int32)(rd["VB_ID"]);
            Item.SoDen = (String)(rd["VB_SoDen"]);
            Item.PhanLoai_ID = (String)(rd["VB_PhanLoai_ID"]);
            Item.CapGui_Ten = (String)(rd["VB_CapGui_Ten"]);
            Item.NgayNhan = (DateTime)(rd["VB_NgayNhan"]);
            Item.NgayTrenVanBan = (DateTime)(rd["VB_NgayTrenVanBan"]);
            Item.SoKyHieu = (String)(rd["VB_SoKyHieu"]);
            Item.LoaiVanBan_Ten = (String)(rd["VB_LoaiVanBan_Ten"]);
            Item.NoiGui_Ten = (String)(rd["VB_NoiGui_Ten"]);
            Item.TrichYeu = (String)(rd["VB_TrichYeu"]);
            Item.NgayTao = (DateTime)(rd["VB_NgayTao"]);
            Item.NguoiTao = (String)(rd["VB_NguoiTao"]);
            Item.TrangThai = (Int32)(rd["VB_TrangThai"]);
            Item.CQ_ID = (Int32)(rd["VB_CQ_ID"]);
            Item.CQ_Ten = (String)(rd["VB_CQ_Ten"]);
            return Item;
        }
        
        public static VanBan getFromReaderSearchCongVan(IDataReader rd)
        {
            VanBan Item = new VanBan();
            Item.ID = (Int32)(rd["VB_ID"]);
            Item.SoDen = (String)(rd["VB_SoDen"]);
            Item.SoKyHieu = (String)(rd["VB_SoKyHieu"]);
            Item.TrichYeu = (String)(rd["VB_TrichYeu"]);
            return Item;
        }
        public static VanBan getFromReaderXuLy(IDataReader rd)
        {
            VanBan Item = new VanBan();
            Nodes _Nodes = new Nodes();
            if (rd.FieldExists("VB_ID"))
            {
                Item.ID = (Int32)(rd["VB_ID"]);
            }
            if (rd.FieldExists("VB_SoDen"))
            {
                Item.SoDen = (String)(rd["VB_SoDen"]);
            }
            if (rd.FieldExists("VB_PhanLoai_ID"))
            {
                Item.PhanLoai_ID = (String)(rd["VB_PhanLoai_ID"]);
            }
            if (rd.FieldExists("VB_CapGui_Ten"))
            {
                Item.CapGui_Ten = (String)(rd["VB_CapGui_Ten"]);
            }
            if (rd.FieldExists("VB_NgayNhan"))
            {
                Item.NgayNhan = (DateTime)(rd["VB_NgayNhan"]);
            }
            if (rd.FieldExists("VB_NgayTrenVanBan"))
            {
                Item.NgayTrenVanBan = (DateTime)(rd["VB_NgayTrenVanBan"]);
            }
            if (rd.FieldExists("VB_SoKyHieu"))
            {
                Item.SoKyHieu = (String)(rd["VB_SoKyHieu"]);
            }
            if (rd.FieldExists("VB_LoaiVanBan_Ten"))
            {
                Item.LoaiVanBan_Ten = (String)(rd["VB_LoaiVanBan_Ten"]);
            }
            if (rd.FieldExists("VB_NoiGui_Ten"))
            {
                Item.NoiGui_Ten = (String)(rd["VB_NoiGui_Ten"]);
            }
            if (rd.FieldExists("VB_TrichYeu"))
            {
                Item.TrichYeu = (String)(rd["VB_TrichYeu"]);
            }
            if (rd.FieldExists("VB_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["VB_NgayTao"]);
            }
            if (rd.FieldExists("VB_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["VB_NguoiTao"]);
            }
            if (rd.FieldExists("VB_TrangThai"))
            {
                Item.TrangThai = (Int32)(rd["VB_TrangThai"]);
            }
            if (rd.FieldExists("VB_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["VB_CQ_ID"]);
            }
            if (rd.FieldExists("VB_CQ_Ten"))
            {
                Item.CQ_Ten = (String)(rd["VB_CQ_Ten"]);
            }
            if (rd.FieldExists("VB_LichSu"))
            {
                Item.LichSu = (String)(rd["VB_LichSu"]);
            }
            if (rd.FieldExists("VB_CVBNODE_ID"))
            {
                Item.CVBNODE_ID = (Int32)(rd["VB_CVBNODE_ID"]);
            }
            if (rd.FieldExists("VB_WF_ID"))
            {
                Item.WF_ID = (Int32)(rd["VB_WF_ID"]);
            }
            if (rd.FieldExists("NODE_AddMember"))
            {
                _Nodes.AddMember = (Boolean)(rd["NODE_AddMember"]);
            }
            if (rd.FieldExists("NODE_AddCoQuan"))
            {
                _Nodes.AddCoQuan = (Boolean)(rd["NODE_AddCoQuan"]);
            }
            if (rd.FieldExists("NODE_ChuyenTiep"))
            {
                _Nodes.ChuyenTiep = (Boolean)(rd["NODE_ChuyenTiep"]);
            }
            if (rd.FieldExists("NODE_ChuyenNguoc"))
            {
                _Nodes.ChuyenNguoc = (Boolean)(rd["NODE_ChuyenNguoc"]);
            }
            if (rd.FieldExists("NODE_AddAllMember"))
            {
                _Nodes.AddAllMember = (Boolean)(rd["NODE_AddAllMember"]);
            }
            if (rd.FieldExists("NODE_KetThuc"))
            {
                _Nodes.KetThuc = (Boolean)(rd["NODE_KetThuc"]);
            }
            if (rd.FieldExists("NODE_BatDau"))
            {
                _Nodes.BatDau = (Boolean)(rd["NODE_BatDau"]);
            }
            Item.nodes = _Nodes;
            return Item;
        }
        public static VanBan SelectByIdView(Int32 VB_ID,string Username)
        {
            VanBan Item = new VanBan();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            obj[1] = new SqlParameter("Username", Username);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Select_SelectByIdView_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    Files item = new Files();
                    item.Ten = rd["F_Ten"].ToString();
                    item.ID = Convert.ToInt32(rd["F_ID"]);
                    item.NguoiTao = rd["F_NguoiTao"].ToString();
                    filelist.Add(item);
                }
            }
            Item.Filelist = filelist;
            return Item;
        }
        public static VanBan SelectByIdXuLy(Int32 VB_ID, string Username)
        {
            VanBan Item = new VanBan();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            obj[1] = new SqlParameter("Username", Username);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Select_SelectByIdXuLy_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReaderXuLy(rd);
                    Files item = new Files();
                    item.Ten = rd["F_Ten"].ToString();
                    item.ID = Convert.ToInt32(rd["F_ID"]);
                    item.NguoiTao = rd["F_NguoiTao"].ToString();
                    filelist.Add(item);
                }
            }
            Item.Filelist = filelist;
            return Item;
        }
        public static int SelectChannelByUsername(string Username,DateTime Ngay)
        {
            int Item = 0;
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Ngay", Ngay);
            Item = Convert.ToInt32(SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Pager_PagerByUserChannel_linhnx", obj));
            return Item;
        }
        public static List<VanBan> SelectChonCongVanDen(string Username, string q)
        {
            List<VanBan> List = new List<VanBan>();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Select_SelectChonCongVanDen_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderSearchCongVan(rd));
                }
            }
            return List;
        }
        public static VanBan SelectByIdView(Int32 VB_ID)
        {
            VanBan Item = new VanBan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBan_Select_SelectByIdView_hungpm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReaderTiny(rd);
                    Files item = new Files();
                    item.Ten = rd["F_Ten"].ToString();
                    item.ID = Convert.ToInt32(rd["F_ID"]);
                    item.NguoiTao = rd["F_NguoiTao"].ToString();
                    filelist.Add(item);
                }
            }
            Item.Filelist = filelist;
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
}


