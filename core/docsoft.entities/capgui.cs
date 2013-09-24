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
    #region Capgui
    #region BO
    public class Capgui : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiTao { get; set; }
        #endregion
        #region Contructor
        public Capgui()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return CapguiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class CapguiCollection : BaseEntityCollection<Capgui>
    { }
    #endregion
    #region Dal
    public class CapguiDal
    {
        #region Methods

        public static void DeleteById(Int32 CG_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CG_ID", CG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblCapgui_Delete_DeleteById_linhnx", obj);
        }

        public static Capgui Insert(Capgui Inserted)
        {
            Capgui Item = new Capgui();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("CG_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("CG_Ma", Inserted.Ma);
            obj[2] = new SqlParameter("CG_NgayTao", Inserted.NgayTao);
            obj[3] = new SqlParameter("CG_NgayCapNhat", Inserted.NgayCapNhat);
            obj[4] = new SqlParameter("CG_NguoiTao", Inserted.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCapgui_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Capgui Update(Capgui Updated)
        {
            Capgui Item = new Capgui();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("CG_ID", Updated.ID);
            obj[1] = new SqlParameter("CG_Ten", Updated.Ten);
            obj[2] = new SqlParameter("CG_Ma", Updated.Ma);
            obj[3] = new SqlParameter("CG_NgayTao", Updated.NgayTao);
            obj[4] = new SqlParameter("CG_NgayCapNhat", Updated.NgayCapNhat);
            obj[5] = new SqlParameter("CG_NguoiTao", Updated.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCapgui_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Capgui SelectById(Int32 CG_ID)
        {
            Capgui Item = new Capgui();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CG_ID", CG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCapgui_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static CapguiCollection SelectAll()
        {
            CapguiCollection List = new CapguiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblCapgui_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderTiny(rd));
                }
            }
            return List;
        }
        public static Pager<Capgui> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Capgui> pg = new Pager<Capgui>("sp_tblCapgui_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Capgui getFromReader(IDataReader rd)
        {
            Capgui Item = new Capgui();
            Item.ID = (Int32)(rd["CG_ID"]);
            Item.Ten = (String)(rd["CG_Ten"]);
            Item.Ma = (String)(rd["CG_Ma"]);
            Item.NgayTao = (DateTime)(rd["CG_NgayTao"]);
            Item.NgayCapNhat = (DateTime)(rd["CG_NgayCapNhat"]);
            Item.NguoiTao = (String)(rd["CG_NguoiTao"]);
            return Item;
        }
        public static Capgui getFromReaderTiny(IDataReader rd)
        {
            Capgui Item = new Capgui();
            Item.ID = (Int32)(rd["CG_ID"]);
            Item.Ten = (String)(rd["CG_Ten"]);
            Item.Ma = (String)(rd["CG_Ma"]);
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
}


