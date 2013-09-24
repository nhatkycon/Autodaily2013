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
    public class View : docPlugUI
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
            var ID = c.Request["VID"];
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
            #endregion
            switch (subAct)
            {
                case "get":
                    #region Nạp js
                    sb.Append(JavaScriptConvert.SerializeObject(AlbumDal.SelectAll(con)));
                    break;
                    #endregion
                case "draff":
                    #region Nạp draff
                    sb.Append(Guid.NewGuid().ToString());
                    break;
                    #endregion
                case "save":
                    #region save
                    if (Security.IsAuthenticated())
                    {
                        var item = draff == "1" ? new Album() : AlbumDal.SelectById(new Guid(ID));
                        item.AnhDaiDien = Anh;
                        item.Ma = Ma;
                        item.MoTa = MoTa;
                        item.Ten = Ten;
                        item.ThuTu = Convert.ToInt32(ThuTu);
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
                    }
                    break;
                    #endregion
                case "DeleteDoc":
                    #region Xóa tài liệu đính kèm
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        string _files = Server.MapPath("~/lib/up/sanpham/") + item.ThuMuc + @"\";
                        string _file1 = _files + @"\" + item.Ten + item.MimeType;
                        string _file2 = _files + @"\" + item.Ten + "400x400" + item.MimeType;
                        if (Directory.Exists(_files))
                        {
                            File.Delete(_file1);
                            File.Delete(_file2);
                            Directory.Delete(_files);
                        }
                        FilesDal.DeleteById(item.ID);
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(View), "appStore.pmSpa.desktop.controls.AlbumMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var itemformat = Lib.GetResource(Assembly.GetExecutingAssembly(), "AlbumMgr.anh-item.htm");
                    var bodyformat = Lib.GetResource(Assembly.GetExecutingAssembly(), "AlbumMgr.view.htm");
                    var anhFsFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "AlbumMgr.anh-dich-vu-full.htm");

                    var sbItem = new StringBuilder();
                    var sbAnhFs = new StringBuilder();
                    var slideIndex = 0;
                    foreach (var anh in FilesDal.SelectByPRowId(new Guid(ID)))
                    {
                        sbItem.AppendFormat(itemformat
                            , domain
                            , Lib.imgSize(anh.Path, "full")
                            , anh.ID
                            , anh.ThuMuc
                            , Lib.imgSize(anh.Path, "400x400"));
                        sbAnhFs.AppendFormat(anhFsFormat, slideIndex == 0 ? "block" : "none", domain, Lib.imgSize(anh.Path, "full"), anh.ThuMuc);
                        slideIndex++;
                    }
                    sb.AppendFormat(bodyformat, domain, sbItem, sbAnhFs, ID);
                    sb.Append(@"<script>
        
    $(function() {
        $('.anh-view-item').each(function (i) {
            var item = $(this);
            item.click(function() {
                $('.dv-fs-box').show();
                $('.dv-fs-closeBtn').unbind('click').click(function() {
                    $('.dv-fs-box').hide();
                });
                if(!dichVuDsSlidesInitial) {
                    dichVuFsSlide = new Swipe(document.getElementById('dv-fs-body'));
                    dichVuDsSlidesInitial = true;
                }
            });
        });
    });
</script>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(View), "appStore.pmSpa.desktop.controls.AlbumMgr.JScript1.js")
                        , "{AlbumMgrFn.ViewAllbum('" + AlbumDal.SelectById(new Guid(ID)).Ten + "');}");
                    break;
                    #endregion
            }

            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }
}
