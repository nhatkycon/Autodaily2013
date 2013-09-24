using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using linh.core;
using linh.core.dal;
using System.Web;
namespace linh.controls
{
    public class Pager<T> where T : BaseEntity, new()
    {
        public List<T> List { get; set; }
        public Int64 Total { get; set; }
        public Int32 PageSize { get; set; }
        public Int32 TotalPages { get; set; }
        public string StoreProcedure { get; set; }
        public Int64 PageIndex { get; set; }
        public string Query { get; set; }
        public string Paging { get; set; }
        public int PagingSize { get; set; }
        public string CUrl { get; set; }
        public bool UseRewriter { get; set; }
        protected virtual void ExecuteStore()
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("PageSize", PageSize);
            obj[1] = new SqlParameter("PageIndex", PageIndex);
            List = new List<T>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, StoreProcedure, obj))
            {
                while (rd.Read())
                {
                    Total = Convert.ToInt64(rd["Total"]);
                    List.Add((T)(new T().getFromReader(rd)));
                }
            }
            GeneratePaging();
        }
        protected virtual void ExecuteStore(SqlConnection con)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("PageSize", PageSize);
            obj[1] = new SqlParameter("PageIndex", PageIndex);
            List = new List<T>();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, StoreProcedure, obj))
            {
                while (rd.Read())
                {
                    Total = Convert.ToInt64(rd["Total"]);
                    List.Add((T)(new T().getFromReader(rd)));
                }
            }
            GeneratePaging();
        }
        protected virtual void ExecuteStore(SqlParameter[] obj)
        {
            int _length = obj.Length;
            Array.Resize(ref obj, _length + 2);
            obj[_length] = new SqlParameter("PageSize", PageSize);
            obj[_length + 1] = new SqlParameter("PageIndex", PageIndex);
            List = new List<T>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, StoreProcedure, obj))
            {
                while (rd.Read())
                {
                    Total = Convert.ToInt64(rd["Total"]);
                    List.Add((T)(new T().getFromReader(rd)));
                }
            }
            GeneratePaging();
        }
        protected virtual void ExecuteStore(SqlParameter[] obj, SqlConnection con)
        {
            int _length = obj.Length;
            Array.Resize(ref obj, _length + 2);
            obj[_length] = new SqlParameter("PageSize", PageSize);
            obj[_length + 1] = new SqlParameter("PageIndex", PageIndex);
            List = new List<T>();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, StoreProcedure, obj))
            {
                while (rd.Read())
                {
                    Total = Convert.ToInt64(rd["Total"]);
                    List.Add((T)(new T().getFromReader(rd)));
                }
            }
            GeneratePaging();
        }
        protected virtual void ExecuteStore(SqlParameter[] obj, SqlTransaction con)
        {
            int _length = obj.Length;
            Array.Resize(ref obj, _length + 2);
            obj[_length] = new SqlParameter("PageSize", PageSize);
            obj[_length + 1] = new SqlParameter("PageIndex", PageIndex);
            List = new List<T>();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, StoreProcedure, obj))
            {
                while (rd.Read())
                {
                    Total = Convert.ToInt64(rd["Total"]);
                    List.Add((T)(new T().getFromReader(rd)));
                }
            }
            GeneratePaging();
        }
        protected virtual void GeneratePaging()
        {
            #region Nạp TotalPages, currentPageStage, maxPage
            if (Total % PageSize == 0)
            {
                TotalPages = Convert.ToInt32(Total / PageSize);
            }
            else
            {
                TotalPages = Convert.ToInt32(Math.Floor(Convert.ToDouble(Total / PageSize))) + 1;
            }

            Int64 currentPageStage = 0;
            if (PageIndex % PagingSize == 0)
            {
                currentPageStage = PageIndex / PagingSize;
            }
            else
            {
                currentPageStage = Convert.ToInt64(Math.Floor(Convert.ToDouble(PageIndex / PagingSize))) + 1;
            }
            Int64 maxPage = 0;
            if (TotalPages % PagingSize == 0)
            {
                maxPage = TotalPages / PagingSize;
            }
            else
            {
                maxPage = Convert.ToInt64(Math.Floor(Convert.ToDouble(TotalPages / PagingSize))) + 1;
            }
            #endregion
            var sb = new StringBuilder();
            #region new
            #endregion
            #region old
            if (Total > 0 && Total > PageSize)
            {
                if (TotalPages < PagingSize)// Tổng số trang nhỏ hơn số trang trong khay paging
                {
                    #region Paging
                    for (int i = Convert.ToInt32(((currentPageStage - 1) * PagingSize) + 1); i <= (currentPageStage * PagingSize); i++)
                    {
                        if (i <= TotalPages)
                        {
                            //sb.AppendFormat("<a class=\"PagingItem {1}\" href=\"{4}{2}{3}\">{0}</a>"
                            //    , i
                            //    , i == PageIndex ? "PagingItemActive" : ""
                            //    , UseRewriter ? Query + "/" : "&" + Query + "="
                            //    , i
                            //    , string.IsNullOrEmpty(CUrl) ? "?" : CUrl);
                            sb.AppendFormat("<a class=\"PagingItem {1}\" href=\"{2}\">{0}</a>"
                                , i
                                , i == PageIndex ? "PagingItemActive" : ""
                                , string.Format(CUrl, i, Query));
                        }
                    }
                    #endregion
                }
                else
                {
                    if (currentPageStage > 1 && currentPageStage < maxPage)
                    {
                        #region Firts, Prev
                        sb.AppendFormat("<a class=\"PagingItem PagingItemFirts\" href=\"{0}\"><<</a>"
                            , string.Format(CUrl, "1", Query));
                        sb.AppendFormat("<a class=\"PagingItem PagingItemPrev\" href=\"{0}\"><</a>"
                            , string.Format(CUrl, ((currentPageStage - 1) * PagingSize), Query));
                        #endregion
                        #region Paging
                        for (int i = Convert.ToInt32(((currentPageStage - 1) * PagingSize) + 1); i <= (currentPageStage * PagingSize); i++)
                        {
                            if (i < TotalPages)
                            {
                                sb.AppendFormat("<a class=\"PagingItem {1}\" href=\"{2}\">{0}</a>"
                                , i
                                , i == PageIndex ? "PagingItemActive" : ""
                                , string.Format(CUrl, i, Query));
                            }
                        }
                        #endregion
                        #region Next, Last
                        sb.AppendFormat("<a class=\"PagingItem PagingItemFirts\" href=\"{0}\">></a>"
                            , string.Format(CUrl, (currentPageStage * PagingSize) + 1, Query));
                        sb.AppendFormat("<a class=\"PagingItem PagingItemFirts\" href=\"{0}\">>></a>"
                            , string.Format(CUrl, TotalPages, Query));
                        #endregion

                    }
                    else if (currentPageStage == 1)
                    {
                        #region Paging
                        for (int i = Convert.ToInt32(((currentPageStage - 1) * PagingSize) + 1); i <= (currentPageStage * PagingSize); i++)
                        {
                            if (i < TotalPages)
                            {
                                sb.AppendFormat("<a class=\"PagingItem {1}\" href=\"{2}\">{0}</a>"
                                , i
                                , i == PageIndex ? "PagingItemActive" : ""
                                , string.Format(CUrl, i, Query));
                            }
                        }
                        #endregion
                        #region Next, Last
                        sb.AppendFormat("<a class=\"PagingItem PagingItemFirts\" href=\"{0}\">></a>"
                            , string.Format(CUrl, (currentPageStage * PagingSize) + 1, Query));
                        sb.AppendFormat("<a class=\"PagingItem PagingItemFirts\" href=\"{0}\">>></a>"
                            , string.Format(CUrl, TotalPages, Query));
                        #endregion
                    }
                    else
                    {
                        #region Firts, Prev
                        sb.AppendFormat("<a class=\"PagingItem PagingItemFirts\" href=\"{0}\"><<</a>"
                            , string.Format(CUrl, "1", Query));
                        sb.AppendFormat("<a class=\"PagingItem PagingItemPrev\" href=\"{0}\"><</a>"
                            , string.Format(CUrl, ((currentPageStage - 1) * PagingSize), Query));
                        #endregion
                        #region Paging
                        for (int i = Convert.ToInt32(((currentPageStage - 1) * PagingSize) + 1); i <= (currentPageStage * PagingSize); i++)
                        {
                            if (i < TotalPages)
                            {
                                sb.AppendFormat("<a class=\"PagingItem {1}\" href=\"{2}\">{0}</a>"
                                , i
                                , i == PageIndex ? "PagingItemActive" : ""
                                , string.Format(CUrl, i, Query));
                            }
                        }
                        #endregion
                    }
                }
            }
            #endregion
            Paging = sb.ToString();
        }
        public Pager() { }
        public Pager(string _StoreProcedure, string _Query, Int32? _PageSize, Int32 _PagingSize, bool? _UseRewriter, string _CUrl)
        {
            if (_Query == null) _Query = "Index";
            Query = _Query;
            string pageIndex = HttpContext.Current.Request[Query];
            if (pageIndex == null) pageIndex = "0";
            Int64 _PageIndex = 0; ;
            if (Int64.TryParse(pageIndex, out _PageIndex)) _PageIndex = Convert.ToInt64(pageIndex);
            if (_PageIndex == 0) _PageIndex = 1;
            PageIndex = _PageIndex;
            if (_PageSize == null) _PageSize = 10;
            UseRewriter = _UseRewriter.Value;
            CUrl = _CUrl;
            StoreProcedure = _StoreProcedure;
            PageSize = _PageSize.Value;
            PagingSize = _PagingSize;
            ExecuteStore();
        }
        public Pager(string _StoreProcedure, string _Query, Int32? _PageSize, Int32 _PagingSize, bool? _UseRewriter, string _CUrl, SqlParameter[] obj)
        {
            if (string.IsNullOrEmpty(_Query)) _Query = "Index";
            Query = _Query;
            string pageIndex = HttpContext.Current.Request[Query];
            if (pageIndex == null) pageIndex = "0";
            Int64 _PageIndex = 0; ;
            if (Int64.TryParse(pageIndex, out _PageIndex)) _PageIndex = Convert.ToInt64(pageIndex);
            if (_PageIndex == 0) _PageIndex = 1;
            PageIndex = _PageIndex;
            if (_PageSize == null) _PageSize = 10;
            UseRewriter = _UseRewriter.Value;
            CUrl = _CUrl;
            StoreProcedure = _StoreProcedure;
            PageSize = _PageSize.Value;
            PagingSize = _PagingSize;
            ExecuteStore(obj);
        }
        public Pager(SqlConnection con, string _StoreProcedure, string _Query, Int32? _PageSize, Int32 _PagingSize, bool? _UseRewriter, string _CUrl, SqlParameter[] obj)
        {
            if (string.IsNullOrEmpty(_Query)) _Query = "Index";
            Query = _Query;
            string pageIndex = HttpContext.Current.Request[Query];
            if (pageIndex == null) pageIndex = "0";
            Int64 _PageIndex = 0; ;
            if (Int64.TryParse(pageIndex, out _PageIndex)) _PageIndex = Convert.ToInt64(pageIndex);
            if (_PageIndex == 0) _PageIndex = 1;
            PageIndex = _PageIndex;
            if (_PageSize == null) _PageSize = 10;
            UseRewriter = _UseRewriter.Value;
            CUrl = _CUrl;
            StoreProcedure = _StoreProcedure;
            PageSize = _PageSize.Value;
            PagingSize = _PagingSize;
            ExecuteStore(obj, con);
        }
        public Pager(SqlTransaction con, string _StoreProcedure, string _Query, Int32? _PageSize, Int32 _PagingSize, bool? _UseRewriter, string _CUrl, SqlParameter[] obj)
        {
            if (string.IsNullOrEmpty(_Query)) _Query = "Index";
            Query = _Query;
            string pageIndex = HttpContext.Current.Request[Query];
            if (pageIndex == null) pageIndex = "0";
            Int64 _PageIndex = 0; ;
            if (Int64.TryParse(pageIndex, out _PageIndex)) _PageIndex = Convert.ToInt64(pageIndex);
            if (_PageIndex == 0) _PageIndex = 1;
            PageIndex = _PageIndex;
            if (_PageSize == null) _PageSize = 10;
            UseRewriter = _UseRewriter.Value;
            CUrl = _CUrl;
            StoreProcedure = _StoreProcedure;
            PageSize = _PageSize.Value;
            PagingSize = _PagingSize;
            ExecuteStore(obj, con);
        }
    }
}
