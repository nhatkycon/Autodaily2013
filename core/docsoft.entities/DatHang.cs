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
#region DatHang
#region BO
public class DatHang : BaseEntity
{
    #region Properties
    public Guid ID { get; set; }
    public String KH_Ten { get; set; }
    public String KH_Email { get; set; }
    public String KH_Mobile { get; set; }
    public String KH_DiaChi { get; set; }
    public Guid KH_ID { get; set; }
    public Int32 GiaTri { get; set; }
    public Int32 PhiVanChuyen { get; set; }
    public Int32 Tong { get; set; }
    public Boolean GiaoHang { get; set; }
    public DateTime NgayGiao { get; set; }
    public Boolean Readed { get; set; }
    public DateTime NgayTao { get; set; }
    #endregion
    #region Contructor
    public DatHang()
    { }
    #endregion
    #region Customs properties

    #endregion
    public override BaseEntity getFromReader(IDataReader rd)
    {
        return DatHangDal.getFromReader(rd);
    }
}
#endregion
#region Collection
public class DatHangCollection : BaseEntityCollection<DatHang>
{ }
#endregion
#region Dal
public class DatHangDal
{
    #region Methods

    public static void DeleteById(Guid DH_ID)
    {
        var obj = new SqlParameter[1];
        obj[0] = new SqlParameter("DH_ID", DH_ID);
        SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Delete_DeleteById_linhnx", obj);
    }

