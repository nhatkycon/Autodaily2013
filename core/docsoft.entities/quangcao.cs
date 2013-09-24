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
using linh.common;

namespace docsoft.entities
{
    #region QuangCao
  
    #region BO
    public class QuangCao : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Anh { get; set; }
        public String Url { get; set; }
        public Int32 ThuTu { get; set; }
        public Guid RowId { get; set; }
        public Int32 TrangQuangCao { get; set; }
        public String TrangQuangCao_Ten { get; set; }
        public Guid ViTri { get; set; }
        public String ViTri_Ten { get; set; }
        public Boolean Active { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayHetHan { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayDangKy { get; set; }
        public String TenDonVi { get; set; }
        public String DiaChiDonVi { get; set; }
        public String NguoiLienHe { get; set; }
        public String Email { get; set; }
        public String DienThoai { get; set; }
        public Double SoTienThanhToan { get; set; }

        #endregion
        #region Contructor
        public QuangCao()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return QuangCaoDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class QuangCaoCollection : BaseEntityCollection<QuangCao>
    { }
    #endregion
    #region Dal
    public class QuangCaoDal
    {

        #region Methods HoangDA

        public static void DeleteByIdHoangDA(Int32 ADV_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ADV_ID", ADV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Delete_DeleteById_hoangda", obj);
        }

        public static QuangCao InsertHoangDA(QuangCao Inserted)
        {
            QuangCao Item = new QuangCao();
            SqlParameter[] obj = new SqlParameter[21];
            obj[0] = new SqlParameter("ADV_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("ADV_Anh", Inserted.Anh);
            obj[2] = new SqlParameter("ADV_Url", Inserted.Url);
            obj[3] = new SqlParameter("ADV_ThuTu", Inserted.ThuTu);
            obj[4] = new SqlParameter("ADV_RowId", Inserted.RowId);
            obj[5] = new SqlParameter("ADV_TrangQuangCao", Inserted.TrangQuangCao);
            obj[6] = new SqlParameter("ADV_TrangQuangCao_Ten", Inserted.TrangQuangCao_Ten);
            obj[7] = new SqlParameter("ADV_ViTri", Inserted.ViTri);
            obj[8] = new SqlParameter("ADV_ViTri_Ten", Inserted.ViTri_Ten);
            obj[9] = new SqlParameter("ADV_Active", Inserted.Active);
            obj[10] = new SqlParameter("ADV_NgayTao", Inserted.NgayTao);
            obj[11] = new SqlParameter("ADV_NgayHetHan", Inserted.NgayHetHan);
            obj[12] = new SqlParameter("ADV_NgayCapNhat", Inserted.NgayCapNhat);
            obj[13] = new SqlParameter("ADV_NguoiTao", Inserted.NguoiTao);
            obj[14] = new SqlParameter("ADV_NgayDangKy", Inserted.NgayDangKy);
            obj[15] = new SqlParameter("ADV_TenDonVi", Inserted.TenDonVi);
            obj[16] = new SqlParameter("ADV_DiaChiDonVi", Inserted.DiaChiDonVi);
            obj[17] = new SqlParameter("ADV_NguoiLienHe", Inserted.NguoiLienHe);
            obj[18] = new SqlParameter("ADV_Email", Inserted.Email);
            obj[19] = new SqlParameter("ADV_DienThoai", Inserted.DienThoai);
            obj[20] = new SqlParameter("ADV_SoTienThanhToan", Inserted.SoTienThanhToan);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuangCao UpdateHoangDA(QuangCao Updated)
        {
            QuangCao Item = new QuangCao();
            SqlParameter[] obj = new SqlParameter[22];
            obj[0] = new SqlParameter("ADV_ID", Updated.ID);
            obj[1] = new SqlParameter("ADV_Ten", Updated.Ten);
            obj[2] = new SqlParameter("ADV_Anh", Updated.Anh);
            obj[3] = new SqlParameter("ADV_Url", Updated.Url);
            obj[4] = new SqlParameter("ADV_ThuTu", Updated.ThuTu);
            obj[5] = new SqlParameter("ADV_RowId", Updated.RowId);
            obj[6] = new SqlParameter("ADV_TrangQuangCao", Updated.TrangQuangCao);
            obj[7] = new SqlParameter("ADV_TrangQuangCao_Ten", Updated.TrangQuangCao_Ten);
            obj[8] = new SqlParameter("ADV_ViTri", Updated.ViTri);
            obj[9] = new SqlParameter("ADV_ViTri_Ten", Updated.ViTri_Ten);
            obj[10] = new SqlParameter("ADV_Active", Updated.Active);
            obj[11] = new SqlParameter("ADV_NgayTao", Updated.NgayTao);
            obj[12] = new SqlParameter("ADV_NgayHetHan", Updated.NgayHetHan);
            obj[13] = new SqlParameter("ADV_NgayCapNhat", Updated.NgayCapNhat);
            obj[14] = new SqlParameter("ADV_NguoiTao", Updated.NguoiTao);
            obj[15] = new SqlParameter("ADV_NgayDangKy", Updated.NgayDangKy);
            obj[16] = new SqlParameter("ADV_TenDonVi", Updated.TenDonVi);
            obj[17] = new SqlParameter("ADV_DiaChiDonVi", Updated.DiaChiDonVi);
            obj[18] = new SqlParameter("ADV_NguoiLienHe", Updated.NguoiLienHe);
            obj[19] = new SqlParameter("ADV_Email", Updated.Email);
            obj[20] = new SqlParameter("ADV_DienThoai", Updated.DienThoai);
            obj[21] = new SqlParameter("ADV_SoTienThanhToan", Updated.SoTienThanhToan);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuangCao SelectByIdHoangDA(Int32 ADV_ID)
        {
            QuangCao Item = new QuangCao();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ADV_ID", ADV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuangCaoCollection SelectAllHoangDA()
        {
            QuangCaoCollection List = new QuangCaoCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<QuangCao> pagerNormalHoangDA(string url, bool rewrite, string sort, string q, int size)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            Pager<QuangCao> pg = new Pager<QuangCao>("sp_tblQuangCao_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion         


        #region Methods

        public static void DeleteById(Int32 ADV_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ADV_ID", ADV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Delete_DeleteById_linhnx", obj);
        }

        public static QuangCao Insert(QuangCao Inserted)
        {
            QuangCao Item = new QuangCao();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("ADV_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("ADV_Anh", Inserted.Anh);
            obj[2] = new SqlParameter("ADV_Url", Inserted.Url);
            obj[3] = new SqlParameter("ADV_ThuTu", Inserted.ThuTu);
            obj[4] = new SqlParameter("ADV_RowId", Inserted.RowId);
            obj[5] = new SqlParameter("ADV_Active", Inserted.Active);
            obj[6] = new SqlParameter("ADV_ViTri", Inserted.ViTri);
            obj[7] = new SqlParameter("ADV_ViTri_Ten", Inserted.ViTri_Ten);
            obj[8] = new SqlParameter("TrangQuangCao_Ten", Inserted.TrangQuangCao_Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuangCao Update(QuangCao Updated)
        {
            QuangCao Item = new QuangCao();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("ADV_ID", Updated.ID);
            obj[1] = new SqlParameter("ADV_Ten", Updated.Ten);
            obj[2] = new SqlParameter("ADV_Anh", Updated.Anh);
            obj[3] = new SqlParameter("ADV_Url", Updated.Url);
            obj[4] = new SqlParameter("ADV_ThuTu", Updated.ThuTu);
            obj[5] = new SqlParameter("ADV_RowId", Updated.RowId);
            obj[6] = new SqlParameter("ADV_Active", Updated.Active);
            obj[7] = new SqlParameter("ADV_ViTri", Updated.ViTri);
            obj[8] = new SqlParameter("ADV_ViTri_Ten", Updated.ViTri_Ten);
            obj[9] = new SqlParameter("TrangQuangCao_Ten", Updated.TrangQuangCao_Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuangCao SelectById(Int32 ADV_ID)
        {
            QuangCao Item = new QuangCao();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ADV_ID", ADV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuangCaoCollection SelectAll()
        {
            QuangCaoCollection List = new QuangCaoCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<QuangCao> pagerNormal(string url, bool rewrite, string sort, string q, string dm)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            Pager<QuangCao> pg = new Pager<QuangCao>("sp_tblQuangCao_Pager_Normal_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static QuangCao getFromReader(IDataReader rd)
        {
            QuangCao Item = new QuangCao();
            if (rd.FieldExists("ADV_ID"))
            {
                Item.ID = (Int32)(rd["ADV_ID"]);
            }
            if (rd.FieldExists("ADV_Ten"))
            {
                Item.Ten = (String)(rd["ADV_Ten"]);
            }
            if (rd.FieldExists("ADV_Anh"))
            {
                Item.Anh = (String)(rd["ADV_Anh"]);
            }
            if (rd.FieldExists("ADV_Url"))
            {
                Item.Url = (String)(rd["ADV_Url"]);
            }
            if (rd.FieldExists("ADV_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["ADV_ThuTu"]);
            }
            if (rd.FieldExists("ADV_RowId"))
            {
                Item.RowId = (Guid)(rd["ADV_RowId"]);
            }
            if (rd.FieldExists("ADV_TrangQuangCao"))
            {
                Item.TrangQuangCao = (Int32)(rd["ADV_TrangQuangCao"]);
            }
            if (rd.FieldExists("ADV_TrangQuangCao_Ten"))
            {
                Item.TrangQuangCao_Ten = (String)(rd["ADV_TrangQuangCao_Ten"]);
            }
            if (rd.FieldExists("ADV_ViTri"))
            {
                Item.ViTri = (Guid)(rd["ADV_ViTri"]);
            }
            if (rd.FieldExists("ADV_ViTri_Ten"))
            {
                Item.ViTri_Ten = (String)(rd["ADV_ViTri_Ten"]);
            }
            if (rd.FieldExists("ADV_Active"))
            {
                Item.Active = (Boolean)(rd["ADV_Active"]);
            }
            if (rd.FieldExists("ADV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["ADV_NgayTao"]);
            }
            if (rd.FieldExists("ADV_NgayHetHan"))
            {
                Item.NgayHetHan = (DateTime)(rd["ADV_NgayHetHan"]);
            }
            if (rd.FieldExists("ADV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["ADV_NgayCapNhat"]);
            }
            if (rd.FieldExists("ADV_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["ADV_NguoiTao"]);
            }
            if (rd.FieldExists("ADV_NgayDangKy"))
            {
                Item.NgayDangKy = (DateTime)(rd["ADV_NgayDangKy"]);
            }
            if (rd.FieldExists("ADV_TenDonVi"))
            {
                Item.TenDonVi = (String)(rd["ADV_TenDonVi"]);
            }
            if (rd.FieldExists("ADV_DiaChiDonVi"))
            {
                Item.DiaChiDonVi = (String)(rd["ADV_DiaChiDonVi"]);
            }
            if (rd.FieldExists("ADV_NguoiLienHe"))
            {
                Item.NguoiLienHe = (String)(rd["ADV_NguoiLienHe"]);
            }
            if (rd.FieldExists("ADV_Email"))
            {
                Item.Email = (String)(rd["ADV_Email"]);
            }
            if (rd.FieldExists("ADV_DienThoai"))
            {
                Item.DienThoai = (String)(rd["ADV_DienThoai"]);
            }
            if (rd.FieldExists("ADV_SoTienThanhToan"))
            {
                Item.SoTienThanhToan = (Double)(rd["ADV_SoTienThanhToan"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteMultiById(String ADV_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ADV_ID", ADV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Delete_DeleteMultiById_hungpm", obj);
        }
        public static void UpdateMulti(String ADV_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ADV_ID", ADV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Update_UpdateMultiById_hungpm", obj);
        }
        public static QuangCaoCollection SelectByDanhMuc(string DM_Ma, int Top)
        {
            QuangCaoCollection List = new QuangCaoCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuangCao_Select_SelectByDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static QuangCaoCollection SelectByDanhMuc(SqlConnection con, string DM_Ma, int Top)
        {
            QuangCaoCollection List = new QuangCaoCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblQuangCao_Select_SelectByDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static string formatAdvChiTietKieu1(QuangCao item, string domain)
        {
            StringBuilder sb = new StringBuilder();
            bool isFull = string.IsNullOrEmpty(item.TrangQuangCao_Ten);
            sb.AppendFormat(@"<div class=""{0}"">
{3}{2}{1}
</div>", isFull ? "adv-item-chiTietBig1" : "adv-item-chiTietTiny1"
       , isFull ? "" : string.Format(@"<span class=""adv-item-mota"">{2}</span><a href=""{0}"" class=""adv-item-url"">{0}</a>", item.Url, item.Ten, item.TrangQuangCao_Ten)
       , string.IsNullOrEmpty(item.Anh) ? "" : string.Format(@"<a href=""{2}"" class=""adv-item-img-box""><img class=""adv-item-img"" src=""{0}lib/up/i/{1}""/></a>", domain, isFull ? item.Anh : Lib.imgSize(item.Anh, "100x100"), item.Url)
       , isFull ? "" : string.Format(@"<a class=""adv-item-ten"" href=""{0}"">{1}</a>", item.Url, item.Ten, item.TrangQuangCao_Ten)
       );
            return sb.ToString();
        }
        #endregion
    }
    #endregion

    #endregion
}
