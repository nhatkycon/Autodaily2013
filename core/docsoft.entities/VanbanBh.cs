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
    #region VanBanBh
    #region BO
    public class VanBanBh : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 LV_ID { get; set; }
        public String LV_Ten { get; set; }
        public Int32 LOAI_ID { get; set; }
        public String LOAI_Ten { get; set; }
        public String Ma { get; set; }
        public String NoiGui { get; set; }
        public String DiaChi { get; set; }
        public String CMT { get; set; }
        public DateTime NgayCap { get; set; }
        public String DienThoai { get; set; }
        public String Fax { get; set; }
        public String Email { get; set; }
        public String NoiDung { get; set; }
        public Guid RowId { get; set; }
        public Int32 TrangThai { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public DateTime NgayHenTra { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public String NguoiNop { get; set; }
        public DateTime MCCM_NgayNhan { get; set; }
        public Int32 MCCM_CQ_ID { get; set; }
        public String MCCM_CQ_Ten { get; set; }
        public Int32 MCCM_MEM_ID { get; set; }
        public String MCCM_MEM_Username { get; set; }
        public String MCCM_MEM_Ten { get; set; }
        public DateTime CMMC_NgayNhan { get; set; }
        public Int32 CMMC_MEM_ID { get; set; }
        public String CMMC_MEM_Username { get; set; }
        public String CMMC_MEM_Ten { get; set; }
        public DateTime MCNN_NgayTra { get; set; }
        public String MCNN_NguoiNhan { get; set; }
        public Int16 ThoiHan { get; set; }
        public Int16 KetQua { get; set; }
        #endregion
        #region Contructor
        public VanBanBh()
        { }
        #endregion
        #region Customs properties
        public string MTLList { get; set; }
        public string TLList { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return VanBanBhDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class VanBanBhCollection : BaseEntityCollection<VanBanBh>
    { }
    #endregion
    #region Dal
    public class VanBanBhDal
    {
        #region Methods

        public static void DeleteById(Int32 VB_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanBh_Delete_DeleteById_linhnx", obj);
        }

        public static VanBanBh Insert(VanBanBh Inserted)
        {
            VanBanBh Item = new VanBanBh();
            SqlParameter[] obj = new SqlParameter[36];
            obj[0] = new SqlParameter("VB_LV_ID", Inserted.LV_ID);
            obj[1] = new SqlParameter("VB_LV_Ten", Inserted.LV_Ten);
            obj[2] = new SqlParameter("VB_LOAI_ID", Inserted.LOAI_ID);
            obj[3] = new SqlParameter("VB_LOAI_Ten", Inserted.LOAI_Ten);
            obj[4] = new SqlParameter("VB_Ma", Inserted.Ma);
            obj[5] = new SqlParameter("VB_NoiGui", Inserted.NoiGui);
            obj[6] = new SqlParameter("VB_DiaChi", Inserted.DiaChi);
            obj[7] = new SqlParameter("VB_CMT", Inserted.CMT);
            obj[8] = new SqlParameter("VB_NgayCap", Inserted.NgayCap);
            obj[9] = new SqlParameter("VB_DienThoai", Inserted.DienThoai);
            obj[10] = new SqlParameter("VB_Fax", Inserted.Fax);
            obj[11] = new SqlParameter("VB_Email", Inserted.Email);
            obj[12] = new SqlParameter("VB_NoiDung", Inserted.NoiDung);
            obj[13] = new SqlParameter("VB_RowId", Inserted.RowId);
            obj[14] = new SqlParameter("VB_TrangThai", Inserted.TrangThai);
            obj[15] = new SqlParameter("VB_NguoiTao", Inserted.NguoiTao);
            obj[16] = new SqlParameter("VB_NgayTao", Inserted.NgayTao);
            obj[17] = new SqlParameter("VB_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[18] = new SqlParameter("VB_NgayCapNhat", Inserted.NgayCapNhat);
            obj[19] = new SqlParameter("VB_NgayHenTra", Inserted.NgayHenTra);
            obj[20] = new SqlParameter("VB_NgayTiepNhan", Inserted.NgayTiepNhan);
            obj[21] = new SqlParameter("VB_NguoiNop", Inserted.NguoiNop);
            obj[22] = new SqlParameter("VB_MCCM_NgayNhan", Inserted.MCCM_NgayNhan);
            obj[23] = new SqlParameter("VB_MCCM_CQ_ID", Inserted.MCCM_CQ_ID);
            obj[24] = new SqlParameter("VB_MCCM_CQ_Ten", Inserted.MCCM_CQ_Ten);
            obj[25] = new SqlParameter("VB_MCCM_MEM_ID", Inserted.MCCM_MEM_ID);
            obj[26] = new SqlParameter("VB_MCCM_MEM_Username", Inserted.MCCM_MEM_Username);
            obj[27] = new SqlParameter("VB_MCCM_MEM_Ten", Inserted.MCCM_MEM_Ten);
            obj[28] = new SqlParameter("VB_CMMC_NgayNhan", Inserted.CMMC_NgayNhan);
            obj[29] = new SqlParameter("VB_CMMC_MEM_ID", Inserted.CMMC_MEM_ID);
            obj[30] = new SqlParameter("VB_CMMC_MEM_Username", Inserted.CMMC_MEM_Username);
            obj[31] = new SqlParameter("VB_CMMC_MEM_Ten", Inserted.CMMC_MEM_Ten);
            obj[32] = new SqlParameter("VB_MCNN_NgayTra", Inserted.MCNN_NgayTra);
            obj[33] = new SqlParameter("VB_MCNN_NguoiNhan", Inserted.MCNN_NguoiNhan);
            obj[34] = new SqlParameter("VB_ThoiHan", Inserted.ThoiHan);
            obj[35] = new SqlParameter("VB_KetQua", Inserted.KetQua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanBh_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VanBanBh Update(VanBanBh Updated)
        {
            VanBanBh Item = new VanBanBh();
            SqlParameter[] obj = new SqlParameter[37];
            obj[0] = new SqlParameter("VB_ID", Updated.ID);
            obj[1] = new SqlParameter("VB_LV_ID", Updated.LV_ID);
            obj[2] = new SqlParameter("VB_LV_Ten", Updated.LV_Ten);
            obj[3] = new SqlParameter("VB_LOAI_ID", Updated.LOAI_ID);
            obj[4] = new SqlParameter("VB_LOAI_Ten", Updated.LOAI_Ten);
            obj[5] = new SqlParameter("VB_Ma", Updated.Ma);
            obj[6] = new SqlParameter("VB_NoiGui", Updated.NoiGui);
            obj[7] = new SqlParameter("VB_DiaChi", Updated.DiaChi);
            obj[8] = new SqlParameter("VB_CMT", Updated.CMT);
            obj[9] = new SqlParameter("VB_NgayCap", Updated.NgayCap);
            obj[10] = new SqlParameter("VB_DienThoai", Updated.DienThoai);
            obj[11] = new SqlParameter("VB_Fax", Updated.Fax);
            obj[12] = new SqlParameter("VB_Email", Updated.Email);
            obj[13] = new SqlParameter("VB_NoiDung", Updated.NoiDung);
            obj[14] = new SqlParameter("VB_RowId", Updated.RowId);
            obj[15] = new SqlParameter("VB_TrangThai", Updated.TrangThai);
            obj[16] = new SqlParameter("VB_NguoiTao", Updated.NguoiTao);
            obj[17] = new SqlParameter("VB_NgayTao", Updated.NgayTao);
            obj[18] = new SqlParameter("VB_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[19] = new SqlParameter("VB_NgayCapNhat", Updated.NgayCapNhat);
            obj[20] = new SqlParameter("VB_NgayHenTra", Updated.NgayHenTra);
            obj[21] = new SqlParameter("VB_NgayTiepNhan", Updated.NgayTiepNhan);
            obj[22] = new SqlParameter("VB_NguoiNop", Updated.NguoiNop);
            obj[23] = new SqlParameter("VB_MCCM_NgayNhan", Updated.MCCM_NgayNhan);
            obj[24] = new SqlParameter("VB_MCCM_CQ_ID", Updated.MCCM_CQ_ID);
            obj[25] = new SqlParameter("VB_MCCM_CQ_Ten", Updated.MCCM_CQ_Ten);
            obj[26] = new SqlParameter("VB_MCCM_MEM_ID", Updated.MCCM_MEM_ID);
            obj[27] = new SqlParameter("VB_MCCM_MEM_Username", Updated.MCCM_MEM_Username);
            obj[28] = new SqlParameter("VB_MCCM_MEM_Ten", Updated.MCCM_MEM_Ten);
            obj[29] = new SqlParameter("VB_CMMC_NgayNhan", Updated.CMMC_NgayNhan);
            obj[30] = new SqlParameter("VB_CMMC_MEM_ID", Updated.CMMC_MEM_ID);
            obj[31] = new SqlParameter("VB_CMMC_MEM_Username", Updated.CMMC_MEM_Username);
            obj[32] = new SqlParameter("VB_CMMC_MEM_Ten", Updated.CMMC_MEM_Ten);
            obj[33] = new SqlParameter("VB_MCNN_NgayTra", Updated.MCNN_NgayTra);
            obj[34] = new SqlParameter("VB_MCNN_NguoiNhan", Updated.MCNN_NguoiNhan);
            obj[35] = new SqlParameter("VB_ThoiHan", Updated.ThoiHan);
            obj[36] = new SqlParameter("VB_KetQua", Updated.KetQua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanBh_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VanBanBh SelectById(Int32 VB_ID)
        {
            VanBanBh Item = new VanBanBh();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VB_ID", VB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanBh_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VanBanBhCollection SelectAll()
        {
            VanBanBhCollection List = new VanBanBhCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanBh_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<VanBanBh> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<VanBanBh> pg = new Pager<VanBanBh>("sp_tblVanBanBh_Pager_Normal_linhnx", "q", 50, 50, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static VanBanBh getFromReader(IDataReader rd)
        {
            VanBanBh Item = new VanBanBh();
            if (rd.FieldExists("VB_ID"))
            {
                Item.ID = (Int32)(rd["VB_ID"]);
            }
            if (rd.FieldExists("VB_LV_ID"))
            {
                Item.LV_ID = (Int32)(rd["VB_LV_ID"]);
            }
            if (rd.FieldExists("VB_LV_Ten"))
            {
                Item.LV_Ten = (String)(rd["VB_LV_Ten"]);
            }
            if (rd.FieldExists("VB_LOAI_ID"))
            {
                Item.LOAI_ID = (Int32)(rd["VB_LOAI_ID"]);
            }
            if (rd.FieldExists("VB_LOAI_Ten"))
            {
                Item.LOAI_Ten = (String)(rd["VB_LOAI_Ten"]);
            }
            if (rd.FieldExists("VB_Ma"))
            {
                Item.Ma = (String)(rd["VB_Ma"]);
            }
            if (rd.FieldExists("VB_NoiGui"))
            {
                Item.NoiGui = (String)(rd["VB_NoiGui"]);
            }
            if (rd.FieldExists("VB_DiaChi"))
            {
                Item.DiaChi = (String)(rd["VB_DiaChi"]);
            }
            if (rd.FieldExists("VB_CMT"))
            {
                Item.CMT = (String)(rd["VB_CMT"]);
            }
            if (rd.FieldExists("VB_NgayCap"))
            {
                Item.NgayCap = (DateTime)(rd["VB_NgayCap"]);
            }
            if (rd.FieldExists("VB_DienThoai"))
            {
                Item.DienThoai = (String)(rd["VB_DienThoai"]);
            }
            if (rd.FieldExists("VB_Fax"))
            {
                Item.Fax = (String)(rd["VB_Fax"]);
            }
            if (rd.FieldExists("VB_Email"))
            {
                Item.Email = (String)(rd["VB_Email"]);
            }
            if (rd.FieldExists("VB_NoiDung"))
            {
                Item.NoiDung = (String)(rd["VB_NoiDung"]);
            }
            if (rd.FieldExists("VB_RowId"))
            {
                Item.RowId = (Guid)(rd["VB_RowId"]);
            }
            if (rd.FieldExists("VB_TrangThai"))
            {
                Item.TrangThai = (Int32)(rd["VB_TrangThai"]);
            }
            if (rd.FieldExists("VB_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["VB_NguoiTao"]);
            }
            if (rd.FieldExists("VB_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["VB_NgayTao"]);
            }
            if (rd.FieldExists("VB_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["VB_NguoiCapNhat"]);
            }
            if (rd.FieldExists("VB_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["VB_NgayCapNhat"]);
            }
            if (rd.FieldExists("VB_NgayHenTra"))
            {
                Item.NgayHenTra = (DateTime)(rd["VB_NgayHenTra"]);
            }
            if (rd.FieldExists("VB_NgayTiepNhan"))
            {
                Item.NgayTiepNhan = (DateTime)(rd["VB_NgayTiepNhan"]);
            }
            if (rd.FieldExists("VB_NguoiNop"))
            {
                Item.NguoiNop = (String)(rd["VB_NguoiNop"]);
            }
            if (rd.FieldExists("VB_MCCM_NgayNhan"))
            {
                Item.MCCM_NgayNhan = (DateTime)(rd["VB_MCCM_NgayNhan"]);
            }
            if (rd.FieldExists("VB_MCCM_CQ_ID"))
            {
                Item.MCCM_CQ_ID = (Int32)(rd["VB_MCCM_CQ_ID"]);
            }
            if (rd.FieldExists("VB_MCCM_CQ_Ten"))
            {
                Item.MCCM_CQ_Ten = (String)(rd["VB_MCCM_CQ_Ten"]);
            }
            if (rd.FieldExists("VB_MCCM_MEM_ID"))
            {
                Item.MCCM_MEM_ID = (Int32)(rd["VB_MCCM_MEM_ID"]);
            }
            if (rd.FieldExists("VB_MCCM_MEM_Username"))
            {
                Item.MCCM_MEM_Username = (String)(rd["VB_MCCM_MEM_Username"]);
            }
            if (rd.FieldExists("VB_MCCM_MEM_Ten"))
            {
                Item.MCCM_MEM_Ten = (String)(rd["VB_MCCM_MEM_Ten"]);
            }
            if (rd.FieldExists("VB_CMMC_NgayNhan"))
            {
                Item.CMMC_NgayNhan = (DateTime)(rd["VB_CMMC_NgayNhan"]);
            }
            if (rd.FieldExists("VB_CMMC_MEM_ID"))
            {
                Item.CMMC_MEM_ID = (Int32)(rd["VB_CMMC_MEM_ID"]);
            }
            if (rd.FieldExists("VB_CMMC_MEM_Username"))
            {
                Item.CMMC_MEM_Username = (String)(rd["VB_CMMC_MEM_Username"]);
            }
            if (rd.FieldExists("VB_CMMC_MEM_Ten"))
            {
                Item.CMMC_MEM_Ten = (String)(rd["VB_CMMC_MEM_Ten"]);
            }
            if (rd.FieldExists("VB_MCNN_NgayTra"))
            {
                Item.MCNN_NgayTra = (DateTime)(rd["VB_MCNN_NgayTra"]);
            }
            if (rd.FieldExists("VB_MCNN_NguoiNhan"))
            {
                Item.MCNN_NguoiNhan = (String)(rd["VB_MCNN_NguoiNhan"]);
            }
            if (rd.FieldExists("VB_ThoiHan"))
            {
                Item.ThoiHan = (Int16)(rd["VB_ThoiHan"]);
            }
            if (rd.FieldExists("VB_KetQua"))
            {
                Item.KetQua = (Int16)(rd["VB_KetQua"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static VanBanBh InsertDraff(VanBanBh Inserted)
        {
            VanBanBh Item = new VanBanBh();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("VB_NgayTao", Inserted.NgayTao);
            obj[1] = new SqlParameter("VB_NguoiTao", Inserted.NguoiTao);
            obj[2] = new SqlParameter("VB_NgayCapNhat", Inserted.NgayCapNhat);
            obj[3] = new SqlParameter("VB_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanBh_Insert_InsertDraff_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static VanBanBh UpdateX(VanBanBh Updated)
        {
            VanBanBh Item = new VanBanBh();
            SqlParameter[] obj = new SqlParameter[37];
            obj[0] = new SqlParameter("VB_ID", Updated.ID);
            obj[1] = new SqlParameter("MTLList", Updated.MTLList);
            obj[2] = new SqlParameter("TLList", Updated.TLList);
            obj[3] = new SqlParameter("VB_LOAI_ID", Updated.LOAI_ID);
            obj[5] = new SqlParameter("VB_Ma", Updated.Ma);
            obj[6] = new SqlParameter("VB_NgayTiepNhan", Updated.NgayTiepNhan);
            obj[7] = new SqlParameter("VB_NgayHenTra", Updated.NgayHenTra);
            obj[8] = new SqlParameter("VB_NguoiNop", Updated.NguoiNop);
            obj[9] = new SqlParameter("VB_NoiGui", Updated.NoiGui);
            obj[10] = new SqlParameter("VB_DiaChi", Updated.DiaChi);
            obj[11] = new SqlParameter("VB_CMT", Updated.CMT);
            obj[12] = new SqlParameter("VB_NgayCap", Updated.NgayCap);
            obj[13] = new SqlParameter("VB_DienThoai", Updated.DienThoai);
            obj[14] = new SqlParameter("VB_Fax", Updated.Fax);
            obj[15] = new SqlParameter("VB_Email", Updated.Email);
            obj[16] = new SqlParameter("VB_NoiDung", Updated.NoiDung);
            obj[17] = new SqlParameter("VB_RowId", Updated.RowId);
            //obj[18] = new SqlParameter("VB_TrangThai", Updated.TrangThai);
            obj[21] = new SqlParameter("VB_NguoiCapNhat", Updated.NguoiCapNhat);
            if (Updated.NgayCapNhat.ToString().IndexOf("1/1/0001") != -1)
            {
                obj[22] = new SqlParameter("VB_NgayCapNhat",DBNull.Value);
            }
            else
            {
                obj[22] = new SqlParameter("VB_NgayCapNhat", Updated.NgayCapNhat);
            }
            obj[23] = new SqlParameter("VB_TrangThai", Updated.TrangThai);
            obj[24] = new SqlParameter("VB_MCCM_CQ_ID", Updated.MCCM_CQ_ID);
            obj[25] = new SqlParameter("VB_MCCM_CQ_Ten", Updated.MCCM_CQ_Ten);
            obj[26] = new SqlParameter("VB_MCCM_MEM_ID", Updated.MCCM_MEM_ID);
            obj[27] = new SqlParameter("VB_MCCM_MEM_Username", Updated.MCCM_MEM_Username);
            obj[28] = new SqlParameter("VB_MCCM_MEM_Ten", Updated.MCCM_MEM_Ten);
            if (Updated.CMMC_NgayNhan.ToString().IndexOf("1/1/0001") != -1)
            {
                obj[29] = new SqlParameter("VB_CMMC_NgayNhan", DBNull.Value);
            }
            else
            {
                obj[29] = new SqlParameter("VB_CMMC_NgayNhan", Updated.CMMC_NgayNhan);
            }
            obj[30] = new SqlParameter("VB_CMMC_MEM_ID", Updated.CMMC_MEM_ID);
            obj[31] = new SqlParameter("VB_CMMC_MEM_Username", Updated.CMMC_MEM_Username);
            obj[32] = new SqlParameter("VB_CMMC_MEM_Ten", Updated.CMMC_MEM_Ten);
            if (Updated.MCNN_NgayTra.ToString().IndexOf("1/1/0001") != -1)
            {
                obj[33] = new SqlParameter("VB_MCNN_NgayTra", DBNull.Value);
            }
            else
            {
                obj[33] = new SqlParameter("VB_MCNN_NgayTra", Updated.MCNN_NgayTra);
            }
            obj[34] = new SqlParameter("VB_MCNN_NguoiNhan", Updated.MCNN_NguoiNhan);
            obj[35] = new SqlParameter("VB_ThoiHan", Updated.ThoiHan);
            obj[36] = new SqlParameter("VB_KetQua", Updated.KetQua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanBh_Update_UpdateNormalX_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static string SelectTopMa(string DM_ID, string LV_ID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("LV_ID", LV_ID);
            return SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblVanBanBh_Select_TopMaValue_linhnx", obj).ToString();
        }
        #endregion
    }
    #endregion

    #endregion
}


