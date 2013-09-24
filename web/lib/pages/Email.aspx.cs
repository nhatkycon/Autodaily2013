using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.common;
using linh.core.dal;

public partial class lib_pages_Email : System.Web.UI.Page
{
    public delegate void SendEmailSingleDelegate(string email, string title, string body);
    void SendMailSingle(string email, string title, string body)
    {
        omail.Send(email, "NhatKyCon.Vn", title, body, "gigawebhome@gmail.com", "NhatKyCon.Vn", "25111987");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var dele = new emailAllDelegate(emailAll);
        dele.BeginInvoke(null, null);
    }
    protected void btnEmail_Click(object sender, EventArgs e)
    {
        
    }

    public delegate void emailAllDelegate();
    void emailAll()
    {
        var sr = File.OpenText(Server.MapPath("~/lib/pages/email/nhacNhoNhatKyHangTuan1.htm"));
        var strContents = sr.ReadToEnd();
        sr.Close();
        var sb = new StringBuilder();
        var title = "Nhật ký con bạn tuần này";
        var body = new StringBuilder();
        var dele = new SendEmailSingleDelegate(SendMailSingle);
        using (var con = DAL.con())
        {
            foreach (var mem in MemberDal.SelectAllEmailUsername(con))
            {
                sb = new StringBuilder();
                var list = CapNhatDal.SelectByUsername(con, "10", mem.Username);
                foreach (var item in list)
                {
                    sb.AppendFormat(@"
<li>
<a style='color: #333;' href='http://nhatkycon.vn/lib/pages/NhatKy/Post.aspx?ID={0}'>
{1} - {2}
</a>
</li>",item.ID,item.NgayViet.ToString("dd/MM/yy"),item.Ten);

                }
                body=new StringBuilder();
                body.AppendFormat(strContents
                                  , mem.Ten
                                  , mem.Email
                                  , mem.ID
                                  , sb);

                dele.BeginInvoke(mem.Email, title, body.ToString(), null, null);    
            }
        }
    }
}