using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using pmSpa.entities;

[assembly: WebResource("appStore.pmSpa.ketQuaMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.ketQuaMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.pmSpa.ketQuaMgr
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số

            var ID = Request["ID"];
            var DV_ID = Request["DV_ID"];
            var TT_ID = Request["TT_ID"];
            var DM_ID = Request["DM_ID"];
            var KH_ID = Request["KH_ID"];
            var Ten = Request["Ten"];
            var MoTa = Request["MoTa"];
            var Anh = Request["Anh"];
            var NoiDung = Request["NoiDung"];
            var NgayTao = Request["NgayTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiTao = Request["NguoiTao"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var ThuTu = Request["ThuTu"];
            var Active = Request["Active"];

            string q = Request["q"];
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    var pg = KetQuaDal.pagerNormal(string.Empty, false, jgrsidx + " " + jgrsord, q,  Convert.ToInt32(jgRows));

                    var listRow = pg.List.Select(item => new jgridRow(item.ID.ToString(), new string[]
                                                                                                               {
                                                                                                                   item.ID.ToString(), item.TT_Ten, item.KH_Ten, item.Ten, item.MoTa, item.Active.ToString()
                                                                                                               })).ToList();
                    var grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "0", "0", listRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "autoCompleteByQ":
                    #region lấy dữ liệu cho autoCompleteByQ
                    var autoCompleteByQ = KetQuaDal.pagerNormal(string.Empty, false, jgrsidx + " " + jgrsord, q, Convert.ToInt32(jgRows));
                    sb.Append(JavaScriptConvert.SerializeObject(autoCompleteByQ.List));
                    break;
                    #endregion                
                case "save":
                    #region lưu
                    var itemSave = !string.IsNullOrEmpty(ID) ? KetQuaDal.SelectById(new Guid(ID)) : new KetQua();
                    
                    if (string.IsNullOrEmpty(Ten))
                    {
                        sb.Append("0");
                        break;
                    }

                    itemSave.Active = Convert.ToBoolean(Active);
                    itemSave.Anh = Anh;
                    if (!string.IsNullOrEmpty(TT_ID))
                    {
                        itemSave.TT_ID = new Guid(TT_ID);
                    }
                    if (!string.IsNullOrEmpty(KH_ID))
                    {
                        itemSave.KH_ID = new Guid(KH_ID);
                    }
                    itemSave.ThuTu = Convert.ToInt32(ThuTu);
                    itemSave.Ten = Ten;
                    itemSave.MoTa = MoTa;
                    itemSave.NgayCapNhat = DateTime.Now;
                    itemSave.NguoiCapNhat = Security.Username;
                    itemSave.NoiDung = NoiDung;
                    itemSave.Ten = Ten;
                    if (!string.IsNullOrEmpty(ID))
                    {
                        itemSave = KetQuaDal.Update(itemSave);
                    }
                    else
                    {
                        itemSave.NgayTao = DateTime.Now;
                        itemSave.NguoiTao = Security.Username;
                        itemSave.NgayTao = DateTime.Now;
                        itemSave.NguoiCapNhat = Security.Username;
                        itemSave = KetQuaDal.Insert(itemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(KetQuaDal.SelectById(new Guid(ID))));
                    }
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        KetQuaDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.ketQuaMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.ketQuaMgr.JScript1.js")
                        , "{ketQuaMgr.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
