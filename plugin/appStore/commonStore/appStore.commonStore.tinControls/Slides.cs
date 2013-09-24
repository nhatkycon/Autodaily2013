using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using linh.frm;
[assembly: WebResource("appStore.commonStore.tinControls.slides.min.jquery.js", "text/javascript", PerformSubstitution = true)]
namespace appStore.commonStore.tinControls
{
    public class Slides : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            KhoiTao(DAL.con());
            writer.Write(Html);
            base.Render(writer);
        }
        public override void KhoiTao(SqlConnection con)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(
                @"
<div id=""container"">
    <div id=""slides"">
	    <div class=""slides_container"">");
            var list = TinDal.SelectByDanhMuc("Slides", 20, con);
            foreach (Tin item in list)
            {
                sb.Append(TinDal.formatSlides(item, domain));
            }
            sb.AppendFormat(
    @"
	    </div>
    </div>
</div>
<script src=""{0}/lib/css/web/images-with-captions/js/slides.min.jquery.js"" type=""text/javascript""></script>", domain);
            sb.Append(
                @"
<script>
    $(function () {
        $('#slides').slides({
            preload: false,
            play: 15000,
            pause: 15000,
            hoverPause: true,
            animationStart: function (current) {
                $('.caption').animate({
                    bottom: -35
                }, 100);
            },
            animationComplete: function (current) {
                $('.caption').animate({
                    bottom: 0
                }, 200);
            },
            slidesLoaded: function () {
                $('.caption').animate({
                    bottom: 0
                }, 200);
            }
        });
    });
</script>");
            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }

}
