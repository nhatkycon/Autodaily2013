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
    #region LienKet
    #region BO
    public class LienKet : BaseEntity
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
        public LienKet()
        { }
        #endregion
        #region Customs properties
        public String multiID { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LienKetDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LienKetCollection : BaseEntityCollection<LienKet>
    { }
    #endregion
    #region LienKetDal
    public class LienKetDal
    {
        #region Methods

        public static void DeleteById(Int64 LK_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LK_ID", LK_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Delete_DeleteById_linhnx", obj);
        }

        public static LienKet Insert(LienKet Inserted)
        {
            LienKet Item = new LienKet();
            SqlParameter[] obj = new SqlParameter[15];
          
            obj[0] = new SqlParameter("LK_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("LK_MoTa", Inserted.MoTa);       
            obj[2] = new SqlParameter("LK_Anh", Inserted.Anh);
            obj[3] = new SqlParameter("LK_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("LK_NguoiTao", Inserted.NguoiTao);
            obj[5] = new SqlParameter("LK_RowId", Inserted.RowId);          
            obj[6] = new SqlParameter("LK_Active", Inserted.Active);
            obj[7] = new SqlParameter("LK_ThuTu", Inserted.ThuTu);
            obj[8] = new SqlParameter("LK_NgayCapNhat", Inserted.NgayCapNhat);
            obj[9] = new SqlParameter("LK_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[10] = new SqlParameter("LK_NgayDang", Inserted.NgayDang);
            string htl = string.Format("{0:dd/MM/yy}", Inserted.NgayDang);
            if (htl != "01/01/01")
            {
                obj[10] = new SqlParameter("LK_NgayDang", Inserted.NgayDang);
            }
            else
            {
                obj[10] = new SqlParameter("LK_NgayDang", DBNull.Value);
            }
            obj[11] = new SqlParameter("LK_NgayHetHan", Inserted.NgayHetHan);
            string htl1 = string.Format("{0:dd/MM/yy}", Inserted.NgayHetHan);
            if (htl1 != "01/01/01")
            {
                obj[11] = new SqlParameter("LK_NgayHetHan", Inserted.NgayHetHan);
            }
            else
            {
                obj[11] = new SqlParameter("LK_NgayHetHan", DBNull.Value);
            }
            obj[12] = new SqlParameter("LK_HetHan", Inserted.HetHan);
            obj[13] = new SqlParameter("LK_Moi", Inserted.Moi);
            obj[14] = new SqlParameter("LK_url", Inserted.url);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LienKet Update(LienKet Updated)
        {
            LienKet Item = new LienKet();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("LK_ID", Updated.ID);
       
            obj[1] = new SqlParameter("LK_Ten", Updated.Ten);
            obj[2] = new SqlParameter("LK_MoTa", Updated.MoTa);
          
            obj[3] = new SqlParameter("LK_Anh", Updated.Anh);
            obj[4] = new SqlParameter("LK_NgayTao", Updated.NgayTao);
            obj[5] = new SqlParameter("LK_NguoiTao", Updated.NguoiTao);
            obj[6] = new SqlParameter("LK_RowId", Updated.RowId);
        
            obj[7] = new SqlParameter("LK_Active", Updated.Active);
            obj[8] = new SqlParameter("LK_ThuTu", Updated.ThuTu);
            obj[9] = new SqlParameter("LK_NgayCapNhat", Updated.NgayCapNhat);
            obj[10] = new SqlParameter("LK_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[11] = new SqlParameter("LK_NgayDang", Updated.NgayDang);
            string htl = string.Format("{0:dd/MM/yy}", Updated.NgayDang);
            if (htl != "01/01/01")
            {
                obj[11] = new SqlParameter("LK_NgayDang", Updated.NgayDang);
            }
            else
            {
                obj[11] = new SqlParameter("LK_NgayDang", DBNull.Value);
            }
            obj[12] = new SqlParameter("LK_NgayHetHan", Updated.NgayHetHan);
            string htl1 = string.Format("{0:dd/MM/yy}", Updated.NgayHetHan);
            if (htl != "01/01/01")
            {
                obj[12] = new SqlParameter("LK_NgayHetHan", Updated.NgayHetHan);
            }
            else
            {
                obj[12] = new SqlParameter("LK_NgayHetHan", DBNull.Value);
            }
            obj[13] = new SqlParameter("LK_HetHan", Updated.HetHan);
            obj[14] = new SqlParameter("LK_Moi", Updated.Moi);
            obj[15] = new SqlParameter("LK_url", Updated.url);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LienKet SelectById(Int64 LK_ID)
        {
            LienKet Item = new LienKet();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LK_ID", LK_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LienKetCollection SelectAll()
        {
            LienKetCollection List = new LienKetCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<LienKet> pagerNormal(string url, bool rewrite, string sort, string q, string nguoitao, int acp)
        {
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
           
            obj[2] = new SqlParameter("acp", acp);
            obj[3] = new SqlParameter("NguoiTao", nguoitao);
          
            Pager<LienKet> pg = new Pager<LienKet>("sp_tblLienket_Pager_Normal_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
    
        #endregion

        #region Utilities
        public static LienKet getFromReader(IDataReader rd)
        {
            LienKet Item = new LienKet();
            if (rd.FieldExists("LK_ID"))
            {
                Item.ID = (Int64)(rd["LK_ID"]);
            }
            
            if (rd.FieldExists("LK_Ten"))
            {
                Item.Ten = (String)(rd["LK_Ten"]);
            }
            if (rd.FieldExists("LK_url"))
            {
                Item.url = (String)(rd["LK_url"]);
            }
            if (rd.FieldExists("LK_MoTa"))
            {
                Item.MoTa = (String)(rd["LK_MoTa"]);
            }
           
            if (rd.FieldExists("LK_Anh"))
            {
                Item.Anh = (String)(rd["LK_Anh"]);
            }
            if (rd.FieldExists("LK_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["LK_NgayTao"]);
            }
            if (rd.FieldExists("LK_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["LK_NguoiTao"]);
            }
            if (rd.FieldExists("LK_RowId"))
            {
                Item.RowId = (Guid)(rd["LK_RowId"]);
            }
            
            if (rd.FieldExists("LK_Active"))
            {
                Item.Active = (Boolean)(rd["LK_Active"]);
            }
            if (rd.FieldExists("LK_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["LK_ThuTu"]);
            }

            if (rd.FieldExists("LK_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["LK_NgayCapNhat"]);
            }

            if (rd.FieldExists("LK_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["LK_NguoiCapNhat"]);
            }

            if (rd.FieldExists("LK_NgayDang"))
            {
                Item.NgayDang = (DateTime)(rd["LK_NgayDang"]);
            }

            if (rd.FieldExists("LK_NgayHetHan"))
            {
                Item.NgayHetHan = (DateTime)(rd["LK_NgayHetHan"]);
            }

            if (rd.FieldExists("LK_HetHan"))
            {
                Item.HetHan = (Boolean)(rd["LK_HetHan"]);
            }

            if (rd.FieldExists("LK_Moi"))
            {
                Item.Moi = (Boolean)(rd["LK_Moi"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteMultiById(String LK_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LK_ID", LK_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Delete_DeleteMultiById_hungpm", obj);
        }
        public static void UpdateHotMulti(LienKet LK_Hot)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("LK_ID", LK_Hot.multiID);
         
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Update_UpdateHotMultiById_hungpm", obj);
        }
        public static void UpdateMulti(LienKet LK_Active)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("LK_ID", LK_Active.multiID);
            obj[1] = new SqlParameter("LK_Active", LK_Active.Active);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Update_UpdateMultiById_hungpm", obj);
        }
        public static void UpdateHetHanMulti(LienKet LKHetHan)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("LK_ID", LKHetHan.multiID);
            obj[1] = new SqlParameter("LK_HetHan", LKHetHan.HetHan);
            obj[2] = new SqlParameter("LK_NgayHetHan", LKHetHan.NgayHetHan);
            string htl = string.Format("{0:dd/MM/yy}", LKHetHan.NgayHetHan);
            if (htl != "01/01/01")
            {
                obj[2] = new SqlParameter("LK_NgayHetHan", LKHetHan.NgayHetHan);
            }
            else
            {
                obj[2] = new SqlParameter("LK_NgayHetHan", DBNull.Value);
            }
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Update_UpdateHetHanMultiById_hungpm", obj);
        }
        public static LienKetCollection SelectTopTen()
        {
            LienKetCollection List = new LienKetCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Select_SelectTopTen_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static LienKetCollection SelectTop(int Top)
        {
            LienKetCollection List = new LienKetCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLienket_Select_SelectTop_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static LienKetCollection SelectDanhSachHome(int top)
        {
            LienKetCollection List = new LienKetCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssLK_Select_SelectDanhSachHome_linhnx", obj))
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
