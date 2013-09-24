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
#region DatHangChiTiet
#region BO
public class DatHangChiTiet : BaseEntity
{
    #region Properties
    public Guid ID { get; set; }
    public Guid DH_ID { get; set; }
    public Guid HH_ID { get; set; }
    public String HH_Ten { get; set; }
    public Int32 HH_SoLuong { get; set; }
    public Int32 HH_Gia { get; set; }
    public Int32 HH_Tong { get; set; }
    public DateTime NgayTao { get; set; }
    #endregion
    #region Contructor
    public DatHangChiTiet()
    { }
    #endregion
    #region Customs properties

    #endregion
    public override BaseEntity getFromReader(IDataReader rd)
    {
        return DatHangChiTietDal.getFromReader(rd);
    }
}
#endregion
#region Collection
public class DatHangChiTietCollection : BaseEntityCollection<DatHangChiTiet>
{ }
#endregion
#region Dal
public class DatHangChiTietDal
{
    #region Methods

    public static void DeleteById(Guid DHCT_ID)
    {
        var obj = new SqlParameter[1];
        obj[0] = new SqlParameter("DHCT_ID", DHCT_ID);
        SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Delete_DeleteById_linhnx", obj);
    }

    public static DatHangChiTiet Insert(DatHangChiTiet item)
    {
        var Item = new DatHangChiTiet();
        var obj = new SqlParameter[8];
        obj[0] = new SqlParameter("DHCT_ID", item.ID);
        obj[1] = new SqlParameter("DHCT_DH_ID", item.DH_ID);
        obj[2] = new SqlParameter("DHCT_HH_ID", item.HH_ID);
        obj[3] = new SqlParameter("DHCT_HH_Ten", item.HH_Ten);
        obj[4] = new SqlParameter("DHCT_HH_SoLuong", item.HH_SoLuong);
        obj[5] = new SqlParameter("DHCT_HH_Gia", item.HH_Gia);
        obj[6] = new SqlParameter("DHCT_HH_Tong", item.HH_Tong);
        if (item.NgayTao > DateTime.MinValue)
        {
            obj[7] = new SqlParameter("DHCT_NgayTao", item.NgayTao);
        }
        else
        {
            obj[7] = new SqlParameter("DHCT_NgayTao", DBNull.Value);
        }

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Insert_InsertNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static DatHangChiTiet Update(DatHangChiTiet item)
    {
        var Item = new DatHangChiTiet();
        var obj = new SqlParameter[8];
        obj[0] = new SqlParameter("DHCT_ID", item.ID);
        obj[1] = new SqlParameter("DHCT_DH_ID", item.DH_ID);
        obj[2] = new SqlParameter("DHCT_HH_ID", item.HH_ID);
        obj[3] = new SqlParameter("DHCT_HH_Ten", item.HH_Ten);
        obj[4] = new SqlParameter("DHCT_HH_SoLuong", item.HH_SoLuong);
        obj[5] = new SqlParameter("DHCT_HH_Gia", item.HH_Gia);
        obj[6] = new SqlParameter("DHCT_HH_Tong", item.HH_Tong);
        if (item.NgayTao > DateTime.MinValue)
        {
            obj[7] = new SqlParameter("DHCT_NgayTao", item.NgayTao);
        }
        else
        {
            obj[7] = new SqlParameter("DHCT_NgayTao", DBNull.Value);
        }

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Update_UpdateNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static DatHangChiTiet SelectById(Guid DHCT_ID)
    {
        var Item = new DatHangChiTiet();
        var obj = new SqlParameter[1];
        obj[0] = new SqlParameter("DHCT_ID", DHCT_ID);
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Select_SelectById_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static DatHangChiTietCollection SelectAll()
    {
        var List = new DatHangChiTietCollection();
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Select_SelectAll_linhnx"))
        {
            while (rd.Read())
            {
                List.Add(getFromReader(rd));
            }
        }
        return List;
    }
    public static Pager<DatHangChiTiet> pagerNormal(string url, bool rewrite, string sort, string q, int size)
    {
        var obj = new SqlParameter[2];
        obj[0] = new SqlParameter("Sort", sort);
        if (!string.IsNullOrEmpty(q))
        {
            obj[1] = new SqlParameter("q", q);
        }
        else
        {
            obj[1] = new SqlParameter("q", DBNull.Value);
        }

        var pg = new Pager<DatHangChiTiet>("sp_tblDatHangChiTiet_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
        return pg;
    }
    #endregion

    #region Utilities
    public static DatHangChiTiet getFromReader(IDataReader rd)
    {
        var Item = new DatHangChiTiet();
        if (rd.FieldExists("DHCT_ID"))
        {
            Item.ID = (Guid)(rd["DHCT_ID"]);
        }
        if (rd.FieldExists("DHCT_DH_ID"))
        {
            Item.DH_ID = (Guid)(rd["DHCT_DH_ID"]);
        }
        if (rd.FieldExists("DHCT_HH_ID"))
        {
            Item.HH_ID = (Guid)(rd["DHCT_HH_ID"]);
        }
        if (rd.FieldExists("DHCT_HH_Ten"))
        {
            Item.HH_Ten = (String)(rd["DHCT_HH_Ten"]);
        }
        if (rd.FieldExists("DHCT_HH_SoLuong"))
        {
            Item.HH_SoLuong = (Int32)(rd["DHCT_HH_SoLuong"]);
        }
        if (rd.FieldExists("DHCT_HH_Gia"))
        {
            Item.HH_Gia = (Int32)(rd["DHCT_HH_Gia"]);
        }
        if (rd.FieldExists("DHCT_HH_Tong"))
        {
            Item.HH_Tong = (Int32)(rd["DHCT_HH_Tong"]);
        }
        if (rd.FieldExists("DHCT_NgayTao"))
        {
            Item.NgayTao = (DateTime)(rd["DHCT_NgayTao"]);
        }
        return Item;
    }
    #endregion

    #region Extend
    public static DatHangChiTietCollection SelectByDhId(string DH_ID)
    {
        var List = new DatHangChiTietCollection();
        var obj = new SqlParameter[1];
        if(!string.IsNullOrEmpty(DH_ID))
        {
            obj[0] = new SqlParameter("DH_ID", DH_ID);
        }
        else
        {
            obj[0] = new SqlParameter("DH_ID", DBNull.Value);
        }
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Select_SelectByDhId_linhnx", obj))
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