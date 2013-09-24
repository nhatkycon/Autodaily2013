using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using docsoft.entities;
using linh.common;
using linh.core.dal;

public class BcyMail
{
    public delegate void SendEmailSingleDelegate(string email, string title, string body);
    void SendMailSingle(string email, string title, string body)
    {
        omail.Send(email, "NhatKyCon", title, body, "gigawebhome@gmail.com", "NhatKyCon", "25111987");
    }

    public delegate void LoiChucDele(Guid id);
    public void LoiChuc(Guid id)
    {
        var dele = new LoiChucDele(LoiChucProcess);
        dele.BeginInvoke(id, null, null);
    }

    public  void LoiChucProcess(Guid id)
    {
        using(var con  = DAL.con())
        {
            var loiChuc = LoiChucDal.SelectById( con, id);
            var be = BeDal.SelectById(con, loiChuc.P_ID);
            var mem = MemberDal.SelectByUser(con, loiChuc.Username);
            var beMem = MemberDal.SelectByUser(con, be.Username);
            var dele = new SendEmailSingleDelegate(SendMailSingle);
            var title = string.Format("{0} đã gửi lời chúc đến bé của bạn - NhatKyCon"
                ,mem.Ten);
            var body = string.Format(@"<h1>Chào {0}!</h1>{1} đã gửi lời chúc đến bé nhà bạn<br/><hr/><br/>
<strong>{2}</strong><br/>
<hr/>
<a href=""http://nhatkycon.vn/lib/pages/NhatKy/Default.aspx?ID={3}#{4}"">Xem</a>
NhậtKýCon - <a href=""http://nhatkycon.vn/lib/pages/NhatKy/Default.aspx?ID=aa1c69e5-3cc1-4ef0-a7e8-00ca320ccc15"">Nhím</a>"
                , beMem.Ten
                , mem.Ten
                , loiChuc.NoiDung
                , be.ID
                , loiChuc.ID);
            dele.BeginInvoke(beMem.Email, title, body, null, null);

        }
    }

    public delegate void BinhLuanDele(Guid id);
    public void BinhLuan(Guid id)
    {
        var dele = new BinhLuanDele(BinhLuanProcess);
        dele.BeginInvoke(id, null, null);
    }
    public void BinhLuanProcess(Guid id)
    {
        using (var con = DAL.con())
        {
            var bl = BinhLuanDal.SelectById(id);
            var mem = MemberDal.SelectByUser(bl.Username);
            var title = "";
            var body = "";
            var beMem = new Member();
            if(!string.IsNullOrEmpty(bl.Url))
            {
                if(bl.Url.IndexOf("Album.aspx") > -1)
                {
                    var item = AlbumDal.SelectById(con, bl.P_RowId);
                    beMem = MemberDal.SelectByUser(item.NguoiTao);
                    title = string.Format("{0} đã bình luận album {1} - NhatKyCon"
                , mem.Ten, item.Ten);
                    body = string.Format(@"
<h1>Chào {0}!</h1><strong>{1}</strong> đã bình luận album {2}<br/><hr/><br/>
<strong>{1}</strong> nói: <br/><br/>
<strong>{3}</strong><br/><br/>
<hr/>
<a style=""display:inline-block; padding: 10px; border:solid 1px #ccc;"" href=""{4}"">Xem chi tiết</a><br/><br/>
NhậtKýCon - <a href=""http://nhatkycon.vn/lib/pages/NhatKy/Default.aspx?ID=aa1c69e5-3cc1-4ef0-a7e8-00ca320ccc15"">Nhím</a>"
                        , beMem.Ten
                        , mem.Ten
                        , item.Ten
                        , bl.NoiDung
                        , bl.Url);

                }
                else if (bl.Url.IndexOf("TheoDoi") > -1)
                {
                    var item = BaoCaoTheoDoiDal.SelectById(con, bl.P_RowId);
                    beMem = MemberDal.SelectByUser(item.Username);
                    title = string.Format("{0} đã bình luận báo cáo theo dõi {1} - NhatKyCon"
                , mem.Ten, item.Ten);
                    body = string.Format(@"
<h1>Chào {0}!</h1><strong>{1}</strong> đã bình luận báo cáo theo dõi {2}<br/><hr/><br/>
<strong>{1}</strong> nói: <br/><br/>
<strong>{3}</strong><br/><br/>
<hr/>
<a style=""display:inline-block; padding: 10px; border:solid 1px #ccc;"" href=""{4}"">Xem chi tiết</a><br/><br/>
NhậtKýCon - <a href=""http://nhatkycon.vn/lib/pages/NhatKy/Default.aspx?ID=aa1c69e5-3cc1-4ef0-a7e8-00ca320ccc15"">Nhím</a>"
                        , beMem.Ten
                        , mem.Ten
                        , item.Ten
                        , bl.NoiDung
                        , bl.Url);
                }
                else if (bl.Url.IndexOf("Post.aspx") > -1)
                {
                    var item = CapNhatDal.SelectById(con, bl.P_RowId);
                    beMem = MemberDal.SelectByUser(item.Username);
                    title = string.Format("{0} đã bình luận cập nhật {1} - NhatKyCon"
                , mem.Ten, item.Ten);
                    body = string.Format(@"
<h1>Chào {0}!</h1><strong>{1}</strong> đã bình luận cập nhật{2}<br/><hr/><br/>
<strong>{1}</strong> nói: <br/><br/>
<strong>{3}</strong><br/><br/>
<hr/>
<a style=""display:inline-block; padding: 10px; border:solid 1px #ccc;"" href=""{4}"">Xem chi tiết</a><br/><br/>
NhậtKýCon - <a href=""http://nhatkycon.vn/lib/pages/NhatKy/Default.aspx?ID=aa1c69e5-3cc1-4ef0-a7e8-00ca320ccc15"">Nhím</a>"
                        , beMem.Ten
                        , mem.Ten
                        , item.Ten
                        , bl.NoiDung
                        , bl.Url);
                }
                var dele = new SendEmailSingleDelegate(SendMailSingle);
                dele.BeginInvoke(beMem.Email, title, body, null, null);

                var listBl = BinhLuanDal.ByPid(con, bl.P_RowId.ToString(), null, "50", null);
                foreach (var itemBl in listBl)
                {
                    if(itemBl.Username!= mem.Username && itemBl.Username != mem.Username)
                    {
                        body = string.Format(@"
<h1>Chào {0}!</h1><strong>{1}</strong> đã bình luận chủ đề có bạn<br/><hr/><br/>
<strong>{1}</strong> nói: <br/><br/>
<strong>{2}</strong><br/><br/>
<hr/>
<a style=""display:inline-block; padding: 10px; border:solid 1px #ccc;"" href=""{3}"">Xem chi tiết</a><br/><br/>
NhậtKýCon - <a href=""http://nhatkycon.vn/lib/pages/NhatKy/Default.aspx?ID=aa1c69e5-3cc1-4ef0-a7e8-00ca320ccc15"">Nhím</a>"
                        , itemBl._Member.Ten
                        , mem.Ten
                        , bl.NoiDung
                        , bl.Url);
                        dele = new SendEmailSingleDelegate(SendMailSingle);
                        dele.BeginInvoke(itemBl._Member.Email, title, body, null, null);    
                    }
                }
            }
        }
    }
}