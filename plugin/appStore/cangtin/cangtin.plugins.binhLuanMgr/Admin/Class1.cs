using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
[assembly: WebResource("cangtin.plugins.binhLuanMgr.Admin.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cangtin.plugins.binhLuanMgr.Admin.htm.htm", "text/html")]
namespace cangtin.plugins.binhLuanMgr.Admin
{
    public class Class1 : docPlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        void sendmailThongbao(string email, string tieude, string noidung)
        {
            omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "Cangtin Comment", "123$5678");
        }
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            var _ID = Request["ID"];
            string _q = Request["q"];

            var ID = Request["ID"];
            var DM_ID = Request["DM_ID"];
            var Ten = Request["Ten"];
            var Duyet = Request["Duyet"];
            var NoiDung = Request["NoiDung"];
            var P_RowId = Request["P_RowId"];
            var Url = Request["Url"];
            List<jgridRow> ListRow;
            #endregion

            var dele = new sendEmailDele(sendmailThongbao);
            var emailTemp = Lib.GetResource(Assembly.GetExecutingAssembly(), "Admin.email-comment-new.htm");
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "BL_NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    var pg = BinhLuanDal.pagerNormal(string.Empty, false, jgrsidx + " " + jgrsord, null, Convert.ToInt32(jgRows),
                                                     null, null);

                    ListRow=new List<jgridRow>();
                    foreach (var item in pg.List)
                    {
                        ListRow.Add(new jgridRow(
                            item.ID.ToString(), new string[]
                                                    {
                                                        item.ID.ToString(),
                                                        item._Member.Ten,
                                                        string.Format("<b>{0}</b><br/>{1}",item.Ten,item.NoiDung),
                                                        item.NgayTao.ToString("dd-MM-yy HH:mm"),                                                                                                                
                                                        item.Duyet.ToString(),
                                                        string.Format(@"<a href=""{0}#{1}"" target=""_blank"">>></a>",item.Url,item.ID )
                                                    }
                            ));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pg.TotalPages.ToString(), pg.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(BinhLuanDal.SelectById(new Guid(ID))));
                    }
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        BinhLuanDal.DeleteMultiById(ID);
                    }
                    break;
                    #endregion                                
                case "duyet":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        BinhLuanDal.DuyetMultiById(ID, Duyet == "1");
                    }
                    break;
                    #endregion                                
                case "save":
                    #region lưu

                    var Item = string.IsNullOrEmpty(ID) ? new BinhLuan() : BinhLuanDal.SelectById(new Guid(ID));
                    if (!string.IsNullOrEmpty(Duyet))
                    {
                        Item.Duyet = Convert.ToBoolean(Duyet);
                    }
                    Item.NoiDung = NoiDung;
                    Item.Ten = Ten;
                    if (!string.IsNullOrEmpty(P_RowId))
                    {
                        Item.P_RowId = new Guid(P_RowId);
                    }
                    Item.Url = Url;
                    if(!string.IsNullOrEmpty(ID))
                    {
                        Item = BinhLuanDal.Update(Item);
                    }
                    else
                    {
                        Item.ID = Guid.NewGuid();
                        Item.NgayTao = DateTime.Now;
                        Item.NguoiTao = Security.Username;
                        dele.BeginInvoke("danhbaspa@gmail.com", "Cangtin comment new " + Security.Username
                                         , string.Format(emailTemp, Security.Username
                                                         , Request.UserHostAddress
                                                         , DateTime.Now.ToString("HH:mm dd/MM/yyyy")
                                                         , Item.Ten
                                                         , Item.Url
                                                         , Item.NoiDung), null, null);
                        Item = BinhLuanDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cangtin.plugins.binhLuanMgr.Admin.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "Admin.mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cangtin.plugins.binhLuanMgr.Admin.JScript1.js")
                        , "{binhLuanMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
