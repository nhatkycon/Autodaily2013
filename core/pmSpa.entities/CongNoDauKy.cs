using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core;
using linh.core.dal;

namespace pmSpa.entities
{

    #region CongNoDauKy
        #region BO
		public class CongNoDauKy: BaseEntity
		{			
			#region Properties
			public  Guid ID{get;set;}
			public  Guid KH_ID{get;set;}
			public  Double Tien{get;set;}
			public  DateTime NgayTao{get;set;}
			public  String NguoiTao{get;set;}
			public  DateTime NgayCapNhat{get;set;}
			public  String NguoiCapNhat{get;set;}
			public  Boolean No{get;set;}
			#endregion
			#region Contructor
			public CongNoDauKy()
			{ }
			#endregion
			#region Customs properties
            public KhachHang _KhachHang { get; set; }
			
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return CongNoDauKyDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class CongNoDauKyCollection : BaseEntityCollection<CongNoDauKy>
			{}			
		#endregion
        #region Dal
            public class CongNoDauKyDal
            {   
                #region Methods
                
                public static void DeleteById(Guid CNKH_ID)
                {
                    var obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("CNKH_ID", CNKH_ID);
                    SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblCongNoDauKy_Delete_DeleteById_linhnx", obj);
                }                
                
                public static CongNoDauKy Insert(CongNoDauKy item)
                {
                    var Item = new CongNoDauKy();
                    var obj = new SqlParameter[8];
                    						obj[0] = new SqlParameter("CNKH_ID", item.ID);
						obj[1] = new SqlParameter("CNKH_KH_ID", item.KH_ID);
						obj[2] = new SqlParameter("CNKH_Tien", item.Tien);
					if(item.NgayTao > DateTime.MinValue)
					{
				obj[3] = new SqlParameter("CNKH_NgayTao", item.NgayTao);
					}
					else{
						obj[3] = new SqlParameter("CNKH_NgayTao", DBNull.Value);
					}
						obj[4] = new SqlParameter("CNKH_NguoiTao", item.NguoiTao);
					if(item.NgayCapNhat > DateTime.MinValue)
					{
				obj[5] = new SqlParameter("CNKH_NgayCapNhat", item.NgayCapNhat);
					}
					else{
						obj[5] = new SqlParameter("CNKH_NgayCapNhat", DBNull.Value);
					}
						obj[6] = new SqlParameter("CNKH_NguoiCapNhat", item.NguoiCapNhat);
						obj[7] = new SqlParameter("CNKH_No", item.No);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCongNoDauKy_Insert_InsertNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static CongNoDauKy Update(CongNoDauKy item)
                {
                    var Item = new CongNoDauKy();
                    var obj = new SqlParameter[8];
                    				obj[0] = new SqlParameter("CNKH_ID", item.ID);
				obj[1] = new SqlParameter("CNKH_KH_ID", item.KH_ID);
				obj[2] = new SqlParameter("CNKH_Tien", item.Tien);
					if(item.NgayTao > DateTime.MinValue)
					{
				obj[3] = new SqlParameter("CNKH_NgayTao", item.NgayTao);
					}
					else{
						obj[3] = new SqlParameter("CNKH_NgayTao", DBNull.Value);
					}
				obj[4] = new SqlParameter("CNKH_NguoiTao", item.NguoiTao);
					if(item.NgayCapNhat > DateTime.MinValue)
					{
				obj[5] = new SqlParameter("CNKH_NgayCapNhat", item.NgayCapNhat);
					}
					else{
						obj[5] = new SqlParameter("CNKH_NgayCapNhat", DBNull.Value);
					}
				obj[6] = new SqlParameter("CNKH_NguoiCapNhat", item.NguoiCapNhat);
				obj[7] = new SqlParameter("CNKH_No", item.No);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCongNoDauKy_Update_UpdateNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static CongNoDauKy SelectById(Guid CNKH_ID)
                {
                    var Item = new CongNoDauKy();
                    var obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("CNKH_ID", CNKH_ID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCongNoDauKy_Select_SelectById_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static CongNoDauKyCollection SelectAll()
                {
                    var List = new CongNoDauKyCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCongNoDauKy_Select_SelectAll_linhnx"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<CongNoDauKy> pagerNormal(string url,bool rewrite,string sort,string q,int size)
				{
					var obj = new SqlParameter[2];
            		obj[0] = new SqlParameter("Sort", sort);
					if (!string.IsNullOrEmpty(q))
            		{
                		obj[1] = new SqlParameter("q", q);
            		}
            		else
            		{
                		obj[1] = new SqlParameter("q",DBNull.Value);
            		}
					
					var pg = new Pager<CongNoDauKy>("sp_tblCongNoDauKy_Pager_Normal_linhnx", "page", size, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static CongNoDauKy getFromReader(IDataReader rd)
                {
                    var Item = new CongNoDauKy();
                    					if(rd.FieldExists("CNKH_ID")){
					Item.ID = (Guid)(rd["CNKH_ID"]);
					}
					if(rd.FieldExists("CNKH_KH_ID")){
					Item.KH_ID = (Guid)(rd["CNKH_KH_ID"]);
					}
					if(rd.FieldExists("CNKH_Tien")){
					Item.Tien = (Double)(rd["CNKH_Tien"]);
					}
					if(rd.FieldExists("CNKH_NgayTao")){
					Item.NgayTao = (DateTime)(rd["CNKH_NgayTao"]);
					}
					if(rd.FieldExists("CNKH_NguoiTao")){
					Item.NguoiTao = (String)(rd["CNKH_NguoiTao"]);
					}
					if(rd.FieldExists("CNKH_NgayCapNhat")){
					Item.NgayCapNhat = (DateTime)(rd["CNKH_NgayCapNhat"]);
					}
					if(rd.FieldExists("CNKH_NguoiCapNhat")){
					Item.NguoiCapNhat = (String)(rd["CNKH_NguoiCapNhat"]);
					}
					if(rd.FieldExists("CNKH_No")){
					Item.No = (Boolean)(rd["CNKH_No"]);
					}
                    Item._KhachHang = KhachHangDal.getFromReader(rd);
                    return Item;                    
                }
                 #endregion
				
				#region Extend
                public static Pager<CongNoDauKy> pagerByKhId(string sort, int size, string KH_ID)
                {
                    var obj = new SqlParameter[2];
                    obj[0] = new SqlParameter("Sort", sort);
                    if (!string.IsNullOrEmpty(KH_ID))
                    {
                        obj[1] = new SqlParameter("KH_ID", KH_ID);
                    }
                    else
                    {
                        obj[1] = new SqlParameter("KH_ID", DBNull.Value);
                    }

                    var pg = new Pager<CongNoDauKy>("sp_tblCongNoDauKy_Pager_byKhId_linhnx", "page", size, 10, false, string.Empty, obj);
                    return pg;
                }
				#endregion
            }
        #endregion
		       
        #endregion
}
