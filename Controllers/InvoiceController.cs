using sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sushi.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        private readonly DataClasses1DataContext data;

        public InvoiceController()
        {
            string connectionString = "Data Source=JIN-592G\\SQLEXPRESS;Initial Catalog=DACS;Integrated Security=True";
            data = new DataClasses1DataContext(connectionString);
        }
        // GET: ThongKe
        public ActionResult Invoice(int mahdid)
        {
            var all_thongke = from h in data.HOA_DONs
                              where h.MaHÐ == mahdid
                              join c in data.ChiTietDonHangs on h.MaHÐ equals c.MaHÐ
                              join k in data.KhachHangs on h.MaKH equals k.MaKH
                              join p in data.Sushis on c.ID_Sushi equals p.ID_Sushi
                              group h by new
                              {

                                  k.HoTenKH,
                                  k.DiaChi,
                                  k.Email,
                                  k.SDT,
                                  h.ThanhToan,
                                  c.SoLuong,
                                  c.TongGia,
                                  c.NgayMua,
                                  h.TongTienTT,
                                  h.NgayGiao,
                                  h.NgayDat,
                                  p.TenSushi,
                                  p.Gia
                              } into g
                              select new invoice
                              {
                                  hotenkh = g.Key.HoTenKH,
                                  diachi = g.Key.DiaChi,
                                  email = g.Key.Email,
                                  sdt = g.Key.SDT,

                                  tongtt = g.Key.TongGia,
                                  tongtien = g.Key.TongTienTT,
                                  ngaymua = g.Key.NgayMua,
                                  ngaydat = String.Format("{0:dd/MM/yyyy}", g.Key.NgayDat),
                                  ngaygiao = String.Format("{0:dd/MM/yyyy}", g.Key.NgayGiao),
                                  tensp = g.Key.TenSushi,
                                  soluong = g.Key.SoLuong,
                                  giasp = g.Key.Gia,
                                  tinhtrangtt = g.Key.ThanhToan.ToString(),


                              };





            return View(all_thongke.ToList());

        }
    }
}