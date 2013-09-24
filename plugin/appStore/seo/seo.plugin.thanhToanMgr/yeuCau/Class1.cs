using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh;
using linh.frm;
using linh.json;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.common;
using seo.entities;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using System.Globalization;
[assembly: WebResource("seo.plugin.thanhToanMgr.yeuCau.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("seo.plugin.thanhToanMgr.yeuCau.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace seo.plugin.thanhToanMgr.yeuCau
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _Duyet = Request["Duyet"];
            string _Khoa = Request["Khoa"];
            string _q = Request["q"];
            List<jgridRow> ListRow = new List<jgridRow>();
            ThanhToan Item;
            string Username = Security.Username;
            bool logged = Security.IsAuthenticated();
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<ThanhToan> PagerGet = ThanhToanDal.pagerYeuCau("T_" + jgrsidx + " " + jgrsord, Convert.ToInt32(jgRows));
                    foreach (ThanhToan item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), 
                            new string[] { 
                            item.ID.ToString(),
                            item.NguoiYeuCau,
                            item.SoDu.ToString("C",new CultureInfo("vi-Vn")),
                            item.NgayTao.ToString("hh:mm dd/MM/yy")
                            }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "duyet":
                    #region duyet
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        using (SqlConnection con = DAL.con())
                        {
                            con.Open();
                            SqlTransaction tran = con.BeginTransaction();
                            try
                            {
                                bool Khoa = Convert.ToBoolean(_Khoa);
                                double total;
                                TaiKhoan tkItem;
                                foreach (string item in _ID.Split(new char[] { ',' }))
                                {
                                    if (item.Length > 0)
                                    {
                                        total = 0;
                                        Item = ThanhToanDal.SelectById(Convert.ToInt32(item), tran);
                                        tkItem = TaiKhoanDal.SelectByUsername(Item.NguoiYeuCau, tran);
                                        if (!string.IsNullOrEmpty(tkItem.Tk))
                                        {
                                            total = Convert.ToDouble(maHoa.DecryptString(tkItem.Tk, tkItem.Username));
                                        }
                                        if (Khoa)
                                        {
                                            if (!Item.Duyet)
                                            {
                                                total = total - Convert.ToDouble(Item.SoDu);
                                            }
                                        }
                                        ThanhToanDal.Duyet(item, _Khoa, tran);
                                        TaiKhoanDal.UpdateTk(tkItem.ID, maHoa.EncryptString(total.ToString(), Item.NguoiYeuCau), tran);
                                    }
                                   
                                }
                                tran.Commit();
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();
                                sb.Append(ex.ToString());
                            }
                            finally
                            {
                                con.Close();
                            }
                        }                        
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "seo.plugin.thanhToanMgr.yeuCau.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    if (!logged)
                    {
                        renderText("un-authorized", "text/plain");
                    }
                   
                    sb.Append(@"
<div class=""mdl-head"">
    <a class=""mdl-head-btn mdl-head-del"" id=""ThanhToanMgryeuCau-yeuCauBtn"" href=""javascript:;"" onclick=""ThanhToanMgryeuCauFn.duyet(true);"">Duyệt</a>    
</div>
<table id=""ThanhToanMgryeuCau-List"" class=""mdl-list""></table>
<div id=""ThanhToanMgryeuCau-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "seo.plugin.thanhToanMgr.yeuCau.JScript1.js")
                        , "{ThanhToanMgryeuCauFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn)); 
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
