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
    #region CauHoi
    #region BO
    public class CauHoi : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public Int32 Diem { get; set; }
        public Guid LOAI_ID { get; set; }
        public Int32 Luot { get; set; }
        public Boolean KetQua { get; set; }
        #endregion
        #region Contructor
        public CauHoi()
        { }
        #endregion
        #region Customs properties

        public DanhMuc _DanhMuc { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return CauHoiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class CauHoiCollection : BaseEntityCollection<CauHoi>
    { }
    #endregion
    #region Dal
    public class CauHoiDal
    {
        #region Methods

        public static void DeleteById(Guid CH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CH_ID", CH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_CauHoi_Delete_DeleteById_linhnx", obj);
        }

        public static CauHoi Insert(CauHoi item)
        {
            var Item = new CauHoi();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("CH_ID", item.ID);
            obj[1] = new SqlParameter("CH_Ten", item.Ten);
            obj[2] = new SqlParameter("CH_MoTa", item.MoTa);
            obj[3] = new SqlParameter("CH_Diem", item.Diem);
            obj[4] = new SqlParameter("CH_LOAI_ID", item.LOAI_ID);
            obj[5] = new SqlParameter("CH_Luot", item.Luot);
            obj[6] = new SqlParameter("CH_KetQua", item.KetQua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_CauHoi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static CauHoi Update(CauHoi item)
        {
            var Item = new CauHoi();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("CH_ID", item.ID);
            obj[1] = new SqlParameter("CH_Ten", item.Ten);
            obj[2] = new SqlParameter("CH_MoTa", item.MoTa);
            obj[3] = new SqlParameter("CH_Diem", item.Diem);
            obj[4] = new SqlParameter("CH_LOAI_ID", item.LOAI_ID);
            obj[5] = new SqlParameter("CH_Luot", item.Luot);
            obj[6] = new SqlParameter("CH_KetQua", item.KetQua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_CauHoi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static CauHoi SelectById(Guid CH_ID)
        {
            var Item = new CauHoi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CH_ID", CH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_CauHoi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static CauHoiCollection SelectAll(SqlConnection con)
        {
            var List = new CauHoiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_CauHoi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static CauHoiCollection SelectAll()
        {
            return SelectAll(DAL.con());
        }
        public static Pager<CauHoi> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<CauHoi>("sp_tblAuto_CauHoi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static CauHoi getFromReader(IDataReader rd)
        {
            var Item = new CauHoi();
            if (rd.FieldExists("CH_ID"))
            {
                Item.ID = (Guid)(rd["CH_ID"]);
            }
            if (rd.FieldExists("CH_Ten"))
            {
                Item.Ten = (String)(rd["CH_Ten"]);
            }
            if (rd.FieldExists("CH_MoTa"))
            {
                Item.MoTa = (String)(rd["CH_MoTa"]);
            }
            if (rd.FieldExists("CH_Diem"))
            {
                Item.Diem = (Int32)(rd["CH_Diem"]);
            }
            if (rd.FieldExists("CH_LOAI_ID"))
            {
                Item.LOAI_ID = (Guid)(rd["CH_LOAI_ID"]);
            }
            if (rd.FieldExists("CH_Luot"))
            {
                Item.Luot = (Int32)(rd["CH_Luot"]);
            }
            if (rd.FieldExists("CH_KetQua"))
            {
                Item.KetQua = (Boolean)(rd["CH_KetQua"]);
            }
            Item._DanhMuc = DanhMucDal.getFromReader(rd);
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion
}


