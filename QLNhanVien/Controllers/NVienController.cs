using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNhanVien.Models;

namespace QLNhanVien.Controllers
{
    public class NVienController : Controller
    {
        // GET: NVien
        Model1 db = new Model1();
        [HttpGet]
        public ActionResult Index()
        {
            var query = db.NhanViens.Select(p => p);
            return View(query);
        }
        [HttpGet]
        public ActionResult ChiTiet(String id)
        {
            var query = db.NhanViens.Where(p => p.Manv == id).First();
            return View(query);
        }
        [HttpGet]
        public ActionResult Them()
        {
            ViewData["Phong"] = new SelectList(db.Phongs, "MaPhong", "TenPhong");
            return View();
        }
        [HttpPost]
        public ActionResult Them(FormCollection f,NhanVien nv)
        {
            var ma = f["Manv"];
            var ten = f["Hoten"];
            var phong = f["Phong"];
            var luong = f["Luong"];
            if (String.IsNullOrEmpty(ma))
            {
                ViewData["Loi1"] = "Ma nhan vien khong duoc de trong!";
            }else if (String.IsNullOrEmpty(ten))
            {
                ViewData["Loi2"] = "Ho ten khong duoc de trong!";
            }else if(String.IsNullOrEmpty(luong)){
                ViewData["Loi3"] = "Luong khong duoc de trong!";
            }
            else
            {
                nv.Manv = ma;
                nv.Hoten = ten;
                nv.Maphong = phong;
                nv.Luong = Convert.ToDouble(luong);
                db.NhanViens.Add(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Them();
        }
    }
}