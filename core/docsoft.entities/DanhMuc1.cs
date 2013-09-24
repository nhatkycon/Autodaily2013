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
    #region DanhMuc1
    #region BO
    public class DanhMuc1 : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }
        public Int32 PID { get; set; }
        public Int32 Level { get; set; }
        public String PIDList { get; set; }
        public String Lang { get; set; }
        public Boolean LangBased { get; set; }
        public Int32 LangBasedId { get; set; }
        public String Ten { get; set; }
        public String Alias { get; set; }
        public String Mota { get; set; }
        public String Anh { get; set; }
        public String Keywords { get; set; }
        public String Description { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean MacDinh { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int64 Xem { get; set; }
        public Byte Loai { get; set; }
        public Int32 TotalChild { get; set; }
        public Boolean TrangChu { get; set; }
        public Boolean NoiBat { get; set; }
        public Boolean Moi { get; set; }
        public Guid RowId { get; set; }
        public Boolean Xoa { get; set; }
        public Boolean Active { get; set; }
        public Boolean Publish { get; set; }
        #endregion
        #region Contructor
        public DanhMuc1()
        { }
        public DanhMuc1(Int32? id, Int32? gh_id, Int32? pid, Int32? level, String pidlist, String lang, Boolean? langbased, Int32? langbasedid, String ten, String alias, String mota, String anh, String keywords, String description, Int32? thutu, Boolean? macdinh, DateTime? ngaytao, DateTime? ngaycapnhat, Int64? xem, Byte? loai, Int32? totalchild, Boolean? trangchu, Boolean? noibat, Boolean? moi, Guid? rowid, Boolean? xoa, Boolean? active, Boolean? publish)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (gh_id != null)
            {
                GH_ID = gh_id.Value;
            }
            if (pid != null)
            {
                PID = pid.Value;
            }
            if (level != null)
            {
                Level = level.Value;
            }
            PIDList = pidlist;
            Lang = lang;
            if (langbased != null)
            {
                LangBased = langbased.Value;
            }
            if (langbasedid != null)
            {
                LangBasedId = langbasedid.Value;
            }
            Ten = ten;
            Alias = alias;
            Mota = mota;
            Anh = anh;
            Keywords = keywords;
            Description = description;
            if (thutu != null)
            {
                ThuTu = thutu.Value;
            }
            if (macdinh != null)
            {
                MacDinh = macdinh.Value;
            }
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }
            if (ngaycapnhat != null)
            {
                NgayCapNhat = ngaycapnhat.Value;
            }
            if (xem != null)
            {
                Xem = xem.Value;
            }
            if (loai != null)
            {
                Loai = loai.Value;
            }
            if (totalchild != null)
            {
                TotalChild = totalchild.Value;
            }
            if (trangchu != null)
            {
                TrangChu = trangchu.Value;
            }
            if (noibat != null)
            {
                NoiBat = noibat.Value;
            }
            if (moi != null)
            {
                Moi = moi.Value;
            }
            if (rowid != null)
            {
                RowId = rowid.Value;
            }
            if (xoa != null)
            {
                Xoa = xoa.Value;
            }
            if (active != null)
            {
                Active = active.Value;
            }
            if (publish != null)
            {
                Publish = publish.Value;
            }

        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DanhMuc1Dal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DanhMuc1Collection : BaseEntityCollection<DanhMuc1>
    { }
    #endregion
    #region Dal
    public class DanhMuc1Dal
    {
        #region Methods

        public static void DeleteById(Int32 DM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc1_Delete_DeleteById_linhnx", obj);
        }
        public static DanhMuc1 Insert(DanhMuc1 Inserted)
        {
            DanhMuc1 Item = new DanhMuc1();
            SqlParameter[] obj = new SqlParameter[27];
            obj[0] = new SqlParameter("DM_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("DM_PID", Inserted.PID);
            obj[2] = new SqlParameter("DM_Level", Inserted.Level);
            obj[3] = new SqlParameter("DM_PIDList", Inserted.PIDList);
            obj[4] = new SqlParameter("DM_Lang", Inserted.Lang);
            obj[5] = new SqlParameter("DM_LangBased", Inserted.LangBased);
            obj[6] = new SqlParameter("DM_LangBasedId", Inserted.LangBasedId);
            obj[7] = new SqlParameter("DM_Ten", Inserted.Ten);
            obj[8] = new SqlParameter("DM_Alias", Inserted.Alias);
            obj[9] = new SqlParameter("DM_Mota", Inserted.Mota);
            obj[10] = new SqlParameter("DM_Anh", Inserted.Anh);
            obj[11] = new SqlParameter("DM_Keywords", Inserted.Keywords);
            obj[12] = new SqlParameter("DM_Description", Inserted.Description);
            obj[13] = new SqlParameter("DM_ThuTu", Inserted.ThuTu);
            obj[14] = new SqlParameter("DM_MacDinh", Inserted.MacDinh);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("DM_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[15] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("DM_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[16] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[17] = new SqlParameter("DM_Xem", Inserted.Xem);
            obj[18] = new SqlParameter("DM_Loai", Inserted.Loai);
            obj[19] = new SqlParameter("DM_TotalChild", Inserted.TotalChild);
            obj[20] = new SqlParameter("DM_TrangChu", Inserted.TrangChu);
            obj[21] = new SqlParameter("DM_NoiBat", Inserted.NoiBat);
            obj[22] = new SqlParameter("DM_Moi", Inserted.Moi);
            obj[23] = new SqlParameter("DM_RowId", Inserted.RowId);
            obj[24] = new SqlParameter("DM_Xoa", Inserted.Xoa);
            obj[25] = new SqlParameter("DM_Active", Inserted.Active);
            obj[26] = new SqlParameter("DM_Publish", Inserted.Publish);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc1_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc1 Insert(Int32? id, Int32? gh_id, Int32? pid, Int32? level, String pidlist, String lang, Boolean? langbased, Int32? langbasedid, String ten, String alias, String mota, String anh, String keywords, String description, Int32? thutu, Boolean? macdinh, DateTime? ngaytao, DateTime? ngaycapnhat, Int64? xem, Byte? loai, Int32? totalchild, Boolean? trangchu, Boolean? noibat, Boolean? moi, Guid? rowid, Boolean? xoa, Boolean? active, Boolean? publish)
        {
            DanhMuc1 Item = new DanhMuc1();
            SqlParameter[] obj = new SqlParameter[27];
            if (gh_id != null)
            {
                obj[0] = new SqlParameter("DM_GH_ID", gh_id);
            }
            else
            {
                obj[0] = new SqlParameter("DM_GH_ID", DBNull.Value);
            }
            if (pid != null)
            {
                obj[1] = new SqlParameter("DM_PID", pid);
            }
            else
            {
                obj[1] = new SqlParameter("DM_PID", DBNull.Value);
            }
            if (level != null)
            {
                obj[2] = new SqlParameter("DM_Level", level);
            }
            else
            {
                obj[2] = new SqlParameter("DM_Level", DBNull.Value);
            }
            if (pidlist != null)
            {
                obj[3] = new SqlParameter("DM_PIDList", pidlist);
            }
            else
            {
                obj[3] = new SqlParameter("DM_PIDList", DBNull.Value);
            }
            if (lang != null)
            {
                obj[4] = new SqlParameter("DM_Lang", lang);
            }
            else
            {
                obj[4] = new SqlParameter("DM_Lang", DBNull.Value);
            }
            if (langbased != null)
            {
                obj[5] = new SqlParameter("DM_LangBased", langbased);
            }
            else
            {
                obj[5] = new SqlParameter("DM_LangBased", DBNull.Value);
            }
            if (langbasedid != null)
            {
                obj[6] = new SqlParameter("DM_LangBasedId", langbasedid);
            }
            else
            {
                obj[6] = new SqlParameter("DM_LangBasedId", DBNull.Value);
            }
            if (ten != null)
            {
                obj[7] = new SqlParameter("DM_Ten", ten);
            }
            else
            {
                obj[7] = new SqlParameter("DM_Ten", DBNull.Value);
            }
            if (alias != null)
            {
                obj[8] = new SqlParameter("DM_Alias", alias);
            }
            else
            {
                obj[8] = new SqlParameter("DM_Alias", DBNull.Value);
            }
            if (mota != null)
            {
                obj[9] = new SqlParameter("DM_Mota", mota);
            }
            else
            {
                obj[9] = new SqlParameter("DM_Mota", DBNull.Value);
            }
            if (anh != null)
            {
                obj[10] = new SqlParameter("DM_Anh", anh);
            }
            else
            {
                obj[10] = new SqlParameter("DM_Anh", DBNull.Value);
            }
            if (keywords != null)
            {
                obj[11] = new SqlParameter("DM_Keywords", keywords);
            }
            else
            {
                obj[11] = new SqlParameter("DM_Keywords", DBNull.Value);
            }
            if (description != null)
            {
                obj[12] = new SqlParameter("DM_Description", description);
            }
            else
            {
                obj[12] = new SqlParameter("DM_Description", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[13] = new SqlParameter("DM_ThuTu", thutu);
            }
            else
            {
                obj[13] = new SqlParameter("DM_ThuTu", DBNull.Value);
            }
            if (macdinh != null)
            {
                obj[14] = new SqlParameter("DM_MacDinh", macdinh);
            }
            else
            {
                obj[14] = new SqlParameter("DM_MacDinh", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[15] = new SqlParameter("DM_NgayTao", ngaytao);
            }
            else
            {
                obj[15] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            if (ngaycapnhat != null)
            {
                obj[16] = new SqlParameter("DM_NgayCapNhat", ngaycapnhat);
            }
            else
            {
                obj[16] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            if (xem != null)
            {
                obj[17] = new SqlParameter("DM_Xem", xem);
            }
            else
            {
                obj[17] = new SqlParameter("DM_Xem", DBNull.Value);
            }
            if (loai != null)
            {
                obj[18] = new SqlParameter("DM_Loai", loai);
            }
            else
            {
                obj[18] = new SqlParameter("DM_Loai", DBNull.Value);
            }
            if (totalchild != null)
            {
                obj[19] = new SqlParameter("DM_TotalChild", totalchild);
            }
            else
            {
                obj[19] = new SqlParameter("DM_TotalChild", DBNull.Value);
            }
            if (trangchu != null)
            {
                obj[20] = new SqlParameter("DM_TrangChu", trangchu);
            }
            else
            {
                obj[20] = new SqlParameter("DM_TrangChu", DBNull.Value);
            }
            if (noibat != null)
            {
                obj[21] = new SqlParameter("DM_NoiBat", noibat);
            }
            else
            {
                obj[21] = new SqlParameter("DM_NoiBat", DBNull.Value);
            }
            if (moi != null)
            {
                obj[22] = new SqlParameter("DM_Moi", moi);
            }
            else
            {
                obj[22] = new SqlParameter("DM_Moi", DBNull.Value);
            }
            if (rowid != null)
            {
                obj[23] = new SqlParameter("DM_RowId", rowid);
            }
            else
            {
                obj[23] = new SqlParameter("DM_RowId", DBNull.Value);
            }
            if (xoa != null)
            {
                obj[24] = new SqlParameter("DM_Xoa", xoa);
            }
            else
            {
                obj[24] = new SqlParameter("DM_Xoa", DBNull.Value);
            }
            if (active != null)
            {
                obj[25] = new SqlParameter("DM_Active", active);
            }
            else
            {
                obj[25] = new SqlParameter("DM_Active", DBNull.Value);
            }
            if (publish != null)
            {
                obj[26] = new SqlParameter("DM_Publish", publish);
            }
            else
            {
                obj[26] = new SqlParameter("DM_Publish", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc1_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc1 Update(DanhMuc1 Updated)
        {
            DanhMuc1 Item = new DanhMuc1();
            SqlParameter[] obj = new SqlParameter[28];
            obj[0] = new SqlParameter("DM_ID", Updated.ID);
            obj[1] = new SqlParameter("DM_GH_ID", Updated.GH_ID);
            obj[2] = new SqlParameter("DM_PID", Updated.PID);
            obj[3] = new SqlParameter("DM_Level", Updated.Level);
            obj[4] = new SqlParameter("DM_PIDList", Updated.PIDList);
            obj[5] = new SqlParameter("DM_Lang", Updated.Lang);
            obj[6] = new SqlParameter("DM_LangBased", Updated.LangBased);
            obj[7] = new SqlParameter("DM_LangBasedId", Updated.LangBasedId);
            obj[8] = new SqlParameter("DM_Ten", Updated.Ten);
            obj[9] = new SqlParameter("DM_Alias", Updated.Alias);
            obj[10] = new SqlParameter("DM_Mota", Updated.Mota);
            obj[11] = new SqlParameter("DM_Anh", Updated.Anh);
            obj[12] = new SqlParameter("DM_Keywords", Updated.Keywords);
            obj[13] = new SqlParameter("DM_Description", Updated.Description);
            obj[14] = new SqlParameter("DM_ThuTu", Updated.ThuTu);
            obj[15] = new SqlParameter("DM_MacDinh", Updated.MacDinh);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[16] = new SqlParameter("DM_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[16] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[18] = new SqlParameter("DM_Xem", Updated.Xem);
            obj[19] = new SqlParameter("DM_Loai", Updated.Loai);
            obj[20] = new SqlParameter("DM_TotalChild", Updated.TotalChild);
            obj[21] = new SqlParameter("DM_TrangChu", Updated.TrangChu);
            obj[22] = new SqlParameter("DM_NoiBat", Updated.NoiBat);
            obj[23] = new SqlParameter("DM_Moi", Updated.Moi);
            obj[24] = new SqlParameter("DM_RowId", Updated.RowId);
            obj[25] = new SqlParameter("DM_Xoa", Updated.Xoa);
            obj[26] = new SqlParameter("DM_Active", Updated.Active);
            obj[27] = new SqlParameter("DM_Publish", Updated.Publish);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc1_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc1 Update(Int32? id, Int32? gh_id, Int32? pid, Int32? level, String pidlist, String lang, Boolean? langbased, Int32? langbasedid, String ten, String alias, String mota, String anh, String keywords, String description, Int32? thutu, Boolean? macdinh, DateTime? ngaytao, DateTime? ngaycapnhat, Int64? xem, Byte? loai, Int32? totalchild, Boolean? trangchu, Boolean? noibat, Boolean? moi, Guid? rowid, Boolean? xoa, Boolean? active, Boolean? publish)
        {
            DanhMuc1 Item = new DanhMuc1();
            SqlParameter[] obj = new SqlParameter[28];
            if (id != null)
            {
                obj[0] = new SqlParameter("DM_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (gh_id != null)
            {
                obj[1] = new SqlParameter("DM_GH_ID", gh_id);
            }
            else
            {
                obj[1] = new SqlParameter("DM_GH_ID", DBNull.Value);
            }
            if (pid != null)
            {
                obj[2] = new SqlParameter("DM_PID", pid);
            }
            else
            {
                obj[2] = new SqlParameter("DM_PID", DBNull.Value);
            }
            if (level != null)
            {
                obj[3] = new SqlParameter("DM_Level", level);
            }
            else
            {
                obj[3] = new SqlParameter("DM_Level", DBNull.Value);
            }
            if (pidlist != null)
            {
                obj[4] = new SqlParameter("DM_PIDList", pidlist);
            }
            else
            {
                obj[4] = new SqlParameter("DM_PIDList", DBNull.Value);
            }
            if (lang != null)
            {
                obj[5] = new SqlParameter("DM_Lang", lang);
            }
            else
            {
                obj[5] = new SqlParameter("DM_Lang", DBNull.Value);
            }
            if (langbased != null)
            {
                obj[6] = new SqlParameter("DM_LangBased", langbased);
            }
            else
            {
                obj[6] = new SqlParameter("DM_LangBased", DBNull.Value);
            }
            if (langbasedid != null)
            {
                obj[7] = new SqlParameter("DM_LangBasedId", langbasedid);
            }
            else
            {
                obj[7] = new SqlParameter("DM_LangBasedId", DBNull.Value);
            }
            if (ten != null)
            {
                obj[8] = new SqlParameter("DM_Ten", ten);
            }
            else
            {
                obj[8] = new SqlParameter("DM_Ten", DBNull.Value);
            }
            if (alias != null)
            {
                obj[9] = new SqlParameter("DM_Alias", alias);
            }
            else
            {
                obj[9] = new SqlParameter("DM_Alias", DBNull.Value);
            }
            if (mota != null)
            {
                obj[10] = new SqlParameter("DM_Mota", mota);
            }
            else
            {
                obj[10] = new SqlParameter("DM_Mota", DBNull.Value);
            }
            if (anh != null)
            {
                obj[11] = new SqlParameter("DM_Anh", anh);
            }
            else
            {
                obj[11] = new SqlParameter("DM_Anh", DBNull.Value);
            }
            if (keywords != null)
            {
                obj[12] = new SqlParameter("DM_Keywords", keywords);
            }
            else
            {
                obj[12] = new SqlParameter("DM_Keywords", DBNull.Value);
            }
            if (description != null)
            {
                obj[13] = new SqlParameter("DM_Description", description);
            }
            else
            {
                obj[13] = new SqlParameter("DM_Description", DBNull.Value);
            }
            if (thutu != null)
            {
                obj[14] = new SqlParameter("DM_ThuTu", thutu);
            }
            else
            {
                obj[14] = new SqlParameter("DM_ThuTu", DBNull.Value);
            }
            if (macdinh != null)
            {
                obj[15] = new SqlParameter("DM_MacDinh", macdinh);
            }
            else
            {
                obj[15] = new SqlParameter("DM_MacDinh", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[16] = new SqlParameter("DM_NgayTao", ngaytao);
            }
            else
            {
                obj[16] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            if (ngaycapnhat != null)
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", ngaycapnhat);
            }
            else
            {
                obj[17] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            if (xem != null)
            {
                obj[18] = new SqlParameter("DM_Xem", xem);
            }
            else
            {
                obj[18] = new SqlParameter("DM_Xem", DBNull.Value);
            }
            if (loai != null)
            {
                obj[19] = new SqlParameter("DM_Loai", loai);
            }
            else
            {
                obj[19] = new SqlParameter("DM_Loai", DBNull.Value);
            }
            if (totalchild != null)
            {
                obj[20] = new SqlParameter("DM_TotalChild", totalchild);
            }
            else
            {
                obj[20] = new SqlParameter("DM_TotalChild", DBNull.Value);
            }
            if (trangchu != null)
            {
                obj[21] = new SqlParameter("DM_TrangChu", trangchu);
            }
            else
            {
                obj[21] = new SqlParameter("DM_TrangChu", DBNull.Value);
            }
            if (noibat != null)
            {
                obj[22] = new SqlParameter("DM_NoiBat", noibat);
            }
            else
            {
                obj[22] = new SqlParameter("DM_NoiBat", DBNull.Value);
            }
            if (moi != null)
            {
                obj[23] = new SqlParameter("DM_Moi", moi);
            }
            else
            {
                obj[23] = new SqlParameter("DM_Moi", DBNull.Value);
            }
            if (rowid != null)
            {
                obj[24] = new SqlParameter("DM_RowId", rowid);
            }
            else
            {
                obj[24] = new SqlParameter("DM_RowId", DBNull.Value);
            }
            if (xoa != null)
            {
                obj[25] = new SqlParameter("DM_Xoa", xoa);
            }
            else
            {
                obj[25] = new SqlParameter("DM_Xoa", DBNull.Value);
            }
            if (active != null)
            {
                obj[26] = new SqlParameter("DM_Active", active);
            }
            else
            {
                obj[26] = new SqlParameter("DM_Active", DBNull.Value);
            }
            if (publish != null)
            {
                obj[27] = new SqlParameter("DM_Publish", publish);
            }
            else
            {
                obj[27] = new SqlParameter("DM_Publish", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc1_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc1 SelectById(Int32 DM_ID)
        {
            DanhMuc1 Item = new DanhMuc1();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc1_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc1Collection SelectAll()
        {
            DanhMuc1Collection List = new DanhMuc1Collection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc1_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DanhMuc1> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<DanhMuc1> pg = new Pager<DanhMuc1>("sp_tblDanhMuc1_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static DanhMuc1 getFromReader(IDataReader rd)
        {
            DanhMuc1 Item = new DanhMuc1();
            if (rd.FieldExists("DM_ID"))
            {
                Item.ID = (Int32)(rd["DM_ID"]);
            }
            if (rd.FieldExists("DM_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["DM_GH_ID"]);
            }
            if (rd.FieldExists("DM_PID"))
            {
                Item.PID = (Int32)(rd["DM_PID"]);
            }
            if (rd.FieldExists("DM_Level"))
            {
                Item.Level = (Int32)(rd["DM_Level"]);
            }
            if (rd.FieldExists("DM_PIDList"))
            {
                Item.PIDList = (String)(rd["DM_PIDList"]);
            }
            if (rd.FieldExists("DM_Lang"))
            {
                Item.Lang = (String)(rd["DM_Lang"]);
            }
            if (rd.FieldExists("DM_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["DM_LangBased"]);
            }
            if (rd.FieldExists("DM_LangBasedId"))
            {
                Item.LangBasedId = (Int32)(rd["DM_LangBasedId"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                Item.Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("DM_Alias"))
            {
                Item.Alias = (String)(rd["DM_Alias"]);
            }
            if (rd.FieldExists("DM_Mota"))
            {
                Item.Mota = (String)(rd["DM_Mota"]);
            }
            if (rd.FieldExists("DM_Anh"))
            {
                Item.Anh = (String)(rd["DM_Anh"]);
            }
            if (rd.FieldExists("DM_Keywords"))
            {
                Item.Keywords = (String)(rd["DM_Keywords"]);
            }
            if (rd.FieldExists("DM_Description"))
            {
                Item.Description = (String)(rd["DM_Description"]);
            }
            if (rd.FieldExists("DM_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            }
            if (rd.FieldExists("DM_MacDinh"))
            {
                Item.MacDinh = (Boolean)(rd["DM_MacDinh"]);
            }
            if (rd.FieldExists("DM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DM_NgayTao"]);
            }
            if (rd.FieldExists("DM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["DM_NgayCapNhat"]);
            }
            if (rd.FieldExists("DM_Xem"))
            {
                Item.Xem = (Int64)(rd["DM_Xem"]);
            }
            if (rd.FieldExists("DM_Loai"))
            {
                Item.Loai = (Byte)(rd["DM_Loai"]);
            }
            if (rd.FieldExists("DM_TotalChild"))
            {
                Item.TotalChild = (Int32)(rd["DM_TotalChild"]);
            }
            if (rd.FieldExists("DM_TrangChu"))
            {
                Item.TrangChu = (Boolean)(rd["DM_TrangChu"]);
            }
            if (rd.FieldExists("DM_NoiBat"))
            {
                Item.NoiBat = (Boolean)(rd["DM_NoiBat"]);
            }
            if (rd.FieldExists("DM_Moi"))
            {
                Item.Moi = (Boolean)(rd["DM_Moi"]);
            }
            if (rd.FieldExists("DM_RowId"))
            {
                Item.RowId = (Guid)(rd["DM_RowId"]);
            }
            if (rd.FieldExists("DM_Xoa"))
            {
                Item.Xoa = (Boolean)(rd["DM_Xoa"]);
            }
            if (rd.FieldExists("DM_Active"))
            {
                Item.Active = (Boolean)(rd["DM_Active"]);
            }
            if (rd.FieldExists("DM_Publish"))
            {
                Item.Publish = (Boolean)(rd["DM_Publish"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        #endregion
    }
    #endregion
    #endregion
}


