using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.frm;
using linh.common;
using System.Reflection;
using linh.json;
using pmSpa.entities;
using System.Globalization;
using Microsoft.Reporting.WebForms;
using System.IO;

[assembly: WebResource("appStore.pmSpa.desktop.controls.AlbumMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.AlbumMgr.mdl.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.AlbumMgr.htm.htm", "text/html", PerformSubstitution = true)]

namespace appStore.pmSpa.desktop.controls.AlbumMgr
{
    public class DanhSach : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con(), this.Page);
            writer.Write(Html);
            base.Render(writer);
        }

        public override void KhoiTao(SqlConnection con, Page page)
        {
            var sb = new StringBuilder();
            var cs = page.ClientScript;
            var c = HttpContext.Current;
            #region bien
            var ID = c.Request["ID"];
            var SPA_ID = c.Request["SPA_ID"];
            var Ma = c.Request["Ma"];
            var P_RowId = c.Request["P_RowId"];
            var Ten = c.Request["Ten"];
            var Anh = c.Request["Anh"];
            var MoTa = c.Request["MoTa"];
            var ThuTu = c.Request["ThuTu"];
            var TongSoAnh = c.Request["TongSoAnh"];
            var Active = c.Request["Active"];
            var NguoiTao = c.Request["NguoiTao"];
            var NgayTao = c.Request["NgayTao"];
            var MacDinh = c.Request["MacDinh"];
            var draff = c.Request["draff"];
            var _F_ID = c.Request["F_ID"];
            var ListRow = new List<jgridRow>();
            #endregion
            switch (subAct)
            {
                case "get":
                    #region Nạp list
                    sb.Append(JavaScriptConvert.SerializeObject(AlbumDal.SelectAll(con)));
                    break;
                    #endregion
                case "getGrid":
                    #region Nạp grid
                    var list = AlbumDal.SelectByPid(con, P_RowId);
                    foreach (Album item in list)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.Ma
                            , item.Ten
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                        }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , "1"
                        , list.Count.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                    #endregion
                case "draff":
                    #region Nạp draff
                    sb.Append(Guid.NewGuid().ToString());
                    break;
                    #endregion
                case "del":
                    #region Delete
                    if (!string.IsNullOrEmpty(ID))
                    {
                        AlbumDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region edit
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var abItem=AlbumDal.SelectById(new Guid(ID));
                        abItem.ListFiles = FilesDal.SelectByPRowId(abItem.ID);
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(abItem));

                    }
                    break;
                    #endregion
                case "save":
                    #region save
                    if (!string.IsNullOrEmpty(Ten))
                    {
                        var item = draff == "1" ? new Album() : AlbumDal.SelectById(new Guid(ID));
                        item.AnhDaiDien = Anh;
                        item.Ma = Ma;
                        item.MoTa = MoTa;
                        item.Ten = Ten;
                        item.ThuTu = Convert.ToInt32(ThuTu);
                        if (!string.IsNullOrEmpty(P_RowId))
                        {
                            item.P_RowId = new Guid(P_RowId);
                        }
                        if (draff == "1")
                        {
                            item.ID = new Guid(ID);
                            item.NgayTao = DateTime.Now;
                            item.NguoiTao = Security.Username;
                            item = AlbumDal.Insert(item);
                        }
                        else
                        {
                            item = AlbumDal.Update(item);
                        }
                        item.ListFiles = FilesDal.SelectByPRowId(item.ID);
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(item));
                    }
                    break;
                    #endregion
                case "DeleteDoc":
                    #region Xóa tài liệu đính kèm
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        
                        try
                        {
                            string _files = c.Server.MapPath("~/lib/up/sanpham/") + item.ThuMuc + @"\";
                            string _file1 = _files + @"\" + item.Ten + item.MimeType;
                            string _file2 = _files + @"\" + item.Ten + "400x400" + item.MimeType;
                            string _file3 = _files + @"\" + item.Ten + "full" + item.MimeType;
                            if (Directory.Exists(_files))
                            {
                                File.Delete(_file1);
                                File.Delete(_file2);
                                File.Delete(_file3);
                                Directory.Delete(_files);
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        FilesDal.DeleteById(item.ID);
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(DanhSach), "appStore.pmSpa.desktop.controls.AlbumMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    sb.AppendFormat(Lib.GetResource(Assembly.GetExecutingAssembly(), "AlbumMgr.Body.htm"), domain);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "AlbumMgr.mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(DanhSach), "appStore.pmSpa.desktop.controls.AlbumMgr.JScript1.js")
                        , "{AlbumMgrFn.getAlbum();}");
                    break;
                    #endregion
            }

            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }
}
