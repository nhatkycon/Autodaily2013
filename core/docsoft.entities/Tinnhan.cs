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
    #region Tinnhan
    #region BO
    public class Tinnhan : BaseEntity
    {
        #region Properties
        public Int32 TinID { get; set; }
        public Int32 PID { get; set; }
        public Guid RowID { get; set; }
        public String Tieude { get; set; }
        public String Noidung { get; set; }
        public DateTime Ngaygui { get; set; }
        public Boolean Quantrong { get; set; }
        public Boolean File { get; set; }
        public Boolean Dagui { get; set; }
        public Boolean forward { get; set; }
        public String Usergui { get; set; }
        public String Listnguoinhan { get; set; }
        public String Listcc { get; set; }
        public String Listbc { get; set; }

        #endregion
        #region Contructor
        public Tinnhan()
        { }
        #endregion
        #region Customs properties
        public Int32 Thutu { get; set; }
        public Boolean Doc { get; set; }
        public Boolean Co { get; set; }

        public String Nguoigui { get; set; }
        public String NguoiguiTen { get; set; }

        public String Nguoinhan { get; set; }
        public Int32 slNguoinhan { get; set; }
        public Boolean UserCC { get; set; }
        public Boolean UserBC { get; set; }
        
        public String sNgaygui { get; set; }

        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }

        public TinhanMember NguoiguiObj { get; set; }


        public List<TinhanMember> Nguoinhanlist { get; set; }

        public List<TinhanMember> Cclist { get; set; }

        public List<TinhanMember> Bclist { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinnhanDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinnhanCollection : BaseEntityCollection<Tinnhan>
    { }
    #endregion
    #region Dal
    public class TinnhanDal
    {
        #region Methods
        public static void DeleteById(Int32 TN_TinID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TN_TinID", TN_TinID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Delete_DeleteById_ductt", obj);
        }
        public static Tinnhan Insert(Tinnhan Inserted)
        {
            Tinnhan Item = new Tinnhan();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("TN_PID", Inserted.PID);
            obj[1] = new SqlParameter("TN_RowID", Inserted.RowID);
            obj[2] = new SqlParameter("TN_Tieude", Inserted.Tieude);
            obj[3] = new SqlParameter("TN_Noidung", Inserted.Noidung);
            obj[4] = new SqlParameter("TN_Ngaygui", Inserted.Ngaygui);
            obj[5] = new SqlParameter("TN_Quantrong", Inserted.Quantrong);
            obj[6] = new SqlParameter("TN_File", Inserted.File);
            obj[7] = new SqlParameter("TN_Dagui", Inserted.Dagui);
            obj[8] = new SqlParameter("TN_forward", Inserted.forward);
            obj[9] = new SqlParameter("TN_Usergui", Inserted.Usergui);
            obj[10] = new SqlParameter("TN_Listnguoinhan", Inserted.Listnguoinhan);
            obj[11] = new SqlParameter("TN_Listcc", Inserted.Listcc);
            obj[12] = new SqlParameter("TN_Listbc", Inserted.Listbc);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Insert_InsertNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Tinnhan Update(Tinnhan Updated)
        {
            Tinnhan Item = new Tinnhan();
            SqlParameter[] obj = new SqlParameter[15];
            obj[0] = new SqlParameter("TN_TinID", Updated.TinID);
            obj[1] = new SqlParameter("TN_PID", Updated.PID);
            obj[2] = new SqlParameter("TN_RowID", Updated.RowID);
            obj[3] = new SqlParameter("TN_Tieude", Updated.Tieude);
            obj[4] = new SqlParameter("TN_Noidung", Updated.Noidung);
            obj[5] = new SqlParameter("TN_Ngaygui", Updated.Ngaygui);
            obj[6] = new SqlParameter("TN_Quantrong", Updated.Quantrong);
            obj[7] = new SqlParameter("TN_File", Updated.File);
            obj[8] = new SqlParameter("TN_Dagui", Updated.Dagui);
            obj[9] = new SqlParameter("TN_forward", Updated.forward);
            obj[10] = new SqlParameter("TN_Nguoigui", Updated.Nguoigui);
            obj[11] = new SqlParameter("TN_Usergui", Updated.Usergui);
            obj[12] = new SqlParameter("TN_Listnguoinhan", Updated.Listnguoinhan);
            obj[13] = new SqlParameter("TN_Listcc", Updated.Listcc);
            obj[14] = new SqlParameter("TN_Listbc", Updated.Listbc);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Update_UpdateNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        /// <summary>
        /// hàm này lấy thông tin từ select
        /// </summary>
        /// <param name="TN_TinID"></param>
        /// <returns></returns>
        public static Tinnhan SelectById(Int32 TN_TinID)
        {
            Tinnhan Item = new Tinnhan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TN_TinID", TN_TinID);


            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Select_SelectById_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }

            }

            List<Files> filelist = new List<Files>();
            filelist = FilesDal.SelectByTinnhanID(DAL.con(), Item.RowID);
            Item.Filelist = filelist;

            TinhanMember nguoigui = new TinhanMember();
            nguoigui = TinhanMemberDal.SelectNguoiguiByTinId(Item.TinID);
            Item.NguoiguiObj = nguoigui;


            List<TinhanMember> Nguoinhanlist = new List<TinhanMember>();
            Nguoinhanlist = TinhanMemberDal.SelectNguoinhanByTinId(DAL.con(), Item.TinID);
            Item.Nguoinhanlist = Nguoinhanlist;

            List<TinhanMember> Cclist = new List<TinhanMember>();
            Cclist = TinhanMemberDal.SelectCcByTinId(DAL.con(), Item.TinID);
            Item.Cclist = Cclist;

            List<TinhanMember> Bclist = new List<TinhanMember>();
            Bclist = TinhanMemberDal.SelectBcByTinId(DAL.con(), Item.TinID);
            Item.Bclist = Bclist;


            return Item;
        }
        public static TinnhanCollection SelectAll()
        {
            TinnhanCollection List = new TinnhanCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Select_SelectAll_ductt"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tinnhan> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<Tinnhan> pg = new Pager<Tinnhan>("sp_tblTinnhan_Pager_Normal_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Tinnhan getFromReader(IDataReader rd)
        {
            Tinnhan Item = new Tinnhan();
            if (rd.FieldExists("TN_Thutu"))
            {
                Item.Thutu =Convert.ToInt32(rd["TN_Thutu"]);
            }
            if (rd.FieldExists("TN_TinID"))
            {
                Item.TinID = (Int32)(rd["TN_TinID"]);
            }
            if (rd.FieldExists("TN_PID"))
            {
                Item.PID = (Int32)(rd["TN_PID"]);
            }
            if (rd.FieldExists("TN_RowID"))
            {
                Item.RowID = (Guid)(rd["TN_RowID"]);
            }
            if (rd.FieldExists("TN_Tieude"))
            {
                Item.Tieude = (String)(rd["TN_Tieude"]);
            }
            if (rd.FieldExists("TN_Noidung"))
            {
                Item.Noidung = (String)(rd["TN_Noidung"]);
            }
            if (rd.FieldExists("TN_Ngaygui"))
            {
                Item.Ngaygui = (DateTime)(rd["TN_Ngaygui"]);
            }
            if (rd.FieldExists("TN_Quantrong"))
            {
                Item.Quantrong = (Boolean)(rd["TN_Quantrong"]);
            }
            if (rd.FieldExists("TN_File"))
            {
                Item.File = (Boolean)(rd["TN_File"]);
            }
            if (rd.FieldExists("TN_Dagui"))
            {
                Item.Dagui = (Boolean)(rd["TN_Dagui"]);
            }
            if (rd.FieldExists("TN_forward"))
            {
                Item.forward = (Boolean)(rd["TN_forward"]);
            }
            if (rd.FieldExists("TNM_Doc"))
            {
                Item.Doc = (Boolean)(rd["TNM_Doc"]);
            }
            if (rd.FieldExists("TNM_Co"))
            {
                Item.Co = (Boolean)(rd["TNM_Co"]);
            }
            if (rd.FieldExists("TNM_Nguoigui"))
            {
                Item.Nguoigui = (String)(rd["TNM_Nguoigui"]);
            }
            if (rd.FieldExists("TNM_NguoiguiTen"))
            {
                Item.NguoiguiTen = (String)(rd["TNM_NguoiguiTen"]);
            }
            if (rd.FieldExists("TNM_Nguoinhan"))
            {
                Item.Nguoinhan = (String)(rd["TNM_Nguoinhan"]);
            }

            if (rd.FieldExists("TNM_UserCC"))
            {
                Item.UserCC = (Boolean)(rd["TNM_UserCC"]);
            }
            if (rd.FieldExists("TNM_UserBC"))
            {
                Item.UserBC = (Boolean)(rd["TNM_UserBC"]);
            }
            if (rd.FieldExists("slNguoinhan"))
            {
                Item.slNguoinhan = (Int32)(rd["slNguoinhan"]);
            }
            if (rd.FieldExists("TN_Usergui"))
            {
                Item.Usergui = (String)(rd["TN_Usergui"]);
            }
            if (rd.FieldExists("TN_Listnguoinhan"))
            {
                Item.Listnguoinhan = (String)(rd["TN_Listnguoinhan"]);
            }
            if (rd.FieldExists("TN_Listcc"))
            {
                Item.Listcc = (String)(rd["TN_Listcc"]);
            }
            if (rd.FieldExists("TN_Listbc"))
            {
                Item.Listbc = (String)(rd["TN_Listbc"]);
            }

            return Item;
        }
        #endregion

        #region Extend
       
        public static void DeletelistById(string TN_TinID, string username)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TN_TinID", TN_TinID);
            obj[1] = new SqlParameter("username", username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Delete_DeletelistById_ductt", obj);
        }
        public static void XoaBylistId(string TN_TinID, string username)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TN_TinID", TN_TinID);
            obj[1] = new SqlParameter("username", username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Delete_XoaBylistId_ductt", obj);
        }
        public static void DelEmpty(Int32 TN_TinID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TN_TinID", TN_TinID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Delete_DelEmpty_ductt", obj);
        }

        public static Tinnhan InsertDraff(Tinnhan Inserted)
        {
            Tinnhan Item = new Tinnhan();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("TN_PID", Inserted.PID);
            obj[1] = new SqlParameter("TN_RowID", Inserted.RowID);
            obj[2] = new SqlParameter("TN_Tieude", Inserted.Tieude);
            obj[3] = new SqlParameter("TN_Noidung", Inserted.Noidung);
            obj[4] = new SqlParameter("TN_Ngaygui", Inserted.Ngaygui);
            obj[5] = new SqlParameter("TN_Quantrong", Inserted.Quantrong);
            obj[6] = new SqlParameter("TN_File", Inserted.File);
            obj[7] = new SqlParameter("TN_Dagui", Inserted.Dagui);
            obj[8] = new SqlParameter("TN_forward", Inserted.forward);
            obj[9] = new SqlParameter("TN_Usergui", Inserted.Usergui);
            obj[10] = new SqlParameter("TN_Listnguoinhan", Inserted.Listnguoinhan);
            obj[11] = new SqlParameter("TN_Listcc", Inserted.Listcc);
            obj[12] = new SqlParameter("TN_Listbc", Inserted.Listbc);


            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Insert_InsertNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        /// <summary>
        /// Hàm này lấy thông tin dùng chuỗi
        /// </summary>
        /// <param name="TN_TinID"></param>
        /// <returns></returns>
        public static Tinnhan SelectById2(Int32 TN_TinID)
        {
            Tinnhan Item = new Tinnhan();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TN_TinID", TN_TinID);


            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhan_Select_SelectById_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }

            }

            List<Files> filelist = new List<Files>();
            filelist = FilesDal.SelectByTinnhanID(DAL.con(), Item.RowID);
            Item.Filelist = filelist;

            TinhanMember nguoigui = new TinhanMember();
            string[] _nguoigui = Item.Usergui.Split(new char[] { '(' });
            nguoigui.Ten = _nguoigui[0];
            nguoigui.User = _nguoigui[1].Remove(_nguoigui[1].Length - 2);
            nguoigui.TinID = Item.TinID;


            Item.NguoiguiObj = nguoigui;
            List<TinhanMember> Nguoinhanlist = new List<TinhanMember>();
            string[] _listnguoinhan = Item.Listnguoinhan.Split(new char[] { ',' });
            for (int i = 0; i < _listnguoinhan.Length - 1; i++)
            {
                TinhanMember Itemnhan = new TinhanMember();
                string[] _nguoinhan = _listnguoinhan[i].Split(new char[] { '(' });
                
                Itemnhan.Ten = _nguoinhan[0];
                Itemnhan.User = _nguoinhan[1].Remove(_nguoinhan[1].Length - 1);

                Itemnhan.TinID = Item.TinID;
                Nguoinhanlist.Add(Itemnhan);

            }
            Item.Nguoinhanlist = Nguoinhanlist;

            List<TinhanMember> Cclist = new List<TinhanMember>();
            string[] _listcc = Item.Listcc.Split(new char[] { ',' });
            for (int i = 0; i < _listcc.Length - 1; i++)
            {
                TinhanMember ItemCc= new TinhanMember();
                string[] _nguoicc = _listcc[i].Split(new char[] { '(' });
                
                ItemCc.Ten = _nguoicc[0];
                ItemCc.User = _nguoicc[1].Remove(_nguoicc[1].Length - 1);
                ItemCc.TinID = Item.TinID;
                Cclist.Add(ItemCc);

            }
            Item.Cclist = Cclist;

            List<TinhanMember> Bclist = new List<TinhanMember>();
            //Bclist = TinhanMemberDal.SelectBcByTinId(DAL.con(), Item.TinID);
            string[] _listbc = Item.Listbc.Split(new char[] { ',' });
            for (int i = 0; i < _listbc.Length - 1; i++)
            {
                TinhanMember Itembc = new TinhanMember();
                string[] _nguoibc = _listbc[i].Split(new char[] { '(' });
               
                Itembc.Ten = _nguoibc[0];
                Itembc.User = _nguoibc[1].Remove(_nguoibc[1].Length - 1);
                Itembc.TinID = Item.TinID;
                Bclist.Add(Itembc);

            }
            Item.Bclist = Bclist;


            return Item;
        }
        public static Pager<Tinnhan> GetTinDen(string url, bool rewrite, string sort, string username, string s)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("Username", username);
            if (!string.IsNullOrEmpty(s))
            {
                obj[2] = new SqlParameter("s", s);
            }
            else
            {
                obj[2] = new SqlParameter("s", DBNull.Value);
            }
            Pager<Tinnhan> pg = new Pager<Tinnhan>("sp_tblTinnhan_Pager_GetTinDen_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tinnhan> GetTindagui(string url, bool rewrite, string sort, string username, string s)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("Username", username);
            if (!string.IsNullOrEmpty(s))
            {
                obj[2] = new SqlParameter("s", s);
            }
            else
            {
                obj[2] = new SqlParameter("s", DBNull.Value);
            }
            Pager<Tinnhan> pg = new Pager<Tinnhan>("sp_tblTinnhan_Pager_GetTindagui_ductt", "page", 20, 10, rewrite, url, obj);

            return pg;
        }
        public static Pager<Tinnhan> GetTinchuagui(string url, bool rewrite, string sort, string username, string s)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("Username", username);
            if (!string.IsNullOrEmpty(s))
            {
                obj[2] = new SqlParameter("s", s);
            }
            else
            {
                obj[2] = new SqlParameter("s", DBNull.Value);
            }
            Pager<Tinnhan> pg = new Pager<Tinnhan>("sp_tblTinnhan_Pager_GetTinchuagui_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tinnhan> GetTindaxoa(string url, bool rewrite, string sort, string username, string s)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("Username", username);
            if (!string.IsNullOrEmpty(s))
            {
                obj[2] = new SqlParameter("s", s);
            }
            else
            {
                obj[2] = new SqlParameter("s", DBNull.Value);
            }
            Pager<Tinnhan> pg = new Pager<Tinnhan>("sp_tblTinnhan_Pager_GetTindaxoa_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        
            
        #endregion
    }
    #endregion

    #endregion

    #region TinhanMember
    #region BO
    public class TinhanMember : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 TinID { get; set; }
        public String User { get; set; }
        public String Ten { get; set; }
        public Boolean Gui { get; set; }
        public Boolean Nhan { get; set; }
        public Boolean UserCC { get; set; }
        public Boolean UserBC { get; set; }
        public Boolean Doc { get; set; }
        public Boolean Co { get; set; }
        public Boolean Thungrac { get; set; }
        public Boolean Thuden { get; set; }
        public Boolean Dagui { get; set; }
        public Boolean Spam { get; set; }
        public Int32 Thumuc { get; set; }
        public Boolean Xoa { get; set; }
        #endregion
        #region Contructor
        public TinhanMember()
        { }
        public TinhanMember(IDataReader rd)
        {
            if (rd.FieldExists("TNM_ID"))
            {
                ID = (Int32)(rd["TNM_ID"]);
            }
            if (rd.FieldExists("TNM_TinID"))
            {
                TinID = (Int32)(rd["TNM_TinID"]);
            }
            if (rd.FieldExists("TNM_User"))
            {
                User = (String)(rd["TNM_User"]);
            }
            if (rd.FieldExists("TNM_Ten"))
            {
                Ten = (String)(rd["TNM_Ten"]);
            }
            if (rd.FieldExists("TNM_Gui"))
            {
                Gui = (Boolean)(rd["TNM_Gui"]);
            }
            if (rd.FieldExists("TNM_Nhan"))
            {
                Nhan = (Boolean)(rd["TNM_Nhan"]);
            }
            if (rd.FieldExists("TNM_UserCC"))
            {
                UserCC = (Boolean)(rd["TNM_UserCC"]);
            }
            if (rd.FieldExists("TNM_UserBC"))
            {
                UserBC = (Boolean)(rd["TNM_UserBC"]);
            }
            if (rd.FieldExists("TNM_Doc"))
            {
                Doc = (Boolean)(rd["TNM_Doc"]);
            }
            if (rd.FieldExists("TNM_Co"))
            {
                Co = (Boolean)(rd["TNM_Co"]);
            }
            if (rd.FieldExists("TNM_Thungrac"))
            {
                Thungrac = (Boolean)(rd["TNM_Thungrac"]);
            }
            if (rd.FieldExists("TNM_Thuden"))
            {
                Thuden = (Boolean)(rd["TNM_Thuden"]);
            }
            if (rd.FieldExists("TNM_Dagui"))
            {
                Dagui = (Boolean)(rd["TNM_Dagui"]);
            }
            if (rd.FieldExists("TNM_Spam"))
            {
                Spam = (Boolean)(rd["TNM_Spam"]);
            }
            if (rd.FieldExists("TNM_Thumuc"))
            {
                Thumuc = (Int32)(rd["TNM_Thumuc"]);
            }
            if (rd.FieldExists("TNM_Xoa"))
            {
                Xoa = (Boolean)(rd["TNM_Xoa"]);
            }
        }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinhanMemberDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinhanMemberCollection : BaseEntityCollection<TinhanMember>
    { }
    #endregion
    #region Dal
    public class TinhanMemberDal
    {
        #region Methods

        public static void DeleteById(Int32 TNM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TNM_ID", TNM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_Delete_DeleteById_ductt", obj);
        }

        public static void ClearTemp(Int32 TNM_TinID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TNM_TinID", TNM_TinID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_Delete_ClearTemp_ductt", obj);
        }

        public static TinhanMember Insert(TinhanMember Inserted)
        {
            TinhanMember Item = new TinhanMember();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("TNM_TinID", Inserted.TinID);
            obj[1] = new SqlParameter("TNM_User", Inserted.User);
            obj[2] = new SqlParameter("TNM_Gui", Inserted.Gui);
            obj[3] = new SqlParameter("TNM_UserCC", Inserted.UserCC);
            obj[4] = new SqlParameter("TNM_UserBC", Inserted.UserBC);
            obj[5] = new SqlParameter("TNM_Doc", Inserted.Doc);
            obj[6] = new SqlParameter("TNM_Co", Inserted.Co);
            obj[7] = new SqlParameter("TNM_Thungrac", Inserted.Thungrac);
            obj[8] = new SqlParameter("TNM_Thuden", Inserted.Thuden);
            obj[9] = new SqlParameter("TNM_Dagui", Inserted.Dagui);
            obj[10] = new SqlParameter("TNM_Spam", Inserted.Spam);
            obj[11] = new SqlParameter("TNM_Thumuc", Inserted.Thumuc);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_Insert_InsertNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinhanMember InsertNhan(TinhanMember Inserted)
        {
            TinhanMember Item = new TinhanMember();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("TNM_TinID", Inserted.TinID);
            obj[1] = new SqlParameter("TNM_User", Inserted.User);
            obj[2] = new SqlParameter("TNM_Gui", Inserted.Gui);
            obj[3] = new SqlParameter("TNM_UserCC", Inserted.UserCC);
            obj[4] = new SqlParameter("TNM_UserBC", Inserted.UserBC);
            obj[5] = new SqlParameter("TNM_Doc", Inserted.Doc);
            obj[6] = new SqlParameter("TNM_Co", Inserted.Co);
            obj[7] = new SqlParameter("TNM_Thungrac", Inserted.Thungrac);
            obj[8] = new SqlParameter("TNM_Thuden", Inserted.Thuden);
            obj[9] = new SqlParameter("TNM_Dagui", Inserted.Dagui);
            obj[10] = new SqlParameter("TNM_Spam", Inserted.Spam);
            obj[11] = new SqlParameter("TNM_Thumuc", Inserted.Thumuc);
            obj[12] = new SqlParameter("TNM_Nhan", Inserted.Nhan);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_Insert_InsertNhan_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinhanMember Update(TinhanMember Updated)
        {
            TinhanMember Item = new TinhanMember();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("TNM_ID", Updated.ID);
            obj[1] = new SqlParameter("TNM_TinID", Updated.TinID);
            obj[2] = new SqlParameter("TNM_User", Updated.User);
            obj[3] = new SqlParameter("TNM_Gui", Updated.Gui);
            obj[4] = new SqlParameter("TNM_UserCC", Updated.UserCC);
            obj[5] = new SqlParameter("TNM_UserBC", Updated.UserBC);
            obj[6] = new SqlParameter("TNM_Doc", Updated.Doc);
            obj[7] = new SqlParameter("TNM_Co", Updated.Co);
            obj[8] = new SqlParameter("TNM_Thungrac", Updated.Thungrac);
            obj[9] = new SqlParameter("TNM_Thuden", Updated.Thuden);
            obj[10] = new SqlParameter("TNM_Dagui", Updated.Dagui);
            obj[11] = new SqlParameter("TNM_Spam", Updated.Spam);
            obj[12] = new SqlParameter("TNM_Thumuc", Updated.Thumuc);
            obj[13] = new SqlParameter("TNM_Xoa", Updated.Xoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_Update_UpdateNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinhanMember SelectById(Int32 TNM_ID)
        {
            TinhanMember Item = new TinhanMember();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TNM_ID", TNM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_Select_SelectById_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinhanMember SelectByTinID(Int32 TNM_TinID, string TNM_User)
        {
            TinhanMember Item = new TinhanMember();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TNM_TinID", TNM_TinID);
            obj[1] = new SqlParameter("TNM_User", TNM_User);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_Select_SelectByTinID_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static TinhanMember SelectNguoiguiByTinId(Int32 TinID)
        {
            TinhanMember Item = new TinhanMember();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TinID", TinID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_Select_SelectNguoiguiByTinId_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinhanMemberCollection SelectNguoinhanByTinId(SqlConnection con, Int32 TinID)
        {
            TinhanMemberCollection List = new TinhanMemberCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TinID", TinID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTinhanMember_Select_SelectNguoinhanByTinId_ductt", obj))
            {
                while (rd.Read())
                {
                    List.Add(new TinhanMember(rd));
                }
            }
            return List;
        }
        public static TinhanMemberCollection SelectCcByTinId(SqlConnection con, Int32 TinID)
        {
            TinhanMemberCollection List = new TinhanMemberCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TinID", TinID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTinhanMember_Select_SelectCcByTinId_ductt", obj))
            {
                while (rd.Read())
                {
                    List.Add(new TinhanMember(rd));
                }
            }
            return List;
        }
        public static TinhanMemberCollection SelectBcByTinId(SqlConnection con, Int32 TinID)
        {
            TinhanMemberCollection List = new TinhanMemberCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TinID", TinID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTinhanMember_Select_SelectBcByTinId_ductt", obj))
            {
                while (rd.Read())
                {
                    List.Add(new TinhanMember(rd));
                }
            }
            return List;
        }
        public static void DatcoBylistId(string TN_TinID, string username)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TN_TinID", TN_TinID);
            obj[1] = new SqlParameter("username", username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_DatcoBylistId_ductt", obj);
        }
        public static void ChuyentoiBylistId(string TN_TinID, string username, string chuyenden)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TN_TinID", TN_TinID);
            obj[1] = new SqlParameter("username", username);
            obj[2] = new SqlParameter("chuyenden", chuyenden);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_ChuyentoiBylistId_ductt", obj);
        }
        public static void BocoBylistId(string TN_TinID, string username)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TN_TinID", TN_TinID);
            obj[1] = new SqlParameter("username", username);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_BocoBylistId_ductt", obj);
        }
        public static TinhanMemberCollection SelectAll()
        {
            TinhanMemberCollection List = new TinhanMemberCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinhanMember_Select_SelectAll_ductt"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TinhanMember> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TinhanMember> pg = new Pager<TinhanMember>("sp_tblTinhanMember_Pager_Normal_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TinhanMember getFromReader(IDataReader rd)
        {
            TinhanMember Item = new TinhanMember();
            if (rd.FieldExists("TNM_ID"))
            {
                Item.ID = (Int32)(rd["TNM_ID"]);
            }
            if (rd.FieldExists("TNM_TinID"))
            {
                Item.TinID = (Int32)(rd["TNM_TinID"]);
            }
            if (rd.FieldExists("TNM_User"))
            {
                Item.User = (String)(rd["TNM_User"]);
            }
            if (rd.FieldExists("TNM_Ten"))
            {
                Item.Ten = (String)(rd["TNM_Ten"]);
            }
            if (rd.FieldExists("TNM_Gui"))
            {
                Item.Gui = (Boolean)(rd["TNM_Gui"]);
            }
            if (rd.FieldExists("TNM_Nhan"))
            {
                Item.Nhan = (Boolean)(rd["TNM_Nhan"]);
            }
            if (rd.FieldExists("TNM_UserCC"))
            {
                Item.UserCC = (Boolean)(rd["TNM_UserCC"]);
            }
            if (rd.FieldExists("TNM_UserBC"))
            {
                Item.UserBC = (Boolean)(rd["TNM_UserBC"]);
            }
            if (rd.FieldExists("TNM_Doc"))
            {
                Item.Doc = (Boolean)(rd["TNM_Doc"]);
            }
            if (rd.FieldExists("TNM_Co"))
            {
                Item.Co = (Boolean)(rd["TNM_Co"]);
            }
            if (rd.FieldExists("TNM_Thungrac"))
            {
                Item.Thungrac = (Boolean)(rd["TNM_Thungrac"]);
            }
            if (rd.FieldExists("TNM_Thuden"))
            {
                Item.Thuden = (Boolean)(rd["TNM_Thuden"]);
            }
            if (rd.FieldExists("TNM_Dagui"))
            {
                Item.Dagui = (Boolean)(rd["TNM_Dagui"]);
            }
            if (rd.FieldExists("TNM_Spam"))
            {
                Item.Spam = (Boolean)(rd["TNM_Spam"]);
            }
            if (rd.FieldExists("TNM_Thumuc"))
            {
                Item.Thumuc = (Int32)(rd["TNM_Thumuc"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion

    #region TinnhanDanhba
    #region BO
    public class TinnhanDanhba : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String User { get; set; }
        public String Username { get; set; }
        public String Ten { get; set; }
        
        #endregion
        #region Contructor
        public TinnhanDanhba()
        { }
        #endregion
        #region Customs properties
        public Int32 Thutu { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinnhanDanhbaDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinnhanDanhbaCollection : BaseEntityCollection<TinnhanDanhba>
    { }
    #endregion
    #region Dal
    public class TinnhanDanhbaDal
    {
        #region Methods

        public static void DeleteById(Int32 DB_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DB_ID", DB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanDanhba_Delete_DeleteById_ductt", obj);
        }

        public static TinnhanDanhba Insert(TinnhanDanhba Inserted)
        {
            TinnhanDanhba Item = new TinnhanDanhba();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DB_User", Inserted.User);
            obj[1] = new SqlParameter("DB_Username", Inserted.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanDanhba_Insert_InsertNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanDanhba Update(TinnhanDanhba Updated)
        {
            TinnhanDanhba Item = new TinnhanDanhba();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("DB_ID", Updated.ID);
            obj[1] = new SqlParameter("DB_User", Updated.User);
            obj[2] = new SqlParameter("DB_Username", Updated.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanDanhba_Update_UpdateNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanDanhba SelectById(Int32 DB_ID)
        {
            TinnhanDanhba Item = new TinnhanDanhba();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DB_ID", DB_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanDanhba_Select_SelectById_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanDanhbaCollection SelectAll()
        {
            TinnhanDanhbaCollection List = new TinnhanDanhbaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanDanhba_Select_SelectAll_ductt"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TinnhanDanhba> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TinnhanDanhba> pg = new Pager<TinnhanDanhba>("sp_tblTinnhanDanhba_Pager_Normal_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TinnhanDanhba getFromReader(IDataReader rd)
        {
            TinnhanDanhba Item = new TinnhanDanhba();
            if (rd.FieldExists("DB_ID"))
            {
                Item.ID = (Int32)(rd["DB_ID"]);
            }
            if (rd.FieldExists("DB_User"))
            {
                Item.User = (String)(rd["DB_User"]);
            }
            if (rd.FieldExists("DB_Username"))
            {
                Item.Username = (String)(rd["DB_Username"]);
            }
            if (rd.FieldExists("DB_Thutu"))
            {
                Item.Thutu = Convert.ToInt32(rd["DB_Thutu"]);
            }
            if (rd.FieldExists("MEM_Ten"))
            {
                Item.Ten = (String)(rd["MEM_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<TinnhanDanhba> pagerSelectByUser(string url, bool rewrite, string sort, string User, string GID,string s)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("User", User);
            if (!string.IsNullOrEmpty(GID))
            {
                obj[2] = new SqlParameter("GID", GID);
            }
            else
            {
                obj[2] = new SqlParameter("GID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s))
            {
                obj[3] = new SqlParameter("s", s);
            }
            else
            {
                obj[3] = new SqlParameter("s", DBNull.Value);
            }
            Pager<TinnhanDanhba> pg = new Pager<TinnhanDanhba>("sp_tblTinnhanDanhba_Pager_SelectByUser_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static TinnhanDanhbaCollection SelectByUser(string User, string GID, string s)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("User", User);
            if (!string.IsNullOrEmpty(GID))
            {
                obj[1] = new SqlParameter("GID", GID);
            }
            else
            {
                obj[1] = new SqlParameter("GID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(s))
            {
                obj[2] = new SqlParameter("s", s);
            }
            else
            {
                obj[2] = new SqlParameter("s", DBNull.Value);
            }
            TinnhanDanhbaCollection List = new TinnhanDanhbaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanDanhba_Select_SelectByUser_ductt", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static void XoaBylistId(string DB_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DB_ID", DB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanDanhba_Delete_XoaBylistId_ductt", obj);
        }
        public static void XoaByGroupId(string DB_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DB_ID", DB_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanDanhba_Delete_XoaByGroupId_ductt", obj);
        }
        public static void ChuyentoiBylistId(string DB_ID,  string G_ID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DB_ID", DB_ID);
            obj[1] = new SqlParameter("G_ID", G_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_TinnhanDanhba_ChuyentoiBylistId_ductt", obj);
        }
        #endregion
    }
    #endregion

    #endregion
  
    #region TinnhanGroup
    #region BO
    public class TinnhanGroup : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Username { get; set; }
        #endregion
        #region Contructor
        public TinnhanGroup()
        { }
        #endregion
        #region Customs properties
        public Int32 Thutu { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinnhanGroupDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinnhanGroupCollection : BaseEntityCollection<TinnhanGroup>
    { }
    #endregion
    #region Dal
    public class TinnhanGroupDal
    {
        #region Methods

        public static void DeleteById(Int32 G_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("G_ID", G_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroup_Delete_DeleteById_ductt", obj);
        }

        public static TinnhanGroup Insert(TinnhanGroup Inserted)
        {
            TinnhanGroup Item = new TinnhanGroup();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("G_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("G_Username", Inserted.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroup_Insert_InsertNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanGroup Update(TinnhanGroup Updated)
        {
            TinnhanGroup Item = new TinnhanGroup();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("G_ID", Updated.ID);
            obj[1] = new SqlParameter("G_Ten", Updated.Ten);
            obj[2] = new SqlParameter("G_Username", Updated.Username);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroup_Update_UpdateNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanGroup SelectById(Int32 G_ID)
        {
            TinnhanGroup Item = new TinnhanGroup();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("G_ID", G_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroup_Select_SelectById_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanGroupCollection SelectAll()
        {
            TinnhanGroupCollection List = new TinnhanGroupCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroup_Select_SelectAll_ductt"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TinnhanGroup> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TinnhanGroup> pg = new Pager<TinnhanGroup>("sp_tblTinnhanGroup_Pager_Normal_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TinnhanGroup getFromReader(IDataReader rd)
        {
            TinnhanGroup Item = new TinnhanGroup();
            if (rd.FieldExists("G_ID"))
            {
                Item.ID = (Int32)(rd["G_ID"]);
            }
            if (rd.FieldExists("G_Ten"))
            {
                Item.Ten = (String)(rd["G_Ten"]);
            }
            if (rd.FieldExists("G_Username"))
            {
                Item.Username = (String)(rd["G_Username"]);
            }
            if (rd.FieldExists("G_Thutu"))
            {
                Item.Thutu = Convert.ToInt32(rd["G_Thutu"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<TinnhanGroup> pagerSelectByUser(string url, bool rewrite, string sort, string User)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("User", User);
            Pager<TinnhanGroup> pg = new Pager<TinnhanGroup>("sp_tblTinnhanGroup_Pager_SelectByUser_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static void XoaBylistId(string G_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("G_ID", G_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroup_Delete_XoaBylistId_ductt", obj);
        }
        public static TinnhanGroupCollection SelectAllByUser(string q,string Username)
        {
            TinnhanGroupCollection List = new TinnhanGroupCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroup_Select_SelectAllByUser_ductt", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        
        }
        public static TinnhanGroupCollection SelectByUserName(string User, string Username)
        {
            TinnhanGroupCollection List = new TinnhanGroupCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("User", User);
            obj[1] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroup_Select_SelectByUserName_ductt", obj))
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

    #region TinnhanGroupDetail
    #region BO
    public class TinnhanGroupDetail : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 IDG { get; set; }
        public Int32 IDDB { get; set; }
        public String Username { get; set; }
        public Int32 Thutu { get; set; }
        #endregion
        #region Contructor
        public TinnhanGroupDetail()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinnhanGroupDetailDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinnhanGroupDetailCollection : BaseEntityCollection<TinnhanGroupDetail>
    { }
    #endregion
    #region Dal
    public class TinnhanGroupDetailDal
    {
        #region Methods

        public static void DeleteById(Int32 GD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GD_ID", GD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroupDetail_Delete_DeleteById_ductt", obj);
        }

        public static TinnhanGroupDetail Insert(TinnhanGroupDetail Inserted)
        {
            TinnhanGroupDetail Item = new TinnhanGroupDetail();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("GD_ID", Inserted.ID);
            obj[1] = new SqlParameter("GD_IDG", Inserted.IDG);
            obj[2] = new SqlParameter("GD_IDDB", Inserted.IDDB);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroupDetail_Insert_InsertNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanGroupDetail Update(TinnhanGroupDetail Updated)
        {
            TinnhanGroupDetail Item = new TinnhanGroupDetail();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("GD_ID", Updated.ID);
            obj[1] = new SqlParameter("GD_IDG", Updated.IDG);
            obj[2] = new SqlParameter("GD_IDDB", Updated.IDDB);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroupDetail_Update_UpdateNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanGroupDetail SelectById(Int32 GD_ID)
        {
            TinnhanGroupDetail Item = new TinnhanGroupDetail();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GD_ID", GD_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroupDetail_Select_SelectById_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanGroupDetailCollection SelectAll()
        {
            TinnhanGroupDetailCollection List = new TinnhanGroupDetailCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroupDetail_Select_SelectAll_ductt"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TinnhanGroupDetail> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TinnhanGroupDetail> pg = new Pager<TinnhanGroupDetail>("sp_tblTinnhanGroupDetail_Pager_Normal_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TinnhanGroupDetail getFromReader(IDataReader rd)
        {
            TinnhanGroupDetail Item = new TinnhanGroupDetail();
            if (rd.FieldExists("GD_ID"))
            {
                Item.ID = (Int32)(rd["GD_ID"]);
            }
            if (rd.FieldExists("GD_IDG"))
            {
                Item.IDG = (Int32)(rd["GD_IDG"]);
            }
            if (rd.FieldExists("GD_IDDB"))
            {
                Item.IDDB = (Int32)(rd["GD_IDDB"]);
            }
            if (rd.FieldExists("GD_Thutu"))
            {
                Item.Thutu = Convert.ToInt32(rd["GD_Thutu"]);
            }
            if (rd.FieldExists("GD_Username"))
            {
                Item.Username = (String)(rd["GD_Username"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<TinnhanGroupDetail> pagerSelectByUser(string url, bool rewrite, string sort, int IDG)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("IDG", IDG);
            Pager<TinnhanGroupDetail> pg = new Pager<TinnhanGroupDetail>("sp_tblTinnhanGroupDetail_Pager_SelectByUser_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static void XoaBylistId(string GD_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GD_ID", GD_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanGroupDetail_Delete_XoaBylistId_ductt", obj);
        }
        #endregion
    }
    #endregion

    #endregion

    #region TinnhanThumuc
    #region BO
    public class TinnhanThumuc : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 MemID { get; set; }
        public String Thumuc { get; set; }
        #endregion
        #region Contructor
        public TinnhanThumuc()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinnhanThumucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinnhanThumucCollection : BaseEntityCollection<TinnhanThumuc>
    { }
    #endregion
    #region Dal
    public class TinnhanThumucDal
    {
        #region Methods

        public static void DeleteById(Int32 TNTM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TNTM_ID", TNTM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanThumuc_Delete_DeleteById_ductt", obj);
        }

        public static TinnhanThumuc Insert(TinnhanThumuc Inserted)
        {
            TinnhanThumuc Item = new TinnhanThumuc();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TNTM_ID", Inserted.ID);
            obj[1] = new SqlParameter("TNTM_MemID", Inserted.MemID);
            obj[2] = new SqlParameter("TNTM_Thumuc", Inserted.Thumuc);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanThumuc_Insert_InsertNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanThumuc Update(TinnhanThumuc Updated)
        {
            TinnhanThumuc Item = new TinnhanThumuc();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TNTM_ID", Updated.ID);
            obj[1] = new SqlParameter("TNTM_MemID", Updated.MemID);
            obj[2] = new SqlParameter("TNTM_Thumuc", Updated.Thumuc);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanThumuc_Update_UpdateNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanThumuc SelectById(Int32 TNTM_ID)
        {
            TinnhanThumuc Item = new TinnhanThumuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TNTM_ID", TNTM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanThumuc_Select_SelectById_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinnhanThumucCollection SelectAll()
        {
            TinnhanThumucCollection List = new TinnhanThumucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTinnhanThumuc_Select_SelectAll_ductt"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<TinnhanThumuc> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<TinnhanThumuc> pg = new Pager<TinnhanThumuc>("sp_tblTinnhanThumuc_Pager_Normal_ductt", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static TinnhanThumuc getFromReader(IDataReader rd)
        {
            TinnhanThumuc Item = new TinnhanThumuc();
            if (rd.FieldExists("TNTM_ID"))
            {
                Item.ID = (Int32)(rd["TNTM_ID"]);
            }
            if (rd.FieldExists("TNTM_MemID"))
            {
                Item.MemID = (Int32)(rd["TNTM_MemID"]);
            }
            if (rd.FieldExists("TNTM_Thumuc"))
            {
                Item.Thumuc = (String)(rd["TNTM_Thumuc"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion


    #region Herderinfo
    public class HerderEntity : BaseEntity
    {
        #region Properties
        String Username { get; set; }
        String Ten  { get; set; }
        #endregion
        #region Contructor
        public HerderEntity()
        { }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return (new HerderEntity());
        }
    }
    #endregion

    #region TinnhanHerder
    public class TinnhanHerder : BaseEntity
    {
        #region Properties
        HerderEntity Nguoigui { get; set; }
        List<HerderEntity> ListNguoinhan { get; set; }
        List<HerderEntity> Listcc { get; set; }
        List<HerderEntity> Listbc { get; set; }
        #endregion
        #region Contructor
        public TinnhanHerder()
        { }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return (new TinnhanHerder());
        }
    }
    #endregion

}
