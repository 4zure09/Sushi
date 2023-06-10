using sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sushi.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        private readonly DataClasses1DataContext data;

        public GioHangController()
        {
            string connectionString = "Data Source=JIN-592G\\SQLEXPRESS;Initial Catalog=DACS;Integrated Security=True";
            data = new DataClasses1DataContext(connectionString);
        }
        public KhachHang layKhachHang()
        {
            KhachHang kh = (KhachHang)Session["KhachHang"];
            return kh;


        }
        public List<cart> layGioHang()
        {

            KhachHang kh = layKhachHang();
            List<cart> listGioHang = data.carts.Where(n => n.MaKH == kh.MaKH).ToList();
            if (listGioHang == null)
            {
                listGioHang = new List<cart>();
            }
            return listGioHang;
        }

        public ActionResult themGioHang(string idaddcart, string strURL)
        {
            if (Session["KhachHang"] == null || Session["KhachHang"].ToString() == "")
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<cart> listGioHang = layGioHang();
                cart sanpham = listGioHang.Find(n => n.ID_Sushi == idaddcart);
                KhachHang kh = layKhachHang();
                Sushi sp = data.Sushis.FirstOrDefault(s => s.ID_Sushi == idaddcart);
                if (kh == null || kh.ToString() == "")
                {
                    return RedirectToAction("DangNhap", "User");
                }
                else
                {
                    if (sanpham == null)
                    {
                        sanpham = new cart();
                        sanpham.ID_Sushi = idaddcart;
                        sanpham.MaKH = kh.MaKH;
                        sanpham.SoluongMua = 1;
                        sanpham.Gia = sp.Gia;
                        data.carts.InsertOnSubmit(sanpham);
                        data.SubmitChanges();
                        return Redirect(strURL);
                    }
                    else
                    {
                        sanpham.SoluongMua++;

                        data.SubmitChanges();
                        sanpham.Gia = sanpham.SoluongMua * sp.Gia;
                        data.SubmitChanges();
                        return Redirect(strURL);
                    }
                }
            }

        }
        private int tongSoLuongSanPham()
        {
            int tsl = 0;
            List<cart> listGioHang = layGioHang();
            if (listGioHang != null)
            {
                tsl = Convert.ToInt32(listGioHang.Sum(n => n.SoluongMua));
            }
            return tsl;
        }


        private int tongSanPham()
        {
            int ssp = 0;
            List<cart> listGioHang = layGioHang();
            if (listGioHang != null)
            {
                ssp = listGioHang.Count;
            }
            return ssp;
        }
        private decimal tongGia()
        {
            decimal tonggia = 0;

            List<cart> listGioHang = layGioHang();
            if (listGioHang != null)
            {
                tonggia = Convert.ToDecimal(listGioHang.Sum(n => n.Gia));
            }
            return tonggia;

        }

        private decimal Gia1sp()
        {
            decimal gia = 0;
            List<cart> listGioHang = layGioHang();
            if (listGioHang != null)
            {
                foreach (var item in listGioHang)
                {
                    Sushi sp = data.Sushis.SingleOrDefault(s => s.ID_Sushi == item.ID_Sushi);
                    gia = Convert.ToDecimal(1 * sp.Gia);
                }
            }
            return gia;
        }
        public ActionResult GioHang()
        {
            if (Session["KhachHang"] == null || Session["KhachHang"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Account");
            }
            else
            {
                List<cart> listGioHang = layGioHang();
                ViewBag.Tongsoluongsanpham = tongSoLuongSanPham();
                ViewBag.Tongsosanpham = tongSanPham();
                ViewBag.TongGia = tongGia();
                ViewBag.Gia1sp = Gia1sp();
                return View(listGioHang);
            }

        }
        public ActionResult XoaGioHang(string delcartid)
        {
            List<cart> listGioHang = layGioHang();
            cart sanpham = listGioHang.SingleOrDefault(n => n.ID_Sushi == delcartid);
            if (sanpham != null)
            {
                listGioHang.RemoveAll(n => n.ID_Sushi == delcartid);
                data.carts.DeleteOnSubmit(sanpham);
                data.SubmitChanges();
                return RedirectToAction("GioHang");

            }
            return RedirectToAction("GioHang");
        }

        public ActionResult CapnhatGioHang(string upid, FormCollection collection)
        {
            List<cart> listGioHang = layGioHang();
            cart sanpham = listGioHang.SingleOrDefault(n => n.ID_Sushi == upid);
            if (sanpham != null)
            {
                sanpham.SoluongMua = int.Parse(collection["txtSoLg"].ToString());
                sanpham.Gia = int.Parse(collection["txtSoLg"].ToString()) * sanpham.Sushi.Gia;
                data.SubmitChanges();
            }

            return RedirectToAction("GioHang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<cart> listGioHang = layGioHang();
            foreach (var item in listGioHang)
            {
                data.carts.DeleteOnSubmit(item); data.SubmitChanges();
            }
            if (Session["XNDH"] != null)
            {
                Session["XNDH"] = null;
                return RedirectToAction("XacnhanDonhang", "Home");
            }
            return RedirectToAction("GioHang");
        }

        //Lấy giỏ hàng của payment
        public List<CTHDlst> Layhoadon()
        {
            List<CTHDlst> lstChitiet = Session["CTHD"] as List<CTHDlst>;
            if (lstChitiet == null)
            {
                lstChitiet = new List<CTHDlst>();
                Session["CTHD"] = lstChitiet;
            }
            return lstChitiet;
        }

        //Đặt hàng 
        public ActionResult Dathang()
        {
            List<cart> listGioHang = layGioHang();
            List<CTHDlst> lsthd = Layhoadon();
            HOA_DON hd = new HOA_DON();
            hd.NgayDat = DateTime.Now;

            hd.MaKH = (Session["KhachHang"] as KhachHang).MaKH;
            hd.TongTienTT = (decimal)0;
            data.HOA_DONs.InsertOnSubmit(hd);
            data.SubmitChanges();
            Session["HoaDonTam"] = hd;
            return RedirectToAction("Paymentcart", "GioHang");


        }

        // Trang thanh toán của cart
        [HttpGet]
        public ActionResult Paymentcart()
        {
            if (Session["KhachHang"] == null || Session["KhachHang"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Account");
            }

            List<cart> listGioHang = layGioHang();
            ViewBag.TongHoaDon = tongGia();
            ViewBag.TongSoLuong = tongSoLuongSanPham();
            ViewBag.Gia1sp = Gia1sp();
            return View(listGioHang);
        }
        [HttpPost]
        public ActionResult Paymentcart(FormCollection collection)
        {
            List<cart> listGioHang = layGioHang();

            HOA_DON hd = (HOA_DON)Session["HoaDonTam"];

            cart listid = listGioHang.Find(l => l.MaKH == hd.MaKH);
            List<CTHDlst> lsthd = Layhoadon();
            if (listid != null)
            {
                foreach (cart g in listGioHang)
                {
                    ChiTietDonHang cthd = new ChiTietDonHang();
                    cthd.NgayMua = String.Format("{0:dd/MM/yyyy}", DateTime.Now).ToString();
                    cthd.MaHÐ = hd.MaHÐ;
                    cthd.ID_Sushi = g.ID_Sushi;
                    Sushi sp = data.Sushis.Single(n => n.ID_Sushi == g.ID_Sushi);
                    cthd.SoLuong = g.SoluongMua;
                    cthd.TongGia = sp.Gia * g.SoluongMua;
                    Session["SPDC"] = sp;
                    // Cập nhật số lượng
                    /*if (sp.SoLuong > 0)
                    {

                        sp.SLTruyCap = sp.SLTruyCap + g.SoluongMua; //Cập nhật độ HOT của sản phẩm
                        sp.SoLuong = sp.SoLuong - g.SoluongMua;
                        data.CT_HDs.InsertOnSubmit(cthd);
                        data.SubmitChanges();

                    }
                    else
                    {
                        ViewData["ErrorMuaHang"] = "Số lượng hàng không đủ";
                        return this.Paymentcart();
                    }*/
                    HOA_DON tongtt = data.HOA_DONs.SingleOrDefault(s => s.MaHÐ == hd.MaHÐ);
                    if (tongtt != null)
                    {
                        tongtt.ThanhToan = true;
                        tongtt.TongTienTT = tongtt.TongTienTT + cthd.TongGia;

                        data.SubmitChanges();
                    }
                }




            }
            Session["XNDH"] = "Ok";
            if (listid != null)
            {
                return RedirectToAction("XoaTatCaGioHang", "GioHang");
            }

            return RedirectToAction("XacnhanDonhang", "Home");
        }



        // Phần Mua ngay
        public ActionResult ChonSanPham(string idsanpham)
        {
            if (Session["KhachHang"] == null || Session["KhachHang"].ToString() == "")
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<CTHDlst> lsthd = Layhoadon();
                HOA_DON hd = new HOA_DON();
                hd.NgayDat = DateTime.Now;

                hd.MaKH = (Session["KhachHang"] as KhachHang).MaKH;
                hd.TongTienTT = (decimal)0;
                data.HOA_DONs.InsertOnSubmit(hd);
                data.SubmitChanges();

                HOA_DON tthd = data.HOA_DONs.SingleOrDefault(h => h.MaHÐ == hd.MaHÐ);
                int mahd = tthd.MaHÐ;
                Session["MaHD"] = tthd;
                CTHDlst sanpham = lsthd.Find(s => s.Mahd == mahd);
                if (sanpham == null)
                {
                    sanpham = new CTHDlst(idsanpham, mahd);
                    lsthd.Add(sanpham);
                    return RedirectToAction("Payment", "GioHang");
                }
                else
                {

                    return RedirectToAction("Payment", "GioHang");
                }
            }

        }

        [HttpGet]
        public ActionResult Payment()
        {
            if (Session["KhachHang"] == null || Session["KhachHang"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Account");
            }
            if (Session["CTHD"] == null || Session["CTHD"].ToString() == "")
            {
                return RedirectToAction("Index", "Home");
            }
            List<CTHDlst> lst = Layhoadon();
            ViewBag.TongHoaDon = tongGia();
            ViewBag.TongSoLuong = tongSoLuongSanPham();
            ViewBag.Gia1sp = Gia1sp();
            return View(lst);
        }
        [HttpPost]
        public ActionResult Payment(FormCollection collection)
        {
            List<cart> listGioHang = layGioHang();
            List<CTHDlst> lsthd = Layhoadon();

            foreach (var item in lsthd)
            {
                ChiTietDonHang cthd = new ChiTietDonHang();
                cthd.NgayMua = String.Format("{0:dd/MM/yyyy}", DateTime.Now).ToString();
                cthd.MaHÐ = item.Mahd;
                cthd.ID_Sushi = item.masp;
                cthd.SoLuong = item.iSoluong;
                cthd.TongGia = (decimal)item.tonggia;


                HOA_DON tongtt = data.HOA_DONs.SingleOrDefault(s => s.MaHÐ == item.Mahd);
                if (tongtt.TongTienTT == 0)
                {
                    tongtt.ThanhToan = true;
                    tongtt.TongTienTT = (decimal)item.tonggia;
                    data.SubmitChanges();
                }
                // Cập nhật số lượng

                /*Sushi slt = data.Sushis.Single(p => p.ID_Sushi == item.masp);
                if (slt.SoLuong > 0)
                {

                    //slt.SLTruyCap = slt.SLTruyCap + item.iSoluong;
                    slt.SoLuong = slt.SoLuong - item.iSoluong;
                    Session["SPDC"] = slt;
                    data.ChiTietDonHangs.InsertOnSubmit(cthd);
                    data.SubmitChanges();
                    //xóa list sau mỗi lần thanh toán, tránh bị lặp đồ trong lần thanh toán tiếp theo
                    lsthd.Clear();
                    return RedirectToAction("XacnhanDonhang", "Home");
                }
                else
                {
                    ViewData["ErrorMuaHang"] = "Số lượng hàng không đủ";
                    return this.Payment();
                }*/
            }
            data.SubmitChanges();
            Session["CTHD"] = null;
            //xóa list sau mỗi lần thanh toán, tránh bị lặp đồ trong lần thanh toán tiếp theo
            lsthd.Clear();
            return RedirectToAction("XacnhanDonhang", "Home");
        }

        //Hủy đơn hàng đang tạo
        public ActionResult HuyDonHang(int delid)
        {
            List<CTHDlst> lstGioHang = Layhoadon();
            CTHDlst sanpham = lstGioHang.SingleOrDefault(n => n.Mahd == delid);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.Mahd == delid);
                var D_sanpham = data.HOA_DONs.Where(m => m.MaHÐ == delid).First();
                data.HOA_DONs.DeleteOnSubmit(D_sanpham);
                data.SubmitChanges();
                lstGioHang.Clear();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}