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
    #region Nhom
    #region BO
    public class Nhom : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public String Ten { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Active { get; set; }
        public Boolean Hot { get; set; }
        public Boolean Hot1 { get; set; }
        public Boolean Hot2 { get; set; }
        public Boolean Hot3 { get; set; }
        #endregion
        #region Contructor
        public Nhom()
        { }
        public Nhom(Int32? id, Int32? dm_id, String ten, Int32? thutu, Boolean? active, Boolean? hot, Boolean? hot1, Boolean? hot2, Boolean? hot3)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (dm_id != null)
            {
                DM_ID = dm_id.Value;
            }
            Ten = ten;
            if (thutu != null)
            {
                ThuTu = thutu.Value;
            }
            if (active != null)
            {
                Active = active.Value;
            }
            if (hot != null)
            {
                Hot = hot.Value;
            }
            if (hot1 != null)
            {
                Hot1 = hot1.Value;
            }
            if (hot2 != null)
            {
                Hot2 = hot2.Value;
            }
            if (hot3 != null)
            {
                Hot3 = hot3.Value;
            }

        }
        #endregion
        #region Customs properties
        public docbao.entitites.DanhMuc _DanhMuc { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return NhomDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class NhomCollection : BaseEntityCollection<Nhom>
    { }
    #endregion
    #region Dal
    public class NhomDal
    { 
                #region Methods
                
                public static void DeleteById(Int32 N_ID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("N_ID", N_ID);
                    SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhom_Delete_DeleteById_linhnx", obj);
                }                
                public static Nhom Insert(Nhom Inserted)
                {
                    Nhom Item = new Nhom();
                    SqlParameter[] obj = new SqlParameter[8];
                    obj[0] = new SqlParameter("N_DM_ID", Inserted.DM_ID);
					obj[1] = new SqlParameter("N_Ten", Inserted.Ten);
					obj[2] = new SqlParameter("N_ThuTu", Inserted.ThuTu);
					obj[3] = new SqlParameter("N_Active", Inserted.Active);
					obj[4] = new SqlParameter("N_Hot", Inserted.Hot);
					obj[5] = new SqlParameter("N_Hot1", Inserted.Hot1);
					obj[6] = new SqlParameter("N_Hot2", Inserted.Hot2);
					obj[7] = new SqlParameter("N_Hot3", Inserted.Hot3);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhom_Insert_InsertNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                public static Nhom Insert(Int32? id,Int32? dm_id,String ten,Int32? thutu,Boolean? active,Boolean? hot,Boolean? hot1,Boolean? hot2,Boolean? hot3)
                {
                    Nhom Item = new Nhom();
                    SqlParameter[] obj = new SqlParameter[8];
                    					if(dm_id!=null)
					{
						obj[0] = new SqlParameter("N_DM_ID", dm_id);
					}
					else{
						obj[0] = new SqlParameter("N_DM_ID", DBNull.Value);
					}
					if(ten!=null)
					{
						obj[1] = new SqlParameter("N_Ten", ten);
					}
					else{
						obj[1] = new SqlParameter("N_Ten", DBNull.Value);
					}
					if(thutu!=null)
					{
						obj[2] = new SqlParameter("N_ThuTu", thutu);
					}
					else{
						obj[2] = new SqlParameter("N_ThuTu", DBNull.Value);
					}
					if(active!=null)
					{
						obj[3] = new SqlParameter("N_Active", active);
					}
					else{
						obj[3] = new SqlParameter("N_Active", DBNull.Value);
					}
					if(hot!=null)
					{
						obj[4] = new SqlParameter("N_Hot", hot);
					}
					else{
						obj[4] = new SqlParameter("N_Hot", DBNull.Value);
					}
					if(hot1!=null)
					{
						obj[5] = new SqlParameter("N_Hot1", hot1);
					}
					else{
						obj[5] = new SqlParameter("N_Hot1", DBNull.Value);
					}
					if(hot2!=null)
					{
						obj[6] = new SqlParameter("N_Hot2", hot2);
					}
					else{
						obj[6] = new SqlParameter("N_Hot2", DBNull.Value);
					}
					if(hot3!=null)
					{
						obj[7] = new SqlParameter("N_Hot3", hot3);
					}
					else{
						obj[7] = new SqlParameter("N_Hot3", DBNull.Value);
					}

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhom_Insert_InsertNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                public static Nhom Update(Nhom Updated)
                {
                    Nhom Item = new Nhom();
                    SqlParameter[] obj = new SqlParameter[9];
                    				obj[0] = new SqlParameter("N_ID", Updated.ID);
				obj[1] = new SqlParameter("N_DM_ID", Updated.DM_ID);
				obj[2] = new SqlParameter("N_Ten", Updated.Ten);
				obj[3] = new SqlParameter("N_ThuTu", Updated.ThuTu);
				obj[4] = new SqlParameter("N_Active", Updated.Active);
				obj[5] = new SqlParameter("N_Hot", Updated.Hot);
				obj[6] = new SqlParameter("N_Hot1", Updated.Hot1);
				obj[7] = new SqlParameter("N_Hot2", Updated.Hot2);
				obj[8] = new SqlParameter("N_Hot3", Updated.Hot3);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhom_Update_UpdateNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                public static Nhom Update(Int32? id,Int32? dm_id,String ten,Int32? thutu,Boolean? active,Boolean? hot,Boolean? hot1,Boolean? hot2,Boolean? hot3)
                {
                    Nhom Item = new Nhom();
                    SqlParameter[] obj = new SqlParameter[9];
                    					if(id!=null)
					{
						obj[0] = new SqlParameter("N_ID", id);
					}
					else{
						obj[0] = new SqlParameter("N_ID", DBNull.Value);
					}
					if(dm_id!=null)
					{
						obj[1] = new SqlParameter("N_DM_ID", dm_id);
					}
					else{
						obj[1] = new SqlParameter("N_DM_ID", DBNull.Value);
					}
					if(ten!=null)
					{
						obj[2] = new SqlParameter("N_Ten", ten);
					}
					else{
						obj[2] = new SqlParameter("N_Ten", DBNull.Value);
					}
					if(thutu!=null)
					{
						obj[3] = new SqlParameter("N_ThuTu", thutu);
					}
					else{
						obj[3] = new SqlParameter("N_ThuTu", DBNull.Value);
					}
					if(active!=null)
					{
						obj[4] = new SqlParameter("N_Active", active);
					}
					else{
						obj[4] = new SqlParameter("N_Active", DBNull.Value);
					}
					if(hot!=null)
					{
						obj[5] = new SqlParameter("N_Hot", hot);
					}
					else{
						obj[5] = new SqlParameter("N_Hot", DBNull.Value);
					}
					if(hot1!=null)
					{
						obj[6] = new SqlParameter("N_Hot1", hot1);
					}
					else{
						obj[6] = new SqlParameter("N_Hot1", DBNull.Value);
					}
					if(hot2!=null)
					{
						obj[7] = new SqlParameter("N_Hot2", hot2);
					}
					else{
						obj[7] = new SqlParameter("N_Hot2", DBNull.Value);
					}
					if(hot3!=null)
					{
						obj[8] = new SqlParameter("N_Hot3", hot3);
					}
					else{
						obj[8] = new SqlParameter("N_Hot3", DBNull.Value);
					}

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhom_Update_UpdateNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                public static Nhom SelectById(Int32 N_ID)
                {
                    Nhom Item = new Nhom();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("N_ID", N_ID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhom_Select_SelectById_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                public static NhomCollection SelectAll()
                {
                    NhomCollection List = new NhomCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhom_Select_SelectAll_linhnx"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
                public static NhomCollection SelectAll(SqlConnection con)
                {
                    NhomCollection List = new NhomCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssNhom_Select_SelectAll_linhnx"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<Nhom> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<Nhom> pg = new Pager<Nhom>("tblRss_sp_tblNhom_Pager_Normal_linhnx", "q", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
                #region Utilities                
                public static Nhom getFromReader(IDataReader rd)
                {
                    Nhom Item = new Nhom();
                    docbao.entitites.DanhMuc _Item = docbao.entitites.DanhMucDal.getFromReader(rd);
                    Item._DanhMuc = _Item;
                    if(rd.FieldExists("N_ID")){
					Item.ID = (Int32)(rd["N_ID"]);
					}
					if(rd.FieldExists("N_DM_ID")){
					Item.DM_ID = (Int32)(rd["N_DM_ID"]);
					}
					if(rd.FieldExists("N_Ten")){
					Item.Ten = (String)(rd["N_Ten"]);
					}
					if(rd.FieldExists("N_ThuTu")){
					Item.ThuTu = (Int32)(rd["N_ThuTu"]);
					}
					if(rd.FieldExists("N_Active")){
					Item.Active = (Boolean)(rd["N_Active"]);
					}
					if(rd.FieldExists("N_Hot")){
					Item.Hot = (Boolean)(rd["N_Hot"]);
					}
					if(rd.FieldExists("N_Hot1")){
					Item.Hot1 = (Boolean)(rd["N_Hot1"]);
					}
					if(rd.FieldExists("N_Hot2")){
					Item.Hot2 = (Boolean)(rd["N_Hot2"]);
					}
					if(rd.FieldExists("N_Hot3")){
					Item.Hot3 = (Boolean)(rd["N_Hot3"]);
					}
                    return Item;                    
                }
                 #endregion
                #region Extend
                public static NhomCollection SelectByTin(string T_ID)
                {
                    NhomCollection List = new NhomCollection();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("T_ID", T_ID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Select_SelectByTin_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
                public static NhomCollection SelectByDm(SqlConnection con, string DM_Ma)
                {
                    NhomCollection List = new NhomCollection();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("DM_Ma", DM_Ma);
                    using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tblRss_sp_tblRssNhomTin_Select_SelectByDm_linhnx", obj))
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
