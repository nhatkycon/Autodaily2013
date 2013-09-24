using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using linh.frm;
using linh.common;
using System.IO;
using linh.controls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using linh.core.dal;
using System.Drawing;
using System.Diagnostics;
namespace linh.httpModule
{
    public class Captcha : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string _capchaCode = CaptchaImage.GenerateRandomCode(CaptchaType.AlphaNumeric, 6);
            context.Session["capcha"] = _capchaCode;
            CaptchaImage c = new CaptchaImage(_capchaCode, 138, 40, "Tahoma", Color.White, Color.Orange);
            context.Response.ClearContent();
            context.Response.ContentType = "image/jpeg";
            MemoryStream ms = new MemoryStream();
            c.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            context.Response.OutputStream.Write(ms.ToArray(), 0, Convert.ToInt32(ms.Length));
            ms.Close();
            context.Response.End();
        }
    }
}
