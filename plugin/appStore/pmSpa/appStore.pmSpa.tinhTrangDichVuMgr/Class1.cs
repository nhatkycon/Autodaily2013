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

[assembly: WebResource("appStore.pmSpa.tinhTrangDichVuMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.tinhTrangDichVuMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace appStore.pmSpa.tinhTrangDichVuMgr
{
    public class Class1: docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số
            var ID = Request["ID"];
            var DM_ID = Request["DM_ID"];
            var DM_Ten = Request["DM_Ten"];
            var DV_ID = Request["DV_ID"];
            var DV_Ten = Request["DV_Ten"];
            var SoLuong = Request["SoLuong"];
            var ThuTu = Request["ThuTu"];
            var MoTa = Request["MoTa"];

            string q = Request["q"];
            #endregion
            switch (subAct)
            {
                case "getSub":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    var listSub = TinhTrangDichVuDal.SelectDmId(DM_ID);

                    var listRowSub = listSub.Select(item => new jgridRow(item.ID.ToString(), new string[]
                                                                                                               {
                                                                                                                   item.ID.ToString(), 
                                                                                                                   item.ThuTu.ToString(),  
                                                                                                                   item.DV_Ten, 
                                                                                                                   item.SoLuong.ToString()
                                                                                                               })).ToList();
                    var gridSub = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "0", "0", listRowSub);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSub));
                    break;
                    #endregion
                case "saveSub":
                    #region lưu
                    var itemSub = new TinhTrangDichVu();
                    if (!string.IsNullOrEmpty(ID))
                    {
                        itemSub = TinhTrangDichVuDal.SelectById(new Guid(ID));
                    }
                    else
                    {
                        itemSub.ID = Guid.NewGuid();
                    }
                    if (!string.IsNullOrEmpty(DM_ID))
                    {
                        itemSub.DM_ID = new Guid(DM_ID);
                    }
                    if (!string.IsNullOrEmpty(DV_ID))
                    {
                        itemSub.DV_ID = new Guid(DV_ID);
                    }
                    itemSub.SoLuong = Convert.ToInt32(SoLuong);
                    itemSub.NgayCapNhat = DateTime.Now;
                    itemSub.NguoiCapNhat = Security.Username;
                    itemSub.ThuTu = Convert.ToInt32(ThuTu);
                    if (!string.IsNullOrEmpty(ID))
                    {
                        itemSub = TinhTrangDichVuDal.Update(itemSub);
                    }
                    else
                    {
                        itemSub.NgayTao = DateTime.Now;
                        itemSub.NguoiTao = Security.Username;
                        itemSub = TinhTrangDichVuDal.Insert(itemSub);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "editSub":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(TinhTrangDichVuDal.SelectById(new Guid(ID))));
                    }
                    break;
                    #endregion
                case "delSub":
                    #region xóa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        TinhTrangDichVuDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "getByDmId":
                    #region lấy dữ liệu cho grid
                    sb.Append(JavaScriptConvert.SerializeObject(TinhTrangDichVuDal.SelectDmId(DM_ID)));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.tinhTrangDichVuMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.pmSpa.tinhTrangDichVuMgr.JScript1.js")
                        , "{tinhTrangDichVuMgr.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
