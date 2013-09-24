

#region sanpham
#region BO
#region BO
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
public class sanpham : BaseEntity
{
    #region Properties
    public Guid sanphamID { get; set; }
    public String tensanpham { get; set; }
    public String tensanphamen { get; set; }
    public String mota { get; set; }
    public String motaen { get; set; }
    public String chitiet { get; set; }
    public String chitieten { get; set; }
    public String xuatxu { get; set; }
    public String xuatxuen { get; set; }
    public String hinhanh { get; set; }
    public String hinhanhlon { get; set; }
    public String doanhnghiepID { get; set; }
    public String nhomID { get; set; }
    public Int32 trangthai { get; set; }
    public Int16 hot { get; set; }
    public DateTime ngaydang { get; set; }
    public DateTime ngayhethan { get; set; }
    public String nhomconID { get; set; }
    public String giaban { get; set; }
    public String tieuchuan { get; set; }
    #endregion
    #region Contructor
    public sanpham()
    { }
    #endregion
    #region Customs properties

    #endregion
    public override BaseEntity getFromReader(IDataReader rd)
    {
        return sanphamDal.getFromReader(rd);
    }
}
#endregion
#region Collection
public class sanphamCollection : BaseEntityCollection<sanpham>
{ }
#endregion
#region Dal
public class sanphamDal
{
    #region Methods

    public static void DeleteById(Guid sanphamID)
    {
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("sanphamID", sanphamID);
        SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_sanpham_Delete_DeleteById_linhnx", obj);
    }

