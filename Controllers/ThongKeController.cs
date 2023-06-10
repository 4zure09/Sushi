using sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sushi.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        private readonly DataClasses1DataContext data;

        public ThongKeController()
        {
            string connectionString = "Data Source=JIN-592G\\SQLEXPRESS;Initial Catalog=DACS;Integrated Security=True";
            data = new DataClasses1DataContext(connectionString);
        }
        // GET: ThongKe
        public ActionResult ThongKe()
        {
            var all_thongke = from c in data.ChiTietDonHangs
                              join h in data.HOA_DONs on c.MaHÐ equals h.MaHÐ
                              group c by new { c.MaHÐ, h.ThanhToan } into g
                              select new ThongKe
                              {
                                  mahd = g.Key.MaHÐ,
                                  tonggia = g.Sum(c => c.TongGia),
                                  tinhtrangthanhtoan = g.Key.ThanhToan

                              };

            int? soluongdaban = data.ChiTietDonHangs.Sum(s => s.SoLuong);
            decimal? thunhap = data.ChiTietDonHangs.Sum(s => s.TongGia);

            ViewBag.soluongdaban = soluongdaban;
            ViewBag.thunhap = thunhap;

            return View(all_thongke.ToList());

        }
    }
}