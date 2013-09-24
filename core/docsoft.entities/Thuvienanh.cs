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
    #region ThuVienAnh
    #region BO
    public class ThuVienAnh : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
     
     
        public String Ten { get; set; }
        public String url { get; set; }
        public String MoTa { get; set; }
      
        public String Anh { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public Guid RowId { get; set; }
      
     
        public Boolean Active { get; set; }
        public Int32 ThuTu { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayDang { get; set; }
        public DateTime NgayHetHan { get; set; }
        public Boolean HetHan { get; set; }
        public Boolean Moi { get; set; }
        #endregion
        #region Contructor
        public ThuVienAnh()
        { }
        #endregion
        #region Customs properties
        public String multiID { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuVienAnhDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuVienAnhCollection : BaseEntityCollection<ThuVienAnh>
    { }
    #endregion
    #region ThuVienAnhDal
    public class ThuVienAnhDal
    {
        #region Methods

        public static void DeleteById(Int64 TVA_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TVA_ID", TVA_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Delete_DeleteById_linhnx", obj);
        }

        public static ThuVienAnh Insert(ThuVienAnh Inserted)
        {
            ThuVienAnh Item = new ThuVienAnh();
            SqlParameter[] obj = new SqlParameter[15];
          
            obj[0] = new SqlParameter("TVA_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("TVA_MoTa", Inserted.MoTa);       
            obj[2] = new SqlParameter("TVA_Anh", Inserted.Anh);
            obj[3] = new SqlParameter("TVA_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("TVA_NguoiTao", Inserted.NguoiTao);
            obj[5] = new SqlParameter("TVA_RowId", Inserted.RowId);          
            obj[6] = new SqlParameter("TVA_Active", Inserted.Active);
            obj[7] = new SqlParameter("TVA_ThuTu", Inserted.ThuTu);
            obj[8] = new SqlParameter("TVA_NgayCapNhat", Inserted.NgayCapNhat);
            obj[9] = new SqlParameter("TVA_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[10] = new SqlParameter("TVA_NgayDang", Inserted.NgayDang);
            string htl = string.Format("{0:dd/MM/yy}", Inserted.NgayDang);
            if (htl != "01/01/01")
            {
                obj[10] = new SqlParameter("TVA_NgayDang", Inserted.NgayDang);
            }
            else
            {
                obj[10] = new SqlParameter("TVA_NgayDang", DBNull.Value);
            }
            obj[11] = new SqlParameter("TVA_NgayHetHan", Inserted.NgayHetHan);
            string htl1 = string.Format("{0:dd/MM/yy}", Inserted.NgayHetHan);
            if (htl1 != "01/01/01")
            {
                obj[11] = new SqlParameter("TVA_NgayHetHan", Inserted.NgayHetHan);
            }
            else
            {
                obj[11] = new SqlParameter("TVA_NgayHetHan", DBNull.Value);
            }
            obj[12] = new SqlParameter("TVA_HetHan", Inserted.HetHan);
            obj[13] = new SqlParameter("TVA_Moi", Inserted.Moi);
            obj[14] = new SqlParameter("TVA_url", Inserted.url);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuVienAnh Update(ThuVienAnh Updated)
        {
            ThuVienAnh Item = new ThuVienAnh();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("TVA_ID", Updated.ID);
       
            obj[1] = new SqlParameter("TVA_Ten", Updated.Ten);
            obj[2] = new SqlParameter("TVA_MoTa", Updated.MoTa);
          
            obj[3] = new SqlParameter("TVA_Anh", Updated.Anh);
            obj[4] = new SqlParameter("TVA_NgayTao", Updated.NgayTao);
            obj[5] = new SqlParameter("TVA_NguoiTao", Updated.NguoiTao);
            obj[6] = new SqlParameter("TVA_RowId", Updated.RowId);
        
            obj[7] = new SqlParameter("TVA_Active", Updated.Active);
            obj[8] = new SqlParameter("TVA_ThuTu", Updated.ThuTu);
            obj[9] = new SqlParameter("TVA_NgayCapNhat", Updated.NgayCapNhat);
            obj[10] = new SqlParameter("TVA_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[11] = new SqlParameter("TVA_NgayDang", Updated.NgayDang);
            string htl = string.Format("{0:dd/MM/yy}", Updated.NgayDang);
            if (htl != "01/01/01")
            {
                obj[11] = new SqlParameter("TVA_NgayDang", Updated.NgayDang);
            }
            else
            {
                obj[11] = new SqlParameter("TVA_NgayDang", DBNull.Value);
            }
            obj[12] = new SqlParameter("TVA_NgayHetHan", Updated.NgayHetHan);
            string htl1 = string.Format("{0:dd/MM/yy}", Updated.NgayHetHan);
            if (htl != "01/01/01")
            {
                obj[12] = new SqlParameter("TVA_NgayHetHan", Updated.NgayHetHan);
            }
            else
            {
                obj[12] = new SqlParameter("TVA_NgayHetHan", DBNull.Value);
            }
            obj[13] = new SqlParameter("TVA_HetHan", Updated.HetHan);
            obj[14] = new SqlParameter("TVA_Moi", Updated.Moi);
            obj[15] = new SqlParameter("TVA_url", Updated.url);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuVienAnh SelectById(Int64 TVA_ID)
        {
            ThuVienAnh Item = new ThuVienAnh();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TVA_ID", TVA_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuVienAnhCollection SelectAll()
        {
            ThuVienAnhCollection List = new ThuVienAnhCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ThuVienAnh> pagerNormal(string url, bool rewrite, string sort, string q, string nguoitao, int acp)
        {
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
           
            obj[2] = new SqlParameter("acp", acp);
            obj[3] = new SqlParameter("NguoiTao", nguoitao);
          
            Pager<ThuVienAnh> pg = new Pager<ThuVienAnh>("sp_tblThuVienAnh_Pager_Normal_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
    
        #endregion

        #region Utilities
        public static ThuVienAnh getFromReader(IDataReader rd)
        {
            ThuVienAnh Item = new ThuVienAnh();
            if (rd.FieldExists("TVA_ID"))
            {
                Item.ID = (Int64)(rd["TVA_ID"]);
            }
            
            if (rd.FieldExists("TVA_Ten"))
            {
                Item.Ten = (String)(rd["TVA_Ten"]);
            }
            if (rd.FieldExists("TVA_url"))
            {
                Item.url = (String)(rd["TVA_url"]);
            }
            if (rd.FieldExists("TVA_MoTa"))
            {
                Item.MoTa = (String)(rd["TVA_MoTa"]);
            }
           
            if (rd.FieldExists("TVA_Anh"))
            {
                Item.Anh = (String)(rd["TVA_Anh"]);
            }
            if (rd.FieldExists("TVA_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TVA_NgayTao"]);
            }
            if (rd.FieldExists("TVA_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TVA_NguoiTao"]);
            }
            if (rd.FieldExists("TVA_RowId"))
            {
                Item.RowId = (Guid)(rd["TVA_RowId"]);
            }
            
            if (rd.FieldExists("TVA_Active"))
            {
                Item.Active = (Boolean)(rd["TVA_Active"]);
            }
            if (rd.FieldExists("TVA_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TVA_ThuTu"]);
            }

            if (rd.FieldExists("TVA_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TVA_NgayCapNhat"]);
            }

            if (rd.FieldExists("TVA_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TVA_NguoiCapNhat"]);
            }

            if (rd.FieldExists("TVA_NgayDang"))
            {
                Item.NgayDang = (DateTime)(rd["TVA_NgayDang"]);
            }

            if (rd.FieldExists("TVA_NgayHetHan"))
            {
                Item.NgayHetHan = (DateTime)(rd["TVA_NgayHetHan"]);
            }

            if (rd.FieldExists("TVA_HetHan"))
            {
                Item.HetHan = (Boolean)(rd["TVA_HetHan"]);
            }

            if (rd.FieldExists("TVA_Moi"))
            {
                Item.Moi = (Boolean)(rd["TVA_Moi"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteMultiById(String TVA_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TVA_ID", TVA_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Delete_DeleteMultiById_hungpm", obj);
        }
        public static void UpdateHotMulti(ThuVienAnh TVA_Hot)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TVA_ID", TVA_Hot.multiID);
         
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Update_UpdateHotMultiById_hungpm", obj);
        }
        public static void UpdateMulti(ThuVienAnh TVA_Active)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TVA_ID", TVA_Active.multiID);
            obj[1] = new SqlParameter("TVA_Active", TVA_Active.Active);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Update_UpdateMultiById_hungpm", obj);
        }
        public static void UpdateHetHanMulti(ThuVienAnh TVAHetHan)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TVA_ID", TVAHetHan.multiID);
            obj[1] = new SqlParameter("TVA_HetHan", TVAHetHan.HetHan);
            obj[2] = new SqlParameter("TVA_NgayHetHan", TVAHetHan.NgayHetHan);
            string htl = string.Format("{0:dd/MM/yy}", TVAHetHan.NgayHetHan);
            if (htl != "01/01/01")
            {
                obj[2] = new SqlParameter("TVA_NgayHetHan", TVAHetHan.NgayHetHan);
            }
            else
            {
                obj[2] = new SqlParameter("TVA_NgayHetHan", DBNull.Value);
            }
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Update_UpdateHetHanMultiById_hungpm", obj);
        }
        public static ThuVienAnhCollection SelectTopTen()
        {
            ThuVienAnhCollection List = new ThuVienAnhCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Select_SelectTopTen_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static ThuVienAnhCollection SelectTop(int Top)
        {
            ThuVienAnhCollection List = new ThuVienAnhCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuVienAnh_Select_SelectTop_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static ThuVienAnhCollection SelectDanhSachHome(int top)
        {
            ThuVienAnhCollection List = new ThuVienAnhCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTVA_Select_SelectDanhSachHome_linhnx", obj))
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
