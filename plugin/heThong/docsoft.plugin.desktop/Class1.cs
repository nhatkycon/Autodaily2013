using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh;
using linh.frm;
using linh.common;
using System.Web.UI;
using linh.json;
using docsoft.entities;
using linh.controls;
[assembly: WebResource("docsoft.plugin.desktop.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.desktop.JScript2.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.desktop.JScript3.js", "text/javascript", PerformSubstitution = true)]
namespace docsoft.plugin.desktop
{
    public class tinTuc:docPlugUI
    {
        public string link { get; set; }
        public string SoBanGhi { get; set; }
        public override void AddTabs()
        {
            base.AddTabs();
            this.Tabs[0].Settings.Add(new ModuleSetting("link", "String", link, "Nguồn"));
            ModuleSettingItemCollection msicOption = new ModuleSettingItemCollection();
            msicOption.Add(new ModuleSettingItem(true, "3", 0, "3"));
            msicOption.Add(new ModuleSettingItem(false, "5", 1, "5"));
            msicOption.Add(new ModuleSettingItem(false, "10", 2, "10"));
            msicOption.Add(new ModuleSettingItem(false, "15", 3, "15"));
            this.Tabs[0].Settings.Add(new ModuleSetting("SoBanGhi", "", SoBanGhi, "Lựa chọn", msicOption));
        }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            base.LoadSetting(SettingNode);
            link = GetSetting("link", SettingNode);
            SoBanGhi = GetSetting("SoBanGhi", SettingNode);
        }
        public override void ImportPlugin()
        {
            if (string.IsNullOrEmpty(Title)) Title = "Tin tức";
            if (string.IsNullOrEmpty(link)) link = "http://vnexpress.net/rss/gl/trang-chu.rss";
            if (string.IsNullOrEmpty(SoBanGhi)) SoBanGhi = "3";
            base.ImportPlugin();
        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            List<linkrss> list = Lib.GetLinkFromRss(link);

            if (string.IsNullOrEmpty(SoBanGhi)) SoBanGhi = "3";

            if (string.IsNullOrEmpty(link))
            {
                sb.AppendFormat("Chọn nguồn tin");
            }
            else
            {
                if (list.Count == 0)
                {
                    sb.AppendFormat("Chưa có tin mới");
                }
                else
                {
                    int i = 0;
                    foreach (linkrss item in list)
                    {
                        if (i < Convert.ToInt32(SoBanGhi.ToString())) 
                        {
                            sb.AppendFormat(@"<a target=""_blank"" class=""DeskMdl-TinRssMdl-Item-Title"" href=""{0}"">{1}</a><span class=""DeskMdl-TinRssMdl-Item-MoTa"">{2}</span>"
                                , item.Url, item.Ten, item.Mota);
                        }
                        i++;
                    }
                }
            }
            
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }

