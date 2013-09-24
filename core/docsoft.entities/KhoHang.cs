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
    #region KhoHang
    #region BO
    public class KhoHang : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ten { get; set; }
        public String DiaChi { get; set; }
        public String Ma { get; set; }
        public Guid KV_ID { get; set; }
        #endregion
        #region Contructor
        public KhoHang()
        { }
        #endregion
        #region Customs properties
        public string KV_Ten { get; set; }
        public int SoLuong { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return KhoHangDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class KhoHangCollection : BaseEntityCollection<KhoHang>
    { }
    #endregion
    #region Dal
    public class KhoHangDal
    {
        #region Methods

        public static void DeleteById(Guid KH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblKhoHang_Delete_DeleteById_linhnx", obj);
        }

        public static KhoHang Insert(KhoHang item)
        {
            var Item = new KhoHang();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("KH_ID", item.ID);
            obj[1] = new SqlParameter("KH_Ten", item.Ten);
            obj[2] = new SqlParameter("KH_DiaChi", item.DiaChi);
            obj[3] = new SqlParameter("KH_Ma", item.Ma);
            obj[4] = new SqlParameter("KH_KV_ID", item.KV_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKhoHang_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KhoHang Update(KhoHang item)
        {
            var Item = new KhoHang();
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("KH_ID", item.ID);
            obj[1] = new SqlParameter("KH_Ten", item.Ten);
            obj[2] = new SqlParameter("KH_DiaChi", item.DiaChi);
            obj[3] = new SqlParameter("KH_Ma", item.Ma);
            obj[4] = new SqlParameter("KH_KV_ID", item.KV_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKhoHang_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KhoHang SelectById(Guid KH_ID)
        {
            var Item = new KhoHang();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKhoHang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static KhoHangCollection SelectAll()
        {
            var List = new KhoHangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKhoHang_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<KhoHang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            var pg = new Pager<KhoHang>("sp_tblKhoHang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static KhoHang getFromReader(IDataReader rd)
        {
            var Item = new KhoHang();
            if (rd.FieldExists("KH_ID"))
            {
                Item.ID = (Guid)(rd["KH_ID"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.Ten = (String)(rd["KH_Ten"]);
            }
            if (rd.FieldExists("KH_DiaChi"))
            {
                Item.DiaChi = (String)(rd["KH_DiaChi"]);
            }
            if (rd.FieldExists("KH_Ma"))
            {
                Item.Ma = (String)(rd["KH_Ma"]);
            }
            if (rd.FieldExists("KV_Ten"))
            {
                Item.KV_Ten = (String)(rd["KV_Ten"]);
            }
            if (rd.FieldExists("KV_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["SoLuong"]);
            }
            if (rd.FieldExists("KH_KV_ID"))
            {
                Item.KV_ID = (Guid)(rd["KH_KV_ID"]);
            }
            return Item;
        }
        public static Pager<KhoHang> pagerSearchByHangHoa(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            var pg = new Pager<KhoHang>("sp_tblKhoHang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static KhoHangCollection SelectByHangHoa(string HH_ID)
        {
            var List = new KhoHangCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblKhoHang_Select_SelectByHangHoa_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion
    #endregion
}


