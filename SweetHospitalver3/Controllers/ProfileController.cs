using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Profile()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Profilerecordinfor(string MaHS)
        {
            HOSO hOSO = db.HOSO.Find(MaHS);
            return View(hOSO);
        }
        [HttpGet]
        public ActionResult Profilerecordadd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Profilerecordadd(HOSO hOSO)
        {
            if (string.IsNullOrEmpty(hOSO.HoTen) == true)
            {
                ModelState.AddModelError("", "Chưa điền họ và tên nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.NgaySinh.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền ngày sinh nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.Sdt.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền số điện thoại nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.GioiTinh) == true)
            {
                ModelState.AddModelError("", "Chưa chọn giới tính nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.NgheNghiep) == true)
            {
                ModelState.AddModelError("", "Chưa điền nghề nghiệp nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.CCCD.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền CCCD nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.Email) == true)
            {
                ModelState.AddModelError("", "Chưa điền Email nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.DanToc) == true)
            {
                ModelState.AddModelError("", "Chưa chọn dân tộc nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.DiaChi) == true)
            {
                ModelState.AddModelError("", "Chưa điền địa chỉ nè bạn ơi!");
                return View(hOSO);
            }
            hOSO.TK = "Hayetop";
            hOSO.MaHS = "haop";
            db.HOSO.Add(hOSO);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(hOSO.MaHS))
            {
                return RedirectToAction("Profile");
            }
            else
            {
                ModelState.AddModelError("", "Cấp số thất bại");
                return View(hOSO);
            }
        }
    }
}