    public static DatHang Insert(DatHang item)
    {
        var Item = new DatHang();
        var obj = new SqlParameter[13];
        obj[0] = new SqlParameter("DH_ID", item.ID);
        obj[1] = new SqlParameter("DH_KH_Ten", item.KH_Ten);
        obj[2] = new SqlParameter("DH_KH_Email", item.KH_Email);
        obj[3] = new SqlParameter("DH_KH_Mobile", item.KH_Mobile);
        obj[4] = new SqlParameter("DH_KH_DiaChi", item.KH_DiaChi);
        obj[5] = new SqlParameter("DH_KH_ID", item.KH_ID);
        obj[6] = new SqlParameter("DH_GiaTri", item.GiaTri);
        obj[7] = new SqlParameter("DH_PhiVanChuyen", item.PhiVanChuyen);
        obj[8] = new SqlParameter("DH_Tong", item.Tong);
        obj[9] = new SqlParameter("DH_GiaoHang", item.GiaoHang);
        if (item.NgayGiao > DateTime.MinValue)
        {
            obj[10] = new SqlParameter("DH_NgayGiao", item.NgayGiao);
        }
        else
        {
            obj[10] = new SqlParameter("DH_NgayGiao", DBNull.Value);
        }
        obj[11] = new SqlParameter("DH_Readed", item.Readed);
        if (item.NgayTao > DateTime.MinValue)
        {
            obj[12] = new SqlParameter("DH_NgayTao", item.NgayTao);
        }
        else
        {
            obj[12] = new SqlParameter("DH_NgayTao", DBNull.Value);
        }

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Insert_InsertNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static DatHang Update(DatHang item)
    {
        var Item = new DatHang();
        var obj = new SqlParameter[13];
        obj[0] = new SqlParameter("DH_ID", item.ID);
        obj[1] = new SqlParameter("DH_KH_Ten", item.KH_Ten);
        obj[2] = new SqlParameter("DH_KH_Email", item.KH_Email);
        obj[3] = new SqlParameter("DH_KH_Mobile", item.KH_Mobile);
        obj[4] = new SqlParameter("DH_KH_DiaChi", item.KH_DiaChi);
        obj[5] = new SqlParameter("DH_KH_ID", item.KH_ID);
        obj[6] = new SqlParameter("DH_GiaTri", item.GiaTri);
        obj[7] = new SqlParameter("DH_PhiVanChuyen", item.PhiVanChuyen);
        obj[8] = new SqlParameter("DH_Tong", item.Tong);
        obj[9] = new SqlParameter("DH_GiaoHang", item.GiaoHang);
        if (item.NgayGiao > DateTime.MinValue)
        {
            obj[10] = new SqlParameter("DH_NgayGiao", item.NgayGiao);
        }
        else
        {
            obj[10] = new SqlParameter("DH_NgayGiao", DBNull.Value);
        }
        obj[11] = new SqlParameter("DH_Readed", item.Readed);
        if (item.NgayTao > DateTime.MinValue)
        {
            obj[12] = new SqlParameter("DH_NgayTao", item.NgayTao);
        }
        else
        {
            obj[12] = new SqlParameter("DH_NgayTao", DBNull.Value);
        }

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Update_UpdateNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static DatHang SelectById(Guid DH_ID)
    {
        var Item = new DatHang();
        var obj = new SqlParameter[1];
        obj[0] = new SqlParameter("DH_ID", DH_ID);
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Select_SelectById_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static DatHangCollection SelectAll()
    {
        var List = new DatHangCollection();
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Select_SelectAll_linhnx"))
        {
            while (rd.Read())
            {
                List.Add(getFromReader(rd));
            }
        }
        return List;
    }
    public static Pager<DatHang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
    {
        var obj = new SqlParameter[1];
        obj[0] = new SqlParameter("Sort", sort);
        var pg = new Pager<DatHang>("sp_tblDatHang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
        return pg;
    }
    #endregion

    #region Utilities
    public static DatHang getFromReader(IDataReader rd)
    {
        var Item = new DatHang();
        if (rd.FieldExists("DH_ID"))
        {
            Item.ID = (Guid)(rd["DH_ID"]);
        }
        if (rd.FieldExists("DH_KH_Ten"))
        {
            Item.KH_Ten = (String)(rd["DH_KH_Ten"]);
        }
        if (rd.FieldExists("DH_KH_Email"))
        {
            Item.KH_Email = (String)(rd["DH_KH_Email"]);
        }
        if (rd.FieldExists("DH_KH_Mobile"))
        {
            Item.KH_Mobile = (String)(rd["DH_KH_Mobile"]);
        }
        if (rd.FieldExists("DH_KH_DiaChi"))
        {
            Item.KH_DiaChi = (String)(rd["DH_KH_DiaChi"]);
        }
        if (rd.FieldExists("DH_KH_ID"))
        {
            Item.KH_ID = (Guid)(rd["DH_KH_ID"]);
        }
        if (rd.FieldExists("DH_GiaTri"))
        {
            Item.GiaTri = (Int32)(rd["DH_GiaTri"]);
        }
        if (rd.FieldExists("DH_PhiVanChuyen"))
        {
            Item.PhiVanChuyen = (Int32)(rd["DH_PhiVanChuyen"]);
        }
        if (rd.FieldExists("DH_Tong"))
        {
            Item.Tong = (Int32)(rd["DH_Tong"]);
        }
        if (rd.FieldExists("DH_GiaoHang"))
        {
            Item.GiaoHang = (Boolean)(rd["DH_GiaoHang"]);
        }
        if (rd.FieldExists("DH_NgayGiao"))
        {
            Item.NgayGiao = (DateTime)(rd["DH_NgayGiao"]);
        }
        if (rd.FieldExists("DH_Readed"))
        {
            Item.Readed = (Boolean)(rd["DH_Readed"]);
        }
        if (rd.FieldExists("DH_NgayTao"))
        {
            Item.NgayTao = (DateTime)(rd["DH_NgayTao"]);
        }
        return Item;
    }
    #endregion

    #region Extend
    public static Pager<DatHang> pagerNormalChuaGiao(string url, bool rewrite, string sort, int size)
    {
        var obj = new SqlParameter[1];
        obj[0] = new SqlParameter("Sort", sort);
        var pg = new Pager<DatHang>("sp_tblDatHang_Pager_pagerNormalChuaGiao_linhnx", "page", size, 10, rewrite, url, obj);
        return pg;
    }
    public static void GiaoById(string DH_ID)
    {
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("ID", DH_ID);
        SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Update_GiaoById_linhnx", obj);
    }
    #endregion
}
#endregion

#endregion