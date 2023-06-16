using sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace sushi.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private readonly DataClasses1DataContext data;

        public ProductsController()
        {
            string connectionString = "Data Source=JIN-592G\\SQLEXPRESS;Initial Catalog=DACS;Integrated Security=True";
            data = new DataClasses1DataContext(connectionString);
        }
        public ActionResult Index(int? page, string searchString)
        {
            var all_sanpham = from s in data.Sushis select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                all_sanpham = all_sanpham.Where(p => p.TenSushi.Contains(searchString));
            }

            /*ViewBag.LoaiSP = new SelectList(data.Loai_SPs, "Ma_Loai", "TenLoai");
            if (cateid != 0)
            {
                var sanpham_with_category = data.Loai_SPs.Where(s => s.Ma_Loai == cateid).FirstOrDefault();
                all_sanpham = all_sanpham.Where(p => p.Ma_Loai == sanpham_with_category.Ma_Loai);
            }

            if (page == null)
                page = 1;
            /* var all_book = (from Sach in data.Saches select Sach).OrderBy(m => m.masach);*/
            int pageSize = 16;
            int pageNum = page ?? 1;
            return View(all_sanpham.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, Sushi s, int cateid = 0, int idtypeSP = 0, int brandid = 0)
        {
            var E_masp = collection["ID_Sushi"];
            var E_tensp = collection["TenSushi"];
            var E_hinhsp = collection["Hinh"];
            var E_mota = collection["MoTa"];
            decimal E_giaban = Convert.ToDecimal(collection["Gia"]);
            var E_id = Convert.ToString(collection["ID"]);
            if (string.IsNullOrEmpty(E_masp))
            { 
                ViewData["Error"] = "Don't empty";
            }
            else
            {
                s.ID_Sushi = E_masp.ToString();
                s.TenSushi = E_tensp.ToString();
                s.Gia = E_giaban;
                s.MoTa = E_mota;
                s.Hinh = E_hinhsp.ToString();
                data.Sushis.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return Create(collection, s, cateid, idtypeSP, brandid);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/images" + file.FileName));
            return "/images" + file.FileName;
        }

        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_sanpham = data.Sushis.First(m => m.ID_Sushi == id);
            var E_masp = collection["ID_Sushi"];
            var E_tensp = collection["TenSushi"];
            var E_hinhsp = collection["Hinh"];
            var E_mota = collection["MoTa"];
            decimal E_giaban = Convert.ToDecimal(collection["Gia"]);
            var E_id = Convert.ToInt32(collection["ID"]);
            if (string.IsNullOrEmpty(E_masp))
            {
                ViewData["Error"] = "Don't empty";
            }
            else
            {
                E_sanpham.ID_Sushi = E_masp.ToString();
                E_sanpham.TenSushi = E_tensp.ToString();
                E_sanpham.Gia = E_giaban;
                E_sanpham.MoTa = E_mota.ToString();
                E_sanpham.Hinh = E_hinhsp.ToString();
                UpdateModel(E_sanpham);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return Edit(id, collection);
        }
        public ActionResult Delete(string id)
        {
            var D_Sach = data.Sushis.First(m => m.ID_Sushi == id);
            return View(D_Sach);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_Sach = data.Sushis.Where(m => m.ID_Sushi == id).First();
            data.Sushis.DeleteOnSubmit(D_Sach);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}