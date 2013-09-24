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
[assembly: WebResource("appStore.pmSpa.desktop.controls.KHang.DangKy.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.KHang.TuVan.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.KHang.TuVan-In.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.KHang.Print.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("appStore.pmSpa.desktop.controls.KHang.start-up.png", "image/png")]
namespace appStore.pmSpa.desktop.controls.KHang
{
    public class DangKy : docPlugUI
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
            var ID = Request["ID"];
            var TT_ID = Request["TT_ID"];
            var DV_ID = Request["DV_ID"];
            var Ma = Request["Ma"];
            var So = Request["So"];
            var KH_ID = Request["KH_ID"];
            var TuVanVien = Request["TuVanVien"];
            var Ngay = Request["Ngay"];
            var NgayTao = Request["NgayTao"];
            var NguoiTao = Request["NguoiTao"];
            var NgayCapNhat = Request["NgayCapNhat"];
            var NguoiCapNhat = Request["NguoiCapNhat"];
            var TinhTrangSucKhoe = Request["TinhTrangSucKhoe"];
            var TinhTrangLanDa = Request["TinhTrangLanDa"];
            var GhiChu = Request["GhiChu"];
            var YKienKhachHang = Request["YKienKhachHang"];
            var HieuQua = Request["HieuQua"];
            var PDV_ID = Request["PDV_ID"];
            var TuVanVienDanhGia = Request["TuVanVienDanhGia"];
            var KhongTheoDoi = Request["KhongTheoDoi"];
            var DichVuDieuTriKhac = Request["DichVuDieuTriKhac"];
            var KH_NguoiGioiThieu = Request["KH_NguoiGioiThieu"];

            var KH_Ma = Request["KH_Ma"];
            var Anh = Request["Anh"];
            var KH_Ten = Request["KH_Ten"];
            var KH_GioiTinh = Request["KH_GioiTinh"];
            var KH_NgaySinh = Request["KH_NgaySinh"];
            var KH_DiaChi = Request["KH_DiaChi"];
            var KH_KhuVuc_ID = Request["KH_KhuVuc_ID"];
            var KH_Phone = Request["KH_Phone"];
            var KH_Mobile = Request["KH_Mobile"];
            var KH_Ym = Request["KH_Ym"];
            var KH_CMND = Request["KH_CMND"];
            var KH_Email = Request["KH_Email"];
            var KH_NguonGoc_ID = Request["KH_NguonGoc_ID"];
            var LinhVuc_ID = Request["LinhVuc_ID"];
            #endregion
            switch (subAct)
            {
                case "draff":
                    #region draff
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(KhachHangDal.SelectDraff(con)));                    
                    break;
                    #endregion
                case "draffTuVan":
                    #region draffTuVan
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(TuVanDal.SelectDraff(con)));
                    break;
                    #endregion
                case "addTinhTrang":
                    #region addTinhTrang
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var itemTuVanTinhTrang = TuVanTinhTrangDal.Insert(new TuVanTinhTrang()
                                                                            {
                                                                                ID = Guid.NewGuid()
                                                                                ,
                                                                                NgayTao = DateTime.Now
                                                                                ,
                                                                                TT_ID = new Guid(TT_ID)
                                                                                ,
                                                                                ThuTu = 0
                                                                                ,
                                                                                TV_ID = new Guid(ID)
                                                                            });
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemTuVanTinhTrang));
                    }
                    
                    break;
                    #endregion
                case "delTinhTrang":
                    #region delTinhTrang
                    TuVanTinhTrangDal.DeleteById(new Guid(TT_ID));
                    break;
                    #endregion
                case "delDichVu":
                    #region delDichVu
                    RelationDal.DeleteByCidPid(DV_ID, ID);
                    break;
                    #endregion
                case "getAlbum":
                    #region getAlbum
                    var slideIndex = 0;
                    var anhFsFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "AlbumMgr.anh-dich-vu-full.htm");
                    foreach (var anh in FilesDal.SelectByPRowId(new Guid(ID)))
                    {
                        sb.AppendFormat(anhFsFormat, slideIndex == 0 ? "block" : "none", domain, Lib.imgSize(anh.Path, "full"), anh.ThuMuc);
                        slideIndex++;
                    }
                    break;
                    #endregion
                case "save":
                    #region save
                    if(!string.IsNullOrEmpty(KH_Ten))
                    {
                        var khItem = new KhachHang();
                        khItem.CMND = KH_CMND;
                        khItem.DanhGia = 0;
                        khItem.DiaChi = KH_DiaChi;
                        khItem.Email = KH_Email;
                        khItem.FacebookUid = string.Empty;
                        khItem.GioiTinh = Convert.ToBoolean(KH_GioiTinh);
                        if (!string.IsNullOrEmpty(KH_KhuVuc_ID))
                        {
                            khItem.KhuVuc_ID = new Guid(KH_KhuVuc_ID);
                        }
                        khItem.ID = Guid.NewGuid();
                        khItem.Ma = KH_Ma;
                        khItem.Mobile = KH_Mobile;
                        khItem.NgayCapNhat = DateTime.Now;
                        khItem.NgaySinh = Convert.ToDateTime(KH_NgaySinh, new CultureInfo("vi-Vn"));
                        khItem.NguoiCapNhat = Security.Username;
                        khItem.NguoiTao = Security.Username;
                        if (!string.IsNullOrEmpty(LinhVuc_ID))
                        {
                            khItem.LinhVuc_ID = new Guid(LinhVuc_ID);
                        }
                        khItem.TuVanVien = TuVanVien;
                        if (!string.IsNullOrEmpty(KH_NguonGoc_ID))
                        {
                            khItem.NguonGoc_ID = new Guid(KH_NguonGoc_ID);
                        }
                        if (!string.IsNullOrEmpty(KH_NguoiGioiThieu))
                        {
                            khItem.NguoiGioiThieu = new Guid(KH_NguoiGioiThieu);
                        }
                        khItem.Phone = KH_Phone;
                        khItem.Ten = KH_Ten;
                        khItem.Ym = KH_Ym;
                        khItem.NgayTao = DateTime.Now;
                        khItem.Anh = Anh;
                        khItem = KhachHangDal.Insert(khItem);
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(khItem));
                    }
                    break;
                    #endregion
                case "editTuVan":
                    #region editTuVan
                    var itemEditTuvan = TuVanDal.SelectById(new Guid(ID));
                    itemEditTuvan._TuVanTinhTrang = TuVanTinhTrangDal.SelectByTvId(ID);
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemEditTuvan));
                    break;
                    #endregion
                case "saveTuVan":
                    #region saveTuVan
                    if (!string.IsNullOrEmpty(So))
                    {
                        var tvItem = new TuVan();
                        tvItem.ID = new Guid(ID);
                        tvItem.DichVuDieuTriKhac = DichVuDieuTriKhac;
                        tvItem.GhiChu = GhiChu;
                        tvItem.HieuQua = false;
                        tvItem.KH_ID = new Guid(KH_ID);
                        tvItem.Ma = Ma;
                        tvItem.Ngay = Convert.ToDateTime(Ngay, new CultureInfo("vi-Vn"));
                        tvItem.NgayCapNhat = DateTime.Now;
                        tvItem.NgayTao = DateTime.Now;
                        tvItem.NguoiCapNhat = Security.Username;
                        tvItem.NguoiTao = Security.Username;
                        tvItem.So = So;
                        tvItem.TinhTrangLanDa = TinhTrangLanDa;
                        tvItem.TinhTrangSucKhoe = TinhTrangSucKhoe;
                        tvItem.TuVanVien = TuVanVien;
                        tvItem.YKienKhachHang = YKienKhachHang;
                        tvItem = TuVanDal.Insert(tvItem);
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(tvItem));
                    }
                    break;
                    #endregion
                case "reports":
                    #region bao cao
                    var itemTuVanRpt = new List<TuVan>();
                    itemTuVanRpt.Add(TuVanDal.SelectById(new Guid(ID)));
                    var listKh = new List<KhachHang>();
                    listKh.Add(KhachHangDal.SelectById(itemTuVanRpt[0].KH_ID));
                    RenderReport(itemTuVanRpt, listKh, DanhMucDal.SelectByTvId(ID).ToList(), "WORD", "Báo cáo", DateTime.Now.ToString("dd-mm-yy"));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(DangKy), "appStore.pmSpa.desktop.controls.KHang.DangKy.js"));
                    break;
                    #endregion                
                case "print":
                    #region Nạp js
                    if(!string.IsNullOrEmpty(ID))
                    {
                        var tvItem = TuVanDal.SelectById(new Guid(ID));
                        var khItem = KhachHangDal.SelectById(tvItem.KH_ID);
                        var memItem = MemberDal.SelectByUser(tvItem.TuVanVien);
                        var printFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.TuVan-In.htm");
                        var ttFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.TuVan-In-TinhTrang-Item.htm");
                        var dvFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.TuVan-In-DichVu-Item.htm");

                        var sbTinhTrang = new StringBuilder();
                        var sbDichVu = new StringBuilder();
                        var tinhTrangItem = new DanhMuc();
                        var dichVuItem = new TinhTrangDichVu();
                        foreach (var rel in RelationDal.SelectByPid(tvItem.ID.ToString()))
                        {
                            tinhTrangItem = DanhMucDal.SelectById(rel.CID);
                            sbDichVu=new StringBuilder();
                            foreach (var itemdv in TinhTrangDichVuDal.SelectDmId(rel.CID.ToString()))
                            {
                                sbDichVu.AppendFormat(dvFormat
                                   , itemdv.dvu.Ma
                                   , itemdv.dvu.Ten
                                   , itemdv.dvu.SoLan
                                   , itemdv.dvu.ThoiGian
                                   , string.Format(new CultureInfo("vi-Vn"), "{0:c}", itemdv.dvu.Gia).Replace(",00 ₫", ""));
                            }
                            sbTinhTrang.AppendFormat(ttFormat, tinhTrangItem.Ten, sbDichVu);
                        }

                        sb.AppendFormat(printFormat
                                        , cs.GetWebResourceUrl(typeof (DangKy),"appStore.pmSpa.desktop.controls.KHang.start-up.png")
                                        , khItem.Ma
                                        , string.Empty
                                        , tvItem.So
                                        , tvItem.NgayTao.ToString("dd/MM/yy")
                                        , memItem.Ten
                                        , khItem.Ten
                                        , khItem.GioiTinh ? "Nữ" : "Nam"
                                        , khItem.NgaySinh.ToString("dd/MM/yy")
                                        , khItem.DiaChi
                                        , khItem.KhuVuc_Ten
                                        , khItem.Phone
                                        , khItem.Mobile
                                        , khItem.Ym
                                        , khItem.CMND
                                        , khItem.Email
                                        , khItem.NguonGoc_Ten
                                        , tvItem.TinhTrangSucKhoe
                                        , tvItem.TinhTrangLanDa
                                        , tvItem.YKienKhachHang
                                        , sbTinhTrang
                                        , tvItem.DichVuDieuTriKhac
                                        , cs.GetWebResourceUrl(typeof(DangKy), "appStore.pmSpa.desktop.controls.KHang.Print.css"));
                    }
                    break;
                    #endregion                
                default:
                    #region nạp
                    var listFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "KHang.TuVan.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(DangKy), "appStore.pmSpa.desktop.controls.KHang.DangKy.js")
                        , "{danhMucDichVuMgr.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(listFn));
                    break;
                    #endregion
            }

            Html = sb.ToString();
            base.KhoiTao(con);
        }


        public string Ma { get; set; }
        public string Css { get; set; }
        public string Ten { get; set; }
        public string Top { get; set; }
        public string Header_Url { get; set; }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            Ma = GetSetting("Ma", SettingNode);
            Ten = GetSetting("Ten", SettingNode);
            Css = GetSetting("Css", SettingNode);
            Top = GetSetting("Top", SettingNode);
            Header_Url = GetSetting("Header_Url", SettingNode);
            base.LoadSetting(SettingNode);
        }
        public override void AddTabs()
        {
            base.AddTabs();
            ModuleSetting Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Ma";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Ma;
            Tab1Settings1.Title = "Mã danh mục";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Ten";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Ten;
            Tab1Settings1.Title = "Tên";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Top";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Top;
            Tab1Settings1.Title = "Số lượng";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Css";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Css;
            Tab1Settings1.Title = "Css";
            this.Tabs[0].Settings.Add(Tab1Settings1);

            Tab1Settings1 = new ModuleSetting();
            Tab1Settings1.Key = "Header_Url";
            Tab1Settings1.Type = "String";
            Tab1Settings1.Value = Header_Url;
            Tab1Settings1.Title = "Url";
            this.Tabs[0].Settings.Add(Tab1Settings1);
        }
        public override void ImportPlugin()
        {
            if (Ma == null) Ma = "12";
            if (Top == null) Top = "5";
            if (Ten == null) Ten = "Tên Module";
            if (Css == null) Css = "";
            if (Header_Url == null) Header_Url = "";
            base.ImportPlugin();
        }

        public void SetSubDataSource(object sender, SubreportProcessingEventArgs e)
        {
            var dmId = e.Parameters[0].Values[0].ToString();
            e.DataSources.Add(new ReportDataSource("DataSet1", TinhTrangDichVuDal.SelectDmId(dmId).ToList()));
            
        }
        public void RenderReport(List<TuVan> dt, List<KhachHang> dt1, List<DanhMuc> listDm, string loai, string _ten, string _ngay)
        {

            LocalReport localReport = new LocalReport();
            localReport.SubreportProcessing += new SubreportProcessingEventHandler(SetSubDataSource);
            localReport.ReportEmbeddedResource = "appStore.pmSpa.desktop.controls.KHang.TuVanRpt.rdlc";

            //A method that returns a collection for our report

            //Note: A report can have multiple data sources


            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet2", dt1);
            ReportDataSource reportDataSource2 = new ReportDataSource("DataSet3", listDm);
            localReport.DataSources.Add(reportDataSource);
            localReport.DataSources.Add(reportDataSource1);
            localReport.DataSources.Add(reportDataSource2);
            localReport.EnableExternalImages = true;
            //ReportParameter ten = new ReportParameter("Ten", _ten);
            //localReport.SetParameters(ten);

            //ReportParameter Host = new ReportParameter("Host", domain);
            //localReport.SetParameters(Host);

            //ReportParameter ngay = new ReportParameter("Ngay", _ngay);
            //localReport.SetParameters(ngay);

            string reportType = string.IsNullOrEmpty(loai) ? "PDF" : loai;
            string mimeType;
            string encoding;
            string fileNameExtension;
            //The DeviceInfo settings should be changed based on the reportType

            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx

            string deviceInfo =

            "<DeviceInfo>" +

            "  <OutputFormat>PDF</OutputFormat>" +

            "  <PageWidth>11.69in</PageWidth>" +

            "  <PageHeight>8.27in</PageHeight>" +

            "  <MarginTop>0.5in</MarginTop>" +

            "  <MarginLeft>1in</MarginLeft>" +

            "  <MarginRight>1in</MarginRight>" +

            "  <MarginBottom>0.5in</MarginBottom>" +

            "</DeviceInfo>";



            Warning[] warnings;

            string[] streams;

            byte[] renderedBytes;



            //Render the report
            localReport.EnableExternalImages = true;
            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=\"" + (string.IsNullOrEmpty(_ten) ? "Phiếu" : _ten) + "." + fileNameExtension + "\"");
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }
    }
}
