using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Reporting.WebForms;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using System.IO;

[assembly: WebResource("appStore.commonStore.hangHoaMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.hangHoaMgr.DangKySanPhamDacTrung.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.hangHoaMgr.DangKySanPhamMenu.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.hangHoaMgr.DuyetSPDT.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.commonStore.hangHoaMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.hangHoaMgr
{
    
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số
            var ID = Request["ID"];
            var DM_ID = Request["DM_ID"];
            var GH_ID = Request["GH_ID"];
            var Lang = Request["Lang"];
            var LangBased_ID = Request["LangBased_ID"];
            var LangBased = Request["LangBased"];
            var Alias = Request["Alias"];
            var Ten = Request["Ten"];
            var Ma = Request["Ma"];
            var Keywords = Request["Keywords"];
            var Description = Request["Description"];
            var MoTa = Request["MoTa"];
            var NoiDung = Request["NoiDung"];
            var GNY = Request["GNY"];
            var GiaNhap = Request["GiaNhap"];
            var DonVi_ID = Request["DonVi_ID"];
            var SoLuong = Request["SoLuong"];
            var RowId = Request["RowId"];
            var NgayTao = Request["NgayTao"];
            var NguoiTao = Request["NguoiTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var Anh = Request["Anh"];
            var Publish = Request["Publish"];
            var Active = Request["Active"];
            var Home = Request["Home"];
            var Hot1 = Request["Hot1"];
            var Hot2 = Request["Hot2"];
            var Hot3 = Request["Hot3"];
            var Hot4 = Request["Hot4"];
            var HetHang = Request["HetHang"];
            var TonDinhMuc = Request["TonDinhMuc"];
            var Draff = Request["Draff"];
            var _q = Request["q"];
            var draff = Request["draff"];
            var Loai = Request["Loai"];
            var Rep_Ten = Request["Rep_Ten"];
            var Rep_Ngay = Request["Rep_Ngay"];
            var _F_ID = Request["F_ID"];
            List<jgridRow> ListRow = new List<jgridRow>();

            //List<DanhMuc> ListDanhMucBG = new List<DanhMuc>();
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    var pagerGet = HangHoaDal.ByDm("", false, jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), DM_ID);
                    foreach (HangHoa item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.DM_Ten
                            , item.Ma
                            , item.Ten
                            , Lib.TienVietNam(item.GiaNhap)
                            , Lib.TienVietNam(item.GNY)
                            , item.SoLuong.ToString()
                            , item.DonVi_Ten
                            , string.Format("{0:dd/MM/yy}",item.NgayCapNhat)
                        }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , pagerGet.TotalPages.ToString()
                        , pagerGet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        HangHoaDal.DeleteByMultiId(ID);
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var hhitem = HangHoaDal.SelectById(new Guid(ID));
                        hhitem.ListFiles = FilesDal.SelectByPRowId(hhitem.ID);
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(hhitem));
                    }
                    break;
                    #endregion
                case "draff":
                    #region draff
                    sb.Append(Guid.NewGuid().ToString());
                    break;
                    #endregion
                case "autoCompleteByQ":
                    #region lấy dữ liệu cho grid
                    var pagerByQ = HangHoaDal.ByDm("", false, "HH_NgayTao asc", _q, 10, string.Empty);
                    sb.Append(JavaScriptConvert.SerializeObject(pagerByQ.List));
                    break;
                    #endregion
                case "save":
                    #region save
                    if (Security.IsAuthenticated())
                    {
                        var item = draff == "1" ? new HangHoa() : HangHoaDal.SelectById(new Guid(ID));
                        item.DM_ID = new Guid(DM_ID);
                        item.Ten = Ten;
                        item.Ma = Ma;
                        item.Keywords = Keywords;
                        item.MoTa = MoTa;
                        item.NoiDung = NoiDung;
                        item.GNY = Convert.ToDouble(GNY);
                        item.GiaNhap = Convert.ToDouble(GiaNhap);
                        item.DonVi_ID = new Guid(DonVi_ID);
                        item.SoLuong = Convert.ToDouble(SoLuong);
                        item.Anh = Anh;
                        item.HetHang = Convert.ToBoolean(HetHang);
                        item.TonDinhMuc = Convert.ToDouble(TonDinhMuc);
                        item.NguoiCapNhat = Security.Username;
                        item.NgayCapNhat = DateTime.Now;
                        if (draff == "1")
                        {
                            item.ID = new Guid(ID);
                            item.NgayTao = DateTime.Now;
                            item.NguoiTao = Security.Username;                            
                            item.RowId = Guid.NewGuid();
                            item = HangHoaDal.Insert(item);
                        }
                        else
                        {
                            item = HangHoaDal.Update(item);
                        }
                        sb.Append("1");
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
                        try
                        {
                            if (Directory.Exists(_files))
                            {
                                File.Delete(_file1);
                                File.Delete(_file2);
                                Directory.Delete(_files);
                            }
                        }
                        catch
                        {
                            
                        }
                        FilesDal.DeleteById(item.ID);
                        
                    }
                    break;
                    #endregion
                case "reports":
                    #region bao cao
                    var pagerGetReport = HangHoaDal.ByDm("", false, jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), DM_ID);

                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.hangHoaMgr.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.hangHoaMgr.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "appStore.commonStore.hangHoaMgr.JScript1.js")
                        , "{hangHoaMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }

    }
}


