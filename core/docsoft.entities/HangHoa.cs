using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using linh.common;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace docsoft.entities
{
    #region HangHoa
    #region BO
    public class HangHoa : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid DM_ID { get; set; }
        public Guid GH_ID { get; set; }
        public String Lang { get; set; }
        public Guid LangBased_ID { get; set; }
        public Boolean LangBased { get; set; }
        public String Alias { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String Keywords { get; set; }
        public String Description { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public Double GNY { get; set; }
        public Double GiaNhap { get; set; }
        public Guid DonVi_ID { get; set; }
        public Double SoLuong { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public String Anh { get; set; }
        public Boolean Publish { get; set; }
        public Boolean Active { get; set; }
        public Boolean Home { get; set; }
        public Boolean Hot1 { get; set; }
        public Boolean Hot2 { get; set; }
        public Boolean Hot3 { get; set; }
        public Boolean Hot4 { get; set; }
        public Boolean Draff { get; set; }
        public Double TonDinhMuc { get; set; }
        public Boolean HetHang { get; set; }
        #endregion
        #region Contructor
        public HangHoa()
        { }
        #endregion
        #region Customs properties
        public String DM_Ten { get; set; }
        public String DonVi_Ten { get; set; }
        public List<Files> ListFiles { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return HangHoaDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class HangHoaCollection : BaseEntityCollection<HangHoa>
    { }
    #endregion
    #region Dal
    public class HangHoaDal
    {
        #region Methods

        public static void DeleteById(Guid HH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Delete_DeleteById_linhnx", obj);
        }
        public static void DeleteByMultiId(string HH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Delete_DeleteByMultiId_linhnx", obj);
        }
        public static HangHoa Insert(HangHoa item)
        {
            var Item = new HangHoa();
            var obj = new SqlParameter[33];
            obj[0] = new SqlParameter("HH_ID", item.ID);
            obj[1] = new SqlParameter("HH_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("HH_GH_ID", item.GH_ID);
            obj[3] = new SqlParameter("HH_Lang", item.Lang);
            obj[4] = new SqlParameter("HH_LangBased_ID", item.LangBased_ID);
            obj[5] = new SqlParameter("HH_LangBased", item.LangBased);
            obj[6] = new SqlParameter("HH_Alias", item.Alias);
            obj[7] = new SqlParameter("HH_Ten", item.Ten);
            obj[8] = new SqlParameter("HH_Ma", item.Ma);
            obj[9] = new SqlParameter("HH_Keywords", item.Keywords);
            obj[10] = new SqlParameter("HH_Description", item.Description);
            obj[11] = new SqlParameter("HH_MoTa", item.MoTa);
            obj[12] = new SqlParameter("HH_NoiDung", item.NoiDung);
            obj[13] = new SqlParameter("HH_GNY", item.GNY);
            obj[14] = new SqlParameter("HH_GiaNhap", item.GiaNhap);
            obj[15] = new SqlParameter("HH_DonVi_ID", item.DonVi_ID);
            obj[16] = new SqlParameter("HH_SoLuong", item.SoLuong);
            obj[17] = new SqlParameter("HH_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("HH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[18] = new SqlParameter("HH_NgayTao", DBNull.Value);
            }
            obj[19] = new SqlParameter("HH_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[20] = new SqlParameter("HH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[20] = new SqlParameter("HH_NgayCapNhat", DBNull.Value);
            }
            obj[21] = new SqlParameter("HH_NguoiCapNhat", item.NguoiCapNhat);
            obj[22] = new SqlParameter("HH_Anh", item.Anh);
            obj[23] = new SqlParameter("HH_Publish", item.Publish);
            obj[24] = new SqlParameter("HH_Active", item.Active);
            obj[25] = new SqlParameter("HH_Home", item.Home);
            obj[26] = new SqlParameter("HH_Hot1", item.Hot1);
            obj[27] = new SqlParameter("HH_Hot2", item.Hot2);
            obj[28] = new SqlParameter("HH_Hot3", item.Hot3);
            obj[29] = new SqlParameter("HH_Hot4", item.Hot4);
            obj[30] = new SqlParameter("HH_Draff", item.Draff);
            obj[31] = new SqlParameter("HH_TonDinhMuc", item.TonDinhMuc);
            obj[32] = new SqlParameter("HH_HetHang", item.HetHang);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HangHoa Update(HangHoa item)
        {
            var Item = new HangHoa();
            var obj = new SqlParameter[33];
            obj[0] = new SqlParameter("HH_ID", item.ID);
            obj[1] = new SqlParameter("HH_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("HH_GH_ID", item.GH_ID);
            obj[3] = new SqlParameter("HH_Lang", item.Lang);
            obj[4] = new SqlParameter("HH_LangBased_ID", item.LangBased_ID);
            obj[5] = new SqlParameter("HH_LangBased", item.LangBased);
            obj[6] = new SqlParameter("HH_Alias", item.Alias);
            obj[7] = new SqlParameter("HH_Ten", item.Ten);
            obj[8] = new SqlParameter("HH_Ma", item.Ma);
            obj[9] = new SqlParameter("HH_Keywords", item.Keywords);
            obj[10] = new SqlParameter("HH_Description", item.Description);
            obj[11] = new SqlParameter("HH_MoTa", item.MoTa);
            obj[12] = new SqlParameter("HH_NoiDung", item.NoiDung);
            obj[13] = new SqlParameter("HH_GNY", item.GNY);
            obj[14] = new SqlParameter("HH_GiaNhap", item.GiaNhap);
            obj[15] = new SqlParameter("HH_DonVi_ID", item.DonVi_ID);
            obj[16] = new SqlParameter("HH_SoLuong", item.SoLuong);
            obj[17] = new SqlParameter("HH_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("HH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[18] = new SqlParameter("HH_NgayTao", DBNull.Value);
            }
            obj[19] = new SqlParameter("HH_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[20] = new SqlParameter("HH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[20] = new SqlParameter("HH_NgayCapNhat", DBNull.Value);
            }
            obj[21] = new SqlParameter("HH_NguoiCapNhat", item.NguoiCapNhat);
            obj[22] = new SqlParameter("HH_Anh", item.Anh);
            obj[23] = new SqlParameter("HH_Publish", item.Publish);
            obj[24] = new SqlParameter("HH_Active", item.Active);
            obj[25] = new SqlParameter("HH_Home", item.Home);
            obj[26] = new SqlParameter("HH_Hot1", item.Hot1);
            obj[27] = new SqlParameter("HH_Hot2", item.Hot2);
            obj[28] = new SqlParameter("HH_Hot3", item.Hot3);
            obj[29] = new SqlParameter("HH_Hot4", item.Hot4);
            obj[30] = new SqlParameter("HH_Draff", item.Draff);
            obj[31] = new SqlParameter("HH_TonDinhMuc", item.TonDinhMuc);
            obj[32] = new SqlParameter("HH_HetHang", item.HetHang);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HangHoa SelectById(Guid HH_ID)
        {
            var Item = new HangHoa();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HangHoaCollection SelectAll()
        {
            var List = new HangHoaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<HangHoa> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<HangHoa>("sp_tblHangHoa_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static HangHoa getFromReader(IDataReader rd)
        {
            var Item = new HangHoa();
            if (rd.FieldExists("HH_ID"))
            {
                Item.ID = (Guid)(rd["HH_ID"]);
            }
            if (rd.FieldExists("HH_DM_ID"))
            {
                Item.DM_ID = (Guid)(rd["HH_DM_ID"]);
            }
            if (rd.FieldExists("HH_GH_ID"))
            {
                Item.GH_ID = (Guid)(rd["HH_GH_ID"]);
            }
            if (rd.FieldExists("HH_Lang"))
            {
                Item.Lang = (String)(rd["HH_Lang"]);
            }
            if (rd.FieldExists("HH_LangBased_ID"))
            {
                Item.LangBased_ID = (Guid)(rd["HH_LangBased_ID"]);
            }
            if (rd.FieldExists("HH_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["HH_LangBased"]);
            }
            if (rd.FieldExists("HH_Alias"))
            {
                Item.Alias = (String)(rd["HH_Alias"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.Ten = (String)(rd["HH_Ten"]);
            }
            if (rd.FieldExists("HH_Ma"))
            {
                Item.Ma = (String)(rd["HH_Ma"]);
            }
            if (rd.FieldExists("HH_Keywords"))
            {
                Item.Keywords = (String)(rd["HH_Keywords"]);
            }
            if (rd.FieldExists("HH_Description"))
            {
                Item.Description = (String)(rd["HH_Description"]);
            }
            if (rd.FieldExists("HH_MoTa"))
            {
                Item.MoTa = (String)(rd["HH_MoTa"]);
            }
            if (rd.FieldExists("HH_NoiDung"))
            {
                Item.NoiDung = (String)(rd["HH_NoiDung"]);
            }
            if (rd.FieldExists("HH_GNY"))
            {
                Item.GNY = (Double)(rd["HH_GNY"]);
            }
            if (rd.FieldExists("HH_GiaNhap"))
            {
                Item.GiaNhap = (Double)(rd["HH_GiaNhap"]);
            }
            if (rd.FieldExists("HH_DonVi_ID"))
            {
                Item.DonVi_ID = (Guid)(rd["HH_DonVi_ID"]);
            }
            if (rd.FieldExists("HH_SoLuong"))
            {
                Item.SoLuong = (Double)(rd["HH_SoLuong"]);
            }
            if (rd.FieldExists("HH_RowId"))
            {
                Item.RowId = (Guid)(rd["HH_RowId"]);
            }
            if (rd.FieldExists("HH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["HH_NgayTao"]);
            }
            if (rd.FieldExists("HH_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["HH_NguoiTao"]);
            }
            if (rd.FieldExists("HH_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["HH_NgayCapNhat"]);
            }
            if (rd.FieldExists("HH_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["HH_NguoiCapNhat"]);
            }
            if (rd.FieldExists("HH_Anh"))
            {
                Item.Anh = (String)(rd["HH_Anh"]);
            }
            if (rd.FieldExists("HH_Publish"))
            {
                Item.Publish = (Boolean)(rd["HH_Publish"]);
            }
            if (rd.FieldExists("HH_Active"))
            {
                Item.Active = (Boolean)(rd["HH_Active"]);
            }
            if (rd.FieldExists("HH_Home"))
            {
                Item.Home = (Boolean)(rd["HH_Home"]);
            }
            if (rd.FieldExists("HH_Hot1"))
            {
                Item.Hot1 = (Boolean)(rd["HH_Hot1"]);
            }
            if (rd.FieldExists("HH_Hot2"))
            {
                Item.Hot2 = (Boolean)(rd["HH_Hot2"]);
            }
            if (rd.FieldExists("HH_Hot3"))
            {
                Item.Hot3 = (Boolean)(rd["HH_Hot3"]);
            }
            if (rd.FieldExists("HH_Hot4"))
            {
                Item.Hot4 = (Boolean)(rd["HH_Hot4"]);
            }
            if (rd.FieldExists("HH_Draff"))
            {
                Item.Draff = (Boolean)(rd["HH_Draff"]);
            }
            if (rd.FieldExists("HH_TonDinhMuc"))
            {
                Item.TonDinhMuc = (Double)(rd["HH_TonDinhMuc"]);
            }
            if (rd.FieldExists("HH_HetHang"))
            {
                Item.HetHang = (Boolean)(rd["HH_HetHang"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("DonVi_Ten"))
            {
                Item.DonVi_Ten = (String)(rd["DonVi_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<HangHoa> ByDm(string url, bool rewrite, string sort, string q, int size, string DM_ID)
        {
            var obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            var pg = new Pager<HangHoa>("sp_tblHangHoa_Pager_ByDm_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<HangHoa> ByDmMa(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string DM_Ma)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_Ma))
            {
                obj[2] = new SqlParameter("DM_Ma", DM_Ma);
            }
            else
            {
                obj[2] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            var pg = new Pager<HangHoa>(con, "sp_tblHangHoa_Pager_ByDmMa_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static HangHoaCollection SelectTopByDmMa(string DM_Ma, string Top)
        {
            var list = new HangHoaCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            if (!string.IsNullOrEmpty(DM_Ma))
            {
                obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            }
            else
            {
                obj[1] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTopByDmMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static HangHoaCollection SelectTopByDmMa(string DM_Ma, string Top, SqlConnection con)
        {
            var list = new HangHoaCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            if (!string.IsNullOrEmpty(DM_Ma))
            {
                obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            }
            else
            {
                obj[1] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTopByDmMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static HangHoaCollection SelectTopLienQuan(string ID, string Top)
        {
            var list = new HangHoaCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            if (!string.IsNullOrEmpty(ID))
            {
                obj[1] = new SqlParameter("ID", ID);
            }
            else
            {
                obj[1] = new SqlParameter("ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTopLienQuan_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static HangHoaCollection SelectTopLienQuan(string ID, string Top, SqlConnection con)
        {
            var list = new HangHoaCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            if (!string.IsNullOrEmpty(ID))
            {
                obj[1] = new SqlParameter("ID", ID);
            }
            else
            {
                obj[1] = new SqlParameter("ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTopLienQuan_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }

        public static HangHoaCollection SelectTopHot1(SqlConnection con, string Top)
        {
            var list = new HangHoaCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTopHot1_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static HangHoaCollection SelectTopHot2(SqlConnection con, string Top)
        {
            var list = new HangHoaCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTopHot2_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static HangHoaCollection SelectTopHot3(SqlConnection con, string Top)
        {
            var list = new HangHoaCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTopHot3_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static HangHoaCollection SelectTopHot(SqlConnection con, string Top)
        {
            var list = new HangHoaCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTopHot_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        #endregion

        #region format
        public static string FormatHangHoaMoi(HangHoa item, string css, string domain)
        {
            var c = HttpContext.Current;
            var sb = new StringBuilder();
            sb.AppendFormat(@"
<div class=""{6}"">
    <a title=""{5}"" href=""{0}/Products/{1}/{2}/{3}.html"" class=""hh-anh-box"">
        <img src=""{0}/lib/up/i/{4}"" alt=""{5}"" class=""hh-anh"" />
    </a>
    <a href=""javascript:;"" class=""buybtn"" _id=""{3}"">Mua hàng</a>
    <a title=""{5}"" href=""{0}/Products/{1}/{2}/{3}.html"" class=""hh-ten"">
    {5}
    </a>
</div>
", domain, Lib.Bodau(item.DM_Ten)
 ,Lib.Bodau(item.Ten),item.ID
 , Lib.imgSize(item.Anh, "326")
 ,item.Ten
 ,css
 );
            return sb.ToString();
        }
        public static string FormatChiTiet(HangHoa item, string css, string domain)
        {
            var c = HttpContext.Current;
            var sb = new StringBuilder();
            sb.AppendFormat(@"
<div class=""hh-item-view"">
    <div class=""hh-anh-pnl"">
        <a href=""{0}/lib/up/i/{5}"" class=""hh-anh-box"">
            <img src=""{0}/lib/up/i/{5}"" class=""hh-anh""/>
        </a>
        <a href=""#"" class=""hh-anh-box-small"">
            <img src="""" class=""hh-anh-small""/>
        </a>
    </div>
    <div class=""hh-content-box"">
        <h1 class=""hh-ten"">{6}</h1>
        <div class=""hh-mota"">{7}</div>
        <div class=""hh-tools"">
            <a href=""javascript:;""  _id=""{3}"" class=""buybtn"">Đặt hàng</a>
            <span class=""hh-label"">Số lượng:</span>
            <span class=""hh-soLuong"">{9}</span>
            <span class=""hh-donVi"">{10}</span>
        </div>               
        <div class=""hh-noiDung-title"">Chi tiết</div>
        <div class=""hh-noiDung"">{8}</div>
    </div>    
</div>
", domain
 , Lib.Bodau(item.DM_Ten)
 , Lib.Bodau(item.Ten)
 , item.ID
 , Lib.imgSize(item.Anh, "180x240")
 , Lib.imgSize(item.Anh, "full")
 , item.Ten
 , item.MoTa
 , item.NoiDung
 , item.SoLuong
 , item.DonVi_Ten
 );
            return sb.ToString();
        }
        #endregion
    }
    #endregion

    #endregion
}
