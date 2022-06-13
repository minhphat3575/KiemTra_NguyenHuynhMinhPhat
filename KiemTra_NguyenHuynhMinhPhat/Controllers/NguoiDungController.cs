using KiemTra_NguyenHuynhMinhPhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenHuynhMinhPhat.Controllers
{
    
    public class NguoiDungController : Controller
    {
        MydataDataContext data = new MydataDataContext();
        // GET: NguoiDung
    
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
           
            var MSSV = collection["MaSV"];
            var matkhau = collection["matkhau"];
            SinhVien s = data.SinhViens.SingleOrDefault(n => n.MaSV == MSSV && n.matkhau == matkhau);
            if(s != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                Session["TaiKhoan"] = s;
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập mật khẩu không đúng";
            }
            return RedirectToAction("listSinhVien", "Home");
        }
    }
}