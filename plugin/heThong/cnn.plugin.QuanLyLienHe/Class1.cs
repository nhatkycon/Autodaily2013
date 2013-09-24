using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh;
using docsoft;
using docsoft.entities;
using System.Web;
using System.Web.UI;
using linh.json;
using linh.controls;
[assembly: WebResource("cnn.plugin.QuanLyLienHe.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLyLienHe.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace cnn.plugin.QuanLyLienHe
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region tham so
            string _ID = Request["ID"];
            string _PRowId = Request["PRowId"];
            string _PID = Request["PID"];
            string _Ten = Request["Ten"];
            string _DiaChi = Request["DiaChi"];
            string _CongTy = Request["CongTy"];
            string _Email = Request["Email"];
            string _DienThoai = Request["DienThoai"];
            //string _Phone = Request["Phone"];
            string _Skype = Request["Skype"];
            string _Ym = Request["Ym"];
            string _Website = Request["Website"];                        
            string _Active = Request["Active"];
            string _RowId = Request["RowId"];
            string _q = Request["q"];
            #endregion
            
            switch (subAct)
            {

                case "get":
                    #region Get du lieu cho Grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";                    
                    Pager<LienHe> PagerGet = LienHeDal.pagerNormal("", false, "LH_" + jgrsidx + " " + jgrsord, _q, Request["rows"]);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (LienHe lh in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(lh.ID.ToString(),
                            new string[] { 
                                lh.ID.ToString()
                               ,lh.Ten
                               ,lh.DiaChi
                               ,lh.CongTy
                               ,lh.Email
                               ,lh.Mobile
                               ,lh.Skype
                               ,lh.Ym
                               ,lh.Website
                               ,lh.Active.ToString()
                                 }));
                        
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;

                    #endregion
                 
                case "edit":         
                    #region Sua mau tin
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(LienHeDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion            
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        //LienHeDal.DeleteByIdList(_ID);
                        LienHeDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion 
                case "save":
                          #region luu thong tin
                    LienHe ItemSave = new LienHe();
                    
                    if (string.IsNullOrEmpty(_Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = LienHeDal.SelectById(Convert.ToInt32(_ID));
                    }                    
                    ItemSave.Ten = _Ten;                    
                    ItemSave.DiaChi = _DiaChi;
                    ItemSave.CongTy = _CongTy;
                    ItemSave.Email = _Email;                    
                    ItemSave.Mobile = _DienThoai;
                    ItemSave.Skype = _Skype;
                    ItemSave.Ym = _Ym;                    
                    ItemSave.Website = _Website;
                    ItemSave.Active =Convert.ToBoolean(_Active);
                    ItemSave.PRowId = Guid.NewGuid();                    
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave.NguoiCapNhat = Security.Username;
                        ItemSave.NgayCapNhat = DateTime.Now;
                        //ItemSave.NgayTao =ItemSave.NgayTao;                       
                        ItemSave = LienHeDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.NgayCapNhat = DateTime.Now;
                        ItemSave.NguoiTao = Security.Username;                        
                        ItemSave = LienHeDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                #endregion                
                default:
                    #region Nap
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId); //Kiem tra quyen
                    sb.Append(@"
<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-lienhe"" />
</span>

<a class=""mdl-head-btn mdl-head-add"" id=""qllienhemdl-addBtn"" href=""javascript:qllienhefn.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""qllienhemdl-editBtn"" href=""javascript:qllienhefn.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""qllienhemdl-delBtn"" href=""javascript:qllienhefn.del();"">Xóa</a>
</div>

<table id=""lienhemdl-List"" class=""mdl-list""></table>
<div id=""lienhePager""></div>

            ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLyLienHe.JScript1.js")
                        , "{qllienhefn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));

                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
