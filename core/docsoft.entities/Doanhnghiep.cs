#region doanhnghiep
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
public class doanhnghiep : BaseEntity
{
    #region Properties
    public Guid doanhnghiepID { get; set; }
    public String tendangnhap { get; set; }
    public String matkhau { get; set; }
    public String tendoanhnghiep { get; set; }
    public String tendoanhnghiepen { get; set; }
    public String mota { get; set; }
    public String motaen { get; set; }
    public String chitiet { get; set; }
    public String chitieten { get; set; }
    public String hinhanh { get; set; }
    public Guid tinhID { get; set; }
    public String diachi { get; set; }
    public String diachien { get; set; }
    public String dienthoaidn { get; set; }
    public String fax { get; set; }
    public String nguoilienhe { get; set; }
    public String dienthoainguoilh { get; set; }
    public String website { get; set; }
    public DateTime ngaydangky { get; set; }
    public String email { get; set; }
    public Int16 trangthai { get; set; }
    public String chucvunguoilh { get; set; }
    public String chucvunguoilhen { get; set; }
    public String emailnguoilh { get; set; }
    public String mobilenguoilh { get; set; }
    public String tenmien { get; set; }
    public Guid nhomID { get; set; }
    public Int16 lopthanhvienID { get; set; }
    public String hinhanhlon { get; set; }
    public Boolean isActive { get; set; }
    public DateTime ngayhethan { get; set; }
    #endregion
    #region Contructor
    public doanhnghiep()
    { }
    #endregion
    #region Customs properties

    #endregion
    public override BaseEntity getFromReader(IDataReader rd)
    {
        return doanhnghiepDal.getFromReader(rd);
    }
}
        #endregion
#region Collection
public class doanhnghiepCollection : BaseEntityCollection<doanhnghiep>
{ }
#endregion
#region Dal
public class doanhnghiepDal
{
    #region Methods

    public static void DeleteById(Guid doanhnghiepID)
    {
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("doanhnghiepID", doanhnghiepID);
        SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_doanhnghiep_Delete_DeleteById_linhnx", obj);
    }

