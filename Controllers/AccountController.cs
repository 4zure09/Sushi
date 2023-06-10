using sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace sushi.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly DataClasses1DataContext db;

        public AccountController()
        {
            string connectionString = "Data Source=JIN-592G\\SQLEXPRESS;Initial Catalog=DACS;Integrated Security=True";
            db = new DataClasses1DataContext(connectionString);
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();


        }
        [HttpPost]
        public ActionResult Register(FormCollection collection, TaiKhoan tk)
        {


            var tendangnhap = collection["TenDangNhap"];
            var matkhau = collection["MatKhau"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];

            if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["NhapMKXN"] = "Vui lòng nhập mật khẩu xác nhận";
            }
            else
            {
                if (!matkhau.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mật khẩu khác nhau quá bạn êiii!";
                }
                else
                {
                    TaiKhoan tkif = db.TaiKhoans.SingleOrDefault(i => i.TenDangNhap == tendangnhap);
                    if (tkif == null)
                    {
                        tk.TenDangNhap = tendangnhap;
                        tk.MatKhau = matkhau;
                        Session["DangKyTemp"] = tendangnhap;
                        db.TaiKhoans.InsertOnSubmit(tk);
                        db.SubmitChanges();
                        return RedirectToAction("DangKyThongTin");
                    }
                    else
                    {
                        ViewData["ErrorTaiKhoan"] = "Tài khoản đã được sử dụng";
                    }




                }
            }
            return this.Register();

        }
        public ActionResult DangKyThongTin()
        {

            return View();


        }
        [HttpPost]
        public ActionResult DangKyThongTin(FormCollection collection, KhachHang kh)
        {

            var hoten = collection["HoTenKH"];
            var tendangnhap = Session["DangKyTemp"].ToString();

            var email = collection["Email"];
            var diachi = collection["DiaChi"];
            var dienthoai = collection["SDT"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            if (String.IsNullOrEmpty(tendangnhap))
            {
                ViewData["error"] = "Error!!!";
            }
            else
            {
                KhachHang khif = db.KhachHangs.SingleOrDefault(c => c.SDT == dienthoai);
                if (khif == null)
                {
                    kh.MaKH = "KH" + dienthoai;
                    kh.HoTenKH = hoten;
                    kh.TenDangNhap = Session["DangKyTemp"].ToString();
                    kh.Email = email;

                    kh.DiaChi = diachi;
                    kh.SDT = dienthoai;

                    db.KhachHangs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewData["ErrorNum"] = "Số điện thoại đã được sử dụng";
                }



            }
            return this.DangKyThongTin();

        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var username = collection["TenDangNhap"];
            var matkhau = collection["MatKhau"];
            TaiKhoan kh = db.TaiKhoans.SingleOrDefault(h => h.TenDangNhap == username && h.MatKhau == matkhau);
            if (kh != null)
            {
                NhanVien nv = db.NhanViens.SingleOrDefault(n => n.TenDangNhap == username);
                if (nv != null)
                {
                    ViewBag.NhanVien = "Chào mừng trở lại";
                    Session["NhanVien"] = nv;

                    if (nv.MaCV.Contains("NV") == true) //So sánh chuỗi MaCV có chữ NV hay không, nếu đúng ( true ) thì trả về
                    {
                        Session["NhanVienCapThap"] = nv.MaCV;

                    }
                    else //Nếu không, ngược lại
                    {
                        Session["NhanVienCapCao"] = nv.MaCV;

                    }


                    /*Session["ChucVu"] = nv.MaCV;*/

                    //Chuyển qua trang admin, thay Index với Products bằng Thống kê của trang Admin
                    return RedirectToAction("ThongKe", "ThongKe");
                }
                else
                {
                    ViewBag.ThongBao = "Vô mua luôn thôi bạn êii";
                    KhachHang i = db.KhachHangs.SingleOrDefault(log => log.TenDangNhap == username);
                    Session["KhachHang"] = i;
                    Session["TaiKhoan"] = i.MaKH;
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ViewData["LoiDangNhap"] = "Tên đăng nhập hoặc mật khẩu không đúng";
            }

            return this.Login();
        }

        public ActionResult DangXuat()
        {
            List<CTHDlst> lstChitiet = Session["CTHD"] as List<CTHDlst>;
            if (lstChitiet != null)
            {
                lstChitiet.Clear();
            }
            Session["KhachHang"] = null;
            Session["NhanVien"] = null;
            Session["CTHD"] = null;
            Session["MaHD"] = null;
            Session["HoaDonTam"] = null;
            Session["NhanVienCapCao"] = null;
            Session["NhanVienCapThap"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ThongTin(string taikhoan)
        {

            var all_info = from i in db.KhachHangs select i;
            all_info = all_info.Where(s => s.MaKH == taikhoan);

            return View(all_info);
        }
        public ActionResult Index()
        {

            return View();
        }
    }
}