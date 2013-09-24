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
    #region QuyTac
    #region BO
    public class QuyTac : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Host { get; set; }
        public Int32 Loai { get; set; }
        public String Xpath { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Xoa { get; set; }
        #endregion
        #region Contructor
        public QuyTac()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return QuyTacDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class QuyTacCollection : BaseEntityCollection<QuyTac>
    { }
    #endregion
    #region Dal
    public class QuyTacDal
    {
        #region Methods

        public static void DeleteById(Int32 QT_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("QT_ID", QT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblQuyTac_Delete_DeleteById_hoangda", obj);
        }

        public static QuyTac Insert(QuyTac Inserted)
        {
            QuyTac Item = new QuyTac();
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("QT_Host", Inserted.Host);
            obj[1] = new SqlParameter("QT_Loai", Inserted.Loai);
            obj[2] = new SqlParameter("QT_Xpath", Inserted.Xpath);
            obj[3] = new SqlParameter("QT_ThuTu", Inserted.ThuTu);
            obj[4] = new SqlParameter("QT_Xoa", Inserted.Xoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuyTac_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuyTac Update(QuyTac Updated)
        {
            QuyTac Item = new QuyTac();
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("QT_ID", Updated.ID);
            obj[1] = new SqlParameter("QT_Host", Updated.Host);
            obj[2] = new SqlParameter("QT_Loai", Updated.Loai);
            obj[3] = new SqlParameter("QT_Xpath", Updated.Xpath);
            obj[4] = new SqlParameter("QT_ThuTu", Updated.ThuTu);
            obj[5] = new SqlParameter("QT_Xoa", Updated.Xoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuyTac_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuyTac SelectById(Int32 QT_ID)
        {
            QuyTac Item = new QuyTac();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("QT_ID", QT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuyTac_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuyTacCollection SelectAll()
        {
            QuyTacCollection List = new QuyTacCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuyTac_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<QuyTac> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            Pager<QuyTac> pg = new Pager<QuyTac>("sp_tblQuyTac_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static QuyTac getFromReader(IDataReader rd)
        {
            QuyTac Item = new QuyTac();
            if (rd.FieldExists("QT_ID"))
            {
                Item.ID = (Int32)(rd["QT_ID"]);
            }
            if (rd.FieldExists("QT_Host"))
            {
                Item.Host = (String)(rd["QT_Host"]);
            }
            if (rd.FieldExists("QT_Loai"))
            {
                Item.Loai = (Int32)(rd["QT_Loai"]);
            }
            if (rd.FieldExists("QT_Xpath"))
            {
                Item.Xpath = (String)(rd["QT_Xpath"]);
            }
            if (rd.FieldExists("QT_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["QT_ThuTu"]);
            }
            if (rd.FieldExists("QT_Xoa"))
            {
                Item.Xoa = (Boolean)(rd["QT_Xoa"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static QuyTacCollection SelectByHost(string host)
        {
            SqlParameter[] obj = new SqlParameter[1];
            if (!string.IsNullOrEmpty(host))
            {
                obj[0] = new SqlParameter("host", host);
            }
            else
            {
                obj[0] = new SqlParameter("host", DBNull.Value);
            }
            QuyTacCollection List = new QuyTacCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuyTac_Select_SelectByHost_hoangda", obj))
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