    public class pHtml : docPlugUI
    {
        public string str { get; set; }
        public override void AddTabs()
        {
            base.AddTabs();
            this.Tabs[0].Settings.Add(new ModuleSetting("str", "html", str, "Mã HTML"));
        }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            base.LoadSetting(SettingNode);
            str = GetSetting("str", SettingNode);
        }
        public override void ImportPlugin()
        {
            if (string.IsNullOrEmpty(Title)) Title = "HTML";
            if (string.IsNullOrEmpty(str)) str = "";
            base.ImportPlugin();
        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.Write(str);
            base.Render(writer);
        }
    }

    public class dVanBanDen : docPlugUI
    {
        public override void ImportPlugin()
        {
            if(string.IsNullOrEmpty(Title)) Title = "Văn bản mới đến";
            base.ImportPlugin();
        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
         
            string _q = Request["q"];
            switch (subAct)
            {
                case "get":
                    #region Lấy danh sách
                    if(string.IsNullOrEmpty(jgRows)) jgRows="20";
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<VanBan> pagerGet = VanBanDal.PagerByUser("", false, "VB_" + jgrsidx + " " + jgrsord
                        , jgRows, Security.Username, Request["VB_Draff"], Request["VB_TrangThai"]
                        , Request["VB_CQ_ID"], Request["VB_MEM_Username"], Request["VB_PhanLoai_ID"]
                        , Request["VB_NoiGui_ID"], Request["VB_LoaiVanBan_ID"], _q);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (VanBan item in pagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString()
                            , new string[] { 
                            item.ID.ToString(),
                            string.Format("<a href=\"javascript:dvanBanDen.getVanBanNode('{1}');\">{0}</a>",item.SoDen,item.ID),
                            item.SoKyHieu,
                            string.Format("{0:dd/MM/yy}",item.NgayTrenVanBan),
                            item.Doc ? string.Format(@"<a class=""vanBan-list-item"" href=""javascript:dvanBanDen.getVanBan('{1}');"">{0}</a>",item.TrichYeu,item.ID) : string.Format(@"<a class=""vanBan-list-item vanBan-list-item-bold"" href=""javascript:dvanBanDen.getVanBan('{1}');"">{0}</a>",item.TrichYeu,item.ID),
                            item.TrichYeu,
                            item.MEM_Ten,
                            }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pagerGet.TotalPages.ToString(), pagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "GetVanBan":
                    #region chỉnh sửa node
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        VanBan itemGetVanBan = VanBanDal.SelectByIdView(Convert.ToInt32(_ID), Security.Username);
                        if (itemGetVanBan.Filelist.Count > 0)
                        {
                            if (itemGetVanBan.Filelist[0].ID != 0)
                            {
                                foreach (Files item in itemGetVanBan.Filelist)
                                {
                                    itemGetVanBan.FileListStr += string.Format(@"<a href=""../Default.aspx?act=download&ID={0}"" class=""adm-token-item"">{1}</a>"
                                        , item.ID, item.Ten);
                                }
                            }
                        }
                        sb.Append(string.Format("({0})", JavaScriptConvert.SerializeObject(itemGetVanBan)));
                    }
                    break;
                    #endregion
                case "GetVanBanXuLy":
                    #region chỉnh sửa node
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        VanBan itemGetVanBan = VanBanDal.SelectByIdXuLy(Convert.ToInt32(_ID), Security.Username);
                        if (itemGetVanBan.Filelist.Count > 0)
                        {
                            if (itemGetVanBan.Filelist[0].ID != 0)
                            {
                                foreach (Files item in itemGetVanBan.Filelist)
                                {
                                    itemGetVanBan.FileListStr += string.Format(@"<a href=""../Default.aspx?act=download&ID={0}"" class=""adm-token-item"">{1}</a>"
                                        , item.ID, item.Ten);
                                }
                            }
                        }
                        sb.Append(string.Format("({0})", JavaScriptConvert.SerializeObject(itemGetVanBan)));
                    }
                    break;
                    #endregion
                case "getNode":
                    #region Lấy node theo WFID
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        NodesCollection ListByWf = NodesDal.SelectAll();
                        List<jgridRow> ListRowNodes = new List<jgridRow>();
                        foreach (Nodes item in ListByWf)
                        {
                            ListRowNodes.Add(new jgridRow(item.ID.ToString()
                                , new string[] { 
                            item.ID.ToString(),
                            item.Ten,
                            item.MoTa,
                            item.BatDau ? "Bắt đầu" : (item.KetThuc ? "Kết thúc" : "Bước"),
                            item.ThuTu.ToString()
                            }));
                        }
                        jgrid gridNodes = new jgrid("1", "1", ListByWf.Count.ToString(), ListRowNodes);
                        sb.Append(JavaScriptConvert.SerializeObject(gridNodes));
                    }
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<table class=""dvanBanDenMdl-List"" class=""mdl-list"">
</table>
<div class=""dvanBanDenMdl-Pager""></div>
<div class=""sub-mdl"">
    <ul>
        <li><a id=""dvanBanDenMdl-ChiTietMdl-subMdlViewBtn"" href=""#dvanBanDenMdl-chiTietMdl-ViewMdl"">Thông tin văn bản đến</a></li>
        <li><a id=""dvanBanDenMdl-ChiTietMdl-subMdlLogsBtn"" href=""#dvanBanDenMdl-chiTietMdl-LogsMdl"">Lịch sử</a></li>
    </ul>
    <div id=""dvanBanDenMdl-chiTietMdl-ViewMdl"">
    </div>
    <div id=""dvanBanDenMdl-chiTietMdl-LogsMdl"">
    </div>
</div>
");
                    sb.AppendFormat(@"<script src=""{0}"" type=""text/javascript""></script>"
                        , cs.GetWebResourceUrl(typeof(dVanBanDen), "docsoft.plugin.desktop.JScript1.js"));
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        public string trangthai(int trangThai_Id)
        {
            switch (trangThai_Id)
            {
                case 0: return "Nháp";
                case 1: return "Chưa xử lý";
                case 2: return "Mới";
                case 3: return "Hoàn thành";
                default: return "";
            }
        }
    }
    
    public class UserOnline : docPlugUI
    {
        public string SoBanGhi { get; set; }
        public override void ImportPlugin()
        {
            if (string.IsNullOrEmpty(Title)) Title = "Hiển thị danh sách người dùng Online";            
            base.ImportPlugin();
        }
        public override void AddTabs()
        {
            base.AddTabs();
            ModuleSettingItemCollection msicOption = new ModuleSettingItemCollection();
            msicOption.Add(new ModuleSettingItem(true,"5",0,"5"));
            msicOption.Add(new ModuleSettingItem(false,"10",1,"10"));
            msicOption.Add(new ModuleSettingItem(false, "15", 2, "15"));
            this.Tabs[0].Settings.Add(new ModuleSetting("SoBanGhi", "", SoBanGhi, "Lựa chọn", msicOption));
        }
        public override void LoadSetting(System.Xml.XmlNode SettingNode)
        {
            SoBanGhi = GetSetting("SoBanGhi", SettingNode);
            base.LoadSetting(SettingNode);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
             switch (subAct)
            {
                case "get":
                    #region Lấy danh sách
                    string sbg = Request["sobanghi"];
                    if (string.IsNullOrEmpty(sbg)) sbg = "5";
                    MemberCollection mcMember = MemberDal.UserOnline(Security.Username, Convert.ToInt32(sbg.ToString()));
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (Member item in mcMember)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString()
                            , new string[] { 
                            item.Username,
                            item.SLOnline.ToString()
                            }));
                    }
                    jgrid grid = new jgrid(jgrpage, sbg.ToString(), sbg.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<table class=""userOnlineMdl-List"">
</table>
<div class=""userOnlineMdl-Pager""></div><input type=""hidden"" value=""" + SoBanGhi.ToString() + @""" id=""userOnlineMdl-SoBanGhi"" />");
                    sb.AppendFormat(@"<script src=""{0}"" type=""text/javascript""></script>"
                        , cs.GetWebResourceUrl(typeof(UserOnline), "docsoft.plugin.desktop.JScript2.js"));
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
             writer.Write(sb.ToString());
             base.Render(writer);
        }
    }

    public class dThoiTiet : docPlugUI
    {
        public string diadanh { get; set; }
        public override void ImportPlugin()
        {
            if (string.IsNullOrEmpty(Title)) Title = "Thời tiết";
            base.ImportPlugin();
        }
        protected override void Render(HtmlTextWriter writer)
        {
            ClientScriptManager cs = this.Page.ClientScript;
            StringBuilder sb = new StringBuilder();
            diadanh = Request["DiaDanh"];
           
            if (string.IsNullOrEmpty(diadanh))
            {
                diadanh = "http://vnexpress.net/ListFile/Weather/Hanoi.xml";
            }
            List<thoitiet> list = Lib.GetThoiTiet(diadanh);
            switch (subAct)
            {

                case "get":
                    sb.Append("("+JavaScriptConvert.SerializeObject(list)+")");
                    break;
                default:
                    sb.AppendFormat(@"<div class=""DeskMdl-ThoiTietMdl-content""><select class=""DeskMdl-ThoiTietMdl-Select-diadanh"" onchange=""javascript:dthoitiet.doidiadanh(this.value)"">
                    <option value=""http://vnexpress.net/ListFile/Weather/Sonla.xml"">Sơn La</option>
                    <option value=""http://vnexpress.net/ListFile/Weather/Haiphong.xml"">Hải Phòng</option>
                    <option value=""http://vnexpress.net/ListFile/Weather/Hanoi.xml"" selected=""selected"">Hà Nội</option>
                    <option value=""http://vnexpress.net/ListFile/Weather/Vinh.xml"">Vinh</option>
                    <option value=""http://vnexpress.net/ListFile/Weather/Danang.xml"">Đà Nẵng</option>
                    <option value=""http://vnexpress.net/ListFile/Weather/Nhatrang.xml"">Nha Trang</option>
                    <option value=""http://vnexpress.net/ListFile/Weather/Pleicu.xml"">Pleiku</option>
                    <option value=""http://vnexpress.net/ListFile/Weather/HCM.xml"">TP Hồ Chí Minh</option>
                    </select>");
                   
                    foreach (thoitiet item in list)
                    {
                        sb.AppendFormat(@"<div class=""DeskMdl-ThoiTietMdl-Item-thoitiet"">
                                        <img class=""DeskMdl-ThoiTietMdl-Img"" src=""http://vnexpress.net/images/Weather/{0}"" />
                                        <img class=""DeskMdl-ThoiTietMdl-Img"" src=""http://vnexpress.net/images/Weather/{1}"" />
                                        <img class=""DeskMdl-ThoiTietMdl-Img"" src=""http://vnexpress.net/images/Weather/{2}"" />
                                        <img class=""DeskMdl-ThoiTietMdl-Img"" src=""http://vnexpress.net/images/Weather/{3}"" />
                                        <img class=""DeskMdl-ThoiTietMdl-Img"" src=""http://vnexpress.net/images/Weather/{4}"" />
                                        <img class=""DeskMdl-ThoiTietMdl-Img"" src=""http://vnexpress.net/images/Weather/{5}"" />
                                        <img src=""http://vnexpress.net/images/Weather/c.gif"" />
                                        </div>
                                        <span class=""DeskMdl-ThoiTietMdl-Item-Detail"">{6}</span>",
                                item.AdImg, item.AdImg1, item.AdImg2, item.AdImg3, item.AdImg4, item.AdImg5, item.Weather);
                    }
                    sb.AppendFormat(@"</div>");
                    sb.AppendFormat(@"<script src=""{0}"" type=""text/javascript""></script>"
                        , cs.GetWebResourceUrl(typeof(dThoiTiet), "docsoft.plugin.desktop.JScript3.js"));
                    break;
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
