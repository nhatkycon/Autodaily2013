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
#region GiaoThuong
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
public class giaothuongHam : BaseEntity
{
    #region Properties
    public Guid giaothuongHamID { get; set; }
    public String tieude { get; set; }
    public String tieudeen { get; set; }
    public String mota { get; set; }
    public String motaen { get; set; }
    public String chitiet { get; set; }
    public String chitieten { get; set; }
    public String hinhanh { get; set; }
    public String hinhanhlon { get; set; }
    public String xuatxu { get; set; }
    public DateTime ngayhethan { get; set; }
    public DateTime ngaydang { get; set; }
    public String doanhnghiepID { get; set; }
    public String nhomID { get; set; }
    public Int32 trangthai { get; set; }
    public Int16 loaigiaothuongHamID { get; set; }
    public String nhomconID { get; set; }
    #endregion
    #region Contructor
    public giaothuongHam()
    { }
    #endregion
    #region Customs properties

    #endregion
    public override BaseEntity getFromReader(IDataReader rd)
    {
        return giaothuongHamDal.getFromReader(rd);
    }
}
#endregion
#region Collection
public class giaothuongHamCollection : BaseEntityCollection<giaothuongHam>
{ }
#endregion
#region Dal
public class giaothuongHamDal
{
    #region Methods

    public static void DeleteById(Guid giaothuongHamID)
    {
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("giaothuongHamID", giaothuongHamID);
        SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_giaothuongHam_Delete_DeleteById_linhnx", obj);
    }

    public static giaothuongHam Insert(giaothuongHam Inserted)
    {
        giaothuongHam Item = new giaothuongHam();
        SqlParameter[] obj = new SqlParameter[16];
        obj[0] = new SqlParameter("giaothuongHamID", Inserted.giaothuongHamID);
        obj[1] = new SqlParameter("tieude", Inserted.tieude);
        obj[2] = new SqlParameter("tieudeen", Inserted.tieudeen);
        obj[3] = new SqlParameter("mota", Inserted.mota);
        obj[4] = new SqlParameter("motaen", Inserted.motaen);
        obj[5] = new SqlParameter("chitiet", Inserted.chitiet);
        obj[6] = new SqlParameter("chitieten", Inserted.chitieten);
        obj[7] = new SqlParameter("hinhanh", Inserted.hinhanh);
        obj[8] = new SqlParameter("hinhanhlon", Inserted.hinhanhlon);
        obj[9] = new SqlParameter("xuatxu", Inserted.xuatxu);
        obj[10] = new SqlParameter("ngayhethan", Inserted.ngayhethan);
        obj[11] = new SqlParameter("ngaydang", Inserted.ngaydang);
        obj[12] = new SqlParameter("doanhnghiepID", Inserted.doanhnghiepID);
        obj[13] = new SqlParameter("nhomID", Inserted.nhomID);
        obj[14] = new SqlParameter("trangthai", Inserted.trangthai);
        obj[15] = new SqlParameter("loaigiaothuongHamID", Inserted.loaigiaothuongHamID);
        obj[16] = new SqlParameter("nhomconID", Inserted.nhomconID);

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_giaothuongHam_Insert_InsertNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static giaothuongHam Update(giaothuongHam Updated)
    {
        giaothuongHam Item = new giaothuongHam();
        SqlParameter[] obj = new SqlParameter[17];
        obj[0] = new SqlParameter("giaothuongHamID", Updated.giaothuongHamID);
        obj[1] = new SqlParameter("tieude", Updated.tieude);
        obj[2] = new SqlParameter("tieudeen", Updated.tieudeen);
        obj[3] = new SqlParameter("mota", Updated.mota);
        obj[4] = new SqlParameter("motaen", Updated.motaen);
        obj[5] = new SqlParameter("chitiet", Updated.chitiet);
        obj[6] = new SqlParameter("chitieten", Updated.chitieten);
        obj[7] = new SqlParameter("hinhanh", Updated.hinhanh);
        obj[8] = new SqlParameter("hinhanhlon", Updated.hinhanhlon);
        obj[9] = new SqlParameter("xuatxu", Updated.xuatxu);
        obj[10] = new SqlParameter("ngayhethan", Updated.ngayhethan);
        obj[11] = new SqlParameter("ngaydang", Updated.ngaydang);
        obj[12] = new SqlParameter("doanhnghiepID", Updated.doanhnghiepID);
        obj[13] = new SqlParameter("nhomID", Updated.nhomID);
        obj[14] = new SqlParameter("trangthai", Updated.trangthai);
        obj[15] = new SqlParameter("loaigiaothuongHamID", Updated.loaigiaothuongHamID);
        obj[16] = new SqlParameter("nhomconID", Updated.nhomconID);

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_giaothuongHam_Update_UpdateNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static giaothuongHam SelectById(Guid giaothuongHamID)
    {
        giaothuongHam Item = new giaothuongHam();
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("giaothuongHamID", giaothuongHamID);
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_giaothuongHam_Select_SelectById_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static giaothuongHamCollection SelectAll()
    {
        giaothuongHamCollection List = new giaothuongHamCollection();
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_giaothuongHam_Select_SelectAll_linhnx"))
        {
            while (rd.Read())
            {
                List.Add(getFromReader(rd));
            }
        }
        return List;
    }
    public static Pager<giaothuongHam> pagerNormal(string url, bool rewrite, string sort)
    {
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("Sort", sort);
        Pager<giaothuongHam> pg = new Pager<giaothuongHam>("sp_tblgiaothuongHam_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
        return pg;
    }
    #endregion

    #region Utilities
    public static giaothuongHam getFromReader(IDataReader rd)
    {
        giaothuongHam Item = new giaothuongHam();
        if (rd.FieldExists("giaothuongHamID"))
        {
            Item.giaothuongHamID = (Guid)(rd["giaothuongHamID"]);
        }
        if (rd.FieldExists("tieude"))
        {
            Item.tieude = (String)(rd["tieude"]);
        }
        if (rd.FieldExists("tieudeen"))
        {
            Item.tieudeen = (String)(rd["tieudeen"]);
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
        if (rd.FieldExists("hinhanh"))
        {
            Item.hinhanh = (String)(rd["hinhanh"]);
        }
        if (rd.FieldExists("hinhanhlon"))
        {
            Item.hinhanhlon = (String)(rd["hinhanhlon"]);
        }
        if (rd.FieldExists("xuatxu"))
        {
            Item.xuatxu = (String)(rd["xuatxu"]);
        }
        if (rd.FieldExists("ngayhethan"))
        {
            Item.ngayhethan = (DateTime)(rd["ngayhethan"]);
        }
        if (rd.FieldExists("ngaydang"))
        {
            Item.ngaydang = (DateTime)(rd["ngaydang"]);
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
        if (rd.FieldExists("loaigiaothuongHamID"))
        {
            Item.loaigiaothuongHamID = (Int16)(rd["loaigiaothuongHamID"]);
        }
        if (rd.FieldExists("nhomconID"))
        {
            Item.nhomconID = (String)(rd["nhomconID"]);
        }
        return Item;
    }
    #endregion

    #region Extend
    #endregion
}
#endregion

#endregion