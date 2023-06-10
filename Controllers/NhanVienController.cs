using sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace sushi.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly DataClasses1DataContext data;

        public NhanVienController()
        {
            string connectionString = "Data Source=JIN-592G\\SQLEXPRESS;Initial Catalog=DACS;Integrated Security=True";
            data = new DataClasses1DataContext(connectionString);
        }
        public ActionResult Index(int? page, string searchString, int cateid = 0)
        {
            var all_sanpham = from s in data.NhanViens select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                all_sanpham = all_sanpham.Where(p => p.HoTen.Contains(searchString));
            }

            ViewBag.ChucVuNV = new SelectList(data.CHUC_VUs, "MaCV", "ChucVu");


            if (page == null)
                page = 1;
            /* var all_book = (from Sach in data.Saches select Sach).OrderBy(m => m.masach);*/
            int pageSize = 16;
            int pageNum = page ?? 1;
            return View(all_sanpham.ToPagedList(pageNum, pageSize));
        }
        // GET: NhanVien
        public ActionResult Create()
        {
            ViewBag.ChucVu = new SelectList(data.CHUC_VUs, "MaCV", "ChucVU");

            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, NhanVien s, string catecvid)
        {
            var E_manv = collection["MaNV"];
            var E_tennv = collection["HoTen"];
            var E_useraccount = collection["TenDangNhapTK"];
            var E_SDT = collection["SDT"];
            var E_diachi = collection["DiaChi"];
            var E_email = collection["Email"];

            if (string.IsNullOrEmpty(E_manv))
            {
                ViewData["Error"] = "Don't empty";
            }
            else if (catecvid != null)
            {
                s.MaNV = E_manv.ToString();
                s.MaCV = catecvid;

                var user = data.TaiKhoans.SingleOrDefault(e => e.TenDangNhap == E_useraccount);
                if (user == null)
                {
                    TaiKhoan dktk = new TaiKhoan();
                    dktk.TenDangNhap = E_useraccount.ToString();
                    dktk.MatKhau = "123";
                    data.TaiKhoans.InsertOnSubmit(dktk);
                    data.SubmitChanges();
                }

                s.TenDangNhap = E_useraccount;
                s.HoTen = E_tennv.ToString();
                s.SDT = E_SDT;
                s.Email = E_email;
                s.DiaChi = E_diachi;

                data.NhanViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }

        public ActionResult Edit(string id)
        {

            var D_sanpham = data.NhanViens.Where(m => m.MaNV.StartsWith(id)).First();
            return View(D_sanpham);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_nv = data.NhanViens.First(m => m.MaNV == id);

            var E_tennv = collection["HoTen"];
            var E_pass = collection["MatKhau"];
            var E_SDT = collection["SDT"];
            var E_diachi = collection["DiaChi"];
            var E_email = collection["Email"];
            var E_manv = E_nv.MaNV;
            if (string.IsNullOrEmpty(E_manv))
            {
                ViewData["Error"] = "Don't empty";
            }
            else
            {
                E_nv.HoTen = E_tennv;
                TaiKhoan tk = data.TaiKhoans.SingleOrDefault(s => s.TenDangNhap == E_nv.TenDangNhap);
                if (tk != null)
                {
                    tk.MatKhau = E_pass;
                    data.SubmitChanges();
                }
                E_nv.DiaChi = E_diachi;
                E_nv.SDT = E_SDT;
                E_nv.Email = E_email;
                UpdateModel(E_nv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(string id)
        {
            var D_Sach = data.NhanViens.First(m => m.MaNV == id);
            return View(D_Sach);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_Sach = data.NhanViens.Where(m => m.MaNV == id).First();
            data.NhanViens.DeleteOnSubmit(D_Sach);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}