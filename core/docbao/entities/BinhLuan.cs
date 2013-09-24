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
    #region BinhLuan
    #region BO
    public class BinhLuan : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 T_ID { get; set; }
        public String Ten { get; set; }
        public String Email { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public Guid RowId { get; set; }
        public Boolean Active { get; set; }
        #endregion
        #region Contructor
        public BinhLuan()
        { }
        public BinhLuan(Int32? id, Int32? t_id, String ten, String email, String noidung, DateTime? ngaytao, Guid? rowid, Boolean? active)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (t_id != null)
            {
                T_ID = t_id.Value;
            }
            Ten = ten;
            Email = email;
            NoiDung = noidung;
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }
            if (rowid != null)
            {
                RowId = rowid.Value;
            }
            if (active != null)
            {
                Active = active.Value;
            }

        }
        #endregion
        #region Customs properties

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
                
                public static void DeleteById(Int32 BL_ID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("BL_ID", BL_ID);
                    SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBinhLuan_Delete_DeleteById_linhnx", obj);
                }                
                public static BinhLuan Insert(BinhLuan Inserted)
                {
                    BinhLuan Item = new BinhLuan();
                    SqlParameter[] obj = new SqlParameter[7];
                    						obj[0] = new SqlParameter("BL_T_ID", Inserted.T_ID);
						obj[1] = new SqlParameter("BL_Ten", Inserted.Ten);
						obj[2] = new SqlParameter("BL_Email", Inserted.Email);
						obj[3] = new SqlParameter("BL_NoiDung", Inserted.NoiDung);
					if(Inserted.NgayTao > DateTime.MinValue)
					{
				obj[4] = new SqlParameter("BL_NgayTao", Inserted.NgayTao);
					}
					else{
						obj[4] = new SqlParameter("BL_NgayTao", DBNull.Value);
					}
						obj[5] = new SqlParameter("BL_RowId", Inserted.RowId);
						obj[6] = new SqlParameter("BL_Active", Inserted.Active);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBinhLuan_Insert_InsertNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                public static BinhLuan Insert(Int32? id,Int32? t_id,String ten,String email,String noidung,DateTime? ngaytao,Guid? rowid,Boolean? active)
                {
                    BinhLuan Item = new BinhLuan();
                    SqlParameter[] obj = new SqlParameter[7];
                    					if(t_id!=null)
					{
						obj[0] = new SqlParameter("BL_T_ID", t_id);
					}
					else{
						obj[0] = new SqlParameter("BL_T_ID", DBNull.Value);
					}
					if(ten!=null)
					{
						obj[1] = new SqlParameter("BL_Ten", ten);
					}
					else{
						obj[1] = new SqlParameter("BL_Ten", DBNull.Value);
					}
					if(email!=null)
					{
						obj[2] = new SqlParameter("BL_Email", email);
					}
					else{
						obj[2] = new SqlParameter("BL_Email", DBNull.Value);
					}
					if(noidung!=null)
					{
						obj[3] = new SqlParameter("BL_NoiDung", noidung);
					}
					else{
						obj[3] = new SqlParameter("BL_NoiDung", DBNull.Value);
					}
					if(ngaytao!=null)
					{
						obj[4] = new SqlParameter("BL_NgayTao", ngaytao);
					}
					else{
						obj[4] = new SqlParameter("BL_NgayTao", DBNull.Value);
					}
					if(rowid!=null)
					{
						obj[5] = new SqlParameter("BL_RowId", rowid);
					}
					else{
						obj[5] = new SqlParameter("BL_RowId", DBNull.Value);
					}
					if(active!=null)
					{
						obj[6] = new SqlParameter("BL_Active", active);
					}
					else{
						obj[6] = new SqlParameter("BL_Active", DBNull.Value);
					}

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBinhLuan_Insert_InsertNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                public static BinhLuan Update(BinhLuan Updated)
                {
                    BinhLuan Item = new BinhLuan();
                    SqlParameter[] obj = new SqlParameter[8];
                    				obj[0] = new SqlParameter("BL_ID", Updated.ID);
				obj[1] = new SqlParameter("BL_T_ID", Updated.T_ID);
				obj[2] = new SqlParameter("BL_Ten", Updated.Ten);
				obj[3] = new SqlParameter("BL_Email", Updated.Email);
				obj[4] = new SqlParameter("BL_NoiDung", Updated.NoiDung);
					if(Updated.NgayTao > DateTime.MinValue)
					{
				obj[5] = new SqlParameter("BL_NgayTao", Updated.NgayTao);
					}
					else{
						obj[5] = new SqlParameter("BL_NgayTao", DBNull.Value);
					}
				obj[6] = new SqlParameter("BL_RowId", Updated.RowId);
				obj[7] = new SqlParameter("BL_Active", Updated.Active);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBinhLuan_Update_UpdateNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                public static BinhLuan Update(Int32? id,Int32? t_id,String ten,String email,String noidung,DateTime? ngaytao,Guid? rowid,Boolean? active)
                {
                    BinhLuan Item = new BinhLuan();
                    SqlParameter[] obj = new SqlParameter[8];
                    					if(id!=null)
					{
						obj[0] = new SqlParameter("BL_ID", id);
					}
					else{
						obj[0] = new SqlParameter("BL_ID", DBNull.Value);
					}
					if(t_id!=null)
					{
						obj[1] = new SqlParameter("BL_T_ID", t_id);
					}
					else{
						obj[1] = new SqlParameter("BL_T_ID", DBNull.Value);
					}
					if(ten!=null)
					{
						obj[2] = new SqlParameter("BL_Ten", ten);
					}
					else{
						obj[2] = new SqlParameter("BL_Ten", DBNull.Value);
					}
					if(email!=null)
					{
						obj[3] = new SqlParameter("BL_Email", email);
					}
					else{
						obj[3] = new SqlParameter("BL_Email", DBNull.Value);
					}
					if(noidung!=null)
					{
						obj[4] = new SqlParameter("BL_NoiDung", noidung);
					}
					else{
						obj[4] = new SqlParameter("BL_NoiDung", DBNull.Value);
					}
					if(ngaytao!=null)
					{
						obj[5] = new SqlParameter("BL_NgayTao", ngaytao);
					}
					else{
						obj[5] = new SqlParameter("BL_NgayTao", DBNull.Value);
					}
					if(rowid!=null)
					{
						obj[6] = new SqlParameter("BL_RowId", rowid);
					}
					else{
						obj[6] = new SqlParameter("BL_RowId", DBNull.Value);
					}
					if(active!=null)
					{
						obj[7] = new SqlParameter("BL_Active", active);
					}
					else{
						obj[7] = new SqlParameter("BL_Active", DBNull.Value);
					}

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBinhLuan_Update_UpdateNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                public static BinhLuan SelectById(Int32 BL_ID)
                {
                    BinhLuan Item = new BinhLuan();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("BL_ID", BL_ID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBinhLuan_Select_SelectById_linhnx", obj))
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
                    BinhLuanCollection List = new BinhLuanCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBinhLuan_Select_SelectAll_linhnx"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<BinhLuan> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<BinhLuan> pg = new Pager<BinhLuan>("tblRss_sp_tblBinhLuan_Pager_Normal_linhnx", "q", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
                #region Utilities                
                public static BinhLuan getFromReader(IDataReader rd)
                {
                    BinhLuan Item = new BinhLuan();
                    					if(rd.FieldExists("BL_ID")){
					Item.ID = (Int32)(rd["BL_ID"]);
					}
					if(rd.FieldExists("BL_T_ID")){
					Item.T_ID = (Int32)(rd["BL_T_ID"]);
					}
					if(rd.FieldExists("BL_Ten")){
					Item.Ten = (String)(rd["BL_Ten"]);
					}
					if(rd.FieldExists("BL_Email")){
					Item.Email = (String)(rd["BL_Email"]);
					}
					if(rd.FieldExists("BL_NoiDung")){
					Item.NoiDung = (String)(rd["BL_NoiDung"]);
					}
					if(rd.FieldExists("BL_NgayTao")){
					Item.NgayTao = (DateTime)(rd["BL_NgayTao"]);
					}
					if(rd.FieldExists("BL_RowId")){
					Item.RowId = (Guid)(rd["BL_RowId"]);
					}
					if(rd.FieldExists("BL_Active")){
					Item.Active = (Boolean)(rd["BL_Active"]);
					}
                    return Item;                    
                }
                 #endregion
                #region Extend
                public static BinhLuanCollection SelectByTinId(string T_ID, string Active)
                {
                    BinhLuanCollection List = new BinhLuanCollection();
                    SqlParameter[] obj = new SqlParameter[2];
                    obj[0] = new SqlParameter("T_ID", T_ID);
                    if (string.IsNullOrEmpty(Active))
                    {
                        obj[1] = new SqlParameter("Active", DBNull.Value);
                    }
                    else
                    {
                        obj[1] = new SqlParameter("Active", Active);
                    }
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssBinhLuan_Select_SelectByTinId_linhnx", obj))
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

 