using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using linh.core.dal;
using linh.controls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
namespace docbao.entitites
{
    #region Adv
    #region BO
    public class Adv : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 Loai { get; set; }
        public String Ten { get; set; }
        public String NoiDung { get; set; }
        public String MaViTri { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Active { get; set; }
        public String Files { get; set; }
        public String FilesMime { get; set; }
        public String Urls { get; set; }
        public Int32 Clicks { get; set; }
        #endregion
        #region Contructor
        public Adv()
        { }
        public Adv(Int32? id, Int32? loai, String ten, String noidung, String mavitri, Int32? thutu, Boolean? active, String files, String filesmime, String urls, Int32? clicks)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (loai != null)
            {
                Loai = loai.Value;
            }
            Ten = ten;
            NoiDung = noidung;
            MaViTri = mavitri;
            if (thutu != null)
            {
                ThuTu = thutu.Value;
            }
            if (active != null)
            {
                Active = active.Value;
            }
            Files = files;
            FilesMime = filesmime;
            Urls = urls;
            if (clicks != null)
            {
                Clicks = clicks.Value;
            }

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return AdvDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class AdvCollection : BaseEntityCollection<Adv>
    { }
    #endregion
    #region Dal
    public class AdvDal
    {
        #region Methods

        public static void DeleteById(Int32 A_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("A_ID", A_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssAdv_Delete_DeleteById_linhnx", obj);
        }
        public static Adv Insert(Adv Inserted)
        {
            Adv Item = new Adv();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("A_Loai", Inserted.Loai);
            obj[1] = new SqlParameter("A_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("A_NoiDung", Inserted.NoiDung);
            obj[3] = new SqlParameter("A_MaViTri", Inserted.MaViTri);
            obj[4] = new SqlParameter("A_ThuTu", Inserted.ThuTu);
            obj[5] = new SqlParameter("A_Active", Inserted.Active);
            obj[6] = new SqlParameter("A_Files", Inserted.Files);
            obj[7] = new SqlParameter("A_FilesMime", Inserted.FilesMime);
            obj[8] = new SqlParameter("A_Urls", Inserted.Urls);
            obj[9] = new SqlParameter("A_Clicks", Inserted.Clicks);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssAdv_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Adv Insert(Int32? id, Int32? loai, String ten, String noidung, String mavitri, Int32? thutu, Boolean? active, String files, String filesmime, String urls, Int32? clicks)
        {
            Adv Item = new Adv();
            SqlParameter[] obj = new SqlParameter[10];
            if (loai != null)
            {
                obj[0] = new SqlParameter("A_Loai", loai);
            }
            else
            {
                obj[0] = new SqlParameter("A_Loai", DBNull.Value);
            }
            if (ten != null)
            {
                obj[1] = new SqlParameter("A_Ten", ten);
            }
            else
            {
                obj[1] = new SqlParameter("A_Ten", DBNull.Value);
            }
            if (noidung != null)
            {
                obj[2] = new SqlParameter("A_NoiDung", noidung);
            }
            else
            {
                obj[2] = new SqlParameter("A_NoiDung", DBNull.Value);
            }
            if (mavitri != null)
            {
                obj[3] = new SqlParameter("A_MaViTri", mavitri);
            }
            else
            {
                obj[3] = new SqlParameter("A_MaViTri", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[4] = new SqlParameter("A_ThuTu", thutu);
            }
            else
            {
                obj[4] = new SqlParameter("A_ThuTu", DBNull.Value);
            }
            if (active != null)
            {
                obj[5] = new SqlParameter("A_Active", active);
            }
            else
            {
                obj[5] = new SqlParameter("A_Active", DBNull.Value);
            }
            if (files != null)
            {
                obj[6] = new SqlParameter("A_Files", files);
            }
            else
            {
                obj[6] = new SqlParameter("A_Files", DBNull.Value);
            }
            if (filesmime != null)
            {
                obj[7] = new SqlParameter("A_FilesMime", filesmime);
            }
            else
            {
                obj[7] = new SqlParameter("A_FilesMime", DBNull.Value);
            }
            if (urls != null)
            {
                obj[8] = new SqlParameter("A_Urls", urls);
            }
            else
            {
                obj[8] = new SqlParameter("A_Urls", DBNull.Value);
            }
            if (clicks != null)
            {
                obj[9] = new SqlParameter("A_Clicks", clicks);
            }
            else
            {
                obj[9] = new SqlParameter("A_Clicks", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssAdv_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Adv Update(Adv Updated)
        {
            Adv Item = new Adv();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("A_ID", Updated.ID);
            obj[1] = new SqlParameter("A_Loai", Updated.Loai);
            obj[2] = new SqlParameter("A_Ten", Updated.Ten);
            obj[3] = new SqlParameter("A_NoiDung", Updated.NoiDung);
            obj[4] = new SqlParameter("A_MaViTri", Updated.MaViTri);
            obj[5] = new SqlParameter("A_ThuTu", Updated.ThuTu);
            obj[6] = new SqlParameter("A_Active", Updated.Active);
            obj[7] = new SqlParameter("A_Files", Updated.Files);
            obj[8] = new SqlParameter("A_FilesMime", Updated.FilesMime);
            obj[9] = new SqlParameter("A_Urls", Updated.Urls);
            obj[10] = new SqlParameter("A_Clicks", Updated.Clicks);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssAdv_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Adv Update(Int32? id, Int32? loai, String ten, String noidung, String mavitri, Int32? thutu, Boolean? active, String files, String filesmime, String urls, Int32? clicks)
        {
            Adv Item = new Adv();
            SqlParameter[] obj = new SqlParameter[11];
            if (id != null)
            {
                obj[0] = new SqlParameter("A_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("A_ID", DBNull.Value);
            }
            if (loai != null)
            {
                obj[1] = new SqlParameter("A_Loai", loai);
            }
            else
            {
                obj[1] = new SqlParameter("A_Loai", DBNull.Value);
            }
            if (ten != null)
            {
                obj[2] = new SqlParameter("A_Ten", ten);
            }
            else
            {
                obj[2] = new SqlParameter("A_Ten", DBNull.Value);
            }
            if (noidung != null)
            {
                obj[3] = new SqlParameter("A_NoiDung", noidung);
            }
            else
            {
                obj[3] = new SqlParameter("A_NoiDung", DBNull.Value);
            }
            if (mavitri != null)
            {
                obj[4] = new SqlParameter("A_MaViTri", mavitri);
            }
            else
            {
                obj[4] = new SqlParameter("A_MaViTri", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[5] = new SqlParameter("A_ThuTu", thutu);
            }
            else
            {
                obj[5] = new SqlParameter("A_ThuTu", DBNull.Value);
            }
            if (active != null)
            {
                obj[6] = new SqlParameter("A_Active", active);
            }
            else
            {
                obj[6] = new SqlParameter("A_Active", DBNull.Value);
            }
            if (files != null)
            {
                obj[7] = new SqlParameter("A_Files", files);
            }
            else
            {
                obj[7] = new SqlParameter("A_Files", DBNull.Value);
            }
            if (filesmime != null)
            {
                obj[8] = new SqlParameter("A_FilesMime", filesmime);
            }
            else
            {
                obj[8] = new SqlParameter("A_FilesMime", DBNull.Value);
            }
            if (urls != null)
            {
                obj[9] = new SqlParameter("A_Urls", urls);
            }
            else
            {
                obj[9] = new SqlParameter("A_Urls", DBNull.Value);
            }
            if (clicks != null)
            {
                obj[10] = new SqlParameter("A_Clicks", clicks);
            }
            else
            {
                obj[10] = new SqlParameter("A_Clicks", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssAdv_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Adv SelectById(Int32 A_ID)
        {
            Adv Item = new Adv();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("A_ID", A_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssAdv_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static AdvCollection SelectAll()
        {
            AdvCollection List = new AdvCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssAdv_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Adv> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Adv> pg = new Pager<Adv>("tblRss_sp_tblAdv_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Adv getFromReader(IDataReader rd)
        {
            Adv Item = new Adv();
            if (rd.FieldExists("A_ID"))
            {
                Item.ID = (Int32)(rd["A_ID"]);
            }
            if (rd.FieldExists("A_Loai"))
            {
                Item.Loai = (Int32)(rd["A_Loai"]);
            }
            if (rd.FieldExists("A_Ten"))
            {
                Item.Ten = (String)(rd["A_Ten"]);
            }
            if (rd.FieldExists("A_NoiDung"))
            {
                Item.NoiDung = (String)(rd["A_NoiDung"]);
            }
            if (rd.FieldExists("A_MaViTri"))
            {
                Item.MaViTri = (String)(rd["A_MaViTri"]);
            }
            if (rd.FieldExists("A_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["A_ThuTu"]);
            }
            if (rd.FieldExists("A_Active"))
            {
                Item.Active = (Boolean)(rd["A_Active"]);
            }
            if (rd.FieldExists("A_Files"))
            {
                Item.Files = (String)(rd["A_Files"]);
            }
            if (rd.FieldExists("A_FilesMime"))
            {
                Item.FilesMime = (String)(rd["A_FilesMime"]);
            }
            if (rd.FieldExists("A_Urls"))
            {
                Item.Urls = (String)(rd["A_Urls"]);
            }
            if (rd.FieldExists("A_Clicks"))
            {
                Item.Clicks = (Int32)(rd["A_Clicks"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static AdvCollection SelectByViTri(string MaViTri,int Top)
        {
            AdvCollection List = new AdvCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("MaViTri", MaViTri);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssAdv_Select_SelectByViTri_linhnx", obj))
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
