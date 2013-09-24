using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using System.Data.SqlClient;
using linh.core.dal;
using docsoft;
using docsoft.entities;
using System.Web.UI;
using System.Web;
[assembly: WebResource("appStore.authorityStore.content.html.Banner.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.authorityStore.content.html
{
    #region Banner
    public class Banner : PlugUI
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            bool login = SecurityCangTin.IsAuthenticated();
            Page _Page = new Page();
            ClientScriptManager cs = _Page.ClientScript;
            StringBuilder sb = new StringBuilder();
            HttpContext c = HttpContext.Current;
            string _alias = c.Request["pages"];
            sb.AppendFormat(@"
    <div class=""top"">
        <div class=""top-box"">
            <div class=""top-r"">");
            if (login)
            {
                sb.AppendFormat(@"
                <a href=""{0}"" class=""top-r-avatar avatar-50-box""><img src=""5f45c3ea-3a9d-4089-ba18-6bac8c70aec450x50.jpeg"" class=""avatar-50"" /></a>
                <a href=""javascript:;"" class=""top-r-item top-r-msg"">Tin nhắn</a><span class=""top-r-space"">|</span>
                <a href=""javascript:;"" class=""top-r-item top-r-thongBao"">Thông báo</a><a href=""{0}"" class=""top-r-item top-r-profile"">Tiểu ni</a>
            ",domain);
            }
            else
            {
                sb.AppendFormat(@"
                <a href=""javascript:;"" class=""top-r-item top-r-login"">Đăng nhập</a><a href=""javascript:;"" class=""top-r-item top-r-register"">Đăng ký</a>
            ");
            }
            
            sb.AppendFormat(@"                
            </div>
            <div class=""top-l"">
                <a href=""{0}"" class=""logo""></a>
                <a href=""{0}tim-ban/"" class=""top-l-item{2}"">Tìm bạn</a>
                <a href=""{0}su-kien/"" class=""top-l-item{3}"">Sự kiện</a>
                <a href=""{0}qua/"" class=""top-l-item{4}"">Quà</a>
            </div>
            <div class=""search-pnl"">
                <a href=""javascript:;"" class=""search-btn"">
                </a>
                <input class=""search-txt"" />
            </div>
        </div>
    </div>", domain
           , _alias == "home" ? " top-l-item-active" : ""
           , _alias == "tim-ban" ? " top-l-item-active" : ""
           , _alias == "su-kien" ? " top-l-item-active" : ""
           , _alias == "qua" ? " top-l-item-active" : "");
            sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Banner), "appStore.authorityStore.content.html.Banner.js")
                        , "{bannerFn.setup();}");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }
    #endregion
}