    public static sanpham Insert(sanpham Inserted)
    {
        sanpham Item = new sanpham();
        SqlParameter[] obj = new SqlParameter[19];
        obj[0] = new SqlParameter("sanphamID", Inserted.sanphamID);
        obj[1] = new SqlParameter("tensanpham", Inserted.tensanpham);
        obj[2] = new SqlParameter("tensanphamen", Inserted.tensanphamen);
        obj[3] = new SqlParameter("mota", Inserted.mota);
        obj[4] = new SqlParameter("motaen", Inserted.motaen);
        obj[5] = new SqlParameter("chitiet", Inserted.chitiet);
        obj[6] = new SqlParameter("chitieten", Inserted.chitieten);
        obj[7] = new SqlParameter("xuatxu", Inserted.xuatxu);
        obj[8] = new SqlParameter("xuatxuen", Inserted.xuatxuen);
        obj[9] = new SqlParameter("hinhanh", Inserted.hinhanh);
        obj[10] = new SqlParameter("hinhanhlon", Inserted.hinhanhlon);
        obj[11] = new SqlParameter("doanhnghiepID", Inserted.doanhnghiepID);
        obj[12] = new SqlParameter("nhomID", Inserted.nhomID);
        obj[13] = new SqlParameter("trangthai", Inserted.trangthai);
        obj[14] = new SqlParameter("is_hot", Inserted.hot);
        obj[15] = new SqlParameter("ngaydang", Inserted.ngaydang);
        obj[16] = new SqlParameter("ngayhethan", Inserted.ngayhethan);
        obj[17] = new SqlParameter("nhomconID", Inserted.nhomconID);
        obj[18] = new SqlParameter("giaban", Inserted.giaban);
        obj[19] = new SqlParameter("tieuchuan", Inserted.tieuchuan);

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_sanpham_Insert_InsertNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static sanpham Update(sanpham Updated)
    {
        sanpham Item = new sanpham();
        SqlParameter[] obj = new SqlParameter[20];
        obj[0] = new SqlParameter("sanphamID", Updated.sanphamID);
        obj[1] = new SqlParameter("tensanpham", Updated.tensanpham);
        obj[2] = new SqlParameter("tensanphamen", Updated.tensanphamen);
        obj[3] = new SqlParameter("mota", Updated.mota);
        obj[4] = new SqlParameter("motaen", Updated.motaen);
        obj[5] = new SqlParameter("chitiet", Updated.chitiet);
        obj[6] = new SqlParameter("chitieten", Updated.chitieten);
        obj[7] = new SqlParameter("xuatxu", Updated.xuatxu);
        obj[8] = new SqlParameter("xuatxuen", Updated.xuatxuen);
        obj[9] = new SqlParameter("hinhanh", Updated.hinhanh);
        obj[10] = new SqlParameter("hinhanhlon", Updated.hinhanhlon);
        obj[11] = new SqlParameter("doanhnghiepID", Updated.doanhnghiepID);
        obj[12] = new SqlParameter("nhomID", Updated.nhomID);
        obj[13] = new SqlParameter("trangthai", Updated.trangthai);
        obj[14] = new SqlParameter("is_hot", Updated.hot);
        obj[15] = new SqlParameter("ngaydang", Updated.ngaydang);
        obj[16] = new SqlParameter("ngayhethan", Updated.ngayhethan);
        obj[17] = new SqlParameter("nhomconID", Updated.nhomconID);
        obj[18] = new SqlParameter("giaban", Updated.giaban);
        obj[19] = new SqlParameter("tieuchuan", Updated.tieuchuan);

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_sanpham_Update_UpdateNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static sanpham SelectById(Guid sanphamID)
    {
        sanpham Item = new sanpham();
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("sanphamID", sanphamID);
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_sanpham_Select_SelectById_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static sanphamCollection SelectAll()
    {
        sanphamCollection List = new sanphamCollection();
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_sanpham_Select_SelectAll_linhnx"))
        {
            while (rd.Read())
            {
                List.Add(getFromReader(rd));
            }
        }
        return List;
    }
    public static Pager<sanpham> pagerNormal(string url, bool rewrite, string sort)
    {
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("Sort", sort);
        Pager<sanpham> pg = new Pager<sanpham>("sp_tblsanpham_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
        return pg;
    }
    #endregion

    #region Utilities
    public static sanpham getFromReader(IDataReader rd)
    {
        sanpham Item = new sanpham();
        if (rd.FieldExists("sanphamID"))
        {
            Item.sanphamID = (Guid)(rd["sanphamID"]);
        }
        if (rd.FieldExists("tensanpham"))
        {
            Item.tensanpham = (String)(rd["tensanpham"]);
        }
        if (rd.FieldExists("tensanphamen"))
        {
            Item.tensanphamen = (String)(rd["tensanphamen"]);
        }
        if (rd.FieldExists("mota"))
        {
            Item.mota = (String)(rd["mota"]);
        }
        if (rd.FieldExists("motaen"))
        {
            Item.motaen = (String)(rd["motaen"]);
        }
        if (rd.FieldExists("chitiet"))
        {
            Item.chitiet = (String)(rd["chitiet"]);
        }
        if (rd.FieldExists("chitieten"))
        {
            Item.chitieten = (String)(rd["chitieten"]);
        }
        if (rd.FieldExists("xuatxu"))
        {
            Item.xuatxu = (String)(rd["xuatxu"]);
        }
        if (rd.FieldExists("xuatxuen"))
        {
            Item.xuatxuen = (String)(rd["xuatxuen"]);
        }
        if (rd.FieldExists("hinhanh"))
        {
            Item.hinhanh = (String)(rd["hinhanh"]);
        }
        if (rd.FieldExists("hinhanhlon"))
        {
            Item.hinhanhlon = (String)(rd["hinhanhlon"]);
        }
        if (rd.FieldExists("doanhnghiepID"))
        {
            Item.doanhnghiepID = (String)(rd["doanhnghiepID"]);
        }
        if (rd.FieldExists("nhomID"))
        {
            Item.nhomID = (String)(rd["nhomID"]);
        }
        if (rd.FieldExists("trangthai"))
        {
            Item.trangthai = (Int32)(rd["trangthai"]);
        }
        if (rd.FieldExists("is_hot"))
        {
            Item.hot = (Int16)(rd["is_hot"]);
        }
        if (rd.FieldExists("ngaydang"))
        {
            Item.ngaydang = (DateTime)(rd["ngaydang"]);
        }
        if (rd.FieldExists("ngayhethan"))
        {
            Item.ngayhethan = (DateTime)(rd["ngayhethan"]);
        }
        if (rd.FieldExists("nhomconID"))
        {
            Item.nhomconID = (String)(rd["nhomconID"]);
        }
        if (rd.FieldExists("giaban"))
        {
            Item.giaban = (String)(rd["giaban"]);
        }
        if (rd.FieldExists("tieuchuan"))
        {
            Item.tieuchuan = (String)(rd["tieuchuan"]);
        }
        return Item;
    }
    #endregion

    #region Extend
    #endregion
}
#endregion

#endregion
#endregion