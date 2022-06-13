using KiemTra_NguyenHuynhMinhPhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenHuynhMinhPhat.Controllers
{
    public class SinhVienController : Controller
    {
        MydataDataContext data = new MydataDataContext();
        // GET: SinhVien
        public ActionResult listSinhVien()
        {
            var all_SV = from ss in data.SinhViens select ss;
            return View(all_SV);
        }
        public ActionResult Details(string id)
        {
            SinhVien sv = data.SinhViens.SingleOrDefault(p => p.MaSV == id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            return View(sv);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_masv = collection["MaSV"];
            var E_tensinhvien = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);

            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];

            if (string.IsNullOrEmpty(E_tensinhvien))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = E_masv;
                s.HoTen = E_tensinhvien.ToString();
                s.GioiTinh = E_gioitinh.ToString();
                s.NgaySinh = E_ngaysinh;
                s.Hinh = E_hinh;
                s.MaNganh = E_manganh;
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("List");
            }
            return this.Create();
        }
        public ActionResult Delete(string id)
        {
            var D_sach = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sach = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("List");
        }
        public ActionResult Edit(string id)
        {
            var E_sach = data.SinhViens.First(m => m.MaSV == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_sach = data.SinhViens.First(m => m.MaSV == id);
            var E_tensinhvien = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];
            E_sach.MaSV = id;
            if (string.IsNullOrEmpty(E_tensinhvien))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sach.HoTen = E_tensinhvien.ToString();
                E_sach.GioiTinh = E_gioitinh.ToString();
                E_sach.NgaySinh = E_ngaysinh;
                E_sach.Hinh = E_hinh;
                E_sach.MaNganh = E_manganh;
                UpdateModel(E_sach);
                data.SubmitChanges();
                return RedirectToAction("listSinhVien");
            }
            return this.Edit(id);
        }
    }
}