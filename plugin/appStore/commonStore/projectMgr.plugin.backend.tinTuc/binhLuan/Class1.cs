using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using linh;
using linh.frm;
using linh.json;
using linh.common;
using linh.controls;
using docsoft;
using docsoft.entities;
using System.Xml;
using System.Globalization;
using System.IO;
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.binhLuan.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.binhLuan.htm.htm", "text/html")]
namespace projectMgr.plugin.backend.tinTuc.binhLuan
{
    public class Class1 : docPlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        void sendmailThongbao(string email, string tieude, string noidung)
        {
            omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "Milan", "123$5678");
        }
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;

            HttpContext c = HttpContext.Current;

            var ID = c.Request["ID"];
            var PID = c.Request["PID"];
            var C_ID = c.Request["C_ID"];
            var KH_Ten = c.Request["KH_Ten"];
            var KH_Email = c.Request["KH_Email"];
            var KH_Mobile = c.Request["KH_Mobile"];
            var NoiDung = c.Request["NoiDung"];
            var NgayTao = c.Request["NgayTao"];
            var Active = c.Request["Active"];
            var Readed = c.Request["Readed"];
            var Ten = c.Request["Ten"];
            var MoTa = c.Request["MoTa"];
            var Anh = c.Request["Anh"];


            var _q = Request["q"];
            List<jgridRow> ListRow;
            #endregion
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    Pager<Comment> PagerGet = CommentDal.pagerNormal(_q, jgRows);
                    ListRow = new List<jgridRow>();
                    foreach (Comment item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,item.KH_Ten
                            ,item.KH_Email
                            ,item.KH_Mobile
                            ,string.Format(@"<span class=""{1}{2}"">{0}</span>",item.Ten,item.Readed ? "" : "comment-bold", item.Active ? " comment-active" : "")
                            ,item.PID == 0 ? "" : string.Format(@"<a href=""javascript:;"" target=""_blank"">xem</a>", item.PID)
                            ,item.NgayTao.ToString("dd/MM/yy HH:mm")
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    //jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "add":
                    #region thêm mới
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    Comment itemGetVanBan = CommentDal.SelectById(Convert.ToInt32(ID));
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemGetVanBan));
                    break;
                    #endregion
                case "send":
                    #region chỉnh sửa
                    Comment itemSend = CommentDal.SelectById(Convert.ToInt32(ID));
                    itemSend.Active = true;
                    CommentDal.Update(itemSend);

                    _dele.BeginInvoke(itemSend.KH_Email
                            , string.Format("Milan Clinic & Spa - MilanSpa.vn: Tra loi  {0}", DateTime.Now.ToString("hh:mm-dd/MM/yy"))
                            , string.Format("{0}<hr/>{1}", NoiDung
                            , itemSend.PID == 0 ? "" : string.Format(@"Quý khách vui lòng <a href=""http://milanspa.vn/lib/pages/TinTuc_Tin_ChiTiet.aspx?ID={1}"">xem bình luận</a>", domain, itemSend.PID))
                            , null, null);

                    _dele.BeginInvoke("danhbaspa@gmail.com"
                            , string.Format("Milan Clinic & Spa - MilanSpa.vn: Tra loi  {0}", DateTime.Now.ToString("hh:mm-dd/MM/yy"))
                            , string.Format("{0}<hr/>{1}", NoiDung
                            , itemSend.PID == 0 ? "" : string.Format(@"Quý khách vui lòng <a href=""http://milanspa.vn/lib/pages/TinTuc_Tin_ChiTiet.aspx?ID={1}"">xem bình luận</a>", domain, itemSend.PID))
                            , null, null);
                    itemSend.KH_Ten = "Milan Clinic & Spa";
                    itemSend.KH_Mobile = "";
                    itemSend.NoiDung = NoiDung;
                    itemSend.Active = true;
                    if (string.IsNullOrEmpty(C_ID))
                        C_ID = "0";
                    itemSend.C_ID = Convert.ToInt32(C_ID);
                    CommentDal.Insert(itemSend);
                    break;
                    #endregion
                case "save":
                    #region chỉnh sửa

                    Comment itemSend1 = !string.IsNullOrEmpty(ID) ? CommentDal.SelectById(Convert.ToInt32(ID)) : new Comment();
                    itemSend1.KH_Ten = KH_Ten;
                    itemSend1.KH_Mobile = KH_Mobile;
                    itemSend1.KH_Email = KH_Email;
                    itemSend1.NoiDung = NoiDung;
                    itemSend1.Ten = Ten;
                    itemSend1.MoTa = MoTa;
                    itemSend1.Active = Convert.ToBoolean(Active);
                    itemSend1.Anh = Anh;
                    if (string.IsNullOrEmpty(ID))
                    {
                        itemSend1.NgayTao = DateTime.Now;                        
                        CommentDal.Insert(itemSend1);
                    }
                    else
                    {
                        CommentDal.Update(itemSend1);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        CommentDal.DeleteById(Convert.ToInt32(ID));
                    }
                    break;
                    #endregion
                case "readed":
                    #region readed
                    if (!string.IsNullOrEmpty(ID))
                    {
                        CommentDal.ReadedById(Convert.ToInt32(ID));
                    }
                    break;
                    #endregion
                case "duyet":
                    #region Duyệt tin hàng loạt
                    Tin ItemDuyet = new Tin();
                    if (!string.IsNullOrEmpty(ID))
                    {
                        CommentDal.ActiveById(ID);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.binhLuan.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-dbBlMdl-search-tin"" />
</span>
    <a class=""mdl-head-btn mdl-head-del"" id=""dbtinmdl-addBtn"" href=""javascript:dbBlfn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-add"" id=""tinmdlDuyetTin-addBtn"" href=""javascript:dbBlfn.duyet('true');"">Duyệt</a>
    <a class=""mdl-head-btn mdl-head-add"" id=""tinmdlDuyetTin-addBtn"" href=""javascript:dbBlfn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-add"" id=""tinmdlDuyetTin-addBtn"" href=""javascript:dbBlfn.rep();"">Trả lời</a>
</div>
<table id=""dbBlMdl-List"" class=""mdl-list""></table>
<div id=""dbBlMdl-Pagerql""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.binhLuan.JScript1.js")
                        , "{dbBlfn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
