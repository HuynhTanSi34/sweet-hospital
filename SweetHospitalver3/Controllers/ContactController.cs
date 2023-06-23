using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        HospitalDbContext db = new HospitalDbContext();
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(PHANHOI pHANHOI)
        {
            if (string.IsNullOrEmpty(pHANHOI.HoTen) == true)
            {
                ModelState.AddModelError("", "Chưa điền họ và tên nè bạn ơi!");
                return View(pHANHOI);
            }
            if (string.IsNullOrEmpty(pHANHOI.Sdt.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền số điện thoại nè bạn ơi!");
                return View(pHANHOI);
            }
            if (string.IsNullOrEmpty(pHANHOI.Email) == true)
            {
                ModelState.AddModelError("", "Chưa điền Email nè bạn ơi!");
                return View(pHANHOI);
            }
            if (string.IsNullOrEmpty(pHANHOI.NoiDung) == true)
            {
                ModelState.AddModelError("", "Chưa điền nội dung nè bạn ơi!");
                return View(pHANHOI);
            }
            pHANHOI.TrangThai = "Chưa trả lời";
            db.PHANHOI.Add(pHANHOI);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(pHANHOI.HoTen))
            {
                return RedirectToAction("Contact");
            }
            else
            {
                ModelState.AddModelError("", "Phản hồi thất bại");
                return View(pHANHOI);
            }
        }
    }
}