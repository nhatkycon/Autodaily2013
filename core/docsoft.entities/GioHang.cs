using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using linh.core;

namespace docsoft.entities
{
    public class GioHang
    {
        public int Total { get; set; }
        public int TotalItem { get; set; }
        public int ShipCost { get; set; }
        public Dictionary<string, GioHangItem> List { get; set; }
        public GioHang()
        {
            if (HttpContext.Current.Session["cart"] == null)
            {
                List = new Dictionary<string, GioHangItem>();
                HttpContext.Current.Session["cart"] = List;
            }
            var list = HttpContext.Current.Session["cart"] as Dictionary<string, GioHangItem>;
            List = list;
            Calculate();
        }
        public void Calculate()
        {
            if (List == null)
            {
                List = new Dictionary<string, GioHangItem>();
                HttpContext.Current.Session["cart"] = List;
            }
            var list = HttpContext.Current.Session["cart"] as Dictionary<string, GioHangItem>;
            List = list;
            Total = 0;
            ShipCost = 0;
            TotalItem = 0;
            foreach (GioHangItem item in List.Values)
            {
                Total += item.Gia * item.SoLuong;
                TotalItem += item.SoLuong;
            }
            if (Total < 80)
            {
                ShipCost = 5;
            }
        }
        public void Add(HangHoa item)
        {
            var gioHangItem = new GioHangItem();
            if (List[item.ID.ToString().ToString()] != null)
            {
                gioHangItem = List[item.ID.ToString().ToString()];
                gioHangItem.SoLuong += 1;
                List.Remove(item.ID.ToString().ToString());
                List.Add(item.ID.ToString().ToString(), gioHangItem);
            }
            else
            {
                gioHangItem = new GioHangItem(item.Ten, item.Anh, Convert.ToInt32(item.GNY), 1);
                List.Add(item.ID.ToString().ToString(), gioHangItem);
            }
            Calculate();
            HttpContext.Current.Session["cart"] = List;
        }
        public void Add(HangHoa item, string SoLuong)
        {
            var gioHangItem = new GioHangItem();
            if (SoLuong == null) SoLuong = "1";
            if (List.ContainsKey(item.ID.ToString()))
            {
                gioHangItem = List[item.ID.ToString()];
                gioHangItem.SoLuong += Convert.ToInt32(SoLuong);
                List.Remove(item.ID.ToString());
                List.Add(item.ID.ToString(), gioHangItem);
            }
            else
            {
                gioHangItem = new GioHangItem(item.Ten, item.Anh, Convert.ToInt32(item.GNY), Convert.ToInt32(SoLuong));
                List.Add(item.ID.ToString(), gioHangItem);
            }
            Calculate();
            HttpContext.Current.Session["cart"] = List;
        }
        public void UpdateSl(HangHoa item, string SoLuong)
        {
            var gioHangItem = new GioHangItem();
            if (SoLuong == null) SoLuong = "1";
            if (List.ContainsKey(item.ID.ToString()))
            {
                gioHangItem = List[item.ID.ToString()];
                gioHangItem.SoLuong = Convert.ToInt32(SoLuong);
                List.Remove(item.ID.ToString());
                List.Add(item.ID.ToString(), gioHangItem);
            }
            else
            {
                gioHangItem = new GioHangItem(item.Ten, item.Anh, Convert.ToInt32(item.GNY), Convert.ToInt32(SoLuong));
                List.Add(item.ID.ToString(), gioHangItem);
            }
            Calculate();
            HttpContext.Current.Session["cart"] = List;
        }
        public void Add(string id, string ten, string anh, string gia, string soluong)
        {
            var item = new HangHoa();
            item.ID = new Guid(id);
            item.Ten = ten;
            item.Anh = anh;
            item.GNY = Convert.ToDouble(gia);
            var gioHangItem = new GioHangItem();
            if (List.ContainsKey(item.ID.ToString()))
            {
                gioHangItem = List[item.ID.ToString()];
                gioHangItem.SoLuong += 1;
                List.Remove(item.ID.ToString());
                List.Add(item.ID.ToString(), gioHangItem);
            }
            else
            {
                gioHangItem = new GioHangItem(item.Ten, item.Anh, Convert.ToInt32(item.GNY), Convert.ToInt32(soluong));
                List.Add(item.ID.ToString(), gioHangItem);
            }
            Calculate();
            HttpContext.Current.Session["cart"] = List;
        }
        public void Remove(string item)
        {
            if (List.ContainsKey(item))
            {
                List.Remove(item);
                Calculate();
            }
            HttpContext.Current.Session["cart"] = List;
        }
        public void Clear()
        {
            List = new Dictionary<string, GioHangItem>();
            Calculate();
            HttpContext.Current.Session["cart"] = List;
        }

    }
    public class GioHangItem : BaseEntity
    {
        public string Ten { get; set; }
        public string Img { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public GioHangItem() { }
        public GioHangItem(string ten, string img, int gia, int soLuong)
        {
            Ten = ten;
            Img = img;
            Gia = gia;
            SoLuong = soLuong;
        }

        public override BaseEntity getFromReader(System.Data.IDataReader rd)
        {
            throw new NotImplementedException();
        }
    }
    public class GioHangList : BaseEntityCollection<GioHangItem>
    {
    }
}
