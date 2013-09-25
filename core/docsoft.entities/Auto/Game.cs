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
    #region Game
    #region BO
    public class Game : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ten { get; set; }
        public Int32 ThuTu { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public Game()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return GameDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class GameCollection : BaseEntityCollection<Game>
    { }
    #endregion
    #region Dal
    public class GameDal
    {
        #region Methods

        public static void DeleteById(Guid G_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("G_ID", G_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Game_Delete_DeleteById_linhnx", obj);
        }

        public static Game Insert(Game item)
        {
            var Item = new Game();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("G_ID", item.ID);
            obj[1] = new SqlParameter("G_Ten", item.Ten);
            obj[2] = new SqlParameter("G_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("G_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("G_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Game_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Game Update(Game item)
        {
            var Item = new Game();
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("G_ID", item.ID);
            obj[1] = new SqlParameter("G_Ten", item.Ten);
            obj[2] = new SqlParameter("G_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("G_NgayTao", item.NgayTao);
            }
            else
            {
                obj[3] = new SqlParameter("G_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Game_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Game SelectById(Guid G_ID)
        {
            var Item = new Game();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("G_ID", G_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAuto_Game_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GameCollection SelectAll(SqlConnection con)
        {
            var List = new GameCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAuto_Game_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static GameCollection SelectAll()
        {
            return SelectAll(DAL.con());
        }
        public static Pager<Game> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<Game>("sp_tblAuto_Game_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Game getFromReader(IDataReader rd)
        {
            var Item = new Game();
            if (rd.FieldExists("G_ID"))
            {
                Item.ID = (Guid)(rd["G_ID"]);
            }
            if (rd.FieldExists("G_Ten"))
            {
                Item.Ten = (String)(rd["G_Ten"]);
            }
            if (rd.FieldExists("G_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["G_ThuTu"]);
            }
            if (rd.FieldExists("G_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["G_NgayTao"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion
}


