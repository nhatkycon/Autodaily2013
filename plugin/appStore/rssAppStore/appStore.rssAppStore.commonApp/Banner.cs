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
using linh.controls;
using linh.common;

namespace appStore.rssAppStore.commonApp
{
    public class Banner : PlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            StringBuilder sb = new StringBuilder();
            docsoft.entities.DanhMuc ItemDm = docsoft.entities.DanhMucDal.SelectByMa("HETHONG-LOGO-MAIN", con);
            sb.AppendFormat(@"
<div class=""bodyGlobal top"">
    <div class=""boxGlobal"">
        <div class=""box1Global"">");
            sb.AppendFormat(@"<div class=""logo"">{0}</div>", ItemDm.Description);

            sb.AppendFormat(@"<div class=""advPnl-top""></div>");
            sb.AppendFormat(@"
        </div>
    </div>
</div>");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }
}
