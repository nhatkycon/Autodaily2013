using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using linh;
using linh.frm;
using linh.json;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.common;
[assembly: WebResource("docsoft.plugin.loaidanhmuc.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.loaidanhmuc.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace docsoft.plugin.loaidanhmuc
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _Ten = Request["Ten"];
            string _Ma = Request["Ma"];
            string _KyHieu = Request["KyHieu"];
            string _ThuTu = Request["STT"];
            string _q = Request["q"];
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    var listRow = LoaiDanhMucDal.SelectAll().Select(ldm => new jgridRow(ldm.ID.ToString(), new string[]
                                                                                                               {
                                                                                                                   ldm.ID.ToString(), ldm.ThuTu.ToString(), ldm.Ma, ldm.KyHieu, ldm.Ten, string.Format("{0:dd/MM/yy}", ldm.NgayCapNhat), ldm.NguoiTao + "/" + ldm.NguoiSua
                                                                                                               })).ToList();
                    var grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "0", "0", listRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getAll":
                    #region lấy toàn bộ loai danh mục                    
                    var listGetPid = LoaiDanhMucDal.SelectAll();
                    listGetPid.Add(new LoaiDanhMuc(){Ten = "Chọn"});
                    sb.Append(JavaScriptConvert.SerializeObject(listGetPid));
                    break;
                    #endregion
                case "save":
                    #region lưu
                    var ItemSave = new LoaiDanhMuc();
                    if (string.IsNullOrEmpty(_Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = LoaiDanhMucDal.SelectById(new Guid(_ID));
                    }                    
                    ItemSave.Ten = _Ten;
                    ItemSave.Ma = _Ma;
                    ItemSave.KyHieu = _KyHieu;
                    ItemSave.ThuTu = Int32.Parse(_ThuTu);
                    ItemSave.NgayCapNhat = DateTime.Now;
                    ItemSave.NguoiTao = Security.Username;
                    ItemSave.NguoiSua = Security.Username;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = LoaiDanhMucDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave.ID = Guid.NewGuid();
                        ItemSave = LoaiDanhMucDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion               
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(LoaiDanhMucDal.SelectById(new Guid(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        LoaiDanhMucDal.DeleteById(new Guid(_ID));
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.loaidanhmuc.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.loaidanhmuc.JScript1.js")
                        , "{loaidanhmuc.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn)); 
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