    public static doanhnghiep Insert(doanhnghiep Inserted)
    {
        doanhnghiep Item = new doanhnghiep();
        SqlParameter[] obj = new SqlParameter[30];
        obj[0] = new SqlParameter("doanhnghiepID", Inserted.doanhnghiepID);
        obj[1] = new SqlParameter("tendangnhap", Inserted.tendangnhap);
        obj[2] = new SqlParameter("matkhau", Inserted.matkhau);
        obj[3] = new SqlParameter("tendoanhnghiep", Inserted.tendoanhnghiep);
        obj[4] = new SqlParameter("tendoanhnghiepen", Inserted.tendoanhnghiepen);
        obj[5] = new SqlParameter("mota", Inserted.mota);
        obj[6] = new SqlParameter("motaen", Inserted.motaen);
        obj[7] = new SqlParameter("chitiet", Inserted.chitiet);
        obj[8] = new SqlParameter("chitieten", Inserted.chitieten);
        obj[9] = new SqlParameter("hinhanh", Inserted.hinhanh);
        obj[10] = new SqlParameter("tinhID", Inserted.tinhID);
        obj[11] = new SqlParameter("diachi", Inserted.diachi);
        obj[12] = new SqlParameter("diachien", Inserted.diachien);
        obj[13] = new SqlParameter("dienthoaidn", Inserted.dienthoaidn);
        obj[14] = new SqlParameter("fax", Inserted.fax);
        obj[15] = new SqlParameter("nguoilienhe", Inserted.nguoilienhe);
        obj[16] = new SqlParameter("dienthoainguoilh", Inserted.dienthoainguoilh);
        obj[17] = new SqlParameter("website", Inserted.website);
        obj[18] = new SqlParameter("ngaydangky", Inserted.ngaydangky);
        obj[19] = new SqlParameter("email", Inserted.email);
        obj[20] = new SqlParameter("trangthai", Inserted.trangthai);
        obj[21] = new SqlParameter("chucvunguoilh", Inserted.chucvunguoilh);
        obj[22] = new SqlParameter("chucvunguoilhen", Inserted.chucvunguoilhen);
        obj[23] = new SqlParameter("emailnguoilh", Inserted.emailnguoilh);
        obj[24] = new SqlParameter("mobilenguoilh", Inserted.mobilenguoilh);
        obj[25] = new SqlParameter("tenmien", Inserted.tenmien);
        obj[26] = new SqlParameter("nhomID", Inserted.nhomID);
        obj[27] = new SqlParameter("lopthanhvienID", Inserted.lopthanhvienID);
        obj[28] = new SqlParameter("hinhanhlon", Inserted.hinhanhlon);
        obj[29] = new SqlParameter("isActive", Inserted.isActive);
        obj[30] = new SqlParameter("ngayhethan", Inserted.ngayhethan);

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_doanhnghiep_Insert_InsertNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static doanhnghiep Update(doanhnghiep Updated)
    {
        doanhnghiep Item = new doanhnghiep();
        SqlParameter[] obj = new SqlParameter[31];
        obj[0] = new SqlParameter("doanhnghiepID", Updated.doanhnghiepID);
        obj[1] = new SqlParameter("tendangnhap", Updated.tendangnhap);
        obj[2] = new SqlParameter("matkhau", Updated.matkhau);
        obj[3] = new SqlParameter("tendoanhnghiep", Updated.tendoanhnghiep);
        obj[4] = new SqlParameter("tendoanhnghiepen", Updated.tendoanhnghiepen);
        obj[5] = new SqlParameter("mota", Updated.mota);
        obj[6] = new SqlParameter("motaen", Updated.motaen);
        obj[7] = new SqlParameter("chitiet", Updated.chitiet);
        obj[8] = new SqlParameter("chitieten", Updated.chitieten);
        obj[9] = new SqlParameter("hinhanh", Updated.hinhanh);
        obj[10] = new SqlParameter("tinhID", Updated.tinhID);
        obj[11] = new SqlParameter("diachi", Updated.diachi);
        obj[12] = new SqlParameter("diachien", Updated.diachien);
        obj[13] = new SqlParameter("dienthoaidn", Updated.dienthoaidn);
        obj[14] = new SqlParameter("fax", Updated.fax);
        obj[15] = new SqlParameter("nguoilienhe", Updated.nguoilienhe);
        obj[16] = new SqlParameter("dienthoainguoilh", Updated.dienthoainguoilh);
        obj[17] = new SqlParameter("website", Updated.website);
        obj[18] = new SqlParameter("ngaydangky", Updated.ngaydangky);
        obj[19] = new SqlParameter("email", Updated.email);
        obj[20] = new SqlParameter("trangthai", Updated.trangthai);
        obj[21] = new SqlParameter("chucvunguoilh", Updated.chucvunguoilh);
        obj[22] = new SqlParameter("chucvunguoilhen", Updated.chucvunguoilhen);
        obj[23] = new SqlParameter("emailnguoilh", Updated.emailnguoilh);
        obj[24] = new SqlParameter("mobilenguoilh", Updated.mobilenguoilh);
        obj[25] = new SqlParameter("tenmien", Updated.tenmien);
        obj[26] = new SqlParameter("nhomID", Updated.nhomID);
        obj[27] = new SqlParameter("lopthanhvienID", Updated.lopthanhvienID);
        obj[28] = new SqlParameter("hinhanhlon", Updated.hinhanhlon);
        obj[29] = new SqlParameter("isActive", Updated.isActive);
        obj[30] = new SqlParameter("ngayhethan", Updated.ngayhethan);

        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_doanhnghiep_Update_UpdateNormal_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static doanhnghiep SelectById(Guid doanhnghiepID)
    {
        doanhnghiep Item = new doanhnghiep();
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("doanhnghiepID", doanhnghiepID);
        using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_doanhnghiep_Select_SelectById_linhnx", obj))
        {
            while (rd.Read())
            {
                Item = getFromReader(rd);
            }
        }
        return Item;
    }

    public static doanhnghiepCollection SelectAll(SqlConnection con)
    {
        doanhnghiepCollection List = new doanhnghiepCollection();
        using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_doanhnghiep_Select_SelectAll_linhnx"))
        {
            while (rd.Read())
            {
                List.Add(getFromReader(rd));
            }
        }
        return List;
    }
    public static Pager<doanhnghiep> pagerNormal(string url, bool rewrite, string sort)
    {
        SqlParameter[] obj = new SqlParameter[1];
        obj[0] = new SqlParameter("Sort", sort);
        Pager<doanhnghiep> pg = new Pager<doanhnghiep>("sp_tbldoanhnghiep_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
        return pg;
    }
    #endregion

    #region Utilities
    public static doanhnghiep getFromReader(IDataReader rd)
    {
        doanhnghiep Item = new doanhnghiep();
        if (rd.FieldExists("doanhnghiepID"))
        {
            Item.doanhnghiepID = (Guid)(rd["doanhnghiepID"]);
        }
        if (rd.FieldExists("tendangnhap"))
        {
            Item.tendangnhap = (String)(rd["tendangnhap"]);
        }
        if (rd.FieldExists("matkhau"))
        {
            Item.matkhau = (String)(rd["matkhau"]);
        }
        if (rd.FieldExists("tendoanhnghiep"))
        {
            Item.tendoanhnghiep = (String)(rd["tendoanhnghiep"]);
        }
        if (rd.FieldExists("tendoanhnghiepen"))
        {
            Item.tendoanhnghiepen = (String)(rd["tendoanhnghiepen"]);
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
        if (rd.FieldExists("tinhID"))
        {
            Item.tinhID = (Guid)(rd["tinhID"]);
        }
        if (rd.FieldExists("diachi"))
        {
            Item.diachi = (String)(rd["diachi"]);
        }
        if (rd.FieldExists("diachien"))
        {
            Item.diachien = (String)(rd["diachien"]);
        }
        if (rd.FieldExists("dienthoaidn"))
        {
            Item.dienthoaidn = (String)(rd["dienthoaidn"]);
        }
        if (rd.FieldExists("fax"))
        {
            Item.fax = (String)(rd["fax"]);
        }
        if (rd.FieldExists("nguoilienhe"))
        {
            Item.nguoilienhe = (String)(rd["nguoilienhe"]);
        }
        if (rd.FieldExists("dienthoainguoilh"))
        {
            Item.dienthoainguoilh = (String)(rd["dienthoainguoilh"]);
        }
        if (rd.FieldExists("website"))
        {
            Item.website = (String)(rd["website"]);
        }
        if (rd.FieldExists("ngaydangky"))
        {
            Item.ngaydangky = (DateTime)(rd["ngaydangky"]);
        }
        if (rd.FieldExists("email"))
        {
            Item.email = (String)(rd["email"]);
        }
        if (rd.FieldExists("trangthai"))
        {
            Item.trangthai = (Int16)(rd["trangthai"]);
        }
        if (rd.FieldExists("chucvunguoilh"))
        {
            Item.chucvunguoilh = (String)(rd["chucvunguoilh"]);
        }
        if (rd.FieldExists("chucvunguoilhen"))
        {
            Item.chucvunguoilhen = (String)(rd["chucvunguoilhen"]);
        }
        if (rd.FieldExists("emailnguoilh"))
        {
            Item.emailnguoilh = (String)(rd["emailnguoilh"]);
        }
        if (rd.FieldExists("mobilenguoilh"))
        {
            Item.mobilenguoilh = (String)(rd["mobilenguoilh"]);
        }
        if (rd.FieldExists("tenmien"))
        {
            Item.tenmien = (String)(rd["tenmien"]);
        }
        if (rd.FieldExists("nhomID"))
        {
            Item.nhomID = (Guid)(rd["nhomID"]);
        }
        if (rd.FieldExists("lopthanhvienID"))
        {
            Item.lopthanhvienID = (Int16)(rd["lopthanhvienID"]);
        }
        if (rd.FieldExists("hinhanhlon"))
        {
            Item.hinhanhlon = (String)(rd["hinhanhlon"]);
        }
        if (rd.FieldExists("isActive"))
        {
            Item.isActive = (Boolean)(rd["isActive"]);
        }
        if (rd.FieldExists("ngayhethan"))
        {
            Item.ngayhethan = (DateTime)(rd["ngayhethan"]);
        }
        return Item;
    }
    #endregion

    #region Extend
    #endregion
}
#endregion

#endregion