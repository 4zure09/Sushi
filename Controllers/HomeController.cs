using sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace sushi.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataClasses1DataContext data;

        public HomeController()
        {
            string connectionString = "Data Source=JIN-592G\\SQLEXPRESS;Initial Catalog=DACS;Integrated Security=True";
            data = new DataClasses1DataContext(connectionString);
        }
            public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult XacnhanDonhang()
        {
            string tens = (Session["SPDC"] as Sushi).TenSushi;
            var spdc = (from p in data.Sushis where p.TenSushi == tens select p).OrderBy( m => m.Gia); //Sắp xếp theo giá
            /*var spdc = (from p in data.Sushis where p.MaPhanLoai == mapl select p).OrderByDescending(m => m.SLTruyCap);*/
            int pageSize = 3;

            return View(spdc.ToPagedList(1, pageSize));
        }
        //Lịch sử giao dịch
        public ActionResult LichSuGiaoDich(string taikhoangiaodich)
        {

            var hdList = from c in data.ChiTietDonHangs
                         join h in data.HOA_DONs on c.MaHÐ equals h.MaHÐ
                         where h.MaKH == taikhoangiaodich
                         join p in data.Sushis on c.ID_Sushi equals p.ID_Sushi
                         group c by new { h.MaHÐ, p.TenSushi, c.SoLuong, c.NgayMua, c.TongGia, p.Hinh } into g
                         select new Lichsugiaodich
                         {
                             mahd = g.Key.MaHÐ,
                             tensp = g.Key.TenSushi,
                             iSoluong = g.Key.SoLuong,
                             ngaymua = g.Key.NgayMua,
                             tonggia = g.Key.TongGia,
                             hinhanh = g.Key.Hinh
                         };


            return View(hdList);


        }
    }
}