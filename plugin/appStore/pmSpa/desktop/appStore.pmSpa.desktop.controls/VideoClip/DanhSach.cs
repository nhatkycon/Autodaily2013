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
using docbao.entitites;
namespace appStore.pmSpa.desktop.controls.VideoClip
{
    public class DanhSach : docPlugUI
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
            var sbItems = new StringBuilder();
            var cs = page.ClientScript;
            var c = HttpContext.Current;
            var _id = c.Request["VID"];

            Video Item = new Video();
            VideoCollection List = new VideoCollection();
            var itemFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "VideoClip.item.htm");
            var bodyFormat = Lib.GetResource(Assembly.GetExecutingAssembly(), "VideoClip.Body.htm");
            if (!string.IsNullOrEmpty(_id))
            {
                #region Xem chi tiết Video

                Item = VideoDal.SelectById(Convert.ToInt32(_id));
                List = VideoDal.SelectByIdList(_id, 10);

                #endregion
            }
            else
            {
                #region Mặc định
                List = VideoDal.SelectHot(50);
                if (List.Count > 0)
                {
                    Item = List[0];
                }
                #endregion
            }


            if (List.Count > 0)
            {
                if (List.Count > 1)
                {
                    foreach (Video item in List)
                    {
                        sbItems.AppendFormat(itemFormat, domain, item.ID, item.Anh, item.Ten, Lib.Bodau(item.Ten));
                    }
                }
            }
            sb.AppendFormat(bodyFormat, domain, sbItems);

            Html = sb.ToString();
            base.KhoiTao(con);
        }
    }
}
