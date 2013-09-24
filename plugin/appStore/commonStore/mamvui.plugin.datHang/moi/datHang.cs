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
using Microsoft.Reporting.WebForms;
[assembly: WebResource("mamvui.plugin.datHang.moi.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("mamvui.plugin.datHang.moi.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace mamvui.plugin.datHang.moi
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _Ten = Request["Ten"];
            string _Ma = Request["Ma"];
            string _KyHieu = Request["KyHieu"];
            string _ThuTu = Request["ThuTu"];
            string _q = Request["q"];
            string _Active = Request["Active"];
            List<jgridRow> ListRow = new List<jgridRow>();
            Language Item;
            jgrid grid = new jgrid();
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<DatHang> PagerGet = DatHangDal.pagerNormalChuaGiao("", false, "DH_" + jgrsidx + " " + jgrsord,  Convert.ToInt32(Request["rows"]));
                    foreach (DatHang item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(),
                            new string[] { item.ID.ToString()
                                , item.KH_Ten
                                , item.KH_Mobile
                                , item.KH_DiaChi
                                ,string.Format("{0}.000đ",item.Tong)
                                ,string.Format("{0:dd-MM-yy HH:mm}",item.NgayTao)
                                ,string.Format(@"<input onclick=""datHangMoiFn.daGiao('{0}');"" type=""checkbox"" _id=""{0}"" {1}/>",item.ID,item.GiaoHang ? @" checked=""checked""" : "")
                            }));
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "reports":
                    #region bao cao
                    Pager<DatHang> pagerGetReport = DatHangDal.pagerNormalChuaGiao("", false, "DH_ID desc",  Convert.ToInt32(Request["rows"]));
                    RenderReport(pagerGetReport.List, "WORD");
                    #endregion
                    break;
                case "reportsNgay":
                    #region bao cao
                    Pager<DatHang> pagerGetReportDay = DatHangDal.pagerNormalChuaGiao("", false, "DH_ID desc", Convert.ToInt32(Request["rows"]));
                    RenderReport(pagerGetReportDay.List, "WORD");
                    #endregion
                    break;
                case "getSubGrid":
                #region getSubGrid
                    foreach (DatHangChiTiet item in DatHangChiTietDal.SelectByDhId(_ID))
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(),
                            new string[] { item.ID.ToString()
                                , item.HH_Ten                                
                                , string.Format("{0}.000đ",item.HH_Gia)
                                , item.HH_SoLuong.ToString()
                                ,string.Format("{0}.000đ",item.HH_Gia * item.HH_SoLuong)
                            }));
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "100", "100", ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                #endregion
                case "save":
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = LanguageDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new Language();
                    }
                    Item.Ten = _Ten;
                    Item.Ma = _Ma;
                    Item.ThuTu = Int32.Parse(_ThuTu);
                    Item.Active = Convert.ToBoolean(_Active);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = LanguageDal.Update(Item);
                    }
                    else
                    {
                        Item = LanguageDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(LanguageDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "getActive":
                    #region chỉnh sửa
                    sb.Append(JavaScriptConvert.SerializeObject(LanguageDal.SelectAll()));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DatHangDal.DeleteById(new Guid(_ID));
                    }
                    break;
                    #endregion
                case "giao":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DatHangDal.GiaoById(_ID);
                    }
                    break;
                    #endregion
                case "AutoComplete":
                    #region xóa
                    JavaScriptConvert.SerializeObject(LanguageDal.SelectAll());
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "mamvui.plugin.datHang.moi.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-languageFn"" />
</span>
<a  _resource=""admin.system.label.del"" class=""mdl-head-btn mdl-head-del"" id=""datHangMoiMdl-delBtn"" href=""javascript:datHangMoiFn.del();"">Xóa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""giaoViecMdl-delBtn"" href=""javascript:datHangMoiFn.nap();"">Nạp lại</a>
<a class=""mdl-head-btn mdl-head-del"" id=""giaoViecMdl-delBtn"" href=""javascript:datHangMoiFn.baocao();"">Báo cáo</a>
</div>

<table id=""datHangMoiMdl-List"" class=""mdl-list""></table>
<div id=""datHangMoiMdl-Pager""></div>
<div class=""sub-mdl"">
    <div class=""mdl-head"">
    </div>
    <table id=""datHangChiTietMdl-List"" class=""mdl-list""></table>
</div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "mamvui.plugin.datHang.moi.JScript1.js")
                        , "{datHangMoiFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn)); 
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        public void RenderReport(List<DatHang> dt, string loai)
        {

            LocalReport localReport = new LocalReport();

            localReport.ReportEmbeddedResource = "mamvui.plugin.datHang.moi.Report1.rdlc";


            //A method that returns a collection for our report

            //Note: A report can have multiple data sources


            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
            localReport.DataSources.Add(reportDataSource);
            //ReportParameter ten = new ReportParameter("Ten", _ten);
            //ReportParameter ngay = new ReportParameter("Ngay", _ngay);
            //localReport.SetParameters(ten);
            //localReport.SetParameters(ngay);
            string reportType = loai;
            string mimeType;
            string encoding;
            string fileNameExtension;
            //The DeviceInfo settings should be changed based on the reportType

            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx

            string deviceInfo =

            "<DeviceInfo>" +

            "  <OutputFormat>WORD</OutputFormat>" +

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

            renderedBytes = localReport.Render(

                reportType,

                deviceInfo,

                out mimeType,

                out encoding,

                out fileNameExtension,

                out streams,

                out warnings);

            //Clear the response stream and write the bytes to the outputstream

            //Set content-disposition to "attachment" so that user is prompted to take an action

            //on the file (open or save)
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=\"Giao hàng." + fileNameExtension + "\"");
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }
    }
}
