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
    #region TinMember
    #region BO
    public class TinMember : BaseEntity
    {
        #region Properties
        public Int64 ID { get; set; }
        public Int32 T_ID { get; set; }
        public Int32 MEM_ID { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public TinMember()
        { }
        public TinMember(Int64? id, Int32? t_id, Int32? mem_id, DateTime? ngaytao)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (t_id != null)
            {
                T_ID = t_id.Value;
            }
            if (mem_id != null)
            {
                MEM_ID = mem_id.Value;
            }
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }

        }
        #endregion
        #region Customs properties
        public docsoft.entities.Member _Member { get; set; }
        public Tin _Tin { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinMemberDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinMemberCollection : BaseEntityCollection<TinMember>
    { }
    #endregion
    #region Dal
    public class TinMemberDal
    {
        #region Methods

        public static void DeleteById(Int64 TM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TM_ID", TM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTinMember_Delete_DeleteById_linhnx", obj);
        }
        public static TinMember Insert(TinMember Inserted)
        {
            TinMember Item = new TinMember();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TM_T_ID", Inserted.T_ID);
            obj[1] = new SqlParameter("TM_MEM_ID", Inserted.MEM_ID);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[2] = new SqlParameter("TM_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[2] = new SqlParameter("TM_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTinMember_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinMember Insert(Int64? id, Int32? t_id, Int32? mem_id, DateTime? ngaytao)
        {
            TinMember Item = new TinMember();
            SqlParameter[] obj = new SqlParameter[3];
            if (t_id != null)
            {
                obj[0] = new SqlParameter("TM_T_ID", t_id);
            }
            else
            {
                obj[0] = new SqlParameter("TM_T_ID", DBNull.Value);
            }
            if (mem_id != null)
            {
                obj[1] = new SqlParameter("TM_MEM_ID", mem_id);
            }
            else
            {
                obj[1] = new SqlParameter("TM_MEM_ID", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[2] = new SqlParameter("TM_NgayTao", ngaytao);
            }
            else
            {
                obj[2] = new SqlParameter("TM_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTinMember_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinMember Update(TinMember Updated)
        {
            TinMember Item = new TinMember();
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("TM_ID", Updated.ID);
            obj[1] = new SqlParameter("TM_T_ID", Updated.T_ID);
            obj[2] = new SqlParameter("TM_MEM_ID", Updated.MEM_ID);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("TM_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("TM_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTinMember_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinMember Update(Int64? id, Int32? t_id, Int32? mem_id, DateTime? ngaytao)
        {
            TinMember Item = new TinMember();
            SqlParameter[] obj = new SqlParameter[4];
            if (id != null)
            {
                obj[0] = new SqlParameter("TM_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("TM_ID", DBNull.Value);
            }
            if (t_id != null)
            {
                obj[1] = new SqlParameter("TM_T_ID", t_id);
            }
            else
            {
                obj[1] = new SqlParameter("TM_T_ID", DBNull.Value);
            }
            if (mem_id != null)
            {
                obj[2] = new SqlParameter("TM_MEM_ID", mem_id);
            }
            else
            {
                obj[2] = new SqlParameter("TM_MEM_ID", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[3] = new SqlParameter("TM_NgayTao", ngaytao);
            }
            else
            {
                obj[3] = new SqlParameter("TM_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTinMember_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinMember SelectById(Int64 TM_ID)
        {
            TinMember Item = new TinMember();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TM_ID", TM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTinMember_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinMemberCollection SelectAll()
        {
            TinMemberCollection List = new TinMemberCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTinMember_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TinMember> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TinMember> pg = new Pager<TinMember>("tblRss_sp_tblTinMember_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static TinMember getFromReader(IDataReader rd)
        {
            TinMember Item = new TinMember();
            if (rd.FieldExists("TM_ID"))
            {
                Item.ID = (Int64)(rd["TM_ID"]);
            }
            if (rd.FieldExists("TM_T_ID"))
            {
                Item.T_ID = (Int32)(rd["TM_T_ID"]);
            }
            if (rd.FieldExists("TM_MEM_ID"))
            {
                Item.MEM_ID = (Int32)(rd["TM_MEM_ID"]);
            }
            if (rd.FieldExists("TM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TM_NgayTao"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        public static TinMember InsertByUsername(Int32? t_id, string Username, DateTime? ngaytao)
        {
            TinMember Item = new TinMember();
            SqlParameter[] obj = new SqlParameter[3];
            if (t_id != null)
            {
                obj[0] = new SqlParameter("TM_T_ID", t_id);
            }
            else
            {
                obj[0] = new SqlParameter("TM_T_ID", DBNull.Value);
            }
            if (Username != null)
            {
                obj[1] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[1] = new SqlParameter("Username", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[2] = new SqlParameter("TM_NgayTao", ngaytao);
            }
            else
            {
                obj[2] = new SqlParameter("TM_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTinMember_Insert_InsertByUsername_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        #endregion
    }
    #endregion
    #endregion
}
