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
    #region Be
    #region BO
    public class Be : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Nick { get; set; }
        public String Ten { get; set; }
        public String Ho { get; set; }
        public String Alias { get; set; }
        public Boolean GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayMangThai { get; set; }
        public DateTime NgayDuSinh { get; set; }
        public DateTime NgayKinhCuoi { get; set; }
        public Boolean MangThai { get; set; }
        public String Anh { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String Username { get; set; }
        public Boolean Khoa { get; set; }
        public Boolean KhongChiaSe { get; set; }
        public Int32 CanNangKhiSinh { get; set; }
        public Int32 LuotXem { get; set; }
        public Int32 LuotThich { get; set; }
        public String Cover { get; set; }
        public String CoverCss { get; set; }
        #endregion
        #region Contructor
        public Be()
        { }
        #endregion
        #region Customs properties

        public bool Thich { get; set; }
        public List<CapNhat> CapNhats { get; set; }
        public List<GiaDinh> GiaDinhs { get; set; }
        public List<LoiChuc> LoiChucs { get; set; }
        public int Thang { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BeDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BeCollection : BaseEntityCollection<Be>
    { }
    #endregion
    #region Dal
    public class BeDal
    {
        #region Methods

        public static void DeleteById(Guid B_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("B_ID", B_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBe_Delete_DeleteById_linhnx", obj);
        }

        public static Be Insert(Be item)
        {
            var Item = new Be();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("B_ID", item.ID);
            obj[1] = new SqlParameter("B_Nick", item.Nick);
            obj[2] = new SqlParameter("B_Ten", item.Ten);
            obj[3] = new SqlParameter("B_Ho", item.Ho);
            obj[4] = new SqlParameter("B_Alias", item.Alias);
            obj[5] = new SqlParameter("B_GioiTinh", item.GioiTinh);
            if (item.NgaySinh > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("B_NgaySinh", item.NgaySinh);
            }
            else
            {
                obj[6] = new SqlParameter("B_NgaySinh", DBNull.Value);
            }
            if (item.NgayMangThai > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("B_NgayMangThai", item.NgayMangThai);
            }
            else
            {
                obj[7] = new SqlParameter("B_NgayMangThai", DBNull.Value);
            }
            if (item.NgayDuSinh > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("B_NgayDuSinh", item.NgayDuSinh);
            }
            else
            {
                obj[8] = new SqlParameter("B_NgayDuSinh", DBNull.Value);
            }
            if (item.NgayKinhCuoi > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("B_NgayKinhCuoi", item.NgayKinhCuoi);
            }
            else
            {
                obj[9] = new SqlParameter("B_NgayKinhCuoi", DBNull.Value);
            }
            obj[10] = new SqlParameter("B_MangThai", item.MangThai);
            obj[11] = new SqlParameter("B_Anh", item.Anh);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("B_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("B_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("B_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("B_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("B_Username", item.Username);
            obj[15] = new SqlParameter("B_Khoa", item.Khoa);
            obj[16] = new SqlParameter("B_KhongChiaSe", item.KhongChiaSe);
            obj[17] = new SqlParameter("B_CanNangKhiSinh", item.CanNangKhiSinh);
            obj[18] = new SqlParameter("B_LuotXem", item.LuotXem);
            obj[19] = new SqlParameter("B_LuotThich", item.LuotThich);
            obj[20] = new SqlParameter("B_Cover", item.Cover);
            obj[21] = new SqlParameter("B_CoverCss", item.CoverCss);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBe_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Be Update(Be item)
        {
            var Item = new Be();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("B_ID", item.ID);
            obj[1] = new SqlParameter("B_Nick", item.Nick);
            obj[2] = new SqlParameter("B_Ten", item.Ten);
            obj[3] = new SqlParameter("B_Ho", item.Ho);
            obj[4] = new SqlParameter("B_Alias", item.Alias);
            obj[5] = new SqlParameter("B_GioiTinh", item.GioiTinh);
            if (item.NgaySinh > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("B_NgaySinh", item.NgaySinh);
            }
            else
            {
                obj[6] = new SqlParameter("B_NgaySinh", DBNull.Value);
            }
            if (item.NgayMangThai > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("B_NgayMangThai", item.NgayMangThai);
            }
            else
            {
                obj[7] = new SqlParameter("B_NgayMangThai", DBNull.Value);
            }
            if (item.NgayDuSinh > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("B_NgayDuSinh", item.NgayDuSinh);
            }
            else
            {
                obj[8] = new SqlParameter("B_NgayDuSinh", DBNull.Value);
            }
            if (item.NgayKinhCuoi > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("B_NgayKinhCuoi", item.NgayKinhCuoi);
            }
            else
            {
                obj[9] = new SqlParameter("B_NgayKinhCuoi", DBNull.Value);
            }
            obj[10] = new SqlParameter("B_MangThai", item.MangThai);
            obj[11] = new SqlParameter("B_Anh", item.Anh);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("B_NgayTao", item.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("B_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("B_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("B_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("B_Username", item.Username);
            obj[15] = new SqlParameter("B_Khoa", item.Khoa);
            obj[16] = new SqlParameter("B_KhongChiaSe", item.KhongChiaSe);
            obj[17] = new SqlParameter("B_CanNangKhiSinh", item.CanNangKhiSinh);
            obj[18] = new SqlParameter("B_LuotXem", item.LuotXem);
            obj[19] = new SqlParameter("B_LuotThich", item.LuotThich);
            obj[20] = new SqlParameter("B_Cover", item.Cover);
            obj[21] = new SqlParameter("B_CoverCss", item.CoverCss);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBe_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Be SelectById(Guid B_ID)
        {
            return SelectById(DAL.con(), B_ID);
        }
        public static Be SelectById(SqlConnection con, Guid B_ID)
        {
            var Item = new Be();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("B_ID", B_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBe_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Be SelectById(SqlConnection con, Guid B_ID, string Username)
        {
            var Item = new Be();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("B_ID", B_ID);
            obj[1] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBe_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static BeCollection SelectAll()
        {
            var List = new BeCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBe_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Be> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Be>("sp_tblBe_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Be getFromReader(IDataReader rd)
        {
            var Item = new Be();
            if (rd.FieldExists("B_ID"))
            {
                Item.ID = (Guid)(rd["B_ID"]);
            }
            if (rd.FieldExists("B_Nick"))
            {
                Item.Nick = (String)(rd["B_Nick"]);
            }
            if (rd.FieldExists("B_Ten"))
            {
                Item.Ten = (String)(rd["B_Ten"]);
            }
            if (rd.FieldExists("B_Ho"))
            {
                Item.Ho = (String)(rd["B_Ho"]);
            }
            if (rd.FieldExists("B_Alias"))
            {
                Item.Alias = (String)(rd["B_Alias"]);
            }
            if (rd.FieldExists("B_GioiTinh"))
            {
                Item.GioiTinh = (Boolean)(rd["B_GioiTinh"]);
            }
            if (rd.FieldExists("B_NgaySinh"))
            {
                Item.NgaySinh = (DateTime)(rd["B_NgaySinh"]);
            }
            if (rd.FieldExists("B_NgayMangThai"))
            {
                Item.NgayMangThai = (DateTime)(rd["B_NgayMangThai"]);
            }
            if (rd.FieldExists("B_NgayDuSinh"))
            {
                Item.NgayDuSinh = (DateTime)(rd["B_NgayDuSinh"]);
            }
            if (rd.FieldExists("B_NgayKinhCuoi"))
            {
                Item.NgayKinhCuoi = (DateTime)(rd["B_NgayKinhCuoi"]);
            }
            if (rd.FieldExists("B_MangThai"))
            {
                Item.MangThai = (Boolean)(rd["B_MangThai"]);
            }
            if (rd.FieldExists("B_Anh"))
            {
                Item.Anh = (String)(rd["B_Anh"]);
            }
            if (rd.FieldExists("B_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["B_NgayTao"]);
            }
            if (rd.FieldExists("B_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["B_NgayCapNhat"]);
            }
            if (rd.FieldExists("B_Username"))
            {
                Item.Username = (String)(rd["B_Username"]);
            }
            if (rd.FieldExists("B_Cover"))
            {
                Item.Cover = (String)(rd["B_Cover"]);
            }
            if (rd.FieldExists("B_Khoa"))
            {
                Item.Khoa = (Boolean)(rd["B_Khoa"]);
            }
            if (rd.FieldExists("B_KhongChiaSe"))
            {
                Item.KhongChiaSe = (Boolean)(rd["B_KhongChiaSe"]);
            }
            if (rd.FieldExists("B_CanNangKhiSinh"))
            {
                Item.CanNangKhiSinh = (Int32)(rd["B_CanNangKhiSinh"]);
            }
            if (rd.FieldExists("B_LuotXem"))
            {
                Item.LuotXem = (Int32)(rd["B_LuotXem"]);
            }
            if (rd.FieldExists("B_LuotThich"))
            {
                Item.LuotThich = (Int32)(rd["B_LuotThich"]);
            }
            if (rd.FieldExists("B_Thang"))
            {
                Item.Thang = (Int32)(rd["B_Thang"]);
            }
            if (rd.FieldExists("B_Thich"))
            {
                Item.Thich = (Boolean)(rd["B_Thich"]);
            }
            if (rd.FieldExists("B_CoverCss"))
            {
                Item.CoverCss = (String)(rd["B_CoverCss"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<Be> beYeuThichByUser(string url, bool rewrite, string Sort, string Username, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            if (!string.IsNullOrEmpty(Sort))
            {
                obj[1] = new SqlParameter("Sort", Sort);
            }
            else
            {
                obj[1] = new SqlParameter("Sort", DBNull.Value);
            }

            var pg = new Pager<Be>("sp_tblBe_Pager_beYeuThichByUser_linhnx", "pgBe", size, 10, rewrite, url, obj);
            return pg;
        }
        public static BeCollection ByUser(SqlConnection con, string Username, int Top)
        {
            var List = new BeCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBe_Select_ByUser_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static BeCollection Search(SqlConnection con, string q, int Top)
        {
            var List = new BeCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("q", q);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBe_Select_TimKiemBe", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Be SelectByNick(SqlConnection con, string Nick, string Username)
        {
            var Item = new Be();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Nick", Nick);
            obj[1] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBe_Select_SelectByNick_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static BeCollection CungTuoi(SqlConnection con, string B_ID, int Top)
        {
            var List = new BeCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("B_ID", B_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBe_Select_CungTuoi_linhnx", obj))
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

    #region Thich
    #region BO
    public class Thich : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid P_ID { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public Thich()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThichDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThichCollection : BaseEntityCollection<Thich>
    { }
    #endregion
    #region Dal
    public class ThichDal
    {
        #region Methods

        public static void DeleteById(Guid T_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Delete_DeleteById_linhnx", obj);
        }

        public static Thich Insert(Thich item)
        {
            var Item = new Thich();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("T_ID", item.ID);
            obj[1] = new SqlParameter("T_P_ID", item.P_ID);
            obj[2] = new SqlParameter("T_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("T_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("T_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Thich Update(Thich item)
        {
            var Item = new Thich();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("T_ID", item.ID);
            obj[1] = new SqlParameter("T_P_ID", item.P_ID);
            obj[2] = new SqlParameter("T_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("T_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("T_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Thich SelectById(Guid T_ID)
        {
            var Item = new Thich();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("T_ID", T_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThichCollection SelectAll()
        {
            var List = new ThichCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Thich> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Thich>("sp_tblThich_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Thich getFromReader(IDataReader rd)
        {
            var Item = new Thich();
            if (rd.FieldExists("T_ID"))
            {
                Item.ID = (Guid)(rd["T_ID"]);
            }
            if (rd.FieldExists("T_P_ID"))
            {
                Item.P_ID = (Guid)(rd["T_P_ID"]);
            }
            if (rd.FieldExists("T_Username"))
            {
                Item.Username = (String)(rd["T_Username"]);
            }
            if (rd.FieldExists("T_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["T_NgayTao"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteByPIdUsername(Guid P_ID,string Username)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("P_ID", P_ID);
            obj[1] = new SqlParameter("Username", Username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThich_Delete_DeleteByPIdUsername_linhnx", obj);
        }
        #endregion
    }
    #endregion
    #endregion

    #region GiaDinh
    #region BO
    public class GiaDinh : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid P_ID { get; set; }
        public String Ten { get; set; }
        public String Email { get; set; }
        public String Anh { get; set; }
        public Guid LOAI_ID { get; set; }
        public Int32 ThuTu { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String refUsername { get; set; }
        public String NoiDung { get; set; }
        #endregion
        #region Contructor
        public GiaDinh()
        { }
        #endregion
        #region Customs properties

        public string LOAI_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return GiaDinhDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class GiaDinhCollection : BaseEntityCollection<GiaDinh>
    { }
    #endregion
    #region Dal
    public class GiaDinhDal
    {
        #region Methods

        public static void DeleteById(Guid GD_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GD_ID", GD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaDinh_Delete_DeleteById_linhnx", obj);
        }

        public static GiaDinh Insert(GiaDinh item)
        {
            var Item = new GiaDinh();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("GD_ID", item.ID);
            obj[1] = new SqlParameter("GD_P_ID", item.P_ID);
            obj[2] = new SqlParameter("GD_Ten", item.Ten);
            obj[3] = new SqlParameter("GD_Email", item.Email);
            obj[4] = new SqlParameter("GD_Anh", item.Anh);
            obj[5] = new SqlParameter("GD_LOAI_ID", item.LOAI_ID);
            obj[6] = new SqlParameter("GD_ThuTu", item.ThuTu);
            obj[7] = new SqlParameter("GD_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("GD_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("GD_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("GD_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[9] = new SqlParameter("GD_NgayCapNhat", DBNull.Value);
            }
            obj[10] = new SqlParameter("GD_refUsername", item.refUsername);
            obj[11] = new SqlParameter("GD_NoiDung", item.NoiDung);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaDinh_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GiaDinh Update(GiaDinh item)
        {
            var Item = new GiaDinh();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("GD_ID", item.ID);
            obj[1] = new SqlParameter("GD_P_ID", item.P_ID);
            obj[2] = new SqlParameter("GD_Ten", item.Ten);
            obj[3] = new SqlParameter("GD_Email", item.Email);
            obj[4] = new SqlParameter("GD_Anh", item.Anh);
            obj[5] = new SqlParameter("GD_LOAI_ID", item.LOAI_ID);
            obj[6] = new SqlParameter("GD_ThuTu", item.ThuTu);
            obj[7] = new SqlParameter("GD_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("GD_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("GD_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("GD_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[9] = new SqlParameter("GD_NgayCapNhat", DBNull.Value);
            }
            obj[10] = new SqlParameter("GD_refUsername", item.refUsername);
            obj[11] = new SqlParameter("GD_NoiDung", item.NoiDung);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaDinh_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GiaDinh SelectById(Guid GD_ID)
        {
            var Item = new GiaDinh();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GD_ID", GD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaDinh_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GiaDinhCollection SelectAll()
        {
            var List = new GiaDinhCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaDinh_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<GiaDinh> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<GiaDinh>("sp_tblGiaDinh_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static GiaDinh getFromReader(IDataReader rd)
        {
            var Item = new GiaDinh();
            if (rd.FieldExists("GD_ID"))
            {
                Item.ID = (Guid)(rd["GD_ID"]);
            }
            if (rd.FieldExists("GD_P_ID"))
            {
                Item.P_ID = (Guid)(rd["GD_P_ID"]);
            }
            if (rd.FieldExists("GD_Ten"))
            {
                Item.Ten = (String)(rd["GD_Ten"]);
            }
            if (rd.FieldExists("GD_Email"))
            {
                Item.Email = (String)(rd["GD_Email"]);
            }
            if (rd.FieldExists("GD_Anh"))
            {
                Item.Anh = (String)(rd["GD_Anh"]);
            }
            if (rd.FieldExists("GD_LOAI_ID"))
            {
                Item.LOAI_ID = (Guid)(rd["GD_LOAI_ID"]);
            }
            if (rd.FieldExists("GD_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["GD_ThuTu"]);
            }
            if (rd.FieldExists("GD_Username"))
            {
                Item.Username = (String)(rd["GD_Username"]);
            }
            if (rd.FieldExists("GD_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["GD_NgayTao"]);
            }
            if (rd.FieldExists("GD_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["GD_NgayCapNhat"]);
            }
            if (rd.FieldExists("GD_refUsername"))
            {
                Item.refUsername = (String)(rd["GD_refUsername"]);
            }
            if (rd.FieldExists("GD_NoiDung"))
            {
                Item.NoiDung = (String)(rd["GD_NoiDung"]);
            }
            if (rd.FieldExists("GD_LOAI_Ten"))
            {
                Item.LOAI_Ten = (String)(rd["GD_LOAI_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static GiaDinhCollection SelectByPid(SqlConnection con,string P_ID, int Top)
        {
            var List = new GiaDinhCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("P_ID", P_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblGiaDinh_Select_SelectByPid_linhnx", obj))
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


    #region CapNhat
    #region BO
    public class CapNhat : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid P_ID { get; set; }
        public Int32 Loai { get; set; }
        public String Ten { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public String Username { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Boolean Thich { get; set; }
        public Int32 LuotBinhLuan { get; set; }
        public Int32 LuotThich { get; set; }
        public Int32 LuotXem { get; set; }
        public Guid HoatDong_ID { get; set; }
        public String VideoUrl { get; set; }
        public Guid AB_ID { get; set; }
        public String Anh { get; set; }
        public DateTime NgayViet { get; set; }
        #endregion
        #region Contructor
        public CapNhat()
        { }
        #endregion
        #region Customs properties

        public string HoatDong_Ten { get; set; }
        public List<Anh> Anhs { get; set; }
        public Be BeItem { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return CapNhatDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class CapNhatCollection : BaseEntityCollection<CapNhat>
    { }
    #endregion
    #region Dal
    public class CapNhatDal
    {
        #region Methods

        public static void DeleteById(Guid U_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("U_ID", U_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblCapNhat_Delete_DeleteById_linhnx", obj);
        }

        public static CapNhat Insert(CapNhat item)
        {
            var Item = new CapNhat();
            var obj = new SqlParameter[17];
            obj[0] = new SqlParameter("U_ID", item.ID);
            obj[1] = new SqlParameter("U_P_ID", item.P_ID);
            obj[2] = new SqlParameter("U_Loai", item.Loai);
            obj[3] = new SqlParameter("U_Ten", item.Ten);
            obj[4] = new SqlParameter("U_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("U_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("U_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("U_Username", item.Username);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("U_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("U_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("U_Thich", item.Thich);
            obj[9] = new SqlParameter("U_LuotBinhLuan", item.LuotBinhLuan);
            obj[10] = new SqlParameter("U_LuotThich", item.LuotThich);
            obj[11] = new SqlParameter("U_LuotXem", item.LuotXem);
            obj[12] = new SqlParameter("U_HoatDong_ID", item.HoatDong_ID);
            obj[13] = new SqlParameter("U_VideoUrl", item.VideoUrl);
            obj[14] = new SqlParameter("U_AB_ID", item.AB_ID);
            obj[15] = new SqlParameter("U_Anh", item.Anh);
            if (item.NgayViet > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("U_NgayViet", item.NgayViet);
            }
            else
            {
                obj[16] = new SqlParameter("U_NgayViet", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCapNhat_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static CapNhat Update(CapNhat item)
        {
            var Item = new CapNhat();
            var obj = new SqlParameter[17];
            obj[0] = new SqlParameter("U_ID", item.ID);
            obj[1] = new SqlParameter("U_P_ID", item.P_ID);
            obj[2] = new SqlParameter("U_Loai", item.Loai);
            obj[3] = new SqlParameter("U_Ten", item.Ten);
            obj[4] = new SqlParameter("U_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("U_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("U_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("U_Username", item.Username);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("U_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[7] = new SqlParameter("U_NgayCapNhat", DBNull.Value);
            }
            obj[8] = new SqlParameter("U_Thich", item.Thich);
            obj[9] = new SqlParameter("U_LuotBinhLuan", item.LuotBinhLuan);
            obj[10] = new SqlParameter("U_LuotThich", item.LuotThich);
            obj[11] = new SqlParameter("U_LuotXem", item.LuotXem);
            obj[12] = new SqlParameter("U_HoatDong_ID", item.HoatDong_ID);
            obj[13] = new SqlParameter("U_VideoUrl", item.VideoUrl);
            obj[14] = new SqlParameter("U_AB_ID", item.AB_ID);
            obj[15] = new SqlParameter("U_Anh", item.Anh);
            if (item.NgayViet > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("U_NgayViet", item.NgayViet);
            }
            else
            {
                obj[16] = new SqlParameter("U_NgayViet", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCapNhat_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static CapNhat SelectById(Guid U_ID)
        {
            var Item = new CapNhat();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("U_ID", U_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCapNhat_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static CapNhat SelectById(SqlConnection con, Guid U_ID)
        {
            var Item = new CapNhat();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("U_ID", U_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblCapNhat_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static CapNhatCollection SelectAll()
        {
            var List = new CapNhatCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCapNhat_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<CapNhat> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<CapNhat>("sp_tblCapNhat_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static CapNhat getFromReader(IDataReader rd)
        {
            var Item = new CapNhat();
            if (rd.FieldExists("U_ID"))
            {
                Item.ID = (Guid)(rd["U_ID"]);
            }
            if (rd.FieldExists("U_P_ID"))
            {
                Item.P_ID = (Guid)(rd["U_P_ID"]);
            }
            if (rd.FieldExists("U_Loai"))
            {
                Item.Loai = (Int32)(rd["U_Loai"]);
            }
            if (rd.FieldExists("U_Ten"))
            {
                Item.Ten = (String)(rd["U_Ten"]);
            }
            if (rd.FieldExists("U_NoiDung"))
            {
                Item.NoiDung = (String)(rd["U_NoiDung"]);
            }
            if (rd.FieldExists("U_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["U_NgayTao"]);
            }
            if (rd.FieldExists("U_Username"))
            {
                Item.Username = (String)(rd["U_Username"]);
            }
            if (rd.FieldExists("U_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["U_NgayCapNhat"]);
            }
            if (rd.FieldExists("U_Thich"))
            {
                Item.Thich = (Boolean)(rd["U_Thich"]);
            }
            if (rd.FieldExists("U_LuotBinhLuan"))
            {
                Item.LuotBinhLuan = (Int32)(rd["U_LuotBinhLuan"]);
            }
            if (rd.FieldExists("U_LuotThich"))
            {
                Item.LuotThich = (Int32)(rd["U_LuotThich"]);
            }
            if (rd.FieldExists("U_LuotXem"))
            {
                Item.LuotXem = (Int32)(rd["U_LuotXem"]);
            }
            if (rd.FieldExists("U_HoatDong_ID"))
            {
                Item.HoatDong_ID = (Guid)(rd["U_HoatDong_ID"]);
            }
            if (rd.FieldExists("U_VideoUrl"))
            {
                Item.VideoUrl = (String)(rd["U_VideoUrl"]);
            }
            if (rd.FieldExists("U_AB_ID"))
            {
                Item.AB_ID = (Guid)(rd["U_AB_ID"]);
            }
            if (rd.FieldExists("U_Anh"))
            {
                Item.Anh = (String)(rd["U_Anh"]);
            }
            if (rd.FieldExists("U_HoatDong_Ten"))
            {
                Item.HoatDong_Ten = (String)(rd["U_HoatDong_Ten"]);
            }
            if (rd.FieldExists("U_NgayViet"))
            {
                Item.NgayViet = (DateTime)(rd["U_NgayViet"]);
            }
            if(Item.Loai==4 && Item.AB_ID!= Guid.Empty)
            {
                var listAnh = AnhDal.SelectByAbId(DAL.con(), Item.AB_ID.ToString(), 3);
                Item.Anhs = listAnh;
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<CapNhat> ByPid(string url, bool rewrite, string sort, string q, int size, string Pid, string Username)
        {
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            obj[2] = new SqlParameter("Pid", Pid);
            if (!string.IsNullOrEmpty(Username))
            {
                obj[3] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[3] = new SqlParameter("Username", DBNull.Value);
            }
            var pg = new Pager<CapNhat>("sp_tblCapNhat_Pager_ByPid_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<CapNhat> capNhatYeuThichByUsername(string url, bool rewrite, string sort, int size, string Username)
        {
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Username", Username);
            if (!string.IsNullOrEmpty(sort))
            {
                obj[1] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[1] = new SqlParameter("Sort", DBNull.Value);
            }
            var pg = new Pager<CapNhat>("sp_tblCapNhat_Pager_capNhatYeuThichByUsername_linhnx", "postPg", size, 10, rewrite, url, obj);
            return pg;
        }
        public static CapNhatCollection SelectByUsername(SqlConnection con, string Top, string Username)
        {
            var List = new CapNhatCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Username", Username);
            if (!string.IsNullOrEmpty(Top))
            {
                obj[1] = new SqlParameter("Top", Top);
            }
            else
            {
                obj[1] = new SqlParameter("Top", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblCapNhat_Select_selectByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static CapNhatCollection WallById(SqlConnection con,string Top,string Pid, string Username,string Fromdate)
        {
            var List = new CapNhatCollection();
            var obj = new SqlParameter[4];
            if(!string.IsNullOrEmpty(Top))
            {
                obj[0] = new SqlParameter("Top", Top);
            }
            else
            {
                obj[0] = new SqlParameter("Top", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Pid))
            {
                obj[1] = new SqlParameter("Pid", Pid);
            }
            else
            {
                obj[1] = new SqlParameter("Pid", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Username))
            {
                obj[2] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[2] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Fromdate))
            {
                obj[3] = new SqlParameter("Fromdate", Fromdate);
            }
            else
            {
                obj[3] = new SqlParameter("Fromdate", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCapNhat_Select_WallById", obj))
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


    #region LoiChuc
    #region BO
    public class LoiChuc : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid P_ID { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public String Username { get; set; }
        public Int32 LuotThich { get; set; }
        public Boolean Thich { get; set; }
        #endregion
        #region Contructor
        public LoiChuc()
        { }
        #endregion
        #region Customs properties

        public Member _Member { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LoiChucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LoiChucCollection : BaseEntityCollection<LoiChuc>
    { }
    #endregion
    #region Dal
    public class LoiChucDal
    {
        #region Methods

        public static void DeleteById(Guid LC_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LC_ID", LC_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLoiChuc_Delete_DeleteById_linhnx", obj);
        }

        public static LoiChuc Insert(LoiChuc item)
        {
            var Item = new LoiChuc();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("LC_ID", item.ID);
            obj[1] = new SqlParameter("LC_P_ID", item.P_ID);
            obj[2] = new SqlParameter("LC_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("LC_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("LC_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("LC_Username", item.Username);
            obj[5] = new SqlParameter("LC_LuotThich", item.LuotThich);
            obj[6] = new SqlParameter("LC_Thich", item.Thich);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoiChuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoiChuc Update(LoiChuc item)
        {
            var Item = new LoiChuc();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("LC_ID", item.ID);
            obj[1] = new SqlParameter("LC_P_ID", item.P_ID);
            obj[2] = new SqlParameter("LC_NoiDung", item.NoiDung);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("LC_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("LC_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("LC_Username", item.Username);
            obj[5] = new SqlParameter("LC_LuotThich", item.LuotThich);
            obj[6] = new SqlParameter("LC_Thich", item.Thich);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoiChuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoiChuc SelectById(Guid LC_ID)
        {
            var Item = new LoiChuc();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LC_ID", LC_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoiChuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoiChucCollection SelectAll()
        {
            var List = new LoiChucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoiChuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LoiChuc> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<LoiChuc>("sp_tblLoiChuc_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static LoiChuc getFromReader(IDataReader rd)
        {
            var Item = new LoiChuc();
            if (rd.FieldExists("LC_ID"))
            {
                Item.ID = (Guid)(rd["LC_ID"]);
            }
            if (rd.FieldExists("LC_P_ID"))
            {
                Item.P_ID = (Guid)(rd["LC_P_ID"]);
            }
            if (rd.FieldExists("LC_NoiDung"))
            {
                Item.NoiDung = (String)(rd["LC_NoiDung"]);
            }
            if (rd.FieldExists("LC_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LC_NgayTao"]);
            }
            if (rd.FieldExists("LC_Username"))
            {
                Item.Username = (String)(rd["LC_Username"]);
            }
            if (rd.FieldExists("LC_LuotThich"))
            {
                Item.LuotThich = (Int32)(rd["LC_LuotThich"]);
            }
            if (rd.FieldExists("LC_Thich"))
            {
                Item.Thich = (Boolean)(rd["LC_Thich"]);
            }
            var mem = new Member();
            if (rd.FieldExists("MEM_Ten"))
            {
                mem.Ten = (String)(rd["MEM_Ten"]);
            }
            if (rd.FieldExists("MEM_Anh"))
            {
                mem.Anh = (String)(rd["MEM_Anh"]);
            }
            Item._Member = mem; 
            return Item;
        }
        #endregion

        #region Extend
        public static LoiChuc SelectById(SqlConnection con, Guid LC_ID)
        {
            var Item = new LoiChuc();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LC_ID", LC_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblLoiChuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static LoiChucCollection SelectPid(SqlConnection con,int Top, string P_ID)
        {
            var List = new LoiChucCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("P_ID", P_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoiChuc_Select_SelectByPId_linhnx", obj))
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

    #region Anh
    #region BO
    public class Anh : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid AB_ID { get; set; }
        public Guid P_ID { get; set; }
        public String Ten { get; set; }
        public String FileAnh { get; set; }
        public Boolean Thich { get; set; }
        public Int32 LuotThich { get; set; }
        public Int32 LuotXem { get; set; }
        public Int32 LuotBinhLuan { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public Anh()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return AnhDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class AnhCollection : BaseEntityCollection<Anh>
    { }
    #endregion
    #region Dal
    public class AnhDal
    {
        #region Methods

        public static void DeleteById(Guid A_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("A_ID", A_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Delete_DeleteById_linhnx", obj);
        }

        public static Anh Insert(Anh item)
        {
            var Item = new Anh();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("A_ID", item.ID);
            obj[1] = new SqlParameter("A_AB_ID", item.AB_ID);
            obj[2] = new SqlParameter("A_P_ID", item.P_ID);
            obj[3] = new SqlParameter("A_Ten", item.Ten);
            obj[4] = new SqlParameter("A_FileAnh", item.FileAnh);
            obj[5] = new SqlParameter("A_Thich", item.Thich);
            obj[6] = new SqlParameter("A_LuotThich", item.LuotThich);
            obj[7] = new SqlParameter("A_LuotXem", item.LuotXem);
            obj[8] = new SqlParameter("A_LuotBinhLuan", item.LuotBinhLuan);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("A_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("A_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Anh Update(Anh item)
        {
            var Item = new Anh();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("A_ID", item.ID);
            obj[1] = new SqlParameter("A_AB_ID", item.AB_ID);
            obj[2] = new SqlParameter("A_P_ID", item.P_ID);
            obj[3] = new SqlParameter("A_Ten", item.Ten);
            obj[4] = new SqlParameter("A_FileAnh", item.FileAnh);
            obj[5] = new SqlParameter("A_Thich", item.Thich);
            obj[6] = new SqlParameter("A_LuotThich", item.LuotThich);
            obj[7] = new SqlParameter("A_LuotXem", item.LuotXem);
            obj[8] = new SqlParameter("A_LuotBinhLuan", item.LuotBinhLuan);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("A_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("A_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Anh SelectById(Guid A_ID)
        {
            var Item = new Anh();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("A_ID", A_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static AnhCollection SelectAll()
        {
            var List = new AnhCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Anh> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Anh>("sp_tblAnh_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Anh getFromReader(IDataReader rd)
        {
            var Item = new Anh();
            if (rd.FieldExists("A_ID"))
            {
                Item.ID = (Guid)(rd["A_ID"]);
            }
            if (rd.FieldExists("A_AB_ID"))
            {
                Item.AB_ID = (Guid)(rd["A_AB_ID"]);
            }
            if (rd.FieldExists("A_P_ID"))
            {
                Item.P_ID = (Guid)(rd["A_P_ID"]);
            }
            if (rd.FieldExists("A_Ten"))
            {
                Item.Ten = (String)(rd["A_Ten"]);
            }
            if (rd.FieldExists("A_FileAnh"))
            {
                Item.FileAnh = (String)(rd["A_FileAnh"]);
            }
            if (rd.FieldExists("A_Thich"))
            {
                Item.Thich = (Boolean)(rd["A_Thich"]);
            }
            if (rd.FieldExists("A_LuotThich"))
            {
                Item.LuotThich = (Int32)(rd["A_LuotThich"]);
            }
            if (rd.FieldExists("A_LuotXem"))
            {
                Item.LuotXem = (Int32)(rd["A_LuotXem"]);
            }
            if (rd.FieldExists("A_LuotBinhLuan"))
            {
                Item.LuotBinhLuan = (Int32)(rd["A_LuotBinhLuan"]);
            }
            if (rd.FieldExists("A_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["A_NgayTao"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static AnhCollection SelectByAbId(SqlConnection con,string AB_ID)
        {
            var List = new AnhCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("AB_ID", AB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Select_SelectByAbId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static AnhCollection SelectByAbId(SqlConnection con, string AB_ID, int Top)
        {
            var List = new AnhCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("AB_ID", AB_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAnh_Select_SelectByAbId_linhnx", obj))
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

    #region BinhLuan
    #region BO
    public class BinhLuan : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid P_RowId { get; set; }
        public Guid PBL_ID { get; set; }
        public String Ten { get; set; }
        public String NoiDung { get; set; }
        public String Url { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 LuotThich { get; set; }
        #endregion
        #region Contructor
        public BinhLuan()
        { }
        #endregion
        #region Customs properties

        public int LuotBinhLuan { get; set; }
        public Member _Member { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BinhLuanDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BinhLuanCollection : BaseEntityCollection<BinhLuan>
    { }
    #endregion
    #region Dal
    public class BinhLuanDal
    {
        #region Methods

        public static void DeleteById(Guid BL_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BL_ID", BL_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Delete_DeleteById_linhnx", obj);
        }

        public static BinhLuan Insert(BinhLuan item)
        {
            var Item = new BinhLuan();
            var obj = new SqlParameter[9];
            obj[0] = new SqlParameter("BL_ID", item.ID);
            obj[1] = new SqlParameter("BL_P_RowId", item.P_RowId);
            obj[2] = new SqlParameter("BL_PBL_ID", item.PBL_ID);
            obj[3] = new SqlParameter("BL_Ten", item.Ten);
            obj[4] = new SqlParameter("BL_NoiDung", item.NoiDung);
            obj[5] = new SqlParameter("BL_Url", item.Url);
            obj[6] = new SqlParameter("BL_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("BL_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("BL_NgayTao", DBNull.Value);
            }
            obj[8] = new SqlParameter("BL_LuotThich", item.LuotThich);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BinhLuan Update(BinhLuan item)
        {
            var Item = new BinhLuan();
            var obj = new SqlParameter[9];
            obj[0] = new SqlParameter("BL_ID", item.ID);
            obj[1] = new SqlParameter("BL_P_RowId", item.P_RowId);
            obj[2] = new SqlParameter("BL_PBL_ID", item.PBL_ID);
            obj[3] = new SqlParameter("BL_Ten", item.Ten);
            obj[4] = new SqlParameter("BL_NoiDung", item.NoiDung);
            obj[5] = new SqlParameter("BL_Url", item.Url);
            obj[6] = new SqlParameter("BL_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("BL_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("BL_NgayTao", DBNull.Value);
            }
            obj[8] = new SqlParameter("BL_LuotThich", item.LuotThich);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BinhLuan SelectById(Guid BL_ID)
        {
            var Item = new BinhLuan();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BL_ID", BL_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BinhLuanCollection SelectAll()
        {
            var List = new BinhLuanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<BinhLuan> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<BinhLuan>("sp_tblBinhLuan_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }


        #endregion

        #region Utilities
        public static BinhLuan getFromReader(IDataReader rd)
        {
            var Item = new BinhLuan();
            if (rd.FieldExists("BL_ID"))
            {
                Item.ID = (Guid)(rd["BL_ID"]);
            }
            if (rd.FieldExists("BL_P_RowId"))
            {
                Item.P_RowId = (Guid)(rd["BL_P_RowId"]);
            }
            if (rd.FieldExists("BL_PBL_ID"))
            {
                Item.PBL_ID = (Guid)(rd["BL_PBL_ID"]);
            }
            if (rd.FieldExists("BL_Ten"))
            {
                Item.Ten = (String)(rd["BL_Ten"]);
            }
            if (rd.FieldExists("BL_NoiDung"))
            {
                Item.NoiDung = (String)(rd["BL_NoiDung"]);
            }
            if (rd.FieldExists("BL_Url"))
            {
                Item.Url = (String)(rd["BL_Url"]);
            }
            if (rd.FieldExists("BL_Username"))
            {
                Item.Username = (String)(rd["BL_Username"]);
            }
            if (rd.FieldExists("BL_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["BL_NgayTao"]);
            }
            if (rd.FieldExists("BL_LuotThich"))
            {
                Item.LuotThich = (Int32)(rd["BL_LuotThich"]);
            }
            Item._Member = MemberDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static BinhLuanCollection ByPid(SqlConnection con, string Pid, string FromDate, string Top, string Username)
        {
            var List = new BinhLuanCollection();
            var obj = new SqlParameter[4];
            if(!string.IsNullOrEmpty(Pid))
            {
                obj[0] = new SqlParameter("Pid", Pid);
            }
            else
            {
                obj[0] = new SqlParameter("Pid", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(FromDate))
            {
                obj[1] = new SqlParameter("FromDate", FromDate);
            }
            else
            {
                obj[1] = new SqlParameter("FromDate", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Top))
            {
                obj[2] = new SqlParameter("Top", Top);
            }
            else
            {
                obj[2] = new SqlParameter("Top", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Username))
            {
                obj[3] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[3] = new SqlParameter("Username", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBinhLuan_Select_ByPid_linhnx", obj))
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

    #region TheoDoi
    #region BO
    public class TheoDoi : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid P_ID { get; set; }
        public Guid BCTD_ID { get; set; }
        public DateTime NgayGhi { get; set; }
        public Int32 ChieuCao { get; set; }
        public Int32 CanNang { get; set; }
        public Guid LOAI_ID { get; set; }
        public Guid LOAISUB_ID { get; set; }
        public String Username { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Boolean HeThong { get; set; }
        #endregion
        #region Contructor
        public TheoDoi()
        { }
        #endregion
        #region Customs properties

        public string LOAISUB_Ten { get; set; }
        public string LOAISUB_ChuanNam { get; set; }
        public string LOAISUB_Nu { get; set; }
        public DanhMuc _DanhMuc { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TheoDoiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TheoDoiCollection : BaseEntityCollection<TheoDoi>
    { }
    #endregion
    #region Dal
    public class TheoDoiDal
    {
        #region Methods

        public static void DeleteById(Guid BD_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BD_ID", BD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTheoDoi_Delete_DeleteById_linhnx", obj);
        }

        public static TheoDoi Insert(TheoDoi item)
        {
            var Item = new TheoDoi();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("BD_ID", item.ID);
            obj[1] = new SqlParameter("BD_BCTD_ID", item.BCTD_ID);
            obj[2] = new SqlParameter("BD_P_ID", item.P_ID);
            if (item.NgayGhi > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("BD_NgayGhi", item.NgayGhi);
            }
            else
            {
                obj[3] = new SqlParameter("BD_NgayGhi", DBNull.Value);
            }
            obj[4] = new SqlParameter("BD_ChieuCao", item.ChieuCao);
            obj[5] = new SqlParameter("BD_CanNang", item.CanNang);
            obj[6] = new SqlParameter("BD_LOAI_ID", item.LOAI_ID);
            obj[7] = new SqlParameter("BD_LOAISUB_ID", item.LOAISUB_ID);
            obj[8] = new SqlParameter("BD_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("BD_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("BD_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("BD_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[10] = new SqlParameter("BD_NgayCapNhat", DBNull.Value);
            }
            obj[11] = new SqlParameter("BD_HeThong", item.HeThong);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTheoDoi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TheoDoi Update(TheoDoi item)
        {
            var Item = new TheoDoi();
            var obj = new SqlParameter[12];
            obj[0] = new SqlParameter("BD_ID", item.ID);
            obj[1] = new SqlParameter("BD_BCTD_ID", item.BCTD_ID);
            obj[2] = new SqlParameter("BD_P_ID", item.P_ID);
            if (item.NgayGhi > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("BD_NgayGhi", item.NgayGhi);
            }
            else
            {
                obj[3] = new SqlParameter("BD_NgayGhi", DBNull.Value);
            }
            obj[4] = new SqlParameter("BD_ChieuCao", item.ChieuCao);
            obj[5] = new SqlParameter("BD_CanNang", item.CanNang);
            obj[6] = new SqlParameter("BD_LOAI_ID", item.LOAI_ID);
            obj[7] = new SqlParameter("BD_LOAISUB_ID", item.LOAISUB_ID);
            obj[8] = new SqlParameter("BD_Username", item.Username);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("BD_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("BD_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("BD_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[10] = new SqlParameter("BD_NgayCapNhat", DBNull.Value);
            }
            obj[11] = new SqlParameter("BD_HeThong", item.HeThong);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTheoDoi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
                
        public static TheoDoi SelectById(Guid BD_ID)
        {
            var Item = new TheoDoi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BD_ID", BD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTheoDoi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TheoDoiCollection SelectAll()
        {
            var List = new TheoDoiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTheoDoi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TheoDoi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<TheoDoi>("sp_tblTheoDoi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TheoDoi getFromReader(IDataReader rd)
        {
            var Item = new TheoDoi();
            if (rd.FieldExists("BD_ID"))
            {
                Item.ID = (Guid)(rd["BD_ID"]);
            }
            if (rd.FieldExists("BD_P_ID"))
            {
                Item.P_ID = (Guid)(rd["BD_P_ID"]);
            }
            if (rd.FieldExists("BD_BCTD_ID"))
            {
                Item.BCTD_ID = (Guid)(rd["BD_BCTD_ID"]);
            }
            if (rd.FieldExists("BD_NgayGhi"))
            {
                Item.NgayGhi = (DateTime)(rd["BD_NgayGhi"]);
            }
            if (rd.FieldExists("BD_ChieuCao"))
            {
                Item.ChieuCao = (Int32)(rd["BD_ChieuCao"]);
            }
            if (rd.FieldExists("BD_CanNang"))
            {
                Item.CanNang = (Int32)(rd["BD_CanNang"]);
            }
            if (rd.FieldExists("BD_LOAI_ID"))
            {
                Item.LOAI_ID = (Guid)(rd["BD_LOAI_ID"]);
            }
            if (rd.FieldExists("BD_LOAISUB_ID"))
            {
                Item.LOAISUB_ID = (Guid)(rd["BD_LOAISUB_ID"]);
            }
            if (rd.FieldExists("BD_Username"))
            {
                Item.Username = (String)(rd["BD_Username"]);
            }
            if (rd.FieldExists("BD_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["BD_NgayTao"]);
            }
            if (rd.FieldExists("BD_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["BD_NgayCapNhat"]);
            }
            if (rd.FieldExists("BD_HeThong"))
            {
                Item.HeThong = (Boolean)(rd["BD_HeThong"]);
            }
            if (rd.FieldExists("BD_LOAISUB_Ten"))
            {
                Item.LOAISUB_Ten = (String)(rd["BD_LOAISUB_Ten"]);
            }
            if (rd.FieldExists("BD_LOAISUB_ChuanNam"))
            {
                Item.LOAISUB_ChuanNam = (String)(rd["BD_LOAISUB_ChuanNam"]);
            }
            if (rd.FieldExists("BD_LOAISUB_Nu"))
            {
                Item.LOAISUB_Nu = (String)(rd["BD_LOAISUB_Nu"]);
            }
            Item._DanhMuc = DanhMucDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static TheoDoiCollection SelectByLoaiIdPid(SqlConnection con,string LOAI_ID, string P_ID)
        {
            var List = new TheoDoiCollection();
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("LOAI_ID", LOAI_ID);
            obj[1] = new SqlParameter("P_ID", P_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTheoDoi_Select_SelectByLoaiIdPid_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static TheoDoiCollection SelectByBctd(SqlConnection con, string BCTD_ID)
        {
            var list = new TheoDoiCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BCTD_ID", BCTD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTheoDoi_Select_SelectByBCTD_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        #endregion
    }
    #endregion

    #endregion

    #region BaoCaoTheoDoi
    #region BO
    public class BaoCaoTheoDoi : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid PID_ID { get; set; }
        public Guid LOAI_ID { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Active { get; set; }
        public String Username { get; set; }
        public String Ten { get; set; }
        #endregion
        #region Contructor
        public BaoCaoTheoDoi()
        { }
        #endregion
        #region Customs properties
        public DanhMuc _DanhMuc { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BaoCaoTheoDoiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BaoCaoTheoDoiCollection : BaseEntityCollection<BaoCaoTheoDoi>
    { }
    #endregion
    #region Dal
    public class BaoCaoTheoDoiDal
    {
        #region Methods

        public static void DeleteById(Guid BCTD_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BCTD_ID", BCTD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblBaoCaoTheoDoi_Delete_DeleteById_linhnx", obj);
        }

        public static BaoCaoTheoDoi Insert(BaoCaoTheoDoi item)
        {
            var Item = new BaoCaoTheoDoi();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("BCTD_ID", item.ID);
            obj[1] = new SqlParameter("BCTD_PID_ID", item.PID_ID);
            obj[2] = new SqlParameter("BCTD_LOAI_ID", item.LOAI_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("BCTD_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("BCTD_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("BCTD_Active", item.Active);
            obj[5] = new SqlParameter("BCTD_Username", item.Username);
            obj[6] = new SqlParameter("BCTD_Ten", item.Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBaoCaoTheoDoi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BaoCaoTheoDoi Update(BaoCaoTheoDoi item)
        {
            var Item = new BaoCaoTheoDoi();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("BCTD_ID", item.ID);
            obj[1] = new SqlParameter("BCTD_PID_ID", item.PID_ID);
            obj[2] = new SqlParameter("BCTD_LOAI_ID", item.LOAI_ID);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("BCTD_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("BCTD_NgayTao", DBNull.Value);
            }
            obj[4] = new SqlParameter("BCTD_Active", item.Active);
            obj[5] = new SqlParameter("BCTD_Username", item.Username);
            obj[6] = new SqlParameter("BCTD_Ten", item.Ten);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBaoCaoTheoDoi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BaoCaoTheoDoi SelectById(Guid BCTD_ID)
        {
            var Item = new BaoCaoTheoDoi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BCTD_ID", BCTD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBaoCaoTheoDoi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BaoCaoTheoDoiCollection SelectAll()
        {
            var List = new BaoCaoTheoDoiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblBaoCaoTheoDoi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<BaoCaoTheoDoi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<BaoCaoTheoDoi>("sp_tblBaoCaoTheoDoi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static BaoCaoTheoDoi getFromReader(IDataReader rd)
        {
            var Item = new BaoCaoTheoDoi();
            if (rd.FieldExists("BCTD_ID"))
            {
                Item.ID = (Guid)(rd["BCTD_ID"]);
            }
            if (rd.FieldExists("BCTD_PID_ID"))
            {
                Item.PID_ID = (Guid)(rd["BCTD_PID_ID"]);
            }
            if (rd.FieldExists("BCTD_LOAI_ID"))
            {
                Item.LOAI_ID = (Guid)(rd["BCTD_LOAI_ID"]);
            }
            if (rd.FieldExists("BCTD_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["BCTD_NgayTao"]);
            }
            if (rd.FieldExists("BCTD_Active"))
            {
                Item.Active = (Boolean)(rd["BCTD_Active"]);
            }
            if (rd.FieldExists("BCTD_Username"))
            {
                Item.Username = (String)(rd["BCTD_Username"]);
            }
            if (rd.FieldExists("BCTD_Ten"))
            {
                Item.Ten = (String)(rd["BCTD_Ten"]);
            }
            Item._DanhMuc = DanhMucDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        public static BaoCaoTheoDoi SelectById(SqlConnection con, Guid BCTD_ID)
        {
            var Item = new BaoCaoTheoDoi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BCTD_ID", BCTD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBaoCaoTheoDoi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static BaoCaoTheoDoiCollection SelectByPid(SqlConnection con, string PID_ID)
        {
            var list = new BaoCaoTheoDoiCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PID_ID", PID_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblBaoCaoTheoDoi_Select_SelectByPId_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        #endregion
    }
    #endregion

    #endregion
}


