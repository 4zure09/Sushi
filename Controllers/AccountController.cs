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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (true)
            {
                // Kiểm tra thông tin đăng nhập
                string tenDangNhap = collection["TenDangNhap"];
                string matKhau = collection["MatKhau"];
                var user = db.TaiKhoans.FirstOrDefault(u => u.TenDangNhap == tenDangNhap && u.MatKhau == matKhau);
                if (user != null)
                {
                    // Đăng nhập thành công, thực hiện các hành động khác, ví dụ: lưu thông tin người dùng vào session, cookie, ...
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin đăng nhập không chính xác.");
                }
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}