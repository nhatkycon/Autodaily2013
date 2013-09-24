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
    #region WorkFlows
        #region BO
		public class WorkFlows: BaseEntity
		{			
			#region Properties
			public  Int32 ID{get;set;}
			public  Int32 CQ_ID{get;set;}
			public  String Ten{get;set;}
			public  String MoTa{get;set;}
			public  DateTime NgayTao{get;set;}
			public  DateTime NgayCapNhat{get;set;}
			public  Guid RowId{get;set;}
			public  Boolean Active{get;set;}
			public  Boolean MacDinh{get;set;}
			#endregion
			#region Contructor
			public WorkFlows()
			{ }
			#endregion
			#region Customs properties
			
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return WorkFlowsDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection
			public class WorkFlowsCollection : BaseEntityCollection<WorkFlows>
			{}			
		#endregion
        #region Dal
            public class WorkFlowsDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 WF_ID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("WF_ID", WF_ID);
                    SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblWorkFlows_Delete_DeleteById_linhnx", obj);
                }                
                
                public static WorkFlows Insert(WorkFlows Inserted)
                {
                    WorkFlows Item = new WorkFlows();
                    SqlParameter[] obj = new SqlParameter[8];
                    				obj[0] = new SqlParameter("WF_CQ_ID", Inserted.CQ_ID);
				obj[1] = new SqlParameter("WF_Ten", Inserted.Ten);
				obj[2] = new SqlParameter("WF_MoTa", Inserted.MoTa);
				obj[3] = new SqlParameter("WF_NgayTao", Inserted.NgayTao);
				obj[4] = new SqlParameter("WF_NgayCapNhat", Inserted.NgayCapNhat);
				obj[5] = new SqlParameter("WF_RowId", Inserted.RowId);
				obj[6] = new SqlParameter("WF_Active", Inserted.Active);
				obj[7] = new SqlParameter("WF_MacDinh", Inserted.MacDinh);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblWorkFlows_Insert_InsertNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static WorkFlows Update(WorkFlows Updated)
                {
                    WorkFlows Item = new WorkFlows();
                    SqlParameter[] obj = new SqlParameter[9];
                    				obj[0] = new SqlParameter("WF_ID", Updated.ID);
				obj[1] = new SqlParameter("WF_CQ_ID", Updated.CQ_ID);
				obj[2] = new SqlParameter("WF_Ten", Updated.Ten);
				obj[3] = new SqlParameter("WF_MoTa", Updated.MoTa);
				obj[4] = new SqlParameter("WF_NgayTao", Updated.NgayTao);
				obj[5] = new SqlParameter("WF_NgayCapNhat", Updated.NgayCapNhat);
				obj[6] = new SqlParameter("WF_RowId", Updated.RowId);
				obj[7] = new SqlParameter("WF_Active", Updated.Active);
				obj[8] = new SqlParameter("WF_MacDinh", Updated.MacDinh);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblWorkFlows_Update_UpdateNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static WorkFlows SelectById(Int32 WF_ID)
                {
                    WorkFlows Item = new WorkFlows();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("WF_ID", WF_ID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblWorkFlows_Select_SelectById_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static WorkFlowsCollection SelectAll()
                {
                    WorkFlowsCollection List = new WorkFlowsCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblWorkFlows_Select_SelectAll_linhnx"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<WorkFlows> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<WorkFlows> pg = new Pager<WorkFlows>("sp_tblWorkFlows_Pager_Normal_linhnx", "q", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities
                public static WorkFlows getFromReader(IDataReader rd)
                {
                    WorkFlows Item = new WorkFlows();
                    					Item.ID = (Int32)(rd["WF_ID"]);
					Item.CQ_ID = (Int32)(rd["WF_CQ_ID"]);
					Item.Ten = (String)(rd["WF_Ten"]);
					Item.MoTa = (String)(rd["WF_MoTa"]);
					Item.NgayTao = (DateTime)(rd["WF_NgayTao"]);
					Item.NgayCapNhat = (DateTime)(rd["WF_NgayCapNhat"]);
					Item.RowId = (Guid)(rd["WF_RowId"]);
					Item.Active = (Boolean)(rd["WF_Active"]);
					Item.MacDinh = (Boolean)(rd["WF_MacDinh"]);
                    return Item;                    
                }
                 #endregion
				#region Extend
                /// <summary>
                /// Trả về VBNODE_ID active của user
                /// </summary>
                /// <param name="WF_ID"></param>
                /// <param name="VB_ID"></param>
                /// <returns></returns>
                public static Int32 SetWorkFlowVBID(Int32 WF_ID,Int32 VB_ID)
                {
                    SqlParameter[] obj = new SqlParameter[2];
                    obj[0] = new SqlParameter("WF_ID", WF_ID);
                    obj[1] = new SqlParameter("VB_ID", VB_ID);
                    return Convert.ToInt32(SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblWorkFlows_Setup_linhnx", obj));
                }
                public static Int32 StartWorkFlows(Int32 WF_ID, Int32 VB_ID,string NguoiTao,string CIDList)
                {
                    SqlParameter[] obj = new SqlParameter[4];
                    obj[0] = new SqlParameter("WF_ID", WF_ID);
                    obj[1] = new SqlParameter("VB_ID", VB_ID);
                    obj[2] = new SqlParameter("NguoiTao", NguoiTao);
                    if (string.IsNullOrEmpty(CIDList))
                    {
                        obj[3] = new SqlParameter("CIDList", DBNull.Value);
                    }
                    else
                    {
                        obj[3] = new SqlParameter("CIDList", CIDList);
                    }
                    return Convert.ToInt32(SqlHelper.ExecuteScalar(DAL.con(), CommandType.StoredProcedure, "sp_tblWorkFlows_StartWorkFlows_linhnx", obj));
                }                
				#endregion
            }
        #endregion		       
        #endregion
}

